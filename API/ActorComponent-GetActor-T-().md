### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[ActorComponent](./ActorComponent.md 'UnrealEngine.Framework.ActorComponent')
## ActorComponent.GetActor&lt;T&gt;() Method
Returns the component's owner actor of the specified class  
```csharp
public T GetActor<T>()
    where T : UnrealEngine.Framework.Actor;
```
#### Type parameters
<a name='UnrealEngine-Framework-ActorComponent-GetActor-T-()-T'></a>
`T`  

Constraints [Actor](./Actor.md 'UnrealEngine.Framework.Actor')  
  
#### Returns
[T](#UnrealEngine-Framework-ActorComponent-GetActor-T-()-T 'UnrealEngine.Framework.ActorComponent.GetActor&lt;T&gt;().T')  
An actor or `null` on failure  
