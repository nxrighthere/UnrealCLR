### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## MovementComponent Class
An abstract component that defines functionality for moving a [PrimitiveComponent](./PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')  
```csharp
public abstract class MovementComponent : UnrealEngine.Framework.ActorComponent
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](./ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; MovementComponent  
### Properties
- [ConstrainToPlane](./MovementComponent-ConstrainToPlane.md 'UnrealEngine.Framework.MovementComponent.ConstrainToPlane')
- [PlaneConstraint](./MovementComponent-PlaneConstraint.md 'UnrealEngine.Framework.MovementComponent.PlaneConstraint')
- [SnapToPlaneAtStart](./MovementComponent-SnapToPlaneAtStart.md 'UnrealEngine.Framework.MovementComponent.SnapToPlaneAtStart')
- [UpdateOnlyIfRendered](./MovementComponent-UpdateOnlyIfRendered.md 'UnrealEngine.Framework.MovementComponent.UpdateOnlyIfRendered')
### Methods
- [ConstrainDirectionToPlane(System.Numerics.Vector3, System.Numerics.Vector3)](./MovementComponent-ConstrainDirectionToPlane(Vector3_Vector3).md 'UnrealEngine.Framework.MovementComponent.ConstrainDirectionToPlane(System.Numerics.Vector3, System.Numerics.Vector3)')
- [ConstrainLocationToPlane(System.Numerics.Vector3, System.Numerics.Vector3)](./MovementComponent-ConstrainLocationToPlane(Vector3_Vector3).md 'UnrealEngine.Framework.MovementComponent.ConstrainLocationToPlane(System.Numerics.Vector3, System.Numerics.Vector3)')
- [ConstrainNormalToPlane(System.Numerics.Vector3, System.Numerics.Vector3)](./MovementComponent-ConstrainNormalToPlane(Vector3_Vector3).md 'UnrealEngine.Framework.MovementComponent.ConstrainNormalToPlane(System.Numerics.Vector3, System.Numerics.Vector3)')
- [GetGravity()](./MovementComponent-GetGravity().md 'UnrealEngine.Framework.MovementComponent.GetGravity()')
- [GetMaxSpeed()](./MovementComponent-GetMaxSpeed().md 'UnrealEngine.Framework.MovementComponent.GetMaxSpeed()')
- [GetPlaneConstraintNormal()](./MovementComponent-GetPlaneConstraintNormal().md 'UnrealEngine.Framework.MovementComponent.GetPlaneConstraintNormal()')
- [GetPlaneConstraintNormal(System.Numerics.Vector3)](./MovementComponent-GetPlaneConstraintNormal(Vector3).md 'UnrealEngine.Framework.MovementComponent.GetPlaneConstraintNormal(System.Numerics.Vector3)')
- [GetPlaneConstraintOrigin()](./MovementComponent-GetPlaneConstraintOrigin().md 'UnrealEngine.Framework.MovementComponent.GetPlaneConstraintOrigin()')
- [GetPlaneConstraintOrigin(System.Numerics.Vector3)](./MovementComponent-GetPlaneConstraintOrigin(Vector3).md 'UnrealEngine.Framework.MovementComponent.GetPlaneConstraintOrigin(System.Numerics.Vector3)')
- [GetVelocity()](./MovementComponent-GetVelocity().md 'UnrealEngine.Framework.MovementComponent.GetVelocity()')
- [GetVelocity(System.Numerics.Vector3)](./MovementComponent-GetVelocity(Vector3).md 'UnrealEngine.Framework.MovementComponent.GetVelocity(System.Numerics.Vector3)')
- [IsExceedingMaxSpeed(float)](./MovementComponent-IsExceedingMaxSpeed(float).md 'UnrealEngine.Framework.MovementComponent.IsExceedingMaxSpeed(float)')
- [IsInWater()](./MovementComponent-IsInWater().md 'UnrealEngine.Framework.MovementComponent.IsInWater()')
- [SetPlaneConstraintFromVectors(System.Numerics.Vector3, System.Numerics.Vector3)](./MovementComponent-SetPlaneConstraintFromVectors(Vector3_Vector3).md 'UnrealEngine.Framework.MovementComponent.SetPlaneConstraintFromVectors(System.Numerics.Vector3, System.Numerics.Vector3)')
- [SetPlaneConstraintNormal(System.Numerics.Vector3)](./MovementComponent-SetPlaneConstraintNormal(Vector3).md 'UnrealEngine.Framework.MovementComponent.SetPlaneConstraintNormal(System.Numerics.Vector3)')
- [SetPlaneConstraintOrigin(System.Numerics.Vector3)](./MovementComponent-SetPlaneConstraintOrigin(Vector3).md 'UnrealEngine.Framework.MovementComponent.SetPlaneConstraintOrigin(System.Numerics.Vector3)')
- [SetVelocity(System.Numerics.Vector3)](./MovementComponent-SetVelocity(Vector3).md 'UnrealEngine.Framework.MovementComponent.SetVelocity(System.Numerics.Vector3)')
- [StopMovement()](./MovementComponent-StopMovement().md 'UnrealEngine.Framework.MovementComponent.StopMovement()')
