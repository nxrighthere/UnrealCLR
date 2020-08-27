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
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using UnrealEngine.Plugins;

namespace UnrealEngine.Runtime {
	internal enum LogLevel : int {
		Display,
		Warning,
		Error,
		Fatal
	}

	internal unsafe struct Argument {
		internal fixed byte data[16];
	}

	internal delegate int InitializeDelegate(IntPtr functions, int checksum);

	internal sealed class Plugin {
		internal PluginLoader loader;
		internal Assembly assembly;
		internal Dictionary<int, IntPtr> userFunctions;
	}

	internal sealed class AssembliesContextManager  {
		internal AssemblyLoadContext assembliesContext;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal WeakReference CreateAssembliesContext() {
			assembliesContext = new AssemblyLoadContext("UnrealEngine", true);

			return new WeakReference(assembliesContext, trackResurrection: true);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void UnloadAssembliesContext() => assembliesContext?.Unload();
	}

	internal static class Core {
		// Managed functionality

		internal delegate void InvokeDelegate(IntPtr managedFunction, Argument value);
		internal delegate void ExceptionDelegate(string message);
		internal delegate void LogDelegate(LogLevel level, string message);

		internal static AssembliesContextManager assembliesContextManager;
		internal static WeakReference assembliesContextWeakReference;
		internal static Plugin plugin;
		internal static IntPtr sharedEvents;
		internal static IntPtr sharedFunctions;
		internal static int sharedChecksum;

		internal static InvokeDelegate Invoke;
		internal static ExceptionDelegate Exception;
		internal static LogDelegate Log;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static unsafe int Initialize(IntPtr functions, int checksum) {
			try {
				assembliesContextManager = new AssembliesContextManager();
				assembliesContextWeakReference = assembliesContextManager.CreateAssembliesContext();

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

					nativeFunctions[head++] = typeof(Core).GetMethod("ExecuteManagedFunction", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle.GetFunctionPointer();
					nativeFunctions[head++] = typeof(Core).GetMethod("FindManagedFunction", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle.GetFunctionPointer();
					nativeFunctions[head++] = typeof(Core).GetMethod("LoadAssemblies", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle.GetFunctionPointer();
					nativeFunctions[head++] = typeof(Core).GetMethod("UnloadAssemblies", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle.GetFunctionPointer();
				}

				sharedEvents = buffer[position++];
				sharedFunctions = buffer[position++];
				sharedChecksum = checksum;
			}

			catch (Exception exception) {
				Exception("Runtime initialization failed\r\n" + exception.ToString());
			}

			return 0xF;
		}

		// Native functionality

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ExecuteManagedFunction(IntPtr managedFunction, Argument value) {
			try {
				Invoke(managedFunction, value);
			}

			catch (Exception exception) {
				Exception(exception.ToString());
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr FindManagedFunction(IntPtr methodPointer, int optional) {
			IntPtr function = IntPtr.Zero;

			try {
				string method = Marshal.PtrToStringAuto(methodPointer);

				if (plugin != null && !plugin.userFunctions.TryGetValue(method.GetHashCode(StringComparison.CurrentCulture), out function) && optional != 1)
					Log(LogLevel.Error, "Managed function was not found \"" + method + "\"");
			}

			catch (Exception exception) {
				Exception(exception.ToString());
			}

			return function;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void LoadAssemblies() {
			try {
				const string frameworkName = "UnrealEngine.Framework";
				string assemblyPath = Assembly.GetExecutingAssembly().Location;
				string managedFolder = assemblyPath.Substring(0, assemblyPath.IndexOf("Plugins", StringComparison.CurrentCulture)) + "Managed";
				string[] folders = Directory.GetDirectories(managedFolder);

				Array.Resize(ref folders, folders.Length + 1);

				folders[folders.Length - 1] = managedFolder;

				foreach (string folder in folders) {
					IEnumerable<string> assemblies = Directory.EnumerateFiles(folder, "*.dll", SearchOption.AllDirectories);

					foreach (string assembly in assemblies) {
						AssemblyName name = null;

						try {
							name = AssemblyName.GetAssemblyName(assembly);
						}

						catch (BadImageFormatException) {
							continue;
						}

						if (name?.Name != frameworkName) {
							plugin = new Plugin();
							plugin.loader = PluginLoader.CreateFromAssemblyFile(assembly, config => { config.DefaultContext = assembliesContextManager.assembliesContext; config.IsUnloadable = true; });
							plugin.assembly = plugin.loader.LoadAssemblyFromPath(assembly);

							AssemblyName[] referencedAssemblies = plugin.assembly.GetReferencedAssemblies();

							foreach (AssemblyName referencedAssembly in referencedAssemblies) {
								if (referencedAssembly.Name == frameworkName) {
									Assembly framework = plugin.loader.LoadAssembly(referencedAssembly);

									using (assembliesContextManager.assembliesContext.EnterContextualReflection()) {
										Type sharedClass = framework.GetType(frameworkName + ".Shared");

										if ((int)sharedClass.GetField("checksum", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null) == sharedChecksum) {
											plugin.userFunctions = (Dictionary<int, IntPtr>)sharedClass.GetMethod("Load", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { sharedEvents, sharedFunctions, plugin.assembly });

											Log(LogLevel.Display, "Framework loaded succesfuly for " + assembly);
										} else {
											Log(LogLevel.Fatal, "Framework loading failed, version is incompatible with the runtime, please, recompile the project with an updated version referenced in " + assembly);
										}
									}

									return;
								}
							}

							UnloadAssemblies();
						}
					}
				}
			}

			catch (Exception exception) {
				Exception("Loading of assemblies failed\r\n" + exception.ToString());
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void UnloadAssemblies() {
			try {
				plugin?.loader.Dispose();
				plugin = null;

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
				assembliesContextWeakReference = assembliesContextManager.CreateAssembliesContext();
			}

			catch (Exception exception) {
				Exception("Unloading of assemblies failed\r\n" + exception.ToString());
			}
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
