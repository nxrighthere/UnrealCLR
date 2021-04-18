### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.AddTorqueInDegrees(Vector3, string, bool) Method
Adds a torque in degrees to a rigid body  
```csharp
public void AddTorqueInDegrees(in System.Numerics.Vector3 torque, string boneName=null, bool accelerationChange=false);
```
#### Parameters
<a name='UnrealEngine_Framework_PrimitiveComponent_AddTorqueInDegrees(System_Numerics_Vector3_string_bool)_torque'></a>
`torque` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Torque to apply, direction is axis of rotation and magnitude is strength of the torque
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddTorqueInDegrees(System_Numerics_Vector3_string_bool)_boneName'></a>
`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
If applied to [SkeletalMeshComponent](SkeletalMeshComponent.md 'UnrealEngine.Framework.SkeletalMeshComponent'), the name of the body to apply an angular impulse to, or `null` to indicate the root body
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddTorqueInDegrees(System_Numerics_Vector3_string_bool)_accelerationChange'></a>
`accelerationChange` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, [torque](PrimitiveComponent_AddTorqueInDegrees(Vector3_string_bool).md#UnrealEngine_Framework_PrimitiveComponent_AddTorqueInDegrees(System_Numerics_Vector3_string_bool)_torque 'UnrealEngine.Framework.PrimitiveComponent.AddTorqueInDegrees(System.Numerics.Vector3, string, bool).torque') is taken as a change in acceleration instead of a physical force (the mass will have no effect)
  
