### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## AudioComponent Class
A component that is used to play a sound  
```csharp
public class AudioComponent : UnrealEngine.Framework.SceneComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; AudioComponent  
### Constructors

***
[AudioComponent(Actor, string, bool, Blueprint)](AudioComponent_AudioComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.AudioComponent.AudioComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[IsPlaying](AudioComponent_IsPlaying.md 'UnrealEngine.Framework.AudioComponent.IsPlaying')

Returns `true` if the sound playing any audio  

***
[Paused](AudioComponent_Paused.md 'UnrealEngine.Framework.AudioComponent.Paused')

Gets or sets whether the audio is paused  
### Methods

***
[FadeIn(float, float, float, AudioFadeCurve)](AudioComponent_FadeIn(float_float_float_AudioFadeCurve).md 'UnrealEngine.Framework.AudioComponent.FadeIn(float, float, float, UnrealEngine.Framework.AudioFadeCurve)')

Smoothly starts the audio, can be used instead of [Play()](AudioComponent_Play().md 'UnrealEngine.Framework.AudioComponent.Play()')

***
[FadeOut(float, float, AudioFadeCurve)](AudioComponent_FadeOut(float_float_AudioFadeCurve).md 'UnrealEngine.Framework.AudioComponent.FadeOut(float, float, UnrealEngine.Framework.AudioFadeCurve)')

Smoothly stops the audio, can be used instead of [Stop()](AudioComponent_Stop().md 'UnrealEngine.Framework.AudioComponent.Stop()')

***
[Play()](AudioComponent_Play().md 'UnrealEngine.Framework.AudioComponent.Play()')

Plays the audio  

***
[SetSound(SoundBase)](AudioComponent_SetSound(SoundBase).md 'UnrealEngine.Framework.AudioComponent.SetSound(UnrealEngine.Framework.SoundBase)')

Sets the sound object  

***
[Stop()](AudioComponent_Stop().md 'UnrealEngine.Framework.AudioComponent.Stop()')

Stops the audio  
