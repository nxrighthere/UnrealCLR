using System;
using System.Drawing;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class Main {
		private static ISystem runningSystem;

		public static void OnWorldPostBegin() {
			Debug.Log(LogLevel.Display, "Hello, Unreal Engine!");

			TestSystems testSystem = default;

			if (World.GetActor<LevelScript>().GetEnum("Test Systems", ref testSystem))
				Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, testSystem + " system started!");

			switch (testSystem) {
				case TestSystems.AssertionConsistency:
					runningSystem = new AssertionConsistency();
					break;

				case TestSystems.AudioPlayback:
					runningSystem = new AudioPlayback();
					break;

				case TestSystems.BlueprintsExtensibility:
					runningSystem = new BlueprintsExtensibility();
					break;

				case TestSystems.DebugVisualization:
					runningSystem = new DebugVisualization();
					break;

				case TestSystems.DynamicEvents:
					runningSystem = new DynamicEvents();
					break;

				case TestSystems.DynamicsConsistency:
					runningSystem = new DynamicsConsistency();
					break;

				case TestSystems.ExceptionsConsistency:
					runningSystem = new ExceptionsConsistency();
					break;

				case TestSystems.ExternalConsistency:
					runningSystem = new ExternalConsistency();
					break;

				case TestSystems.InstancedStaticMeshes:
					runningSystem = new InstancedStaticMeshes();
					break;

				case TestSystems.ObjectOrientedDesign:
					runningSystem = new ObjectOrientedDesign();
					break;

				case TestSystems.PhysicsSimulation:
					runningSystem = new PhysicsSimulation();
					break;

				case TestSystems.RadialForce:
					runningSystem = new RadialForce();
					break;

				case TestSystems.RuntimeConsistency:
					runningSystem = new RuntimeConsistency();
					break;

				case TestSystems.SkeletalMeshes:
					runningSystem = new SkeletalMeshes();
					break;

				case TestSystems.SpatialQueries:
					runningSystem = new SpatialQueries();
					break;

				case TestSystems.StaticMeshes:
					runningSystem = new StaticMeshes();
					break;

				case TestSystems.TextureAssets:
					runningSystem = new TextureAssets();
					break;

				default:
					break;
			}

			runningSystem.OnBeginPlay();
		}

		public static void OnWorldPrePhysicsTick(float deltaTime) => runningSystem.OnTick(deltaTime);

		public static void OnWorldEnd() {
			runningSystem.OnEndPlay();

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