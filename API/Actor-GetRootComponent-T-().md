### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Actor](./Actor.md 'UnrealEngine.Framework.Actor')
## Actor.GetRootComponent&lt;T&gt;() Method
Returns the root component of the actor if matches the specified type  
```csharp
public T GetRootComponent<T>()
    where T : UnrealEngine.Framework.SceneComponent;
```
#### Type parameters
<a name='UnrealEngine-Framework-Actor-GetRootComponent-T-()-T'></a>
`T`  

Constraints [SceneComponent](./SceneComponent.md 'UnrealEngine.Framework.SceneComponent')  
  
#### Returns
[T](#UnrealEngine-Framework-Actor-GetRootComponent-T-()-T 'UnrealEngine.Framework.Actor.GetRootComponent&lt;T&gt;().T')  
A component or `null` on failure  
