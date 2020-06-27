### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## Actor Class
The base class of an object that can be placed or spawned in a level  
```csharp
public class Actor :
IObject,
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
&#8627; [TriggerBase](./UnrealEngine-Framework-TriggerBase.md 'UnrealEngine.Framework.TriggerBase')  

Implements [IObject](./UnrealEngine-Framework-IObject.md 'UnrealEngine.Framework.IObject'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Actor](./UnrealEngine-Framework-Actor.md 'UnrealEngine.Framework.Actor')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Constructors
- [Actor(string, UnrealEngine.Framework.Blueprint)](./UnrealEngine-Framework-Actor-Actor(string_UnrealEngine-Framework-Blueprint).md 'UnrealEngine.Framework.Actor.Actor(string, UnrealEngine.Framework.Blueprint)')
### Properties
- [BlockInput](./UnrealEngine-Framework-Actor-BlockInput.md 'UnrealEngine.Framework.Actor.BlockInput')
- [ID](./UnrealEngine-Framework-Actor-ID.md 'UnrealEngine.Framework.Actor.ID')
- [InputComponent](./UnrealEngine-Framework-Actor-InputComponent.md 'UnrealEngine.Framework.Actor.InputComponent')
- [IsRootComponentMovable](./UnrealEngine-Framework-Actor-IsRootComponentMovable.md 'UnrealEngine.Framework.Actor.IsRootComponentMovable')
- [IsSpawned](./UnrealEngine-Framework-Actor-IsSpawned.md 'UnrealEngine.Framework.Actor.IsSpawned')
- [Name](./UnrealEngine-Framework-Actor-Name.md 'UnrealEngine.Framework.Actor.Name')
### Methods
- [AddTag(string)](./UnrealEngine-Framework-Actor-AddTag(string).md 'UnrealEngine.Framework.Actor.AddTag(string)')
- [Destroy()](./UnrealEngine-Framework-Actor-Destroy().md 'UnrealEngine.Framework.Actor.Destroy()')
- [Equals(UnrealEngine.Framework.Actor)](./UnrealEngine-Framework-Actor-Equals(UnrealEngine-Framework-Actor).md 'UnrealEngine.Framework.Actor.Equals(UnrealEngine.Framework.Actor)')
- [GetBool(string, bool)](./UnrealEngine-Framework-Actor-GetBool(string_bool).md 'UnrealEngine.Framework.Actor.GetBool(string, bool)')
- [GetBounds(bool, System.Numerics.Vector3, System.Numerics.Vector3)](./UnrealEngine-Framework-Actor-GetBounds(bool_System-Numerics-Vector3_System-Numerics-Vector3).md 'UnrealEngine.Framework.Actor.GetBounds(bool, System.Numerics.Vector3, System.Numerics.Vector3)')
- [GetByte(string, byte)](./UnrealEngine-Framework-Actor-GetByte(string_byte).md 'UnrealEngine.Framework.Actor.GetByte(string, byte)')
- [GetComponent&lt;T&gt;(string)](./UnrealEngine-Framework-Actor-GetComponent-T-(string).md 'UnrealEngine.Framework.Actor.GetComponent&lt;T&gt;(string)')
- [GetComponentByTag&lt;T&gt;(string)](./UnrealEngine-Framework-Actor-GetComponentByTag-T-(string).md 'UnrealEngine.Framework.Actor.GetComponentByTag&lt;T&gt;(string)')
- [GetComponentByTag&lt;T&gt;(uint)](./UnrealEngine-Framework-Actor-GetComponentByTag-T-(uint).md 'UnrealEngine.Framework.Actor.GetComponentByTag&lt;T&gt;(uint)')
- [GetDistanceTo(UnrealEngine.Framework.Actor)](./UnrealEngine-Framework-Actor-GetDistanceTo(UnrealEngine-Framework-Actor).md 'UnrealEngine.Framework.Actor.GetDistanceTo(UnrealEngine.Framework.Actor)')
- [GetDouble(string, double)](./UnrealEngine-Framework-Actor-GetDouble(string_double).md 'UnrealEngine.Framework.Actor.GetDouble(string, double)')
- [GetFloat(string, float)](./UnrealEngine-Framework-Actor-GetFloat(string_float).md 'UnrealEngine.Framework.Actor.GetFloat(string, float)')
- [GetHashCode()](./UnrealEngine-Framework-Actor-GetHashCode().md 'UnrealEngine.Framework.Actor.GetHashCode()')
- [GetInt(string, int)](./UnrealEngine-Framework-Actor-GetInt(string_int).md 'UnrealEngine.Framework.Actor.GetInt(string, int)')
- [GetLong(string, long)](./UnrealEngine-Framework-Actor-GetLong(string_long).md 'UnrealEngine.Framework.Actor.GetLong(string, long)')
- [GetRootComponent&lt;T&gt;()](./UnrealEngine-Framework-Actor-GetRootComponent-T-().md 'UnrealEngine.Framework.Actor.GetRootComponent&lt;T&gt;()')
- [GetShort(string, short)](./UnrealEngine-Framework-Actor-GetShort(string_short).md 'UnrealEngine.Framework.Actor.GetShort(string, short)')
- [GetText(string, string)](./UnrealEngine-Framework-Actor-GetText(string_string).md 'UnrealEngine.Framework.Actor.GetText(string, string)')
- [GetUInt(string, uint)](./UnrealEngine-Framework-Actor-GetUInt(string_uint).md 'UnrealEngine.Framework.Actor.GetUInt(string, uint)')
- [GetULong(string, ulong)](./UnrealEngine-Framework-Actor-GetULong(string_ulong).md 'UnrealEngine.Framework.Actor.GetULong(string, ulong)')
- [GetUShort(string, ushort)](./UnrealEngine-Framework-Actor-GetUShort(string_ushort).md 'UnrealEngine.Framework.Actor.GetUShort(string, ushort)')
- [HasTag(string)](./UnrealEngine-Framework-Actor-HasTag(string).md 'UnrealEngine.Framework.Actor.HasTag(string)')
- [Hide(bool)](./UnrealEngine-Framework-Actor-Hide(bool).md 'UnrealEngine.Framework.Actor.Hide(bool)')
- [IsOverlappingActor(UnrealEngine.Framework.Actor)](./UnrealEngine-Framework-Actor-IsOverlappingActor(UnrealEngine-Framework-Actor).md 'UnrealEngine.Framework.Actor.IsOverlappingActor(UnrealEngine.Framework.Actor)')
- [RemoveTag(string)](./UnrealEngine-Framework-Actor-RemoveTag(string).md 'UnrealEngine.Framework.Actor.RemoveTag(string)')
- [Rename(string)](./UnrealEngine-Framework-Actor-Rename(string).md 'UnrealEngine.Framework.Actor.Rename(string)')
- [SetBool(string, bool)](./UnrealEngine-Framework-Actor-SetBool(string_bool).md 'UnrealEngine.Framework.Actor.SetBool(string, bool)')
- [SetByte(string, byte)](./UnrealEngine-Framework-Actor-SetByte(string_byte).md 'UnrealEngine.Framework.Actor.SetByte(string, byte)')
- [SetDouble(string, double)](./UnrealEngine-Framework-Actor-SetDouble(string_double).md 'UnrealEngine.Framework.Actor.SetDouble(string, double)')
- [SetEnableCollision(bool)](./UnrealEngine-Framework-Actor-SetEnableCollision(bool).md 'UnrealEngine.Framework.Actor.SetEnableCollision(bool)')
- [SetFloat(string, float)](./UnrealEngine-Framework-Actor-SetFloat(string_float).md 'UnrealEngine.Framework.Actor.SetFloat(string, float)')
- [SetInt(string, int)](./UnrealEngine-Framework-Actor-SetInt(string_int).md 'UnrealEngine.Framework.Actor.SetInt(string, int)')
- [SetLifeSpan(float)](./UnrealEngine-Framework-Actor-SetLifeSpan(float).md 'UnrealEngine.Framework.Actor.SetLifeSpan(float)')
- [SetLong(string, long)](./UnrealEngine-Framework-Actor-SetLong(string_long).md 'UnrealEngine.Framework.Actor.SetLong(string, long)')
- [SetRootComponent(UnrealEngine.Framework.SceneComponent)](./UnrealEngine-Framework-Actor-SetRootComponent(UnrealEngine-Framework-SceneComponent).md 'UnrealEngine.Framework.Actor.SetRootComponent(UnrealEngine.Framework.SceneComponent)')
- [SetShort(string, short)](./UnrealEngine-Framework-Actor-SetShort(string_short).md 'UnrealEngine.Framework.Actor.SetShort(string, short)')
- [SetText(string, string)](./UnrealEngine-Framework-Actor-SetText(string_string).md 'UnrealEngine.Framework.Actor.SetText(string, string)')
- [SetUInt(string, uint)](./UnrealEngine-Framework-Actor-SetUInt(string_uint).md 'UnrealEngine.Framework.Actor.SetUInt(string, uint)')
- [SetULong(string, ulong)](./UnrealEngine-Framework-Actor-SetULong(string_ulong).md 'UnrealEngine.Framework.Actor.SetULong(string, ulong)')
- [SetUShort(string, ushort)](./UnrealEngine-Framework-Actor-SetUShort(string_ushort).md 'UnrealEngine.Framework.Actor.SetUShort(string, ushort)')
- [TeleportTo(System.Numerics.Vector3, System.Numerics.Quaternion, bool, bool)](./UnrealEngine-Framework-Actor-TeleportTo(System-Numerics-Vector3_System-Numerics-Quaternion_bool_bool).md 'UnrealEngine.Framework.Actor.TeleportTo(System.Numerics.Vector3, System.Numerics.Quaternion, bool, bool)')
