using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class InstancedStaticMeshes {
		private const int maxCubes = 200;
		private static Actor actor = new Actor("InstancedCubes");
		private static SceneComponent sceneComponent = new SceneComponent(actor);
		private static Transform[] transforms = new Transform[maxCubes];
		private static InstancedStaticMeshComponent instancedStaticMeshComponent = new InstancedStaticMeshComponent(actor, setAsRoot: true);
		private static Material material = Material.Load("/Game/Tests/BasicMaterial");
		private static float rotationSpeed = 2.5f;

		public static void OnBeginPlay() {
			Debug.Log(LogLevel.Display, "Hello, Unreal Engine!");
			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, MethodBase.GetCurrentMethod().DeclaringType + " system started!");

			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			instancedStaticMeshComponent.SetStaticMesh(StaticMesh.Cube);
			instancedStaticMeshComponent.SetMaterial(0, material);
			instancedStaticMeshComponent.CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", LinearColor.White);

			for (int i = 0; i < maxCubes; i++) {
				sceneComponent.SetRelativeLocation(new Vector3(150.0f * i, 50.0f * i, 100.0f * i));
				sceneComponent.SetRelativeRotation(Maths.CreateFromYawPitchRoll(5.0f * i, 0.0f, 0.0f));
				sceneComponent.AddLocalOffset(new Vector3(15.0f * i, 20.0f * i, 25.0f * i));
				sceneComponent.GetTransform(ref transforms[i]);
				instancedStaticMeshComponent.AddInstance(transforms[i]);
			}

			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, "Instances are created! Number of instances: " + instancedStaticMeshComponent.InstanceCount);
		}

		public static void OnEndPlay() {
			Debug.Log(LogLevel.Display, "See you soon, Unreal Engine!");
			Debug.ClearOnScreenMessages();
		}

		public static void OnTick() {
			Debug.AddOnScreenMessage(1, 1.0f, Color.SkyBlue, "Frame number: " + Engine.FrameNumber);

			float deltaTime = World.DeltaTime;
			Quaternion deltaRotation = Maths.CreateFromYawPitchRoll(rotationSpeed * deltaTime, rotationSpeed * deltaTime, rotationSpeed * deltaTime);

			for (int i = 0; i < maxCubes; i++) {
				sceneComponent.SetWorldTransform(transforms[i]);
				sceneComponent.AddLocalRotation(deltaRotation);
				sceneComponent.GetTransform(ref transforms[i]);

				instancedStaticMeshComponent.UpdateInstanceTransform(i, transforms[i], markRenderStateDirty: i == maxCubes - 1);
			}
		}
	}
}