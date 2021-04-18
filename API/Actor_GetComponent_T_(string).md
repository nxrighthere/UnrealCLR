### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[Actor](Actor.md 'UnrealEngine.Framework.Actor')
## Actor.GetComponent&lt;T&gt;(string) Method
Returns the component of the actor if matches the specified type, optionally with the specified name  
```csharp
public T GetComponent<T>(string name=null)
    where T : UnrealEngine.Framework.ActorComponent;
```
#### Type parameters
<a name='UnrealEngine_Framework_Actor_GetComponent_T_(string)_T'></a>
`T`  
The type of the component
  
#### Parameters
<a name='UnrealEngine_Framework_Actor_GetComponent_T_(string)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the component
  
#### Returns
[T](Actor_GetComponent_T_(string).md#UnrealEngine_Framework_Actor_GetComponent_T_(string)_T 'UnrealEngine.Framework.Actor.GetComponent&lt;T&gt;(string).T')  
A component or `null` on failure
