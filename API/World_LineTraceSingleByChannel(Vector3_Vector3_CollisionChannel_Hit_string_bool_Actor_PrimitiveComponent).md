### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[World](World.md 'UnrealEngine.Framework.World')
## World.LineTraceSingleByChannel(Vector3, Vector3, CollisionChannel, Hit, string, bool, Actor, PrimitiveComponent) Method
Traces a ray against the world using a specific channel and retrieves the first blocking hit with a bone name  
```csharp
public static bool LineTraceSingleByChannel(in System.Numerics.Vector3 start, in System.Numerics.Vector3 end, UnrealEngine.Framework.CollisionChannel channel, ref UnrealEngine.Framework.Hit hit, ref string boneName, bool traceComplex=false, UnrealEngine.Framework.Actor ignoredActor=null, UnrealEngine.Framework.PrimitiveComponent ignoredComponent=null);
```
#### Parameters
<a name='UnrealEngine_Framework_World_LineTraceSingleByChannel(System_Numerics_Vector3_System_Numerics_Vector3_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_string_bool_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_start'></a>
`start` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
<a name='UnrealEngine_Framework_World_LineTraceSingleByChannel(System_Numerics_Vector3_System_Numerics_Vector3_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_string_bool_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_end'></a>
`end` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
<a name='UnrealEngine_Framework_World_LineTraceSingleByChannel(System_Numerics_Vector3_System_Numerics_Vector3_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_string_bool_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_channel'></a>
`channel` [CollisionChannel](CollisionChannel.md 'UnrealEngine.Framework.CollisionChannel')  
  
<a name='UnrealEngine_Framework_World_LineTraceSingleByChannel(System_Numerics_Vector3_System_Numerics_Vector3_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_string_bool_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_hit'></a>
`hit` [Hit](Hit.md 'UnrealEngine.Framework.Hit')  
  
<a name='UnrealEngine_Framework_World_LineTraceSingleByChannel(System_Numerics_Vector3_System_Numerics_Vector3_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_string_bool_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_boneName'></a>
`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='UnrealEngine_Framework_World_LineTraceSingleByChannel(System_Numerics_Vector3_System_Numerics_Vector3_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_string_bool_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_traceComplex'></a>
`traceComplex` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
<a name='UnrealEngine_Framework_World_LineTraceSingleByChannel(System_Numerics_Vector3_System_Numerics_Vector3_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_string_bool_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_ignoredActor'></a>
`ignoredActor` [Actor](Actor.md 'UnrealEngine.Framework.Actor')  
  
<a name='UnrealEngine_Framework_World_LineTraceSingleByChannel(System_Numerics_Vector3_System_Numerics_Vector3_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_string_bool_UnrealEngine_Framework_Actor_UnrealEngine_Framework_PrimitiveComponent)_ignoredComponent'></a>
`ignoredComponent` [PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` on success
