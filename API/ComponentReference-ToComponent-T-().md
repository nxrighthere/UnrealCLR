### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[ComponentReference](./ComponentReference.md 'UnrealEngine.Framework.ComponentReference')
## ComponentReference.ToComponent&lt;T&gt;() Method
Converts the component reference to the component of the specified class  
```csharp
public T ToComponent<T>()
    where T : UnrealEngine.Framework.ActorComponent;
```
#### Type parameters
<a name='UnrealEngine-Framework-ComponentReference-ToComponent-T-()-T'></a>
`T`  

Constraints [ActorComponent](./ActorComponent.md 'UnrealEngine.Framework.ActorComponent')  
  
#### Returns
[T](#UnrealEngine-Framework-ComponentReference-ToComponent-T-()-T 'UnrealEngine.Framework.ComponentReference.ToComponent&lt;T&gt;().T')  
A component or `null` on failure  
