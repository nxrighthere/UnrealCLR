using System;
using System.Diagnostics;
using System.IO;

public static class Install {
	private static void Main() {
		Console.Title = "UnrealCLR Installation Tool";
		Console.SetIn(new StreamReader(Console.OpenStandardInput(8192), Console.InputEncoding, false, bufferSize: 1024));

		Console.WriteLine("Welcome to UnrealCLR installation tool!");
		Console.Write(Environment.NewLine + "Please, set a path to an Unreal Engine project: ");

		string projectPath = @"" + Console.ReadLine().Replace("\"", String.Empty).Replace("\'", String.Empty).TrimEnd(Path.DirectorySeparatorChar);
		string sourcePath = Directory.GetCurrentDirectory() + "/..";

		if (Directory.GetFiles(projectPath, "*.uproject", SearchOption.TopDirectoryOnly).Length != 0) {
			Console.WriteLine("Project file found in \"" + projectPath + "\" folder!");
			Console.Write(Environment.NewLine + "Do you want to compile and install the tests? [y/n] ");

			bool compileTests = false;

			if (Console.ReadKey(false).Key == ConsoleKey.Y)
				compileTests = true;

			Console.Write(Environment.NewLine + "Installation will delete all previous files of the plugin" + (compileTests ? " and content of tests" : String.Empty) + ". Do you want to continue? [y/n] ");

			if (Console.ReadKey(false).Key == ConsoleKey.Y) {
				string nativeSource = sourcePath + "/Source/Native";

				Console.WriteLine(Environment.NewLine + "Removing the previous plugin installation...");

				if (Directory.Exists(projectPath + "/Plugins/UnrealCLR"))
					Directory.Delete(projectPath + "/Plugins/UnrealCLR", true);

				Console.WriteLine("Copying native source code and the runtime host of the plugin...");

				foreach (string directoriesPath in Directory.GetDirectories(nativeSource, "*", SearchOption.AllDirectories)) {
					Directory.CreateDirectory(directoriesPath.Replace(nativeSource, projectPath + "/Plugins/UnrealCLR"));
				}

				foreach (string filesPath in Directory.GetFiles(nativeSource, "*.*", SearchOption.AllDirectories)) {
					File.Copy(filesPath, filesPath.Replace(nativeSource, projectPath  + "/Plugins/UnrealCLR"), true);
				}

				Console.WriteLine("Launching compilation of the managed runtime...");

				var runtimeCompilation = Process.Start(new ProcessStartInfo {
					FileName = "dotnet",
					Arguments =  "publish " + sourcePath + "/Source/Managed/Runtime --configuration Release --framework net5.0 --output \"" + projectPath + "/Plugins/UnrealCLR/Managed\"",
					CreateNoWindow = false,
					UseShellExecute = true
				});

				runtimeCompilation.WaitForExit();

				if (runtimeCompilation.ExitCode != 0)
					Error("Compilation of the runtime was finished with an error (Exit code: " + runtimeCompilation.ExitCode + ")!");

				Console.WriteLine("Launching compilation of the framework...");

				var frameworkCompilation = Process.Start(new ProcessStartInfo {
					FileName = "dotnet",
					Arguments =  "publish " + sourcePath + "/Source/Managed/Framework --configuration Release --framework net5.0",
					CreateNoWindow = false,
					UseShellExecute = true
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
						Directory.CreateDirectory(directoriesPath.Replace(contentPath, projectPath + "/Content"));
					}

					foreach (string filesPath in Directory.GetFiles(contentPath, "*.*", SearchOption.AllDirectories)) {
						File.Copy(filesPath, filesPath.Replace(contentPath, projectPath  + "/Content"), true);
					}

					Console.WriteLine("Launching compilation of the tests...");

					var testsCompilation = Process.Start(new ProcessStartInfo {
						FileName = "dotnet",
						Arguments =  "publish " + sourcePath + "/Source/Managed/Tests --configuration Release --framework net5.0 --output \"" + projectPath + "/Managed/Tests\"",
						CreateNoWindow = false,
						UseShellExecute = true
					});

					testsCompilation.WaitForExit();

					if (testsCompilation.ExitCode != 0)
						Error("Compilation of the tests was finished with an error (Exit code: " + testsCompilation.ExitCode + ")!");
				}

				Console.WriteLine("Done! Please, don't forget to recompile custom code with an updated framework!");
			} else {
				Console.WriteLine(Environment.NewLine + "Installation canceled");
			}
		} else {
			Error("Project file not found in \"" + projectPath + "\" folder!");
		}
	}

	private static void Error(string message) {
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(message);
		Console.ResetColor();
		Environment.Exit(-1);
	}
}
