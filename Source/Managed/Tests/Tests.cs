using System;
using System.Drawing;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class Main {
		private static ISystem runningSystem;

		public static void OnWorldPostBegin() {
			Debug.Log(LogLevel.Display, "Hello, Unreal Engine!");

			if (World.CurrentLevelName == "Tests") {
				TestSystems testSystem = default;

				if (World.GetActor<LevelScript>().GetEnum("Test Systems", ref testSystem))
					Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, testSystem + " system started!");

				runningSystem = testSystem switch {
					TestSystems.AssertionConsistency => new AssertionConsistency(),
					TestSystems.AudioPlayback => new AudioPlayback(),
					TestSystems.BlueprintsExtensibility => new BlueprintsExtensibility(),
					TestSystems.DebugVisualization => new DebugVisualization(),
					TestSystems.DynamicEvents => new DynamicEvents(),
					TestSystems.DynamicsConsistency => new DynamicsConsistency(),
					TestSystems.ExceptionsConsistency => new ExceptionsConsistency(),
					TestSystems.ExternalConsistency => new ExternalConsistency(),
					TestSystems.InstancedStaticMeshes => new InstancedStaticMeshes(),
					TestSystems.ObjectOrientedDesign => new ObjectOrientedDesign(),
					TestSystems.PhysicsSimulation => new PhysicsSimulation(),
					TestSystems.RadialForce => new RadialForce(),
					TestSystems.RuntimeConsistency => new RuntimeConsistency(),
					TestSystems.SkeletalMeshes => new SkeletalMeshes(),
					TestSystems.SpatialQueries => new SpatialQueries(),
					TestSystems.StaticMeshes => new StaticMeshes(),
					TestSystems.TextRenderer => new TextRenderer(),
					TestSystems.TextureAssets => new TextureAssets(),
					TestSystems.VirtualReality => new VirtualReality(),
					_ => throw new Exception("Unknown system")
				};
			}

			runningSystem?.OnBeginPlay();
		}

		public static void OnWorldPrePhysicsTick(float deltaTime) => runningSystem?.OnTick(deltaTime);

		public static void OnWorldEnd() {
			runningSystem?.OnEndPlay();

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
			TextRenderer,
			TextureAssets,
			VirtualReality
		}
	}

	public interface ISystem {
		void OnBeginPlay() { }
		void OnTick(float deltaTime) { }
		void OnEndPlay() { }
	}
}