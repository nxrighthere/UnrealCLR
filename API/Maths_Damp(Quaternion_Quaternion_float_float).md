### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[Maths](Maths.md 'UnrealEngine.Framework.Maths')
## Maths.Damp(Quaternion, Quaternion, float, float) Method
Creates framerate-independent dampened motion between two values  
```csharp
public static System.Numerics.Quaternion Damp(System.Numerics.Quaternion from, System.Numerics.Quaternion to, float lambda, float deltaTime);
```
#### Parameters
<a name='UnrealEngine_Framework_Maths_Damp(System_Numerics_Quaternion_System_Numerics_Quaternion_float_float)_from'></a>
`from` [System.Numerics.Quaternion](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Quaternion 'System.Numerics.Quaternion')  
Value to damp from
  
<a name='UnrealEngine_Framework_Maths_Damp(System_Numerics_Quaternion_System_Numerics_Quaternion_float_float)_to'></a>
`to` [System.Numerics.Quaternion](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Quaternion 'System.Numerics.Quaternion')  
Value to damp to
  
<a name='UnrealEngine_Framework_Maths_Damp(System_Numerics_Quaternion_System_Numerics_Quaternion_float_float)_lambda'></a>
`lambda` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Smoothing factor
  
<a name='UnrealEngine_Framework_Maths_Damp(System_Numerics_Quaternion_System_Numerics_Quaternion_float_float)_deltaTime'></a>
`deltaTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Time since last damp
  
#### Returns
[System.Numerics.Quaternion](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Quaternion 'System.Numerics.Quaternion')  
