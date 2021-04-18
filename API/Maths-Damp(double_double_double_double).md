### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Maths](./Maths.md 'UnrealEngine.Framework.Maths')
## Maths.Damp(double, double, double, double) Method
Creates framerate-independent dampened motion between two values  
```csharp
public static double Damp(double from, double to, double lambda, double deltaTime);
```
#### Parameters
<a name='UnrealEngine-Framework-Maths-Damp(double_double_double_double)-from'></a>
`from` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Value to damp from  
  
<a name='UnrealEngine-Framework-Maths-Damp(double_double_double_double)-to'></a>
`to` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Value to damp to  
  
<a name='UnrealEngine-Framework-Maths-Damp(double_double_double_double)-lambda'></a>
`lambda` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Smoothing factor  
  
<a name='UnrealEngine-Framework-Maths-Damp(double_double_double_double)-deltaTime'></a>
`deltaTime` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Time since last damp  
  
#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
