/*
 *  Unreal Engine .NET 6 integration
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

#include "UnrealCLRFramework.h"

DEFINE_LOG_CATEGORY(LogUnrealManaged);

namespace UnrealCLRFramework {
	#define UNREALCLR_GET_ATTACHMENT_RULE(Rule, Result) {\
		switch (Rule) {\
			case AttachmentTransformRule::KeepRelativeTransform:\
				Result = FAttachmentTransformRules::KeepRelativeTransform;\
				break;\
			case AttachmentTransformRule::KeepWorldTransform:\
				Result = FAttachmentTransformRules::KeepWorldTransform;\
				break;\
			case AttachmentTransformRule::SnapToTargetIncludingScale:\
				Result = FAttachmentTransformRules::SnapToTargetIncludingScale;\
				break;\
			case AttachmentTransformRule::SnapToTargetNotIncludingScale:\
				Result = FAttachmentTransformRules::SnapToTargetNotIncludingScale;\
				break;\
			default:\
				break;\
		}\
	}

	#define UNREALCLR_GET_DETACHMENT_RULE(Rule, Result) {\
		switch (Rule) {\
			case DetachmentTransformRule::KeepRelativeTransform:\
				Result = FDetachmentTransformRules::KeepRelativeTransform;\
				break;\
			case DetachmentTransformRule::KeepWorldTransform:\
				Result = FDetachmentTransformRules::KeepWorldTransform;\
				break;\
			default:\
				break;\
		}\
	}

	#define UNREALCLR_GET_ACTOR_TYPE(Type, Head, Tail, Result) {\
		switch (Type) {\
			case ActorType::Base:\
				Result = Head AActor Tail;\
				break;\
			case ActorType::Camera:\
				Result = Head ACameraActor Tail;\
				break;\
			case ActorType::TriggerBox:\
				Result = Head ATriggerBox Tail;\
				break;\
			case ActorType::TriggerSphere:\
				Result = Head ATriggerSphere Tail;\
				break;\
			case ActorType::TriggerCapsule:\
				Result = Head ATriggerCapsule Tail;\
				break;\
			case ActorType::Pawn:\
				Result = Head APawn Tail;\
				break;\
			case ActorType::Character:\
				Result = Head ACharacter Tail;\
				break;\
			case ActorType::AIController:\
				Result = Head AAIController Tail;\
				break;\
			case ActorType::PlayerController:\
				Result = Head APlayerController Tail;\
				break;\
			case ActorType::Brush:\
				Result = Head ABrush Tail;\
				break;\
			case ActorType::AmbientSound:\
				Result = Head AAmbientSound Tail;\
				break;\
			case ActorType::DirectionalLight:\
				Result = Head ADirectionalLight Tail;\
				break;\
			case ActorType::PointLight:\
				Result = Head APointLight Tail;\
				break;\
			case ActorType::RectLight:\
				Result = Head ARectLight Tail;\
				break;\
			case ActorType::SpotLight:\
				Result = Head ASpotLight Tail;\
				break;\
			case ActorType::TriggerVolume:\
				Result = Head ATriggerVolume Tail;\
				break;\
			case ActorType::PostProcessVolume:\
				Result = Head APostProcessVolume Tail;\
				break;\
			case ActorType::LevelScript:\
				Result = Head ALevelScriptActor Tail;\
				break;\
			case ActorType::GameModeBase:\
				Result = Head AGameModeBase Tail;\
				break;\
			default:\
				break;\
		}\
	}

	#define UNREALCLR_GET_COMPONENT_TYPE(Type, Head, Tail, Result) {\
		switch (Type) {\
			case ComponentType::Actor:\
				Result = Head UActorComponent Tail;\
				break;\
			case ComponentType::Input:\
				Result = Head UInputComponent Tail;\
				break;\
			case ComponentType::Movement:\
				Result = Head UMovementComponent Tail;\
				break;\
			case ComponentType::RotatingMovement:\
				Result = Head URotatingMovementComponent Tail;\
				break;\
			case ComponentType::Scene:\
				Result = Head USceneComponent Tail;\
				break;\
			case ComponentType::Audio:\
				Result = Head UAudioComponent Tail;\
				break;\
			case ComponentType::Camera:\
				Result = Head UCameraComponent Tail;\
				break;\
			case ComponentType::Light:\
				Result = Head ULightComponent Tail;\
				break;\
			case ComponentType::DirectionalLight:\
				Result = Head UDirectionalLightComponent Tail;\
				break;\
			case ComponentType::MotionController:\
				Result = Head UMotionControllerComponent Tail;\
				break;\
			case ComponentType::StaticMesh:\
				Result = Head UStaticMeshComponent Tail;\
				break;\
			case ComponentType::InstancedStaticMesh:\
				Result = Head UInstancedStaticMeshComponent Tail;\
				break;\
			case ComponentType::HierarchicalInstancedStaticMesh:\
				Result = Head UHierarchicalInstancedStaticMeshComponent Tail;\
				break;\
			case ComponentType::ChildActor:\
				Result = Head UChildActorComponent Tail;\
				break;\
			case ComponentType::SpringArm:\
				Result = Head USpringArmComponent Tail;\
				break;\
			case ComponentType::PostProcess:\
				Result = Head UPostProcessComponent Tail;\
				break;\
			case ComponentType::Box:\
				Result = Head UBoxComponent Tail;\
				break;\
			case ComponentType::Sphere:\
				Result = Head USphereComponent Tail;\
				break;\
			case ComponentType::Capsule:\
				Result = Head UCapsuleComponent Tail;\
				break;\
			case ComponentType::SkeletalMesh:\
				Result = Head USkeletalMeshComponent Tail;\
				break;\
			case ComponentType::TextRender:\
				Result = Head UTextRenderComponent Tail;\
				break;\
			case ComponentType::Spline:\
				Result = Head USplineComponent Tail;\
				break;\
			case ComponentType::RadialForce:\
				Result = Head URadialForceComponent Tail;\
				break;\
			default:\
				break;\
		}\
	}

	#define UNREALCLR_GET_MOVABLE_COMPONENT_TYPE(Type, Head, Tail, Result) {\
		switch (Type) {\
			case ComponentType::Scene:\
				Result = Head USceneComponent Tail;\
				break;\
			case ComponentType::Audio:\
				Result = Head UAudioComponent Tail;\
				break;\
			case ComponentType::Camera:\
				Result = Head UCameraComponent Tail;\
				break;\
			case ComponentType::Light:\
				Result = Head ULightComponent Tail;\
				break;\
			case ComponentType::DirectionalLight:\
				Result = Head UDirectionalLightComponent Tail;\
				break;\
			case ComponentType::MotionController:\
				Result = Head UMotionControllerComponent Tail;\
				break;\
			case ComponentType::StaticMesh:\
				Result = Head UStaticMeshComponent Tail;\
				break;\
			case ComponentType::InstancedStaticMesh:\
				Result = Head UInstancedStaticMeshComponent Tail;\
				break;\
			case ComponentType::HierarchicalInstancedStaticMesh:\
				Result = Head UHierarchicalInstancedStaticMeshComponent Tail;\
				break;\
			case ComponentType::ChildActor:\
				Result = Head UChildActorComponent Tail;\
				break;\
			case ComponentType::SpringArm:\
				Result = Head USpringArmComponent Tail;\
				break;\
			case ComponentType::PostProcess:\
				Result = Head UPostProcessComponent Tail;\
				break;\
			case ComponentType::Box:\
				Result = Head UBoxComponent Tail;\
				break;\
			case ComponentType::Sphere:\
				Result = Head USphereComponent Tail;\
				break;\
			case ComponentType::Capsule:\
				Result = Head UCapsuleComponent Tail;\
				break;\
			case ComponentType::SkeletalMesh:\
				Result = Head USkeletalMeshComponent Tail;\
				break;\
			case ComponentType::TextRender:\
				Result = Head UTextRenderComponent Tail;\
				break;\
			case ComponentType::Spline:\
				Result = Head USplineComponent Tail;\
				break;\
			case ComponentType::RadialForce:\
				Result = Head URadialForceComponent Tail;\
				break;\
			default:\
				break;\
		}\
	}

	#define UNREALCLR_GET_PROPERTY_VALUE(Type, Object, Name, Value)\
		FName name(UTF8_TO_TCHAR(Name));\
		for (TFieldIterator<Type> currentProperty(Object->GetClass()); currentProperty; ++currentProperty) {\
			Type* property = *currentProperty;\
			if (property->GetFName() == name) {\
				*Value = property->GetPropertyValue_InContainer(Object);\
				return true;\
			}\
		}\
		return false;

	#define UNREALCLR_SET_PROPERTY_VALUE(Type, Object, Name, Value)\
		FName name(UTF8_TO_TCHAR(Name));\
		for (TFieldIterator<Type> currentProperty(Object->GetClass()); currentProperty; ++currentProperty) {\
			Type* property = *currentProperty;\
			if (property->GetFName() == name) {\
				property->SetPropertyValue_InContainer(Object, Value);\
				return true;\
			}\
		}\
		return false;

	#define UNREALCLR_GET_BONE_NAME(Hit, Name)\
		if (Name && Hit.BoneName.GetStringLength() > 0) {\
			const char* boneName = TCHAR_TO_UTF8(*Hit.BoneName.ToString());\
			UnrealCLR::Utility::Strcpy(Name, boneName, UnrealCLR::Utility::Strlen(boneName));\
		}

	#define UNREALCLR_SET_BONE_NAME(Name)\
		FName boneName;\
		if (!Name)\
			boneName = NAME_None;\
		else\
			boneName = FName(UTF8_TO_TCHAR(Name));

	#define UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent)\
		FCollisionQueryParams queryParams;\
		if (IgnoredActor)\
			queryParams.AddIgnoredActor(IgnoredActor);\
		if (IgnoredComponent)\
			queryParams.AddIgnoredComponent(IgnoredComponent);

	#define UNREALCLR_SET_COMPONENT_INSTANCE(Component, Name)\
		Actor->AddInstanceComponent(Component);\
		component->OnComponentCreated();\
		component->RegisterComponent();\
		if (Name)\
			component->Rename(*FString(UTF8_TO_TCHAR(Name)));

	#define UNREALCLR_SET_ACTOR_EVENT(Type, Condition, Method) {\
		switch (Type) {\
			case ActorEventType::OnActorBeginOverlap:\
				if (Condition Actor->OnActorBeginOverlap.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorBeginOverlap))\
					Actor->OnActorBeginOverlap. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorBeginOverlap);\
				break;\
			case ActorEventType::OnActorEndOverlap:\
				if (Condition Actor->OnActorEndOverlap.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorEndOverlap))\
					Actor->OnActorEndOverlap. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorEndOverlap);\
				break;\
			case ActorEventType::OnActorHit:\
				if (Condition Actor->OnActorHit.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorHit))\
					Actor->OnActorHit. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorHit);\
				break;\
			case ActorEventType::OnActorBeginCursorOver:\
				if (Condition Actor->OnBeginCursorOver.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorBeginCursorOver))\
					Actor->OnBeginCursorOver. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorBeginCursorOver);\
				break;\
			case ActorEventType::OnActorEndCursorOver:\
				if (Condition Actor->OnEndCursorOver.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorEndCursorOver))\
					Actor->OnEndCursorOver. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorEndCursorOver);\
				break;\
			case ActorEventType::OnActorClicked:\
				if (Condition Actor->OnClicked.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorClicked))\
					Actor->OnClicked. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorClicked);\
				break;\
			case ActorEventType::OnActorReleased:\
				if (Condition Actor->OnReleased.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorReleased))\
					Actor->OnReleased. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ActorReleased);\
				break;\
			default:\
				break;\
		}\
	}

	#define UNREALCLR_SET_COMPONENT_EVENT(Type, Condition, Method) {\
		switch (Type) {\
			case ComponentEventType::OnComponentBeginOverlap:\
				if (Condition PrimitiveComponent->OnComponentBeginOverlap.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentBeginOverlap))\
					PrimitiveComponent->OnComponentBeginOverlap. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentBeginOverlap);\
				break;\
			case ComponentEventType::OnComponentEndOverlap:\
				if (Condition PrimitiveComponent->OnComponentEndOverlap.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentEndOverlap))\
					PrimitiveComponent->OnComponentEndOverlap. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentEndOverlap);\
				break;\
			case ComponentEventType::OnComponentHit:\
				if (Condition PrimitiveComponent->OnComponentHit.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentHit))\
					PrimitiveComponent->OnComponentHit. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentHit);\
				break;\
			case ComponentEventType::OnComponentBeginCursorOver:\
				if (Condition PrimitiveComponent->OnBeginCursorOver.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentBeginCursorOver))\
					PrimitiveComponent->OnBeginCursorOver. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentBeginCursorOver);\
				break;\
			case ComponentEventType::OnComponentEndCursorOver:\
				if (Condition PrimitiveComponent->OnEndCursorOver.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentEndCursorOver))\
					PrimitiveComponent->OnEndCursorOver. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentEndCursorOver);\
				break;\
			case ComponentEventType::OnComponentClicked:\
				if (Condition PrimitiveComponent->OnClicked.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentClicked))\
					PrimitiveComponent->OnClicked. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentClicked);\
				break;\
			case ComponentEventType::OnComponentReleased:\
				if (Condition PrimitiveComponent->OnReleased.IsAlreadyBound(UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentReleased))\
					PrimitiveComponent->OnReleased. Method (UnrealCLR::Engine::Manager, &UUnrealCLRManager::ComponentReleased);\
				break;\
			default:\
				break;\
		}\
	}

	#define UNREALCLR_COLOR_TO_INTEGER(Color) (Color.A << 24) + (Color.R << 16) + (Color.G << 8) + Color.B

	#if ENGINE_MAJOR_VERSION == 4
		#define UNREALCLR_CONTROLLER_HAND 17
		#define UNREALCLR_BOUNDS_SIZE 28

		#if ENGINE_MINOR_VERSION <= 26
			#define UNREALCLR_BLEND_TYPE 5
		#elif ENGINE_MINOR_VERSION >= 27
			#define UNREALCLR_BLEND_TYPE 6
		#endif

		#if ENGINE_MINOR_VERSION <= 25
			#define UNREALCLR_PIXEL_FORMAT 71
		#elif ENGINE_MINOR_VERSION >= 26
			#define UNREALCLR_PIXEL_FORMAT 72
		#endif
	#elif ENGINE_MAJOR_VERSION == 5
		#define UNREALCLR_BLEND_TYPE 6
		#define UNREALCLR_PIXEL_FORMAT 85
		#define UNREALCLR_CONTROLLER_HAND 18

		// Large World Coordinates changed float sphere radius to double but this will be refactored to double in UE5 stable release. 
		// Currently this is aliased to FLargeWorldCoordinatesReal. Check Engine\Source\Runtime\CoreUObject\Public\UObject\NoExportTypes.h for FVector where it explains.
		#define UNREALCLR_BOUNDS_SIZE 56	

		#ifdef BRANCH_NAME
			// There may be a better way to get this information
			#ifdef BRANCH_NAME == "++UE5+Release-5.0-EarlyAccess"
				#define UNREALCLR_PIXEL_FORMAT 72
			#else 
				#define UNREALCLR_PIXEL_FORMAT 85
			#endif
		#else
			#define UNREALCLR_PIXEL_FORMAT 85
		#endif

	#endif

	static_assert(AudioFadeCurve::Count == AudioFadeCurve(4), "Invalid elements count of the [AudioFadeCurve] enumeration");
	static_assert(BlendType::VTBlend_MAX == BlendType(UNREALCLR_BLEND_TYPE), "Invalid elements count of the [BlendType] enumeration");
	static_assert(CollisionChannel::ECC_MAX == CollisionChannel(33), "Invalid elements count of the [CollisionChannel] enumeration");
	static_assert(CollisionResponse::ECR_MAX == CollisionResponse(3), "Invalid elements count of the [CollisionResponse] enumeration");
	static_assert(ControllerHand::ControllerHand_Count == ControllerHand(UNREALCLR_CONTROLLER_HAND), "Invalid elements count of the [ControllerHand] enumeration");
	static_assert(InputEvent::IE_MAX == InputEvent(5), "Invalid elements count of the [InputEvent] enumeration");
	static_assert(NetMode::NM_MAX == NetMode(4), "Invalid elements count of the [NetMode] enumeration");
	static_assert(PixelFormat::PF_MAX == PixelFormat(UNREALCLR_PIXEL_FORMAT), "Invalid elements count of the [PixelFormat] enumeration");

	static_assert(sizeof(Bounds) == UNREALCLR_BOUNDS_SIZE, "Invalid size of the [Bounds] structure");
	static_assert(sizeof(CollisionShape) == 16, "Invalid size of the [CollisionShape] structure");

	namespace Assert {
		void OutputMessage(const char* Message) {
			FString message(UTF8_TO_TCHAR(Message));

			UE_LOG(LogUnrealManaged, Error, TEXT("%s: %s"), ANSI_TO_TCHAR(__FUNCTION__), *message);

			GEngine->AddOnScreenDebugMessage((uint64)-1, 60.0f, FColor::Red, *message);
		}
	}

	namespace CommandLine {
		void Get(char* Arguments) {
			const char* arguments = TCHAR_TO_UTF8(FCommandLine::Get());

			UnrealCLR::Utility::Strcpy(Arguments, arguments, UnrealCLR::Utility::Strlen(arguments));
		}

		void Set(const char* Arguments) {
			FCommandLine::Set(UTF8_TO_TCHAR(Arguments));
		}

		void Append(const char* Arguments) {
			FCommandLine::Append(UTF8_TO_TCHAR(Arguments));
		}
	}

	namespace Debug {
		void Log(LogLevel Level, const char* Message) {
			#define UNREALCLR_FRAMEWORK_LOG(Verbosity) UE_LOG(LogUnrealManaged, Verbosity, TEXT("%s: %s"), ANSI_TO_TCHAR(__FUNCTION__), *FString(UTF8_TO_TCHAR(Message)));

			if (Level == LogLevel::Display) {
				UNREALCLR_FRAMEWORK_LOG(Display);
			} else if (Level == LogLevel::Warning) {
				UNREALCLR_FRAMEWORK_LOG(Warning);
			} else if (Level == LogLevel::Error) {
				UNREALCLR_FRAMEWORK_LOG(Error);
			} else if (Level == LogLevel::Fatal) {
				UNREALCLR_FRAMEWORK_LOG(Fatal);
			}
		}

		void Exception(const char* Message) {
			GEngine->AddOnScreenDebugMessage((uint64)-1, 10.0f, FColor::Red, *FString(UTF8_TO_TCHAR(Message)));
		}

		void AddOnScreenMessage(int32 Key, float TimeToDisplay, Color DisplayColor, const char* Message) {
			GEngine->AddOnScreenDebugMessage((uint64)Key, TimeToDisplay, DisplayColor, *FString(UTF8_TO_TCHAR(Message)));
		}

		void ClearOnScreenMessages() {
			GEngine->ClearOnScreenDebugMessages();
		}

		void DrawBox(const Vector3* Center, const Vector3* Extent, const Quaternion* Rotation, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness) {
			DrawDebugBox(UnrealCLR::Engine::World, *Center, *Extent, *Rotation, Color, PersistentLines, LifeTime, DepthPriority, Thickness);
		}

		void DrawCapsule(const Vector3* Center, float HalfHeight, float Radius, const Quaternion* Rotation, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness) {
			DrawDebugCapsule(UnrealCLR::Engine::World, *Center, HalfHeight, Radius, *Rotation, Color, PersistentLines, LifeTime, DepthPriority, Thickness);
		}

		void DrawCone(const Vector3* Origin, const Vector3* Direction, float Length, float AngleWidth, float AngleHeight, int32 Sides, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness) {
			DrawDebugCone(UnrealCLR::Engine::World, *Origin, *Direction, Length, AngleWidth, AngleHeight, Sides, Color, PersistentLines, LifeTime, DepthPriority, Thickness);
		}

		void DrawCylinder(const Vector3* Start, const Vector3* End, float Radius, int32 Segments, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness) {
			DrawDebugCylinder(UnrealCLR::Engine::World, *Start, *End, Radius, Segments, Color, PersistentLines, LifeTime, DepthPriority, Thickness);
		}

		void DrawSphere(const Vector3* Center, float Radius, int32 Segments, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness) {
			DrawDebugSphere(UnrealCLR::Engine::World, *Center, Radius, Segments, Color, PersistentLines, LifeTime, DepthPriority, Thickness);
		}

		void DrawLine(const Vector3* Start, const Vector3* End, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness) {
			DrawDebugLine(UnrealCLR::Engine::World, *Start, *End, Color, PersistentLines, LifeTime, DepthPriority, Thickness);
		}

		void DrawPoint(const Vector3* Location, float Size, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority) {
			DrawDebugPoint(UnrealCLR::Engine::World, *Location, Size, Color, PersistentLines, LifeTime, DepthPriority);
		}

		void FlushPersistentLines() {
			FlushPersistentDebugLines(UnrealCLR::Engine::World);
		}
	}

	namespace Object {
		bool IsPendingKill(UObject* Object) {
			return Object->IsPendingKill();
		}

		bool IsValid(UObject* Object) {
			return Object->IsValidLowLevel();
		}

		UObject* Load(ObjectType Type, const char* Name) {
			UObject* object = nullptr;

			switch (Type) {
				case ObjectType::Blueprint: {
					#if WITH_EDITOR
						object = StaticLoadObject(UBlueprint::StaticClass(), nullptr, *FString(UTF8_TO_TCHAR(Name)));
					#else
						FString name(UTF8_TO_TCHAR(Name));
						int32 index = INDEX_NONE;

						if (name.FindLastChar(TCHAR('/'), index)) {
							name.AppendChar(TCHAR('.'));
							name.Append(name.Mid(index + 1, name.Len() - index - 2));
						}

						name.Append(TEXT("_C"));

						object = StaticLoadObject(UClass::StaticClass(), nullptr, *name);
					#endif
					break;
				}

				case ObjectType::SoundWave: {
					object = StaticLoadObject(USoundWave::StaticClass(), nullptr, *FString(UTF8_TO_TCHAR(Name)));
					break;
				}

				case ObjectType::AnimationSequence: {
					object = StaticLoadObject(UAnimSequence::StaticClass(), nullptr, *FString(UTF8_TO_TCHAR(Name)));
					break;
				}

				case ObjectType::AnimationMontage: {
					object = StaticLoadObject(UAnimMontage::StaticClass(), nullptr, *FString(UTF8_TO_TCHAR(Name)));
					break;
				}

				case ObjectType::StaticMesh: {
					object = StaticLoadObject(UStaticMesh::StaticClass(), nullptr, *FString(UTF8_TO_TCHAR(Name)));
					break;
				}

				case ObjectType::SkeletalMesh: {
					object = StaticLoadObject(USkeletalMesh::StaticClass(), nullptr, *FString(UTF8_TO_TCHAR(Name)));
					break;
				}

				case ObjectType::Material: {
					object = StaticLoadObject(UMaterial::StaticClass(), nullptr, *FString(UTF8_TO_TCHAR(Name)));
					break;
				}

				case ObjectType::Font: {
					object = StaticLoadObject(UFont::StaticClass(), nullptr, *FString(UTF8_TO_TCHAR(Name)));
					break;
				}

				case ObjectType::Texture2D: {
					object = StaticLoadObject(UTexture2D::StaticClass(), nullptr, *FString(UTF8_TO_TCHAR(Name)));
					break;
				}

				default:
					break;
			}

			return object;
		}

		void Rename(UObject* Object, const char* Name) {
			FString name(UTF8_TO_TCHAR(Name));

			Object->Rename(*name);
		}

		bool Invoke(UObject* Object, const char* Command) {
			static FOutputDeviceNull outputDevice;

			return Object->CallFunctionByNameWithArguments(UTF8_TO_TCHAR(Command), outputDevice, nullptr, true);
		}

		AActor* ToActor(UObject* Object, ActorType Type) {
			AActor* actor = nullptr;

			UNREALCLR_GET_ACTOR_TYPE(Type, Cast<, >(Object), actor);

			return actor;
		}

		UActorComponent* ToComponent(UObject* Object, ComponentType Type) {
			UActorComponent* component = nullptr;

			UNREALCLR_GET_COMPONENT_TYPE(Type, Cast<, >(Object), component);

			return component;
		}

		uint32 GetID(UObject* Object) {
			return Object->GetUniqueID();
		}

		void GetName(UObject* Object, char* Name) {
			const char* name = TCHAR_TO_UTF8(*Object->GetName());

			UnrealCLR::Utility::Strcpy(Name, name, UnrealCLR::Utility::Strlen(name));
		}

		bool GetBool(UObject* Object, const char* Name, bool* Value) {
			UNREALCLR_GET_PROPERTY_VALUE(FBoolProperty, Object, Name, Value);
		}

		bool GetByte(UObject* Object, const char* Name, uint8* Value) {
			UNREALCLR_GET_PROPERTY_VALUE(FByteProperty, Object, Name, Value);
		}

		bool GetShort(UObject* Object, const char* Name, int16* Value) {
			UNREALCLR_GET_PROPERTY_VALUE(FInt16Property, Object, Name, Value);
		}

		bool GetInt(UObject* Object, const char* Name, int32* Value) {
			UNREALCLR_GET_PROPERTY_VALUE(FIntProperty, Object, Name, Value);
		}

		bool GetLong(UObject* Object, const char* Name, int64* Value) {
			UNREALCLR_GET_PROPERTY_VALUE(FInt64Property, Object, Name, Value);
		}

		bool GetUShort(UObject* Object, const char* Name, uint16* Value) {
			UNREALCLR_GET_PROPERTY_VALUE(FUInt16Property, Object, Name, Value);
		}

		bool GetUInt(UObject* Object, const char* Name, uint32* Value) {
			UNREALCLR_GET_PROPERTY_VALUE(FUInt32Property, Object, Name, Value);
		}

		bool GetULong(UObject* Object, const char* Name, uint64* Value) {
			UNREALCLR_GET_PROPERTY_VALUE(FUInt64Property, Object, Name, Value);
		}

		bool GetFloat(UObject* Object, const char* Name, float* Value) {
			UNREALCLR_GET_PROPERTY_VALUE(FFloatProperty, Object, Name, Value);
		}

		bool GetDouble(UObject* Object, const char* Name, double* Value) {
			UNREALCLR_GET_PROPERTY_VALUE(FDoubleProperty, Object, Name, Value);
		}

		bool GetEnum(UObject* Object, const char* Name, int32* Value) {
			FName name(UTF8_TO_TCHAR(Name));

			for (TFieldIterator<FNumericProperty> currentProperty(Object->GetClass()); currentProperty; ++currentProperty) {
				FNumericProperty* property = *currentProperty;

				if (property->GetFName() == name) {
					*Value = static_cast<int32>(property->GetSignedIntPropertyValue(property->ContainerPtrToValuePtr<int32>(Object)));

					return true;
				}
			}

			return false;
		}

		bool GetString(UObject* Object, const char* Name, char* Value) {
			FName name(UTF8_TO_TCHAR(Name));

			for (TFieldIterator<FStrProperty> currentProperty(Object->GetClass()); currentProperty; ++currentProperty) {
				FStrProperty* property = *currentProperty;

				if (property->GetFName() == name) {
					const char* string = TCHAR_TO_UTF8(*property->GetPropertyValue_InContainer(Object));

					UnrealCLR::Utility::Strcpy((char*)Value, string, UnrealCLR::Utility::Strlen(string));

					return true;
				}
			}

			return false;
		}

		bool GetText(UObject* Object, const char* Name, char* Value) {
			FName name(UTF8_TO_TCHAR(Name));

			for (TFieldIterator<FTextProperty> currentProperty(Object->GetClass()); currentProperty; ++currentProperty) {
				FTextProperty* property = *currentProperty;

				if (property->GetFName() == name) {
					const char* string = TCHAR_TO_UTF8(*property->GetPropertyValue_InContainer(Object).ToString());

					UnrealCLR::Utility::Strcpy(Value, string, UnrealCLR::Utility::Strlen(string));

					return true;
				}
			}

			return false;
		}

		bool SetBool(UObject* Object, const char* Name, bool Value) {
			UNREALCLR_SET_PROPERTY_VALUE(FBoolProperty, Object, Name, Value);
		}

		bool SetByte(UObject* Object, const char* Name, uint8 Value) {
			UNREALCLR_SET_PROPERTY_VALUE(FByteProperty, Object, Name, Value);
		}

		bool SetShort(UObject* Object, const char* Name, int16 Value) {
			UNREALCLR_SET_PROPERTY_VALUE(FInt16Property, Object, Name, Value);
		}

		bool SetInt(UObject* Object, const char* Name, int32 Value) {
			UNREALCLR_SET_PROPERTY_VALUE(FIntProperty, Object, Name, Value);
		}

		bool SetLong(UObject* Object, const char* Name, int64 Value) {
			UNREALCLR_SET_PROPERTY_VALUE(FInt64Property, Object, Name, Value);
		}

		bool SetUShort(UObject* Object, const char* Name, uint16 Value) {
			UNREALCLR_SET_PROPERTY_VALUE(FUInt16Property, Object, Name, Value);
		}

		bool SetUInt(UObject* Object, const char* Name, uint32 Value) {
			UNREALCLR_SET_PROPERTY_VALUE(FUInt32Property, Object, Name, Value);
		}

		bool SetULong(UObject* Object, const char* Name, uint64 Value) {
			UNREALCLR_SET_PROPERTY_VALUE(FUInt64Property, Object, Name, Value);
		}

		bool SetFloat(UObject* Object, const char* Name, float Value) {
			UNREALCLR_SET_PROPERTY_VALUE(FFloatProperty, Object, Name, Value);
		}

		bool SetDouble(UObject* Object, const char* Name, double Value) {
			UNREALCLR_SET_PROPERTY_VALUE(FDoubleProperty, Object, Name, Value);
		}

		bool SetEnum(UObject* Object, const char* Name, int32 Value) {
			FName name(UTF8_TO_TCHAR(Name));

			for (TFieldIterator<FNumericProperty> currentProperty(Object->GetClass()); currentProperty; ++currentProperty) {
				FNumericProperty* property = *currentProperty;

				if (property->GetFName() == name) {
					property->SetIntPropertyValue(property->ContainerPtrToValuePtr<int32>(Object), static_cast<int64>(Value));

					return true;
				}
			}

			return false;
		}

		bool SetString(UObject* Object, const char* Name, const char* Value) {
			FName name(UTF8_TO_TCHAR(Name));

			for (TFieldIterator<FStrProperty> currentProperty(Object->GetClass()); currentProperty; ++currentProperty) {
				FStrProperty* property = *currentProperty;

				if (property->GetFName() == name) {
					property->SetPropertyValue_InContainer(Object, FString(UTF8_TO_TCHAR(Value)));

					return true;
				}
			}

			return false;
		}

		bool SetText(UObject* Object, const char* Name, const char* Value) {
			FName name(UTF8_TO_TCHAR(Name));

			for (TFieldIterator<FTextProperty> currentProperty(Object->GetClass()); currentProperty; ++currentProperty) {
				FTextProperty* property = *currentProperty;

				if (property->GetFName() == name) {
					property->SetPropertyValue_InContainer(Object, FText::FromString(FString(UTF8_TO_TCHAR(Value))));

					return true;
				}
			}

			return false;
		}
	}

	namespace Asset {
		bool IsValid(FAssetData* Asset) {
			return Asset->IsValid();
		}

		void GetName(FAssetData* Asset, char* Name) {
			const char* name = TCHAR_TO_UTF8(*Asset->AssetName.ToString());

			UnrealCLR::Utility::Strcpy(Name, name, UnrealCLR::Utility::Strlen(name));
		}

		void GetPath(FAssetData* Asset, char* Path) {
			FString objectPath = Asset->ObjectPath.ToString();

			int32 index = INDEX_NONE;

			if (objectPath.FindLastChar(TCHAR('.'), index))
				objectPath = FString(index, *objectPath);

			const char* path = TCHAR_TO_UTF8(*objectPath);

			UnrealCLR::Utility::Strcpy(Path, path, UnrealCLR::Utility::Strlen(path));
		}
	}

	namespace AssetRegistry {
		IAssetRegistry* Get() {
			static IAssetRegistry* assetRegistry;

			if (!assetRegistry)
				assetRegistry = &FModuleManager::Get().LoadModuleChecked<FAssetRegistryModule>(TEXT("AssetRegistry")).Get();

			return assetRegistry;
		}

		bool HasAssets(IAssetRegistry* AssetRegistry, const char* Path, bool Recursive) {
			return AssetRegistry->HasAssets(FName(UTF8_TO_TCHAR(Path)), Recursive);
		}

		void ForEachAsset(IAssetRegistry* AssetRegistry, const char* Path, bool Recursive, bool IncludeOnlyOnDiskAssets, FAssetData** Array, int32* Elements) {
			static TArray<FAssetData> assets;
			static TArray<FAssetData*> references;

			assets.Reset();
			references.Reset();

			AssetRegistry->GetAssetsByPath(FName(UTF8_TO_TCHAR(Path)), assets, Recursive, IncludeOnlyOnDiskAssets);

			int32 elements = assets.Num();

			if (elements > 0) {
				for (int32 i = 0; i < elements; i++) {
					references.Add(&assets[i]);
				}

				*Array = reinterpret_cast<FAssetData*>(references.GetData());
				*Elements = references.Num();
			}
		}
	}

	namespace Blueprint {
		bool IsValidActorClass(UBlueprint* Blueprint, ActorType Type) {
			#if WITH_EDITOR
				TSubclassOf<AActor> type;

				UNREALCLR_GET_ACTOR_TYPE(Type, UNREALCLR_NONE, ::StaticClass(), type);

				return Blueprint->ParentClass == type;
			#else
				return true;
			#endif
		}

		bool IsValidComponentClass(UBlueprint* Blueprint, ComponentType Type) {
			#if WITH_EDITOR
				TSubclassOf<USceneComponent> type;

				UNREALCLR_GET_MOVABLE_COMPONENT_TYPE(Type, UNREALCLR_NONE, ::StaticClass(), type);

				return Blueprint->ParentClass == type;
			#else
				return true;
			#endif
		}
	}

	namespace Application {
		bool IsCanEverRender() {
			return FApp::CanEverRender();
		}

		bool IsPackagedForDistribution() {
			return FGenericPlatformMisc::IsPackagedForDistribution();
		}

		bool IsPackagedForShipping() {
			#if UE_BUILD_SHIPPING
				return true;
			#else
				return false;
			#endif
		}

		void GetProjectDirectory(char* Directory) {
			const char* directory = TCHAR_TO_UTF8(*FPaths::ConvertRelativePathToFull(FPaths::ProjectDir()));

			UnrealCLR::Utility::Strcpy(Directory, directory, UnrealCLR::Utility::Strlen(directory));
		}

		void GetDefaultLanguage(char* Language) {
			const char* language = TCHAR_TO_UTF8(*FGenericPlatformMisc::GetDefaultLanguage());

			UnrealCLR::Utility::Strcpy(Language, language, UnrealCLR::Utility::Strlen(language));
		}

		void GetProjectName(char* ProjectName) {
			const char* projectName = TCHAR_TO_UTF8(FApp::GetProjectName());

			UnrealCLR::Utility::Strcpy(ProjectName, projectName, UnrealCLR::Utility::Strlen(projectName));
		}

		float GetVolumeMultiplier() {
			return FApp::GetVolumeMultiplier();
		}

		void SetProjectName(const char* ProjectName) {
			FApp::SetProjectName(UTF8_TO_TCHAR(ProjectName));
		}

		void SetVolumeMultiplier(float Value) {
			FApp::SetVolumeMultiplier(Value);
		}

		void RequestExit(bool Force) {
			FGenericPlatformMisc::RequestExit(Force);
		}
	}

	namespace ConsoleManager {
		bool IsRegisteredVariable(const char* Name) {
			return IConsoleManager::Get().IsNameRegistered(UTF8_TO_TCHAR(Name));
		}

		IConsoleVariable* FindVariable(const char* Name) {
			return IConsoleManager::Get().FindConsoleVariable(UTF8_TO_TCHAR(Name));
		}

		IConsoleVariable* RegisterVariableBool(const char* Name, const char* Help, bool DefaultValue, bool ReadOnly) {
			return IConsoleManager::Get().RegisterConsoleVariable(UTF8_TO_TCHAR(Name), DefaultValue, UTF8_TO_TCHAR(Help), !ReadOnly ? ECVF_Default : ECVF_ReadOnly);
		}

		IConsoleVariable* RegisterVariableInt(const char* Name, const char* Help, int32 DefaultValue, bool ReadOnly) {
			return IConsoleManager::Get().RegisterConsoleVariable(UTF8_TO_TCHAR(Name), DefaultValue, UTF8_TO_TCHAR(Help), !ReadOnly ? ECVF_Default : ECVF_ReadOnly);
		}

		IConsoleVariable* RegisterVariableFloat(const char* Name, const char* Help, float DefaultValue, bool ReadOnly) {
			return IConsoleManager::Get().RegisterConsoleVariable(UTF8_TO_TCHAR(Name), DefaultValue, UTF8_TO_TCHAR(Help), !ReadOnly ? ECVF_Default : ECVF_ReadOnly);
		}

		IConsoleVariable* RegisterVariableString(const char* Name, const char* Help, const char* DefaultValue, bool ReadOnly) {
			return IConsoleManager::Get().RegisterConsoleVariable(UTF8_TO_TCHAR(Name), UTF8_TO_TCHAR(DefaultValue), UTF8_TO_TCHAR(Help), !ReadOnly ? ECVF_Default : ECVF_ReadOnly);
		}

		void RegisterCommand(const char* Name, const char* Help, ConsoleCommandDelegate Callback, bool ReadOnly) {
			auto callback = [Callback](const TArray<FString>& Arguments) {
				if (UnrealCLR::Status == UnrealCLR::StatusType::Running) {
					float value = 0.0f;

					if (Arguments.Num() > 0)
						FDefaultValueHelper::ParseFloat(Arguments[0], value);

					UnrealCLR::ManagedCommand(UnrealCLR::Command((void*)Callback, value));
				}
			};

			IConsoleManager::Get().RegisterConsoleCommand(UTF8_TO_TCHAR(Name), UTF8_TO_TCHAR(Help), FConsoleCommandWithArgsDelegate::CreateLambda(callback), !ReadOnly ? ECVF_Default : ECVF_ReadOnly);
		}

		void UnregisterObject(const char* Name) {
			IConsoleManager::Get().UnregisterConsoleObject(UTF8_TO_TCHAR(Name), false);
		}
	}

	namespace Engine {
		bool IsSplitScreen() {
#if ENGINE_MAJOR_VERSION >= 5
			return GEngine->HasMultipleLocalPlayers(UnrealCLR::Engine::World);
#else
			return GEngine->IsSplitScreen(UnrealCLR::Engine::World);
#endif
		}

		bool IsEditor() {
			return UnrealCLR::Engine::World->IsPlayInEditor();
		}

		bool IsForegroundWindow() {
			return UnrealCLR::Engine::World->GetGameViewport()->Viewport->IsForegroundWindow();
		}

		bool IsExitRequested() {
			return IsEngineExitRequested();
		}

		NetMode GetNetMode() {
			return UnrealCLR::Engine::World->GetNetMode();
		}

		uint32 GetFrameNumber() {
			return GFrameNumber;
		}

		void GetViewportSize(Vector2* Value) {
			*Value = FVector2D(GEngine->GameViewport->Viewport->GetSizeXY());
		}

		void GetScreenResolution(Vector2* Value) {
			*Value = FVector2D(static_cast<float>(GSystemResolution.ResX), static_cast<float>(GSystemResolution.ResY));
		}

		WindowMode GetWindowMode() {
			return UnrealCLR::Engine::World->GetGameViewport()->Viewport->GetWindowMode();
		}

		void GetVersion(char* Version) {
			const char* version = TCHAR_TO_UTF8(*FEngineVersion::Current().ToString());

			UnrealCLR::Utility::Strcpy(Version, version, UnrealCLR::Utility::Strlen(version));
		}

		float GetMaxFPS() {
			return GEngine->GetMaxFPS();
		}

		void SetMaxFPS(float MaxFPS) {
			GEngine->SetMaxFPS(MaxFPS);
		}

		void SetTitle(const char* Title) {
			UGameEngine* gameEngine = Cast<UGameEngine>(GEngine);

			if (gameEngine) {
				TSharedPtr<SWindow> gameViewportWindow = gameEngine->GameViewportWindow.Pin();

				if (gameViewportWindow.IsValid())
					gameViewportWindow->SetTitle(FText::FromString(FString(UTF8_TO_TCHAR(Title))));
			}
		}

		void AddActionMapping(const char* ActionName, const char* Key, bool Shift, bool Ctrl, bool Alt, bool Cmd) {
			UPlayerInput::AddEngineDefinedActionMapping(FInputActionKeyMapping(FName(UTF8_TO_TCHAR(ActionName)), FKey(UTF8_TO_TCHAR(Key)), Shift, Ctrl, Alt, Cmd));
		}

		void AddAxisMapping(const char* AxisName, const char* Key, float Scale) {
			UPlayerInput::AddEngineDefinedAxisMapping(FInputAxisKeyMapping(FName(UTF8_TO_TCHAR(AxisName)), FKey(UTF8_TO_TCHAR(Key)), Scale));
		}

		void ForceGarbageCollection(bool FullPurge) {
			GEngine->ForceGarbageCollection(FullPurge);
		}

		void DelayGarbageCollection() {
			GEngine->DelayGarbageCollection();
		}
	}

	namespace HeadMountedDisplay {
		bool IsConnected() {
			return UHeadMountedDisplayFunctionLibrary::IsHeadMountedDisplayConnected();
		}

		bool GetEnabled() {
			return UHeadMountedDisplayFunctionLibrary::IsHeadMountedDisplayEnabled();
		}

		bool GetLowPersistenceMode() {
			return UHeadMountedDisplayFunctionLibrary::IsInLowPersistenceMode();
		}

		void GetDeviceName(char* Name) {
			FName deviceName = UHeadMountedDisplayFunctionLibrary::GetHMDDeviceName();

			const char* name = TCHAR_TO_UTF8(*deviceName.ToString());

			UnrealCLR::Utility::Strcpy(Name, name, UnrealCLR::Utility::Strlen(name));
		}

		void SetEnable(bool Value) {
			UHeadMountedDisplayFunctionLibrary::EnableHMD(Value);
		}

		void SetLowPersistenceMode(bool Value) {
			UHeadMountedDisplayFunctionLibrary::EnableLowPersistenceMode(Value);
		}
	}

	namespace World {
		void ForEachActor(AActor** Array, int32* Elements) {
			static TArray<AActor*> actors;

			actors.Reset();

			for (TActorIterator<AActor> currentActor(UnrealCLR::Engine::World); currentActor; ++currentActor) {
				actors.Add(*currentActor);
			}

			int32 elements = actors.Num();

			if (elements > 0) {
				*Array = reinterpret_cast<AActor*>(actors.GetData());
				*Elements = elements;
			}
		}

		int32 GetActorCount() {
			return UnrealCLR::Engine::World->GetActorCount();
		}

		float GetDeltaSeconds() {
			return UnrealCLR::Engine::World->GetDeltaSeconds();
		}

		float GetRealTimeSeconds() {
			return UnrealCLR::Engine::World->GetRealTimeSeconds();
		}

		float GetTimeSeconds() {
			return UnrealCLR::Engine::World->GetTimeSeconds();
		}

		void GetCurrentLevelName(char* LevelName) {
			FString mapName = UnrealCLR::Engine::World->GetMapName();

			mapName.RemoveFromStart(UnrealCLR::Engine::World->StreamingLevelsPrefix);

			const char* levelName = TCHAR_TO_UTF8(*mapName);

			UnrealCLR::Utility::Strcpy(LevelName, levelName, UnrealCLR::Utility::Strlen(levelName));
		}

		bool GetSimulatePhysics() {
			return UnrealCLR::Engine::World->bShouldSimulatePhysics;
		}

		void GetWorldOrigin(Vector3* Value) {
			*Value = FVector(UnrealCLR::Engine::World->OriginLocation);
		}

		AActor* GetActor(const char* Name, ActorType Type) {
			FString name;
			AActor* actor = nullptr;
			TSubclassOf<AActor> type;

			if (Name)
				name = FString(UTF8_TO_TCHAR(Name));

			UNREALCLR_GET_ACTOR_TYPE(Type, UNREALCLR_NONE, ::StaticClass(), type);

			for (TActorIterator<AActor> currentActor(UnrealCLR::Engine::World, type); currentActor; ++currentActor) {
				if (!Name || (Name && *currentActor->GetName() == name)) {
					actor = *currentActor;
					break;
				}
			}

			return actor;
		}

		AActor* GetActorByTag(const char* Tag, ActorType Type) {
			AActor* actor = nullptr;
			TSubclassOf<AActor> type;
			FName tag(UTF8_TO_TCHAR(Tag));

			UNREALCLR_GET_ACTOR_TYPE(Type, UNREALCLR_NONE, ::StaticClass(), type);

			for (TActorIterator<AActor> currentActor(UnrealCLR::Engine::World, type); currentActor; ++currentActor) {
				if (currentActor->ActorHasTag(tag)) {
					actor = *currentActor;
					break;
				}
			}

			return actor;
		}

		AActor* GetActorByID(uint32 ID, ActorType Type) {
			AActor* actor = nullptr;
			TSubclassOf<AActor> type;

			UNREALCLR_GET_ACTOR_TYPE(Type, UNREALCLR_NONE, ::StaticClass(), type);

			for (TActorIterator<AActor> currentActor(UnrealCLR::Engine::World, type); currentActor; ++currentActor) {
				if (currentActor->GetUniqueID() == ID) {
					actor = *currentActor;
					break;
				}
			}

			return actor;
		}

		APlayerController* GetFirstPlayerController() {
			return UnrealCLR::Engine::World->GetFirstPlayerController();
		}

		AGameModeBase* GetGameMode() {
			return UnrealCLR::Engine::World->GetAuthGameMode();
		}

		void SetOnActorBeginOverlapCallback(ActorOverlapDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginOverlap] = (void*)Callback;
		}

		void SetOnActorEndOverlapCallback(ActorOverlapDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnActorEndOverlap] = (void*)Callback;
		}

		void SetOnActorHitCallback(ActorHitDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnActorHit] = (void*)Callback;
		}

		void SetOnActorBeginCursorOverCallback(ActorCursorDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginCursorOver] = (void*)Callback;
		}

		void SetOnActorEndCursorOverCallback(ActorCursorDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnActorEndCursorOver] = (void*)Callback;
		}

		void SetOnActorClickedCallback(ActorKeyDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnActorClicked] = (void*)Callback;
		}

		void SetOnActorReleasedCallback(ActorKeyDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnActorReleased] = (void*)Callback;
		}

		void SetOnComponentBeginOverlapCallback(ComponentOverlapDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnComponentBeginOverlap] = (void*)Callback;
		}

		void SetOnComponentEndOverlapCallback(ComponentOverlapDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndOverlap] = (void*)Callback;
		}

		void SetOnComponentHitCallback(ComponentHitDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnComponentHit] = (void*)Callback;
		}

		void SetOnComponentBeginCursorOverCallback(ComponentCursorDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnComponentBeginCursorOver] = (void*)Callback;
		}

		void SetOnComponentEndCursorOverCallback(ComponentCursorDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndCursorOver] = (void*)Callback;
		}

		void SetOnComponentClickedCallback(ComponentKeyDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnComponentClicked] = (void*)Callback;
		}

		void SetOnComponentReleasedCallback(ComponentKeyDelegate Callback) {
			UnrealCLR::Shared::Events[UnrealCLR::OnComponentReleased] = (void*)Callback;
		}

		void SetSimulatePhysics(bool Value) {
			UnrealCLR::Engine::World->bShouldSimulatePhysics = Value;
		}

		void SetGravity(float Value) {
			AWorldSettings* worldSettings = UnrealCLR::Engine::World->GetWorldSettings();

			worldSettings->bGlobalGravitySet = true;
			worldSettings->GlobalGravityZ = Value;
		}

		bool SetWorldOrigin(const Vector3* Value) {
			return UnrealCLR::Engine::World->SetNewWorldOrigin(FIntVector(*Value));
		}

		void OpenLevel(const char* LevelName) {
			GEngine->SetClientTravel(UnrealCLR::Engine::World, UTF8_TO_TCHAR(LevelName), TRAVEL_Absolute);
		}

		bool LineTraceTestByChannel(const Vector3* Start, const Vector3* End, CollisionChannel Channel, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			queryParams.bTraceComplex = TraceComplex;

			return UnrealCLR::Engine::World->LineTraceTestByChannel(*Start, *End, Channel, queryParams);
		}

		bool LineTraceTestByProfile(const Vector3* Start, const Vector3* End, const char* ProfileName, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			queryParams.bTraceComplex = TraceComplex;

			return UnrealCLR::Engine::World->LineTraceTestByProfile(*Start, *End, FName(UTF8_TO_TCHAR(ProfileName)), queryParams);
		}

		bool LineTraceSingleByChannel(const Vector3* Start, const Vector3* End, CollisionChannel Channel, Hit* Hit, char* BoneName, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			FHitResult hit;

			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			queryParams.bTraceComplex = TraceComplex;

			bool result = UnrealCLR::Engine::World->LineTraceSingleByChannel(hit, *Start, *End, Channel, queryParams);

			UNREALCLR_GET_BONE_NAME(hit, BoneName);

			*Hit = hit;

			return result;
		}

		bool LineTraceSingleByProfile(const Vector3* Start, const Vector3* End, const char* ProfileName, Hit* Hit, char* BoneName, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			FHitResult hit;

			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			queryParams.bTraceComplex = TraceComplex;

			bool result = UnrealCLR::Engine::World->LineTraceSingleByProfile(hit, *Start, *End, FName(UTF8_TO_TCHAR(ProfileName)), queryParams);

			UNREALCLR_GET_BONE_NAME(hit, BoneName);

			*Hit = hit;

			return result;
		}

		bool SweepTestByChannel(const Vector3* Start, const Vector3* End, const Quaternion* Rotation, CollisionChannel Channel, const CollisionShape* Shape, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			queryParams.bTraceComplex = TraceComplex;

			return UnrealCLR::Engine::World->SweepTestByChannel(*Start, *End, *Rotation, Channel, *Shape, queryParams);
		}

		bool SweepTestByProfile(const Vector3* Start, const Vector3* End, const Quaternion* Rotation, const char* ProfileName, const CollisionShape* Shape, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			queryParams.bTraceComplex = TraceComplex;

			return UnrealCLR::Engine::World->SweepTestByProfile( *Start, *End, *Rotation, FName(UTF8_TO_TCHAR(ProfileName)), *Shape, queryParams);
		}

		bool SweepSingleByChannel(const Vector3* Start, const Vector3* End, const Quaternion* Rotation, CollisionChannel Channel, const CollisionShape* Shape, Hit* Hit, char* BoneName, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			FHitResult hit;

			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			queryParams.bTraceComplex = TraceComplex;

			bool result = UnrealCLR::Engine::World->SweepSingleByChannel(hit, *Start, *End, *Rotation, Channel, *Shape, queryParams);

			UNREALCLR_GET_BONE_NAME(hit, BoneName);

			*Hit = hit;

			return result;
		}

		bool SweepSingleByProfile(const Vector3* Start, const Vector3* End, const Quaternion* Rotation, const char* ProfileName, const CollisionShape* Shape, Hit* Hit, char* BoneName, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			FHitResult hit;

			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			queryParams.bTraceComplex = TraceComplex;

			bool result = UnrealCLR::Engine::World->SweepSingleByProfile(hit, *Start, *End, *Rotation, FName(UTF8_TO_TCHAR(ProfileName)), *Shape, queryParams);

			UNREALCLR_GET_BONE_NAME(hit, BoneName);

			*Hit = hit;

			return result;
		}

		bool OverlapAnyTestByChannel(const Vector3* Location, const Quaternion* Rotation, CollisionChannel Channel, const CollisionShape* Shape, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			return UnrealCLR::Engine::World->OverlapAnyTestByChannel(*Location, *Rotation, Channel, *Shape, queryParams);
		}

		bool OverlapAnyTestByProfile(const Vector3* Location, const Quaternion* Rotation, const char* ProfileName, const CollisionShape* Shape, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			return UnrealCLR::Engine::World->OverlapAnyTestByProfile(*Location, *Rotation, FName(UTF8_TO_TCHAR(ProfileName)), *Shape, queryParams);
		}

		bool OverlapBlockingTestByChannel(const Vector3* Location, const Quaternion* Rotation, CollisionChannel Channel, const CollisionShape* Shape, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			return UnrealCLR::Engine::World->OverlapBlockingTestByChannel(*Location, *Rotation, Channel, *Shape, queryParams);
		}

		bool OverlapBlockingTestByProfile(const Vector3* Location, const Quaternion* Rotation, const char* ProfileName, const CollisionShape* Shape, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent) {
			UNREALCLR_SET_COLLISION_QUERY_PARAMS(IgnoredActor, IgnoredComponent);

			return UnrealCLR::Engine::World->OverlapBlockingTestByProfile(*Location, *Rotation, FName(UTF8_TO_TCHAR(ProfileName)), *Shape, queryParams);
		}
	}

	namespace ConsoleObject {
		bool IsBool(IConsoleObject* ConsoleObject) {
			return ConsoleObject->IsVariableBool();
		}

		bool IsInt(IConsoleObject* ConsoleObject) {
			return ConsoleObject->IsVariableInt();
		}

		bool IsFloat(IConsoleObject* ConsoleObject) {
			return ConsoleObject->IsVariableFloat();
		}

		bool IsString(IConsoleObject* ConsoleObject) {
			return ConsoleObject->IsVariableString();
		}
	}

	namespace ConsoleVariable {
		bool GetBool(IConsoleVariable* ConsoleVariable) {
			return ConsoleVariable->GetBool();
		}

		int32 GetInt(IConsoleVariable* ConsoleVariable) {
			return ConsoleVariable->GetInt();
		}

		float GetFloat(IConsoleVariable* ConsoleVariable) {
			return ConsoleVariable->GetFloat();
		}

		void GetString(IConsoleVariable* ConsoleVariable, char* Value) {
			const char* value = TCHAR_TO_UTF8(*ConsoleVariable->GetString());

			UnrealCLR::Utility::Strcpy(Value, value, UnrealCLR::Utility::Strlen(value));
		}

		void SetBool(IConsoleVariable* ConsoleVariable, bool Value) {
			ConsoleVariable->Set(Value);
		}

		void SetInt(IConsoleVariable* ConsoleVariable, int32 Value) {
			ConsoleVariable->Set(Value);
		}

		void SetFloat(IConsoleVariable* ConsoleVariable, float Value) {
			ConsoleVariable->Set(Value);
		}

		void SetString(IConsoleVariable* ConsoleVariable, const char* Value) {
			ConsoleVariable->Set(UTF8_TO_TCHAR(Value));
		}

		void SetOnChangedCallback(IConsoleVariable* ConsoleVariable, ConsoleVariableDelegate Callback) {
			auto callback = [Callback](IConsoleVariable* ConsoleVariable) {
				UnrealCLR::ManagedCommand(UnrealCLR::Command((void*)Callback));
			};

			ConsoleVariable->SetOnChangedCallback(FConsoleVariableDelegate::CreateLambda(callback));
		}

		void ClearOnChangedCallback(IConsoleVariable* ConsoleVariable) {
			FConsoleVariableDelegate emptyDelegate;

			ConsoleVariable->SetOnChangedCallback(emptyDelegate);
		}
	}

	namespace Actor {
		bool IsPendingKill(AActor* Actor) {
			return Actor->IsPendingKillPending();
		}

		bool IsRootComponentMovable(AActor* Actor) {
			return Actor->IsRootComponentMovable();
		}

		bool IsOverlappingActor(AActor* Actor, AActor* Other) {
			return Actor->IsOverlappingActor(Other);
		}

		void ForEachComponent(AActor* Actor, UActorComponent** Array, int32* Elements) {
			static TArray<UActorComponent*> components;

			components.Reset();

			Actor->GetComponents(components);

			int32 elements = components.Num();

			if (elements > 0) {
				*Array = reinterpret_cast<UActorComponent*>(components.GetData());
				*Elements = elements;
			}
		}

		void ForEachAttachedActor(AActor* Actor, AActor** Array, int32* Elements) {
			static TArray<AActor*> actors;

			actors.Reset();

			Actor->GetAttachedActors(actors);

			int32 elements = actors.Num();

			if (elements > 0) {
				*Array = reinterpret_cast<AActor*>(actors.GetData());
				*Elements = elements;
			}
		}

		void ForEachChildActor(AActor* Actor, AActor** Array, int32* Elements) {
			static TArray<AActor*> actors;

			actors.Reset();

			Actor->GetAllChildActors(actors);

			int32 elements = actors.Num();

			if (elements > 0) {
				*Array = reinterpret_cast<AActor*>(actors.GetData());
				*Elements = elements;
			}
		}

		void ForEachOverlappingActor(AActor* Actor, AActor** Array, int32* Elements) {
			static TArray<AActor*> overlappingActors;

			overlappingActors.Reset();

			Actor->GetOverlappingActors(overlappingActors);

			int32 elements = overlappingActors.Num();

			if (elements > 0) {
				*Array = reinterpret_cast<AActor*>(overlappingActors.GetData());
				*Elements = elements;
			}
		}

		AActor* Spawn(const char* Name, ActorType Type, UObject* Blueprint) {
			AActor* actor = nullptr;

			if (!Blueprint) {
				UNREALCLR_GET_ACTOR_TYPE(Type, UnrealCLR::Engine::World->SpawnActor UNREALCLR_BRACKET_LEFT, ::StaticClass() UNREALCLR_BRACKET_RIGHT, actor);
			} else {
				#if !WITH_EDITOR
					UNREALCLR_GET_ACTOR_TYPE(Type, UnrealCLR::Engine::World->SpawnActor<, >(Cast<UClass>(Blueprint)), actor);
				#else
					UNREALCLR_GET_ACTOR_TYPE(Type, UnrealCLR::Engine::World->SpawnActor<, >(Cast<UBlueprint>(Blueprint)->GeneratedClass), actor);
				#endif
			}

			if (actor && Name) {
				FString name(UTF8_TO_TCHAR(Name));

				actor->Rename(*name);

				#if WITH_EDITOR
					actor->SetActorLabel(*name);
				#endif
			}

			return actor;
		}

		bool Destroy(AActor* Actor) {
			return UnrealCLR::Engine::World->DestroyActor(Actor);
		}

		void Rename(AActor* Actor, const char* Name) {
			FString name(UTF8_TO_TCHAR(Name));

			Actor->Rename(*name);

			#if WITH_EDITOR
				Actor->SetActorLabel(*name);
			#endif
		}

		void Hide(AActor* Actor, bool Value) {
			Actor->SetActorHiddenInGame(Value);
		}

		bool TeleportTo(AActor* Actor, const Vector3* DestinationLocation, const Quaternion* DestinationRotation, bool IsATest, bool NoCheck) {
			return Actor->TeleportTo(*DestinationLocation, FRotator(*DestinationRotation), IsATest, NoCheck);
		}

		UActorComponent* GetComponent(AActor* Actor, const char* Name, ComponentType Type) {
			FString name;
			UActorComponent* component = nullptr;
			TSubclassOf<UActorComponent> type;

			if (Name)
				name = FString(UTF8_TO_TCHAR(Name));

			UNREALCLR_GET_COMPONENT_TYPE(Type, UNREALCLR_NONE, ::StaticClass(), type);

			for (UActorComponent* currentComponent : Actor->GetComponents()) {
				if (currentComponent && currentComponent->IsA(type) && (!Name || (Name && *currentComponent->GetName() == name))) {
					component = currentComponent;
					break;
				}
			}

			return component;
		}

		UActorComponent* GetComponentByTag(AActor* Actor, const char* Tag, ComponentType Type) {
			UActorComponent* component = nullptr;
			TSubclassOf<UActorComponent> type;
			FName tag(UTF8_TO_TCHAR(Tag));

			UNREALCLR_GET_COMPONENT_TYPE(Type, UNREALCLR_NONE, ::StaticClass(), type);

			for (UActorComponent* currentComponent : Actor->GetComponents()) {
				if (currentComponent->ComponentHasTag(tag)) {
					component = currentComponent;
					break;
				}
			}

			return component;
		}

		UActorComponent* GetComponentByID(AActor* Actor, uint32 ID, ComponentType Type) {
			UActorComponent* component = nullptr;
			TSubclassOf<UActorComponent> type;

			UNREALCLR_GET_COMPONENT_TYPE(Type, UNREALCLR_NONE, ::StaticClass(), type);

			for (UActorComponent* currentComponent : Actor->GetComponents()) {
				if (currentComponent->GetUniqueID() == ID) {
					component = currentComponent;
					break;
				}
			}

			return component;
		}

		USceneComponent* GetRootComponent(AActor* Actor, ComponentType Type) {
			USceneComponent* component = nullptr;
			USceneComponent* rootComponent = Actor->GetRootComponent();
			TSubclassOf<UActorComponent> type;

			UNREALCLR_GET_MOVABLE_COMPONENT_TYPE(Type, UNREALCLR_NONE, ::StaticClass(), type);

			if (rootComponent->IsA(type))
				component = rootComponent;

			return component;
		}

		UInputComponent* GetInputComponent(AActor* Actor) {
			return Actor->InputComponent;
		}

		float GetCreationTime(AActor* Actor) {
			return Actor->CreationTime;
		}

		bool GetBlockInput(AActor* Actor) {
			return Actor->bBlockInput;
		}

		float GetDistanceTo(AActor* Actor, AActor* Other) {
			return Actor->GetDistanceTo(Other);
		}

		float GetHorizontalDistanceTo(AActor* Actor, AActor* Other) {
			return Actor->GetDistanceTo(Other);
		}

		void GetBounds(AActor* Actor, bool OnlyCollidingComponents, Vector3* Origin, Vector3* Extent) {
			FVector origin, extent;

			Actor->GetActorBounds(OnlyCollidingComponents, origin, extent);

			*Origin = origin;
			*Extent = extent;
		}

		void GetEyesViewPoint(AActor* Actor, Vector3* Location, Quaternion* Rotation) {
			FVector location;
			FRotator rotation;

			Actor->GetActorEyesViewPoint(location, rotation);

			*Location = location;
			*Rotation = rotation.Quaternion();
		}

		bool SetRootComponent(AActor* Actor, USceneComponent* RootComponent) {
			return Actor->SetRootComponent(RootComponent);
		}

		void SetInputComponent(AActor* Actor, UInputComponent* InputComponent) {
			Actor->InputComponent = InputComponent;
		}

		void SetBlockInput(AActor* Actor, bool Value) {
			Actor->bBlockInput = Value;
		}

		void SetLifeSpan(AActor* Actor, float LifeSpan) {
			Actor->SetLifeSpan(LifeSpan);
		}

		void SetEnableInput(AActor* Actor, APlayerController* PlayerController, bool Value) {
			if (Value)
				Actor->EnableInput(PlayerController);
			else
				Actor->DisableInput(PlayerController);
		}

		void SetEnableCollision(AActor* Actor, bool Value) {
			Actor->SetActorEnableCollision(Value);
		}

		void AddTag(AActor* Actor, const char* Tag) {
			Actor->Tags.AddUnique(FName(UTF8_TO_TCHAR(Tag)));
		}

		void RemoveTag(AActor* Actor, const char* Tag) {
			Actor->Tags.Remove(FName(UTF8_TO_TCHAR(Tag)));
		}

		bool HasTag(AActor* Actor, const char* Tag) {
			return Actor->ActorHasTag(FName(UTF8_TO_TCHAR(Tag)));
		}

		void RegisterEvent(AActor* Actor, ActorEventType Type) {
			UNREALCLR_SET_ACTOR_EVENT(Type, !, AddDynamic);
		}

		void UnregisterEvent(AActor* Actor, ActorEventType Type) {
			UNREALCLR_SET_ACTOR_EVENT(Type, UNREALCLR_NONE, RemoveDynamic);
		}
	}

	namespace GameModeBase {
		bool GetUseSeamlessTravel(AGameModeBase* GameModeBase) {
			return GameModeBase->bUseSeamlessTravel;
		}

		void SetUseSeamlessTravel(AGameModeBase* GameModeBase, bool Value) {
			GameModeBase->bUseSeamlessTravel = Value;
		}

		void SwapPlayerControllers(AGameModeBase* GameModeBase, APlayerController* PlayerController, APlayerController* NewPlayerController) {
			GameModeBase->SwapPlayerControllers(PlayerController, NewPlayerController);
		}
	}

	namespace Pawn {
		bool IsControlled(APawn* Pawn) {
			return Pawn->IsPawnControlled();
		}

		bool IsPlayerControlled(APawn* Pawn) {
			return Pawn->IsPlayerControlled();
		}

		AutoPossessAI GetAutoPossessAI(APawn* Pawn) {
			return Pawn->AutoPossessAI;
		}

		AutoReceiveInput GetAutoPossessPlayer(APawn* Pawn) {
			return Pawn->AutoPossessPlayer;
		}

		bool GetUseControllerRotationYaw(APawn* Pawn) {
			return Pawn->bUseControllerRotationYaw;
		}

		bool GetUseControllerRotationPitch(APawn* Pawn) {
			return Pawn->bUseControllerRotationPitch;
		}

		bool GetUseControllerRotationRoll(APawn* Pawn) {
			return Pawn->bUseControllerRotationRoll;
		}

		void GetGravityDirection(APawn* Pawn, Vector3* Value) {
			*Value = Pawn->GetGravityDirection();
		}

		AAIController* GetAIController(APawn* Pawn) {
			return Cast<AAIController>(Pawn->GetController());
		}

		APlayerController* GetPlayerController(APawn* Pawn) {
			return Cast<APlayerController>(Pawn->GetController());
		}

		void SetAutoPossessAI(APawn* Pawn, AutoPossessAI Value) {
			Pawn->AutoPossessAI = Value;
		}

		void SetAutoPossessPlayer(APawn* Pawn, AutoReceiveInput Value) {
			Pawn->AutoPossessPlayer = Value;
		}

		void SetUseControllerRotationYaw(APawn* Pawn, bool Value) {
			Pawn->bUseControllerRotationYaw = Value;
		}

		void SetUseControllerRotationPitch(APawn* Pawn, bool Value) {
			Pawn->bUseControllerRotationPitch = Value;
		}

		void SetUseControllerRotationRoll(APawn* Pawn, bool Value) {
			Pawn->bUseControllerRotationRoll = Value;
		}

		void AddControllerYawInput(APawn* Pawn, float Value) {
			Pawn->AddControllerYawInput(Value);
		}

		void AddControllerPitchInput(APawn* Pawn, float Value) {
			Pawn->AddControllerPitchInput(Value);
		}

		void AddControllerRollInput(APawn* Pawn, float Value) {
			Pawn->AddControllerRollInput(Value);
		}

		void AddMovementInput(APawn* Pawn, const Vector3* WorldDirection, float ScaleValue, bool Force) {
			Pawn->AddMovementInput(*WorldDirection, ScaleValue, Force);
		}
	}

	namespace Character {
		bool IsCrouched(ACharacter* Character) {
			return Character->bIsCrouched;
		}

		bool CanCrouch(ACharacter* Character) {
			return Character->CanCrouch();
		}

		bool CanJump(ACharacter* Character) {
			return Character->CanJump();
		}

		void CheckJumpInput(ACharacter* Character, float DeltaTime) {
			Character->CheckJumpInput(DeltaTime);
		}

		void ClearJumpInput(ACharacter* Character, float DeltaTime) {
			Character->ClearJumpInput(DeltaTime);
		}

		void Launch(ACharacter* Character, const Vector3* Velocity, bool OverrideXY, bool OverrideZ) {
			Character->LaunchCharacter(*Velocity, OverrideXY, OverrideZ);
		}

		void Crouch(ACharacter* Character) {
			Character->Crouch();
		}

		void StopCrouching(ACharacter* Character) {
			Character->UnCrouch();
		}

		void Jump(ACharacter* Character) {
			Character->Jump();
		}

		void StopJumping(ACharacter* Character) {
			Character->StopJumping();
		}

		void SetOnLandedCallback(ACharacter* Character, CharacterLandedDelegate Callback) {
			UUnrealCLRCharacter* character = NewObject<UUnrealCLRCharacter>(Character);

			character->LandedCallback = (void*)Callback;

			Character->LandedDelegate.AddDynamic(character, &UUnrealCLRCharacter::Landed);
		}
	}

	namespace Controller {
		bool IsLookInputIgnored(AController* Controller) {
			return Controller->IsLookInputIgnored();
		}

		bool IsMoveInputIgnored(AController* Controller) {
			return Controller->IsMoveInputIgnored();
		}

		bool IsPlayerController(AController* Controller) {
			return Controller->IsPlayerController();
		}

		APawn* GetPawn(AController* Controller) {
			return Controller->GetPawn();
		}

		ACharacter* GetCharacter(AController* Controller) {
			return Controller->GetCharacter();
		}

		AActor* GetViewTarget(AController* Controller) {
			return Controller->GetViewTarget();
		}

		void GetControlRotation(AController* Controller, Quaternion* Value) {
			*Value = Controller->GetControlRotation().Quaternion();
		}

		void GetDesiredRotation(AController* Controller, Quaternion* Value) {
			*Value = Controller->GetDesiredRotation().Quaternion();
		}

		bool LineOfSightTo(AController* Controller, AActor* Actor, const Vector3* ViewPoint, bool AlternateChecks) {
			return Controller->LineOfSightTo(Actor, *ViewPoint, AlternateChecks);
		}

		void SetControlRotation(AController* Controller, const Quaternion* Value) {
			Controller->SetControlRotation(FRotator(*Value));
		}

		void SetInitialLocationAndRotation(AController* Controller, const Vector3* NewLocation, const Quaternion* NewRotation) {
			Controller->SetInitialLocationAndRotation(*NewLocation, FRotator(*NewRotation));
		}

		void SetIgnoreLookInput(AController* Controller, bool Value) {
			Controller->SetIgnoreLookInput(Value);
		}

		void SetIgnoreMoveInput(AController* Controller, bool Value) {
			Controller->SetIgnoreMoveInput(Value);
		}

		void ResetIgnoreLookInput(AController* Controller) {
			Controller->ResetIgnoreLookInput();
		}

		void ResetIgnoreMoveInput(AController* Controller) {
			Controller->ResetIgnoreMoveInput();
		}

		void Possess(AController* Controller, APawn* Pawn) {
			Controller->Possess(Pawn);
		}

		void Unpossess(AController* Controller) {
			Controller->UnPossess();
		}
	}

	namespace AIController {
		void ClearFocus(AAIController* AIController, AIFocusPriority Priority) {
			AIController->ClearFocus(static_cast<EAIFocusPriority::Type>(Priority));
		}

		void GetFocalPoint(AAIController* AIController, Vector3* Value) {
			*Value = AIController->GetFocalPoint();
		}

		void SetFocalPoint(AAIController* AIController, const Vector3* NewFocus, AIFocusPriority Priority) {
			AIController->SetFocalPoint(*NewFocus, static_cast<EAIFocusPriority::Type>(Priority));
		}

		AActor* GetFocusActor(AAIController* AIController) {
			return AIController->GetFocusActor();
		}

		bool GetAllowStrafe(AAIController* AIController) {
			return AIController->bAllowStrafe;
		}

		void SetAllowStrafe(AAIController* AIController, bool Value) {
			AIController->bAllowStrafe = Value;
		}

		void SetFocus(AAIController* AIController, AActor* NewFocus, AIFocusPriority Priority) {
			AIController->SetFocus(NewFocus, static_cast<EAIFocusPriority::Type>(Priority));
		}
	}

	namespace PlayerController {
		bool IsPaused(APlayerController* PlayerController) {
			return PlayerController->IsPaused();
		}

		bool GetShowMouseCursor(APlayerController* PlayerController) {
			return PlayerController->bShowMouseCursor;
		}

		bool GetEnableClickEvents(APlayerController* PlayerController) {
			return PlayerController->bEnableClickEvents;
		}

		bool GetEnableMouseOverEvents(APlayerController* PlayerController) {
			return PlayerController->bEnableMouseOverEvents;
		}

		bool GetMousePosition(APlayerController* PlayerController, float* X, float* Y) {
			return PlayerController->GetMousePosition(*X, *Y);
		}

		UPlayer* GetPlayer(APlayerController* PlayerController) {
			return PlayerController->Player;
		}

		UPlayerInput* GetPlayerInput(APlayerController* PlayerController) {
			return PlayerController->PlayerInput;
		}

		bool GetHitResultAtScreenPosition(APlayerController* PlayerController, const Vector2* ScreenPosition, CollisionChannel TraceChannel, Hit* Hit, bool TraceComplex) {
			FHitResult hit;

			bool result = PlayerController->GetHitResultAtScreenPosition(*ScreenPosition, TraceChannel, TraceComplex, hit);

			*Hit = hit;

			return result;
		}

		bool GetHitResultUnderCursor(APlayerController* PlayerController, CollisionChannel TraceChannel, Hit* Hit, bool TraceComplex) {
			FHitResult hit;

			bool result = PlayerController->GetHitResultUnderCursor(TraceChannel, TraceComplex, hit);

			*Hit = hit;

			return result;
		}

		void SetShowMouseCursor(APlayerController* PlayerController, bool Value) {
			PlayerController->bShowMouseCursor = Value;
		}

		void SetEnableClickEvents(APlayerController* PlayerController, bool Value) {
			PlayerController->bEnableClickEvents = Value;
		}

		void SetEnableMouseOverEvents(APlayerController* PlayerController, bool Value) {
			PlayerController->bEnableMouseOverEvents = Value;
		}

		void SetMousePosition(APlayerController* PlayerController, float X, float Y) {
			PlayerController->SetMouseLocation(static_cast<int32>(X), static_cast<int32>(Y));
		}

		void ConsoleCommand(APlayerController* PlayerController, const char* Command, bool WriteToLog) {
			PlayerController->ConsoleCommand(FString(UTF8_TO_TCHAR(Command)), WriteToLog);
		}

		bool SetPause(APlayerController* PlayerController, bool Value) {
			return PlayerController->SetPause(Value);
		}

		void SetViewTarget(APlayerController* PlayerController, AActor* NewViewTarget) {
			PlayerController->SetViewTarget(NewViewTarget);
		}

		void SetViewTargetWithBlend(APlayerController* PlayerController, AActor* NewViewTarget, float Time, float Exponent, BlendType Type, bool LockOutgoing) {
			PlayerController->SetViewTargetWithBlend(NewViewTarget, Time, Type, Exponent, LockOutgoing);
		}

		void AddYawInput(APlayerController* PlayerController, float Value) {
			PlayerController->AddYawInput(Value);
		}

		void AddPitchInput(APlayerController* PlayerController, float Value) {
			PlayerController->AddPitchInput(Value);
		}

		void AddRollInput(APlayerController* PlayerController, float Value) {
			PlayerController->AddRollInput(Value);
		}
	}

	namespace Volume {
		bool EncompassesPoint(AVolume* Volume, const Vector3* Point, float SphereRadius, float* DistanceToPoint) {
			return Volume->EncompassesPoint(*Point, SphereRadius, DistanceToPoint);
		}
	}

	namespace PostProcessVolume {
		bool GetEnabled(APostProcessVolume* PostProcessVolume) {
			return PostProcessVolume->bEnabled;
		}

		float GetBlendRadius(APostProcessVolume* PostProcessVolume) {
			return PostProcessVolume->BlendRadius;
		}

		float GetBlendWeight(APostProcessVolume* PostProcessVolume) {
			return PostProcessVolume->BlendWeight;
		}

		bool GetUnbound(APostProcessVolume* PostProcessVolume) {
			return PostProcessVolume->bUnbound;
		}

		float GetPriority(APostProcessVolume* PostProcessVolume) {
			return PostProcessVolume->Priority;
		}

		void SetEnabled(APostProcessVolume* PostProcessVolume, bool Value) {
			PostProcessVolume->bEnabled = Value;
		}

		void SetBlendRadius(APostProcessVolume* PostProcessVolume, float Value) {
			PostProcessVolume->BlendRadius = Value;
		}

		void SetBlendWeight(APostProcessVolume* PostProcessVolume, float Value) {
			PostProcessVolume->BlendWeight = Value;
		}

		void SetUnbound(APostProcessVolume* PostProcessVolume, bool Value) {
			PostProcessVolume->bUnbound = Value;
		}

		void SetPriority(APostProcessVolume* PostProcessVolume, float Priority) {
			PostProcessVolume->Priority = Priority;
		}
	}

	namespace SoundBase {
		float GetDuration(USoundBase* SoundBase) {
			return SoundBase->Duration;
		}
	}

	namespace SoundWave {
		bool GetLoop(USoundWave* SoundWave) {
			return SoundWave->bLooping;
		}

		void SetLoop(USoundWave* SoundWave, bool Value) {
			SoundWave->bLooping = Value;
		}
	}

	namespace AnimationInstance {
		UAnimMontage* GetCurrentActiveMontage(UAnimInstance* AnimationInstance) {
			return AnimationInstance->GetCurrentActiveMontage();
		}

		bool IsPlaying(UAnimInstance* AnimationInstance, UAnimMontage* Montage) {
			return AnimationInstance->Montage_IsPlaying(Montage);
		}

		float GetPlayRate(UAnimInstance* AnimationInstance, UAnimMontage* Montage) {
			return AnimationInstance->Montage_GetPlayRate(Montage);
		}

		float GetPosition(UAnimInstance* AnimationInstance, UAnimMontage* Montage) {
			return AnimationInstance->Montage_GetPosition(Montage);
		}

		float GetBlendTime(UAnimInstance* AnimationInstance, UAnimMontage* Montage) {
			return AnimationInstance->Montage_GetBlendTime(Montage);
		}

		void GetCurrentSection(UAnimInstance* AnimationInstance, UAnimMontage* Montage, char* SectionName) {
			const char* sectionName = TCHAR_TO_UTF8(*AnimationInstance->Montage_GetCurrentSection(Montage).ToString());

			UnrealCLR::Utility::Strcpy(SectionName, sectionName, UnrealCLR::Utility::Strlen(sectionName));
		}

		void SetPlayRate(UAnimInstance* AnimationInstance, UAnimMontage* Montage, float Value) {
			AnimationInstance->Montage_SetPlayRate(Montage, Value);
		}

		void SetPosition(UAnimInstance* AnimationInstance, UAnimMontage* Montage, float Position) {
			AnimationInstance->Montage_SetPosition(Montage, Position);
		}

		void SetNextSection(UAnimInstance* AnimationInstance, UAnimMontage* Montage, const char* SectionToChange, const char* NextSection) {
			AnimationInstance->Montage_SetNextSection(FName(UTF8_TO_TCHAR(SectionToChange)), FName(UTF8_TO_TCHAR(NextSection)), Montage);
		}

		float PlayMontage(UAnimInstance* AnimationInstance, UAnimMontage* Montage, float PlayRate, float TimeToStartMontageAt, bool StopAllMontages) {
			return AnimationInstance->Montage_Play(Montage, PlayRate, EMontagePlayReturnType::MontageLength, TimeToStartMontageAt, StopAllMontages);
		}

		void PauseMontage(UAnimInstance* AnimationInstance, UAnimMontage* Montage) {
			AnimationInstance->Montage_Pause(Montage);
		}

		void ResumeMontage(UAnimInstance* AnimationInstance, UAnimMontage* Montage) {
			AnimationInstance->Montage_Resume(Montage);
		}

		void StopMontage(UAnimInstance* AnimationInstance, UAnimMontage* Montage, float BlendOutTime) {
			AnimationInstance->Montage_Stop(BlendOutTime, Montage);
		}

		void JumpToSection(UAnimInstance* AnimationInstance, UAnimMontage* Montage, const char* SectionName) {
			AnimationInstance->Montage_JumpToSection(FName(UTF8_TO_TCHAR(SectionName)), Montage);
		}

		void JumpToSectionsEnd(UAnimInstance* AnimationInstance, UAnimMontage* Montage, const char* SectionName) {
			AnimationInstance->Montage_JumpToSectionsEnd(FName(UTF8_TO_TCHAR(SectionName)), Montage);
		}
	}

	namespace Player {
		APlayerController* GetPlayerController(UPlayer* Player) {
			return Player->GetPlayerController(UnrealCLR::Engine::World);
		}
	}

	namespace PlayerInput {
		bool IsKeyPressed(UPlayerInput* PlayerInput, const char* Key) {
			return PlayerInput->IsPressed(FKey(UTF8_TO_TCHAR(Key)));
		}

		float GetTimeKeyPressed(UPlayerInput* PlayerInput, const char* Key) {
			return PlayerInput->GetTimeDown(FKey(UTF8_TO_TCHAR(Key)));
		}

		void GetMouseSensitivity(UPlayerInput* PlayerInput, Vector2* Value) {
			Value->X = PlayerInput->GetMouseSensitivityX();
			Value->Y = PlayerInput->GetMouseSensitivityY();
		}

		void SetMouseSensitivity(UPlayerInput* PlayerInput, const Vector2* Value) {
			PlayerInput->SetMouseSensitivity(Value->X, Value->Y);
		}

		void AddActionMapping(UPlayerInput* PlayerInput, const char* ActionName, const char* Key, bool Shift, bool Ctrl, bool Alt, bool Cmd) {
			PlayerInput->AddActionMapping(FInputActionKeyMapping(FName(UTF8_TO_TCHAR(ActionName)), FKey(UTF8_TO_TCHAR(Key)), Shift, Ctrl, Alt, Cmd));
		}

		void AddAxisMapping(UPlayerInput* PlayerInput, const char* AxisName, const char* Key, float Scale) {
			PlayerInput->AddAxisMapping(FInputAxisKeyMapping(FName(UTF8_TO_TCHAR(AxisName)), FKey(UTF8_TO_TCHAR(Key)), Scale));
		}

		void RemoveActionMapping(UPlayerInput* PlayerInput, const char* ActionName, const char* Key) {
			PlayerInput->RemoveActionMapping(FInputActionKeyMapping(FName(UTF8_TO_TCHAR(ActionName)), FKey(UTF8_TO_TCHAR(Key))));
		}

		void RemoveAxisMapping(UPlayerInput* PlayerInput, const char* AxisName, const char* Key) {
			PlayerInput->RemoveAxisMapping(FInputAxisKeyMapping(FName(UTF8_TO_TCHAR(AxisName)), FKey(UTF8_TO_TCHAR(Key))));
		}
	}

	namespace Font {
		void GetStringSize(UFont* Font, const char* Text, int32* Height, int32* Width) {
			int32 height, width;

			Font->GetStringHeightAndWidth(UTF8_TO_TCHAR(Text), height, width);

			*Height = height;
			*Width = width;
		}
	}

	namespace Texture2D {
		UTexture2D* CreateFromFile(const char* FilePath) {
			return FImageUtils::ImportFileAsTexture2D(FString(UTF8_TO_TCHAR(FilePath)));
		}

		UTexture2D* CreateFromBuffer(const uint8* Buffer, int32 Length) {
			return FImageUtils::ImportBufferAsTexture2D(TArray<uint8>(Buffer, Length));
		}

		bool HasAlphaChannel(UTexture2D* Texture2D) {
			return Texture2D->HasAlphaChannel();
		}

		void GetSize(UTexture2D* Texture2D, Vector2* Value) {
			Value->X = Texture2D->GetSizeX();
			Value->Y = Texture2D->GetSizeY();
		}

		PixelFormat GetPixelFormat(UTexture2D* Texture2D) {
			return Texture2D->GetPixelFormat();
		}
	}

	namespace ActorComponent {
		bool IsOwnerSelected(UActorComponent* ActorComponent) {
			return ActorComponent->IsOwnerSelected();
		}

		AActor* GetOwner(UActorComponent* ActorComponent, ActorType Type) {
			AActor* actor = nullptr;

			UNREALCLR_GET_ACTOR_TYPE(Type, Cast<, >(ActorComponent->GetOwner()), actor);

			return actor;
		}

		void Destroy(UActorComponent* ActorComponent, bool PromoteChild) {
			ActorComponent->DestroyComponent(PromoteChild);
		}

		void AddTag(UActorComponent* ActorComponent, const char* Tag) {
			ActorComponent->ComponentTags.AddUnique(FName(UTF8_TO_TCHAR(Tag)));
		}

		void RemoveTag(UActorComponent* ActorComponent, const char* Tag) {
			ActorComponent->ComponentTags.Remove(FName(UTF8_TO_TCHAR(Tag)));
		}

		bool HasTag(UActorComponent* ActorComponent, const char* Tag) {
			return ActorComponent->ComponentHasTag(FName(UTF8_TO_TCHAR(Tag)));
		}
	}

	namespace InputComponent {
		bool HasBindings(UInputComponent* InputComponent) {
			return InputComponent->HasBindings();
		}

		int32 GetActionBindingsNumber(UInputComponent* InputComponent) {
			return InputComponent->GetNumActionBindings();
		}

		void ClearActionBindings(UInputComponent* InputComponent) {
			InputComponent->ClearActionBindings();
		}

		void BindAction(UInputComponent* InputComponent, const char* ActionName, InputEvent KeyEvent, bool ExecutedWhenPaused, InputDelegate Callback) {
			FInputActionBinding actionBinding(FName(UTF8_TO_TCHAR(ActionName)), KeyEvent);

			actionBinding.bExecuteWhenPaused = ExecutedWhenPaused;
			actionBinding.ActionDelegate.GetDelegateForManualSet().BindLambda([Callback]() {
				UnrealCLR::ManagedCommand(UnrealCLR::Command((void*)Callback));
			});

			InputComponent->AddActionBinding(actionBinding);
		}

		void BindAxis(UInputComponent* InputComponent, const char* AxisName, bool ExecutedWhenPaused, InputAxisDelegate Callback) {
			FInputAxisBinding axisBinding(FName(UTF8_TO_TCHAR(AxisName)));

			axisBinding.bExecuteWhenPaused = ExecutedWhenPaused;
			axisBinding.AxisDelegate.GetDelegateForManualSet().BindLambda([Callback](float AxisValue) {
				UnrealCLR::ManagedCommand(UnrealCLR::Command((void*)Callback, AxisValue));
			});

			InputComponent->AxisBindings.Emplace(axisBinding);
		}

		void RemoveActionBinding(UInputComponent* InputComponent, const char* ActionName, InputEvent KeyEvent) {
			InputComponent->RemoveActionBinding(FName(UTF8_TO_TCHAR(ActionName)), KeyEvent);
		}

		bool GetBlockInput(UInputComponent* InputComponent) {
			return InputComponent->bBlockInput;
		}

		void SetBlockInput(UInputComponent* InputComponent, bool Value) {
			InputComponent->bBlockInput = Value;
		}

		int32 GetPriority(UInputComponent* InputComponent) {
			return InputComponent->Priority;
		}

		void SetPriority(UInputComponent* InputComponent, int32 Value) {
			InputComponent->Priority = Value;
		}
	}

	namespace MovementComponent {
		bool GetConstrainToPlane(UMovementComponent* MovementComponent) {
			return MovementComponent->bConstrainToPlane;
		}

		bool GetSnapToPlaneAtStart(UMovementComponent* MovementComponent) {
			return MovementComponent->bSnapToPlaneAtStart;
		}

		bool GetUpdateOnlyIfRendered(UMovementComponent* MovementComponent) {
			return MovementComponent->bUpdateOnlyIfRendered;
		}

		void GetVelocity(UMovementComponent* MovementComponent, Vector3* Value) {
			*Value = MovementComponent->Velocity;
		}

		PlaneConstraintAxis GetPlaneConstraint(UMovementComponent* MovementComponent) {
			return MovementComponent->GetPlaneConstraintAxisSetting();
		}

		void GetPlaneConstraintNormal(UMovementComponent* MovementComponent, Vector3* Value) {
			*Value = MovementComponent->GetPlaneConstraintNormal();
		}

		void GetPlaneConstraintOrigin(UMovementComponent* MovementComponent, Vector3* Value) {
			*Value = MovementComponent->GetPlaneConstraintOrigin();
		}

		float GetGravity(UMovementComponent* MovementComponent) {
			return MovementComponent->GetGravityZ();
		}

		float GetMaxSpeed(UMovementComponent* MovementComponent) {
			return MovementComponent->GetMaxSpeed();
		}

		void SetConstrainToPlane(UMovementComponent* MovementComponent, bool Value) {
			MovementComponent->bConstrainToPlane = Value;
		}

		void SetSnapToPlaneAtStart(UMovementComponent* MovementComponent, bool Value) {
			MovementComponent->bSnapToPlaneAtStart = Value;
		}

		void SetUpdateOnlyIfRendered(UMovementComponent* MovementComponent, bool Value) {
			MovementComponent->bUpdateOnlyIfRendered = Value;
		}

		void SetVelocity(UMovementComponent* MovementComponent, const Vector3* Value) {
			MovementComponent->Velocity = *Value;
		}

		void SetPlaneConstraint(UMovementComponent* MovementComponent, PlaneConstraintAxis Value) {
			MovementComponent->SetPlaneConstraintAxisSetting(Value);
		}

		void SetPlaneConstraintNormal(UMovementComponent* MovementComponent, const Vector3* Value) {
			MovementComponent->SetPlaneConstraintNormal(*Value);
		}

		 void SetPlaneConstraintOrigin(UMovementComponent* MovementComponent, const Vector3* Value) {
			MovementComponent->SetPlaneConstraintOrigin(*Value);
		 }

		void SetPlaneConstraintFromVectors(UMovementComponent* MovementComponent, const Vector3* Forward, const Vector3* Up) {
			MovementComponent->SetPlaneConstraintFromVectors(*Forward, *Up);
		}

		bool IsExceedingMaxSpeed(UMovementComponent* MovementComponent, float MaxSpeed) {
			return MovementComponent->IsExceedingMaxSpeed(MaxSpeed);
		}

		bool IsInWater(UMovementComponent* MovementComponent) {
			return MovementComponent->IsInWater();
		}

		void StopMovement(UMovementComponent* MovementComponent) {
			MovementComponent->StopMovementImmediately();
		}

		void ConstrainDirectionToPlane(UMovementComponent* MovementComponent, const Vector3* Direction, Vector3* Value) {
			*Value = MovementComponent->ConstrainDirectionToPlane(*Direction);
		}

		void ConstrainLocationToPlane(UMovementComponent* MovementComponent, const Vector3* Location, Vector3* Value) {
			*Value = MovementComponent->ConstrainLocationToPlane(*Location);
		}

		void ConstrainNormalToPlane(UMovementComponent* MovementComponent, const Vector3* Normal, Vector3* Value) {
			*Value = MovementComponent->ConstrainNormalToPlane(*Normal);
		}
	}

	namespace RotatingMovementComponent {
		URotatingMovementComponent* Create(AActor* Actor, const char* Name) {
			URotatingMovementComponent* component = NewObject<URotatingMovementComponent>(Actor);

			UNREALCLR_SET_COMPONENT_INSTANCE(component, Name);

			return component;
		}

		bool GetRotationInLocalSpace(URotatingMovementComponent* RotatingMovementComponent) {
			return RotatingMovementComponent->bRotationInLocalSpace;
		}

		void GetPivotTranslation(URotatingMovementComponent* RotatingMovementComponent, Vector3* Value) {
			*Value = RotatingMovementComponent->PivotTranslation;
		}

		void GetRotationRate(URotatingMovementComponent* RotatingMovementComponent, Quaternion* Value) {
			*Value = RotatingMovementComponent->RotationRate.Quaternion();
		}

		void SetRotationInLocalSpace(URotatingMovementComponent* RotatingMovementComponent, bool Value) {
			RotatingMovementComponent->bRotationInLocalSpace = Value;
		}

		void SetPivotTranslation(URotatingMovementComponent* RotatingMovementComponent, const Vector3* Value) {
			RotatingMovementComponent->PivotTranslation = *Value;
		}

		void SetRotationRate(URotatingMovementComponent* RotatingMovementComponent, const Quaternion* Value) {
			RotatingMovementComponent->RotationRate = FRotator(*Value);
		}
	}

	namespace SceneComponent {
		bool IsAttachedToComponent(USceneComponent* SceneComponent, USceneComponent* Component) {
			return SceneComponent->IsAttachedTo(Component);
		}

		bool IsAttachedToActor(USceneComponent* SceneComponent, AActor* Actor) {
			USceneComponent* Component = SceneComponent;

			while (Component) {
				if (Component->GetOwner() == Actor)
					return true;

				Component = Component->GetAttachParent();
			}

			return false;
		}

		bool IsVisible(USceneComponent* SceneComponent) {
			return SceneComponent->IsVisible();
		}

		bool IsSocketExists(USceneComponent* SceneComponent, const char* SocketName) {
			return SceneComponent->DoesSocketExist(FName(UTF8_TO_TCHAR(SocketName)));
		}

		bool HasAnySockets(USceneComponent* SceneComponent) {
			return SceneComponent->HasAnySockets();
		}

		bool CanAttachAsChild(USceneComponent* SceneComponent, USceneComponent* ChildComponent, const char* SocketName) {
			return SceneComponent->CanAttachAsChild(ChildComponent, FName(UTF8_TO_TCHAR(SocketName)));
		}

		void ForEachAttachedChild(USceneComponent* SceneComponent, USceneComponent** Array, int32* Elements) {
			static TArray<USceneComponent*> attachedComponents;

			attachedComponents.Reset();

			attachedComponents = SceneComponent->GetAttachChildren();

			int32 elements = attachedComponents.Num();

			if (elements > 0) {
				*Array = reinterpret_cast<USceneComponent*>(attachedComponents.GetData());
				*Elements = elements;
			}
		}

		USceneComponent* Create(AActor* Actor, ComponentType Type, const char* Name, bool SetAsRoot, UObject* Blueprint) {
			USceneComponent* component = nullptr;

			if (!Blueprint) {
				UNREALCLR_GET_MOVABLE_COMPONENT_TYPE(Type, NewObject<, >(Actor), component);
			} else {
				#if !WITH_EDITOR
					UNREALCLR_GET_MOVABLE_COMPONENT_TYPE(Type, NewObject<, >(Actor, Cast<UClass>(Blueprint)), component);
				#else
					UNREALCLR_GET_MOVABLE_COMPONENT_TYPE(Type, NewObject<, >(Actor, Cast<UBlueprint>(Blueprint)->GeneratedClass), component);
				#endif
			}

			if (component) {
				USceneComponent* rootComponent = Actor->GetRootComponent();

				if (!rootComponent || SetAsRoot)
					Actor->SetRootComponent(component);
				else
					component->AttachToComponent(rootComponent, FAttachmentTransformRules::KeepRelativeTransform);

				UNREALCLR_SET_COMPONENT_INSTANCE(component, Name);
			}

			return component;
		}

		bool AttachToComponent(USceneComponent* SceneComponent, USceneComponent* Parent, AttachmentTransformRule AttachmentRule, const char* SocketName) {
			FAttachmentTransformRules attachmentRules = FAttachmentTransformRules::KeepRelativeTransform;
			FName socketName;

			UNREALCLR_GET_ATTACHMENT_RULE(AttachmentRule, attachmentRules);

			if (SocketName)
				socketName = FName(UTF8_TO_TCHAR(SocketName));

			return SceneComponent->AttachToComponent(Parent, attachmentRules, socketName);
		}

		void DetachFromComponent(USceneComponent* SceneComponent, DetachmentTransformRule DetachmentRule) {
			FDetachmentTransformRules detachmentRules = FDetachmentTransformRules::KeepRelativeTransform;

			UNREALCLR_GET_DETACHMENT_RULE(DetachmentRule, detachmentRules);

			SceneComponent->DetachFromComponent(detachmentRules);
		}

		void Activate(USceneComponent* SceneComponent) {
			SceneComponent->Activate();
		}

		void Deactivate(USceneComponent* SceneComponent) {
			SceneComponent->Deactivate();
		}

		void UpdateToWorld(USceneComponent* SceneComponent, TeleportType Type, UpdateTransformFlags Flags) {
			SceneComponent->UpdateComponentToWorld(static_cast<EUpdateTransformFlags>(Flags), Type);
		}

		void AddLocalOffset(USceneComponent* SceneComponent, const Vector3* DeltaLocation) {
			SceneComponent->AddLocalOffset(*DeltaLocation);
		}

		void AddLocalRotation(USceneComponent* SceneComponent, const Quaternion* DeltaRotation) {
			SceneComponent->AddLocalRotation(*DeltaRotation);
		}

		void AddRelativeLocation(USceneComponent* SceneComponent, const Vector3* DeltaLocation) {
			SceneComponent->AddRelativeLocation(*DeltaLocation);
		}

		void AddRelativeRotation(USceneComponent* SceneComponent, const Quaternion* DeltaRotation) {
			SceneComponent->AddRelativeRotation(*DeltaRotation);
		}

		void AddLocalTransform(USceneComponent* SceneComponent, const Transform* DeltaTransform) {
			SceneComponent->AddLocalTransform(*DeltaTransform);
		}

		void AddWorldOffset(USceneComponent* SceneComponent, const Vector3* DeltaLocation) {
			SceneComponent->AddWorldOffset(*DeltaLocation);
		}

		void AddWorldRotation(USceneComponent* SceneComponent, const Quaternion* DeltaRotation) {
			SceneComponent->AddWorldRotation(*DeltaRotation);
		}

		void AddWorldTransform(USceneComponent* SceneComponent, const Transform* DeltaTransform) {
			SceneComponent->AddWorldTransform(*DeltaTransform);
		}

		void GetAttachedSocketName(USceneComponent* SceneComponent, char* SocketName) {
			const char* socketName = TCHAR_TO_UTF8(*SceneComponent->GetAttachSocketName().ToString());

			UnrealCLR::Utility::Strcpy(SocketName, socketName, UnrealCLR::Utility::Strlen(socketName));
		}

		void GetBounds(USceneComponent* SceneComponent, const Transform* LocalToWorld, Bounds* Value) {
			*Value = SceneComponent->CalcBounds(*LocalToWorld);
		}

		void GetSocketLocation(USceneComponent* SceneComponent, const char* SocketName, Vector3* Value) {
			*Value = SceneComponent->GetSocketLocation(FName(UTF8_TO_TCHAR(SocketName)));
		}

		void GetSocketRotation(USceneComponent* SceneComponent, const char* SocketName, Quaternion* Value) {
			*Value = SceneComponent->GetSocketQuaternion(FName(UTF8_TO_TCHAR(SocketName)));
		}

		void GetComponentVelocity(USceneComponent* SceneComponent, Vector3* Value) {
			*Value = SceneComponent->GetComponentVelocity();
		}

		void GetComponentLocation(USceneComponent* SceneComponent, Vector3* Value) {
			*Value = SceneComponent->GetComponentLocation();
		}

		void GetComponentRotation(USceneComponent* SceneComponent, Quaternion* Value) {
			*Value = SceneComponent->GetComponentQuat();
		}

		void GetComponentScale(USceneComponent* SceneComponent, Vector3* Value) {
			*Value = SceneComponent->GetComponentScale();
		}

		void GetComponentTransform(USceneComponent* SceneComponent, Transform* Value) {
			*Value = SceneComponent->GetComponentTransform();
		}

		void GetForwardVector(USceneComponent* SceneComponent, Vector3* Value) {
			*Value = SceneComponent->GetForwardVector();
		}

		void GetRightVector(USceneComponent* SceneComponent, Vector3* Value) {
			*Value = SceneComponent->GetRightVector();
		}

		void GetUpVector(USceneComponent* SceneComponent, Vector3* Value) {
			*Value = SceneComponent->GetUpVector();
		}

		void SetMobility(USceneComponent* SceneComponent, ComponentMobility Mobility) {
			SceneComponent->SetMobility(Mobility);
		}

		void SetVisibility(USceneComponent* SceneComponent, bool NewVisibility, bool PropagateToChildren) {
			SceneComponent->SetVisibility(NewVisibility, PropagateToChildren);
		}

		void SetRelativeLocation(USceneComponent* SceneComponent, const Vector3* Location) {
			SceneComponent->SetRelativeLocation(*Location);
		}

		void SetRelativeRotation(USceneComponent* SceneComponent, const Quaternion* Rotation) {
			SceneComponent->SetRelativeRotation(*Rotation);
		}

		void SetRelativeTransform(USceneComponent* SceneComponent, const Transform* Transform) {
			SceneComponent->SetRelativeTransform(*Transform);
		}

		void SetWorldLocation(USceneComponent* SceneComponent, const Vector3* Location) {
			SceneComponent->SetWorldLocation(*Location);
		}

		void SetWorldRotation(USceneComponent* SceneComponent, const Quaternion* Rotation) {
			SceneComponent->SetWorldRotation(*Rotation);
		}

		void SetWorldScale(USceneComponent* SceneComponent, const Vector3* Scale) {
			SceneComponent->SetWorldScale3D(*Scale);
		}

		void SetWorldTransform(USceneComponent* SceneComponent, const Transform* Transform) {
			SceneComponent->SetWorldTransform(*Transform);
		}
	}

	namespace AudioComponent {
		bool IsPlaying(UAudioComponent* AudioComponent) {
			return AudioComponent->IsPlaying();
		}

		bool GetPaused(UAudioComponent* AudioComponent) {
			return AudioComponent->bIsPaused;
		}

		void SetSound(UAudioComponent* AudioComponent, USoundBase* Sound) {
			AudioComponent->SetSound(Sound);
		}

		void SetPaused(UAudioComponent* AudioComponent, bool Value) {
			AudioComponent->SetPaused(Value);
		}

		void Play(UAudioComponent* AudioComponent) {
			AudioComponent->Play();
		}

		void Stop(UAudioComponent* AudioComponent) {
			AudioComponent->Stop();
		}

		void FadeIn(UAudioComponent* AudioComponent, float Duration, float VolumeLevel, float StartTime, AudioFadeCurve FadeCurve) {
			AudioComponent->FadeIn(Duration, VolumeLevel, StartTime, FadeCurve);
		}

		void FadeOut(UAudioComponent* AudioComponent, float Duration, float VolumeLevel, AudioFadeCurve FadeCurve) {
			AudioComponent->FadeOut(Duration, VolumeLevel, FadeCurve);
		}
	}

	namespace CameraComponent {
		bool GetConstrainAspectRatio(UCameraComponent* CameraComponent) {
			return CameraComponent->bConstrainAspectRatio;
		}

		float GetAspectRatio(UCameraComponent* CameraComponent) {
			return CameraComponent->AspectRatio;
		}

		float GetFieldOfView(UCameraComponent* CameraComponent) {
			return CameraComponent->FieldOfView;
		}

		float GetOrthoFarClipPlane(UCameraComponent* CameraComponent) {
			return CameraComponent->OrthoFarClipPlane;
		}

		float GetOrthoNearClipPlane(UCameraComponent* CameraComponent) {
			return CameraComponent->OrthoNearClipPlane;
		}

		float GetOrthoWidth(UCameraComponent* CameraComponent) {
			return CameraComponent->OrthoWidth;
		}

		bool GetLockToHeadMountedDisplay(UCameraComponent* CameraComponent) {
			return CameraComponent->bLockToHmd;
		}

		void SetProjectionMode(UCameraComponent* CameraComponent, CameraProjectionMode Mode) {
			CameraComponent->SetProjectionMode(Mode);
		}

		void SetConstrainAspectRatio(UCameraComponent* CameraComponent, bool Value) {
			CameraComponent->bConstrainAspectRatio = Value;
		}

		void SetAspectRatio(UCameraComponent* CameraComponent, float Value) {
			CameraComponent->AspectRatio = Value;
		}

		void SetFieldOfView(UCameraComponent* CameraComponent, float Value) {
			CameraComponent->FieldOfView = Value;
		}

		void SetOrthoFarClipPlane(UCameraComponent* CameraComponent, float Value) {
			CameraComponent->OrthoFarClipPlane = Value;
		}

		void SetOrthoNearClipPlane(UCameraComponent* CameraComponent, float Value) {
			CameraComponent->OrthoNearClipPlane = Value;
		}

		void SetOrthoWidth(UCameraComponent* CameraComponent, float Value) {
			CameraComponent->OrthoWidth = Value;
		}

		void SetLockToHeadMountedDisplay(UCameraComponent* CameraComponent, bool Value) {
			CameraComponent->bLockToHmd = Value;
		}
	}

	namespace ChildActorComponent {
		AActor* GetChildActor(UChildActorComponent* ChildActorComponent, ActorType Type) {
			AActor* actor = nullptr;

			UNREALCLR_GET_ACTOR_TYPE(Type, Cast<, >(ChildActorComponent->GetChildActor()), actor);

			return actor;
		}

		AActor* SetChildActor(UChildActorComponent* ChildActorComponent, ActorType Type) {
			TSubclassOf<AActor> type;

			UNREALCLR_GET_ACTOR_TYPE(Type, UNREALCLR_NONE, ::StaticClass(), type);

			ChildActorComponent->SetChildActorClass(type);

			return ChildActorComponent->GetChildActor();
		}
	}

	namespace SpringArmComponent {
		bool IsCollisionFixApplied(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->IsCollisionFixApplied();
		}

		bool GetDrawDebugLagMarkers(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->bDrawDebugLagMarkers;
		}

		bool GetCollisionTest(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->bDoCollisionTest;
		}

		bool GetCameraPositionLag(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->bEnableCameraLag;
		}

		bool GetCameraRotationLag(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->bEnableCameraRotationLag;
		}

		bool GetCameraLagSubstepping(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->bUseCameraLagSubstepping;
		}

		bool GetInheritPitch(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->bInheritPitch;
		}

		bool GetInheritRoll(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->bInheritRoll;
		}

		bool GetInheritYaw(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->bInheritYaw;
		}

		float GetCameraLagMaxDistance(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->CameraLagMaxDistance;
		}

		float GetCameraLagMaxTimeStep(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->CameraLagMaxTimeStep;
		}

		float GetCameraPositionLagSpeed(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->CameraLagSpeed;
		}

		float GetCameraRotationLagSpeed(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->CameraRotationLagSpeed;
		}

		CollisionChannel GetProbeChannel(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->ProbeChannel;
		}

		float GetProbeSize(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->ProbeSize;
		}

		void GetSocketOffset(USpringArmComponent* SpringArmComponent, Vector3* Value) {
			*Value = SpringArmComponent->SocketOffset;
		}

		float GetTargetArmLength(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->TargetArmLength;
		}

		void GetTargetOffset(USpringArmComponent* SpringArmComponent, Vector3* Value) {
			*Value = SpringArmComponent->TargetOffset;
		}

		void GetUnfixedCameraPosition(USpringArmComponent* SpringArmComponent, Vector3* Value) {
			*Value = SpringArmComponent->GetUnfixedCameraPosition();
		}

		void GetDesiredRotation(USpringArmComponent* SpringArmComponent, Quaternion* Value) {
			*Value = SpringArmComponent->GetDesiredRotation().Quaternion();
		}

		void GetTargetRotation(USpringArmComponent* SpringArmComponent, Quaternion* Value) {
			*Value = SpringArmComponent->GetTargetRotation().Quaternion();
		}

		bool GetUsePawnControlRotation(USpringArmComponent* SpringArmComponent) {
			return SpringArmComponent->bUsePawnControlRotation;
		}

		void SetDrawDebugLagMarkers(USpringArmComponent* SpringArmComponent, bool Value) {
			SpringArmComponent->bDrawDebugLagMarkers = Value;
		}

		void SetCollisionTest(USpringArmComponent* SpringArmComponent, bool Value) {
			SpringArmComponent->bDoCollisionTest = Value;
		}

		void SetCameraPositionLag(USpringArmComponent* SpringArmComponent, bool Value) {
			SpringArmComponent->bEnableCameraLag = Value;
		}

		void SetCameraRotationLag(USpringArmComponent* SpringArmComponent, bool Value) {
			SpringArmComponent->bEnableCameraRotationLag = Value;
		}

		void SetCameraLagSubstepping(USpringArmComponent* SpringArmComponent, bool Value) {
			SpringArmComponent->bUseCameraLagSubstepping = Value;
		}

		void SetInheritPitch(USpringArmComponent* SpringArmComponent, bool Value) {
			SpringArmComponent->bInheritPitch = Value;
		}

		void SetInheritRoll(USpringArmComponent* SpringArmComponent, bool Value) {
			SpringArmComponent->bInheritRoll = Value;
		}

		void SetInheritYaw(USpringArmComponent* SpringArmComponent, bool Value) {
			SpringArmComponent->bInheritYaw = Value;
		}

		void SetCameraLagMaxDistance(USpringArmComponent* SpringArmComponent, float Value) {
			SpringArmComponent->CameraLagMaxDistance = Value;
		}

		void SetCameraLagMaxTimeStep(USpringArmComponent* SpringArmComponent, float Value) {
			SpringArmComponent->CameraLagMaxTimeStep = Value;
		}

		void SetCameraPositionLagSpeed(USpringArmComponent* SpringArmComponent, float Value) {
			SpringArmComponent->CameraLagSpeed = Value;
		}

		void SetCameraRotationLagSpeed(USpringArmComponent* SpringArmComponent, float Value) {
			SpringArmComponent->CameraRotationLagSpeed = Value;
		}

		void SetProbeChannel(USpringArmComponent* SpringArmComponent, CollisionChannel Value) {
			SpringArmComponent->ProbeChannel = Value;
		}

		void SetProbeSize(USpringArmComponent* SpringArmComponent, float Value) {
			SpringArmComponent->ProbeSize = Value;
		}

		void SetSocketOffset(USpringArmComponent* SpringArmComponent, const Vector3* Value) {
			SpringArmComponent->SocketOffset = *Value;
		}

		void SetTargetArmLength(USpringArmComponent* SpringArmComponent, float Value) {
			SpringArmComponent->TargetArmLength = Value;
		}

		void SetTargetOffset(USpringArmComponent* SpringArmComponent, const Vector3* Value) {
			SpringArmComponent->TargetOffset = *Value;
		}

		void SetUsePawnControlRotation(USpringArmComponent* SpringArmComponent, bool value) {
			SpringArmComponent->bUsePawnControlRotation = value;
		}
	}

	namespace PostProcessComponent {
		bool GetEnabled(UPostProcessComponent* PostProcessComponent) {
			return PostProcessComponent->bEnabled;
		}

		float GetBlendRadius(UPostProcessComponent* PostProcessComponent) {
			return PostProcessComponent->BlendRadius;
		}

		float GetBlendWeight(UPostProcessComponent* PostProcessComponent) {
			return PostProcessComponent->BlendWeight;
		}

		bool GetUnbound(UPostProcessComponent* PostProcessComponent) {
			return PostProcessComponent->bUnbound;
		}

		float GetPriority(UPostProcessComponent* PostProcessComponent) {
			return PostProcessComponent->Priority;
		}

		void SetEnabled(UPostProcessComponent* PostProcessComponent, bool Value) {
			PostProcessComponent->bEnabled = Value;
		}

		void SetBlendRadius(UPostProcessComponent* PostProcessComponent, float Value) {
			PostProcessComponent->BlendRadius = Value;
		}

		void SetBlendWeight(UPostProcessComponent* PostProcessComponent, float Value) {
			PostProcessComponent->BlendWeight = Value;
		}

		void SetUnbound(UPostProcessComponent* PostProcessComponent, bool Value) {
			PostProcessComponent->bUnbound = Value;
		}

		void SetPriority(UPostProcessComponent* PostProcessComponent, float Priority) {
			PostProcessComponent->Priority = Priority;
		}
	}

	namespace PrimitiveComponent {
		bool IsGravityEnabled(UPrimitiveComponent* PrimitiveComponent) {
			return PrimitiveComponent->IsGravityEnabled();
		}

		bool IsOverlappingComponent(UPrimitiveComponent* PrimitiveComponent, UPrimitiveComponent* Other) {
			return PrimitiveComponent->IsOverlappingComponent(Other);
		}

		void ForEachOverlappingComponent(UPrimitiveComponent* PrimitiveComponent, UPrimitiveComponent** Array, int32* Elements) {
			static TArray<UPrimitiveComponent*> overlappingComponents;

			overlappingComponents.Reset();

			PrimitiveComponent->GetOverlappingComponents(overlappingComponents);

			int32 elements = overlappingComponents.Num();

			if (elements > 0) {
				*Array = reinterpret_cast<UPrimitiveComponent*>(overlappingComponents.GetData());
				*Elements = elements;
			}
		}

		void AddAngularImpulseInDegrees(UPrimitiveComponent* PrimitiveComponent, const Vector3* Impulse, const char* BoneName, bool VelocityChange) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->AddAngularImpulseInDegrees(*Impulse, boneName, VelocityChange);
		}

		void AddAngularImpulseInRadians(UPrimitiveComponent* PrimitiveComponent, const Vector3* Impulse, const char* BoneName, bool VelocityChange) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->AddAngularImpulseInRadians(*Impulse, boneName, VelocityChange);
		}

		void AddForce(UPrimitiveComponent* PrimitiveComponent, const Vector3* Force, const char* BoneName, bool AccelerationChange) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->AddForce(*Force, boneName, AccelerationChange);
		}

		void AddForceAtLocation(UPrimitiveComponent* PrimitiveComponent, const Vector3* Force, const Vector3* Location, const char* BoneName, bool LocalSpace) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			if (!LocalSpace)
				PrimitiveComponent->AddForceAtLocation(*Force, *Location, boneName);
			else
				PrimitiveComponent->AddForceAtLocationLocal(*Force, *Location, boneName);
		}

		void AddImpulse(UPrimitiveComponent* PrimitiveComponent, const Vector3* Impulse, const char* BoneName, bool VelocityChange) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->AddImpulse(*Impulse, boneName, VelocityChange);
		}

		void AddImpulseAtLocation(UPrimitiveComponent* PrimitiveComponent, const Vector3* Impulse, const Vector3* Location, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->AddImpulseAtLocation(*Impulse, *Location, boneName);
		}

		void AddRadialForce(UPrimitiveComponent* PrimitiveComponent, const Vector3* Origin, float Radius, float Strength, bool LinearFalloff, bool AccelerationChange) {
			PrimitiveComponent->AddRadialForce(*Origin, Radius, Strength, LinearFalloff ? ERadialImpulseFalloff::RIF_Linear : ERadialImpulseFalloff::RIF_Constant, AccelerationChange);
		}

		void AddRadialImpulse(UPrimitiveComponent* PrimitiveComponent, const Vector3* Origin, float Radius, float Strength, bool LinearFalloff, bool AccelerationChange) {
			PrimitiveComponent->AddRadialImpulse(*Origin, Radius, Strength, LinearFalloff ? ERadialImpulseFalloff::RIF_Linear : ERadialImpulseFalloff::RIF_Constant, AccelerationChange);
		}

		void AddTorqueInDegrees(UPrimitiveComponent* PrimitiveComponent, const Vector3* Torque, const char* BoneName, bool AccelerationChange) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->AddTorqueInDegrees(*Torque, boneName, AccelerationChange);
		}

		void AddTorqueInRadians(UPrimitiveComponent* PrimitiveComponent, const Vector3* Torque, const char* BoneName, bool AccelerationChange) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->AddTorqueInRadians(*Torque, boneName, AccelerationChange);
		}

		float GetMass(UPrimitiveComponent* PrimitiveComponent) {
			return PrimitiveComponent->GetMass();
		}

		void GetPhysicsLinearVelocity(UPrimitiveComponent* PrimitiveComponent, Vector3* Value, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->GetPhysicsLinearVelocity(boneName);
		}

		void GetPhysicsLinearVelocityAtPoint(UPrimitiveComponent* PrimitiveComponent, Vector3* Value, const Vector3* Point, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->GetPhysicsLinearVelocityAtPoint(*Point, boneName);
		}

		void GetPhysicsAngularVelocityInDegrees(UPrimitiveComponent* PrimitiveComponent, Vector3* Value, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->GetPhysicsAngularVelocityInDegrees(boneName);
		}

		void GetPhysicsAngularVelocityInRadians(UPrimitiveComponent* PrimitiveComponent, Vector3* Value, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->GetPhysicsAngularVelocityInRadians(boneName);
		}

		bool GetCastShadow(UPrimitiveComponent* PrimitiveComponent) {
			return PrimitiveComponent->CastShadow;
		}

		bool GetOnlyOwnerSee(UPrimitiveComponent* PrimitiveComponent) {
			return PrimitiveComponent->bOnlyOwnerSee;
		}

		bool GetOwnerNoSee(UPrimitiveComponent* PrimitiveComponent) {
			return PrimitiveComponent->bOwnerNoSee;
		}

		bool GetIgnoreRadialForce(UPrimitiveComponent* PrimitiveComponent) {
			return PrimitiveComponent->bIgnoreRadialForce;
		}

		bool GetIgnoreRadialImpulse(UPrimitiveComponent* PrimitiveComponent) {
			return PrimitiveComponent->bIgnoreRadialImpulse;
		}

		UMaterialInstanceDynamic* GetMaterial(UPrimitiveComponent* PrimitiveComponent, int32 ElementIndex) {
			return Cast<UMaterialInstanceDynamic>(PrimitiveComponent->GetMaterial(ElementIndex));
		}

		int32 GetMaterialsNumber(UPrimitiveComponent* PrimitiveComponent) {
			return PrimitiveComponent->GetNumMaterials();
		}

		float GetDistanceToCollision(UPrimitiveComponent* PrimitiveComponent, const Vector3* Point, Vector3* ClosestPointOnCollision) {
			FVector closestPointOnCollision;

			float result = PrimitiveComponent->GetDistanceToCollision(*Point, closestPointOnCollision);

			*ClosestPointOnCollision = closestPointOnCollision;

			return result;
		}

		bool GetSquaredDistanceToCollision(UPrimitiveComponent* PrimitiveComponent, const Vector3* Point, float* SquaredDistance, Vector3* ClosestPointOnCollision) {
			FVector closestPointOnCollision;
			float squaredDistance = 0.0f;

			bool result = PrimitiveComponent->GetSquaredDistanceToCollision(*Point, squaredDistance, closestPointOnCollision);

			*SquaredDistance = squaredDistance;
			*ClosestPointOnCollision = closestPointOnCollision;

			return result;
		}

		float GetAngularDamping(UPrimitiveComponent* PrimitiveComponent) {
			return PrimitiveComponent->GetAngularDamping();
		}

		float GetLinearDamping(UPrimitiveComponent* PrimitiveComponent) {
			return PrimitiveComponent->GetLinearDamping();
		}

		void SetGenerateOverlapEvents(UPrimitiveComponent* PrimitiveComponent, bool Value) {
			PrimitiveComponent->SetGenerateOverlapEvents(Value);
		}

		void SetGenerateHitEvents(UPrimitiveComponent* PrimitiveComponent, bool Value) {
			PrimitiveComponent->SetNotifyRigidBodyCollision(Value);
		}

		void SetMass(UPrimitiveComponent* PrimitiveComponent, float Mass, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->SetMassOverrideInKg(boneName, Mass);
		}

		void SetCenterOfMass(UPrimitiveComponent* PrimitiveComponent, const Vector3* Offset, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->SetCenterOfMass(*Offset, boneName);
		}

		void SetPhysicsLinearVelocity(UPrimitiveComponent* PrimitiveComponent, const Vector3* Velocity, bool AddToCurrent, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->SetPhysicsLinearVelocity(*Velocity, AddToCurrent, boneName);
		}

		void SetPhysicsAngularVelocityInDegrees(UPrimitiveComponent* PrimitiveComponent, const Vector3* AngularVelocity, bool AddToCurrent, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->SetPhysicsAngularVelocityInDegrees(*AngularVelocity, AddToCurrent, boneName);
		}

		void SetPhysicsAngularVelocityInRadians(UPrimitiveComponent* PrimitiveComponent, const Vector3* AngularVelocity, bool AddToCurrent, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->SetPhysicsAngularVelocityInRadians(*AngularVelocity, AddToCurrent, boneName);
		}

		void SetPhysicsMaxAngularVelocityInDegrees(UPrimitiveComponent* PrimitiveComponent, float MaxAngularVelocity, bool AddToCurrent, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->SetPhysicsMaxAngularVelocityInDegrees(MaxAngularVelocity, AddToCurrent, boneName);
		}

		void SetPhysicsMaxAngularVelocityInRadians(UPrimitiveComponent* PrimitiveComponent, float MaxAngularVelocity, bool AddToCurrent, const char* BoneName) {
			UNREALCLR_SET_BONE_NAME(BoneName);

			PrimitiveComponent->SetPhysicsMaxAngularVelocityInRadians(MaxAngularVelocity, AddToCurrent, boneName);
		}

		void SetCastShadow(UPrimitiveComponent* PrimitiveComponent, bool Value) {
			PrimitiveComponent->CastShadow = Value;
		}

		void SetOnlyOwnerSee(UPrimitiveComponent* PrimitiveComponent, bool Value) {
			PrimitiveComponent->bOnlyOwnerSee = Value;
		}

		void SetOwnerNoSee(UPrimitiveComponent* PrimitiveComponent, bool Value) {
			PrimitiveComponent->bOwnerNoSee = Value;
		}

		void SetIgnoreRadialForce(UPrimitiveComponent* PrimitiveComponent, bool Value) {
			PrimitiveComponent->bIgnoreRadialForce = Value;
		}

		void SetIgnoreRadialImpulse(UPrimitiveComponent* PrimitiveComponent, bool Value) {
			PrimitiveComponent->bIgnoreRadialImpulse = Value;
		}

		void SetMaterial(UPrimitiveComponent* PrimitiveComponent, int32 ElementIndex, UMaterialInterface* Material) {
			PrimitiveComponent->SetMaterial(ElementIndex, Material);
		}

		void SetSimulatePhysics(UPrimitiveComponent* PrimitiveComponent, bool Value) {
			PrimitiveComponent->SetSimulatePhysics(Value);
		}

		void SetAngularDamping(UPrimitiveComponent* PrimitiveComponent, float Value) {
			PrimitiveComponent->SetAngularDamping(Value);
		}

		void SetLinearDamping(UPrimitiveComponent* PrimitiveComponent, float Value) {
			PrimitiveComponent->SetLinearDamping(Value);
		}

		void SetEnableGravity(UPrimitiveComponent* PrimitiveComponent, bool Value) {
			PrimitiveComponent->SetEnableGravity(Value);
		}

		void SetCollisionMode(UPrimitiveComponent* PrimitiveComponent, CollisionMode Mode) {
			PrimitiveComponent->SetCollisionEnabled(Mode);
		}

		void SetCollisionChannel(UPrimitiveComponent* PrimitiveComponent, CollisionChannel Channel) {
			PrimitiveComponent->SetCollisionObjectType(Channel);
		}

		void SetCollisionProfileName(UPrimitiveComponent* PrimitiveComponent, const char* ProfileName, bool UpdateOverlaps) {
			PrimitiveComponent->SetCollisionProfileName(FName(UTF8_TO_TCHAR(ProfileName)), UpdateOverlaps);
		}

		void SetCollisionResponseToChannel(UPrimitiveComponent* PrimitiveComponent, CollisionChannel Channel, CollisionResponse Response) {
			PrimitiveComponent->SetCollisionResponseToChannel(Channel, Response);
		}

		void SetCollisionResponseToAllChannels(UPrimitiveComponent* PrimitiveComponent, CollisionResponse Response) {
			PrimitiveComponent->SetCollisionResponseToAllChannels(Response);
		}

		void SetIgnoreActorWhenMoving(UPrimitiveComponent* PrimitiveComponent, AActor* Actor, bool Value) {
			PrimitiveComponent->IgnoreActorWhenMoving(Actor, Value);
		}

		void SetIgnoreComponentWhenMoving(UPrimitiveComponent* PrimitiveComponent, UPrimitiveComponent* Component, bool Value) {
			PrimitiveComponent->IgnoreComponentWhenMoving(Component, Value);
		}

		void ClearMoveIgnoreActors(UPrimitiveComponent* PrimitiveComponent) {
			PrimitiveComponent->ClearMoveIgnoreActors();
		}

		void ClearMoveIgnoreComponents(UPrimitiveComponent* PrimitiveComponent) {
			PrimitiveComponent->ClearMoveIgnoreComponents();
		}

		UMaterialInstanceDynamic* CreateAndSetMaterialInstanceDynamic(UPrimitiveComponent* PrimitiveComponent, int32 ElementIndex) {
			return PrimitiveComponent->CreateAndSetMaterialInstanceDynamic(ElementIndex);
		}

		void RegisterEvent(UPrimitiveComponent* PrimitiveComponent, ComponentEventType Type) {
			UNREALCLR_SET_COMPONENT_EVENT(Type, !, AddDynamic);
		}

		void UnregisterEvent(UPrimitiveComponent* PrimitiveComponent, ComponentEventType Type) {
			UNREALCLR_SET_COMPONENT_EVENT(Type, UNREALCLR_NONE, RemoveDynamic);
		}
	}

	namespace ShapeComponent {
		bool GetDynamicObstacle(UShapeComponent* ShapeComponent) {
			return ShapeComponent->bDynamicObstacle;
		}

		int32 GetShapeColor(UShapeComponent* ShapeComponent) {
			return UNREALCLR_COLOR_TO_INTEGER(ShapeComponent->ShapeColor);
		}

		void SetDynamicObstacle(UShapeComponent* ShapeComponent, bool Value) {
			ShapeComponent->bDynamicObstacle = Value;
		}

		void SetShapeColor(UShapeComponent* ShapeComponent, Color Value) {
			ShapeComponent->ShapeColor = Value;
		}
	}

	namespace BoxComponent {
		void GetScaledBoxExtent(UBoxComponent* BoxComponent, Vector3* Value) {
			*Value = BoxComponent->GetScaledBoxExtent();
		}

		void GetUnscaledBoxExtent(UBoxComponent* BoxComponent, Vector3* Value) {
			*Value = BoxComponent->GetUnscaledBoxExtent();
		}

		void SetBoxExtent(UBoxComponent* BoxComponent, const Vector3* Extent, bool UpdateOverlaps) {
			BoxComponent->SetBoxExtent(*Extent, UpdateOverlaps);
		}

		void InitBoxExtent(UBoxComponent* BoxComponent, const Vector3* Extent) {
			BoxComponent->InitBoxExtent(*Extent);
		}
	}

	namespace SphereComponent {
		float GetScaledSphereRadius(USphereComponent* SphereComponent) {
			return SphereComponent->GetScaledSphereRadius();
		}

		float GetUnscaledSphereRadius(USphereComponent* SphereComponent) {
			return SphereComponent->GetUnscaledSphereRadius();
		}

		float GetShapeScale(USphereComponent* SphereComponent) {
			return SphereComponent->GetShapeScale();
		}

		void SetSphereRadius(USphereComponent* SphereComponent, float SphereRadius, bool UpdateOverlaps) {
			SphereComponent->SetSphereRadius(SphereRadius, UpdateOverlaps);
		}

		void InitSphereRadius(USphereComponent* SphereComponent, float SphereRadius) {
			SphereComponent->InitSphereRadius(SphereRadius);
		}
	}

	namespace CapsuleComponent {
		float GetScaledCapsuleRadius(UCapsuleComponent* CapsuleComponent) {
			return CapsuleComponent->GetScaledCapsuleRadius();
		}

		float GetUnscaledCapsuleRadius(UCapsuleComponent* CapsuleComponent) {
			return CapsuleComponent->GetUnscaledCapsuleRadius();
		}

		float GetShapeScale(UCapsuleComponent* CapsuleComponent) {
			return CapsuleComponent->GetShapeScale();
		}

		void GetScaledCapsuleSize(UCapsuleComponent* CapsuleComponent, float* Radius, float* HalfHeight) {
			CapsuleComponent->GetScaledCapsuleSize(*Radius, *HalfHeight);
		}

		void GetUnscaledCapsuleSize(UCapsuleComponent* CapsuleComponent, float* Radius, float* HalfHeight) {
			CapsuleComponent->GetUnscaledCapsuleSize(*Radius, *HalfHeight);
		}

		void SetCapsuleRadius(UCapsuleComponent* CapsuleComponent, float Radius, bool UpdateOverlaps) {
			CapsuleComponent->SetCapsuleRadius(Radius, UpdateOverlaps);
		}

		void SetCapsuleSize(UCapsuleComponent* CapsuleComponent, float Radius, float HalfHeight, bool UpdateOverlaps) {
			CapsuleComponent->SetCapsuleSize(Radius, HalfHeight, UpdateOverlaps);
		}

		void InitCapsuleSize(UCapsuleComponent* CapsuleComponent, float Radius, float HalfHeight) {
			CapsuleComponent->InitCapsuleSize(Radius, HalfHeight);
		}
	}

	namespace MeshComponent {
		bool IsValidMaterialSlotName(UMeshComponent* MeshComponent, const char* MaterialSlotName) {
			return MeshComponent->IsMaterialSlotNameValid(FName(UTF8_TO_TCHAR(MaterialSlotName)));
		}

		int32 GetMaterialIndex(UMeshComponent* MeshComponent, const char* MaterialSlotName) {
			return MeshComponent->GetMaterialIndex(FName(UTF8_TO_TCHAR(MaterialSlotName)));
		}
	}

	namespace TextRenderComponent {
		void SetFont(UTextRenderComponent* TextRenderComponent, UFont* Value) {
			TextRenderComponent->SetFont(Value);
		}

		void SetText(UTextRenderComponent* TextRenderComponent, const char* Value) {
			TextRenderComponent->SetText(FText::FromString(FString(UTF8_TO_TCHAR(Value))));
		}

		void SetTextMaterial(UTextRenderComponent* TextRenderComponent, UMaterialInterface* Material) {
			TextRenderComponent->SetTextMaterial(Material);
		}

		void SetTextRenderColor(UTextRenderComponent* TextRenderComponent, Color Value) {
			TextRenderComponent->SetTextRenderColor(Value);
		}

		void SetHorizontalAlignment(UTextRenderComponent* TextRenderComponent, HorizontalTextAligment Value) {
			TextRenderComponent->SetHorizontalAlignment(Value);
		}

		void SetHorizontalSpacingAdjustment(UTextRenderComponent* TextRenderComponent, float Value) {
			TextRenderComponent->SetHorizSpacingAdjust(Value);
		}

		void SetVerticalAlignment(UTextRenderComponent* TextRenderComponent, VerticalTextAligment Value) {
			TextRenderComponent->SetVerticalAlignment(Value);
		}

		void SetVerticalSpacingAdjustment(UTextRenderComponent* TextRenderComponent, float Value) {
			TextRenderComponent->SetVertSpacingAdjust(Value);
		}

		void SetScale(UTextRenderComponent* TextRenderComponent, const Vector2* Value) {
			TextRenderComponent->SetXScale(Value->X);
			TextRenderComponent->SetYScale(Value->Y);
		}

		void SetWorldSize(UTextRenderComponent* TextRenderComponent, float Value) {
			TextRenderComponent->SetWorldSize(Value);
		}
	}

	namespace LightComponentBase {
		float GetIntensity(ULightComponentBase* LightComponentBase) {
			return LightComponentBase->Intensity;
		}

		bool GetCastShadows(ULightComponentBase* LightComponentBase) {
			return LightComponentBase->CastShadows;
		}

		void SetCastShadows(ULightComponentBase* LightComponentBase, bool Value) {
			LightComponentBase->SetCastShadows(Value);
		}
	}

	namespace LightComponent {
		void SetIntensity(ULightComponent* LightComponent, float Value) {
			LightComponent->SetIntensity(Value);
		}

		void SetLightColor(ULightComponent* LightComponent, const LinearColor* Value) {
			LightComponent->SetLightColor(*Value);
		}
	}

	namespace MotionControllerComponent {
		bool IsTracked(UMotionControllerComponent* MotionControllerComponent) {
			return MotionControllerComponent->IsTracked();
		}

		bool GetDisplayDeviceModel(UMotionControllerComponent* MotionControllerComponent) {
			return MotionControllerComponent->bDisplayDeviceModel;
		}

		bool GetDisableLowLatencyUpdate(UMotionControllerComponent* MotionControllerComponent) {
			return MotionControllerComponent->bDisableLowLatencyUpdate;
		}

		ControllerHand GetTrackingSource(UMotionControllerComponent* MotionControllerComponent) {
			return MotionControllerComponent->GetTrackingSource();
		}

		void SetDisplayDeviceModel(UMotionControllerComponent* MotionControllerComponent, bool Value) {
			MotionControllerComponent->bDisplayDeviceModel = true;
		}

		void SetDisableLowLatencyUpdate(UMotionControllerComponent* MotionControllerComponent, bool Value) {
			MotionControllerComponent->bDisableLowLatencyUpdate = Value;
		}

		void SetTrackingSource(UMotionControllerComponent* MotionControllerComponent, ControllerHand Value) {
			MotionControllerComponent->SetTrackingSource(Value);
		}

		void SetTrackingMotionSource(UMotionControllerComponent* MotionControllerComponent, const char* Source) {
			MotionControllerComponent->SetTrackingMotionSource(FName(UTF8_TO_TCHAR(Source)));
		}

		void SetAssociatedPlayerIndex(UMotionControllerComponent* MotionControllerComponent, int32 PlayerIndex) {
			MotionControllerComponent->SetAssociatedPlayerIndex(PlayerIndex);
		}

		void SetCustomDisplayMesh(UMotionControllerComponent* MotionControllerComponent, UStaticMesh* StaticMesh) {
			MotionControllerComponent->SetCustomDisplayMesh(StaticMesh);
		}

		void SetDisplayModelSource(UMotionControllerComponent* MotionControllerComponent, const char* Source) {
			MotionControllerComponent->SetDisplayModelSource(FName(UTF8_TO_TCHAR(Source)));
		}
	}

	namespace StaticMeshComponent {
		void GetLocalBounds(UStaticMeshComponent* StaticMeshComponent, Vector3* Min, Vector3* Max) {
			FVector min, max;

			StaticMeshComponent->GetLocalBounds(min, max);

			*Min = min;
			*Max = max;
		}

		UStaticMesh* GetStaticMesh(UStaticMeshComponent* StaticMeshComponent) {
			return StaticMeshComponent->GetStaticMesh();
		}

		bool SetStaticMesh(UStaticMeshComponent* StaticMeshComponent, UStaticMesh* StaticMesh) {
			return StaticMeshComponent->SetStaticMesh(StaticMesh);
		}
	}

	namespace InstancedStaticMeshComponent {
		int32 GetInstanceCount(UInstancedStaticMeshComponent* InstancedStaticMeshComponent) {
			return InstancedStaticMeshComponent->GetInstanceCount();
		}

		bool GetInstanceTransform(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, int32 InstanceIndex, Transform* Value, bool WorldSpace) {
			FTransform transform;

			bool result = InstancedStaticMeshComponent->GetInstanceTransform(InstanceIndex, transform, WorldSpace);

			if (result)
				*Value = transform;

			return result;
		}

		void AddInstance(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, const Transform* InstanceTransform) {
			InstancedStaticMeshComponent->AddInstance(*InstanceTransform);
		}

		void AddInstances(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, int32 EndInstanceIndex, const Transform InstanceTransforms[]) {
			static TArray<FTransform> instanceTransforms;

			instanceTransforms.Reserve(EndInstanceIndex + 1);
			instanceTransforms.Reset();

			for (int32 i = 0; i < EndInstanceIndex; i++) {
				instanceTransforms.Add(InstanceTransforms[i]);
			}

			InstancedStaticMeshComponent->AddInstances(instanceTransforms, false);
		}

		bool UpdateInstanceTransform(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, int32 InstanceIndex, const Transform* InstanceTransform, bool WorldSpace, bool MarkRenderStateDirty, bool Teleport) {
			return InstancedStaticMeshComponent->UpdateInstanceTransform(InstanceIndex, *InstanceTransform, WorldSpace, MarkRenderStateDirty, Teleport);
		}

		bool BatchUpdateInstanceTransforms(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, int32 StartInstanceIndex, int32 EndInstanceIndex, const Transform InstanceTransforms[], bool WorldSpace, bool MarkRenderStateDirty, bool Teleport) {
			static TArray<FTransform> instanceTransforms;

			instanceTransforms.Reserve(EndInstanceIndex + 1);
			instanceTransforms.Reset();

			for (int32 i = 0; i < EndInstanceIndex; i++) {
				instanceTransforms.Add(InstanceTransforms[i]);
			}

			return InstancedStaticMeshComponent->BatchUpdateInstancesTransforms(StartInstanceIndex, instanceTransforms, WorldSpace, MarkRenderStateDirty, Teleport);
		}

		bool RemoveInstance(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, int32 InstanceIndex) {
			return InstancedStaticMeshComponent->RemoveInstance(InstanceIndex);
		}

		void ClearInstances(UInstancedStaticMeshComponent* InstancedStaticMeshComponent) {
			InstancedStaticMeshComponent->ClearInstances();
		}
	}

	namespace HierarchicalInstancedStaticMeshComponent {
		bool GetDisableCollision(UHierarchicalInstancedStaticMeshComponent* HierarchicalInstancedStaticMeshComponent) {
			return HierarchicalInstancedStaticMeshComponent->bDisableCollision;
		}

		void SetDisableCollision(UHierarchicalInstancedStaticMeshComponent* HierarchicalInstancedStaticMeshComponent, bool Value) {
			HierarchicalInstancedStaticMeshComponent->bDisableCollision = Value;
		}
	}

	namespace SkinnedMeshComponent {
		int32 GetBonesNumber(USkinnedMeshComponent* SkinnedMeshComponent) {
			return SkinnedMeshComponent->GetNumBones();
		}

		int32 GetBoneIndex(USkinnedMeshComponent* SkinnedMeshComponent, const char* BoneName) {
			return SkinnedMeshComponent->GetBoneIndex(FName(UTF8_TO_TCHAR(BoneName)));
		}

		void GetBoneName(USkinnedMeshComponent* SkinnedMeshComponent, int32 BoneIndex, char* BoneName) {
			const char* boneName = TCHAR_TO_UTF8(*SkinnedMeshComponent->GetBoneName(BoneIndex).ToString());

			UnrealCLR::Utility::Strcpy(BoneName, boneName, UnrealCLR::Utility::Strlen(boneName));
		}

		void GetBoneTransform(USkinnedMeshComponent* SkinnedMeshComponent, int32 BoneIndex, Transform* Value) {
			*Value = SkinnedMeshComponent->GetBoneTransform(BoneIndex);
		}

		void SetSkeletalMesh(USkinnedMeshComponent* SkinnedMeshComponent, USkeletalMesh* SkeletalMesh, bool ReinitializePose) {
			SkinnedMeshComponent->SetSkeletalMesh(SkeletalMesh, ReinitializePose);
		}
	}

	namespace SkeletalMeshComponent {
		bool IsPlaying(USkeletalMeshComponent* SkeletalMeshComponent) {
			return SkeletalMeshComponent->IsPlaying();
		}

		UAnimInstance* GetAnimationInstance(USkeletalMeshComponent* SkeletalMeshComponent) {
			return SkeletalMeshComponent->GetAnimInstance();
		}

		void SetAnimation(USkeletalMeshComponent* SkeletalMeshComponent, UAnimationAsset* Asset) {
			SkeletalMeshComponent->SetAnimation(Asset);
		}

		void SetAnimationMode(USkeletalMeshComponent* SkeletalMeshComponent, AnimationMode Mode) {
			SkeletalMeshComponent->SetAnimationMode(Mode);
		}

		void SetAnimationBlueprint(USkeletalMeshComponent* SkeletalMeshComponent, UObject* Blueprint) {
			#if !WITH_EDITOR
				SkeletalMeshComponent->SetAnimInstanceClass(Cast<UClass>(Blueprint));
			#else
				SkeletalMeshComponent->SetAnimInstanceClass(Cast<UBlueprint>(Blueprint)->GeneratedClass);
			#endif
		}

		void Play(USkeletalMeshComponent* SkeletalMeshComponent, bool Loop) {
			SkeletalMeshComponent->Play(Loop);
		}

		void PlayAnimation(USkeletalMeshComponent* SkeletalMeshComponent, UAnimationAsset* Asset, bool Loop) {
			SkeletalMeshComponent->PlayAnimation(Asset, Loop);
		}

		void Stop(USkeletalMeshComponent* SkeletalMeshComponent) {
			SkeletalMeshComponent->Stop();
		}
	}

	namespace SplineComponent {
		bool IsClosedLoop(USplineComponent* SplineComponent) {
			return SplineComponent->IsClosedLoop();
		}

		float GetDuration(USplineComponent* SplineComponent) {
			return SplineComponent->Duration;
		}

		SplinePointType GetSplinePointType(USplineComponent* SplineComponent, int32 PointIndex) {
			return SplineComponent->GetSplinePointType(PointIndex);
		}

		int32 GetSplinePointsNumber(USplineComponent* SplineComponent) {
			return SplineComponent->GetNumberOfSplinePoints();
		}

		int32 GetSplineSegmentsNumber(USplineComponent* SplineComponent) {
			return SplineComponent->GetNumberOfSplineSegments();
		}

		void GetTangentAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetTangentAtDistanceAlongSpline(Distance, CoordinateSpace);
		}

		void GetTangentAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetTangentAtSplinePoint(PointIndex, CoordinateSpace);
		}

		void GetTangentAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, Vector3* Value) {
			*Value = SplineComponent->GetTangentAtTime(Time, CoordinateSpace, UseConstantVelocity);
		}

		void GetTransformAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Transform* Value) {
			*Value = SplineComponent->GetTransformAtDistanceAlongSpline(Distance, CoordinateSpace);
		}

		void GetTransformAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, bool UseScale, Transform* Value) {
			*Value = SplineComponent->GetTransformAtSplinePoint(PointIndex, CoordinateSpace, UseScale);
		}

		void GetArriveTangentAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetArriveTangentAtSplinePoint(PointIndex, CoordinateSpace);
		}

		void GetDefaultUpVector(USplineComponent* SplineComponent, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetDefaultUpVector(CoordinateSpace);
		}

		void GetDirectionAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetDirectionAtDistanceAlongSpline(Distance, CoordinateSpace);
		}

		void GetDirectionAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetDirectionAtSplinePoint(PointIndex, CoordinateSpace);
		}

		void GetDirectionAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, Vector3* Value) {
			*Value = SplineComponent->GetDirectionAtTime(Time, CoordinateSpace, UseConstantVelocity);
		}

		float GetDistanceAlongSplineAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex) {
			return SplineComponent->GetDistanceAlongSplineAtSplinePoint(PointIndex);
		}

		void GetLeaveTangentAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetLeaveTangentAtSplinePoint(PointIndex, CoordinateSpace);
		}

		void GetLocationAndTangentAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Location, Vector3* Tangent) {
			FVector location, tangent;

			SplineComponent->GetLocationAndTangentAtSplinePoint(PointIndex, location, tangent, CoordinateSpace);

			*Location = location;
			*Tangent = tangent;
		}

		void GetLocationAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetLocationAtDistanceAlongSpline(Distance, CoordinateSpace);
		}

		void GetLocationAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetLocationAtSplinePoint(PointIndex, CoordinateSpace);
		}

		void GetLocationAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetLocationAtTime(Time, CoordinateSpace);
		}

		void GetRightVectorAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetRightVectorAtDistanceAlongSpline(Distance, CoordinateSpace);
		}

		void GetRightVectorAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetRightVectorAtSplinePoint(PointIndex, CoordinateSpace);
		}

		void GetRightVectorAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, Vector3* Value) {
			*Value = SplineComponent->GetRightVectorAtTime(Time, CoordinateSpace, UseConstantVelocity);
		}

		float GetRollAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace) {
			return SplineComponent->GetRollAtDistanceAlongSpline(Distance, CoordinateSpace);
		}

		float GetRollAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace) {
			return SplineComponent->GetRollAtSplinePoint(PointIndex, CoordinateSpace);
		}

		float GetRollAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity) {
			return SplineComponent->GetRollAtTime(Time, CoordinateSpace, UseConstantVelocity);
		}

		void GetRotationAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Quaternion* Value) {
			*Value = SplineComponent->GetRotationAtDistanceAlongSpline(Distance, CoordinateSpace).Quaternion();
		}

		void GetRotationAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Quaternion* Value) {
			*Value = SplineComponent->GetRotationAtSplinePoint(PointIndex, CoordinateSpace).Quaternion();
		}

		void GetRotationAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, Quaternion* Value) {
			*Value = SplineComponent->GetRotationAtTime(Time, CoordinateSpace, UseConstantVelocity).Quaternion();
		}

		void GetScaleAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, Vector3* Value) {
			*Value = SplineComponent->GetScaleAtDistanceAlongSpline(Distance);
		}

		void GetScaleAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, Vector3* Value) {
			*Value = SplineComponent->GetScaleAtSplinePoint(PointIndex);
		}

		void GetScaleAtTime(USplineComponent* SplineComponent, float Time, bool UseConstantVelocity, Vector3* Value) {
			*Value = SplineComponent->GetScaleAtTime(Time, UseConstantVelocity);
		}

		float GetSplineLength(USplineComponent* SplineComponent) {
			return SplineComponent->GetSplineLength();
		}

		void GetTransformAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, bool UseScale, Transform* Value) {
			*Value = SplineComponent->GetTransformAtTime(Time, CoordinateSpace, UseConstantVelocity, UseScale);
		}

		void GetUpVectorAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetUpVectorAtDistanceAlongSpline(Distance, CoordinateSpace);
		}

		void GetUpVectorAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->GetUpVectorAtSplinePoint(PointIndex, CoordinateSpace);
		}

		void GetUpVectorAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, Vector3* Value) {
			*Value = SplineComponent->GetUpVectorAtTime(Time, CoordinateSpace, UseConstantVelocity);
		}

		void SetDuration(USplineComponent* SplineComponent, float Value) {
			SplineComponent->Duration = Value;
		}

		void SetSplinePointType(USplineComponent* SplineComponent, int32 PointIndex, SplinePointType Type, bool UpdateSpline) {
			SplineComponent->SetSplinePointType(PointIndex, Type, UpdateSpline);
		}

		void SetClosedLoop(USplineComponent* SplineComponent, bool Value, bool UpdateSpline) {
			SplineComponent->SetClosedLoop(Value, UpdateSpline);
		}

		void SetDefaultUpVector(USplineComponent* SplineComponent, const Vector3* Value, SplineCoordinateSpace CoordinateSpace) {
			SplineComponent->SetDefaultUpVector(*Value, CoordinateSpace);
		}

		void SetLocationAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, const Vector3* Value, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline) {
			SplineComponent->SetLocationAtSplinePoint(PointIndex, *Value, CoordinateSpace, UpdateSpline);
		}

		void SetTangentAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, const Vector3* Tangent, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline) {
			SplineComponent->SetTangentAtSplinePoint(PointIndex, *Tangent, CoordinateSpace, UpdateSpline);
		}

		void SetTangentsAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, const Vector3* ArriveTangent, const Vector3* LeaveTangent, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline) {
			SplineComponent->SetTangentsAtSplinePoint(PointIndex, *ArriveTangent, *LeaveTangent, CoordinateSpace, UpdateSpline);
		}

		void SetUpVectorAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, const Vector3* UpVector, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline) {
			SplineComponent->SetUpVectorAtSplinePoint(PointIndex, *UpVector, CoordinateSpace, UpdateSpline);
		}

		void AddSplinePoint(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline) {
			SplineComponent->AddSplinePoint(*Location, CoordinateSpace, UpdateSpline);
		}

		void AddSplinePointAtIndex(USplineComponent* SplineComponent, const Vector3* Location, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline) {
			SplineComponent->AddSplinePointAtIndex(*Location, PointIndex, CoordinateSpace, UpdateSpline);
		}

		void ClearSplinePoints(USplineComponent* SplineComponent, bool UpdateSpline) {
			SplineComponent->ClearSplinePoints(UpdateSpline);
		}

		void FindDirectionClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->FindDirectionClosestToWorldLocation(*Location, CoordinateSpace);
		}

		void FindLocationClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->FindLocationClosestToWorldLocation(*Location, CoordinateSpace);
		}

		void FindUpVectorClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->FindUpVectorClosestToWorldLocation(*Location, CoordinateSpace);
		}

		void FindRightVectorClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->FindRightVectorClosestToWorldLocation(*Location, CoordinateSpace);
		}

		float FindRollClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace) {
			return SplineComponent->FindRollClosestToWorldLocation(*Location, CoordinateSpace);
		}

		void FindScaleClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, Vector3* Value) {
			*Value = SplineComponent->FindScaleClosestToWorldLocation(*Location);
		}

		void FindTangentClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, Vector3* Value) {
			*Value = SplineComponent->FindTangentClosestToWorldLocation(*Location, CoordinateSpace);
		}

		void FindTransformClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, bool UseScale, Transform* Value) {
			*Value = SplineComponent->FindTransformClosestToWorldLocation(*Location, CoordinateSpace, UseScale);
		}

		void RemoveSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, bool UpdateSpline) {
			SplineComponent->RemoveSplinePoint(PointIndex, UpdateSpline);
		}

		void UpdateSpline(USplineComponent* SplineComponent) {
			SplineComponent->UpdateSpline();
		}
	}

	namespace RadialForceComponent {
		bool GetIgnoreOwningActor(URadialForceComponent* RadialForceComponent) {
			return RadialForceComponent->bIgnoreOwningActor;
		}

		bool GetImpulseVelocityChange(URadialForceComponent* RadialForceComponent) {
			return RadialForceComponent->bImpulseVelChange;
		}

		bool GetLinearFalloff(URadialForceComponent* RadialForceComponent) {
			return RadialForceComponent->Falloff == ERadialImpulseFalloff::RIF_Linear;
		}

		float GetForceStrength(URadialForceComponent* RadialForceComponent) {
			return RadialForceComponent->ForceStrength;
		}

		float GetImpulseStrength(URadialForceComponent* RadialForceComponent) {
			return RadialForceComponent->ImpulseStrength;
		}

		float GetRadius(URadialForceComponent* RadialForceComponent) {
			return RadialForceComponent->Radius;
		}

		void SetIgnoreOwningActor(URadialForceComponent* RadialForceComponent, bool Value) {
			RadialForceComponent->bIgnoreOwningActor = Value;
		}

		void SetImpulseVelocityChange(URadialForceComponent* RadialForceComponent, bool Value) {
			RadialForceComponent->bImpulseVelChange = Value;
		}

		void SetLinearFalloff(URadialForceComponent* RadialForceComponent, bool Value) {
			RadialForceComponent->Falloff = Value ? ERadialImpulseFalloff::RIF_Linear : ERadialImpulseFalloff::RIF_Constant;
		}

		void SetForceStrength(URadialForceComponent* RadialForceComponent, float Value) {
			RadialForceComponent->ForceStrength = Value;
		}

		void SetImpulseStrength(URadialForceComponent* RadialForceComponent, float Value) {
			RadialForceComponent->ImpulseStrength = Value;
		}

		void SetRadius(URadialForceComponent* RadialForceComponent, float Value) {
			RadialForceComponent->Radius = Value;
		}

		void AddCollisionChannelToAffect(URadialForceComponent* RadialForceComponent, CollisionChannel Channel) {
			RadialForceComponent->AddCollisionChannelToAffect(Channel);
		}

		void FireImpulse(URadialForceComponent* RadialForceComponent) {
			RadialForceComponent->FireImpulse();
		}
	}

	namespace MaterialInterface {
		bool IsTwoSided(UMaterialInterface* MaterialInterface) {
			return MaterialInterface->IsTwoSided();
		}
	}

	namespace Material {
		bool IsDefaultMaterial(UMaterial* Material) {
			return Material->IsDefaultMaterial();
		}
	}

	namespace MaterialInstance {
		bool IsChildOf(UMaterialInstance* MaterialInstance, UMaterialInterface* Material) {
			return MaterialInstance->IsChildOf(Material);
		}

		UMaterialInstanceDynamic* GetParent(UMaterialInstance* MaterialInstance) {
			return UMaterialInstanceDynamic::Create(MaterialInstance->Parent, MaterialInstance);
		}
	}

	namespace MaterialInstanceDynamic {
		void ClearParameterValues(UMaterialInstanceDynamic* MaterialInstanceDynamic) {
			MaterialInstanceDynamic->ClearParameterValues();
		}

		void SetTextureParameterValue(UMaterialInstanceDynamic* MaterialInstanceDynamic, const char* ParameterName, UTexture* Value) {
			MaterialInstanceDynamic->SetTextureParameterValue(FName(UTF8_TO_TCHAR(ParameterName)), Value);
		}

		void SetVectorParameterValue(UMaterialInstanceDynamic* MaterialInstanceDynamic, const char* ParameterName, const LinearColor* Value) {
			MaterialInstanceDynamic->SetVectorParameterValue(FName(UTF8_TO_TCHAR(ParameterName)), *Value);
		}

		void SetScalarParameterValue(UMaterialInstanceDynamic* MaterialInstanceDynamic, const char* ParameterName, float Value) {
			MaterialInstanceDynamic->SetScalarParameterValue(FName(UTF8_TO_TCHAR(ParameterName)), Value);
		}
	}
}
