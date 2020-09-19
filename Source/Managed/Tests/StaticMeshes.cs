using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class StaticMeshes : ISystem {
		private Actor[] actors;
		private StaticMeshComponent[] staticMeshComponents;
		private Material material;
		private float rotationSpeed;
		private Random random;
		private const int maxActors = 200;

		public StaticMeshes() {
			actors = new Actor[maxActors];
			staticMeshComponents = new StaticMeshComponent[maxActors];
			material = Material.Load("/Game/Tests/BasicMaterial");
			rotationSpeed = 2.5f;
			random = new();
		}

		public void OnBeginPlay() {
			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			for (int i = 0; i < maxActors; i++) {
				actors[i] = new();
				staticMeshComponents[i] = new(actors[i], setAsRoot: true);
				staticMeshComponents[i].AddLocalOffset(new(15.0f * i, 20.0f * i, 25.0f * i));
				staticMeshComponents[i].SetStaticMesh(StaticMesh.Cube);
				staticMeshComponents[i].SetMaterial(0, material);
				staticMeshComponents[i].CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", new((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()));
				staticMeshComponents[i].SetRelativeLocation(new(150.0f * i, 50.0f * i, 100.0f * i));
				staticMeshComponents[i].SetRelativeRotation(Maths.CreateFromYawPitchRoll(5.0f * i, 0.0f, 0.0f));
			}

			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, "Actors are spawned! Number of actors in the world: " + World.ActorCount);
		}

		public void OnTick(float deltaTime) {
			Debug.AddOnScreenMessage(1, 1.0f, Color.SkyBlue, "Frame number: " + Engine.FrameNumber);

			Quaternion deltaRotation = Maths.CreateFromYawPitchRoll(rotationSpeed * deltaTime, rotationSpeed * deltaTime, rotationSpeed * deltaTime);

			for (int i = 0; i < maxActors; i++) {
				staticMeshComponents[i].AddLocalRotation(deltaRotation);
			}
		}

		public void OnEndPlay() => Debug.ClearOnScreenMessages();
	}
}