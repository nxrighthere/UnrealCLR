using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class InstancedStaticMeshes : ISystem {
		private Actor actor;
		private SceneComponent sceneComponent;
		private Transform[] transforms;
		private InstancedStaticMeshComponent instancedStaticMeshComponent;
		private Material material;
		private float rotationSpeed;
		private const int maxCubes = 200;

		public InstancedStaticMeshes() {
			actor = new("InstancedCubes");
			sceneComponent = new(actor);
			transforms = new Transform[maxCubes];
			instancedStaticMeshComponent = new(actor, setAsRoot: true);
			material = Material.Load("/Game/Tests/BasicMaterial");
			rotationSpeed = 2.5f;
		}

		public void OnBeginPlay() {
			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			instancedStaticMeshComponent.SetStaticMesh(StaticMesh.Cube);
			instancedStaticMeshComponent.SetMaterial(0, material);
			instancedStaticMeshComponent.CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", LinearColor.White);

			for (int i = 0; i < maxCubes; i++) {
				sceneComponent.SetRelativeLocation(new(150.0f * i, 50.0f * i, 100.0f * i));
				sceneComponent.SetRelativeRotation(Maths.CreateFromYawPitchRoll(5.0f * i, 0.0f, 0.0f));
				sceneComponent.AddLocalOffset(new(15.0f * i, 20.0f * i, 25.0f * i));
				sceneComponent.GetTransform(ref transforms[i]);
			}

			instancedStaticMeshComponent.AddInstances(transforms);

			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, "Instances are created! Number of instances: " + instancedStaticMeshComponent.InstanceCount);
		}

		public void OnTick(float deltaTime) {
			Debug.AddOnScreenMessage(1, 1.0f, Color.SkyBlue, "Frame number: " + Engine.FrameNumber);

			Quaternion deltaRotation = Maths.CreateFromYawPitchRoll(rotationSpeed * deltaTime, rotationSpeed * deltaTime, rotationSpeed * deltaTime);

			for (int i = 0; i < maxCubes; i++) {
				sceneComponent.SetWorldTransform(transforms[i]);
				sceneComponent.AddLocalRotation(deltaRotation);
				sceneComponent.GetTransform(ref transforms[i]);
			}

			instancedStaticMeshComponent.BatchUpdateInstanceTransforms(0, transforms, markRenderStateDirty: true);
		}

		public void OnEndPlay() => Debug.ClearOnScreenMessages();
	}
}