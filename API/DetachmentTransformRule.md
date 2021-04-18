### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## DetachmentTransformRule Enum
Defines rules for detaching components  
```csharp
public enum DetachmentTransformRule

```
#### Fields
<a name='UnrealEngine_Framework_DetachmentTransformRule_KeepRelativeTransform'></a>
`KeepRelativeTransform` 0  
Keeps current relative transform as the relative transform to the previous parent  
  
<a name='UnrealEngine_Framework_DetachmentTransformRule_KeepWorldTransform'></a>
`KeepWorldTransform` 1  
Automatically calculates the relative transform such that the detached component maintains the same world transform  
  
