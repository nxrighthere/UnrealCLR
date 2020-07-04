### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## DetachmentTransformRule Enum
Defines rules for detaching components  
```csharp
public enum DetachmentTransformRule
```
### Fields
<a name='DetachmentTransformRule-KeepRelativeTransform'></a>
`KeepRelativeTransform` 0  
Keeps current relative transform as the relative transform to the previous parent  
  
<a name='DetachmentTransformRule-KeepWorldTransform'></a>
`KeepWorldTransform` 1  
Automatically calculates the relative transform such that the detached component maintains the same world transform  
  
