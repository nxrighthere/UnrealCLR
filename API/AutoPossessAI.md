### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## AutoPossessAI Enum
Defines the possession type for AI pawn that will be automatically possed by an AI controller  
```csharp
public enum AutoPossessAI : System.Byte
```
### Fields
<a name='AutoPossessAI-Disabled'></a>
`Disabled` 0  
Disabled and not possesses AI  
  
<a name='AutoPossessAI-PlacedInWorld'></a>
`PlacedInWorld` 1  
Only possess by an AI controller if a pawn is placed in the world  
  
<a name='AutoPossessAI-Spawned'></a>
`Spawned` 2  
Only possess by an AI controller if a pawn is spawned after the world has loaded  
  
<a name='AutoPossessAI-PlacedInWorldOrSpawned'></a>
`PlacedInWorldOrSpawned` 3  
Pawn is automatically possessed by an AI controller whenever it's created  
  
