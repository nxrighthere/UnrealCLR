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

			Actor kachujin = new Actor("Kachujin");
			SkeletalMeshComponent kachujinSkeletalMeshComponent = new SkeletalMeshComponent(kachujin);
			SkeletalMesh kachujinSkeletalMesh = SkeletalMesh.Load("/Game/Tests/Characters/Kachujin/SkeletalMesh");

			kachujinSkeletalMeshComponent.SetSkeletalMesh(kachujinSkeletalMesh);
			kachujinSkeletalMeshComponent.SetWorldLocation(new Vector3(-700.0f, -70.0f, -100.0f));
			kachujinSkeletalMeshComponent.SetWorldRotation(Maths.Euler(0.0f, 0.0f, 90.0f));
			kachujinSkeletalMeshComponent.SetAnimationMode(AnimationMode.Asset);
			kachujinSkeletalMeshComponent.PlayAnimation(AnimationSequence.Load("/Game/Tests/Characters/Kachujin/AnimationSequenceSwordSwing"), true);

			Actor ganfault = new Actor("Ganfault");
			SkeletalMeshComponent ganfaultSkeletalMeshComponent = new SkeletalMeshComponent(ganfault);
			SkeletalMesh ganfaultSkeletalMesh = SkeletalMesh.Load("/Game/Tests/Characters/Ganfault/SkeletalMesh");

			ganfaultSkeletalMeshComponent.SetSkeletalMesh(ganfaultSkeletalMesh);
			ganfaultSkeletalMeshComponent.SetWorldLocation(new Vector3(-700.0f, 70.0f, -100.0f));
			ganfaultSkeletalMeshComponent.SetWorldRotation(Maths.Euler(0.0f, 0.0f, 90.0f));
			ganfaultSkeletalMeshComponent.SetAnimationMode(AnimationMode.Asset);
			ganfaultSkeletalMeshComponent.PlayAnimation(AnimationMontage.Load("/Game/Tests/Characters/Ganfault/AnimationMontage"), true);
		}

		public static void OnEndPlay() {
			Debug.Log(LogLevel.Display, "See you soon, Unreal Engine!");
			Debug.ClearOnScreenMessages();
		}
	}
}