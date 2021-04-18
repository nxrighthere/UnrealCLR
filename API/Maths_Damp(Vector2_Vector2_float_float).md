### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[Maths](Maths.md 'UnrealEngine.Framework.Maths')
## Maths.Damp(Vector2, Vector2, float, float) Method
Creates framerate-independent dampened motion between two values  
```csharp
public static System.Numerics.Vector2 Damp(System.Numerics.Vector2 from, System.Numerics.Vector2 to, float lambda, float deltaTime);
```
#### Parameters
<a name='UnrealEngine_Framework_Maths_Damp(System_Numerics_Vector2_System_Numerics_Vector2_float_float)_from'></a>
`from` [System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')  
Value to damp from
  
<a name='UnrealEngine_Framework_Maths_Damp(System_Numerics_Vector2_System_Numerics_Vector2_float_float)_to'></a>
`to` [System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')  
Value to damp to
  
<a name='UnrealEngine_Framework_Maths_Damp(System_Numerics_Vector2_System_Numerics_Vector2_float_float)_lambda'></a>
`lambda` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Smoothing factor
  
<a name='UnrealEngine_Framework_Maths_Damp(System_Numerics_Vector2_System_Numerics_Vector2_float_float)_deltaTime'></a>
`deltaTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Time since last damp
  
#### Returns
[System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')  
