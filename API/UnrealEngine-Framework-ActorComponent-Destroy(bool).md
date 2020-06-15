### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[ActorComponent](./UnrealEngine-Framework-ActorComponent.md 'UnrealEngine.Framework.ActorComponent')
## ActorComponent.Destroy(bool) Method
Unregister the component, removes it from its outer actor's components array and marks for pending kill  
```csharp
public void Destroy(bool promoteChildren=false);
```
#### Parameters
<a name='UnrealEngine-Framework-ActorComponent-Destroy(bool)-promoteChildren'></a>
`promoteChildren` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Promotes the children component in the hierarchy during the destruction  
  
