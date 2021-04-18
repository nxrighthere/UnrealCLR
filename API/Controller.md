### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Controller Class
Non-physical actors that can possess a [Pawn](Pawn.md 'UnrealEngine.Framework.Pawn') to control its actions  
```csharp
public abstract class Controller : UnrealEngine.Framework.Actor
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Actor](Actor.md 'UnrealEngine.Framework.Actor') &#129106; Controller  

Derived  
&#8627; [AIController](AIController.md 'UnrealEngine.Framework.AIController')
&#8627; [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')  
### Properties

***
[IsLookInputIgnored](Controller_IsLookInputIgnored.md 'UnrealEngine.Framework.Controller.IsLookInputIgnored')

Returns `true` if look input is ignored  

***
[IsMoveInputIgnored](Controller_IsMoveInputIgnored.md 'UnrealEngine.Framework.Controller.IsMoveInputIgnored')

Returns `true` if movement input is ignored  

***
[IsPlayerController](Controller_IsPlayerController.md 'UnrealEngine.Framework.Controller.IsPlayerController')

Returns `true` if the controller is a [PlayerController](PlayerController.md 'UnrealEngine.Framework.PlayerController')
### Methods

***
[GetCharacter()](Controller_GetCharacter().md 'UnrealEngine.Framework.Controller.GetCharacter()')

Returns the character or `null` on failure  

***
[GetControlRotation()](Controller_GetControlRotation().md 'UnrealEngine.Framework.Controller.GetControlRotation()')

Returns the control rotation which is a full aim rotation  

***
[GetControlRotation(Quaternion)](Controller_GetControlRotation(Quaternion).md 'UnrealEngine.Framework.Controller.GetControlRotation(System.Numerics.Quaternion)')

Retrieves the control rotation which is a full aim rotation  

***
[GetDesiredRotation()](Controller_GetDesiredRotation().md 'UnrealEngine.Framework.Controller.GetDesiredRotation()')

Returns the target rotation of the pawn  

***
[GetDesiredRotation(Quaternion)](Controller_GetDesiredRotation(Quaternion).md 'UnrealEngine.Framework.Controller.GetDesiredRotation(System.Numerics.Quaternion)')

Retrieves the target rotation of the pawn  

***
[GetPawn()](Controller_GetPawn().md 'UnrealEngine.Framework.Controller.GetPawn()')

Returns the controller's pawn or `null` on failure  

***
[GetViewTarget()](Controller_GetViewTarget().md 'UnrealEngine.Framework.Controller.GetViewTarget()')

Returns the actor the controller is looking at or `null` on failure  

***
[LineOfSightTo(Actor, Vector3, bool)](Controller_LineOfSightTo(Actor_Vector3_bool).md 'UnrealEngine.Framework.Controller.LineOfSightTo(UnrealEngine.Framework.Actor, System.Numerics.Vector3, bool)')

Checks line to center and top of other actor  

***
[Possess(Pawn)](Controller_Possess(Pawn).md 'UnrealEngine.Framework.Controller.Possess(UnrealEngine.Framework.Pawn)')

Handles attaching the controller to the specified pawn  

***
[ResetIgnoreLookInput()](Controller_ResetIgnoreLookInput().md 'UnrealEngine.Framework.Controller.ResetIgnoreLookInput()')

Stops ignoring look input by resetting the ignore look input state  

***
[ResetIgnoreMoveInput()](Controller_ResetIgnoreMoveInput().md 'UnrealEngine.Framework.Controller.ResetIgnoreMoveInput()')

Stops ignoring move input by resetting the ignore move input state  

***
[SetControlRotation(Quaternion)](Controller_SetControlRotation(Quaternion).md 'UnrealEngine.Framework.Controller.SetControlRotation(System.Numerics.Quaternion)')

Sets the control rotation which is a full aim rotation  

***
[SetIgnoreLookInput(bool)](Controller_SetIgnoreLookInput(bool).md 'UnrealEngine.Framework.Controller.SetIgnoreLookInput(bool)')

Locks or unlocks look input, consecutive calls stack up and require the same amount of calls to undo, or can all be undone using [ResetIgnoreLookInput()](Controller_ResetIgnoreLookInput().md 'UnrealEngine.Framework.Controller.ResetIgnoreLookInput()')

***
[SetIgnoreMoveInput(bool)](Controller_SetIgnoreMoveInput(bool).md 'UnrealEngine.Framework.Controller.SetIgnoreMoveInput(bool)')

Locks or unlocks movement input, consecutive calls stack up and require the same amount of calls to undo, or can all be undone using [ResetIgnoreMoveInput()](Controller_ResetIgnoreMoveInput().md 'UnrealEngine.Framework.Controller.ResetIgnoreMoveInput()')

***
[SetInitialLocationAndRotation(Vector3, Quaternion)](Controller_SetInitialLocationAndRotation(Vector3_Quaternion).md 'UnrealEngine.Framework.Controller.SetInitialLocationAndRotation(System.Numerics.Vector3, System.Numerics.Quaternion)')

Sets the initial location and rotation of the controller, as well as the control rotation  

***
[Unpossess()](Controller_Unpossess().md 'UnrealEngine.Framework.Controller.Unpossess()')

Relinquishes control of the pawn  
