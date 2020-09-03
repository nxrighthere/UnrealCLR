### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## TeleportType Enum
Defines teleportation types of physics body  
```csharp
public enum TeleportType : System.Byte
```
### Fields
<a name='TeleportType-None'></a>
`None` 0  
Don't teleport physics body  
  
<a name='TeleportType-TeleportPhysics'></a>
`TeleportPhysics` 1  
Teleport physics body so that velocity remains the same and no collision occurs  
  
<a name='TeleportType-ResetPhysics'></a>
`ResetPhysics` 2  
Teleport physics body and reset physics state completely  
  
