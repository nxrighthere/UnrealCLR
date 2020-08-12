### [UnrealEngine.Framework](./UnrealEngine-Framework.md 'UnrealEngine.Framework').[ConsoleVariable](./ConsoleVariable.md 'UnrealEngine.Framework.ConsoleVariable')
## ConsoleVariable.SetOnChangedCallback(UnrealEngine.Framework.ConsoleVariableDelegate) Method
Sets the static callback function that is called when the console variable value changes  
```csharp
public void SetOnChangedCallback(UnrealEngine.Framework.ConsoleVariableDelegate callback);
```
#### Parameters
<a name='UnrealEngine-Framework-ConsoleVariable-SetOnChangedCallback(UnrealEngine-Framework-ConsoleVariableDelegate)-callback'></a>
`callback` [ConsoleVariableDelegate()](./ConsoleVariableDelegate().md 'UnrealEngine.Framework.ConsoleVariableDelegate()')  
The static function to call when the value of variable is changed  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown if [callback](#UnrealEngine-Framework-ConsoleVariable-SetOnChangedCallback(UnrealEngine-Framework-ConsoleVariableDelegate)-callback 'UnrealEngine.Framework.ConsoleVariable.SetOnChangedCallback(UnrealEngine.Framework.ConsoleVariableDelegate).callback') is not static  
