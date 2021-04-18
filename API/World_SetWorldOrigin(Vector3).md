### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[World](World.md 'UnrealEngine.Framework.World')
## World.SetWorldOrigin(Vector3) Method
Sets <a href="https://docs.unrealengine.com/en-US/Engine/LevelStreaming/WorldBrowser/index.html">world origin</a> to the specified location  
```csharp
public static bool SetWorldOrigin(in System.Numerics.Vector3 value);
```
#### Parameters
<a name='UnrealEngine_Framework_World_SetWorldOrigin(System_Numerics_Vector3)_value'></a>
`value` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the world origin was succesfuly shifted, or `false` if one of the levels are pending visibility update
