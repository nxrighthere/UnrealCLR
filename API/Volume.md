### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Volume Class
An editable 3D volume placed in a level, different types of volumes perform different functions  
```csharp
public abstract class Volume : UnrealEngine.Framework.Brush
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Actor](Actor.md 'UnrealEngine.Framework.Actor') &#129106; [Brush](Brush.md 'UnrealEngine.Framework.Brush') &#129106; Volume  

Derived  
&#8627; [PostProcessVolume](PostProcessVolume.md 'UnrealEngine.Framework.PostProcessVolume')
&#8627; [TriggerVolume](TriggerVolume.md 'UnrealEngine.Framework.TriggerVolume')  
### Methods

***
[EncompassesPoint(Vector3, float, float)](Volume_EncompassesPoint(Vector3_float_float).md 'UnrealEngine.Framework.Volume.EncompassesPoint(System.Numerics.Vector3, float, float)')

Returns `true` if a point or sphere overlaps the volume  
