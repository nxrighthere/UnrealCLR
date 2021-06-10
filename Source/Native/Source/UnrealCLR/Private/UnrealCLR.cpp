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

#include "UnrealCLR.h"

#define LOCTEXT_NAMESPACE "UnrealCLR"

DEFINE_LOG_CATEGORY(LogUnrealCLR);

void UnrealCLR::Module::StartupModule() {
	#define HOSTFXR_VERSION "5.0.7"
	#define HOSTFXR_WINDOWS "/hostfxr.dll"
	#define HOSTFXR_MAC "/libhostfxr.dylib"
	#define HOSTFXR_LINUX "/libhostfxr.so"

	#ifdef UNREALCLR_WINDOWS
		#define HOSTFXR_PATH "Plugins/UnrealCLR/Runtime/Win64/host/fxr/" HOSTFXR_VERSION HOSTFXR_WINDOWS
		#define UNREALCLR_PLATFORM_STRING(string) string
	#elif defined(UNREALCLR_MAC)
		#define HOSTFXR_PATH "Plugins/UnrealCLR/Runtime/Mac/host/fxr/" HOSTFXR_VERSION HOSTFXR_MAC
		#define UNREALCLR_PLATFORM_STRING(string) TCHAR_TO_ANSI(string)
	#elif defined(UNREALCLR_UNIX)
		#define HOSTFXR_PATH "Plugins/UnrealCLR/Runtime/Linux/host/fxr/" HOSTFXR_VERSION HOSTFXR_LINUX
		#define UNREALCLR_PLATFORM_STRING(string) TCHAR_TO_ANSI(string)
	#else
		#error "Unknown platform"
	#endif

	UnrealCLR::Status = UnrealCLR::StatusType::Stopped;
	UnrealCLR::ProjectPath = FPaths::ConvertRelativePathToFull(FPaths::ProjectDir());
	UnrealCLR::UserAssembliesPath = UnrealCLR::ProjectPath + TEXT("Managed/");

	OnWorldPostInitializationHandle = FWorldDelegates::OnPostWorldInitialization.AddRaw(this, &UnrealCLR::Module::OnWorldPostInitialization);
	OnWorldCleanupHandle = FWorldDelegates::OnWorldCleanup.AddRaw(this, &UnrealCLR::Module::OnWorldCleanup);

	const FString hostfxrPath = UnrealCLR::ProjectPath + TEXT(HOSTFXR_PATH);
	const FString assembliesPath = UnrealCLR::ProjectPath + TEXT("Plugins/UnrealCLR/Managed/");
	const FString runtimeConfigPath = assembliesPath + TEXT("UnrealEngine.Runtime.runtimeconfig.json");
	const FString runtimeAssemblyPath = assembliesPath + TEXT("UnrealEngine.Runtime.dll");
	const FString runtimeTypeName = TEXT("UnrealEngine.Runtime.Core, UnrealEngine.Runtime");
	const FString runtimeMethodName = TEXT("ManagedCommand");

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

		if (HostfxrInitializeForRuntimeConfig(UNREALCLR_PLATFORM_STRING(*runtimeConfigPath), nullptr, &HostfxrContext) != 0 || !HostfxrContext) {
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

		if (HostfxrLoadAssemblyAndGetFunctionPointer && HostfxrLoadAssemblyAndGetFunctionPointer(UNREALCLR_PLATFORM_STRING(*runtimeAssemblyPath), UNREALCLR_PLATFORM_STRING(*runtimeTypeName), UNREALCLR_PLATFORM_STRING(*runtimeMethodName), UNMANAGEDCALLERSONLY_METHOD, nullptr, (void**)&UnrealCLR::ManagedCommand) == 0) {
			UE_LOG(LogUnrealCLR, Display, TEXT("%s: Host runtime assembly loaded succesfuly!"), ANSI_TO_TCHAR(__FUNCTION__));
		} else {
			UE_LOG(LogUnrealCLR, Error, TEXT("%s: Host runtime assembly loading failed!"), ANSI_TO_TCHAR(__FUNCTION__));

			return;
		}

		#if WITH_EDITOR
			IPlatformFile& platformFile = FPlatformFileManager::Get().GetPlatformFile();

			if (!platformFile.DirectoryExists(*UnrealCLR::UserAssembliesPath)) {
				platformFile.CreateDirectory(*UnrealCLR::UserAssembliesPath);

				if (!platformFile.DirectoryExists(*UnrealCLR::UserAssembliesPath))
					UE_LOG(LogUnrealCLR, Warning, TEXT("%s: Unable to create a folder for managed assemblies at %s."), ANSI_TO_TCHAR(__FUNCTION__), *UnrealCLR::UserAssembliesPath);
			}
		#endif

		if (UnrealCLR::ManagedCommand) {
			// Framework pointers

			int32 position = 0;
			int32 checksum = 0;

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::AssertFunctions;

				Shared::AssertFunctions[head++] = (void*)&UnrealCLRFramework::Assert::OutputMessage;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::CommandLineFunctions;

				Shared::CommandLineFunctions[head++] = (void*)&UnrealCLRFramework::CommandLine::Get;
				Shared::CommandLineFunctions[head++] = (void*)&UnrealCLRFramework::CommandLine::Set;
				Shared::CommandLineFunctions[head++] = (void*)&UnrealCLRFramework::CommandLine::Append;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::DebugFunctions;

				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::Log;
				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::Exception;
				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::AddOnScreenMessage;
				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::ClearOnScreenMessages;
				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::DrawBox;
				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::DrawCapsule;
				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::DrawCone;
				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::DrawCylinder;
				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::DrawSphere;
				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::DrawLine;
				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::DrawPoint;
				Shared::DebugFunctions[head++] = (void*)&UnrealCLRFramework::Debug::FlushPersistentLines;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ObjectFunctions;

				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::IsPendingKill;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::IsValid;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::Load;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::Rename;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::Invoke;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::ToActor;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::ToComponent;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetID;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetName;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetBool;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetByte;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetShort;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetInt;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetLong;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetUShort;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetUInt;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetULong;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetFloat;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetDouble;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetEnum;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetString;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::GetText;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetBool;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetByte;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetShort;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetInt;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetLong;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetUShort;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetUInt;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetULong;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetFloat;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetDouble;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetEnum;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetString;
				Shared::ObjectFunctions[head++] = (void*)&UnrealCLRFramework::Object::SetText;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ApplicationFunctions;

				Shared::ApplicationFunctions[head++] = (void*)&UnrealCLRFramework::Application::IsCanEverRender;
				Shared::ApplicationFunctions[head++] = (void*)&UnrealCLRFramework::Application::IsPackagedForDistribution;
				Shared::ApplicationFunctions[head++] = (void*)&UnrealCLRFramework::Application::IsPackagedForShipping;
				Shared::ApplicationFunctions[head++] = (void*)&UnrealCLRFramework::Application::GetProjectDirectory;
				Shared::ApplicationFunctions[head++] = (void*)&UnrealCLRFramework::Application::GetDefaultLanguage;
				Shared::ApplicationFunctions[head++] = (void*)&UnrealCLRFramework::Application::GetProjectName;
				Shared::ApplicationFunctions[head++] = (void*)&UnrealCLRFramework::Application::GetVolumeMultiplier;
				Shared::ApplicationFunctions[head++] = (void*)&UnrealCLRFramework::Application::SetProjectName;
				Shared::ApplicationFunctions[head++] = (void*)&UnrealCLRFramework::Application::SetVolumeMultiplier;
				Shared::ApplicationFunctions[head++] = (void*)&UnrealCLRFramework::Application::RequestExit;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ConsoleManagerFunctions;

				Shared::ConsoleManagerFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleManager::IsRegisteredVariable;
				Shared::ConsoleManagerFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleManager::FindVariable;
				Shared::ConsoleManagerFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleManager::RegisterVariableBool;
				Shared::ConsoleManagerFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleManager::RegisterVariableInt;
				Shared::ConsoleManagerFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleManager::RegisterVariableFloat;
				Shared::ConsoleManagerFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleManager::RegisterVariableString;
				Shared::ConsoleManagerFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleManager::RegisterCommand;
				Shared::ConsoleManagerFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleManager::UnregisterObject;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::EngineFunctions;

				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::IsSplitScreen;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::IsEditor;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::IsForegroundWindow;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::IsExitRequested;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::GetNetMode;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::GetFrameNumber;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::GetViewportSize;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::GetScreenResolution;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::GetWindowMode;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::GetVersion;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::GetMaxFPS;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::SetMaxFPS;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::SetTitle;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::AddActionMapping;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::AddAxisMapping;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::ForceGarbageCollection;
				Shared::EngineFunctions[head++] = (void*)&UnrealCLRFramework::Engine::DelayGarbageCollection;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::HeadMountedDisplayFunctions;

				Shared::HeadMountedDisplayFunctions[head++] = (void*)&UnrealCLRFramework::HeadMountedDisplay::IsConnected;
				Shared::HeadMountedDisplayFunctions[head++] = (void*)&UnrealCLRFramework::HeadMountedDisplay::GetEnabled;
				Shared::HeadMountedDisplayFunctions[head++] = (void*)&UnrealCLRFramework::HeadMountedDisplay::GetLowPersistenceMode;
				Shared::HeadMountedDisplayFunctions[head++] = (void*)&UnrealCLRFramework::HeadMountedDisplay::GetDeviceName;
				Shared::HeadMountedDisplayFunctions[head++] = (void*)&UnrealCLRFramework::HeadMountedDisplay::SetEnable;
				Shared::HeadMountedDisplayFunctions[head++] = (void*)&UnrealCLRFramework::HeadMountedDisplay::SetLowPersistenceMode;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::WorldFunctions;

				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::ForEachActor;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetActorCount;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetDeltaSeconds;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetRealTimeSeconds;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetTimeSeconds;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetCurrentLevelName;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetSimulatePhysics;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetWorldOrigin;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetActor;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetActorByTag;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetActorByID;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetFirstPlayerController;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::GetGameMode;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnActorBeginOverlapCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnActorBeginCursorOverCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnActorEndCursorOverCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnActorClickedCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnActorReleasedCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnActorEndOverlapCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnActorHitCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnComponentBeginOverlapCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnComponentEndOverlapCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnComponentHitCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnComponentBeginCursorOverCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnComponentEndCursorOverCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnComponentClickedCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetOnComponentReleasedCallback;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetSimulatePhysics;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetGravity;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SetWorldOrigin;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::OpenLevel;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::LineTraceTestByChannel;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::LineTraceTestByProfile;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::LineTraceSingleByChannel;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::LineTraceSingleByProfile;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SweepTestByChannel;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SweepTestByProfile;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SweepSingleByChannel;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::SweepSingleByProfile;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::OverlapAnyTestByChannel;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::OverlapAnyTestByProfile;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::OverlapBlockingTestByChannel;
				Shared::WorldFunctions[head++] = (void*)&UnrealCLRFramework::World::OverlapBlockingTestByProfile;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::AssetFunctions;

				Shared::AssetFunctions[head++] = (void*)&UnrealCLRFramework::Asset::IsValid;
				Shared::AssetFunctions[head++] = (void*)&UnrealCLRFramework::Asset::GetName;
				Shared::AssetFunctions[head++] = (void*)&UnrealCLRFramework::Asset::GetPath;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::AssetRegistryFunctions;

				Shared::AssetRegistryFunctions[head++] = (void*)&UnrealCLRFramework::AssetRegistry::Get;
				Shared::AssetRegistryFunctions[head++] = (void*)&UnrealCLRFramework::AssetRegistry::HasAssets;
				Shared::AssetRegistryFunctions[head++] = (void*)&UnrealCLRFramework::AssetRegistry::ForEachAsset;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::BlueprintFunctions;

				Shared::BlueprintFunctions[head++] = (void*)&UnrealCLRFramework::Blueprint::IsValidActorClass;
				Shared::BlueprintFunctions[head++] = (void*)&UnrealCLRFramework::Blueprint::IsValidComponentClass;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ConsoleObjectFunctions;

				Shared::ConsoleObjectFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleObject::IsBool;
				Shared::ConsoleObjectFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleObject::IsInt;
				Shared::ConsoleObjectFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleObject::IsFloat;
				Shared::ConsoleObjectFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleObject::IsString;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ConsoleVariableFunctions;

				Shared::ConsoleVariableFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleVariable::GetBool;
				Shared::ConsoleVariableFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleVariable::GetInt;
				Shared::ConsoleVariableFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleVariable::GetFloat;
				Shared::ConsoleVariableFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleVariable::GetString;
				Shared::ConsoleVariableFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleVariable::SetBool;
				Shared::ConsoleVariableFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleVariable::SetInt;
				Shared::ConsoleVariableFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleVariable::SetFloat;
				Shared::ConsoleVariableFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleVariable::SetString;
				Shared::ConsoleVariableFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleVariable::SetOnChangedCallback;
				Shared::ConsoleVariableFunctions[head++] = (void*)&UnrealCLRFramework::ConsoleVariable::ClearOnChangedCallback;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ActorFunctions;

				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::IsPendingKill;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::IsRootComponentMovable;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::IsOverlappingActor;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::ForEachComponent;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::ForEachAttachedActor;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::ForEachChildActor;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::ForEachOverlappingActor;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::Spawn;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::Destroy;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::Rename;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::Hide;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::TeleportTo;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::GetComponent;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::GetComponentByTag;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::GetComponentByID;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::GetRootComponent;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::GetInputComponent;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::GetCreationTime;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::GetBlockInput;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::GetDistanceTo;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::GetHorizontalDistanceTo;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::GetBounds;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::GetEyesViewPoint;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::SetRootComponent;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::SetInputComponent;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::SetBlockInput;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::SetLifeSpan;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::SetEnableInput;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::SetEnableCollision;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::AddTag;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::RemoveTag;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::HasTag;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::RegisterEvent;
				Shared::ActorFunctions[head++] = (void*)&UnrealCLRFramework::Actor::UnregisterEvent;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::GameModeBaseFunctions;

				Shared::GameModeBaseFunctions[head++] = (void*)&UnrealCLRFramework::GameModeBase::GetUseSeamlessTravel;
				Shared::GameModeBaseFunctions[head++] = (void*)&UnrealCLRFramework::GameModeBase::SetUseSeamlessTravel;
				Shared::GameModeBaseFunctions[head++] = (void*)&UnrealCLRFramework::GameModeBase::SwapPlayerControllers;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PawnFunctions;

				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::IsControlled;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::IsPlayerControlled;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::GetAutoPossessAI;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::GetAutoPossessPlayer;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::GetUseControllerRotationYaw;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::GetUseControllerRotationPitch;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::GetUseControllerRotationRoll;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::GetGravityDirection;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::GetAIController;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::GetPlayerController;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::SetAutoPossessAI;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::SetAutoPossessPlayer;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::SetUseControllerRotationYaw;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::SetUseControllerRotationPitch;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::SetUseControllerRotationRoll;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::AddControllerYawInput;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::AddControllerPitchInput;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::AddControllerRollInput;
				Shared::PawnFunctions[head++] = (void*)&UnrealCLRFramework::Pawn::AddMovementInput;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::CharacterFunctions;

				Shared::CharacterFunctions[head++] = (void*)&UnrealCLRFramework::Character::IsCrouched;
				Shared::CharacterFunctions[head++] = (void*)&UnrealCLRFramework::Character::CanCrouch;
				Shared::CharacterFunctions[head++] = (void*)&UnrealCLRFramework::Character::CanJump;
				Shared::CharacterFunctions[head++] = (void*)&UnrealCLRFramework::Character::CheckJumpInput;
				Shared::CharacterFunctions[head++] = (void*)&UnrealCLRFramework::Character::ClearJumpInput;
				Shared::CharacterFunctions[head++] = (void*)&UnrealCLRFramework::Character::Launch;
				Shared::CharacterFunctions[head++] = (void*)&UnrealCLRFramework::Character::Crouch;
				Shared::CharacterFunctions[head++] = (void*)&UnrealCLRFramework::Character::StopCrouching;
				Shared::CharacterFunctions[head++] = (void*)&UnrealCLRFramework::Character::Jump;
				Shared::CharacterFunctions[head++] = (void*)&UnrealCLRFramework::Character::StopJumping;
				Shared::CharacterFunctions[head++] = (void*)&UnrealCLRFramework::Character::SetOnLandedCallback;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ControllerFunctions;

				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::IsLookInputIgnored;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::IsMoveInputIgnored;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::IsPlayerController;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::GetPawn;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::GetCharacter;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::GetViewTarget;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::GetControlRotation;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::GetDesiredRotation;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::LineOfSightTo;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::SetControlRotation;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::SetInitialLocationAndRotation;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::SetIgnoreLookInput;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::SetIgnoreMoveInput;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::ResetIgnoreLookInput;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::ResetIgnoreMoveInput;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::Possess;
				Shared::ControllerFunctions[head++] = (void*)&UnrealCLRFramework::Controller::Unpossess;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::AIControllerFunctions;

				Shared::AIControllerFunctions[head++] = (void*)&UnrealCLRFramework::AIController::ClearFocus;
				Shared::AIControllerFunctions[head++] = (void*)&UnrealCLRFramework::AIController::GetFocalPoint;
				Shared::AIControllerFunctions[head++] = (void*)&UnrealCLRFramework::AIController::SetFocalPoint;
				Shared::AIControllerFunctions[head++] = (void*)&UnrealCLRFramework::AIController::GetFocusActor;
				Shared::AIControllerFunctions[head++] = (void*)&UnrealCLRFramework::AIController::GetAllowStrafe;
				Shared::AIControllerFunctions[head++] = (void*)&UnrealCLRFramework::AIController::SetAllowStrafe;
				Shared::AIControllerFunctions[head++] = (void*)&UnrealCLRFramework::AIController::SetFocus;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PlayerControllerFunctions;

				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::IsPaused;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::GetShowMouseCursor;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::GetEnableClickEvents;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::GetEnableMouseOverEvents;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::GetMousePosition;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::GetPlayer;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::GetPlayerInput;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::GetHitResultAtScreenPosition;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::GetHitResultUnderCursor;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::SetShowMouseCursor;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::SetEnableClickEvents;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::SetEnableMouseOverEvents;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::SetMousePosition;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::ConsoleCommand;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::SetPause;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::SetViewTarget;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::SetViewTargetWithBlend;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::AddYawInput;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::AddPitchInput;
				Shared::PlayerControllerFunctions[head++] = (void*)&UnrealCLRFramework::PlayerController::AddRollInput;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::VolumeFunctions;

				Shared::VolumeFunctions[head++] = (void*)&UnrealCLRFramework::Volume::EncompassesPoint;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PostProcessVolumeFunctions;

				Shared::PostProcessVolumeFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessVolume::GetEnabled;
				Shared::PostProcessVolumeFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessVolume::GetBlendRadius;
				Shared::PostProcessVolumeFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessVolume::GetBlendWeight;
				Shared::PostProcessVolumeFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessVolume::GetUnbound;
				Shared::PostProcessVolumeFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessVolume::GetPriority;
				Shared::PostProcessVolumeFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessVolume::SetEnabled;
				Shared::PostProcessVolumeFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessVolume::SetBlendRadius;
				Shared::PostProcessVolumeFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessVolume::SetBlendWeight;
				Shared::PostProcessVolumeFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessVolume::SetUnbound;
				Shared::PostProcessVolumeFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessVolume::SetPriority;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SoundBaseFunctions;

				Shared::SoundBaseFunctions[head++] = (void*)&UnrealCLRFramework::SoundBase::GetDuration;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SoundWaveFunctions;

				Shared::SoundWaveFunctions[head++] = (void*)&UnrealCLRFramework::SoundWave::GetLoop;
				Shared::SoundWaveFunctions[head++] = (void*)&UnrealCLRFramework::SoundWave::SetLoop;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::AnimationInstanceFunctions;

				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::GetCurrentActiveMontage;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::IsPlaying;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::GetPlayRate;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::GetPosition;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::GetBlendTime;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::GetCurrentSection;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::SetPlayRate;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::SetPosition;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::SetNextSection;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::PlayMontage;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::PauseMontage;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::ResumeMontage;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::StopMontage;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::JumpToSection;
				Shared::AnimationInstanceFunctions[head++] = (void*)&UnrealCLRFramework::AnimationInstance::JumpToSectionsEnd;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PlayerFunctions;

				Shared::PlayerFunctions[head++] = (void*)&UnrealCLRFramework::Player::GetPlayerController;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PlayerInputFunctions;

				Shared::PlayerInputFunctions[head++] = (void*)&UnrealCLRFramework::PlayerInput::IsKeyPressed;
				Shared::PlayerInputFunctions[head++] = (void*)&UnrealCLRFramework::PlayerInput::GetTimeKeyPressed;
				Shared::PlayerInputFunctions[head++] = (void*)&UnrealCLRFramework::PlayerInput::GetMouseSensitivity;
				Shared::PlayerInputFunctions[head++] = (void*)&UnrealCLRFramework::PlayerInput::SetMouseSensitivity;
				Shared::PlayerInputFunctions[head++] = (void*)&UnrealCLRFramework::PlayerInput::AddActionMapping;
				Shared::PlayerInputFunctions[head++] = (void*)&UnrealCLRFramework::PlayerInput::AddAxisMapping;
				Shared::PlayerInputFunctions[head++] = (void*)&UnrealCLRFramework::PlayerInput::RemoveActionMapping;
				Shared::PlayerInputFunctions[head++] = (void*)&UnrealCLRFramework::PlayerInput::RemoveAxisMapping;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::FontFunctions;

				Shared::FontFunctions[head++] = (void*)&UnrealCLRFramework::Font::GetStringSize;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::Texture2DFunctions;

				Shared::Texture2DFunctions[head++] = (void*)&UnrealCLRFramework::Texture2D::CreateFromFile;
				Shared::Texture2DFunctions[head++] = (void*)&UnrealCLRFramework::Texture2D::CreateFromBuffer;
				Shared::Texture2DFunctions[head++] = (void*)&UnrealCLRFramework::Texture2D::HasAlphaChannel;
				Shared::Texture2DFunctions[head++] = (void*)&UnrealCLRFramework::Texture2D::GetSize;
				Shared::Texture2DFunctions[head++] = (void*)&UnrealCLRFramework::Texture2D::GetPixelFormat;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ActorComponentFunctions;

				Shared::ActorComponentFunctions[head++] = (void*)&UnrealCLRFramework::ActorComponent::IsOwnerSelected;
				Shared::ActorComponentFunctions[head++] = (void*)&UnrealCLRFramework::ActorComponent::GetOwner;
				Shared::ActorComponentFunctions[head++] = (void*)&UnrealCLRFramework::ActorComponent::Destroy;
				Shared::ActorComponentFunctions[head++] = (void*)&UnrealCLRFramework::ActorComponent::AddTag;
				Shared::ActorComponentFunctions[head++] = (void*)&UnrealCLRFramework::ActorComponent::RemoveTag;
				Shared::ActorComponentFunctions[head++] = (void*)&UnrealCLRFramework::ActorComponent::HasTag;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::InputComponentFunctions;

				Shared::InputComponentFunctions[head++] = (void*)&UnrealCLRFramework::InputComponent::HasBindings;
				Shared::InputComponentFunctions[head++] = (void*)&UnrealCLRFramework::InputComponent::GetActionBindingsNumber;
				Shared::InputComponentFunctions[head++] = (void*)&UnrealCLRFramework::InputComponent::ClearActionBindings;
				Shared::InputComponentFunctions[head++] = (void*)&UnrealCLRFramework::InputComponent::BindAction;
				Shared::InputComponentFunctions[head++] = (void*)&UnrealCLRFramework::InputComponent::BindAxis;
				Shared::InputComponentFunctions[head++] = (void*)&UnrealCLRFramework::InputComponent::RemoveActionBinding;
				Shared::InputComponentFunctions[head++] = (void*)&UnrealCLRFramework::InputComponent::GetBlockInput;
				Shared::InputComponentFunctions[head++] = (void*)&UnrealCLRFramework::InputComponent::SetBlockInput;
				Shared::InputComponentFunctions[head++] = (void*)&UnrealCLRFramework::InputComponent::GetPriority;
				Shared::InputComponentFunctions[head++] = (void*)&UnrealCLRFramework::InputComponent::SetPriority;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SceneComponentFunctions;

				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::IsAttachedToComponent;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::IsAttachedToActor;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::IsVisible;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::IsSocketExists;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::HasAnySockets;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::CanAttachAsChild;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::ForEachAttachedChild;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::Create;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::AttachToComponent;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::DetachFromComponent;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::Activate;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::Deactivate;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::UpdateToWorld;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::AddLocalOffset;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::AddLocalRotation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::AddRelativeLocation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::AddRelativeRotation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::AddLocalTransform;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::AddWorldOffset;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::AddWorldRotation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::AddWorldTransform;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetAttachedSocketName;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetBounds;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetSocketLocation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetSocketRotation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetComponentVelocity;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetComponentLocation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetComponentRotation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetComponentScale;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetComponentTransform;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetForwardVector;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetRightVector;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::GetUpVector;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::SetMobility;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::SetVisibility;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::SetRelativeLocation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::SetRelativeRotation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::SetRelativeTransform;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::SetWorldLocation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::SetWorldRotation;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::SetWorldScale;
				Shared::SceneComponentFunctions[head++] = (void*)&UnrealCLRFramework::SceneComponent::SetWorldTransform;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::AudioComponentFunctions;

				Shared::AudioComponentFunctions[head++] = (void*)&UnrealCLRFramework::AudioComponent::IsPlaying;
				Shared::AudioComponentFunctions[head++] = (void*)&UnrealCLRFramework::AudioComponent::GetPaused;
				Shared::AudioComponentFunctions[head++] = (void*)&UnrealCLRFramework::AudioComponent::SetSound;
				Shared::AudioComponentFunctions[head++] = (void*)&UnrealCLRFramework::AudioComponent::SetPaused;
				Shared::AudioComponentFunctions[head++] = (void*)&UnrealCLRFramework::AudioComponent::Play;
				Shared::AudioComponentFunctions[head++] = (void*)&UnrealCLRFramework::AudioComponent::Stop;
				Shared::AudioComponentFunctions[head++] = (void*)&UnrealCLRFramework::AudioComponent::FadeIn;
				Shared::AudioComponentFunctions[head++] = (void*)&UnrealCLRFramework::AudioComponent::FadeOut;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::CameraComponentFunctions;

				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::GetConstrainAspectRatio;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::GetAspectRatio;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::GetFieldOfView;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::GetOrthoFarClipPlane;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::GetOrthoNearClipPlane;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::GetOrthoWidth;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::GetLockToHeadMountedDisplay;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::SetProjectionMode;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::SetConstrainAspectRatio;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::SetAspectRatio;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::SetFieldOfView;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::SetOrthoFarClipPlane;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::SetOrthoNearClipPlane;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::SetOrthoWidth;
				Shared::CameraComponentFunctions[head++] = (void*)&UnrealCLRFramework::CameraComponent::SetLockToHeadMountedDisplay;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ChildActorComponentFunctions;

				Shared::ChildActorComponentFunctions[head++] = (void*)&UnrealCLRFramework::ChildActorComponent::GetChildActor;
				Shared::ChildActorComponentFunctions[head++] = (void*)&UnrealCLRFramework::ChildActorComponent::SetChildActor;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SpringArmComponentFunctions;

				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::IsCollisionFixApplied;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetDrawDebugLagMarkers;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetCollisionTest;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetCameraPositionLag;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetCameraRotationLag;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetCameraLagSubstepping;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetInheritPitch;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetInheritRoll;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetInheritYaw;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetCameraLagMaxDistance;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetCameraLagMaxTimeStep;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetCameraPositionLagSpeed;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetCameraRotationLagSpeed;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetProbeChannel;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetProbeSize;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetSocketOffset;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetTargetArmLength;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetTargetOffset;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetUnfixedCameraPosition;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetDesiredRotation;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetTargetRotation;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::GetUsePawnControlRotation;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetDrawDebugLagMarkers;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetCollisionTest;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetCameraPositionLag;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetCameraRotationLag;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetCameraLagSubstepping;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetInheritPitch;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetInheritRoll;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetInheritYaw;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetCameraLagMaxDistance;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetCameraLagMaxTimeStep;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetCameraPositionLagSpeed;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetCameraRotationLagSpeed;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetProbeChannel;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetProbeSize;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetSocketOffset;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetTargetArmLength;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetTargetOffset;
				Shared::SpringArmComponentFunctions[head++] = (void*)&UnrealCLRFramework::SpringArmComponent::SetUsePawnControlRotation;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PostProcessComponentFunctions;

				Shared::PostProcessComponentFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessComponent::GetEnabled;
				Shared::PostProcessComponentFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessComponent::GetBlendRadius;
				Shared::PostProcessComponentFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessComponent::GetBlendWeight;
				Shared::PostProcessComponentFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessComponent::GetUnbound;
				Shared::PostProcessComponentFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessComponent::GetPriority;
				Shared::PostProcessComponentFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessComponent::SetEnabled;
				Shared::PostProcessComponentFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessComponent::SetBlendRadius;
				Shared::PostProcessComponentFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessComponent::SetBlendWeight;
				Shared::PostProcessComponentFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessComponent::SetUnbound;
				Shared::PostProcessComponentFunctions[head++] = (void*)&UnrealCLRFramework::PostProcessComponent::SetPriority;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::PrimitiveComponentFunctions;

				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::IsGravityEnabled;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::IsOverlappingComponent;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::ForEachOverlappingComponent;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::AddAngularImpulseInDegrees;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::AddAngularImpulseInRadians;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::AddForce;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::AddForceAtLocation;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::AddImpulse;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::AddImpulseAtLocation;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::AddRadialForce;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::AddRadialImpulse;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::AddTorqueInDegrees;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::AddTorqueInRadians;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetMass;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetPhysicsLinearVelocity;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetPhysicsLinearVelocityAtPoint;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetPhysicsAngularVelocityInDegrees;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetPhysicsAngularVelocityInRadians;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetCastShadow;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetOnlyOwnerSee;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetOwnerNoSee;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetIgnoreRadialForce;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetIgnoreRadialImpulse;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetMaterial;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetMaterialsNumber;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetDistanceToCollision;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetSquaredDistanceToCollision;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetAngularDamping;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::GetLinearDamping;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetGenerateOverlapEvents;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetGenerateHitEvents;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetMass;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetCenterOfMass;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetPhysicsLinearVelocity;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetPhysicsAngularVelocityInDegrees;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetPhysicsAngularVelocityInRadians;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetPhysicsMaxAngularVelocityInDegrees;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetPhysicsMaxAngularVelocityInRadians;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetCastShadow;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetOnlyOwnerSee;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetOwnerNoSee;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetIgnoreRadialForce;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetIgnoreRadialImpulse;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetMaterial;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetSimulatePhysics;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetAngularDamping;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetLinearDamping;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetEnableGravity;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetCollisionMode;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetCollisionChannel;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetCollisionProfileName;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetCollisionResponseToChannel;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetCollisionResponseToAllChannels;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetIgnoreActorWhenMoving;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::SetIgnoreComponentWhenMoving;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::ClearMoveIgnoreActors;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::ClearMoveIgnoreComponents;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::CreateAndSetMaterialInstanceDynamic;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::RegisterEvent;
				Shared::PrimitiveComponentFunctions[head++] = (void*)&UnrealCLRFramework::PrimitiveComponent::UnregisterEvent;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::ShapeComponentFunctions;

				Shared::ShapeComponentFunctions[head++] = (void*)&UnrealCLRFramework::ShapeComponent::GetDynamicObstacle;
				Shared::ShapeComponentFunctions[head++] = (void*)&UnrealCLRFramework::ShapeComponent::GetShapeColor;
				Shared::ShapeComponentFunctions[head++] = (void*)&UnrealCLRFramework::ShapeComponent::SetDynamicObstacle;
				Shared::ShapeComponentFunctions[head++] = (void*)&UnrealCLRFramework::ShapeComponent::SetShapeColor;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::BoxComponentFunctions;

				Shared::BoxComponentFunctions[head++] = (void*)&UnrealCLRFramework::BoxComponent::GetScaledBoxExtent;
				Shared::BoxComponentFunctions[head++] = (void*)&UnrealCLRFramework::BoxComponent::GetUnscaledBoxExtent;
				Shared::BoxComponentFunctions[head++] = (void*)&UnrealCLRFramework::BoxComponent::SetBoxExtent;
				Shared::BoxComponentFunctions[head++] = (void*)&UnrealCLRFramework::BoxComponent::InitBoxExtent;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SphereComponentFunctions;

				Shared::SphereComponentFunctions[head++] = (void*)&UnrealCLRFramework::SphereComponent::GetScaledSphereRadius;
				Shared::SphereComponentFunctions[head++] = (void*)&UnrealCLRFramework::SphereComponent::GetUnscaledSphereRadius;
				Shared::SphereComponentFunctions[head++] = (void*)&UnrealCLRFramework::SphereComponent::GetShapeScale;
				Shared::SphereComponentFunctions[head++] = (void*)&UnrealCLRFramework::SphereComponent::SetSphereRadius;
				Shared::SphereComponentFunctions[head++] = (void*)&UnrealCLRFramework::SphereComponent::InitSphereRadius;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::CapsuleComponentFunctions;

				Shared::CapsuleComponentFunctions[head++] = (void*)&UnrealCLRFramework::CapsuleComponent::GetScaledCapsuleRadius;
				Shared::CapsuleComponentFunctions[head++] = (void*)&UnrealCLRFramework::CapsuleComponent::GetUnscaledCapsuleRadius;
				Shared::CapsuleComponentFunctions[head++] = (void*)&UnrealCLRFramework::CapsuleComponent::GetShapeScale;
				Shared::CapsuleComponentFunctions[head++] = (void*)&UnrealCLRFramework::CapsuleComponent::GetScaledCapsuleSize;
				Shared::CapsuleComponentFunctions[head++] = (void*)&UnrealCLRFramework::CapsuleComponent::GetUnscaledCapsuleSize;
				Shared::CapsuleComponentFunctions[head++] = (void*)&UnrealCLRFramework::CapsuleComponent::SetCapsuleRadius;
				Shared::CapsuleComponentFunctions[head++] = (void*)&UnrealCLRFramework::CapsuleComponent::SetCapsuleSize;
				Shared::CapsuleComponentFunctions[head++] = (void*)&UnrealCLRFramework::CapsuleComponent::InitCapsuleSize;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MeshComponentFunctions;

				Shared::MeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::MeshComponent::IsValidMaterialSlotName;
				Shared::MeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::MeshComponent::GetMaterialIndex;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::TextRenderComponentFunctions;

				Shared::TextRenderComponentFunctions[head++] = (void*)&UnrealCLRFramework::TextRenderComponent::SetFont;
				Shared::TextRenderComponentFunctions[head++] = (void*)&UnrealCLRFramework::TextRenderComponent::SetText;
				Shared::TextRenderComponentFunctions[head++] = (void*)&UnrealCLRFramework::TextRenderComponent::SetTextMaterial;
				Shared::TextRenderComponentFunctions[head++] = (void*)&UnrealCLRFramework::TextRenderComponent::SetTextRenderColor;
				Shared::TextRenderComponentFunctions[head++] = (void*)&UnrealCLRFramework::TextRenderComponent::SetHorizontalAlignment;
				Shared::TextRenderComponentFunctions[head++] = (void*)&UnrealCLRFramework::TextRenderComponent::SetHorizontalSpacingAdjustment;
				Shared::TextRenderComponentFunctions[head++] = (void*)&UnrealCLRFramework::TextRenderComponent::SetVerticalAlignment;
				Shared::TextRenderComponentFunctions[head++] = (void*)&UnrealCLRFramework::TextRenderComponent::SetVerticalSpacingAdjustment;
				Shared::TextRenderComponentFunctions[head++] = (void*)&UnrealCLRFramework::TextRenderComponent::SetScale;
				Shared::TextRenderComponentFunctions[head++] = (void*)&UnrealCLRFramework::TextRenderComponent::SetWorldSize;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::LightComponentBaseFunctions;

				Shared::LightComponentBaseFunctions[head++] = (void*)&UnrealCLRFramework::LightComponentBase::GetIntensity;
				Shared::LightComponentBaseFunctions[head++] = (void*)&UnrealCLRFramework::LightComponentBase::GetCastShadows;
				Shared::LightComponentBaseFunctions[head++] = (void*)&UnrealCLRFramework::LightComponentBase::SetCastShadows;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::LightComponentFunctions;

				Shared::LightComponentFunctions[head++] = (void*)&UnrealCLRFramework::LightComponent::SetIntensity;
				Shared::LightComponentFunctions[head++] = (void*)&UnrealCLRFramework::LightComponent::SetLightColor;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MotionControllerComponentFunctions;

				Shared::MotionControllerComponentFunctions[head++] = (void*)&UnrealCLRFramework::MotionControllerComponent::IsTracked;
				Shared::MotionControllerComponentFunctions[head++] = (void*)&UnrealCLRFramework::MotionControllerComponent::GetDisplayDeviceModel;
				Shared::MotionControllerComponentFunctions[head++] = (void*)&UnrealCLRFramework::MotionControllerComponent::GetDisableLowLatencyUpdate;
				Shared::MotionControllerComponentFunctions[head++] = (void*)&UnrealCLRFramework::MotionControllerComponent::GetTrackingSource;
				Shared::MotionControllerComponentFunctions[head++] = (void*)&UnrealCLRFramework::MotionControllerComponent::SetDisplayDeviceModel;
				Shared::MotionControllerComponentFunctions[head++] = (void*)&UnrealCLRFramework::MotionControllerComponent::SetDisableLowLatencyUpdate;
				Shared::MotionControllerComponentFunctions[head++] = (void*)&UnrealCLRFramework::MotionControllerComponent::SetTrackingSource;
				Shared::MotionControllerComponentFunctions[head++] = (void*)&UnrealCLRFramework::MotionControllerComponent::SetTrackingMotionSource;
				Shared::MotionControllerComponentFunctions[head++] = (void*)&UnrealCLRFramework::MotionControllerComponent::SetAssociatedPlayerIndex;
				Shared::MotionControllerComponentFunctions[head++] = (void*)&UnrealCLRFramework::MotionControllerComponent::SetCustomDisplayMesh;
				Shared::MotionControllerComponentFunctions[head++] = (void*)&UnrealCLRFramework::MotionControllerComponent::SetDisplayModelSource;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::StaticMeshComponentFunctions;

				Shared::StaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::StaticMeshComponent::GetLocalBounds;
				Shared::StaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::StaticMeshComponent::GetStaticMesh;
				Shared::StaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::StaticMeshComponent::SetStaticMesh;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::InstancedStaticMeshComponentFunctions;

				Shared::InstancedStaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::InstancedStaticMeshComponent::GetInstanceCount;
				Shared::InstancedStaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::InstancedStaticMeshComponent::GetInstanceTransform;
				Shared::InstancedStaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::InstancedStaticMeshComponent::AddInstance;
				Shared::InstancedStaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::InstancedStaticMeshComponent::AddInstances;
				Shared::InstancedStaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::InstancedStaticMeshComponent::UpdateInstanceTransform;
				Shared::InstancedStaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::InstancedStaticMeshComponent::BatchUpdateInstanceTransforms;
				Shared::InstancedStaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::InstancedStaticMeshComponent::RemoveInstance;
				Shared::InstancedStaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::InstancedStaticMeshComponent::ClearInstances;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::HierarchicalInstancedStaticMeshComponentFunctions;

				Shared::HierarchicalInstancedStaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::HierarchicalInstancedStaticMeshComponent::GetDisableCollision;
				Shared::HierarchicalInstancedStaticMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::HierarchicalInstancedStaticMeshComponent::SetDisableCollision;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SkinnedMeshComponentFunctions;

				Shared::SkinnedMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkinnedMeshComponent::GetBonesNumber;
				Shared::SkinnedMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkinnedMeshComponent::GetBoneIndex;
				Shared::SkinnedMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkinnedMeshComponent::GetBoneName;
				Shared::SkinnedMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkinnedMeshComponent::GetBoneTransform;
				Shared::SkinnedMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkinnedMeshComponent::SetSkeletalMesh;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SkeletalMeshComponentFunctions;

				Shared::SkeletalMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkeletalMeshComponent::IsPlaying;
				Shared::SkeletalMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkeletalMeshComponent::GetAnimationInstance;
				Shared::SkeletalMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkeletalMeshComponent::SetAnimation;
				Shared::SkeletalMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkeletalMeshComponent::SetAnimationMode;
				Shared::SkeletalMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkeletalMeshComponent::SetAnimationBlueprint;
				Shared::SkeletalMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkeletalMeshComponent::Play;
				Shared::SkeletalMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkeletalMeshComponent::PlayAnimation;
				Shared::SkeletalMeshComponentFunctions[head++] = (void*)&UnrealCLRFramework::SkeletalMeshComponent::Stop;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::SplineComponentFunctions;

				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::IsClosedLoop;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetDuration;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetSplinePointType;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetSplinePointsNumber;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetSplineSegmentsNumber;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetTangentAtDistanceAlongSpline;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetTangentAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetTangentAtTime;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetTransformAtDistanceAlongSpline;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetTransformAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetArriveTangentAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetDefaultUpVector;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetDirectionAtDistanceAlongSpline;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetDirectionAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetDirectionAtTime;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetDistanceAlongSplineAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetLeaveTangentAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetLocationAndTangentAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetLocationAtDistanceAlongSpline;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetLocationAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetLocationAtTime;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetRightVectorAtDistanceAlongSpline;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetRightVectorAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetRightVectorAtTime;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetRollAtDistanceAlongSpline;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetRollAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetRollAtTime;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetRotationAtDistanceAlongSpline;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetRotationAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetRotationAtTime;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetScaleAtDistanceAlongSpline;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetScaleAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetScaleAtTime;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetSplineLength;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetTransformAtTime;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetUpVectorAtDistanceAlongSpline;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetUpVectorAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::GetUpVectorAtTime;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::SetDuration;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::SetSplinePointType;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::SetClosedLoop;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::SetDefaultUpVector;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::SetLocationAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::SetTangentAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::SetTangentsAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::SetUpVectorAtSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::AddSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::AddSplinePointAtIndex;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::ClearSplinePoints;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::FindDirectionClosestToWorldLocation;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::FindLocationClosestToWorldLocation;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::FindUpVectorClosestToWorldLocation;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::FindRightVectorClosestToWorldLocation;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::FindRollClosestToWorldLocation;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::FindScaleClosestToWorldLocation;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::FindTangentClosestToWorldLocation;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::FindTransformClosestToWorldLocation;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::RemoveSplinePoint;
				Shared::SplineComponentFunctions[head++] = (void*)&UnrealCLRFramework::SplineComponent::UpdateSpline;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::RadialForceComponentFunctions;

				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::GetIgnoreOwningActor;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::GetImpulseVelocityChange;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::GetLinearFalloff;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::GetForceStrength;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::GetImpulseStrength;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::GetRadius;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::SetIgnoreOwningActor;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::SetImpulseVelocityChange;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::SetLinearFalloff;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::SetForceStrength;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::SetImpulseStrength;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::SetRadius;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::AddCollisionChannelToAffect;
				Shared::RadialForceComponentFunctions[head++] = (void*)&UnrealCLRFramework::RadialForceComponent::FireImpulse;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MaterialInterfaceFunctions;

				Shared::MaterialInterfaceFunctions[head++] = (void*)&UnrealCLRFramework::MaterialInterface::IsTwoSided;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MaterialFunctions;

				Shared::MaterialFunctions[head++] = (void*)&UnrealCLRFramework::Material::IsDefaultMaterial;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MaterialInstanceFunctions;

				Shared::MaterialInstanceFunctions[head++] = (void*)&UnrealCLRFramework::MaterialInstance::IsChildOf;
				Shared::MaterialInstanceFunctions[head++] = (void*)&UnrealCLRFramework::MaterialInstance::GetParent;

				checksum += head;
			}

			{
				int32 head = 0;
				Shared::Functions[position++] = Shared::MaterialInstanceDynamicFunctions;

				Shared::MaterialInstanceDynamicFunctions[head++] = (void*)&UnrealCLRFramework::MaterialInstanceDynamic::ClearParameterValues;
				Shared::MaterialInstanceDynamicFunctions[head++] = (void*)&UnrealCLRFramework::MaterialInstanceDynamic::SetTextureParameterValue;
				Shared::MaterialInstanceDynamicFunctions[head++] = (void*)&UnrealCLRFramework::MaterialInstanceDynamic::SetVectorParameterValue;
				Shared::MaterialInstanceDynamicFunctions[head++] = (void*)&UnrealCLRFramework::MaterialInstanceDynamic::SetScalarParameterValue;

				checksum += head;
			}

			checksum += position;

			// Runtime pointers

			Shared::RuntimeFunctions[0] = (void*)&UnrealCLR::Module::Exception;
			Shared::RuntimeFunctions[1] = (void*)&UnrealCLR::Module::Log;

			constexpr void* functions[3] = {
				Shared::RuntimeFunctions,
				Shared::Events,
				Shared::Functions
			};

			if (reinterpret_cast<intptr_t>(UnrealCLR::ManagedCommand(UnrealCLR::Command(functions, checksum))) == 0xF) {
				UE_LOG(LogUnrealCLR, Display, TEXT("%s: Host runtime assembly initialized succesfuly!"), ANSI_TO_TCHAR(__FUNCTION__));
			} else {
				UE_LOG(LogUnrealCLR, Error, TEXT("%s: Host runtime assembly initialization failed!"), ANSI_TO_TCHAR(__FUNCTION__));

				return;
			}

			UnrealCLR::Engine::Manager = NewObject<UUnrealCLRManager>();
			UnrealCLR::Engine::Manager->AddToRoot();
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
	if (UnrealCLR::Engine::Manager) {
		UnrealCLR::Engine::Manager->RemoveFromRoot();
		UnrealCLR::Engine::Manager = nullptr;
	}

	FWorldDelegates::OnPostWorldInitialization.Remove(OnWorldPostInitializationHandle);
	FWorldDelegates::OnWorldCleanup.Remove(OnWorldCleanupHandle);

	FPlatformProcess::FreeDllHandle(HostfxrLibrary);
}

void UnrealCLR::Module::OnWorldPostInitialization(UWorld* World, const UWorld::InitializationValues InitializationValues) {
	if (World->IsGameWorld()) {
		if (UnrealCLR::WorldTickState == TickState::Stopped) {
			UnrealCLR::Engine::World = World;

			if (UnrealCLR::Status != UnrealCLR::StatusType::Stopped) {
				UnrealCLR::ManagedCommand(UnrealCLR::Command(CommandType::LoadAssemblies));
				UnrealCLR::Status = UnrealCLR::StatusType::Running;

				for (TActorIterator<AWorldSettings> currentActor(UnrealCLR::Engine::World); currentActor; ++currentActor) {
					RegisterTickFunction(OnPrePhysicsTickFunction, TG_PrePhysics, *currentActor);
					RegisterTickFunction(OnDuringPhysicsTickFunction, TG_DuringPhysics, *currentActor);
					RegisterTickFunction(OnPostPhysicsTickFunction, TG_PostPhysics, *currentActor);
					RegisterTickFunction(OnPostUpdateTickFunction, TG_PostUpdateWork, *currentActor);

					UnrealCLR::WorldTickState = UnrealCLR::TickState::Registered;

					if (UnrealCLR::Shared::Events[OnWorldBegin])
						UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[OnWorldBegin]));

					break;
				}
			} else {
				#if WITH_EDITOR
					FNotificationInfo notificationInfo(FText::FromString(TEXT("UnrealCLR host is not initialized! Please, check logs and try to restart the engine.")));

					notificationInfo.ExpireDuration = 5.0f;

					FSlateNotificationManager::Get().AddNotification(notificationInfo);
				#endif
			}
		}
	}
}

void UnrealCLR::Module::OnWorldCleanup(UWorld* World, bool SessionEnded, bool CleanupResources) {
	if (World->IsGameWorld() && World == UnrealCLR::Engine::World && UnrealCLR::WorldTickState != UnrealCLR::TickState::Stopped) {
		if (UnrealCLR::Status != UnrealCLR::StatusType::Stopped) {
			if (UnrealCLR::Shared::Events[OnWorldEnd])
				UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[OnWorldEnd]));

			OnPrePhysicsTickFunction.UnRegisterTickFunction();
			OnDuringPhysicsTickFunction.UnRegisterTickFunction();
			OnPostPhysicsTickFunction.UnRegisterTickFunction();
			OnPostUpdateTickFunction.UnRegisterTickFunction();

			UnrealCLR::ManagedCommand(UnrealCLR::Command(CommandType::UnloadAssemblies));
			UnrealCLR::Status = UnrealCLR::StatusType::Idle;
		}

		UnrealCLR::Engine::World = nullptr;
		UnrealCLR::WorldTickState = UnrealCLR::TickState::Stopped;

		FMemory::Memset(UnrealCLR::Shared::Events, 0, sizeof(UnrealCLR::Shared::Events));
	}
}

void UnrealCLR::Module::RegisterTickFunction(FTickFunction& TickFunction, ETickingGroup TickGroup, AWorldSettings* LevelActor) {
	TickFunction.bCanEverTick = true;
	TickFunction.bTickEvenWhenPaused = false;
	TickFunction.bStartWithTickEnabled = true;
	TickFunction.bHighPriority = true;
	TickFunction.bAllowTickOnDedicatedServer = true;
	TickFunction.bRunOnAnyThread = false;
	TickFunction.TickGroup = TickGroup;
	TickFunction.RegisterTickFunction(UnrealCLR::Engine::World->PersistentLevel);
	LevelActor->PrimaryActorTick.AddPrerequisite(UnrealCLR::Engine::Manager, TickFunction);
}

void UnrealCLR::Module::HostError(const char_t* Message) {
	UE_LOG(LogUnrealCLR, Error, TEXT("%s: %s"), ANSI_TO_TCHAR(__FUNCTION__), *FString(Message));
}

void UnrealCLR::Module::Exception(const char* Message) {
	FString message(ANSI_TO_TCHAR(Message));

	UE_LOG(LogUnrealCLR, Error, TEXT("%s: %s"), ANSI_TO_TCHAR(__FUNCTION__), *message);

	GEngine->AddOnScreenDebugMessage((uint64)-1, 10.0f, FColor::Red, *message);
}

void UnrealCLR::Module::Log(UnrealCLR::LogLevel Level, const char* Message) {
	#define UNREALCLR_LOG(Verbosity) UE_LOG(LogUnrealCLR, Verbosity, TEXT("%s: %s"), ANSI_TO_TCHAR(__FUNCTION__), *message);

	FString message(ANSI_TO_TCHAR(Message));

	if (Level == UnrealCLR::LogLevel::Display) {
		UNREALCLR_LOG(Display);
	} else if (Level == UnrealCLR::LogLevel::Warning) {
		UNREALCLR_LOG(Warning);

		GEngine->AddOnScreenDebugMessage((uint64)-1, 60.0f, FColor::Yellow, *message);
	} else if (Level == UnrealCLR::LogLevel::Error) {
		UNREALCLR_LOG(Error);

		GEngine->AddOnScreenDebugMessage((uint64)-1, 60.0f, FColor::Red, *message);
	} else if (Level == UnrealCLR::LogLevel::Fatal) {
		UNREALCLR_LOG(Error);

		GEngine->AddOnScreenDebugMessage((uint64)-1, 60.0f, FColor::Red, *message);

		UnrealCLR::Status = UnrealCLR::StatusType::Idle;
	}
}

void UnrealCLR::PrePhysicsTickFunction::ExecuteTick(float DeltaTime, enum ELevelTick TickType, ENamedThreads::Type CurrentThread, const FGraphEventRef& MyCompletionGraphEvent) {
	if (UnrealCLR::WorldTickState != UnrealCLR::TickState::Started && UnrealCLR::Shared::Events[OnWorldPostBegin]) {
		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[OnWorldPostBegin]));
		UnrealCLR::WorldTickState = UnrealCLR::TickState::Started;
	}

	if (UnrealCLR::Shared::Events[OnWorldPrePhysicsTick])
		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[OnWorldPrePhysicsTick], DeltaTime));
}

void UnrealCLR::DuringPhysicsTickFunction::ExecuteTick(float DeltaTime, enum ELevelTick TickType, ENamedThreads::Type CurrentThread, const FGraphEventRef& MyCompletionGraphEvent) {
	if (UnrealCLR::Shared::Events[OnWorldDuringPhysicsTick])
		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[OnWorldDuringPhysicsTick], DeltaTime));
}

void UnrealCLR::PostPhysicsTickFunction::ExecuteTick(float DeltaTime, enum ELevelTick TickType, ENamedThreads::Type CurrentThread, const FGraphEventRef& MyCompletionGraphEvent) {
	if (UnrealCLR::Shared::Events[OnWorldPostPhysicsTick])
		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[OnWorldPostPhysicsTick], DeltaTime));
}

void UnrealCLR::PostUpdateTickFunction::ExecuteTick(float DeltaTime, enum ELevelTick TickType, ENamedThreads::Type CurrentThread, const FGraphEventRef& MyCompletionGraphEvent) {
	if (UnrealCLR::Shared::Events[OnWorldPostUpdateTick])
		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[OnWorldPostUpdateTick], DeltaTime));
}

FString UnrealCLR::PrePhysicsTickFunction::DiagnosticMessage() {
	return TEXT("PrePhysicsTickFunction");
}

FString UnrealCLR::DuringPhysicsTickFunction::DiagnosticMessage() {
	return TEXT("DuringPhysicsTickFunction");
}

FString UnrealCLR::PostPhysicsTickFunction::DiagnosticMessage() {
	return TEXT("PostPhysicsTickFunction");
}

FString UnrealCLR::PostUpdateTickFunction::DiagnosticMessage() {
	return TEXT("PostUpdateTickFunction");
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
