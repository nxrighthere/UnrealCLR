### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Texture2D Class
A texture asset  
```csharp
public class Texture2D : UnrealEngine.Framework.Texture
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [StreamableRenderAsset](StreamableRenderAsset.md 'UnrealEngine.Framework.StreamableRenderAsset') &#129106; [Texture](Texture.md 'UnrealEngine.Framework.Texture') &#129106; Texture2D  
### Constructors

***
[Texture2D(byte[], int)](Texture2D_Texture2D(byte___int).md 'UnrealEngine.Framework.Texture2D.Texture2D(byte[], int)')

Creates a texture asset from a raw PNG, JPEG, BMP, or EXR image buffer  

***
[Texture2D(string)](Texture2D_Texture2D(string).md 'UnrealEngine.Framework.Texture2D.Texture2D(string)')

Creates a texture asset from a raw PNG, JPEG, BMP, or EXR image file  
### Properties

***
[HasAlphaChannel](Texture2D_HasAlphaChannel.md 'UnrealEngine.Framework.Texture2D.HasAlphaChannel')

Returns `true` if the runtime texture has an alpha channel that is not completely white  
### Methods

***
[GetPixelFormat()](Texture2D_GetPixelFormat().md 'UnrealEngine.Framework.Texture2D.GetPixelFormat()')

Returns the pixel format  

***
[GetSize()](Texture2D_GetSize().md 'UnrealEngine.Framework.Texture2D.GetSize()')

Returns size of the texture  

***
[GetSize(Vector2)](Texture2D_GetSize(Vector2).md 'UnrealEngine.Framework.Texture2D.GetSize(System.Numerics.Vector2)')

Retrieves size of the texture  

***
[Load(string)](Texture2D_Load(string).md 'UnrealEngine.Framework.Texture2D.Load(string)')

Finds and loads a texture by name  
