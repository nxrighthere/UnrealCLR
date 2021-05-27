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

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "UnrealCLRManager.generated.h"

UCLASS()
class UNREALCLR_API UUnrealCLRManager : public UObject {
	GENERATED_BODY()

	public:

	UFUNCTION()
	void ActorBeginOverlap(AActor* OverlapActor, AActor* OtherActor);

	UFUNCTION()
	void ActorEndOverlap(AActor* OverlapActor, AActor* OtherActor);

	UFUNCTION()
	void ActorHit(AActor* HitActor, AActor* OtherActor, FVector NormalImpulse, const FHitResult& Hit);

	UFUNCTION()
	void ActorBeginCursorOver(AActor* Actor);

	UFUNCTION()
	void ActorEndCursorOver(AActor* Actor);

	UFUNCTION()
	void ActorClicked(AActor* Actor, FKey Button);

	UFUNCTION()
	void ActorReleased(AActor* Actor, FKey Button);

	UFUNCTION()
	void ComponentBeginOverlap(UPrimitiveComponent* OverlapComponent, AActor* OtherActor, UPrimitiveComponent* OtherComponent, int32 OtherBodyIndex, bool FromSweep, const FHitResult& SweepResult);

	UFUNCTION()
	void ComponentEndOverlap(UPrimitiveComponent* OverlapComponent, AActor* OtherActor, UPrimitiveComponent* OtherComponent, int32 OtherBodyIndex);

	UFUNCTION()
	void ComponentHit(UPrimitiveComponent* HitComponent, AActor* OtherActor, UPrimitiveComponent* OtherComponent, FVector NormalImpulse, const FHitResult& Hit);

	UFUNCTION()
	void ComponentBeginCursorOver(UPrimitiveComponent* Component);

	UFUNCTION()
	void ComponentEndCursorOver(UPrimitiveComponent* Component);

	UFUNCTION()
	void ComponentClicked(UPrimitiveComponent* Component, FKey Key);

	UFUNCTION()
	void ComponentReleased(UPrimitiveComponent* Component, FKey Key);
};