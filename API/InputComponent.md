### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## InputComponent Class
An input component is a transient component that enables an actor to bind various forms of input events to delegate functions  
```csharp
public class InputComponent : UnrealEngine.Framework.ActorComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; InputComponent  
### Properties

***
[ActionBindingsNumber](InputComponent_ActionBindingsNumber.md 'UnrealEngine.Framework.InputComponent.ActionBindingsNumber')

Returns the number of action bindings  

***
[BlockInput](InputComponent_BlockInput.md 'UnrealEngine.Framework.InputComponent.BlockInput')

Gets or sets whether any components lower on the input stack should be allowed to receive input  

***
[HasBindings](InputComponent_HasBindings.md 'UnrealEngine.Framework.InputComponent.HasBindings')

Indicates whether the component has any input bindings  

***
[Priority](InputComponent_Priority.md 'UnrealEngine.Framework.InputComponent.Priority')

Gets or sets the priority of the input component when pushed in to the stack  
### Methods

***
[BindAction(string, InputEvent, InputDelegate, bool)](InputComponent_BindAction(string_InputEvent_InputDelegate_bool).md 'UnrealEngine.Framework.InputComponent.BindAction(string, UnrealEngine.Framework.InputEvent, UnrealEngine.Framework.InputDelegate, bool)')

Binds the callback function to an action defined in the project settings, or by using [AddActionMapping(string, string, bool, bool, bool, bool)](Engine_AddActionMapping(string_string_bool_bool_bool_bool).md 'UnrealEngine.Framework.Engine.AddActionMapping(string, string, bool, bool, bool, bool)') and [AddActionMapping(string, string, bool, bool, bool, bool)](PlayerInput_AddActionMapping(string_string_bool_bool_bool_bool).md 'UnrealEngine.Framework.PlayerInput.AddActionMapping(string, string, bool, bool, bool, bool)')

***
[BindAxis(string, InputAxisDelegate, bool)](InputComponent_BindAxis(string_InputAxisDelegate_bool).md 'UnrealEngine.Framework.InputComponent.BindAxis(string, UnrealEngine.Framework.InputAxisDelegate, bool)')

Binds the callback function to an axis defined in the project settings, or by using [AddAxisMapping(string, string, float)](Engine_AddAxisMapping(string_string_float).md 'UnrealEngine.Framework.Engine.AddAxisMapping(string, string, float)') and [AddAxisMapping(string, string, float)](PlayerInput_AddAxisMapping(string_string_float).md 'UnrealEngine.Framework.PlayerInput.AddAxisMapping(string, string, float)')

***
[ClearActionBindings()](InputComponent_ClearActionBindings().md 'UnrealEngine.Framework.InputComponent.ClearActionBindings()')

Removes all action bindings  

***
[RemoveActionBinding(string, InputEvent)](InputComponent_RemoveActionBinding(string_InputEvent).md 'UnrealEngine.Framework.InputComponent.RemoveActionBinding(string, UnrealEngine.Framework.InputEvent)')

Removes the action binding  
