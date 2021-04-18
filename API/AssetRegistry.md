### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## AssetRegistry Class
An asset registry  
```csharp
public class AssetRegistry :
System.IEquatable<UnrealEngine.Framework.AssetRegistry>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AssetRegistry  

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[AssetRegistry](AssetRegistry.md 'UnrealEngine.Framework.AssetRegistry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Constructors

***
[AssetRegistry()](AssetRegistry_AssetRegistry().md 'UnrealEngine.Framework.AssetRegistry.AssetRegistry()')

Initializes a new instance of the asset registry  
### Properties

***
[IsCreated](AssetRegistry_IsCreated.md 'UnrealEngine.Framework.AssetRegistry.IsCreated')

Returns `true` if the object is created  
### Methods

***
[Equals(AssetRegistry)](AssetRegistry_Equals(AssetRegistry).md 'UnrealEngine.Framework.AssetRegistry.Equals(UnrealEngine.Framework.AssetRegistry)')

Indicates equality of objects  

***
[ForEachAsset(Action&lt;Asset&gt;, string, bool, bool)](AssetRegistry_ForEachAsset(Action_Asset__string_bool_bool).md 'UnrealEngine.Framework.AssetRegistry.ForEachAsset(System.Action&lt;UnrealEngine.Framework.Asset&gt;, string, bool, bool)')

Performs the specified action on each asset if any  

***
[GetHashCode()](AssetRegistry_GetHashCode().md 'UnrealEngine.Framework.AssetRegistry.GetHashCode()')

Returns a hash code for the object  

***
[HasAssets(string, bool)](AssetRegistry_HasAssets(string_bool).md 'UnrealEngine.Framework.AssetRegistry.HasAssets(string, bool)')

Checks whether the given path contain assets, optionally testing sub-paths  
