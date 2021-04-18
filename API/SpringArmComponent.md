### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## SpringArmComponent Class
A component that maintains its children at a fixed distance from the parent, but will retract the children if there is a collision, and spring back when there is no collision  
```csharp
public class SpringArmComponent : UnrealEngine.Framework.SceneComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; SpringArmComponent  
### Constructors

***
[SpringArmComponent(Actor, string, bool, Blueprint)](SpringArmComponent_SpringArmComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.SpringArmComponent.SpringArmComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[CameraLagMaxDistance](SpringArmComponent_CameraLagMaxDistance.md 'UnrealEngine.Framework.SpringArmComponent.CameraLagMaxDistance')

Gets or sets a max distance the camera target may lag behind the current location  

***
[CameraLagMaxTimeStep](SpringArmComponent_CameraLagMaxTimeStep.md 'UnrealEngine.Framework.SpringArmComponent.CameraLagMaxTimeStep')

Gets or sets a max time step used when sub-stepping camera lag  

***
[CameraLagSubstepping](SpringArmComponent_CameraLagSubstepping.md 'UnrealEngine.Framework.SpringArmComponent.CameraLagSubstepping')

Gets or sets whether the sub-step camera damping so that it handles fluctuating frame rates well  

***
[CameraPositionLag](SpringArmComponent_CameraPositionLag.md 'UnrealEngine.Framework.SpringArmComponent.CameraPositionLag')

Gets or sets whether the camera lags behind target position to smooth its movement  

***
[CameraPositionLagSpeed](SpringArmComponent_CameraPositionLagSpeed.md 'UnrealEngine.Framework.SpringArmComponent.CameraPositionLagSpeed')

Gets or sets how quickly the camera reaches a target position  

***
[CameraRotationLag](SpringArmComponent_CameraRotationLag.md 'UnrealEngine.Framework.SpringArmComponent.CameraRotationLag')

Gets or sets whether the camera lags behind target rotation to smooth its movement  

***
[CameraRotationLagSpeed](SpringArmComponent_CameraRotationLagSpeed.md 'UnrealEngine.Framework.SpringArmComponent.CameraRotationLagSpeed')

Gets or sets how quickly еру camera reaches a target rotation  

***
[CollisionTest](SpringArmComponent_CollisionTest.md 'UnrealEngine.Framework.SpringArmComponent.CollisionTest')

Gets or sets whether the collision test is enabled using [ProbeChannel](SpringArmComponent_ProbeChannel.md 'UnrealEngine.Framework.SpringArmComponent.ProbeChannel') and [ProbeSize](SpringArmComponent_ProbeSize.md 'UnrealEngine.Framework.SpringArmComponent.ProbeSize') to prevent camera clipping into level  

***
[DrawDebugLagMarkers](SpringArmComponent_DrawDebugLagMarkers.md 'UnrealEngine.Framework.SpringArmComponent.DrawDebugLagMarkers')

Gets or sets whether draw markers at the camera target (in green) and the lagged position (in yellow) if the camera location lag is enabled  

***
[InheritPitch](SpringArmComponent_InheritPitch.md 'UnrealEngine.Framework.SpringArmComponent.InheritPitch')

Gets or sets whether the component should inherit pitch from the parent component, has no effect if using absolute rotation  

***
[InheritRoll](SpringArmComponent_InheritRoll.md 'UnrealEngine.Framework.SpringArmComponent.InheritRoll')

Gets or sets whether the component should inherit roll from the parent component, has no effect if using absolute rotation  

***
[InheritYaw](SpringArmComponent_InheritYaw.md 'UnrealEngine.Framework.SpringArmComponent.InheritYaw')

Gets or sets whether the component should inherit yaw from the parent component, has no effect if using absolute rotation  

***
[IsCollisionFixApplied](SpringArmComponent_IsCollisionFixApplied.md 'UnrealEngine.Framework.SpringArmComponent.IsCollisionFixApplied')

Returns `true` if the collision test displacement being applied  

***
[ProbeChannel](SpringArmComponent_ProbeChannel.md 'UnrealEngine.Framework.SpringArmComponent.ProbeChannel')

Gets or sets the collision channel of the query probe ([Camera](CollisionChannel.md#UnrealEngine_Framework_CollisionChannel_Camera 'UnrealEngine.Framework.CollisionChannel.Camera') by default)  

***
[ProbeSize](SpringArmComponent_ProbeSize.md 'UnrealEngine.Framework.SpringArmComponent.ProbeSize')

Gets or sets how big should be the query probe sphere  

***
[TargetArmLength](SpringArmComponent_TargetArmLength.md 'UnrealEngine.Framework.SpringArmComponent.TargetArmLength')

Gets or sets the natural length of the spring arm when there are no collisions  

***
[UsePawnControlRotation](SpringArmComponent_UsePawnControlRotation.md 'UnrealEngine.Framework.SpringArmComponent.UsePawnControlRotation')

Gets or sets if the component should use the view/control rotation of the pawn  
### Methods

***
[GetDesiredRotation()](SpringArmComponent_GetDesiredRotation().md 'UnrealEngine.Framework.SpringArmComponent.GetDesiredRotation()')

Returns the desired rotation for the spring arm, before the rotation constraints such as [InheritYaw](SpringArmComponent_InheritYaw.md 'UnrealEngine.Framework.SpringArmComponent.InheritYaw'), [InheritPitch](SpringArmComponent_InheritPitch.md 'UnrealEngine.Framework.SpringArmComponent.InheritPitch'), or [InheritRoll](SpringArmComponent_InheritRoll.md 'UnrealEngine.Framework.SpringArmComponent.InheritRoll') are enforced  

***
[GetDesiredRotation(Quaternion)](SpringArmComponent_GetDesiredRotation(Quaternion).md 'UnrealEngine.Framework.SpringArmComponent.GetDesiredRotation(System.Numerics.Quaternion)')

Retrieves the desired rotation for the spring arm, before the rotation constraints such as [InheritYaw](SpringArmComponent_InheritYaw.md 'UnrealEngine.Framework.SpringArmComponent.InheritYaw'), [InheritPitch](SpringArmComponent_InheritPitch.md 'UnrealEngine.Framework.SpringArmComponent.InheritPitch'), or [InheritRoll](SpringArmComponent_InheritRoll.md 'UnrealEngine.Framework.SpringArmComponent.InheritRoll') are enforced  

***
[GetSocketOffset()](SpringArmComponent_GetSocketOffset().md 'UnrealEngine.Framework.SpringArmComponent.GetSocketOffset()')

Returns offset at the end of the spring arm, can be used instead of the relative offset of the attached component to ensure the line trace works as desired  

***
[GetSocketOffset(Vector3)](SpringArmComponent_GetSocketOffset(Vector3).md 'UnrealEngine.Framework.SpringArmComponent.GetSocketOffset(System.Numerics.Vector3)')

Retrieves offset at the end of the spring arm, can be used instead of the relative offset of the attached component to ensure the line trace works as desired  

***
[GetTargetOffset()](SpringArmComponent_GetTargetOffset().md 'UnrealEngine.Framework.SpringArmComponent.GetTargetOffset()')

Returns offset at the start of the spring arm in world space  

***
[GetTargetOffset(Vector3)](SpringArmComponent_GetTargetOffset(Vector3).md 'UnrealEngine.Framework.SpringArmComponent.GetTargetOffset(System.Numerics.Vector3)')

Retrieves offset at the start of the spring arm in world space  

***
[GetTargetRotation()](SpringArmComponent_GetTargetRotation().md 'UnrealEngine.Framework.SpringArmComponent.GetTargetRotation()')

Returns the target inherited rotation  

***
[GetTargetRotation(Quaternion)](SpringArmComponent_GetTargetRotation(Quaternion).md 'UnrealEngine.Framework.SpringArmComponent.GetTargetRotation(System.Numerics.Quaternion)')

Retrieves the target inherited rotation  

***
[GetUnfixedCameraPosition()](SpringArmComponent_GetUnfixedCameraPosition().md 'UnrealEngine.Framework.SpringArmComponent.GetUnfixedCameraPosition()')

Returns the unfixed camera position  

***
[GetUnfixedCameraPosition(Vector3)](SpringArmComponent_GetUnfixedCameraPosition(Vector3).md 'UnrealEngine.Framework.SpringArmComponent.GetUnfixedCameraPosition(System.Numerics.Vector3)')

Retrieves the unfixed camera position  

***
[SetSocketOffset(Vector3)](SpringArmComponent_SetSocketOffset(Vector3).md 'UnrealEngine.Framework.SpringArmComponent.SetSocketOffset(System.Numerics.Vector3)')

Sets offset at the end of the spring arm, can be used instead of the relative offset of the attached component to ensure the line trace works as desired  

***
[SetTargetOffset(Vector3)](SpringArmComponent_SetTargetOffset(Vector3).md 'UnrealEngine.Framework.SpringArmComponent.SetTargetOffset(System.Numerics.Vector3)')

Sets offset at the start of the spring arm in world space  
