/*
 *  Copyright (c) 2020 Stanislav Denisov (nxrighthere@gmail.com)
 *
 *  Permission to use, copy, modify, and/or distribute this software free of
 *  charge is hereby granted, provided that the above copyright notice and this
 *  permission notice appear in all copies or portions of this software with
 *  respect to the following terms and conditions:
 *
 *  1. Without specific prior written permission of the copyright holder,
 *  this software is forbidden for rebranding, sublicensing, and the exploitation
 *  of it original brand to get payments in any form.
 *
 *  2. In accordance with DMCA (Digital Millennium Copyright Act), the copyright
 *  holder reserves exclusive permission to take down at any time any publicly
 *  available copy of this software in the original, partial, or modified form.
 *
 *  3. Any modifications that were made by third-parties to this software or its
 *  portions can be used by the copyright holder for any purposes, without any
 *  limiting factors and restrictions.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
 *  WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
 *  MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
 *  ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
 *  WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION
 *  OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN
 *  CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
 */

using System.IO;
using UnrealBuildTool;

public class UnrealCLR : ModuleRules {
	public UnrealCLR(ReadOnlyTargetRules Target) : base(Target)	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicIncludePaths.AddRange(new string[] {

		});

		PrivateIncludePaths.AddRange(new string[] {

		});

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

		DynamicallyLoadedModuleNames.AddRange(new string[] {

		});

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