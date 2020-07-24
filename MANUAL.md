- [Getting started](#getting-started)
  * [Development](#development)
  * [Project](#project)
    + [Creating](#creating)
    + [Running](#running)
    + [Packaging](#packaging)
- [Engine](#engine)
  * [Blueprints](#blueprints)
  * [Data passing](#data-passing)
- [Tools](#tools)

Getting started
--------
### Development
UnrealCLR not tied to how organized the development environment. Any IDE such as [Visual Studio](https://visualstudio.microsoft.com), [Visual Code](https://code.visualstudio.com), or [Rider](https://www.jetbrains.com/rider/), can be used to manage a project with C# code. A programmer has full freedom to set up the building pipeline in any desirable way just as for a regular .NET library.

### Project
#### Creating
After [building and installing](https://github.com/nxrighthere/UnrealCLR#building) the plugin, use IDE or [CLI tool](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new) to create a [.NET class library](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new#classlib) project which targets .NET Core in any preferable location. Don't store source code in `%Project%/Managed` folder of the engine's project, it's used exclusively for loading and packaging user assemblies by the plugin.

Add a reference to `UnrealEngine.Framework.dll` assembly located in `Source/Managed/Framework/bin/Release` folder. Create a new or open a C# class file in the .NET project and replace its content with the following code:
```csharp
using System;
using System.Drawing;
using UnrealEngine.Framework;

namespace Game {
	public static class Main {
		public static void OnBeginPlay() => Debug.AddOnScreenMessage(-1, 10.0f, Color.DeepPink, "Hello, Unreal Engine!");
	}
}
```
Build a .NET assembly to `%Project%/Managed` folder of the engine's project, and make sure that no other assemblies of other .NET projects are stored there. 

Assemblies that no longer referenced and unused in the project will persist in `%Project%/Managed` folder. Consider maintaining this folder through IDE or automation scripts.

#### Running
Create a new or open an existing [level](https://docs.unrealengine.com/en-US/Engine/QuickStart/index.html#3.createanewlevel) of the engine. Open level blueprint by navigating to `Blueprints -> Open Level Blueprint` and create a basic execution pipeline:

<p align="left">
	<img src="https://github.com/Rageware/Images/raw/master/UnrealCLR/level-graph.png" alt="graph">
</p>

Compile the blueprint and enter the [play mode](https://docs.unrealengine.com/en-US/Engine/UI/LevelEditor/InEditorTesting/index.html).

#### Packaging
The plugin is transparently integrated into the [packaging](https://docs.unrealengine.com/en-US/Engine/Basics/Projects/Packaging/index.html) pipeline of the engine and ready for standalone distribution.

Engine
--------
### Blueprints
The plugin provides two blueprints to manage the execution. They can be used in any combinations with other nodes, data types, and C++ code to weave managed functionality with events. It's highly recommended to use creative approaches that extract information from blueprint classes instead of using plain strings for managed functions.

**Find Managed Function**

Attempts to find a managed function from loaded assemblies. This node performs a fast operation to retrieve function pointer from the cached dictionary once assemblies loaded after entering the play mode. Logs an error if the managed function was not found and sets `Result` parameter to `false`. `Optional` checkbox indicates if the managed function is optional and the error should not be logged.

**Execute Managed Function**

Attempts to execute a managed function. This node performs a fast execution of a function pointer. Optionally allows passing an [object reference](https://github.com/nxrighthere/UnrealCLR/blob/master/API/ObjectReference.md) of the engine to managed code with conversion to an appropriate type.

### Data passing
Two options are available to pass data between the managed runtime and the engine.

**Blueprint variables**

The engine provides a convenient way to [manage variables/properties](https://docs.unrealengine.com/en-US/Engine/Blueprints/UserGuide/Variables/index.html) per actor/component basis that are accessible from the world outliner.

Instance-editable blueprint variables:

<p align="left">
	<img src="https://github.com/Rageware/Images/raw/master/UnrealCLR/blueprint-variables.png" alt="blueprint-variables">
</p>

Exposed as properties and accessible from the world outliner:

<p align="left">
	<img src="https://github.com/Rageware/Images/raw/master/UnrealCLR/editor-properties.png" alt="editor-properties">
</p>

See [Actor](https://github.com/nxrighthere/UnrealCLR/blob/master/API/Actor.md) and [ActorComponent](https://github.com/nxrighthere/UnrealCLR/blob/master/API/ActorComponent.md) classes for appropriate methods to get and set data.

**Console variables**

Data that should be globally accessible can be stored in console variables and modified from the editor's console.

<p align="left">
	<img src="https://github.com/Rageware/Images/raw/master/UnrealCLR/console-variable.png" alt="console-variable">
</p>

See [ConsoleVariable](https://github.com/nxrighthere/UnrealCLR/blob/master/API/ConsoleVariable.md) class for appropriate methods to get and set data.

Tools
--------
The plugin is compatible with [.NET tools](https://github.com/natemcmaster/dotnet-tools) and makes the engine's application instance visible as a regular .NET application for IDEs and external programs.
