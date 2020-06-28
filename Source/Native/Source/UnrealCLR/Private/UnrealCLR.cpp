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

#include "UnrealCLR.h"

#define LOCTEXT_NAMESPACE "UnrealCLR"

DEFINE_LOG_CATEGORY(LogUnrealCLR);

void UnrealCLR::Module::StartupModule() {
	#define HOSTFXR_VERSION "3.1.5"
	#define HOSTFXR_WINDOWS "/hostfxr.dll"
	#define HOSTFXR_MAC "/libhostfxr.dylib"
	#define HOSTFXR_LINUX "/libhostfxr.so"

	#ifdef PLATFORM_WINDOWS
		#define HOSTFXR_PATH "Plugins/UnrealCLR/Runtime/Win64/host/fxr/" HOSTFXR_VERSION HOSTFXR_WINDOWS
	#elif PLATFORM_MAC
		#define HOSTFXR_PATH "Plugins/UnrealCLR/Runtime/Mac/host/fxr/" HOSTFXR_VERSION HOSTFXR_MAC
	#else
		#define HOSTFXR_PATH "Plugins/UnrealCLR/Runtime/Linux/host/fxr/" HOSTFXR_VERSION HOSTFXR_LINUX
	#endif

	UnrealCLR::Status = UnrealCLR::StatusType::Stopped;
	UnrealCLR::ProjectPath = FPaths::ConvertRelativePathToFull(FPaths::ProjectDir());
	UnrealCLR::UserAssembliesPath = UnrealCLR::ProjectPath + TEXT("Managed/");

	FString hostfxrPath = UnrealCLR::ProjectPath + TEXT(HOSTFXR_PATH);
	FString assembliesPath = UnrealCLR::ProjectPath + TEXT("Plugins/UnrealCLR/Managed/");
	FString runtimeConfigPath = assembliesPath + TEXT("UnrealEngine.Runtime.runtimeconfig.json");
	FString runtimeAssemblyPath = assembliesPath + TEXT("UnrealEngine.Runtime.dll");
	FString runtimeTypeName = TEXT("UnrealEngine.Runtime.Core, UnrealEngine.Runtime");
	FString runtimeMethodName = TEXT("Initialize");
	FString runtimeMethodDelegateName = TEXT("UnrealEngine.Runtime.InitializeDelegate, UnrealEngine.Runtime");

	OnWorldPreInitializationHandle = FWorldDelegates::OnPreWorldInitialization.AddRaw(this, &UnrealCLR::Module::OnWorldPreInitialization);
	OnWorldCleanupHandle = FWorldDelegates::OnWorldCleanup.AddRaw(this, &UnrealCLR::Module::OnWorldCleanup);

	UE_LOG(LogUnrealCLR, Display, TEXT("%s: Host path set to \"%s\""), ANSI_TO_TCHAR(__FUNCTION__), *hostfxrPath);

	HostfxrLibrary = FPlatformProcess::GetDllHandle(*hostfxrPath);

	if (HostfxrLibrary) {
		UE_LOG(LogUnrealCLR, Display, TEXT("%s: Host library loaded successfuly!"), ANSI_TO_TCHAR(__FUNCTION__));

		hostfxr_set_error_writer_fn HostfxrSetErrorWriter = (hostfxr_set_error_writer_fn)FPlatformProcess::GetDllExport(HostfxrLibrary, TEXT("hostfxr_set_error_writer"));

		if (!HostfxrSetErrorWriter) {
			UE_LOG(LogUnrealCLR, Error, TEXT("%s: Unable to locate hostfxr_set_error_writer entry point!"), ANSI_TO_TCHAR(__FUNCTION__));

			return;
		}

		hostfxr_initialize_for_runtime_config_fn HostfxrInitializeForRuntimeConfig = (hostfxr_initialize_for_runtime_config_fn)FPlatformProcess::GetDllExport(HostfxrLibrary, TEXT("hostfxr_initialize_for_runtime_config"));

		if (!HostfxrInitializeForRuntimeConfig) {
			UE_LOG(LogUnrealCLR, Error, TEXT("%s: Unable to locate hostfxr_initialize_for_runtime_config entry point!"), ANSI_TO_TCHAR(__FUNCTION__));

			return;
		}

		hostfxr_get_runtime_delegate_fn HostfxrGetRuntimeDelegate = (hostfxr_get_runtime_delegate_fn)FPlatformProcess::GetDllExport(HostfxrLibrary, TEXT("hostfxr_get_runtime_delegate"));

		if (!HostfxrGetRuntimeDelegate) {
			UE_LOG(LogUnrealCLR, Error, TEXT("%s: Unable to locate hostfxr_get_runtime_delegate entry point!"), ANSI_TO_TCHAR(__FUNCTION__));

			return;
		}

		hostfxr_close_fn HostfxrClose = (hostfxr_close_fn)FPlatformProcess::GetDllExport(HostfxrLibrary, TEXT("hostfxr_close"));

		if (!HostfxrClose) {
			UE_LOG(LogUnrealCLR, Error, TEXT("%s: Unable to locate hostfxr_close entry point!"), ANSI_TO_TCHAR(__FUNCTION__));

			return;
		}

		HostfxrSetErrorWriter(HostError);

		hostfxr_handle HostfxrContext = nullptr;

		if (HostfxrInitializeForRuntimeConfig(*runtimeConfigPath, nullptr, &HostfxrContext) != 0 || !HostfxrContext) {
			UE_LOG(LogUnrealCLR, Error, TEXT("%s: Unable to initialize the host! Please, try to restart the engine."), ANSI_TO_TCHAR(__FUNCTION__));

			HostfxrClose(HostfxrContext);

			return;
		}

		void* hostfxrLoadAssemblyAndGetFunctionPointer = nullptr;

		if (HostfxrGetRuntimeDelegate(HostfxrContext, hdt_load_assembly_and_get_function_pointer, &hostfxrLoadAssemblyAndGetFunctionPointer) != 0 || !HostfxrGetRuntimeDelegate) {
			UE_LOG(LogUnrealCLR, Error, TEXT("%s: Unable to get hdt_load_assembly_and_get_function_pointer runtime delegate!"), ANSI_TO_TCHAR(__FUNCTION__));

			HostfxrClose(HostfxrContext);

			return;
		}

		HostfxrClose(HostfxrContext);

		UE_LOG(LogUnrealCLR, Display, TEXT("%s: Host functions loaded successfuly!"), ANSI_TO_TCHAR(__FUNCTION__));

		load_assembly_and_get_function_pointer_fn HostfxrLoadAssemblyAndGetFunctionPointer = (load_assembly_and_get_function_pointer_fn)hostfxrLoadAssemblyAndGetFunctionPointer;

		int32 (*Initialize)(void* Functions, int32 Checksum) = nullptr;

		if (HostfxrLoadAssemblyAndGetFunctionPointer && HostfxrLoadAssemblyAndGetFunctionPointer(*runtimeAssemblyPath, *runtimeTypeName, *runtimeMethodName, *runtimeMethodDelegateName, nullptr, (void**)&Initialize) == 0) {
			UE_LOG(LogUnrealCLR, Display, TEXT("%s: Host runtime assembly loaded succesfuly!"), ANSI_TO_TCHAR(__FUNCTION__));
		} else {
			UE_LOG(LogUnrealCLR, Error, TEXT("%s: Host runtime assembly loading failed!"), ANSI_TO_TCHAR(__FUNCTION__));

			return;
		}

		if (Initialize) {
			// Framework pointers

			int32 position = 0;
			int32 checksum = 0;

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::AssertFunctions;

				Shared::AssertFunctions[head++] = &UnrealCLRFramework::Assert::OutputMessage;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::CommandLineFunctions;

				Shared::CommandLineFunctions[head++] = &UnrealCLRFramework::CommandLine::Get;
				Shared::CommandLineFunctions[head++] = &UnrealCLRFramework::CommandLine::Set;
				Shared::CommandLineFunctions[head++] = &UnrealCLRFramework::CommandLine::Append;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::DebugFunctions;

				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::Log;
				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::HandleException;
				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::AddOnScreenMessage;
				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::ClearOnScreenMessages;
				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::DrawBox;
				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::DrawCapsule;
				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::DrawCone;
				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::DrawCylinder;
				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::DrawSphere;
				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::DrawLine;
				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::DrawPoint;
				Shared::DebugFunctions[head++] = &UnrealCLRFramework::Debug::FlushPersistentLines;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ObjectFunctions;

				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::IsPendingKill;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::IsValid;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::Load;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::Rename;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetID;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetName;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetBool;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetByte;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetShort;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetInt;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetLong;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetUShort;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetUInt;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetULong;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetFloat;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetDouble;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::GetText;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::SetBool;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::SetByte;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::SetShort;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::SetInt;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::SetLong;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::SetUShort;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::SetUInt;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::SetULong;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::SetFloat;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::SetDouble;
				Shared::ObjectFunctions[head++] = &UnrealCLRFramework::Object::SetText;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ApplicationFunctions;

				Shared::ApplicationFunctions[head++] = &UnrealCLRFramework::Application::IsCanEverRender;
				Shared::ApplicationFunctions[head++] = &UnrealCLRFramework::Application::IsPackagedForDistribution;
				Shared::ApplicationFunctions[head++] = &UnrealCLRFramework::Application::IsPackagedForShipping;
				Shared::ApplicationFunctions[head++] = &UnrealCLRFramework::Application::GetProjectDirectory;
				Shared::ApplicationFunctions[head++] = &UnrealCLRFramework::Application::GetDefaultLanguage;
				Shared::ApplicationFunctions[head++] = &UnrealCLRFramework::Application::GetProjectName;
				Shared::ApplicationFunctions[head++] = &UnrealCLRFramework::Application::GetVolumeMultiplier;
				Shared::ApplicationFunctions[head++] = &UnrealCLRFramework::Application::SetProjectName;
				Shared::ApplicationFunctions[head++] = &UnrealCLRFramework::Application::SetVolumeMultiplier;
				Shared::ApplicationFunctions[head++] = &UnrealCLRFramework::Application::RequestExit;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ConsoleManagerFunctions;

				Shared::ConsoleManagerFunctions[head++] = &UnrealCLRFramework::ConsoleManager::IsRegisteredVariable;
				Shared::ConsoleManagerFunctions[head++] = &UnrealCLRFramework::ConsoleManager::FindVariable;
				Shared::ConsoleManagerFunctions[head++] = &UnrealCLRFramework::ConsoleManager::RegisterVariableBool;
				Shared::ConsoleManagerFunctions[head++] = &UnrealCLRFramework::ConsoleManager::RegisterVariableInt;
				Shared::ConsoleManagerFunctions[head++] = &UnrealCLRFramework::ConsoleManager::RegisterVariableFloat;
				Shared::ConsoleManagerFunctions[head++] = &UnrealCLRFramework::ConsoleManager::RegisterVariableString;
				Shared::ConsoleManagerFunctions[head++] = &UnrealCLRFramework::ConsoleManager::RegisterCommand;
				Shared::ConsoleManagerFunctions[head++] = &UnrealCLRFramework::ConsoleManager::UnregisterObject;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::EngineFunctions;

				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::IsSplitScreen;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::IsEditor;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::IsForegroundWindow;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::IsExitRequested;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::GetNetMode;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::GetFrameNumber;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::GetViewportSize;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::GetScreenResolution;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::GetWindowMode;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::GetVersion;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::GetMaxFPS;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::SetMaxFPS;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::SetTitle;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::AddActionMapping;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::AddAxisMapping;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::ForceGarbageCollection;
				Shared::EngineFunctions[head++] = &UnrealCLRFramework::Engine::DelayGarbageCollection;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::HeadMountedDisplayFunctions;

				Shared::HeadMountedDisplayFunctions[head++] = &UnrealCLRFramework::HeadMountedDisplay::IsConnected;
				Shared::HeadMountedDisplayFunctions[head++] = &UnrealCLRFramework::HeadMountedDisplay::GetEnabled;
				Shared::HeadMountedDisplayFunctions[head++] = &UnrealCLRFramework::HeadMountedDisplay::GetLowPersistenceMode;
				Shared::HeadMountedDisplayFunctions[head++] = &UnrealCLRFramework::HeadMountedDisplay::GetDeviceName;
				Shared::HeadMountedDisplayFunctions[head++] = &UnrealCLRFramework::HeadMountedDisplay::SetEnable;
				Shared::HeadMountedDisplayFunctions[head++] = &UnrealCLRFramework::HeadMountedDisplay::SetLowPersistenceMode;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::WorldFunctions;

				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::GetSimulatePhysics;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::GetActorCount;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::GetDeltaSeconds;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::GetRealTimeSeconds;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::GetTimeSeconds;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::GetWorldOrigin;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::GetActor;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::GetActorByTag;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::GetActorByID;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::GetFirstPlayerController;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::SetSimulatePhysics;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::SetGravity;
				Shared::WorldFunctions[head++] = &UnrealCLRFramework::World::SetWorldOrigin;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::BlueprintFunctions;

				Shared::BlueprintFunctions[head++] = &UnrealCLRFramework::Blueprint::IsValidActorClass;
				Shared::BlueprintFunctions[head++] = &UnrealCLRFramework::Blueprint::IsValidComponentClass;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ConsoleObjectFunctions;

				Shared::ConsoleObjectFunctions[head++] = &UnrealCLRFramework::ConsoleObject::IsBool;
				Shared::ConsoleObjectFunctions[head++] = &UnrealCLRFramework::ConsoleObject::IsInt;
				Shared::ConsoleObjectFunctions[head++] = &UnrealCLRFramework::ConsoleObject::IsFloat;
				Shared::ConsoleObjectFunctions[head++] = &UnrealCLRFramework::ConsoleObject::IsString;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ConsoleVariableFunctions;

				Shared::ConsoleVariableFunctions[head++] = &UnrealCLRFramework::ConsoleVariable::GetBool;
				Shared::ConsoleVariableFunctions[head++] = &UnrealCLRFramework::ConsoleVariable::GetInt;
				Shared::ConsoleVariableFunctions[head++] = &UnrealCLRFramework::ConsoleVariable::GetFloat;
				Shared::ConsoleVariableFunctions[head++] = &UnrealCLRFramework::ConsoleVariable::GetString;
				Shared::ConsoleVariableFunctions[head++] = &UnrealCLRFramework::ConsoleVariable::SetBool;
				Shared::ConsoleVariableFunctions[head++] = &UnrealCLRFramework::ConsoleVariable::SetInt;
				Shared::ConsoleVariableFunctions[head++] = &UnrealCLRFramework::ConsoleVariable::SetFloat;
				Shared::ConsoleVariableFunctions[head++] = &UnrealCLRFramework::ConsoleVariable::SetString;
				Shared::ConsoleVariableFunctions[head++] = &UnrealCLRFramework::ConsoleVariable::SetOnChangedCallback;
				Shared::ConsoleVariableFunctions[head++] = &UnrealCLRFramework::ConsoleVariable::ClearOnChangedCallback;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ActorFunctions;

				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::IsPendingKill;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::IsRootComponentMovable;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::IsOverlappingActor;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::Spawn;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::Destroy;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::Rename;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::Hide;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::TeleportTo;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::GetComponent;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::GetComponentByTag;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::GetComponentByID;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::GetRootComponent;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::GetInputComponent;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::GetBlockInput;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::GetDistanceTo;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::GetBounds;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::SetRootComponent;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::SetInputComponent;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::SetBlockInput;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::SetLifeSpan;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::SetEnableCollision;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::AddTag;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::RemoveTag;
				Shared::ActorFunctions[head++] = &UnrealCLRFramework::Actor::HasTag;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PawnFunctions;

				Shared::PawnFunctions[head++] = &UnrealCLRFramework::Pawn::AddControllerYawInput;
				Shared::PawnFunctions[head++] = &UnrealCLRFramework::Pawn::AddControllerPitchInput;
				Shared::PawnFunctions[head++] = &UnrealCLRFramework::Pawn::AddControllerRollInput;
				Shared::PawnFunctions[head++] = &UnrealCLRFramework::Pawn::AddMovementInput;
				Shared::PawnFunctions[head++] = &UnrealCLRFramework::Pawn::GetGravityDirection;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ControllerFunctions;

				Shared::ControllerFunctions[head++] = &UnrealCLRFramework::Controller::IsLookInputIgnored;
				Shared::ControllerFunctions[head++] = &UnrealCLRFramework::Controller::IsMoveInputIgnored;
				Shared::ControllerFunctions[head++] = &UnrealCLRFramework::Controller::IsPlayerController;
				Shared::ControllerFunctions[head++] = &UnrealCLRFramework::Controller::GetPawn;
				Shared::ControllerFunctions[head++] = &UnrealCLRFramework::Controller::LineOfSightTo;
				Shared::ControllerFunctions[head++] = &UnrealCLRFramework::Controller::SetInitialLocationAndRotation;
				Shared::ControllerFunctions[head++] = &UnrealCLRFramework::Controller::SetIgnoreLookInput;
				Shared::ControllerFunctions[head++] = &UnrealCLRFramework::Controller::SetIgnoreMoveInput;
				Shared::ControllerFunctions[head++] = &UnrealCLRFramework::Controller::ResetIgnoreLookInput;
				Shared::ControllerFunctions[head++] = &UnrealCLRFramework::Controller::ResetIgnoreMoveInput;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::AIControllerFunctions;

				Shared::AIControllerFunctions[head++] = &UnrealCLRFramework::AIController::ClearFocus;
				Shared::AIControllerFunctions[head++] = &UnrealCLRFramework::AIController::GetFocalPoint;
				Shared::AIControllerFunctions[head++] = &UnrealCLRFramework::AIController::SetFocalPoint;
				Shared::AIControllerFunctions[head++] = &UnrealCLRFramework::AIController::GetFocusActor;
				Shared::AIControllerFunctions[head++] = &UnrealCLRFramework::AIController::GetAllowStrafe;
				Shared::AIControllerFunctions[head++] = &UnrealCLRFramework::AIController::SetAllowStrafe;
				Shared::AIControllerFunctions[head++] = &UnrealCLRFramework::AIController::SetFocus;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PlayerControllerFunctions;

				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::IsPaused;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::GetShowMouseCursor;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::GetMousePosition;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::GetPlayerViewPoint;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::GetPlayerInput;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::SetShowMouseCursor;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::SetMousePosition;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::ConsoleCommand;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::SetPause;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::SetViewTarget;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::SetViewTargetWithBlend;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::AddYawInput;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::AddPitchInput;
				Shared::PlayerControllerFunctions[head++] = &UnrealCLRFramework::PlayerController::AddRollInput;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::VolumeFunctions;

				Shared::VolumeFunctions[head++] = &UnrealCLRFramework::Volume::EncompassesPoint;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PostProcessVolumeFunctions;

				Shared::PostProcessVolumeFunctions[head++] = &UnrealCLRFramework::PostProcessVolume::GetEnabled;
				Shared::PostProcessVolumeFunctions[head++] = &UnrealCLRFramework::PostProcessVolume::GetBlendRadius;
				Shared::PostProcessVolumeFunctions[head++] = &UnrealCLRFramework::PostProcessVolume::GetBlendWeight;
				Shared::PostProcessVolumeFunctions[head++] = &UnrealCLRFramework::PostProcessVolume::GetUnbound;
				Shared::PostProcessVolumeFunctions[head++] = &UnrealCLRFramework::PostProcessVolume::GetPriority;
				Shared::PostProcessVolumeFunctions[head++] = &UnrealCLRFramework::PostProcessVolume::SetEnabled;
				Shared::PostProcessVolumeFunctions[head++] = &UnrealCLRFramework::PostProcessVolume::SetBlendRadius;
				Shared::PostProcessVolumeFunctions[head++] = &UnrealCLRFramework::PostProcessVolume::SetBlendWeight;
				Shared::PostProcessVolumeFunctions[head++] = &UnrealCLRFramework::PostProcessVolume::SetUnbound;
				Shared::PostProcessVolumeFunctions[head++] = &UnrealCLRFramework::PostProcessVolume::SetPriority;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SoundBaseFunctions;

				Shared::SoundBaseFunctions[head++] = &UnrealCLRFramework::SoundBase::GetDuration;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SoundWaveFunctions;

				Shared::SoundWaveFunctions[head++] = &UnrealCLRFramework::SoundWave::GetLoop;
				Shared::SoundWaveFunctions[head++] = &UnrealCLRFramework::SoundWave::SetLoop;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::AnimationInstanceFunctions;

				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::GetCurrentActiveMontage;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageIsPlaying;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageGetPlayRate;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageGetPosition;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageGetBlendTime;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageGetCurrentSection;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageSetPlayRate;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageSetPosition;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageSetNextSection;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontagePlay;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontagePause;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageResume;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageStop;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageJumpToSection;
				Shared::AnimationInstanceFunctions[head++] = &UnrealCLRFramework::AnimationInstance::MontageJumpToSectionsEnd;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PlayerInputFunctions;

				Shared::PlayerInputFunctions[head++] = &UnrealCLRFramework::PlayerInput::IsKeyPressed;
				Shared::PlayerInputFunctions[head++] = &UnrealCLRFramework::PlayerInput::GetTimeKeyPressed;
				Shared::PlayerInputFunctions[head++] = &UnrealCLRFramework::PlayerInput::GetMouseSensitivity;
				Shared::PlayerInputFunctions[head++] = &UnrealCLRFramework::PlayerInput::SetMouseSensitivity;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::Texture2DFunctions;

				Shared::Texture2DFunctions[head++] = &UnrealCLRFramework::Texture2D::GetSize;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ActorComponentFunctions;

				Shared::ActorComponentFunctions[head++] = &UnrealCLRFramework::ActorComponent::IsOwnerSelected;
				Shared::ActorComponentFunctions[head++] = &UnrealCLRFramework::ActorComponent::GetOwner;
				Shared::ActorComponentFunctions[head++] = &UnrealCLRFramework::ActorComponent::Destroy;
				Shared::ActorComponentFunctions[head++] = &UnrealCLRFramework::ActorComponent::AddTag;
				Shared::ActorComponentFunctions[head++] = &UnrealCLRFramework::ActorComponent::RemoveTag;
				Shared::ActorComponentFunctions[head++] = &UnrealCLRFramework::ActorComponent::HasTag;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::InputComponentFunctions;

				Shared::InputComponentFunctions[head++] = &UnrealCLRFramework::InputComponent::HasBindings;
				Shared::InputComponentFunctions[head++] = &UnrealCLRFramework::InputComponent::GetActionBindingsNumber;
				Shared::InputComponentFunctions[head++] = &UnrealCLRFramework::InputComponent::ClearActionBindings;
				Shared::InputComponentFunctions[head++] = &UnrealCLRFramework::InputComponent::BindAction;
				Shared::InputComponentFunctions[head++] = &UnrealCLRFramework::InputComponent::BindAxis;
				Shared::InputComponentFunctions[head++] = &UnrealCLRFramework::InputComponent::RemoveActionBinding;
				Shared::InputComponentFunctions[head++] = &UnrealCLRFramework::InputComponent::GetBlockInput;
				Shared::InputComponentFunctions[head++] = &UnrealCLRFramework::InputComponent::SetBlockInput;
				Shared::InputComponentFunctions[head++] = &UnrealCLRFramework::InputComponent::GetPriority;
				Shared::InputComponentFunctions[head++] = &UnrealCLRFramework::InputComponent::SetPriority;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SceneComponentFunctions;

				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::IsAttachedToComponent;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::IsAttachedToActor;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::IsSocketExists;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::HasAnySockets;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::Create;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::AttachToComponent;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::DetachFromComponent;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::Activate;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::Deactivate;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::UpdateToWorld;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::AddLocalOffset;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::AddLocalRotation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::AddRelativeLocation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::AddRelativeRotation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::AddLocalTransform;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::AddWorldOffset;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::AddWorldRotation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::AddWorldTransform;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::GetAttachedSocketName;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::GetSocketLocation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::GetSocketRotation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::GetComponentVelocity;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::GetComponentLocation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::GetComponentRotation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::GetComponentScale;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::GetComponentTransform;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::GetForwardVector;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::GetRightVector;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::GetUpVector;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::SetMobility;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::SetRelativeLocation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::SetRelativeRotation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::SetRelativeTransform;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::SetWorldLocation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::SetWorldRotation;
				Shared::SceneComponentFunctions[head++] = &UnrealCLRFramework::SceneComponent::SetWorldTransform;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::AudioComponentFunctions;

				Shared::AudioComponentFunctions[head++] = &UnrealCLRFramework::AudioComponent::IsPlaying;
				Shared::AudioComponentFunctions[head++] = &UnrealCLRFramework::AudioComponent::GetPaused;
				Shared::AudioComponentFunctions[head++] = &UnrealCLRFramework::AudioComponent::SetSound;
				Shared::AudioComponentFunctions[head++] = &UnrealCLRFramework::AudioComponent::SetPaused;
				Shared::AudioComponentFunctions[head++] = &UnrealCLRFramework::AudioComponent::Play;
				Shared::AudioComponentFunctions[head++] = &UnrealCLRFramework::AudioComponent::Stop;
				Shared::AudioComponentFunctions[head++] = &UnrealCLRFramework::AudioComponent::FadeIn;
				Shared::AudioComponentFunctions[head++] = &UnrealCLRFramework::AudioComponent::FadeOut;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::CameraComponentFunctions;

				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::GetConstrainAspectRatio;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::GetAspectRatio;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::GetFieldOfView;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::GetOrthoFarClipPlane;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::GetOrthoNearClipPlane;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::GetOrthoWidth;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::GetLockToHeadMountedDisplay;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::SetProjectionMode;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::SetConstrainAspectRatio;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::SetAspectRatio;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::SetFieldOfView;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::SetOrthoFarClipPlane;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::SetOrthoNearClipPlane;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::SetOrthoWidth;
				Shared::CameraComponentFunctions[head++] = &UnrealCLRFramework::CameraComponent::SetLockToHeadMountedDisplay;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ChildActorComponentFunctions;

				Shared::ChildActorComponentFunctions[head++] = &UnrealCLRFramework::ChildActorComponent::SetChildActor;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PrimitiveComponentFunctions;

				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::IsGravityEnabled;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::AddAngularImpulseInDegrees;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::AddAngularImpulseInRadians;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::AddForce;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::AddForceAtLocation;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::AddImpulse;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::AddImpulseAtLocation;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::AddRadialForce;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::AddRadialImpulse;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::AddTorqueInDegrees;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::AddTorqueInRadians;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::GetMass;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::GetCastShadow;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::GetOnlyOwnerSee;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::GetOwnerNoSee;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::GetMaterial;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::GetMaterialsNumber;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::GetDistanceToCollision;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::GetSquaredDistanceToCollision;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::GetAngularDamping;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::GetLinearDamping;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetMass;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetCenterOfMass;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetPhysicsLinearVelocity;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetPhysicsAngularVelocityInDegrees;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetPhysicsAngularVelocityInRadians;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetPhysicsMaxAngularVelocityInDegrees;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetPhysicsMaxAngularVelocityInRadians;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetCastShadow;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetOnlyOwnerSee;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetOwnerNoSee;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetMaterial;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetSimulatePhysics;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetAngularDamping;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetLinearDamping;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetEnableGravity;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetCollisionMode;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetCollisionChannel;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetIgnoreActorWhenMoving;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::SetIgnoreComponentWhenMoving;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::ClearMoveIgnoreActors;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::ClearMoveIgnoreComponents;
				Shared::PrimitiveComponentFunctions[head++] = &UnrealCLRFramework::PrimitiveComponent::CreateAndSetMaterialInstanceDynamic;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ShapeComponentFunctions;

				Shared::ShapeComponentFunctions[head++] = &UnrealCLRFramework::ShapeComponent::GetDynamicObstacle;
				Shared::ShapeComponentFunctions[head++] = &UnrealCLRFramework::ShapeComponent::GetShapeColor;
				Shared::ShapeComponentFunctions[head++] = &UnrealCLRFramework::ShapeComponent::SetDynamicObstacle;
				Shared::ShapeComponentFunctions[head++] = &UnrealCLRFramework::ShapeComponent::SetShapeColor;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::BoxComponentFunctions;

				Shared::BoxComponentFunctions[head++] = &UnrealCLRFramework::BoxComponent::GetScaledBoxExtent;
				Shared::BoxComponentFunctions[head++] = &UnrealCLRFramework::BoxComponent::GetUnscaledBoxExtent;
				Shared::BoxComponentFunctions[head++] = &UnrealCLRFramework::BoxComponent::SetBoxExtent;
				Shared::BoxComponentFunctions[head++] = &UnrealCLRFramework::BoxComponent::InitBoxExtent;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SphereComponentFunctions;

				Shared::SphereComponentFunctions[head++] = &UnrealCLRFramework::SphereComponent::GetScaledSphereRadius;
				Shared::SphereComponentFunctions[head++] = &UnrealCLRFramework::SphereComponent::GetUnscaledSphereRadius;
				Shared::SphereComponentFunctions[head++] = &UnrealCLRFramework::SphereComponent::GetShapeScale;
				Shared::SphereComponentFunctions[head++] = &UnrealCLRFramework::SphereComponent::SetSphereRadius;
				Shared::SphereComponentFunctions[head++] = &UnrealCLRFramework::SphereComponent::InitSphereRadius;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::CapsuleComponentFunctions;

				Shared::CapsuleComponentFunctions[head++] = &UnrealCLRFramework::CapsuleComponent::GetScaledCapsuleRadius;
				Shared::CapsuleComponentFunctions[head++] = &UnrealCLRFramework::CapsuleComponent::GetUnscaledCapsuleRadius;
				Shared::CapsuleComponentFunctions[head++] = &UnrealCLRFramework::CapsuleComponent::GetShapeScale;
				Shared::CapsuleComponentFunctions[head++] = &UnrealCLRFramework::CapsuleComponent::GetScaledCapsuleSize;
				Shared::CapsuleComponentFunctions[head++] = &UnrealCLRFramework::CapsuleComponent::GetUnscaledCapsuleSize;
				Shared::CapsuleComponentFunctions[head++] = &UnrealCLRFramework::CapsuleComponent::SetCapsuleRadius;
				Shared::CapsuleComponentFunctions[head++] = &UnrealCLRFramework::CapsuleComponent::SetCapsuleSize;
				Shared::CapsuleComponentFunctions[head++] = &UnrealCLRFramework::CapsuleComponent::InitCapsuleSize;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MeshComponentFunctions;

				Shared::MeshComponentFunctions[head++] = &UnrealCLRFramework::MeshComponent::IsValidMaterialSlotName;
				Shared::MeshComponentFunctions[head++] = &UnrealCLRFramework::MeshComponent::GetMaterialIndex;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::LightComponentBaseFunctions;

				Shared::LightComponentBaseFunctions[head++] = &UnrealCLRFramework::LightComponentBase::GetIntensity;
				Shared::LightComponentBaseFunctions[head++] = &UnrealCLRFramework::LightComponentBase::GetCastShadows;
				Shared::LightComponentBaseFunctions[head++] = &UnrealCLRFramework::LightComponentBase::SetCastShadows;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::LightComponentFunctions;

				Shared::LightComponentFunctions[head++] = &UnrealCLRFramework::LightComponent::SetIntensity;
				Shared::LightComponentFunctions[head++] = &UnrealCLRFramework::LightComponent::SetLightColor;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MotionControllerComponentFunctions;

				Shared::MotionControllerComponentFunctions[head++] = &UnrealCLRFramework::MotionControllerComponent::IsTracked;
				Shared::MotionControllerComponentFunctions[head++] = &UnrealCLRFramework::MotionControllerComponent::GetDisableLowLatencyUpdate;
				Shared::MotionControllerComponentFunctions[head++] = &UnrealCLRFramework::MotionControllerComponent::GetTrackingSource;
				Shared::MotionControllerComponentFunctions[head++] = &UnrealCLRFramework::MotionControllerComponent::SetDisableLowLatencyUpdate;
				Shared::MotionControllerComponentFunctions[head++] = &UnrealCLRFramework::MotionControllerComponent::SetTrackingSource;
				Shared::MotionControllerComponentFunctions[head++] = &UnrealCLRFramework::MotionControllerComponent::SetTrackingMotionSource;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::StaticMeshComponentFunctions;

				Shared::StaticMeshComponentFunctions[head++] = &UnrealCLRFramework::StaticMeshComponent::GetLocalBounds;
				Shared::StaticMeshComponentFunctions[head++] = &UnrealCLRFramework::StaticMeshComponent::GetStaticMesh;
				Shared::StaticMeshComponentFunctions[head++] = &UnrealCLRFramework::StaticMeshComponent::SetStaticMesh;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::InstancedStaticMeshComponentFunctions;

				Shared::InstancedStaticMeshComponentFunctions[head++] = &UnrealCLRFramework::InstancedStaticMeshComponent::GetInstanceCount;
				Shared::InstancedStaticMeshComponentFunctions[head++] = &UnrealCLRFramework::InstancedStaticMeshComponent::GetInstanceTransform;
				Shared::InstancedStaticMeshComponentFunctions[head++] = &UnrealCLRFramework::InstancedStaticMeshComponent::AddInstance;
				Shared::InstancedStaticMeshComponentFunctions[head++] = &UnrealCLRFramework::InstancedStaticMeshComponent::UpdateInstanceTransform;
				Shared::InstancedStaticMeshComponentFunctions[head++] = &UnrealCLRFramework::InstancedStaticMeshComponent::RemoveInstance;
				Shared::InstancedStaticMeshComponentFunctions[head++] = &UnrealCLRFramework::InstancedStaticMeshComponent::ClearInstances;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SkinnedMeshComponentFunctions;

				Shared::SkinnedMeshComponentFunctions[head++] = &UnrealCLRFramework::SkinnedMeshComponent::SetSkeletalMesh;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SkeletalMeshComponentFunctions;

				Shared::SkeletalMeshComponentFunctions[head++] = &UnrealCLRFramework::SkeletalMeshComponent::IsPlaying;
				Shared::SkeletalMeshComponentFunctions[head++] = &UnrealCLRFramework::SkeletalMeshComponent::GetAnimationInstance;
				Shared::SkeletalMeshComponentFunctions[head++] = &UnrealCLRFramework::SkeletalMeshComponent::SetAnimation;
				Shared::SkeletalMeshComponentFunctions[head++] = &UnrealCLRFramework::SkeletalMeshComponent::SetAnimationMode;
				Shared::SkeletalMeshComponentFunctions[head++] = &UnrealCLRFramework::SkeletalMeshComponent::SetAnimationBlueprint;
				Shared::SkeletalMeshComponentFunctions[head++] = &UnrealCLRFramework::SkeletalMeshComponent::Play;
				Shared::SkeletalMeshComponentFunctions[head++] = &UnrealCLRFramework::SkeletalMeshComponent::PlayAnimation;
				Shared::SkeletalMeshComponentFunctions[head++] = &UnrealCLRFramework::SkeletalMeshComponent::Stop;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::RadialForceComponentFunctions;

				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::GetIgnoreOwningActor;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::GetImpulseVelocityChange;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::GetLinearFalloff;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::GetForceStrength;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::GetImpulseStrength;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::GetRadius;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::SetIgnoreOwningActor;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::SetImpulseVelocityChange;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::SetLinearFalloff;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::SetForceStrength;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::SetImpulseStrength;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::SetRadius;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::AddCollisionChannelToAffect;
				Shared::RadialForceComponentFunctions[head++] = &UnrealCLRFramework::RadialForceComponent::FireImpulse;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MaterialInterfaceFunctions;

				Shared::MaterialInterfaceFunctions[head++] = &UnrealCLRFramework::MaterialInterface::IsTwoSided;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MaterialFunctions;

				Shared::MaterialFunctions[head++] = &UnrealCLRFramework::Material::IsDefaultMaterial;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MaterialInstanceFunctions;

				Shared::MaterialInstanceFunctions[head++] = &UnrealCLRFramework::MaterialInstance::IsChildOf;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MaterialInstanceDynamicFunctions;

				Shared::MaterialInstanceDynamicFunctions[head++] = &UnrealCLRFramework::MaterialInstanceDynamic::ClearParameterValues;
				Shared::MaterialInstanceDynamicFunctions[head++] = &UnrealCLRFramework::MaterialInstanceDynamic::SetTextureParameterValue;
				Shared::MaterialInstanceDynamicFunctions[head++] = &UnrealCLRFramework::MaterialInstanceDynamic::SetVectorParameterValue;
				Shared::MaterialInstanceDynamicFunctions[head++] = &UnrealCLRFramework::MaterialInstanceDynamic::SetScalarParameterValue;

				checksum += head;
			}

			checksum += position;

			// Runtime pointers

			Shared::ManagedFunctions[0] = &UnrealCLR::Module::Invoke;
			Shared::ManagedFunctions[1] = &UnrealCLR::Module::Exception;
			Shared::ManagedFunctions[2] = &UnrealCLR::Module::Log;

			void* functions[3] = {
				Shared::ManagedFunctions,
				Shared::NativeFunctions,
				Shared::Functions
			};

			if (Initialize(functions, checksum) == 0xF) {
				UnrealCLR::ExecuteAssemblyFunction = (UnrealCLR::ExecuteAssemblyFunctionDelegate)Shared::NativeFunctions[0];
				UnrealCLR::LoadAssemblyFunction = (UnrealCLR::LoadAssemblyFunctionDelegate)Shared::NativeFunctions[1];
				UnrealCLR::UnloadAssemblies = (UnrealCLR::UnloadAssembliesDelegate)Shared::NativeFunctions[2];

				UE_LOG(LogUnrealCLR, Display, TEXT("%s: Host runtime assembly initialized succesfuly!"), ANSI_TO_TCHAR(__FUNCTION__));
			} else {
				UE_LOG(LogUnrealCLR, Error, TEXT("%s: Host runtime assembly initialization failed!"), ANSI_TO_TCHAR(__FUNCTION__));

				return;
			}

			IPlatformFile& platformFile = FPlatformFileManager::Get().GetPlatformFile();

			if (!platformFile.DirectoryExists(*UnrealCLR::UserAssembliesPath)) {
				platformFile.CreateDirectory(*UnrealCLR::UserAssembliesPath);

				if (!platformFile.DirectoryExists(*UnrealCLR::UserAssembliesPath))
					UE_LOG(LogUnrealCLR, Error, TEXT("%s: Unable to create a folder for managed assemblies at %s."), ANSI_TO_TCHAR(__FUNCTION__), *UnrealCLR::UserAssembliesPath);
			}

			UnrealCLR::Status = UnrealCLR::StatusType::Idle;

			UE_LOG(LogUnrealCLR, Display, TEXT("%s: Host loaded succesfuly!"), ANSI_TO_TCHAR(__FUNCTION__));
		} else {
			UE_LOG(LogUnrealCLR, Error, TEXT("%s: Host runtime assembly unable to load the initialization function!"), ANSI_TO_TCHAR(__FUNCTION__));

			return;
		}
	} else {
		UE_LOG(LogUnrealCLR, Error, TEXT("%s: Host loading failed!"), ANSI_TO_TCHAR(__FUNCTION__));
	}
}

void UnrealCLR::Module::ShutdownModule() {
	FWorldDelegates::OnPreWorldInitialization.Remove(OnWorldPreInitializationHandle);
	FWorldDelegates::OnWorldCleanup.Remove(OnWorldCleanupHandle);

	FPlatformProcess::FreeDllHandle(HostfxrLibrary);
}

void UnrealCLR::Module::OnWorldPreInitialization(UWorld* World, const UWorld::InitializationValues InitializationValues) {
	if (World->IsGameWorld() && !UnrealCLR::Engine::World) {
		UnrealCLR::Engine::World = World;

		if (UnrealCLR::Status != UnrealCLR::StatusType::Stopped) {
			UnrealCLR::Status = UnrealCLR::StatusType::Running;
		} else {
			#if WITH_EDITOR
				FNotificationInfo notificationInfo(FText::FromString(TEXT("UnrealCLR host is not initialized! Please, check logs and try to restart the engine.")));

				notificationInfo.ExpireDuration = 5.0f;

				FSlateNotificationManager::Get().AddNotification(notificationInfo);
			#endif
		}
	}
}

void UnrealCLR::Module::OnWorldCleanup(UWorld* World, bool SessionEnded, bool CleanupResources) {
	if (World->IsGameWorld() && World == UnrealCLR::Engine::World) {
		UnrealCLR::Engine::World = nullptr;

		if (UnrealCLR::Status != UnrealCLR::StatusType::Stopped) {
			UnrealCLR::UnloadAssemblies();
			UnrealCLR::Status = UnrealCLR::StatusType::Idle;
		}
	}
}

void UnrealCLR::Module::HostError(const char_t* Message) {
	UE_LOG(LogUnrealCLR, Error, TEXT("%s: %s"), ANSI_TO_TCHAR(__FUNCTION__), *FString(Message));
}

void UnrealCLR::Module::Invoke(void(*ManagedFunction)()) {
	ManagedFunction();
}

void UnrealCLR::Module::Exception(const char* Message) {
	UE_LOG(LogUnrealCLR, Error, TEXT("%s: %s"), ANSI_TO_TCHAR(__FUNCTION__), *FString(ANSI_TO_TCHAR(Message)));

	GEngine->AddOnScreenDebugMessage((uint64)-1, 10.0f, FColor::Red, *FString(ANSI_TO_TCHAR(Message)));
}

void UnrealCLR::Module::Log(UnrealCLR::LogLevel Level, const char* Message) {
	#define UNREALCLR_LOG(Verbosity) UE_LOG(LogUnrealCLR, Verbosity, TEXT("%s: %s"), ANSI_TO_TCHAR(__FUNCTION__), *FString(ANSI_TO_TCHAR(Message)));

	if (Level == UnrealCLR::LogLevel::Display) {
		UNREALCLR_LOG(Display);
	} else if (Level == UnrealCLR::LogLevel::Warning) {
		UNREALCLR_LOG(Warning);

		GEngine->AddOnScreenDebugMessage((uint64)-1, 30.0f, FColor::Yellow, *FString(ANSI_TO_TCHAR(Message)));
	} else if (Level == UnrealCLR::LogLevel::Error) {
		UNREALCLR_LOG(Error);

		GEngine->AddOnScreenDebugMessage((uint64)-1, 30.0f, FColor::Red, *FString(ANSI_TO_TCHAR(Message)));
	} else if (Level == UnrealCLR::LogLevel::Fatal) {
		UNREALCLR_LOG(Error);

		GEngine->AddOnScreenDebugMessage((uint64)-1, 30.0f, FColor::Red, *FString(ANSI_TO_TCHAR(Message)));

		UnrealCLR::Status = UnrealCLR::StatusType::Idle;
	}
}

size_t UnrealCLR::Utility::Strcpy(char* Destination, const char* Source, size_t Length) {
	char* destination = Destination;
	const char* source = Source;
	size_t length = Length;

	if (length != 0 && --length != 0) {
		do {
			if ((*destination++ = *source++) == 0)
				break;
		}

		while (--length != 0);
	}

	if (length == 0) {
		if (Length != 0)
			*destination = '\0';

		while (*source++);
	}

	return (source - Source - 1);
}

size_t UnrealCLR::Utility::Strlen(const char* Source) {
	return strlen(Source) + 1;
}

#undef LOCTEXT_NAMESPACE

IMPLEMENT_MODULE(UnrealCLR::Module, UnrealCLR)