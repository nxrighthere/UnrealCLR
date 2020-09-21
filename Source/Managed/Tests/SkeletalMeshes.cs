using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class SkeletalMeshes : ISystem {
		public void OnBeginPlay() {
			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			SkeletalMesh prototypeMesh = SkeletalMesh.Load("/Game/Tests/Characters/Prototype");

			Actor leftPrototype = new("leftPrototype");
			SkeletalMeshComponent leftSkeletalMeshComponent = new(leftPrototype);

			leftSkeletalMeshComponent.SetSkeletalMesh(prototypeMesh);
			leftSkeletalMeshComponent.SetWorldLocation(new(-700.0f, -70.0f, -100.0f));
			leftSkeletalMeshComponent.SetWorldRotation(Maths.Euler(0.0f, 0.0f, 90.0f));
			leftSkeletalMeshComponent.SetAnimationMode(AnimationMode.Asset);
			leftSkeletalMeshComponent.PlayAnimation(AnimationSequence.Load("/Game/Tests/Characters/Animations/IdleAnimationSequence"), true);

			Assert.IsTrue(leftSkeletalMeshComponent.IsPlaying);
			Assert.IsTrue(leftSkeletalMeshComponent.GetBoneName(0) == "root");

			Bounds leftSkeletalMeshComponentBounds = default;

			leftSkeletalMeshComponent.GetBounds(leftSkeletalMeshComponent.GetTransform(), ref leftSkeletalMeshComponentBounds);

			Assert.IsFalse(leftSkeletalMeshComponentBounds == default(Bounds));

			Actor rightPrototype = new("rightPrototype");
			SkeletalMeshComponent rightSkeletalMeshComponent = new(rightPrototype);

			rightSkeletalMeshComponent.SetSkeletalMesh(prototypeMesh);
			rightSkeletalMeshComponent.SetWorldLocation(new(-700.0f, 70.0f, -100.0f));
			rightSkeletalMeshComponent.SetWorldRotation(Maths.Euler(0.0f, 0.0f, 90.0f));
			rightSkeletalMeshComponent.SetAnimationMode(AnimationMode.Asset);

			MaterialInstanceDynamic prototypeMaterial = rightSkeletalMeshComponent.CreateAndSetMaterialInstanceDynamic(0);

			prototypeMaterial.SetVectorParameterValue("AccentColor", new(0.0f, 0.5f, 1.0f));

			Assert.IsNotNull(prototypeMaterial.GetParent());

			AnimationMontage rightPrototypeAnimationMontage = AnimationMontage.Load("/Game/Tests/Characters/Animations/RunAnimationMontage");

			rightSkeletalMeshComponent.PlayAnimation(rightPrototypeAnimationMontage, true);

			AnimationInstance rightPrototypeAnimationInstance = rightSkeletalMeshComponent.GetAnimationInstance();

			Assert.IsTrue(rightPrototypeAnimationInstance.IsPlaying(rightPrototypeAnimationMontage));
			Assert.IsTrue(rightSkeletalMeshComponent.GetBoneName(0) == "root");

			Bounds rightSkeletalMeshComponentBounds = default;

			rightSkeletalMeshComponent.GetBounds(rightSkeletalMeshComponent.GetTransform(), ref rightSkeletalMeshComponentBounds);

			Assert.IsFalse(rightSkeletalMeshComponentBounds == default(Bounds));
		}

		public void OnEndPlay() => Debug.ClearOnScreenMessages();
	}
}