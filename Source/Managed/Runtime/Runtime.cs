/*
 * Copyright (c) 2020 Stanislav Denisov (nxrighthere@gmail.com)
 *
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the GNU Lesser General Public License
 * (LGPL) version 3 with a static linking exception which accompanies this
 * distribution.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
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
		Error,
		Fatal
	}

	internal delegate int InitializeDelegate(IntPtr functions, int checksum);

	internal sealed class Plugin {
		internal PluginLoader loader;
		internal Assembly assembly;
	}

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
				Invoke(managedFunction);
			}

			catch (Exception exception) {
				Exception(exception.ToString());
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr LoadAssemblyFunction(IntPtr assemblyPathPointer, IntPtr typeNamePointer, IntPtr methodNamePointer, bool optional) {
			Type type = null;
			MethodInfo method = null;
			Plugin plugin = null;
			bool loaded = false;
			string assemblyPath = Marshal.PtrToStringAuto(assemblyPathPointer);
			string typeName = Marshal.PtrToStringAuto(typeNamePointer);
			string methodName = Marshal.PtrToStringAuto(methodNamePointer);

			try {
				int assemblyHash = assemblyPath.GetHashCode();

				if (plugins.TryGetValue(assemblyHash, out plugin)) {
					loaded = true;
				} else {
					plugin = new Plugin();
					plugin.loader = PluginLoader.CreateFromAssemblyFile(assemblyPath, config => { config.DefaultContext = assembliesContextManager.assembliesContext; config.IsUnloadable = true; });
					plugin.assembly = plugin.loader.LoadAssemblyFromPath(assemblyPath);
					plugins.Add(assemblyHash, plugin);
				}

				type = plugin.assembly.GetType(typeName);
				method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
			}

			catch (Exception exception) {
				if (!optional) {
					if (typeName.Length == 0 || methodName.Length == 0) {
						Exception("Type or method names can not be empty to load assembly function from \"" + assemblyPath + "\"\r\n" + exception.ToString());

						return IntPtr.Zero;
					}

					Exception("Unable to load assembly function in \"" + assemblyPath + "\" of type name \"" + typeName + "\" with method name \"" + methodName + "\"\r\n" + exception.ToString());
				}

				return IntPtr.Zero;
			}

			if (method == null) {
				if (!optional)
					Log(LogLevel.Error, "Unable to find assembly function in \"" + assemblyPath + "\" of type name \"" + typeName + "\" with method name \"" + methodName + "\"");

				return IntPtr.Zero;
			}

			if (!loaded) {
				AssemblyName[] referencedAssemblies = plugin.assembly.GetReferencedAssemblies();

				foreach (AssemblyName referencedAssembly in referencedAssemblies) {
					if (referencedAssembly.Name == "UnrealEngine.Framework") {
						Assembly frameworkAssembly = plugin.loader.LoadAssembly(referencedAssembly);

						using (assembliesContextManager.assembliesContext.EnterContextualReflection()) {
							Type sharedClass = frameworkAssembly.GetType("UnrealEngine.Framework.Shared");

							if ((bool)sharedClass.GetField("loaded", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null) == false) {
								if ((int)sharedClass.GetField("checksum", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null) == sharedChecksum)
									sharedClass.GetMethod("Load", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { sharedFunctions });
								else
									Log(LogLevel.Fatal, "Unable to load framework from \"" + assemblyPath + "\" of type name \"" + typeName + "\" with method name \"" + methodName + "\"\r\nFramework version is incompatible with the runtime, recompile the project with an updated version");
							}
						}

						break;
					}
				}
			}

			return method.MethodHandle.GetFunctionPointer();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void UnloadAssemblies() {
			try {
				foreach (KeyValuePair<int, Plugin> plugin in plugins) {
					plugin.Value.loader.Dispose();
				}

				plugins.Clear();

				assembliesContextManager.UnloadAssembliesContext();
				assembliesContextManager = null;

				uint unloadAttempts = 0;

				while (assembliesContextWeakReference.IsAlive) {
					GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
					GC.WaitForPendingFinalizers();

					unloadAttempts++;

					if (unloadAttempts == 5000) {
						Log(LogLevel.Warning, "Unloading of assemblies took more time than expected. Trying to unload assemblies to the next breakpoint...");
					} else if (unloadAttempts == 10000) {
						Log(LogLevel.Error, "Unloading of assemblies was failed! This might be caused by running threads, strong GC handles, or by other sources that prevent cooperative unloading.");

						break;
					}
				}

				assembliesContextManager = new AssembliesContextManager();
				assembliesContextManager.CreateAssembliesContext();
			}

			catch (Exception exception) {
				Exception("Unloading of assemblies was finished incorrectly\r\n" + exception.ToString());
			}
		}

		// Managed functionality

		internal delegate void InvokeDelegate(IntPtr managedFunction);
		internal delegate void ExceptionDelegate(string message);
		internal delegate void LogDelegate(LogLevel level, string message);

		internal static AssembliesContextManager assembliesContextManager;
		internal static WeakReference assembliesContextWeakReference;
		internal static Dictionary<int, Plugin> plugins;
		internal static IntPtr sharedFunctions;
		internal static int sharedChecksum;

		internal static InvokeDelegate Invoke;
		internal static ExceptionDelegate Exception;
		internal static LogDelegate Log;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static unsafe int Initialize(IntPtr functions, int checksum) {
			try {
				assembliesContextManager = new AssembliesContextManager();
				assembliesContextManager.CreateAssembliesContext();

				plugins = new Dictionary<int, Plugin>();

				int position = 0;
				IntPtr* buffer = (IntPtr*)functions;

				unchecked {
					int head = 0;
					IntPtr* managedFunctions = (IntPtr*)buffer[position++];

					Invoke = GenerateOptimizedFunction<InvokeDelegate>(managedFunctions[head++]);
					Exception = GenerateOptimizedFunction<ExceptionDelegate>(managedFunctions[head++]);
					Log = GenerateOptimizedFunction<LogDelegate>(managedFunctions[head++]);
				}

				unchecked {
					int head = 0;
					IntPtr* nativeFunctions = (IntPtr*)buffer[position++];

					nativeFunctions[head++] = typeof(Core).GetMethod("ExecuteAssemblyFunction", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle.GetFunctionPointer();
					nativeFunctions[head++] = typeof(Core).GetMethod("LoadAssemblyFunction", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle.GetFunctionPointer();
					nativeFunctions[head++] = typeof(Core).GetMethod("UnloadAssemblies", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle.GetFunctionPointer();
				}

				sharedFunctions = buffer[position++];
				sharedChecksum = checksum;
			}

			catch (Exception exception) {
				Exception(exception.ToString());
			}

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