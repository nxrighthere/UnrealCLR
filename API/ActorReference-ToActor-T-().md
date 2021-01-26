### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[ActorReference](./ActorReference.md 'UnrealEngine.Framework.ActorReference')
## ActorReference.ToActor&lt;T&gt;() Method
Converts the actor reference to the actor of the specified class  
```csharp
public T ToActor<T>()
    where T : UnrealEngine.Framework.Actor;
```
#### Type parameters
<a name='UnrealEngine-Framework-ActorReference-ToActor-T-()-T'></a>
`T`  

Constraints [Actor](./Actor.md 'UnrealEngine.Framework.Actor')  
  
#### Returns
[T](#UnrealEngine-Framework-ActorReference-ToActor-T-()-T 'UnrealEngine.Framework.ActorReference.ToActor&lt;T&gt;().T')  
An actor or `null` on failure  
