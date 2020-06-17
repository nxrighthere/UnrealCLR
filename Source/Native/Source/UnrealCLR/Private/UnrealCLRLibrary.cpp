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

#include "UnrealCLRLibrary.h"

FManagedFunction::FManagedFunction() : Pointer() { }

UUnrealCLRLibrary::UUnrealCLRLibrary(const FObjectInitializer& ObjectInitializer) : Super(ObjectInitializer) { }

void UUnrealCLRLibrary::ExecuteAssemblyFunction(FManagedFunction ManagedFunction) {
	if (UnrealCLR::Status == UnrealCLR::StatusType::Running && ManagedFunction.Pointer != NULL)
		UnrealCLR::ExecuteAssemblyFunction(ManagedFunction.Pointer);
}

FManagedFunction UUnrealCLRLibrary::LoadAssemblyFunction(FString AssemblyPath, FString TypeName, FString MethodName, bool Optional) {
	FManagedFunction managedFunction;

	if (UnrealCLR::Status == UnrealCLR::StatusType::Running) {
		FString assemblyPath = UnrealCLR::UserAssembliesPath + AssemblyPath;

		managedFunction.Pointer = UnrealCLR::LoadAssemblyFunction(*assemblyPath, *TypeName, *MethodName, Optional);
	}

	return managedFunction;
}