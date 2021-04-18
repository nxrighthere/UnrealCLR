### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## ActorReference Struct
A representation of the engine's actor reference  
```csharp
public struct ActorReference :
System.IEquatable<UnrealEngine.Framework.ActorReference>
```

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ActorReference](ActorReference.md 'UnrealEngine.Framework.ActorReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Properties

***
[ID](ActorReference_ID.md 'UnrealEngine.Framework.ActorReference.ID')

Returns the unique ID of the object, reused by the engine, only unique while the object is alive  

***
[IsSpawned](ActorReference_IsSpawned.md 'UnrealEngine.Framework.ActorReference.IsSpawned')

Returns `true` if the actor is spawned  

***
[Name](ActorReference_Name.md 'UnrealEngine.Framework.ActorReference.Name')

Returns the name of the object  
### Methods

***
[Equals(object)](ActorReference_Equals(object).md 'UnrealEngine.Framework.ActorReference.Equals(object)')

Indicates equality of objects  

***
[Equals(ActorReference)](ActorReference_Equals(ActorReference).md 'UnrealEngine.Framework.ActorReference.Equals(UnrealEngine.Framework.ActorReference)')

Indicates equality of objects  

***
[GetHashCode()](ActorReference_GetHashCode().md 'UnrealEngine.Framework.ActorReference.GetHashCode()')

Returns a hash code for the object  

***
[ToActor&lt;T&gt;()](ActorReference_ToActor_T_().md 'UnrealEngine.Framework.ActorReference.ToActor&lt;T&gt;()')

Converts the actor reference to the actor of the specified class  
### Operators

***
[operator ==(ActorReference, ActorReference)](ActorReference_operator(ActorReference_ActorReference).md 'UnrealEngine.Framework.ActorReference.op_Equality(UnrealEngine.Framework.ActorReference, UnrealEngine.Framework.ActorReference)')

Tests for equality between two objects  

***
[operator !=(ActorReference, ActorReference)](ActorReference_operator!(ActorReference_ActorReference).md 'UnrealEngine.Framework.ActorReference.op_Inequality(UnrealEngine.Framework.ActorReference, UnrealEngine.Framework.ActorReference)')

Tests for inequality between two objects  
