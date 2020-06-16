/*
 *  Copyright (c) 2020 Stanislav Denisov (nxrighthere@gmail.com)
 *
 *  Permission to use, copy, modify, and/or distribute this software free of
 *  charge is hereby granted, provided that the above copyright notice and this
 *  permission notice appear in all copies or portions of this software with
 *  respect to the following additional terms and conditions that apply to the
 *  software which distributed in a non-compiled and/or non-object files:
 *
 *  1. Without specific prior written permission of the copyright holder,
 *  this software is forbidden for rebranding, sublicensing, and the exploitation
 *  of its original brand to get payments in any form.
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

#pragma once

#include "Kismet/BlueprintFunctionLibrary.h"
#include "UnrealCLRLibrary.generated.h"

USTRUCT(BlueprintType)
struct UNREALCLR_API FManagedFunction {
	GENERATED_BODY()

	public:

	FManagedFunction();

	void* Pointer;
};

UCLASS()
class UUnrealCLRLibrary : public UBlueprintFunctionLibrary {
	GENERATED_UCLASS_BODY()

	UFUNCTION(BlueprintCallable, Category = ".NET", meta = (ToolTip = "Executes the managed function"))
	static void ExecuteAssemblyFunction(FManagedFunction ManagedFunction);

	UFUNCTION(BlueprintCallable, Category = ".NET", meta = (ToolTip = "Loads the managed function from assembly, optional parameter suppresses errors if the function was not found"))
	static FManagedFunction LoadAssemblyFunction(FString AssemblyPath, FString TypeName, FString MethodName, bool Optional);
};