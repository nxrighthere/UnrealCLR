### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[World](./World.md 'UnrealEngine.Framework.World')
## World.SetOnComponentEndOverlapCallback(UnrealEngine.Framework.PrimitiveComponentOverlapDelegate) Method
Sets the static callback function that is called when primitive components end overlapping  
```csharp
public static void SetOnComponentEndOverlapCallback(UnrealEngine.Framework.PrimitiveComponentOverlapDelegate callback);
```
#### Parameters
<a name='UnrealEngine-Framework-World-SetOnComponentEndOverlapCallback(UnrealEngine-Framework-PrimitiveComponentOverlapDelegate)-callback'></a>
`callback` [PrimitiveComponentOverlapDelegate(UnrealEngine.Framework.ObjectReference, UnrealEngine.Framework.ObjectReference)](./PrimitiveComponentOverlapDelegate(ObjectReference_ObjectReference).md 'UnrealEngine.Framework.PrimitiveComponentOverlapDelegate(UnrealEngine.Framework.ObjectReference, UnrealEngine.Framework.ObjectReference)')  
The static function to call when a primitive component end overlapping with another one  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown if [callback](#UnrealEngine-Framework-World-SetOnComponentEndOverlapCallback(UnrealEngine-Framework-PrimitiveComponentOverlapDelegate)-callback 'UnrealEngine.Framework.World.SetOnComponentEndOverlapCallback(UnrealEngine.Framework.PrimitiveComponentOverlapDelegate).callback') is not static  
