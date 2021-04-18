### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## BlendType Enum
Defines how to blend when changing view targets  
```csharp
public enum BlendType

```
#### Fields
<a name='UnrealEngine_Framework_BlendType_Cubic'></a>
`Cubic` 1  
A slight ease in and ease out, but amount of ease cannot be tweaked  
  
<a name='UnrealEngine_Framework_BlendType_EaseIn'></a>
`EaseIn` 2  
Immediately accelerates, but smoothly decelerates into the target, ease amount can be controlled  
  
<a name='UnrealEngine_Framework_BlendType_EaseInOut'></a>
`EaseInOut` 4  
Smoothly accelerates and decelerates, ease amount can be controlled  
  
<a name='UnrealEngine_Framework_BlendType_EaseOut'></a>
`EaseOut` 3  
Smoothly accelerates, but does not decelerate into the target, ease amount can be controlled  
  
<a name='UnrealEngine_Framework_BlendType_Linear'></a>
`Linear` 0  
A simple linear interpolation  
  
