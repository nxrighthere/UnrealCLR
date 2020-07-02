### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[ConsoleManager](./UnrealEngine-Framework-ConsoleManager.md 'UnrealEngine.Framework.ConsoleManager')
## ConsoleManager.RegisterCommand(string, string, UnrealEngine.Framework.ConsoleCommandDelegate, bool) Method
Creates and registers a static callback function to a console command that takes no arguments, remains alive during the lifetime of the engine until unregistered  
```csharp
public static void RegisterCommand(string name, string help, UnrealEngine.Framework.ConsoleCommandDelegate action, bool readOnly=false);
```
#### Parameters
<a name='UnrealEngine-Framework-ConsoleManager-RegisterCommand(string_string_UnrealEngine-Framework-ConsoleCommandDelegate_bool)-name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the command  
  
<a name='UnrealEngine-Framework-ConsoleManager-RegisterCommand(string_string_UnrealEngine-Framework-ConsoleCommandDelegate_bool)-help'></a>
`help` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Help text for the command  
  
<a name='UnrealEngine-Framework-ConsoleManager-RegisterCommand(string_string_UnrealEngine-Framework-ConsoleCommandDelegate_bool)-action'></a>
`action` [ConsoleCommandDelegate(float)](./UnrealEngine-Framework-ConsoleCommandDelegate(float).md 'UnrealEngine.Framework.ConsoleCommandDelegate(float)')  
The static function to call when the command is executed  
  
<a name='UnrealEngine-Framework-ConsoleManager-RegisterCommand(string_string_UnrealEngine-Framework-ConsoleCommandDelegate_bool)-readOnly'></a>
`readOnly` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, cannot be changed by the user from console  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown if [action](#UnrealEngine-Framework-ConsoleManager-RegisterCommand(string_string_UnrealEngine-Framework-ConsoleCommandDelegate_bool)-action 'UnrealEngine.Framework.ConsoleManager.RegisterCommand(string, string, UnrealEngine.Framework.ConsoleCommandDelegate, bool).action') is not static  
### Remarks
Implementation of [action](#UnrealEngine-Framework-ConsoleManager-RegisterCommand(string_string_UnrealEngine-Framework-ConsoleCommandDelegate_bool)-action 'UnrealEngine.Framework.ConsoleManager.RegisterCommand(string, string, UnrealEngine.Framework.ConsoleCommandDelegate, bool).action') should be explicitly wrapped into try-catch blocks to avoid termination of the process due to unhandled exceptions  
