### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[AudioComponent](AudioComponent.md 'UnrealEngine.Framework.AudioComponent')
## AudioComponent.FadeOut(float, float, AudioFadeCurve) Method
Smoothly stops the audio, can be used instead of [Stop()](AudioComponent_Stop().md 'UnrealEngine.Framework.AudioComponent.Stop()')
```csharp
public void FadeOut(float duration, float volumeLevel=0f, UnrealEngine.Framework.AudioFadeCurve fadeCurve=UnrealEngine.Framework.AudioFadeCurve.Linear);
```
#### Parameters
<a name='UnrealEngine_Framework_AudioComponent_FadeOut(float_float_UnrealEngine_Framework_AudioFadeCurve)_duration'></a>
`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Duration to reach [volumeLevel](AudioComponent_FadeOut(float_float_AudioFadeCurve).md#UnrealEngine_Framework_AudioComponent_FadeOut(float_float_UnrealEngine_Framework_AudioFadeCurve)_volumeLevel 'UnrealEngine.Framework.AudioComponent.FadeOut(float, float, UnrealEngine.Framework.AudioFadeCurve).volumeLevel')
  
<a name='UnrealEngine_Framework_AudioComponent_FadeOut(float_float_UnrealEngine_Framework_AudioFadeCurve)_volumeLevel'></a>
`volumeLevel` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
he percentage of calculated volume to fade to
  
<a name='UnrealEngine_Framework_AudioComponent_FadeOut(float_float_UnrealEngine_Framework_AudioFadeCurve)_fadeCurve'></a>
`fadeCurve` [AudioFadeCurve](AudioFadeCurve.md 'UnrealEngine.Framework.AudioFadeCurve')  
Curve to adjust audio volume
  
