### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Maths Class
Provides additional static constants and methods for mathematical functions that are lack in [System.Math](https://docs.microsoft.com/en-us/dotnet/api/System.Math 'System.Math'), [System.MathF](https://docs.microsoft.com/en-us/dotnet/api/System.MathF 'System.MathF'), and [System.Numerics](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics 'System.Numerics')
```csharp
public static class Maths
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Maths  
### Fields

***
[DegToRadF](Maths_DegToRadF.md 'UnrealEngine.Framework.Maths.DegToRadF')

Degrees-to-radians conversion constant  

***
[RadToDegF](Maths_RadToDegF.md 'UnrealEngine.Framework.Maths.RadToDegF')

Radians-to-degrees conversion constant  
### Methods

***
[Angle(Quaternion, Quaternion)](Maths_Angle(Quaternion_Quaternion).md 'UnrealEngine.Framework.Maths.Angle(System.Numerics.Quaternion, System.Numerics.Quaternion)')

Returns the unsigned angle in degrees  

***
[Angle(Vector2, Vector2)](Maths_Angle(Vector2_Vector2).md 'UnrealEngine.Framework.Maths.Angle(System.Numerics.Vector2, System.Numerics.Vector2)')

Returns the unsigned angle in degrees  

***
[Angle(Vector3, Vector3)](Maths_Angle(Vector3_Vector3).md 'UnrealEngine.Framework.Maths.Angle(System.Numerics.Vector3, System.Numerics.Vector3)')

Returns the unsigned angle in degrees  

***
[AngleAxis(float, Vector3)](Maths_AngleAxis(float_Vector3).md 'UnrealEngine.Framework.Maths.AngleAxis(float, System.Numerics.Vector3)')

Returns a rotation which rotates angle degrees around axis  

***
[ClampMagnitude(Vector2, float)](Maths_ClampMagnitude(Vector2_float).md 'UnrealEngine.Framework.Maths.ClampMagnitude(System.Numerics.Vector2, float)')

Returns a copy of vector with clamped magnitude  

***
[ClampMagnitude(Vector3, float)](Maths_ClampMagnitude(Vector3_float).md 'UnrealEngine.Framework.Maths.ClampMagnitude(System.Numerics.Vector3, float)')

Returns a copy of vector with clamped magnitude  

***
[CreateFromYawPitchRoll(float, float, float)](Maths_CreateFromYawPitchRoll(float_float_float).md 'UnrealEngine.Framework.Maths.CreateFromYawPitchRoll(float, float, float)')

Returns a rotation from the given yaw, pitch, and roll, in radians  

***
[Damp(double, double, double, double)](Maths_Damp(double_double_double_double).md 'UnrealEngine.Framework.Maths.Damp(double, double, double, double)')

Creates framerate-independent dampened motion between two values  

***
[Damp(float, float, float, float)](Maths_Damp(float_float_float_float).md 'UnrealEngine.Framework.Maths.Damp(float, float, float, float)')

Creates framerate-independent dampened motion between two values  

***
[Damp(Quaternion, Quaternion, float, float)](Maths_Damp(Quaternion_Quaternion_float_float).md 'UnrealEngine.Framework.Maths.Damp(System.Numerics.Quaternion, System.Numerics.Quaternion, float, float)')

Creates framerate-independent dampened motion between two values  

***
[Damp(Vector2, Vector2, float, float)](Maths_Damp(Vector2_Vector2_float_float).md 'UnrealEngine.Framework.Maths.Damp(System.Numerics.Vector2, System.Numerics.Vector2, float, float)')

Creates framerate-independent dampened motion between two values  

***
[Damp(Vector3, Vector3, float, float)](Maths_Damp(Vector3_Vector3_float_float).md 'UnrealEngine.Framework.Maths.Damp(System.Numerics.Vector3, System.Numerics.Vector3, float, float)')

Creates framerate-independent dampened motion between two values  

***
[DeltaAngle(double, double)](Maths_DeltaAngle(double_double).md 'UnrealEngine.Framework.Maths.DeltaAngle(double, double)')

Calculates the shortest difference between the two given angles given in degrees  

***
[DeltaAngle(float, float)](Maths_DeltaAngle(float_float).md 'UnrealEngine.Framework.Maths.DeltaAngle(float, float)')

Calculates the shortest difference between the two given angles given in degrees  

***
[Dot(double, double)](Maths_Dot(double_double).md 'UnrealEngine.Framework.Maths.Dot(double, double)')

Returns the dot product of two float values  

***
[Dot(float, float)](Maths_Dot(float_float).md 'UnrealEngine.Framework.Maths.Dot(float, float)')

Returns the dot product of two float values  

***
[Euler(float, float, float)](Maths_Euler(float_float_float).md 'UnrealEngine.Framework.Maths.Euler(float, float, float)')

Returns a rotation which rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis  

***
[Euler(Vector3)](Maths_Euler(Vector3).md 'UnrealEngine.Framework.Maths.Euler(System.Numerics.Vector3)')

Returns a rotation which rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis  

***
[Fraction(double)](Maths_Fraction(double).md 'UnrealEngine.Framework.Maths.Fraction(double)')

Returns the fractional part of a float value  

***
[Fraction(float)](Maths_Fraction(float).md 'UnrealEngine.Framework.Maths.Fraction(float)')

Returns the fractional part of a float value  

***
[FromToRotation(Vector3, Vector3)](Maths_FromToRotation(Vector3_Vector3).md 'UnrealEngine.Framework.Maths.FromToRotation(System.Numerics.Vector3, System.Numerics.Vector3)')

Returns a rotation which rotates from [fromDirection](Maths_FromToRotation(Vector3_Vector3).md#UnrealEngine_Framework_Maths_FromToRotation(System_Numerics_Vector3_System_Numerics_Vector3)_fromDirection 'UnrealEngine.Framework.Maths.FromToRotation(System.Numerics.Vector3, System.Numerics.Vector3).fromDirection') to [toDirection](Maths_FromToRotation(Vector3_Vector3).md#UnrealEngine_Framework_Maths_FromToRotation(System_Numerics_Vector3_System_Numerics_Vector3)_toDirection 'UnrealEngine.Framework.Maths.FromToRotation(System.Numerics.Vector3, System.Numerics.Vector3).toDirection')

***
[InverseLerp(double, double, double)](Maths_InverseLerp(double_double_double).md 'UnrealEngine.Framework.Maths.InverseLerp(double, double, double)')

Inverse-interpolates between two values linearly  

***
[InverseLerp(float, float, float)](Maths_InverseLerp(float_float_float).md 'UnrealEngine.Framework.Maths.InverseLerp(float, float, float)')

Inverse-interpolates between two values linearly  

***
[Lerp(double, double, double)](Maths_Lerp(double_double_double).md 'UnrealEngine.Framework.Maths.Lerp(double, double, double)')

Interpolates between two values linearly  

***
[Lerp(float, float, float)](Maths_Lerp(float_float_float).md 'UnrealEngine.Framework.Maths.Lerp(float, float, float)')

Interpolates between two values linearly  

***
[LerpAngle(double, double, double)](Maths_LerpAngle(double_double_double).md 'UnrealEngine.Framework.Maths.LerpAngle(double, double, double)')

Interpolates between two values linearly, but makes sure the values calculated correctly when they wrap around 360 degrees  

***
[LerpAngle(float, float, float)](Maths_LerpAngle(float_float_float).md 'UnrealEngine.Framework.Maths.LerpAngle(float, float, float)')

Interpolates between two values linearly, but makes sure the values calculated correctly when they wrap around 360 degrees  

***
[Magnitude(Vector2)](Maths_Magnitude(Vector2).md 'UnrealEngine.Framework.Maths.Magnitude(System.Numerics.Vector2)')

Returns the length of the vector  

***
[Magnitude(Vector3)](Maths_Magnitude(Vector3).md 'UnrealEngine.Framework.Maths.Magnitude(System.Numerics.Vector3)')

Returns the length of the vector  

***
[Magnitude(Vector4)](Maths_Magnitude(Vector4).md 'UnrealEngine.Framework.Maths.Magnitude(System.Numerics.Vector4)')

Returns the length of the vector  

***
[MoveTowards(double, double, double)](Maths_MoveTowards(double_double_double).md 'UnrealEngine.Framework.Maths.MoveTowards(double, double, double)')

Returns the vector moved towards a target  

***
[MoveTowards(float, float, float)](Maths_MoveTowards(float_float_float).md 'UnrealEngine.Framework.Maths.MoveTowards(float, float, float)')

Returns the vector moved towards a target  

***
[MoveTowards(Vector2, Vector2, float)](Maths_MoveTowards(Vector2_Vector2_float).md 'UnrealEngine.Framework.Maths.MoveTowards(System.Numerics.Vector2, System.Numerics.Vector2, float)')

Returns the vector moved towards a target  

***
[MoveTowards(Vector3, Vector3, float)](Maths_MoveTowards(Vector3_Vector3_float).md 'UnrealEngine.Framework.Maths.MoveTowards(System.Numerics.Vector3, System.Numerics.Vector3, float)')

Returns the vector moved towards a target  

***
[MoveTowardsAngle(double, double, double)](Maths_MoveTowardsAngle(double_double_double).md 'UnrealEngine.Framework.Maths.MoveTowardsAngle(double, double, double)')

Returns the vector moved towards a target, but makes sure the values calculated correctly when they wrap around 360 degrees  

***
[MoveTowardsAngle(float, float, float)](Maths_MoveTowardsAngle(float_float_float).md 'UnrealEngine.Framework.Maths.MoveTowardsAngle(float, float, float)')

Returns the vector moved towards a target, but makes sure the values calculated correctly when they wrap around 360 degrees  

***
[NextPowerOfTwo(double)](Maths_NextPowerOfTwo(double).md 'UnrealEngine.Framework.Maths.NextPowerOfTwo(double)')

Returns the next power of two  

***
[NextPowerOfTwo(float)](Maths_NextPowerOfTwo(float).md 'UnrealEngine.Framework.Maths.NextPowerOfTwo(float)')

Returns the next power of two  

***
[Perpendicular(Vector2)](Maths_Perpendicular(Vector2).md 'UnrealEngine.Framework.Maths.Perpendicular(System.Numerics.Vector2)')

Returns the vector perpendicular to the specified vector  

***
[PreviousPowerOfTwo(double)](Maths_PreviousPowerOfTwo(double).md 'UnrealEngine.Framework.Maths.PreviousPowerOfTwo(double)')

Returns the previous power of two  

***
[PreviousPowerOfTwo(float)](Maths_PreviousPowerOfTwo(float).md 'UnrealEngine.Framework.Maths.PreviousPowerOfTwo(float)')

Returns the previous power of two  

***
[Project(Vector3, Vector3)](Maths_Project(Vector3_Vector3).md 'UnrealEngine.Framework.Maths.Project(System.Numerics.Vector3, System.Numerics.Vector3)')

Projects a vector onto another vector  

***
[ProjectOnPlane(Vector3, Vector3)](Maths_ProjectOnPlane(Vector3_Vector3).md 'UnrealEngine.Framework.Maths.ProjectOnPlane(System.Numerics.Vector3, System.Numerics.Vector3)')

Projects a vector onto a plane defined by a normal orthogonal to the plane  

***
[Refract(Vector2, Vector2, float)](Maths_Refract(Vector2_Vector2_float).md 'UnrealEngine.Framework.Maths.Refract(System.Numerics.Vector2, System.Numerics.Vector2, float)')

Returns the refraction vector  

***
[Refract(Vector3, Vector3, float)](Maths_Refract(Vector3_Vector3_float).md 'UnrealEngine.Framework.Maths.Refract(System.Numerics.Vector3, System.Numerics.Vector3, float)')

Returns the refraction vector  

***
[Refract(Vector4, Vector4, float)](Maths_Refract(Vector4_Vector4_float).md 'UnrealEngine.Framework.Maths.Refract(System.Numerics.Vector4, System.Numerics.Vector4, float)')

Returns the refraction vector  

***
[Repeat(double, double)](Maths_Repeat(double_double).md 'UnrealEngine.Framework.Maths.Repeat(double, double)')

Loops the value so that it is never larger than length and never smaller than 0.0d  

***
[Repeat(float, float)](Maths_Repeat(float_float).md 'UnrealEngine.Framework.Maths.Repeat(float, float)')

Loops the value so that it is never larger than length and never smaller than 0.0f  

***
[RotateTowards(Quaternion, Quaternion, float)](Maths_RotateTowards(Quaternion_Quaternion_float).md 'UnrealEngine.Framework.Maths.RotateTowards(System.Numerics.Quaternion, System.Numerics.Quaternion, float)')

Returns a rotation which rotated towards a target  

***
[Saturate(double)](Maths_Saturate(double).md 'UnrealEngine.Framework.Maths.Saturate(double)')

Clamps value between 0.0d and 1.0d  

***
[Saturate(float)](Maths_Saturate(float).md 'UnrealEngine.Framework.Maths.Saturate(float)')

Clamps value between 0.0f and 1.0f  

***
[SignedAngle(Vector3, Vector3, Vector3)](Maths_SignedAngle(Vector3_Vector3_Vector3).md 'UnrealEngine.Framework.Maths.SignedAngle(System.Numerics.Vector3, System.Numerics.Vector3, System.Numerics.Vector3)')

Returns the signed angle in degrees  

***
[SmootherStep(double)](Maths_SmootherStep(double).md 'UnrealEngine.Framework.Maths.SmootherStep(double)')

Performs a smoother interpolation between 0.0d and 1.0d with 1st and 2nd order derivatives of zero at endpoints  

***
[SmootherStep(float)](Maths_SmootherStep(float).md 'UnrealEngine.Framework.Maths.SmootherStep(float)')

Performs a smoother interpolation between 0.0f and 1.0f with 1st and 2nd order derivatives of zero at endpoints  

***
[SmoothStep(double)](Maths_SmoothStep(double).md 'UnrealEngine.Framework.Maths.SmoothStep(double)')

Performs smooth (Cubic Hermite) interpolation between 0.0d and 1.0d  

***
[SmoothStep(float)](Maths_SmoothStep(float).md 'UnrealEngine.Framework.Maths.SmoothStep(float)')

Performs smooth (Cubic Hermite) interpolation between 0.0f and 1.0f  

***
[SquareMagnitude(Vector2)](Maths_SquareMagnitude(Vector2).md 'UnrealEngine.Framework.Maths.SquareMagnitude(System.Numerics.Vector2)')

Returns the squared length of the vector  

***
[SquareMagnitude(Vector3)](Maths_SquareMagnitude(Vector3).md 'UnrealEngine.Framework.Maths.SquareMagnitude(System.Numerics.Vector3)')

Returns the squared length of the vector  

***
[SquareMagnitude(Vector4)](Maths_SquareMagnitude(Vector4).md 'UnrealEngine.Framework.Maths.SquareMagnitude(System.Numerics.Vector4)')

Returns the squared length of the vector  
