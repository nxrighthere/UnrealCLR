### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[Actor](Actor.md 'UnrealEngine.Framework.Actor')
## Actor.GetComponentByTag&lt;T&gt;(string) Method
Returns the component of the actor if matches the specified type and tag  
```csharp
public T GetComponentByTag<T>(string tag)
    where T : UnrealEngine.Framework.ActorComponent;
```
#### Type parameters
<a name='UnrealEngine_Framework_Actor_GetComponentByTag_T_(string)_T'></a>
`T`  
The type of the component
  
#### Parameters
<a name='UnrealEngine_Framework_Actor_GetComponentByTag_T_(string)_tag'></a>
`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The tag of the component
  
#### Returns
[T](Actor_GetComponentByTag_T_(string).md#UnrealEngine_Framework_Actor_GetComponentByTag_T_(string)_T 'UnrealEngine.Framework.Actor.GetComponentByTag&lt;T&gt;(string).T')  
A component or `null` on failure
