### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## SceneComponent Class
The base class of components that can be transformed or attached, but has no rendering or collision capabilities  
```csharp
public class SceneComponent : ActorComponent
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](./UnrealEngine-Framework-ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; SceneComponent  

Derived  
&#8627; [AudioComponent](./UnrealEngine-Framework-AudioComponent.md 'UnrealEngine.Framework.AudioComponent')  
&#8627; [LightComponentBase](./UnrealEngine-Framework-LightComponentBase.md 'UnrealEngine.Framework.LightComponentBase')  
&#8627; [PrimitiveComponent](./UnrealEngine-Framework-PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')  
### Constructors
- [SceneComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)](./UnrealEngine-Framework-SceneComponent-SceneComponent(UnrealEngine-Framework-Actor_string_bool_UnrealEngine-Framework-Blueprint).md 'UnrealEngine.Framework.SceneComponent.SceneComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')
### Methods
- [AddLocalOffset(System.Numerics.Vector3)](./UnrealEngine-Framework-SceneComponent-AddLocalOffset(System-Numerics-Vector3).md 'UnrealEngine.Framework.SceneComponent.AddLocalOffset(System.Numerics.Vector3)')
- [AddLocalRotation(System.Numerics.Quaternion)](./UnrealEngine-Framework-SceneComponent-AddLocalRotation(System-Numerics-Quaternion).md 'UnrealEngine.Framework.SceneComponent.AddLocalRotation(System.Numerics.Quaternion)')
- [AddLocalTransform(UnrealEngine.Framework.Transform)](./UnrealEngine-Framework-SceneComponent-AddLocalTransform(UnrealEngine-Framework-Transform).md 'UnrealEngine.Framework.SceneComponent.AddLocalTransform(UnrealEngine.Framework.Transform)')
- [AddRelativeLocation(System.Numerics.Vector3)](./UnrealEngine-Framework-SceneComponent-AddRelativeLocation(System-Numerics-Vector3).md 'UnrealEngine.Framework.SceneComponent.AddRelativeLocation(System.Numerics.Vector3)')
- [AddRelativeRotation(System.Numerics.Quaternion)](./UnrealEngine-Framework-SceneComponent-AddRelativeRotation(System-Numerics-Quaternion).md 'UnrealEngine.Framework.SceneComponent.AddRelativeRotation(System.Numerics.Quaternion)')
- [AddWorldOffset(System.Numerics.Vector3)](./UnrealEngine-Framework-SceneComponent-AddWorldOffset(System-Numerics-Vector3).md 'UnrealEngine.Framework.SceneComponent.AddWorldOffset(System.Numerics.Vector3)')
- [AddWorldRotation(System.Numerics.Quaternion)](./UnrealEngine-Framework-SceneComponent-AddWorldRotation(System-Numerics-Quaternion).md 'UnrealEngine.Framework.SceneComponent.AddWorldRotation(System.Numerics.Quaternion)')
- [AddWorldTransform(UnrealEngine.Framework.Transform)](./UnrealEngine-Framework-SceneComponent-AddWorldTransform(UnrealEngine-Framework-Transform).md 'UnrealEngine.Framework.SceneComponent.AddWorldTransform(UnrealEngine.Framework.Transform)')
- [AttachToComponent(UnrealEngine.Framework.SceneComponent, UnrealEngine.Framework.AttachmentTransformRule, string)](./UnrealEngine-Framework-SceneComponent-AttachToComponent(UnrealEngine-Framework-SceneComponent_UnrealEngine-Framework-AttachmentTransformRule_string).md 'UnrealEngine.Framework.SceneComponent.AttachToComponent(UnrealEngine.Framework.SceneComponent, UnrealEngine.Framework.AttachmentTransformRule, string)')
- [GetForwardVector(System.Numerics.Vector3)](./UnrealEngine-Framework-SceneComponent-GetForwardVector(System-Numerics-Vector3).md 'UnrealEngine.Framework.SceneComponent.GetForwardVector(System.Numerics.Vector3)')
- [GetLocation(System.Numerics.Vector3)](./UnrealEngine-Framework-SceneComponent-GetLocation(System-Numerics-Vector3).md 'UnrealEngine.Framework.SceneComponent.GetLocation(System.Numerics.Vector3)')
- [GetRightVector(System.Numerics.Vector3)](./UnrealEngine-Framework-SceneComponent-GetRightVector(System-Numerics-Vector3).md 'UnrealEngine.Framework.SceneComponent.GetRightVector(System.Numerics.Vector3)')
- [GetRotation(System.Numerics.Quaternion)](./UnrealEngine-Framework-SceneComponent-GetRotation(System-Numerics-Quaternion).md 'UnrealEngine.Framework.SceneComponent.GetRotation(System.Numerics.Quaternion)')
- [GetScale(System.Numerics.Vector3)](./UnrealEngine-Framework-SceneComponent-GetScale(System-Numerics-Vector3).md 'UnrealEngine.Framework.SceneComponent.GetScale(System.Numerics.Vector3)')
- [GetTransform(UnrealEngine.Framework.Transform)](./UnrealEngine-Framework-SceneComponent-GetTransform(UnrealEngine-Framework-Transform).md 'UnrealEngine.Framework.SceneComponent.GetTransform(UnrealEngine.Framework.Transform)')
- [GetUpVector(System.Numerics.Vector3)](./UnrealEngine-Framework-SceneComponent-GetUpVector(System-Numerics-Vector3).md 'UnrealEngine.Framework.SceneComponent.GetUpVector(System.Numerics.Vector3)')
- [GetVelocity(System.Numerics.Vector3)](./UnrealEngine-Framework-SceneComponent-GetVelocity(System-Numerics-Vector3).md 'UnrealEngine.Framework.SceneComponent.GetVelocity(System.Numerics.Vector3)')
- [IsAttachedToActor(UnrealEngine.Framework.Actor)](./UnrealEngine-Framework-SceneComponent-IsAttachedToActor(UnrealEngine-Framework-Actor).md 'UnrealEngine.Framework.SceneComponent.IsAttachedToActor(UnrealEngine.Framework.Actor)')
- [IsAttachedToComponent(UnrealEngine.Framework.SceneComponent)](./UnrealEngine-Framework-SceneComponent-IsAttachedToComponent(UnrealEngine-Framework-SceneComponent).md 'UnrealEngine.Framework.SceneComponent.IsAttachedToComponent(UnrealEngine.Framework.SceneComponent)')
- [SetMobility(UnrealEngine.Framework.ComponentMobility)](./UnrealEngine-Framework-SceneComponent-SetMobility(UnrealEngine-Framework-ComponentMobility).md 'UnrealEngine.Framework.SceneComponent.SetMobility(UnrealEngine.Framework.ComponentMobility)')
- [SetRelativeLocation(System.Numerics.Vector3)](./UnrealEngine-Framework-SceneComponent-SetRelativeLocation(System-Numerics-Vector3).md 'UnrealEngine.Framework.SceneComponent.SetRelativeLocation(System.Numerics.Vector3)')
- [SetRelativeRotation(System.Numerics.Quaternion)](./UnrealEngine-Framework-SceneComponent-SetRelativeRotation(System-Numerics-Quaternion).md 'UnrealEngine.Framework.SceneComponent.SetRelativeRotation(System.Numerics.Quaternion)')
- [SetRelativeTransform(UnrealEngine.Framework.Transform)](./UnrealEngine-Framework-SceneComponent-SetRelativeTransform(UnrealEngine-Framework-Transform).md 'UnrealEngine.Framework.SceneComponent.SetRelativeTransform(UnrealEngine.Framework.Transform)')
- [SetWorldLocation(System.Numerics.Vector3)](./UnrealEngine-Framework-SceneComponent-SetWorldLocation(System-Numerics-Vector3).md 'UnrealEngine.Framework.SceneComponent.SetWorldLocation(System.Numerics.Vector3)')
- [SetWorldRotation(System.Numerics.Quaternion)](./UnrealEngine-Framework-SceneComponent-SetWorldRotation(System-Numerics-Quaternion).md 'UnrealEngine.Framework.SceneComponent.SetWorldRotation(System.Numerics.Quaternion)')
- [SetWorldTransform(UnrealEngine.Framework.Transform)](./UnrealEngine-Framework-SceneComponent-SetWorldTransform(UnrealEngine-Framework-Transform).md 'UnrealEngine.Framework.SceneComponent.SetWorldTransform(UnrealEngine.Framework.Transform)')
- [UpdateToWorld(UnrealEngine.Framework.TeleportType, UnrealEngine.Framework.UpdateTransformFlags)](./UnrealEngine-Framework-SceneComponent-UpdateToWorld(UnrealEngine-Framework-TeleportType_UnrealEngine-Framework-UpdateTransformFlags).md 'UnrealEngine.Framework.SceneComponent.UpdateToWorld(UnrealEngine.Framework.TeleportType, UnrealEngine.Framework.UpdateTransformFlags)')
