### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Actor](./UnrealEngine-Framework-Actor.md 'UnrealEngine.Framework.Actor')
## Actor.GetBounds(bool, System.Numerics.Vector3, System.Numerics.Vector3) Method
Retrieves the bounding box of all components of the actor  
```csharp
public void GetBounds(bool onlyCollidingComponents, ref System.Numerics.Vector3 origin, ref System.Numerics.Vector3 extent);
```
#### Parameters
<a name='UnrealEngine-Framework-Actor-GetBounds(bool_System-Numerics-Vector3_System-Numerics-Vector3)-onlyCollidingComponents'></a>
`onlyCollidingComponents` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, will only return the bounding box for components with enabled collision  
  
<a name='UnrealEngine-Framework-Actor-GetBounds(bool_System-Numerics-Vector3_System-Numerics-Vector3)-origin'></a>
`origin` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
The center of the actor in world space  
  
<a name='UnrealEngine-Framework-Actor-GetBounds(bool_System-Numerics-Vector3_System-Numerics-Vector3)-extent'></a>
`extent` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Half the actor's size in 3D space  
  
