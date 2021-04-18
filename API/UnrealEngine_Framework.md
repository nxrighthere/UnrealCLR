## UnrealEngine.Framework Namespace
### Classes

***
[Actor](Actor.md 'UnrealEngine.Framework.Actor')

The base class of an object that can be placed or spawned in a level  

***
[ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent')

The base class of components that define reusable behavior and can be added to different types of actors  

***
[AIController](AIController.md 'UnrealEngine.Framework.AIController')

The base class of controllers for an AI-controlled [Pawn](Pawn.md 'UnrealEngine.Framework.Pawn')

***
[AmbientSound](AmbientSound.md 'UnrealEngine.Framework.AmbientSound')

A sound actor that can be placed in a level  

***
[AnimationAsset](AnimationAsset.md 'UnrealEngine.Framework.AnimationAsset')

The base class of animation assets that can be played and evaluated to produce a pose  

***
[AnimationCompositeBase](AnimationCompositeBase.md 'UnrealEngine.Framework.AnimationCompositeBase')

The base class of animation composites  

***
[AnimationInstance](AnimationInstance.md 'UnrealEngine.Framework.AnimationInstance')

An animation instance representation  

***
[AnimationMontage](AnimationMontage.md 'UnrealEngine.Framework.AnimationMontage')

A single animation asset that can combine and selectively play animations  

***
[AnimationSequence](AnimationSequence.md 'UnrealEngine.Framework.AnimationSequence')

A single animation asset that can be played  

***
[AnimationSequenceBase](AnimationSequenceBase.md 'UnrealEngine.Framework.AnimationSequenceBase')

The base class of animation sequences  

***
[Application](Application.md 'UnrealEngine.Framework.Application')

Provides information about the application  

***
[Assert](Assert.md 'UnrealEngine.Framework.Assert')

Functionality to detect and diagnose unexpected or invalid runtime conditions during development, emitted if the assembly is built with the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build#options">Debug</a> configuration or if `ASSERTIONS` symbol is defined, signals a breakpoint to an attached debugger  

***
[AssetRegistry](AssetRegistry.md 'UnrealEngine.Framework.AssetRegistry')

An asset registry  

***
[AudioComponent](AudioComponent.md 'UnrealEngine.Framework.AudioComponent')

A component that is used to play a sound  

***
[Blueprint](Blueprint.md 'UnrealEngine.Framework.Blueprint')

An asset that provides an intuitive node-based interface  

***
[BoxComponent](BoxComponent.md 'UnrealEngine.Framework.BoxComponent')

A box generally used for simple collision  

***
[Brush](Brush.md 'UnrealEngine.Framework.Brush')

The base class of brushes for level construction  

***
[Camera](Camera.md 'UnrealEngine.Framework.Camera')

A camera viewpoint that can be placed in a level  

***
[CameraComponent](CameraComponent.md 'UnrealEngine.Framework.CameraComponent')

Represents a camera viewpoint and settings, such as projection type, field of view, and post-process overrides  

***
[CapsuleComponent](CapsuleComponent.md 'UnrealEngine.Framework.CapsuleComponent')

A capsule generally used for simple collision  

***
[Character](Character.md 'UnrealEngine.Framework.Character')

Represents a character that have a mesh, collision, and built-in movement logic  

***
[ChildActorComponent](ChildActorComponent.md 'UnrealEngine.Framework.ChildActorComponent')

A component that automatically spawns and destroys a child actor  

***
[CommandLine](CommandLine.md 'UnrealEngine.Framework.CommandLine')

Functionality to work with the command-line of the engine executable  

***
[ConsoleManager](ConsoleManager.md 'UnrealEngine.Framework.ConsoleManager')

Handles console commands and variables  

***
[ConsoleObject](ConsoleObject.md 'UnrealEngine.Framework.ConsoleObject')

Interface for console objects  

***
[ConsoleVariable](ConsoleVariable.md 'UnrealEngine.Framework.ConsoleVariable')

Interface for console variables  

***
[Controller](Controller.md 'UnrealEngine.Framework.Controller')

Non-physical actors that can possess a [Pawn](Pawn.md 'UnrealEngine.Framework.Pawn') to control its actions  

***
[Debug](Debug.md 'UnrealEngine.Framework.Debug')

Functionality for debugging  

***
[DirectionalLight](DirectionalLight.md 'UnrealEngine.Framework.DirectionalLight')

Simulates light that is being emitted from a source that is infinitely far away  

***
[DirectionalLightComponent](DirectionalLightComponent.md 'UnrealEngine.Framework.DirectionalLightComponent')

A component that represents directional light  

***
[Engine](Engine.md 'UnrealEngine.Framework.Engine')

Functionality for management of engine systems  

***
[Font](Font.md 'UnrealEngine.Framework.Font')

A font object that is used to draw text  

***
[HeadMountedDisplay](HeadMountedDisplay.md 'UnrealEngine.Framework.HeadMountedDisplay')

Functionality for access to the head-mounted display  

***
[HierarchicalInstancedStaticMeshComponent](HierarchicalInstancedStaticMeshComponent.md 'UnrealEngine.Framework.HierarchicalInstancedStaticMeshComponent')

A component that efficiently renders multiple instances of the same [StaticMeshComponent](StaticMeshComponent.md 'UnrealEngine.Framework.StaticMeshComponent') with different level of detail  

***
[InputComponent](InputComponent.md 'UnrealEngine.Framework.InputComponent')

An input component is a transient component that enables an actor to bind various forms of input events to delegate functions  

***
[InstancedStaticMeshComponent](InstancedStaticMeshComponent.md 'UnrealEngine.Framework.InstancedStaticMeshComponent')

A component that efficiently renders multiple instances of the same [StaticMeshComponent](StaticMeshComponent.md 'UnrealEngine.Framework.StaticMeshComponent')

***
[Keys](Keys.md 'UnrealEngine.Framework.Keys')

Key codes  

***
[Keys.Android](Keys_Android.md 'UnrealEngine.Framework.Keys.Android')

Android  

***
[Keys.Daydream](Keys_Daydream.md 'UnrealEngine.Framework.Keys.Daydream')

Google Daydream  

***
[Keys.Gamepad](Keys_Gamepad.md 'UnrealEngine.Framework.Keys.Gamepad')

Gamepad  

***
[Keys.Gesture](Keys_Gesture.md 'UnrealEngine.Framework.Keys.Gesture')

Gestures  

***
[Keys.MixedReality](Keys_MixedReality.md 'UnrealEngine.Framework.Keys.MixedReality')

Microsoft Mixed Reality  

***
[Keys.OculusGo](Keys_OculusGo.md 'UnrealEngine.Framework.Keys.OculusGo')

Oculus Go  

***
[Keys.OculusTouch](Keys_OculusTouch.md 'UnrealEngine.Framework.Keys.OculusTouch')

Oculus Touch  

***
[Keys.Platform](Keys_Platform.md 'UnrealEngine.Framework.Keys.Platform')

Platform-specific  

***
[Keys.PS4](Keys_PS4.md 'UnrealEngine.Framework.Keys.PS4')

PS4  

***
[Keys.Steam](Keys_Steam.md 'UnrealEngine.Framework.Keys.Steam')

Steam Controller  

***
[Keys.ValveIndex](Keys_ValveIndex.md 'UnrealEngine.Framework.Keys.ValveIndex')

Valve Index  

***
[Keys.Virtual](Keys_Virtual.md 'UnrealEngine.Framework.Keys.Virtual')

Virtual key codes used for input axis button press/release emulation  

***
[Keys.Vive](Keys_Vive.md 'UnrealEngine.Framework.Keys.Vive')

HTC Vive  

***
[Keys.Xbox](Keys_Xbox.md 'UnrealEngine.Framework.Keys.Xbox')

Xbox  

***
[LevelScript](LevelScript.md 'UnrealEngine.Framework.LevelScript')

A representation of the level-wide logic defined in the level blueprint  

***
[Light](Light.md 'UnrealEngine.Framework.Light')

A light actor that can be placed in a level  

***
[LightComponent](LightComponent.md 'UnrealEngine.Framework.LightComponent')

A component that represents light  

***
[LightComponentBase](LightComponentBase.md 'UnrealEngine.Framework.LightComponentBase')

The base class of light components  

***
[Material](Material.md 'UnrealEngine.Framework.Material')

An asset which can be applied to a mesh to control the visual look  

***
[MaterialInstance](MaterialInstance.md 'UnrealEngine.Framework.MaterialInstance')

An abstract instance of the material  

***
[MaterialInstanceDynamic](MaterialInstanceDynamic.md 'UnrealEngine.Framework.MaterialInstanceDynamic')

A dynamic instance of the material  

***
[MaterialInterface](MaterialInterface.md 'UnrealEngine.Framework.MaterialInterface')

The base class of materials that can be applied to meshes  

***
[Maths](Maths.md 'UnrealEngine.Framework.Maths')

Provides additional static constants and methods for mathematical functions that are lack in [System.Math](https://docs.microsoft.com/en-us/dotnet/api/System.Math 'System.Math'), [System.MathF](https://docs.microsoft.com/en-us/dotnet/api/System.MathF 'System.MathF'), and [System.Numerics](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics 'System.Numerics')

***
[MeshComponent](MeshComponent.md 'UnrealEngine.Framework.MeshComponent')

An abstract component that is an instance of a renderable collection of triangles  

***
[MotionControllerComponent](MotionControllerComponent.md 'UnrealEngine.Framework.MotionControllerComponent')

A component that represents a physical motion controller in 3D space  

***
[Pawn](Pawn.md 'UnrealEngine.Framework.Pawn')

The base class of actors that can be possessed by players or AI  

***
[Player](Player.md 'UnrealEngine.Framework.Player')

A player representation  

***
[PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')

An actor that is used by human players to control a [Pawn](Pawn.md 'UnrealEngine.Framework.Pawn')

***
[PlayerInput](PlayerInput.md 'UnrealEngine.Framework.PlayerInput')

An input manager of [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')

***
[PointLight](PointLight.md 'UnrealEngine.Framework.PointLight')

Emits light in all directions from the light bulb's tungsten filament  

***
[PostProcessComponent](PostProcessComponent.md 'UnrealEngine.Framework.PostProcessComponent')

A component that is used for post-processing manipulations  

***
[PostProcessVolume](PostProcessVolume.md 'UnrealEngine.Framework.PostProcessVolume')

An actor that is used for post-processing manipulations  

***
[PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')

An abstract component that contains or generates some sort of geometry, generally to be rendered or used as collision data  

***
[RadialForceComponent](RadialForceComponent.md 'UnrealEngine.Framework.RadialForceComponent')

A component that emits a radial force or impulse that can affect physics objects and destructible objects  

***
[RectLight](RectLight.md 'UnrealEngine.Framework.RectLight')

Emits light into the scene from a rectangular plane with a defined width and height  

***
[SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent')

The base class of components that can be transformed or attached, but has no rendering or collision capabilities  

***
[ShapeComponent](ShapeComponent.md 'UnrealEngine.Framework.ShapeComponent')

An abstract component that is represented by a simple geometrical shape  

***
[SkeletalMesh](SkeletalMesh.md 'UnrealEngine.Framework.SkeletalMesh')

A geometry bound to a hierarchical skeleton of bones which can be animated  

***
[SkeletalMeshComponent](SkeletalMeshComponent.md 'UnrealEngine.Framework.SkeletalMeshComponent')

A component that is used to create an instance of an animated [SkeletalMesh](SkeletalMesh.md 'UnrealEngine.Framework.SkeletalMesh') asset  

***
[SkinnedMeshComponent](SkinnedMeshComponent.md 'UnrealEngine.Framework.SkinnedMeshComponent')

A component that supports bone skinned mesh rendering  

***
[SoundBase](SoundBase.md 'UnrealEngine.Framework.SoundBase')

The base class of playable sound objects  

***
[SoundWave](SoundWave.md 'UnrealEngine.Framework.SoundWave')

A playable sound object for raw wave files  

***
[SphereComponent](SphereComponent.md 'UnrealEngine.Framework.SphereComponent')

A sphere generally used for simple collision  

***
[SplineComponent](SplineComponent.md 'UnrealEngine.Framework.SplineComponent')

Represents a spline shape  

***
[SpotLight](SpotLight.md 'UnrealEngine.Framework.SpotLight')

Emits light from a single point in a cone shape  

***
[SpringArmComponent](SpringArmComponent.md 'UnrealEngine.Framework.SpringArmComponent')

A component that maintains its children at a fixed distance from the parent, but will retract the children if there is a collision, and spring back when there is no collision  

***
[StaticMesh](StaticMesh.md 'UnrealEngine.Framework.StaticMesh')

A piece of geometry that consists of a static set of polygons  

***
[StaticMeshComponent](StaticMeshComponent.md 'UnrealEngine.Framework.StaticMeshComponent')

A component that is used to create an instance of a static mesh, a piece of geometry that consists of a static set of polygons  

***
[StreamableRenderAsset](StreamableRenderAsset.md 'UnrealEngine.Framework.StreamableRenderAsset')

A render asset that can be streamed at runtime  

***
[TextRenderComponent](TextRenderComponent.md 'UnrealEngine.Framework.TextRenderComponent')

Renders text in the world  

***
[Texture](Texture.md 'UnrealEngine.Framework.Texture')

A representation of the surface of an object  

***
[Texture2D](Texture2D.md 'UnrealEngine.Framework.Texture2D')

A texture asset  

***
[TriggerBase](TriggerBase.md 'UnrealEngine.Framework.TriggerBase')

The base class of actors that used to generate collision events  

***
[TriggerBox](TriggerBox.md 'UnrealEngine.Framework.TriggerBox')

A box shaped trigger with [BoxComponent](BoxComponent.md 'UnrealEngine.Framework.BoxComponent') used to generate overlap events  

***
[TriggerCapsule](TriggerCapsule.md 'UnrealEngine.Framework.TriggerCapsule')

A capsule shaped trigger with [CapsuleComponent](CapsuleComponent.md 'UnrealEngine.Framework.CapsuleComponent') used to generate overlap events  

***
[TriggerSphere](TriggerSphere.md 'UnrealEngine.Framework.TriggerSphere')

A sphere shaped trigger with [SphereComponent](SphereComponent.md 'UnrealEngine.Framework.SphereComponent') used to generate overlap events  

***
[TriggerVolume](TriggerVolume.md 'UnrealEngine.Framework.TriggerVolume')

An actor that is used to trigger events  

***
[Volume](Volume.md 'UnrealEngine.Framework.Volume')

An editable 3D volume placed in a level, different types of volumes perform different functions  

***
[World](World.md 'UnrealEngine.Framework.World')

The top-level representation of a map or a sandbox in which actors and components will exist and rendered  
### Structs

***
[ActorReference](ActorReference.md 'UnrealEngine.Framework.ActorReference')

A representation of the engine's actor reference  

***
[Asset](Asset.md 'UnrealEngine.Framework.Asset')

A representation of the asset  

***
[Bounds](Bounds.md 'UnrealEngine.Framework.Bounds')

A combined axis-aligned bounding box and bounding sphere with the same origin  

***
[CollisionShape](CollisionShape.md 'UnrealEngine.Framework.CollisionShape')

A collision shape  

***
[ComponentReference](ComponentReference.md 'UnrealEngine.Framework.ComponentReference')

A representation of the engine's component reference  

***
[Hit](Hit.md 'UnrealEngine.Framework.Hit')

A trace hit  

***
[LinearColor](LinearColor.md 'UnrealEngine.Framework.LinearColor')

A linear 32-bit floating-point RGBA color  

***
[ObjectReference](ObjectReference.md 'UnrealEngine.Framework.ObjectReference')

A representation of the engine's object reference  

***
[Transform](Transform.md 'UnrealEngine.Framework.Transform')

Transform composed of location, rotation, and scale  
### Enums

***
[ActorEventType](ActorEventType.md 'UnrealEngine.Framework.ActorEventType')

Defines actor events  

***
[AIFocusPriority](AIFocusPriority.md 'UnrealEngine.Framework.AIFocusPriority')

Defines focus priority for AI  

***
[AnimationMode](AnimationMode.md 'UnrealEngine.Framework.AnimationMode')

Defines the animation mode  

***
[AttachmentTransformRule](AttachmentTransformRule.md 'UnrealEngine.Framework.AttachmentTransformRule')

Defines rules for attaching components  

***
[AudioFadeCurve](AudioFadeCurve.md 'UnrealEngine.Framework.AudioFadeCurve')

Defines the type of fade to adjust audio volume  

***
[AutoPossessAI](AutoPossessAI.md 'UnrealEngine.Framework.AutoPossessAI')

Defines the possession type for AI pawn that will be automatically possed by an AI controller  

***
[AutoReceiveInput](AutoReceiveInput.md 'UnrealEngine.Framework.AutoReceiveInput')

Defines the player index that will be used to pass input  

***
[BlendType](BlendType.md 'UnrealEngine.Framework.BlendType')

Defines how to blend when changing view targets  

***
[CameraProjectionMode](CameraProjectionMode.md 'UnrealEngine.Framework.CameraProjectionMode')

Defines the projection mode for a camera  

***
[CollisionChannel](CollisionChannel.md 'UnrealEngine.Framework.CollisionChannel')

Defines collision channels  

***
[CollisionMode](CollisionMode.md 'UnrealEngine.Framework.CollisionMode')

Defines the collision mode  

***
[CollisionResponse](CollisionResponse.md 'UnrealEngine.Framework.CollisionResponse')

Defines collision response types  

***
[CollisionShapeType](CollisionShapeType.md 'UnrealEngine.Framework.CollisionShapeType')

Defines the collision shape type  

***
[ComponentEventType](ComponentEventType.md 'UnrealEngine.Framework.ComponentEventType')

Defines component events  

***
[ComponentMobility](ComponentMobility.md 'UnrealEngine.Framework.ComponentMobility')

Defines how often a component is allowed to move  

***
[ControllerHand](ControllerHand.md 'UnrealEngine.Framework.ControllerHand')

Defines the controller hands for tracking  

***
[DetachmentTransformRule](DetachmentTransformRule.md 'UnrealEngine.Framework.DetachmentTransformRule')

Defines rules for detaching components  

***
[HorizontalTextAligment](HorizontalTextAligment.md 'UnrealEngine.Framework.HorizontalTextAligment')

Defines the horizontal text aligment type  

***
[InputEvent](InputEvent.md 'UnrealEngine.Framework.InputEvent')

Defines input behavior type  

***
[LogLevel](LogLevel.md 'UnrealEngine.Framework.LogLevel')

Defines the log level for an output log message  

***
[NetMode](NetMode.md 'UnrealEngine.Framework.NetMode')

Defines the networking mode  

***
[PixelFormat](PixelFormat.md 'UnrealEngine.Framework.PixelFormat')

Defines the pixel format  

***
[SplineCoordinateSpace](SplineCoordinateSpace.md 'UnrealEngine.Framework.SplineCoordinateSpace')

Defines coordinate space  

***
[SplinePointType](SplinePointType.md 'UnrealEngine.Framework.SplinePointType')

Defines the spline point type  

***
[TeleportType](TeleportType.md 'UnrealEngine.Framework.TeleportType')

Defines teleportation types of physics body  

***
[UpdateTransformFlags](UpdateTransformFlags.md 'UnrealEngine.Framework.UpdateTransformFlags')

Defines how to update transform during movement  

***
[VerticalTextAligment](VerticalTextAligment.md 'UnrealEngine.Framework.VerticalTextAligment')

Defines the vertical text aligment type  

***
[WindowMode](WindowMode.md 'UnrealEngine.Framework.WindowMode')

Defines the window mode  
### Delegates

***
[ActorCursorDelegate(ActorReference)](ActorCursorDelegate(ActorReference).md 'UnrealEngine.Framework.ActorCursorDelegate(UnrealEngine.Framework.ActorReference)')

Delegate for actor cursor events  

***
[ActorHitDelegate(ActorReference, ActorReference, Vector3, Hit)](ActorHitDelegate(ActorReference_ActorReference_Vector3_Hit).md 'UnrealEngine.Framework.ActorHitDelegate(UnrealEngine.Framework.ActorReference, UnrealEngine.Framework.ActorReference, System.Numerics.Vector3, UnrealEngine.Framework.Hit)')

Delegate for actor hit events  

***
[ActorKeyDelegate(ActorReference, string)](ActorKeyDelegate(ActorReference_string).md 'UnrealEngine.Framework.ActorKeyDelegate(UnrealEngine.Framework.ActorReference, string)')

Delegate for actor key events  

***
[ActorOverlapDelegate(ActorReference, ActorReference)](ActorOverlapDelegate(ActorReference_ActorReference).md 'UnrealEngine.Framework.ActorOverlapDelegate(UnrealEngine.Framework.ActorReference, UnrealEngine.Framework.ActorReference)')

Delegate for actor overlap events  

***
[CharacterLandedDelegate(Hit)](CharacterLandedDelegate(Hit).md 'UnrealEngine.Framework.CharacterLandedDelegate(UnrealEngine.Framework.Hit)')

Delegate for character landing events  

***
[ComponentCursorDelegate(ComponentReference)](ComponentCursorDelegate(ComponentReference).md 'UnrealEngine.Framework.ComponentCursorDelegate(UnrealEngine.Framework.ComponentReference)')

Delegate for component cursor events  

***
[ComponentHitDelegate(ComponentReference, ComponentReference, Vector3, Hit)](ComponentHitDelegate(ComponentReference_ComponentReference_Vector3_Hit).md 'UnrealEngine.Framework.ComponentHitDelegate(UnrealEngine.Framework.ComponentReference, UnrealEngine.Framework.ComponentReference, System.Numerics.Vector3, UnrealEngine.Framework.Hit)')

Delegate for component hit events  

***
[ComponentKeyDelegate(ComponentReference, string)](ComponentKeyDelegate(ComponentReference_string).md 'UnrealEngine.Framework.ComponentKeyDelegate(UnrealEngine.Framework.ComponentReference, string)')

Delegate for component key events  

***
[ComponentOverlapDelegate(ComponentReference, ComponentReference)](ComponentOverlapDelegate(ComponentReference_ComponentReference).md 'UnrealEngine.Framework.ComponentOverlapDelegate(UnrealEngine.Framework.ComponentReference, UnrealEngine.Framework.ComponentReference)')

Delegate for component overlap events  

***
[ConsoleCommandDelegate(float)](ConsoleCommandDelegate(float).md 'UnrealEngine.Framework.ConsoleCommandDelegate(float)')

Delegate for console command events  

***
[ConsoleVariableDelegate()](ConsoleVariableDelegate().md 'UnrealEngine.Framework.ConsoleVariableDelegate()')

Delegate for console variable events  

***
[InputAxisDelegate(float)](InputAxisDelegate(float).md 'UnrealEngine.Framework.InputAxisDelegate(float)')

Delegate for axis events  

***
[InputDelegate()](InputDelegate().md 'UnrealEngine.Framework.InputDelegate()')

Delegate for action events  
