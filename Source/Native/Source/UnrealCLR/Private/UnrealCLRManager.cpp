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

#include "UnrealCLRManager.h"

void UUnrealCLRManager::ActorBeginOverlap(AActor* OverlapActor, AActor* OtherActor) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginOverlap]) {
		void* parameters[2] = {
			OverlapActor,
			OtherActor
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginOverlap], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ActorOverlapDelegate)));
	}
}

void UUnrealCLRManager::ActorEndOverlap(AActor* OverlapActor, AActor* OtherActor) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorEndOverlap]) {
		void* parameters[2] = {
			OverlapActor,
			OtherActor
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorEndOverlap], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ActorOverlapDelegate)));
	}
}

void UUnrealCLRManager::ActorHit(AActor* HitActor, AActor* OtherActor, FVector NormalImpulse, const FHitResult& Hit) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorHit]) {
		UnrealCLRFramework::Vector3 normalImpulse(NormalImpulse);
		UnrealCLRFramework::Hit hit(Hit);

		void* parameters[4] = {
			HitActor,
			OtherActor,
			&normalImpulse,
			&hit
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorHit], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ActorHitDelegate)));
	}
}

void UUnrealCLRManager::ActorBeginCursorOver(AActor* Actor) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginCursorOver]) {
		void* parameters[1] = {
			Actor
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginCursorOver], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ActorCursorDelegate)));
	}
}

void UUnrealCLRManager::ActorEndCursorOver(AActor* Actor) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorEndCursorOver]) {
		void* parameters[1] = {
			Actor
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorEndCursorOver], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ActorCursorDelegate)));
	}
}

void UUnrealCLRManager::ActorClicked(AActor* Actor, FKey Key) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorClicked]) {
		FString key = Key.ToString();

		void* parameters[2] = {
			Actor,
			TCHAR_TO_ANSI(*key)
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorClicked], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ActorKeyDelegate)));
	}
}

void UUnrealCLRManager::ActorReleased(AActor* Actor, FKey Key) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorReleased]) {
		FString key = Key.ToString();

		void* parameters[2] = {
			Actor,
			TCHAR_TO_ANSI(*key)
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorReleased], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ActorKeyDelegate)));
	}
}

void UUnrealCLRManager::ComponentBeginOverlap(UPrimitiveComponent* OverlapComponent, AActor* OtherActor, UPrimitiveComponent* OtherComponent, int32 OtherBodyIndex, bool FromSweep, const FHitResult& SweepResult) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnComponentBeginOverlap]) {
		void* parameters[2] = {
			OverlapComponent,
			OtherComponent
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentBeginOverlap], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ComponentOverlapDelegate)));
	}
}

void UUnrealCLRManager::ComponentEndOverlap(UPrimitiveComponent* OverlapComponent, AActor* OtherActor, UPrimitiveComponent* OtherComponent, int32 OtherBodyIndex) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndOverlap]) {
		void* parameters[2] = {
			OverlapComponent,
			OtherComponent
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndOverlap], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ComponentOverlapDelegate)));
	}
}

void UUnrealCLRManager::ComponentHit(UPrimitiveComponent* HitComponent, AActor* OtherActor, UPrimitiveComponent* OtherComponent, FVector NormalImpulse, const FHitResult& Hit) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnComponentHit]) {
		UnrealCLRFramework::Vector3 normalImpulse(NormalImpulse);
		UnrealCLRFramework::Hit hit(Hit);

		void* parameters[4] = {
			HitComponent,
			OtherComponent,
			&normalImpulse,
			&hit
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentHit], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ComponentHitDelegate)));
	}
}

void UUnrealCLRManager::ComponentBeginCursorOver(UPrimitiveComponent* Component) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginCursorOver]) {
		void* parameters[1] = {
			Component
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentBeginCursorOver], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ComponentCursorDelegate)));
	}
}

void UUnrealCLRManager::ComponentEndCursorOver(UPrimitiveComponent* Component) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndCursorOver]) {
		void* parameters[1] = {
			Component
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndCursorOver], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ComponentCursorDelegate)));
	}
}

void UUnrealCLRManager::ComponentClicked(UPrimitiveComponent* Component, FKey Key) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnComponentClicked]) {
		FString key = Key.ToString();

		void* parameters[2] = {
			Component,
			TCHAR_TO_ANSI(*key)
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentClicked], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ComponentKeyDelegate)));
	}
}

void UUnrealCLRManager::ComponentReleased(UPrimitiveComponent* Component, FKey Key) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnComponentReleased]) {
		FString key = Key.ToString();

		void* parameters[2] = {
			Component,
			TCHAR_TO_ANSI(*key)
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentReleased], UnrealCLR::Callback(parameters, UnrealCLR::CallbackType::ComponentKeyDelegate)));
	}
}