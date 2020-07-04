### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](./PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.GetSquaredDistanceToCollision(System.Numerics.Vector3, float, System.Numerics.Vector3) Method
Retrieves squared distance to closest collision  
```csharp
public bool GetSquaredDistanceToCollision(in System.Numerics.Vector3 point, ref float squaredDistance, ref System.Numerics.Vector3 closestPointOnCollision);
```
#### Parameters
<a name='UnrealEngine-Framework-PrimitiveComponent-GetSquaredDistanceToCollision(System-Numerics-Vector3_float_System-Numerics-Vector3)-point'></a>
`point` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-GetSquaredDistanceToCollision(System-Numerics-Vector3_float_System-Numerics-Vector3)-squaredDistance'></a>
`squaredDistance` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
  
  
<a name='UnrealEngine-Framework-PrimitiveComponent-GetSquaredDistanceToCollision(System-Numerics-Vector3_float_System-Numerics-Vector3)-closestPointOnCollision'></a>
`closestPointOnCollision` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if a distance to the body was found and [squaredDistance](#UnrealEngine-Framework-PrimitiveComponent-GetSquaredDistanceToCollision(System-Numerics-Vector3_float_System-Numerics-Vector3)-squaredDistance 'UnrealEngine.Framework.PrimitiveComponent.GetSquaredDistanceToCollision(System.Numerics.Vector3, float, System.Numerics.Vector3).squaredDistance') has been populated  
