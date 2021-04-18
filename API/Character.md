### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Character Class
Represents a character that have a mesh, collision, and built-in movement logic  
```csharp
public class Character : UnrealEngine.Framework.Pawn
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Actor](Actor.md 'UnrealEngine.Framework.Actor') &#129106; [Pawn](Pawn.md 'UnrealEngine.Framework.Pawn') &#129106; Character  
### Constructors

***
[Character(string, Blueprint)](Character_Character(string_Blueprint).md 'UnrealEngine.Framework.Character.Character(string, UnrealEngine.Framework.Blueprint)')

Spawns the actor in the world  
### Properties

***
[CanCrouch](Character_CanCrouch.md 'UnrealEngine.Framework.Character.CanCrouch')

Returns `true` if the character can crouch  

***
[CanJump](Character_CanJump.md 'UnrealEngine.Framework.Character.CanJump')

Returns `true` if the character can jump  

***
[IsCrouched](Character_IsCrouched.md 'UnrealEngine.Framework.Character.IsCrouched')

Returns `true` if the character is currently crouched  
### Methods

***
[CheckJumpInput(float)](Character_CheckJumpInput(float).md 'UnrealEngine.Framework.Character.CheckJumpInput(float)')

Triggers jump if a jump button is pressed  

***
[ClearJumpInput(float)](Character_ClearJumpInput(float).md 'UnrealEngine.Framework.Character.ClearJumpInput(float)')

Updates jump input state after checking input  

***
[Crouch()](Character_Crouch().md 'UnrealEngine.Framework.Character.Crouch()')

Starts the character crouching on the next update  

***
[Jump()](Character_Jump().md 'UnrealEngine.Framework.Character.Jump()')

Starts the character jumping on the next update  

***
[Launch(Vector3, bool, bool)](Character_Launch(Vector3_bool_bool).md 'UnrealEngine.Framework.Character.Launch(System.Numerics.Vector3, bool, bool)')

Launches the character using the specified velocity  

***
[SetOnLandedCallback(CharacterLandedDelegate)](Character_SetOnLandedCallback(CharacterLandedDelegate).md 'UnrealEngine.Framework.Character.SetOnLandedCallback(UnrealEngine.Framework.CharacterLandedDelegate)')

Sets the callback function that is called when the character landing after falling  

***
[StopCrouching()](Character_StopCrouching().md 'UnrealEngine.Framework.Character.StopCrouching()')

Stops the character crouching on the next update  

***
[StopJumping()](Character_StopJumping().md 'UnrealEngine.Framework.Character.StopJumping()')

Stops the character from jumping on the next update  
