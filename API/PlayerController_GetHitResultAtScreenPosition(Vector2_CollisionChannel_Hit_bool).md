### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')
## PlayerController.GetHitResultAtScreenPosition(Vector2, CollisionChannel, Hit, bool) Method
Retrieves the first blocking hit from the position on the screen  
```csharp
public bool GetHitResultAtScreenPosition(in System.Numerics.Vector2 screenPosition, UnrealEngine.Framework.CollisionChannel traceChannel, ref UnrealEngine.Framework.Hit hit, bool traceComplex=false);
```
#### Parameters
<a name='UnrealEngine_Framework_PlayerController_GetHitResultAtScreenPosition(System_Numerics_Vector2_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_bool)_screenPosition'></a>
`screenPosition` [System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')  
  
<a name='UnrealEngine_Framework_PlayerController_GetHitResultAtScreenPosition(System_Numerics_Vector2_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_bool)_traceChannel'></a>
`traceChannel` [CollisionChannel](CollisionChannel.md 'UnrealEngine.Framework.CollisionChannel')  
  
<a name='UnrealEngine_Framework_PlayerController_GetHitResultAtScreenPosition(System_Numerics_Vector2_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_bool)_hit'></a>
`hit` [Hit](Hit.md 'UnrealEngine.Framework.Hit')  
  
<a name='UnrealEngine_Framework_PlayerController_GetHitResultAtScreenPosition(System_Numerics_Vector2_UnrealEngine_Framework_CollisionChannel_UnrealEngine_Framework_Hit_bool)_traceComplex'></a>
`traceComplex` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` on success
