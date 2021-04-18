### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## ComponentReference Struct
A representation of the engine's component reference  
```csharp
public struct ComponentReference :
System.IEquatable<UnrealEngine.Framework.ComponentReference>
```

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ComponentReference](ComponentReference.md 'UnrealEngine.Framework.ComponentReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Properties

***
[ID](ComponentReference_ID.md 'UnrealEngine.Framework.ComponentReference.ID')

Returns the unique ID of the object, reused by the engine, only unique while the object is alive  

***
[IsCreated](ComponentReference_IsCreated.md 'UnrealEngine.Framework.ComponentReference.IsCreated')

Returns `true` if the object is created  

***
[Name](ComponentReference_Name.md 'UnrealEngine.Framework.ComponentReference.Name')

Returns the name of the object  
### Methods

***
[Equals(object)](ComponentReference_Equals(object).md 'UnrealEngine.Framework.ComponentReference.Equals(object)')

Indicates equality of objects  

***
[Equals(ComponentReference)](ComponentReference_Equals(ComponentReference).md 'UnrealEngine.Framework.ComponentReference.Equals(UnrealEngine.Framework.ComponentReference)')

Indicates equality of objects  

***
[GetHashCode()](ComponentReference_GetHashCode().md 'UnrealEngine.Framework.ComponentReference.GetHashCode()')

Returns a hash code for the object  

***
[ToComponent&lt;T&gt;()](ComponentReference_ToComponent_T_().md 'UnrealEngine.Framework.ComponentReference.ToComponent&lt;T&gt;()')

Converts the component reference to the component of the specified class  
### Operators

***
[operator ==(ComponentReference, ComponentReference)](ComponentReference_operator(ComponentReference_ComponentReference).md 'UnrealEngine.Framework.ComponentReference.op_Equality(UnrealEngine.Framework.ComponentReference, UnrealEngine.Framework.ComponentReference)')

Tests for equality between two objects  

***
[operator !=(ComponentReference, ComponentReference)](ComponentReference_operator!(ComponentReference_ComponentReference).md 'UnrealEngine.Framework.ComponentReference.op_Inequality(UnrealEngine.Framework.ComponentReference, UnrealEngine.Framework.ComponentReference)')

Tests for inequality between two objects  
