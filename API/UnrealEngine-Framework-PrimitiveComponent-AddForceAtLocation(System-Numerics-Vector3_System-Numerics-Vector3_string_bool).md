### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](./UnrealEngine-Framework-PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.AddForceAtLocation(System.Numerics.Vector3, System.Numerics.Vector3, string, bool) Method
Adds a force to a rigid body at a specific location, optionally in local space  
```csharp
public void AddForceAtLocation(in System.Numerics.Vector3 force, in System.Numerics.Vector3 location, string boneName=null, bool localSpace=false);
```
#### Parameters
<a name='UnrealEngine-Framework-PrimitiveComponent-AddForceAtLocation(System-Numerics-Vector3_System-Numerics-Vector3_string_bool)-force'></a>
`force` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Force vector to apply, magnitude indicates strength of force  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-AddForceAtLocation(System-Numerics-Vector3_System-Numerics-Vector3_string_bool)-location'></a>
`location` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
A point in world or local space to apply the force at  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-AddForceAtLocation(System-Numerics-Vector3_System-Numerics-Vector3_string_bool)-boneName'></a>
`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
If applied to [SkeletalMeshComponent](./UnrealEngine-Framework-SkeletalMeshComponent.md 'UnrealEngine.Framework.SkeletalMeshComponent'), the name of the body to apply an angular impulse to, or `null` to indicate the root body  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-AddForceAtLocation(System-Numerics-Vector3_System-Numerics-Vector3_string_bool)-localSpace'></a>
`localSpace` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, applies force in local space instead of world space  
  
