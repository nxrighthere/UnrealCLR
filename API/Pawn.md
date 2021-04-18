### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Pawn Class
The base class of actors that can be possessed by players or AI  
```csharp
public class Pawn : UnrealEngine.Framework.Actor
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Actor](Actor.md 'UnrealEngine.Framework.Actor') &#129106; Pawn  

Derived  
&#8627; [Character](Character.md 'UnrealEngine.Framework.Character')  
### Constructors

***
[Pawn(string, Blueprint)](Pawn_Pawn(string_Blueprint).md 'UnrealEngine.Framework.Pawn.Pawn(string, UnrealEngine.Framework.Blueprint)')

Spawns the actor in the world  
### Properties

***
[AutoPossessAI](Pawn_AutoPossessAI.md 'UnrealEngine.Framework.Pawn.AutoPossessAI')

Gets or sets the automatic possession type by an AI controller  

***
[AutoPossessPlayer](Pawn_AutoPossessPlayer.md 'UnrealEngine.Framework.Pawn.AutoPossessPlayer')

Gets or sets the player index for automatic possession by a player controller  

***
[IsControlled](Pawn_IsControlled.md 'UnrealEngine.Framework.Pawn.IsControlled')

Returns `true` if the pawn is possesed by a [Controller](Controller.md 'UnrealEngine.Framework.Controller')

***
[IsPlayerControlled](Pawn_IsPlayerControlled.md 'UnrealEngine.Framework.Pawn.IsPlayerControlled')

Returns `true` if the pawn is possesed by a [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')

***
[UseControllerRotationPitch](Pawn_UseControllerRotationPitch.md 'UnrealEngine.Framework.Pawn.UseControllerRotationPitch')

Gets or sets whether pitch will be updated to match the controller's control rotation pitch, if controlled by a [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')

***
[UseControllerRotationRoll](Pawn_UseControllerRotationRoll.md 'UnrealEngine.Framework.Pawn.UseControllerRotationRoll')

Gets or sets whether roll will be updated to match the controller's control rotation roll, if controlled by a [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')

***
[UseControllerRotationYaw](Pawn_UseControllerRotationYaw.md 'UnrealEngine.Framework.Pawn.UseControllerRotationYaw')

Gets or sets whether yaw will be updated to match the controller's control rotation yaw, if controlled by a [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')
### Methods

***
[AddControllerPitchInput(float)](Pawn_AddControllerPitchInput(float).md 'UnrealEngine.Framework.Pawn.AddControllerPitchInput(float)')

Adds pitch (look up) input to the controller, if it's a local [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')

***
[AddControllerRollInput(float)](Pawn_AddControllerRollInput(float).md 'UnrealEngine.Framework.Pawn.AddControllerRollInput(float)')

Adds roll input to the controller, if it's a local [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')

***
[AddControllerYawInput(float)](Pawn_AddControllerYawInput(float).md 'UnrealEngine.Framework.Pawn.AddControllerYawInput(float)')

Adds yaw (turn) input to the controller, if it's a local [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')

***
[AddMovementInput(Vector3, float, bool)](Pawn_AddMovementInput(Vector3_float_bool).md 'UnrealEngine.Framework.Pawn.AddMovementInput(System.Numerics.Vector3, float, bool)')

Adds movement input along the given world direction vector (usually normalized)  

***
[GetAIController()](Pawn_GetAIController().md 'UnrealEngine.Framework.Pawn.GetAIController()')

Returns the AI controller or `null` on failure  

***
[GetGravityDirection()](Pawn_GetGravityDirection().md 'UnrealEngine.Framework.Pawn.GetGravityDirection()')

Returns vector direction of gravity  

***
[GetGravityDirection(Vector3)](Pawn_GetGravityDirection(Vector3).md 'UnrealEngine.Framework.Pawn.GetGravityDirection(System.Numerics.Vector3)')

Retrieves vector direction of gravity  

***
[GetPlayerController()](Pawn_GetPlayerController().md 'UnrealEngine.Framework.Pawn.GetPlayerController()')

Returns the player controller or `null` on failure  
