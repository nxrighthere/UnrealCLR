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

void UUnrealCLRManager::ActorBeginOverlap(AActor* OverlapActor, AActor* OtherActor) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginOverlap]) {
		void* parameters[2] = {
			OverlapActor,
			OtherActor
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginOverlap], UnrealCLR::Object(parameters, UnrealCLR::ObjectType::ActorOverlapDelegate)));
	}
}

void UUnrealCLRManager::ActorEndOverlap(AActor* OverlapActor, AActor* OtherActor) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorEndOverlap]) {
		void* parameters[2] = {
			OverlapActor,
			OtherActor
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorEndOverlap], UnrealCLR::Object(parameters, UnrealCLR::ObjectType::ActorOverlapDelegate)));
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

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorHit], UnrealCLR::Object(parameters, UnrealCLR::ObjectType::ActorHitDelegate)));
	}
}

void UUnrealCLRManager::ActorBeginCursorOver(AActor* Actor) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginCursorOver]) {
		void* parameters[1] = {
			Actor
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginCursorOver], UnrealCLR::Object(parameters, UnrealCLR::ObjectType::ActorCursorDelegate)));
	}
}

void UUnrealCLRManager::ActorEndCursorOver(AActor* Actor) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorEndCursorOver]) {
		void* parameters[1] = {
			Actor
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnActorEndCursorOver], UnrealCLR::Object(parameters, UnrealCLR::ObjectType::ActorCursorDelegate)));
	}
}

void UUnrealCLRManager::ComponentBeginOverlap(UPrimitiveComponent* OverlapComponent, AActor* OtherActor, UPrimitiveComponent* OtherComponent, int32 OtherBodyIndex, bool FromSweep, const FHitResult& SweepResult) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnComponentBeginOverlap]) {
		void* parameters[2] = {
			OverlapComponent,
			OtherComponent
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentBeginOverlap], UnrealCLR::Object(parameters, UnrealCLR::ObjectType::ComponentOverlapDelegate)));
	}
}

void UUnrealCLRManager::ComponentEndOverlap(UPrimitiveComponent* OverlapComponent, AActor* OtherActor, UPrimitiveComponent* OtherComponent, int32 OtherBodyIndex) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndOverlap]) {
		void* parameters[2] = {
			OverlapComponent,
			OtherComponent
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndOverlap], UnrealCLR::Object(parameters, UnrealCLR::ObjectType::ComponentOverlapDelegate)));
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

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentHit], UnrealCLR::Object(parameters, UnrealCLR::ObjectType::ComponentHitDelegate)));
	}
}

void UUnrealCLRManager::ComponentBeginCursorOver(UPrimitiveComponent* Component) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnActorBeginCursorOver]) {
		void* parameters[1] = {
			Component
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentBeginCursorOver], UnrealCLR::Object(parameters, UnrealCLR::ObjectType::ComponentCursorDelegate)));
	}
}

void UUnrealCLRManager::ComponentEndCursorOver(UPrimitiveComponent* Component) {
	if (UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndCursorOver]) {
		void* parameters[1] = {
			Component
		};

		UnrealCLR::ManagedCommand(UnrealCLR::Command(UnrealCLR::Shared::Events[UnrealCLR::OnComponentEndCursorOver], UnrealCLR::Object(parameters, UnrealCLR::ObjectType::ComponentCursorDelegate)));
	}
}