### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## AIController Class
The base class of controllers for an AI-controlled [Pawn](Pawn.md 'UnrealEngine.Framework.Pawn')
```csharp
public class AIController : UnrealEngine.Framework.Controller
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Actor](Actor.md 'UnrealEngine.Framework.Actor') &#129106; [Controller](Controller.md 'UnrealEngine.Framework.Controller') &#129106; AIController  
### Constructors

***
[AIController(string, Blueprint)](AIController_AIController(string_Blueprint).md 'UnrealEngine.Framework.AIController.AIController(string, UnrealEngine.Framework.Blueprint)')

Spawns the actor in the world  
### Properties

***
[AllowStrafe](AIController_AllowStrafe.md 'UnrealEngine.Framework.AIController.AllowStrafe')

Gets or sets whether strafing allowed during movement  
### Methods

***
[ClearFocus(AIFocusPriority)](AIController_ClearFocus(AIFocusPriority).md 'UnrealEngine.Framework.AIController.ClearFocus(UnrealEngine.Framework.AIFocusPriority)')

Clears focus for the given priority, will clear focal point as a result  

***
[GetFocalPoint()](AIController_GetFocalPoint().md 'UnrealEngine.Framework.AIController.GetFocalPoint()')

Returns the final position that controller should be looking at  

***
[GetFocalPoint(Vector3)](AIController_GetFocalPoint(Vector3).md 'UnrealEngine.Framework.AIController.GetFocalPoint(System.Numerics.Vector3)')

Retrieves the final position that controller should be looking at  

***
[GetFocusActor()](AIController_GetFocusActor().md 'UnrealEngine.Framework.AIController.GetFocusActor()')

Returns the focused actor or `null` on failure  

***
[SetFocalPoint(Vector3, AIFocusPriority)](AIController_SetFocalPoint(Vector3_AIFocusPriority).md 'UnrealEngine.Framework.AIController.SetFocalPoint(System.Numerics.Vector3, UnrealEngine.Framework.AIFocusPriority)')

Sets focal point for the given priority as absolute position or offset from base  

***
[SetFocus(Actor, AIFocusPriority)](AIController_SetFocus(Actor_AIFocusPriority).md 'UnrealEngine.Framework.AIController.SetFocus(UnrealEngine.Framework.Actor, UnrealEngine.Framework.AIFocusPriority)')

Sets focus actor for the given priority, will set focal point as a result  
