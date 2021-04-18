### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[ActorComponent](./ActorComponent.md 'UnrealEngine.Framework.ActorComponent')
## ActorComponent.Destroy(bool) Method
Unregisters the component, removes it from its outer actor's components array and marks for pending kill  
```csharp
public void Destroy(bool promoteChild=false);
```
#### Parameters
<a name='UnrealEngine-Framework-ActorComponent-Destroy(bool)-promoteChild'></a>
`promoteChild` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Promotes the child component in the hierarchy during the destruction  
  
