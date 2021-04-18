### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## AnimationInstance Class
An animation instance representation  
```csharp
public class AnimationInstance :
System.IEquatable<UnrealEngine.Framework.AnimationInstance>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AnimationInstance  

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[AnimationInstance](AnimationInstance.md 'UnrealEngine.Framework.AnimationInstance')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Properties

***
[IsCreated](AnimationInstance_IsCreated.md 'UnrealEngine.Framework.AnimationInstance.IsCreated')

Returns `true` if the object is created  
### Methods

***
[Equals(AnimationInstance)](AnimationInstance_Equals(AnimationInstance).md 'UnrealEngine.Framework.AnimationInstance.Equals(UnrealEngine.Framework.AnimationInstance)')

Indicates equality of objects  

***
[GetBlendTime(AnimationMontage)](AnimationInstance_GetBlendTime(AnimationMontage).md 'UnrealEngine.Framework.AnimationInstance.GetBlendTime(UnrealEngine.Framework.AnimationMontage)')

Returns the current blend time of the animation montage  

***
[GetBool(string, bool)](AnimationInstance_GetBool(string_bool).md 'UnrealEngine.Framework.AnimationInstance.GetBool(string, bool)')

Retrieves the value of the bool property  

***
[GetByte(string, byte)](AnimationInstance_GetByte(string_byte).md 'UnrealEngine.Framework.AnimationInstance.GetByte(string, byte)')

Retrieves the value of the byte property  

***
[GetCurrentActiveMontage()](AnimationInstance_GetCurrentActiveMontage().md 'UnrealEngine.Framework.AnimationInstance.GetCurrentActiveMontage()')

Returns the current active animation montage or `null` on failure  

***
[GetCurrentSection(AnimationMontage)](AnimationInstance_GetCurrentSection(AnimationMontage).md 'UnrealEngine.Framework.AnimationInstance.GetCurrentSection(UnrealEngine.Framework.AnimationMontage)')

Returns the name of the current animation montage section  

***
[GetDouble(string, double)](AnimationInstance_GetDouble(string_double).md 'UnrealEngine.Framework.AnimationInstance.GetDouble(string, double)')

Retrieves the value of the double property  

***
[GetEnum&lt;T&gt;(string, T)](AnimationInstance_GetEnum_T_(string_T).md 'UnrealEngine.Framework.AnimationInstance.GetEnum&lt;T&gt;(string, T)')

Retrieves the value of the enum property  

***
[GetFloat(string, float)](AnimationInstance_GetFloat(string_float).md 'UnrealEngine.Framework.AnimationInstance.GetFloat(string, float)')

Retrieves the value of the float property  

***
[GetHashCode()](AnimationInstance_GetHashCode().md 'UnrealEngine.Framework.AnimationInstance.GetHashCode()')

Returns a hash code for the object  

***
[GetInt(string, int)](AnimationInstance_GetInt(string_int).md 'UnrealEngine.Framework.AnimationInstance.GetInt(string, int)')

Retrieves the value of the integer property  

***
[GetLong(string, long)](AnimationInstance_GetLong(string_long).md 'UnrealEngine.Framework.AnimationInstance.GetLong(string, long)')

Retrieves the value of the long property  

***
[GetPlayRate(AnimationMontage)](AnimationInstance_GetPlayRate(AnimationMontage).md 'UnrealEngine.Framework.AnimationInstance.GetPlayRate(UnrealEngine.Framework.AnimationMontage)')

Returns the current play rate of the animation montage  

***
[GetPosition(AnimationMontage)](AnimationInstance_GetPosition(AnimationMontage).md 'UnrealEngine.Framework.AnimationInstance.GetPosition(UnrealEngine.Framework.AnimationMontage)')

Returns the current position of the animation montage  

***
[GetShort(string, short)](AnimationInstance_GetShort(string_short).md 'UnrealEngine.Framework.AnimationInstance.GetShort(string, short)')

Retrieves the value of the short property  

***
[GetText(string, string)](AnimationInstance_GetText(string_string).md 'UnrealEngine.Framework.AnimationInstance.GetText(string, string)')

Retrieves the value of the text property  

***
[GetUInt(string, uint)](AnimationInstance_GetUInt(string_uint).md 'UnrealEngine.Framework.AnimationInstance.GetUInt(string, uint)')

Retrieves the value of the unsigned integer property  

***
[GetULong(string, ulong)](AnimationInstance_GetULong(string_ulong).md 'UnrealEngine.Framework.AnimationInstance.GetULong(string, ulong)')

Retrieves the value of the unsigned long property  

***
[GetUShort(string, ushort)](AnimationInstance_GetUShort(string_ushort).md 'UnrealEngine.Framework.AnimationInstance.GetUShort(string, ushort)')

Retrieves the value of the unsigned short property  

***
[Invoke(string)](AnimationInstance_Invoke(string).md 'UnrealEngine.Framework.AnimationInstance.Invoke(string)')

Invokes a command, function, or an event with optional arguments  

***
[IsPlaying(AnimationMontage)](AnimationInstance_IsPlaying(AnimationMontage).md 'UnrealEngine.Framework.AnimationInstance.IsPlaying(UnrealEngine.Framework.AnimationMontage)')

Returns `true` if the animation montage is active and playing  

***
[JumpToSection(AnimationMontage, string)](AnimationInstance_JumpToSection(AnimationMontage_string).md 'UnrealEngine.Framework.AnimationInstance.JumpToSection(UnrealEngine.Framework.AnimationMontage, string)')

Makes the animation montage jump to a named section  

***
[JumpToSectionsEnd(AnimationMontage, string)](AnimationInstance_JumpToSectionsEnd(AnimationMontage_string).md 'UnrealEngine.Framework.AnimationInstance.JumpToSectionsEnd(UnrealEngine.Framework.AnimationMontage, string)')

Makes the animation montage jump to the end of a named section  

***
[PauseMontage(AnimationMontage)](AnimationInstance_PauseMontage(AnimationMontage).md 'UnrealEngine.Framework.AnimationInstance.PauseMontage(UnrealEngine.Framework.AnimationMontage)')

Pauses the animation montage  

***
[PlayMontage(AnimationMontage, float, float, bool)](AnimationInstance_PlayMontage(AnimationMontage_float_float_bool).md 'UnrealEngine.Framework.AnimationInstance.PlayMontage(UnrealEngine.Framework.AnimationMontage, float, float, bool)')

Plays the animation montage  

***
[ResumeMontage(AnimationMontage)](AnimationInstance_ResumeMontage(AnimationMontage).md 'UnrealEngine.Framework.AnimationInstance.ResumeMontage(UnrealEngine.Framework.AnimationMontage)')

Resumes the paused animation montage  

***
[SetBool(string, bool)](AnimationInstance_SetBool(string_bool).md 'UnrealEngine.Framework.AnimationInstance.SetBool(string, bool)')

Sets the value of the bool property  

***
[SetByte(string, byte)](AnimationInstance_SetByte(string_byte).md 'UnrealEngine.Framework.AnimationInstance.SetByte(string, byte)')

Sets the value of the byte property  

***
[SetDouble(string, double)](AnimationInstance_SetDouble(string_double).md 'UnrealEngine.Framework.AnimationInstance.SetDouble(string, double)')

Sets the value of the double property  

***
[SetEnum&lt;T&gt;(string, T)](AnimationInstance_SetEnum_T_(string_T).md 'UnrealEngine.Framework.AnimationInstance.SetEnum&lt;T&gt;(string, T)')

Sets the value of the enum property  

***
[SetFloat(string, float)](AnimationInstance_SetFloat(string_float).md 'UnrealEngine.Framework.AnimationInstance.SetFloat(string, float)')

Sets the value of the float property  

***
[SetInt(string, int)](AnimationInstance_SetInt(string_int).md 'UnrealEngine.Framework.AnimationInstance.SetInt(string, int)')

Sets the value of the integer property  

***
[SetLong(string, long)](AnimationInstance_SetLong(string_long).md 'UnrealEngine.Framework.AnimationInstance.SetLong(string, long)')

Sets the value of the long property  

***
[SetNextSection(AnimationMontage, string, string)](AnimationInstance_SetNextSection(AnimationMontage_string_string).md 'UnrealEngine.Framework.AnimationInstance.SetNextSection(UnrealEngine.Framework.AnimationMontage, string, string)')

Sets the next section after [sectionToChange](AnimationInstance_SetNextSection(AnimationMontage_string_string).md#UnrealEngine_Framework_AnimationInstance_SetNextSection(UnrealEngine_Framework_AnimationMontage_string_string)_sectionToChange 'UnrealEngine.Framework.AnimationInstance.SetNextSection(UnrealEngine.Framework.AnimationMontage, string, string).sectionToChange')

***
[SetPlayRate(AnimationMontage, float)](AnimationInstance_SetPlayRate(AnimationMontage_float).md 'UnrealEngine.Framework.AnimationInstance.SetPlayRate(UnrealEngine.Framework.AnimationMontage, float)')

Sets the current play rate of the animation montage  

***
[SetPosition(AnimationMontage, float)](AnimationInstance_SetPosition(AnimationMontage_float).md 'UnrealEngine.Framework.AnimationInstance.SetPosition(UnrealEngine.Framework.AnimationMontage, float)')

Sets the current position of the animation montage  

***
[SetShort(string, short)](AnimationInstance_SetShort(string_short).md 'UnrealEngine.Framework.AnimationInstance.SetShort(string, short)')

Sets the value of the short property  

***
[SetText(string, string)](AnimationInstance_SetText(string_string).md 'UnrealEngine.Framework.AnimationInstance.SetText(string, string)')

Sets the value of the text property  

***
[SetUInt(string, uint)](AnimationInstance_SetUInt(string_uint).md 'UnrealEngine.Framework.AnimationInstance.SetUInt(string, uint)')

Sets the value of the unsigned integer property  

***
[SetULong(string, ulong)](AnimationInstance_SetULong(string_ulong).md 'UnrealEngine.Framework.AnimationInstance.SetULong(string, ulong)')

Sets the value of the unsigned long property  

***
[SetUShort(string, ushort)](AnimationInstance_SetUShort(string_ushort).md 'UnrealEngine.Framework.AnimationInstance.SetUShort(string, ushort)')

Sets the value of the unsigned short property  

***
[StopMontage(AnimationMontage, float)](AnimationInstance_StopMontage(AnimationMontage_float).md 'UnrealEngine.Framework.AnimationInstance.StopMontage(UnrealEngine.Framework.AnimationMontage, float)')

Stops the animation montage, if [montage](AnimationInstance_StopMontage(AnimationMontage_float).md#UnrealEngine_Framework_AnimationInstance_StopMontage(UnrealEngine_Framework_AnimationMontage_float)_montage 'UnrealEngine.Framework.AnimationInstance.StopMontage(UnrealEngine.Framework.AnimationMontage, float).montage') is `null` stops all active montages  
