### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## SceneComponent Class
The base class of components that can be transformed or attached, but has no rendering or collision capabilities  
```csharp
public class SceneComponent : UnrealEngine.Framework.ActorComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; SceneComponent  

Derived  
&#8627; [AudioComponent](AudioComponent.md 'UnrealEngine.Framework.AudioComponent')
&#8627; [CameraComponent](CameraComponent.md 'UnrealEngine.Framework.CameraComponent')
&#8627; [ChildActorComponent](ChildActorComponent.md 'UnrealEngine.Framework.ChildActorComponent')
&#8627; [LightComponentBase](LightComponentBase.md 'UnrealEngine.Framework.LightComponentBase')
&#8627; [PostProcessComponent](PostProcessComponent.md 'UnrealEngine.Framework.PostProcessComponent')
&#8627; [PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
&#8627; [RadialForceComponent](RadialForceComponent.md 'UnrealEngine.Framework.RadialForceComponent')
&#8627; [SpringArmComponent](SpringArmComponent.md 'UnrealEngine.Framework.SpringArmComponent')  
### Constructors

***
[SceneComponent(Actor, string, bool, Blueprint)](SceneComponent_SceneComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.SceneComponent.SceneComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[HasAnySockets](SceneComponent_HasAnySockets.md 'UnrealEngine.Framework.SceneComponent.HasAnySockets')

Returns `true` if the component has any sockets  

***
[IsVisible](SceneComponent_IsVisible.md 'UnrealEngine.Framework.SceneComponent.IsVisible')

Returns `true` if the component is visible in the current context  
### Methods

***
[Activate()](SceneComponent_Activate().md 'UnrealEngine.Framework.SceneComponent.Activate()')

Activates the component  

***
[AddLocalOffset(Vector3)](SceneComponent_AddLocalOffset(Vector3).md 'UnrealEngine.Framework.SceneComponent.AddLocalOffset(System.Numerics.Vector3)')

Adds a delta to the location of the component in its local reference frame  

***
[AddLocalRotation(Quaternion)](SceneComponent_AddLocalRotation(Quaternion).md 'UnrealEngine.Framework.SceneComponent.AddLocalRotation(System.Numerics.Quaternion)')

Adds a delta to the rotation of the component in its local reference frame  

***
[AddLocalTransform(Transform)](SceneComponent_AddLocalTransform(Transform).md 'UnrealEngine.Framework.SceneComponent.AddLocalTransform(UnrealEngine.Framework.Transform)')

Adds a delta to the transform of the component in its local reference frame, scale is unchanged  

***
[AddRelativeLocation(Vector3)](SceneComponent_AddRelativeLocation(Vector3).md 'UnrealEngine.Framework.SceneComponent.AddRelativeLocation(System.Numerics.Vector3)')

Adds a delta to the translation of the component relative to its parent  

***
[AddRelativeRotation(Quaternion)](SceneComponent_AddRelativeRotation(Quaternion).md 'UnrealEngine.Framework.SceneComponent.AddRelativeRotation(System.Numerics.Quaternion)')

Adds a delta to the rotation of the component relative to its parent  

***
[AddWorldOffset(Vector3)](SceneComponent_AddWorldOffset(Vector3).md 'UnrealEngine.Framework.SceneComponent.AddWorldOffset(System.Numerics.Vector3)')

Adds a delta to the location of the component in world space  

***
[AddWorldRotation(Quaternion)](SceneComponent_AddWorldRotation(Quaternion).md 'UnrealEngine.Framework.SceneComponent.AddWorldRotation(System.Numerics.Quaternion)')

Adds a delta to the rotation of the component in world space  

***
[AddWorldTransform(Transform)](SceneComponent_AddWorldTransform(Transform).md 'UnrealEngine.Framework.SceneComponent.AddWorldTransform(UnrealEngine.Framework.Transform)')

Adds a delta to the transform of the component in world space, scale is unchanged  

***
[AttachToComponent(SceneComponent, AttachmentTransformRule, string)](SceneComponent_AttachToComponent(SceneComponent_AttachmentTransformRule_string).md 'UnrealEngine.Framework.SceneComponent.AttachToComponent(UnrealEngine.Framework.SceneComponent, UnrealEngine.Framework.AttachmentTransformRule, string)')

Attaches the component to another component, optionally at a named socket  

***
[CanAttachAsChild(SceneComponent, string)](SceneComponent_CanAttachAsChild(SceneComponent_string).md 'UnrealEngine.Framework.SceneComponent.CanAttachAsChild(UnrealEngine.Framework.SceneComponent, string)')

Returns `true` if another scene component can be attached as a child  

***
[Deactivate()](SceneComponent_Deactivate().md 'UnrealEngine.Framework.SceneComponent.Deactivate()')

Deactivates the component  

***
[DetachFromComponent(DetachmentTransformRule)](SceneComponent_DetachFromComponent(DetachmentTransformRule).md 'UnrealEngine.Framework.SceneComponent.DetachFromComponent(UnrealEngine.Framework.DetachmentTransformRule)')

Detaches the component from a parent  

***
[ForEachAttachedChild&lt;T&gt;(Action&lt;T&gt;)](SceneComponent_ForEachAttachedChild_T_(Action_T_).md 'UnrealEngine.Framework.SceneComponent.ForEachAttachedChild&lt;T&gt;(System.Action&lt;T&gt;)')

Performs the specified action on each attached child component if any  

***
[GetAttachedSocketName()](SceneComponent_GetAttachedSocketName().md 'UnrealEngine.Framework.SceneComponent.GetAttachedSocketName()')

Returns the name of a socket the component is attached to  

***
[GetBounds(Transform, Bounds)](SceneComponent_GetBounds(Transform_Bounds).md 'UnrealEngine.Framework.SceneComponent.GetBounds(UnrealEngine.Framework.Transform, UnrealEngine.Framework.Bounds)')

Retrieves calculated bounds of the component  

***
[GetForwardVector()](SceneComponent_GetForwardVector().md 'UnrealEngine.Framework.SceneComponent.GetForwardVector()')

Returns the forward X unit direction vector from the component in world space  

***
[GetForwardVector(Vector3)](SceneComponent_GetForwardVector(Vector3).md 'UnrealEngine.Framework.SceneComponent.GetForwardVector(System.Numerics.Vector3)')

Retrieves the forward X unit direction vector from the component in world space  

***
[GetLocation()](SceneComponent_GetLocation().md 'UnrealEngine.Framework.SceneComponent.GetLocation()')

Returns location of the component in world space  

***
[GetLocation(Vector3)](SceneComponent_GetLocation(Vector3).md 'UnrealEngine.Framework.SceneComponent.GetLocation(System.Numerics.Vector3)')

Retrieves location of the component in world space  

***
[GetRightVector()](SceneComponent_GetRightVector().md 'UnrealEngine.Framework.SceneComponent.GetRightVector()')

Returns the right Y unit direction vector from the component in world space  

***
[GetRightVector(Vector3)](SceneComponent_GetRightVector(Vector3).md 'UnrealEngine.Framework.SceneComponent.GetRightVector(System.Numerics.Vector3)')

Retrieves the right Y unit direction vector from the component in world space  

***
[GetRotation()](SceneComponent_GetRotation().md 'UnrealEngine.Framework.SceneComponent.GetRotation()')

Returns rotation of the component in world space  

***
[GetRotation(Quaternion)](SceneComponent_GetRotation(Quaternion).md 'UnrealEngine.Framework.SceneComponent.GetRotation(System.Numerics.Quaternion)')

Returns rotation of the component in world space  

***
[GetScale()](SceneComponent_GetScale().md 'UnrealEngine.Framework.SceneComponent.GetScale()')

Returns scale of the component in world space  

***
[GetScale(Vector3)](SceneComponent_GetScale(Vector3).md 'UnrealEngine.Framework.SceneComponent.GetScale(System.Numerics.Vector3)')

Retrieves scale of the component in world space  

***
[GetSocketLocation(string, Vector3)](SceneComponent_GetSocketLocation(string_Vector3).md 'UnrealEngine.Framework.SceneComponent.GetSocketLocation(string, System.Numerics.Vector3)')

Retrieves location of a socket in world space  

***
[GetSocketLocation(string)](SceneComponent_GetSocketLocation(string).md 'UnrealEngine.Framework.SceneComponent.GetSocketLocation(string)')

Returns location of a socket in world space  

***
[GetSocketRotation(string, Quaternion)](SceneComponent_GetSocketRotation(string_Quaternion).md 'UnrealEngine.Framework.SceneComponent.GetSocketRotation(string, System.Numerics.Quaternion)')

Retrieves rotation of a socket in world space  

***
[GetSocketRotation(string)](SceneComponent_GetSocketRotation(string).md 'UnrealEngine.Framework.SceneComponent.GetSocketRotation(string)')

Returns rotation of a socket in world space  

***
[GetTransform()](SceneComponent_GetTransform().md 'UnrealEngine.Framework.SceneComponent.GetTransform()')

Returns the transform which assigned to the component  

***
[GetTransform(Transform)](SceneComponent_GetTransform(Transform).md 'UnrealEngine.Framework.SceneComponent.GetTransform(UnrealEngine.Framework.Transform)')

Returns the transform which assigned to the component  

***
[GetUpVector()](SceneComponent_GetUpVector().md 'UnrealEngine.Framework.SceneComponent.GetUpVector()')

Returns the up Z unit direction vector from the component in world space  

***
[GetUpVector(Vector3)](SceneComponent_GetUpVector(Vector3).md 'UnrealEngine.Framework.SceneComponent.GetUpVector(System.Numerics.Vector3)')

Retrieves the up Z unit direction vector from the component in world space  

***
[GetVelocity()](SceneComponent_GetVelocity().md 'UnrealEngine.Framework.SceneComponent.GetVelocity()')

Returns velocity of the component, or the velocity of the physics body if simulating physics  

***
[GetVelocity(Vector3)](SceneComponent_GetVelocity(Vector3).md 'UnrealEngine.Framework.SceneComponent.GetVelocity(System.Numerics.Vector3)')

Retrieves velocity of the component, or the velocity of the physics body if simulating physics  

***
[IsAttachedToActor(Actor)](SceneComponent_IsAttachedToActor(Actor).md 'UnrealEngine.Framework.SceneComponent.IsAttachedToActor(UnrealEngine.Framework.Actor)')

Returns `true` if the component is attached to the actor  

***
[IsAttachedToComponent(SceneComponent)](SceneComponent_IsAttachedToComponent(SceneComponent).md 'UnrealEngine.Framework.SceneComponent.IsAttachedToComponent(UnrealEngine.Framework.SceneComponent)')

Returns `true` if the component is attached to the supplied component  

***
[IsSocketExists(string)](SceneComponent_IsSocketExists(string).md 'UnrealEngine.Framework.SceneComponent.IsSocketExists(string)')

Returns `true` if the a socket with the given name exists  

***
[SetMobility(ComponentMobility)](SceneComponent_SetMobility(ComponentMobility).md 'UnrealEngine.Framework.SceneComponent.SetMobility(UnrealEngine.Framework.ComponentMobility)')

Sets how often the component is allowed to move at runtime  

***
[SetRelativeLocation(Vector3)](SceneComponent_SetRelativeLocation(Vector3).md 'UnrealEngine.Framework.SceneComponent.SetRelativeLocation(System.Numerics.Vector3)')

Sets the location of the component relative to its parent  

***
[SetRelativeRotation(Quaternion)](SceneComponent_SetRelativeRotation(Quaternion).md 'UnrealEngine.Framework.SceneComponent.SetRelativeRotation(System.Numerics.Quaternion)')

Sets the rotation of the component relative to its parent  

***
[SetRelativeTransform(Transform)](SceneComponent_SetRelativeTransform(Transform).md 'UnrealEngine.Framework.SceneComponent.SetRelativeTransform(UnrealEngine.Framework.Transform)')

Sets the transform of the component relative to its parent  

***
[SetVisibility(bool, bool)](SceneComponent_SetVisibility(bool_bool).md 'UnrealEngine.Framework.SceneComponent.SetVisibility(bool, bool)')

Sets the visibility of the component  

***
[SetWorldLocation(Vector3)](SceneComponent_SetWorldLocation(Vector3).md 'UnrealEngine.Framework.SceneComponent.SetWorldLocation(System.Numerics.Vector3)')

Sets the location of the component in world space  

***
[SetWorldRotation(Quaternion)](SceneComponent_SetWorldRotation(Quaternion).md 'UnrealEngine.Framework.SceneComponent.SetWorldRotation(System.Numerics.Quaternion)')

Sets the rotation of the component in world space  

***
[SetWorldScale(Vector3)](SceneComponent_SetWorldScale(Vector3).md 'UnrealEngine.Framework.SceneComponent.SetWorldScale(System.Numerics.Vector3)')

Sets the scale of the component world space  

***
[SetWorldTransform(Transform)](SceneComponent_SetWorldTransform(Transform).md 'UnrealEngine.Framework.SceneComponent.SetWorldTransform(UnrealEngine.Framework.Transform)')

Sets the transform of the component in world space  

***
[UpdateToWorld(TeleportType, UpdateTransformFlags)](SceneComponent_UpdateToWorld(TeleportType_UpdateTransformFlags).md 'UnrealEngine.Framework.SceneComponent.UpdateToWorld(UnrealEngine.Framework.TeleportType, UnrealEngine.Framework.UpdateTransformFlags)')

Recalculates the value of the component to world transform  
