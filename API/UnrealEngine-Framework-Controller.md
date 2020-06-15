### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## Controller Class
Non-physical actors that can possess a [Pawn](./UnrealEngine-Framework-Pawn.md 'UnrealEngine.Framework.Pawn') to control its actions  
```csharp
public abstract class Controller : Actor
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Actor](./UnrealEngine-Framework-Actor.md 'UnrealEngine.Framework.Actor') &#129106; Controller  

Derived  
&#8627; [AIController](./UnrealEngine-Framework-AIController.md 'UnrealEngine.Framework.AIController')  
&#8627; [PlayerController](./UnrealEngine-Framework-PlayerController.md 'UnrealEngine.Framework.PlayerController')  
### Properties
- [IsLookInputIgnored](./UnrealEngine-Framework-Controller-IsLookInputIgnored.md 'UnrealEngine.Framework.Controller.IsLookInputIgnored')
- [IsMoveInputIgnored](./UnrealEngine-Framework-Controller-IsMoveInputIgnored.md 'UnrealEngine.Framework.Controller.IsMoveInputIgnored')
- [IsPlayerController](./UnrealEngine-Framework-Controller-IsPlayerController.md 'UnrealEngine.Framework.Controller.IsPlayerController')
### Methods
- [GetPawn()](./UnrealEngine-Framework-Controller-GetPawn().md 'UnrealEngine.Framework.Controller.GetPawn()')
- [LineOfSightTo(UnrealEngine.Framework.Actor, System.Numerics.Vector3, bool)](./UnrealEngine-Framework-Controller-LineOfSightTo(UnrealEngine-Framework-Actor_System-Numerics-Vector3_bool).md 'UnrealEngine.Framework.Controller.LineOfSightTo(UnrealEngine.Framework.Actor, System.Numerics.Vector3, bool)')
- [ResetIgnoreLookInput()](./UnrealEngine-Framework-Controller-ResetIgnoreLookInput().md 'UnrealEngine.Framework.Controller.ResetIgnoreLookInput()')
- [ResetIgnoreMoveInput()](./UnrealEngine-Framework-Controller-ResetIgnoreMoveInput().md 'UnrealEngine.Framework.Controller.ResetIgnoreMoveInput()')
- [SetIgnoreLookInput(bool)](./UnrealEngine-Framework-Controller-SetIgnoreLookInput(bool).md 'UnrealEngine.Framework.Controller.SetIgnoreLookInput(bool)')
- [SetIgnoreMoveInput(bool)](./UnrealEngine-Framework-Controller-SetIgnoreMoveInput(bool).md 'UnrealEngine.Framework.Controller.SetIgnoreMoveInput(bool)')
- [SetInitialLocationAndRotation(System.Numerics.Vector3, System.Numerics.Quaternion)](./UnrealEngine-Framework-Controller-SetInitialLocationAndRotation(System-Numerics-Vector3_System-Numerics-Quaternion).md 'UnrealEngine.Framework.Controller.SetInitialLocationAndRotation(System.Numerics.Vector3, System.Numerics.Quaternion)')
