### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[AudioComponent](AudioComponent.md 'UnrealEngine.Framework.AudioComponent')
## AudioComponent.FadeIn(float, float, float, AudioFadeCurve) Method
Smoothly starts the audio, can be used instead of [Play()](AudioComponent_Play().md 'UnrealEngine.Framework.AudioComponent.Play()')
```csharp
public void FadeIn(float duration, float volumeLevel=1f, float startTime=0f, UnrealEngine.Framework.AudioFadeCurve fadeCurve=UnrealEngine.Framework.AudioFadeCurve.Linear);
```
#### Parameters
<a name='UnrealEngine_Framework_AudioComponent_FadeIn(float_float_float_UnrealEngine_Framework_AudioFadeCurve)_duration'></a>
`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Duration to reach [volumeLevel](AudioComponent_FadeIn(float_float_float_AudioFadeCurve).md#UnrealEngine_Framework_AudioComponent_FadeIn(float_float_float_UnrealEngine_Framework_AudioFadeCurve)_volumeLevel 'UnrealEngine.Framework.AudioComponent.FadeIn(float, float, float, UnrealEngine.Framework.AudioFadeCurve).volumeLevel')
  
<a name='UnrealEngine_Framework_AudioComponent_FadeIn(float_float_float_UnrealEngine_Framework_AudioFadeCurve)_volumeLevel'></a>
`volumeLevel` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The percentage of calculated volume to fade to
  
<a name='UnrealEngine_Framework_AudioComponent_FadeIn(float_float_float_UnrealEngine_Framework_AudioFadeCurve)_startTime'></a>
`startTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Fading start time
  
<a name='UnrealEngine_Framework_AudioComponent_FadeIn(float_float_float_UnrealEngine_Framework_AudioFadeCurve)_fadeCurve'></a>
`fadeCurve` [AudioFadeCurve](AudioFadeCurve.md 'UnrealEngine.Framework.AudioFadeCurve')  
Curve to adjust audio volume
  
