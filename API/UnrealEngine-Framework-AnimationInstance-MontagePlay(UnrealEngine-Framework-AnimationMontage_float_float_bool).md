### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[AnimationInstance](./UnrealEngine-Framework-AnimationInstance.md 'UnrealEngine.Framework.AnimationInstance')
## AnimationInstance.MontagePlay(UnrealEngine.Framework.AnimationMontage, float, float, bool) Method
Plays an animation montage  
```csharp
public float MontagePlay(UnrealEngine.Framework.AnimationMontage montage, float playRate=1f, float timeToStartMontageAt=0f, bool stopAllMontages=true);
```
#### Parameters
<a name='UnrealEngine-Framework-AnimationInstance-MontagePlay(UnrealEngine-Framework-AnimationMontage_float_float_bool)-montage'></a>
`montage` [AnimationMontage](./UnrealEngine-Framework-AnimationMontage.md 'UnrealEngine.Framework.AnimationMontage')  
  
<a name='UnrealEngine-Framework-AnimationInstance-MontagePlay(UnrealEngine-Framework-AnimationMontage_float_float_bool)-playRate'></a>
`playRate` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
  
<a name='UnrealEngine-Framework-AnimationInstance-MontagePlay(UnrealEngine-Framework-AnimationMontage_float_float_bool)-timeToStartMontageAt'></a>
`timeToStartMontageAt` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
  
<a name='UnrealEngine-Framework-AnimationInstance-MontagePlay(UnrealEngine-Framework-AnimationMontage_float_float_bool)-stopAllMontages'></a>
`stopAllMontages` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The length of the animation montage in seconds, or 0.0f if failed to play  
