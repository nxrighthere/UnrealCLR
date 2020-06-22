using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class SkeletalMeshes {
		public static void OnBeginPlay() {
			Debug.Log(LogLevel.Display, "Hello, Unreal Engine!");
			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, MethodBase.GetCurrentMethod().DeclaringType + " system started!");

			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			SkeletalMesh prototypeMesh = SkeletalMesh.Load("/Game/Tests/Characters/Prototype");

			Actor prototypeLeft = new Actor("prototypeLeft");
			SkeletalMeshComponent prototypeLeftMeshComponent = new SkeletalMeshComponent(prototypeLeft);

			prototypeLeftMeshComponent.SetSkeletalMesh(prototypeMesh);
			prototypeLeftMeshComponent.SetWorldLocation(new Vector3(-700.0f, -70.0f, -100.0f));
			prototypeLeftMeshComponent.SetWorldRotation(Maths.Euler(0.0f, 0.0f, 90.0f));
			prototypeLeftMeshComponent.SetAnimationMode(AnimationMode.Asset);
			prototypeLeftMeshComponent.PlayAnimation(AnimationSequence.Load("/Game/Tests/Characters/Animations/IdleAnimationSequence"), true);

			Assert.IsTrue(prototypeLeftMeshComponent.IsPlaying);

			Actor prototypeRight = new Actor("prototypeRight");
			SkeletalMeshComponent prototypeRightSkeletalMeshComponent = new SkeletalMeshComponent(prototypeRight);

			prototypeRightSkeletalMeshComponent.SetSkeletalMesh(prototypeMesh);
			prototypeRightSkeletalMeshComponent.SetWorldLocation(new Vector3(-700.0f, 70.0f, -100.0f));
			prototypeRightSkeletalMeshComponent.SetWorldRotation(Maths.Euler(0.0f, 0.0f, 90.0f));
			prototypeRightSkeletalMeshComponent.SetAnimationMode(AnimationMode.Asset);
			prototypeRightSkeletalMeshComponent.CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("AccentColor", new LinearColor(0.0f, 0.5f, 1.0f));

			AnimationMontage prototypeRightAnimationMontage = AnimationMontage.Load("/Game/Tests/Characters/Animations/RunAnimationMontage");

			prototypeRightSkeletalMeshComponent.PlayAnimation(prototypeRightAnimationMontage, true);

			AnimationInstance prototypeRightAnimationInstance = prototypeRightSkeletalMeshComponent.GetAnimationInstance();

			Assert.IsTrue(prototypeRightAnimationInstance.MontageIsPlaying(prototypeRightAnimationMontage));
		}

		public static void OnEndPlay() {
			Debug.Log(LogLevel.Display, "See you soon, Unreal Engine!");
			Debug.ClearOnScreenMessages();
		}
	}
}