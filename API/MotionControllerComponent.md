### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## MotionControllerComponent Class
A component that represents a physical motion controller in 3D space  
```csharp
public class MotionControllerComponent : UnrealEngine.Framework.PrimitiveComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; [PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent') &#129106; MotionControllerComponent  
### Constructors

***
[MotionControllerComponent(Actor, string, bool, Blueprint)](MotionControllerComponent_MotionControllerComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.MotionControllerComponent.MotionControllerComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[DisableLowLatencyUpdate](MotionControllerComponent_DisableLowLatencyUpdate.md 'UnrealEngine.Framework.MotionControllerComponent.DisableLowLatencyUpdate')

Gets or sets whether render transforms within the motion controller hierarchy will be updated a second time immediately before rendering  

***
[DisplayDeviceModel](MotionControllerComponent_DisplayDeviceModel.md 'UnrealEngine.Framework.MotionControllerComponent.DisplayDeviceModel')

Gets or sets whether to render a model associated with the set hand  

***
[IsTracked](MotionControllerComponent_IsTracked.md 'UnrealEngine.Framework.MotionControllerComponent.IsTracked')

Returns `true` if the component has a valid tracked device this frame  

***
[TrackingSource](MotionControllerComponent_TrackingSource.md 'UnrealEngine.Framework.MotionControllerComponent.TrackingSource')

Gets or sets the current tracking source  
### Methods

***
[SetAssociatedPlayerIndex(int)](MotionControllerComponent_SetAssociatedPlayerIndex(int).md 'UnrealEngine.Framework.MotionControllerComponent.SetAssociatedPlayerIndex(int)')

Sets the player index which the motion controller should automatically follow  

***
[SetCustomDisplayMesh(StaticMesh)](MotionControllerComponent_SetCustomDisplayMesh(StaticMesh).md 'UnrealEngine.Framework.MotionControllerComponent.SetCustomDisplayMesh(UnrealEngine.Framework.StaticMesh)')

Sets the custom display mesh that attached to the motion controller  

***
[SetDisplayModelSource(string)](MotionControllerComponent_SetDisplayModelSource(string).md 'UnrealEngine.Framework.MotionControllerComponent.SetDisplayModelSource(string)')

Sets the display model source  

***
[SetTrackingMotionSource(string)](MotionControllerComponent_SetTrackingMotionSource(string).md 'UnrealEngine.Framework.MotionControllerComponent.SetTrackingMotionSource(string)')

Sets the tracking motion source  
