### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## NetMode Enum
Defines the networking mode  
```csharp
public enum NetMode
 : System.Byte
```
#### Fields
<a name='UnrealEngine_Framework_NetMode_Client'></a>
`Client` 3  
A client connected to a server  
  
<a name='UnrealEngine_Framework_NetMode_DedicatedServer'></a>
`DedicatedServer` 1  
A server with no local players  
  
<a name='UnrealEngine_Framework_NetMode_ListenServer'></a>
`ListenServer` 2  
A server that also has a local player who is hosting the game, available to other players on the network  
  
<a name='UnrealEngine_Framework_NetMode_Standalone'></a>
`Standalone` 0  
A game without networking, with one or more local players  
  
