### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## SplineComponent Class
Represents a spline shape  
```csharp
public class SplineComponent : UnrealEngine.Framework.PrimitiveComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; [PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent') &#129106; SplineComponent  
### Constructors

***
[SplineComponent(Actor, string, bool, Blueprint)](SplineComponent_SplineComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.SplineComponent.SplineComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[Duration](SplineComponent_Duration.md 'UnrealEngine.Framework.SplineComponent.Duration')

Gets or sets the duration of the spline in seconds  

***
[IsClosedLoop](SplineComponent_IsClosedLoop.md 'UnrealEngine.Framework.SplineComponent.IsClosedLoop')

Returns `true` if the spline is a closed loop  

***
[SplinePointsNumber](SplineComponent_SplinePointsNumber.md 'UnrealEngine.Framework.SplineComponent.SplinePointsNumber')

Returns the number of spline points  

***
[SplineSegmentsNumber](SplineComponent_SplineSegmentsNumber.md 'UnrealEngine.Framework.SplineComponent.SplineSegmentsNumber')

Returns the number of spline segments  
### Methods

***
[AddSplinePoint(Vector3, SplineCoordinateSpace, bool)](SplineComponent_AddSplinePoint(Vector3_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.AddSplinePoint(System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Adds a point to the spline  

***
[AddSplinePointAtIndex(Vector3, int, SplineCoordinateSpace, bool)](SplineComponent_AddSplinePointAtIndex(Vector3_int_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.AddSplinePointAtIndex(System.Numerics.Vector3, int, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Adds a point to the spline at the specified index  

***
[ClearSplinePoints(bool)](SplineComponent_ClearSplinePoints(bool).md 'UnrealEngine.Framework.SplineComponent.ClearSplinePoints(bool)')

Clears all the points in the spline  

***
[FindDirectionClosestToWorldLocation(Vector3, SplineCoordinateSpace)](SplineComponent_FindDirectionClosestToWorldLocation(Vector3_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.FindDirectionClosestToWorldLocation(System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns a unit direction vector of the spline tangent closest to the location in world space  

***
[FindLocationClosestToWorldLocation(Vector3, SplineCoordinateSpace)](SplineComponent_FindLocationClosestToWorldLocation(Vector3_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.FindLocationClosestToWorldLocation(System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns a point of the spline closest to the location in world space  

***
[FindRightVectorClosestToWorldLocation(Vector3, SplineCoordinateSpace)](SplineComponent_FindRightVectorClosestToWorldLocation(Vector3_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.FindRightVectorClosestToWorldLocation(System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns a unit direction vector corresponding to the spline's right vector closest to the location in world space  

***
[FindRollClosestToWorldLocation(Vector3, SplineCoordinateSpace)](SplineComponent_FindRollClosestToWorldLocation(Vector3_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.FindRollClosestToWorldLocation(System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the spline's roll in degrees closest to the location in world space  

***
[FindScaleClosestToWorldLocation(Vector3)](SplineComponent_FindScaleClosestToWorldLocation(Vector3).md 'UnrealEngine.Framework.SplineComponent.FindScaleClosestToWorldLocation(System.Numerics.Vector3)')

Returns the spline's scale closest to the location in world space  

***
[FindTangentClosestToWorldLocation(Vector3, SplineCoordinateSpace)](SplineComponent_FindTangentClosestToWorldLocation(Vector3_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.FindTangentClosestToWorldLocation(System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns a tangent of the spline closest to the location in world space  

***
[FindTransformClosestToWorldLocation(Vector3, SplineCoordinateSpace, bool)](SplineComponent_FindTransformClosestToWorldLocation(Vector3_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.FindTransformClosestToWorldLocation(System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Returns a transform closest to the location in world space  

***
[FindUpVectorClosestToWorldLocation(Vector3, SplineCoordinateSpace)](SplineComponent_FindUpVectorClosestToWorldLocation(Vector3_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.FindUpVectorClosestToWorldLocation(System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns a unit direction vector corresponding to the spline's up vector closest to the location in world space  

***
[GetArriveTangentAtSplinePoint(int, SplineCoordinateSpace, Vector3)](SplineComponent_GetArriveTangentAtSplinePoint(int_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetArriveTangentAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves the arrive tangent at the spline point  

***
[GetArriveTangentAtSplinePoint(int, SplineCoordinateSpace)](SplineComponent_GetArriveTangentAtSplinePoint(int_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetArriveTangentAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the arrive tangent at the spline point  

***
[GetDefaultUpVector(SplineCoordinateSpace, Vector3)](SplineComponent_GetDefaultUpVector(SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetDefaultUpVector(UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves the default up vector of the spline  

***
[GetDefaultUpVector(SplineCoordinateSpace)](SplineComponent_GetDefaultUpVector(SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetDefaultUpVector(UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the default up vector of the spline  

***
[GetDirectionAtDistanceAlongSpline(float, SplineCoordinateSpace, Vector3)](SplineComponent_GetDirectionAtDistanceAlongSpline(float_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetDirectionAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves a unit direction vector of the spline tangent at the given distance along the length of the spline  

***
[GetDirectionAtDistanceAlongSpline(float, SplineCoordinateSpace)](SplineComponent_GetDirectionAtDistanceAlongSpline(float_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetDirectionAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns a unit direction vector of the spline tangent at the given distance along the length of the spline  

***
[GetDirectionAtSplinePoint(int, SplineCoordinateSpace, Vector3)](SplineComponent_GetDirectionAtSplinePoint(int_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetDirectionAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves a unit direction vector at the spline point  

***
[GetDirectionAtSplinePoint(int, SplineCoordinateSpace)](SplineComponent_GetDirectionAtSplinePoint(int_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetDirectionAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns a unit direction vector at the spline point  

***
[GetDirectionAtTime(float, SplineCoordinateSpace, bool, Vector3)](SplineComponent_GetDirectionAtTime(float_SplineCoordinateSpace_bool_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetDirectionAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool, System.Numerics.Vector3)')

Retrieves a unit direction vector of the spline tangent at the given time from 0.0f to the spline duration  

***
[GetDirectionAtTime(float, SplineCoordinateSpace, bool)](SplineComponent_GetDirectionAtTime(float_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.GetDirectionAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Returns a unit direction vector of the spline tangent at the given time from 0.0f to the spline duration  

***
[GetDistanceAlongSplineAtSplinePoint(int)](SplineComponent_GetDistanceAlongSplineAtSplinePoint(int).md 'UnrealEngine.Framework.SplineComponent.GetDistanceAlongSplineAtSplinePoint(int)')

Returns the distance along the spline at the spline point  

***
[GetLeaveTangentAtSplinePoint(int, SplineCoordinateSpace, Vector3)](SplineComponent_GetLeaveTangentAtSplinePoint(int_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetLeaveTangentAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves the leave tangent at the spline point  

***
[GetLeaveTangentAtSplinePoint(int, SplineCoordinateSpace)](SplineComponent_GetLeaveTangentAtSplinePoint(int_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetLeaveTangentAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the leave tangent at the spline point  

***
[GetLocationAndTangentAtSplinePoint(int, SplineCoordinateSpace, Vector3, Vector3)](SplineComponent_GetLocationAndTangentAtSplinePoint(int_SplineCoordinateSpace_Vector3_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetLocationAndTangentAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3, System.Numerics.Vector3)')

Retrieves the location and tangent at the spline point  

***
[GetLocationAtDistanceAlongSpline(float, SplineCoordinateSpace, Vector3)](SplineComponent_GetLocationAtDistanceAlongSpline(float_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetLocationAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves the location at the given distance along the length of the spline  

***
[GetLocationAtDistanceAlongSpline(float, SplineCoordinateSpace)](SplineComponent_GetLocationAtDistanceAlongSpline(float_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetLocationAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the location at the given distance along the length of the spline  

***
[GetLocationAtSplinePoint(int, SplineCoordinateSpace, Vector3)](SplineComponent_GetLocationAtSplinePoint(int_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetLocationAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves the location at the spline point  

***
[GetLocationAtSplinePoint(int, SplineCoordinateSpace)](SplineComponent_GetLocationAtSplinePoint(int_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetLocationAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the location at the spline point  

***
[GetLocationAtTime(float, SplineCoordinateSpace, Vector3)](SplineComponent_GetLocationAtTime(float_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetLocationAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves the location at the given time from 0.0f to the spline duration  

***
[GetLocationAtTime(float, SplineCoordinateSpace)](SplineComponent_GetLocationAtTime(float_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetLocationAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the location at the given time from 0.0f to the spline duration  

***
[GetRightVectorAtDistanceAlongSpline(float, SplineCoordinateSpace, Vector3)](SplineComponent_GetRightVectorAtDistanceAlongSpline(float_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetRightVectorAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves a unit direction vector corresponding to the spline's right vector at the given distance along the length of the spline  

***
[GetRightVectorAtDistanceAlongSpline(float, SplineCoordinateSpace)](SplineComponent_GetRightVectorAtDistanceAlongSpline(float_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetRightVectorAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace)')

Retrieves a unit direction vector corresponding to the spline's right vector at the given distance along the length of the spline  

***
[GetRightVectorAtSplinePoint(int, SplineCoordinateSpace, Vector3)](SplineComponent_GetRightVectorAtSplinePoint(int_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetRightVectorAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves the spline's right vector at the spline point  

***
[GetRightVectorAtSplinePoint(int, SplineCoordinateSpace)](SplineComponent_GetRightVectorAtSplinePoint(int_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetRightVectorAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the spline's right vector at the spline point  

***
[GetRightVectorAtTime(float, SplineCoordinateSpace, bool, Vector3)](SplineComponent_GetRightVectorAtTime(float_SplineCoordinateSpace_bool_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetRightVectorAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool, System.Numerics.Vector3)')

Retrieves the spline's right vector at the given time from 0.0f to the spline duration  

***
[GetRightVectorAtTime(float, SplineCoordinateSpace, bool)](SplineComponent_GetRightVectorAtTime(float_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.GetRightVectorAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Returns the spline's right vector at the given time from 0.0f to the spline duration  

***
[GetRollAtDistanceAlongSpline(float, SplineCoordinateSpace)](SplineComponent_GetRollAtDistanceAlongSpline(float_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetRollAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the spline's roll in degrees at the given distance along the length of the spline  

***
[GetRollAtSplinePoint(int, SplineCoordinateSpace)](SplineComponent_GetRollAtSplinePoint(int_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetRollAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the spline's roll in degrees at the spline point  

***
[GetRollAtTime(float, SplineCoordinateSpace, bool)](SplineComponent_GetRollAtTime(float_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.GetRollAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Returns the spline's roll in degrees at the given time from 0.0f to the spline duration  

***
[GetRotationAtDistanceAlongSpline(float, SplineCoordinateSpace, Quaternion)](SplineComponent_GetRotationAtDistanceAlongSpline(float_SplineCoordinateSpace_Quaternion).md 'UnrealEngine.Framework.SplineComponent.GetRotationAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Quaternion)')

Retrieves a rotation corresponding to the spline's rotation at the given distance along the length of the spline  

***
[GetRotationAtDistanceAlongSpline(float, SplineCoordinateSpace)](SplineComponent_GetRotationAtDistanceAlongSpline(float_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetRotationAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns a rotation corresponding to the spline's rotation at the given distance along the length of the spline  

***
[GetRotationAtSplinePoint(int, SplineCoordinateSpace, Quaternion)](SplineComponent_GetRotationAtSplinePoint(int_SplineCoordinateSpace_Quaternion).md 'UnrealEngine.Framework.SplineComponent.GetRotationAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Quaternion)')

Retrieves a spline's rotation at the spline point  

***
[GetRotationAtSplinePoint(int, SplineCoordinateSpace)](SplineComponent_GetRotationAtSplinePoint(int_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetRotationAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns a spline's rotation at the spline point  

***
[GetRotationAtTime(float, SplineCoordinateSpace, bool, Quaternion)](SplineComponent_GetRotationAtTime(float_SplineCoordinateSpace_bool_Quaternion).md 'UnrealEngine.Framework.SplineComponent.GetRotationAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool, System.Numerics.Quaternion)')

Retrieves a rotation corresponding to the spline's position and direction at the given time from 0.0f to the spline duration  

***
[GetRotationAtTime(float, SplineCoordinateSpace, bool)](SplineComponent_GetRotationAtTime(float_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.GetRotationAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Returns a rotation corresponding to the spline's position and direction at the given time from 0.0f to the spline duration  

***
[GetScaleAtDistanceAlongSpline(float, Vector3)](SplineComponent_GetScaleAtDistanceAlongSpline(float_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetScaleAtDistanceAlongSpline(float, System.Numerics.Vector3)')

Retrieves the spline's scale at the given distance along the length of the spline  

***
[GetScaleAtDistanceAlongSpline(float)](SplineComponent_GetScaleAtDistanceAlongSpline(float).md 'UnrealEngine.Framework.SplineComponent.GetScaleAtDistanceAlongSpline(float)')

Returns the spline's scale at the given distance along the length of the spline  

***
[GetScaleAtSplinePoint(int, Vector3)](SplineComponent_GetScaleAtSplinePoint(int_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetScaleAtSplinePoint(int, System.Numerics.Vector3)')

Retrieves the spline's scale at the spline point  

***
[GetScaleAtSplinePoint(int)](SplineComponent_GetScaleAtSplinePoint(int).md 'UnrealEngine.Framework.SplineComponent.GetScaleAtSplinePoint(int)')

Returns the spline's scale at the spline point  

***
[GetScaleAtTime(float, bool, Vector3)](SplineComponent_GetScaleAtTime(float_bool_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetScaleAtTime(float, bool, System.Numerics.Vector3)')

Retrieves the spline's scale at the given time from 0.0f to the spline duration  

***
[GetScaleAtTime(float, bool)](SplineComponent_GetScaleAtTime(float_bool).md 'UnrealEngine.Framework.SplineComponent.GetScaleAtTime(float, bool)')

Returns the spline's scale at the given time from 0.0f to the spline duration  

***
[GetSplineLength()](SplineComponent_GetSplineLength().md 'UnrealEngine.Framework.SplineComponent.GetSplineLength()')

Returns the total length along the spline  

***
[GetSplinePointType(int)](SplineComponent_GetSplinePointType(int).md 'UnrealEngine.Framework.SplineComponent.GetSplinePointType(int)')

Returns the type of a spline point  

***
[GetTangentAtDistanceAlongSpline(float, SplineCoordinateSpace, Vector3)](SplineComponent_GetTangentAtDistanceAlongSpline(float_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetTangentAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves the tangent at the given distance along the length of the spline  

***
[GetTangentAtDistanceAlongSpline(float, SplineCoordinateSpace)](SplineComponent_GetTangentAtDistanceAlongSpline(float_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetTangentAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the tangent at the given distance along the length of the spline  

***
[GetTangentAtSplinePoint(int, SplineCoordinateSpace, Vector3)](SplineComponent_GetTangentAtSplinePoint(int_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetTangentAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves the tangent at the spline point  

***
[GetTangentAtSplinePoint(int, SplineCoordinateSpace)](SplineComponent_GetTangentAtSplinePoint(int_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetTangentAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the tangent at the spline point  

***
[GetTangentAtTime(float, SplineCoordinateSpace, bool, Vector3)](SplineComponent_GetTangentAtTime(float_SplineCoordinateSpace_bool_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetTangentAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool, System.Numerics.Vector3)')

Retrieves the tangent at the given time from 0.0f to the spline duration  

***
[GetTangentAtTime(float, SplineCoordinateSpace, bool)](SplineComponent_GetTangentAtTime(float_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.GetTangentAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Returns the tangent at the given time from 0.0f to the spline duration  

***
[GetTransformAtDistanceAlongSpline(float, SplineCoordinateSpace, Transform)](SplineComponent_GetTransformAtDistanceAlongSpline(float_SplineCoordinateSpace_Transform).md 'UnrealEngine.Framework.SplineComponent.GetTransformAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace, UnrealEngine.Framework.Transform)')

Retrieves the transform at the given distance along the length of the spline  

***
[GetTransformAtDistanceAlongSpline(float, SplineCoordinateSpace)](SplineComponent_GetTransformAtDistanceAlongSpline(float_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetTransformAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the transform at the given distance along the length of the spline  

***
[GetTransformAtSplinePoint(int, SplineCoordinateSpace, bool, Transform)](SplineComponent_GetTransformAtSplinePoint(int_SplineCoordinateSpace_bool_Transform).md 'UnrealEngine.Framework.SplineComponent.GetTransformAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace, bool, UnrealEngine.Framework.Transform)')

Retrieves the transform at the spline point  

***
[GetTransformAtSplinePoint(int, SplineCoordinateSpace, bool)](SplineComponent_GetTransformAtSplinePoint(int_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.GetTransformAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Returns the transform at the spline point  

***
[GetTransformAtTime(float, SplineCoordinateSpace, bool, bool, Transform)](SplineComponent_GetTransformAtTime(float_SplineCoordinateSpace_bool_bool_Transform).md 'UnrealEngine.Framework.SplineComponent.GetTransformAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool, bool, UnrealEngine.Framework.Transform)')

Retrieves the spline's transform at the given time from 0.0f to the spline duration  

***
[GetTransformAtTime(float, SplineCoordinateSpace, bool, bool)](SplineComponent_GetTransformAtTime(float_SplineCoordinateSpace_bool_bool).md 'UnrealEngine.Framework.SplineComponent.GetTransformAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool, bool)')

Returns the spline's transform at the given time from 0.0f to the spline duration  

***
[GetUpVectorAtDistanceAlongSpline(float, SplineCoordinateSpace, Vector3)](SplineComponent_GetUpVectorAtDistanceAlongSpline(float_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetUpVectorAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves a unit direction vector corresponding to the spline's up vector at the given distance along the length of the spline  

***
[GetUpVectorAtDistanceAlongSpline(float, SplineCoordinateSpace)](SplineComponent_GetUpVectorAtDistanceAlongSpline(float_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetUpVectorAtDistanceAlongSpline(float, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns a unit direction vector corresponding to the spline's up vector at the given distance along the length of the spline  

***
[GetUpVectorAtSplinePoint(int, SplineCoordinateSpace, Vector3)](SplineComponent_GetUpVectorAtSplinePoint(int_SplineCoordinateSpace_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetUpVectorAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace, System.Numerics.Vector3)')

Retrieves the spline's up vector at the spline point  

***
[GetUpVectorAtSplinePoint(int, SplineCoordinateSpace)](SplineComponent_GetUpVectorAtSplinePoint(int_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.GetUpVectorAtSplinePoint(int, UnrealEngine.Framework.SplineCoordinateSpace)')

Returns the spline's up vector at the spline point  

***
[GetUpVectorAtTime(float, SplineCoordinateSpace, bool, Vector3)](SplineComponent_GetUpVectorAtTime(float_SplineCoordinateSpace_bool_Vector3).md 'UnrealEngine.Framework.SplineComponent.GetUpVectorAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool, System.Numerics.Vector3)')

Retrieves the spline's up vector at the given time from 0.0f to the spline duration  

***
[GetUpVectorAtTime(float, SplineCoordinateSpace, bool)](SplineComponent_GetUpVectorAtTime(float_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.GetUpVectorAtTime(float, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Returns the spline's up vector at the given time from 0.0f to the spline duration  

***
[RemoveSplinePoint(int, bool)](SplineComponent_RemoveSplinePoint(int_bool).md 'UnrealEngine.Framework.SplineComponent.RemoveSplinePoint(int, bool)')

Removes a point at the specified index from the spline  

***
[SetClosedLoop(bool, bool)](SplineComponent_SetClosedLoop(bool_bool).md 'UnrealEngine.Framework.SplineComponent.SetClosedLoop(bool, bool)')

Sets whether the spline is a closed loop  

***
[SetDefaultUpVector(Vector3, SplineCoordinateSpace)](SplineComponent_SetDefaultUpVector(Vector3_SplineCoordinateSpace).md 'UnrealEngine.Framework.SplineComponent.SetDefaultUpVector(System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace)')

Sets the default up vector of the spline  

***
[SetLocationAtSplinePoint(int, Vector3, SplineCoordinateSpace, bool)](SplineComponent_SetLocationAtSplinePoint(int_Vector3_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.SetLocationAtSplinePoint(int, System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Sets an existing point to a new location  

***
[SetSplinePointType(int, SplinePointType, bool)](SplineComponent_SetSplinePointType(int_SplinePointType_bool).md 'UnrealEngine.Framework.SplineComponent.SetSplinePointType(int, UnrealEngine.Framework.SplinePointType, bool)')

Sets the type of a spline point  

***
[SetTangentAtSplinePoint(int, Vector3, SplineCoordinateSpace, bool)](SplineComponent_SetTangentAtSplinePoint(int_Vector3_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.SetTangentAtSplinePoint(int, System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Sets the tangent at a given spline point  

***
[SetTangentsAtSplinePoint(int, Vector3, Vector3, SplineCoordinateSpace, bool)](SplineComponent_SetTangentsAtSplinePoint(int_Vector3_Vector3_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.SetTangentsAtSplinePoint(int, System.Numerics.Vector3, System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Sets the tangents at a given spline point  

***
[SetUpVectorAtSplinePoint(int, Vector3, SplineCoordinateSpace, bool)](SplineComponent_SetUpVectorAtSplinePoint(int_Vector3_SplineCoordinateSpace_bool).md 'UnrealEngine.Framework.SplineComponent.SetUpVectorAtSplinePoint(int, System.Numerics.Vector3, UnrealEngine.Framework.SplineCoordinateSpace, bool)')

Sets the up vector at a given spline point  

***
[UpdateSpline()](SplineComponent_UpdateSpline().md 'UnrealEngine.Framework.SplineComponent.UpdateSpline()')

Updates the spline  
