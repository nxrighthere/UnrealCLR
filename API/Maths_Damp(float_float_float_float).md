### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[Maths](Maths.md 'UnrealEngine.Framework.Maths')
## Maths.Damp(float, float, float, float) Method
Creates framerate-independent dampened motion between two values  
```csharp
public static float Damp(float from, float to, float lambda, float deltaTime);
```
#### Parameters
<a name='UnrealEngine_Framework_Maths_Damp(float_float_float_float)_from'></a>
`from` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Value to damp from
  
<a name='UnrealEngine_Framework_Maths_Damp(float_float_float_float)_to'></a>
`to` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Value to damp to
  
<a name='UnrealEngine_Framework_Maths_Damp(float_float_float_float)_lambda'></a>
`lambda` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Smoothing factor
  
<a name='UnrealEngine_Framework_Maths_Damp(float_float_float_float)_deltaTime'></a>
`deltaTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Time since last damp
  
#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
