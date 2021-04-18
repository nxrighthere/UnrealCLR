### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[ConsoleManager](ConsoleManager.md 'UnrealEngine.Framework.ConsoleManager')
## ConsoleManager.RegisterCommand(string, string, ConsoleCommandDelegate, bool) Method
Creates and registers the callback function for a console command that takes no arguments, remains alive during the lifetime of the engine until unregistered  
```csharp
public static void RegisterCommand(string name, string help, UnrealEngine.Framework.ConsoleCommandDelegate callback, bool readOnly=false);
```
#### Parameters
<a name='UnrealEngine_Framework_ConsoleManager_RegisterCommand(string_string_UnrealEngine_Framework_ConsoleCommandDelegate_bool)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the command
  
<a name='UnrealEngine_Framework_ConsoleManager_RegisterCommand(string_string_UnrealEngine_Framework_ConsoleCommandDelegate_bool)_help'></a>
`help` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Help text for the command
  
<a name='UnrealEngine_Framework_ConsoleManager_RegisterCommand(string_string_UnrealEngine_Framework_ConsoleCommandDelegate_bool)_callback'></a>
`callback` [ConsoleCommandDelegate(float)](ConsoleCommandDelegate(float).md 'UnrealEngine.Framework.ConsoleCommandDelegate(float)')  
The function to call when the command is executed
  
<a name='UnrealEngine_Framework_ConsoleManager_RegisterCommand(string_string_UnrealEngine_Framework_ConsoleCommandDelegate_bool)_readOnly'></a>
`readOnly` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, cannot be changed by the user from console
  
