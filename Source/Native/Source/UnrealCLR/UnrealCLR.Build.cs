/*
 * Copyright (c) 2020 Stanislav Denisov (nxrighthere@gmail.com)
 *
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the GNU Lesser General Public License
 * (LGPL) version 3 with a static linking exception which accompanies this
 * distribution.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 */

using System;
using System.IO;
using UnrealBuildTool;

public class UnrealCLR : ModuleRules {
	public UnrealCLR(ReadOnlyTargetRules Target) : base(Target)	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicIncludePaths.AddRange(new string[] { });

		PrivateIncludePaths.AddRange(new string[] { });

		PublicDependencyModuleNames.AddRange(new string[] {
			"Core"
		});

		PrivateDependencyModuleNames.AddRange(new string[] {
			"AIModule",
			"CoreUObject",
			"Engine",
			"HeadMountedDisplay",
			"InputCore",
			"Slate",
			"SlateCore"
		});

		DynamicallyLoadedModuleNames.AddRange(new string[] { });

		if (Target.bBuildEditor) {
			PrivateDependencyModuleNames.AddRange(new string[] {
				"UnrealEd"
			});
		} else {
			string runtimePath = null;

			if (Target.Platform == UnrealTargetPlatform.Win64)
				runtimePath = Path.Combine(ModuleDirectory, "../../Runtime/Win64");
			else if (Target.Platform == UnrealTargetPlatform.Linux)
				runtimePath = Path.Combine(ModuleDirectory, "../../Runtime/Linux");
			else if (Target.Platform == UnrealTargetPlatform.Mac)
				runtimePath = Path.Combine(ModuleDirectory, "../../Runtime/Mac");
			else
				throw new Exception("Unknown platform");

			string[] files = Directory.GetFiles(runtimePath, "*.*", SearchOption.AllDirectories);

			foreach (string file in files) {
				RuntimeDependencies.Add(file);
			}

			files = Directory.GetFiles(Path.Combine(ModuleDirectory, "../../Managed"), "*.*", SearchOption.AllDirectories);

			foreach (string file in files) {
				RuntimeDependencies.Add(file);
			}

			string userAssemblies = Path.Combine(PluginDirectory , "../../Managed");

			if (Directory.Exists(userAssemblies)) {
				files = Directory.GetFiles(userAssemblies, "*.*", SearchOption.AllDirectories);

				foreach (string file in files) {
					RuntimeDependencies.Add(file);
				}
			}
		}
	}
}