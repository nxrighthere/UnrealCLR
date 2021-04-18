### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[Actor](Actor.md 'UnrealEngine.Framework.Actor')
## Actor.GetComponentByID&lt;T&gt;(uint) Method
Returns the component of the actor if matches the specified type and ID  
```csharp
public T GetComponentByID<T>(uint id)
    where T : UnrealEngine.Framework.ActorComponent;
```
#### Type parameters
<a name='UnrealEngine_Framework_Actor_GetComponentByID_T_(uint)_T'></a>
`T`  
The type of the component
  
#### Parameters
<a name='UnrealEngine_Framework_Actor_GetComponentByID_T_(uint)_id'></a>
`id` [System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/System.UInt32 'System.UInt32')  
The ID of the component
  
#### Returns
[T](Actor_GetComponentByID_T_(uint).md#UnrealEngine_Framework_Actor_GetComponentByID_T_(uint)_T 'UnrealEngine.Framework.Actor.GetComponentByID&lt;T&gt;(uint).T')  
A component or `null` on failure
