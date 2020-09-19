using System;
using System.Drawing;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class Main {
		private static TestSystems testSystem;
		private static ISystem runningSystem;
		private static event Action OnBeginPlay;
		private static event Action<float> OnTick;
		private static event Action OnEndPlay;

		public static void OnWorldPostBegin() {
			Debug.Log(LogLevel.Display, "Hello, Unreal Engine!");

			if (World.GetActor<LevelScript>().GetEnum("Test Systems", ref testSystem))
				Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, testSystem + " system started!");

			switch (testSystem) {
				case TestSystems.AssertionConsistency:
					runningSystem = new AssertionConsistency();
					OnBeginPlay += runningSystem.OnBeginPlay;
					break;

				case TestSystems.AudioPlayback:
					runningSystem = new AudioPlayback();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.BlueprintsExtensibility:
					runningSystem = new BlueprintsExtensibility();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.DebugVisualization:
					runningSystem = new DebugVisualization();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.DynamicEvents:
					runningSystem = new DynamicEvents();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnTick += runningSystem.OnTick;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.DynamicsConsistency:
					runningSystem = new DynamicsConsistency();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnTick += runningSystem.OnTick;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.ExceptionsConsistency:
					runningSystem = new ExceptionsConsistency();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.ExternalConsistency:
					runningSystem = new ExternalConsistency();
					OnBeginPlay += runningSystem.OnBeginPlay;
					break;

				case TestSystems.InstancedStaticMeshes:
					runningSystem = new InstancedStaticMeshes();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnTick += runningSystem.OnTick;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.ObjectOrientedDesign:
					runningSystem = new ObjectOrientedDesign();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnTick += runningSystem.OnTick;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.PhysicsSimulation:
					runningSystem = new PhysicsSimulation();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnTick += runningSystem.OnTick;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.RadialForce:
					runningSystem = new RadialForce();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.RuntimeConsistency:
					runningSystem = new RuntimeConsistency();
					OnBeginPlay += runningSystem.OnBeginPlay;
					break;

				case TestSystems.SkeletalMeshes:
					runningSystem = new SkeletalMeshes();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.SpatialQueries:
					runningSystem = new SpatialQueries();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.StaticMeshes:
					runningSystem = new StaticMeshes();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnTick += runningSystem.OnTick;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				case TestSystems.TextureAssets:
					runningSystem = new TextureAssets();
					OnBeginPlay += runningSystem.OnBeginPlay;
					OnEndPlay += runningSystem.OnEndPlay;
					break;

				default:
					break;
			}

			OnBeginPlay?.Invoke();
		}

		public static void OnWorldPrePhysicsTick(float deltaTime) => OnTick?.Invoke(deltaTime);

		public static void OnWorldEnd() {
			OnEndPlay?.Invoke();

			Debug.Log(LogLevel.Display, "See you soon, Unreal Engine!");
		}

		private enum TestSystems {
			AssertionConsistency,
			AudioPlayback,
			BlueprintsExtensibility,
			DebugVisualization,
			DynamicEvents,
			DynamicsConsistency,
			ExceptionsConsistency,
			ExternalConsistency,
			InstancedStaticMeshes,
			ObjectOrientedDesign,
			PhysicsSimulation,
			RadialForce,
			RuntimeConsistency,
			SkeletalMeshes,
			SpatialQueries,
			StaticMeshes,
			TextureAssets
		}
	}

	public interface ISystem {
		void OnBeginPlay() { }
		void OnTick(float deltaTime) { }
		void OnEndPlay() { }
	}
}