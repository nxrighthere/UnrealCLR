### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[PlayerController](./PlayerController.md 'UnrealEngine.Framework.PlayerController')
## PlayerController.GetHitResultAtScreenPosition(System.Numerics.Vector2, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.Hit, bool) Method
Retrieves the first blocking hit from the position on the screen  
```csharp
public bool GetHitResultAtScreenPosition(in System.Numerics.Vector2 screenPosition, UnrealEngine.Framework.CollisionChannel traceChannel, ref UnrealEngine.Framework.Hit hit, bool traceComplex=false);
```
#### Parameters
<a name='UnrealEngine-Framework-PlayerController-GetHitResultAtScreenPosition(System-Numerics-Vector2_UnrealEngine-Framework-CollisionChannel_UnrealEngine-Framework-Hit_bool)-screenPosition'></a>
`screenPosition` [System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')  
  
<a name='UnrealEngine-Framework-PlayerController-GetHitResultAtScreenPosition(System-Numerics-Vector2_UnrealEngine-Framework-CollisionChannel_UnrealEngine-Framework-Hit_bool)-traceChannel'></a>
`traceChannel` [CollisionChannel](./CollisionChannel.md 'UnrealEngine.Framework.CollisionChannel')  
  
<a name='UnrealEngine-Framework-PlayerController-GetHitResultAtScreenPosition(System-Numerics-Vector2_UnrealEngine-Framework-CollisionChannel_UnrealEngine-Framework-Hit_bool)-hit'></a>
`hit` [Hit](./Hit.md 'UnrealEngine.Framework.Hit')  
  
<a name='UnrealEngine-Framework-PlayerController-GetHitResultAtScreenPosition(System-Numerics-Vector2_UnrealEngine-Framework-CollisionChannel_UnrealEngine-Framework-Hit_bool)-traceComplex'></a>
`traceComplex` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` on success  
