### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[World](./World.md 'UnrealEngine.Framework.World')
## World.LineTraceSingleByProfile(System.Numerics.Vector3, System.Numerics.Vector3, string, UnrealEngine.Framework.Hit, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent) Method
Traces a ray against the world using a specific profile and retrieves the first blocking hit  
```csharp
public static bool LineTraceSingleByProfile(in System.Numerics.Vector3 start, in System.Numerics.Vector3 end, string profileName, ref UnrealEngine.Framework.Hit hit, ref string boneName, bool traceComplex=false, UnrealEngine.Framework.Actor ignoredActor=null, UnrealEngine.Framework.PrimitiveComponent ignoredComponent=null);
```
#### Parameters
<a name='UnrealEngine-Framework-World-LineTraceSingleByProfile(System-Numerics-Vector3_System-Numerics-Vector3_string_UnrealEngine-Framework-Hit_string_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-start'></a>
`start` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
<a name='UnrealEngine-Framework-World-LineTraceSingleByProfile(System-Numerics-Vector3_System-Numerics-Vector3_string_UnrealEngine-Framework-Hit_string_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-end'></a>
`end` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
<a name='UnrealEngine-Framework-World-LineTraceSingleByProfile(System-Numerics-Vector3_System-Numerics-Vector3_string_UnrealEngine-Framework-Hit_string_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-profileName'></a>
`profileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='UnrealEngine-Framework-World-LineTraceSingleByProfile(System-Numerics-Vector3_System-Numerics-Vector3_string_UnrealEngine-Framework-Hit_string_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-hit'></a>
`hit` [Hit](./Hit.md 'UnrealEngine.Framework.Hit')  
  
<a name='UnrealEngine-Framework-World-LineTraceSingleByProfile(System-Numerics-Vector3_System-Numerics-Vector3_string_UnrealEngine-Framework-Hit_string_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-boneName'></a>
`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='UnrealEngine-Framework-World-LineTraceSingleByProfile(System-Numerics-Vector3_System-Numerics-Vector3_string_UnrealEngine-Framework-Hit_string_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-traceComplex'></a>
`traceComplex` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
<a name='UnrealEngine-Framework-World-LineTraceSingleByProfile(System-Numerics-Vector3_System-Numerics-Vector3_string_UnrealEngine-Framework-Hit_string_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-ignoredActor'></a>
`ignoredActor` [Actor](./Actor.md 'UnrealEngine.Framework.Actor')  
  
<a name='UnrealEngine-Framework-World-LineTraceSingleByProfile(System-Numerics-Vector3_System-Numerics-Vector3_string_UnrealEngine-Framework-Hit_string_bool_UnrealEngine-Framework-Actor_UnrealEngine-Framework-PrimitiveComponent)-ignoredComponent'></a>
`ignoredComponent` [PrimitiveComponent](./PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` on success  
