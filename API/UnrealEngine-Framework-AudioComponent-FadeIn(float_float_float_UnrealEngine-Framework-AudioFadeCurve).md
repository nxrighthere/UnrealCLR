### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[AudioComponent](./UnrealEngine-Framework-AudioComponent.md 'UnrealEngine.Framework.AudioComponent')
## AudioComponent.FadeIn(float, float, float, UnrealEngine.Framework.AudioFadeCurve) Method
Smoothly starts the audio, can be used instead of [Play()](./UnrealEngine-Framework-AudioComponent-Play().md 'UnrealEngine.Framework.AudioComponent.Play()')  
```csharp
public void FadeIn(float duration, float volumeLevel=1f, float startTime=0f, UnrealEngine.Framework.AudioFadeCurve fadeCurve=UnrealEngine.Framework.AudioFadeCurve.Linear);
```
#### Parameters
<a name='UnrealEngine-Framework-AudioComponent-FadeIn(float_float_float_UnrealEngine-Framework-AudioFadeCurve)-duration'></a>
`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Duration to reach [volumeLevel](#UnrealEngine-Framework-AudioComponent-FadeIn(float_float_float_UnrealEngine-Framework-AudioFadeCurve)-volumeLevel 'UnrealEngine.Framework.AudioComponent.FadeIn(float, float, float, UnrealEngine.Framework.AudioFadeCurve).volumeLevel')  
  
<a name='UnrealEngine-Framework-AudioComponent-FadeIn(float_float_float_UnrealEngine-Framework-AudioFadeCurve)-volumeLevel'></a>
`volumeLevel` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The percentage of calculated volume to fade to  
  
<a name='UnrealEngine-Framework-AudioComponent-FadeIn(float_float_float_UnrealEngine-Framework-AudioFadeCurve)-startTime'></a>
`startTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Fading start time  
  
<a name='UnrealEngine-Framework-AudioComponent-FadeIn(float_float_float_UnrealEngine-Framework-AudioFadeCurve)-fadeCurve'></a>
`fadeCurve` [AudioFadeCurve](./UnrealEngine-Framework-AudioFadeCurve.md 'UnrealEngine.Framework.AudioFadeCurve')  
Curve to adjust audio volume  
  
