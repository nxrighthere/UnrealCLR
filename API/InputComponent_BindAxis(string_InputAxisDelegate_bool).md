### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[InputComponent](InputComponent.md 'UnrealEngine.Framework.InputComponent')
## InputComponent.BindAxis(string, InputAxisDelegate, bool) Method
Binds the callback function to an axis defined in the project settings, or by using [AddAxisMapping(string, string, float)](Engine_AddAxisMapping(string_string_float).md 'UnrealEngine.Framework.Engine.AddAxisMapping(string, string, float)') and [AddAxisMapping(string, string, float)](PlayerInput_AddAxisMapping(string_string_float).md 'UnrealEngine.Framework.PlayerInput.AddAxisMapping(string, string, float)')
```csharp
public void BindAxis(string axisName, UnrealEngine.Framework.InputAxisDelegate callback, bool executedWhenPaused=false);
```
#### Parameters
<a name='UnrealEngine_Framework_InputComponent_BindAxis(string_UnrealEngine_Framework_InputAxisDelegate_bool)_axisName'></a>
`axisName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the axis
  
<a name='UnrealEngine_Framework_InputComponent_BindAxis(string_UnrealEngine_Framework_InputAxisDelegate_bool)_callback'></a>
`callback` [InputAxisDelegate(float)](InputAxisDelegate(float).md 'UnrealEngine.Framework.InputAxisDelegate(float)')  
The function to call while tracking axis
  
<a name='UnrealEngine_Framework_InputComponent_BindAxis(string_UnrealEngine_Framework_InputAxisDelegate_bool)_executedWhenPaused'></a>
`executedWhenPaused` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, executes even if the game is paused
  
