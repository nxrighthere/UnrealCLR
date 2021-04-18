### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.GetSquaredDistanceToCollision(Vector3, float, Vector3) Method
Retrieves squared distance to closest collision  
```csharp
public bool GetSquaredDistanceToCollision(in System.Numerics.Vector3 point, ref float squaredDistance, ref System.Numerics.Vector3 closestPointOnCollision);
```
#### Parameters
<a name='UnrealEngine_Framework_PrimitiveComponent_GetSquaredDistanceToCollision(System_Numerics_Vector3_float_System_Numerics_Vector3)_point'></a>
`point` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
<a name='UnrealEngine_Framework_PrimitiveComponent_GetSquaredDistanceToCollision(System_Numerics_Vector3_float_System_Numerics_Vector3)_squaredDistance'></a>
`squaredDistance` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
  
<a name='UnrealEngine_Framework_PrimitiveComponent_GetSquaredDistanceToCollision(System_Numerics_Vector3_float_System_Numerics_Vector3)_closestPointOnCollision'></a>
`closestPointOnCollision` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if a distance to the body was found and [squaredDistance](PrimitiveComponent_GetSquaredDistanceToCollision(Vector3_float_Vector3).md#UnrealEngine_Framework_PrimitiveComponent_GetSquaredDistanceToCollision(System_Numerics_Vector3_float_System_Numerics_Vector3)_squaredDistance 'UnrealEngine.Framework.PrimitiveComponent.GetSquaredDistanceToCollision(System.Numerics.Vector3, float, System.Numerics.Vector3).squaredDistance') has been populated
