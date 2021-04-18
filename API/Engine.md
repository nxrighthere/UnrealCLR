### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Engine Class
Functionality for management of engine systems  
```csharp
public static class Engine
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Engine  
### Properties

***
[FrameNumber](Engine_FrameNumber.md 'UnrealEngine.Framework.Engine.FrameNumber')

Incremented once per frame before the scene is being rendered  

***
[IsEditor](Engine_IsEditor.md 'UnrealEngine.Framework.Engine.IsEditor')

Returns `true` if the script is executing within the editor  

***
[IsExitRequested](Engine_IsExitRequested.md 'UnrealEngine.Framework.Engine.IsExitRequested')

Returns `true` if the exit was requested  

***
[IsForegroundWindow](Engine_IsForegroundWindow.md 'UnrealEngine.Framework.Engine.IsForegroundWindow')

Returns `true` if the window has focus  

***
[IsSplitScreen](Engine_IsSplitScreen.md 'UnrealEngine.Framework.Engine.IsSplitScreen')

Returns `true` if the game is running in split screen mode  

***
[MaxFPS](Engine_MaxFPS.md 'UnrealEngine.Framework.Engine.MaxFPS')

Gets or sets max frames per second, overrides console variable  

***
[NetMode](Engine_NetMode.md 'UnrealEngine.Framework.Engine.NetMode')

Returns the current networking mode  

***
[Version](Engine_Version.md 'UnrealEngine.Framework.Engine.Version')

Returns the current engine version  

***
[WindowMode](Engine_WindowMode.md 'UnrealEngine.Framework.Engine.WindowMode')

Returns the current mode of the window  
### Methods

***
[AddActionMapping(string, string, bool, bool, bool, bool)](Engine_AddActionMapping(string_string_bool_bool_bool_bool).md 'UnrealEngine.Framework.Engine.AddActionMapping(string, string, bool, bool, bool, bool)')

Adds an engine defined action mapping, cannot be remapped  

***
[AddAxisMapping(string, string, float)](Engine_AddAxisMapping(string_string_float).md 'UnrealEngine.Framework.Engine.AddAxisMapping(string, string, float)')

Adds an engine defined mapping between an axis and key, cannot be remapped  

***
[DelayGarbageCollection()](Engine_DelayGarbageCollection().md 'UnrealEngine.Framework.Engine.DelayGarbageCollection()')

Requests a one frame delay of garbage collection  

***
[ForceGarbageCollection(bool)](Engine_ForceGarbageCollection(bool).md 'UnrealEngine.Framework.Engine.ForceGarbageCollection(bool)')

Updates the timer between garbage collection such that at the next opportunity garbage collection will be run  

***
[GetScreenResolution()](Engine_GetScreenResolution().md 'UnrealEngine.Framework.Engine.GetScreenResolution()')

Returns the current resolution of the screen  

***
[GetScreenResolution(Vector2)](Engine_GetScreenResolution(Vector2).md 'UnrealEngine.Framework.Engine.GetScreenResolution(System.Numerics.Vector2)')

Retrieves the current resolution of the screen  

***
[GetViewportSize()](Engine_GetViewportSize().md 'UnrealEngine.Framework.Engine.GetViewportSize()')

Returns the current size of the viewport  

***
[GetViewportSize(Vector2)](Engine_GetViewportSize(Vector2).md 'UnrealEngine.Framework.Engine.GetViewportSize(System.Numerics.Vector2)')

Retrieves the current size of the viewport  

***
[SetTitle(string)](Engine_SetTitle(string).md 'UnrealEngine.Framework.Engine.SetTitle(string)')

Sets the window title  
