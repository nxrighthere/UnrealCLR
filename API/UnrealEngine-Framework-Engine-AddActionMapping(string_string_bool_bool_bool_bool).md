### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Engine](./UnrealEngine-Framework-Engine.md 'UnrealEngine.Framework.Engine')
## Engine.AddActionMapping(string, string, bool, bool, bool, bool) Method
Adds an engine defined axis mapping, cannot be remapped  
```csharp
public static void AddActionMapping(string actionName, string key, bool shift=false, bool ctrl=false, bool alt=false, bool cmd=false);
```
#### Parameters
<a name='UnrealEngine-Framework-Engine-AddActionMapping(string_string_bool_bool_bool_bool)-actionName'></a>
`actionName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Friendly name of action  
  
<a name='UnrealEngine-Framework-Engine-AddActionMapping(string_string_bool_bool_bool_bool)-key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Key to bind in accordance with [Keys](./UnrealEngine-Framework-Keys.md 'UnrealEngine.Framework.Keys')  
  
<a name='UnrealEngine-Framework-Engine-AddActionMapping(string_string_bool_bool_bool_bool)-shift'></a>
`shift` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if one of the Shift keys must be down when the KeyEvent is received to be acknowledged  
  
<a name='UnrealEngine-Framework-Engine-AddActionMapping(string_string_bool_bool_bool_bool)-ctrl'></a>
`ctrl` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if one of the Ctrl keys must be down when the KeyEvent is received to be acknowledged  
  
<a name='UnrealEngine-Framework-Engine-AddActionMapping(string_string_bool_bool_bool_bool)-alt'></a>
`alt` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if one of the Alt keys must be down when the KeyEvent is received to be acknowledged  
  
<a name='UnrealEngine-Framework-Engine-AddActionMapping(string_string_bool_bool_bool_bool)-cmd'></a>
`cmd` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if one of the Cmd keys must be down when the KeyEvent is received to be acknowledged  
  
