### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[ObjectReference](./ObjectReference.md 'UnrealEngine.Framework.ObjectReference')
## ObjectReference.ToActor&lt;T&gt;() Method
Converts the object reference to the actor of the specified class  
```csharp
public T ToActor<T>()
    where T : UnrealEngine.Framework.Actor;
```
#### Type parameters
<a name='UnrealEngine-Framework-ObjectReference-ToActor-T-()-T'></a>
`T`  

Constraints [Actor](./Actor.md 'UnrealEngine.Framework.Actor')  
  
#### Returns
[T](#UnrealEngine-Framework-ObjectReference-ToActor-T-()-T 'UnrealEngine.Framework.ObjectReference.ToActor&lt;T&gt;().T')  
An actor or `null` on failure  
