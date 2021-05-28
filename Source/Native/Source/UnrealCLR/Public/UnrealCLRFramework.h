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

#pragma once

UNREALCLR_API DECLARE_LOG_CATEGORY_EXTERN(LogUnrealManaged, Log, All);

namespace UnrealCLRFramework {
	using AnimationMode = EAnimationMode::Type;
	using AutoReceiveInput = EAutoReceiveInput::Type;
	using CameraProjectionMode = ECameraProjectionMode::Type;
	using CollisionMode = ECollisionEnabled::Type;
	using CollisionShapeType = ECollisionShape::Type;
	using ComponentMobility = EComponentMobility::Type;
	using SplineCoordinateSpace = ESplineCoordinateSpace::Type;
	using SplinePointType = ESplinePointType::Type;
	using WindowMode = EWindowMode::Type;

	using AudioFadeCurve = EAudioFaderCurve;
	using AutoPossessAI = EAutoPossessAI;
	using BlendType = EViewTargetBlendFunction;
	using CollisionChannel = ECollisionChannel;
	using CollisionResponse = ECollisionResponse;
	using ControllerHand = EControllerHand;
	using HorizontalTextAligment = EHorizTextAligment;
	using InputEvent = EInputEvent;
	using NetMode = ENetMode;
	using PixelFormat = EPixelFormat;
	using TeleportType = ETeleportType;
	using VerticalTextAligment = EVerticalTextAligment;

	using Bounds = FBoxSphereBounds;
	using CollisionShape = FCollisionShape;

	enum struct LogLevel : int32 {
		Display,
		Warning,
		Error,
		Fatal
	};

	enum struct AttachmentTransformRule : int32 {
		KeepRelativeTransform,
		KeepWorldTransform,
		SnapToTargetIncludingScale,
		SnapToTargetNotIncludingScale
	};

	enum struct DetachmentTransformRule : int32 {
		KeepRelativeTransform,
		KeepWorldTransform
	};

	enum struct UpdateTransformFlags : int32 {
		None = 0,
		SkipPhysicsUpdate = 1 << 0,
		PropagateFromParent = 1 << 1,
		OnlyUpdateIfUsingSocket = 1 << 2
	};

	enum struct AIFocusPriority : int32 {
		Default = 0,
		Move = 1,
		Gameplay = 2
	};

	enum struct ActorEventType : int32 {
		OnActorBeginOverlap,
		OnActorEndOverlap,
		OnActorHit,
		OnActorBeginCursorOver,
		OnActorEndCursorOver,
		OnActorClicked,
		OnActorReleased
	};

	enum struct ComponentEventType : int32 {
		OnComponentBeginOverlap,
		OnComponentEndOverlap,
		OnComponentHit,
		OnComponentBeginCursorOver,
		OnComponentEndCursorOver,
		OnComponentClicked,
		OnComponentReleased
	};

	struct Color {
		uint8 B;
		uint8 G;
		uint8 R;
		uint8 A;

		FORCEINLINE Color(FColor Value) {
			this->R = Value.R;
			this->G = Value.G;
			this->B = Value.B;
			this->A = Value.A;
		}

		FORCEINLINE operator FColor() const { return FColor(R, G, B, A); }
	};

	struct Vector2 {
		float X;
		float Y;

		FORCEINLINE Vector2(FVector2D Value) {
			this->X = Value.X;
			this->Y = Value.Y;
		}

		FORCEINLINE operator FVector2D() const { return FVector2D(X, Y); }
	};

	struct Vector3 {
		float X;
		float Y;
		float Z;

		FORCEINLINE Vector3(FVector Value) {
			this->X = Value.X;
			this->Y = Value.Y;
			this->Z = Value.Z;
		}

		FORCEINLINE operator FVector() const { return FVector(X, Y, Z); }
	};

	struct Quaternion {
		float X;
		float Y;
		float Z;
		float W;

		FORCEINLINE Quaternion(FQuat Value) {
			this->X = Value.X;
			this->Y = Value.Y;
			this->Z = Value.Z;
			this->W = Value.W;
		}

		FORCEINLINE operator FQuat() const { return FQuat(X, Y, Z, W); }
	};

	struct Transform {
		Vector3 Location;
		Quaternion Rotation;
		Vector3 Scale;

		FORCEINLINE Transform(const FTransform& Value) :
			Location(Value.GetTranslation()),
			Rotation(Value.GetRotation()),
			Scale(Value.GetScale3D()) { }

		FORCEINLINE operator FTransform() const { return FTransform(Rotation, Location, Scale); }
	};

	struct LinearColor {
		float R;
		float G;
		float B;
		float A;

		FORCEINLINE LinearColor(FLinearColor Value) {
			this->R = Value.R;
			this->G = Value.G;
			this->B = Value.B;
			this->A = Value.A;
		}

		FORCEINLINE operator FLinearColor() const { return FLinearColor(R, G, B, A); }
	};

	struct Hit {
		Vector3 Location;
		Vector3 ImpactLocation;
		Vector3 Normal;
		Vector3 ImpactNormal;
		Vector3 TraceStart;
		Vector3 TraceEnd;
		AActor* Actor;
		float Time;
		float Distance;
		float PenetrationDepth;
		bool BlockingHit;
		bool StartPenetrating;

		FORCEINLINE Hit(const FHitResult& Value) :
			Location(FVector(Value.Location.X, Value.Location.Y, Value.Location.Z)),
			ImpactLocation(FVector(Value.ImpactPoint.X, Value.ImpactPoint.Y, Value.ImpactPoint.Z)),
			Normal(FVector(Value.Normal.X, Value.Normal.Y, Value.Normal.Z)),
			ImpactNormal(FVector(Value.ImpactNormal.X, Value.ImpactNormal.Y, Value.ImpactNormal.Z)),
			TraceStart(FVector(Value.TraceStart.X, Value.TraceStart.Y, Value.TraceStart.Z)),
			TraceEnd(FVector(Value.TraceEnd.X, Value.TraceEnd.Y, Value.TraceEnd.Z)),
			Actor(Value.GetActor()),
			Time(Value.Time),
			Distance(Value.Distance),
			PenetrationDepth(Value.PenetrationDepth),
			BlockingHit(Value.bBlockingHit),
			StartPenetrating(Value.bStartPenetrating) { }
	};

	typedef void (*InputDelegate)();

	typedef void (*InputAxisDelegate)(float);

	typedef void (*ConsoleVariableDelegate)();

	typedef void (*ConsoleCommandDelegate)(float);

	typedef void (*ActorOverlapDelegate)(AActor*, AActor*);

	typedef void (*ActorHitDelegate)(AActor* HitActor, AActor* OtherActor, const Vector3* NormalImpulse, const Hit* Hit);

	typedef void (*ActorCursorDelegate)(AActor* Actor);

	typedef void (*ActorKeyDelegate)(AActor* Actor, const char* Key);

	typedef void (*ComponentOverlapDelegate)(UPrimitiveComponent*, UPrimitiveComponent*);

	typedef void (*ComponentHitDelegate)(UPrimitiveComponent* HitComponent, UPrimitiveComponent* OtherComponent, const Vector3* NormalImpulse, const Hit* Hit);

	typedef void (*ComponentCursorDelegate)(UPrimitiveComponent* Component);

	typedef void (*ComponentKeyDelegate)(UPrimitiveComponent* Component, const char* Key);

	typedef void (*CharacterLandedDelegate)(const Hit* Hit);

	// Enumerable

	enum struct ObjectType : int32 {
		Blueprint,
		SoundWave,
		AnimationSequence,
		AnimationMontage,
		StaticMesh,
		SkeletalMesh,
		Material,
		Font,
		Texture2D
	};

	enum struct ActorType : int32 {
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
	};

	enum struct ComponentType : int32 {
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
	};

	// Non-instantiable

	namespace Assert {
		static void OutputMessage(const uint8* Message);
	}

	namespace CommandLine {
		static void Get(char* Arguments);
		static void Set(const char* Arguments);
		static void Append(const char* Arguments);
	}

	namespace Debug {
		static void Log(LogLevel Level, const uint8* Message);
		static void Exception(const uint8* Exception);
		static void AddOnScreenMessage(int32 Key, float TimeToDisplay, Color DisplayColor, const uint8* Message);
		static void ClearOnScreenMessages();
		static void DrawBox(const Vector3* Center, const Vector3* Extent, const Quaternion* Rotation, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness);
		static void DrawCapsule(const Vector3* Center, float HalfHeight, float Radius, const Quaternion* Rotation, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness);
		static void DrawCone(const Vector3* Origin, const Vector3* Direction, float Length, float AngleWidth, float AngleHeight, int32 Sides, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness);
		static void DrawCylinder(const Vector3* Start, const Vector3* End, float Radius, int32 Segments, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness);
		static void DrawSphere(const Vector3* Center, float Radius, int32 Segments, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness);
		static void DrawLine(const Vector3* Start, const Vector3* End, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority, float Thickness);
		static void DrawPoint(const Vector3* Location, float Size, Color Color, bool PersistentLines, float LifeTime, uint8 DepthPriority);
		static void FlushPersistentLines();
	}

	namespace Object {
		static bool IsPendingKill(UObject* Object);
		static bool IsValid(UObject* Object);
		static UObject* Load(ObjectType Type, const char* Name);
		static void Rename(UObject* Object, const char* Name);
		static bool Invoke(UObject* Object, const uint8* Command);
		static AActor* ToActor(UObject* Object, ActorType Type);
		static UActorComponent* ToComponent(UObject* Object, ComponentType Type);
		static uint32 GetID(UObject* Object);
		static void GetName(UObject* Object, char* Name);
		static bool GetBool(UObject* Object, const char* Name, bool* value);
		static bool GetByte(UObject* Object, const char* Name, uint8* Value);
		static bool GetShort(UObject* Object, const char* Name, int16* Value);
		static bool GetInt(UObject* Object, const char* Name, int32* Value);
		static bool GetLong(UObject* Object, const char* Name, int64* Value);
		static bool GetUShort(UObject* Object, const char* Name, uint16* Value);
		static bool GetUInt(UObject* Object, const char* Name, uint32* Value);
		static bool GetULong(UObject* Object, const char* Name, uint64* Value);
		static bool GetFloat(UObject* Object, const char* Name, float* Value);
		static bool GetDouble(UObject* Object, const char* Name, double* Value);
		static bool GetEnum(UObject* Object, const char* Name, int32* Value);
		static bool GetString(UObject* Object, const char* Name, char* Value);
		static bool GetText(UObject* Object, const char* Name, char* Value);
		static bool SetBool(UObject* Object, const char* Name, bool value);
		static bool SetByte(UObject* Object, const char* Name, uint8 Value);
		static bool SetShort(UObject* Object, const char* Name, int16 Value);
		static bool SetInt(UObject* Object, const char* Name, int32 Value);
		static bool SetLong(UObject* Object, const char* Name, int64 Value);
		static bool SetUShort(UObject* Object, const char* Name, uint16 Value);
		static bool SetUInt(UObject* Object, const char* Name, uint32 Value);
		static bool SetULong(UObject* Object, const char* Name, uint64 Value);
		static bool SetFloat(UObject* Object, const char* Name, float Value);
		static bool SetDouble(UObject* Object, const char* Name, double Value);
		static bool SetEnum(UObject* Object, const char* Name, int32 Value);
		static bool SetString(UObject* Object, const char* Name, const char* Value);
		static bool SetText(UObject* Object, const char* Name, const char* Value);
	}

	namespace Application {
		static bool IsCanEverRender();
		static bool IsPackagedForDistribution();
		static bool IsPackagedForShipping();
		static void GetProjectDirectory(char* Directory);
		static void GetDefaultLanguage(char* Language);
		static void GetProjectName(char* ProjectName);
		static float GetVolumeMultiplier();
		static void SetProjectName(const char* ProjectName);
		static void SetVolumeMultiplier(float Value);
		static void RequestExit(bool Force);
	}

	namespace ConsoleManager {
		static bool IsRegisteredVariable(const char* Name);
		static IConsoleVariable* FindVariable(const char* Name);
		static IConsoleVariable* RegisterVariableBool(const char* Name, const char* Help, bool DefaultValue, bool ReadOnly);
		static IConsoleVariable* RegisterVariableInt(const char* Name, const char* Help, int32 DefaultValue, bool ReadOnly);
		static IConsoleVariable* RegisterVariableFloat(const char* Name, const char* Help, float DefaultValue, bool ReadOnly);
		static IConsoleVariable* RegisterVariableString(const char* Name, const char* Help, const char* DefaultValue, bool ReadOnly);
		static void RegisterCommand(const char* Name, const char* Help, ConsoleCommandDelegate Callback, bool ReadOnly);
		static void UnregisterObject(const char* Name);
	}

	namespace Engine {
		static bool IsSplitScreen();
		static bool IsEditor();
		static bool IsForegroundWindow();
		static bool IsExitRequested();
		static NetMode GetNetMode();
		static uint32 GetFrameNumber();
		static void GetViewportSize(Vector2* Value);
		static void GetScreenResolution(Vector2* Value);
		static WindowMode GetWindowMode();
		static void GetVersion(char* Version);
		static float GetMaxFPS();
		static void SetMaxFPS(float MaxFPS);
		static void SetTitle(const char* Title);
		static void AddActionMapping(const char* ActionName, const char* Key, bool Shift, bool Ctrl, bool Alt, bool Cmd);
		static void AddAxisMapping(const char* AxisName, const char* Key, float Scale);
		static void ForceGarbageCollection(bool FullPurge);
		static void DelayGarbageCollection();
	}

	namespace HeadMountedDisplay {
		static bool IsConnected();
		static bool GetEnabled();
		static bool GetLowPersistenceMode();
		static void GetDeviceName(char* Name);
		static void SetEnable(bool Value);
		static void SetLowPersistenceMode(bool Value);
	}

	namespace World {
		static void ForEachActor(AActor** Array, int32* Elements);
		static int32 GetActorCount();
		static float GetDeltaSeconds();
		static float GetRealTimeSeconds();
		static float GetTimeSeconds();
		static void GetCurrentLevelName(char* LevelName);
		static bool GetSimulatePhysics();
		static void GetWorldOrigin(Vector3* Value);
		static AActor* GetActor(const char* Name, ActorType Type);
		static AActor* GetActorByTag(const char* Tag, ActorType Type);
		static AActor* GetActorByID(uint32 ID, ActorType Type);
		static APlayerController* GetFirstPlayerController();
		static AGameModeBase* GetGameMode();
		static void SetOnActorBeginOverlapCallback(ActorOverlapDelegate Callback);
		static void SetOnActorEndOverlapCallback(ActorOverlapDelegate Callback);
		static void SetOnActorHitCallback(ActorHitDelegate Callback);
		static void SetOnActorBeginCursorOverCallback(ActorCursorDelegate Callback);
		static void SetOnActorEndCursorOverCallback(ActorCursorDelegate Callback);
		static void SetOnActorClickedCallback(ActorKeyDelegate Callback);
		static void SetOnActorReleasedCallback(ActorKeyDelegate Callback);
		static void SetOnComponentBeginOverlapCallback(ComponentOverlapDelegate Callback);
		static void SetOnComponentEndOverlapCallback(ComponentOverlapDelegate Callback);
		static void SetOnComponentHitCallback(ComponentHitDelegate Callback);
		static void SetOnComponentBeginCursorOverCallback(ComponentCursorDelegate Callback);
		static void SetOnComponentEndCursorOverCallback(ComponentCursorDelegate Callback);
		static void SetOnComponentClickedCallback(ComponentKeyDelegate Callback);
		static void SetOnComponentReleasedCallback(ComponentKeyDelegate Callback);
		static void SetSimulatePhysics(bool Value);
		static void SetGravity(float Value);
		static bool SetWorldOrigin(const Vector3* Value);
		static void OpenLevel(const char* LevelName);
		static bool LineTraceTestByChannel(const Vector3* Start, const Vector3* End, CollisionChannel Channel, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
		static bool LineTraceTestByProfile(const Vector3* Start, const Vector3* End, const char* ProfileName, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
		static bool LineTraceSingleByChannel(const Vector3* Start, const Vector3* End, CollisionChannel Channel, Hit* Hit, char* BoneName, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
		static bool LineTraceSingleByProfile(const Vector3* Start, const Vector3* End, const char* ProfileName, Hit* Hit, char* BoneName, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
		static bool SweepTestByChannel(const Vector3* Start, const Vector3* End, const Quaternion* Rotation, CollisionChannel Channel, const CollisionShape* Shape, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
		static bool SweepTestByProfile(const Vector3* Start, const Vector3* End, const Quaternion* Rotation, const char* ProfileName, const CollisionShape* Shape, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
		static bool SweepSingleByChannel(const Vector3* Start, const Vector3* End, const Quaternion* Rotation, CollisionChannel Channel, const CollisionShape* Shape, Hit* Hit, char* BoneName, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
		static bool SweepSingleByProfile(const Vector3* Start, const Vector3* End, const Quaternion* Rotation, const char* ProfileName, const CollisionShape* Shape, Hit* Hit, char* BoneName, bool TraceComplex, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
		static bool OverlapAnyTestByChannel(const Vector3* Location, const Quaternion* Rotation, CollisionChannel Channel, const CollisionShape* Shape, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
		static bool OverlapAnyTestByProfile(const Vector3* Location, const Quaternion* Rotation, const char* ProfileName, const CollisionShape* Shape, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
		static bool OverlapBlockingTestByChannel(const Vector3* Location, const Quaternion* Rotation, CollisionChannel Channel, const CollisionShape* Shape, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
		static bool OverlapBlockingTestByProfile(const Vector3* Location, const Quaternion* Rotation, const char* ProfileName, const CollisionShape* Shape, AActor* IgnoredActor, UPrimitiveComponent* IgnoredComponent);
	}

	// Instantiable

	namespace Asset {
		static bool IsValid(FAssetData* Asset);
		static void GetName(FAssetData* Asset, char* Name);
		static void GetPath(FAssetData* Asset, char* Path);
	}

	namespace AssetRegistry {
		static IAssetRegistry* Get();
		static bool HasAssets(IAssetRegistry* AssetRegistry, const char* Path, bool Recursive);
		static void ForEachAsset(IAssetRegistry* AssetRegistry, const char* Path, bool Recursive, bool IncludeOnlyOnDiskAssets, FAssetData** Array, int32* Elements);
	}

	namespace Blueprint {
		static bool IsValidActorClass(UBlueprint* Blueprint, ActorType Type);
		static bool IsValidComponentClass(UBlueprint* Blueprint, ComponentType Type);
	}

	namespace ConsoleObject {
		static bool IsBool(IConsoleObject* ConsoleObject);
		static bool IsInt(IConsoleObject* ConsoleObject);
		static bool IsFloat(IConsoleObject* ConsoleObject);
		static bool IsString(IConsoleObject* ConsoleObject);
	}

	namespace ConsoleVariable {
		static bool GetBool(IConsoleVariable* ConsoleVariable);
		static int32 GetInt(IConsoleVariable* ConsoleVariable);
		static float GetFloat(IConsoleVariable* ConsoleVariable);
		static void GetString(IConsoleVariable* ConsoleVariable, char* Value);
		static void SetBool(IConsoleVariable* ConsoleVariable, bool Value);
		static void SetInt(IConsoleVariable* ConsoleVariable, int32 Value);
		static void SetFloat(IConsoleVariable* ConsoleVariable, float Value);
		static void SetString(IConsoleVariable* ConsoleVariable, const char* Value);
		static void SetOnChangedCallback(IConsoleVariable* ConsoleVariable, ConsoleVariableDelegate Callback);
		static void ClearOnChangedCallback(IConsoleVariable* ConsoleVariable);
	}

	namespace Actor {
		static bool IsPendingKill(AActor* Actor);
		static bool IsRootComponentMovable(AActor* Actor);
		static bool IsOverlappingActor(AActor* Actor, AActor* Other);
		static void ForEachComponent(AActor* Actor, UActorComponent** Array, int32* Elements);
		static void ForEachAttachedActor(AActor* Actor, AActor** Array, int32* Elements);
		static void ForEachChildActor(AActor* Actor, AActor** Array, int32* Elements);
		static void ForEachOverlappingActor(AActor* Actor, AActor** Array, int32* Elements);
		static AActor* Spawn(const char* Name, ActorType Type, UObject* Blueprint);
		static bool Destroy(AActor* Actor);
		static void Rename(AActor* Actor, const char* Name);
		static void Hide(AActor* Actor, bool Value);
		static bool TeleportTo(AActor* Actor, const Vector3* DestinationLocation, const Quaternion* DestinationRotation, bool IsATest, bool NoCheck);
		static UActorComponent* GetComponent(AActor* Actor, const char* Name, ComponentType Type);
		static UActorComponent* GetComponentByTag(AActor* Actor, const char* Tag, ComponentType Type);
		static UActorComponent* GetComponentByID(AActor* Actor, uint32 ID, ComponentType Type);
		static USceneComponent* GetRootComponent(AActor* Actor, ComponentType Type);
		static UInputComponent* GetInputComponent(AActor* Actor);
		static float GetCreationTime(AActor* Actor);
		static bool GetBlockInput(AActor* Actor);
		static float GetDistanceTo(AActor* Actor, AActor* Other);
		static float GetHorizontalDistanceTo(AActor* Actor, AActor* Other);
		static void GetBounds(AActor* Actor, bool OnlyCollidingComponents, Vector3* Origin, Vector3* Extent);
		static void GetEyesViewPoint(AActor* Actor, Vector3* Location, Quaternion* Rotation);
		static bool SetRootComponent(AActor* Actor, USceneComponent* RootComponent);
		static void SetInputComponent(AActor* Actor, UInputComponent* InputComponent);
		static void SetBlockInput(AActor* Actor, bool Value);
		static void SetLifeSpan(AActor* Actor, float LifeSpan);
		static void SetEnableInput(AActor* Actor, APlayerController* PlayerController, bool Value);
		static void SetEnableCollision(AActor* Actor, bool Value);
		static void AddTag(AActor* Actor, const char* Tag);
		static void RemoveTag(AActor* Actor, const char* Tag);
		static bool HasTag(AActor* Actor, const char* Tag);
		static void RegisterEvent(AActor* Actor, ActorEventType Type);
		static void UnregisterEvent(AActor* Actor, ActorEventType Type);
	}

	namespace GameModeBase {
		static bool GetUseSeamlessTravel(AGameModeBase* GameModeBase);
		static void SetUseSeamlessTravel(AGameModeBase* GameModeBase, bool Value);
		static void SwapPlayerControllers(AGameModeBase* GameModeBase, APlayerController* PlayerController, APlayerController* NewPlayerController);
	}

	namespace TriggerBase { }

	namespace TriggerBox { }

	namespace TriggerCapsule { }

	namespace TriggerSphere { }

	namespace Pawn {
		static bool IsControlled(APawn* Pawn);
		static bool IsPlayerControlled(APawn* Pawn);
		static AutoPossessAI GetAutoPossessAI(APawn* Pawn);
		static AutoReceiveInput GetAutoPossessPlayer(APawn* Pawn);
		static bool GetUseControllerRotationYaw(APawn* Pawn);
		static bool GetUseControllerRotationPitch(APawn* Pawn);
		static bool GetUseControllerRotationRoll(APawn* Pawn);
		static void GetGravityDirection(APawn* Pawn, Vector3* Value);
		static AAIController* GetAIController(APawn* Pawn);
		static APlayerController* GetPlayerController(APawn* Pawn);
		static void SetAutoPossessAI(APawn* Pawn, AutoPossessAI Value);
		static void SetAutoPossessPlayer(APawn* Pawn, AutoReceiveInput Value);
		static void SetUseControllerRotationYaw(APawn* Pawn, bool Value);
		static void SetUseControllerRotationPitch(APawn* Pawn, bool Value);
		static void SetUseControllerRotationRoll(APawn* Pawn, bool Value);
		static void AddControllerYawInput(APawn* Pawn, float Value);
		static void AddControllerPitchInput(APawn* Pawn, float Value);
		static void AddControllerRollInput(APawn* Pawn, float Value);
		static void AddMovementInput(APawn* Pawn, const Vector3* WorldDirection, float ScaleValue, bool Force);
	}

	namespace Character {
		static bool IsCrouched(ACharacter* Character);
		static bool CanCrouch(ACharacter* Character);
		static bool CanJump(ACharacter* Character);
		static void CheckJumpInput(ACharacter* Character, float DeltaTime);
		static void ClearJumpInput(ACharacter* Character, float DeltaTime);
		static void Launch(ACharacter* Character, const Vector3* Velocity, bool OverrideXY, bool OverrideZ);
		static void Crouch(ACharacter* Character);
		static void StopCrouching(ACharacter* Character);
		static void Jump(ACharacter* Character);
		static void StopJumping(ACharacter* Character);
		static void SetOnLandedCallback(ACharacter* Character, CharacterLandedDelegate Callback);
	}

	namespace Controller {
		static bool IsLookInputIgnored(AController* Controller);
		static bool IsMoveInputIgnored(AController* Controller);
		static bool IsPlayerController(AController* Controller);
		static APawn* GetPawn(AController* Controller);
		static ACharacter* GetCharacter(AController* Controller);
		static AActor* GetViewTarget(AController* Controller);
		static void GetControlRotation(AController* Controller, Quaternion* Value);
		static void GetDesiredRotation(AController* Controller, Quaternion* Value);
		static bool LineOfSightTo(AController* Controller, AActor* Actor, const Vector3* ViewPoint, bool AlternateChecks);
		static void SetControlRotation(AController* Controller, const Quaternion* Value);
		static void SetInitialLocationAndRotation(AController* Controller, const Vector3* NewLocation, const Quaternion* NewRotation);
		static void SetIgnoreLookInput(AController* Controller, bool Value);
		static void SetIgnoreMoveInput(AController* Controller, bool Value);
		static void ResetIgnoreLookInput(AController* Controller);
		static void ResetIgnoreMoveInput(AController* Controller);
		static void Possess(AController* Controller, APawn* Pawn);
		static void Unpossess(AController* Controller);
	}

	namespace AIController {
		static void ClearFocus(AAIController* AIController, AIFocusPriority Priority);
		static void GetFocalPoint(AAIController* AIController, Vector3* Value);
		static void SetFocalPoint(AAIController* AIController, const Vector3* NewFocus, AIFocusPriority Priority);
		static AActor* GetFocusActor(AAIController* AIController);
		static bool GetAllowStrafe(AAIController* AIController);
		static void SetAllowStrafe(AAIController* AIController, bool Value);
		static void SetFocus(AAIController* AIController, AActor* NewFocus, AIFocusPriority Priority);
	}

	namespace PlayerController {
		static bool IsPaused(APlayerController* PlayerController);
		static bool GetShowMouseCursor(APlayerController* PlayerController);
		static bool GetEnableClickEvents(APlayerController* PlayerController);
		static bool GetEnableMouseOverEvents(APlayerController* PlayerController);
		static bool GetMousePosition(APlayerController* PlayerController, float* X, float* Y);
		static UPlayer* GetPlayer(APlayerController* PlayerController);
		static UPlayerInput* GetPlayerInput(APlayerController* PlayerController);
		static bool GetHitResultAtScreenPosition(APlayerController* PlayerController, const Vector2* ScreenPosition, CollisionChannel TraceChannel, Hit* Hit, bool TraceComplex);
		static bool GetHitResultUnderCursor(APlayerController* PlayerController, CollisionChannel TraceChannel, Hit* Hit, bool TraceComplex);
		static void SetShowMouseCursor(APlayerController* PlayerController, bool Value);
		static void SetEnableClickEvents(APlayerController* PlayerController, bool Value);
		static void SetEnableMouseOverEvents(APlayerController* PlayerController, bool Value);
		static void SetMousePosition(APlayerController* PlayerController, float X, float Y);
		static void ConsoleCommand(APlayerController* PlayerController, const char* Command, bool WriteToLog);
		static bool SetPause(APlayerController* PlayerController, bool Value);
		static void SetViewTarget(APlayerController* PlayerController, AActor* NewViewTarget);
		static void SetViewTargetWithBlend(APlayerController* PlayerController, AActor* NewViewTarget, float Time, float Exponent, BlendType Type, bool LockOutgoing);
		static void AddYawInput(APlayerController* PlayerController, float Value);
		static void AddPitchInput(APlayerController* PlayerController, float Value);
		static void AddRollInput(APlayerController* PlayerController, float Value);
	}

	namespace Volume {
		static bool EncompassesPoint(AVolume* Volume, const Vector3* Point, float SphereRadius, float* OutDistanceToPoint);
	}

	namespace TriggerVolume { }

	namespace PostProcessVolume {
		static bool GetEnabled(APostProcessVolume* PostProcessVolume);
		static float GetBlendRadius(APostProcessVolume* PostProcessVolume);
		static float GetBlendWeight(APostProcessVolume* PostProcessVolume);
		static bool GetUnbound(APostProcessVolume* PostProcessVolume);
		static float GetPriority(APostProcessVolume* PostProcessVolume);
		static void SetEnabled(APostProcessVolume* PostProcessVolume, bool Value);
		static void SetBlendRadius(APostProcessVolume* PostProcessVolume, float Value);
		static void SetBlendWeight(APostProcessVolume* PostProcessVolume, float Value);
		static void SetUnbound(APostProcessVolume* PostProcessVolume, bool Value);
		static void SetPriority(APostProcessVolume* PostProcessVolume, float Priority);
	}

	namespace LevelScript { }

	namespace AmbientSound { }

	namespace Light { }

	namespace DirectionalLight { }

	namespace PointLight { }

	namespace RectLight { }

	namespace SpotLight { }

	namespace SoundBase {
		static float GetDuration(USoundBase* SoundBase);
	}

	namespace SoundWave {
		static bool GetLoop(USoundWave* SoundWave);
		static void SetLoop(USoundWave* SoundWave, bool Value);
	}

	namespace AnimationAsset {

	}

	namespace AnimationSequenceBase {

	}

	namespace AnimationSequence {

	}

	namespace AnimationCompositeBase {

	}

	namespace AnimationMontage {

	}

	namespace AnimationInstance {
		static UAnimMontage* GetCurrentActiveMontage(UAnimInstance* AnimationInstance);
		static bool IsPlaying(UAnimInstance* AnimationInstance, UAnimMontage* Montage);
		static float GetPlayRate(UAnimInstance* AnimationInstance, UAnimMontage* Montage);
		static float GetPosition(UAnimInstance* AnimationInstance, UAnimMontage* Montage);
		static float GetBlendTime(UAnimInstance* AnimationInstance, UAnimMontage* Montage);
		static void GetCurrentSection(UAnimInstance* AnimationInstance, UAnimMontage* Montage, char* SectionName);
		static void SetPlayRate(UAnimInstance* AnimationInstance, UAnimMontage* Montage, float Value);
		static void SetPosition(UAnimInstance* AnimationInstance, UAnimMontage* Montage, float Position);
		static void SetNextSection(UAnimInstance* AnimationInstance, UAnimMontage* Montage, const char* SectionToChange, const char* NextSection);
		static float PlayMontage(UAnimInstance* AnimationInstance, UAnimMontage* Montage, float PlayRate, float TimeToStartMontageAt, bool StopAllMontages);
		static void PauseMontage(UAnimInstance* AnimationInstance, UAnimMontage* Montage);
		static void ResumeMontage(UAnimInstance* AnimationInstance, UAnimMontage* Montage);
		static void StopMontage(UAnimInstance* AnimationInstance, UAnimMontage* Montage, float BlendOutTime);
		static void JumpToSection(UAnimInstance* AnimationInstance, UAnimMontage* Montage, const char* SectionName);
		static void JumpToSectionsEnd(UAnimInstance* AnimationInstance, UAnimMontage* Montage, const char* SectionName);
	}

	namespace Player {
		static APlayerController* GetPlayerController(UPlayer* Player);
	}

	namespace PlayerInput {
		static bool IsKeyPressed(UPlayerInput* PlayerInput, const char* Key);
		static float GetTimeKeyPressed(UPlayerInput* PlayerInput, const char* Key);
		static void GetMouseSensitivity(UPlayerInput* PlayerInput, Vector2* Value);
		static void SetMouseSensitivity(UPlayerInput* PlayerInput, const Vector2* Value);
		static void AddActionMapping(UPlayerInput* PlayerInput, const char* ActionName, const char* Key, bool Shift, bool Ctrl, bool Alt, bool Cmd);
		static void AddAxisMapping(UPlayerInput* PlayerInput, const char* AxisName, const char* Key, float Scale);
		static void RemoveActionMapping(UPlayerInput* PlayerInput, const char* ActionName, const char* Key);
		static void RemoveAxisMapping(UPlayerInput* PlayerInput, const char* AxisName, const char* Key);
	}

	namespace Font {
		static void GetStringSize(UFont* Font, const char* Text, int32* Height, int32* Width);
	}

	namespace StreamableRenderAsset {

	}

	namespace StaticMesh {

	}

	namespace SkeletalMesh {

	}

	namespace Texture {

	}

	namespace Texture2D {
		static UTexture2D* CreateFromFile(const char* FilePath);
		static UTexture2D* CreateFromBuffer(const uint8* Buffer, int32 Length);
		static bool HasAlphaChannel(UTexture2D* Texture2D);
		static void GetSize(UTexture2D* Texture2D, Vector2* Value);
		static PixelFormat GetPixelFormat(UTexture2D* Texture2D);
	}

	namespace ActorComponent {
		static bool IsOwnerSelected(UActorComponent* ActorComponent);
		static AActor* GetOwner(UActorComponent* ActorComponent, ActorType Type);
		static void Destroy(UActorComponent* ActorComponent, bool PromoteChild);
		static void AddTag(UActorComponent* ActorComponent, const char* Tag);
		static void RemoveTag(UActorComponent* ActorComponent, const char* Tag);
		static bool HasTag(UActorComponent* ActorComponent, const char* Tag);
	}

	namespace InputComponent {
		static bool HasBindings(UInputComponent* InputComponent);
		static int32 GetActionBindingsNumber(UInputComponent* InputComponent);
		static void ClearActionBindings(UInputComponent* InputComponent);
		static void BindAction(UInputComponent* InputComponent, const char* ActionName, InputEvent KeyEvent, bool ExecutedWhenPaused, InputDelegate Callback);
		static void BindAxis(UInputComponent* InputComponent, const char* AxisName, bool ExecutedWhenPaused, InputAxisDelegate Callback);
		static void RemoveActionBinding(UInputComponent* InputComponent, const char* ActionName, InputEvent KeyEvent);
		static bool GetBlockInput(UInputComponent* InputComponent);
		static void SetBlockInput(UInputComponent* InputComponent, bool Value);
		static int32 GetPriority(UInputComponent* InputComponent);
		static void SetPriority(UInputComponent* InputComponent, int32 Value);
	}

	namespace SceneComponent {
		static bool IsAttachedToComponent(USceneComponent* SceneComponent, USceneComponent* Component);
		static bool IsAttachedToActor(USceneComponent* SceneComponent, AActor* Actor);
		static bool IsVisible(USceneComponent* SceneComponent);
		static bool IsSocketExists(USceneComponent* SceneComponent, const char* SocketName);
		static bool HasAnySockets(USceneComponent* SceneComponent);
		static bool CanAttachAsChild(USceneComponent* SceneComponent, USceneComponent* ChildComponent, const char* SocketName);
		static void ForEachAttachedChild(USceneComponent* SceneComponent, USceneComponent** Array, int32* Elements);
		static USceneComponent* Create(AActor* Actor, ComponentType Type, const char* Name, bool SetAsRoot, UObject* Blueprint);
		static bool AttachToComponent(USceneComponent* SceneComponent, USceneComponent* Parent, AttachmentTransformRule AttachmentRule, const char* SocketName);
		static void DetachFromComponent(USceneComponent* SceneComponent, DetachmentTransformRule DetachmentRule);
		static void Activate(USceneComponent* SceneComponent);
		static void Deactivate(USceneComponent* SceneComponent);
		static void UpdateToWorld(USceneComponent* SceneComponent, TeleportType Type, UpdateTransformFlags Flags);
		static void AddLocalOffset(USceneComponent* SceneComponent, const Vector3* DeltaLocation);
		static void AddLocalRotation(USceneComponent* SceneComponent, const Quaternion* DeltaRotation);
		static void AddRelativeLocation(USceneComponent* SceneComponent, const Vector3* DeltaLocation);
		static void AddRelativeRotation(USceneComponent* SceneComponent, const Quaternion* DeltaRotation);
		static void AddLocalTransform(USceneComponent* SceneComponent, const Transform* DeltaTransform);
		static void AddWorldOffset(USceneComponent* SceneComponent, const Vector3* DeltaLocation);
		static void AddWorldRotation(USceneComponent* SceneComponent, const Quaternion* DeltaRotation);
		static void AddWorldTransform(USceneComponent* SceneComponent, const Transform* DeltaTransform);
		static void GetAttachedSocketName(USceneComponent* SceneComponent, char* SocketName);
		static void GetBounds(USceneComponent* SceneComponent, const Transform* LocalToWorld, Bounds* Value);
		static void GetSocketLocation(USceneComponent* SceneComponent, const char* SocketName, Vector3* Value);
		static void GetSocketRotation(USceneComponent* SceneComponent, const char* SocketName, Quaternion* Value);
		static void GetComponentVelocity(USceneComponent* SceneComponent, Vector3* Value);
		static void GetComponentLocation(USceneComponent* SceneComponent, Vector3* Value);
		static void GetComponentRotation(USceneComponent* SceneComponent, Quaternion* Value);
		static void GetComponentScale(USceneComponent* SceneComponent, Vector3* Value);
		static void GetComponentTransform(USceneComponent* SceneComponent, Transform* Value);
		static void GetForwardVector(USceneComponent* SceneComponent, Vector3* Value);
		static void GetRightVector(USceneComponent* SceneComponent, Vector3* Value);
		static void GetUpVector(USceneComponent* SceneComponent, Vector3* Value);
		static void SetMobility(USceneComponent* SceneComponent, ComponentMobility Mobility);
		static void SetVisibility(USceneComponent* SceneComponent, bool NewVisibility, bool PropagateToChildren);
		static void SetRelativeLocation(USceneComponent* SceneComponent, const Vector3* Location);
		static void SetRelativeRotation(USceneComponent* SceneComponent, const Quaternion* Rotation);
		static void SetRelativeTransform(USceneComponent* SceneComponent, const Transform* Transform);
		static void SetWorldLocation(USceneComponent* SceneComponent, const Vector3* Location);
		static void SetWorldRotation(USceneComponent* SceneComponent, const Quaternion* Rotation);
		static void SetWorldScale(USceneComponent* SceneComponent, const Vector3* Scale);
		static void SetWorldTransform(USceneComponent* SceneComponent, const Transform* Transform);
	}

	namespace AudioComponent {
		static bool IsPlaying(UAudioComponent* AudioComponent);
		static bool GetPaused(UAudioComponent* AudioComponent);
		static void SetSound(UAudioComponent* AudioComponent, USoundBase* Sound);
		static void SetPaused(UAudioComponent* AudioComponent, bool Value);
		static void Play(UAudioComponent* AudioComponent);
		static void Stop(UAudioComponent* AudioComponent);
		static void FadeIn(UAudioComponent* AudioComponent, float Duration, float VolumeLevel, float StartTime, AudioFadeCurve FadeCurve);
		static void FadeOut(UAudioComponent* AudioComponent, float Duration, float VolumeLevel, AudioFadeCurve FadeCurve);
	}

	namespace CameraComponent {
		static bool GetConstrainAspectRatio(UCameraComponent* CameraComponent);
		static float GetAspectRatio(UCameraComponent* CameraComponent);
		static float GetFieldOfView(UCameraComponent* CameraComponent);
		static float GetOrthoFarClipPlane(UCameraComponent* CameraComponent);
		static float GetOrthoNearClipPlane(UCameraComponent* CameraComponent);
		static float GetOrthoWidth(UCameraComponent* CameraComponent);
		static bool GetLockToHeadMountedDisplay(UCameraComponent* CameraComponent);
		static void SetProjectionMode(UCameraComponent* CameraComponent, CameraProjectionMode Mode);
		static void SetConstrainAspectRatio(UCameraComponent* CameraComponent, bool Value);
		static void SetAspectRatio(UCameraComponent* CameraComponent, float Value);
		static void SetFieldOfView(UCameraComponent* CameraComponent, float Value);
		static void SetOrthoFarClipPlane(UCameraComponent* CameraComponent, float Value);
		static void SetOrthoNearClipPlane(UCameraComponent* CameraComponent, float Value);
		static void SetOrthoWidth(UCameraComponent* CameraComponent, float Value);
		static void SetLockToHeadMountedDisplay(UCameraComponent* CameraComponent, bool Value);
	}

	namespace ChildActorComponent {
		static AActor* GetChildActor(UChildActorComponent* ChildActorComponent, ActorType Type);
		static AActor* SetChildActor(UChildActorComponent* ChildActorComponent, ActorType Type);
	}

	namespace SpringArmComponent {
		static bool IsCollisionFixApplied(USpringArmComponent* SpringArmComponent);
		static bool GetDrawDebugLagMarkers(USpringArmComponent* SpringArmComponent);
		static bool GetCollisionTest(USpringArmComponent* SpringArmComponent);
		static bool GetCameraPositionLag(USpringArmComponent* SpringArmComponent);
		static bool GetCameraRotationLag(USpringArmComponent* SpringArmComponent);
		static bool GetCameraLagSubstepping(USpringArmComponent* SpringArmComponent);
		static bool GetInheritPitch(USpringArmComponent* SpringArmComponent);
		static bool GetInheritRoll(USpringArmComponent* SpringArmComponent);
		static bool GetInheritYaw(USpringArmComponent* SpringArmComponent);
		static float GetCameraLagMaxDistance(USpringArmComponent* SpringArmComponent);
		static float GetCameraLagMaxTimeStep(USpringArmComponent* SpringArmComponent);
		static float GetCameraPositionLagSpeed(USpringArmComponent* SpringArmComponent);
		static float GetCameraRotationLagSpeed(USpringArmComponent* SpringArmComponent);
		static CollisionChannel GetProbeChannel(USpringArmComponent* SpringArmComponent);
		static float GetProbeSize(USpringArmComponent* SpringArmComponent);
		static void GetSocketOffset(USpringArmComponent* SpringArmComponent, Vector3* Value);
		static float GetTargetArmLength(USpringArmComponent* SpringArmComponent);
		static void GetTargetOffset(USpringArmComponent* SpringArmComponent, Vector3* Value);
		static void GetUnfixedCameraPosition(USpringArmComponent* SpringArmComponent, Vector3* Value);
		static void GetDesiredRotation(USpringArmComponent* SpringArmComponent, Quaternion* Value);
		static void GetTargetRotation(USpringArmComponent* SpringArmComponent, Quaternion* Value);
		static bool GetUsePawnControlRotation(USpringArmComponent* SpringArmComponent);
		static void SetDrawDebugLagMarkers(USpringArmComponent* SpringArmComponent, bool Value);
		static void SetCollisionTest(USpringArmComponent* SpringArmComponent, bool Value);
		static void SetCameraPositionLag(USpringArmComponent* SpringArmComponent, bool Value);
		static void SetCameraRotationLag(USpringArmComponent* SpringArmComponent, bool Value);
		static void SetCameraLagSubstepping(USpringArmComponent* SpringArmComponent, bool Value);
		static void SetInheritPitch(USpringArmComponent* SpringArmComponent, bool Value);
		static void SetInheritRoll(USpringArmComponent* SpringArmComponent, bool Value);
		static void SetInheritYaw(USpringArmComponent* SpringArmComponent, bool Value);
		static void SetCameraLagMaxDistance(USpringArmComponent* SpringArmComponent, float Value);
		static void SetCameraLagMaxTimeStep(USpringArmComponent* SpringArmComponent, float Value);
		static void SetCameraPositionLagSpeed(USpringArmComponent* SpringArmComponent, float Value);
		static void SetCameraRotationLagSpeed(USpringArmComponent* SpringArmComponent, float Value);
		static void SetProbeChannel(USpringArmComponent* SpringArmComponent, CollisionChannel Value);
		static void SetProbeSize(USpringArmComponent* SpringArmComponent, float Value);
		static void SetSocketOffset(USpringArmComponent* SpringArmComponent, const Vector3* Value);
		static void SetTargetArmLength(USpringArmComponent* SpringArmComponent, float Value);
		static void SetTargetOffset(USpringArmComponent* SpringArmComponent, const Vector3* Value);
		static void SetUsePawnControlRotation(USpringArmComponent* SpringArmComponent, bool value);
	}

	namespace PostProcessComponent {
		static bool GetEnabled(UPostProcessComponent* PostProcessComponent);
		static float GetBlendRadius(UPostProcessComponent* PostProcessComponent);
		static float GetBlendWeight(UPostProcessComponent* PostProcessComponent);
		static bool GetUnbound(UPostProcessComponent* PostProcessComponent);
		static float GetPriority(UPostProcessComponent* PostProcessComponent);
		static void SetEnabled(UPostProcessComponent* PostProcessComponent, bool Value);
		static void SetBlendRadius(UPostProcessComponent* PostProcessComponent, float Value);
		static void SetBlendWeight(UPostProcessComponent* PostProcessComponent, float Value);
		static void SetUnbound(UPostProcessComponent* PostProcessComponent, bool Value);
		static void SetPriority(UPostProcessComponent* PostProcessComponent, float Priority);
	}

	namespace PrimitiveComponent {
		static bool IsGravityEnabled(UPrimitiveComponent* PrimitiveComponent);
		static bool IsOverlappingComponent(UPrimitiveComponent* PrimitiveComponent, UPrimitiveComponent* Other);
		static void ForEachOverlappingComponent(UPrimitiveComponent* PrimitiveComponent, UPrimitiveComponent** Array, int32* Elements);
		static void AddAngularImpulseInDegrees(UPrimitiveComponent* PrimitiveComponent, const Vector3* Impulse, const char* BoneName, bool VelocityChange);
		static void AddAngularImpulseInRadians(UPrimitiveComponent* PrimitiveComponent, const Vector3* Impulse, const char* BoneName, bool VelocityChange);
		static void AddForce(UPrimitiveComponent* PrimitiveComponent, const Vector3* Force, const char* BoneName, bool AccelerationChange);
		static void AddForceAtLocation(UPrimitiveComponent* PrimitiveComponent, const Vector3* Force, const Vector3* Location, const char* BoneName, bool LocalSpace);
		static void AddImpulse(UPrimitiveComponent* PrimitiveComponent, const Vector3* Impulse, const char* BoneName, bool VelocityChange);
		static void AddImpulseAtLocation(UPrimitiveComponent* PrimitiveComponent, const Vector3* Impulse, const Vector3* Location, const char* BoneName);
		static void AddRadialForce(UPrimitiveComponent* PrimitiveComponent, const Vector3* Origin, float Radius, float Strength, bool LinearFalloff, bool AccelerationChange);
		static void AddRadialImpulse(UPrimitiveComponent* PrimitiveComponent, const Vector3* Origin, float Radius, float Strength, bool LinearFalloff, bool AccelerationChange);
		static void AddTorqueInDegrees(UPrimitiveComponent* PrimitiveComponent, const Vector3* Torque, const char* BoneName, bool AccelerationChange);
		static void AddTorqueInRadians(UPrimitiveComponent* PrimitiveComponent, const Vector3* Torque, const char* BoneName, bool AccelerationChange);
		static float GetMass(UPrimitiveComponent* PrimitiveComponent);
		static void GetPhysicsLinearVelocity(UPrimitiveComponent* PrimitiveComponent, Vector3* Value, const char* BoneName);
		static void GetPhysicsLinearVelocityAtPoint(UPrimitiveComponent* PrimitiveComponent, Vector3* Value, const Vector3* Point, const char* BoneName);
		static void GetPhysicsAngularVelocityInDegrees(UPrimitiveComponent* PrimitiveComponent, Vector3* Value, const char* BoneName);
		static void GetPhysicsAngularVelocityInRadians(UPrimitiveComponent* PrimitiveComponent, Vector3* Value, const char* BoneName);
		static bool GetCastShadow(UPrimitiveComponent* PrimitiveComponent);
		static bool GetOnlyOwnerSee(UPrimitiveComponent* PrimitiveComponent);
		static bool GetOwnerNoSee(UPrimitiveComponent* PrimitiveComponent);
		static bool GetIgnoreRadialForce(UPrimitiveComponent* PrimitiveComponent);
		static bool GetIgnoreRadialImpulse(UPrimitiveComponent* PrimitiveComponent);
		static UMaterialInstanceDynamic* GetMaterial(UPrimitiveComponent* PrimitiveComponent, int32 ElementIndex);
		static int32 GetMaterialsNumber(UPrimitiveComponent* PrimitiveComponent);
		static float GetDistanceToCollision(UPrimitiveComponent* PrimitiveComponent, const Vector3* Point, Vector3* ClosestPointOnCollision);
		static bool GetSquaredDistanceToCollision(UPrimitiveComponent* PrimitiveComponent, const Vector3* Point, float* SquaredDistance, Vector3* ClosestPointOnCollision);
		static float GetAngularDamping(UPrimitiveComponent* PrimitiveComponent);
		static float GetLinearDamping(UPrimitiveComponent* PrimitiveComponent);
		static void SetGenerateOverlapEvents(UPrimitiveComponent* PrimitiveComponent, bool Value);
		static void SetGenerateHitEvents(UPrimitiveComponent* PrimitiveComponent, bool Value);
		static void SetMass(UPrimitiveComponent* PrimitiveComponent, float Mass, const char* BoneName);
		static void SetCenterOfMass(UPrimitiveComponent* PrimitiveComponent, const Vector3* Offset, const char* BoneName);
		static void SetPhysicsLinearVelocity(UPrimitiveComponent* PrimitiveComponent, const Vector3* Velocity, bool AddToCurrent, const char* BoneName);
		static void SetPhysicsAngularVelocityInDegrees(UPrimitiveComponent* PrimitiveComponent, const Vector3* AngularVelocity, bool AddToCurrent, const char* BoneName);
		static void SetPhysicsAngularVelocityInRadians(UPrimitiveComponent* PrimitiveComponent, const Vector3* AngularVelocity, bool AddToCurrent, const char* BoneName);
		static void SetPhysicsMaxAngularVelocityInDegrees(UPrimitiveComponent* PrimitiveComponent, float MaxAngularVelocity, bool AddToCurrent, const char* BoneName);
		static void SetPhysicsMaxAngularVelocityInRadians(UPrimitiveComponent* PrimitiveComponent, float MaxAngularVelocity, bool AddToCurrent, const char* BoneName);
		static void SetCastShadow(UPrimitiveComponent* PrimitiveComponent, bool Value);
		static void SetOnlyOwnerSee(UPrimitiveComponent* PrimitiveComponent, bool Value);
		static void SetOwnerNoSee(UPrimitiveComponent* PrimitiveComponent, bool Value);
		static void SetIgnoreRadialForce(UPrimitiveComponent* PrimitiveComponent, bool Value);
		static void SetIgnoreRadialImpulse(UPrimitiveComponent* PrimitiveComponent, bool Value);
		static void SetMaterial(UPrimitiveComponent* PrimitiveComponent, int32 ElementIndex, UMaterialInterface* Material);
		static void SetSimulatePhysics(UPrimitiveComponent* PrimitiveComponent, bool Value);
		static void SetAngularDamping(UPrimitiveComponent* PrimitiveComponent, float Value);
		static void SetLinearDamping(UPrimitiveComponent* PrimitiveComponent, float Value);
		static void SetEnableGravity(UPrimitiveComponent* PrimitiveComponent, bool Value);
		static void SetCollisionMode(UPrimitiveComponent* PrimitiveComponent, CollisionMode Mode);
		static void SetCollisionChannel(UPrimitiveComponent* PrimitiveComponent, CollisionChannel Channel);
		static void SetCollisionProfileName(UPrimitiveComponent* PrimitiveComponent, const char* ProfileName, bool UpdateOverlaps);
		static void SetCollisionResponseToChannel(UPrimitiveComponent* PrimitiveComponent, CollisionChannel Channel, CollisionResponse Response);
		static void SetCollisionResponseToAllChannels(UPrimitiveComponent* PrimitiveComponent, CollisionResponse Response);
		static void SetIgnoreActorWhenMoving(UPrimitiveComponent* PrimitiveComponent, AActor* Actor, bool Value);
		static void SetIgnoreComponentWhenMoving(UPrimitiveComponent* PrimitiveComponent, UPrimitiveComponent* Component, bool Value);
		static void ClearMoveIgnoreActors(UPrimitiveComponent* PrimitiveComponent);
		static void ClearMoveIgnoreComponents(UPrimitiveComponent* PrimitiveComponent);
		static UMaterialInstanceDynamic* CreateAndSetMaterialInstanceDynamic(UPrimitiveComponent* PrimitiveComponent, int32 ElementIndex);
		static void RegisterEvent(UPrimitiveComponent* PrimitiveComponent, ComponentEventType Type);
		static void UnregisterEvent(UPrimitiveComponent* PrimitiveComponent, ComponentEventType Type);
	}

	namespace ShapeComponent {
		static bool GetDynamicObstacle(UShapeComponent* ShapeComponent);
		static int32 GetShapeColor(UShapeComponent* ShapeComponent);
		static void SetDynamicObstacle(UShapeComponent* ShapeComponent, bool Value);
		static void SetShapeColor(UShapeComponent* ShapeComponent, Color Value);
	}

	namespace BoxComponent {
		static void GetScaledBoxExtent(UBoxComponent* BoxComponent, Vector3* Value);
		static void GetUnscaledBoxExtent(UBoxComponent* BoxComponent, Vector3* Value);
		static void SetBoxExtent(UBoxComponent* BoxComponent, const Vector3* Extent, bool UpdateOverlaps);
		static void InitBoxExtent(UBoxComponent* BoxComponent, const Vector3* Extent);
	}

	namespace SphereComponent {
		static float GetScaledSphereRadius(USphereComponent* SphereComponent);
		static float GetUnscaledSphereRadius(USphereComponent* SphereComponent);
		static float GetShapeScale(USphereComponent* SphereComponent);
		static void SetSphereRadius(USphereComponent* SphereComponent, float SphereRadius, bool UpdateOverlaps);
		static void InitSphereRadius(USphereComponent* SphereComponent, float SphereRadius);
	}

	namespace CapsuleComponent {
		static float GetScaledCapsuleRadius(UCapsuleComponent* CapsuleComponent);
		static float GetUnscaledCapsuleRadius(UCapsuleComponent* CapsuleComponent);
		static float GetShapeScale(UCapsuleComponent* CapsuleComponent);
		static void GetScaledCapsuleSize(UCapsuleComponent* CapsuleComponent, float* Radius, float* HalfHeight);
		static void GetUnscaledCapsuleSize(UCapsuleComponent* CapsuleComponent, float* Radius, float* HalfHeight);
		static void SetCapsuleRadius(UCapsuleComponent* CapsuleComponent, float Radius, bool UpdateOverlaps);
		static void SetCapsuleSize(UCapsuleComponent* CapsuleComponent, float Radius, float HalfHeight, bool UpdateOverlaps);
		static void InitCapsuleSize(UCapsuleComponent* CapsuleComponent, float Radius, float HalfHeight);
	}

	namespace MeshComponent {
		static bool IsValidMaterialSlotName(UMeshComponent* MeshComponent, const char* MaterialSlotName);
		static int32 GetMaterialIndex(UMeshComponent* MeshComponent, const char* MaterialSlotName);
	}

	namespace TextRenderComponent {
		static void SetFont(UTextRenderComponent* TextRenderComponent, UFont* Value);
		static void SetText(UTextRenderComponent* TextRenderComponent, const char* Value);
		static void SetTextMaterial(UTextRenderComponent* TextRenderComponent, UMaterialInterface* Material);
		static void SetTextRenderColor(UTextRenderComponent* TextRenderComponent, Color Value);
		static void SetHorizontalAlignment(UTextRenderComponent* TextRenderComponent, HorizontalTextAligment Value);
		static void SetHorizontalSpacingAdjustment(UTextRenderComponent* TextRenderComponent, float Value);
		static void SetVerticalAlignment(UTextRenderComponent* TextRenderComponent, VerticalTextAligment Value);
		static void SetVerticalSpacingAdjustment(UTextRenderComponent* TextRenderComponent, float Value);
		static void SetScale(UTextRenderComponent* TextRenderComponent, const Vector2* Value);
		static void SetWorldSize(UTextRenderComponent* TextRenderComponent, float Value);
	}

	namespace LightComponentBase {
		static float GetIntensity(ULightComponentBase* LightComponentBase);
		static bool GetCastShadows(ULightComponentBase* LightComponentBase);
		static void SetCastShadows(ULightComponentBase* LightComponentBase, bool Value);
	}

	namespace LightComponent {
		static void SetIntensity(ULightComponent* LightComponent, float Value);
		static void SetLightColor(ULightComponent* LightComponent, const LinearColor* Value);
	}

	namespace DirectionalLightComponent {

	}

	namespace MotionControllerComponent {
		static bool IsTracked(UMotionControllerComponent* MotionControllerComponent);
		static bool GetDisplayDeviceModel(UMotionControllerComponent* MotionControllerComponent);
		static bool GetDisableLowLatencyUpdate(UMotionControllerComponent* MotionControllerComponent);
		static ControllerHand GetTrackingSource(UMotionControllerComponent* MotionControllerComponent);
		static void SetDisplayDeviceModel(UMotionControllerComponent* MotionControllerComponent, bool Value);
		static void SetDisableLowLatencyUpdate(UMotionControllerComponent* MotionControllerComponent, bool Value);
		static void SetTrackingSource(UMotionControllerComponent* MotionControllerComponent, ControllerHand Value);
		static void SetTrackingMotionSource(UMotionControllerComponent* MotionControllerComponent, const char* Source);
		static void SetAssociatedPlayerIndex(UMotionControllerComponent* MotionControllerComponent, int32 PlayerIndex);
		static void SetCustomDisplayMesh(UMotionControllerComponent* MotionControllerComponent, UStaticMesh* StaticMesh);
		static void SetDisplayModelSource(UMotionControllerComponent* MotionControllerComponent, const char* Source);
	}

	namespace StaticMeshComponent {
		static void GetLocalBounds(UStaticMeshComponent* StaticMeshComponent, Vector3* Min, Vector3* Max);
		static UStaticMesh* GetStaticMesh(UStaticMeshComponent* StaticMeshComponent);
		static bool SetStaticMesh(UStaticMeshComponent* StaticMeshComponent, UStaticMesh* StaticMesh);
	}

	namespace InstancedStaticMeshComponent {
		static int32 GetInstanceCount(UInstancedStaticMeshComponent* InstancedStaticMeshComponent);
		static bool GetInstanceTransform(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, int32 InstanceIndex, Transform* Value, bool WorldSpace);
		static void AddInstance(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, const Transform* InstanceTransform);
		static void AddInstances(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, int32 EndInstanceIndex, const Transform InstanceTransforms[]);
		static bool UpdateInstanceTransform(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, int32 InstanceIndex, const Transform* InstanceTransform, bool WorldSpace, bool MarkRenderStateDirty, bool Teleport);
		static bool BatchUpdateInstanceTransforms(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, int32 StartInstanceIndex, int32 EndInstanceIndex, const Transform InstanceTransforms[], bool WorldSpace, bool MarkRenderStateDirty, bool Teleport);
		static bool RemoveInstance(UInstancedStaticMeshComponent* InstancedStaticMeshComponent, int32 InstanceIndex);
		static void ClearInstances(UInstancedStaticMeshComponent* InstancedStaticMeshComponent);
	}

	namespace HierarchicalInstancedStaticMeshComponent {
		static bool GetDisableCollision(UHierarchicalInstancedStaticMeshComponent* HierarchicalInstancedStaticMeshComponent);
		static void SetDisableCollision(UHierarchicalInstancedStaticMeshComponent* HierarchicalInstancedStaticMeshComponent, bool Value);
	}

	namespace SkinnedMeshComponent {
		static int32 GetBonesNumber(USkinnedMeshComponent* SkinnedMeshComponent);
		static int32 GetBoneIndex(USkinnedMeshComponent* SkinnedMeshComponent, const char* BoneName);
		static void GetBoneName(USkinnedMeshComponent* SkinnedMeshComponent, int32 BoneIndex, char* BoneName);
		static void GetBoneTransform(USkinnedMeshComponent* SkinnedMeshComponent, int32 BoneIndex, Transform* Value);
		static void SetSkeletalMesh(USkinnedMeshComponent* SkinnedMeshComponent, USkeletalMesh* SkeletalMesh, bool ReinitializePose);
	}

	namespace SkeletalMeshComponent {
		static bool IsPlaying(USkeletalMeshComponent* SkeletalMeshComponent);
		static UAnimInstance* GetAnimationInstance(USkeletalMeshComponent* SkeletalMeshComponent);
		static void SetAnimation(USkeletalMeshComponent* SkeletalMeshComponent, UAnimationAsset* Asset);
		static void SetAnimationMode(USkeletalMeshComponent* SkeletalMeshComponent, AnimationMode Mode);
		static void SetAnimationBlueprint(USkeletalMeshComponent* SkeletalMeshComponent, UObject* Blueprint);
		static void Play(USkeletalMeshComponent* SkeletalMeshComponent, bool Loop);
		static void PlayAnimation(USkeletalMeshComponent* SkeletalMeshComponent, UAnimationAsset* Asset, bool Loop);
		static void Stop(USkeletalMeshComponent* SkeletalMeshComponent);
	}

	namespace SplineComponent {
		static bool IsClosedLoop(USplineComponent* SplineComponent);
		static float GetDuration(USplineComponent* SplineComponent);
		static SplinePointType GetSplinePointType(USplineComponent* SplineComponent, int32 PointIndex);
		static int32 GetSplinePointsNumber(USplineComponent* SplineComponent);
		static int32 GetSplineSegmentsNumber(USplineComponent* SplineComponent);
		static void GetTangentAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetTangentAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetTangentAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, Vector3* Value);
		static void GetTransformAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Transform* Value);
		static void GetTransformAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, bool UseScale, Transform* Value);
		static void GetArriveTangentAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetDefaultUpVector(USplineComponent* SplineComponent, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetDirectionAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetDirectionAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetDirectionAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, Vector3* Value);
		static float GetDistanceAlongSplineAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex);
		static void GetLeaveTangentAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetLocationAndTangentAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Location, Vector3* Tangent);
		static void GetLocationAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetLocationAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetLocationAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetRightVectorAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetRightVectorAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetRightVectorAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, Vector3* Value);
		static float GetRollAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace);
		static float GetRollAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace);
		static float GetRollAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity);
		static void GetRotationAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Quaternion* Value);
		static void GetRotationAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Quaternion* Value);
		static void GetRotationAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, Quaternion* Value);
		static void GetScaleAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, Vector3* Value);
		static void GetScaleAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, Vector3* Value);
		static void GetScaleAtTime(USplineComponent* SplineComponent, float Time, bool UseConstantVelocity, Vector3* Value);
		static float GetSplineLength(USplineComponent* SplineComponent);
		static void GetTransformAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, bool UseScale, Transform* Value);
		static void GetUpVectorAtDistanceAlongSpline(USplineComponent* SplineComponent, float Distance, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetUpVectorAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void GetUpVectorAtTime(USplineComponent* SplineComponent, float Time, SplineCoordinateSpace CoordinateSpace, bool UseConstantVelocity, Vector3* Value);
		static void SetDuration(USplineComponent* SplineComponent, float Value);
		static void SetSplinePointType(USplineComponent* SplineComponent, int32 PointIndex, SplinePointType Type, bool UpdateSpline);
		static void SetClosedLoop(USplineComponent* SplineComponent, bool Value, bool UpdateSpline);
		static void SetDefaultUpVector(USplineComponent* SplineComponent, const Vector3* Value, SplineCoordinateSpace CoordinateSpace);
		static void SetLocationAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, const Vector3* Value, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline);
		static void SetTangentAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, const Vector3* Tangent, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline);
		static void SetTangentsAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, const Vector3* ArriveTangent, const Vector3* LeaveTangent, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline);
		static void SetUpVectorAtSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, const Vector3* UpVector, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline);
		static void AddSplinePoint(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline);
		static void AddSplinePointAtIndex(USplineComponent* SplineComponent, const Vector3* Location, int32 PointIndex, SplineCoordinateSpace CoordinateSpace, bool UpdateSpline);
		static void ClearSplinePoints(USplineComponent* SplineComponent, bool UpdateSpline);
		static void FindDirectionClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void FindLocationClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void FindUpVectorClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void FindRightVectorClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static float FindRollClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace);
		static void FindScaleClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, Vector3* Value);
		static void FindTangentClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, Vector3* Value);
		static void FindTransformClosestToWorldLocation(USplineComponent* SplineComponent, const Vector3* Location, SplineCoordinateSpace CoordinateSpace, bool UseScale, Transform* Value);
		static void RemoveSplinePoint(USplineComponent* SplineComponent, int32 PointIndex, bool UpdateSpline);
		static void UpdateSpline(USplineComponent* SplineComponent);
	}

	namespace RadialForceComponent {
		static bool GetIgnoreOwningActor(URadialForceComponent* RadialForceComponent);
		static bool GetImpulseVelocityChange(URadialForceComponent* RadialForceComponent);
		static bool GetLinearFalloff(URadialForceComponent* RadialForceComponent);
		static float GetForceStrength(URadialForceComponent* RadialForceComponent);
		static float GetImpulseStrength(URadialForceComponent* RadialForceComponent);
		static float GetRadius(URadialForceComponent* RadialForceComponent);
		static void SetIgnoreOwningActor(URadialForceComponent* RadialForceComponent, bool Value);
		static void SetImpulseVelocityChange(URadialForceComponent* RadialForceComponent, bool Value);
		static void SetLinearFalloff(URadialForceComponent* RadialForceComponent, bool Value);
		static void SetForceStrength(URadialForceComponent* RadialForceComponent, float Value);
		static void SetImpulseStrength(URadialForceComponent* RadialForceComponent, float Value);
		static void SetRadius(URadialForceComponent* RadialForceComponent, float Value);
		static void AddCollisionChannelToAffect(URadialForceComponent* RadialForceComponent, CollisionChannel Channel);
		static void FireImpulse(URadialForceComponent* RadialForceComponent);
	}

	namespace MaterialInterface {
		static bool IsTwoSided(UMaterialInterface* MaterialInterface);
	}

	namespace Material {
		static bool IsDefaultMaterial(UMaterial* Material);
	}

	namespace MaterialInstance {
		static bool IsChildOf(UMaterialInstance* MaterialInstance, UMaterialInterface* Material);
		static UMaterialInstanceDynamic* GetParent(UMaterialInstance* MaterialInstance);
	}

	namespace MaterialInstanceDynamic {
		static void ClearParameterValues(UMaterialInstanceDynamic* MaterialInstanceDynamic);
		static void SetTextureParameterValue(UMaterialInstanceDynamic* MaterialInstanceDynamic, const char* ParameterName, UTexture* Value);
		static void SetVectorParameterValue(UMaterialInstanceDynamic* MaterialInstanceDynamic, const char* ParameterName, const LinearColor* Value);
		static void SetScalarParameterValue(UMaterialInstanceDynamic* MaterialInstanceDynamic, const char* ParameterName, float Value);
	}
}