### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[PrimitiveComponent](PrimitiveComponent.md 'UnrealEngine.Framework.PrimitiveComponent')
## PrimitiveComponent.CreateAndSetMaterialInstanceDynamic(int) Method
Creates a dynamic material instance for the specified element index, the parent of the instance is set to the material being replaced  
```csharp
public UnrealEngine.Framework.MaterialInstanceDynamic CreateAndSetMaterialInstanceDynamic(int elementIndex);
```
#### Parameters
<a name='UnrealEngine_Framework_PrimitiveComponent_CreateAndSetMaterialInstanceDynamic(int)_elementIndex'></a>
`elementIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The index of the skin to replace the material for, if invalid, the material is unchanged and `null` is returned
  
#### Returns
[MaterialInstanceDynamic](MaterialInstanceDynamic.md 'UnrealEngine.Framework.MaterialInstanceDynamic')  
A material instance or `null` on failure
