### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## UpdateTransformFlags Enum
Defines how to update transform during movement  
```csharp
public enum UpdateTransformFlags

```
#### Fields
<a name='UnrealEngine_Framework_UpdateTransformFlags_None'></a>
`None` 0  
Default update  
  
<a name='UnrealEngine_Framework_UpdateTransformFlags_OnlyUpdateIfUsingSocket'></a>
`OnlyUpdateIfUsingSocket` 4  
Only update child transform if attached to parent via a socket  
  
<a name='UnrealEngine_Framework_UpdateTransformFlags_PropagateFromParent'></a>
`PropagateFromParent` 2  
The update is coming as a result of the parent updating  
  
<a name='UnrealEngine_Framework_UpdateTransformFlags_SkipPhysicsUpdate'></a>
`SkipPhysicsUpdate` 1  
Don't update the underlying physics  
  
