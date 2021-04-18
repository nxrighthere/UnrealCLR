### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## InstancedStaticMeshComponent Class
A component that efficiently renders multiple instances of the same [StaticMeshComponent](StaticMeshComponent.md 'UnrealEngine.Framework.StaticMeshComponent')
```csharp
public class InstancedStaticMeshComponent : UnrealEngine.Framework.StaticMeshComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ActorComponent](ActorComponent.md 'UnrealEngine.Framework.ActorComponent') &#129106; [SceneComponent](SceneComponent.md 'UnrealEngine.Framework.SceneComponent') &#129106; [PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent') &#129106; [MeshComponent](MeshComponent.md 'UnrealEngine.Framework.MeshComponent') &#129106; [StaticMeshComponent](StaticMeshComponent.md 'UnrealEngine.Framework.StaticMeshComponent') &#129106; InstancedStaticMeshComponent  

Derived  
&#8627; [HierarchicalInstancedStaticMeshComponent](HierarchicalInstancedStaticMeshComponent.md 'UnrealEngine.Framework.HierarchicalInstancedStaticMeshComponent')  
### Constructors

***
[InstancedStaticMeshComponent(Actor, string, bool, Blueprint)](InstancedStaticMeshComponent_InstancedStaticMeshComponent(Actor_string_bool_Blueprint).md 'UnrealEngine.Framework.InstancedStaticMeshComponent.InstancedStaticMeshComponent(UnrealEngine.Framework.Actor, string, bool, UnrealEngine.Framework.Blueprint)')

Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically  
### Properties

***
[InstanceCount](InstancedStaticMeshComponent_InstanceCount.md 'UnrealEngine.Framework.InstancedStaticMeshComponent.InstanceCount')

Returns the number of instances in the component  
### Methods

***
[AddInstance(Transform)](InstancedStaticMeshComponent_AddInstance(Transform).md 'UnrealEngine.Framework.InstancedStaticMeshComponent.AddInstance(UnrealEngine.Framework.Transform)')

Adds an instance to the component using the transform that will be applied at instantiation  

***
[BatchUpdateInstanceTransforms(int, Transform[], bool, bool, bool)](InstancedStaticMeshComponent_BatchUpdateInstanceTransforms(int_Transform___bool_bool_bool).md 'UnrealEngine.Framework.InstancedStaticMeshComponent.BatchUpdateInstanceTransforms(int, UnrealEngine.Framework.Transform[], bool, bool, bool)')

Updates the transform for an array of instances  

***
[ClearInstances()](InstancedStaticMeshComponent_ClearInstances().md 'UnrealEngine.Framework.InstancedStaticMeshComponent.ClearInstances()')

Clears all instances being rendered by the component  

***
[GetInstanceTransform(int, Transform, bool)](InstancedStaticMeshComponent_GetInstanceTransform(int_Transform_bool).md 'UnrealEngine.Framework.InstancedStaticMeshComponent.GetInstanceTransform(int, UnrealEngine.Framework.Transform, bool)')

Retrieves the transform of the specified instance  

***
[RemoveInstance(int)](InstancedStaticMeshComponent_RemoveInstance(int).md 'UnrealEngine.Framework.InstancedStaticMeshComponent.RemoveInstance(int)')

Removes the specified instance  

***
[UpdateInstanceTransform(int, Transform, bool, bool, bool)](InstancedStaticMeshComponent_UpdateInstanceTransform(int_Transform_bool_bool_bool).md 'UnrealEngine.Framework.InstancedStaticMeshComponent.UpdateInstanceTransform(int, UnrealEngine.Framework.Transform, bool, bool, bool)')

Updates the transform for the specified instance  
