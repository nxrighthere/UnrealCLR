### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](./PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.AddImpulse(System.Numerics.Vector3, string, bool) Method
Adds an impulse to a rigid body  
```csharp
public void AddImpulse(in System.Numerics.Vector3 impulse, string boneName=null, bool velocityChange=false);
```
#### Parameters
<a name='UnrealEngine-Framework-PrimitiveComponent-AddImpulse(System-Numerics-Vector3_string_bool)-impulse'></a>
`impulse` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Magnitude and direction of the impulse to apply  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-AddImpulse(System-Numerics-Vector3_string_bool)-boneName'></a>
`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
If applied to [SkeletalMeshComponent](./SkeletalMeshComponent.md 'UnrealEngine.Framework.SkeletalMeshComponent'), the name of the body to apply an angular impulse to, or `null` to indicate the root body  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-AddImpulse(System-Numerics-Vector3_string_bool)-velocityChange'></a>
`velocityChange` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, [impulse](#UnrealEngine-Framework-PrimitiveComponent-AddImpulse(System-Numerics-Vector3_string_bool)-impulse 'UnrealEngine.Framework.PrimitiveComponent.AddImpulse(System.Numerics.Vector3, string, bool).impulse') is taken as a change in velocity instead of a physical force (the mass will have no effect)  
  
