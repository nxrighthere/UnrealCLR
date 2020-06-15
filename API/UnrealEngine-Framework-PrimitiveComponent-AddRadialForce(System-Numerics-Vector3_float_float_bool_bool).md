### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](./UnrealEngine-Framework-PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.AddRadialForce(System.Numerics.Vector3, float, float, bool, bool) Method
Adds a force to all rigid bodies in the component, originating from the supplied world-space location  
```csharp
public void AddRadialForce(in System.Numerics.Vector3 origin, float radius, float strength, bool linearFalloff=false, bool accelerationChange=false);
```
#### Parameters
<a name='UnrealEngine-Framework-PrimitiveComponent-AddRadialForce(System-Numerics-Vector3_float_float_bool_bool)-origin'></a>
`origin` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Origin of the force in world space  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-AddRadialForce(System-Numerics-Vector3_float_float_bool_bool)-radius'></a>
`radius` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Radius within which to apply the force  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-AddRadialForce(System-Numerics-Vector3_float_float_bool_bool)-strength'></a>
`strength` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Strength of the force to apply  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-AddRadialForce(System-Numerics-Vector3_float_float_bool_bool)-linearFalloff'></a>
`linearFalloff` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, the force will lose its strength linearly  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-AddRadialForce(System-Numerics-Vector3_float_float_bool_bool)-accelerationChange'></a>
`accelerationChange` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, [strength](#UnrealEngine-Framework-PrimitiveComponent-AddRadialForce(System-Numerics-Vector3_float_float_bool_bool)-strength 'UnrealEngine.Framework.PrimitiveComponent.AddRadialForce(System.Numerics.Vector3, float, float, bool, bool).strength') is taken as a change in acceleration instead of a physical force (the mass will have no effect)  
  
