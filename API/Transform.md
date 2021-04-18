### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Transform Struct
Transform composed of location, rotation, and scale  
```csharp
public struct Transform :
System.IEquatable<UnrealEngine.Framework.Transform>
```

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Transform](Transform.md 'UnrealEngine.Framework.Transform')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Constructors

***
[Transform(Vector3, Quaternion, Vector3)](Transform_Transform(Vector3_Quaternion_Vector3).md 'UnrealEngine.Framework.Transform.Transform(System.Numerics.Vector3, System.Numerics.Quaternion, System.Numerics.Vector3)')

Initializes a new instance the transform  
### Properties

***
[Location](Transform_Location.md 'UnrealEngine.Framework.Transform.Location')

Gets or sets the location component  

***
[Rotation](Transform_Rotation.md 'UnrealEngine.Framework.Transform.Rotation')

Gets or sets the rotation component  

***
[Scale](Transform_Scale.md 'UnrealEngine.Framework.Transform.Scale')

Gets or sets the scale component  
### Methods

***
[Equals(object)](Transform_Equals(object).md 'UnrealEngine.Framework.Transform.Equals(object)')

Indicates equality of objects  

***
[Equals(Transform)](Transform_Equals(Transform).md 'UnrealEngine.Framework.Transform.Equals(UnrealEngine.Framework.Transform)')

Indicates equality of objects  

***
[GetHashCode()](Transform_GetHashCode().md 'UnrealEngine.Framework.Transform.GetHashCode()')

Returns a hash code for the object  

***
[ToString()](Transform_ToString().md 'UnrealEngine.Framework.Transform.ToString()')

Returns a string that represents this instance  

***
[ToString(IFormatProvider)](Transform_ToString(IFormatProvider).md 'UnrealEngine.Framework.Transform.ToString(System.IFormatProvider)')

Returns a string that represents this instance  
### Operators

***
[operator ==(Transform, Transform)](Transform_operator(Transform_Transform).md 'UnrealEngine.Framework.Transform.op_Equality(UnrealEngine.Framework.Transform, UnrealEngine.Framework.Transform)')

Tests for equality between two objects  

***
[implicit operator string(Transform)](Transform_implicitoperatorstring(Transform).md 'UnrealEngine.Framework.Transform.op_Implicit string(UnrealEngine.Framework.Transform)')

Implicitly casts this instance to a string  

***
[operator !=(Transform, Transform)](Transform_operator!(Transform_Transform).md 'UnrealEngine.Framework.Transform.op_Inequality(UnrealEngine.Framework.Transform, UnrealEngine.Framework.Transform)')

Tests for inequality between two objects  
