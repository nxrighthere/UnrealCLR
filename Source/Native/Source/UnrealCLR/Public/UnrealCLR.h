/*
 *  Copyright (c) 2020 Stanislav Denisov (nxrighthere@gmail.com)
 *
 *  Permission to use, copy, modify, and/or distribute this software free of
 *  charge is hereby granted, provided that the above copyright notice and this
 *  permission notice appear in all copies or portions of this software with
 *  respect to the following additional terms and conditions that apply to the
 *  software which distributed in a non-compiled and/or non-object files:
 *
 *  1. Without specific prior written permission of the copyright holder,
 *  this software is forbidden for rebranding, sublicensing, and the exploitation
 *  of its original brand to get payments in any form.
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
#include "Components/InputComponent.h"
#include "Components/ShapeComponent.h"
#include "Components/SphereComponent.h"
#include "DrawDebugHelpers.h"
#include "Engine/DirectionalLight.h"
#include "Engine/GameEngine.h"
#include "Engine/Light.h"
#include "Engine/PointLight.h"
#include "Engine/RectLight.h"
#include "Engine/SpotLight.h"
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
	enum class StatusType : int32 {
		Stopped,
		Idle,
		Running
	};

	enum class LogLevel : int32 {
		Display,
		Warning,
		Error
	};

	typedef void (*ExecuteAssemblyFunctionDelegate)(void*);
	typedef void* (*LoadAssemblyFunctionDelegate)(const char_t* AssemblyPath, const char_t* TypeName, const char_t* MethodName, int8_t Optional);
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
		constexpr int32 storageSize = 32;

		void* AssertFunctions[storageSize];
		void* CommandLineFunctions[storageSize];
		void* DebugFunctions[storageSize];
		void* ObjectFunctions[storageSize];
		void* ApplicationFunctions[storageSize];
		void* ConsoleManagerFunctions[storageSize];
		void* EngineFunctions[storageSize];
		void* WorldFunctions[storageSize];
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
		void* MotionControllerComponentFunctions[storageSize];
		void* StaticMeshComponentFunctions[storageSize];
		void* InstancedStaticMeshComponentFunctions[storageSize];
		void* SkinnedMeshComponentFunctions[storageSize];
		void* SkeletalMeshComponentFunctions[storageSize];
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