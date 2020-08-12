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

#include "UnrealCLRManager.h"

void UUnrealCLRManager::ActorBeginOverlap(AActor* OverlappedActor, AActor* OtherActor) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginOverlap]) {
		void* actors[2] = {
			OverlappedActor,
			OtherActor
		};

		UnrealCLR::ExecuteManagedFunction(UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginOverlap], UnrealCLR::Argument(actors, true));
	}
}

void UUnrealCLRManager::ActorEndOverlap(AActor* OverlappedActor, AActor* OtherActor) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorEndOverlap]) {
		void* actors[2] = {
			OverlappedActor,
			OtherActor
		};

		UnrealCLR::ExecuteManagedFunction(UnrealCLR::Shared::Events[UnrealCLR::OnActorEndOverlap], UnrealCLR::Argument(actors, true));
	}
}

void UUnrealCLRManager::ComponentBeginOverlap(UPrimitiveComponent* OverlappedComponent, AActor* OtherActor, UPrimitiveComponent* OtherComponent, int32 OtherBodyIndex, bool FromSweep, const FHitResult& SweepResult) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnComponentBeginOverlap]) {
		void* primitiveComponents[2] = {
			OverlappedComponent,
			OtherComponent
		};

		UnrealCLR::ExecuteManagedFunction(UnrealCLR::Shared::Events[UnrealCLR::OnComponentBeginOverlap], UnrealCLR::Argument(primitiveComponents, true));
	}
}

void UUnrealCLRManager::ComponentEndOverlap(UPrimitiveComponent* OverlappedComponent, AActor* OtherActor, UPrimitiveComponent* OtherComponent, int32 OtherBodyIndex) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndOverlap]) {
		void* primitiveComponents[2] = {
			OverlappedComponent,
			OtherComponent
		};

		UnrealCLR::ExecuteManagedFunction(UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndOverlap], UnrealCLR::Argument(primitiveComponents, true));
	}
}