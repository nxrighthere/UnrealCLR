- [Getting started](#getting-started)
  * [Development](#development)
  * [Project](#project)
    + [Entry point](#entry-point)
    + [Blueprint functions](#blueprint-functions)
  * [Packaging](#packaging)
- [Engine](#engine)
  * [World events](#world-events)
  * [Code structure](#code-structure)
  * [Blueprints](#blueprints)
  * [Data passing](#data-passing)
- [Tools](#tools)

Getting started
--------
### Development
UnrealCLR doesn't depend on how the development environment is organized. Any IDE such as [Visual Studio](https://visualstudio.microsoft.com), [Visual Code](https://code.visualstudio.com), or [Rider](https://www.jetbrains.com/rider/), can be used to manage a project. The programmer has full freedom to set up the building pipeline in any desirable way just as for a regular .NET library.

### Project
After [building and installing](https://github.com/nxrighthere/UnrealCLR#building) the plugin, use IDE or [CLI tool](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new) to create a [.NET class library](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new#classlib) project which targets `net5.0` in any preferable location. Don't store source code in `%Project%/Managed` folder of the engine's project, it's used exclusively for loading and packaging user assemblies by the plugin.

Add a reference to `UnrealEngine.Framework.dll` assembly located in `Source/Managed/Framework/bin/Release` folder.

Assuming you put your code in `%Project%/MyDotNetCode`, your project file should look similar to this:
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
    <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>
    <OutputPath>../Managed/Build</OutputPath>
  </PropertyGroup>

  <ItemGroup>
    <Reference Include="UnrealEngine.Framework">
      <HintPath>%UnrealCLR%/Source/Managed/Framework/bin/Release/UnrealEngine.Framework.dll</HintPath>
    </Reference>
  </ItemGroup>
</Project>
```

Create a new or open a source code file in the .NET project and replace its content with the following code:

#### Entry point

<details>
<summary>C#</summary>

```csharp
using System;
using System.Drawing;
using UnrealEngine.Framework;

namespace Game {
	public class Main { // Indicates the main entry point for automatic loading by the plugin
		public static void OnWorldBegin() => Debug.AddOnScreenMessage(-1, 10.0f, Color.DeepPink, "Hello, Unreal Engine!");

		public static void OnWorldPostBegin() => Debug.AddOnScreenMessage(-1, 10.0f, Color.DeepPink, "How's it going?");

		public static void OnWorldEnd() => Debug.AddOnScreenMessage(-1, 10.0f, Color.DeepPink, "See you soon, Unreal Engine!");

		public static void OnWorldPrePhysicsTick(float deltaTime) => Debug.AddOnScreenMessage(1, 10.0f, Color.DeepPink, "On pre physics tick invoked!");

		public static void OnWorldDuringPhysicsTick(float deltaTime) => Debug.AddOnScreenMessage(2, 10.0f, Color.DeepPink, "On during physics tick invoked!");

		public static void OnWorldPostPhysicsTick(float deltaTime) => Debug.AddOnScreenMessage(3, 10.0f, Color.DeepPink, "On post physics tick invoked!");

		public static void OnWorldPostUpdateTick(float deltaTime) => Debug.AddOnScreenMessage(4, 10.0f, Color.DeepPink, "On post update tick invoked!");
	}
}
```
</details>

<details>
<summary>F#</summary>

```fsharp
namespace Game

open System
open System.Drawing
open UnrealEngine.Framework

module Main = // Indicates the main entry point for automatic loading by the plugin
    let OnWorldBegin() = Debug.AddOnScreenMessage(-1, 10.0f, Color.DeepPink, "Hello, Unreal Engine!")

    let OnWorldPostBegin() = Debug.AddOnScreenMessage(-1, 10.0f, Color.DeepPink, "How's it going?")

    let OnWorldEnd() = Debug.AddOnScreenMessage(-1, 10.0f, Color.DeepPink, "See you soon, Unreal Engine!")

    let OnWorldPrePhysicsTick(deltaTime:float32) = Debug.AddOnScreenMessage(1, 10.0f, Color.DeepPink, "On pre physics tick invoked!")

    let OnWorldDuringPhysicsTick(deltaTime:float32) = Debug.AddOnScreenMessage(2, 10.0f, Color.DeepPink, "On during physics tick invoked!")

    let OnWorldPostPhysicsTick(deltaTime:float32) = Debug.AddOnScreenMessage(3, 10.0f, Color.DeepPink, "On post physics tick invoked!")

    let OnWorldPostUpdateTick(deltaTime:float32) = Debug.AddOnScreenMessage(4, 10.0f, Color.DeepPink, "On post update tick invoked!")
```
</details>

All functions of the main entry point are optional, and it's not necessary to implement them for every [tick group](https://docs.unrealengine.com/en-US/Programming/UnrealArchitecture/Actors/Ticking/index.html).

[Publish](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish) a .NET assembly to `%Project%/Managed` folder of the engine's project, and make sure that no other assemblies of other .NET projects are stored there.

Assemblies that no longer referenced and unused in the project will persist in `%Project%/Managed` folder. Consider maintaining this folder through IDE or automation scripts.

Enter the [play mode](https://docs.unrealengine.com/en-US/Basics/HowTo/PIE/index.html) to execute managed code. Stop the play mode to unload assemblies from memory for further recompilation.

#### Blueprint functions

<details>
<summary>C#</summary>

```csharp
using System;
using System.Drawing;
using UnrealEngine.Framework;

namespace Game {
	public class System { // Custom class for loading functions from blueprints
		public static void Function() => Debug.AddOnScreenMessage(-1, 10.0f, Color.DeepPink, "Blueprint function invoked!");
	}
}
```
</details>

<details>
<summary>F#</summary>

```fsharp
namespace Game

open System
open System.Drawing
open UnrealEngine.Framework

module System = // Custom module for loading functions from blueprints
    let Function() = Debug.AddOnScreenMessage(-1, 10.0f, Color.DeepPink, "Blueprint function invoked!")
```
</details>

To run a blueprint function, create a new or open an existing [level](https://docs.unrealengine.com/en-US/Engine/QuickStart/index.html#3.createanewlevel) of the engine. Open level blueprint by navigating to `Blueprints -> Open Level Blueprint` and create a basic execution flow by right-clicking on the graph and selecting nodes from the .NET category:

<p align="left">
	<img src="https://github.com/Rageware/Images/raw/master/UnrealCLR/level-graph.png" alt="graph">
</p>

Compile the blueprint and enter the play mode.

### Packaging
The plugin is transparently integrated into the [packaging](https://docs.unrealengine.com/en-US/Engine/Basics/Projects/Packaging/index.html) pipeline of the engine and ready for standalone distribution.

Engine
--------
### World events
The framework provides world events that are executed by the engine in a predetermined order to drive logic and simulation. Event functions are automatically loaded by the plugin from `Main` class for further execution.

`OnWorldBegin()` Called after the world is initialized before the level script.

`OnWorldPostBegin()` Called after the level script when default actors are spawned.

`OnWorldEnd()` Called before deinitialization of the world after the level script.

`OnWorldPrePhysicsTick(float deltaTime)` Called at the beginning of the frame.

`OnWorldDuringPhysicsTick(float deltaTime)` Called when physics simulation has begun.

`OnWorldPostPhysicsTick(float deltaTime)` Called when physics simulation is complete.

`OnWorldPostUpdateTick(float deltaTime)` Called after cameras are updated.

### Code structure
The plugin allows organizing the code structure of the project in any preferable way. Any paradigms or patterns can be used to drive logic and simulation without any intermediate management between user code and the engine.

**Object-Oriented Design**

```csharp
using System;
using System.Drawing;
using UnrealEngine.Framework;

namespace Game {
	public class Main {
		private static Entity[] entities = new Entity[32];

		public static void OnWorldBegin() {
			for (int i = 0; i < entities.Length; i++) {
				entities[i] = new Entity(nameof(Entity) + i);
				entities[i].OnBegin();
			}
		}

		public static void OnWorldPrePhysicsTick(float deltaTime) {
			for (int i = 0; i < entities.Length; i++) {
				if (entities[i].CanTick)
					entities[i].OnPrePhysicsTick(deltaTime);
			}
		}
	}

	public class Entity : Actor {
		public Entity(string name = null, bool canTick = true) : base(name) {
			CanTick = canTick;
		}

		public bool CanTick { get; set; }

		public void OnBegin() => Debug.AddOnScreenMessage(-1, 1.0f, Color.LightSeaGreen, Name + " begin!");

		public void OnPrePhysicsTick(float deltaTime) => Debug.AddOnScreenMessage(-1, 1.0f, Color.LightSteelBlue, Name + " tick!");
	}
}
```

**Data-Oriented Design**

```csharp
using System;
using System.Drawing;
using UnrealEngine.Framework;

namespace Game {
	public class Main {
		private static Actor[] entities = new Actor[32];
		private static bool[] canTick = new bool[entities.Length];

		public static void OnWorldBegin() {
			for (int i = 0; i < entities.Length; i++) {
				entities[i] = new Actor("Entity" + i);
				canTick[i] = true;

				OnEntityBegin(i);
			}
		}

		public static void OnWorldPrePhysicsTick(float deltaTime) {
			for (int i = 0; i < entities.Length; i++) {
				if (canTick[i])
					OnEntityPrePhysicsTick(i, deltaTime);
			}
		}

		private static void OnEntityBegin(int id) => Debug.AddOnScreenMessage(-1, 1.0f, Color.LightSeaGreen, entities[id].Name + " begin!");

		private static void OnEntityPrePhysicsTick(int id, float deltaTime) => Debug.AddOnScreenMessage(-1, 1.0f, Color.LightSteelBlue, entities[id].Name + " tick!");
	}
}
```

See [tests project](https://github.com/nxrighthere/UnrealCLR/tree/master/Source/Managed/Tests) for a basic implementation of various systems.

### Blueprints
The plugin provides two blueprints to manage the execution. They can be used in any combinations with other nodes, data types, and C++ code to weave managed functionality with events. It's highly recommended to use creative approaches that extract information from blueprint classes instead of using plain strings for managed functions.

**Find Managed Function**

Attempts to find a managed function from loaded assemblies. This node performs a fast operation to retrieve function pointer from the cached dictionary once assemblies loaded after entering the play mode. Logs an error if the managed function was not found and sets `Result` parameter to `false`. `Optional` checkbox indicates if the managed function is optional and the error should not be logged.

**Execute Managed Function**

Attempts to execute a managed function. This node performs a fast execution of a function pointer. Optionally allows passing an [object reference](https://github.com/nxrighthere/UnrealCLR/blob/master/API/ObjectReference.md) of the engine to managed code with further conversion to an appropriate type.

### Data passing
Several options are available to pass data between the managed runtime and the engine.

**Commands, functions, and events**

The engine's reflection system allows to dynamically invoke commands, functions, and events of engine classes from managed code to pass data on-demand through custom arguments.

Blueprint event dispatcher:

<p align="left">
	<img src="https://github.com/Rageware/Images/raw/master/UnrealCLR/event-dispatcher.png" alt="event-dispatcher">
</p>

```csharp
blueprint.Invoke($"TestEvent \"{ message }\" { value }");
```

See [Actor.Invoke()](https://github.com/nxrighthere/UnrealCLR/blob/master/API/Actor-Invoke(string).md), [ActorComponent.Invoke()](https://github.com/nxrighthere/UnrealCLR/blob/master/API/ActorComponent-Invoke(string).md), and [AnimationInstance.Invoke()](https://github.com/nxrighthere/UnrealCLR/blob/master/API/AnimationInstance-Invoke(string).md) methods.

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

See [Actor](https://github.com/nxrighthere/UnrealCLR/blob/master/API/Actor.md), [ActorComponent](https://github.com/nxrighthere/UnrealCLR/blob/master/API/ActorComponent.md), and [AnimationInstance](https://github.com/nxrighthere/UnrealCLR/blob/master/API/AnimationInstance.md) classes for appropriate methods to get and set data.

**Console variables**

Data that should be globally accessible can be stored in console variables and modified from the editor's console.

<p align="left">
	<img src="https://github.com/Rageware/Images/raw/master/UnrealCLR/console-variable.png" alt="console-variable">
</p>

See [ConsoleVariable](https://github.com/nxrighthere/UnrealCLR/blob/master/API/ConsoleVariable.md) class for appropriate methods to get and set data.

Tools
--------
The plugin is compatible with [.NET tools](https://github.com/natemcmaster/dotnet-tools) and makes the engine's application instance visible as a regular .NET application for IDEs and external programs.
