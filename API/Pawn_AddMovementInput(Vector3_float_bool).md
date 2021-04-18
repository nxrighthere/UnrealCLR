### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework').[Pawn](Pawn.md 'UnrealEngine.Framework.Pawn')
## Pawn.AddMovementInput(Vector3, float, bool) Method
Adds movement input along the given world direction vector (usually normalized)  
```csharp
public void AddMovementInput(in System.Numerics.Vector3 worldDirection, float scaleValue=1f, bool force=false);
```
#### Parameters
<a name='UnrealEngine_Framework_Pawn_AddMovementInput(System_Numerics_Vector3_float_bool)_worldDirection'></a>
`worldDirection` [System.Numerics.Vector3](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector3 'System.Numerics.Vector3')  
Direction in world space to apply input
  
<a name='UnrealEngine_Framework_Pawn_AddMovementInput(System_Numerics_Vector3_float_bool)_scaleValue'></a>
`scaleValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
Scale to apply to input, 0.5f applies half the normal value, while -1.0 would reverse the direction
  
<a name='UnrealEngine_Framework_Pawn_AddMovementInput(System_Numerics_Vector3_float_bool)_force'></a>
`force` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If `true`, always add the input, ignoring the result of [IsMoveInputIgnored](Controller_IsMoveInputIgnored.md 'UnrealEngine.Framework.Controller.IsMoveInputIgnored')
  
