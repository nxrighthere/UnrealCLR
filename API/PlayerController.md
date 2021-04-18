### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## PlayerController Class
An actor that is used by human players to control a [Pawn](Pawn.md 'UnrealEngine.Framework.Pawn')
```csharp
public class PlayerController : UnrealEngine.Framework.Controller
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Actor](Actor.md 'UnrealEngine.Framework.Actor') &#129106; [Controller](Controller.md 'UnrealEngine.Framework.Controller') &#129106; PlayerController  
### Constructors

***
[PlayerController(string, Blueprint)](PlayerController_PlayerController(string_Blueprint).md 'UnrealEngine.Framework.PlayerController.PlayerController(string, UnrealEngine.Framework.Blueprint)')

Spawns the actor in the world  
### Properties

***
[EnableClickEvents](PlayerController_EnableClickEvents.md 'UnrealEngine.Framework.PlayerController.EnableClickEvents')

Gets or sets whether click events should be generated  

***
[EnableMouseOverEvents](PlayerController_EnableMouseOverEvents.md 'UnrealEngine.Framework.PlayerController.EnableMouseOverEvents')

Gets or sets whether the mouse over events should be generated  

***
[IsPaused](PlayerController_IsPaused.md 'UnrealEngine.Framework.PlayerController.IsPaused')

Returns `true` if game is currently paused  

***
[ShowMouseCursor](PlayerController_ShowMouseCursor.md 'UnrealEngine.Framework.PlayerController.ShowMouseCursor')

Gets or sets whether the mouse cursor should be displayed  
### Methods

***
[AddPitchInput(float)](PlayerController_AddPitchInput(float).md 'UnrealEngine.Framework.PlayerController.AddPitchInput(float)')

Adds pitch (look up) input  

***
[AddRollInput(float)](PlayerController_AddRollInput(float).md 'UnrealEngine.Framework.PlayerController.AddRollInput(float)')

Adds roll input  

***
[AddYawInput(float)](PlayerController_AddYawInput(float).md 'UnrealEngine.Framework.PlayerController.AddYawInput(float)')

Adds yaw (turn) input  

***
[ConsoleCommand(string, bool)](PlayerController_ConsoleCommand(string_bool).md 'UnrealEngine.Framework.PlayerController.ConsoleCommand(string, bool)')

Executes the command on the [Player](Player.md 'UnrealEngine.Framework.Player') object, `DumpConsoleCommands` command can be used to list all available variables and commands  

***
[GetHitResultAtScreenPosition(Vector2, CollisionChannel, Hit, bool)](PlayerController_GetHitResultAtScreenPosition(Vector2_CollisionChannel_Hit_bool).md 'UnrealEngine.Framework.PlayerController.GetHitResultAtScreenPosition(System.Numerics.Vector2, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.Hit, bool)')

Retrieves the first blocking hit from the position on the screen  

***
[GetHitResultUnderCursor(CollisionChannel, Hit, bool)](PlayerController_GetHitResultUnderCursor(CollisionChannel_Hit_bool).md 'UnrealEngine.Framework.PlayerController.GetHitResultUnderCursor(UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.Hit, bool)')

Retrieves the first blocking hit under the mouse cursor  

***
[GetMousePosition(float, float)](PlayerController_GetMousePosition(float_float).md 'UnrealEngine.Framework.PlayerController.GetMousePosition(float, float)')

Retrieves the X and Y screen coordinates of the mouse cursor  

***
[GetPlayer()](PlayerController_GetPlayer().md 'UnrealEngine.Framework.PlayerController.GetPlayer()')

Returns the player representation or `null` on failure  

***
[GetPlayerInput()](PlayerController_GetPlayerInput().md 'UnrealEngine.Framework.PlayerController.GetPlayerInput()')

Returns the input manager or `null` on failure  

***
[SetMousePosition(float, float)](PlayerController_SetMousePosition(float_float).md 'UnrealEngine.Framework.PlayerController.SetMousePosition(float, float)')

Positions the mouse cursor in screen space, in pixels  

***
[SetPause(bool)](PlayerController_SetPause(bool).md 'UnrealEngine.Framework.PlayerController.SetPause(bool)')

Pauses a local game  

***
[SetViewTarget(Actor)](PlayerController_SetViewTarget(Actor).md 'UnrealEngine.Framework.PlayerController.SetViewTarget(UnrealEngine.Framework.Actor)')

Sets the view target  

***
[SetViewTargetWithBlend(Actor, float, float, BlendType, bool)](PlayerController_SetViewTargetWithBlend(Actor_float_float_BlendType_bool).md 'UnrealEngine.Framework.PlayerController.SetViewTargetWithBlend(UnrealEngine.Framework.Actor, float, float, UnrealEngine.Framework.BlendType, bool)')

Sets the view target blending with variable control  
