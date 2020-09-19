using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class PhysicsSimulation : ISystem {
		private Actor[] actors;
		private StaticMeshComponent[] staticMeshComponents;
		private Material material;
		private float rotationSpeed;
		private Random random;
		private const int maxActors = 200;

		public PhysicsSimulation() {
			actors = new Actor[maxActors];
			staticMeshComponents = new StaticMeshComponent[maxActors];
			material = Material.Load("/Game/Tests/BasicMaterial");
			rotationSpeed = 2.5f;
			random = new();
		}

		public void OnBeginPlay() {
			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, MethodBase.GetCurrentMethod().DeclaringType + " system started!");

			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			const int halfActors = maxActors / 2;

			for (int i = 0; i < maxActors; i++) {
				actors[i] = new();
				staticMeshComponents[i] = new(actors[i], setAsRoot: true);
				staticMeshComponents[i].SetStaticMesh(StaticMesh.Cube);
				staticMeshComponents[i].SetMaterial(0, material);
				staticMeshComponents[i].CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", LinearColor.Yellow);

				if (i < halfActors)
					staticMeshComponents[i].SetRelativeLocation(new(0.0f, -400.0f, 250.0f * i));
				else
					staticMeshComponents[i].SetRelativeLocation(new(0.0f, 400.0f, 250.0f * (i - halfActors)));

				staticMeshComponents[i].UpdateToWorld(TeleportType.ResetPhysics);
				staticMeshComponents[i].SetSimulatePhysics(true);
			}

			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, "Actors are spawned! Number of actors in the world: " + World.ActorCount);
		}

		public void OnTick(float deltaTime) {
			Debug.AddOnScreenMessage(1, 1.0f, Color.SkyBlue, "Frame number: " + Engine.FrameNumber);

			Quaternion deltaRotation = Maths.CreateFromYawPitchRoll(rotationSpeed * deltaTime, 0.0f, 0.0f);

			for (int i = 0; i < maxActors; i++) {
				staticMeshComponents[i].AddLocalRotation(deltaRotation);
			}
		}

		public void OnEndPlay() => Debug.ClearOnScreenMessages();
	}
}