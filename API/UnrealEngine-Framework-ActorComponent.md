### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## ActorComponent Class
The base class of components that define reusable behavior and can be added to different types of actors  
```csharp
public class ActorComponent :
IObject,
IEquatable<ActorComponent>
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ActorComponent  

Derived  
&#8627; [InputComponent](./UnrealEngine-Framework-InputComponent.md 'UnrealEngine.Framework.InputComponent')  
&#8627; [SceneComponent](./UnrealEngine-Framework-SceneComponent.md 'UnrealEngine.Framework.SceneComponent')  

Implements [IObject](./UnrealEngine-Framework-IObject.md 'UnrealEngine.Framework.IObject'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ActorComponent](./UnrealEngine-Framework-ActorComponent.md 'UnrealEngine.Framework.ActorComponent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Properties
- [ID](./UnrealEngine-Framework-ActorComponent-ID.md 'UnrealEngine.Framework.ActorComponent.ID')
- [IsCreated](./UnrealEngine-Framework-ActorComponent-IsCreated.md 'UnrealEngine.Framework.ActorComponent.IsCreated')
- [IsOwnerSelected](./UnrealEngine-Framework-ActorComponent-IsOwnerSelected.md 'UnrealEngine.Framework.ActorComponent.IsOwnerSelected')
- [Name](./UnrealEngine-Framework-ActorComponent-Name.md 'UnrealEngine.Framework.ActorComponent.Name')
### Methods
- [AddTag(string)](./UnrealEngine-Framework-ActorComponent-AddTag(string).md 'UnrealEngine.Framework.ActorComponent.AddTag(string)')
- [Destroy(bool)](./UnrealEngine-Framework-ActorComponent-Destroy(bool).md 'UnrealEngine.Framework.ActorComponent.Destroy(bool)')
- [Equals(UnrealEngine.Framework.ActorComponent)](./UnrealEngine-Framework-ActorComponent-Equals(UnrealEngine-Framework-ActorComponent).md 'UnrealEngine.Framework.ActorComponent.Equals(UnrealEngine.Framework.ActorComponent)')
- [GetActor()](./UnrealEngine-Framework-ActorComponent-GetActor().md 'UnrealEngine.Framework.ActorComponent.GetActor()')
- [GetBool(string, bool)](./UnrealEngine-Framework-ActorComponent-GetBool(string_bool).md 'UnrealEngine.Framework.ActorComponent.GetBool(string, bool)')
- [GetByte(string, byte)](./UnrealEngine-Framework-ActorComponent-GetByte(string_byte).md 'UnrealEngine.Framework.ActorComponent.GetByte(string, byte)')
- [GetDouble(string, double)](./UnrealEngine-Framework-ActorComponent-GetDouble(string_double).md 'UnrealEngine.Framework.ActorComponent.GetDouble(string, double)')
- [GetFloat(string, float)](./UnrealEngine-Framework-ActorComponent-GetFloat(string_float).md 'UnrealEngine.Framework.ActorComponent.GetFloat(string, float)')
- [GetHashCode()](./UnrealEngine-Framework-ActorComponent-GetHashCode().md 'UnrealEngine.Framework.ActorComponent.GetHashCode()')
- [GetInt(string, int)](./UnrealEngine-Framework-ActorComponent-GetInt(string_int).md 'UnrealEngine.Framework.ActorComponent.GetInt(string, int)')
- [GetLong(string, long)](./UnrealEngine-Framework-ActorComponent-GetLong(string_long).md 'UnrealEngine.Framework.ActorComponent.GetLong(string, long)')
- [GetShort(string, short)](./UnrealEngine-Framework-ActorComponent-GetShort(string_short).md 'UnrealEngine.Framework.ActorComponent.GetShort(string, short)')
- [GetText(string, string)](./UnrealEngine-Framework-ActorComponent-GetText(string_string).md 'UnrealEngine.Framework.ActorComponent.GetText(string, string)')
- [GetUInt(string, uint)](./UnrealEngine-Framework-ActorComponent-GetUInt(string_uint).md 'UnrealEngine.Framework.ActorComponent.GetUInt(string, uint)')
- [GetULong(string, ulong)](./UnrealEngine-Framework-ActorComponent-GetULong(string_ulong).md 'UnrealEngine.Framework.ActorComponent.GetULong(string, ulong)')
- [GetUShort(string, ushort)](./UnrealEngine-Framework-ActorComponent-GetUShort(string_ushort).md 'UnrealEngine.Framework.ActorComponent.GetUShort(string, ushort)')
- [HasTag(string)](./UnrealEngine-Framework-ActorComponent-HasTag(string).md 'UnrealEngine.Framework.ActorComponent.HasTag(string)')
- [RemoveTag(string)](./UnrealEngine-Framework-ActorComponent-RemoveTag(string).md 'UnrealEngine.Framework.ActorComponent.RemoveTag(string)')
- [Rename(string)](./UnrealEngine-Framework-ActorComponent-Rename(string).md 'UnrealEngine.Framework.ActorComponent.Rename(string)')
- [SetBool(string, bool)](./UnrealEngine-Framework-ActorComponent-SetBool(string_bool).md 'UnrealEngine.Framework.ActorComponent.SetBool(string, bool)')
- [SetByte(string, byte)](./UnrealEngine-Framework-ActorComponent-SetByte(string_byte).md 'UnrealEngine.Framework.ActorComponent.SetByte(string, byte)')
- [SetDouble(string, double)](./UnrealEngine-Framework-ActorComponent-SetDouble(string_double).md 'UnrealEngine.Framework.ActorComponent.SetDouble(string, double)')
- [SetFloat(string, float)](./UnrealEngine-Framework-ActorComponent-SetFloat(string_float).md 'UnrealEngine.Framework.ActorComponent.SetFloat(string, float)')
- [SetInt(string, int)](./UnrealEngine-Framework-ActorComponent-SetInt(string_int).md 'UnrealEngine.Framework.ActorComponent.SetInt(string, int)')
- [SetLong(string, long)](./UnrealEngine-Framework-ActorComponent-SetLong(string_long).md 'UnrealEngine.Framework.ActorComponent.SetLong(string, long)')
- [SetShort(string, short)](./UnrealEngine-Framework-ActorComponent-SetShort(string_short).md 'UnrealEngine.Framework.ActorComponent.SetShort(string, short)')
- [SetText(string, string)](./UnrealEngine-Framework-ActorComponent-SetText(string_string).md 'UnrealEngine.Framework.ActorComponent.SetText(string, string)')
- [SetUInt(string, uint)](./UnrealEngine-Framework-ActorComponent-SetUInt(string_uint).md 'UnrealEngine.Framework.ActorComponent.SetUInt(string, uint)')
- [SetULong(string, ulong)](./UnrealEngine-Framework-ActorComponent-SetULong(string_ulong).md 'UnrealEngine.Framework.ActorComponent.SetULong(string, ulong)')
- [SetUShort(string, ushort)](./UnrealEngine-Framework-ActorComponent-SetUShort(string_ushort).md 'UnrealEngine.Framework.ActorComponent.SetUShort(string, ushort)')
