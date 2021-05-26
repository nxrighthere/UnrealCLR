using CommandLine;
using System;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public static class Install {
	public class Options
    {
		[Option("compile-tests", Required = false, HelpText = "Compile and add tests.", Default = false)]
		public bool CompileTests { get; set; }

		[Option("path-to-project", Required = false, HelpText = "Path to the UnrealEngine project folder.")]
		public string PathToProject { get; set; }

		[Option("skip-approve", Required = false, HelpText = "Skip asking for approval to continue installing.", Default = false)]
		public bool SkipApprove { get; set; }
    }

	private static string AdjustProvidedPath(string rawPath) => $@"{rawPath}".Replace("\"", String.Empty, StringComparison.Ordinal).Replace("\'", String.Empty, StringComparison.Ordinal).TrimEnd(Path.DirectorySeparatorChar);

	private static bool ContainsUProjectFile(string projectPath) => Directory.GetFiles(projectPath, "*.uproject", SearchOption.TopDirectoryOnly).Length != 0;

	private static void InstallUnrealCLR(string projectPath, string sourcePath, bool compileTests)
    {
		string nativeSource = sourcePath + "/Source/Native";

		Console.WriteLine(Environment.NewLine + "Removing the previous plugin installation...");

		if (Directory.Exists(projectPath + "/Plugins/UnrealCLR"))
			Directory.Delete(projectPath + "/Plugins/UnrealCLR", true);

		Console.WriteLine("Copying native source code and the runtime host of the plugin...");

		foreach (string directoriesPath in Directory.GetDirectories(nativeSource, "*", SearchOption.AllDirectories))
		{
			Directory.CreateDirectory(directoriesPath.Replace(nativeSource, projectPath + "/Plugins/UnrealCLR", StringComparison.Ordinal));
		}

		foreach (string filesPath in Directory.GetFiles(nativeSource, "*.*", SearchOption.AllDirectories))
		{
			File.Copy(filesPath, filesPath.Replace(nativeSource, projectPath + "/Plugins/UnrealCLR", StringComparison.Ordinal), true);
		}

		Console.WriteLine("Launching compilation of the managed runtime...");

		var runtimeCompilation = Process.Start(new ProcessStartInfo
		{
			FileName = "dotnet",
			Arguments = $"publish \"{ sourcePath }/Source/Managed/Runtime\" --configuration Release --framework net5.0 --output \"{ projectPath }/Plugins/UnrealCLR/Managed\"",
			CreateNoWindow = false,
			UseShellExecute = false
		});

		runtimeCompilation.WaitForExit();

		if (runtimeCompilation.ExitCode != 0)
			Error("Compilation of the runtime was finished with an error (Exit code: " + runtimeCompilation.ExitCode + ")!");

		Console.WriteLine("Launching compilation of the framework...");

		var frameworkCompilation = Process.Start(new ProcessStartInfo
		{
			FileName = "dotnet",
			Arguments = $"publish \"{ sourcePath }/Source/Managed/Framework\" --configuration Release --framework net5.0 --output \"{ sourcePath }/Source/Managed/Framework/bin/Release\"",
			CreateNoWindow = false,
			UseShellExecute = false
		});

		frameworkCompilation.WaitForExit();

		if (frameworkCompilation.ExitCode != 0)
			Error("Compilation of the framework was finished with an error (Exit code: " + frameworkCompilation.ExitCode + ")!");

		if (compileTests)
		{
			string contentPath = sourcePath + "/Content";

			Console.WriteLine("Removing the previous content of the tests...");

			if (Directory.Exists(projectPath + "/Content/Tests"))
				Directory.Delete(projectPath + "/Content/Tests", true);

			Console.WriteLine("Copying the content of the tests...");

			foreach (string directoriesPath in Directory.GetDirectories(contentPath, "*", SearchOption.AllDirectories))
			{
				Directory.CreateDirectory(directoriesPath.Replace(contentPath, projectPath + "/Content", StringComparison.Ordinal));
			}

			foreach (string filesPath in Directory.GetFiles(contentPath, "*.*", SearchOption.AllDirectories))
			{
				File.Copy(filesPath, filesPath.Replace(contentPath, projectPath + "/Content", StringComparison.Ordinal), true);
			}

			Console.WriteLine("Launching compilation of the tests...");

			var testsCompilation = Process.Start(new ProcessStartInfo
			{
				FileName = "dotnet",
				Arguments = $"publish \"{ sourcePath }/Source/Managed/Tests\" --configuration Release --framework net5.0 --output \"{ projectPath }/Managed/Tests\"",
				CreateNoWindow = false,
				UseShellExecute = false
			});

			testsCompilation.WaitForExit();

			if (testsCompilation.ExitCode != 0)
				Error("Compilation of the tests was finished with an error (Exit code: " + testsCompilation.ExitCode + ")!");
		}

		Console.Write("Done!");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.Write(" Please, don't forget to recompile custom code with an updated framework!");
		Console.ResetColor();
		Environment.Exit(0);
	}

	private static void RunNonInteractive(Options opts)
    {
		Console.Title = "UnrealCLR Installation Tool";
		Console.WriteLine("Welcome to UnrealCLR installation tool!");
		string projectPath = AdjustProvidedPath(opts.PathToProject);
		string sourcePath = Directory.GetCurrentDirectory() + "/..";
		if (ContainsUProjectFile(projectPath))
		{
			Console.WriteLine($"Project file found in \"{ projectPath }\" folder!");

			bool compileTests = opts.CompileTests;

			Console.Write($"{Environment.NewLine} Installation will delete all previous files of the plugin{(compileTests ? " and content of tests" : String.Empty)}. {(opts.SkipApprove ? String.Empty : "Do you want to continue? [y/n]")}");

			if (opts.SkipApprove || Console.ReadKey(false).Key == ConsoleKey.Y) InstallUnrealCLR(projectPath, sourcePath, compileTests);
			else Console.WriteLine(Environment.NewLine + "Installation canceled");
		}
		else
		{
			Error($"Project file not found in \"{ projectPath }\" folder!");
		}
	}

	private static void RunInteractive()
    {
		Console.Title = "UnrealCLR Installation Tool";

		using StreamReader consoleReader = new StreamReader(Console.OpenStandardInput(8192), Console.InputEncoding, false, bufferSize: 1024);

		Console.SetIn(consoleReader);

		Console.WriteLine("Welcome to UnrealCLR installation tool!");
		Console.Write(Environment.NewLine + "Please, set a path to an Unreal Engine project: ");

		string projectPath = AdjustProvidedPath(Console.ReadLine());
		string sourcePath = Directory.GetCurrentDirectory() + "/..";

		if (ContainsUProjectFile(projectPath))
		{
			Console.WriteLine($"Project file found in \"{ projectPath }\" folder!");
			Console.Write(Environment.NewLine + "Do you want to compile and install the tests? [y/n] ");

			bool compileTests = false;

			if (Console.ReadKey(false).Key == ConsoleKey.Y)
				compileTests = true;

			Console.Write($"{Environment.NewLine} Installation will delete all previous files of the plugin{(compileTests ? " and content of tests" : String.Empty)}. Do you want to continue? [y/n]");

			if (Console.ReadKey(false).Key == ConsoleKey.Y) InstallUnrealCLR(projectPath, sourcePath, compileTests);
			else Console.WriteLine(Environment.NewLine + "Installation canceled");
		}
		else
		{
			Error($"Project file not found in \"{ projectPath }\" folder!");
		}
	}

	private static void Run(Options opts)
    {
		if (string.IsNullOrEmpty(opts.PathToProject)) RunInteractive();
		else RunNonInteractive(opts);
    }

	private static void Main(string[] args) {
		CommandLine.Parser.Default.ParseArguments<Options>(args)
			.WithParsed(Run)
			.WithNotParsed((IEnumerable<Error> errs) => Console.WriteLine(errs.ToString()));
	}

	private static void Error(string message) {
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(message);
		Console.ResetColor();
		Environment.Exit(-1);
	}
}
