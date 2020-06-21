### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[InstancedStaticMeshComponent](./UnrealEngine-Framework-InstancedStaticMeshComponent.md 'UnrealEngine.Framework.InstancedStaticMeshComponent')
## InstancedStaticMeshComponent.UpdateInstanceTransform(int, UnrealEngine.Framework.Transform, bool, bool, bool) Method
Updates the transform for the specified instance  
```csharp
public bool UpdateInstanceTransform(int instanceIndex, in UnrealEngine.Framework.Transform instanceTransform, bool worldSpace=false, bool markRenderStateDirty=false, bool teleport=false);
```
#### Parameters
<a name='UnrealEngine-Framework-InstancedStaticMeshComponent-UpdateInstanceTransform(int_UnrealEngine-Framework-Transform_bool_bool_bool)-instanceIndex'></a>
`instanceIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The index of the instance to update  
  
<a name='UnrealEngine-Framework-InstancedStaticMeshComponent-UpdateInstanceTransform(int_UnrealEngine-Framework-Transform_bool_bool_bool)-instanceTransform'></a>
`instanceTransform` [Transform](./UnrealEngine-Framework-Transform.md 'UnrealEngine.Framework.Transform')  
The new transform to apply  
  
<a name='UnrealEngine-Framework-InstancedStaticMeshComponent-UpdateInstanceTransform(int_UnrealEngine-Framework-Transform_bool_bool_bool)-worldSpace'></a>
`worldSpace` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, the new transform is interpreted as a world space transform, otherwise it is interpreted as local space  
  
<a name='UnrealEngine-Framework-InstancedStaticMeshComponent-UpdateInstanceTransform(int_UnrealEngine-Framework-Transform_bool_bool_bool)-markRenderStateDirty'></a>
`markRenderStateDirty` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If the render state is marked as dirty the change should be visible immediately, consider setting it to `true` only during the update of the last instance in a batch  
  
<a name='UnrealEngine-Framework-InstancedStaticMeshComponent-UpdateInstanceTransform(int_UnrealEngine-Framework-Transform_bool_bool_bool)-teleport'></a>
`teleport` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the instance's physics should be moved normally, or teleported (moved instantly, ignoring velocity)  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if successful  
