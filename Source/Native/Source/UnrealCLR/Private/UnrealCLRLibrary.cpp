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

void UUnrealCLRLibrary::ExecuteManagedFunction(FManagedFunction ManagedFunction, UObject* Object = nullptr) {
	if (UnrealCLR::Status == UnrealCLR::StatusType::Running && ManagedFunction.Pointer)
		UnrealCLR::ExecuteManagedFunction(ManagedFunction.Pointer, Object);
}

FManagedFunction UUnrealCLRLibrary::FindManagedFunction(FString Method, bool Optional, bool& Result) {
	FManagedFunction managedFunction;

	if (UnrealCLR::Status == UnrealCLR::StatusType::Running && !Method.IsEmpty())
		managedFunction.Pointer = UnrealCLR::FindManagedFunction(*Method, Optional);

	Result = managedFunction.Pointer != nullptr;

	return managedFunction;
}