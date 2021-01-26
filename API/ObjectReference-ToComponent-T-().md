### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[ObjectReference](./ObjectReference.md 'UnrealEngine.Framework.ObjectReference')
## ObjectReference.ToComponent&lt;T&gt;() Method
Converts the object reference to the component of the specified class  
```csharp
public T ToComponent<T>()
    where T : UnrealEngine.Framework.ActorComponent;
```
#### Type parameters
<a name='UnrealEngine-Framework-ObjectReference-ToComponent-T-()-T'></a>
`T`  

Constraints [ActorComponent](./ActorComponent.md 'UnrealEngine.Framework.ActorComponent')  
  
#### Returns
[T](#UnrealEngine-Framework-ObjectReference-ToComponent-T-()-T 'UnrealEngine.Framework.ObjectReference.ToComponent&lt;T&gt;().T')  
A component or `null` on failure  
