### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.AddForceAtLocation(Vector3, Vector3, string, bool) Method
Adds a force to a rigid body at a specific location, optionally in local space  
```csharp
public void AddForceAtLocation(in System.Numerics.Vector3 force, in System.Numerics.Vector3 location, string boneName=null, bool localSpace=false);
```
#### Parameters
<a name='UnrealEngine_Framework_PrimitiveComponent_AddForceAtLocation(System_Numerics_Vector3_System_Numerics_Vector3_string_bool)_force'></a>
`force` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Force vector to apply, magnitude indicates strength of force
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddForceAtLocation(System_Numerics_Vector3_System_Numerics_Vector3_string_bool)_location'></a>
`location` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
A point in world or local space to apply the force at
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddForceAtLocation(System_Numerics_Vector3_System_Numerics_Vector3_string_bool)_boneName'></a>
`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
If applied to [SkeletalMeshComponent](SkeletalMeshComponent.md 'UnrealEngine.Framework.SkeletalMeshComponent'), the name of the body to apply an angular impulse to, or `null` to indicate the root body
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddForceAtLocation(System_Numerics_Vector3_System_Numerics_Vector3_string_bool)_localSpace'></a>
`localSpace` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, applies force in local space instead of world space
  
