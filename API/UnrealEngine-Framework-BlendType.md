### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## BlendType Enum
Defines how to blend when changing view targets  
```csharp
public enum BlendType
```
### Fields
<a name='UnrealEngine-Framework-BlendType-Linear'></a>
`Linear` 0  
A simple linear interpolation  
  
<a name='UnrealEngine-Framework-BlendType-Cubic'></a>
`Cubic` 1  
A slight ease in and ease out, but amount of ease cannot be tweaked  
  
<a name='UnrealEngine-Framework-BlendType-EaseIn'></a>
`EaseIn` 2  
Immediately accelerates, but smoothly decelerates into the target, ease amount can be controlled  
  
<a name='UnrealEngine-Framework-BlendType-EaseOut'></a>
`EaseOut` 3  
Smoothly accelerates, but does not decelerate into the target, ease amount can be controlled  
  
<a name='UnrealEngine-Framework-BlendType-EaseInOut'></a>
`EaseInOut` 4  
Smoothly accelerates and decelerates, ease amount can be controlled  
  
