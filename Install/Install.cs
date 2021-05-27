using System;
using System.Diagnostics;
using System.IO;

public static class Install {
	private static void Main(string[] arguments) {
		Console.Title = "UnrealCLR Installation Tool";

		using StreamReader consoleReader = new(Console.OpenStandardInput(8192), Console.InputEncoding, false, bufferSize: 1024);

		Console.SetIn(consoleReader);

		string projectPath = null;
		bool? compileTestsOption = null;
		bool? overwriteFilesOption = null;

		for (int i = 0; i < arguments.Length; i++) {
			if (arguments[i].Contains("--project-path", StringComparison.Ordinal))
				projectPath = arguments[i + 1];

			if (arguments[i].Contains("--compile-tests", StringComparison.Ordinal))
				compileTestsOption = bool.Parse(arguments[i + 1]);

			if (arguments[i].Contains("--overwrite-files", StringComparison.Ordinal))
				overwriteFilesOption = true;
		}

		Console.WriteLine("Welcome to the UnrealCLR installation tool!");

		if (String.IsNullOrEmpty(projectPath)) {
			Console.Write(Environment.NewLine + "Please, set a path to an Unreal Engine project: ");

			projectPath = @"" + Console.ReadLine();
		}

		projectPath = projectPath.Replace("\"", String.Empty, StringComparison.Ordinal).Replace("\'", String.Empty, StringComparison.Ordinal).TrimEnd(Path.DirectorySeparatorChar);

		string sourcePath = Directory.GetCurrentDirectory() + "/..";

		if (Directory.GetFiles(projectPath, "*.uproject", SearchOption.TopDirectoryOnly).Length != 0) {
			Console.WriteLine($"Project file found in \"{ projectPath }\" folder!");

			bool compileTests = false;

			if (compileTestsOption != null) {
				compileTests = compileTestsOption.GetValueOrDefault();
			} else {
				Console.Write(Environment.NewLine + "Do you want to compile and install tests? [y/n] ");

				if (Console.ReadKey(false).Key == ConsoleKey.Y)
					compileTests = true;
			}

			bool overwriteFiles = false;

			if (overwriteFilesOption != null) {
				overwriteFiles = overwriteFilesOption.GetValueOrDefault();
			} else {
				Console.Write(Environment.NewLine + "Installation will delete all previous files of the plugin" + (compileTests ? " and content of tests" : String.Empty) + ". Do you want to continue? [y/n] ");

				if (Console.ReadKey(false).Key == ConsoleKey.Y)
					overwriteFiles = true;
			}

			if (overwriteFiles) {
				string nativeSource = sourcePath + "/Source/Native";

				Console.WriteLine(Environment.NewLine + "Removing the previous plugin installation...");

				if (Directory.Exists(projectPath + "/Plugins/UnrealCLR"))
					Directory.Delete(projectPath + "/Plugins/UnrealCLR", true);

				Console.WriteLine("Copying native source code and the runtime host of the plugin...");

				foreach (string directoriesPath in Directory.GetDirectories(nativeSource, "*", SearchOption.AllDirectories)) {
					Directory.CreateDirectory(directoriesPath.Replace(nativeSource, projectPath + "/Plugins/UnrealCLR", StringComparison.Ordinal));
				}

				foreach (string filesPath in Directory.GetFiles(nativeSource, "*.*", SearchOption.AllDirectories)) {
					File.Copy(filesPath, filesPath.Replace(nativeSource, projectPath  + "/Plugins/UnrealCLR", StringComparison.Ordinal), true);
				}

				Console.WriteLine("Launching compilation of the managed runtime...");

				var runtimeCompilation = Process.Start(new ProcessStartInfo {
					FileName = "dotnet",
					Arguments =  $"publish \"{ sourcePath }/Source/Managed/Runtime\" --configuration Release --framework net5.0 --output \"{ projectPath }/Plugins/UnrealCLR/Managed\"",
					CreateNoWindow = false,
					UseShellExecute = false
				});

				runtimeCompilation.WaitForExit();

				if (runtimeCompilation.ExitCode != 0)
					Error("Compilation of the runtime was finished with an error (Exit code: " + runtimeCompilation.ExitCode + ")!");

				Console.WriteLine("Launching compilation of the framework...");

				var frameworkCompilation = Process.Start(new ProcessStartInfo {
					FileName = "dotnet",
					Arguments =  $"publish \"{ sourcePath }/Source/Managed/Framework\" --configuration Release --framework net5.0 --output \"{ sourcePath }/Source/Managed/Framework/bin/Release\"",
					CreateNoWindow = false,
					UseShellExecute = false
				});

				frameworkCompilation.WaitForExit();

				if (frameworkCompilation.ExitCode != 0)
					Error("Compilation of the framework was finished with an error (Exit code: " + frameworkCompilation.ExitCode + ")!");

				if (compileTests) {
					string contentPath = sourcePath + "/Content";

					Console.WriteLine("Removing the previous content of the tests...");

					if (Directory.Exists(projectPath + "/Content/Tests"))
						Directory.Delete(projectPath + "/Content/Tests", true);

					Console.WriteLine("Copying the content of the tests...");

					foreach (string directoriesPath in Directory.GetDirectories(contentPath, "*", SearchOption.AllDirectories)) {
						Directory.CreateDirectory(directoriesPath.Replace(contentPath, projectPath + "/Content", StringComparison.Ordinal));
					}

					foreach (string filesPath in Directory.GetFiles(contentPath, "*.*", SearchOption.AllDirectories)) {
						File.Copy(filesPath, filesPath.Replace(contentPath, projectPath  + "/Content", StringComparison.Ordinal), true);
					}

					Console.WriteLine("Launching compilation of the tests...");

					var testsCompilation = Process.Start(new ProcessStartInfo {
						FileName = "dotnet",
						Arguments =  $"publish \"{ sourcePath }/Source/Managed/Tests\" --configuration Release --framework net5.0 --output \"{ projectPath }/Managed/Tests\"",
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
			} else {
				Console.WriteLine(Environment.NewLine + "Installation canceled");
			}
		} else {
			Error($"Project file not found in \"{ projectPath }\" folder!");
		}
	}

	private static void Error(string message) {
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(message);
		Console.ResetColor();
		Environment.Exit(-1);
	}
}
