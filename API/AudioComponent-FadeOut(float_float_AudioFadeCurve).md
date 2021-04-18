### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[AudioComponent](./AudioComponent.md 'UnrealEngine.Framework.AudioComponent')
## AudioComponent.FadeOut(float, float, UnrealEngine.Framework.AudioFadeCurve) Method
Smoothly stops the audio, can be used instead of [Stop()](./AudioComponent-Stop().md 'UnrealEngine.Framework.AudioComponent.Stop()')  
```csharp
public void FadeOut(float duration, float volumeLevel=0f, UnrealEngine.Framework.AudioFadeCurve fadeCurve=UnrealEngine.Framework.AudioFadeCurve.Linear);
```
#### Parameters
<a name='UnrealEngine-Framework-AudioComponent-FadeOut(float_float_UnrealEngine-Framework-AudioFadeCurve)-duration'></a>
`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Duration to reach [volumeLevel](#UnrealEngine-Framework-AudioComponent-FadeOut(float_float_UnrealEngine-Framework-AudioFadeCurve)-volumeLevel 'UnrealEngine.Framework.AudioComponent.FadeOut(float, float, UnrealEngine.Framework.AudioFadeCurve).volumeLevel')  
  
<a name='UnrealEngine-Framework-AudioComponent-FadeOut(float_float_UnrealEngine-Framework-AudioFadeCurve)-volumeLevel'></a>
`volumeLevel` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
he percentage of calculated volume to fade to  
  
<a name='UnrealEngine-Framework-AudioComponent-FadeOut(float_float_UnrealEngine-Framework-AudioFadeCurve)-fadeCurve'></a>
`fadeCurve` [AudioFadeCurve](./AudioFadeCurve.md 'UnrealEngine.Framework.AudioFadeCurve')  
Curve to adjust audio volume  
  
