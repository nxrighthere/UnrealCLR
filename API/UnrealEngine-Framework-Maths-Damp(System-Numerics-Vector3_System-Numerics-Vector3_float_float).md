### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Maths](./UnrealEngine-Framework-Maths.md 'UnrealEngine.Framework.Maths')
## Maths.Damp(System.Numerics.Vector3, System.Numerics.Vector3, float, float) Method
Creates framerate-independent dampened motion between two values  
```csharp
public static System.Numerics.Vector3 Damp(System.Numerics.Vector3 from, System.Numerics.Vector3 to, float lambda, float deltaTime);
```
#### Parameters
<a name='UnrealEngine-Framework-Maths-Damp(System-Numerics-Vector3_System-Numerics-Vector3_float_float)-from'></a>
`from` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Value to damp from  
  
<a name='UnrealEngine-Framework-Maths-Damp(System-Numerics-Vector3_System-Numerics-Vector3_float_float)-to'></a>
`to` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Value to damp to  
  
<a name='UnrealEngine-Framework-Maths-Damp(System-Numerics-Vector3_System-Numerics-Vector3_float_float)-lambda'></a>
`lambda` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Smoothing factor  
  
<a name='UnrealEngine-Framework-Maths-Damp(System-Numerics-Vector3_System-Numerics-Vector3_float_float)-deltaTime'></a>
`deltaTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Time since last damp  
  
#### Returns
[System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
