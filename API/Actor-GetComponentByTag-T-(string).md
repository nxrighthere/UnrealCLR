### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Actor](./Actor.md 'UnrealEngine.Framework.Actor')
## Actor.GetComponentByTag&lt;T&gt;(string) Method
Returns the component of the actor if matches the specified type and tag  
```csharp
public T GetComponentByTag<T>(string tag)
    where T : UnrealEngine.Framework.ActorComponent;
```
#### Type parameters
<a name='UnrealEngine-Framework-Actor-GetComponentByTag-T-(string)-T'></a>
`T`  
The type of the component  

Constraints [ActorComponent](./ActorComponent.md 'UnrealEngine.Framework.ActorComponent')  
  
#### Parameters
<a name='UnrealEngine-Framework-Actor-GetComponentByTag-T-(string)-tag'></a>
`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The tag of the component  
  
#### Returns
[T](#UnrealEngine-Framework-Actor-GetComponentByTag-T-(string)-T 'UnrealEngine.Framework.Actor.GetComponentByTag&lt;T&gt;(string).T')  
A component or `null` on failure  
