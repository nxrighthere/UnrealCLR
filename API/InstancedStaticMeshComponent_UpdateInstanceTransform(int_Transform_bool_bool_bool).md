### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[InstancedStaticMeshComponent](InstancedStaticMeshComponent.md 'UnrealEngine.Framework.InstancedStaticMeshComponent')
## InstancedStaticMeshComponent.UpdateInstanceTransform(int, Transform, bool, bool, bool) Method
Updates the transform for the specified instance  
```csharp
public bool UpdateInstanceTransform(int instanceIndex, in UnrealEngine.Framework.Transform instanceTransform, bool worldSpace=false, bool markRenderStateDirty=false, bool teleport=false);
```
#### Parameters
<a name='UnrealEngine_Framework_InstancedStaticMeshComponent_UpdateInstanceTransform(int_UnrealEngine_Framework_Transform_bool_bool_bool)_instanceIndex'></a>
`instanceIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The index of the instance to update
  
<a name='UnrealEngine_Framework_InstancedStaticMeshComponent_UpdateInstanceTransform(int_UnrealEngine_Framework_Transform_bool_bool_bool)_instanceTransform'></a>
`instanceTransform` [Transform](Transform.md 'UnrealEngine.Framework.Transform')  
The new transform to apply
  
<a name='UnrealEngine_Framework_InstancedStaticMeshComponent_UpdateInstanceTransform(int_UnrealEngine_Framework_Transform_bool_bool_bool)_worldSpace'></a>
`worldSpace` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, the new transform is interpreted as a world space transform, otherwise it is interpreted as local space
  
<a name='UnrealEngine_Framework_InstancedStaticMeshComponent_UpdateInstanceTransform(int_UnrealEngine_Framework_Transform_bool_bool_bool)_markRenderStateDirty'></a>
`markRenderStateDirty` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If the render state is marked as dirty the change should be visible immediately, consider setting it to `true` only during the update of the last instance in a batch
  
<a name='UnrealEngine_Framework_InstancedStaticMeshComponent_UpdateInstanceTransform(int_UnrealEngine_Framework_Transform_bool_bool_bool)_teleport'></a>
`teleport` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the instance's physics should be moved normally, or teleported (moved instantly, ignoring velocity)
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if successful
