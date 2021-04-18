### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[ConsoleManager](./ConsoleManager.md 'UnrealEngine.Framework.ConsoleManager')
## ConsoleManager.RegisterVariable(string, string, string, bool) Method
Creates and registers a string console variable, remains alive during the lifetime of the engine until unregistered  
```csharp
public static UnrealEngine.Framework.ConsoleVariable RegisterVariable(string name, string help, string defaultValue=null, bool readOnly=false);
```
#### Parameters
<a name='UnrealEngine-Framework-ConsoleManager-RegisterVariable(string_string_string_bool)-name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the variable  
  
<a name='UnrealEngine-Framework-ConsoleManager-RegisterVariable(string_string_string_bool)-help'></a>
`help` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Help text for the variable  
  
<a name='UnrealEngine-Framework-ConsoleManager-RegisterVariable(string_string_string_bool)-defaultValue'></a>
`defaultValue` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A default value  
  
<a name='UnrealEngine-Framework-ConsoleManager-RegisterVariable(string_string_string_bool)-readOnly'></a>
`readOnly` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, cannot be changed by the user from console  
  
#### Returns
[ConsoleVariable](./ConsoleVariable.md 'UnrealEngine.Framework.ConsoleVariable')  
A console variable or `null` on failure  
