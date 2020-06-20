### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## NetMode Enum
Defines the networking mode  
```csharp
public enum NetMode : System.Byte
```
### Fields
<a name='UnrealEngine-Framework-NetMode-Standalone'></a>
`Standalone` 0  
A game without networking, with one or more local players  
  
<a name='UnrealEngine-Framework-NetMode-DedicatedServer'></a>
`DedicatedServer` 1  
A server with no local players  
  
<a name='UnrealEngine-Framework-NetMode-ListenServer'></a>
`ListenServer` 2  
A server that also has a local player who is hosting the game, available to other players on the network  
  
<a name='UnrealEngine-Framework-NetMode-Client'></a>
`Client` 3  
A client connected to a server  
  
