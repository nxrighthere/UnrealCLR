### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Maths](./Maths.md 'UnrealEngine.Framework.Maths')
## Maths.Damp(System.Numerics.Vector2, System.Numerics.Vector2, float, float) Method
Creates framerate-independent dampened motion between two values  
```csharp
public static System.Numerics.Vector2 Damp(System.Numerics.Vector2 from, System.Numerics.Vector2 to, float lambda, float deltaTime);
```
#### Parameters
<a name='UnrealEngine-Framework-Maths-Damp(System-Numerics-Vector2_System-Numerics-Vector2_float_float)-from'></a>
`from` [System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')  
Value to damp from  
  
<a name='UnrealEngine-Framework-Maths-Damp(System-Numerics-Vector2_System-Numerics-Vector2_float_float)-to'></a>
`to` [System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')  
Value to damp to  
  
<a name='UnrealEngine-Framework-Maths-Damp(System-Numerics-Vector2_System-Numerics-Vector2_float_float)-lambda'></a>
`lambda` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Smoothing factor  
  
<a name='UnrealEngine-Framework-Maths-Damp(System-Numerics-Vector2_System-Numerics-Vector2_float_float)-deltaTime'></a>
`deltaTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Time since last damp  
  
#### Returns
[System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')  
