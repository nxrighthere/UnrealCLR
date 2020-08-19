### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## Controller Class
Non-physical actors that can possess a [Pawn](./Pawn.md 'UnrealEngine.Framework.Pawn') to control its actions  
```csharp
public abstract class Controller : Actor
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Actor](./Actor.md 'UnrealEngine.Framework.Actor') &#129106; Controller  

Derived  
&#8627; [AIController](./AIController.md 'UnrealEngine.Framework.AIController')  
&#8627; [PlayerController](./PlayerController.md 'UnrealEngine.Framework.PlayerController')  
### Properties
- [IsLookInputIgnored](./Controller-IsLookInputIgnored.md 'UnrealEngine.Framework.Controller.IsLookInputIgnored')
- [IsMoveInputIgnored](./Controller-IsMoveInputIgnored.md 'UnrealEngine.Framework.Controller.IsMoveInputIgnored')
- [IsPlayerController](./Controller-IsPlayerController.md 'UnrealEngine.Framework.Controller.IsPlayerController')
### Methods
- [GetCharacter()](./Controller-GetCharacter().md 'UnrealEngine.Framework.Controller.GetCharacter()')
- [GetControlRotation()](./Controller-GetControlRotation().md 'UnrealEngine.Framework.Controller.GetControlRotation()')
- [GetControlRotation(System.Numerics.Quaternion)](./Controller-GetControlRotation(Quaternion).md 'UnrealEngine.Framework.Controller.GetControlRotation(System.Numerics.Quaternion)')
- [GetPawn()](./Controller-GetPawn().md 'UnrealEngine.Framework.Controller.GetPawn()')
- [LineOfSightTo(UnrealEngine.Framework.Actor, System.Numerics.Vector3, bool)](./Controller-LineOfSightTo(Actor_Vector3_bool).md 'UnrealEngine.Framework.Controller.LineOfSightTo(UnrealEngine.Framework.Actor, System.Numerics.Vector3, bool)')
- [ResetIgnoreLookInput()](./Controller-ResetIgnoreLookInput().md 'UnrealEngine.Framework.Controller.ResetIgnoreLookInput()')
- [ResetIgnoreMoveInput()](./Controller-ResetIgnoreMoveInput().md 'UnrealEngine.Framework.Controller.ResetIgnoreMoveInput()')
- [SetControlRotation(System.Numerics.Quaternion)](./Controller-SetControlRotation(Quaternion).md 'UnrealEngine.Framework.Controller.SetControlRotation(System.Numerics.Quaternion)')
- [SetIgnoreLookInput(bool)](./Controller-SetIgnoreLookInput(bool).md 'UnrealEngine.Framework.Controller.SetIgnoreLookInput(bool)')
- [SetIgnoreMoveInput(bool)](./Controller-SetIgnoreMoveInput(bool).md 'UnrealEngine.Framework.Controller.SetIgnoreMoveInput(bool)')
- [SetInitialLocationAndRotation(System.Numerics.Vector3, System.Numerics.Quaternion)](./Controller-SetInitialLocationAndRotation(Vector3_Quaternion).md 'UnrealEngine.Framework.Controller.SetInitialLocationAndRotation(System.Numerics.Vector3, System.Numerics.Quaternion)')
