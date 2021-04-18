### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## LinearColor Struct
A linear 32-bit floating-point RGBA color  
```csharp
public struct LinearColor :
System.IEquatable<UnrealEngine.Framework.LinearColor>
```

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[LinearColor](LinearColor.md 'UnrealEngine.Framework.LinearColor')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Constructors

***
[LinearColor(float, float, float, float)](LinearColor_LinearColor(float_float_float_float).md 'UnrealEngine.Framework.LinearColor.LinearColor(float, float, float, float)')

Initializes a new instance the linear color  

***
[LinearColor(float[])](LinearColor_LinearColor(float__).md 'UnrealEngine.Framework.LinearColor.LinearColor(float[])')

Initializes a new instance the linear color  

***
[LinearColor(Color)](LinearColor_LinearColor(Color).md 'UnrealEngine.Framework.LinearColor.LinearColor(System.Drawing.Color)')

Initializes a new instance the linear color  

***
[LinearColor(Vector3, float)](LinearColor_LinearColor(Vector3_float).md 'UnrealEngine.Framework.LinearColor.LinearColor(System.Numerics.Vector3, float)')

Initializes a new instance the linear color  

***
[LinearColor(Vector4)](LinearColor_LinearColor(Vector4).md 'UnrealEngine.Framework.LinearColor.LinearColor(System.Numerics.Vector4)')

Initializes a new instance the linear color  
### Properties

***
[A](LinearColor_A.md 'UnrealEngine.Framework.LinearColor.A')

Gets or sets the alpha component of the linear color  

***
[B](LinearColor_B.md 'UnrealEngine.Framework.LinearColor.B')

Gets or sets the blue component of the linear color  

***
[Black](LinearColor_Black.md 'UnrealEngine.Framework.LinearColor.Black')

The black color  

***
[Blue](LinearColor_Blue.md 'UnrealEngine.Framework.LinearColor.Blue')

The blue color  

***
[G](LinearColor_G.md 'UnrealEngine.Framework.LinearColor.G')

Gets or sets the green component of the linear color  

***
[Green](LinearColor_Green.md 'UnrealEngine.Framework.LinearColor.Green')

The green color  

***
[Grey](LinearColor_Grey.md 'UnrealEngine.Framework.LinearColor.Grey')

The grey color  

***
[R](LinearColor_R.md 'UnrealEngine.Framework.LinearColor.R')

Gets or sets the red component of the linear color  

***
[Red](LinearColor_Red.md 'UnrealEngine.Framework.LinearColor.Red')

The red color  

***
[this[int]](LinearColor_this_int_.md 'UnrealEngine.Framework.LinearColor.this[int]')

Gets or sets the component at the specified index  

***
[White](LinearColor_White.md 'UnrealEngine.Framework.LinearColor.White')

The white color  

***
[Yellow](LinearColor_Yellow.md 'UnrealEngine.Framework.LinearColor.Yellow')

The yellow color  
### Methods

***
[Add(LinearColor, LinearColor)](LinearColor_Add(LinearColor_LinearColor).md 'UnrealEngine.Framework.LinearColor.Add(UnrealEngine.Framework.LinearColor, UnrealEngine.Framework.LinearColor)')

Adds two colors  

***
[Divide(LinearColor, LinearColor)](LinearColor_Divide(LinearColor_LinearColor).md 'UnrealEngine.Framework.LinearColor.Divide(UnrealEngine.Framework.LinearColor, UnrealEngine.Framework.LinearColor)')

Divides two colors  

***
[Equals(object)](LinearColor_Equals(object).md 'UnrealEngine.Framework.LinearColor.Equals(object)')

Indicates equality of objects  

***
[Equals(LinearColor)](LinearColor_Equals(LinearColor).md 'UnrealEngine.Framework.LinearColor.Equals(UnrealEngine.Framework.LinearColor)')

Indicates equality of objects  

***
[FromColor(Color)](LinearColor_FromColor(Color).md 'UnrealEngine.Framework.LinearColor.FromColor(System.Drawing.Color)')

Converts the color into a linear color  

***
[GetHashCode()](LinearColor_GetHashCode().md 'UnrealEngine.Framework.LinearColor.GetHashCode()')

Returns a hash code for the object  

***
[Lerp(LinearColor, LinearColor, float)](LinearColor_Lerp(LinearColor_LinearColor_float).md 'UnrealEngine.Framework.LinearColor.Lerp(UnrealEngine.Framework.LinearColor, UnrealEngine.Framework.LinearColor, float)')

Performs a linear interpolation between two colors  

***
[Multiply(LinearColor, LinearColor)](LinearColor_Multiply(LinearColor_LinearColor).md 'UnrealEngine.Framework.LinearColor.Multiply(UnrealEngine.Framework.LinearColor, UnrealEngine.Framework.LinearColor)')

Multiplies two colors  

***
[Subtract(LinearColor, LinearColor)](LinearColor_Subtract(LinearColor_LinearColor).md 'UnrealEngine.Framework.LinearColor.Subtract(UnrealEngine.Framework.LinearColor, UnrealEngine.Framework.LinearColor)')

Subtracts two colors  

***
[ToArray()](LinearColor_ToArray().md 'UnrealEngine.Framework.LinearColor.ToArray()')

Creates an array containing the elements of the linear color  

***
[ToString()](LinearColor_ToString().md 'UnrealEngine.Framework.LinearColor.ToString()')

Returns a string that represents this instance  

***
[ToString(IFormatProvider)](LinearColor_ToString(IFormatProvider).md 'UnrealEngine.Framework.LinearColor.ToString(System.IFormatProvider)')

Returns a string that represents this instance  

***
[ToVector3()](LinearColor_ToVector3().md 'UnrealEngine.Framework.LinearColor.ToVector3()')

Converts the linear color into a three component vector  

***
[ToVector4()](LinearColor_ToVector4().md 'UnrealEngine.Framework.LinearColor.ToVector4()')

Converts the linear color into a four component vector  
### Operators

***
[operator +(LinearColor, LinearColor)](LinearColor_operator+(LinearColor_LinearColor).md 'UnrealEngine.Framework.LinearColor.op_Addition(UnrealEngine.Framework.LinearColor, UnrealEngine.Framework.LinearColor)')

Adds two colors  

***
[operator /(float, LinearColor)](LinearColor_operator_(float_LinearColor).md 'UnrealEngine.Framework.LinearColor.op_Division(float, UnrealEngine.Framework.LinearColor)')

Divides two colors  

***
[operator ==(LinearColor, LinearColor)](LinearColor_operator(LinearColor_LinearColor).md 'UnrealEngine.Framework.LinearColor.op_Equality(UnrealEngine.Framework.LinearColor, UnrealEngine.Framework.LinearColor)')

Tests for equality between two objects  

***
[implicit operator string(LinearColor)](LinearColor_implicitoperatorstring(LinearColor).md 'UnrealEngine.Framework.LinearColor.op_Implicit string(UnrealEngine.Framework.LinearColor)')

Implicitly casts this instance to a string  

***
[implicit operator LinearColor(Color)](LinearColor_implicitoperatorLinearColor(Color).md 'UnrealEngine.Framework.LinearColor.op_Implicit UnrealEngine.Framework.LinearColor(System.Drawing.Color)')

Implicitly casts color instance to a linear color  

***
[operator !=(LinearColor, LinearColor)](LinearColor_operator!(LinearColor_LinearColor).md 'UnrealEngine.Framework.LinearColor.op_Inequality(UnrealEngine.Framework.LinearColor, UnrealEngine.Framework.LinearColor)')

Tests for inequality between two objects  

***
[operator *(float, LinearColor)](LinearColor_operator_(float_LinearColor).md 'UnrealEngine.Framework.LinearColor.op_Multiply(float, UnrealEngine.Framework.LinearColor)')

Multiplies two colors  

***
[operator -(LinearColor, LinearColor)](LinearColor_operator-(LinearColor_LinearColor).md 'UnrealEngine.Framework.LinearColor.op_Subtraction(UnrealEngine.Framework.LinearColor, UnrealEngine.Framework.LinearColor)')

Subtracts two colors  
