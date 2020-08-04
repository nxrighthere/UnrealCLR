using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class ObjectOrientedDesign {
		private const int maxEntities = 10;
		private static Entity[] entities = new Entity[maxEntities];
		private static Material material = Material.Load("/Game/Tests/BasicMaterial");
		private static Random random = new Random();

		private class Entity : Actor {
			private StateComponent component = null;

			public StateComponent StateComponent => component;

			public Entity(string name = null) : base(name) { }

			public void CreateMesh(float rotationSpeed, string name = null, bool setAsRoot = false) {
				component = new StateComponent(this, rotationSpeed, name, setAsRoot);
				component.SetStaticMesh(StaticMesh.Cube);
				component.SetMaterial(0, material);
			}
		}

		private class StateComponent : StaticMeshComponent {
			public float RotationSpeed { get; set; }

			public StateComponent(Entity entity, float rotationSpeed, string name = null, bool setAsRoot = false) : base(entity, name, setAsRoot) => RotationSpeed = rotationSpeed;
		}

		public static void OnBeginPlay() {
			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, MethodBase.GetCurrentMethod().DeclaringType + " system started!");

			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			for (int i = 0; i < maxEntities; i++) {
				string entityName = "Entity" + (i > 0 ? i.ToString() : String.Empty);

				entities[i] = new Entity(entityName);
				entities[i].CreateMesh(1.0f, "StateComponent", true);
				entities[i].StateComponent.SetRelativeRotation(Maths.CreateFromYawPitchRoll(5.0f * i, 0.0f, 0.0f));
				entities[i].StateComponent.CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", new LinearColor((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()));
				entities[i].StateComponent.SetRelativeLocation(new Vector3(0.0f, 0.0f, 120.0f * i));
				entities[i].StateComponent.AddLocalOffset(new Vector3(0.0f, 0.0f, -420.0f));

				Entity entity = World.GetActor<Entity>(entityName);
				StateComponent component = entity.GetComponent<StateComponent>();

				Assert.IsTrue(entity.Equals(entities[i]));
				Assert.IsTrue(component.Equals(entities[i].StateComponent));
			}

			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, "Actors are spawned! Number of actors in the world: " + World.ActorCount);
		}

		public static void OnEndPlay() => Debug.ClearOnScreenMessages();

		public static void OnTick() {
			float deltaTime = World.DeltaTime;

			for (int i = 0; i < maxEntities; i++) {
				entities[i].StateComponent.AddLocalRotation(new Quaternion(Vector3.UnitZ * entities[i].StateComponent.RotationSpeed * deltaTime, -1.0f));
			}
		}
	}
}