### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## CameraComponent Class
Represents a camera viewpoint and settings, such as projection type, field of view, and post-process overrides  
```csharp
public class CameraComponent : UnrealEngine.Framework.SceneComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; CameraComponent  
### Constructors

***
[CameraComponent(Actor, string, bool, Blueprint)](CameraComponent_CameraComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.CameraComponent.CameraComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[AspectRatio](CameraComponent_AspectRatio.md 'UnrealEngine.Framework.CameraComponent.AspectRatio')

Gets or sets the aspect ratio if [ConstrainAspectRatio](CameraComponent_ConstrainAspectRatio.md 'UnrealEngine.Framework.CameraComponent.ConstrainAspectRatio') set to `true`

***
[ConstrainAspectRatio](CameraComponent_ConstrainAspectRatio.md 'UnrealEngine.Framework.CameraComponent.ConstrainAspectRatio')

Gets or sets whether black bars will be added if the destination view has a different aspect ratio than the camera requested  

***
[FieldOfView](CameraComponent_FieldOfView.md 'UnrealEngine.Framework.CameraComponent.FieldOfView')

Gets or sets the horizontal field of view (in degrees) in perspective mode (ignored in orthographic mode)  

***
[LockToHeadMountedDisplay](CameraComponent_LockToHeadMountedDisplay.md 'UnrealEngine.Framework.CameraComponent.LockToHeadMountedDisplay')

Gets or sets whether the camera's orientation and position is locked to the head-mounted display  

***
[OrthoFarClipPlane](CameraComponent_OrthoFarClipPlane.md 'UnrealEngine.Framework.CameraComponent.OrthoFarClipPlane')

Gets or sets the far plane distance of the orthographic view (in world units)  

***
[OrthoNearClipPlane](CameraComponent_OrthoNearClipPlane.md 'UnrealEngine.Framework.CameraComponent.OrthoNearClipPlane')

Gets or sets the near plane distance of the orthographic view (in world units)  

***
[OrthoWidth](CameraComponent_OrthoWidth.md 'UnrealEngine.Framework.CameraComponent.OrthoWidth')

Gets or sets the desired width of the orthographic view (in world units)  
### Methods

***
[SetProjectionMode(CameraProjectionMode)](CameraComponent_SetProjectionMode(CameraProjectionMode).md 'UnrealEngine.Framework.CameraComponent.SetProjectionMode(UnrealEngine.Framework.CameraProjectionMode)')

Sets the projection mode  
