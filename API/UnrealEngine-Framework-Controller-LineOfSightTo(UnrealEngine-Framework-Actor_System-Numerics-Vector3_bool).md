### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Controller](./UnrealEngine-Framework-Controller.md 'UnrealEngine.Framework.Controller')
## Controller.LineOfSightTo(UnrealEngine.Framework.Actor, System.Numerics.Vector3, bool) Method
Checks line to center and top of other actor  
```csharp
public bool LineOfSightTo(UnrealEngine.Framework.Actor actor, in System.Numerics.Vector3 viewPoint, bool alternateChecks=false);
```
#### Parameters
<a name='UnrealEngine-Framework-Controller-LineOfSightTo(UnrealEngine-Framework-Actor_System-Numerics-Vector3_bool)-actor'></a>
`actor` [Actor](./UnrealEngine-Framework-Actor.md 'UnrealEngine.Framework.Actor')  
The actor whose visibility is being checked  
  
<a name='UnrealEngine-Framework-Controller-LineOfSightTo(UnrealEngine-Framework-Actor_System-Numerics-Vector3_bool)-viewPoint'></a>
`viewPoint` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Eye position visibility is being checked from, if [System.Numerics.Vector3.Zero](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3.Zero 'System.Numerics.Vector3.Zero') is passed in, uses current view target's eye position  
  
<a name='UnrealEngine-Framework-Controller-LineOfSightTo(UnrealEngine-Framework-Actor_System-Numerics-Vector3_bool)-alternateChecks'></a>
`alternateChecks` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Used only in [AIController](./UnrealEngine-Framework-AIController.md 'UnrealEngine.Framework.AIController') implementation  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if controller's [Pawn](./UnrealEngine-Framework-Pawn.md 'UnrealEngine.Framework.Pawn') can see other actor  
