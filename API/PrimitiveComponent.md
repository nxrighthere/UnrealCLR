### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## PrimitiveComponent Class
An abstract component that contains or generates some sort of geometry, generally to be rendered or used as collision data  
```csharp
public abstract class PrimitiveComponent : UnrealEngine.Framework.SceneComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; PrimitiveComponent  

Derived  
&#8627; [MeshComponent](MeshComponent.md 'UnrealEngine.Framework.MeshComponent')
&#8627; [MotionControllerComponent](MotionControllerComponent.md 'UnrealEngine.Framework.MotionControllerComponent')
&#8627; [ShapeComponent](ShapeComponent.md 'UnrealEngine.Framework.ShapeComponent')
&#8627; [SplineComponent](SplineComponent.md 'UnrealEngine.Framework.SplineComponent')
&#8627; [TextRenderComponent](TextRenderComponent.md 'UnrealEngine.Framework.TextRenderComponent')  
### Properties

***
[AngularDamping](PrimitiveComponent_AngularDamping.md 'UnrealEngine.Framework.PrimitiveComponent.AngularDamping')

Gets or sets the angular damping of the component  

***
[CastShadow](PrimitiveComponent_CastShadow.md 'UnrealEngine.Framework.PrimitiveComponent.CastShadow')

Gets or sets whether the component should cast a shadow  

***
[IgnoreRadialForce](PrimitiveComponent_IgnoreRadialForce.md 'UnrealEngine.Framework.PrimitiveComponent.IgnoreRadialForce')

Gets or sets whether the component should ignore radial forces  

***
[IgnoreRadialImpulse](PrimitiveComponent_IgnoreRadialImpulse.md 'UnrealEngine.Framework.PrimitiveComponent.IgnoreRadialImpulse')

Gets or sets whether the component should ignore radial impulses  

***
[IsGravityEnabled](PrimitiveComponent_IsGravityEnabled.md 'UnrealEngine.Framework.PrimitiveComponent.IsGravityEnabled')

Returns `true` if the component is affected by gravity, always returns `false` if physics simulation is disabled for the component  

***
[LinearDamping](PrimitiveComponent_LinearDamping.md 'UnrealEngine.Framework.PrimitiveComponent.LinearDamping')

Gets or sets the linear damping of the component  

***
[Mass](PrimitiveComponent_Mass.md 'UnrealEngine.Framework.PrimitiveComponent.Mass')

Returns approximate mass in kilograms  

***
[MaterialsNumber](PrimitiveComponent_MaterialsNumber.md 'UnrealEngine.Framework.PrimitiveComponent.MaterialsNumber')

Returns number of material elements in the primitive  

***
[OnlyOwnerSee](PrimitiveComponent_OnlyOwnerSee.md 'UnrealEngine.Framework.PrimitiveComponent.OnlyOwnerSee')

Gets or sets the component visibility when the view actor is the component's owner  

***
[OwnerNoSee](PrimitiveComponent_OwnerNoSee.md 'UnrealEngine.Framework.PrimitiveComponent.OwnerNoSee')

Gets or sets whether the component would not be visible when the view actor is the component's owner, directly or indirectly  
### Methods

***
[AddAngularImpulseInDegrees(Vector3, string, bool)](PrimitiveComponent_AddAngularImpulseInDegrees(Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddAngularImpulseInDegrees(System.Numerics.Vector3, string, bool)')

Adds an angular impulse in degrees to a rigid body  

***
[AddAngularImpulseInRadians(Vector3, string, bool)](PrimitiveComponent_AddAngularImpulseInRadians(Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddAngularImpulseInRadians(System.Numerics.Vector3, string, bool)')

Adds an angular impulse in radians to a rigid body  

***
[AddForce(Vector3, string, bool)](PrimitiveComponent_AddForce(Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddForce(System.Numerics.Vector3, string, bool)')

Adds a force to a rigid body  

***
[AddForceAtLocation(Vector3, Vector3, string, bool)](PrimitiveComponent_AddForceAtLocation(Vector3_Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddForceAtLocation(System.Numerics.Vector3, System.Numerics.Vector3, string, bool)')

Adds a force to a rigid body at a specific location, optionally in local space  

***
[AddImpulse(Vector3, string, bool)](PrimitiveComponent_AddImpulse(Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddImpulse(System.Numerics.Vector3, string, bool)')

Adds an impulse to a rigid body  

***
[AddImpulseAtLocation(Vector3, Vector3, string)](PrimitiveComponent_AddImpulseAtLocation(Vector3_Vector3_string).md 'UnrealEngine.Framework.PrimitiveComponent.AddImpulseAtLocation(System.Numerics.Vector3, System.Numerics.Vector3, string)')

Adds an impulse to a rigid body at a specific location  

***
[AddRadialForce(Vector3, float, float, bool, bool)](PrimitiveComponent_AddRadialForce(Vector3_float_float_bool_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddRadialForce(System.Numerics.Vector3, float, float, bool, bool)')

Adds a force to all rigid bodies in the component, originating from the supplied world-space location  

***
[AddRadialImpulse(Vector3, float, float, bool, bool)](PrimitiveComponent_AddRadialImpulse(Vector3_float_float_bool_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddRadialImpulse(System.Numerics.Vector3, float, float, bool, bool)')

Adds an impulse to all rigid bodies in the component, originating from the supplied world-space location  

***
[AddTorqueInDegrees(Vector3, string, bool)](PrimitiveComponent_AddTorqueInDegrees(Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddTorqueInDegrees(System.Numerics.Vector3, string, bool)')

Adds a torque in degrees to a rigid body  

***
[AddTorqueInRadians(Vector3, string, bool)](PrimitiveComponent_AddTorqueInRadians(Vector3_string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.AddTorqueInRadians(System.Numerics.Vector3, string, bool)')

Adds a torque in radians to a rigid body  

***
[ClearMoveIgnoreActors()](PrimitiveComponent_ClearMoveIgnoreActors().md 'UnrealEngine.Framework.PrimitiveComponent.ClearMoveIgnoreActors()')

Clears the list of actors that ignored during the movement  

***
[ClearMoveIgnoreComponents()](PrimitiveComponent_ClearMoveIgnoreComponents().md 'UnrealEngine.Framework.PrimitiveComponent.ClearMoveIgnoreComponents()')

Clears the list of components that ignored during the movement  

***
[CreateAndSetMaterialInstanceDynamic(int)](PrimitiveComponent_CreateAndSetMaterialInstanceDynamic(int).md 'UnrealEngine.Framework.PrimitiveComponent.CreateAndSetMaterialInstanceDynamic(int)')

Creates a dynamic material instance for the specified element index, the parent of the instance is set to the material being replaced  

***
[ForEachOverlappingComponent&lt;T&gt;(Action&lt;T&gt;)](PrimitiveComponent_ForEachOverlappingComponent_T_(Action_T_).md 'UnrealEngine.Framework.PrimitiveComponent.ForEachOverlappingComponent&lt;T&gt;(System.Action&lt;T&gt;)')

Performs the specified action on each overlapping component if any  

***
[GetDistanceToCollision(Vector3, Vector3)](PrimitiveComponent_GetDistanceToCollision(Vector3_Vector3).md 'UnrealEngine.Framework.PrimitiveComponent.GetDistanceToCollision(System.Numerics.Vector3, System.Numerics.Vector3)')

Retrieves distance to closest collision  

***
[GetMaterial(int)](PrimitiveComponent_GetMaterial(int).md 'UnrealEngine.Framework.PrimitiveComponent.GetMaterial(int)')

Returns the material at the specified element index or `null` on failure  

***
[GetPhysicsAngularVelocityInDegrees(string)](PrimitiveComponent_GetPhysicsAngularVelocityInDegrees(string).md 'UnrealEngine.Framework.PrimitiveComponent.GetPhysicsAngularVelocityInDegrees(string)')

Returns the angular velocity in degrees of a single body  

***
[GetPhysicsAngularVelocityInDegrees(Vector3, string)](PrimitiveComponent_GetPhysicsAngularVelocityInDegrees(Vector3_string).md 'UnrealEngine.Framework.PrimitiveComponent.GetPhysicsAngularVelocityInDegrees(System.Numerics.Vector3, string)')

Retrieves the angular velocity in degrees of a single body  

***
[GetPhysicsAngularVelocityInRadians(string)](PrimitiveComponent_GetPhysicsAngularVelocityInRadians(string).md 'UnrealEngine.Framework.PrimitiveComponent.GetPhysicsAngularVelocityInRadians(string)')

Returns the angular velocity in radians of a single body  

***
[GetPhysicsAngularVelocityInRadians(Vector3, string)](PrimitiveComponent_GetPhysicsAngularVelocityInRadians(Vector3_string).md 'UnrealEngine.Framework.PrimitiveComponent.GetPhysicsAngularVelocityInRadians(System.Numerics.Vector3, string)')

Retrieves the angular velocity in radians of a single body  

***
[GetPhysicsLinearVelocity(string)](PrimitiveComponent_GetPhysicsLinearVelocity(string).md 'UnrealEngine.Framework.PrimitiveComponent.GetPhysicsLinearVelocity(string)')

Returns the linear velocity of a single body  

***
[GetPhysicsLinearVelocity(Vector3, string)](PrimitiveComponent_GetPhysicsLinearVelocity(Vector3_string).md 'UnrealEngine.Framework.PrimitiveComponent.GetPhysicsLinearVelocity(System.Numerics.Vector3, string)')

Retrieves the linear velocity of a single body  

***
[GetPhysicsLinearVelocityAtPoint(Vector3, string)](PrimitiveComponent_GetPhysicsLinearVelocityAtPoint(Vector3_string).md 'UnrealEngine.Framework.PrimitiveComponent.GetPhysicsLinearVelocityAtPoint(System.Numerics.Vector3, string)')

Returns the linear velocity of a point on a single body  

***
[GetPhysicsLinearVelocityAtPoint(Vector3, Vector3, string)](PrimitiveComponent_GetPhysicsLinearVelocityAtPoint(Vector3_Vector3_string).md 'UnrealEngine.Framework.PrimitiveComponent.GetPhysicsLinearVelocityAtPoint(System.Numerics.Vector3, System.Numerics.Vector3, string)')

Retrieves the linear velocity of a point on a single body  

***
[GetSquaredDistanceToCollision(Vector3, float, Vector3)](PrimitiveComponent_GetSquaredDistanceToCollision(Vector3_float_Vector3).md 'UnrealEngine.Framework.PrimitiveComponent.GetSquaredDistanceToCollision(System.Numerics.Vector3, float, System.Numerics.Vector3)')

Retrieves squared distance to closest collision  

***
[IsOverlappingComponent(PrimitiveComponent)](PrimitiveComponent_IsOverlappingComponent(PrimitiveComponent).md 'UnrealEngine.Framework.PrimitiveComponent.IsOverlappingComponent(UnrealEngine.Framework.PrimitiveComponent)')

Returns `true` if the component is overlapping another component  

***
[RegisterEvent(ComponentEventType)](PrimitiveComponent_RegisterEvent(ComponentEventType).md 'UnrealEngine.Framework.PrimitiveComponent.RegisterEvent(UnrealEngine.Framework.ComponentEventType)')

Registers an event notification for the primitive component  

***
[SetCenterOfMass(Vector3, string)](PrimitiveComponent_SetCenterOfMass(Vector3_string).md 'UnrealEngine.Framework.PrimitiveComponent.SetCenterOfMass(System.Numerics.Vector3, string)')

Sets the center of mass of a single body  

***
[SetCollisionChannel(CollisionChannel)](PrimitiveComponent_SetCollisionChannel(CollisionChannel).md 'UnrealEngine.Framework.PrimitiveComponent.SetCollisionChannel(UnrealEngine.Framework.CollisionChannel)')

Sets the collision channel of the component  

***
[SetCollisionMode(CollisionMode)](PrimitiveComponent_SetCollisionMode(CollisionMode).md 'UnrealEngine.Framework.PrimitiveComponent.SetCollisionMode(UnrealEngine.Framework.CollisionMode)')

Sets the collision mode of the component  

***
[SetCollisionProfileName(string, bool)](PrimitiveComponent_SetCollisionProfileName(string_bool).md 'UnrealEngine.Framework.PrimitiveComponent.SetCollisionProfileName(string, bool)')

Sets the collision <a href="https://docs.unrealengine.com/en-US/Engine/Physics/Collision/Reference/index.html">profile name</a> of the component  

***
[SetCollisionResponseToAllChannels(CollisionResponse)](PrimitiveComponent_SetCollisionResponseToAllChannels(CollisionResponse).md 'UnrealEngine.Framework.PrimitiveComponent.SetCollisionResponseToAllChannels(UnrealEngine.Framework.CollisionResponse)')

Sets the collision response to all channels of the component  

***
[SetCollisionResponseToChannel(CollisionChannel, CollisionResponse)](PrimitiveComponent_SetCollisionResponseToChannel(CollisionChannel_CollisionResponse).md 'UnrealEngine.Framework.PrimitiveComponent.SetCollisionResponseToChannel(UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.CollisionResponse)')

Sets the collision response to channel of the component  

***
[SetEnableGravity(bool)](PrimitiveComponent_SetEnableGravity(bool).md 'UnrealEngine.Framework.PrimitiveComponent.SetEnableGravity(bool)')

Sets whether the component is affected by gravity, applies only to components with enabled physics simulation  

***
[SetGenerateHitEvents(bool)](PrimitiveComponent_SetGenerateHitEvents(bool).md 'UnrealEngine.Framework.PrimitiveComponent.SetGenerateHitEvents(bool)')

Sets whether the component should generate hit events when it's collides with other components  

***
[SetGenerateOverlapEvents(bool)](PrimitiveComponent_SetGenerateOverlapEvents(bool).md 'UnrealEngine.Framework.PrimitiveComponent.SetGenerateOverlapEvents(bool)')

Sets whether the component should generate overlap events when it's overlaps other components  

***
[SetIgnoreActorWhenMoving(Actor, bool)](PrimitiveComponent_SetIgnoreActorWhenMoving(Actor_bool).md 'UnrealEngine.Framework.PrimitiveComponent.SetIgnoreActorWhenMoving(UnrealEngine.Framework.Actor, bool)')

Sets whether to ignore collision of all components of a specified actor during the movement  

***
[SetIgnoreComponentWhenMoving(PrimitiveComponent, bool)](PrimitiveComponent_SetIgnoreComponentWhenMoving(PrimitiveComponent_bool).md 'UnrealEngine.Framework.PrimitiveComponent.SetIgnoreComponentWhenMoving(UnrealEngine.Framework.PrimitiveComponent, bool)')

Sets whether to ignore collision of a specified component during the movement  

***
[SetMass(float, string)](PrimitiveComponent_SetMass(float_string).md 'UnrealEngine.Framework.PrimitiveComponent.SetMass(float, string)')

Sets the mass in kilograms of a rigid body  

***
[SetMaterial(int, MaterialInterface)](PrimitiveComponent_SetMaterial(int_MaterialInterface).md 'UnrealEngine.Framework.PrimitiveComponent.SetMaterial(int, UnrealEngine.Framework.MaterialInterface)')

Sets the material applied to an element of the mesh  

***
[SetPhysicsAngularVelocityInDegrees(Vector3, bool, string)](PrimitiveComponent_SetPhysicsAngularVelocityInDegrees(Vector3_bool_string).md 'UnrealEngine.Framework.PrimitiveComponent.SetPhysicsAngularVelocityInDegrees(System.Numerics.Vector3, bool, string)')

Sets the angular velocity in degrees of a single body  

***
[SetPhysicsAngularVelocityInRadians(Vector3, bool, string)](PrimitiveComponent_SetPhysicsAngularVelocityInRadians(Vector3_bool_string).md 'UnrealEngine.Framework.PrimitiveComponent.SetPhysicsAngularVelocityInRadians(System.Numerics.Vector3, bool, string)')

Sets the angular velocity in radians of a single body  

***
[SetPhysicsLinearVelocity(Vector3, bool, string)](PrimitiveComponent_SetPhysicsLinearVelocity(Vector3_bool_string).md 'UnrealEngine.Framework.PrimitiveComponent.SetPhysicsLinearVelocity(System.Numerics.Vector3, bool, string)')

Sets the linear velocity of a single body  

***
[SetPhysicsMaxAngularVelocityInDegrees(float, bool, string)](PrimitiveComponent_SetPhysicsMaxAngularVelocityInDegrees(float_bool_string).md 'UnrealEngine.Framework.PrimitiveComponent.SetPhysicsMaxAngularVelocityInDegrees(float, bool, string)')

Sets the maximum angular velocity in degrees of a single body  

***
[SetPhysicsMaxAngularVelocityInRadians(float, bool, string)](PrimitiveComponent_SetPhysicsMaxAngularVelocityInRadians(float_bool_string).md 'UnrealEngine.Framework.PrimitiveComponent.SetPhysicsMaxAngularVelocityInRadians(float, bool, string)')

Sets the maximum angular velocity in radians of a single body  

***
[SetSimulatePhysics(bool)](PrimitiveComponent_SetSimulatePhysics(bool).md 'UnrealEngine.Framework.PrimitiveComponent.SetSimulatePhysics(bool)')

Sets whether a single body should use physics simulation, or should be kinematic, if the component is currently attached to something, beginning simulation will detach it  

***
[UnregisterEvent(ComponentEventType)](PrimitiveComponent_UnregisterEvent(ComponentEventType).md 'UnrealEngine.Framework.PrimitiveComponent.UnregisterEvent(UnrealEngine.Framework.ComponentEventType)')

Unregisters an event notification for the primitive component  
