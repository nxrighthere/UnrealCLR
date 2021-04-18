### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[Maths](Maths.md 'UnrealEngine.Framework.Maths')
## Maths.Damp(double, double, double, double) Method
Creates framerate-independent dampened motion between two values  
```csharp
public static double Damp(double from, double to, double lambda, double deltaTime);
```
#### Parameters
<a name='UnrealEngine_Framework_Maths_Damp(double_double_double_double)_from'></a>
`from` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Value to damp from
  
<a name='UnrealEngine_Framework_Maths_Damp(double_double_double_double)_to'></a>
`to` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Value to damp to
  
<a name='UnrealEngine_Framework_Maths_Damp(double_double_double_double)_lambda'></a>
`lambda` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Smoothing factor
  
<a name='UnrealEngine_Framework_Maths_Damp(double_double_double_double)_deltaTime'></a>
`deltaTime` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Time since last damp
  
#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
