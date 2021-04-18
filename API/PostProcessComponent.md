### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## PostProcessComponent Class
A component that is used for post-processing manipulations  
```csharp
public class PostProcessComponent : UnrealEngine.Framework.SceneComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; PostProcessComponent  
### Constructors

***
[PostProcessComponent(Actor, string, bool, Blueprint)](PostProcessComponent_PostProcessComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.PostProcessComponent.PostProcessComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[BlendRadius](PostProcessComponent_BlendRadius.md 'UnrealEngine.Framework.PostProcessComponent.BlendRadius')

Gets or sets the world space radius around the volume that is used for blending if not unbound  

***
[BlendWeight](PostProcessComponent_BlendWeight.md 'UnrealEngine.Framework.PostProcessComponent.BlendWeight')

Gets or sets the blend weight, 0.0f indicates no effect, 1.0f indicates full effect  

***
[Enabled](PostProcessComponent_Enabled.md 'UnrealEngine.Framework.PostProcessComponent.Enabled')

Gets or sets whether the volume is enabled  

***
[Priority](PostProcessComponent_Priority.md 'UnrealEngine.Framework.PostProcessComponent.Priority')

Gets or sets the priority of the volume  

***
[Unbound](PostProcessComponent_Unbound.md 'UnrealEngine.Framework.PostProcessComponent.Unbound')

Gets or sets whether the volume covers the whole world or only the area inside its bounds  
