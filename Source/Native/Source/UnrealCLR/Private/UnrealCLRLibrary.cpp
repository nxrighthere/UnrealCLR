/*
 *  Unreal Engine .NET 5 integration 
 *  Copyright (c) 2021 Stanislav Denisov
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *  SOFTWARE.
 */

#include "UnrealCLRLibrary.h"

FManagedFunction::FManagedFunction() : Pointer() { }

UUnrealCLRLibrary::UUnrealCLRLibrary(const FObjectInitializer& ObjectInitializer) : Super(ObjectInitializer) { }

void UUnrealCLRLibrary::ExecuteManagedFunction(FManagedFunction ManagedFunction, UObject* Object = nullptr) {
	if (UnrealCLR::Status == UnrealCLR::StatusType::Running && ManagedFunction.Pointer)
		UnrealCLR::ManagedCommand(UnrealCLR::Command(ManagedFunction.Pointer, Object));
}

FManagedFunction UUnrealCLRLibrary::FindManagedFunction(FString Method, bool Optional, bool& Result) {
	FManagedFunction managedFunction;

	if (UnrealCLR::Status == UnrealCLR::StatusType::Running && !Method.IsEmpty())
		managedFunction.Pointer = UnrealCLR::ManagedCommand(UnrealCLR::Command(TCHAR_TO_ANSI(*Method), Optional));

	Result = managedFunction.Pointer != nullptr;

	return managedFunction;
}

UUnrealCLRCharacter::UUnrealCLRCharacter(const FObjectInitializer& ObjectInitializer) : Super(ObjectInitializer) { }

void UUnrealCLRCharacter::Landed(const FHitResult& Hit) {
	UnrealCLRFramework::Hit hit(Hit);

	void* parameters[1] = {
		&hit
	};

	UnrealCLR::ManagedCommand(UnrealCLR::Command(LandedCallback, UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::CharacterLandedDelegate)));
}