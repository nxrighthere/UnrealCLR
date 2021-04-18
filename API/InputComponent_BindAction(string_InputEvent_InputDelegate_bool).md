### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[InputComponent](InputComponent.md 'UnrealEngine.Framework.InputComponent')
## InputComponent.BindAction(string, InputEvent, InputDelegate, bool) Method
Binds the callback function to an action defined in the project settings, or by using [AddActionMapping(string, string, bool, bool, bool, bool)](Engine_AddActionMapping(string_string_bool_bool_bool_bool).md 'UnrealEngine.Framework.Engine.AddActionMapping(string, string, bool, bool, bool, bool)') and [AddActionMapping(string, string, bool, bool, bool, bool)](PlayerInput_AddActionMapping(string_string_bool_bool_bool_bool).md 'UnrealEngine.Framework.PlayerInput.AddActionMapping(string, string, bool, bool, bool, bool)')
```csharp
public void BindAction(string actionName, UnrealEngine.Framework.InputEvent keyEvent, UnrealEngine.Framework.InputDelegate callback, bool executedWhenPaused=false);
```
#### Parameters
<a name='UnrealEngine_Framework_InputComponent_BindAction(string_UnrealEngine_Framework_InputEvent_UnrealEngine_Framework_InputDelegate_bool)_actionName'></a>
`actionName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the action
  
<a name='UnrealEngine_Framework_InputComponent_BindAction(string_UnrealEngine_Framework_InputEvent_UnrealEngine_Framework_InputDelegate_bool)_keyEvent'></a>
`keyEvent` [InputEvent](InputEvent.md 'UnrealEngine.Framework.InputEvent')  
The type of input behavior
  
<a name='UnrealEngine_Framework_InputComponent_BindAction(string_UnrealEngine_Framework_InputEvent_UnrealEngine_Framework_InputDelegate_bool)_callback'></a>
`callback` [InputDelegate()](InputDelegate().md 'UnrealEngine.Framework.InputDelegate()')  
The function to call when the input is triggered
  
<a name='UnrealEngine_Framework_InputComponent_BindAction(string_UnrealEngine_Framework_InputEvent_UnrealEngine_Framework_InputDelegate_bool)_executedWhenPaused'></a>
`executedWhenPaused` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, executes even if the game is paused
  
