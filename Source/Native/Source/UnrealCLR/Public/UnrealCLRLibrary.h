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