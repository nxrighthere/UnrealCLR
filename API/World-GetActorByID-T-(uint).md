### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[World](./World.md 'UnrealEngine.Framework.World')
## World.GetActorByID&lt;T&gt;(uint) Method
Returns the first actor in the world of the specified class and ID, this operation is slow and should be used with caution  
```csharp
public static T GetActorByID<T>(uint id)
    where T : UnrealEngine.Framework.Actor;
```
#### Type parameters
<a name='UnrealEngine-Framework-World-GetActorByID-T-(uint)-T'></a>
`T`  
The type of the actor  

Constraints [Actor](./Actor.md 'UnrealEngine.Framework.Actor')  
  
#### Parameters
<a name='UnrealEngine-Framework-World-GetActorByID-T-(uint)-id'></a>
`id` [System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/System.UInt32 'System.UInt32')  
The ID of the actor  
  
#### Returns
[T](#UnrealEngine-Framework-World-GetActorByID-T-(uint)-T 'UnrealEngine.Framework.World.GetActorByID&lt;T&gt;(uint).T')  
An actor or `null` on failure  
