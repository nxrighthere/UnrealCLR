/*
 *  Unreal Engine .NET 5 integration 
 *  Copyright (c) 2021 Stanislav Denisov
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *  SOFTWARE.
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace UnrealEngine.Framework {
	// Automatically generated

	internal static class Shared {
		internal const int checksum = 0x2D0;
		internal static Dictionary<int, IntPtr> userFunctions = new();
		private const string dynamicTypesAssemblyName = "UnrealEngine.DynamicTypes";
		private static readonly ModuleBuilder moduleBuilder = AssemblyBuilder.DefineDynamicAssembly(new(dynamicTypesAssemblyName), AssemblyBuilderAccess.RunAndCollect).DefineDynamicModule(dynamicTypesAssemblyName);
		private static readonly Type[] delegateCtorSignature = { typeof(object), typeof(IntPtr) };
		private static Dictionary<string, Delegate> delegatesCache = new();
		private static Dictionary<string, Type> delegateTypesCache = new();
		private const MethodAttributes ctorAttributes = MethodAttributes.RTSpecialName | MethodAttributes.HideBySig | MethodAttributes.Public;
		private const MethodImplAttributes implAttributes = MethodImplAttributes.Runtime | MethodImplAttributes.Managed;
		private const MethodAttributes invokeAttributes = MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual;
		private const TypeAttributes delegateTypeAttributes = TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.AnsiClass | TypeAttributes.AutoClass;

		internal static unsafe Dictionary<int, IntPtr> Load(IntPtr* events, IntPtr functions, Assembly pluginAssembly) {
			int position = 0;
			IntPtr* buffer = (IntPtr*)functions;

			unchecked {
				int head = 0;
				IntPtr* assertFunctions = (IntPtr*)buffer[position++];

				Assert.outputMessage = (delegate* unmanaged[Cdecl]<byte[], void>)assertFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* commandLineFunctions = (IntPtr*)buffer[position++];

				CommandLine.get = (delegate* unmanaged[Cdecl]<byte[], void>)commandLineFunctions[head++];
				CommandLine.set = (delegate* unmanaged[Cdecl]<string, void>)commandLineFunctions[head++];
				CommandLine.append = (delegate* unmanaged[Cdecl]<string, void>)commandLineFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* debugFunctions = (IntPtr*)buffer[position++];

				Debug.log = (delegate* unmanaged[Cdecl]<LogLevel, byte[], void>)debugFunctions[head++];
				Debug.exception = (delegate* unmanaged[Cdecl]<byte[], void>)debugFunctions[head++];
				Debug.addOnScreenMessage = (delegate* unmanaged[Cdecl]<int, float, int, byte[], void>)debugFunctions[head++];
				Debug.clearOnScreenMessages = (delegate* unmanaged[Cdecl]<void>)debugFunctions[head++];
				Debug.drawBox = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, in Quaternion, int, Bool, float, byte, float, void>)debugFunctions[head++];
				Debug.drawCapsule = (delegate* unmanaged[Cdecl]<in Vector3, float, float, in Quaternion, int, Bool, float, byte, float, void>)debugFunctions[head++];
				Debug.drawCone = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, float, float, float, int, int, Bool, float, byte, float, void>)debugFunctions[head++];
				Debug.drawCylinder = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, float, int, int, Bool, float, byte, float, void>)debugFunctions[head++];
				Debug.drawSphere = (delegate* unmanaged[Cdecl]<in Vector3, float, int, int, Bool, float, byte, float, void>)debugFunctions[head++];
				Debug.drawLine = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, int, Bool, float, byte, float, void>)debugFunctions[head++];
				Debug.drawPoint = (delegate* unmanaged[Cdecl]<in Vector3, float, int, Bool, float, byte, void>)debugFunctions[head++];
				Debug.flushPersistentLines = (delegate* unmanaged[Cdecl]<void>)debugFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* objectFunctions = (IntPtr*)buffer[position++];

				Object.isPendingKill = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)objectFunctions[head++];
				Object.isValid = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)objectFunctions[head++];
				Object.load = (delegate* unmanaged[Cdecl]<ObjectType, string, IntPtr>)objectFunctions[head++];
				Object.rename = (delegate* unmanaged[Cdecl]<IntPtr, string, void>)objectFunctions[head++];
				Object.invoke = (delegate* unmanaged[Cdecl]<IntPtr, byte[], Bool>)objectFunctions[head++];
				Object.toActor = (delegate* unmanaged[Cdecl]<IntPtr, ActorType, IntPtr>)objectFunctions[head++];
				Object.toComponent = (delegate* unmanaged[Cdecl]<IntPtr, ComponentType, IntPtr>)objectFunctions[head++];
				Object.getID = (delegate* unmanaged[Cdecl]<IntPtr, uint>)objectFunctions[head++];
				Object.getName = (delegate* unmanaged[Cdecl]<IntPtr, byte[], void>)objectFunctions[head++];
				Object.getBool = (delegate* unmanaged[Cdecl]<IntPtr, string, ref bool, Bool>)objectFunctions[head++];
				Object.getByte = (delegate* unmanaged[Cdecl]<IntPtr, string, ref byte, Bool>)objectFunctions[head++];
				Object.getShort = (delegate* unmanaged[Cdecl]<IntPtr, string, ref short, Bool>)objectFunctions[head++];
				Object.getInt = (delegate* unmanaged[Cdecl]<IntPtr, string, ref int, Bool>)objectFunctions[head++];
				Object.getLong = (delegate* unmanaged[Cdecl]<IntPtr, string, ref long, Bool>)objectFunctions[head++];
				Object.getUShort = (delegate* unmanaged[Cdecl]<IntPtr, string, ref ushort, Bool>)objectFunctions[head++];
				Object.getUInt = (delegate* unmanaged[Cdecl]<IntPtr, string, ref uint, Bool>)objectFunctions[head++];
				Object.getULong = (delegate* unmanaged[Cdecl]<IntPtr, string, ref ulong, Bool>)objectFunctions[head++];
				Object.getFloat = (delegate* unmanaged[Cdecl]<IntPtr, string, ref float, Bool>)objectFunctions[head++];
				Object.getDouble = (delegate* unmanaged[Cdecl]<IntPtr, string, ref double, Bool>)objectFunctions[head++];
				Object.getEnum = (delegate* unmanaged[Cdecl]<IntPtr, string, ref int, Bool>)objectFunctions[head++];
				Object.getString = (delegate* unmanaged[Cdecl]<IntPtr, string, byte[], Bool>)objectFunctions[head++];
				Object.getText = (delegate* unmanaged[Cdecl]<IntPtr, string, byte[], Bool>)objectFunctions[head++];
				Object.setBool = (delegate* unmanaged[Cdecl]<IntPtr, string, Bool, Bool>)objectFunctions[head++];
				Object.setByte = (delegate* unmanaged[Cdecl]<IntPtr, string, byte, Bool>)objectFunctions[head++];
				Object.setShort = (delegate* unmanaged[Cdecl]<IntPtr, string, short, Bool>)objectFunctions[head++];
				Object.setInt = (delegate* unmanaged[Cdecl]<IntPtr, string, int, Bool>)objectFunctions[head++];
				Object.setLong = (delegate* unmanaged[Cdecl]<IntPtr, string, long, Bool>)objectFunctions[head++];
				Object.setUShort = (delegate* unmanaged[Cdecl]<IntPtr, string, ushort, Bool>)objectFunctions[head++];
				Object.setUInt = (delegate* unmanaged[Cdecl]<IntPtr, string, uint, Bool>)objectFunctions[head++];
				Object.setULong = (delegate* unmanaged[Cdecl]<IntPtr, string, ulong, Bool>)objectFunctions[head++];
				Object.setFloat = (delegate* unmanaged[Cdecl]<IntPtr, string, float, Bool>)objectFunctions[head++];
				Object.setDouble = (delegate* unmanaged[Cdecl]<IntPtr, string, double, Bool>)objectFunctions[head++];
				Object.setEnum = (delegate* unmanaged[Cdecl]<IntPtr, string, int, Bool>)objectFunctions[head++];
				Object.setString = (delegate* unmanaged[Cdecl]<IntPtr, string, string, Bool>)objectFunctions[head++];
				Object.setText = (delegate* unmanaged[Cdecl]<IntPtr, string, string, Bool>)objectFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* applicationFunctions = (IntPtr*)buffer[position++];

				Application.isCanEverRender = (delegate* unmanaged[Cdecl]<Bool>)applicationFunctions[head++];
				Application.isPackagedForDistribution = (delegate* unmanaged[Cdecl]<Bool>)applicationFunctions[head++];
				Application.isPackagedForShipping = (delegate* unmanaged[Cdecl]<Bool>)applicationFunctions[head++];
				Application.getProjectDirectory = (delegate* unmanaged[Cdecl]<byte[], void>)applicationFunctions[head++];
				Application.getDefaultLanguage = (delegate* unmanaged[Cdecl]<byte[], void>)applicationFunctions[head++];
				Application.getProjectName = (delegate* unmanaged[Cdecl]<byte[], void>)applicationFunctions[head++];
				Application.getVolumeMultiplier = (delegate* unmanaged[Cdecl]<float>)applicationFunctions[head++];
				Application.setProjectName = (delegate* unmanaged[Cdecl]<string, void>)applicationFunctions[head++];
				Application.setVolumeMultiplier = (delegate* unmanaged[Cdecl]<float, void>)applicationFunctions[head++];
				Application.requestExit = (delegate* unmanaged[Cdecl]<Bool, void>)applicationFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* consoleManagerFunctions = (IntPtr*)buffer[position++];

				ConsoleManager.isRegisteredVariable = (delegate* unmanaged[Cdecl]<string, Bool>)consoleManagerFunctions[head++];
				ConsoleManager.findVariable = (delegate* unmanaged[Cdecl]<string, IntPtr>)consoleManagerFunctions[head++];
				ConsoleManager.registerVariableBool = (delegate* unmanaged[Cdecl]<string, string, Bool, Bool, IntPtr>)consoleManagerFunctions[head++];
				ConsoleManager.registerVariableInt = (delegate* unmanaged[Cdecl]<string, string, int, Bool, IntPtr>)consoleManagerFunctions[head++];
				ConsoleManager.registerVariableFloat = (delegate* unmanaged[Cdecl]<string, string, float, Bool, IntPtr>)consoleManagerFunctions[head++];
				ConsoleManager.registerVariableString = (delegate* unmanaged[Cdecl]<string, string, string, Bool, IntPtr>)consoleManagerFunctions[head++];
				ConsoleManager.registerCommand = (delegate* unmanaged[Cdecl]<string, string, IntPtr, Bool, void>)consoleManagerFunctions[head++];
				ConsoleManager.unregisterObject = (delegate* unmanaged[Cdecl]<string, void>)consoleManagerFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* engineFunctions = (IntPtr*)buffer[position++];

				Engine.isSplitScreen = (delegate* unmanaged[Cdecl]<Bool>)engineFunctions[head++];
				Engine.isEditor = (delegate* unmanaged[Cdecl]<Bool>)engineFunctions[head++];
				Engine.isForegroundWindow = (delegate* unmanaged[Cdecl]<Bool>)engineFunctions[head++];
				Engine.isExitRequested = (delegate* unmanaged[Cdecl]<Bool>)engineFunctions[head++];
				Engine.getNetMode = (delegate* unmanaged[Cdecl]<NetMode>)engineFunctions[head++];
				Engine.getFrameNumber = (delegate* unmanaged[Cdecl]<uint>)engineFunctions[head++];
				Engine.getViewportSize = (delegate* unmanaged[Cdecl]<ref Vector2, void>)engineFunctions[head++];
				Engine.getScreenResolution = (delegate* unmanaged[Cdecl]<ref Vector2, void>)engineFunctions[head++];
				Engine.getWindowMode = (delegate* unmanaged[Cdecl]<WindowMode>)engineFunctions[head++];
				Engine.getVersion = (delegate* unmanaged[Cdecl]<byte[], void>)engineFunctions[head++];
				Engine.getMaxFPS = (delegate* unmanaged[Cdecl]<float>)engineFunctions[head++];
				Engine.setMaxFPS = (delegate* unmanaged[Cdecl]<float, void>)engineFunctions[head++];
				Engine.setTitle = (delegate* unmanaged[Cdecl]<string, void>)engineFunctions[head++];
				Engine.addActionMapping = (delegate* unmanaged[Cdecl]<string, string, Bool, Bool, Bool, Bool, void>)engineFunctions[head++];
				Engine.addAxisMapping = (delegate* unmanaged[Cdecl]<string, string, float, void>)engineFunctions[head++];
				Engine.forceGarbageCollection = (delegate* unmanaged[Cdecl]<Bool, void>)engineFunctions[head++];
				Engine.delayGarbageCollection = (delegate* unmanaged[Cdecl]<void>)engineFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* headMountedDisplayFunctions = (IntPtr*)buffer[position++];

				HeadMountedDisplay.isConnected = (delegate* unmanaged[Cdecl]<Bool>)headMountedDisplayFunctions[head++];
				HeadMountedDisplay.getEnabled = (delegate* unmanaged[Cdecl]<Bool>)headMountedDisplayFunctions[head++];
				HeadMountedDisplay.getLowPersistenceMode = (delegate* unmanaged[Cdecl]<Bool>)headMountedDisplayFunctions[head++];
				HeadMountedDisplay.getDeviceName = (delegate* unmanaged[Cdecl]<byte[], void>)headMountedDisplayFunctions[head++];
				HeadMountedDisplay.setEnable = (delegate* unmanaged[Cdecl]<Bool, void>)headMountedDisplayFunctions[head++];
				HeadMountedDisplay.setLowPersistenceMode = (delegate* unmanaged[Cdecl]<Bool, void>)headMountedDisplayFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* worldFunctions = (IntPtr*)buffer[position++];

				World.forEachActor = (delegate* unmanaged[Cdecl]<ref ObjectReference*, ref int, void>)worldFunctions[head++];
				World.getActorCount = (delegate* unmanaged[Cdecl]<int>)worldFunctions[head++];
				World.getDeltaSeconds = (delegate* unmanaged[Cdecl]<float>)worldFunctions[head++];
				World.getRealTimeSeconds = (delegate* unmanaged[Cdecl]<float>)worldFunctions[head++];
				World.getTimeSeconds = (delegate* unmanaged[Cdecl]<float>)worldFunctions[head++];
				World.getCurrentLevelName = (delegate* unmanaged[Cdecl]<byte[], void>)worldFunctions[head++];
				World.getSimulatePhysics = (delegate* unmanaged[Cdecl]<Bool>)worldFunctions[head++];
				World.getWorldOrigin = (delegate* unmanaged[Cdecl]<ref Vector3, void>)worldFunctions[head++];
				World.getActor = (delegate* unmanaged[Cdecl]<string, ActorType, IntPtr>)worldFunctions[head++];
				World.getActorByTag = (delegate* unmanaged[Cdecl]<string, ActorType, IntPtr>)worldFunctions[head++];
				World.getActorByID = (delegate* unmanaged[Cdecl]<uint, ActorType, IntPtr>)worldFunctions[head++];
				World.getFirstPlayerController = (delegate* unmanaged[Cdecl]<IntPtr>)worldFunctions[head++];
				World.getGameMode = (delegate* unmanaged[Cdecl]<IntPtr>)worldFunctions[head++];
				World.setOnActorBeginOverlapCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnActorBeginCursorOverCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnActorEndCursorOverCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnActorClickedCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnActorReleasedCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnActorEndOverlapCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnActorHitCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnComponentBeginOverlapCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnComponentEndOverlapCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnComponentHitCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnComponentBeginCursorOverCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnComponentEndCursorOverCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnComponentClickedCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setOnComponentReleasedCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)worldFunctions[head++];
				World.setSimulatePhysics = (delegate* unmanaged[Cdecl]<Bool, void>)worldFunctions[head++];
				World.setGravity = (delegate* unmanaged[Cdecl]<float, void>)worldFunctions[head++];
				World.setWorldOrigin = (delegate* unmanaged[Cdecl]<in Vector3, Bool>)worldFunctions[head++];
				World.openLevel = (delegate* unmanaged[Cdecl]<string, void>)worldFunctions[head++];
				World.lineTraceTestByChannel = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, CollisionChannel, Bool, IntPtr, IntPtr, Bool>)worldFunctions[head++];
				World.lineTraceTestByProfile = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, string, Bool, IntPtr, IntPtr, Bool>)worldFunctions[head++];
				World.lineTraceSingleByChannel = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, CollisionChannel, ref Hit, byte[], Bool, IntPtr, IntPtr, Bool>)worldFunctions[head++];
				World.lineTraceSingleByProfile = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, string, ref Hit, byte[], Bool, IntPtr, IntPtr, Bool>)worldFunctions[head++];
				World.sweepTestByChannel = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, in Quaternion, CollisionChannel, in CollisionShape, Bool, IntPtr, IntPtr, Bool>)worldFunctions[head++];
				World.sweepTestByProfile = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, in Quaternion, string, in CollisionShape, Bool, IntPtr, IntPtr, Bool>)worldFunctions[head++];
				World.sweepSingleByChannel = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, in Quaternion, CollisionChannel, in CollisionShape, ref Hit, byte[], Bool, IntPtr, IntPtr, Bool>)worldFunctions[head++];
				World.sweepSingleByProfile = (delegate* unmanaged[Cdecl]<in Vector3, in Vector3, in Quaternion, string, in CollisionShape, ref Hit, byte[], Bool, IntPtr, IntPtr, Bool>)worldFunctions[head++];
				World.overlapAnyTestByChannel = (delegate* unmanaged[Cdecl]<in Vector3, in Quaternion, CollisionChannel, in CollisionShape, IntPtr, IntPtr, Bool>)worldFunctions[head++];
				World.overlapAnyTestByProfile = (delegate* unmanaged[Cdecl]<in Vector3, in Quaternion, string, in CollisionShape, IntPtr, IntPtr, Bool>)worldFunctions[head++];
				World.overlapBlockingTestByChannel = (delegate* unmanaged[Cdecl]<in Vector3, in Quaternion, CollisionChannel, in CollisionShape, IntPtr, IntPtr, Bool>)worldFunctions[head++];
				World.overlapBlockingTestByProfile = (delegate* unmanaged[Cdecl]<in Vector3, in Quaternion, string, in CollisionShape, IntPtr, IntPtr, Bool>)worldFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* assetFunctions = (IntPtr*)buffer[position++];

				Asset.isValid = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)assetFunctions[head++];
				Asset.getName = (delegate* unmanaged[Cdecl]<IntPtr, byte[], void>)assetFunctions[head++];
				Asset.getPath = (delegate* unmanaged[Cdecl]<IntPtr, byte[], void>)assetFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* assetRegistryFunctions = (IntPtr*)buffer[position++];

				AssetRegistry.get = (delegate* unmanaged[Cdecl]<IntPtr>)assetRegistryFunctions[head++];
				AssetRegistry.hasAssets = (delegate* unmanaged[Cdecl]<IntPtr, string, Bool, Bool>)assetRegistryFunctions[head++];
				AssetRegistry.forEachAsset = (delegate* unmanaged[Cdecl]<IntPtr, string, Bool, Bool, ref Asset*, ref int, void>)assetRegistryFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* blueprintFunctions = (IntPtr*)buffer[position++];

				Blueprint.isValidActorClass = (delegate* unmanaged[Cdecl]<IntPtr, ActorType, Bool>)blueprintFunctions[head++];
				Blueprint.isValidComponentClass = (delegate* unmanaged[Cdecl]<IntPtr, ComponentType, Bool>)blueprintFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* consoleObjectFunctions = (IntPtr*)buffer[position++];

				ConsoleObject.isBool = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)consoleObjectFunctions[head++];
				ConsoleObject.isInt = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)consoleObjectFunctions[head++];
				ConsoleObject.isFloat = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)consoleObjectFunctions[head++];
				ConsoleObject.isString = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)consoleObjectFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* consoleVariableFunctions = (IntPtr*)buffer[position++];

				ConsoleVariable.getBool = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)consoleVariableFunctions[head++];
				ConsoleVariable.getInt = (delegate* unmanaged[Cdecl]<IntPtr, int>)consoleVariableFunctions[head++];
				ConsoleVariable.getFloat = (delegate* unmanaged[Cdecl]<IntPtr, float>)consoleVariableFunctions[head++];
				ConsoleVariable.getString = (delegate* unmanaged[Cdecl]<IntPtr, byte[], void>)consoleVariableFunctions[head++];
				ConsoleVariable.setBool = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)consoleVariableFunctions[head++];
				ConsoleVariable.setInt = (delegate* unmanaged[Cdecl]<IntPtr, int, void>)consoleVariableFunctions[head++];
				ConsoleVariable.setFloat = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)consoleVariableFunctions[head++];
				ConsoleVariable.setString = (delegate* unmanaged[Cdecl]<IntPtr, string, void>)consoleVariableFunctions[head++];
				ConsoleVariable.setOnChangedCallback = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)consoleVariableFunctions[head++];
				ConsoleVariable.clearOnChangedCallback = (delegate* unmanaged[Cdecl]<IntPtr, void>)consoleVariableFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* actorFunctions = (IntPtr*)buffer[position++];

				Actor.isPendingKill = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)actorFunctions[head++];
				Actor.isRootComponentMovable = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)actorFunctions[head++];
				Actor.isOverlappingActor = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool>)actorFunctions[head++];
				Actor.forEachComponent = (delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void>)actorFunctions[head++];
				Actor.forEachAttachedActor = (delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void>)actorFunctions[head++];
				Actor.forEachChildActor = (delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void>)actorFunctions[head++];
				Actor.forEachOverlappingActor = (delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void>)actorFunctions[head++];
				Actor.spawn = (delegate* unmanaged[Cdecl]<string, ActorType, IntPtr, IntPtr>)actorFunctions[head++];
				Actor.destroy = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)actorFunctions[head++];
				Actor.rename = (delegate* unmanaged[Cdecl]<IntPtr, string, void>)actorFunctions[head++];
				Actor.hide = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)actorFunctions[head++];
				Actor.teleportTo = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, in Quaternion, Bool, Bool, Bool>)actorFunctions[head++];
				Actor.getComponent = (delegate* unmanaged[Cdecl]<IntPtr, string, ComponentType, IntPtr>)actorFunctions[head++];
				Actor.getComponentByTag = (delegate* unmanaged[Cdecl]<IntPtr, string, ComponentType, IntPtr>)actorFunctions[head++];
				Actor.getComponentByID = (delegate* unmanaged[Cdecl]<IntPtr, uint, ComponentType, IntPtr>)actorFunctions[head++];
				Actor.getRootComponent = (delegate* unmanaged[Cdecl]<IntPtr, ComponentType, IntPtr>)actorFunctions[head++];
				Actor.getInputComponent = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)actorFunctions[head++];
				Actor.getCreationTime = (delegate* unmanaged[Cdecl]<IntPtr, float>)actorFunctions[head++];
				Actor.getBlockInput = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)actorFunctions[head++];
				Actor.getDistanceTo = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float>)actorFunctions[head++];
				Actor.getHorizontalDistanceTo = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float>)actorFunctions[head++];
				Actor.getBounds = (delegate* unmanaged[Cdecl]<IntPtr, Bool, ref Vector3, ref Vector3, void>)actorFunctions[head++];
				Actor.getEyesViewPoint = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, ref Quaternion, void>)actorFunctions[head++];
				Actor.setRootComponent = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool>)actorFunctions[head++];
				Actor.setInputComponent = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)actorFunctions[head++];
				Actor.setBlockInput = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)actorFunctions[head++];
				Actor.setLifeSpan = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)actorFunctions[head++];
				Actor.setEnableInput = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool, void>)actorFunctions[head++];
				Actor.setEnableCollision = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)actorFunctions[head++];
				Actor.addTag = (delegate* unmanaged[Cdecl]<IntPtr, string, void>)actorFunctions[head++];
				Actor.removeTag = (delegate* unmanaged[Cdecl]<IntPtr, string, void>)actorFunctions[head++];
				Actor.hasTag = (delegate* unmanaged[Cdecl]<IntPtr, string, Bool>)actorFunctions[head++];
				Actor.registerEvent = (delegate* unmanaged[Cdecl]<IntPtr, ActorEventType, void>)actorFunctions[head++];
				Actor.unregisterEvent = (delegate* unmanaged[Cdecl]<IntPtr, ActorEventType, void>)actorFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* gameModeBaseFunctions = (IntPtr*)buffer[position++];

				GameModeBase.getUseSeamlessTravel = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)gameModeBaseFunctions[head++];
				GameModeBase.setUseSeamlessTravel = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)gameModeBaseFunctions[head++];
				GameModeBase.swapPlayerControllers = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, void>)gameModeBaseFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* pawnFunctions = (IntPtr*)buffer[position++];

				Pawn.isControlled = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)pawnFunctions[head++];
				Pawn.isPlayerControlled = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)pawnFunctions[head++];
				Pawn.getAutoPossessAI = (delegate* unmanaged[Cdecl]<IntPtr, AutoPossessAI>)pawnFunctions[head++];
				Pawn.getAutoPossessPlayer = (delegate* unmanaged[Cdecl]<IntPtr, AutoReceiveInput>)pawnFunctions[head++];
				Pawn.getUseControllerRotationYaw = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)pawnFunctions[head++];
				Pawn.getUseControllerRotationPitch = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)pawnFunctions[head++];
				Pawn.getUseControllerRotationRoll = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)pawnFunctions[head++];
				Pawn.getGravityDirection = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)pawnFunctions[head++];
				Pawn.getAIController = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)pawnFunctions[head++];
				Pawn.getPlayerController = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)pawnFunctions[head++];
				Pawn.setAutoPossessAI = (delegate* unmanaged[Cdecl]<IntPtr, AutoPossessAI, void>)pawnFunctions[head++];
				Pawn.setAutoPossessPlayer = (delegate* unmanaged[Cdecl]<IntPtr, AutoReceiveInput, void>)pawnFunctions[head++];
				Pawn.setUseControllerRotationYaw = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)pawnFunctions[head++];
				Pawn.setUseControllerRotationPitch = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)pawnFunctions[head++];
				Pawn.setUseControllerRotationRoll = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)pawnFunctions[head++];
				Pawn.addControllerYawInput = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)pawnFunctions[head++];
				Pawn.addControllerPitchInput = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)pawnFunctions[head++];
				Pawn.addControllerRollInput = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)pawnFunctions[head++];
				Pawn.addMovementInput = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, float, Bool, void>)pawnFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* characterFunctions = (IntPtr*)buffer[position++];

				Character.isCrouched = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)characterFunctions[head++];
				Character.canCrouch = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)characterFunctions[head++];
				Character.canJump = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)characterFunctions[head++];
				Character.checkJumpInput = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)characterFunctions[head++];
				Character.clearJumpInput = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)characterFunctions[head++];
				Character.launch = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, Bool, Bool, void>)characterFunctions[head++];
				Character.crouch = (delegate* unmanaged[Cdecl]<IntPtr, void>)characterFunctions[head++];
				Character.stopCrouching = (delegate* unmanaged[Cdecl]<IntPtr, void>)characterFunctions[head++];
				Character.jump = (delegate* unmanaged[Cdecl]<IntPtr, void>)characterFunctions[head++];
				Character.stopJumping = (delegate* unmanaged[Cdecl]<IntPtr, void>)characterFunctions[head++];
				Character.setOnLandedCallback = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)characterFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* controllerFunctions = (IntPtr*)buffer[position++];

				Controller.isLookInputIgnored = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)controllerFunctions[head++];
				Controller.isMoveInputIgnored = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)controllerFunctions[head++];
				Controller.isPlayerController = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)controllerFunctions[head++];
				Controller.getPawn = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)controllerFunctions[head++];
				Controller.getCharacter = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)controllerFunctions[head++];
				Controller.getViewTarget = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)controllerFunctions[head++];
				Controller.getControlRotation = (delegate* unmanaged[Cdecl]<IntPtr, ref Quaternion, void>)controllerFunctions[head++];
				Controller.getDesiredRotation = (delegate* unmanaged[Cdecl]<IntPtr, ref Quaternion, void>)controllerFunctions[head++];
				Controller.lineOfSightTo = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, in Vector3, Bool, Bool>)controllerFunctions[head++];
				Controller.setControlRotation = (delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void>)controllerFunctions[head++];
				Controller.setInitialLocationAndRotation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, in Quaternion, void>)controllerFunctions[head++];
				Controller.setIgnoreLookInput = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)controllerFunctions[head++];
				Controller.setIgnoreMoveInput = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)controllerFunctions[head++];
				Controller.resetIgnoreLookInput = (delegate* unmanaged[Cdecl]<IntPtr, void>)controllerFunctions[head++];
				Controller.resetIgnoreMoveInput = (delegate* unmanaged[Cdecl]<IntPtr, void>)controllerFunctions[head++];
				Controller.possess = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)controllerFunctions[head++];
				Controller.unpossess = (delegate* unmanaged[Cdecl]<IntPtr, void>)controllerFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* aIControllerFunctions = (IntPtr*)buffer[position++];

				AIController.clearFocus = (delegate* unmanaged[Cdecl]<IntPtr, AIFocusPriority, void>)aIControllerFunctions[head++];
				AIController.getFocalPoint = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)aIControllerFunctions[head++];
				AIController.setFocalPoint = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, AIFocusPriority, void>)aIControllerFunctions[head++];
				AIController.getFocusActor = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)aIControllerFunctions[head++];
				AIController.getAllowStrafe = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)aIControllerFunctions[head++];
				AIController.setAllowStrafe = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)aIControllerFunctions[head++];
				AIController.setFocus = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, AIFocusPriority, void>)aIControllerFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* playerControllerFunctions = (IntPtr*)buffer[position++];

				PlayerController.isPaused = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)playerControllerFunctions[head++];
				PlayerController.getShowMouseCursor = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)playerControllerFunctions[head++];
				PlayerController.getEnableClickEvents = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)playerControllerFunctions[head++];
				PlayerController.getEnableMouseOverEvents = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)playerControllerFunctions[head++];
				PlayerController.getMousePosition = (delegate* unmanaged[Cdecl]<IntPtr, ref float, ref float, Bool>)playerControllerFunctions[head++];
				PlayerController.getPlayer = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)playerControllerFunctions[head++];
				PlayerController.getPlayerInput = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)playerControllerFunctions[head++];
				PlayerController.getHitResultAtScreenPosition = (delegate* unmanaged[Cdecl]<IntPtr, in Vector2, CollisionChannel, ref Hit, Bool, Bool>)playerControllerFunctions[head++];
				PlayerController.getHitResultUnderCursor = (delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel, ref Hit, Bool, Bool>)playerControllerFunctions[head++];
				PlayerController.setShowMouseCursor = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)playerControllerFunctions[head++];
				PlayerController.setEnableClickEvents = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)playerControllerFunctions[head++];
				PlayerController.setEnableMouseOverEvents = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)playerControllerFunctions[head++];
				PlayerController.setMousePosition = (delegate* unmanaged[Cdecl]<IntPtr, float, float, void>)playerControllerFunctions[head++];
				PlayerController.consoleCommand = (delegate* unmanaged[Cdecl]<IntPtr, string, Bool, void>)playerControllerFunctions[head++];
				PlayerController.setPause = (delegate* unmanaged[Cdecl]<IntPtr, Bool, Bool>)playerControllerFunctions[head++];
				PlayerController.setViewTarget = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)playerControllerFunctions[head++];
				PlayerController.setViewTargetWithBlend = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float, float, BlendType, Bool, void>)playerControllerFunctions[head++];
				PlayerController.addYawInput = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)playerControllerFunctions[head++];
				PlayerController.addPitchInput = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)playerControllerFunctions[head++];
				PlayerController.addRollInput = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)playerControllerFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* volumeFunctions = (IntPtr*)buffer[position++];

				Volume.encompassesPoint = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, float, ref float, Bool>)volumeFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* postProcessVolumeFunctions = (IntPtr*)buffer[position++];

				PostProcessVolume.getEnabled = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)postProcessVolumeFunctions[head++];
				PostProcessVolume.getBlendRadius = (delegate* unmanaged[Cdecl]<IntPtr, float>)postProcessVolumeFunctions[head++];
				PostProcessVolume.getBlendWeight = (delegate* unmanaged[Cdecl]<IntPtr, float>)postProcessVolumeFunctions[head++];
				PostProcessVolume.getUnbound = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)postProcessVolumeFunctions[head++];
				PostProcessVolume.getPriority = (delegate* unmanaged[Cdecl]<IntPtr, float>)postProcessVolumeFunctions[head++];
				PostProcessVolume.setEnabled = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)postProcessVolumeFunctions[head++];
				PostProcessVolume.setBlendRadius = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)postProcessVolumeFunctions[head++];
				PostProcessVolume.setBlendWeight = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)postProcessVolumeFunctions[head++];
				PostProcessVolume.setUnbound = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)postProcessVolumeFunctions[head++];
				PostProcessVolume.setPriority = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)postProcessVolumeFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* soundBaseFunctions = (IntPtr*)buffer[position++];

				SoundBase.getDuration = (delegate* unmanaged[Cdecl]<IntPtr, float>)soundBaseFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* soundWaveFunctions = (IntPtr*)buffer[position++];

				SoundWave.getLoop = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)soundWaveFunctions[head++];
				SoundWave.setLoop = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)soundWaveFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* animationInstanceFunctions = (IntPtr*)buffer[position++];

				AnimationInstance.getCurrentActiveMontage = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)animationInstanceFunctions[head++];
				AnimationInstance.isPlaying = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool>)animationInstanceFunctions[head++];
				AnimationInstance.getPlayRate = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float>)animationInstanceFunctions[head++];
				AnimationInstance.getPosition = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float>)animationInstanceFunctions[head++];
				AnimationInstance.getBlendTime = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float>)animationInstanceFunctions[head++];
				AnimationInstance.getCurrentSection = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, byte[], void>)animationInstanceFunctions[head++];
				AnimationInstance.setPlayRate = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float, void>)animationInstanceFunctions[head++];
				AnimationInstance.setPosition = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float, void>)animationInstanceFunctions[head++];
				AnimationInstance.setNextSection = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, string, string, void>)animationInstanceFunctions[head++];
				AnimationInstance.playMontage = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float, float, Bool, float>)animationInstanceFunctions[head++];
				AnimationInstance.pauseMontage = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)animationInstanceFunctions[head++];
				AnimationInstance.resumeMontage = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)animationInstanceFunctions[head++];
				AnimationInstance.stopMontage = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float, void>)animationInstanceFunctions[head++];
				AnimationInstance.jumpToSection = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, string, void>)animationInstanceFunctions[head++];
				AnimationInstance.jumpToSectionsEnd = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, string, void>)animationInstanceFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* playerFunctions = (IntPtr*)buffer[position++];

				Player.getPlayerController = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)playerFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* playerInputFunctions = (IntPtr*)buffer[position++];

				PlayerInput.isKeyPressed = (delegate* unmanaged[Cdecl]<IntPtr, string, Bool>)playerInputFunctions[head++];
				PlayerInput.getTimeKeyPressed = (delegate* unmanaged[Cdecl]<IntPtr, string, float>)playerInputFunctions[head++];
				PlayerInput.getMouseSensitivity = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector2, void>)playerInputFunctions[head++];
				PlayerInput.setMouseSensitivity = (delegate* unmanaged[Cdecl]<IntPtr, in Vector2, void>)playerInputFunctions[head++];
				PlayerInput.addActionMapping = (delegate* unmanaged[Cdecl]<IntPtr, string, string, Bool, Bool, Bool, Bool, void>)playerInputFunctions[head++];
				PlayerInput.addAxisMapping = (delegate* unmanaged[Cdecl]<IntPtr, string, string, float, void>)playerInputFunctions[head++];
				PlayerInput.removeActionMapping = (delegate* unmanaged[Cdecl]<IntPtr, string, string, void>)playerInputFunctions[head++];
				PlayerInput.removeAxisMapping = (delegate* unmanaged[Cdecl]<IntPtr, string, string, void>)playerInputFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* fontFunctions = (IntPtr*)buffer[position++];

				Font.getStringSize = (delegate* unmanaged[Cdecl]<IntPtr, string, ref int, ref int, void>)fontFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* texture2DFunctions = (IntPtr*)buffer[position++];

				Texture2D.createFromFile = (delegate* unmanaged[Cdecl]<string, IntPtr>)texture2DFunctions[head++];
				Texture2D.createFromBuffer = (delegate* unmanaged[Cdecl]<byte[], int, IntPtr>)texture2DFunctions[head++];
				Texture2D.hasAlphaChannel = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)texture2DFunctions[head++];
				Texture2D.getSize = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector2, void>)texture2DFunctions[head++];
				Texture2D.getPixelFormat = (delegate* unmanaged[Cdecl]<IntPtr, PixelFormat>)texture2DFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* actorComponentFunctions = (IntPtr*)buffer[position++];

				ActorComponent.isOwnerSelected = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)actorComponentFunctions[head++];
				ActorComponent.getOwner = (delegate* unmanaged[Cdecl]<IntPtr, ActorType, IntPtr>)actorComponentFunctions[head++];
				ActorComponent.destroy = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)actorComponentFunctions[head++];
				ActorComponent.addTag = (delegate* unmanaged[Cdecl]<IntPtr, string, void>)actorComponentFunctions[head++];
				ActorComponent.removeTag = (delegate* unmanaged[Cdecl]<IntPtr, string, void>)actorComponentFunctions[head++];
				ActorComponent.hasTag = (delegate* unmanaged[Cdecl]<IntPtr, string, Bool>)actorComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* inputComponentFunctions = (IntPtr*)buffer[position++];

				InputComponent.hasBindings = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)inputComponentFunctions[head++];
				InputComponent.getActionBindingsNumber = (delegate* unmanaged[Cdecl]<IntPtr, int>)inputComponentFunctions[head++];
				InputComponent.clearActionBindings = (delegate* unmanaged[Cdecl]<IntPtr, void>)inputComponentFunctions[head++];
				InputComponent.bindAction = (delegate* unmanaged[Cdecl]<IntPtr, string, InputEvent, Bool, IntPtr, void>)inputComponentFunctions[head++];
				InputComponent.bindAxis = (delegate* unmanaged[Cdecl]<IntPtr, string, Bool, IntPtr, void>)inputComponentFunctions[head++];
				InputComponent.removeActionBinding = (delegate* unmanaged[Cdecl]<IntPtr, string, InputEvent, void>)inputComponentFunctions[head++];
				InputComponent.getBlockInput = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)inputComponentFunctions[head++];
				InputComponent.setBlockInput = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)inputComponentFunctions[head++];
				InputComponent.getPriority = (delegate* unmanaged[Cdecl]<IntPtr, int>)inputComponentFunctions[head++];
				InputComponent.setPriority = (delegate* unmanaged[Cdecl]<IntPtr, int, void>)inputComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* sceneComponentFunctions = (IntPtr*)buffer[position++];

				SceneComponent.isAttachedToComponent = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool>)sceneComponentFunctions[head++];
				SceneComponent.isAttachedToActor = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool>)sceneComponentFunctions[head++];
				SceneComponent.isVisible = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)sceneComponentFunctions[head++];
				SceneComponent.isSocketExists = (delegate* unmanaged[Cdecl]<IntPtr, string, Bool>)sceneComponentFunctions[head++];
				SceneComponent.hasAnySockets = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)sceneComponentFunctions[head++];
				SceneComponent.canAttachAsChild = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, string, Bool>)sceneComponentFunctions[head++];
				SceneComponent.forEachAttachedChild = (delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void>)sceneComponentFunctions[head++];
				SceneComponent.create = (delegate* unmanaged[Cdecl]<IntPtr, ComponentType, string, Bool, IntPtr, IntPtr>)sceneComponentFunctions[head++];
				SceneComponent.attachToComponent = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, AttachmentTransformRule, string, Bool>)sceneComponentFunctions[head++];
				SceneComponent.detachFromComponent = (delegate* unmanaged[Cdecl]<IntPtr, DetachmentTransformRule, void>)sceneComponentFunctions[head++];
				SceneComponent.activate = (delegate* unmanaged[Cdecl]<IntPtr, void>)sceneComponentFunctions[head++];
				SceneComponent.deactivate = (delegate* unmanaged[Cdecl]<IntPtr, void>)sceneComponentFunctions[head++];
				SceneComponent.updateToWorld = (delegate* unmanaged[Cdecl]<IntPtr, TeleportType, UpdateTransformFlags, void>)sceneComponentFunctions[head++];
				SceneComponent.addLocalOffset = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.addLocalRotation = (delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void>)sceneComponentFunctions[head++];
				SceneComponent.addRelativeLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.addRelativeRotation = (delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void>)sceneComponentFunctions[head++];
				SceneComponent.addLocalTransform = (delegate* unmanaged[Cdecl]<IntPtr, in Transform, void>)sceneComponentFunctions[head++];
				SceneComponent.addWorldOffset = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.addWorldRotation = (delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void>)sceneComponentFunctions[head++];
				SceneComponent.addWorldTransform = (delegate* unmanaged[Cdecl]<IntPtr, in Transform, void>)sceneComponentFunctions[head++];
				SceneComponent.getAttachedSocketName = (delegate* unmanaged[Cdecl]<IntPtr, byte[], void>)sceneComponentFunctions[head++];
				SceneComponent.getBounds = (delegate* unmanaged[Cdecl]<IntPtr, in Transform, ref Bounds, void>)sceneComponentFunctions[head++];
				SceneComponent.getSocketLocation = (delegate* unmanaged[Cdecl]<IntPtr, string, ref Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.getSocketRotation = (delegate* unmanaged[Cdecl]<IntPtr, string, ref Quaternion, void>)sceneComponentFunctions[head++];
				SceneComponent.getComponentVelocity = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.getComponentLocation = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.getComponentRotation = (delegate* unmanaged[Cdecl]<IntPtr, ref Quaternion, void>)sceneComponentFunctions[head++];
				SceneComponent.getComponentScale = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.getComponentTransform = (delegate* unmanaged[Cdecl]<IntPtr, ref Transform, void>)sceneComponentFunctions[head++];
				SceneComponent.getForwardVector = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.getRightVector = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.getUpVector = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.setMobility = (delegate* unmanaged[Cdecl]<IntPtr, ComponentMobility, void>)sceneComponentFunctions[head++];
				SceneComponent.setVisibility = (delegate* unmanaged[Cdecl]<IntPtr, Bool, Bool, void>)sceneComponentFunctions[head++];
				SceneComponent.setRelativeLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.setRelativeRotation = (delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void>)sceneComponentFunctions[head++];
				SceneComponent.setRelativeTransform = (delegate* unmanaged[Cdecl]<IntPtr, in Transform, void>)sceneComponentFunctions[head++];
				SceneComponent.setWorldLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.setWorldRotation = (delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void>)sceneComponentFunctions[head++];
				SceneComponent.setWorldScale = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void>)sceneComponentFunctions[head++];
				SceneComponent.setWorldTransform = (delegate* unmanaged[Cdecl]<IntPtr, in Transform, void>)sceneComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* audioComponentFunctions = (IntPtr*)buffer[position++];

				AudioComponent.isPlaying = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)audioComponentFunctions[head++];
				AudioComponent.getPaused = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)audioComponentFunctions[head++];
				AudioComponent.setSound = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)audioComponentFunctions[head++];
				AudioComponent.setPaused = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)audioComponentFunctions[head++];
				AudioComponent.play = (delegate* unmanaged[Cdecl]<IntPtr, void>)audioComponentFunctions[head++];
				AudioComponent.stop = (delegate* unmanaged[Cdecl]<IntPtr, void>)audioComponentFunctions[head++];
				AudioComponent.fadeIn = (delegate* unmanaged[Cdecl]<IntPtr, float, float, float, AudioFadeCurve, void>)audioComponentFunctions[head++];
				AudioComponent.fadeOut = (delegate* unmanaged[Cdecl]<IntPtr, float, float, AudioFadeCurve, void>)audioComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* cameraComponentFunctions = (IntPtr*)buffer[position++];

				CameraComponent.getConstrainAspectRatio = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)cameraComponentFunctions[head++];
				CameraComponent.getAspectRatio = (delegate* unmanaged[Cdecl]<IntPtr, float>)cameraComponentFunctions[head++];
				CameraComponent.getFieldOfView = (delegate* unmanaged[Cdecl]<IntPtr, float>)cameraComponentFunctions[head++];
				CameraComponent.getOrthoFarClipPlane = (delegate* unmanaged[Cdecl]<IntPtr, float>)cameraComponentFunctions[head++];
				CameraComponent.getOrthoNearClipPlane = (delegate* unmanaged[Cdecl]<IntPtr, float>)cameraComponentFunctions[head++];
				CameraComponent.getOrthoWidth = (delegate* unmanaged[Cdecl]<IntPtr, float>)cameraComponentFunctions[head++];
				CameraComponent.getLockToHeadMountedDisplay = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)cameraComponentFunctions[head++];
				CameraComponent.setProjectionMode = (delegate* unmanaged[Cdecl]<IntPtr, CameraProjectionMode, void>)cameraComponentFunctions[head++];
				CameraComponent.setConstrainAspectRatio = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)cameraComponentFunctions[head++];
				CameraComponent.setAspectRatio = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)cameraComponentFunctions[head++];
				CameraComponent.setFieldOfView = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)cameraComponentFunctions[head++];
				CameraComponent.setOrthoFarClipPlane = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)cameraComponentFunctions[head++];
				CameraComponent.setOrthoNearClipPlane = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)cameraComponentFunctions[head++];
				CameraComponent.setOrthoWidth = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)cameraComponentFunctions[head++];
				CameraComponent.setLockToHeadMountedDisplay = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)cameraComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* childActorComponentFunctions = (IntPtr*)buffer[position++];

				ChildActorComponent.getChildActor = (delegate* unmanaged[Cdecl]<IntPtr, ActorType, IntPtr>)childActorComponentFunctions[head++];
				ChildActorComponent.setChildActor = (delegate* unmanaged[Cdecl]<IntPtr, ActorType, IntPtr>)childActorComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* springArmComponentFunctions = (IntPtr*)buffer[position++];

				SpringArmComponent.isCollisionFixApplied = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)springArmComponentFunctions[head++];
				SpringArmComponent.getDrawDebugLagMarkers = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)springArmComponentFunctions[head++];
				SpringArmComponent.getCollisionTest = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)springArmComponentFunctions[head++];
				SpringArmComponent.getCameraPositionLag = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)springArmComponentFunctions[head++];
				SpringArmComponent.getCameraRotationLag = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)springArmComponentFunctions[head++];
				SpringArmComponent.getCameraLagSubstepping = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)springArmComponentFunctions[head++];
				SpringArmComponent.getInheritPitch = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)springArmComponentFunctions[head++];
				SpringArmComponent.getInheritRoll = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)springArmComponentFunctions[head++];
				SpringArmComponent.getInheritYaw = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)springArmComponentFunctions[head++];
				SpringArmComponent.getCameraLagMaxDistance = (delegate* unmanaged[Cdecl]<IntPtr, float>)springArmComponentFunctions[head++];
				SpringArmComponent.getCameraLagMaxTimeStep = (delegate* unmanaged[Cdecl]<IntPtr, float>)springArmComponentFunctions[head++];
				SpringArmComponent.getCameraPositionLagSpeed = (delegate* unmanaged[Cdecl]<IntPtr, float>)springArmComponentFunctions[head++];
				SpringArmComponent.getCameraRotationLagSpeed = (delegate* unmanaged[Cdecl]<IntPtr, float>)springArmComponentFunctions[head++];
				SpringArmComponent.getProbeChannel = (delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel>)springArmComponentFunctions[head++];
				SpringArmComponent.getProbeSize = (delegate* unmanaged[Cdecl]<IntPtr, float>)springArmComponentFunctions[head++];
				SpringArmComponent.getSocketOffset = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)springArmComponentFunctions[head++];
				SpringArmComponent.getTargetArmLength = (delegate* unmanaged[Cdecl]<IntPtr, float>)springArmComponentFunctions[head++];
				SpringArmComponent.getTargetOffset = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)springArmComponentFunctions[head++];
				SpringArmComponent.getUnfixedCameraPosition = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)springArmComponentFunctions[head++];
				SpringArmComponent.getDesiredRotation = (delegate* unmanaged[Cdecl]<IntPtr, ref Quaternion, void>)springArmComponentFunctions[head++];
				SpringArmComponent.getTargetRotation = (delegate* unmanaged[Cdecl]<IntPtr, ref Quaternion, void>)springArmComponentFunctions[head++];
				SpringArmComponent.getUsePawnControlRotation = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)springArmComponentFunctions[head++];
				SpringArmComponent.setDrawDebugLagMarkers = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setCollisionTest = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setCameraPositionLag = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setCameraRotationLag = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setCameraLagSubstepping = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setInheritPitch = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setInheritRoll = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setInheritYaw = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setCameraLagMaxDistance = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setCameraLagMaxTimeStep = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setCameraPositionLagSpeed = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setCameraRotationLagSpeed = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setProbeChannel = (delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setProbeSize = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setSocketOffset = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setTargetArmLength = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setTargetOffset = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void>)springArmComponentFunctions[head++];
				SpringArmComponent.setUsePawnControlRotation = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)springArmComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* postProcessComponentFunctions = (IntPtr*)buffer[position++];

				PostProcessComponent.getEnabled = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)postProcessComponentFunctions[head++];
				PostProcessComponent.getBlendRadius = (delegate* unmanaged[Cdecl]<IntPtr, float>)postProcessComponentFunctions[head++];
				PostProcessComponent.getBlendWeight = (delegate* unmanaged[Cdecl]<IntPtr, float>)postProcessComponentFunctions[head++];
				PostProcessComponent.getUnbound = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)postProcessComponentFunctions[head++];
				PostProcessComponent.getPriority = (delegate* unmanaged[Cdecl]<IntPtr, float>)postProcessComponentFunctions[head++];
				PostProcessComponent.setEnabled = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)postProcessComponentFunctions[head++];
				PostProcessComponent.setBlendRadius = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)postProcessComponentFunctions[head++];
				PostProcessComponent.setBlendWeight = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)postProcessComponentFunctions[head++];
				PostProcessComponent.setUnbound = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)postProcessComponentFunctions[head++];
				PostProcessComponent.setPriority = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)postProcessComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* primitiveComponentFunctions = (IntPtr*)buffer[position++];

				PrimitiveComponent.isGravityEnabled = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)primitiveComponentFunctions[head++];
				PrimitiveComponent.isOverlappingComponent = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool>)primitiveComponentFunctions[head++];
				PrimitiveComponent.forEachOverlappingComponent = (delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.addAngularImpulseInDegrees = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.addAngularImpulseInRadians = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.addForce = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.addForceAtLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, in Vector3, string, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.addImpulse = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.addImpulseAtLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, in Vector3, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.addRadialForce = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, float, float, Bool, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.addRadialImpulse = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, float, float, Bool, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.addTorqueInDegrees = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.addTorqueInRadians = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getMass = (delegate* unmanaged[Cdecl]<IntPtr, float>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getPhysicsLinearVelocity = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getPhysicsLinearVelocityAtPoint = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, in Vector3, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getPhysicsAngularVelocityInDegrees = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getPhysicsAngularVelocityInRadians = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getCastShadow = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getOnlyOwnerSee = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getOwnerNoSee = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getIgnoreRadialForce = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getIgnoreRadialImpulse = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getMaterial = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getMaterialsNumber = (delegate* unmanaged[Cdecl]<IntPtr, int>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getDistanceToCollision = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, ref Vector3, float>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getSquaredDistanceToCollision = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, ref float, ref Vector3, Bool>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getAngularDamping = (delegate* unmanaged[Cdecl]<IntPtr, float>)primitiveComponentFunctions[head++];
				PrimitiveComponent.getLinearDamping = (delegate* unmanaged[Cdecl]<IntPtr, float>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setGenerateOverlapEvents = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setGenerateHitEvents = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setMass = (delegate* unmanaged[Cdecl]<IntPtr, float, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setCenterOfMass = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setPhysicsLinearVelocity = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, Bool, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setPhysicsAngularVelocityInDegrees = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, Bool, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setPhysicsAngularVelocityInRadians = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, Bool, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setPhysicsMaxAngularVelocityInDegrees = (delegate* unmanaged[Cdecl]<IntPtr, float, Bool, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setPhysicsMaxAngularVelocityInRadians = (delegate* unmanaged[Cdecl]<IntPtr, float, Bool, string, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setCastShadow = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setOnlyOwnerSee = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setOwnerNoSee = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setIgnoreRadialForce = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setIgnoreRadialImpulse = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setMaterial = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setSimulatePhysics = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setAngularDamping = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setLinearDamping = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setEnableGravity = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setCollisionMode = (delegate* unmanaged[Cdecl]<IntPtr, CollisionMode, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setCollisionChannel = (delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setCollisionProfileName = (delegate* unmanaged[Cdecl]<IntPtr, string, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setCollisionResponseToChannel = (delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel, CollisionResponse, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setCollisionResponseToAllChannels = (delegate* unmanaged[Cdecl]<IntPtr, CollisionResponse, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setIgnoreActorWhenMoving = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.setIgnoreComponentWhenMoving = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.clearMoveIgnoreActors = (delegate* unmanaged[Cdecl]<IntPtr, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.clearMoveIgnoreComponents = (delegate* unmanaged[Cdecl]<IntPtr, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.createAndSetMaterialInstanceDynamic = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr>)primitiveComponentFunctions[head++];
				PrimitiveComponent.registerEvent = (delegate* unmanaged[Cdecl]<IntPtr, ComponentEventType, void>)primitiveComponentFunctions[head++];
				PrimitiveComponent.unregisterEvent = (delegate* unmanaged[Cdecl]<IntPtr, ComponentEventType, void>)primitiveComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* shapeComponentFunctions = (IntPtr*)buffer[position++];

				ShapeComponent.getDynamicObstacle = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)shapeComponentFunctions[head++];
				ShapeComponent.getShapeColor = (delegate* unmanaged[Cdecl]<IntPtr, int>)shapeComponentFunctions[head++];
				ShapeComponent.setDynamicObstacle = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)shapeComponentFunctions[head++];
				ShapeComponent.setShapeColor = (delegate* unmanaged[Cdecl]<IntPtr, int, void>)shapeComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* boxComponentFunctions = (IntPtr*)buffer[position++];

				BoxComponent.getScaledBoxExtent = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)boxComponentFunctions[head++];
				BoxComponent.getUnscaledBoxExtent = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void>)boxComponentFunctions[head++];
				BoxComponent.setBoxExtent = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, Bool, void>)boxComponentFunctions[head++];
				BoxComponent.initBoxExtent = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void>)boxComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* sphereComponentFunctions = (IntPtr*)buffer[position++];

				SphereComponent.getScaledSphereRadius = (delegate* unmanaged[Cdecl]<IntPtr, float>)sphereComponentFunctions[head++];
				SphereComponent.getUnscaledSphereRadius = (delegate* unmanaged[Cdecl]<IntPtr, float>)sphereComponentFunctions[head++];
				SphereComponent.getShapeScale = (delegate* unmanaged[Cdecl]<IntPtr, float>)sphereComponentFunctions[head++];
				SphereComponent.setSphereRadius = (delegate* unmanaged[Cdecl]<IntPtr, float, Bool, void>)sphereComponentFunctions[head++];
				SphereComponent.initSphereRadius = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)sphereComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* capsuleComponentFunctions = (IntPtr*)buffer[position++];

				CapsuleComponent.getScaledCapsuleRadius = (delegate* unmanaged[Cdecl]<IntPtr, float>)capsuleComponentFunctions[head++];
				CapsuleComponent.getUnscaledCapsuleRadius = (delegate* unmanaged[Cdecl]<IntPtr, float>)capsuleComponentFunctions[head++];
				CapsuleComponent.getShapeScale = (delegate* unmanaged[Cdecl]<IntPtr, float>)capsuleComponentFunctions[head++];
				CapsuleComponent.getScaledCapsuleSize = (delegate* unmanaged[Cdecl]<IntPtr, ref float, ref float, void>)capsuleComponentFunctions[head++];
				CapsuleComponent.getUnscaledCapsuleSize = (delegate* unmanaged[Cdecl]<IntPtr, ref float, ref float, void>)capsuleComponentFunctions[head++];
				CapsuleComponent.setCapsuleRadius = (delegate* unmanaged[Cdecl]<IntPtr, float, Bool, void>)capsuleComponentFunctions[head++];
				CapsuleComponent.setCapsuleSize = (delegate* unmanaged[Cdecl]<IntPtr, float, float, Bool, void>)capsuleComponentFunctions[head++];
				CapsuleComponent.initCapsuleSize = (delegate* unmanaged[Cdecl]<IntPtr, float, float, void>)capsuleComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* meshComponentFunctions = (IntPtr*)buffer[position++];

				MeshComponent.isValidMaterialSlotName = (delegate* unmanaged[Cdecl]<IntPtr, string, Bool>)meshComponentFunctions[head++];
				MeshComponent.getMaterialIndex = (delegate* unmanaged[Cdecl]<IntPtr, string, int>)meshComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* textRenderComponentFunctions = (IntPtr*)buffer[position++];

				TextRenderComponent.setFont = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)textRenderComponentFunctions[head++];
				TextRenderComponent.setText = (delegate* unmanaged[Cdecl]<IntPtr, string, void>)textRenderComponentFunctions[head++];
				TextRenderComponent.setTextMaterial = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)textRenderComponentFunctions[head++];
				TextRenderComponent.setTextRenderColor = (delegate* unmanaged[Cdecl]<IntPtr, int, void>)textRenderComponentFunctions[head++];
				TextRenderComponent.setHorizontalAlignment = (delegate* unmanaged[Cdecl]<IntPtr, HorizontalTextAligment, void>)textRenderComponentFunctions[head++];
				TextRenderComponent.setHorizontalSpacingAdjustment = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)textRenderComponentFunctions[head++];
				TextRenderComponent.setVerticalAlignment = (delegate* unmanaged[Cdecl]<IntPtr, VerticalTextAligment, void>)textRenderComponentFunctions[head++];
				TextRenderComponent.setVerticalSpacingAdjustment = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)textRenderComponentFunctions[head++];
				TextRenderComponent.setScale = (delegate* unmanaged[Cdecl]<IntPtr, in Vector2, void>)textRenderComponentFunctions[head++];
				TextRenderComponent.setWorldSize = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)textRenderComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* lightComponentBaseFunctions = (IntPtr*)buffer[position++];

				LightComponentBase.getIntensity = (delegate* unmanaged[Cdecl]<IntPtr, float>)lightComponentBaseFunctions[head++];
				LightComponentBase.getCastShadows = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)lightComponentBaseFunctions[head++];
				LightComponentBase.setCastShadows = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)lightComponentBaseFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* lightComponentFunctions = (IntPtr*)buffer[position++];

				LightComponent.setIntensity = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)lightComponentFunctions[head++];
				LightComponent.setLightColor = (delegate* unmanaged[Cdecl]<IntPtr, in LinearColor, void>)lightComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* motionControllerComponentFunctions = (IntPtr*)buffer[position++];

				MotionControllerComponent.isTracked = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)motionControllerComponentFunctions[head++];
				MotionControllerComponent.getDisplayDeviceModel = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)motionControllerComponentFunctions[head++];
				MotionControllerComponent.getDisableLowLatencyUpdate = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)motionControllerComponentFunctions[head++];
				MotionControllerComponent.getTrackingSource = (delegate* unmanaged[Cdecl]<IntPtr, ControllerHand>)motionControllerComponentFunctions[head++];
				MotionControllerComponent.setDisplayDeviceModel = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)motionControllerComponentFunctions[head++];
				MotionControllerComponent.setDisableLowLatencyUpdate = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)motionControllerComponentFunctions[head++];
				MotionControllerComponent.setTrackingSource = (delegate* unmanaged[Cdecl]<IntPtr, ControllerHand, void>)motionControllerComponentFunctions[head++];
				MotionControllerComponent.setTrackingMotionSource = (delegate* unmanaged[Cdecl]<IntPtr, string, void>)motionControllerComponentFunctions[head++];
				MotionControllerComponent.setAssociatedPlayerIndex = (delegate* unmanaged[Cdecl]<IntPtr, int, void>)motionControllerComponentFunctions[head++];
				MotionControllerComponent.setCustomDisplayMesh = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)motionControllerComponentFunctions[head++];
				MotionControllerComponent.setDisplayModelSource = (delegate* unmanaged[Cdecl]<IntPtr, string, void>)motionControllerComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* staticMeshComponentFunctions = (IntPtr*)buffer[position++];

				StaticMeshComponent.getLocalBounds = (delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, ref Vector3, void>)staticMeshComponentFunctions[head++];
				StaticMeshComponent.getStaticMesh = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)staticMeshComponentFunctions[head++];
				StaticMeshComponent.setStaticMesh = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool>)staticMeshComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* instancedStaticMeshComponentFunctions = (IntPtr*)buffer[position++];

				InstancedStaticMeshComponent.getInstanceCount = (delegate* unmanaged[Cdecl]<IntPtr, int>)instancedStaticMeshComponentFunctions[head++];
				InstancedStaticMeshComponent.getInstanceTransform = (delegate* unmanaged[Cdecl]<IntPtr, int, ref Transform, Bool, Bool>)instancedStaticMeshComponentFunctions[head++];
				InstancedStaticMeshComponent.addInstance = (delegate* unmanaged[Cdecl]<IntPtr, in Transform, void>)instancedStaticMeshComponentFunctions[head++];
				InstancedStaticMeshComponent.addInstances = (delegate* unmanaged[Cdecl]<IntPtr, int, Transform[], void>)instancedStaticMeshComponentFunctions[head++];
				InstancedStaticMeshComponent.updateInstanceTransform = (delegate* unmanaged[Cdecl]<IntPtr, int, in Transform, Bool, Bool, Bool, Bool>)instancedStaticMeshComponentFunctions[head++];
				InstancedStaticMeshComponent.batchUpdateInstanceTransforms = (delegate* unmanaged[Cdecl]<IntPtr, int, int, Transform[], Bool, Bool, Bool, Bool>)instancedStaticMeshComponentFunctions[head++];
				InstancedStaticMeshComponent.removeInstance = (delegate* unmanaged[Cdecl]<IntPtr, int, Bool>)instancedStaticMeshComponentFunctions[head++];
				InstancedStaticMeshComponent.clearInstances = (delegate* unmanaged[Cdecl]<IntPtr, void>)instancedStaticMeshComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* hierarchicalInstancedStaticMeshComponentFunctions = (IntPtr*)buffer[position++];

				HierarchicalInstancedStaticMeshComponent.getDisableCollision = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)hierarchicalInstancedStaticMeshComponentFunctions[head++];
				HierarchicalInstancedStaticMeshComponent.setDisableCollision = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)hierarchicalInstancedStaticMeshComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* skinnedMeshComponentFunctions = (IntPtr*)buffer[position++];

				SkinnedMeshComponent.getBonesNumber = (delegate* unmanaged[Cdecl]<IntPtr, int>)skinnedMeshComponentFunctions[head++];
				SkinnedMeshComponent.getBoneIndex = (delegate* unmanaged[Cdecl]<IntPtr, string, int>)skinnedMeshComponentFunctions[head++];
				SkinnedMeshComponent.getBoneName = (delegate* unmanaged[Cdecl]<IntPtr, int, byte[], void>)skinnedMeshComponentFunctions[head++];
				SkinnedMeshComponent.getBoneTransform = (delegate* unmanaged[Cdecl]<IntPtr, int, ref Transform, void>)skinnedMeshComponentFunctions[head++];
				SkinnedMeshComponent.setSkeletalMesh = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool, void>)skinnedMeshComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* skeletalMeshComponentFunctions = (IntPtr*)buffer[position++];

				SkeletalMeshComponent.isPlaying = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)skeletalMeshComponentFunctions[head++];
				SkeletalMeshComponent.getAnimationInstance = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)skeletalMeshComponentFunctions[head++];
				SkeletalMeshComponent.setAnimation = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)skeletalMeshComponentFunctions[head++];
				SkeletalMeshComponent.setAnimationMode = (delegate* unmanaged[Cdecl]<IntPtr, AnimationMode, void>)skeletalMeshComponentFunctions[head++];
				SkeletalMeshComponent.setAnimationBlueprint = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)skeletalMeshComponentFunctions[head++];
				SkeletalMeshComponent.play = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)skeletalMeshComponentFunctions[head++];
				SkeletalMeshComponent.playAnimation = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool, void>)skeletalMeshComponentFunctions[head++];
				SkeletalMeshComponent.stop = (delegate* unmanaged[Cdecl]<IntPtr, void>)skeletalMeshComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* splineComponentFunctions = (IntPtr*)buffer[position++];

				SplineComponent.isClosedLoop = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)splineComponentFunctions[head++];
				SplineComponent.getDuration = (delegate* unmanaged[Cdecl]<IntPtr, float>)splineComponentFunctions[head++];
				SplineComponent.getSplinePointType = (delegate* unmanaged[Cdecl]<IntPtr, int, SplinePointType>)splineComponentFunctions[head++];
				SplineComponent.getSplinePointsNumber = (delegate* unmanaged[Cdecl]<IntPtr, int>)splineComponentFunctions[head++];
				SplineComponent.getSplineSegmentsNumber = (delegate* unmanaged[Cdecl]<IntPtr, int>)splineComponentFunctions[head++];
				SplineComponent.getTangentAtDistanceAlongSpline = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getTangentAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getTangentAtTime = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getTransformAtDistanceAlongSpline = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Transform, void>)splineComponentFunctions[head++];
				SplineComponent.getTransformAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, Bool, ref Transform, void>)splineComponentFunctions[head++];
				SplineComponent.getArriveTangentAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getDefaultUpVector = (delegate* unmanaged[Cdecl]<IntPtr, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getDirectionAtDistanceAlongSpline = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getDirectionAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getDirectionAtTime = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getDistanceAlongSplineAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, float>)splineComponentFunctions[head++];
				SplineComponent.getLeaveTangentAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getLocationAndTangentAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getLocationAtDistanceAlongSpline = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getLocationAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getLocationAtTime = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getRightVectorAtDistanceAlongSpline = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getRightVectorAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getRightVectorAtTime = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getRollAtDistanceAlongSpline = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, float>)splineComponentFunctions[head++];
				SplineComponent.getRollAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, float>)splineComponentFunctions[head++];
				SplineComponent.getRollAtTime = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, float>)splineComponentFunctions[head++];
				SplineComponent.getRotationAtDistanceAlongSpline = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Quaternion, void>)splineComponentFunctions[head++];
				SplineComponent.getRotationAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Quaternion, void>)splineComponentFunctions[head++];
				SplineComponent.getRotationAtTime = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, ref Quaternion, void>)splineComponentFunctions[head++];
				SplineComponent.getScaleAtDistanceAlongSpline = (delegate* unmanaged[Cdecl]<IntPtr, float, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getScaleAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getScaleAtTime = (delegate* unmanaged[Cdecl]<IntPtr, float, Bool, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getSplineLength = (delegate* unmanaged[Cdecl]<IntPtr, float>)splineComponentFunctions[head++];
				SplineComponent.getTransformAtTime = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, Bool, ref Transform, void>)splineComponentFunctions[head++];
				SplineComponent.getUpVectorAtDistanceAlongSpline = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getUpVectorAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.getUpVectorAtTime = (delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.setDuration = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)splineComponentFunctions[head++];
				SplineComponent.setSplinePointType = (delegate* unmanaged[Cdecl]<IntPtr, int, SplinePointType, Bool, void>)splineComponentFunctions[head++];
				SplineComponent.setClosedLoop = (delegate* unmanaged[Cdecl]<IntPtr, Bool, Bool, void>)splineComponentFunctions[head++];
				SplineComponent.setDefaultUpVector = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, void>)splineComponentFunctions[head++];
				SplineComponent.setLocationAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, in Vector3, SplineCoordinateSpace, Bool, void>)splineComponentFunctions[head++];
				SplineComponent.setTangentAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, in Vector3, SplineCoordinateSpace, Bool, void>)splineComponentFunctions[head++];
				SplineComponent.setTangentsAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, in Vector3, in Vector3, SplineCoordinateSpace, Bool, void>)splineComponentFunctions[head++];
				SplineComponent.setUpVectorAtSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, in Vector3, SplineCoordinateSpace, Bool, void>)splineComponentFunctions[head++];
				SplineComponent.addSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, Bool, void>)splineComponentFunctions[head++];
				SplineComponent.addSplinePointAtIndex = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, int, SplineCoordinateSpace, Bool, void>)splineComponentFunctions[head++];
				SplineComponent.clearSplinePoints = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)splineComponentFunctions[head++];
				SplineComponent.findDirectionClosestToWorldLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.findLocationClosestToWorldLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.findUpVectorClosestToWorldLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.findRightVectorClosestToWorldLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.findRollClosestToWorldLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, float>)splineComponentFunctions[head++];
				SplineComponent.findScaleClosestToWorldLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.findTangentClosestToWorldLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, ref Vector3, void>)splineComponentFunctions[head++];
				SplineComponent.findTransformClosestToWorldLocation = (delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, Bool, ref Transform, void>)splineComponentFunctions[head++];
				SplineComponent.removeSplinePoint = (delegate* unmanaged[Cdecl]<IntPtr, int, Bool, void>)splineComponentFunctions[head++];
				SplineComponent.updateSpline = (delegate* unmanaged[Cdecl]<IntPtr, void>)splineComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* radialForceComponentFunctions = (IntPtr*)buffer[position++];

				RadialForceComponent.getIgnoreOwningActor = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)radialForceComponentFunctions[head++];
				RadialForceComponent.getImpulseVelocityChange = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)radialForceComponentFunctions[head++];
				RadialForceComponent.getLinearFalloff = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)radialForceComponentFunctions[head++];
				RadialForceComponent.getForceStrength = (delegate* unmanaged[Cdecl]<IntPtr, float>)radialForceComponentFunctions[head++];
				RadialForceComponent.getImpulseStrength = (delegate* unmanaged[Cdecl]<IntPtr, float>)radialForceComponentFunctions[head++];
				RadialForceComponent.getRadius = (delegate* unmanaged[Cdecl]<IntPtr, float>)radialForceComponentFunctions[head++];
				RadialForceComponent.setIgnoreOwningActor = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)radialForceComponentFunctions[head++];
				RadialForceComponent.setImpulseVelocityChange = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)radialForceComponentFunctions[head++];
				RadialForceComponent.setLinearFalloff = (delegate* unmanaged[Cdecl]<IntPtr, Bool, void>)radialForceComponentFunctions[head++];
				RadialForceComponent.setForceStrength = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)radialForceComponentFunctions[head++];
				RadialForceComponent.setImpulseStrength = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)radialForceComponentFunctions[head++];
				RadialForceComponent.setRadius = (delegate* unmanaged[Cdecl]<IntPtr, float, void>)radialForceComponentFunctions[head++];
				RadialForceComponent.addCollisionChannelToAffect = (delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel, void>)radialForceComponentFunctions[head++];
				RadialForceComponent.fireImpulse = (delegate* unmanaged[Cdecl]<IntPtr, void>)radialForceComponentFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* materialInterfaceFunctions = (IntPtr*)buffer[position++];

				MaterialInterface.isTwoSided = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)materialInterfaceFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* materialFunctions = (IntPtr*)buffer[position++];

				Material.isDefaultMaterial = (delegate* unmanaged[Cdecl]<IntPtr, Bool>)materialFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* materialInstanceFunctions = (IntPtr*)buffer[position++];

				MaterialInstance.isChildOf = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool>)materialInstanceFunctions[head++];
				MaterialInstance.getParent = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)materialInstanceFunctions[head++];
			}

			unchecked {
				int head = 0;
				IntPtr* materialInstanceDynamicFunctions = (IntPtr*)buffer[position++];

				MaterialInstanceDynamic.clearParameterValues = (delegate* unmanaged[Cdecl]<IntPtr, void>)materialInstanceDynamicFunctions[head++];
				MaterialInstanceDynamic.setTextureParameterValue = (delegate* unmanaged[Cdecl]<IntPtr, string, IntPtr, void>)materialInstanceDynamicFunctions[head++];
				MaterialInstanceDynamic.setVectorParameterValue = (delegate* unmanaged[Cdecl]<IntPtr, string, in LinearColor, void>)materialInstanceDynamicFunctions[head++];
				MaterialInstanceDynamic.setScalarParameterValue = (delegate* unmanaged[Cdecl]<IntPtr, string, float, void>)materialInstanceDynamicFunctions[head++];
			}

			unchecked {
				Type[] types = pluginAssembly.GetTypes();

				foreach (Type type in types) {
					MethodInfo[] methods = type.GetMethods();

					if (type.Name == "Main" && type.IsPublic) {
						foreach (MethodInfo method in methods) {
							if (method.IsPublic && method.IsStatic && !method.IsGenericMethod) {
								ParameterInfo[] parameterInfos = method.GetParameters();

								if (parameterInfos.Length <= 1) {
									if (method.Name == "OnWorldBegin") {
										if (parameterInfos.Length == 0)
											events[0] = GetFunctionPointer(method);
										else
											throw new ArgumentException(method.Name + " should not have arguments");

										continue;
									}

									if (method.Name == "OnWorldPostBegin") {
										if (parameterInfos.Length == 0)
											events[1] = GetFunctionPointer(method);
										else
											throw new ArgumentException(method.Name + " should not have arguments");

										continue;
									}

									if (method.Name == "OnWorldPrePhysicsTick") {
										if (parameterInfos.Length == 1 && parameterInfos[0].ParameterType == typeof(float))
											events[2] = GetFunctionPointer(method);
										else
											throw new ArgumentException(method.Name + " should have a float argument");

										continue;
									}

									if (method.Name == "OnWorldDuringPhysicsTick") {
										if (parameterInfos.Length == 1 && parameterInfos[0].ParameterType == typeof(float))
											events[3] = GetFunctionPointer(method);
										else
											throw new ArgumentException(method.Name + " should have a float argument");

										continue;
									}

									if (method.Name == "OnWorldPostPhysicsTick") {
										if (parameterInfos.Length == 1 && parameterInfos[0].ParameterType == typeof(float))
											events[4] = GetFunctionPointer(method);
										else
											throw new ArgumentException(method.Name + " should have a float argument");

										continue;
									}

									if (method.Name == "OnWorldPostUpdateTick") {
										if (parameterInfos.Length == 1 && parameterInfos[0].ParameterType == typeof(float))
											events[5] = GetFunctionPointer(method);
										else
											throw new ArgumentException(method.Name + " should have a float argument");

										continue;
									}

									if (method.Name == "OnWorldEnd") {
										if (parameterInfos.Length == 0)
											events[6] = GetFunctionPointer(method);
										else
											throw new ArgumentException(method.Name + " should not have arguments");

										continue;
									}
								}
							}
						}
					}

					foreach (MethodInfo method in methods) {
						if (method.IsPublic && method.IsStatic && !method.IsGenericMethod) {
							ParameterInfo[] parameterInfos = method.GetParameters();

							if (parameterInfos.Length <= 1) {
								if (parameterInfos.Length == 1 && parameterInfos[0].ParameterType != typeof(ObjectReference))
									continue;

								string name = type.FullName + "." + method.Name;

								userFunctions.Add(name.GetHashCode(StringComparison.Ordinal), GetFunctionPointer(method));
							}
						}
					}
				}
			}

			Directory.SetCurrentDirectory(Application.ProjectDirectory);

			GC.Collect();
			GC.WaitForPendingFinalizers();

			return userFunctions;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static string GetTypeName(Type type) => type.FullName.Replace(".", string.Empty, StringComparison.Ordinal);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static string GetMethodName(Type[] parameters, Type returnType) {
			string name = GetTypeName(returnType);

			foreach (Type type in parameters) {
				name += '_' + GetTypeName(type);
			}

			return name;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Type GetDelegateType(Type[] parameters, Type returnType) {
			string methodName = GetMethodName(parameters, returnType);

			return delegateTypesCache.GetOrAdd(methodName, () => MakeDelegate(parameters, returnType, methodName));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Type MakeDelegate(Type[] types, Type returnType, string name) {
			TypeBuilder builder = moduleBuilder.DefineType(name, delegateTypeAttributes, typeof(MulticastDelegate));

			builder.DefineConstructor(ctorAttributes, CallingConventions.Standard, delegateCtorSignature).SetImplementationFlags(implAttributes);
			builder.DefineMethod("Invoke", invokeAttributes, returnType, types).SetImplementationFlags(implAttributes);

			return builder.CreateTypeInfo();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static IntPtr GetFunctionPointer(MethodInfo method) {
			string methodName = $"{ method.DeclaringType.FullName }.{ method.Name }";

			Delegate dynamicDelegate = delegatesCache.GetOrAdd(methodName, () => {
				ParameterInfo[] parameterInfos = method.GetParameters();
				Type[] parameterTypes = new Type[parameterInfos.Length];

				for (int i = 0; i < parameterTypes.Length; i++) {
					parameterTypes[i] = parameterInfos[i].ParameterType;
				}

				return method.CreateDelegate(GetDelegateType(parameterTypes, method.ReturnType));
			});

			return Collector.GetFunctionPointer(dynamicDelegate);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	partial struct LinearColor {
		private float r;
		private float g;
		private float b;
		private float a;
	}

	[StructLayout(LayoutKind.Sequential)]
	partial struct Transform {
		private Vector3 location;
		private Quaternion rotation;
		private Vector3 scale;
	}

	[StructLayout(LayoutKind.Sequential)]
	partial struct Hit {
		private Vector3 location;
		private Vector3 impactLocation;
		private Vector3 normal;
		private Vector3 impactNormal;
		private Vector3 traceStart;
		private Vector3 traceEnd;
		private IntPtr actor;
		private float time;
		private float distance;
		private float penetrationDepth;
		private Bool blockingHit;
		private Bool startPenetrating;
	}

	[StructLayout(LayoutKind.Explicit, Size = 28)]
	partial struct Bounds {
		[FieldOffset(0)]
		private Vector3 origin;
		[FieldOffset(12)]
		private Vector3 boxExtent;
		[FieldOffset(24)]
		private float sphereRadius;
	}

	[StructLayout(LayoutKind.Explicit, Size = 16)]
	partial struct CollisionShape {
		[FieldOffset(0)]
		private CollisionShapeType shapeType;
		[FieldOffset(4)]
		private Box box;
		[FieldOffset(4)]
		private Sphere sphere;
		[FieldOffset(4)]
		private Capsule capsule;

		private struct Box {
			internal Vector3 halfExtent;
		}

		private struct Sphere {
			internal float radius;
		}

		private struct Capsule {
			internal float radius;
			internal float halfHeight;
		}
	}

	internal struct Bool {
		private byte value;

		public Bool(byte value) => this.value = value;

		public static implicit operator bool(Bool value) => value.value != 0;

		public static implicit operator Bool(bool value) => !value ? new(0) : new(1);

		public override int GetHashCode() => value.GetHashCode();
	}

	internal enum ObjectType : int {
		Blueprint,
		SoundWave,
		AnimationSequence,
		AnimationMontage,
		StaticMesh,
		SkeletalMesh,
		Material,
		Font,
		Texture2D
	}

	internal enum ActorType : int {
		Base,
		Camera,
		TriggerBox,
		TriggerSphere,
		TriggerCapsule,
		Pawn,
		Character,
		AIController,
		PlayerController,
		Brush,
		AmbientSound,
		DirectionalLight,
		PointLight,
		RectLight,
		SpotLight,
		TriggerVolume,
		PostProcessVolume,
		LevelScript,
		GameModeBase
	}

	internal enum ComponentType : int {
		// Non-attachable
		Actor,
		Input,
		// Attachable
		Scene,
		Audio,
		Camera,
		Light,
		DirectionalLight,
		MotionController,
		StaticMesh,
		InstancedStaticMesh,
		HierarchicalInstancedStaticMesh,
		ChildActor,
		SpringArm,
		PostProcess,
		Box,
		Sphere,
		Capsule,
		TextRender,
		SkeletalMesh,
		Spline,
		RadialForce
	}

	static unsafe partial class Assert {
		internal static delegate* unmanaged[Cdecl]<byte[], void> outputMessage;
	}

	static unsafe partial class CommandLine {
		internal static delegate* unmanaged[Cdecl]<byte[], void> get;
		internal static delegate* unmanaged[Cdecl]<string, void> set;
		internal static delegate* unmanaged[Cdecl]<string, void> append;
	}

	static unsafe partial class Debug {
		internal static delegate* unmanaged[Cdecl]<LogLevel, byte[], void> log;
		internal static delegate* unmanaged[Cdecl]<byte[], void> exception;
		internal static delegate* unmanaged[Cdecl]<int, float, int, byte[], void> addOnScreenMessage;
		internal static delegate* unmanaged[Cdecl]<void> clearOnScreenMessages;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, in Quaternion, int, Bool, float, byte, float, void> drawBox;
		internal static delegate* unmanaged[Cdecl]<in Vector3, float, float, in Quaternion, int, Bool, float, byte, float, void> drawCapsule;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, float, float, float, int, int, Bool, float, byte, float, void> drawCone;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, float, int, int, Bool, float, byte, float, void> drawCylinder;
		internal static delegate* unmanaged[Cdecl]<in Vector3, float, int, int, Bool, float, byte, float, void> drawSphere;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, int, Bool, float, byte, float, void> drawLine;
		internal static delegate* unmanaged[Cdecl]<in Vector3, float, int, Bool, float, byte, void> drawPoint;
		internal static delegate* unmanaged[Cdecl]<void> flushPersistentLines;
	}

	internal static unsafe class Object {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isPendingKill;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isValid;
		internal static delegate* unmanaged[Cdecl]<ObjectType, string, IntPtr> load;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, void> rename;
		internal static delegate* unmanaged[Cdecl]<IntPtr, byte[], Bool> invoke;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ActorType, IntPtr> toActor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ComponentType, IntPtr> toComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, uint> getID;
		internal static delegate* unmanaged[Cdecl]<IntPtr, byte[], void> getName;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref bool, Bool> getBool;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref byte, Bool> getByte;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref short, Bool> getShort;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref int, Bool> getInt;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref long, Bool> getLong;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref ushort, Bool> getUShort;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref uint, Bool> getUInt;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref ulong, Bool> getULong;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref float, Bool> getFloat;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref double, Bool> getDouble;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref int, Bool> getEnum;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, byte[], Bool> getString;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, byte[], Bool> getText;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, Bool, Bool> setBool;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, byte, Bool> setByte;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, short, Bool> setShort;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, int, Bool> setInt;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, long, Bool> setLong;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ushort, Bool> setUShort;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, uint, Bool> setUInt;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ulong, Bool> setULong;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, float, Bool> setFloat;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, double, Bool> setDouble;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, int, Bool> setEnum;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, string, Bool> setString;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, string, Bool> setText;
	}

	static unsafe partial class Application {
		internal static delegate* unmanaged[Cdecl]<Bool> isCanEverRender;
		internal static delegate* unmanaged[Cdecl]<Bool> isPackagedForDistribution;
		internal static delegate* unmanaged[Cdecl]<Bool> isPackagedForShipping;
		internal static delegate* unmanaged[Cdecl]<byte[], void> getProjectDirectory;
		internal static delegate* unmanaged[Cdecl]<byte[], void> getDefaultLanguage;
		internal static delegate* unmanaged[Cdecl]<byte[], void> getProjectName;
		internal static delegate* unmanaged[Cdecl]<float> getVolumeMultiplier;
		internal static delegate* unmanaged[Cdecl]<string, void> setProjectName;
		internal static delegate* unmanaged[Cdecl]<float, void> setVolumeMultiplier;
		internal static delegate* unmanaged[Cdecl]<Bool, void> requestExit;
	}

	static unsafe partial class ConsoleManager {
		internal static delegate* unmanaged[Cdecl]<string, Bool> isRegisteredVariable;
		internal static delegate* unmanaged[Cdecl]<string, IntPtr> findVariable;
		internal static delegate* unmanaged[Cdecl]<string, string, Bool, Bool, IntPtr> registerVariableBool;
		internal static delegate* unmanaged[Cdecl]<string, string, int, Bool, IntPtr> registerVariableInt;
		internal static delegate* unmanaged[Cdecl]<string, string, float, Bool, IntPtr> registerVariableFloat;
		internal static delegate* unmanaged[Cdecl]<string, string, string, Bool, IntPtr> registerVariableString;
		internal static delegate* unmanaged[Cdecl]<string, string, IntPtr, Bool, void> registerCommand;
		internal static delegate* unmanaged[Cdecl]<string, void> unregisterObject;
	}

	static unsafe partial class Engine {
		internal static delegate* unmanaged[Cdecl]<Bool> isSplitScreen;
		internal static delegate* unmanaged[Cdecl]<Bool> isEditor;
		internal static delegate* unmanaged[Cdecl]<Bool> isForegroundWindow;
		internal static delegate* unmanaged[Cdecl]<Bool> isExitRequested;
		internal static delegate* unmanaged[Cdecl]<NetMode> getNetMode;
		internal static delegate* unmanaged[Cdecl]<uint> getFrameNumber;
		internal static delegate* unmanaged[Cdecl]<ref Vector2, void> getViewportSize;
		internal static delegate* unmanaged[Cdecl]<ref Vector2, void> getScreenResolution;
		internal static delegate* unmanaged[Cdecl]<WindowMode> getWindowMode;
		internal static delegate* unmanaged[Cdecl]<byte[], void> getVersion;
		internal static delegate* unmanaged[Cdecl]<float> getMaxFPS;
		internal static delegate* unmanaged[Cdecl]<float, void> setMaxFPS;
		internal static delegate* unmanaged[Cdecl]<string, void> setTitle;
		internal static delegate* unmanaged[Cdecl]<string, string, Bool, Bool, Bool, Bool, void> addActionMapping;
		internal static delegate* unmanaged[Cdecl]<string, string, float, void> addAxisMapping;
		internal static delegate* unmanaged[Cdecl]<Bool, void> forceGarbageCollection;
		internal static delegate* unmanaged[Cdecl]<void> delayGarbageCollection;
	}

	static unsafe partial class HeadMountedDisplay {
		internal static delegate* unmanaged[Cdecl]<Bool> isConnected;
		internal static delegate* unmanaged[Cdecl]<Bool> getEnabled;
		internal static delegate* unmanaged[Cdecl]<Bool> getLowPersistenceMode;
		internal static delegate* unmanaged[Cdecl]<byte[], void> getDeviceName;
		internal static delegate* unmanaged[Cdecl]<Bool, void> setEnable;
		internal static delegate* unmanaged[Cdecl]<Bool, void> setLowPersistenceMode;
	}

	static unsafe partial class World {
		internal static delegate* unmanaged[Cdecl]<ref ObjectReference*, ref int, void> forEachActor;
		internal static delegate* unmanaged[Cdecl]<int> getActorCount;
		internal static delegate* unmanaged[Cdecl]<float> getDeltaSeconds;
		internal static delegate* unmanaged[Cdecl]<float> getRealTimeSeconds;
		internal static delegate* unmanaged[Cdecl]<float> getTimeSeconds;
		internal static delegate* unmanaged[Cdecl]<byte[], void> getCurrentLevelName;
		internal static delegate* unmanaged[Cdecl]<Bool> getSimulatePhysics;
		internal static delegate* unmanaged[Cdecl]<ref Vector3, void> getWorldOrigin;
		internal static delegate* unmanaged[Cdecl]<string, ActorType, IntPtr> getActor;
		internal static delegate* unmanaged[Cdecl]<string, ActorType, IntPtr> getActorByTag;
		internal static delegate* unmanaged[Cdecl]<uint, ActorType, IntPtr> getActorByID;
		internal static delegate* unmanaged[Cdecl]<IntPtr> getFirstPlayerController;
		internal static delegate* unmanaged[Cdecl]<IntPtr> getGameMode;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnActorBeginOverlapCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnActorEndOverlapCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnActorHitCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnActorBeginCursorOverCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnActorEndCursorOverCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnActorClickedCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnActorReleasedCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnComponentBeginOverlapCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnComponentEndOverlapCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnComponentHitCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnComponentBeginCursorOverCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnComponentEndCursorOverCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnComponentClickedCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> setOnComponentReleasedCallback;
		internal static delegate* unmanaged[Cdecl]<Bool, void> setSimulatePhysics;
		internal static delegate* unmanaged[Cdecl]<float, void> setGravity;
		internal static delegate* unmanaged[Cdecl]<in Vector3, Bool> setWorldOrigin;
		internal static delegate* unmanaged[Cdecl]<string, void> openLevel;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, CollisionChannel, Bool, IntPtr, IntPtr, Bool> lineTraceTestByChannel;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, string, Bool, IntPtr, IntPtr, Bool> lineTraceTestByProfile;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, CollisionChannel, ref Hit, byte[], Bool, IntPtr, IntPtr, Bool> lineTraceSingleByChannel;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, string, ref Hit, byte[], Bool, IntPtr, IntPtr, Bool> lineTraceSingleByProfile;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, in Quaternion, CollisionChannel, in CollisionShape, Bool, IntPtr, IntPtr, Bool> sweepTestByChannel;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, in Quaternion, string, in CollisionShape, Bool, IntPtr, IntPtr, Bool> sweepTestByProfile;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, in Quaternion, CollisionChannel, in CollisionShape, ref Hit, byte[], Bool, IntPtr, IntPtr, Bool> sweepSingleByChannel;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Vector3, in Quaternion, string, in CollisionShape, ref Hit, byte[], Bool, IntPtr, IntPtr, Bool> sweepSingleByProfile;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Quaternion, CollisionChannel, in CollisionShape, IntPtr, IntPtr, Bool> overlapAnyTestByChannel;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Quaternion, string, in CollisionShape, IntPtr, IntPtr, Bool> overlapAnyTestByProfile;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Quaternion, CollisionChannel, in CollisionShape, IntPtr, IntPtr, Bool> overlapBlockingTestByChannel;
		internal static delegate* unmanaged[Cdecl]<in Vector3, in Quaternion, string, in CollisionShape, IntPtr, IntPtr, Bool> overlapBlockingTestByProfile;
	}

	unsafe partial struct Asset {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isValid;
		internal static delegate* unmanaged[Cdecl]<IntPtr, byte[], void> getName;
		internal static delegate* unmanaged[Cdecl]<IntPtr, byte[], void> getPath;
	}

	unsafe partial class AssetRegistry {
		internal static delegate* unmanaged[Cdecl]<IntPtr> get;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, Bool, Bool> hasAssets;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, Bool, Bool, ref Asset*, ref int, void> forEachAsset;
	}

	unsafe partial class Blueprint {
		internal static delegate* unmanaged[Cdecl]<IntPtr, ActorType, Bool> isValidActorClass;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ComponentType, Bool> isValidComponentClass;
	}

	unsafe partial class ConsoleObject {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isBool;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isInt;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isFloat;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isString;
	}

	unsafe partial class ConsoleVariable {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getBool;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int> getInt;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getFloat;
		internal static delegate* unmanaged[Cdecl]<IntPtr, byte[], void> getString;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setBool;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, void> setInt;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setFloat;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, void> setString;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> setOnChangedCallback;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> clearOnChangedCallback;
	}

	unsafe partial class Actor {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isPendingKill;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isRootComponentMovable;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool> isOverlappingActor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void> forEachComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void> forEachAttachedActor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void> forEachChildActor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void> forEachOverlappingActor;
		internal static delegate* unmanaged[Cdecl]<string, ActorType, IntPtr, IntPtr> spawn;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> destroy;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, void> rename;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> hide;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, in Quaternion, Bool, Bool, Bool> teleportTo;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ComponentType, IntPtr> getComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ComponentType, IntPtr> getComponentByTag;
		internal static delegate* unmanaged[Cdecl]<IntPtr, uint, ComponentType, IntPtr> getComponentByID;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ComponentType, IntPtr> getRootComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getInputComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getCreationTime;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getBlockInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float> getDistanceTo;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float> getHorizontalDistanceTo;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, ref Vector3, ref Vector3, void> getBounds;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, ref Quaternion, void> getEyesViewPoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool> setRootComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> setInputComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setBlockInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setLifeSpan;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool, void> setEnableInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setEnableCollision;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, void> addTag;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, void> removeTag;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, Bool> hasTag;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ActorEventType, void> registerEvent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ActorEventType, void> unregisterEvent;
	}

	unsafe partial class GameModeBase {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getUseSeamlessTravel;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setUseSeamlessTravel;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, void> swapPlayerControllers;
	}

	unsafe partial class TriggerBase { }

	unsafe partial class TriggerBox { }

	unsafe partial class TriggerCapsule { }

	unsafe partial class TriggerSphere { }

	unsafe partial class Pawn {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isControlled;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isPlayerControlled;
		internal static delegate* unmanaged[Cdecl]<IntPtr, AutoPossessAI> getAutoPossessAI;
		internal static delegate* unmanaged[Cdecl]<IntPtr, AutoReceiveInput> getAutoPossessPlayer;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getUseControllerRotationYaw;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getUseControllerRotationPitch;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getUseControllerRotationRoll;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getGravityDirection;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getAIController;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getPlayerController;
		internal static delegate* unmanaged[Cdecl]<IntPtr, AutoPossessAI, void> setAutoPossessAI;
		internal static delegate* unmanaged[Cdecl]<IntPtr, AutoReceiveInput, void> setAutoPossessPlayer;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setUseControllerRotationYaw;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setUseControllerRotationPitch;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setUseControllerRotationRoll;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> addControllerYawInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> addControllerPitchInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> addControllerRollInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, float, Bool, void> addMovementInput;
	}

	unsafe partial class Character {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isCrouched;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> canCrouch;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> canJump;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> checkJumpInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> clearJumpInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, Bool, Bool, void> launch;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> crouch;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> stopCrouching;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> jump;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> stopJumping;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> setOnLandedCallback;
	}

	unsafe partial class Controller {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isLookInputIgnored;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isMoveInputIgnored;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isPlayerController;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getPawn;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getCharacter;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getViewTarget;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Quaternion, void> getControlRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Quaternion, void> getDesiredRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, in Vector3, Bool, Bool> lineOfSightTo;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void> setControlRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, in Quaternion, void> setInitialLocationAndRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setIgnoreLookInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setIgnoreMoveInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> resetIgnoreLookInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> resetIgnoreMoveInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> possess;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> unpossess;
	}

	unsafe partial class AIController {
		internal static delegate* unmanaged[Cdecl]<IntPtr, AIFocusPriority, void> clearFocus;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getFocalPoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, AIFocusPriority, void> setFocalPoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getFocusActor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getAllowStrafe;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setAllowStrafe;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, AIFocusPriority, void> setFocus;
	}

	unsafe partial class PlayerController {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isPaused;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getShowMouseCursor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getEnableClickEvents;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getEnableMouseOverEvents;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref float, ref float, Bool> getMousePosition;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getPlayer;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getPlayerInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector2, CollisionChannel, ref Hit, Bool, Bool> getHitResultAtScreenPosition;
		internal static delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel, ref Hit, Bool, Bool> getHitResultUnderCursor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setShowMouseCursor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setEnableClickEvents;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setEnableMouseOverEvents;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, float, void> setMousePosition;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, Bool, void> consoleCommand;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, Bool> setPause;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> setViewTarget;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float, float, BlendType, Bool, void> setViewTargetWithBlend;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> addYawInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> addPitchInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> addRollInput;
	}

	unsafe partial class Volume {
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, float, ref float, Bool> encompassesPoint;
	}

	unsafe partial class TriggerVolume { }

	unsafe partial class PostProcessVolume {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getEnabled;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getBlendRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getBlendWeight;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getUnbound;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getPriority;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setEnabled;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setBlendRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setBlendWeight;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setUnbound;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setPriority;
	}

	unsafe partial class LevelScript { }

	unsafe partial class AmbientSound { }

	unsafe partial class Light { }

	unsafe partial class DirectionalLight { }

	unsafe partial class PointLight { }

	unsafe partial class RectLight { }

	unsafe partial class SpotLight { }

	unsafe partial class SoundBase {
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getDuration;
	}

	unsafe partial class SoundWave {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getLoop;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setLoop;
	}

	unsafe partial class AnimationAsset { }

	unsafe partial class AnimationSequenceBase { }

	unsafe partial class AnimationSequence { }

	unsafe partial class AnimationCompositeBase { }

	unsafe partial class AnimationMontage { }

	unsafe partial class AnimationInstance {
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getCurrentActiveMontage;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool> isPlaying;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float> getPlayRate;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float> getPosition;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float> getBlendTime;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, byte[], void> getCurrentSection;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float, void> setPlayRate;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float, void> setPosition;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, string, string, void> setNextSection;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float, float, Bool, float> playMontage;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> pauseMontage;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> resumeMontage;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, float, void> stopMontage;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, string, void> jumpToSection;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, string, void> jumpToSectionsEnd;
	}

	unsafe partial class Player {
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getPlayerController;
	}

	unsafe partial class PlayerInput {
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, Bool> isKeyPressed;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, float> getTimeKeyPressed;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector2, void> getMouseSensitivity;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector2, void> setMouseSensitivity;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, string, Bool, Bool, Bool, Bool, void> addActionMapping;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, string, float, void> addAxisMapping;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, string, void> removeActionMapping;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, string, void> removeAxisMapping;
	}

	unsafe partial class Font {
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref int, ref int, void> getStringSize;
	}

	unsafe partial class StreamableRenderAsset { }

	unsafe partial class StaticMesh { }

	unsafe partial class SkeletalMesh { }

	unsafe partial class Texture { }

	unsafe partial class Texture2D {
		internal static delegate* unmanaged[Cdecl]<string, IntPtr> createFromFile;
		internal static delegate* unmanaged[Cdecl]<byte[], int, IntPtr> createFromBuffer;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> hasAlphaChannel;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector2, void> getSize;
		internal static delegate* unmanaged[Cdecl]<IntPtr, PixelFormat> getPixelFormat;
	}

	unsafe partial class ActorComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isOwnerSelected;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ActorType, IntPtr> getOwner;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> destroy;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, void> addTag;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, void> removeTag;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, Bool> hasTag;
	}

	unsafe partial class InputComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> hasBindings;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int> getActionBindingsNumber;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> clearActionBindings;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, InputEvent, Bool, IntPtr, void> bindAction;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, Bool, IntPtr, void> bindAxis;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, InputEvent, void> removeActionBinding;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getBlockInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setBlockInput;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int> getPriority;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, void> setPriority;
	}

	unsafe partial class SceneComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool> isAttachedToComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool> isAttachedToActor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isVisible;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, Bool> isSocketExists;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> hasAnySockets;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, string, Bool> canAttachAsChild;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void> forEachAttachedChild;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ComponentType, string, Bool, IntPtr, IntPtr> create;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, AttachmentTransformRule, string, Bool> attachToComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, DetachmentTransformRule, void> detachFromComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> activate;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> deactivate;
		internal static delegate* unmanaged[Cdecl]<IntPtr, TeleportType, UpdateTransformFlags, void> updateToWorld;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void> addLocalOffset;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void> addLocalRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void> addRelativeLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void> addRelativeRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Transform, void> addLocalTransform;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void> addWorldOffset;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void> addWorldRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Transform, void> addWorldTransform;
		internal static delegate* unmanaged[Cdecl]<IntPtr, byte[], void> getAttachedSocketName;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Transform, ref Bounds, void> getBounds;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref Vector3, void> getSocketLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, ref Quaternion, void> getSocketRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getComponentVelocity;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getComponentLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Quaternion, void> getComponentRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getComponentScale;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Transform, void> getComponentTransform;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getForwardVector;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getRightVector;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getUpVector;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ComponentMobility, void> setMobility;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, Bool, void> setVisibility;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void> setRelativeLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void> setRelativeRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Transform, void> setRelativeTransform;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void> setWorldLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Quaternion, void> setWorldRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void> setWorldScale;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Transform, void> setWorldTransform;
	}

	unsafe partial class AudioComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isPlaying;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getPaused;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> setSound;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setPaused;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> play;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> stop;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, float, float, AudioFadeCurve, void> fadeIn;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, float, AudioFadeCurve, void> fadeOut;
	}

	unsafe partial class CameraComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getConstrainAspectRatio;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getAspectRatio;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getFieldOfView;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getOrthoFarClipPlane;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getOrthoNearClipPlane;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getOrthoWidth;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getLockToHeadMountedDisplay;
		internal static delegate* unmanaged[Cdecl]<IntPtr, CameraProjectionMode, void> setProjectionMode;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setConstrainAspectRatio;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setAspectRatio;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setFieldOfView;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setOrthoFarClipPlane;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setOrthoNearClipPlane;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setOrthoWidth;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setLockToHeadMountedDisplay;
	}

	unsafe partial class ChildActorComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, ActorType, IntPtr> getChildActor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ActorType, IntPtr> setChildActor;
	}

	unsafe partial class SpringArmComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isCollisionFixApplied;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getDrawDebugLagMarkers;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getCollisionTest;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getCameraPositionLag;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getCameraRotationLag;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getCameraLagSubstepping;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getInheritPitch;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getInheritRoll;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getInheritYaw;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getCameraLagMaxDistance;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getCameraLagMaxTimeStep;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getCameraPositionLagSpeed;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getCameraRotationLagSpeed;
		internal static delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel> getProbeChannel;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getProbeSize;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getSocketOffset;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getTargetArmLength;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getTargetOffset;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getUnfixedCameraPosition;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Quaternion, void> getDesiredRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Quaternion, void> getTargetRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getUsePawnControlRotation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setDrawDebugLagMarkers;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setCollisionTest;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setCameraPositionLag;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setCameraRotationLag;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setCameraLagSubstepping;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setInheritPitch;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setInheritRoll;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setInheritYaw;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setCameraLagMaxDistance;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setCameraLagMaxTimeStep;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setCameraPositionLagSpeed;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setCameraRotationLagSpeed;
		internal static delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel, void> setProbeChannel;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setProbeSize;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void> setSocketOffset;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setTargetArmLength;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void> setTargetOffset;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setUsePawnControlRotation;
	}

	unsafe partial class PostProcessComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getEnabled;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getBlendRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getBlendWeight;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getUnbound;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getPriority;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setEnabled;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setBlendRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setBlendWeight;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setUnbound;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setPriority;
	}

	unsafe partial class PrimitiveComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isGravityEnabled;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool> isOverlappingComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref ObjectReference*, ref int, void> forEachOverlappingComponent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void> addAngularImpulseInDegrees;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void> addAngularImpulseInRadians;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void> addForce;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, in Vector3, string, Bool, void> addForceAtLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void> addImpulse;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, in Vector3, string, void> addImpulseAtLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, float, float, Bool, Bool, void> addRadialForce;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, float, float, Bool, Bool, void> addRadialImpulse;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void> addTorqueInDegrees;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, Bool, void> addTorqueInRadians;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getMass;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, string, void> getPhysicsLinearVelocity;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, in Vector3, string, void> getPhysicsLinearVelocityAtPoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, string, void> getPhysicsAngularVelocityInDegrees;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, string, void> getPhysicsAngularVelocityInRadians;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getCastShadow;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getOnlyOwnerSee;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getOwnerNoSee;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getIgnoreRadialForce;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getIgnoreRadialImpulse;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr> getMaterial;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int> getMaterialsNumber;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, ref Vector3, float> getDistanceToCollision;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, ref float, ref Vector3, Bool> getSquaredDistanceToCollision;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getAngularDamping;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getLinearDamping;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setGenerateOverlapEvents;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setGenerateHitEvents;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, string, void> setMass;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, string, void> setCenterOfMass;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, Bool, string, void> setPhysicsLinearVelocity;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, Bool, string, void> setPhysicsAngularVelocityInDegrees;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, Bool, string, void> setPhysicsAngularVelocityInRadians;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, Bool, string, void> setPhysicsMaxAngularVelocityInDegrees;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, Bool, string, void> setPhysicsMaxAngularVelocityInRadians;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setCastShadow;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setOnlyOwnerSee;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setOwnerNoSee;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setIgnoreRadialForce;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setIgnoreRadialImpulse;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, void> setMaterial;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setSimulatePhysics;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setAngularDamping;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setLinearDamping;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setEnableGravity;
		internal static delegate* unmanaged[Cdecl]<IntPtr, CollisionMode, void> setCollisionMode;
		internal static delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel, void> setCollisionChannel;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, Bool, void> setCollisionProfileName;
		internal static delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel, CollisionResponse, void> setCollisionResponseToChannel;
		internal static delegate* unmanaged[Cdecl]<IntPtr, CollisionResponse, void> setCollisionResponseToAllChannels;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool, void> setIgnoreActorWhenMoving;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool, void> setIgnoreComponentWhenMoving;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> clearMoveIgnoreActors;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> clearMoveIgnoreComponents;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr> createAndSetMaterialInstanceDynamic;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ComponentEventType, void> registerEvent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ComponentEventType, void> unregisterEvent;
	}

	unsafe partial class ShapeComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getDynamicObstacle;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int> getShapeColor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setDynamicObstacle;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, void> setShapeColor;
	}

	unsafe partial class BoxComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getScaledBoxExtent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, void> getUnscaledBoxExtent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, Bool, void> setBoxExtent;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, void> initBoxExtent;
	}

	unsafe partial class SphereComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getScaledSphereRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getUnscaledSphereRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getShapeScale;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, Bool, void> setSphereRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> initSphereRadius;
	}

	unsafe partial class CapsuleComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getScaledCapsuleRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getUnscaledCapsuleRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getShapeScale;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref float, ref float, void> getScaledCapsuleSize;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref float, ref float, void> getUnscaledCapsuleSize;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, Bool, void> setCapsuleRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, float, Bool, void> setCapsuleSize;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, float, void> initCapsuleSize;
	}

	unsafe partial class MeshComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, Bool> isValidMaterialSlotName;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, int> getMaterialIndex;
	}

	unsafe partial class TextRenderComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> setFont;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, void> setText;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> setTextMaterial;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, void> setTextRenderColor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, HorizontalTextAligment, void> setHorizontalAlignment;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setHorizontalSpacingAdjustment;
		internal static delegate* unmanaged[Cdecl]<IntPtr, VerticalTextAligment, void> setVerticalAlignment;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setVerticalSpacingAdjustment;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector2, void> setScale;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setWorldSize;
	}

	unsafe partial class LightComponentBase {
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getIntensity;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getCastShadows;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setCastShadows;
	}

	unsafe partial class LightComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setIntensity;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in LinearColor, void> setLightColor;
	}

	unsafe partial class DirectionalLightComponent { }

	unsafe partial class MotionControllerComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isTracked;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getDisplayDeviceModel;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getDisableLowLatencyUpdate;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ControllerHand> getTrackingSource;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setDisplayDeviceModel;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setDisableLowLatencyUpdate;
		internal static delegate* unmanaged[Cdecl]<IntPtr, ControllerHand, void> setTrackingSource;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, void> setTrackingMotionSource;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, void> setAssociatedPlayerIndex;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> setCustomDisplayMesh;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, void> setDisplayModelSource;
	}

	unsafe partial class StaticMeshComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, ref Vector3, ref Vector3, void> getLocalBounds;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getStaticMesh;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool> setStaticMesh;
	}

	unsafe partial class InstancedStaticMeshComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, int> getInstanceCount;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, ref Transform, Bool, Bool> getInstanceTransform;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Transform, void> addInstance;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, Transform[], void> addInstances;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, in Transform, Bool, Bool, Bool, Bool> updateInstanceTransform;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, int, Transform[], Bool, Bool, Bool, Bool> batchUpdateInstanceTransforms;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, Bool> removeInstance;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> clearInstances;
	}

	unsafe partial class HierarchicalInstancedStaticMeshComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getDisableCollision;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setDisableCollision;
	}

	unsafe partial class SkinnedMeshComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, int> getBonesNumber;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, int> getBoneIndex;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, byte[], void> getBoneName;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, ref Transform, void> getBoneTransform;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool, void> setSkeletalMesh;
	}

	unsafe partial class SkeletalMeshComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isPlaying;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getAnimationInstance;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> setAnimation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, AnimationMode, void> setAnimationMode;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> setAnimationBlueprint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> play;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool, void> playAnimation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> stop;
	}

	unsafe partial class SplineComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isClosedLoop;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getDuration;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplinePointType> getSplinePointType;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int> getSplinePointsNumber;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int> getSplineSegmentsNumber;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void> getTangentAtDistanceAlongSpline;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void> getTangentAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, ref Vector3, void> getTangentAtTime;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Transform, void> getTransformAtDistanceAlongSpline;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, Bool, ref Transform, void> getTransformAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void> getArriveTangentAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, SplineCoordinateSpace, ref Vector3, void> getDefaultUpVector;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void> getDirectionAtDistanceAlongSpline;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void> getDirectionAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, ref Vector3, void> getDirectionAtTime;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, float> getDistanceAlongSplineAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void> getLeaveTangentAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, ref Vector3, void> getLocationAndTangentAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void> getLocationAtDistanceAlongSpline;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void> getLocationAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void> getLocationAtTime;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void> getRightVectorAtDistanceAlongSpline;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void> getRightVectorAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, ref Vector3, void> getRightVectorAtTime;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, float> getRollAtDistanceAlongSpline;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, float> getRollAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, float> getRollAtTime;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Quaternion, void> getRotationAtDistanceAlongSpline;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Quaternion, void> getRotationAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, ref Quaternion, void> getRotationAtTime;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, ref Vector3, void> getScaleAtDistanceAlongSpline;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, ref Vector3, void> getScaleAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, Bool, ref Vector3, void> getScaleAtTime;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getSplineLength;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, Bool, ref Transform, void> getTransformAtTime;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, ref Vector3, void> getUpVectorAtDistanceAlongSpline;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplineCoordinateSpace, ref Vector3, void> getUpVectorAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, SplineCoordinateSpace, Bool, ref Vector3, void> getUpVectorAtTime;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setDuration;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, SplinePointType, Bool, void> setSplinePointType;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, Bool, void> setClosedLoop;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, void> setDefaultUpVector;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, in Vector3, SplineCoordinateSpace, Bool, void> setLocationAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, in Vector3, SplineCoordinateSpace, Bool, void> setTangentAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, in Vector3, in Vector3, SplineCoordinateSpace, Bool, void> setTangentsAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, in Vector3, SplineCoordinateSpace, Bool, void> setUpVectorAtSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, Bool, void> addSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, int, SplineCoordinateSpace, Bool, void> addSplinePointAtIndex;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> clearSplinePoints;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, ref Vector3, void> findDirectionClosestToWorldLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, ref Vector3, void> findLocationClosestToWorldLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, ref Vector3, void> findUpVectorClosestToWorldLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, ref Vector3, void> findRightVectorClosestToWorldLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, float> findRollClosestToWorldLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, ref Vector3, void> findScaleClosestToWorldLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, ref Vector3, void> findTangentClosestToWorldLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, in Vector3, SplineCoordinateSpace, Bool, ref Transform, void> findTransformClosestToWorldLocation;
		internal static delegate* unmanaged[Cdecl]<IntPtr, int, Bool, void> removeSplinePoint;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> updateSpline;
	}

	unsafe partial class RadialForceComponent {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getIgnoreOwningActor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getImpulseVelocityChange;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> getLinearFalloff;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getForceStrength;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getImpulseStrength;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float> getRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setIgnoreOwningActor;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setImpulseVelocityChange;
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool, void> setLinearFalloff;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setForceStrength;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setImpulseStrength;
		internal static delegate* unmanaged[Cdecl]<IntPtr, float, void> setRadius;
		internal static delegate* unmanaged[Cdecl]<IntPtr, CollisionChannel, void> addCollisionChannelToAffect;
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> fireImpulse;
	}

	unsafe partial class MaterialInterface {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isTwoSided;
	}

	unsafe partial class Material {
		internal static delegate* unmanaged[Cdecl]<IntPtr, Bool> isDefaultMaterial;
	}

	unsafe partial class MaterialInstance {
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Bool> isChildOf;
		internal static delegate* unmanaged[Cdecl]<IntPtr, IntPtr> getParent;
	}

	unsafe partial class MaterialInstanceDynamic {
		internal static delegate* unmanaged[Cdecl]<IntPtr, void> clearParameterValues;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, IntPtr, void> setTextureParameterValue;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, in LinearColor, void> setVectorParameterValue;
		internal static delegate* unmanaged[Cdecl]<IntPtr, string, float, void> setScalarParameterValue;
	}
}
