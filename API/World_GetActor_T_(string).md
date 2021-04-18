### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[World](World.md 'UnrealEngine.Framework.World')
## World.GetActor&lt;T&gt;(string) Method
Returns the first actor in the world of the specified class, optionally with the specified name, this operation is slow and should be used with caution  
```csharp
public static T GetActor<T>(string name=null)
    where T : UnrealEngine.Framework.Actor;
```
#### Type parameters
<a name='UnrealEngine_Framework_World_GetActor_T_(string)_T'></a>
`T`  
The type of the actor
  
#### Parameters
<a name='UnrealEngine_Framework_World_GetActor_T_(string)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the actor, may differ from the label in the editor
  
#### Returns
[T](World_GetActor_T_(string).md#UnrealEngine_Framework_World_GetActor_T_(string)_T 'UnrealEngine.Framework.World.GetActor&lt;T&gt;(string).T')  
An actor or `null` on failure
