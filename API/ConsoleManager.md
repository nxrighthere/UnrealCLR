### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## ConsoleManager Class
Handles console commands and variables  
```csharp
public static class ConsoleManager
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ConsoleManager  
### Methods

***
[FindVariable(string)](ConsoleManager_FindVariable(string).md 'UnrealEngine.Framework.ConsoleManager.FindVariable(string)')

Finds a console variable  

***
[IsRegisteredVariable(string)](ConsoleManager_IsRegisteredVariable(string).md 'UnrealEngine.Framework.ConsoleManager.IsRegisteredVariable(string)')

Returns `true` if a console command or variable has been registered  

***
[RegisterCommand(string, string, ConsoleCommandDelegate, bool)](ConsoleManager_RegisterCommand(string_string_ConsoleCommandDelegate_bool).md 'UnrealEngine.Framework.ConsoleManager.RegisterCommand(string, string, UnrealEngine.Framework.ConsoleCommandDelegate, bool)')

Creates and registers the callback function for a console command that takes no arguments, remains alive during the lifetime of the engine until unregistered  

***
[RegisterVariable(string, string, bool, bool)](ConsoleManager_RegisterVariable(string_string_bool_bool).md 'UnrealEngine.Framework.ConsoleManager.RegisterVariable(string, string, bool, bool)')

Creates and registers a bool console variable, remains alive during the lifetime of the engine until unregistered  

***
[RegisterVariable(string, string, float, bool)](ConsoleManager_RegisterVariable(string_string_float_bool).md 'UnrealEngine.Framework.ConsoleManager.RegisterVariable(string, string, float, bool)')

Creates and registers a float console variable, remains alive during the lifetime of the engine until unregistered  

***
[RegisterVariable(string, string, int, bool)](ConsoleManager_RegisterVariable(string_string_int_bool).md 'UnrealEngine.Framework.ConsoleManager.RegisterVariable(string, string, int, bool)')

Creates and registers an integer console variable, remains alive during the lifetime of the engine until unregistered  

***
[RegisterVariable(string, string, string, bool)](ConsoleManager_RegisterVariable(string_string_string_bool).md 'UnrealEngine.Framework.ConsoleManager.RegisterVariable(string, string, string, bool)')

Creates and registers a string console variable, remains alive during the lifetime of the engine until unregistered  

***
[UnregisterObject(string)](ConsoleManager_UnregisterObject(string).md 'UnrealEngine.Framework.ConsoleManager.UnregisterObject(string)')

Deletes and unregisters a console command or variable  
