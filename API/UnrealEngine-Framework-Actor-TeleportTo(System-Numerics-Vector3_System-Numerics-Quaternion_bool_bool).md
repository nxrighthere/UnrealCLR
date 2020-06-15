### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Actor](./UnrealEngine-Framework-Actor.md 'UnrealEngine.Framework.Actor')
## Actor.TeleportTo(System.Numerics.Vector3, System.Numerics.Quaternion, bool, bool) Method
Teleports an actor to a new location  
```csharp
public bool TeleportTo(in System.Numerics.Vector3 destinationLocation, in System.Numerics.Quaternion destinationRotation, bool isATest=false, bool noCheck=false);
```
#### Parameters
<a name='UnrealEngine-Framework-Actor-TeleportTo(System-Numerics-Vector3_System-Numerics-Quaternion_bool_bool)-destinationLocation'></a>
`destinationLocation` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
The target destination point  
  
<a name='UnrealEngine-Framework-Actor-TeleportTo(System-Numerics-Vector3_System-Numerics-Quaternion_bool_bool)-destinationRotation'></a>
`destinationRotation` [System.Numerics.Quaternion](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Quaternion 'System.Numerics.Quaternion')  
The target rotation at the destination  
  
<a name='UnrealEngine-Framework-Actor-TeleportTo(System-Numerics-Vector3_System-Numerics-Quaternion_bool_bool)-isATest'></a>
`isATest` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, shouldn't cause any notifications (used by AI pathfinding, for example)  
  
<a name='UnrealEngine-Framework-Actor-TeleportTo(System-Numerics-Vector3_System-Numerics-Quaternion_bool_bool)-noCheck'></a>
`noCheck` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, should skip checking for positioning in the world or relative to other actors trying to slightly move the actor out  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the actor has been successfully moved  
