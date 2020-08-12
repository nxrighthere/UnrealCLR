### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[World](./World.md 'UnrealEngine.Framework.World')
## World.SetOnActorHitCallback(UnrealEngine.Framework.ActorHitDelegate) Method
Sets the static callback function that is called when actors hit collisions  
```csharp
public static void SetOnActorHitCallback(UnrealEngine.Framework.ActorHitDelegate callback);
```
#### Parameters
<a name='UnrealEngine-Framework-World-SetOnActorHitCallback(UnrealEngine-Framework-ActorHitDelegate)-callback'></a>
`callback` [ActorHitDelegate(UnrealEngine.Framework.ObjectReference, UnrealEngine.Framework.ObjectReference, System.Numerics.Vector3, UnrealEngine.Framework.Hit)](./ActorHitDelegate(ObjectReference_ObjectReference_Vector3_Hit).md 'UnrealEngine.Framework.ActorHitDelegate(UnrealEngine.Framework.ObjectReference, UnrealEngine.Framework.ObjectReference, System.Numerics.Vector3, UnrealEngine.Framework.Hit)')  
The static function to call when an actor hit another one  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown if [callback](#UnrealEngine-Framework-World-SetOnActorHitCallback(UnrealEngine-Framework-ActorHitDelegate)-callback 'UnrealEngine.Framework.World.SetOnActorHitCallback(UnrealEngine.Framework.ActorHitDelegate).callback') is not static  
