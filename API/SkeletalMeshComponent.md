### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## SkeletalMeshComponent Class
A component that is used to create an instance of an animated [SkeletalMesh](SkeletalMesh.md 'UnrealEngine.Framework.SkeletalMesh') asset  
```csharp
public class SkeletalMeshComponent : UnrealEngine.Framework.SkinnedMeshComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; [PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent') &#129106; [MeshComponent](MeshComponent.md 'UnrealEngine.Framework.MeshComponent') &#129106; [SkinnedMeshComponent](SkinnedMeshComponent.md 'UnrealEngine.Framework.SkinnedMeshComponent') &#129106; SkeletalMeshComponent  
### Constructors

***
[SkeletalMeshComponent(Actor, string, bool, Blueprint)](SkeletalMeshComponent_SkeletalMeshComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.SkeletalMeshComponent.SkeletalMeshComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[IsPlaying](SkeletalMeshComponent_IsPlaying.md 'UnrealEngine.Framework.SkeletalMeshComponent.IsPlaying')

Returns `true` if playing animation  
### Methods

***
[GetAnimationInstance()](SkeletalMeshComponent_GetAnimationInstance().md 'UnrealEngine.Framework.SkeletalMeshComponent.GetAnimationInstance()')

Returns the animation instance that is driving the class or `null` on failure  

***
[Play(bool)](SkeletalMeshComponent_Play(bool).md 'UnrealEngine.Framework.SkeletalMeshComponent.Play(bool)')

Plays the animation  

***
[PlayAnimation(AnimationAsset, bool)](SkeletalMeshComponent_PlayAnimation(AnimationAsset_bool).md 'UnrealEngine.Framework.SkeletalMeshComponent.PlayAnimation(UnrealEngine.Framework.AnimationAsset, bool)')

Plays the animation asset  

***
[SetAnimation(AnimationAsset)](SkeletalMeshComponent_SetAnimation(AnimationAsset).md 'UnrealEngine.Framework.SkeletalMeshComponent.SetAnimation(UnrealEngine.Framework.AnimationAsset)')

Sets the animation to play  

***
[SetAnimationBlueprint(Blueprint)](SkeletalMeshComponent_SetAnimationBlueprint(Blueprint).md 'UnrealEngine.Framework.SkeletalMeshComponent.SetAnimationBlueprint(UnrealEngine.Framework.Blueprint)')

Sets the animation blueprint  

***
[SetAnimationMode(AnimationMode)](SkeletalMeshComponent_SetAnimationMode(AnimationMode).md 'UnrealEngine.Framework.SkeletalMeshComponent.SetAnimationMode(UnrealEngine.Framework.AnimationMode)')

Sets the animation mode  

***
[Stop()](SkeletalMeshComponent_Stop().md 'UnrealEngine.Framework.SkeletalMeshComponent.Stop()')

Stops the animation  
