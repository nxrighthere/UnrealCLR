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
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace UnrealEngine.Framework {
	// Automatically generated

	internal static class Shared {
		internal const int checksum = 0x281;
		internal static Dictionary<int, IntPtr> userFunctions = new Dictionary<int, IntPtr>();
		private const string dynamicTypesAssemblyName = "UnrealEngine.DynamicTypes";
		private static readonly ModuleBuilder moduleBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(dynamicTypesAssemblyName), AssemblyBuilderAccess.RunAndCollect).DefineDynamicModule(dynamicTypesAssemblyName);
		private static readonly Type[] delegateCtorSignature = { typeof(object), typeof(IntPtr) };
		private static Dictionary<string, Delegate> delegatesCache = new Dictionary<string, Delegate>();
		private static Dictionary<string, Type> delegateTypesCache = new Dictionary<string, Type>();
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

				Assert.outputMessage = GenerateOptimizedFunction<Assert.OutputMessageFunction>(assertFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* commandLineFunctions = (IntPtr*)buffer[position++];

				CommandLine.get = GenerateOptimizedFunction<CommandLine.GetFunction>(commandLineFunctions[head++]);
				CommandLine.set = GenerateOptimizedFunction<CommandLine.SetFunction>(commandLineFunctions[head++]);
				CommandLine.append = GenerateOptimizedFunction<CommandLine.AppendFunction>(commandLineFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* debugFunctions = (IntPtr*)buffer[position++];

				Debug.log = GenerateOptimizedFunction<Debug.LogFunction>(debugFunctions[head++]);
				Debug.handleException = GenerateOptimizedFunction<Debug.HandleExceptionFunction>(debugFunctions[head++]);
				Debug.addOnScreenMessage = GenerateOptimizedFunction<Debug.AddOnScreenMessageFunction>(debugFunctions[head++]);
				Debug.clearOnScreenMessages = GenerateOptimizedFunction<Debug.ClearOnScreenMessagesFunction>(debugFunctions[head++]);
				Debug.drawBox = GenerateOptimizedFunction<Debug.DrawBoxFunction>(debugFunctions[head++]);
				Debug.drawCapsule = GenerateOptimizedFunction<Debug.DrawCapsuleFunction>(debugFunctions[head++]);
				Debug.drawCone = GenerateOptimizedFunction<Debug.DrawConeFunction>(debugFunctions[head++]);
				Debug.drawCylinder = GenerateOptimizedFunction<Debug.DrawCylinderFunction>(debugFunctions[head++]);
				Debug.drawSphere = GenerateOptimizedFunction<Debug.DrawSphereFunction>(debugFunctions[head++]);
				Debug.drawLine = GenerateOptimizedFunction<Debug.DrawLineFunction>(debugFunctions[head++]);
				Debug.drawPoint = GenerateOptimizedFunction<Debug.DrawPointFunction>(debugFunctions[head++]);
				Debug.flushPersistentLines = GenerateOptimizedFunction<Debug.FlushPersistentLinesFunction>(debugFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* objectFunctions = (IntPtr*)buffer[position++];

				Object.isPendingKill = GenerateOptimizedFunction<Object.IsPendingKillFunction>(objectFunctions[head++]);
				Object.isValid = GenerateOptimizedFunction<Object.IsValidFunction>(objectFunctions[head++]);
				Object.load = GenerateOptimizedFunction<Object.LoadFunction>(objectFunctions[head++]);
				Object.rename = GenerateOptimizedFunction<Object.RenameFunction>(objectFunctions[head++]);
				Object.invoke = GenerateOptimizedFunction<Object.InvokeFunction>(objectFunctions[head++]);
				Object.toActor = GenerateOptimizedFunction<Object.ToActorFunction>(objectFunctions[head++]);
				Object.toComponent = GenerateOptimizedFunction<Object.ToComponentFunction>(objectFunctions[head++]);
				Object.getID = GenerateOptimizedFunction<Object.GetIDFunction>(objectFunctions[head++]);
				Object.getName = GenerateOptimizedFunction<Object.GetNameFunction>(objectFunctions[head++]);
				Object.getBool = GenerateOptimizedFunction<Object.GetBoolFunction>(objectFunctions[head++]);
				Object.getByte = GenerateOptimizedFunction<Object.GetByteFunction>(objectFunctions[head++]);
				Object.getShort = GenerateOptimizedFunction<Object.GetShortFunction>(objectFunctions[head++]);
				Object.getInt = GenerateOptimizedFunction<Object.GetIntFunction>(objectFunctions[head++]);
				Object.getLong = GenerateOptimizedFunction<Object.GetLongFunction>(objectFunctions[head++]);
				Object.getUShort = GenerateOptimizedFunction<Object.GetUShortFunction>(objectFunctions[head++]);
				Object.getUInt = GenerateOptimizedFunction<Object.GetUIntFunction>(objectFunctions[head++]);
				Object.getULong = GenerateOptimizedFunction<Object.GetULongFunction>(objectFunctions[head++]);
				Object.getFloat = GenerateOptimizedFunction<Object.GetFloatFunction>(objectFunctions[head++]);
				Object.getDouble = GenerateOptimizedFunction<Object.GetDoubleFunction>(objectFunctions[head++]);
				Object.getEnum = GenerateOptimizedFunction<Object.GetEnumFunction>(objectFunctions[head++]);
				Object.getText = GenerateOptimizedFunction<Object.GetTextFunction>(objectFunctions[head++]);
				Object.setBool = GenerateOptimizedFunction<Object.SetBoolFunction>(objectFunctions[head++]);
				Object.setByte = GenerateOptimizedFunction<Object.SetByteFunction>(objectFunctions[head++]);
				Object.setShort = GenerateOptimizedFunction<Object.SetShortFunction>(objectFunctions[head++]);
				Object.setInt = GenerateOptimizedFunction<Object.SetIntFunction>(objectFunctions[head++]);
				Object.setLong = GenerateOptimizedFunction<Object.SetLongFunction>(objectFunctions[head++]);
				Object.setUShort = GenerateOptimizedFunction<Object.SetUShortFunction>(objectFunctions[head++]);
				Object.setUInt = GenerateOptimizedFunction<Object.SetUIntFunction>(objectFunctions[head++]);
				Object.setULong = GenerateOptimizedFunction<Object.SetULongFunction>(objectFunctions[head++]);
				Object.setFloat = GenerateOptimizedFunction<Object.SetFloatFunction>(objectFunctions[head++]);
				Object.setDouble = GenerateOptimizedFunction<Object.SetDoubleFunction>(objectFunctions[head++]);
				Object.setEnum = GenerateOptimizedFunction<Object.SetEnumFunction>(objectFunctions[head++]);
				Object.setText = GenerateOptimizedFunction<Object.SetTextFunction>(objectFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* applicationFunctions = (IntPtr*)buffer[position++];

				Application.isCanEverRender = GenerateOptimizedFunction<Application.IsCanEverRenderFunction>(applicationFunctions[head++]);
				Application.isPackagedForDistribution = GenerateOptimizedFunction<Application.IsPackagedForDistributionFunction>(applicationFunctions[head++]);
				Application.isPackagedForShipping = GenerateOptimizedFunction<Application.IsPackagedForShippingFunction>(applicationFunctions[head++]);
				Application.getProjectDirectory = GenerateOptimizedFunction<Application.GetProjectDirectoryFunction>(applicationFunctions[head++]);
				Application.getDefaultLanguage = GenerateOptimizedFunction<Application.GetDefaultLanguageFunction>(applicationFunctions[head++]);
				Application.getProjectName = GenerateOptimizedFunction<Application.GetProjectNameFunction>(applicationFunctions[head++]);
				Application.getVolumeMultiplier = GenerateOptimizedFunction<Application.GetVolumeMultiplierFunction>(applicationFunctions[head++]);
				Application.setProjectName = GenerateOptimizedFunction<Application.SetProjectNameFunction>(applicationFunctions[head++]);
				Application.setVolumeMultiplier = GenerateOptimizedFunction<Application.SetVolumeMultiplierFunction>(applicationFunctions[head++]);
				Application.requestExit = GenerateOptimizedFunction<Application.RequestExitFunction>(applicationFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* consoleManagerFunctions = (IntPtr*)buffer[position++];

				ConsoleManager.isRegisteredVariable = GenerateOptimizedFunction<ConsoleManager.IsRegisteredVariableFunction>(consoleManagerFunctions[head++]);
				ConsoleManager.findVariable = GenerateOptimizedFunction<ConsoleManager.FindVariableFunction>(consoleManagerFunctions[head++]);
				ConsoleManager.registerVariableBool = GenerateOptimizedFunction<ConsoleManager.RegisterVariableBoolFunction>(consoleManagerFunctions[head++]);
				ConsoleManager.registerVariableInt = GenerateOptimizedFunction<ConsoleManager.RegisterVariableIntFunction>(consoleManagerFunctions[head++]);
				ConsoleManager.registerVariableFloat = GenerateOptimizedFunction<ConsoleManager.RegisterVariableFloatFunction>(consoleManagerFunctions[head++]);
				ConsoleManager.registerVariableString = GenerateOptimizedFunction<ConsoleManager.RegisterVariableStringFunction>(consoleManagerFunctions[head++]);
				ConsoleManager.registerCommand = GenerateOptimizedFunction<ConsoleManager.RegisterCommandFunction>(consoleManagerFunctions[head++]);
				ConsoleManager.unregisterObject = GenerateOptimizedFunction<ConsoleManager.UnregisterObjectFunction>(consoleManagerFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* engineFunctions = (IntPtr*)buffer[position++];

				Engine.isSplitScreen = GenerateOptimizedFunction<Engine.IsSplitScreenFunction>(engineFunctions[head++]);
				Engine.isEditor = GenerateOptimizedFunction<Engine.IsEditorFunction>(engineFunctions[head++]);
				Engine.isForegroundWindow = GenerateOptimizedFunction<Engine.IsForegroundWindowFunction>(engineFunctions[head++]);
				Engine.isExitRequested = GenerateOptimizedFunction<Engine.IsExitRequestedFunction>(engineFunctions[head++]);
				Engine.getNetMode = GenerateOptimizedFunction<Engine.GetNetModeFunction>(engineFunctions[head++]);
				Engine.getFrameNumber = GenerateOptimizedFunction<Engine.GetFrameNumberFunction>(engineFunctions[head++]);
				Engine.getViewportSize = GenerateOptimizedFunction<Engine.GetViewportSizeFunction>(engineFunctions[head++]);
				Engine.getScreenResolution = GenerateOptimizedFunction<Engine.GetScreenResolutionFunction>(engineFunctions[head++]);
				Engine.getWindowMode = GenerateOptimizedFunction<Engine.GetWindowModeFunction>(engineFunctions[head++]);
				Engine.getVersion = GenerateOptimizedFunction<Engine.GetVersionFunction>(engineFunctions[head++]);
				Engine.getMaxFPS = GenerateOptimizedFunction<Engine.GetMaxFPSFunction>(engineFunctions[head++]);
				Engine.setMaxFPS = GenerateOptimizedFunction<Engine.SetMaxFPSFunction>(engineFunctions[head++]);
				Engine.setTitle = GenerateOptimizedFunction<Engine.SetTitleFunction>(engineFunctions[head++]);
				Engine.addActionMapping = GenerateOptimizedFunction<Engine.AddActionMappingFunction>(engineFunctions[head++]);
				Engine.addAxisMapping = GenerateOptimizedFunction<Engine.AddAxisMappingFunction>(engineFunctions[head++]);
				Engine.forceGarbageCollection = GenerateOptimizedFunction<Engine.ForceGarbageCollectionFunction>(engineFunctions[head++]);
				Engine.delayGarbageCollection = GenerateOptimizedFunction<Engine.DelayGarbageCollectionFunction>(engineFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* headMountedDisplayFunctions = (IntPtr*)buffer[position++];

				HeadMountedDisplay.isConnected = GenerateOptimizedFunction<HeadMountedDisplay.IsConnectedFunction>(headMountedDisplayFunctions[head++]);
				HeadMountedDisplay.getEnabled = GenerateOptimizedFunction<HeadMountedDisplay.GetEnabledFunction>(headMountedDisplayFunctions[head++]);
				HeadMountedDisplay.getLowPersistenceMode = GenerateOptimizedFunction<HeadMountedDisplay.GetLowPersistenceModeFunction>(headMountedDisplayFunctions[head++]);
				HeadMountedDisplay.getDeviceName = GenerateOptimizedFunction<HeadMountedDisplay.GetDeviceNameFunction>(headMountedDisplayFunctions[head++]);
				HeadMountedDisplay.setEnable = GenerateOptimizedFunction<HeadMountedDisplay.SetEnableFunction>(headMountedDisplayFunctions[head++]);
				HeadMountedDisplay.setLowPersistenceMode = GenerateOptimizedFunction<HeadMountedDisplay.SetLowPersistenceModeFunction>(headMountedDisplayFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* worldFunctions = (IntPtr*)buffer[position++];

				World.getActorCount = GenerateOptimizedFunction<World.GetActorCountFunction>(worldFunctions[head++]);
				World.getDeltaSeconds = GenerateOptimizedFunction<World.GetDeltaSecondsFunction>(worldFunctions[head++]);
				World.getRealTimeSeconds = GenerateOptimizedFunction<World.GetRealTimeSecondsFunction>(worldFunctions[head++]);
				World.getTimeSeconds = GenerateOptimizedFunction<World.GetTimeSecondsFunction>(worldFunctions[head++]);
				World.getCurrentLevelName = GenerateOptimizedFunction<World.GetCurrentLevelNameFunction>(worldFunctions[head++]);
				World.getSimulatePhysics = GenerateOptimizedFunction<World.GetSimulatePhysicsFunction>(worldFunctions[head++]);
				World.getWorldOrigin = GenerateOptimizedFunction<World.GetWorldOriginFunction>(worldFunctions[head++]);
				World.getActor = GenerateOptimizedFunction<World.GetActorFunction>(worldFunctions[head++]);
				World.getActorByTag = GenerateOptimizedFunction<World.GetActorByTagFunction>(worldFunctions[head++]);
				World.getActorByID = GenerateOptimizedFunction<World.GetActorByIDFunction>(worldFunctions[head++]);
				World.getFirstPlayerController = GenerateOptimizedFunction<World.GetFirstPlayerControllerFunction>(worldFunctions[head++]);
				World.setOnActorBeginOverlapCallback = GenerateOptimizedFunction<World.SetOnActorBeginOverlapCallbackFunction>(worldFunctions[head++]);
				World.setOnActorBeginCursorOverCallback = GenerateOptimizedFunction<World.SetOnActorBeginCursorOverCallbackFunction>(worldFunctions[head++]);
				World.setOnActorEndCursorOverCallback = GenerateOptimizedFunction<World.SetOnActorEndCursorOverCallbackFunction>(worldFunctions[head++]);
				World.setOnActorEndOverlapCallback = GenerateOptimizedFunction<World.SetOnActorEndOverlapCallbackFunction>(worldFunctions[head++]);
				World.setOnActorHitCallback = GenerateOptimizedFunction<World.SetOnActorHitCallbackFunction>(worldFunctions[head++]);
				World.setOnComponentBeginOverlapCallback = GenerateOptimizedFunction<World.SetOnComponentBeginOverlapCallbackFunction>(worldFunctions[head++]);
				World.setOnComponentEndOverlapCallback = GenerateOptimizedFunction<World.SetOnComponentEndOverlapCallbackFunction>(worldFunctions[head++]);
				World.setOnComponentHitCallback = GenerateOptimizedFunction<World.SetOnComponentHitCallbackFunction>(worldFunctions[head++]);
				World.setOnComponentBeginCursorOverCallback = GenerateOptimizedFunction<World.SetOnComponentBeginCursorOverCallbackFunction>(worldFunctions[head++]);
				World.setOnComponentEndCursorOverCallback = GenerateOptimizedFunction<World.SetOnComponentEndCursorOverCallbackFunction>(worldFunctions[head++]);
				World.setSimulatePhysics = GenerateOptimizedFunction<World.SetSimulatePhysicsFunction>(worldFunctions[head++]);
				World.setGravity = GenerateOptimizedFunction<World.SetGravityFunction>(worldFunctions[head++]);
				World.setWorldOrigin = GenerateOptimizedFunction<World.SetWorldOriginFunction>(worldFunctions[head++]);
				World.openLevel = GenerateOptimizedFunction<World.OpenLevelFunction>(worldFunctions[head++]);
				World.lineTraceTestByChannel = GenerateOptimizedFunction<World.LineTraceTestByChannelFunction>(worldFunctions[head++]);
				World.lineTraceTestByProfile = GenerateOptimizedFunction<World.LineTraceTestByProfileFunction>(worldFunctions[head++]);
				World.lineTraceSingleByChannel = GenerateOptimizedFunction<World.LineTraceSingleByChannelFunction>(worldFunctions[head++]);
				World.lineTraceSingleByProfile = GenerateOptimizedFunction<World.LineTraceSingleByProfileFunction>(worldFunctions[head++]);
				World.sweepTestByChannel = GenerateOptimizedFunction<World.SweepTestByChannelFunction>(worldFunctions[head++]);
				World.sweepTestByProfile = GenerateOptimizedFunction<World.SweepTestByProfileFunction>(worldFunctions[head++]);
				World.sweepSingleByChannel = GenerateOptimizedFunction<World.SweepSingleByChannelFunction>(worldFunctions[head++]);
				World.sweepSingleByProfile = GenerateOptimizedFunction<World.SweepSingleByProfileFunction>(worldFunctions[head++]);
				World.overlapAnyTestByChannel = GenerateOptimizedFunction<World.OverlapAnyTestByChannelFunction>(worldFunctions[head++]);
				World.overlapAnyTestByProfile = GenerateOptimizedFunction<World.OverlapAnyTestByProfileFunction>(worldFunctions[head++]);
				World.overlapBlockingTestByChannel = GenerateOptimizedFunction<World.OverlapBlockingTestByChannelFunction>(worldFunctions[head++]);
				World.overlapBlockingTestByProfile = GenerateOptimizedFunction<World.OverlapBlockingTestByProfileFunction>(worldFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* blueprintFunctions = (IntPtr*)buffer[position++];

				Blueprint.isValidActorClass = GenerateOptimizedFunction<Blueprint.IsValidActorClassFunction>(blueprintFunctions[head++]);
				Blueprint.isValidComponentClass = GenerateOptimizedFunction<Blueprint.IsValidComponentClassFunction>(blueprintFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* consoleObjectFunctions = (IntPtr*)buffer[position++];

				ConsoleObject.isBool = GenerateOptimizedFunction<ConsoleObject.IsBoolFunction>(consoleObjectFunctions[head++]);
				ConsoleObject.isInt = GenerateOptimizedFunction<ConsoleObject.IsIntFunction>(consoleObjectFunctions[head++]);
				ConsoleObject.isFloat = GenerateOptimizedFunction<ConsoleObject.IsFloatFunction>(consoleObjectFunctions[head++]);
				ConsoleObject.isString = GenerateOptimizedFunction<ConsoleObject.IsStringFunction>(consoleObjectFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* consoleVariableFunctions = (IntPtr*)buffer[position++];

				ConsoleVariable.getBool = GenerateOptimizedFunction<ConsoleVariable.GetBoolFunction>(consoleVariableFunctions[head++]);
				ConsoleVariable.getInt = GenerateOptimizedFunction<ConsoleVariable.GetIntFunction>(consoleVariableFunctions[head++]);
				ConsoleVariable.getFloat = GenerateOptimizedFunction<ConsoleVariable.GetFloatFunction>(consoleVariableFunctions[head++]);
				ConsoleVariable.getString = GenerateOptimizedFunction<ConsoleVariable.GetStringFunction>(consoleVariableFunctions[head++]);
				ConsoleVariable.setBool = GenerateOptimizedFunction<ConsoleVariable.SetBoolFunction>(consoleVariableFunctions[head++]);
				ConsoleVariable.setInt = GenerateOptimizedFunction<ConsoleVariable.SetIntFunction>(consoleVariableFunctions[head++]);
				ConsoleVariable.setFloat = GenerateOptimizedFunction<ConsoleVariable.SetFloatFunction>(consoleVariableFunctions[head++]);
				ConsoleVariable.setString = GenerateOptimizedFunction<ConsoleVariable.SetStringFunction>(consoleVariableFunctions[head++]);
				ConsoleVariable.setOnChangedCallback = GenerateOptimizedFunction<ConsoleVariable.SetOnChangedCallbackFunction>(consoleVariableFunctions[head++]);
				ConsoleVariable.clearOnChangedCallback = GenerateOptimizedFunction<ConsoleVariable.ClearOnChangedCallbackFunction>(consoleVariableFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* actorFunctions = (IntPtr*)buffer[position++];

				Actor.isPendingKill = GenerateOptimizedFunction<Actor.IsPendingKillFunction>(actorFunctions[head++]);
				Actor.isRootComponentMovable = GenerateOptimizedFunction<Actor.IsRootComponentMovableFunction>(actorFunctions[head++]);
				Actor.isOverlappingActor = GenerateOptimizedFunction<Actor.IsOverlappingActorFunction>(actorFunctions[head++]);
				Actor.spawn = GenerateOptimizedFunction<Actor.SpawnFunction>(actorFunctions[head++]);
				Actor.destroy = GenerateOptimizedFunction<Actor.DestroyFunction>(actorFunctions[head++]);
				Actor.rename = GenerateOptimizedFunction<Actor.RenameFunction>(actorFunctions[head++]);
				Actor.hide = GenerateOptimizedFunction<Actor.HideFunction>(actorFunctions[head++]);
				Actor.teleportTo = GenerateOptimizedFunction<Actor.TeleportToFunction>(actorFunctions[head++]);
				Actor.getComponent = GenerateOptimizedFunction<Actor.GetComponentFunction>(actorFunctions[head++]);
				Actor.getComponentByTag = GenerateOptimizedFunction<Actor.GetComponentByTagFunction>(actorFunctions[head++]);
				Actor.getComponentByID = GenerateOptimizedFunction<Actor.GetComponentByIDFunction>(actorFunctions[head++]);
				Actor.getRootComponent = GenerateOptimizedFunction<Actor.GetRootComponentFunction>(actorFunctions[head++]);
				Actor.getInputComponent = GenerateOptimizedFunction<Actor.GetInputComponentFunction>(actorFunctions[head++]);
				Actor.getCreationTime = GenerateOptimizedFunction<Actor.GetCreationTimeFunction>(actorFunctions[head++]);
				Actor.getBlockInput = GenerateOptimizedFunction<Actor.GetBlockInputFunction>(actorFunctions[head++]);
				Actor.getDistanceTo = GenerateOptimizedFunction<Actor.GetDistanceToFunction>(actorFunctions[head++]);
				Actor.getHorizontalDistanceTo = GenerateOptimizedFunction<Actor.GetHorizontalDistanceToFunction>(actorFunctions[head++]);
				Actor.getBounds = GenerateOptimizedFunction<Actor.GetBoundsFunction>(actorFunctions[head++]);
				Actor.getEyesViewPoint = GenerateOptimizedFunction<Actor.GetEyesViewPointFunction>(actorFunctions[head++]);
				Actor.setRootComponent = GenerateOptimizedFunction<Actor.SetRootComponentFunction>(actorFunctions[head++]);
				Actor.setInputComponent = GenerateOptimizedFunction<Actor.SetInputComponentFunction>(actorFunctions[head++]);
				Actor.setBlockInput = GenerateOptimizedFunction<Actor.SetBlockInputFunction>(actorFunctions[head++]);
				Actor.setLifeSpan = GenerateOptimizedFunction<Actor.SetLifeSpanFunction>(actorFunctions[head++]);
				Actor.setEnableInput = GenerateOptimizedFunction<Actor.SetEnableInputFunction>(actorFunctions[head++]);
				Actor.setEnableCollision = GenerateOptimizedFunction<Actor.SetEnableCollisionFunction>(actorFunctions[head++]);
				Actor.addTag = GenerateOptimizedFunction<Actor.AddTagFunction>(actorFunctions[head++]);
				Actor.removeTag = GenerateOptimizedFunction<Actor.RemoveTagFunction>(actorFunctions[head++]);
				Actor.hasTag = GenerateOptimizedFunction<Actor.HasTagFunction>(actorFunctions[head++]);
				Actor.registerEvent = GenerateOptimizedFunction<Actor.RegisterEventFunction>(actorFunctions[head++]);
				Actor.unregisterEvent = GenerateOptimizedFunction<Actor.UnregisterEventFunction>(actorFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* pawnFunctions = (IntPtr*)buffer[position++];

				Pawn.addControllerYawInput = GenerateOptimizedFunction<Pawn.AddControllerYawInputFunction>(pawnFunctions[head++]);
				Pawn.addControllerPitchInput = GenerateOptimizedFunction<Pawn.AddControllerPitchInputFunction>(pawnFunctions[head++]);
				Pawn.addControllerRollInput = GenerateOptimizedFunction<Pawn.AddControllerRollInputFunction>(pawnFunctions[head++]);
				Pawn.addMovementInput = GenerateOptimizedFunction<Pawn.AddMovementInputFunction>(pawnFunctions[head++]);
				Pawn.getAutoPossessAI = GenerateOptimizedFunction<Pawn.GetAutoPossessAIFunction>(pawnFunctions[head++]);
				Pawn.getAutoPossessPlayer = GenerateOptimizedFunction<Pawn.GetAutoPossessPlayerFunction>(pawnFunctions[head++]);
				Pawn.getGravityDirection = GenerateOptimizedFunction<Pawn.GetGravityDirectionFunction>(pawnFunctions[head++]);
				Pawn.getAIController = GenerateOptimizedFunction<Pawn.GetAIControllerFunction>(pawnFunctions[head++]);
				Pawn.getPlayerController = GenerateOptimizedFunction<Pawn.GetPlayerControllerFunction>(pawnFunctions[head++]);
				Pawn.setAutoPossessAI = GenerateOptimizedFunction<Pawn.SetAutoPossessAIFunction>(pawnFunctions[head++]);
				Pawn.setAutoPossessPlayer = GenerateOptimizedFunction<Pawn.SetAutoPossessPlayerFunction>(pawnFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* characterFunctions = (IntPtr*)buffer[position++];

				Character.isCrouched = GenerateOptimizedFunction<Character.IsCrouchedFunction>(characterFunctions[head++]);
				Character.canCrouch = GenerateOptimizedFunction<Character.CanCrouchFunction>(characterFunctions[head++]);
				Character.canJump = GenerateOptimizedFunction<Character.CanJumpFunction>(characterFunctions[head++]);
				Character.checkJumpInput = GenerateOptimizedFunction<Character.CheckJumpInputFunction>(characterFunctions[head++]);
				Character.clearJumpInput = GenerateOptimizedFunction<Character.ClearJumpInputFunction>(characterFunctions[head++]);
				Character.launch = GenerateOptimizedFunction<Character.LaunchFunction>(characterFunctions[head++]);
				Character.crouch = GenerateOptimizedFunction<Character.CrouchFunction>(characterFunctions[head++]);
				Character.stopCrouching = GenerateOptimizedFunction<Character.StopCrouchingFunction>(characterFunctions[head++]);
				Character.jump = GenerateOptimizedFunction<Character.JumpFunction>(characterFunctions[head++]);
				Character.stopJumping = GenerateOptimizedFunction<Character.StopJumpingFunction>(characterFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* controllerFunctions = (IntPtr*)buffer[position++];

				Controller.isLookInputIgnored = GenerateOptimizedFunction<Controller.IsLookInputIgnoredFunction>(controllerFunctions[head++]);
				Controller.isMoveInputIgnored = GenerateOptimizedFunction<Controller.IsMoveInputIgnoredFunction>(controllerFunctions[head++]);
				Controller.isPlayerController = GenerateOptimizedFunction<Controller.IsPlayerControllerFunction>(controllerFunctions[head++]);
				Controller.getPawn = GenerateOptimizedFunction<Controller.GetPawnFunction>(controllerFunctions[head++]);
				Controller.getCharacter = GenerateOptimizedFunction<Controller.GetCharacterFunction>(controllerFunctions[head++]);
				Controller.getViewTarget = GenerateOptimizedFunction<Controller.GetViewTargetFunction>(controllerFunctions[head++]);
				Controller.getControlRotation = GenerateOptimizedFunction<Controller.GetControlRotationFunction>(controllerFunctions[head++]);
				Controller.getDesiredRotation = GenerateOptimizedFunction<Controller.GetDesiredRotationFunction>(controllerFunctions[head++]);
				Controller.lineOfSightTo = GenerateOptimizedFunction<Controller.LineOfSightToFunction>(controllerFunctions[head++]);
				Controller.setControlRotation = GenerateOptimizedFunction<Controller.SetControlRotationFunction>(controllerFunctions[head++]);
				Controller.setInitialLocationAndRotation = GenerateOptimizedFunction<Controller.SetInitialLocationAndRotationFunction>(controllerFunctions[head++]);
				Controller.setIgnoreLookInput = GenerateOptimizedFunction<Controller.SetIgnoreLookInputFunction>(controllerFunctions[head++]);
				Controller.setIgnoreMoveInput = GenerateOptimizedFunction<Controller.SetIgnoreMoveInputFunction>(controllerFunctions[head++]);
				Controller.resetIgnoreLookInput = GenerateOptimizedFunction<Controller.ResetIgnoreLookInputFunction>(controllerFunctions[head++]);
				Controller.resetIgnoreMoveInput = GenerateOptimizedFunction<Controller.ResetIgnoreMoveInputFunction>(controllerFunctions[head++]);
				Controller.possess = GenerateOptimizedFunction<Controller.PossessFunction>(controllerFunctions[head++]);
				Controller.unpossess = GenerateOptimizedFunction<Controller.UnpossessFunction>(controllerFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* aIControllerFunctions = (IntPtr*)buffer[position++];

				AIController.clearFocus = GenerateOptimizedFunction<AIController.ClearFocusFunction>(aIControllerFunctions[head++]);
				AIController.getFocalPoint = GenerateOptimizedFunction<AIController.GetFocalPointFunction>(aIControllerFunctions[head++]);
				AIController.setFocalPoint = GenerateOptimizedFunction<AIController.SetFocalPointFunction>(aIControllerFunctions[head++]);
				AIController.getFocusActor = GenerateOptimizedFunction<AIController.GetFocusActorFunction>(aIControllerFunctions[head++]);
				AIController.getAllowStrafe = GenerateOptimizedFunction<AIController.GetAllowStrafeFunction>(aIControllerFunctions[head++]);
				AIController.setAllowStrafe = GenerateOptimizedFunction<AIController.SetAllowStrafeFunction>(aIControllerFunctions[head++]);
				AIController.setFocus = GenerateOptimizedFunction<AIController.SetFocusFunction>(aIControllerFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* playerControllerFunctions = (IntPtr*)buffer[position++];

				PlayerController.isPaused = GenerateOptimizedFunction<PlayerController.IsPausedFunction>(playerControllerFunctions[head++]);
				PlayerController.getShowMouseCursor = GenerateOptimizedFunction<PlayerController.GetShowMouseCursorFunction>(playerControllerFunctions[head++]);
				PlayerController.getEnableMouseOverEvents = GenerateOptimizedFunction<PlayerController.GetEnableMouseOverEventsFunction>(playerControllerFunctions[head++]);
				PlayerController.getMousePosition = GenerateOptimizedFunction<PlayerController.GetMousePositionFunction>(playerControllerFunctions[head++]);
				PlayerController.getPlayer = GenerateOptimizedFunction<PlayerController.GetPlayerFunction>(playerControllerFunctions[head++]);
				PlayerController.getPlayerInput = GenerateOptimizedFunction<PlayerController.GetPlayerInputFunction>(playerControllerFunctions[head++]);
				PlayerController.setShowMouseCursor = GenerateOptimizedFunction<PlayerController.SetShowMouseCursorFunction>(playerControllerFunctions[head++]);
				PlayerController.setEnableMouseOverEvents = GenerateOptimizedFunction<PlayerController.SetEnableMouseOverEventsFunction>(playerControllerFunctions[head++]);
				PlayerController.setMousePosition = GenerateOptimizedFunction<PlayerController.SetMousePositionFunction>(playerControllerFunctions[head++]);
				PlayerController.consoleCommand = GenerateOptimizedFunction<PlayerController.ConsoleCommandFunction>(playerControllerFunctions[head++]);
				PlayerController.setPause = GenerateOptimizedFunction<PlayerController.SetPauseFunction>(playerControllerFunctions[head++]);
				PlayerController.setViewTarget = GenerateOptimizedFunction<PlayerController.SetViewTargetFunction>(playerControllerFunctions[head++]);
				PlayerController.setViewTargetWithBlend = GenerateOptimizedFunction<PlayerController.SetViewTargetWithBlendFunction>(playerControllerFunctions[head++]);
				PlayerController.addYawInput = GenerateOptimizedFunction<PlayerController.AddYawInputFunction>(playerControllerFunctions[head++]);
				PlayerController.addPitchInput = GenerateOptimizedFunction<PlayerController.AddPitchInputFunction>(playerControllerFunctions[head++]);
				PlayerController.addRollInput = GenerateOptimizedFunction<PlayerController.AddRollInputFunction>(playerControllerFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* volumeFunctions = (IntPtr*)buffer[position++];

				Volume.encompassesPoint = GenerateOptimizedFunction<Volume.EncompassesPointFunction>(volumeFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* postProcessVolumeFunctions = (IntPtr*)buffer[position++];

				PostProcessVolume.getEnabled = GenerateOptimizedFunction<PostProcessVolume.GetEnabledFunction>(postProcessVolumeFunctions[head++]);
				PostProcessVolume.getBlendRadius = GenerateOptimizedFunction<PostProcessVolume.GetBlendRadiusFunction>(postProcessVolumeFunctions[head++]);
				PostProcessVolume.getBlendWeight = GenerateOptimizedFunction<PostProcessVolume.GetBlendWeightFunction>(postProcessVolumeFunctions[head++]);
				PostProcessVolume.getUnbound = GenerateOptimizedFunction<PostProcessVolume.GetUnboundFunction>(postProcessVolumeFunctions[head++]);
				PostProcessVolume.getPriority = GenerateOptimizedFunction<PostProcessVolume.GetPriorityFunction>(postProcessVolumeFunctions[head++]);
				PostProcessVolume.setEnabled = GenerateOptimizedFunction<PostProcessVolume.SetEnabledFunction>(postProcessVolumeFunctions[head++]);
				PostProcessVolume.setBlendRadius = GenerateOptimizedFunction<PostProcessVolume.SetBlendRadiusFunction>(postProcessVolumeFunctions[head++]);
				PostProcessVolume.setBlendWeight = GenerateOptimizedFunction<PostProcessVolume.SetBlendWeightFunction>(postProcessVolumeFunctions[head++]);
				PostProcessVolume.setUnbound = GenerateOptimizedFunction<PostProcessVolume.SetUnboundFunction>(postProcessVolumeFunctions[head++]);
				PostProcessVolume.setPriority = GenerateOptimizedFunction<PostProcessVolume.SetPriorityFunction>(postProcessVolumeFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* soundBaseFunctions = (IntPtr*)buffer[position++];

				SoundBase.getDuration = GenerateOptimizedFunction<SoundBase.GetDurationFunction>(soundBaseFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* soundWaveFunctions = (IntPtr*)buffer[position++];

				SoundWave.getLoop = GenerateOptimizedFunction<SoundWave.GetLoopFunction>(soundWaveFunctions[head++]);
				SoundWave.setLoop = GenerateOptimizedFunction<SoundWave.SetLoopFunction>(soundWaveFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* animationInstanceFunctions = (IntPtr*)buffer[position++];

				AnimationInstance.getCurrentActiveMontage = GenerateOptimizedFunction<AnimationInstance.GetCurrentActiveMontageFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.isPlaying = GenerateOptimizedFunction<AnimationInstance.IsPlayingFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.getPlayRate = GenerateOptimizedFunction<AnimationInstance.GetPlayRateFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.getPosition = GenerateOptimizedFunction<AnimationInstance.GetPositionFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.getBlendTime = GenerateOptimizedFunction<AnimationInstance.GetBlendTimeFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.getCurrentSection = GenerateOptimizedFunction<AnimationInstance.GetCurrentSectionFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.setPlayRate = GenerateOptimizedFunction<AnimationInstance.SetPlayRateFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.setPosition = GenerateOptimizedFunction<AnimationInstance.SetPositionFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.setNextSection = GenerateOptimizedFunction<AnimationInstance.SetNextSectionFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.playMontage = GenerateOptimizedFunction<AnimationInstance.PlayMontageFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.pauseMontage = GenerateOptimizedFunction<AnimationInstance.PauseMontageFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.resumeMontage = GenerateOptimizedFunction<AnimationInstance.ResumeMontageFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.stopMontage = GenerateOptimizedFunction<AnimationInstance.StopMontageFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.jumpToSection = GenerateOptimizedFunction<AnimationInstance.JumpToSectionFunction>(animationInstanceFunctions[head++]);
				AnimationInstance.jumpToSectionsEnd = GenerateOptimizedFunction<AnimationInstance.JumpToSectionsEndFunction>(animationInstanceFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* playerFunctions = (IntPtr*)buffer[position++];

				Player.getPlayerController = GenerateOptimizedFunction<Player.GetPlayerControllerFunction>(playerFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* playerInputFunctions = (IntPtr*)buffer[position++];

				PlayerInput.isKeyPressed = GenerateOptimizedFunction<PlayerInput.IsKeyPressedFunction>(playerInputFunctions[head++]);
				PlayerInput.getTimeKeyPressed = GenerateOptimizedFunction<PlayerInput.GetTimeKeyPressedFunction>(playerInputFunctions[head++]);
				PlayerInput.getMouseSensitivity = GenerateOptimizedFunction<PlayerInput.GetMouseSensitivityFunction>(playerInputFunctions[head++]);
				PlayerInput.setMouseSensitivity = GenerateOptimizedFunction<PlayerInput.SetMouseSensitivityFunction>(playerInputFunctions[head++]);
				PlayerInput.addActionMapping = GenerateOptimizedFunction<PlayerInput.AddActionMappingFunction>(playerInputFunctions[head++]);
				PlayerInput.addAxisMapping = GenerateOptimizedFunction<PlayerInput.AddAxisMappingFunction>(playerInputFunctions[head++]);
				PlayerInput.removeActionMapping = GenerateOptimizedFunction<PlayerInput.RemoveActionMappingFunction>(playerInputFunctions[head++]);
				PlayerInput.removeAxisMapping = GenerateOptimizedFunction<PlayerInput.RemoveAxisMappingFunction>(playerInputFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* texture2DFunctions = (IntPtr*)buffer[position++];

				Texture2D.createFromFile = GenerateOptimizedFunction<Texture2D.CreateFromFileFunction>(texture2DFunctions[head++]);
				Texture2D.createFromBuffer = GenerateOptimizedFunction<Texture2D.CreateFromBufferFunction>(texture2DFunctions[head++]);
				Texture2D.hasAlphaChannel = GenerateOptimizedFunction<Texture2D.HasAlphaChannelFunction>(texture2DFunctions[head++]);
				Texture2D.getSize = GenerateOptimizedFunction<Texture2D.GetSizeFunction>(texture2DFunctions[head++]);
				Texture2D.getPixelFormat = GenerateOptimizedFunction<Texture2D.GetPixelFormatFunction>(texture2DFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* actorComponentFunctions = (IntPtr*)buffer[position++];

				ActorComponent.isOwnerSelected = GenerateOptimizedFunction<ActorComponent.IsOwnerSelectedFunction>(actorComponentFunctions[head++]);
				ActorComponent.getOwner = GenerateOptimizedFunction<ActorComponent.GetOwnerFunction>(actorComponentFunctions[head++]);
				ActorComponent.destroy = GenerateOptimizedFunction<ActorComponent.DestroyFunction>(actorComponentFunctions[head++]);
				ActorComponent.addTag = GenerateOptimizedFunction<ActorComponent.AddTagFunction>(actorComponentFunctions[head++]);
				ActorComponent.removeTag = GenerateOptimizedFunction<ActorComponent.RemoveTagFunction>(actorComponentFunctions[head++]);
				ActorComponent.hasTag = GenerateOptimizedFunction<ActorComponent.HasTagFunction>(actorComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* inputComponentFunctions = (IntPtr*)buffer[position++];

				InputComponent.hasBindings = GenerateOptimizedFunction<InputComponent.HasBindingsFunction>(inputComponentFunctions[head++]);
				InputComponent.getActionBindingsNumber = GenerateOptimizedFunction<InputComponent.GetActionBindingsNumberFunction>(inputComponentFunctions[head++]);
				InputComponent.clearActionBindings = GenerateOptimizedFunction<InputComponent.ClearActionBindingsFunction>(inputComponentFunctions[head++]);
				InputComponent.bindAction = GenerateOptimizedFunction<InputComponent.BindActionFunction>(inputComponentFunctions[head++]);
				InputComponent.bindAxis = GenerateOptimizedFunction<InputComponent.BindAxisFunction>(inputComponentFunctions[head++]);
				InputComponent.removeActionBinding = GenerateOptimizedFunction<InputComponent.RemoveActionBindingFunction>(inputComponentFunctions[head++]);
				InputComponent.getBlockInput = GenerateOptimizedFunction<InputComponent.GetBlockInputFunction>(inputComponentFunctions[head++]);
				InputComponent.setBlockInput = GenerateOptimizedFunction<InputComponent.SetBlockInputFunction>(inputComponentFunctions[head++]);
				InputComponent.getPriority = GenerateOptimizedFunction<InputComponent.GetPriorityFunction>(inputComponentFunctions[head++]);
				InputComponent.setPriority = GenerateOptimizedFunction<InputComponent.SetPriorityFunction>(inputComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* sceneComponentFunctions = (IntPtr*)buffer[position++];

				SceneComponent.isAttachedToComponent = GenerateOptimizedFunction<SceneComponent.IsAttachedToComponentFunction>(sceneComponentFunctions[head++]);
				SceneComponent.isAttachedToActor = GenerateOptimizedFunction<SceneComponent.IsAttachedToActorFunction>(sceneComponentFunctions[head++]);
				SceneComponent.isVisible = GenerateOptimizedFunction<SceneComponent.IsVisibleFunction>(sceneComponentFunctions[head++]);
				SceneComponent.isSocketExists = GenerateOptimizedFunction<SceneComponent.IsSocketExistsFunction>(sceneComponentFunctions[head++]);
				SceneComponent.hasAnySockets = GenerateOptimizedFunction<SceneComponent.HasAnySocketsFunction>(sceneComponentFunctions[head++]);
				SceneComponent.create = GenerateOptimizedFunction<SceneComponent.CreateFunction>(sceneComponentFunctions[head++]);
				SceneComponent.attachToComponent = GenerateOptimizedFunction<SceneComponent.AttachToComponentFunction>(sceneComponentFunctions[head++]);
				SceneComponent.detachFromComponent = GenerateOptimizedFunction<SceneComponent.DetachFromComponentFunction>(sceneComponentFunctions[head++]);
				SceneComponent.activate = GenerateOptimizedFunction<SceneComponent.ActivateFunction>(sceneComponentFunctions[head++]);
				SceneComponent.deactivate = GenerateOptimizedFunction<SceneComponent.DeactivateFunction>(sceneComponentFunctions[head++]);
				SceneComponent.updateToWorld = GenerateOptimizedFunction<SceneComponent.UpdateToWorldFunction>(sceneComponentFunctions[head++]);
				SceneComponent.addLocalOffset = GenerateOptimizedFunction<SceneComponent.AddLocalOffsetFunction>(sceneComponentFunctions[head++]);
				SceneComponent.addLocalRotation = GenerateOptimizedFunction<SceneComponent.AddLocalRotationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.addRelativeLocation = GenerateOptimizedFunction<SceneComponent.AddRelativeLocationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.addRelativeRotation = GenerateOptimizedFunction<SceneComponent.AddRelativeRotationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.addLocalTransform = GenerateOptimizedFunction<SceneComponent.AddLocalTransformFunction>(sceneComponentFunctions[head++]);
				SceneComponent.addWorldOffset = GenerateOptimizedFunction<SceneComponent.AddWorldOffsetFunction>(sceneComponentFunctions[head++]);
				SceneComponent.addWorldRotation = GenerateOptimizedFunction<SceneComponent.AddWorldRotationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.addWorldTransform = GenerateOptimizedFunction<SceneComponent.AddWorldTransformFunction>(sceneComponentFunctions[head++]);
				SceneComponent.getAttachedSocketName = GenerateOptimizedFunction<SceneComponent.GetAttachedSocketNameFunction>(sceneComponentFunctions[head++]);
				SceneComponent.getSocketLocation = GenerateOptimizedFunction<SceneComponent.GetSocketLocationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.getSocketRotation = GenerateOptimizedFunction<SceneComponent.GetSocketRotationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.getComponentVelocity = GenerateOptimizedFunction<SceneComponent.GetComponentVelocityFunction>(sceneComponentFunctions[head++]);
				SceneComponent.getComponentLocation = GenerateOptimizedFunction<SceneComponent.GetComponentLocationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.getComponentRotation = GenerateOptimizedFunction<SceneComponent.GetComponentRotationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.getComponentScale = GenerateOptimizedFunction<SceneComponent.GetComponentScaleFunction>(sceneComponentFunctions[head++]);
				SceneComponent.getComponentTransform = GenerateOptimizedFunction<SceneComponent.GetComponentTransformFunction>(sceneComponentFunctions[head++]);
				SceneComponent.getForwardVector = GenerateOptimizedFunction<SceneComponent.GetForwardVectorFunction>(sceneComponentFunctions[head++]);
				SceneComponent.getRightVector = GenerateOptimizedFunction<SceneComponent.GetRightVectorFunction>(sceneComponentFunctions[head++]);
				SceneComponent.getUpVector = GenerateOptimizedFunction<SceneComponent.GetUpVectorFunction>(sceneComponentFunctions[head++]);
				SceneComponent.setMobility = GenerateOptimizedFunction<SceneComponent.SetMobilityFunction>(sceneComponentFunctions[head++]);
				SceneComponent.setVisibility = GenerateOptimizedFunction<SceneComponent.SetVisibilityFunction>(sceneComponentFunctions[head++]);
				SceneComponent.setRelativeLocation = GenerateOptimizedFunction<SceneComponent.SetRelativeLocationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.setRelativeRotation = GenerateOptimizedFunction<SceneComponent.SetRelativeRotationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.setRelativeTransform = GenerateOptimizedFunction<SceneComponent.SetRelativeTransformFunction>(sceneComponentFunctions[head++]);
				SceneComponent.setWorldLocation = GenerateOptimizedFunction<SceneComponent.SetWorldLocationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.setWorldRotation = GenerateOptimizedFunction<SceneComponent.SetWorldRotationFunction>(sceneComponentFunctions[head++]);
				SceneComponent.setWorldScale = GenerateOptimizedFunction<SceneComponent.SetWorldScaleFunction>(sceneComponentFunctions[head++]);
				SceneComponent.setWorldTransform = GenerateOptimizedFunction<SceneComponent.SetWorldTransformFunction>(sceneComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* audioComponentFunctions = (IntPtr*)buffer[position++];

				AudioComponent.isPlaying = GenerateOptimizedFunction<AudioComponent.IsPlayingFunction>(audioComponentFunctions[head++]);
				AudioComponent.getPaused = GenerateOptimizedFunction<AudioComponent.GetPausedFunction>(audioComponentFunctions[head++]);
				AudioComponent.setSound = GenerateOptimizedFunction<AudioComponent.SetSoundFunction>(audioComponentFunctions[head++]);
				AudioComponent.setPaused = GenerateOptimizedFunction<AudioComponent.SetPausedFunction>(audioComponentFunctions[head++]);
				AudioComponent.play = GenerateOptimizedFunction<AudioComponent.PlayFunction>(audioComponentFunctions[head++]);
				AudioComponent.stop = GenerateOptimizedFunction<AudioComponent.StopFunction>(audioComponentFunctions[head++]);
				AudioComponent.fadeIn = GenerateOptimizedFunction<AudioComponent.FadeInFunction>(audioComponentFunctions[head++]);
				AudioComponent.fadeOut = GenerateOptimizedFunction<AudioComponent.FadeOutFunction>(audioComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* cameraComponentFunctions = (IntPtr*)buffer[position++];

				CameraComponent.getConstrainAspectRatio = GenerateOptimizedFunction<CameraComponent.GetConstrainAspectRatioFunction>(cameraComponentFunctions[head++]);
				CameraComponent.getAspectRatio = GenerateOptimizedFunction<CameraComponent.GetAspectRatioFunction>(cameraComponentFunctions[head++]);
				CameraComponent.getFieldOfView = GenerateOptimizedFunction<CameraComponent.GetFieldOfViewFunction>(cameraComponentFunctions[head++]);
				CameraComponent.getOrthoFarClipPlane = GenerateOptimizedFunction<CameraComponent.GetOrthoFarClipPlaneFunction>(cameraComponentFunctions[head++]);
				CameraComponent.getOrthoNearClipPlane = GenerateOptimizedFunction<CameraComponent.GetOrthoNearClipPlaneFunction>(cameraComponentFunctions[head++]);
				CameraComponent.getOrthoWidth = GenerateOptimizedFunction<CameraComponent.GetOrthoWidthFunction>(cameraComponentFunctions[head++]);
				CameraComponent.getLockToHeadMountedDisplay = GenerateOptimizedFunction<CameraComponent.GetLockToHeadMountedDisplayFunction>(cameraComponentFunctions[head++]);
				CameraComponent.setProjectionMode = GenerateOptimizedFunction<CameraComponent.SetProjectionModeFunction>(cameraComponentFunctions[head++]);
				CameraComponent.setConstrainAspectRatio = GenerateOptimizedFunction<CameraComponent.SetConstrainAspectRatioFunction>(cameraComponentFunctions[head++]);
				CameraComponent.setAspectRatio = GenerateOptimizedFunction<CameraComponent.SetAspectRatioFunction>(cameraComponentFunctions[head++]);
				CameraComponent.setFieldOfView = GenerateOptimizedFunction<CameraComponent.SetFieldOfViewFunction>(cameraComponentFunctions[head++]);
				CameraComponent.setOrthoFarClipPlane = GenerateOptimizedFunction<CameraComponent.SetOrthoFarClipPlaneFunction>(cameraComponentFunctions[head++]);
				CameraComponent.setOrthoNearClipPlane = GenerateOptimizedFunction<CameraComponent.SetOrthoNearClipPlaneFunction>(cameraComponentFunctions[head++]);
				CameraComponent.setOrthoWidth = GenerateOptimizedFunction<CameraComponent.SetOrthoWidthFunction>(cameraComponentFunctions[head++]);
				CameraComponent.setLockToHeadMountedDisplay = GenerateOptimizedFunction<CameraComponent.SetLockToHeadMountedDisplayFunction>(cameraComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* childActorComponentFunctions = (IntPtr*)buffer[position++];

				ChildActorComponent.setChildActor = GenerateOptimizedFunction<ChildActorComponent.SetChildActorFunction>(childActorComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* springArmComponentFunctions = (IntPtr*)buffer[position++];

				SpringArmComponent.isCollisionFixApplied = GenerateOptimizedFunction<SpringArmComponent.IsCollisionFixAppliedFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getDrawDebugLagMarkers = GenerateOptimizedFunction<SpringArmComponent.GetDrawDebugLagMarkersFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getCollisionTest = GenerateOptimizedFunction<SpringArmComponent.GetCollisionTestFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getCameraPositionLag = GenerateOptimizedFunction<SpringArmComponent.GetCameraPositionLagFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getCameraRotationLag = GenerateOptimizedFunction<SpringArmComponent.GetCameraRotationLagFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getCameraLagSubstepping = GenerateOptimizedFunction<SpringArmComponent.GetCameraLagSubsteppingFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getInheritPitch = GenerateOptimizedFunction<SpringArmComponent.GetInheritPitchFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getInheritRoll = GenerateOptimizedFunction<SpringArmComponent.GetInheritRollFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getInheritYaw = GenerateOptimizedFunction<SpringArmComponent.GetInheritYawFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getCameraLagMaxDistance = GenerateOptimizedFunction<SpringArmComponent.GetCameraLagMaxDistanceFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getCameraLagMaxTimeStep = GenerateOptimizedFunction<SpringArmComponent.GetCameraLagMaxTimeStepFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getCameraPositionLagSpeed = GenerateOptimizedFunction<SpringArmComponent.GetCameraPositionLagSpeedFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getCameraRotationLagSpeed = GenerateOptimizedFunction<SpringArmComponent.GetCameraRotationLagSpeedFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getProbeChannel = GenerateOptimizedFunction<SpringArmComponent.GetProbeChannelFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getProbeSize = GenerateOptimizedFunction<SpringArmComponent.GetProbeSizeFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getSocketOffset = GenerateOptimizedFunction<SpringArmComponent.GetSocketOffsetFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getTargetArmLength = GenerateOptimizedFunction<SpringArmComponent.GetTargetArmLengthFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getTargetOffset = GenerateOptimizedFunction<SpringArmComponent.GetTargetOffsetFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getUnfixedCameraPosition = GenerateOptimizedFunction<SpringArmComponent.GetUnfixedCameraPositionFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getDesiredRotation = GenerateOptimizedFunction<SpringArmComponent.GetDesiredRotationFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.getTargetRotation = GenerateOptimizedFunction<SpringArmComponent.GetTargetRotationFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setDrawDebugLagMarkers = GenerateOptimizedFunction<SpringArmComponent.SetDrawDebugLagMarkersFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setCollisionTest = GenerateOptimizedFunction<SpringArmComponent.SetCollisionTestFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setCameraPositionLag = GenerateOptimizedFunction<SpringArmComponent.SetCameraPositionLagFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setCameraRotationLag = GenerateOptimizedFunction<SpringArmComponent.SetCameraRotationLagFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setCameraLagSubstepping = GenerateOptimizedFunction<SpringArmComponent.SetCameraLagSubsteppingFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setInheritPitch = GenerateOptimizedFunction<SpringArmComponent.SetInheritPitchFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setInheritRoll = GenerateOptimizedFunction<SpringArmComponent.SetInheritRollFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setInheritYaw = GenerateOptimizedFunction<SpringArmComponent.SetInheritYawFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setCameraLagMaxDistance = GenerateOptimizedFunction<SpringArmComponent.SetCameraLagMaxDistanceFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setCameraLagMaxTimeStep = GenerateOptimizedFunction<SpringArmComponent.SetCameraLagMaxTimeStepFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setCameraPositionLagSpeed = GenerateOptimizedFunction<SpringArmComponent.SetCameraPositionLagSpeedFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setCameraRotationLagSpeed = GenerateOptimizedFunction<SpringArmComponent.SetCameraRotationLagSpeedFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setProbeChannel = GenerateOptimizedFunction<SpringArmComponent.SetProbeChannelFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setProbeSize = GenerateOptimizedFunction<SpringArmComponent.SetProbeSizeFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setSocketOffset = GenerateOptimizedFunction<SpringArmComponent.SetSocketOffsetFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setTargetArmLength = GenerateOptimizedFunction<SpringArmComponent.SetTargetArmLengthFunction>(springArmComponentFunctions[head++]);
				SpringArmComponent.setTargetOffset = GenerateOptimizedFunction<SpringArmComponent.SetTargetOffsetFunction>(springArmComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* primitiveComponentFunctions = (IntPtr*)buffer[position++];

				PrimitiveComponent.isGravityEnabled = GenerateOptimizedFunction<PrimitiveComponent.IsGravityEnabledFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.isOverlappingComponent = GenerateOptimizedFunction<PrimitiveComponent.IsOverlappingComponentFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.addAngularImpulseInDegrees = GenerateOptimizedFunction<PrimitiveComponent.AddAngularImpulseInDegreesFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.addAngularImpulseInRadians = GenerateOptimizedFunction<PrimitiveComponent.AddAngularImpulseInRadiansFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.addForce = GenerateOptimizedFunction<PrimitiveComponent.AddForceFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.addForceAtLocation = GenerateOptimizedFunction<PrimitiveComponent.AddForceAtLocationFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.addImpulse = GenerateOptimizedFunction<PrimitiveComponent.AddImpulseFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.addImpulseAtLocation = GenerateOptimizedFunction<PrimitiveComponent.AddImpulseAtLocationFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.addRadialForce = GenerateOptimizedFunction<PrimitiveComponent.AddRadialForceFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.addRadialImpulse = GenerateOptimizedFunction<PrimitiveComponent.AddRadialImpulseFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.addTorqueInDegrees = GenerateOptimizedFunction<PrimitiveComponent.AddTorqueInDegreesFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.addTorqueInRadians = GenerateOptimizedFunction<PrimitiveComponent.AddTorqueInRadiansFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getMass = GenerateOptimizedFunction<PrimitiveComponent.GetMassFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getPhysicsLinearVelocity = GenerateOptimizedFunction<PrimitiveComponent.GetPhysicsLinearVelocityFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getPhysicsLinearVelocityAtPoint = GenerateOptimizedFunction<PrimitiveComponent.GetPhysicsLinearVelocityAtPointFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getPhysicsAngularVelocityInDegrees = GenerateOptimizedFunction<PrimitiveComponent.GetPhysicsAngularVelocityInDegreesFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getPhysicsAngularVelocityInRadians = GenerateOptimizedFunction<PrimitiveComponent.GetPhysicsAngularVelocityInRadiansFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getCastShadow = GenerateOptimizedFunction<PrimitiveComponent.GetCastShadowFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getOnlyOwnerSee = GenerateOptimizedFunction<PrimitiveComponent.GetOnlyOwnerSeeFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getOwnerNoSee = GenerateOptimizedFunction<PrimitiveComponent.GetOwnerNoSeeFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getIgnoreRadialForce = GenerateOptimizedFunction<PrimitiveComponent.GetIgnoreRadialForceFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getIgnoreRadialImpulse = GenerateOptimizedFunction<PrimitiveComponent.GetIgnoreRadialImpulseFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getMaterial = GenerateOptimizedFunction<PrimitiveComponent.GetMaterialFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getMaterialsNumber = GenerateOptimizedFunction<PrimitiveComponent.GetMaterialsNumberFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getDistanceToCollision = GenerateOptimizedFunction<PrimitiveComponent.GetDistanceToCollisionFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getSquaredDistanceToCollision = GenerateOptimizedFunction<PrimitiveComponent.GetSquaredDistanceToCollisionFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getAngularDamping = GenerateOptimizedFunction<PrimitiveComponent.GetAngularDampingFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.getLinearDamping = GenerateOptimizedFunction<PrimitiveComponent.GetLinearDampingFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setGenerateOverlapEvents = GenerateOptimizedFunction<PrimitiveComponent.SetGenerateOverlapEventsFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setGenerateHitEvents = GenerateOptimizedFunction<PrimitiveComponent.SetGenerateHitEventsFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setMass = GenerateOptimizedFunction<PrimitiveComponent.SetMassFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setCenterOfMass = GenerateOptimizedFunction<PrimitiveComponent.SetCenterOfMassFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setPhysicsLinearVelocity = GenerateOptimizedFunction<PrimitiveComponent.SetPhysicsLinearVelocityFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setPhysicsAngularVelocityInDegrees = GenerateOptimizedFunction<PrimitiveComponent.SetPhysicsAngularVelocityInDegreesFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setPhysicsAngularVelocityInRadians = GenerateOptimizedFunction<PrimitiveComponent.SetPhysicsAngularVelocityInRadiansFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setPhysicsMaxAngularVelocityInDegrees = GenerateOptimizedFunction<PrimitiveComponent.SetPhysicsMaxAngularVelocityInDegreesFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setPhysicsMaxAngularVelocityInRadians = GenerateOptimizedFunction<PrimitiveComponent.SetPhysicsMaxAngularVelocityInRadiansFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setCastShadow = GenerateOptimizedFunction<PrimitiveComponent.SetCastShadowFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setOnlyOwnerSee = GenerateOptimizedFunction<PrimitiveComponent.SetOnlyOwnerSeeFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setOwnerNoSee = GenerateOptimizedFunction<PrimitiveComponent.SetOwnerNoSeeFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setIgnoreRadialForce = GenerateOptimizedFunction<PrimitiveComponent.SetIgnoreRadialForceFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setIgnoreRadialImpulse = GenerateOptimizedFunction<PrimitiveComponent.SetIgnoreRadialImpulseFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setMaterial = GenerateOptimizedFunction<PrimitiveComponent.SetMaterialFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setSimulatePhysics = GenerateOptimizedFunction<PrimitiveComponent.SetSimulatePhysicsFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setAngularDamping = GenerateOptimizedFunction<PrimitiveComponent.SetAngularDampingFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setLinearDamping = GenerateOptimizedFunction<PrimitiveComponent.SetLinearDampingFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setEnableGravity = GenerateOptimizedFunction<PrimitiveComponent.SetEnableGravityFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setCollisionMode = GenerateOptimizedFunction<PrimitiveComponent.SetCollisionModeFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setCollisionChannel = GenerateOptimizedFunction<PrimitiveComponent.SetCollisionChannelFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setCollisionProfileName = GenerateOptimizedFunction<PrimitiveComponent.SetCollisionProfileNameFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setCollisionResponseToChannel = GenerateOptimizedFunction<PrimitiveComponent.SetCollisionResponseToChannelFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setCollisionResponseToAllChannels = GenerateOptimizedFunction<PrimitiveComponent.SetCollisionResponseToAllChannelsFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setIgnoreActorWhenMoving = GenerateOptimizedFunction<PrimitiveComponent.SetIgnoreActorWhenMovingFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.setIgnoreComponentWhenMoving = GenerateOptimizedFunction<PrimitiveComponent.SetIgnoreComponentWhenMovingFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.clearMoveIgnoreActors = GenerateOptimizedFunction<PrimitiveComponent.ClearMoveIgnoreActorsFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.clearMoveIgnoreComponents = GenerateOptimizedFunction<PrimitiveComponent.ClearMoveIgnoreComponentsFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.createAndSetMaterialInstanceDynamic = GenerateOptimizedFunction<PrimitiveComponent.CreateAndSetMaterialInstanceDynamicFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.registerEvent = GenerateOptimizedFunction<PrimitiveComponent.RegisterEventFunction>(primitiveComponentFunctions[head++]);
				PrimitiveComponent.unregisterEvent = GenerateOptimizedFunction<PrimitiveComponent.UnregisterEventFunction>(primitiveComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* shapeComponentFunctions = (IntPtr*)buffer[position++];

				ShapeComponent.getDynamicObstacle = GenerateOptimizedFunction<ShapeComponent.GetDynamicObstacleFunction>(shapeComponentFunctions[head++]);
				ShapeComponent.getShapeColor = GenerateOptimizedFunction<ShapeComponent.GetShapeColorFunction>(shapeComponentFunctions[head++]);
				ShapeComponent.setDynamicObstacle = GenerateOptimizedFunction<ShapeComponent.SetDynamicObstacleFunction>(shapeComponentFunctions[head++]);
				ShapeComponent.setShapeColor = GenerateOptimizedFunction<ShapeComponent.SetShapeColorFunction>(shapeComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* boxComponentFunctions = (IntPtr*)buffer[position++];

				BoxComponent.getScaledBoxExtent = GenerateOptimizedFunction<BoxComponent.GetScaledBoxExtentFunction>(boxComponentFunctions[head++]);
				BoxComponent.getUnscaledBoxExtent = GenerateOptimizedFunction<BoxComponent.GetUnscaledBoxExtentFunction>(boxComponentFunctions[head++]);
				BoxComponent.setBoxExtent = GenerateOptimizedFunction<BoxComponent.SetBoxExtentFunction>(boxComponentFunctions[head++]);
				BoxComponent.initBoxExtent = GenerateOptimizedFunction<BoxComponent.InitBoxExtentFunction>(boxComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* sphereComponentFunctions = (IntPtr*)buffer[position++];

				SphereComponent.getScaledSphereRadius = GenerateOptimizedFunction<SphereComponent.GetScaledSphereRadiusFunction>(sphereComponentFunctions[head++]);
				SphereComponent.getUnscaledSphereRadius = GenerateOptimizedFunction<SphereComponent.GetUnscaledSphereRadiusFunction>(sphereComponentFunctions[head++]);
				SphereComponent.getShapeScale = GenerateOptimizedFunction<SphereComponent.GetShapeScaleFunction>(sphereComponentFunctions[head++]);
				SphereComponent.setSphereRadius = GenerateOptimizedFunction<SphereComponent.SetSphereRadiusFunction>(sphereComponentFunctions[head++]);
				SphereComponent.initSphereRadius = GenerateOptimizedFunction<SphereComponent.InitSphereRadiusFunction>(sphereComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* capsuleComponentFunctions = (IntPtr*)buffer[position++];

				CapsuleComponent.getScaledCapsuleRadius = GenerateOptimizedFunction<CapsuleComponent.GetScaledCapsuleRadiusFunction>(capsuleComponentFunctions[head++]);
				CapsuleComponent.getUnscaledCapsuleRadius = GenerateOptimizedFunction<CapsuleComponent.GetUnscaledCapsuleRadiusFunction>(capsuleComponentFunctions[head++]);
				CapsuleComponent.getShapeScale = GenerateOptimizedFunction<CapsuleComponent.GetShapeScaleFunction>(capsuleComponentFunctions[head++]);
				CapsuleComponent.getScaledCapsuleSize = GenerateOptimizedFunction<CapsuleComponent.GetScaledCapsuleSizeFunction>(capsuleComponentFunctions[head++]);
				CapsuleComponent.getUnscaledCapsuleSize = GenerateOptimizedFunction<CapsuleComponent.GetUnscaledCapsuleSizeFunction>(capsuleComponentFunctions[head++]);
				CapsuleComponent.setCapsuleRadius = GenerateOptimizedFunction<CapsuleComponent.SetCapsuleRadiusFunction>(capsuleComponentFunctions[head++]);
				CapsuleComponent.setCapsuleSize = GenerateOptimizedFunction<CapsuleComponent.SetCapsuleSizeFunction>(capsuleComponentFunctions[head++]);
				CapsuleComponent.initCapsuleSize = GenerateOptimizedFunction<CapsuleComponent.InitCapsuleSizeFunction>(capsuleComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* meshComponentFunctions = (IntPtr*)buffer[position++];

				MeshComponent.isValidMaterialSlotName = GenerateOptimizedFunction<MeshComponent.IsValidMaterialSlotNameFunction>(meshComponentFunctions[head++]);
				MeshComponent.getMaterialIndex = GenerateOptimizedFunction<MeshComponent.GetMaterialIndexFunction>(meshComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* lightComponentBaseFunctions = (IntPtr*)buffer[position++];

				LightComponentBase.getIntensity = GenerateOptimizedFunction<LightComponentBase.GetIntensityFunction>(lightComponentBaseFunctions[head++]);
				LightComponentBase.getCastShadows = GenerateOptimizedFunction<LightComponentBase.GetCastShadowsFunction>(lightComponentBaseFunctions[head++]);
				LightComponentBase.setCastShadows = GenerateOptimizedFunction<LightComponentBase.SetCastShadowsFunction>(lightComponentBaseFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* lightComponentFunctions = (IntPtr*)buffer[position++];

				LightComponent.setIntensity = GenerateOptimizedFunction<LightComponent.SetIntensityFunction>(lightComponentFunctions[head++]);
				LightComponent.setLightColor = GenerateOptimizedFunction<LightComponent.SetLightColorFunction>(lightComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* motionControllerComponentFunctions = (IntPtr*)buffer[position++];

				MotionControllerComponent.isTracked = GenerateOptimizedFunction<MotionControllerComponent.IsTrackedFunction>(motionControllerComponentFunctions[head++]);
				MotionControllerComponent.getDisableLowLatencyUpdate = GenerateOptimizedFunction<MotionControllerComponent.GetDisableLowLatencyUpdateFunction>(motionControllerComponentFunctions[head++]);
				MotionControllerComponent.getTrackingSource = GenerateOptimizedFunction<MotionControllerComponent.GetTrackingSourceFunction>(motionControllerComponentFunctions[head++]);
				MotionControllerComponent.setDisableLowLatencyUpdate = GenerateOptimizedFunction<MotionControllerComponent.SetDisableLowLatencyUpdateFunction>(motionControllerComponentFunctions[head++]);
				MotionControllerComponent.setTrackingSource = GenerateOptimizedFunction<MotionControllerComponent.SetTrackingSourceFunction>(motionControllerComponentFunctions[head++]);
				MotionControllerComponent.setTrackingMotionSource = GenerateOptimizedFunction<MotionControllerComponent.SetTrackingMotionSourceFunction>(motionControllerComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* staticMeshComponentFunctions = (IntPtr*)buffer[position++];

				StaticMeshComponent.getLocalBounds = GenerateOptimizedFunction<StaticMeshComponent.GetLocalBoundsFunction>(staticMeshComponentFunctions[head++]);
				StaticMeshComponent.getStaticMesh = GenerateOptimizedFunction<StaticMeshComponent.GetStaticMeshFunction>(staticMeshComponentFunctions[head++]);
				StaticMeshComponent.setStaticMesh = GenerateOptimizedFunction<StaticMeshComponent.SetStaticMeshFunction>(staticMeshComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* instancedStaticMeshComponentFunctions = (IntPtr*)buffer[position++];

				InstancedStaticMeshComponent.getInstanceCount = GenerateOptimizedFunction<InstancedStaticMeshComponent.GetInstanceCountFunction>(instancedStaticMeshComponentFunctions[head++]);
				InstancedStaticMeshComponent.getInstanceTransform = GenerateOptimizedFunction<InstancedStaticMeshComponent.GetInstanceTransformFunction>(instancedStaticMeshComponentFunctions[head++]);
				InstancedStaticMeshComponent.addInstance = GenerateOptimizedFunction<InstancedStaticMeshComponent.AddInstanceFunction>(instancedStaticMeshComponentFunctions[head++]);
				InstancedStaticMeshComponent.updateInstanceTransform = GenerateOptimizedFunction<InstancedStaticMeshComponent.UpdateInstanceTransformFunction>(instancedStaticMeshComponentFunctions[head++]);
				InstancedStaticMeshComponent.removeInstance = GenerateOptimizedFunction<InstancedStaticMeshComponent.RemoveInstanceFunction>(instancedStaticMeshComponentFunctions[head++]);
				InstancedStaticMeshComponent.clearInstances = GenerateOptimizedFunction<InstancedStaticMeshComponent.ClearInstancesFunction>(instancedStaticMeshComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* skinnedMeshComponentFunctions = (IntPtr*)buffer[position++];

				SkinnedMeshComponent.getBonesNumber = GenerateOptimizedFunction<SkinnedMeshComponent.GetBonesNumberFunction>(skinnedMeshComponentFunctions[head++]);
				SkinnedMeshComponent.getBoneIndex = GenerateOptimizedFunction<SkinnedMeshComponent.GetBoneIndexFunction>(skinnedMeshComponentFunctions[head++]);
				SkinnedMeshComponent.getBoneName = GenerateOptimizedFunction<SkinnedMeshComponent.GetBoneNameFunction>(skinnedMeshComponentFunctions[head++]);
				SkinnedMeshComponent.getBoneTransform = GenerateOptimizedFunction<SkinnedMeshComponent.GetBoneTransformFunction>(skinnedMeshComponentFunctions[head++]);
				SkinnedMeshComponent.setSkeletalMesh = GenerateOptimizedFunction<SkinnedMeshComponent.SetSkeletalMeshFunction>(skinnedMeshComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* skeletalMeshComponentFunctions = (IntPtr*)buffer[position++];

				SkeletalMeshComponent.isPlaying = GenerateOptimizedFunction<SkeletalMeshComponent.IsPlayingFunction>(skeletalMeshComponentFunctions[head++]);
				SkeletalMeshComponent.getAnimationInstance = GenerateOptimizedFunction<SkeletalMeshComponent.GetAnimationInstanceFunction>(skeletalMeshComponentFunctions[head++]);
				SkeletalMeshComponent.setAnimation = GenerateOptimizedFunction<SkeletalMeshComponent.SetAnimationFunction>(skeletalMeshComponentFunctions[head++]);
				SkeletalMeshComponent.setAnimationMode = GenerateOptimizedFunction<SkeletalMeshComponent.SetAnimationModeFunction>(skeletalMeshComponentFunctions[head++]);
				SkeletalMeshComponent.setAnimationBlueprint = GenerateOptimizedFunction<SkeletalMeshComponent.SetAnimationBlueprintFunction>(skeletalMeshComponentFunctions[head++]);
				SkeletalMeshComponent.play = GenerateOptimizedFunction<SkeletalMeshComponent.PlayFunction>(skeletalMeshComponentFunctions[head++]);
				SkeletalMeshComponent.playAnimation = GenerateOptimizedFunction<SkeletalMeshComponent.PlayAnimationFunction>(skeletalMeshComponentFunctions[head++]);
				SkeletalMeshComponent.stop = GenerateOptimizedFunction<SkeletalMeshComponent.StopFunction>(skeletalMeshComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* splineComponentFunctions = (IntPtr*)buffer[position++];

				SplineComponent.isClosedLoop = GenerateOptimizedFunction<SplineComponent.IsClosedLoopFunction>(splineComponentFunctions[head++]);
				SplineComponent.getDuration = GenerateOptimizedFunction<SplineComponent.GetDurationFunction>(splineComponentFunctions[head++]);
				SplineComponent.getSplinePointType = GenerateOptimizedFunction<SplineComponent.GetSplinePointTypeFunction>(splineComponentFunctions[head++]);
				SplineComponent.getSplinePointsNumber = GenerateOptimizedFunction<SplineComponent.GetSplinePointsNumberFunction>(splineComponentFunctions[head++]);
				SplineComponent.getSplineSegmentsNumber = GenerateOptimizedFunction<SplineComponent.GetSplineSegmentsNumberFunction>(splineComponentFunctions[head++]);
				SplineComponent.getTangentAtDistanceAlongSpline = GenerateOptimizedFunction<SplineComponent.GetTangentAtDistanceAlongSplineFunction>(splineComponentFunctions[head++]);
				SplineComponent.getTangentAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetTangentAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getTangentAtTime = GenerateOptimizedFunction<SplineComponent.GetTangentAtTimeFunction>(splineComponentFunctions[head++]);
				SplineComponent.getTransformAtDistanceAlongSpline = GenerateOptimizedFunction<SplineComponent.GetTransformAtDistanceAlongSplineFunction>(splineComponentFunctions[head++]);
				SplineComponent.getTransformAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetTransformAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getArriveTangentAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetArriveTangentAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getDefaultUpVector = GenerateOptimizedFunction<SplineComponent.GetDefaultUpVectorFunction>(splineComponentFunctions[head++]);
				SplineComponent.getDirectionAtDistanceAlongSpline = GenerateOptimizedFunction<SplineComponent.GetDirectionAtDistanceAlongSplineFunction>(splineComponentFunctions[head++]);
				SplineComponent.getDirectionAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetDirectionAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getDirectionAtTime = GenerateOptimizedFunction<SplineComponent.GetDirectionAtTimeFunction>(splineComponentFunctions[head++]);
				SplineComponent.getDistanceAlongSplineAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetDistanceAlongSplineAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getLeaveTangentAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetLeaveTangentAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getLocationAndTangentAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetLocationAndTangentAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getLocationAtDistanceAlongSpline = GenerateOptimizedFunction<SplineComponent.GetLocationAtDistanceAlongSplineFunction>(splineComponentFunctions[head++]);
				SplineComponent.getLocationAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetLocationAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getLocationAtTime = GenerateOptimizedFunction<SplineComponent.GetLocationAtTimeFunction>(splineComponentFunctions[head++]);
				SplineComponent.getRightVectorAtDistanceAlongSpline = GenerateOptimizedFunction<SplineComponent.GetRightVectorAtDistanceAlongSplineFunction>(splineComponentFunctions[head++]);
				SplineComponent.getRightVectorAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetRightVectorAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getRightVectorAtTime = GenerateOptimizedFunction<SplineComponent.GetRightVectorAtTimeFunction>(splineComponentFunctions[head++]);
				SplineComponent.getRollAtDistanceAlongSpline = GenerateOptimizedFunction<SplineComponent.GetRollAtDistanceAlongSplineFunction>(splineComponentFunctions[head++]);
				SplineComponent.getRollAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetRollAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getRollAtTime = GenerateOptimizedFunction<SplineComponent.GetRollAtTimeFunction>(splineComponentFunctions[head++]);
				SplineComponent.getRotationAtDistanceAlongSpline = GenerateOptimizedFunction<SplineComponent.GetRotationAtDistanceAlongSplineFunction>(splineComponentFunctions[head++]);
				SplineComponent.getRotationAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetRotationAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getRotationAtTime = GenerateOptimizedFunction<SplineComponent.GetRotationAtTimeFunction>(splineComponentFunctions[head++]);
				SplineComponent.getScaleAtDistanceAlongSpline = GenerateOptimizedFunction<SplineComponent.GetScaleAtDistanceAlongSplineFunction>(splineComponentFunctions[head++]);
				SplineComponent.getScaleAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetScaleAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getScaleAtTime = GenerateOptimizedFunction<SplineComponent.GetScaleAtTimeFunction>(splineComponentFunctions[head++]);
				SplineComponent.getSplineLength = GenerateOptimizedFunction<SplineComponent.GetSplineLengthFunction>(splineComponentFunctions[head++]);
				SplineComponent.getTransformAtTime = GenerateOptimizedFunction<SplineComponent.GetTransformAtTimeFunction>(splineComponentFunctions[head++]);
				SplineComponent.getUpVectorAtDistanceAlongSpline = GenerateOptimizedFunction<SplineComponent.GetUpVectorAtDistanceAlongSplineFunction>(splineComponentFunctions[head++]);
				SplineComponent.getUpVectorAtSplinePoint = GenerateOptimizedFunction<SplineComponent.GetUpVectorAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.getUpVectorAtTime = GenerateOptimizedFunction<SplineComponent.GetUpVectorAtTimeFunction>(splineComponentFunctions[head++]);
				SplineComponent.setDuration = GenerateOptimizedFunction<SplineComponent.SetDurationFunction>(splineComponentFunctions[head++]);
				SplineComponent.setSplinePointType = GenerateOptimizedFunction<SplineComponent.SetSplinePointTypeFunction>(splineComponentFunctions[head++]);
				SplineComponent.setClosedLoop = GenerateOptimizedFunction<SplineComponent.SetClosedLoopFunction>(splineComponentFunctions[head++]);
				SplineComponent.setDefaultUpVector = GenerateOptimizedFunction<SplineComponent.SetDefaultUpVectorFunction>(splineComponentFunctions[head++]);
				SplineComponent.setLocationAtSplinePoint = GenerateOptimizedFunction<SplineComponent.SetLocationAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.setTangentAtSplinePoint = GenerateOptimizedFunction<SplineComponent.SetTangentAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.setTangentsAtSplinePoint = GenerateOptimizedFunction<SplineComponent.SetTangentsAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.setUpVectorAtSplinePoint = GenerateOptimizedFunction<SplineComponent.SetUpVectorAtSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.addSplinePoint = GenerateOptimizedFunction<SplineComponent.AddSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.addSplinePointAtIndex = GenerateOptimizedFunction<SplineComponent.AddSplinePointAtIndexFunction>(splineComponentFunctions[head++]);
				SplineComponent.clearSplinePoints = GenerateOptimizedFunction<SplineComponent.ClearSplinePointsFunction>(splineComponentFunctions[head++]);
				SplineComponent.findDirectionClosestToWorldLocation = GenerateOptimizedFunction<SplineComponent.FindDirectionClosestToWorldLocationFunction>(splineComponentFunctions[head++]);
				SplineComponent.findLocationClosestToWorldLocation = GenerateOptimizedFunction<SplineComponent.FindLocationClosestToWorldLocationFunction>(splineComponentFunctions[head++]);
				SplineComponent.findUpVectorClosestToWorldLocation = GenerateOptimizedFunction<SplineComponent.FindUpVectorClosestToWorldLocationFunction>(splineComponentFunctions[head++]);
				SplineComponent.findRightVectorClosestToWorldLocation = GenerateOptimizedFunction<SplineComponent.FindRightVectorClosestToWorldLocationFunction>(splineComponentFunctions[head++]);
				SplineComponent.findRollClosestToWorldLocation = GenerateOptimizedFunction<SplineComponent.FindRollClosestToWorldLocationFunction>(splineComponentFunctions[head++]);
				SplineComponent.findScaleClosestToWorldLocation = GenerateOptimizedFunction<SplineComponent.FindScaleClosestToWorldLocationFunction>(splineComponentFunctions[head++]);
				SplineComponent.findTangentClosestToWorldLocation = GenerateOptimizedFunction<SplineComponent.FindTangentClosestToWorldLocationFunction>(splineComponentFunctions[head++]);
				SplineComponent.findTransformClosestToWorldLocation = GenerateOptimizedFunction<SplineComponent.FindTransformClosestToWorldLocationFunction>(splineComponentFunctions[head++]);
				SplineComponent.removeSplinePoint = GenerateOptimizedFunction<SplineComponent.RemoveSplinePointFunction>(splineComponentFunctions[head++]);
				SplineComponent.updateSpline = GenerateOptimizedFunction<SplineComponent.UpdateSplineFunction>(splineComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* radialForceComponentFunctions = (IntPtr*)buffer[position++];

				RadialForceComponent.getIgnoreOwningActor = GenerateOptimizedFunction<RadialForceComponent.GetIgnoreOwningActorFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.getImpulseVelocityChange = GenerateOptimizedFunction<RadialForceComponent.GetImpulseVelocityChangeFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.getLinearFalloff = GenerateOptimizedFunction<RadialForceComponent.GetLinearFalloffFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.getForceStrength = GenerateOptimizedFunction<RadialForceComponent.GetForceStrengthFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.getImpulseStrength = GenerateOptimizedFunction<RadialForceComponent.GetImpulseStrengthFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.getRadius = GenerateOptimizedFunction<RadialForceComponent.GetRadiusFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.setIgnoreOwningActor = GenerateOptimizedFunction<RadialForceComponent.SetIgnoreOwningActorFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.setImpulseVelocityChange = GenerateOptimizedFunction<RadialForceComponent.SetImpulseVelocityChangeFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.setLinearFalloff = GenerateOptimizedFunction<RadialForceComponent.SetLinearFalloffFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.setForceStrength = GenerateOptimizedFunction<RadialForceComponent.SetForceStrengthFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.setImpulseStrength = GenerateOptimizedFunction<RadialForceComponent.SetImpulseStrengthFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.setRadius = GenerateOptimizedFunction<RadialForceComponent.SetRadiusFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.addCollisionChannelToAffect = GenerateOptimizedFunction<RadialForceComponent.AddCollisionChannelToAffectFunction>(radialForceComponentFunctions[head++]);
				RadialForceComponent.fireImpulse = GenerateOptimizedFunction<RadialForceComponent.FireImpulseFunction>(radialForceComponentFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* materialInterfaceFunctions = (IntPtr*)buffer[position++];

				MaterialInterface.isTwoSided = GenerateOptimizedFunction<MaterialInterface.IsTwoSidedFunction>(materialInterfaceFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* materialFunctions = (IntPtr*)buffer[position++];

				Material.isDefaultMaterial = GenerateOptimizedFunction<Material.IsDefaultMaterialFunction>(materialFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* materialInstanceFunctions = (IntPtr*)buffer[position++];

				MaterialInstance.isChildOf = GenerateOptimizedFunction<MaterialInstance.IsChildOfFunction>(materialInstanceFunctions[head++]);
			}

			unchecked {
				int head = 0;
				IntPtr* materialInstanceDynamicFunctions = (IntPtr*)buffer[position++];

				MaterialInstanceDynamic.clearParameterValues = GenerateOptimizedFunction<MaterialInstanceDynamic.ClearParameterValuesFunction>(materialInstanceDynamicFunctions[head++]);
				MaterialInstanceDynamic.setTextureParameterValue = GenerateOptimizedFunction<MaterialInstanceDynamic.SetTextureParameterValueFunction>(materialInstanceDynamicFunctions[head++]);
				MaterialInstanceDynamic.setVectorParameterValue = GenerateOptimizedFunction<MaterialInstanceDynamic.SetVectorParameterValueFunction>(materialInstanceDynamicFunctions[head++]);
				MaterialInstanceDynamic.setScalarParameterValue = GenerateOptimizedFunction<MaterialInstanceDynamic.SetScalarParameterValueFunction>(materialInstanceDynamicFunctions[head++]);
			}

			unchecked {
				Type[] types = pluginAssembly.GetTypes();

				foreach (Type type in types) {
					MethodInfo[] methods = type.GetMethods();

					if (type.Name == "Main" && type.IsPublic) {
						foreach (MethodInfo method in methods) {
							if (method.IsPublic && method.IsStatic) {
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
						if (method.IsPublic && method.IsStatic) {
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static TDelegate GenerateOptimizedFunction<TDelegate>(IntPtr pointer) where TDelegate : class {
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

	partial struct LinearColor {
		private float r;
		private float g;
		private float b;
		private float a;
	}

	partial struct Transform {
		private Quaternion rotation;
		private Vector3 location;
		private Vector3 scale;
	}

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

		public static implicit operator Bool(bool value) => !value ? new Bool(0) : new Bool(1);

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
		LevelScript
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
		ChildActor,
		SpringArm,
		Box,
		Sphere,
		Capsule,
		SkeletalMesh,
		Spline,
		RadialForce
	}

	static partial class Assert {
		internal delegate void OutputMessageFunction(string message);

		internal static OutputMessageFunction outputMessage;
	}

	static partial class CommandLine {
		internal delegate void GetFunction(byte[] arguments);
		internal delegate void SetFunction(string arguments);
		internal delegate void AppendFunction(string arguments);

		internal static GetFunction get;
		internal static SetFunction set;
		internal static AppendFunction append;
	}

	static partial class Debug {
		internal delegate void LogFunction(LogLevel level, string message);
		internal delegate void HandleExceptionFunction(string exception);
		internal delegate void AddOnScreenMessageFunction(int key, float timeToDisplay, int displayColor, string message);
		internal delegate void ClearOnScreenMessagesFunction();
		internal delegate void DrawBoxFunction(in Vector3 center, in Vector3 extent, in Quaternion rotation, int color, Bool persistentLines, float lifeTime, byte depthPriority, float thickness);
		internal delegate void DrawCapsuleFunction(in Vector3 center, float halfHeight, float radius, in Quaternion rotation, int color, Bool persistentLines, float lifeTime, byte depthPriority, float thickness);
		internal delegate void DrawConeFunction(in Vector3 origin, in Vector3 direction, float length, float angleWidth, float angleHeight, int sides, int color, Bool persistentLines, float lifeTime, byte depthPriority, float thickness);
		internal delegate void DrawCylinderFunction(in Vector3 start, in Vector3 end, float radius, int segments, int color, Bool persistentLines, float lifeTime, byte depthPriority, float thickness);
		internal delegate void DrawSphereFunction(in Vector3 center, float radius, int segments, int color, Bool persistentLines, float lifeTime, byte depthPriority, float thickness);
		internal delegate void DrawLineFunction(in Vector3 start, in Vector3 end, int color, Bool persistentLines, float lifeTime, byte depthPriority, float thickness);
		internal delegate void DrawPointFunction(in Vector3 location, float size, int color, Bool persistentLines, float lifeTime, byte depthPriority);
		internal delegate void FlushPersistentLinesFunction();

		internal static LogFunction log;
		internal static HandleExceptionFunction handleException;
		internal static AddOnScreenMessageFunction addOnScreenMessage;
		internal static ClearOnScreenMessagesFunction clearOnScreenMessages;
		internal static DrawBoxFunction drawBox;
		internal static DrawCapsuleFunction drawCapsule;
		internal static DrawConeFunction drawCone;
		internal static DrawCylinderFunction drawCylinder;
		internal static DrawSphereFunction drawSphere;
		internal static DrawLineFunction drawLine;
		internal static DrawPointFunction drawPoint;
		internal static FlushPersistentLinesFunction flushPersistentLines;
	}

	internal static class Object {
		internal delegate Bool IsPendingKillFunction(IntPtr @object);
		internal delegate Bool IsValidFunction(IntPtr @object);
		internal delegate IntPtr LoadFunction(ObjectType type, string name);
		internal delegate void RenameFunction(IntPtr @object, string name);
		internal delegate Bool InvokeFunction(IntPtr @object, string command);
		internal delegate IntPtr ToActorFunction(IntPtr @object, ActorType type);
		internal delegate IntPtr ToComponentFunction(IntPtr @object, ComponentType type);
		internal delegate uint GetIDFunction(IntPtr @object);
		internal delegate void GetNameFunction(IntPtr @object, byte[] name);
		internal delegate Bool GetBoolFunction(IntPtr @object, string name, ref bool value);
		internal delegate Bool GetByteFunction(IntPtr @object, string name, ref byte value);
		internal delegate Bool GetShortFunction(IntPtr @object, string name, ref short value);
		internal delegate Bool GetIntFunction(IntPtr @object, string name, ref int value);
		internal delegate Bool GetLongFunction(IntPtr @object, string name, ref long value);
		internal delegate Bool GetUShortFunction(IntPtr @object, string name, ref ushort value);
		internal delegate Bool GetUIntFunction(IntPtr @object, string name, ref uint value);
		internal delegate Bool GetULongFunction(IntPtr @object, string name, ref ulong value);
		internal delegate Bool GetFloatFunction(IntPtr @object, string name, ref float value);
		internal delegate Bool GetDoubleFunction(IntPtr @object, string name, ref double value);
		internal delegate Bool GetEnumFunction(IntPtr @object, string name, ref int value);
		internal delegate Bool GetTextFunction(IntPtr @object, string name, byte[] value);
		internal delegate Bool SetBoolFunction(IntPtr @object, string name, Bool value);
		internal delegate Bool SetByteFunction(IntPtr @object, string name, byte value);
		internal delegate Bool SetShortFunction(IntPtr @object, string name, short value);
		internal delegate Bool SetIntFunction(IntPtr @object, string name, int value);
		internal delegate Bool SetLongFunction(IntPtr @object, string name, long value);
		internal delegate Bool SetUShortFunction(IntPtr @object, string name, ushort value);
		internal delegate Bool SetUIntFunction(IntPtr @object, string name, uint value);
		internal delegate Bool SetULongFunction(IntPtr @object, string name, ulong value);
		internal delegate Bool SetFloatFunction(IntPtr @object, string name, float value);
		internal delegate Bool SetDoubleFunction(IntPtr @object, string name, double value);
		internal delegate Bool SetEnumFunction(IntPtr @object, string name, int value);
		internal delegate Bool SetTextFunction(IntPtr @object, string name, string value);

		internal static IsPendingKillFunction isPendingKill;
		internal static IsValidFunction isValid;
		internal static LoadFunction load;
		internal static RenameFunction rename;
		internal static InvokeFunction invoke;
		internal static ToActorFunction toActor;
		internal static ToComponentFunction toComponent;
		internal static GetIDFunction getID;
		internal static GetNameFunction getName;
		internal static GetBoolFunction getBool;
		internal static GetByteFunction getByte;
		internal static GetShortFunction getShort;
		internal static GetIntFunction getInt;
		internal static GetLongFunction getLong;
		internal static GetUShortFunction getUShort;
		internal static GetUIntFunction getUInt;
		internal static GetULongFunction getULong;
		internal static GetFloatFunction getFloat;
		internal static GetDoubleFunction getDouble;
		internal static GetEnumFunction getEnum;
		internal static GetTextFunction getText;
		internal static SetBoolFunction setBool;
		internal static SetByteFunction setByte;
		internal static SetShortFunction setShort;
		internal static SetIntFunction setInt;
		internal static SetLongFunction setLong;
		internal static SetUShortFunction setUShort;
		internal static SetUIntFunction setUInt;
		internal static SetULongFunction setULong;
		internal static SetFloatFunction setFloat;
		internal static SetDoubleFunction setDouble;
		internal static SetEnumFunction setEnum;
		internal static SetTextFunction setText;
	}

	static partial class Application {
		internal delegate Bool IsCanEverRenderFunction();
		internal delegate Bool IsPackagedForDistributionFunction();
		internal delegate Bool IsPackagedForShippingFunction();
		internal delegate void GetProjectDirectoryFunction(byte[] directory);
		internal delegate void GetDefaultLanguageFunction(byte[] language);
		internal delegate void GetProjectNameFunction(byte[] projectName);
		internal delegate float GetVolumeMultiplierFunction();
		internal delegate void SetProjectNameFunction(string projectName);
		internal delegate void SetVolumeMultiplierFunction(float value);
		internal delegate void RequestExitFunction(Bool force);

		internal static IsCanEverRenderFunction isCanEverRender;
		internal static IsPackagedForDistributionFunction isPackagedForDistribution;
		internal static IsPackagedForShippingFunction isPackagedForShipping;
		internal static GetProjectDirectoryFunction getProjectDirectory;
		internal static GetDefaultLanguageFunction getDefaultLanguage;
		internal static GetProjectNameFunction getProjectName;
		internal static GetVolumeMultiplierFunction getVolumeMultiplier;
		internal static SetProjectNameFunction setProjectName;
		internal static SetVolumeMultiplierFunction setVolumeMultiplier;
		internal static RequestExitFunction requestExit;
	}

	static partial class ConsoleManager {
		internal delegate Bool IsRegisteredVariableFunction(string name);
		internal delegate IntPtr FindVariableFunction(string name);
		internal delegate IntPtr RegisterVariableBoolFunction(string name, string help, Bool defaultValue, Bool readOnly);
		internal delegate IntPtr RegisterVariableIntFunction(string name, string help, int defaultValue, Bool readOnly);
		internal delegate IntPtr RegisterVariableFloatFunction(string name, string help, float defaultValue, Bool readOnly);
		internal delegate IntPtr RegisterVariableStringFunction(string name, string help, string defaultValue, Bool readOnly);
		internal delegate void RegisterCommandFunction(string name, string help, IntPtr callback, Bool readOnly);
		internal delegate void UnregisterObjectFunction(string name);

		internal static IsRegisteredVariableFunction isRegisteredVariable;
		internal static FindVariableFunction findVariable;
		internal static RegisterVariableBoolFunction registerVariableBool;
		internal static RegisterVariableIntFunction registerVariableInt;
		internal static RegisterVariableFloatFunction registerVariableFloat;
		internal static RegisterVariableStringFunction registerVariableString;
		internal static RegisterCommandFunction registerCommand;
		internal static UnregisterObjectFunction unregisterObject;
	}

	static partial class Engine {
		internal delegate Bool IsSplitScreenFunction();
		internal delegate Bool IsEditorFunction();
		internal delegate Bool IsForegroundWindowFunction();
		internal delegate Bool IsExitRequestedFunction();
		internal delegate NetMode GetNetModeFunction();
		internal delegate uint GetFrameNumberFunction();
		internal delegate void GetViewportSizeFunction(ref Vector2 value);
		internal delegate void GetScreenResolutionFunction(ref Vector2 value);
		internal delegate WindowMode GetWindowModeFunction();
		internal delegate void GetVersionFunction(byte[] version);
		internal delegate float GetMaxFPSFunction();
		internal delegate void SetMaxFPSFunction(float maxFPS);
		internal delegate void SetTitleFunction(string title);
		internal delegate void AddActionMappingFunction(string actionName, string key, Bool shift, Bool ctrl, Bool alt, Bool cmd);
		internal delegate void AddAxisMappingFunction(string axisName, string key, float scale);
		internal delegate void ForceGarbageCollectionFunction(Bool fullPurge);
		internal delegate void DelayGarbageCollectionFunction();

		internal static IsSplitScreenFunction isSplitScreen;
		internal static IsEditorFunction isEditor;
		internal static IsForegroundWindowFunction isForegroundWindow;
		internal static IsExitRequestedFunction isExitRequested;
		internal static GetNetModeFunction getNetMode;
		internal static GetFrameNumberFunction getFrameNumber;
		internal static GetViewportSizeFunction getViewportSize;
		internal static GetScreenResolutionFunction getScreenResolution;
		internal static GetWindowModeFunction getWindowMode;
		internal static GetVersionFunction getVersion;
		internal static GetMaxFPSFunction getMaxFPS;
		internal static SetMaxFPSFunction setMaxFPS;
		internal static SetTitleFunction setTitle;
		internal static AddActionMappingFunction addActionMapping;
		internal static AddAxisMappingFunction addAxisMapping;
		internal static ForceGarbageCollectionFunction forceGarbageCollection;
		internal static DelayGarbageCollectionFunction delayGarbageCollection;
	}

	static partial class HeadMountedDisplay {
		internal delegate Bool IsConnectedFunction();
		internal delegate Bool GetEnabledFunction();
		internal delegate Bool GetLowPersistenceModeFunction();
		internal delegate void GetDeviceNameFunction(byte[] name);
		internal delegate void SetEnableFunction(Bool value);
		internal delegate void SetLowPersistenceModeFunction(Bool value);

		internal static IsConnectedFunction isConnected;
		internal static GetEnabledFunction getEnabled;
		internal static GetLowPersistenceModeFunction getLowPersistenceMode;
		internal static GetDeviceNameFunction getDeviceName;
		internal static SetEnableFunction setEnable;
		internal static SetLowPersistenceModeFunction setLowPersistenceMode;
	}

	static partial class World {
		internal delegate int GetActorCountFunction();
		internal delegate float GetDeltaSecondsFunction();
		internal delegate float GetRealTimeSecondsFunction();
		internal delegate float GetTimeSecondsFunction();
		internal delegate void GetCurrentLevelNameFunction(byte[] levelName);
		internal delegate Bool GetSimulatePhysicsFunction();
		internal delegate void GetWorldOriginFunction(ref Vector3 value);
		internal delegate IntPtr GetActorFunction(string name, ActorType type);
		internal delegate IntPtr GetActorByTagFunction(string tag, ActorType type);
		internal delegate IntPtr GetActorByIDFunction(uint iD, ActorType type);
		internal delegate IntPtr GetFirstPlayerControllerFunction();
		internal delegate void SetOnActorBeginOverlapCallbackFunction(IntPtr callback);
		internal delegate void SetOnActorEndOverlapCallbackFunction(IntPtr callback);
		internal delegate void SetOnActorHitCallbackFunction(IntPtr callback);
		internal delegate void SetOnActorBeginCursorOverCallbackFunction(IntPtr callback);
		internal delegate void SetOnActorEndCursorOverCallbackFunction(IntPtr callback);
		internal delegate void SetOnComponentBeginOverlapCallbackFunction(IntPtr callback);
		internal delegate void SetOnComponentEndOverlapCallbackFunction(IntPtr callback);
		internal delegate void SetOnComponentHitCallbackFunction(IntPtr callback);
		internal delegate void SetOnComponentBeginCursorOverCallbackFunction(IntPtr callback);
		internal delegate void SetOnComponentEndCursorOverCallbackFunction(IntPtr callback);
		internal delegate void SetSimulatePhysicsFunction(Bool value);
		internal delegate void SetGravityFunction(float value);
		internal delegate Bool SetWorldOriginFunction(in Vector3 value);
		internal delegate void OpenLevelFunction(string levelName);
		internal delegate Bool LineTraceTestByChannelFunction(in Vector3 start, in Vector3 end, CollisionChannel channel, Bool traceComplex, IntPtr ignoredActor, IntPtr ignoredComponent);
		internal delegate Bool LineTraceTestByProfileFunction(in Vector3 start, in Vector3 end, string profileName, Bool traceComplex, IntPtr ignoredActor, IntPtr ignoredComponent);
		internal delegate Bool LineTraceSingleByChannelFunction(in Vector3 start, in Vector3 end, CollisionChannel channel, ref Hit hit, byte[] boneName, Bool traceComplex, IntPtr ignoredActor, IntPtr ignoredComponent);
		internal delegate Bool LineTraceSingleByProfileFunction(in Vector3 start, in Vector3 end, string profileName, ref Hit hit, byte[] boneName, Bool traceComplex, IntPtr ignoredActor, IntPtr ignoredComponent);
		internal delegate Bool SweepTestByChannelFunction(in Vector3 start, in Vector3 end, in Quaternion rotation, CollisionChannel channel, in CollisionShape shape, Bool traceComplex, IntPtr ignoredActor, IntPtr ignoredComponent);
		internal delegate Bool SweepTestByProfileFunction(in Vector3 start, in Vector3 end, in Quaternion rotation, string profileName, in CollisionShape shape, Bool traceComplex, IntPtr ignoredActor, IntPtr ignoredComponent);
		internal delegate Bool SweepSingleByChannelFunction(in Vector3 start, in Vector3 end, in Quaternion rotation, CollisionChannel channel, in CollisionShape shape, ref Hit hit, byte[] boneName, Bool traceComplex, IntPtr ignoredActor, IntPtr ignoredComponent);
		internal delegate Bool SweepSingleByProfileFunction(in Vector3 start, in Vector3 end, in Quaternion rotation, string profileName, in CollisionShape shape, ref Hit hit, byte[] boneName, Bool traceComplex, IntPtr ignoredActor, IntPtr ignoredComponent);
		internal delegate Bool OverlapAnyTestByChannelFunction(in Vector3 location, in Quaternion rotation, CollisionChannel channel, in CollisionShape shape, IntPtr ignoredActor, IntPtr ignoredComponent);
		internal delegate Bool OverlapAnyTestByProfileFunction(in Vector3 location, in Quaternion rotation, string profileName, in CollisionShape shape, IntPtr ignoredActor, IntPtr ignoredComponent);
		internal delegate Bool OverlapBlockingTestByChannelFunction(in Vector3 location, in Quaternion rotation, CollisionChannel channel, in CollisionShape shape, IntPtr ignoredActor, IntPtr ignoredComponent);
		internal delegate Bool OverlapBlockingTestByProfileFunction(in Vector3 location, in Quaternion rotation, string profileName, in CollisionShape shape, IntPtr ignoredActor, IntPtr ignoredComponent);

		internal static GetActorCountFunction getActorCount;
		internal static GetDeltaSecondsFunction getDeltaSeconds;
		internal static GetRealTimeSecondsFunction getRealTimeSeconds;
		internal static GetTimeSecondsFunction getTimeSeconds;
		internal static GetCurrentLevelNameFunction getCurrentLevelName;
		internal static GetSimulatePhysicsFunction getSimulatePhysics;
		internal static GetWorldOriginFunction getWorldOrigin;
		internal static GetActorFunction getActor;
		internal static GetActorByTagFunction getActorByTag;
		internal static GetActorByIDFunction getActorByID;
		internal static GetFirstPlayerControllerFunction getFirstPlayerController;
		internal static SetOnActorBeginOverlapCallbackFunction setOnActorBeginOverlapCallback;
		internal static SetOnActorEndOverlapCallbackFunction setOnActorEndOverlapCallback;
		internal static SetOnActorHitCallbackFunction setOnActorHitCallback;
		internal static SetOnActorBeginCursorOverCallbackFunction setOnActorBeginCursorOverCallback;
		internal static SetOnActorEndCursorOverCallbackFunction setOnActorEndCursorOverCallback;
		internal static SetOnComponentBeginOverlapCallbackFunction setOnComponentBeginOverlapCallback;
		internal static SetOnComponentEndOverlapCallbackFunction setOnComponentEndOverlapCallback;
		internal static SetOnComponentHitCallbackFunction setOnComponentHitCallback;
		internal static SetOnComponentBeginCursorOverCallbackFunction setOnComponentBeginCursorOverCallback;
		internal static SetOnComponentEndCursorOverCallbackFunction setOnComponentEndCursorOverCallback;
		internal static SetSimulatePhysicsFunction setSimulatePhysics;
		internal static SetGravityFunction setGravity;
		internal static SetWorldOriginFunction setWorldOrigin;
		internal static OpenLevelFunction openLevel;
		internal static LineTraceTestByChannelFunction lineTraceTestByChannel;
		internal static LineTraceTestByProfileFunction lineTraceTestByProfile;
		internal static LineTraceSingleByChannelFunction lineTraceSingleByChannel;
		internal static LineTraceSingleByProfileFunction lineTraceSingleByProfile;
		internal static SweepTestByChannelFunction sweepTestByChannel;
		internal static SweepTestByProfileFunction sweepTestByProfile;
		internal static SweepSingleByChannelFunction sweepSingleByChannel;
		internal static SweepSingleByProfileFunction sweepSingleByProfile;
		internal static OverlapAnyTestByChannelFunction overlapAnyTestByChannel;
		internal static OverlapAnyTestByProfileFunction overlapAnyTestByProfile;
		internal static OverlapBlockingTestByChannelFunction overlapBlockingTestByChannel;
		internal static OverlapBlockingTestByProfileFunction overlapBlockingTestByProfile;
	}

	partial class Blueprint {
		internal delegate Bool IsValidActorClassFunction(IntPtr blueprint, ActorType type);
		internal delegate Bool IsValidComponentClassFunction(IntPtr blueprint, ComponentType type);

		internal static IsValidActorClassFunction isValidActorClass;
		internal static IsValidComponentClassFunction isValidComponentClass;
	}

	partial class ConsoleObject {
		internal delegate Bool IsBoolFunction(IntPtr consoleObject);
		internal delegate Bool IsIntFunction(IntPtr consoleObject);
		internal delegate Bool IsFloatFunction(IntPtr consoleObject);
		internal delegate Bool IsStringFunction(IntPtr consoleObject);

		internal static IsBoolFunction isBool;
		internal static IsIntFunction isInt;
		internal static IsFloatFunction isFloat;
		internal static IsStringFunction isString;
	}

	partial class ConsoleVariable {
		internal delegate Bool GetBoolFunction(IntPtr consoleVariable);
		internal delegate int GetIntFunction(IntPtr consoleVariable);
		internal delegate float GetFloatFunction(IntPtr consoleVariable);
		internal delegate void GetStringFunction(IntPtr consoleVariable, byte[] value);
		internal delegate void SetBoolFunction(IntPtr consoleVariable, Bool value);
		internal delegate void SetIntFunction(IntPtr consoleVariable, int value);
		internal delegate void SetFloatFunction(IntPtr consoleVariable, float value);
		internal delegate void SetStringFunction(IntPtr consoleVariable, string value);
		internal delegate void SetOnChangedCallbackFunction(IntPtr consoleVariable, IntPtr callback);
		internal delegate void ClearOnChangedCallbackFunction(IntPtr consoleVariable);

		internal static GetBoolFunction getBool;
		internal static GetIntFunction getInt;
		internal static GetFloatFunction getFloat;
		internal static GetStringFunction getString;
		internal static SetBoolFunction setBool;
		internal static SetIntFunction setInt;
		internal static SetFloatFunction setFloat;
		internal static SetStringFunction setString;
		internal static SetOnChangedCallbackFunction setOnChangedCallback;
		internal static ClearOnChangedCallbackFunction clearOnChangedCallback;
	}

	partial class Actor {
		internal delegate Bool IsPendingKillFunction(IntPtr actor);
		internal delegate Bool IsRootComponentMovableFunction(IntPtr actor);
		internal delegate Bool IsOverlappingActorFunction(IntPtr actor, IntPtr other);
		internal delegate IntPtr SpawnFunction(string name, ActorType type, IntPtr blueprint);
		internal delegate Bool DestroyFunction(IntPtr actor);
		internal delegate void RenameFunction(IntPtr actor, string name);
		internal delegate void HideFunction(IntPtr actor, Bool value);
		internal delegate Bool TeleportToFunction(IntPtr actor, in Vector3 destinationLocation, in Quaternion destinationRotation, Bool isATest, Bool noCheck);
		internal delegate IntPtr GetComponentFunction(IntPtr actor, string name, ComponentType type);
		internal delegate IntPtr GetComponentByTagFunction(IntPtr actor, string tag, ComponentType type);
		internal delegate IntPtr GetComponentByIDFunction(IntPtr actor, uint iD, ComponentType type);
		internal delegate IntPtr GetRootComponentFunction(IntPtr actor, ComponentType type);
		internal delegate IntPtr GetInputComponentFunction(IntPtr actor);
		internal delegate float GetCreationTimeFunction(IntPtr actor);
		internal delegate Bool GetBlockInputFunction(IntPtr actor);
		internal delegate float GetDistanceToFunction(IntPtr actor, IntPtr other);
		internal delegate float GetHorizontalDistanceToFunction(IntPtr actor, IntPtr other);
		internal delegate void GetBoundsFunction(IntPtr actor, Bool onlyCollidingComponents, ref Vector3 origin, ref Vector3 extent);
		internal delegate void GetEyesViewPointFunction(IntPtr actor, ref Vector3 location, ref Quaternion rotation);
		internal delegate Bool SetRootComponentFunction(IntPtr actor, IntPtr rootComponent);
		internal delegate void SetInputComponentFunction(IntPtr actor, IntPtr inputComponent);
		internal delegate void SetBlockInputFunction(IntPtr actor, Bool value);
		internal delegate void SetLifeSpanFunction(IntPtr actor, float lifeSpan);
		internal delegate void SetEnableInputFunction(IntPtr actor, IntPtr playerController, Bool value);
		internal delegate void SetEnableCollisionFunction(IntPtr actor, Bool value);
		internal delegate void AddTagFunction(IntPtr actor, string tag);
		internal delegate void RemoveTagFunction(IntPtr actor, string tag);
		internal delegate Bool HasTagFunction(IntPtr actor, string tag);
		internal delegate void RegisterEventFunction(IntPtr actor, ActorEventType type);
		internal delegate void UnregisterEventFunction(IntPtr actor, ActorEventType type);

		internal static IsPendingKillFunction isPendingKill;
		internal static IsRootComponentMovableFunction isRootComponentMovable;
		internal static IsOverlappingActorFunction isOverlappingActor;
		internal static SpawnFunction spawn;
		internal static DestroyFunction destroy;
		internal static RenameFunction rename;
		internal static HideFunction hide;
		internal static TeleportToFunction teleportTo;
		internal static GetComponentFunction getComponent;
		internal static GetComponentByTagFunction getComponentByTag;
		internal static GetComponentByIDFunction getComponentByID;
		internal static GetRootComponentFunction getRootComponent;
		internal static GetInputComponentFunction getInputComponent;
		internal static GetCreationTimeFunction getCreationTime;
		internal static GetBlockInputFunction getBlockInput;
		internal static GetDistanceToFunction getDistanceTo;
		internal static GetHorizontalDistanceToFunction getHorizontalDistanceTo;
		internal static GetBoundsFunction getBounds;
		internal static GetEyesViewPointFunction getEyesViewPoint;
		internal static SetRootComponentFunction setRootComponent;
		internal static SetInputComponentFunction setInputComponent;
		internal static SetBlockInputFunction setBlockInput;
		internal static SetLifeSpanFunction setLifeSpan;
		internal static SetEnableInputFunction setEnableInput;
		internal static SetEnableCollisionFunction setEnableCollision;
		internal static AddTagFunction addTag;
		internal static RemoveTagFunction removeTag;
		internal static HasTagFunction hasTag;
		internal static RegisterEventFunction registerEvent;
		internal static UnregisterEventFunction unregisterEvent;
	}

	partial class TriggerBase { }

	partial class TriggerBox { }

	partial class TriggerCapsule { }

	partial class TriggerSphere { }

	partial class Pawn {
		internal delegate void AddControllerYawInputFunction(IntPtr pawn, float value);
		internal delegate void AddControllerPitchInputFunction(IntPtr pawn, float value);
		internal delegate void AddControllerRollInputFunction(IntPtr pawn, float value);
		internal delegate void AddMovementInputFunction(IntPtr pawn, in Vector3 worldDirection, float scaleValue, Bool force);
		internal delegate AutoPossessAI GetAutoPossessAIFunction(IntPtr pawn);
		internal delegate AutoReceiveInput GetAutoPossessPlayerFunction(IntPtr pawn);
		internal delegate void GetGravityDirectionFunction(IntPtr pawn, ref Vector3 value);
		internal delegate IntPtr GetAIControllerFunction(IntPtr pawn);
		internal delegate IntPtr GetPlayerControllerFunction(IntPtr pawn);
		internal delegate void SetAutoPossessAIFunction(IntPtr pawn, AutoPossessAI value);
		internal delegate void SetAutoPossessPlayerFunction(IntPtr pawn, AutoReceiveInput value);

		internal static AddControllerYawInputFunction addControllerYawInput;
		internal static AddControllerPitchInputFunction addControllerPitchInput;
		internal static AddControllerRollInputFunction addControllerRollInput;
		internal static AddMovementInputFunction addMovementInput;
		internal static GetAutoPossessAIFunction getAutoPossessAI;
		internal static GetAutoPossessPlayerFunction getAutoPossessPlayer;
		internal static GetGravityDirectionFunction getGravityDirection;
		internal static GetAIControllerFunction getAIController;
		internal static GetPlayerControllerFunction getPlayerController;
		internal static SetAutoPossessAIFunction setAutoPossessAI;
		internal static SetAutoPossessPlayerFunction setAutoPossessPlayer;
	}

	partial class Character {
		internal delegate Bool IsCrouchedFunction(IntPtr character);
		internal delegate Bool CanCrouchFunction(IntPtr character);
		internal delegate Bool CanJumpFunction(IntPtr character);
		internal delegate void CheckJumpInputFunction(IntPtr character, float deltaTime);
		internal delegate void ClearJumpInputFunction(IntPtr character, float deltaTime);
		internal delegate void LaunchFunction(IntPtr character, in Vector3 velocity, Bool overrideXY, Bool overrideZ);
		internal delegate void CrouchFunction(IntPtr character);
		internal delegate void StopCrouchingFunction(IntPtr character);
		internal delegate void JumpFunction(IntPtr character);
		internal delegate void StopJumpingFunction(IntPtr character);

		internal static IsCrouchedFunction isCrouched;
		internal static CanCrouchFunction canCrouch;
		internal static CanJumpFunction canJump;
		internal static CheckJumpInputFunction checkJumpInput;
		internal static ClearJumpInputFunction clearJumpInput;
		internal static LaunchFunction launch;
		internal static CrouchFunction crouch;
		internal static StopCrouchingFunction stopCrouching;
		internal static JumpFunction jump;
		internal static StopJumpingFunction stopJumping;
	}

	partial class Controller {
		internal delegate Bool IsLookInputIgnoredFunction(IntPtr controller);
		internal delegate Bool IsMoveInputIgnoredFunction(IntPtr controller);
		internal delegate Bool IsPlayerControllerFunction(IntPtr controller);
		internal delegate IntPtr GetPawnFunction(IntPtr controller);
		internal delegate IntPtr GetCharacterFunction(IntPtr controller);
		internal delegate IntPtr GetViewTargetFunction(IntPtr controller);
		internal delegate void GetControlRotationFunction(IntPtr controller, ref Quaternion value);
		internal delegate void GetDesiredRotationFunction(IntPtr controller, ref Quaternion value);
		internal delegate Bool LineOfSightToFunction(IntPtr controller, IntPtr actor, in Vector3 viewPoint, Bool alternateChecks);
		internal delegate void SetControlRotationFunction(IntPtr controller, in Quaternion value);
		internal delegate void SetInitialLocationAndRotationFunction(IntPtr controller, in Vector3 newLocation, in Quaternion newRotation);
		internal delegate void SetIgnoreLookInputFunction(IntPtr controller, Bool value);
		internal delegate void SetIgnoreMoveInputFunction(IntPtr controller, Bool value);
		internal delegate void ResetIgnoreLookInputFunction(IntPtr controller);
		internal delegate void ResetIgnoreMoveInputFunction(IntPtr controller);
		internal delegate void PossessFunction(IntPtr controller, IntPtr pawn);
		internal delegate void UnpossessFunction(IntPtr controller);

		internal static IsLookInputIgnoredFunction isLookInputIgnored;
		internal static IsMoveInputIgnoredFunction isMoveInputIgnored;
		internal static IsPlayerControllerFunction isPlayerController;
		internal static GetPawnFunction getPawn;
		internal static GetCharacterFunction getCharacter;
		internal static GetViewTargetFunction getViewTarget;
		internal static GetControlRotationFunction getControlRotation;
		internal static GetDesiredRotationFunction getDesiredRotation;
		internal static LineOfSightToFunction lineOfSightTo;
		internal static SetControlRotationFunction setControlRotation;
		internal static SetInitialLocationAndRotationFunction setInitialLocationAndRotation;
		internal static SetIgnoreLookInputFunction setIgnoreLookInput;
		internal static SetIgnoreMoveInputFunction setIgnoreMoveInput;
		internal static ResetIgnoreLookInputFunction resetIgnoreLookInput;
		internal static ResetIgnoreMoveInputFunction resetIgnoreMoveInput;
		internal static PossessFunction possess;
		internal static UnpossessFunction unpossess;
	}

	partial class AIController {
		internal delegate void ClearFocusFunction(IntPtr aiController, AIFocusPriority priority);
		internal delegate void GetFocalPointFunction(IntPtr aiController, ref Vector3 value);
		internal delegate void SetFocalPointFunction(IntPtr aiController, in Vector3 newFocus, AIFocusPriority priority);
		internal delegate IntPtr GetFocusActorFunction(IntPtr aiController);
		internal delegate Bool GetAllowStrafeFunction(IntPtr aiController);
		internal delegate void SetAllowStrafeFunction(IntPtr aiController, Bool value);
		internal delegate void SetFocusFunction(IntPtr aiController, IntPtr newFocus, AIFocusPriority priority);

		internal static ClearFocusFunction clearFocus;
		internal static GetFocalPointFunction getFocalPoint;
		internal static SetFocalPointFunction setFocalPoint;
		internal static GetFocusActorFunction getFocusActor;
		internal static GetAllowStrafeFunction getAllowStrafe;
		internal static SetAllowStrafeFunction setAllowStrafe;
		internal static SetFocusFunction setFocus;
	}

	partial class PlayerController {
		internal delegate Bool IsPausedFunction(IntPtr playerController);
		internal delegate Bool GetShowMouseCursorFunction(IntPtr playerController);
		internal delegate Bool GetEnableMouseOverEventsFunction(IntPtr playerController);
		internal delegate Bool GetMousePositionFunction(IntPtr playerController, ref float x, ref float y);
		internal delegate IntPtr GetPlayerFunction(IntPtr playerController);
		internal delegate IntPtr GetPlayerInputFunction(IntPtr playerController);
		internal delegate void SetShowMouseCursorFunction(IntPtr playerController, Bool value);
		internal delegate void SetEnableMouseOverEventsFunction(IntPtr playerController, Bool value);
		internal delegate void SetMousePositionFunction(IntPtr playerController, float x, float y);
		internal delegate void ConsoleCommandFunction(IntPtr playerController, string command, Bool writeToLog);
		internal delegate Bool SetPauseFunction(IntPtr playerController, Bool value);
		internal delegate void SetViewTargetFunction(IntPtr playerController, IntPtr newViewTarget);
		internal delegate void SetViewTargetWithBlendFunction(IntPtr playerController, IntPtr newViewTarget, float time, float exponent, BlendType type, Bool lockOutgoing);
		internal delegate void AddYawInputFunction(IntPtr playerController, float value);
		internal delegate void AddPitchInputFunction(IntPtr playerController, float value);
		internal delegate void AddRollInputFunction(IntPtr playerController, float value);

		internal static IsPausedFunction isPaused;
		internal static GetShowMouseCursorFunction getShowMouseCursor;
		internal static GetEnableMouseOverEventsFunction getEnableMouseOverEvents;
		internal static GetMousePositionFunction getMousePosition;
		internal static GetPlayerFunction getPlayer;
		internal static GetPlayerInputFunction getPlayerInput;
		internal static SetShowMouseCursorFunction setShowMouseCursor;
		internal static SetEnableMouseOverEventsFunction setEnableMouseOverEvents;
		internal static SetMousePositionFunction setMousePosition;
		internal static ConsoleCommandFunction consoleCommand;
		internal static SetPauseFunction setPause;
		internal static SetViewTargetFunction setViewTarget;
		internal static SetViewTargetWithBlendFunction setViewTargetWithBlend;
		internal static AddYawInputFunction addYawInput;
		internal static AddPitchInputFunction addPitchInput;
		internal static AddRollInputFunction addRollInput;
	}

	partial class Volume {
		internal delegate Bool EncompassesPointFunction(IntPtr volume, in Vector3 point, float sphereRadius, ref float outDistanceToPoint);

		internal static EncompassesPointFunction encompassesPoint;
	}

	partial class TriggerVolume { }

	partial class PostProcessVolume {
		internal delegate Bool GetEnabledFunction(IntPtr postProcessVolume);
		internal delegate float GetBlendRadiusFunction(IntPtr postProcessVolume);
		internal delegate float GetBlendWeightFunction(IntPtr postProcessVolume);
		internal delegate Bool GetUnboundFunction(IntPtr postProcessVolume);
		internal delegate float GetPriorityFunction(IntPtr postProcessVolume);
		internal delegate void SetEnabledFunction(IntPtr postProcessVolume, Bool value);
		internal delegate void SetBlendRadiusFunction(IntPtr postProcessVolume, float value);
		internal delegate void SetBlendWeightFunction(IntPtr postProcessVolume, float value);
		internal delegate void SetUnboundFunction(IntPtr postProcessVolume, Bool value);
		internal delegate void SetPriorityFunction(IntPtr postProcessVolume, float priority);

		internal static GetEnabledFunction getEnabled;
		internal static GetBlendRadiusFunction getBlendRadius;
		internal static GetBlendWeightFunction getBlendWeight;
		internal static GetUnboundFunction getUnbound;
		internal static GetPriorityFunction getPriority;
		internal static SetEnabledFunction setEnabled;
		internal static SetBlendRadiusFunction setBlendRadius;
		internal static SetBlendWeightFunction setBlendWeight;
		internal static SetUnboundFunction setUnbound;
		internal static SetPriorityFunction setPriority;
	}

	partial class LevelScript { }

	partial class AmbientSound { }

	partial class Light { }

	partial class DirectionalLight { }

	partial class PointLight { }

	partial class RectLight { }

	partial class SpotLight { }

	partial class SoundBase {
		internal delegate float GetDurationFunction(IntPtr soundBase);

		internal static GetDurationFunction getDuration;
	}

	partial class SoundWave {
		internal delegate Bool GetLoopFunction(IntPtr soundWave);
		internal delegate void SetLoopFunction(IntPtr soundWave, Bool value);

		internal static GetLoopFunction getLoop;
		internal static SetLoopFunction setLoop;
	}

	partial class AnimationAsset { }

	partial class AnimationSequenceBase { }

	partial class AnimationSequence { }

	partial class AnimationCompositeBase { }

	partial class AnimationMontage { }

	partial class AnimationInstance {
		internal delegate IntPtr GetCurrentActiveMontageFunction(IntPtr animationInstance);
		internal delegate Bool IsPlayingFunction(IntPtr animationInstance, IntPtr montage);
		internal delegate float GetPlayRateFunction(IntPtr animationInstance, IntPtr montage);
		internal delegate float GetPositionFunction(IntPtr animationInstance, IntPtr montage);
		internal delegate float GetBlendTimeFunction(IntPtr animationInstance, IntPtr montage);
		internal delegate void GetCurrentSectionFunction(IntPtr animationInstance, IntPtr montage, byte[] sectionName);
		internal delegate void SetPlayRateFunction(IntPtr animationInstance, IntPtr montage, float value);
		internal delegate void SetPositionFunction(IntPtr animationInstance, IntPtr montage, float position);
		internal delegate void SetNextSectionFunction(IntPtr animationInstance, IntPtr montage, string sectionToChange, string nextSection);
		internal delegate float PlayMontageFunction(IntPtr animationInstance, IntPtr montage, float playRate, float timeToStartMontageAt, Bool stopAllMontages);
		internal delegate void PauseMontageFunction(IntPtr animationInstance, IntPtr montage);
		internal delegate void ResumeMontageFunction(IntPtr animationInstance, IntPtr montage);
		internal delegate void StopMontageFunction(IntPtr animationInstance, IntPtr montage, float blendOutTime);
		internal delegate void JumpToSectionFunction(IntPtr animationInstance, IntPtr montage, string sectionName);
		internal delegate void JumpToSectionsEndFunction(IntPtr animationInstance, IntPtr montage, string sectionName);

		internal static GetCurrentActiveMontageFunction getCurrentActiveMontage;
		internal static IsPlayingFunction isPlaying;
		internal static GetPlayRateFunction getPlayRate;
		internal static GetPositionFunction getPosition;
		internal static GetBlendTimeFunction getBlendTime;
		internal static GetCurrentSectionFunction getCurrentSection;
		internal static SetPlayRateFunction setPlayRate;
		internal static SetPositionFunction setPosition;
		internal static SetNextSectionFunction setNextSection;
		internal static PlayMontageFunction playMontage;
		internal static PauseMontageFunction pauseMontage;
		internal static ResumeMontageFunction resumeMontage;
		internal static StopMontageFunction stopMontage;
		internal static JumpToSectionFunction jumpToSection;
		internal static JumpToSectionsEndFunction jumpToSectionsEnd;
	}

	partial class Player {
		internal delegate IntPtr GetPlayerControllerFunction(IntPtr player);

		internal static GetPlayerControllerFunction getPlayerController;
	}

	partial class PlayerInput {
		internal delegate Bool IsKeyPressedFunction(IntPtr playerInput, string key);
		internal delegate float GetTimeKeyPressedFunction(IntPtr playerInput, string key);
		internal delegate void GetMouseSensitivityFunction(IntPtr playerInput, ref Vector2 value);
		internal delegate void SetMouseSensitivityFunction(IntPtr playerInput, in Vector2 value);
		internal delegate void AddActionMappingFunction(IntPtr playerInput, string actionName, string key, Bool shift, Bool ctrl, Bool alt, Bool cmd);
		internal delegate void AddAxisMappingFunction(IntPtr playerInput, string axisName, string key, float scale);
		internal delegate void RemoveActionMappingFunction(IntPtr playerInput, string actionName, string key);
		internal delegate void RemoveAxisMappingFunction(IntPtr playerInput, string axisName, string key);

		internal static IsKeyPressedFunction isKeyPressed;
		internal static GetTimeKeyPressedFunction getTimeKeyPressed;
		internal static GetMouseSensitivityFunction getMouseSensitivity;
		internal static SetMouseSensitivityFunction setMouseSensitivity;
		internal static AddActionMappingFunction addActionMapping;
		internal static AddAxisMappingFunction addAxisMapping;
		internal static RemoveActionMappingFunction removeActionMapping;
		internal static RemoveAxisMappingFunction removeAxisMapping;
	}

	partial class StreamableRenderAsset { }

	partial class StaticMesh { }

	partial class SkeletalMesh { }

	partial class Texture { }

	partial class Texture2D {
		internal delegate IntPtr CreateFromFileFunction(string filePath);
		internal delegate IntPtr CreateFromBufferFunction(byte[] buffer, int length);
		internal delegate Bool HasAlphaChannelFunction(IntPtr texture2D);
		internal delegate void GetSizeFunction(IntPtr texture2D, ref Vector2 value);
		internal delegate PixelFormat GetPixelFormatFunction(IntPtr texture2D);

		internal static CreateFromFileFunction createFromFile;
		internal static CreateFromBufferFunction createFromBuffer;
		internal static HasAlphaChannelFunction hasAlphaChannel;
		internal static GetSizeFunction getSize;
		internal static GetPixelFormatFunction getPixelFormat;
	}

	partial class ActorComponent {
		internal delegate Bool IsOwnerSelectedFunction(IntPtr actorComponent);
		internal delegate IntPtr GetOwnerFunction(IntPtr actorComponent, ActorType type);
		internal delegate void DestroyFunction(IntPtr actorComponent, Bool promoteChildren);
		internal delegate void AddTagFunction(IntPtr actorComponent, string tag);
		internal delegate void RemoveTagFunction(IntPtr actorComponent, string tag);
		internal delegate Bool HasTagFunction(IntPtr actorComponent, string tag);

		internal static IsOwnerSelectedFunction isOwnerSelected;
		internal static GetOwnerFunction getOwner;
		internal static DestroyFunction destroy;
		internal static AddTagFunction addTag;
		internal static RemoveTagFunction removeTag;
		internal static HasTagFunction hasTag;
	}

	partial class InputComponent {
		internal delegate Bool HasBindingsFunction(IntPtr inputComponent);
		internal delegate int GetActionBindingsNumberFunction(IntPtr inputComponent);
		internal delegate void ClearActionBindingsFunction(IntPtr inputComponent);
		internal delegate void BindActionFunction(IntPtr inputComponent, string actionName, InputEvent keyEvent, Bool executedWhenPaused, IntPtr callback);
		internal delegate void BindAxisFunction(IntPtr inputComponent, string axisName, Bool executedWhenPaused, IntPtr callback);
		internal delegate void RemoveActionBindingFunction(IntPtr inputComponent, string actionName, InputEvent keyEvent);
		internal delegate Bool GetBlockInputFunction(IntPtr inputComponent);
		internal delegate void SetBlockInputFunction(IntPtr inputComponent, Bool value);
		internal delegate int GetPriorityFunction(IntPtr inputComponent);
		internal delegate void SetPriorityFunction(IntPtr inputComponent, int value);

		internal static HasBindingsFunction hasBindings;
		internal static GetActionBindingsNumberFunction getActionBindingsNumber;
		internal static ClearActionBindingsFunction clearActionBindings;
		internal static BindActionFunction bindAction;
		internal static BindAxisFunction bindAxis;
		internal static RemoveActionBindingFunction removeActionBinding;
		internal static GetBlockInputFunction getBlockInput;
		internal static SetBlockInputFunction setBlockInput;
		internal static GetPriorityFunction getPriority;
		internal static SetPriorityFunction setPriority;
	}

	partial class SceneComponent {
		internal delegate Bool IsAttachedToComponentFunction(IntPtr sceneComponent, IntPtr component);
		internal delegate Bool IsAttachedToActorFunction(IntPtr sceneComponent, IntPtr actor);
		internal delegate Bool IsVisibleFunction(IntPtr sceneComponent);
		internal delegate Bool IsSocketExistsFunction(IntPtr sceneComponent, string socketName);
		internal delegate Bool HasAnySocketsFunction(IntPtr sceneComponent);
		internal delegate IntPtr CreateFunction(IntPtr actor, ComponentType type, string name, Bool setAsRoot, IntPtr blueprint);
		internal delegate Bool AttachToComponentFunction(IntPtr sceneComponent, IntPtr parent, AttachmentTransformRule attachmentRule, string socketName);
		internal delegate void DetachFromComponentFunction(IntPtr sceneComponent, DetachmentTransformRule detachmentRule);
		internal delegate void ActivateFunction(IntPtr sceneComponent);
		internal delegate void DeactivateFunction(IntPtr sceneComponent);
		internal delegate void UpdateToWorldFunction(IntPtr sceneComponent, TeleportType type, UpdateTransformFlags flags);
		internal delegate void AddLocalOffsetFunction(IntPtr sceneComponent, in Vector3 deltaLocation);
		internal delegate void AddLocalRotationFunction(IntPtr sceneComponent, in Quaternion deltaRotation);
		internal delegate void AddRelativeLocationFunction(IntPtr sceneComponent, in Vector3 deltaLocation);
		internal delegate void AddRelativeRotationFunction(IntPtr sceneComponent, in Quaternion deltaRotation);
		internal delegate void AddLocalTransformFunction(IntPtr sceneComponent, in Transform deltaTransform);
		internal delegate void AddWorldOffsetFunction(IntPtr sceneComponent, in Vector3 deltaLocation);
		internal delegate void AddWorldRotationFunction(IntPtr sceneComponent, in Quaternion deltaRotation);
		internal delegate void AddWorldTransformFunction(IntPtr sceneComponent, in Transform deltaTransform);
		internal delegate void GetAttachedSocketNameFunction(IntPtr sceneComponent, byte[] socketName);
		internal delegate void GetSocketLocationFunction(IntPtr sceneComponent, string socketName, ref Vector3 value);
		internal delegate void GetSocketRotationFunction(IntPtr sceneComponent, string socketName, ref Quaternion value);
		internal delegate void GetComponentVelocityFunction(IntPtr sceneComponent, ref Vector3 value);
		internal delegate void GetComponentLocationFunction(IntPtr sceneComponent, ref Vector3 value);
		internal delegate void GetComponentRotationFunction(IntPtr sceneComponent, ref Quaternion value);
		internal delegate void GetComponentScaleFunction(IntPtr sceneComponent, ref Vector3 value);
		internal delegate void GetComponentTransformFunction(IntPtr sceneComponent, ref Transform value);
		internal delegate void GetForwardVectorFunction(IntPtr sceneComponent, ref Vector3 value);
		internal delegate void GetRightVectorFunction(IntPtr sceneComponent, ref Vector3 value);
		internal delegate void GetUpVectorFunction(IntPtr sceneComponent, ref Vector3 value);
		internal delegate void SetMobilityFunction(IntPtr sceneComponent, ComponentMobility mobility);
		internal delegate void SetVisibilityFunction(IntPtr sceneComponent, Bool newVisibility, Bool propagateToChildren);
		internal delegate void SetRelativeLocationFunction(IntPtr sceneComponent, in Vector3 location);
		internal delegate void SetRelativeRotationFunction(IntPtr sceneComponent, in Quaternion rotation);
		internal delegate void SetRelativeTransformFunction(IntPtr sceneComponent, in Transform transform);
		internal delegate void SetWorldLocationFunction(IntPtr sceneComponent, in Vector3 location);
		internal delegate void SetWorldRotationFunction(IntPtr sceneComponent, in Quaternion rotation);
		internal delegate void SetWorldScaleFunction(IntPtr sceneComponent, in Vector3 scale);
		internal delegate void SetWorldTransformFunction(IntPtr sceneComponent, in Transform transform);

		internal static IsAttachedToComponentFunction isAttachedToComponent;
		internal static IsAttachedToActorFunction isAttachedToActor;
		internal static IsVisibleFunction isVisible;
		internal static IsSocketExistsFunction isSocketExists;
		internal static HasAnySocketsFunction hasAnySockets;
		internal static CreateFunction create;
		internal static AttachToComponentFunction attachToComponent;
		internal static DetachFromComponentFunction detachFromComponent;
		internal static ActivateFunction activate;
		internal static DeactivateFunction deactivate;
		internal static UpdateToWorldFunction updateToWorld;
		internal static AddLocalOffsetFunction addLocalOffset;
		internal static AddLocalRotationFunction addLocalRotation;
		internal static AddRelativeLocationFunction addRelativeLocation;
		internal static AddRelativeRotationFunction addRelativeRotation;
		internal static AddLocalTransformFunction addLocalTransform;
		internal static AddWorldOffsetFunction addWorldOffset;
		internal static AddWorldRotationFunction addWorldRotation;
		internal static AddWorldTransformFunction addWorldTransform;
		internal static GetAttachedSocketNameFunction getAttachedSocketName;
		internal static GetSocketLocationFunction getSocketLocation;
		internal static GetSocketRotationFunction getSocketRotation;
		internal static GetComponentVelocityFunction getComponentVelocity;
		internal static GetComponentLocationFunction getComponentLocation;
		internal static GetComponentRotationFunction getComponentRotation;
		internal static GetComponentScaleFunction getComponentScale;
		internal static GetComponentTransformFunction getComponentTransform;
		internal static GetForwardVectorFunction getForwardVector;
		internal static GetRightVectorFunction getRightVector;
		internal static GetUpVectorFunction getUpVector;
		internal static SetMobilityFunction setMobility;
		internal static SetVisibilityFunction setVisibility;
		internal static SetRelativeLocationFunction setRelativeLocation;
		internal static SetRelativeRotationFunction setRelativeRotation;
		internal static SetRelativeTransformFunction setRelativeTransform;
		internal static SetWorldLocationFunction setWorldLocation;
		internal static SetWorldRotationFunction setWorldRotation;
		internal static SetWorldScaleFunction setWorldScale;
		internal static SetWorldTransformFunction setWorldTransform;
	}

	partial class AudioComponent {
		internal delegate Bool IsPlayingFunction(IntPtr audioComponent);
		internal delegate Bool GetPausedFunction(IntPtr audioComponent);
		internal delegate void SetSoundFunction(IntPtr audioComponent, IntPtr sound);
		internal delegate void SetPausedFunction(IntPtr audioComponent, Bool value);
		internal delegate void PlayFunction(IntPtr audioComponent);
		internal delegate void StopFunction(IntPtr audioComponent);
		internal delegate void FadeInFunction(IntPtr audioComponent, float duration, float volumeLevel, float startTime, AudioFadeCurve fadeCurve);
		internal delegate void FadeOutFunction(IntPtr audioComponent, float duration, float volumeLevel, AudioFadeCurve fadeCurve);

		internal static IsPlayingFunction isPlaying;
		internal static GetPausedFunction getPaused;
		internal static SetSoundFunction setSound;
		internal static SetPausedFunction setPaused;
		internal static PlayFunction play;
		internal static StopFunction stop;
		internal static FadeInFunction fadeIn;
		internal static FadeOutFunction fadeOut;
	}

	partial class CameraComponent {
		internal delegate Bool GetConstrainAspectRatioFunction(IntPtr cameraComponent);
		internal delegate float GetAspectRatioFunction(IntPtr cameraComponent);
		internal delegate float GetFieldOfViewFunction(IntPtr cameraComponent);
		internal delegate float GetOrthoFarClipPlaneFunction(IntPtr cameraComponent);
		internal delegate float GetOrthoNearClipPlaneFunction(IntPtr cameraComponent);
		internal delegate float GetOrthoWidthFunction(IntPtr cameraComponent);
		internal delegate Bool GetLockToHeadMountedDisplayFunction(IntPtr cameraComponent);
		internal delegate void SetProjectionModeFunction(IntPtr cameraComponent, CameraProjectionMode mode);
		internal delegate void SetConstrainAspectRatioFunction(IntPtr cameraComponent, Bool value);
		internal delegate void SetAspectRatioFunction(IntPtr cameraComponent, float value);
		internal delegate void SetFieldOfViewFunction(IntPtr cameraComponent, float value);
		internal delegate void SetOrthoFarClipPlaneFunction(IntPtr cameraComponent, float value);
		internal delegate void SetOrthoNearClipPlaneFunction(IntPtr cameraComponent, float value);
		internal delegate void SetOrthoWidthFunction(IntPtr cameraComponent, float value);
		internal delegate void SetLockToHeadMountedDisplayFunction(IntPtr cameraComponent, Bool value);

		internal static GetConstrainAspectRatioFunction getConstrainAspectRatio;
		internal static GetAspectRatioFunction getAspectRatio;
		internal static GetFieldOfViewFunction getFieldOfView;
		internal static GetOrthoFarClipPlaneFunction getOrthoFarClipPlane;
		internal static GetOrthoNearClipPlaneFunction getOrthoNearClipPlane;
		internal static GetOrthoWidthFunction getOrthoWidth;
		internal static GetLockToHeadMountedDisplayFunction getLockToHeadMountedDisplay;
		internal static SetProjectionModeFunction setProjectionMode;
		internal static SetConstrainAspectRatioFunction setConstrainAspectRatio;
		internal static SetAspectRatioFunction setAspectRatio;
		internal static SetFieldOfViewFunction setFieldOfView;
		internal static SetOrthoFarClipPlaneFunction setOrthoFarClipPlane;
		internal static SetOrthoNearClipPlaneFunction setOrthoNearClipPlane;
		internal static SetOrthoWidthFunction setOrthoWidth;
		internal static SetLockToHeadMountedDisplayFunction setLockToHeadMountedDisplay;
	}

	partial class ChildActorComponent {
		internal delegate IntPtr SetChildActorFunction(IntPtr childActorComponent, ActorType type);

		internal static SetChildActorFunction setChildActor;
	}

	partial class SpringArmComponent {
		internal delegate Bool IsCollisionFixAppliedFunction(IntPtr springArmComponent);
		internal delegate Bool GetDrawDebugLagMarkersFunction(IntPtr springArmComponent);
		internal delegate Bool GetCollisionTestFunction(IntPtr springArmComponent);
		internal delegate Bool GetCameraPositionLagFunction(IntPtr springArmComponent);
		internal delegate Bool GetCameraRotationLagFunction(IntPtr springArmComponent);
		internal delegate Bool GetCameraLagSubsteppingFunction(IntPtr springArmComponent);
		internal delegate Bool GetInheritPitchFunction(IntPtr springArmComponent);
		internal delegate Bool GetInheritRollFunction(IntPtr springArmComponent);
		internal delegate Bool GetInheritYawFunction(IntPtr springArmComponent);
		internal delegate float GetCameraLagMaxDistanceFunction(IntPtr springArmComponent);
		internal delegate float GetCameraLagMaxTimeStepFunction(IntPtr springArmComponent);
		internal delegate float GetCameraPositionLagSpeedFunction(IntPtr springArmComponent);
		internal delegate float GetCameraRotationLagSpeedFunction(IntPtr springArmComponent);
		internal delegate CollisionChannel GetProbeChannelFunction(IntPtr springArmComponent);
		internal delegate float GetProbeSizeFunction(IntPtr springArmComponent);
		internal delegate void GetSocketOffsetFunction(IntPtr springArmComponent, ref Vector3 value);
		internal delegate float GetTargetArmLengthFunction(IntPtr springArmComponent);
		internal delegate void GetTargetOffsetFunction(IntPtr springArmComponent, ref Vector3 value);
		internal delegate void GetUnfixedCameraPositionFunction(IntPtr springArmComponent, ref Vector3 value);
		internal delegate void GetDesiredRotationFunction(IntPtr springArmComponent, ref Quaternion value);
		internal delegate void GetTargetRotationFunction(IntPtr springArmComponent, ref Quaternion value);
		internal delegate void SetDrawDebugLagMarkersFunction(IntPtr springArmComponent, Bool value);
		internal delegate void SetCollisionTestFunction(IntPtr springArmComponent, Bool value);
		internal delegate void SetCameraPositionLagFunction(IntPtr springArmComponent, Bool value);
		internal delegate void SetCameraRotationLagFunction(IntPtr springArmComponent, Bool value);
		internal delegate void SetCameraLagSubsteppingFunction(IntPtr springArmComponent, Bool value);
		internal delegate void SetInheritPitchFunction(IntPtr springArmComponent, Bool value);
		internal delegate void SetInheritRollFunction(IntPtr springArmComponent, Bool value);
		internal delegate void SetInheritYawFunction(IntPtr springArmComponent, Bool value);
		internal delegate void SetCameraLagMaxDistanceFunction(IntPtr springArmComponent, float value);
		internal delegate void SetCameraLagMaxTimeStepFunction(IntPtr springArmComponent, float value);
		internal delegate void SetCameraPositionLagSpeedFunction(IntPtr springArmComponent, float value);
		internal delegate void SetCameraRotationLagSpeedFunction(IntPtr springArmComponent, float value);
		internal delegate void SetProbeChannelFunction(IntPtr springArmComponent, CollisionChannel value);
		internal delegate void SetProbeSizeFunction(IntPtr springArmComponent, float value);
		internal delegate void SetSocketOffsetFunction(IntPtr springArmComponent, in Vector3 value);
		internal delegate void SetTargetArmLengthFunction(IntPtr springArmComponent, float value);
		internal delegate void SetTargetOffsetFunction(IntPtr springArmComponent, in Vector3 value);

		internal static IsCollisionFixAppliedFunction isCollisionFixApplied;
		internal static GetDrawDebugLagMarkersFunction getDrawDebugLagMarkers;
		internal static GetCollisionTestFunction getCollisionTest;
		internal static GetCameraPositionLagFunction getCameraPositionLag;
		internal static GetCameraRotationLagFunction getCameraRotationLag;
		internal static GetCameraLagSubsteppingFunction getCameraLagSubstepping;
		internal static GetInheritPitchFunction getInheritPitch;
		internal static GetInheritRollFunction getInheritRoll;
		internal static GetInheritYawFunction getInheritYaw;
		internal static GetCameraLagMaxDistanceFunction getCameraLagMaxDistance;
		internal static GetCameraLagMaxTimeStepFunction getCameraLagMaxTimeStep;
		internal static GetCameraPositionLagSpeedFunction getCameraPositionLagSpeed;
		internal static GetCameraRotationLagSpeedFunction getCameraRotationLagSpeed;
		internal static GetProbeChannelFunction getProbeChannel;
		internal static GetProbeSizeFunction getProbeSize;
		internal static GetSocketOffsetFunction getSocketOffset;
		internal static GetTargetArmLengthFunction getTargetArmLength;
		internal static GetTargetOffsetFunction getTargetOffset;
		internal static GetUnfixedCameraPositionFunction getUnfixedCameraPosition;
		internal static GetDesiredRotationFunction getDesiredRotation;
		internal static GetTargetRotationFunction getTargetRotation;
		internal static SetDrawDebugLagMarkersFunction setDrawDebugLagMarkers;
		internal static SetCollisionTestFunction setCollisionTest;
		internal static SetCameraPositionLagFunction setCameraPositionLag;
		internal static SetCameraRotationLagFunction setCameraRotationLag;
		internal static SetCameraLagSubsteppingFunction setCameraLagSubstepping;
		internal static SetInheritPitchFunction setInheritPitch;
		internal static SetInheritRollFunction setInheritRoll;
		internal static SetInheritYawFunction setInheritYaw;
		internal static SetCameraLagMaxDistanceFunction setCameraLagMaxDistance;
		internal static SetCameraLagMaxTimeStepFunction setCameraLagMaxTimeStep;
		internal static SetCameraPositionLagSpeedFunction setCameraPositionLagSpeed;
		internal static SetCameraRotationLagSpeedFunction setCameraRotationLagSpeed;
		internal static SetProbeChannelFunction setProbeChannel;
		internal static SetProbeSizeFunction setProbeSize;
		internal static SetSocketOffsetFunction setSocketOffset;
		internal static SetTargetArmLengthFunction setTargetArmLength;
		internal static SetTargetOffsetFunction setTargetOffset;
	}

	partial class PrimitiveComponent {
		internal delegate Bool IsGravityEnabledFunction(IntPtr primitiveComponent);
		internal delegate Bool IsOverlappingComponentFunction(IntPtr primitiveComponent, IntPtr other);
		internal delegate void AddAngularImpulseInDegreesFunction(IntPtr primitiveComponent, in Vector3 impulse, string boneName, Bool velocityChange);
		internal delegate void AddAngularImpulseInRadiansFunction(IntPtr primitiveComponent, in Vector3 impulse, string boneName, Bool velocityChange);
		internal delegate void AddForceFunction(IntPtr primitiveComponent, in Vector3 force, string boneName, Bool accelerationChange);
		internal delegate void AddForceAtLocationFunction(IntPtr primitiveComponent, in Vector3 force, in Vector3 location, string boneName, Bool localSpace);
		internal delegate void AddImpulseFunction(IntPtr primitiveComponent, in Vector3 impulse, string boneName, Bool velocityChange);
		internal delegate void AddImpulseAtLocationFunction(IntPtr primitiveComponent, in Vector3 impulse, in Vector3 location, string boneName);
		internal delegate void AddRadialForceFunction(IntPtr primitiveComponent, in Vector3 origin, float radius, float strength, Bool linearFalloff, Bool accelerationChange);
		internal delegate void AddRadialImpulseFunction(IntPtr primitiveComponent, in Vector3 origin, float radius, float strength, Bool linearFalloff, Bool accelerationChange);
		internal delegate void AddTorqueInDegreesFunction(IntPtr primitiveComponent, in Vector3 torque, string boneName, Bool accelerationChange);
		internal delegate void AddTorqueInRadiansFunction(IntPtr primitiveComponent, in Vector3 torque, string boneName, Bool accelerationChange);
		internal delegate float GetMassFunction(IntPtr primitiveComponent);
		internal delegate void GetPhysicsLinearVelocityFunction(IntPtr primitiveComponent, ref Vector3 value, string boneName);
		internal delegate void GetPhysicsLinearVelocityAtPointFunction(IntPtr primitiveComponent, ref Vector3 value, in Vector3 point, string boneName);
		internal delegate void GetPhysicsAngularVelocityInDegreesFunction(IntPtr primitiveComponent, ref Vector3 value, string boneName);
		internal delegate void GetPhysicsAngularVelocityInRadiansFunction(IntPtr primitiveComponent, ref Vector3 value, string boneName);
		internal delegate Bool GetCastShadowFunction(IntPtr primitiveComponent);
		internal delegate Bool GetOnlyOwnerSeeFunction(IntPtr primitiveComponent);
		internal delegate Bool GetOwnerNoSeeFunction(IntPtr primitiveComponent);
		internal delegate Bool GetIgnoreRadialForceFunction(IntPtr primitiveComponent);
		internal delegate Bool GetIgnoreRadialImpulseFunction(IntPtr primitiveComponent);
		internal delegate IntPtr GetMaterialFunction(IntPtr primitiveComponent, int elementIndex);
		internal delegate int GetMaterialsNumberFunction(IntPtr primitiveComponent);
		internal delegate float GetDistanceToCollisionFunction(IntPtr primitiveComponent, in Vector3 point, ref Vector3 closestPointOnCollision);
		internal delegate Bool GetSquaredDistanceToCollisionFunction(IntPtr primitiveComponent, in Vector3 point, ref float squaredDistance, ref Vector3 closestPointOnCollision);
		internal delegate float GetAngularDampingFunction(IntPtr primitiveComponent);
		internal delegate float GetLinearDampingFunction(IntPtr primitiveComponent);
		internal delegate void SetGenerateOverlapEventsFunction(IntPtr primitiveComponent, Bool value);
		internal delegate void SetGenerateHitEventsFunction(IntPtr primitiveComponent, Bool value);
		internal delegate void SetMassFunction(IntPtr primitiveComponent, float mass, string boneName);
		internal delegate void SetCenterOfMassFunction(IntPtr primitiveComponent, in Vector3 offset, string boneName);
		internal delegate void SetPhysicsLinearVelocityFunction(IntPtr primitiveComponent, in Vector3 velocity, Bool addToCurrent, string boneName);
		internal delegate void SetPhysicsAngularVelocityInDegreesFunction(IntPtr primitiveComponent, in Vector3 angularVelocity, Bool addToCurrent, string boneName);
		internal delegate void SetPhysicsAngularVelocityInRadiansFunction(IntPtr primitiveComponent, in Vector3 angularVelocity, Bool addToCurrent, string boneName);
		internal delegate void SetPhysicsMaxAngularVelocityInDegreesFunction(IntPtr primitiveComponent, float maxAngularVelocity, Bool addToCurrent, string boneName);
		internal delegate void SetPhysicsMaxAngularVelocityInRadiansFunction(IntPtr primitiveComponent, float maxAngularVelocity, Bool addToCurrent, string boneName);
		internal delegate void SetCastShadowFunction(IntPtr primitiveComponent, Bool value);
		internal delegate void SetOnlyOwnerSeeFunction(IntPtr primitiveComponent, Bool value);
		internal delegate void SetOwnerNoSeeFunction(IntPtr primitiveComponent, Bool value);
		internal delegate void SetIgnoreRadialForceFunction(IntPtr primitiveComponent, Bool value);
		internal delegate void SetIgnoreRadialImpulseFunction(IntPtr primitiveComponent, Bool value);
		internal delegate void SetMaterialFunction(IntPtr primitiveComponent, int elementIndex, IntPtr material);
		internal delegate void SetSimulatePhysicsFunction(IntPtr primitiveComponent, Bool value);
		internal delegate void SetAngularDampingFunction(IntPtr primitiveComponent, float value);
		internal delegate void SetLinearDampingFunction(IntPtr primitiveComponent, float value);
		internal delegate void SetEnableGravityFunction(IntPtr primitiveComponent, Bool value);
		internal delegate void SetCollisionModeFunction(IntPtr primitiveComponent, CollisionMode mode);
		internal delegate void SetCollisionChannelFunction(IntPtr primitiveComponent, CollisionChannel channel);
		internal delegate void SetCollisionProfileNameFunction(IntPtr primitiveComponent, string profileName, Bool updateOverlaps);
		internal delegate void SetCollisionResponseToChannelFunction(IntPtr primitiveComponent, CollisionChannel channel, CollisionResponse response);
		internal delegate void SetCollisionResponseToAllChannelsFunction(IntPtr primitiveComponent, CollisionResponse response);
		internal delegate void SetIgnoreActorWhenMovingFunction(IntPtr primitiveComponent, IntPtr actor, Bool value);
		internal delegate void SetIgnoreComponentWhenMovingFunction(IntPtr primitiveComponent, IntPtr component, Bool value);
		internal delegate void ClearMoveIgnoreActorsFunction(IntPtr primitiveComponent);
		internal delegate void ClearMoveIgnoreComponentsFunction(IntPtr primitiveComponent);
		internal delegate IntPtr CreateAndSetMaterialInstanceDynamicFunction(IntPtr primitiveComponent, int elementIndex);
		internal delegate void RegisterEventFunction(IntPtr primitiveComponent, ComponentEventType type);
		internal delegate void UnregisterEventFunction(IntPtr primitiveComponent, ComponentEventType type);

		internal static IsGravityEnabledFunction isGravityEnabled;
		internal static IsOverlappingComponentFunction isOverlappingComponent;
		internal static AddAngularImpulseInDegreesFunction addAngularImpulseInDegrees;
		internal static AddAngularImpulseInRadiansFunction addAngularImpulseInRadians;
		internal static AddForceFunction addForce;
		internal static AddForceAtLocationFunction addForceAtLocation;
		internal static AddImpulseFunction addImpulse;
		internal static AddImpulseAtLocationFunction addImpulseAtLocation;
		internal static AddRadialForceFunction addRadialForce;
		internal static AddRadialImpulseFunction addRadialImpulse;
		internal static AddTorqueInDegreesFunction addTorqueInDegrees;
		internal static AddTorqueInRadiansFunction addTorqueInRadians;
		internal static GetMassFunction getMass;
		internal static GetPhysicsLinearVelocityFunction getPhysicsLinearVelocity;
		internal static GetPhysicsLinearVelocityAtPointFunction getPhysicsLinearVelocityAtPoint;
		internal static GetPhysicsAngularVelocityInDegreesFunction getPhysicsAngularVelocityInDegrees;
		internal static GetPhysicsAngularVelocityInRadiansFunction getPhysicsAngularVelocityInRadians;
		internal static GetCastShadowFunction getCastShadow;
		internal static GetOnlyOwnerSeeFunction getOnlyOwnerSee;
		internal static GetOwnerNoSeeFunction getOwnerNoSee;
		internal static GetIgnoreRadialForceFunction getIgnoreRadialForce;
		internal static GetIgnoreRadialImpulseFunction getIgnoreRadialImpulse;
		internal static GetMaterialFunction getMaterial;
		internal static GetMaterialsNumberFunction getMaterialsNumber;
		internal static GetDistanceToCollisionFunction getDistanceToCollision;
		internal static GetSquaredDistanceToCollisionFunction getSquaredDistanceToCollision;
		internal static GetAngularDampingFunction getAngularDamping;
		internal static GetLinearDampingFunction getLinearDamping;
		internal static SetGenerateOverlapEventsFunction setGenerateOverlapEvents;
		internal static SetGenerateHitEventsFunction setGenerateHitEvents;
		internal static SetMassFunction setMass;
		internal static SetCenterOfMassFunction setCenterOfMass;
		internal static SetPhysicsLinearVelocityFunction setPhysicsLinearVelocity;
		internal static SetPhysicsAngularVelocityInDegreesFunction setPhysicsAngularVelocityInDegrees;
		internal static SetPhysicsAngularVelocityInRadiansFunction setPhysicsAngularVelocityInRadians;
		internal static SetPhysicsMaxAngularVelocityInDegreesFunction setPhysicsMaxAngularVelocityInDegrees;
		internal static SetPhysicsMaxAngularVelocityInRadiansFunction setPhysicsMaxAngularVelocityInRadians;
		internal static SetCastShadowFunction setCastShadow;
		internal static SetOnlyOwnerSeeFunction setOnlyOwnerSee;
		internal static SetOwnerNoSeeFunction setOwnerNoSee;
		internal static SetIgnoreRadialForceFunction setIgnoreRadialForce;
		internal static SetIgnoreRadialImpulseFunction setIgnoreRadialImpulse;
		internal static SetMaterialFunction setMaterial;
		internal static SetSimulatePhysicsFunction setSimulatePhysics;
		internal static SetAngularDampingFunction setAngularDamping;
		internal static SetLinearDampingFunction setLinearDamping;
		internal static SetEnableGravityFunction setEnableGravity;
		internal static SetCollisionModeFunction setCollisionMode;
		internal static SetCollisionChannelFunction setCollisionChannel;
		internal static SetCollisionProfileNameFunction setCollisionProfileName;
		internal static SetCollisionResponseToChannelFunction setCollisionResponseToChannel;
		internal static SetCollisionResponseToAllChannelsFunction setCollisionResponseToAllChannels;
		internal static SetIgnoreActorWhenMovingFunction setIgnoreActorWhenMoving;
		internal static SetIgnoreComponentWhenMovingFunction setIgnoreComponentWhenMoving;
		internal static ClearMoveIgnoreActorsFunction clearMoveIgnoreActors;
		internal static ClearMoveIgnoreComponentsFunction clearMoveIgnoreComponents;
		internal static CreateAndSetMaterialInstanceDynamicFunction createAndSetMaterialInstanceDynamic;
		internal static RegisterEventFunction registerEvent;
		internal static UnregisterEventFunction unregisterEvent;
	}

	partial class ShapeComponent {
		internal delegate Bool GetDynamicObstacleFunction(IntPtr shapeComponent);
		internal delegate int GetShapeColorFunction(IntPtr shapeComponent);
		internal delegate void SetDynamicObstacleFunction(IntPtr shapeComponent, Bool value);
		internal delegate void SetShapeColorFunction(IntPtr shapeComponent, int value);

		internal static GetDynamicObstacleFunction getDynamicObstacle;
		internal static GetShapeColorFunction getShapeColor;
		internal static SetDynamicObstacleFunction setDynamicObstacle;
		internal static SetShapeColorFunction setShapeColor;
	}

	partial class BoxComponent {
		internal delegate void GetScaledBoxExtentFunction(IntPtr boxComponent, ref Vector3 value);
		internal delegate void GetUnscaledBoxExtentFunction(IntPtr boxComponent, ref Vector3 value);
		internal delegate void SetBoxExtentFunction(IntPtr boxComponent, in Vector3 extent, Bool updateOverlaps);
		internal delegate void InitBoxExtentFunction(IntPtr boxComponent, in Vector3 extent);

		internal static GetScaledBoxExtentFunction getScaledBoxExtent;
		internal static GetUnscaledBoxExtentFunction getUnscaledBoxExtent;
		internal static SetBoxExtentFunction setBoxExtent;
		internal static InitBoxExtentFunction initBoxExtent;
	}

	partial class SphereComponent {
		internal delegate float GetScaledSphereRadiusFunction(IntPtr sphereComponent);
		internal delegate float GetUnscaledSphereRadiusFunction(IntPtr sphereComponent);
		internal delegate float GetShapeScaleFunction(IntPtr sphereComponent);
		internal delegate void SetSphereRadiusFunction(IntPtr sphereComponent, float sphereRadius, Bool updateOverlaps);
		internal delegate void InitSphereRadiusFunction(IntPtr sphereComponent, float sphereRadius);

		internal static GetScaledSphereRadiusFunction getScaledSphereRadius;
		internal static GetUnscaledSphereRadiusFunction getUnscaledSphereRadius;
		internal static GetShapeScaleFunction getShapeScale;
		internal static SetSphereRadiusFunction setSphereRadius;
		internal static InitSphereRadiusFunction initSphereRadius;
	}

	partial class CapsuleComponent {
		internal delegate float GetScaledCapsuleRadiusFunction(IntPtr capsuleComponent);
		internal delegate float GetUnscaledCapsuleRadiusFunction(IntPtr capsuleComponent);
		internal delegate float GetShapeScaleFunction(IntPtr capsuleComponent);
		internal delegate void GetScaledCapsuleSizeFunction(IntPtr capsuleComponent, ref float radius, ref float halfHeight);
		internal delegate void GetUnscaledCapsuleSizeFunction(IntPtr capsuleComponent, ref float radius, ref float halfHeight);
		internal delegate void SetCapsuleRadiusFunction(IntPtr capsuleComponent, float radius, Bool updateOverlaps);
		internal delegate void SetCapsuleSizeFunction(IntPtr capsuleComponent, float radius, float halfHeight, Bool updateOverlaps);
		internal delegate void InitCapsuleSizeFunction(IntPtr capsuleComponent, float radius, float halfHeight);

		internal static GetScaledCapsuleRadiusFunction getScaledCapsuleRadius;
		internal static GetUnscaledCapsuleRadiusFunction getUnscaledCapsuleRadius;
		internal static GetShapeScaleFunction getShapeScale;
		internal static GetScaledCapsuleSizeFunction getScaledCapsuleSize;
		internal static GetUnscaledCapsuleSizeFunction getUnscaledCapsuleSize;
		internal static SetCapsuleRadiusFunction setCapsuleRadius;
		internal static SetCapsuleSizeFunction setCapsuleSize;
		internal static InitCapsuleSizeFunction initCapsuleSize;
	}

	partial class MeshComponent {
		internal delegate Bool IsValidMaterialSlotNameFunction(IntPtr meshComponent, string materialSlotName);
		internal delegate int GetMaterialIndexFunction(IntPtr meshComponent, string materialSlotName);

		internal static IsValidMaterialSlotNameFunction isValidMaterialSlotName;
		internal static GetMaterialIndexFunction getMaterialIndex;
	}

	partial class LightComponentBase {
		internal delegate float GetIntensityFunction(IntPtr lightComponentBase);
		internal delegate Bool GetCastShadowsFunction(IntPtr lightComponentBase);
		internal delegate void SetCastShadowsFunction(IntPtr lightComponentBase, Bool value);

		internal static GetIntensityFunction getIntensity;
		internal static GetCastShadowsFunction getCastShadows;
		internal static SetCastShadowsFunction setCastShadows;
	}

	partial class LightComponent {
		internal delegate void SetIntensityFunction(IntPtr lightComponent, float value);
		internal delegate void SetLightColorFunction(IntPtr lightComponent, in LinearColor value);

		internal static SetIntensityFunction setIntensity;
		internal static SetLightColorFunction setLightColor;
	}

	partial class DirectionalLightComponent { }

	partial class MotionControllerComponent {
		internal delegate Bool IsTrackedFunction(IntPtr motionControllerComponent);
		internal delegate Bool GetDisableLowLatencyUpdateFunction(IntPtr motionControllerComponent);
		internal delegate ControllerHand GetTrackingSourceFunction(IntPtr motionControllerComponent);
		internal delegate void SetDisableLowLatencyUpdateFunction(IntPtr motionControllerComponent, Bool value);
		internal delegate void SetTrackingSourceFunction(IntPtr motionControllerComponent, ControllerHand value);
		internal delegate void SetTrackingMotionSourceFunction(IntPtr motionControllerComponent, string source);

		internal static IsTrackedFunction isTracked;
		internal static GetDisableLowLatencyUpdateFunction getDisableLowLatencyUpdate;
		internal static GetTrackingSourceFunction getTrackingSource;
		internal static SetDisableLowLatencyUpdateFunction setDisableLowLatencyUpdate;
		internal static SetTrackingSourceFunction setTrackingSource;
		internal static SetTrackingMotionSourceFunction setTrackingMotionSource;
	}

	partial class StaticMeshComponent {
		internal delegate void GetLocalBoundsFunction(IntPtr staticMeshComponent, ref Vector3 min, ref Vector3 max);
		internal delegate IntPtr GetStaticMeshFunction(IntPtr staticMeshComponent);
		internal delegate Bool SetStaticMeshFunction(IntPtr staticMeshComponent, IntPtr staticMesh);

		internal static GetLocalBoundsFunction getLocalBounds;
		internal static GetStaticMeshFunction getStaticMesh;
		internal static SetStaticMeshFunction setStaticMesh;
	}

	partial class InstancedStaticMeshComponent {
		internal delegate int GetInstanceCountFunction(IntPtr instancedStaticMeshComponent);
		internal delegate Bool GetInstanceTransformFunction(IntPtr instancedStaticMeshComponent, int instanceIndex, ref Transform value, Bool worldSpace);
		internal delegate int AddInstanceFunction(IntPtr instancedStaticMeshComponent, in Transform instanceTransform);
		internal delegate Bool UpdateInstanceTransformFunction(IntPtr instancedStaticMeshComponent, int instanceIndex, in Transform instanceTransform, Bool worldSpace, Bool markRenderStateDirty, Bool teleport);
		internal delegate Bool RemoveInstanceFunction(IntPtr instancedStaticMeshComponent, int instanceIndex);
		internal delegate void ClearInstancesFunction(IntPtr instancedStaticMeshComponent);

		internal static GetInstanceCountFunction getInstanceCount;
		internal static GetInstanceTransformFunction getInstanceTransform;
		internal static AddInstanceFunction addInstance;
		internal static UpdateInstanceTransformFunction updateInstanceTransform;
		internal static RemoveInstanceFunction removeInstance;
		internal static ClearInstancesFunction clearInstances;
	}

	partial class SkinnedMeshComponent {
		internal delegate int GetBonesNumberFunction(IntPtr skinnedMeshComponent);
		internal delegate int GetBoneIndexFunction(IntPtr skinnedMeshComponent, string boneName);
		internal delegate void GetBoneNameFunction(IntPtr skinnedMeshComponent, int boneIndex, byte[] boneName);
		internal delegate void GetBoneTransformFunction(IntPtr skinnedMeshComponent, int boneIndex, ref Transform value);
		internal delegate void SetSkeletalMeshFunction(IntPtr skinnedMeshComponent, IntPtr skeletalMesh, Bool reinitializePose);

		internal static GetBonesNumberFunction getBonesNumber;
		internal static GetBoneIndexFunction getBoneIndex;
		internal static GetBoneNameFunction getBoneName;
		internal static GetBoneTransformFunction getBoneTransform;
		internal static SetSkeletalMeshFunction setSkeletalMesh;
	}

	partial class SkeletalMeshComponent {
		internal delegate Bool IsPlayingFunction(IntPtr skeletalMeshComponent);
		internal delegate IntPtr GetAnimationInstanceFunction(IntPtr skeletalMeshComponent);
		internal delegate void SetAnimationFunction(IntPtr skeletalMeshComponent, IntPtr asset);
		internal delegate void SetAnimationModeFunction(IntPtr skeletalMeshComponent, AnimationMode mode);
		internal delegate void SetAnimationBlueprintFunction(IntPtr skeletalMeshComponent, IntPtr blueprint);
		internal delegate void PlayFunction(IntPtr skeletalMeshComponent, Bool loop);
		internal delegate void PlayAnimationFunction(IntPtr skeletalMeshComponent, IntPtr asset, Bool loop);
		internal delegate void StopFunction(IntPtr skeletalMeshComponent);

		internal static IsPlayingFunction isPlaying;
		internal static GetAnimationInstanceFunction getAnimationInstance;
		internal static SetAnimationFunction setAnimation;
		internal static SetAnimationModeFunction setAnimationMode;
		internal static SetAnimationBlueprintFunction setAnimationBlueprint;
		internal static PlayFunction play;
		internal static PlayAnimationFunction playAnimation;
		internal static StopFunction stop;
	}

	partial class SplineComponent {
		internal delegate Bool IsClosedLoopFunction(IntPtr splineComponent);
		internal delegate float GetDurationFunction(IntPtr splineComponent);
		internal delegate SplinePointType GetSplinePointTypeFunction(IntPtr splineComponent, int pointIndex);
		internal delegate int GetSplinePointsNumberFunction(IntPtr splineComponent);
		internal delegate int GetSplineSegmentsNumberFunction(IntPtr splineComponent);
		internal delegate void GetTangentAtDistanceAlongSplineFunction(IntPtr splineComponent, float distance, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetTangentAtSplinePointFunction(IntPtr splineComponent, int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetTangentAtTimeFunction(IntPtr splineComponent, float time, SplineCoordinateSpace coordinateSpace, Bool useConstantVelocity, ref Vector3 value);
		internal delegate void GetTransformAtDistanceAlongSplineFunction(IntPtr splineComponent, float distance, SplineCoordinateSpace coordinateSpace, ref Transform value);
		internal delegate void GetTransformAtSplinePointFunction(IntPtr splineComponent, int pointIndex, SplineCoordinateSpace coordinateSpace, Bool useScale, ref Transform value);
		internal delegate void GetArriveTangentAtSplinePointFunction(IntPtr splineComponent, int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetDefaultUpVectorFunction(IntPtr splineComponent, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetDirectionAtDistanceAlongSplineFunction(IntPtr splineComponent, float distance, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetDirectionAtSplinePointFunction(IntPtr splineComponent, int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetDirectionAtTimeFunction(IntPtr splineComponent, float time, SplineCoordinateSpace coordinateSpace, Bool useConstantVelocity, ref Vector3 value);
		internal delegate float GetDistanceAlongSplineAtSplinePointFunction(IntPtr splineComponent, int pointIndex);
		internal delegate void GetLeaveTangentAtSplinePointFunction(IntPtr splineComponent, int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetLocationAndTangentAtSplinePointFunction(IntPtr splineComponent, int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 location, ref Vector3 tangent);
		internal delegate void GetLocationAtDistanceAlongSplineFunction(IntPtr splineComponent, float distance, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetLocationAtSplinePointFunction(IntPtr splineComponent, int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetLocationAtTimeFunction(IntPtr splineComponent, float time, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetRightVectorAtDistanceAlongSplineFunction(IntPtr splineComponent, float distance, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetRightVectorAtSplinePointFunction(IntPtr splineComponent, int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetRightVectorAtTimeFunction(IntPtr splineComponent, float time, SplineCoordinateSpace coordinateSpace, Bool useConstantVelocity, ref Vector3 value);
		internal delegate float GetRollAtDistanceAlongSplineFunction(IntPtr splineComponent, float distance, SplineCoordinateSpace coordinateSpace);
		internal delegate float GetRollAtSplinePointFunction(IntPtr splineComponent, int pointIndex, SplineCoordinateSpace coordinateSpace);
		internal delegate float GetRollAtTimeFunction(IntPtr splineComponent, float time, SplineCoordinateSpace coordinateSpace, Bool useConstantVelocity);
		internal delegate void GetRotationAtDistanceAlongSplineFunction(IntPtr splineComponent, float distance, SplineCoordinateSpace coordinateSpace, ref Quaternion value);
		internal delegate void GetRotationAtSplinePointFunction(IntPtr splineComponent, int pointIndex, SplineCoordinateSpace coordinateSpace, ref Quaternion value);
		internal delegate void GetRotationAtTimeFunction(IntPtr splineComponent, float time, SplineCoordinateSpace coordinateSpace, Bool useConstantVelocity, ref Quaternion value);
		internal delegate void GetScaleAtDistanceAlongSplineFunction(IntPtr splineComponent, float distance, ref Vector3 value);
		internal delegate void GetScaleAtSplinePointFunction(IntPtr splineComponent, int pointIndex, ref Vector3 value);
		internal delegate void GetScaleAtTimeFunction(IntPtr splineComponent, float time, Bool useConstantVelocity, ref Vector3 value);
		internal delegate float GetSplineLengthFunction(IntPtr splineComponent);
		internal delegate void GetTransformAtTimeFunction(IntPtr splineComponent, float time, SplineCoordinateSpace coordinateSpace, Bool useConstantVelocity, Bool useScale, ref Transform value);
		internal delegate void GetUpVectorAtDistanceAlongSplineFunction(IntPtr splineComponent, float distance, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetUpVectorAtSplinePointFunction(IntPtr splineComponent, int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void GetUpVectorAtTimeFunction(IntPtr splineComponent, float time, SplineCoordinateSpace coordinateSpace, Bool useConstantVelocity, ref Vector3 value);
		internal delegate void SetDurationFunction(IntPtr splineComponent, float value);
		internal delegate void SetSplinePointTypeFunction(IntPtr splineComponent, int pointIndex, SplinePointType type, Bool updateSpline);
		internal delegate void SetClosedLoopFunction(IntPtr splineComponent, Bool value, Bool updateSpline);
		internal delegate void SetDefaultUpVectorFunction(IntPtr splineComponent, in Vector3 value, SplineCoordinateSpace coordinateSpace);
		internal delegate void SetLocationAtSplinePointFunction(IntPtr splineComponent, int pointIndex, in Vector3 value, SplineCoordinateSpace coordinateSpace, Bool updateSpline);
		internal delegate void SetTangentAtSplinePointFunction(IntPtr splineComponent, int pointIndex, in Vector3 tangent, SplineCoordinateSpace coordinateSpace, Bool updateSpline);
		internal delegate void SetTangentsAtSplinePointFunction(IntPtr splineComponent, int pointIndex, in Vector3 arriveTangent, in Vector3 leaveTangent, SplineCoordinateSpace coordinateSpace, Bool updateSpline);
		internal delegate void SetUpVectorAtSplinePointFunction(IntPtr splineComponent, int pointIndex, in Vector3 upVector, SplineCoordinateSpace coordinateSpace, Bool updateSpline);
		internal delegate void AddSplinePointFunction(IntPtr splineComponent, in Vector3 location, SplineCoordinateSpace coordinateSpace, Bool updateSpline);
		internal delegate void AddSplinePointAtIndexFunction(IntPtr splineComponent, in Vector3 location, int pointIndex, SplineCoordinateSpace coordinateSpace, Bool updateSpline);
		internal delegate void ClearSplinePointsFunction(IntPtr splineComponent, Bool updateSpline);
		internal delegate void FindDirectionClosestToWorldLocationFunction(IntPtr splineComponent, in Vector3 location, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void FindLocationClosestToWorldLocationFunction(IntPtr splineComponent, in Vector3 location, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void FindUpVectorClosestToWorldLocationFunction(IntPtr splineComponent, in Vector3 location, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void FindRightVectorClosestToWorldLocationFunction(IntPtr splineComponent, in Vector3 location, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate float FindRollClosestToWorldLocationFunction(IntPtr splineComponent, in Vector3 location, SplineCoordinateSpace coordinateSpace);
		internal delegate void FindScaleClosestToWorldLocationFunction(IntPtr splineComponent, in Vector3 location, ref Vector3 value);
		internal delegate void FindTangentClosestToWorldLocationFunction(IntPtr splineComponent, in Vector3 location, SplineCoordinateSpace coordinateSpace, ref Vector3 value);
		internal delegate void FindTransformClosestToWorldLocationFunction(IntPtr splineComponent, in Vector3 location, SplineCoordinateSpace coordinateSpace, Bool useScale, ref Transform value);
		internal delegate void RemoveSplinePointFunction(IntPtr splineComponent, int pointIndex, Bool updateSpline);
		internal delegate void UpdateSplineFunction(IntPtr splineComponent);

		internal static IsClosedLoopFunction isClosedLoop;
		internal static GetDurationFunction getDuration;
		internal static GetSplinePointTypeFunction getSplinePointType;
		internal static GetSplinePointsNumberFunction getSplinePointsNumber;
		internal static GetSplineSegmentsNumberFunction getSplineSegmentsNumber;
		internal static GetTangentAtDistanceAlongSplineFunction getTangentAtDistanceAlongSpline;
		internal static GetTangentAtSplinePointFunction getTangentAtSplinePoint;
		internal static GetTangentAtTimeFunction getTangentAtTime;
		internal static GetTransformAtDistanceAlongSplineFunction getTransformAtDistanceAlongSpline;
		internal static GetTransformAtSplinePointFunction getTransformAtSplinePoint;
		internal static GetArriveTangentAtSplinePointFunction getArriveTangentAtSplinePoint;
		internal static GetDefaultUpVectorFunction getDefaultUpVector;
		internal static GetDirectionAtDistanceAlongSplineFunction getDirectionAtDistanceAlongSpline;
		internal static GetDirectionAtSplinePointFunction getDirectionAtSplinePoint;
		internal static GetDirectionAtTimeFunction getDirectionAtTime;
		internal static GetDistanceAlongSplineAtSplinePointFunction getDistanceAlongSplineAtSplinePoint;
		internal static GetLeaveTangentAtSplinePointFunction getLeaveTangentAtSplinePoint;
		internal static GetLocationAndTangentAtSplinePointFunction getLocationAndTangentAtSplinePoint;
		internal static GetLocationAtDistanceAlongSplineFunction getLocationAtDistanceAlongSpline;
		internal static GetLocationAtSplinePointFunction getLocationAtSplinePoint;
		internal static GetLocationAtTimeFunction getLocationAtTime;
		internal static GetRightVectorAtDistanceAlongSplineFunction getRightVectorAtDistanceAlongSpline;
		internal static GetRightVectorAtSplinePointFunction getRightVectorAtSplinePoint;
		internal static GetRightVectorAtTimeFunction getRightVectorAtTime;
		internal static GetRollAtDistanceAlongSplineFunction getRollAtDistanceAlongSpline;
		internal static GetRollAtSplinePointFunction getRollAtSplinePoint;
		internal static GetRollAtTimeFunction getRollAtTime;
		internal static GetRotationAtDistanceAlongSplineFunction getRotationAtDistanceAlongSpline;
		internal static GetRotationAtSplinePointFunction getRotationAtSplinePoint;
		internal static GetRotationAtTimeFunction getRotationAtTime;
		internal static GetScaleAtDistanceAlongSplineFunction getScaleAtDistanceAlongSpline;
		internal static GetScaleAtSplinePointFunction getScaleAtSplinePoint;
		internal static GetScaleAtTimeFunction getScaleAtTime;
		internal static GetSplineLengthFunction getSplineLength;
		internal static GetTransformAtTimeFunction getTransformAtTime;
		internal static GetUpVectorAtDistanceAlongSplineFunction getUpVectorAtDistanceAlongSpline;
		internal static GetUpVectorAtSplinePointFunction getUpVectorAtSplinePoint;
		internal static GetUpVectorAtTimeFunction getUpVectorAtTime;
		internal static SetDurationFunction setDuration;
		internal static SetSplinePointTypeFunction setSplinePointType;
		internal static SetClosedLoopFunction setClosedLoop;
		internal static SetDefaultUpVectorFunction setDefaultUpVector;
		internal static SetLocationAtSplinePointFunction setLocationAtSplinePoint;
		internal static SetTangentAtSplinePointFunction setTangentAtSplinePoint;
		internal static SetTangentsAtSplinePointFunction setTangentsAtSplinePoint;
		internal static SetUpVectorAtSplinePointFunction setUpVectorAtSplinePoint;
		internal static AddSplinePointFunction addSplinePoint;
		internal static AddSplinePointAtIndexFunction addSplinePointAtIndex;
		internal static ClearSplinePointsFunction clearSplinePoints;
		internal static FindDirectionClosestToWorldLocationFunction findDirectionClosestToWorldLocation;
		internal static FindLocationClosestToWorldLocationFunction findLocationClosestToWorldLocation;
		internal static FindUpVectorClosestToWorldLocationFunction findUpVectorClosestToWorldLocation;
		internal static FindRightVectorClosestToWorldLocationFunction findRightVectorClosestToWorldLocation;
		internal static FindRollClosestToWorldLocationFunction findRollClosestToWorldLocation;
		internal static FindScaleClosestToWorldLocationFunction findScaleClosestToWorldLocation;
		internal static FindTangentClosestToWorldLocationFunction findTangentClosestToWorldLocation;
		internal static FindTransformClosestToWorldLocationFunction findTransformClosestToWorldLocation;
		internal static RemoveSplinePointFunction removeSplinePoint;
		internal static UpdateSplineFunction updateSpline;
	}

	partial class RadialForceComponent {
		internal delegate Bool GetIgnoreOwningActorFunction(IntPtr radialForceComponent);
		internal delegate Bool GetImpulseVelocityChangeFunction(IntPtr radialForceComponent);
		internal delegate Bool GetLinearFalloffFunction(IntPtr radialForceComponent);
		internal delegate float GetForceStrengthFunction(IntPtr radialForceComponent);
		internal delegate float GetImpulseStrengthFunction(IntPtr radialForceComponent);
		internal delegate float GetRadiusFunction(IntPtr radialForceComponent);
		internal delegate void SetIgnoreOwningActorFunction(IntPtr radialForceComponent, Bool value);
		internal delegate void SetImpulseVelocityChangeFunction(IntPtr radialForceComponent, Bool value);
		internal delegate void SetLinearFalloffFunction(IntPtr radialForceComponent, Bool value);
		internal delegate void SetForceStrengthFunction(IntPtr radialForceComponent, float value);
		internal delegate void SetImpulseStrengthFunction(IntPtr radialForceComponent, float value);
		internal delegate void SetRadiusFunction(IntPtr radialForceComponent, float value);
		internal delegate void AddCollisionChannelToAffectFunction(IntPtr radialForceComponent, CollisionChannel channel);
		internal delegate void FireImpulseFunction(IntPtr radialForceComponent);

		internal static GetIgnoreOwningActorFunction getIgnoreOwningActor;
		internal static GetImpulseVelocityChangeFunction getImpulseVelocityChange;
		internal static GetLinearFalloffFunction getLinearFalloff;
		internal static GetForceStrengthFunction getForceStrength;
		internal static GetImpulseStrengthFunction getImpulseStrength;
		internal static GetRadiusFunction getRadius;
		internal static SetIgnoreOwningActorFunction setIgnoreOwningActor;
		internal static SetImpulseVelocityChangeFunction setImpulseVelocityChange;
		internal static SetLinearFalloffFunction setLinearFalloff;
		internal static SetForceStrengthFunction setForceStrength;
		internal static SetImpulseStrengthFunction setImpulseStrength;
		internal static SetRadiusFunction setRadius;
		internal static AddCollisionChannelToAffectFunction addCollisionChannelToAffect;
		internal static FireImpulseFunction fireImpulse;
	}

	partial class MaterialInterface {
		internal delegate Bool IsTwoSidedFunction(IntPtr materialInterface);

		internal static IsTwoSidedFunction isTwoSided;
	}

	partial class Material {
		internal delegate Bool IsDefaultMaterialFunction(IntPtr material);

		internal static IsDefaultMaterialFunction isDefaultMaterial;
	}

	partial class MaterialInstance {
		internal delegate Bool IsChildOfFunction(IntPtr materialInstance, IntPtr material);

		internal static IsChildOfFunction isChildOf;
	}

	partial class MaterialInstanceDynamic {
		internal delegate void ClearParameterValuesFunction(IntPtr materialInstanceDynamic);
		internal delegate void SetTextureParameterValueFunction(IntPtr materialInstanceDynamic, string parameterName, IntPtr value);
		internal delegate void SetVectorParameterValueFunction(IntPtr materialInstanceDynamic, string parameterName, in LinearColor value);
		internal delegate void SetScalarParameterValueFunction(IntPtr materialInstanceDynamic, string parameterName, float value);

		internal static ClearParameterValuesFunction clearParameterValues;
		internal static SetTextureParameterValueFunction setTextureParameterValue;
		internal static SetVectorParameterValueFunction setVectorParameterValue;
		internal static SetScalarParameterValueFunction setScalarParameterValue;
	}
}
