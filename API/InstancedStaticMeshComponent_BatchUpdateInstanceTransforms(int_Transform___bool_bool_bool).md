### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[InstancedStaticMeshComponent](InstancedStaticMeshComponent.md 'UnrealEngine.Framework.InstancedStaticMeshComponent')
## InstancedStaticMeshComponent.BatchUpdateInstanceTransforms(int, Transform[], bool, bool, bool) Method
Updates the transform for an array of instances  
```csharp
public bool BatchUpdateInstanceTransforms(int startInstanceIndex, UnrealEngine.Framework.Transform[] instanceTransforms, bool worldSpace=false, bool markRenderStateDirty=false, bool teleport=false);
```
#### Parameters
<a name='UnrealEngine_Framework_InstancedStaticMeshComponent_BatchUpdateInstanceTransforms(int_UnrealEngine_Framework_Transform___bool_bool_bool)_startInstanceIndex'></a>
`startInstanceIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The starting index of the instances to update
  
<a name='UnrealEngine_Framework_InstancedStaticMeshComponent_BatchUpdateInstanceTransforms(int_UnrealEngine_Framework_Transform___bool_bool_bool)_instanceTransforms'></a>
`instanceTransforms` [Transform](Transform.md 'UnrealEngine.Framework.Transform')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The new transforms to apply
  
<a name='UnrealEngine_Framework_InstancedStaticMeshComponent_BatchUpdateInstanceTransforms(int_UnrealEngine_Framework_Transform___bool_bool_bool)_worldSpace'></a>
`worldSpace` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, the new transforms are interpreted as a world space transforms, otherwise it is interpreted as local space
  
<a name='UnrealEngine_Framework_InstancedStaticMeshComponent_BatchUpdateInstanceTransforms(int_UnrealEngine_Framework_Transform___bool_bool_bool)_markRenderStateDirty'></a>
`markRenderStateDirty` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If the render state is marked as dirty the change should be visible immediately
  
<a name='UnrealEngine_Framework_InstancedStaticMeshComponent_BatchUpdateInstanceTransforms(int_UnrealEngine_Framework_Transform___bool_bool_bool)_teleport'></a>
`teleport` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the instances physics should be moved normally, or teleported (moved instantly, ignoring velocity)
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if successful
