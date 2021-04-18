### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## ActorComponent Class
The base class of components that define reusable behavior and can be added to different types of actors  
```csharp
public abstract class ActorComponent :
System.IEquatable<UnrealEngine.Framework.ActorComponent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ActorComponent  

Derived  
&#8627; [InputComponent](InputComponent.md 'UnrealEngine.Framework.InputComponent')
&#8627; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent')  

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Properties

***
[ID](ActorComponent_ID.md 'UnrealEngine.Framework.ActorComponent.ID')

Returns the unique ID of the component, reused by the engine, only unique while the component is alive  

***
[IsCreated](ActorComponent_IsCreated.md 'UnrealEngine.Framework.ActorComponent.IsCreated')

Returns `true` if the object is created  

***
[IsOwnerSelected](ActorComponent_IsOwnerSelected.md 'UnrealEngine.Framework.ActorComponent.IsOwnerSelected')

Returns `true` if the component's owner is selected in the editor  

***
[Name](ActorComponent_Name.md 'UnrealEngine.Framework.ActorComponent.Name')

Returns the name of the component  
### Methods

***
[AddTag(string)](ActorComponent_AddTag(string).md 'UnrealEngine.Framework.ActorComponent.AddTag(string)')

Adds a tag to the component that can be used for grouping and categorizing  

***
[Destroy(bool)](ActorComponent_Destroy(bool).md 'UnrealEngine.Framework.ActorComponent.Destroy(bool)')

Unregisters the component, removes it from its outer actor's components array and marks for pending kill  

***
[Equals(ActorComponent)](ActorComponent_Equals(ActorComponent).md 'UnrealEngine.Framework.ActorComponent.Equals(UnrealEngine.Framework.ActorComponent)')

Indicates equality of objects  

***
[GetActor&lt;T&gt;()](ActorComponent_GetActor_T_().md 'UnrealEngine.Framework.ActorComponent.GetActor&lt;T&gt;()')

Returns the component's owner actor of the specified class  

***
[GetBool(string, bool)](ActorComponent_GetBool(string_bool).md 'UnrealEngine.Framework.ActorComponent.GetBool(string, bool)')

Retrieves the value of the bool property  

***
[GetByte(string, byte)](ActorComponent_GetByte(string_byte).md 'UnrealEngine.Framework.ActorComponent.GetByte(string, byte)')

Retrieves the value of the byte property  

***
[GetDouble(string, double)](ActorComponent_GetDouble(string_double).md 'UnrealEngine.Framework.ActorComponent.GetDouble(string, double)')

Retrieves the value of the double property  

***
[GetEnum&lt;T&gt;(string, T)](ActorComponent_GetEnum_T_(string_T).md 'UnrealEngine.Framework.ActorComponent.GetEnum&lt;T&gt;(string, T)')

Retrieves the value of the enum property  

***
[GetFloat(string, float)](ActorComponent_GetFloat(string_float).md 'UnrealEngine.Framework.ActorComponent.GetFloat(string, float)')

Retrieves the value of the float property  

***
[GetHashCode()](ActorComponent_GetHashCode().md 'UnrealEngine.Framework.ActorComponent.GetHashCode()')

Returns a hash code for the object  

***
[GetInt(string, int)](ActorComponent_GetInt(string_int).md 'UnrealEngine.Framework.ActorComponent.GetInt(string, int)')

Retrieves the value of the integer property  

***
[GetLong(string, long)](ActorComponent_GetLong(string_long).md 'UnrealEngine.Framework.ActorComponent.GetLong(string, long)')

Retrieves the value of the long property  

***
[GetShort(string, short)](ActorComponent_GetShort(string_short).md 'UnrealEngine.Framework.ActorComponent.GetShort(string, short)')

Retrieves the value of the short property  

***
[GetText(string, string)](ActorComponent_GetText(string_string).md 'UnrealEngine.Framework.ActorComponent.GetText(string, string)')

Retrieves the value of the text property  

***
[GetUInt(string, uint)](ActorComponent_GetUInt(string_uint).md 'UnrealEngine.Framework.ActorComponent.GetUInt(string, uint)')

Retrieves the value of the unsigned integer property  

***
[GetULong(string, ulong)](ActorComponent_GetULong(string_ulong).md 'UnrealEngine.Framework.ActorComponent.GetULong(string, ulong)')

Retrieves the value of the unsigned long property  

***
[GetUShort(string, ushort)](ActorComponent_GetUShort(string_ushort).md 'UnrealEngine.Framework.ActorComponent.GetUShort(string, ushort)')

Retrieves the value of the unsigned short property  

***
[HasTag(string)](ActorComponent_HasTag(string).md 'UnrealEngine.Framework.ActorComponent.HasTag(string)')

Indicates whether the component has a tag  

***
[Invoke(string)](ActorComponent_Invoke(string).md 'UnrealEngine.Framework.ActorComponent.Invoke(string)')

Invokes a command, function, or an event with optional arguments  

***
[RemoveTag(string)](ActorComponent_RemoveTag(string).md 'UnrealEngine.Framework.ActorComponent.RemoveTag(string)')

Removes a tag from the component  

***
[Rename(string)](ActorComponent_Rename(string).md 'UnrealEngine.Framework.ActorComponent.Rename(string)')

Renames the component  

***
[SetBool(string, bool)](ActorComponent_SetBool(string_bool).md 'UnrealEngine.Framework.ActorComponent.SetBool(string, bool)')

Sets the value of the bool property  

***
[SetByte(string, byte)](ActorComponent_SetByte(string_byte).md 'UnrealEngine.Framework.ActorComponent.SetByte(string, byte)')

Sets the value of the byte property  

***
[SetDouble(string, double)](ActorComponent_SetDouble(string_double).md 'UnrealEngine.Framework.ActorComponent.SetDouble(string, double)')

Sets the value of the double property  

***
[SetEnum&lt;T&gt;(string, T)](ActorComponent_SetEnum_T_(string_T).md 'UnrealEngine.Framework.ActorComponent.SetEnum&lt;T&gt;(string, T)')

Sets the value of the enum property  

***
[SetFloat(string, float)](ActorComponent_SetFloat(string_float).md 'UnrealEngine.Framework.ActorComponent.SetFloat(string, float)')

Sets the value of the float property  

***
[SetInt(string, int)](ActorComponent_SetInt(string_int).md 'UnrealEngine.Framework.ActorComponent.SetInt(string, int)')

Sets the value of the integer property  

***
[SetLong(string, long)](ActorComponent_SetLong(string_long).md 'UnrealEngine.Framework.ActorComponent.SetLong(string, long)')

Sets the value of the long property  

***
[SetShort(string, short)](ActorComponent_SetShort(string_short).md 'UnrealEngine.Framework.ActorComponent.SetShort(string, short)')

Sets the value of the short property  

***
[SetText(string, string)](ActorComponent_SetText(string_string).md 'UnrealEngine.Framework.ActorComponent.SetText(string, string)')

Sets the value of the text property  

***
[SetUInt(string, uint)](ActorComponent_SetUInt(string_uint).md 'UnrealEngine.Framework.ActorComponent.SetUInt(string, uint)')

Sets the value of the unsigned integer property  

***
[SetULong(string, ulong)](ActorComponent_SetULong(string_ulong).md 'UnrealEngine.Framework.ActorComponent.SetULong(string, ulong)')

Sets the value of the unsigned long property  

***
[SetUShort(string, ushort)](ActorComponent_SetUShort(string_ushort).md 'UnrealEngine.Framework.ActorComponent.SetUShort(string, ushort)')

Sets the value of the unsigned short property  
