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

#pragma once

// @third party code - BEGIN CoreCLR
#include "../../Dependencies/CoreCLR/includes/coreclr_delegates.h"
#include "../../Dependencies/CoreCLR/includes/hostfxr.h"
// @third party code - END CoreCLR

#include "AIController.h"
#include "Animation/AnimInstance.h"
#include "Camera/CameraActor.h"
#include "Camera/CameraComponent.h"
#include "Components/AudioComponent.h"
#include "Components/BoxComponent.h"
#include "Components/CapsuleComponent.h"
#include "Components/DirectionalLightComponent.h"
#include "Components/InputComponent.h"
#include "Components/LightComponent.h"
#include "Components/LightComponentBase.h"
#include "Components/ShapeComponent.h"
#include "Components/SphereComponent.h"
#include "DrawDebugHelpers.h"
#include "Engine/DirectionalLight.h"
#include "Engine/GameEngine.h"
#include "Engine/Light.h"
#include "Engine/PointLight.h"
#include "Engine/RectLight.h"
#include "Engine/SpotLight.h"
#include "Engine/TriggerBox.h"
#include "Engine/TriggerCapsule.h"
#include "Engine/TriggerSphere.h"
#include "EngineUtils.h"
#include "GameFramework/Actor.h"
#include "GameFramework/Character.h"
#include "GameFramework/PlayerController.h"
#include "GameFramework/PlayerInput.h"
#include "HeadMountedDisplayFunctionLibrary.h"
#include "Materials/MaterialInstanceDynamic.h"
#include "Misc/DefaultValueHelper.h"
#include "Modules/ModuleManager.h"
#include "MotionControllerComponent.h"
#include "PhysicsEngine/RadialForceComponent.h"
#include "Sound/AmbientSound.h"
#include "UnrealEngine.h"

#include "UnrealCLRFramework.h"
#include "UnrealCLRLibrary.h"

#if WITH_EDITOR
	#include "Editor.h"
	#include "Framework/Notifications/NotificationManager.h"
	#include "Widgets/Notifications/SNotificationList.h"
#endif

#define UNREALCLR_NONE
#define UNREALCLR_BRACKET_LEFT (
#define UNREALCLR_BRACKET_RIGHT )

UNREALCLR_API DECLARE_LOG_CATEGORY_EXTERN(LogUnrealCLR, Log, All);

namespace UnrealCLR {
	enum struct StatusType : int32 {
		Stopped,
		Idle,
		Running
	};

	enum struct LogLevel : int32 {
		Display,
		Warning,
		Error
	};

	typedef void (*ExecuteAssemblyFunctionDelegate)(void*);
	typedef void* (*LoadAssemblyFunctionDelegate)(const char_t* AssemblyPath, const char_t* TypeName, const char_t* MethodName, int32_t Optional);
	typedef void (*UnloadAssembliesDelegate)();

	static ExecuteAssemblyFunctionDelegate ExecuteAssemblyFunction;
	static LoadAssemblyFunctionDelegate LoadAssemblyFunction;
	static UnloadAssembliesDelegate UnloadAssemblies;
	static FString ProjectPath;
	static FString UserAssembliesPath;
	static StatusType Status = StatusType::Stopped;

	class Module : public IModuleInterface {
		protected:

		virtual void StartupModule() override;
		virtual void ShutdownModule() override;

		private:

		void OnPreWorldInitialization(UWorld* World, const UWorld::InitializationValues InitializationValues);
		void OnWorldCleanup(UWorld* World, bool SessionEnded, bool CleanupResources);

		static void HostError(const char_t* Message);
		static void Invoke(void(*)());
		static void Exception(const char* Message);
		static void Log(UnrealCLR::LogLevel Level, const char* Message);

		void* HostfxrLibrary;
		FDelegateHandle OnPreWorldInitializationHandle;
		FDelegateHandle OnWorldCleanupHandle;
	};

	namespace Engine {
		static UWorld* World;
	}

	namespace Shared {
		constexpr int32 storageSize = 64;

		// Non-instantiable

		void* AssertFunctions[storageSize];
		void* CommandLineFunctions[storageSize];
		void* DebugFunctions[storageSize];
		void* ObjectFunctions[storageSize];
		void* ApplicationFunctions[storageSize];
		void* ConsoleManagerFunctions[storageSize];
		void* EngineFunctions[storageSize];
		void* WorldFunctions[storageSize];

		// Instantiable

		void* BlueprintFunctions[storageSize];
		void* ConsoleObjectFunctions[storageSize];
		void* ConsoleVariableFunctions[storageSize];
		void* ActorFunctions[storageSize];
		void* PawnFunctions[storageSize];
		void* ControllerFunctions[storageSize];
		void* AIControllerFunctions[storageSize];
		void* PlayerControllerFunctions[storageSize];
		void* VolumeFunctions[storageSize];
		void* SoundBaseFunctions[storageSize];
		void* SoundWaveFunctions[storageSize];
		void* AnimationInstanceFunctions[storageSize];
		void* PlayerInputFunctions[storageSize];
		void* Texture2DFunctions[storageSize];
		void* ActorComponentFunctions[storageSize];
		void* InputComponentFunctions[storageSize];
		void* SceneComponentFunctions[storageSize];
		void* AudioComponentFunctions[storageSize];
		void* CameraComponentFunctions[storageSize];
		void* PrimitiveComponentFunctions[storageSize];
		void* ShapeComponentFunctions[storageSize];
		void* BoxComponentFunctions[storageSize];
		void* SphereComponentFunctions[storageSize];
		void* CapsuleComponentFunctions[storageSize];
		void* MeshComponentFunctions[storageSize];
		void* LightComponentBaseFunctions[storageSize];
		void* LightComponentFunctions[storageSize];
		void* MotionControllerComponentFunctions[storageSize];
		void* StaticMeshComponentFunctions[storageSize];
		void* InstancedStaticMeshComponentFunctions[storageSize];
		void* SkinnedMeshComponentFunctions[storageSize];
		void* SkeletalMeshComponentFunctions[storageSize];
		void* RadialForceComponentFunctions[storageSize];
		void* MaterialInterfaceFunctions[storageSize];
		void* MaterialFunctions[storageSize];
		void* MaterialInstanceFunctions[storageSize];
		void* MaterialInstanceDynamicFunctions[storageSize];
		void* HeadMountedDisplayFunctions[storageSize];

		void* ManagedFunctions[3];
		void* NativeFunctions[3];
		void* Functions[128];
	}

	namespace Utility {
		FORCEINLINE static size_t Strcpy(char* Destination, const char* Source, size_t Length);
		FORCEINLINE static size_t Strlen(const char* Source);
	}
}