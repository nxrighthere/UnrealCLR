### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## UpdateTransformFlags Enum
Defines how to update transform during movement  
```csharp
public enum UpdateTransformFlags
```
### Fields
<a name='UpdateTransformFlags-None'></a>
`None` 0  
Default update  
  
<a name='UpdateTransformFlags-SkipPhysicsUpdate'></a>
`SkipPhysicsUpdate` 1  
Don't update the underlying physics  
  
<a name='UpdateTransformFlags-PropagateFromParent'></a>
`PropagateFromParent` 2  
The update is coming as a result of the parent updating  
  
<a name='UpdateTransformFlags-OnlyUpdateIfUsingSocket'></a>
`OnlyUpdateIfUsingSocket` 4  
Only update child transform if attached to parent via a socket  
  
