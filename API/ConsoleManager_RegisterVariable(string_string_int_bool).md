### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[ConsoleManager](ConsoleManager.md 'UnrealEngine.Framework.ConsoleManager')
## ConsoleManager.RegisterVariable(string, string, int, bool) Method
Creates and registers an integer console variable, remains alive during the lifetime of the engine until unregistered  
```csharp
public static UnrealEngine.Framework.ConsoleVariable RegisterVariable(string name, string help, int defaultValue=0, bool readOnly=false);
```
#### Parameters
<a name='UnrealEngine_Framework_ConsoleManager_RegisterVariable(string_string_int_bool)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the variable
  
<a name='UnrealEngine_Framework_ConsoleManager_RegisterVariable(string_string_int_bool)_help'></a>
`help` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Help text for the variable
  
<a name='UnrealEngine_Framework_ConsoleManager_RegisterVariable(string_string_int_bool)_defaultValue'></a>
`defaultValue` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A default value
  
<a name='UnrealEngine_Framework_ConsoleManager_RegisterVariable(string_string_int_bool)_readOnly'></a>
`readOnly` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, cannot be changed by the user from console
  
#### Returns
[ConsoleVariable](ConsoleVariable.md 'UnrealEngine.Framework.ConsoleVariable')  
A console variable or `null` on failure
