### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.AddImpulseAtLocation(Vector3, Vector3, string) Method
Adds an impulse to a rigid body at a specific location  
```csharp
public void AddImpulseAtLocation(in System.Numerics.Vector3 impulse, in System.Numerics.Vector3 location, string boneName=null);
```
#### Parameters
<a name='UnrealEngine_Framework_PrimitiveComponent_AddImpulseAtLocation(System_Numerics_Vector3_System_Numerics_Vector3_string)_impulse'></a>
`impulse` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Magnitude and direction of the impulse to apply
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddImpulseAtLocation(System_Numerics_Vector3_System_Numerics_Vector3_string)_location'></a>
`location` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
A point in world space to apply the impulse at
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddImpulseAtLocation(System_Numerics_Vector3_System_Numerics_Vector3_string)_boneName'></a>
`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
If applied to [SkeletalMeshComponent](SkeletalMeshComponent.md 'UnrealEngine.Framework.SkeletalMeshComponent'), the name of the body to apply an angular impulse to, or `null` to indicate the root body
  
