<p align="center">
	<img src="https://i.imgur.com/c6Zn7SE.png" alt="alt logo">
</p>

[![PayPal](https://github.com/Rageware/Shields/blob/master/paypal.svg)](https://www.paypal.me/nxrighthere) [![Bountysource](https://github.com/Rageware/Shields/blob/master/bountysource.svg)](https://salt.bountysource.com/checkout/amount?team=nxrighthere) [![Coinbase](https://github.com/Rageware/Shields/blob/master/coinbase.svg)](https://commerce.coinbase.com/checkout/03e11816-b6fc-4e14-b974-29a1d0886697)

UnrealCLR is a plugin which natively integrates .NET Core host into the Unreal Engine with the Common Language Runtime for direct execution of the managed code through user-driven blueprint pipelines to build a game logic using the full power of .NET facilities with engine API. The project is aimed at stability, performance, and maintainability.

[API reference](https://github.com/nxrighthere/UnrealCLR/blob/master/API/UnrealEngine-Framework.md) | [Roadmap](https://github.com/users/nxrighthere/projects/5?fullscreen=true) | [Legend](https://github.com/nxrighthere/UnrealCLR/blob/master/LEGEND.md) | [Support](https://gumroad.com/l/unrealclr) | [Contact](mailto:nxrighthere@gmail.com)

Features:

- Host loading, integration, and management during the lifetime of the engine
- Dynamic loading, unloading, isolation, and dependency resolving of user assemblies at runtime
- On-the-fly access and execution of the managed functionality through blueprints
- Runtime exceptions handling and tracing
- Continuously evolving framework for access to the engine API from the managed code written in idiomatic C#
- High-performance interoperability through generated IL code and utilization of blittable data types
- Support of .NET facilities including hardware-accelerated math with transparent re-mapping to vector types of the engine
- Support of .NET tools for debugging and profiling such as [JetBrains](https://www.jetbrains.com/products.html#lang=csharp) product line, [dnSpy](https://github.com/0xd4d/dnSpy) debugger, and others
- Full independence from the compilation pipeline of assemblies with support of [NuGet](https://www.nuget.org) packages, analyzers, and generators
- Automatic project packaging for standalone distribution
- Carefully handcrafted source code for best maintainability and performance
- Extensive unit testing to ensure the robustness and consistency
- Distributed as a plugin and doesn't require rebuilding the engine
- Documented source code

The plugin is available for Windows, Linux, and macOS (x64).

Building
--------
### Prerequisites
- Unreal Engine 4.25.1
- A native [compilation toolchain](https://docs.unrealengine.com/en-US/Programming/Development/VisualStudioSetup/index.html) with platform-specific dependencies
- [.NET Core SDK 3.1.301](https://dotnet.microsoft.com/download/dotnet-core/3.1)

### Auto

#### Compilation
Create a new or use an existing Unreal Engine C++ project. Clone the repository, navigate to `Install` folder, and run `dotnet run`. Follow the installation instructions. Open the project after the installation process is complete.

#### Upgrading
To upgrade the plugin, re-run the installation process.

### Manual

#### Compilation

##### Plugin
Create a new or use an existing Unreal Engine C++ project. Clone the repository, copy the content of the `Source/Native` folder to `%Project%/Plugins/UnrealCLR` directory. Compile the managed runtime from `Source/Managed/Runtime` folder by running the following command: `dotnet publish --configuration Release --framework netcoreapp3.1 --output "%Project%/Plugins/UnrealCLR/Managed"`. Restart Unreal Engine, open the project, and build the plugin.

##### Tests
To quickly start testing, open a project with the plugin in Unreal Engine, copy all folders from the `Content` of the cloned repository to `%Project%/Content` directory, and wait until they loaded in the Content Browser. Compile the managed assemblies from `Source/Managed/Tests` folder by running the following commands:
```
dotnet publish "../Framework" --configuration Release --framework netcoreapp3.1
dotnet publish --configuration Release --framework netcoreapp3.1 --output "%Project%/Managed/Tests"
```

#### Upgrading
To upgrade, delete the plugin folder from a project, and repeat all steps from the compilation section.

Running
--------
### Plugin
The plugin is automatically loaded at startup. To make sure that the plugin is initialized open the console window from `Window -> Developer Tools -> Output Log`, find `UnrealCLR` logs using the search input.

### Tests
Open the scene with tests in the editor and enter the play mode. To switch a test, navigate to `Blueprints -> Open Level Blueprint`, select the Test Systems enumeration, and change default value on the right panel.

Overview
--------
### Design and architecture
UnrealCLR is designed to be flexible and extensible. The plugin is transparently managing core functionality of the runtime, binding and caching the engine API for managed environment. The programmer has full control over execution flow through blueprint pipelines that allow to dynamically weave native events of the engine and its objects with managed logic. There's no hidden states or obscured order of execution behind the lifecycle of scripts.

### Hot reload
The plugin is independent of the compilation routine of user assemblies. It's loading assemblies in accordance with user-driven blueprint pipelines and resolving dependencies at runtime after entering/leaving the play mode. The framework of the plugin with the engine API is automatically recognized and loaded as a dependency.

### Assemblies management
At runtime, UnrealCLR loading managed assemblies into a cached isolated context. It allows dynamically replace assemblies after unloading them from memory, therefore the programmer can work with code without restarting the editor for continuous development. The compilation pipeline is entirely up to a developer, it can be organized in any desirable way without any limitations and with full support of [NuGet](https://www.nuget.org) packages.

### Engine application program interface
The plugin and framework are evolving all the time to utilize as much power of the Unreal Engine as possible. It's crucial to have a feature-rich API. The system is created with high-performance in mind but without trading safety. The vast majority of code is written and verified by hand to prevent any unexpected behaviors at runtime and to ensure stability.

### Powerful tooling
Use your favorite .NET Core tools that can be attached to the process of the engine just as to a regular .NET application for profiling and debugging. It's very convenient and works out of the box without any external effort. Analyze performance, monitor CPU usage and memory consumption, debug execution, take full control over the code. Explore new possibilities and extend your toolset in no time.

Essentials
--------
### Exceptions
The runtime redirects all unhandled exceptions to log files and on-screen messages of the engine, however, it's highly recommended to use [try/catch](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-use-the-try-catch-block-to-catch-exceptions) blocks to override redirections with custom handlers. It's necessary to have an attached debugger to properly trace exceptions in the editor or standalone.

### Memory management
Unreal Engine, as well as .NET runtime, utilizes a garbage collector for memory management. The framework is designed with consistency in mind to prevent crashes and validate memory transparently for a programmer, no matter how objects were created and freed: with C++, C#, or blueprints.

### World coordinate system
By default, the engine uses a left-handed, z-up world coordinate system, but the framework is optionally remapping vector types to a left-handed, y-up world coordinates. Yaw, pitch, and roll from .NET numerics are always correctly translated to Unreal Engine. Axis conventions changed to: forward direction Z axis, right direction X axis, up direction Y axis. One unit remains equal to one centimeter.

To use a left-handed, z-up world coordinate system, set `UNREALCLR_Z_UP` constant in `Native/Source/UnrealCLR/Public/UnrealCLRFramework.h` to a non-zero value and recompile the plugin from `Window -> Developer Tools -> Modules`. Restart the engine after recompilation. This option affects the re-mapping of all coordinate system specific .NET numerics.

### Ecosystem compatibility
The framework replicates the classes hierarchy of the engine with full interoperability support. Any external C++ code, blueprints, and plugins are compatible and extensible with UnrealCLR by design through the engine API.

Acknowledgments
--------
Thanks to [@natemcmaster](https://github.com/natemcmaster) for a great .NET library that simplifies dynamic loading of assemblies.

Special thanks to [@Doraku](https://github.com/Doraku) for an amazing documentation generator and rapid improvement of it.
