### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[World](World.md 'UnrealEngine.Framework.World')
## World.OverlapAnyTestByProfile(Vector3, Quaternion, string, CollisionShape, Actor, PrimitiveComponent) Method
Tests the collision shape at the specified location using a specific profile to determine if any blocking or overlapping occurred  
```csharp
public static bool OverlapAnyTestByProfile(in System.Numerics.Vector3 location, in System.Numerics.Quaternion rotation, string profileName, in UnrealEngine.Framework.CollisionShape shape, UnrealEngine.Framework.Actor ignoredActor=null, UnrealEngine.Framework.PrimitiveComponent ignoredComponent=null);
```
#### Parameters
<a name='UnrealEngine_Framework_World_OverlapAnyTestByProfile(System_Numerics_Vector3_System_Numerics_Quaternion_string_UnrealEngine_Framework_CollisionShape_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_location'></a>
`location` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
<a name='UnrealEngine_Framework_World_OverlapAnyTestByProfile(System_Numerics_Vector3_System_Numerics_Quaternion_string_UnrealEngine_Framework_CollisionShape_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_rotation'></a>
`rotation` [System.Numerics.Quaternion](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Quaternion 'System.Numerics.Quaternion')  
  
<a name='UnrealEngine_Framework_World_OverlapAnyTestByProfile(System_Numerics_Vector3_System_Numerics_Quaternion_string_UnrealEngine_Framework_CollisionShape_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_profileName'></a>
`profileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='UnrealEngine_Framework_World_OverlapAnyTestByProfile(System_Numerics_Vector3_System_Numerics_Quaternion_string_UnrealEngine_Framework_CollisionShape_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_shape'></a>
`shape` [CollisionShape](CollisionShape.md 'UnrealEngine.Framework.CollisionShape')  
  
<a name='UnrealEngine_Framework_World_OverlapAnyTestByProfile(System_Numerics_Vector3_System_Numerics_Quaternion_string_UnrealEngine_Framework_CollisionShape_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_ignoredActor'></a>
`ignoredActor` [Actor](Actor.md 'UnrealEngine.Framework.Actor')  
  
<a name='UnrealEngine_Framework_World_OverlapAnyTestByProfile(System_Numerics_Vector3_System_Numerics_Quaternion_string_UnrealEngine_Framework_CollisionShape_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_ignoredComponent'></a>
`ignoredComponent` [PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` on success
