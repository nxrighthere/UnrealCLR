### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## Actor Class
The base class of an object that can be placed or spawned in a level  
```csharp
public class Actor :
IEquatable<Actor>
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Actor  

Derived  
&#8627; [AmbientSound](./UnrealEngine-Framework-AmbientSound.md 'UnrealEngine.Framework.AmbientSound')  
&#8627; [Brush](./UnrealEngine-Framework-Brush.md 'UnrealEngine.Framework.Brush')  
&#8627; [Camera](./UnrealEngine-Framework-Camera.md 'UnrealEngine.Framework.Camera')  
&#8627; [Controller](./UnrealEngine-Framework-Controller.md 'UnrealEngine.Framework.Controller')  
&#8627; [Light](./UnrealEngine-Framework-Light.md 'UnrealEngine.Framework.Light')  
&#8627; [Pawn](./UnrealEngine-Framework-Pawn.md 'UnrealEngine.Framework.Pawn')  

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Actor](./UnrealEngine-Framework-Actor.md 'UnrealEngine.Framework.Actor')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Constructors
- [Actor(string, UnrealEngine.Framework.Blueprint)](./UnrealEngine-Framework-Actor-Actor(string_UnrealEngine-Framework-Blueprint).md 'UnrealEngine.Framework.Actor.Actor(string, UnrealEngine.Framework.Blueprint)')
### Properties
- [BlockInput](./UnrealEngine-Framework-Actor-BlockInput.md 'UnrealEngine.Framework.Actor.BlockInput')
- [InputComponent](./UnrealEngine-Framework-Actor-InputComponent.md 'UnrealEngine.Framework.Actor.InputComponent')
- [IsRootComponentMovable](./UnrealEngine-Framework-Actor-IsRootComponentMovable.md 'UnrealEngine.Framework.Actor.IsRootComponentMovable')
- [IsSpawned](./UnrealEngine-Framework-Actor-IsSpawned.md 'UnrealEngine.Framework.Actor.IsSpawned')
- [Name](./UnrealEngine-Framework-Actor-Name.md 'UnrealEngine.Framework.Actor.Name')
### Methods
- [AddTag(string)](./UnrealEngine-Framework-Actor-AddTag(string).md 'UnrealEngine.Framework.Actor.AddTag(string)')
- [AttachToActor(UnrealEngine.Framework.Actor, UnrealEngine.Framework.AttachmentTransformRule, string)](./UnrealEngine-Framework-Actor-AttachToActor(UnrealEngine-Framework-Actor_UnrealEngine-Framework-AttachmentTransformRule_string).md 'UnrealEngine.Framework.Actor.AttachToActor(UnrealEngine.Framework.Actor, UnrealEngine.Framework.AttachmentTransformRule, string)')
- [Destroy()](./UnrealEngine-Framework-Actor-Destroy().md 'UnrealEngine.Framework.Actor.Destroy()')
- [Equals(UnrealEngine.Framework.Actor)](./UnrealEngine-Framework-Actor-Equals(UnrealEngine-Framework-Actor).md 'UnrealEngine.Framework.Actor.Equals(UnrealEngine.Framework.Actor)')
- [GetBounds(bool, System.Numerics.Vector3, System.Numerics.Vector3)](./UnrealEngine-Framework-Actor-GetBounds(bool_System-Numerics-Vector3_System-Numerics-Vector3).md 'UnrealEngine.Framework.Actor.GetBounds(bool, System.Numerics.Vector3, System.Numerics.Vector3)')
- [GetComponent&lt;T&gt;(string)](./UnrealEngine-Framework-Actor-GetComponent-T-(string).md 'UnrealEngine.Framework.Actor.GetComponent&lt;T&gt;(string)')
- [GetDistanceTo(UnrealEngine.Framework.Actor)](./UnrealEngine-Framework-Actor-GetDistanceTo(UnrealEngine-Framework-Actor).md 'UnrealEngine.Framework.Actor.GetDistanceTo(UnrealEngine.Framework.Actor)')
- [GetHashCode()](./UnrealEngine-Framework-Actor-GetHashCode().md 'UnrealEngine.Framework.Actor.GetHashCode()')
- [GetRootComponent&lt;T&gt;()](./UnrealEngine-Framework-Actor-GetRootComponent-T-().md 'UnrealEngine.Framework.Actor.GetRootComponent&lt;T&gt;()')
- [HasTag(string)](./UnrealEngine-Framework-Actor-HasTag(string).md 'UnrealEngine.Framework.Actor.HasTag(string)')
- [Hide(bool)](./UnrealEngine-Framework-Actor-Hide(bool).md 'UnrealEngine.Framework.Actor.Hide(bool)')
- [IsOverlappingActor(UnrealEngine.Framework.Actor)](./UnrealEngine-Framework-Actor-IsOverlappingActor(UnrealEngine-Framework-Actor).md 'UnrealEngine.Framework.Actor.IsOverlappingActor(UnrealEngine.Framework.Actor)')
- [RemoveTag(string)](./UnrealEngine-Framework-Actor-RemoveTag(string).md 'UnrealEngine.Framework.Actor.RemoveTag(string)')
- [Rename(string)](./UnrealEngine-Framework-Actor-Rename(string).md 'UnrealEngine.Framework.Actor.Rename(string)')
- [SetEnableCollision(bool)](./UnrealEngine-Framework-Actor-SetEnableCollision(bool).md 'UnrealEngine.Framework.Actor.SetEnableCollision(bool)')
- [SetLifeSpan(float)](./UnrealEngine-Framework-Actor-SetLifeSpan(float).md 'UnrealEngine.Framework.Actor.SetLifeSpan(float)')
- [SetRootComponent(UnrealEngine.Framework.SceneComponent)](./UnrealEngine-Framework-Actor-SetRootComponent(UnrealEngine-Framework-SceneComponent).md 'UnrealEngine.Framework.Actor.SetRootComponent(UnrealEngine.Framework.SceneComponent)')
- [TeleportTo(System.Numerics.Vector3, System.Numerics.Quaternion, bool, bool)](./UnrealEngine-Framework-Actor-TeleportTo(System-Numerics-Vector3_System-Numerics-Quaternion_bool_bool).md 'UnrealEngine.Framework.Actor.TeleportTo(System.Numerics.Vector3, System.Numerics.Quaternion, bool, bool)')
