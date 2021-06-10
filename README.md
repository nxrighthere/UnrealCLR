<p align="center">
	<img src="https://i.imgur.com/c6Zn7SE.png" alt="alt logo">
</p>

[![PayPal](https://github.com/Rageware/Shields/blob/master/paypal.svg)](https://www.paypal.me/nxrighthere) [![Coinbase](https://github.com/Rageware/Shields/blob/master/coinbase.svg)](https://commerce.coinbase.com/checkout/03e11816-b6fc-4e14-b974-29a1d0886697)

UnrealCLR is a plugin which natively integrates .NET host into the Unreal Engine with the Common Language Runtime for direct execution of managed code to build a game/application logic using the full power of C# 9.0, F# 5.0, and .NET facilities with engine API. The project is aimed at stability, performance, and maintainability.

[API reference](https://github.com/nxrighthere/UnrealCLR/blob/master/API/UnrealEngine-Framework.md) | [Manual](https://github.com/nxrighthere/UnrealCLR/blob/master/MANUAL.md) | [Code of Conduct](https://github.com/nxrighthere/UnrealCLR/blob/master/CODE_OF_CONDUCT.md) | [Community](https://github.com/nxrighthere/UnrealCLR/discussions) | [Roadmap](https://github.com/users/nxrighthere/projects/5?fullscreen=true) | [Contact](mailto:nxrighthere@gmail.com)

Features:

- Host loading, integration, and management during the lifetime of the engine
- Dynamic loading, unloading, isolation, and dependency resolving of user assemblies at runtime
- On-the-fly access and execution of managed functionality through blueprints
- Runtime exceptions handling and tracing
- Continuously evolving framework for access to the engine API from managed code written in idiomatic C#
- High-performance interoperability through optimized code and utilization of blittable data types
- Support of .NET facilities including hardware-accelerated math with transparent re-mapping to vector types of the engine
- Support of .NET tools for debugging and profiling such as [JetBrains](https://www.jetbrains.com/products.html#lang=csharp) product line, [dnSpy](https://github.com/0xd4d/dnSpy) debugger, and [others](https://github.com/natemcmaster/dotnet-tools)
- Full independence from the compilation pipeline of assemblies with support of [NuGet](https://www.nuget.org) packages, analyzers, and generators
- Automatic project packaging for standalone distribution
- Carefully handcrafted source code for best maintainability and performance
- Extensive unit testing to ensure the robustness and consistency
- Distributed as a plugin and doesn't require rebuilding the engine
- Documented source code

The plugin is available for Windows, Linux, and macOS (x64).

<p align="center"> 
  <img src="https://i.imgur.com/ITARWUQ.png" alt="megagrant">
</p>

Building
--------
### Prerequisites
- Unreal Engine 4.25.4 or higher
- A native [compilation toolchain](https://docs.unrealengine.com/en-US/Programming/Development/VisualStudioSetup/index.html#runtheunrealenginepre-requisiteinstaller) with platform-specific dependencies
- [.NET 5 SDK 5.0.301](https://dotnet.microsoft.com/download/dotnet/5.0)

### Auto

#### Compilation
Create a new or use an existing Unreal Engine C++ or blueprints project. Clone the repository or download a desirable version from the [releases](https://github.com/nxrighthere/UnrealCLR/releases) section. Navigate to `Install` folder, and run `dotnet run` command. Follow the installation instructions. Open the project after the installation process is complete.

#### Upgrading
Make sure that the Unreal Engine is not running. Re-run the installation process. Recompile custom code with an updated framework.

#### Command-line options
`--project-path <path>` Sets a path to an Unreal Engine project

`--compile-tests <true/false>` Indicates whether tests should be compiled

`--overwrite-files` Indicates whether all previous files of the plugin and content of tests should be overwritten

### Manual

#### Compilation

##### Plugin
Create a new or use an existing Unreal Engine C++ or blueprints project. Clone the repository or download a desirable version from the [releases](https://github.com/nxrighthere/UnrealCLR/releases) section. Copy the content of the `Source/Native` folder to `%Project%/Plugins/UnrealCLR` directory. Compile the managed runtime from `Source/Managed/Runtime` folder by running the following command: `dotnet publish --configuration Release --framework net5.0 --output "%Project%/Plugins/UnrealCLR/Managed"`. Restart Unreal Engine, open the project, and build the plugin.

##### Tests
To quickly start testing, open a project with the plugin in Unreal Engine, copy all folders from the `Content` of the repository to `%Project%/Content` directory, and wait until they loaded in the Content Browser. Compile the managed assemblies from `Source/Managed/Tests` folder by running the following commands:
```
dotnet publish "../Framework" --configuration Release --framework net5.0
dotnet publish --configuration Release --framework net5.0 --output "%Project%/Managed/Tests"
```

#### Upgrading
Make sure that the Unreal Engine is not running. Delete the plugin folder from a project, and repeat all steps from the compilation section. Recompile custom code with an updated framework.

Running
--------
### Plugin
The plugin is automatically loaded at startup. To make sure that it's initialized open the console window from `Window -> Developer Tools -> Output Log`, find `UnrealCLR` logs using the search input.

### Tests
Open the scene with tests in the editor and enter the play mode. To switch a test, navigate to `Blueprints -> Open Level Blueprint`, select the `Test Systems` enumeration on the left panel, and change default value on the right panel.

Overview
--------
### Design and architecture
UnrealCLR is designed to be flexible and extensible. The plugin is transparently managing core functionality of the runtime, binding and caching the engine API for managed environment. The programmer has full control over execution flow through code and blueprints that allow to dynamically weave native events of the engine and its objects with managed logic. There's no hidden states or obscured order of execution behind the lifecycle of scripts.

### Assemblies management
At runtime, UnrealCLR loading managed assemblies into a cached isolated context. It allows dynamically replace assemblies after unloading them from memory, therefore the programmer can work with code without restarting the editor for continuous development. The compilation pipeline is entirely up to a developer, it can be organized in any desirable way without any limitations and with full support of [NuGet](https://www.nuget.org) packages.

### Engine application program interface
The plugin and framework are evolving all the time to utilize as much power of the Unreal Engine as possible. It's crucial to have a feature-rich API. The system is created with high-performance in mind but without trading safety. The vast majority of code is written and verified by hand to prevent any unexpected behaviors at runtime and to ensure stability.

### Powerful tooling
Use your favorite IDE and [.NET tools](https://github.com/natemcmaster/dotnet-tools) that can be attached to the process of the engine just as to a regular .NET application for profiling and debugging. It's very convenient and works out of the box without any external effort. Analyze performance, monitor CPU usage and memory consumption, debug execution, take full control over the code. Explore new possibilities and extend your toolset in no time.

Essentials
--------
### Exceptions
The runtime redirects all unhandled exceptions to log files, the console window, and on-screen messages of the engine, however, it's highly recommended to use [try/catch](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-use-the-try-catch-block-to-catch-exceptions) blocks to override redirections with custom handlers. It's necessary to have an attached debugger to properly trace exceptions in the editor or standalone.

### Memory management
Unreal Engine, as well as .NET runtime, utilizes a garbage collector for memory management. The framework is designed with consistency in mind to prevent crashes and validate memory transparently for a programmer, no matter how objects were created and freed: with C++, C#, F#, or blueprints.

### Hot reload
The plugin is independent of the compilation routine of user assemblies. It's loading assemblies from `%Project%/Managed` folder and resolving dependencies at runtime after entering/leaving the play mode. The framework of the plugin with the engine API is automatically recognized and loaded as a dependency.

### Ecosystem compatibility
The framework replicates the class hierarchy of the engine with full interoperability support. Any external C++ code, blueprints, and plugins are compatible and extensible with UnrealCLR by design through the engine API. The plugin integrated into the engine's building pipeline and ready for distribution of self-contained applications.

Acknowledgments
--------
Thanks to [@natemcmaster](https://github.com/natemcmaster) for a great .NET library that simplifies dynamic loading of assemblies.

Special thanks to [@Doraku](https://github.com/Doraku) for an amazing documentation generator and rapid improvement of it.

Supporters
--------
These wonderful people make open-source better:
<p align="left"> 
  <img src="https://github.com/Rageware/Supporters/blob/master/unrealclr-supporters.png" alt="supporters">
</p>
