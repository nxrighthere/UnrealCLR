### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')
## PlayerController.SetViewTargetWithBlend(Actor, float, float, BlendType, bool) Method
Sets the view target blending with variable control  
```csharp
public void SetViewTargetWithBlend(UnrealEngine.Framework.Actor newViewTarget, float time=0f, float exponent=0f, UnrealEngine.Framework.BlendType type=UnrealEngine.Framework.BlendType.Linear, bool lockOutgoing=false);
```
#### Parameters
<a name='UnrealEngine_Framework_PlayerController_SetViewTargetWithBlend(UnrealEngine_Framework_Actor_float_float_UnrealEngine_Framework_BlendType_bool)_newViewTarget'></a>
`newViewTarget` [Actor](Actor.md 'UnrealEngine.Framework.Actor')  
An actor to set as view target
  
<a name='UnrealEngine_Framework_PlayerController_SetViewTargetWithBlend(UnrealEngine_Framework_Actor_float_float_UnrealEngine_Framework_BlendType_bool)_time'></a>
`time` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Time taken to blend
  
<a name='UnrealEngine_Framework_PlayerController_SetViewTargetWithBlend(UnrealEngine_Framework_Actor_float_float_UnrealEngine_Framework_BlendType_bool)_exponent'></a>
`exponent` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Exponent, used by certain [BlendType](BlendType.md 'UnrealEngine.Framework.BlendType') to control the shape of the curve
  
<a name='UnrealEngine_Framework_PlayerController_SetViewTargetWithBlend(UnrealEngine_Framework_Actor_float_float_UnrealEngine_Framework_BlendType_bool)_type'></a>
`type` [BlendType](BlendType.md 'UnrealEngine.Framework.BlendType')  
The blending type
  
<a name='UnrealEngine_Framework_PlayerController_SetViewTargetWithBlend(UnrealEngine_Framework_Actor_float_float_UnrealEngine_Framework_BlendType_bool)_lockOutgoing'></a>
`lockOutgoing` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, lock outgoing view target to last frame's camera position for the remainder of the blend
  
