### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Debug Class
Functionality for debugging  
```csharp
public static class Debug
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Debug  
### Methods

***
[AddOnScreenMessage(int, float, Color, string)](Debug_AddOnScreenMessage(int_float_Color_string).md 'UnrealEngine.Framework.Debug.AddOnScreenMessage(int, float, System.Drawing.Color, string)')

Prints a debug message on the screen assigned to the key identifier, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration  

***
[ClearOnScreenMessages()](Debug_ClearOnScreenMessages().md 'UnrealEngine.Framework.Debug.ClearOnScreenMessages()')

Clears any existing debug messages, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration  

***
[DrawBox(Vector3, Vector3, Quaternion, Color, bool, float, byte, float)](Debug_DrawBox(Vector3_Vector3_Quaternion_Color_bool_float_byte_float).md 'UnrealEngine.Framework.Debug.DrawBox(System.Numerics.Vector3, System.Numerics.Vector3, System.Numerics.Quaternion, System.Drawing.Color, bool, float, byte, float)')

Draws a debug box, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration  

***
[DrawCapsule(Vector3, float, float, Quaternion, Color, bool, float, byte, float)](Debug_DrawCapsule(Vector3_float_float_Quaternion_Color_bool_float_byte_float).md 'UnrealEngine.Framework.Debug.DrawCapsule(System.Numerics.Vector3, float, float, System.Numerics.Quaternion, System.Drawing.Color, bool, float, byte, float)')

Draws a debug capsule, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration  

***
[DrawCone(Vector3, Vector3, float, float, float, int, Color, bool, float, byte, float)](Debug_DrawCone(Vector3_Vector3_float_float_float_int_Color_bool_float_byte_float).md 'UnrealEngine.Framework.Debug.DrawCone(System.Numerics.Vector3, System.Numerics.Vector3, float, float, float, int, System.Drawing.Color, bool, float, byte, float)')

Draws a debug cone, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration  

***
[DrawCylinder(Vector3, Vector3, float, int, Color, bool, float, byte, float)](Debug_DrawCylinder(Vector3_Vector3_float_int_Color_bool_float_byte_float).md 'UnrealEngine.Framework.Debug.DrawCylinder(System.Numerics.Vector3, System.Numerics.Vector3, float, int, System.Drawing.Color, bool, float, byte, float)')

Draws a debug cylinder, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration  

***
[DrawLine(Vector3, Vector3, Color, bool, float, byte, float)](Debug_DrawLine(Vector3_Vector3_Color_bool_float_byte_float).md 'UnrealEngine.Framework.Debug.DrawLine(System.Numerics.Vector3, System.Numerics.Vector3, System.Drawing.Color, bool, float, byte, float)')

Draws a debug line, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration  

***
[DrawPoint(Vector3, float, Color, bool, float, byte)](Debug_DrawPoint(Vector3_float_Color_bool_float_byte).md 'UnrealEngine.Framework.Debug.DrawPoint(System.Numerics.Vector3, float, System.Drawing.Color, bool, float, byte)')

Draws a debug point, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration  

***
[DrawSphere(Vector3, float, int, Color, bool, float, byte, float)](Debug_DrawSphere(Vector3_float_int_Color_bool_float_byte_float).md 'UnrealEngine.Framework.Debug.DrawSphere(System.Numerics.Vector3, float, int, System.Drawing.Color, bool, float, byte, float)')

Draws a debug sphere, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration  

***
[Exception(Exception)](Debug_Exception(Exception).md 'UnrealEngine.Framework.Debug.Exception(System.Exception)')

Creates a log file with the name of assembly if required and writes an exception to it, prints it on the screen, printing on the screen is omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration, but log file will persist  

***
[FlushPersistentLines()](Debug_FlushPersistentLines().md 'UnrealEngine.Framework.Debug.FlushPersistentLines()')

Flushes persistent debug lines, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration  

***
[Log(LogLevel, string)](Debug_Log(LogLevel_string).md 'UnrealEngine.Framework.Debug.Log(UnrealEngine.Framework.LogLevel, string)')

Logs a message in accordance to the specified level, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration  
