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

			Console.Write(Environment.NewLine + "Installation will delete all previous files of the plugin, do you want to continue? [y/n] ");

			if (Console.ReadKey(false).Key == ConsoleKey.Y) {
				string nativeSource = sourcePath + "/Source/Native";

				Console.WriteLine(Environment.NewLine + "Removing the previous plugin installation...");

				if (Directory.Exists(projectPath + "/Plugins/UnrealCLR"))
					Directory.Delete(projectPath + "/Plugins/UnrealCLR", true);

				Console.WriteLine("Copying native source code of the plugin...");

				foreach (string dirPath in Directory.GetDirectories(nativeSource, "*", SearchOption.AllDirectories)) {
					Directory.CreateDirectory(dirPath.Replace(nativeSource, projectPath + "/Plugins/UnrealCLR"));
				}

				foreach (string newPath in Directory.GetFiles(nativeSource, "*.*", SearchOption.AllDirectories)) {
					File.Copy(newPath, newPath.Replace(nativeSource, projectPath  + "/Plugins/UnrealCLR"), true);
				}

				Console.WriteLine("Launching compilation of the managed runtime...");

				Process.Start(new ProcessStartInfo {
					FileName = "dotnet",
					Arguments =  "publish " + sourcePath + "/Source/Managed/Runtime --configuration Release --framework netcoreapp3.1 --output \"" + projectPath + "/Plugins/UnrealCLR/Managed\"",
					CreateNoWindow = false,
					UseShellExecute = true
				});

				if (compileTests) {
					string contentPath = sourcePath + "/Content";

					Console.WriteLine("Copying the content of the tests...");

					foreach (string dirPath in Directory.GetDirectories(contentPath, "*", SearchOption.AllDirectories)) {
						Directory.CreateDirectory(dirPath.Replace(contentPath, projectPath + "/Content"));
					}

					foreach (string newPath in Directory.GetFiles(contentPath, "*.*", SearchOption.AllDirectories)) {
						File.Copy(newPath, newPath.Replace(contentPath, projectPath  + "/Content"), true);
					}

					Console.WriteLine("Launching compilation of the framework...");

					var frameworkCompilation = Process.Start(new ProcessStartInfo {
						FileName = "dotnet",
						Arguments =  "publish " + sourcePath + "/Source/Managed/Framework --configuration Release --framework netcoreapp3.1",
						CreateNoWindow = false,
						UseShellExecute = true
					});

					frameworkCompilation.WaitForExit();

					Console.WriteLine("Launching compilation of the tests...");

					Process.Start(new ProcessStartInfo {
						FileName = "dotnet",
						Arguments =  "publish " + sourcePath + "/Source/Managed/Tests --configuration Release --framework netcoreapp3.1 --output \"" + projectPath + "/Managed/Tests\"",
						CreateNoWindow = false,
						UseShellExecute = true
					});
				}
			} else {
				Console.WriteLine(Environment.NewLine + "Installation canceled");
			}
		} else {
			Console.WriteLine("Project file not found in \"" + projectPath + "\" folder!");
		}
	}
}