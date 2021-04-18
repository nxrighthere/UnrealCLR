### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework')
## CollisionMode Enum
Defines the collision mode  
```csharp
public enum CollisionMode
```
### Fields
<a name='CollisionMode-NoCollision'></a>
`NoCollision` 0  
No collision  
  
<a name='CollisionMode-QueryOnly'></a>
`QueryOnly` 1  
Used for spatial queries (raycasts, sweeps, and overlaps)  
  
<a name='CollisionMode-PhysicsOnly'></a>
`PhysicsOnly` 2  
Used for physics simulation (rigid bodies, and constraints)  
  
<a name='CollisionMode-QueryAndPhysics'></a>
`QueryAndPhysics` 3  
Can be used for both spatial queries and physics simulation  
  
