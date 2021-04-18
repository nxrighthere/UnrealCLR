### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[Engine](Engine.md 'UnrealEngine.Framework.Engine')
## Engine.AddActionMapping(string, string, bool, bool, bool, bool) Method
Adds an engine defined action mapping, cannot be remapped  
```csharp
public static void AddActionMapping(string actionName, string key, bool shift=false, bool ctrl=false, bool alt=false, bool cmd=false);
```
#### Parameters
<a name='UnrealEngine_Framework_Engine_AddActionMapping(string_string_bool_bool_bool_bool)_actionName'></a>
`actionName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Friendly name of action
  
<a name='UnrealEngine_Framework_Engine_AddActionMapping(string_string_bool_bool_bool_bool)_key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Key to bind in accordance with [Keys](Keys.md 'UnrealEngine.Framework.Keys')
  
<a name='UnrealEngine_Framework_Engine_AddActionMapping(string_string_bool_bool_bool_bool)_shift'></a>
`shift` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if one of the Shift keys must be down when the KeyEvent is received to be acknowledged
  
<a name='UnrealEngine_Framework_Engine_AddActionMapping(string_string_bool_bool_bool_bool)_ctrl'></a>
`ctrl` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if one of the Ctrl keys must be down when the KeyEvent is received to be acknowledged
  
<a name='UnrealEngine_Framework_Engine_AddActionMapping(string_string_bool_bool_bool_bool)_alt'></a>
`alt` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if one of the Alt keys must be down when the KeyEvent is received to be acknowledged
  
<a name='UnrealEngine_Framework_Engine_AddActionMapping(string_string_bool_bool_bool_bool)_cmd'></a>
`cmd` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if one of the Cmd keys must be down when the KeyEvent is received to be acknowledged
  
