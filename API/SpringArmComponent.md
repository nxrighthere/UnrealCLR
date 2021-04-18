### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## SpringArmComponent Class
A component that maintains its children at a fixed distance from the parent, but will retract the children if there is a collision, and spring back when there is no collision  
```csharp
public class SpringArmComponent : UnrealEngine.Framework.SceneComponent
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](./ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](./SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; SpringArmComponent  
### Constructors
- [SpringArmComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)](./SpringArmComponent-SpringArmComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.SpringArmComponent.SpringArmComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')
### Properties
- [CameraLagMaxDistance](./SpringArmComponent-CameraLagMaxDistance.md 'UnrealEngine.Framework.SpringArmComponent.CameraLagMaxDistance')
- [CameraLagMaxTimeStep](./SpringArmComponent-CameraLagMaxTimeStep.md 'UnrealEngine.Framework.SpringArmComponent.CameraLagMaxTimeStep')
- [CameraLagSubstepping](./SpringArmComponent-CameraLagSubstepping.md 'UnrealEngine.Framework.SpringArmComponent.CameraLagSubstepping')
- [CameraPositionLag](./SpringArmComponent-CameraPositionLag.md 'UnrealEngine.Framework.SpringArmComponent.CameraPositionLag')
- [CameraPositionLagSpeed](./SpringArmComponent-CameraPositionLagSpeed.md 'UnrealEngine.Framework.SpringArmComponent.CameraPositionLagSpeed')
- [CameraRotationLag](./SpringArmComponent-CameraRotationLag.md 'UnrealEngine.Framework.SpringArmComponent.CameraRotationLag')
- [CameraRotationLagSpeed](./SpringArmComponent-CameraRotationLagSpeed.md 'UnrealEngine.Framework.SpringArmComponent.CameraRotationLagSpeed')
- [CollisionTest](./SpringArmComponent-CollisionTest.md 'UnrealEngine.Framework.SpringArmComponent.CollisionTest')
- [DrawDebugLagMarkers](./SpringArmComponent-DrawDebugLagMarkers.md 'UnrealEngine.Framework.SpringArmComponent.DrawDebugLagMarkers')
- [InheritPitch](./SpringArmComponent-InheritPitch.md 'UnrealEngine.Framework.SpringArmComponent.InheritPitch')
- [InheritRoll](./SpringArmComponent-InheritRoll.md 'UnrealEngine.Framework.SpringArmComponent.InheritRoll')
- [InheritYaw](./SpringArmComponent-InheritYaw.md 'UnrealEngine.Framework.SpringArmComponent.InheritYaw')
- [IsCollisionFixApplied](./SpringArmComponent-IsCollisionFixApplied.md 'UnrealEngine.Framework.SpringArmComponent.IsCollisionFixApplied')
- [ProbeChannel](./SpringArmComponent-ProbeChannel.md 'UnrealEngine.Framework.SpringArmComponent.ProbeChannel')
- [ProbeSize](./SpringArmComponent-ProbeSize.md 'UnrealEngine.Framework.SpringArmComponent.ProbeSize')
- [TargetArmLength](./SpringArmComponent-TargetArmLength.md 'UnrealEngine.Framework.SpringArmComponent.TargetArmLength')
- [UsePawnControlRotation](./SpringArmComponent-UsePawnControlRotation.md 'UnrealEngine.Framework.SpringArmComponent.UsePawnControlRotation')
### Methods
- [GetDesiredRotation()](./SpringArmComponent-GetDesiredRotation().md 'UnrealEngine.Framework.SpringArmComponent.GetDesiredRotation()')
- [GetDesiredRotation(System.Numerics.Quaternion)](./SpringArmComponent-GetDesiredRotation(Quaternion).md 'UnrealEngine.Framework.SpringArmComponent.GetDesiredRotation(System.Numerics.Quaternion)')
- [GetSocketOffset()](./SpringArmComponent-GetSocketOffset().md 'UnrealEngine.Framework.SpringArmComponent.GetSocketOffset()')
- [GetSocketOffset(System.Numerics.Vector3)](./SpringArmComponent-GetSocketOffset(Vector3).md 'UnrealEngine.Framework.SpringArmComponent.GetSocketOffset(System.Numerics.Vector3)')
- [GetTargetOffset()](./SpringArmComponent-GetTargetOffset().md 'UnrealEngine.Framework.SpringArmComponent.GetTargetOffset()')
- [GetTargetOffset(System.Numerics.Vector3)](./SpringArmComponent-GetTargetOffset(Vector3).md 'UnrealEngine.Framework.SpringArmComponent.GetTargetOffset(System.Numerics.Vector3)')
- [GetTargetRotation()](./SpringArmComponent-GetTargetRotation().md 'UnrealEngine.Framework.SpringArmComponent.GetTargetRotation()')
- [GetTargetRotation(System.Numerics.Quaternion)](./SpringArmComponent-GetTargetRotation(Quaternion).md 'UnrealEngine.Framework.SpringArmComponent.GetTargetRotation(System.Numerics.Quaternion)')
- [GetUnfixedCameraPosition()](./SpringArmComponent-GetUnfixedCameraPosition().md 'UnrealEngine.Framework.SpringArmComponent.GetUnfixedCameraPosition()')
- [GetUnfixedCameraPosition(System.Numerics.Vector3)](./SpringArmComponent-GetUnfixedCameraPosition(Vector3).md 'UnrealEngine.Framework.SpringArmComponent.GetUnfixedCameraPosition(System.Numerics.Vector3)')
- [SetSocketOffset(System.Numerics.Vector3)](./SpringArmComponent-SetSocketOffset(Vector3).md 'UnrealEngine.Framework.SpringArmComponent.SetSocketOffset(System.Numerics.Vector3)')
- [SetTargetOffset(System.Numerics.Vector3)](./SpringArmComponent-SetTargetOffset(Vector3).md 'UnrealEngine.Framework.SpringArmComponent.SetTargetOffset(System.Numerics.Vector3)')
