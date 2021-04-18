### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Actor Class
The base class of an object that can be placed or spawned in a level  
```csharp
public class Actor :
System.IEquatable<UnrealEngine.Framework.Actor>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Actor  

Derived  
&#8627; [AmbientSound](AmbientSound.md 'UnrealEngine.Framework.AmbientSound')
&#8627; [Brush](Brush.md 'UnrealEngine.Framework.Brush')
&#8627; [Camera](Camera.md 'UnrealEngine.Framework.Camera')
&#8627; [Controller](Controller.md 'UnrealEngine.Framework.Controller')
&#8627; [LevelScript](LevelScript.md 'UnrealEngine.Framework.LevelScript')
&#8627; [Light](Light.md 'UnrealEngine.Framework.Light')
&#8627; [Pawn](Pawn.md 'UnrealEngine.Framework.Pawn')
&#8627; [TriggerBase](TriggerBase.md 'UnrealEngine.Framework.TriggerBase')  

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Actor](Actor.md 'UnrealEngine.Framework.Actor')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Constructors

***
[Actor(string, Blueprint)](Actor_Actor(string_Blueprint).md 'UnrealEngine.Framework.Actor.Actor(string, UnrealEngine.Framework.Blueprint)')

Spawns the actor in the world  
### Properties

***
[BlockInput](Actor_BlockInput.md 'UnrealEngine.Framework.Actor.BlockInput')

Gets or sets whether the all input on the stack below this actor will not be considered  

***
[CreationTime](Actor_CreationTime.md 'UnrealEngine.Framework.Actor.CreationTime')

Gets the time when the actor was created relative to [Time](World_Time.md 'UnrealEngine.Framework.World.Time')

***
[ID](Actor_ID.md 'UnrealEngine.Framework.Actor.ID')

Returns the unique ID of the actor, reused by the engine, only unique while the actor is alive  

***
[InputComponent](Actor_InputComponent.md 'UnrealEngine.Framework.Actor.InputComponent')

Gets or sets the component that handles input for the actor, if enabled  

***
[IsRootComponentMovable](Actor_IsRootComponentMovable.md 'UnrealEngine.Framework.Actor.IsRootComponentMovable')

Returns `true` if the root component is [Movable](ComponentMobility.md#UnrealEngine_Framework_ComponentMobility_Movable 'UnrealEngine.Framework.ComponentMobility.Movable')

***
[IsSpawned](Actor_IsSpawned.md 'UnrealEngine.Framework.Actor.IsSpawned')

Returns `true` if the actor is spawned  

***
[Name](Actor_Name.md 'UnrealEngine.Framework.Actor.Name')

Returns the name of the actor  
### Methods

***
[AddTag(string)](Actor_AddTag(string).md 'UnrealEngine.Framework.Actor.AddTag(string)')

Adds a tag to the actor that can be used for grouping and categorizing  

***
[Destroy()](Actor_Destroy().md 'UnrealEngine.Framework.Actor.Destroy()')

Returns `true` if the actor is destroyed or already marked for destruction, `false` if indestructible  

***
[Equals(Actor)](Actor_Equals(Actor).md 'UnrealEngine.Framework.Actor.Equals(UnrealEngine.Framework.Actor)')

Indicates equality of objects  

***
[ForEachAttachedActor&lt;T&gt;(Action&lt;T&gt;)](Actor_ForEachAttachedActor_T_(Action_T_).md 'UnrealEngine.Framework.Actor.ForEachAttachedActor&lt;T&gt;(System.Action&lt;T&gt;)')

Performs the specified action on each attached actor if any  

***
[ForEachChildActor&lt;T&gt;(Action&lt;T&gt;)](Actor_ForEachChildActor_T_(Action_T_).md 'UnrealEngine.Framework.Actor.ForEachChildActor&lt;T&gt;(System.Action&lt;T&gt;)')

Performs the specified action on each child actor with [ChildActorComponent](ChildActorComponent.md 'UnrealEngine.Framework.ChildActorComponent'), including children of child if any  

***
[ForEachComponent&lt;T&gt;(Action&lt;T&gt;)](Actor_ForEachComponent_T_(Action_T_).md 'UnrealEngine.Framework.Actor.ForEachComponent&lt;T&gt;(System.Action&lt;T&gt;)')

Performs the specified action on each component if any  

***
[ForEachOverlappingActor&lt;T&gt;(Action&lt;T&gt;)](Actor_ForEachOverlappingActor_T_(Action_T_).md 'UnrealEngine.Framework.Actor.ForEachOverlappingActor&lt;T&gt;(System.Action&lt;T&gt;)')

Performs the specified action on each overlapping actor if any  

***
[GetBool(string, bool)](Actor_GetBool(string_bool).md 'UnrealEngine.Framework.Actor.GetBool(string, bool)')

Retrieves the value of the bool property  

***
[GetBounds(bool, Vector3, Vector3)](Actor_GetBounds(bool_Vector3_Vector3).md 'UnrealEngine.Framework.Actor.GetBounds(bool, System.Numerics.Vector3, System.Numerics.Vector3)')

Retrieves the bounding box of all components of the actor  

***
[GetByte(string, byte)](Actor_GetByte(string_byte).md 'UnrealEngine.Framework.Actor.GetByte(string, byte)')

Retrieves the value of the byte property  

***
[GetComponent&lt;T&gt;(string)](Actor_GetComponent_T_(string).md 'UnrealEngine.Framework.Actor.GetComponent&lt;T&gt;(string)')

Returns the component of the actor if matches the specified type, optionally with the specified name  

***
[GetComponentByID&lt;T&gt;(uint)](Actor_GetComponentByID_T_(uint).md 'UnrealEngine.Framework.Actor.GetComponentByID&lt;T&gt;(uint)')

Returns the component of the actor if matches the specified type and ID  

***
[GetComponentByTag&lt;T&gt;(string)](Actor_GetComponentByTag_T_(string).md 'UnrealEngine.Framework.Actor.GetComponentByTag&lt;T&gt;(string)')

Returns the component of the actor if matches the specified type and tag  

***
[GetDistanceTo(Actor)](Actor_GetDistanceTo(Actor).md 'UnrealEngine.Framework.Actor.GetDistanceTo(UnrealEngine.Framework.Actor)')

Returns the distance from this actor to another one  

***
[GetDouble(string, double)](Actor_GetDouble(string_double).md 'UnrealEngine.Framework.Actor.GetDouble(string, double)')

Retrieves the value of the double property  

***
[GetEnum&lt;T&gt;(string, T)](Actor_GetEnum_T_(string_T).md 'UnrealEngine.Framework.Actor.GetEnum&lt;T&gt;(string, T)')

Retrieves the value of the enum property  

***
[GetEyesViewPoint(Vector3, Quaternion)](Actor_GetEyesViewPoint(Vector3_Quaternion).md 'UnrealEngine.Framework.Actor.GetEyesViewPoint(System.Numerics.Vector3, System.Numerics.Quaternion)')

Retrieves the point of view of the actor  

***
[GetFloat(string, float)](Actor_GetFloat(string_float).md 'UnrealEngine.Framework.Actor.GetFloat(string, float)')

Retrieves the value of the float property  

***
[GetHashCode()](Actor_GetHashCode().md 'UnrealEngine.Framework.Actor.GetHashCode()')

Returns a hash code for the object  

***
[GetHorizontalDistanceTo(Actor)](Actor_GetHorizontalDistanceTo(Actor).md 'UnrealEngine.Framework.Actor.GetHorizontalDistanceTo(UnrealEngine.Framework.Actor)')

Returns the distance from this actor to another one, ignoring Z axis  

***
[GetInt(string, int)](Actor_GetInt(string_int).md 'UnrealEngine.Framework.Actor.GetInt(string, int)')

Retrieves the value of the integer property  

***
[GetLong(string, long)](Actor_GetLong(string_long).md 'UnrealEngine.Framework.Actor.GetLong(string, long)')

Retrieves the value of the long property  

***
[GetRootComponent&lt;T&gt;()](Actor_GetRootComponent_T_().md 'UnrealEngine.Framework.Actor.GetRootComponent&lt;T&gt;()')

Returns the root component of the actor if matches the specified type  

***
[GetShort(string, short)](Actor_GetShort(string_short).md 'UnrealEngine.Framework.Actor.GetShort(string, short)')

Retrieves the value of the short property  

***
[GetText(string, string)](Actor_GetText(string_string).md 'UnrealEngine.Framework.Actor.GetText(string, string)')

Retrieves the value of the text property  

***
[GetUInt(string, uint)](Actor_GetUInt(string_uint).md 'UnrealEngine.Framework.Actor.GetUInt(string, uint)')

Retrieves the value of the unsigned integer property  

***
[GetULong(string, ulong)](Actor_GetULong(string_ulong).md 'UnrealEngine.Framework.Actor.GetULong(string, ulong)')

Retrieves the value of the unsigned long property  

***
[GetUShort(string, ushort)](Actor_GetUShort(string_ushort).md 'UnrealEngine.Framework.Actor.GetUShort(string, ushort)')

Retrieves the value of the unsigned short property  

***
[HasTag(string)](Actor_HasTag(string).md 'UnrealEngine.Framework.Actor.HasTag(string)')

Indicates whether the actor has a tag  

***
[Hide(bool)](Actor_Hide(bool).md 'UnrealEngine.Framework.Actor.Hide(bool)')

Hides the actor  

***
[Invoke(string)](Actor_Invoke(string).md 'UnrealEngine.Framework.Actor.Invoke(string)')

Invokes a command, function, or an event with optional arguments  

***
[IsOverlappingActor(Actor)](Actor_IsOverlappingActor(Actor).md 'UnrealEngine.Framework.Actor.IsOverlappingActor(UnrealEngine.Framework.Actor)')

Returns `true` if any component of the actor is overlapping any component of another one  

***
[RegisterEvent(ActorEventType)](Actor_RegisterEvent(ActorEventType).md 'UnrealEngine.Framework.Actor.RegisterEvent(UnrealEngine.Framework.ActorEventType)')

Registers an event notification for the actor  

***
[RemoveTag(string)](Actor_RemoveTag(string).md 'UnrealEngine.Framework.Actor.RemoveTag(string)')

Removes a tag from the actor  

***
[Rename(string)](Actor_Rename(string).md 'UnrealEngine.Framework.Actor.Rename(string)')

Renames the actor  

***
[SetBool(string, bool)](Actor_SetBool(string_bool).md 'UnrealEngine.Framework.Actor.SetBool(string, bool)')

Sets the value of the bool property  

***
[SetByte(string, byte)](Actor_SetByte(string_byte).md 'UnrealEngine.Framework.Actor.SetByte(string, byte)')

Sets the value of the byte property  

***
[SetDouble(string, double)](Actor_SetDouble(string_double).md 'UnrealEngine.Framework.Actor.SetDouble(string, double)')

Sets the value of the double property  

***
[SetEnableCollision(bool)](Actor_SetEnableCollision(bool).md 'UnrealEngine.Framework.Actor.SetEnableCollision(bool)')

Sets the collision detection of the actor  

***
[SetEnableInput(PlayerController, bool)](Actor_SetEnableInput(PlayerController_bool).md 'UnrealEngine.Framework.Actor.SetEnableInput(UnrealEngine.Framework.PlayerController, bool)')

Sets [InputComponent](Actor_InputComponent.md 'UnrealEngine.Framework.Actor.InputComponent') for non-pawn actors handled by a [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')

***
[SetEnum&lt;T&gt;(string, T)](Actor_SetEnum_T_(string_T).md 'UnrealEngine.Framework.Actor.SetEnum&lt;T&gt;(string, T)')

Sets the value of the enum property  

***
[SetFloat(string, float)](Actor_SetFloat(string_float).md 'UnrealEngine.Framework.Actor.SetFloat(string, float)')

Sets the value of the float property  

***
[SetInt(string, int)](Actor_SetInt(string_int).md 'UnrealEngine.Framework.Actor.SetInt(string, int)')

Sets the value of the integer property  

***
[SetLifeSpan(float)](Actor_SetLifeSpan(float).md 'UnrealEngine.Framework.Actor.SetLifeSpan(float)')

Sets the lifespan of the actor, when it expires the actor will be destroyed, if requested lifespan set to zero, the timer is cleared and the actor will remain alive  

***
[SetLong(string, long)](Actor_SetLong(string_long).md 'UnrealEngine.Framework.Actor.SetLong(string, long)')

Sets the value of the long property  

***
[SetRootComponent(SceneComponent)](Actor_SetRootComponent(SceneComponent).md 'UnrealEngine.Framework.Actor.SetRootComponent(UnrealEngine.Framework.SceneComponent)')

Sets the root component, the actor should be the owner of the component  

***
[SetShort(string, short)](Actor_SetShort(string_short).md 'UnrealEngine.Framework.Actor.SetShort(string, short)')

Sets the value of the short property  

***
[SetText(string, string)](Actor_SetText(string_string).md 'UnrealEngine.Framework.Actor.SetText(string, string)')

Sets the value of the text property  

***
[SetUInt(string, uint)](Actor_SetUInt(string_uint).md 'UnrealEngine.Framework.Actor.SetUInt(string, uint)')

Sets the value of the unsigned integer property  

***
[SetULong(string, ulong)](Actor_SetULong(string_ulong).md 'UnrealEngine.Framework.Actor.SetULong(string, ulong)')

Sets the value of the unsigned long property  

***
[SetUShort(string, ushort)](Actor_SetUShort(string_ushort).md 'UnrealEngine.Framework.Actor.SetUShort(string, ushort)')

Sets the value of the unsigned short property  

***
[TeleportTo(Vector3, Quaternion, bool, bool)](Actor_TeleportTo(Vector3_Quaternion_bool_bool).md 'UnrealEngine.Framework.Actor.TeleportTo(System.Numerics.Vector3, System.Numerics.Quaternion, bool, bool)')

Teleports an actor to a new location  

***
[UnregisterEvent(ActorEventType)](Actor_UnregisterEvent(ActorEventType).md 'UnrealEngine.Framework.Actor.UnregisterEvent(UnrealEngine.Framework.ActorEventType)')

Unregisters an event notification for the actor  
