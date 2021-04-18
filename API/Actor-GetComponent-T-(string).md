### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Actor](./Actor.md 'UnrealEngine.Framework.Actor')
## Actor.GetComponent&lt;T&gt;(string) Method
Returns the component of the actor if matches the specified type, optionally with the specified name  
```csharp
public T GetComponent<T>(string name=null)
    where T : UnrealEngine.Framework.ActorComponent;
```
#### Type parameters
<a name='UnrealEngine-Framework-Actor-GetComponent-T-(string)-T'></a>
`T`  
The type of the component  

Constraints [ActorComponent](./ActorComponent.md 'UnrealEngine.Framework.ActorComponent')  
  
#### Parameters
<a name='UnrealEngine-Framework-Actor-GetComponent-T-(string)-name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the component  
  
#### Returns
[T](#UnrealEngine-Framework-Actor-GetComponent-T-(string)-T 'UnrealEngine.Framework.Actor.GetComponent&lt;T&gt;(string).T')  
A component or `null` on failure  
