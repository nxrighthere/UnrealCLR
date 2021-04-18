### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## CapsuleComponent Class
A capsule generally used for simple collision  
```csharp
public class CapsuleComponent : UnrealEngine.Framework.ShapeComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; [PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent') &#129106; [ShapeComponent](ShapeComponent.md 'UnrealEngine.Framework.ShapeComponent') &#129106; CapsuleComponent  
### Constructors

***
[CapsuleComponent(Actor, string, bool, Blueprint)](CapsuleComponent_CapsuleComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.CapsuleComponent.CapsuleComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[ScaledCapsuleRadius](CapsuleComponent_ScaledCapsuleRadius.md 'UnrealEngine.Framework.CapsuleComponent.ScaledCapsuleRadius')

Returns the capsule radius scaled by the component scale  

***
[ShapeScale](CapsuleComponent_ShapeScale.md 'UnrealEngine.Framework.CapsuleComponent.ShapeScale')

Returns the scale of the shape  

***
[UnscaledCapsuleRadius](CapsuleComponent_UnscaledCapsuleRadius.md 'UnrealEngine.Framework.CapsuleComponent.UnscaledCapsuleRadius')

Returns the capsule radius ignoring the component scale  
### Methods

***
[GetScaledCapsuleSize(float, float)](CapsuleComponent_GetScaledCapsuleSize(float_float).md 'UnrealEngine.Framework.CapsuleComponent.GetScaledCapsuleSize(float, float)')

Retrieves the capsule radius and half-height scaled by the component scale  

***
[GetUnscaledCapsuleSize(float, float)](CapsuleComponent_GetUnscaledCapsuleSize(float_float).md 'UnrealEngine.Framework.CapsuleComponent.GetUnscaledCapsuleSize(float, float)')

Retrieves the capsule radius and half-height ignoring the component scale  

***
[InitCapsuleSize(float, float)](CapsuleComponent_InitCapsuleSize(float_float).md 'UnrealEngine.Framework.CapsuleComponent.InitCapsuleSize(float, float)')

Sets the capsule size without triggering a render or physics update  

***
[SetCapsuleRadius(float, bool)](CapsuleComponent_SetCapsuleRadius(float_bool).md 'UnrealEngine.Framework.CapsuleComponent.SetCapsuleRadius(float, bool)')

Sets the capsule radius, unscaled before the component scale is applied  

***
[SetCapsuleSize(float, float, bool)](CapsuleComponent_SetCapsuleSize(float_float_bool).md 'UnrealEngine.Framework.CapsuleComponent.SetCapsuleSize(float, float, bool)')

Sets the capsule size, unscaled before the component scale is applied  
