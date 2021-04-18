### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Assert Class
Functionality to detect and diagnose unexpected or invalid runtime conditions during development, emitted if the assembly is built with the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build#options">Debug</a> configuration or if `ASSERTIONS` symbol is defined, signals a breakpoint to an attached debugger  
```csharp
public static class Assert
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Assert  
### Methods

***
[IsFalse(bool, string, int, string)](Assert_IsFalse(bool_string_int_string).md 'UnrealEngine.Framework.Assert.IsFalse(bool, string, int, string)')

Logs an assertion if condition is `true`, and prints it on the screen  

***
[IsNotNull&lt;T&gt;(T, string, int, string)](Assert_IsNotNull_T_(T_string_int_string).md 'UnrealEngine.Framework.Assert.IsNotNull&lt;T&gt;(T, string, int, string)')

Logs an assertion if value is `null`, and prints it on the screen  

***
[IsNull&lt;T&gt;(T, string, int, string)](Assert_IsNull_T_(T_string_int_string).md 'UnrealEngine.Framework.Assert.IsNull&lt;T&gt;(T, string, int, string)')

Logs an assertion if value is not `null`, and prints it on the screen  

***
[IsTrue(bool, string, int, string)](Assert_IsTrue(bool_string_int_string).md 'UnrealEngine.Framework.Assert.IsTrue(bool, string, int, string)')

Logs an assertion if condition is `false`, and prints it on the screen  
