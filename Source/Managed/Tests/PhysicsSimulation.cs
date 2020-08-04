using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class PhysicsSimulation {
		private const int maxActors = 200;
		private static Actor[] actors = new Actor[maxActors];
		private static StaticMeshComponent[] staticMeshComponents = new StaticMeshComponent[maxActors];
		private static Material material = Material.Load("/Game/Tests/BasicMaterial");
		private static float rotationSpeed = 2.5f;
		private static Random random = new Random();

		public static void OnBeginPlay() {
			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, MethodBase.GetCurrentMethod().DeclaringType + " system started!");

			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			const int halfActors = maxActors / 2;

			for (int i = 0; i < maxActors; i++) {
				actors[i] = new Actor();
				staticMeshComponents[i] = new StaticMeshComponent(actors[i], setAsRoot: true);
				staticMeshComponents[i].SetStaticMesh(StaticMesh.Cube);
				staticMeshComponents[i].SetMaterial(0, material);
				staticMeshComponents[i].CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", LinearColor.Yellow);

				if (i < halfActors)
					staticMeshComponents[i].SetRelativeLocation(new Vector3(0.0f, -400.0f, 250.0f * i));
				else
					staticMeshComponents[i].SetRelativeLocation(new Vector3(0.0f, 400.0f, 250.0f * (i - halfActors)));

				staticMeshComponents[i].UpdateToWorld(TeleportType.ResetPhysics);
				staticMeshComponents[i].SetSimulatePhysics(true);
			}

			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, "Actors are spawned! Number of actors in the world: " + World.ActorCount);
		}

		public static void OnEndPlay() => Debug.ClearOnScreenMessages();

		public static void OnTick() {
			Debug.AddOnScreenMessage(1, 1.0f, Color.SkyBlue, "Frame number: " + Engine.FrameNumber);

			Quaternion deltaRotation = Maths.CreateFromYawPitchRoll(rotationSpeed * World.DeltaTime, 0.0f, 0.0f);

			for (int i = 0; i < maxActors; i++) {
				staticMeshComponents[i].AddLocalRotation(deltaRotation);
			}
		}
	}
}