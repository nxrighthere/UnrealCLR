### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.AddForce(Vector3, string, bool) Method
Adds a force to a rigid body  
```csharp
public void AddForce(in System.Numerics.Vector3 force, string boneName=null, bool accelerationChange=false);
```
#### Parameters
<a name='UnrealEngine_Framework_PrimitiveComponent_AddForce(System_Numerics_Vector3_string_bool)_force'></a>
`force` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Force vector to apply, magnitude indicates strength of force
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddForce(System_Numerics_Vector3_string_bool)_boneName'></a>
`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
If applied to [SkeletalMeshComponent](SkeletalMeshComponent.md 'UnrealEngine.Framework.SkeletalMeshComponent'), the name of the body to apply an angular impulse to, or `null` to indicate the root body
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddForce(System_Numerics_Vector3_string_bool)_accelerationChange'></a>
`accelerationChange` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, [force](PrimitiveComponent_AddForce(Vector3_string_bool).md#UnrealEngine_Framework_PrimitiveComponent_AddForce(System_Numerics_Vector3_string_bool)_force 'UnrealEngine.Framework.PrimitiveComponent.AddForce(System.Numerics.Vector3, string, bool).force') is taken as a change in acceleration instead of a physical force (the mass will have no effect)
  
