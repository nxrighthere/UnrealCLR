### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## SphereComponent Class
A sphere generally used for simple collision  
```csharp
public class SphereComponent : UnrealEngine.Framework.ShapeComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; [PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent') &#129106; [ShapeComponent](ShapeComponent.md 'UnrealEngine.Framework.ShapeComponent') &#129106; SphereComponent  
### Constructors

***
[SphereComponent(Actor, string, bool, Blueprint)](SphereComponent_SphereComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.SphereComponent.SphereComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[ScaledSphereRadius](SphereComponent_ScaledSphereRadius.md 'UnrealEngine.Framework.SphereComponent.ScaledSphereRadius')

Returns the sphere radius scaled by the component scale  

***
[ShapeScale](SphereComponent_ShapeScale.md 'UnrealEngine.Framework.SphereComponent.ShapeScale')

Returns the scale of the shape  

***
[UnscaledSphereRadius](SphereComponent_UnscaledSphereRadius.md 'UnrealEngine.Framework.SphereComponent.UnscaledSphereRadius')

Returns the sphere radius ignoring the component scale  
### Methods

***
[InitSphereRadius(float)](SphereComponent_InitSphereRadius(float).md 'UnrealEngine.Framework.SphereComponent.InitSphereRadius(float)')

Sets the sphere radius without triggering a render or physics update  

***
[SetSphereRadius(float, bool)](SphereComponent_SetSphereRadius(float_bool).md 'UnrealEngine.Framework.SphereComponent.SetSphereRadius(float, bool)')

Sets the sphere radius, unscaled before the component scale is applied  
