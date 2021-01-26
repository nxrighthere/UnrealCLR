### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[World](./World.md 'UnrealEngine.Framework.World')
## World.GetActorByTag&lt;T&gt;(string) Method
Returns the first actor in the world of the specified class and tag, this operation is slow and should be used with caution  
```csharp
public static T GetActorByTag<T>(string tag)
    where T : UnrealEngine.Framework.Actor;
```
#### Type parameters
<a name='UnrealEngine-Framework-World-GetActorByTag-T-(string)-T'></a>
`T`  
The type of the actor  

Constraints [Actor](./Actor.md 'UnrealEngine.Framework.Actor')  
  
#### Parameters
<a name='UnrealEngine-Framework-World-GetActorByTag-T-(string)-tag'></a>
`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The tag of the actor  
  
#### Returns
[T](#UnrealEngine-Framework-World-GetActorByTag-T-(string)-T 'UnrealEngine.Framework.World.GetActorByTag&lt;T&gt;(string).T')  
An actor or `null` on failure  
