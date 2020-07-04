### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## World Class
The top level representation of a map or a sandbox in which actors and components will exist and be rendered  
```csharp
public static class World
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; World  
### Properties
- [ActorCount](./World-ActorCount.md 'UnrealEngine.Framework.World.ActorCount')
- [DeltaTime](./World-DeltaTime.md 'UnrealEngine.Framework.World.DeltaTime')
- [RealTime](./World-RealTime.md 'UnrealEngine.Framework.World.RealTime')
- [SimulatePhysics](./World-SimulatePhysics.md 'UnrealEngine.Framework.World.SimulatePhysics')
- [Time](./World-Time.md 'UnrealEngine.Framework.World.Time')
### Methods
- [GetActor&lt;T&gt;(string)](./World-GetActor-T-(string).md 'UnrealEngine.Framework.World.GetActor&lt;T&gt;(string)')
- [GetActorByID&lt;T&gt;(uint)](./World-GetActorByID-T-(uint).md 'UnrealEngine.Framework.World.GetActorByID&lt;T&gt;(uint)')
- [GetActorByTag&lt;T&gt;(string)](./World-GetActorByTag-T-(string).md 'UnrealEngine.Framework.World.GetActorByTag&lt;T&gt;(string)')
- [GetFirstPlayerController()](./World-GetFirstPlayerController().md 'UnrealEngine.Framework.World.GetFirstPlayerController()')
- [GetWorldOrigin(System.Numerics.Vector3)](./World-GetWorldOrigin(Vector3).md 'UnrealEngine.Framework.World.GetWorldOrigin(System.Numerics.Vector3)')
- [LineTraceSingleByChannel(System.Numerics.Vector3, System.Numerics.Vector3, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.Hit, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)](./World-LineTraceSingleByChannel(Vector3_Vector3_CollisionChannel_Hit_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceSingleByChannel(System.Numerics.Vector3, System.Numerics.Vector3, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.Hit, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')
- [LineTraceSingleByChannel(System.Numerics.Vector3, System.Numerics.Vector3, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.Hit, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)](./World-LineTraceSingleByChannel(Vector3_Vector3_CollisionChannel_Hit_string_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceSingleByChannel(System.Numerics.Vector3, System.Numerics.Vector3, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.Hit, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')
- [LineTraceSingleByProfile(System.Numerics.Vector3, System.Numerics.Vector3, string, UnrealEngine.Framework.Hit, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)](./World-LineTraceSingleByProfile(Vector3_Vector3_string_Hit_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceSingleByProfile(System.Numerics.Vector3, System.Numerics.Vector3, string, UnrealEngine.Framework.Hit, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')
- [LineTraceSingleByProfile(System.Numerics.Vector3, System.Numerics.Vector3, string, UnrealEngine.Framework.Hit, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)](./World-LineTraceSingleByProfile(Vector3_Vector3_string_Hit_string_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceSingleByProfile(System.Numerics.Vector3, System.Numerics.Vector3, string, UnrealEngine.Framework.Hit, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')
- [LineTraceTestByChannel(System.Numerics.Vector3, System.Numerics.Vector3, UnrealEngine.Framework.CollisionChannel, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)](./World-LineTraceTestByChannel(Vector3_Vector3_CollisionChannel_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceTestByChannel(System.Numerics.Vector3, System.Numerics.Vector3, UnrealEngine.Framework.CollisionChannel, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')
- [LineTraceTestByProfile(System.Numerics.Vector3, System.Numerics.Vector3, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)](./World-LineTraceTestByProfile(Vector3_Vector3_string_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceTestByProfile(System.Numerics.Vector3, System.Numerics.Vector3, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')
- [SetGravity(float)](./World-SetGravity(float).md 'UnrealEngine.Framework.World.SetGravity(float)')
- [SetWorldOrigin(System.Numerics.Vector3)](./World-SetWorldOrigin(Vector3).md 'UnrealEngine.Framework.World.SetWorldOrigin(System.Numerics.Vector3)')
