### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## ObjectReference Struct
A representation of the engine's object reference  
```csharp
public struct ObjectReference :
System.IEquatable<UnrealEngine.Framework.ObjectReference>
```

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ObjectReference](ObjectReference.md 'UnrealEngine.Framework.ObjectReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Properties

***
[ID](ObjectReference_ID.md 'UnrealEngine.Framework.ObjectReference.ID')

Returns the unique ID of the object, reused by the engine, only unique while the object is alive  

***
[IsCreated](ObjectReference_IsCreated.md 'UnrealEngine.Framework.ObjectReference.IsCreated')

Returns `true` if the object is created  

***
[Name](ObjectReference_Name.md 'UnrealEngine.Framework.ObjectReference.Name')

Returns the name of the object  
### Methods

***
[Equals(object)](ObjectReference_Equals(object).md 'UnrealEngine.Framework.ObjectReference.Equals(object)')

Indicates equality of objects  

***
[Equals(ObjectReference)](ObjectReference_Equals(ObjectReference).md 'UnrealEngine.Framework.ObjectReference.Equals(UnrealEngine.Framework.ObjectReference)')

Indicates equality of objects  

***
[GetHashCode()](ObjectReference_GetHashCode().md 'UnrealEngine.Framework.ObjectReference.GetHashCode()')

Returns a hash code for the object  

***
[ToActor&lt;T&gt;()](ObjectReference_ToActor_T_().md 'UnrealEngine.Framework.ObjectReference.ToActor&lt;T&gt;()')

Converts the object reference to the actor of the specified class  

***
[ToComponent&lt;T&gt;()](ObjectReference_ToComponent_T_().md 'UnrealEngine.Framework.ObjectReference.ToComponent&lt;T&gt;()')

Converts the object reference to the component of the specified class  
### Operators

***
[operator ==(ObjectReference, ObjectReference)](ObjectReference_operator(ObjectReference_ObjectReference).md 'UnrealEngine.Framework.ObjectReference.op_Equality(UnrealEngine.Framework.ObjectReference, UnrealEngine.Framework.ObjectReference)')

Tests for equality between two objects  

***
[operator !=(ObjectReference, ObjectReference)](ObjectReference_operator!(ObjectReference_ObjectReference).md 'UnrealEngine.Framework.ObjectReference.op_Inequality(UnrealEngine.Framework.ObjectReference, UnrealEngine.Framework.ObjectReference)')

Tests for inequality between two objects  
