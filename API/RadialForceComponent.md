### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## RadialForceComponent Class
A component that emits a radial force or impulse that can affect physics objects and destructible objects  
```csharp
public class RadialForceComponent : UnrealEngine.Framework.SceneComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; RadialForceComponent  
### Constructors

***
[RadialForceComponent(Actor, string, bool, Blueprint)](RadialForceComponent_RadialForceComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.RadialForceComponent.RadialForceComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[ForceStrength](RadialForceComponent_ForceStrength.md 'UnrealEngine.Framework.RadialForceComponent.ForceStrength')

Gets or sets the force strength  

***
[IgnoreOwningActor](RadialForceComponent_IgnoreOwningActor.md 'UnrealEngine.Framework.RadialForceComponent.IgnoreOwningActor')

Gets or sets whether to apply the force or impulse to any physics objects that are part of the actor which owns the component  

***
[ImpulseStrength](RadialForceComponent_ImpulseStrength.md 'UnrealEngine.Framework.RadialForceComponent.ImpulseStrength')

Gets or sets the impulse strength  

***
[ImpulseVelocityChange](RadialForceComponent_ImpulseVelocityChange.md 'UnrealEngine.Framework.RadialForceComponent.ImpulseVelocityChange')

Gets or sets whether the impulse will ignore the mass of objects and will always result in a fixed velocity change  

***
[LinearFalloff](RadialForceComponent_LinearFalloff.md 'UnrealEngine.Framework.RadialForceComponent.LinearFalloff')

Gets or sets whether the force or impulse should lose its strength linearly  

***
[Radius](RadialForceComponent_Radius.md 'UnrealEngine.Framework.RadialForceComponent.Radius')

Gets or sets the radius within the force or impulse will be applied  
### Methods

***
[AddCollisionChannelToAffect(CollisionChannel)](RadialForceComponent_AddCollisionChannelToAffect(CollisionChannel).md 'UnrealEngine.Framework.RadialForceComponent.AddCollisionChannelToAffect(UnrealEngine.Framework.CollisionChannel)')

Adds a collision channel that will be affected by the radial force  

***
[FireImpulse()](RadialForceComponent_FireImpulse().md 'UnrealEngine.Framework.RadialForceComponent.FireImpulse()')

Fires a single impulse  
