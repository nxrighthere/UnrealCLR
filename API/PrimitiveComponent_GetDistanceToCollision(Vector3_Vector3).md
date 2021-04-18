### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.GetDistanceToCollision(Vector3, Vector3) Method
Retrieves distance to closest collision  
```csharp
public float GetDistanceToCollision(in System.Numerics.Vector3 point, ref System.Numerics.Vector3 closestPointOnCollision);
```
#### Parameters
<a name='UnrealEngine_Framework_PrimitiveComponent_GetDistanceToCollision(System_Numerics_Vector3_System_Numerics_Vector3)_point'></a>
`point` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
<a name='UnrealEngine_Framework_PrimitiveComponent_GetDistanceToCollision(System_Numerics_Vector3_System_Numerics_Vector3)_closestPointOnCollision'></a>
`closestPointOnCollision` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
More than 0.0f if successful, equals to 0.0f if a point is inside the geometry, less than 0.0f if the primitive does not have collision or if the geometry not supported
