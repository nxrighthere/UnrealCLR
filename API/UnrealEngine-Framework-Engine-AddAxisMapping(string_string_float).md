### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Engine](./UnrealEngine-Framework-Engine.md 'UnrealEngine.Framework.Engine')
## Engine.AddAxisMapping(string, string, float) Method
Adds an engine defined mapping between an axis and key, cannot be remapped  
```csharp
public static void AddAxisMapping(string axisName, string key, float scale=1f);
```
#### Parameters
<a name='UnrealEngine-Framework-Engine-AddAxisMapping(string_string_float)-axisName'></a>
`axisName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Friendly name of axis  
  
<a name='UnrealEngine-Framework-Engine-AddAxisMapping(string_string_float)-key'></a>
`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Key to bind in accordance with [Keys](./UnrealEngine-Framework-Keys.md 'UnrealEngine.Framework.Keys')  
  
<a name='UnrealEngine-Framework-Engine-AddAxisMapping(string_string_float)-scale'></a>
`scale` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Multiplier to use for the mapping when accumulating the axis value  
  
