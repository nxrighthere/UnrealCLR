### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## StaticMeshComponent Class
A component that is used to create an instance of a static mesh, a piece of geometry that consists of a static set of polygons  
```csharp
public class StaticMeshComponent : UnrealEngine.Framework.MeshComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; [PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent') &#129106; [MeshComponent](MeshComponent.md 'UnrealEngine.Framework.MeshComponent') &#129106; StaticMeshComponent  

Derived  
&#8627; [InstancedStaticMeshComponent](InstancedStaticMeshComponent.md 'UnrealEngine.Framework.InstancedStaticMeshComponent')  
### Constructors

***
[StaticMeshComponent(Actor, string, bool, Blueprint)](StaticMeshComponent_StaticMeshComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.StaticMeshComponent.StaticMeshComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Methods

***
[GetLocalBounds(Vector3, Vector3)](StaticMeshComponent_GetLocalBounds(Vector3_Vector3).md 'UnrealEngine.Framework.StaticMeshComponent.GetLocalBounds(System.Numerics.Vector3, System.Numerics.Vector3)')

Retrieves local bounds of the mesh  

***
[GetStaticMesh()](StaticMeshComponent_GetStaticMesh().md 'UnrealEngine.Framework.StaticMeshComponent.GetStaticMesh()')

Returns the static mesh used by this instance or `null` on failure  

***
[SetStaticMesh(StaticMesh)](StaticMeshComponent_SetStaticMesh(StaticMesh).md 'UnrealEngine.Framework.StaticMeshComponent.SetStaticMesh(UnrealEngine.Framework.StaticMesh)')

Returns `true` if the mesh was set  
