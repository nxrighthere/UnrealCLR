### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.AddAngularImpulseInRadians(Vector3, string, bool) Method
Adds an angular impulse in radians to a rigid body  
```csharp
public void AddAngularImpulseInRadians(in System.Numerics.Vector3 impulse, string boneName=null, bool velocityChange=false);
```
#### Parameters
<a name='UnrealEngine_Framework_PrimitiveComponent_AddAngularImpulseInRadians(System_Numerics_Vector3_string_bool)_impulse'></a>
`impulse` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Magnitude and direction of the impulse to apply, the direction is the axis of rotation
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddAngularImpulseInRadians(System_Numerics_Vector3_string_bool)_boneName'></a>
`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
If applied to [SkeletalMeshComponent](SkeletalMeshComponent.md 'UnrealEngine.Framework.SkeletalMeshComponent'), the name of the body to apply an angular impulse to, or `null` to indicate the root body
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddAngularImpulseInRadians(System_Numerics_Vector3_string_bool)_velocityChange'></a>
`velocityChange` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, [impulse](PrimitiveComponent_AddAngularImpulseInRadians(Vector3_string_bool).md#UnrealEngine_Framework_PrimitiveComponent_AddAngularImpulseInRadians(System_Numerics_Vector3_string_bool)_impulse 'UnrealEngine.Framework.PrimitiveComponent.AddAngularImpulseInRadians(System.Numerics.Vector3, string, bool).impulse') is taken as a change in velocity instead of a physical force (the mass will have no effect)
  
