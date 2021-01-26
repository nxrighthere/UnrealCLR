### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## Character Class
Represents a character that have a mesh, collision, and built-in movement logic  
```csharp
public class Character : UnrealEngine.Framework.Pawn
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Actor](./Actor.md 'UnrealEngine.Framework.Actor') &#129106; [Pawn](./Pawn.md 'UnrealEngine.Framework.Pawn') &#129106; Character  
### Constructors
- [Character(string, UnrealEngine.Framework.Blueprint)](./Character-Character(string_Blueprint).md 'UnrealEngine.Framework.Character.Character(string, UnrealEngine.Framework.Blueprint)')
### Properties
- [CanCrouch](./Character-CanCrouch.md 'UnrealEngine.Framework.Character.CanCrouch')
- [CanJump](./Character-CanJump.md 'UnrealEngine.Framework.Character.CanJump')
- [IsCrouched](./Character-IsCrouched.md 'UnrealEngine.Framework.Character.IsCrouched')
### Methods
- [CheckJumpInput(float)](./Character-CheckJumpInput(float).md 'UnrealEngine.Framework.Character.CheckJumpInput(float)')
- [ClearJumpInput(float)](./Character-ClearJumpInput(float).md 'UnrealEngine.Framework.Character.ClearJumpInput(float)')
- [Crouch()](./Character-Crouch().md 'UnrealEngine.Framework.Character.Crouch()')
- [Jump()](./Character-Jump().md 'UnrealEngine.Framework.Character.Jump()')
- [Launch(System.Numerics.Vector3, bool, bool)](./Character-Launch(Vector3_bool_bool).md 'UnrealEngine.Framework.Character.Launch(System.Numerics.Vector3, bool, bool)')
- [SetOnLandedCallback(UnrealEngine.Framework.CharacterLandedDelegate)](./Character-SetOnLandedCallback(CharacterLandedDelegate).md 'UnrealEngine.Framework.Character.SetOnLandedCallback(UnrealEngine.Framework.CharacterLandedDelegate)')
- [StopCrouching()](./Character-StopCrouching().md 'UnrealEngine.Framework.Character.StopCrouching()')
- [StopJumping()](./Character-StopJumping().md 'UnrealEngine.Framework.Character.StopJumping()')
