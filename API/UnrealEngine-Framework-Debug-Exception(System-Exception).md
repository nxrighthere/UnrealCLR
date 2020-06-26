### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[Debug](./UnrealEngine-Framework-Debug.md 'UnrealEngine.Framework.Debug')
## Debug.Exception(System.Exception) Method
Creates a log file with the name of assembly if required and writes an exception to it, prints it on the screen, printing on the screen is omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration, but log file will persist  
```csharp
public static void Exception(System.Exception exception);
```
#### Parameters
<a name='UnrealEngine-Framework-Debug-Exception(System-Exception)-exception'></a>
`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
  
