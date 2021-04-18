### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[World](./World.md 'UnrealEngine.Framework.World')
## World.LineTraceTestByChannel(System.Numerics.Vector3, System.Numerics.Vector3, UnrealEngine.Framework.CollisionChannel, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent) Method
Traces a ray against the world using a specific channel  
```csharp
public static bool LineTraceTestByChannel(in System.Numerics.Vector3 start, in System.Numerics.Vector3 end, UnrealEngine.Framework.CollisionChannel channel, bool traceComplex=false, UnrealEngine.Framework.Actor ignoredActor=null, UnrealEngine.Framework.PrimitiveComponent ignoredComponent=null);
```
#### Parameters
<a name='UnrealEngine-Framework-World-LineTraceTestByChannel(System-Numerics-Vector3_System-Numerics-Vector3_UnrealEngine-Framework-CollisionChannel_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-start'></a>
`start` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
<a name='UnrealEngine-Framework-World-LineTraceTestByChannel(System-Numerics-Vector3_System-Numerics-Vector3_UnrealEngine-Framework-CollisionChannel_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-end'></a>
`end` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
<a name='UnrealEngine-Framework-World-LineTraceTestByChannel(System-Numerics-Vector3_System-Numerics-Vector3_UnrealEngine-Framework-CollisionChannel_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-channel'></a>
`channel` [CollisionChannel](./CollisionChannel.md 'UnrealEngine.Framework.CollisionChannel')  
  
<a name='UnrealEngine-Framework-World-LineTraceTestByChannel(System-Numerics-Vector3_System-Numerics-Vector3_UnrealEngine-Framework-CollisionChannel_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-traceComplex'></a>
`traceComplex` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
<a name='UnrealEngine-Framework-World-LineTraceTestByChannel(System-Numerics-Vector3_System-Numerics-Vector3_UnrealEngine-Framework-CollisionChannel_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-ignoredActor'></a>
`ignoredActor` [Actor](./Actor.md 'UnrealEngine.Framework.Actor')  
  
<a name='UnrealEngine-Framework-World-LineTraceTestByChannel(System-Numerics-Vector3_System-Numerics-Vector3_UnrealEngine-Framework-CollisionChannel_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-ignoredComponent'></a>
`ignoredComponent` [PrimitiveComponent](./PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` on success  
