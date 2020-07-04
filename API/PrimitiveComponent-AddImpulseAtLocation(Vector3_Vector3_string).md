### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](./PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.AddImpulseAtLocation(System.Numerics.Vector3, System.Numerics.Vector3, string) Method
Adds an impulse to a rigid body at a specific location  
```csharp
public void AddImpulseAtLocation(in System.Numerics.Vector3 impulse, in System.Numerics.Vector3 location, string boneName=null);
```
#### Parameters
<a name='UnrealEngine-Framework-PrimitiveComponent-AddImpulseAtLocation(System-Numerics-Vector3_System-Numerics-Vector3_string)-impulse'></a>
`impulse` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Magnitude and direction of the impulse to apply  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-AddImpulseAtLocation(System-Numerics-Vector3_System-Numerics-Vector3_string)-location'></a>
`location` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
A point in world space to apply the impulse at  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-AddImpulseAtLocation(System-Numerics-Vector3_System-Numerics-Vector3_string)-boneName'></a>
`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
If applied to [SkeletalMeshComponent](./SkeletalMeshComponent.md 'UnrealEngine.Framework.SkeletalMeshComponent'), the name of the body to apply an angular impulse to, or `null` to indicate the root body  
  
