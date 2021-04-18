### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## PlayerInput Class
An input manager of [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')
```csharp
public class PlayerInput :
System.IEquatable<UnrealEngine.Framework.PlayerInput>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PlayerInput  

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[PlayerInput](PlayerInput.md 'UnrealEngine.Framework.PlayerInput')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Properties

***
[IsCreated](PlayerInput_IsCreated.md 'UnrealEngine.Framework.PlayerInput.IsCreated')

Returns `true` if the object is created  
### Methods

***
[AddActionMapping(string, string, bool, bool, bool, bool)](PlayerInput_AddActionMapping(string_string_bool_bool_bool_bool).md 'UnrealEngine.Framework.PlayerInput.AddActionMapping(string, string, bool, bool, bool, bool)')

Adds a player-specific action mapping  

***
[AddAxisMapping(string, string, float)](PlayerInput_AddAxisMapping(string_string_float).md 'UnrealEngine.Framework.PlayerInput.AddAxisMapping(string, string, float)')

Adds a player-specific mapping between an axis and key  

***
[Equals(PlayerInput)](PlayerInput_Equals(PlayerInput).md 'UnrealEngine.Framework.PlayerInput.Equals(UnrealEngine.Framework.PlayerInput)')

Indicates equality of objects  

***
[GetHashCode()](PlayerInput_GetHashCode().md 'UnrealEngine.Framework.PlayerInput.GetHashCode()')

Returns a hash code for the object  

***
[GetMouseSensitivity()](PlayerInput_GetMouseSensitivity().md 'UnrealEngine.Framework.PlayerInput.GetMouseSensitivity()')

Returns mouse sensitivity  

***
[GetMouseSensitivity(Vector2)](PlayerInput_GetMouseSensitivity(Vector2).md 'UnrealEngine.Framework.PlayerInput.GetMouseSensitivity(System.Numerics.Vector2)')

Retrieves mouse sensitivity  

***
[GetTimeKeyPressed(string)](PlayerInput_GetTimeKeyPressed(string).md 'UnrealEngine.Framework.PlayerInput.GetTimeKeyPressed(string)')

Returns the time a key was pressed  

***
[IsKeyPressed(string)](PlayerInput_IsKeyPressed(string).md 'UnrealEngine.Framework.PlayerInput.IsKeyPressed(string)')

Returns `true` if a key is pressed  

***
[RemoveActionMapping(string, string)](PlayerInput_RemoveActionMapping(string_string).md 'UnrealEngine.Framework.PlayerInput.RemoveActionMapping(string, string)')

Removes a player-specific action mapping  

***
[RemoveAxisMapping(string, string)](PlayerInput_RemoveAxisMapping(string_string).md 'UnrealEngine.Framework.PlayerInput.RemoveAxisMapping(string, string)')

Removes a player-specific mapping between an axis and key  

***
[SetMouseSensitivity(Vector2)](PlayerInput_SetMouseSensitivity(Vector2).md 'UnrealEngine.Framework.PlayerInput.SetMouseSensitivity(System.Numerics.Vector2)')

Sets mouse sensitivity  
