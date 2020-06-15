### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## AttachmentTransformRule Enum
Rules for attaching components  
```csharp
public enum AttachmentTransformRule
```
### Fields
<a name='UnrealEngine-Framework-AttachmentTransformRule-KeepRelativeTransform'></a>
`KeepRelativeTransform` 0  
Keeps current relative transform as the relative transform to the new parent  
  
<a name='UnrealEngine-Framework-AttachmentTransformRule-KeepWorldTransform'></a>
`KeepWorldTransform` 1  
Automatically calculates the relative transform such that the attached component maintains the same world transform  
  
<a name='UnrealEngine-Framework-AttachmentTransformRule-SnapToTargetIncludingScale'></a>
`SnapToTargetIncludingScale` 2  
Snaps location and rotation to the attach point, calculates the relative scale so that the final world scale of the component remains the same  
  
<a name='UnrealEngine-Framework-AttachmentTransformRule-SnapToTargetNotIncludingScale'></a>
`SnapToTargetNotIncludingScale` 3  
Snaps the entire transform to target, including scale  
  
