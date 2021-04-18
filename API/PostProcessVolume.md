### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## PostProcessVolume Class
An actor that is used for post-processing manipulations  
```csharp
public class PostProcessVolume : UnrealEngine.Framework.Volume
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Actor](Actor.md 'UnrealEngine.Framework.Actor') &#129106; [Brush](Brush.md 'UnrealEngine.Framework.Brush') &#129106; [Volume](Volume.md 'UnrealEngine.Framework.Volume') &#129106; PostProcessVolume  
### Constructors

***
[PostProcessVolume(string, Blueprint)](PostProcessVolume_PostProcessVolume(string_Blueprint).md 'UnrealEngine.Framework.PostProcessVolume.PostProcessVolume(string, UnrealEngine.Framework.Blueprint)')

Spawns the actor in the world  
### Properties

***
[BlendRadius](PostProcessVolume_BlendRadius.md 'UnrealEngine.Framework.PostProcessVolume.BlendRadius')

Gets or sets the world space radius around the volume that is used for blending if not unbound  

***
[BlendWeight](PostProcessVolume_BlendWeight.md 'UnrealEngine.Framework.PostProcessVolume.BlendWeight')

Gets or sets the blend weight, 0.0f indicates no effect, 1.0f indicates full effect  

***
[Enabled](PostProcessVolume_Enabled.md 'UnrealEngine.Framework.PostProcessVolume.Enabled')

Gets or sets whether the volume is enabled  

***
[Priority](PostProcessVolume_Priority.md 'UnrealEngine.Framework.PostProcessVolume.Priority')

Gets or sets the priority of the volume  

***
[Unbound](PostProcessVolume_Unbound.md 'UnrealEngine.Framework.PostProcessVolume.Unbound')

Gets or sets whether the volume covers the whole world or only the area inside its bounds  
