### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[World](./World.md 'UnrealEngine.Framework.World')
## World.SetOnComponentEndOverlapCallback(UnrealEngine.Framework.ComponentOverlapDelegate) Method
Sets the static callback function that is called when primitive components end overlapping  
```csharp
public static void SetOnComponentEndOverlapCallback(UnrealEngine.Framework.ComponentOverlapDelegate callback);
```
#### Parameters
<a name='UnrealEngine-Framework-World-SetOnComponentEndOverlapCallback(UnrealEngine-Framework-ComponentOverlapDelegate)-callback'></a>
`callback` [ComponentOverlapDelegate(UnrealEngine.Framework.ObjectReference, UnrealEngine.Framework.ObjectReference)](./ComponentOverlapDelegate(ObjectReference_ObjectReference).md 'UnrealEngine.Framework.ComponentOverlapDelegate(UnrealEngine.Framework.ObjectReference, UnrealEngine.Framework.ObjectReference)')  
The static function to call when a primitive component end overlapping with another one  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown if [callback](#UnrealEngine-Framework-World-SetOnComponentEndOverlapCallback(UnrealEngine-Framework-ComponentOverlapDelegate)-callback 'UnrealEngine.Framework.World.SetOnComponentEndOverlapCallback(UnrealEngine.Framework.ComponentOverlapDelegate).callback') is not static  
