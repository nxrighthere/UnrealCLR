### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## ConsoleVariable Class
Interface for console variables  
```csharp
public class ConsoleVariable : UnrealEngine.Framework.ConsoleObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ConsoleObject](ConsoleObject.md 'UnrealEngine.Framework.ConsoleObject') &#129106; ConsoleVariable  
### Methods

***
[ClearOnChangedCallback()](ConsoleVariable_ClearOnChangedCallback().md 'UnrealEngine.Framework.ConsoleVariable.ClearOnChangedCallback()')

Clears callback function  

***
[GetBool()](ConsoleVariable_GetBool().md 'UnrealEngine.Framework.ConsoleVariable.GetBool()')

Returns the value as a bool, also works on integers and floats  

***
[GetFloat()](ConsoleVariable_GetFloat().md 'UnrealEngine.Framework.ConsoleVariable.GetFloat()')

Returns the value as a float, works on all types  

***
[GetInt()](ConsoleVariable_GetInt().md 'UnrealEngine.Framework.ConsoleVariable.GetInt()')

Returns the value as an integer, shouldn't be used on strings  

***
[GetString()](ConsoleVariable_GetString().md 'UnrealEngine.Framework.ConsoleVariable.GetString()')

Returns the value as a string, works on all types  

***
[SetBool(bool)](ConsoleVariable_SetBool(bool).md 'UnrealEngine.Framework.ConsoleVariable.SetBool(bool)')

Sets the value as a bool  

***
[SetFloat(float)](ConsoleVariable_SetFloat(float).md 'UnrealEngine.Framework.ConsoleVariable.SetFloat(float)')

Sets the value as a float  

***
[SetInt(int)](ConsoleVariable_SetInt(int).md 'UnrealEngine.Framework.ConsoleVariable.SetInt(int)')

Sets the value as an integer  

***
[SetOnChangedCallback(ConsoleVariableDelegate)](ConsoleVariable_SetOnChangedCallback(ConsoleVariableDelegate).md 'UnrealEngine.Framework.ConsoleVariable.SetOnChangedCallback(UnrealEngine.Framework.ConsoleVariableDelegate)')

Sets the callback function that is called when the console variable value changes  

***
[SetString(string)](ConsoleVariable_SetString(string).md 'UnrealEngine.Framework.ConsoleVariable.SetString(string)')

Sets the value as a string  
