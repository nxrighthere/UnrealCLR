### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## BoxComponent Class
A box generally used for simple collision  
```csharp
public class BoxComponent : UnrealEngine.Framework.ShapeComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; [PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent') &#129106; [ShapeComponent](ShapeComponent.md 'UnrealEngine.Framework.ShapeComponent') &#129106; BoxComponent  
### Constructors

***
[BoxComponent(Actor, string, bool, Blueprint)](BoxComponent_BoxComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.BoxComponent.BoxComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Methods

***
[GetScaledBoxExtent()](BoxComponent_GetScaledBoxExtent().md 'UnrealEngine.Framework.BoxComponent.GetScaledBoxExtent()')

Returns the box extents scaled by the component scale  

***
[GetScaledBoxExtent(Vector3)](BoxComponent_GetScaledBoxExtent(Vector3).md 'UnrealEngine.Framework.BoxComponent.GetScaledBoxExtent(System.Numerics.Vector3)')

Retrieves the box extents scaled by the component scale  

***
[GetUnscaledBoxExtent()](BoxComponent_GetUnscaledBoxExtent().md 'UnrealEngine.Framework.BoxComponent.GetUnscaledBoxExtent()')

Returns the box extent ignoring the component scale  

***
[GetUnscaledBoxExtent(Vector3)](BoxComponent_GetUnscaledBoxExtent(Vector3).md 'UnrealEngine.Framework.BoxComponent.GetUnscaledBoxExtent(System.Numerics.Vector3)')

Retrieves the box extent ignoring the component scale  

***
[InitBoxExtent(Vector3)](BoxComponent_InitBoxExtent(Vector3).md 'UnrealEngine.Framework.BoxComponent.InitBoxExtent(System.Numerics.Vector3)')

Sets the box extent size without triggering a render or physics update  

***
[SetBoxExtent(Vector3, bool)](BoxComponent_SetBoxExtent(Vector3_bool).md 'UnrealEngine.Framework.BoxComponent.SetBoxExtent(System.Numerics.Vector3, bool)')

Sets the box extent size, unscaled before the component scale is applied  
