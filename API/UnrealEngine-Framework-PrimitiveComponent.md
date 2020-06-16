### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## PrimitiveComponent Class
An abstract component that contains or generates some sort of geometry, generally to be rendered or used as collision data  
```csharp
public abstract class PrimitiveComponent : SceneComponent
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](./UnrealEngine-Framework-ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](./UnrealEngine-Framework-SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; PrimitiveComponent  

Derived  
&#8627; [CameraComponent](./UnrealEngine-Framework-CameraComponent.md 'UnrealEngine.Framework.CameraComponent')  
&#8627; [MeshComponent](./UnrealEngine-Framework-MeshComponent.md 'UnrealEngine.Framework.MeshComponent')  
&#8627; [MotionControllerComponent](./UnrealEngine-Framework-MotionControllerComponent.md 'UnrealEngine.Framework.MotionControllerComponent')  
&#8627; [ShapeComponent](./UnrealEngine-Framework-ShapeComponent.md 'UnrealEngine.Framework.ShapeComponent')  
### Properties
- [AngularDamping](./UnrealEngine-Framework-PrimitiveComponent-AngularDamping.md 'UnrealEngine.Framework.PrimitiveComponent.AngularDamping')
- [CastShadow](./UnrealEngine-Framework-PrimitiveComponent-CastShadow.md 'UnrealEngine.Framework.PrimitiveComponent.CastShadow')
- [LinearDamping](./UnrealEngine-Framework-PrimitiveComponent-LinearDamping.md 'UnrealEngine.Framework.PrimitiveComponent.LinearDamping')
- [Mass](./UnrealEngine-Framework-PrimitiveComponent-Mass.md 'UnrealEngine.Framework.PrimitiveComponent.Mass')
- [MaterialsNumber](./UnrealEngine-Framework-PrimitiveComponent-MaterialsNumber.md 'UnrealEngine.Framework.PrimitiveComponent.MaterialsNumber')
- [OnlyOwnerSee](./UnrealEngine-Framework-PrimitiveComponent-OnlyOwnerSee.md 'UnrealEngine.Framework.PrimitiveComponent.OnlyOwnerSee')
- [OwnerNoSee](./UnrealEngine-Framework-PrimitiveComponent-OwnerNoSee.md 'UnrealEngine.Framework.PrimitiveComponent.OwnerNoSee')
### Methods
- [AddAngularImpulseInDegrees(System.Numerics.Vector3, string, bool)](./UnrealEngine-Framework-PrimitiveComponent-AddAngularImpulseInDegrees(System-Numerics-Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddAngularImpulseInDegrees(System.Numerics.Vector3, string, bool)')
- [AddAngularImpulseInRadians(System.Numerics.Vector3, string, bool)](./UnrealEngine-Framework-PrimitiveComponent-AddAngularImpulseInRadians(System-Numerics-Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddAngularImpulseInRadians(System.Numerics.Vector3, string, bool)')
- [AddForce(System.Numerics.Vector3, string, bool)](./UnrealEngine-Framework-PrimitiveComponent-AddForce(System-Numerics-Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddForce(System.Numerics.Vector3, string, bool)')
- [AddForceAtLocation(System.Numerics.Vector3, System.Numerics.Vector3, string, bool)](./UnrealEngine-Framework-PrimitiveComponent-AddForceAtLocation(System-Numerics-Vector3_System-Numerics-Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddForceAtLocation(System.Numerics.Vector3, System.Numerics.Vector3, string, bool)')
- [AddImpulse(System.Numerics.Vector3, string, bool)](./UnrealEngine-Framework-PrimitiveComponent-AddImpulse(System-Numerics-Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddImpulse(System.Numerics.Vector3, string, bool)')
- [AddImpulseAtLocation(System.Numerics.Vector3, System.Numerics.Vector3, string)](./UnrealEngine-Framework-PrimitiveComponent-AddImpulseAtLocation(System-Numerics-Vector3_System-Numerics-Vector3_string).md 'UnrealEngine.Framework.PrimitiveComponent.AddImpulseAtLocation(System.Numerics.Vector3, System.Numerics.Vector3, string)')
- [AddRadialForce(System.Numerics.Vector3, float, float, bool, bool)](./UnrealEngine-Framework-PrimitiveComponent-AddRadialForce(System-Numerics-Vector3_float_float_bool_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddRadialForce(System.Numerics.Vector3, float, float, bool, bool)')
- [AddRadialImpulse(System.Numerics.Vector3, float, float, bool, bool)](./UnrealEngine-Framework-PrimitiveComponent-AddRadialImpulse(System-Numerics-Vector3_float_float_bool_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddRadialImpulse(System.Numerics.Vector3, float, float, bool, bool)')
- [AddTorqueInDegrees(System.Numerics.Vector3, string, bool)](./UnrealEngine-Framework-PrimitiveComponent-AddTorqueInDegrees(System-Numerics-Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddTorqueInDegrees(System.Numerics.Vector3, string, bool)')
- [AddTorqueInRadians(System.Numerics.Vector3, string, bool)](./UnrealEngine-Framework-PrimitiveComponent-AddTorqueInRadians(System-Numerics-Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddTorqueInRadians(System.Numerics.Vector3, string, bool)')
- [CreateAndSetMaterialInstanceDynamic(int)](./UnrealEngine-Framework-PrimitiveComponent-CreateAndSetMaterialInstanceDynamic(int).md 'UnrealEngine.Framework.PrimitiveComponent.CreateAndSetMaterialInstanceDynamic(int)')
- [GetDistanceToCollision(System.Numerics.Vector3, System.Numerics.Vector3)](./UnrealEngine-Framework-PrimitiveComponent-GetDistanceToCollision(System-Numerics-Vector3_System-Numerics-Vector3).md 'UnrealEngine.Framework.PrimitiveComponent.GetDistanceToCollision(System.Numerics.Vector3, System.Numerics.Vector3)')
- [GetMaterial(int)](./UnrealEngine-Framework-PrimitiveComponent-GetMaterial(int).md 'UnrealEngine.Framework.PrimitiveComponent.GetMaterial(int)')
- [GetSquaredDistanceToCollision(System.Numerics.Vector3, float, System.Numerics.Vector3)](./UnrealEngine-Framework-PrimitiveComponent-GetSquaredDistanceToCollision(System-Numerics-Vector3_float_System-Numerics-Vector3).md 'UnrealEngine.Framework.PrimitiveComponent.GetSquaredDistanceToCollision(System.Numerics.Vector3, float, System.Numerics.Vector3)')
- [SetMass(float, string)](./UnrealEngine-Framework-PrimitiveComponent-SetMass(float_string).md 'UnrealEngine.Framework.PrimitiveComponent.SetMass(float, string)')
- [SetMaterial(int, UnrealEngine.Framework.MaterialInterface)](./UnrealEngine-Framework-PrimitiveComponent-SetMaterial(int_UnrealEngine-Framework-MaterialInterface).md 'UnrealEngine.Framework.PrimitiveComponent.SetMaterial(int, UnrealEngine.Framework.MaterialInterface)')
- [SetSimulatePhysics(bool)](./UnrealEngine-Framework-PrimitiveComponent-SetSimulatePhysics(bool).md 'UnrealEngine.Framework.PrimitiveComponent.SetSimulatePhysics(bool)')
