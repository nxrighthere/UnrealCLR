### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.AddRadialImpulse(Vector3, float, float, bool, bool) Method
Adds an impulse to all rigid bodies in the component, originating from the supplied world-space location  
```csharp
public void AddRadialImpulse(in System.Numerics.Vector3 origin, float radius, float strength, bool linearFalloff=false, bool accelerationChange=false);
```
#### Parameters
<a name='UnrealEngine_Framework_PrimitiveComponent_AddRadialImpulse(System_Numerics_Vector3_float_float_bool_bool)_origin'></a>
`origin` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Origin of the impulse in world space
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddRadialImpulse(System_Numerics_Vector3_float_float_bool_bool)_radius'></a>
`radius` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Radius within which to apply the impulse
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddRadialImpulse(System_Numerics_Vector3_float_float_bool_bool)_strength'></a>
`strength` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Strength of the impulse to apply
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddRadialImpulse(System_Numerics_Vector3_float_float_bool_bool)_linearFalloff'></a>
`linearFalloff` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, the force will lose its strength linearly
  
<a name='UnrealEngine_Framework_PrimitiveComponent_AddRadialImpulse(System_Numerics_Vector3_float_float_bool_bool)_accelerationChange'></a>
`accelerationChange` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, [strength](PrimitiveComponent_AddRadialImpulse(Vector3_float_float_bool_bool).md#UnrealEngine_Framework_PrimitiveComponent_AddRadialImpulse(System_Numerics_Vector3_float_float_bool_bool)_strength 'UnrealEngine.Framework.PrimitiveComponent.AddRadialImpulse(System.Numerics.Vector3, float, float, bool, bool).strength') is taken as a change in acceleration instead of a physical force (the mass will have no effect)
  
