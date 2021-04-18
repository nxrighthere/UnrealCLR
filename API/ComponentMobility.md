### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## ComponentMobility Enum
Defines how often a component is allowed to move  
```csharp
public enum ComponentMobility

```
#### Fields
<a name='UnrealEngine_Framework_ComponentMobility_Movable'></a>
`Movable` 0  
Movable objects can be moved and changed  
  
<a name='UnrealEngine_Framework_ComponentMobility_Static'></a>
`Static` 1  
Static objects cannot be moved or changed  
- Allows baked lighting  
- Fastest rendering  
  
<a name='UnrealEngine_Framework_ComponentMobility_Stationary'></a>
`Stationary` 2  
A stationary light will only have its shadowing and bounced lighting from static geometry baked by <a href="https://docs.unrealengine.com/en-US/Engine/Rendering/LightingAndShadows/Lightmass/index.html">Lightmass</a>, all other lighting will be dynamic  
  
