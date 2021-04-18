### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[World](./World.md 'UnrealEngine.Framework.World')
## World.SweepTestByProfile(System.Numerics.Vector3, System.Numerics.Vector3, System.Numerics.Quaternion, string, UnrealEngine.Framework.CollisionShape, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent) Method
Sweeps a shape against the world using a specific profile  
```csharp
public static bool SweepTestByProfile(in System.Numerics.Vector3 start, in System.Numerics.Vector3 end, in System.Numerics.Quaternion rotation, string profileName, in UnrealEngine.Framework.CollisionShape shape, bool traceComplex=false, UnrealEngine.Framework.Actor ignoredActor=null, UnrealEngine.Framework.PrimitiveComponent ignoredComponent=null);
```
#### Parameters
<a name='UnrealEngine-Framework-World-SweepTestByProfile(System-Numerics-Vector3_System-Numerics-Vector3_System-Numerics-Quaternion_string_UnrealEngine-Framework-CollisionShape_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-start'></a>
`start` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
<a name='UnrealEngine-Framework-World-SweepTestByProfile(System-Numerics-Vector3_System-Numerics-Vector3_System-Numerics-Quaternion_string_UnrealEngine-Framework-CollisionShape_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-end'></a>
`end` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
<a name='UnrealEngine-Framework-World-SweepTestByProfile(System-Numerics-Vector3_System-Numerics-Vector3_System-Numerics-Quaternion_string_UnrealEngine-Framework-CollisionShape_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-rotation'></a>
`rotation` [System.Numerics.Quaternion](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Quaternion 'System.Numerics.Quaternion')  
  
<a name='UnrealEngine-Framework-World-SweepTestByProfile(System-Numerics-Vector3_System-Numerics-Vector3_System-Numerics-Quaternion_string_UnrealEngine-Framework-CollisionShape_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-profileName'></a>
`profileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='UnrealEngine-Framework-World-SweepTestByProfile(System-Numerics-Vector3_System-Numerics-Vector3_System-Numerics-Quaternion_string_UnrealEngine-Framework-CollisionShape_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-shape'></a>
`shape` [CollisionShape](./CollisionShape.md 'UnrealEngine.Framework.CollisionShape')  
  
<a name='UnrealEngine-Framework-World-SweepTestByProfile(System-Numerics-Vector3_System-Numerics-Vector3_System-Numerics-Quaternion_string_UnrealEngine-Framework-CollisionShape_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-traceComplex'></a>
`traceComplex` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
<a name='UnrealEngine-Framework-World-SweepTestByProfile(System-Numerics-Vector3_System-Numerics-Vector3_System-Numerics-Quaternion_string_UnrealEngine-Framework-CollisionShape_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-ignoredActor'></a>
`ignoredActor` [Actor](./Actor.md 'UnrealEngine.Framework.Actor')  
  
<a name='UnrealEngine-Framework-World-SweepTestByProfile(System-Numerics-Vector3_System-Numerics-Vector3_System-Numerics-Quaternion_string_UnrealEngine-Framework-CollisionShape_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-ignoredComponent'></a>
`ignoredComponent` [PrimitiveComponent](./PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` on success  
