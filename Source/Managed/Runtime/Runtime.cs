/*
 *  Copyright (c) 2020 Stanislav Denisov (nxrighthere@gmail.com)
 *
 *  Permission to use, copy, modify, and/or distribute this software free of
 *  charge is hereby granted, provided that the above copyright notice and this
 *  permission notice appear in all copies or portions of this software with
 *  respect to the following terms and conditions:
 *
 *  1. Without specific prior written permission of the copyright holder,
 *  this software is forbidden for rebranding, sublicensing, and the exploitation
 *  to get payments in any form.
 *
 *  2. In accordance with DMCA (Digital Millennium Copyright Act), the copyright
 *  holder reserves exclusive permission to take down at any time any publicly
 *  available copy of this software in the original, partial, or modified form.
 *
 *  3. Any modifications that were made by third-parties to this software or its
 *  portions can be used by the copyright holder for any purposes, without any
 *  limiting factors and restrictions.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
 *  WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
 *  MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
 *  ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
 *  WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION
 *  OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN
 *  CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Threading;
using UnrealEngine.Plugins;

namespace UnrealEngine.Runtime {
	internal enum LogLevel : int {
		Display,
		Warning,
		Error
	}

	internal delegate int InitializeDelegate(IntPtr managedFunctionsBuffer, IntPtr nativeFunctionsBuffer, IntPtr sharedFunctionsBuffer);

	internal sealed class AssembliesContextManager  {
		internal AssemblyLoadContext assembliesContext;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void CreateAssembliesContext() {
			assembliesContext = new AssemblyLoadContext("UnrealEngine", true);

			Core.assembliesContextWeakReference = new WeakReference(assembliesContext, trackResurrection: true);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void UnloadAssembliesContext() => assembliesContext?.Unload();
	}

	internal static class Core {
		// Native functionality

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ExecuteAssemblyFunction(IntPtr managedFunction) {
			try {
				Core.Invoke(managedFunction);
			}

			catch (Exception exception) {
				Core.Exception(exception.ToString());
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr LoadAssemblyFunction(IntPtr assemblyPathPointer, IntPtr typeNamePointer, IntPtr methodNamePointer, bool optional) {
			Type type = null;
			MethodInfo method = null;
			PluginLoader pluginLoader = null;
			string assemblyPath = Marshal.PtrToStringAuto(assemblyPathPointer);
			string typeName = Marshal.PtrToStringAuto(typeNamePointer);
			string methodName = Marshal.PtrToStringAuto(methodNamePointer);

			try {
				int assemblyHash = assemblyPath.GetHashCode();

				if (!pluginLoaders.TryGetValue(assemblyHash, out pluginLoader)) {
					pluginLoader = PluginLoader.CreateFromAssemblyFile(assemblyPath, config => { config.DefaultContext = assembliesContextManager.assembliesContext; config.IsUnloadable = true; });
					pluginLoaders.Add(assemblyHash, pluginLoader);
				}

				type = pluginLoader.LoadDefaultAssembly().GetType(typeName);
				method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
			}

			catch (Exception exception) {
				if (!optional) {
					if (typeName.Length == 0 || methodName.Length == 0) {
						Core.Exception("Type or method names can not be empty to load assembly function from \"" + assemblyPath + "\"\r\n" + exception.ToString());

						return IntPtr.Zero;
					}

					Core.Exception("Unable to load assembly function in \"" + assemblyPath + "\" of type name \"" + typeName + "\" with method name \"" + methodName + "\"\r\n" + exception.ToString());
				}

				return IntPtr.Zero;
			}

			if (method == null) {
				if (!optional)
					Core.Log(LogLevel.Error, "Unable to find assembly function in \"" + assemblyPath + "\" of type name \"" + typeName + "\" with method name \"" + methodName + "\"");

				return IntPtr.Zero;
			}

			foreach (AssemblyName referencedAssembly in Assembly.GetAssembly(type).GetReferencedAssemblies()) {
				if (referencedAssembly.Name == "UnrealEngine.Framework") {
					Assembly frameworkAssembly = pluginLoader.LoadAssembly(referencedAssembly);

					using (assembliesContextManager.assembliesContext.EnterContextualReflection()) {
						Type sharedClass = frameworkAssembly.GetType("UnrealEngine.Framework.Shared");

						if ((bool)sharedClass.GetField("loaded", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null) == false)
							sharedClass.GetMethod("Load", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { sharedFunctions });
					}

					break;
				}
			}

			return method.MethodHandle.GetFunctionPointer();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void UnloadAssemblies() {
			try {
				foreach (KeyValuePair<int, PluginLoader> pluginLoader in pluginLoaders) {
					pluginLoader.Value.Dispose();
				}

				pluginLoaders.Clear();

				assembliesContextManager.UnloadAssembliesContext();
				assembliesContextManager = null;

				uint unloadAttempts = 0;

				while (assembliesContextWeakReference.IsAlive) {
					GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
					GC.WaitForPendingFinalizers();

					unloadAttempts++;

					if (unloadAttempts == 5000) {
						Core.Log(LogLevel.Warning, "Unloading of assemblies took more time than expected. Trying to unload assemblies to the next breakpoint...");
					} else if (unloadAttempts == 10000) {
						Core.Log(LogLevel.Error, "Unloading of assemblies was failed! This might be caused by running threads, strong GC handles, or by other sources that prevent cooperative unloading.");

						break;
					}
				}

				assembliesContextManager = new AssembliesContextManager();
				assembliesContextManager.CreateAssembliesContext();
			}

			catch (Exception exception) {
				Core.Exception("Unloading of assemblies was finished incorrectly\r\n" + exception.ToString());
			}
		}

		// Managed functionality

		internal delegate void InvokeDelegate(IntPtr managedFunction);
		internal delegate void ExceptionDelegate(string message);
		internal delegate void LogDelegate(LogLevel level, string message);

		internal static AssembliesContextManager assembliesContextManager;
		internal static WeakReference assembliesContextWeakReference;
		internal static Dictionary<int, PluginLoader> pluginLoaders;
		internal static IntPtr sharedFunctions;

		internal static InvokeDelegate Invoke;
		internal static ExceptionDelegate Exception;
		internal static LogDelegate Log;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static unsafe int Initialize(IntPtr managedFunctionsBuffer, IntPtr nativeFunctionsBuffer, IntPtr sharedFunctionsBuffer) {
			assembliesContextManager = new AssembliesContextManager();
			assembliesContextManager.CreateAssembliesContext();

			pluginLoaders = new Dictionary<int, PluginLoader>();

			unchecked {
				int head = 0;
				IntPtr* managedFunctions = (IntPtr*)managedFunctionsBuffer;

				Invoke = GenerateOptimizedFunction<InvokeDelegate>(managedFunctions[head++]);
				Exception = GenerateOptimizedFunction<ExceptionDelegate>(managedFunctions[head++]);
				Log = GenerateOptimizedFunction<LogDelegate>(managedFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* nativeFunctions = (IntPtr*)nativeFunctionsBuffer;

				nativeFunctions[head++] = typeof(Core).GetMethod("ExecuteAssemblyFunction", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle.GetFunctionPointer();
				nativeFunctions[head++] = typeof(Core).GetMethod("LoadAssemblyFunction", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle.GetFunctionPointer();
				nativeFunctions[head++] = typeof(Core).GetMethod("UnloadAssemblies", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle.GetFunctionPointer();
			}

			sharedFunctions = sharedFunctionsBuffer;

			return 0xF;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static TDelegate GenerateOptimizedFunction<TDelegate>(IntPtr pointer) where TDelegate : class {
			Type type = typeof(TDelegate);
			MethodInfo method = type.GetMethod("Invoke");
			ParameterInfo[] parameterInfos = method.GetParameters();
			Type[] parameterTypes = new Type[parameterInfos.Length];

			for (int i = 0; i < parameterTypes.Length; i++) {
				parameterTypes[i] = parameterInfos[i].ParameterType;
			}

			DynamicMethod dynamicMethod = new DynamicMethod(method.Name, method.ReturnType, parameterTypes, Assembly.GetExecutingAssembly().ManifestModule);
			ILGenerator generator = dynamicMethod.GetILGenerator();

			for (int i = 0; i < parameterTypes.Length; i++) {
				generator.Emit(OpCodes.Ldarg, i);
			}

			generator.Emit(OpCodes.Ldc_I8, pointer.ToInt64());
			generator.Emit(OpCodes.Conv_I);
			generator.EmitCalli(OpCodes.Calli, CallingConvention.Cdecl, method.ReturnType, parameterTypes);
			generator.Emit(OpCodes.Ret);

			return dynamicMethod.CreateDelegate(type) as TDelegate;
		}
	}
}