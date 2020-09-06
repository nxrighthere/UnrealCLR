using System.Drawing;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class Main {
		private static AssertionConsistency assertionConsistency;
		private static AudioPlayback audioPlayback;
		private static BlueprintsExtensibility blueprintsExtensibility;
		private static DebugVisualization debugVisualization;
		private static DynamicEvents dynamicEvents;
		private static DynamicsConsistency dynamicsConsistency;
		private static ExceptionsConsistency exceptionsConsistency;
		private static ExternalConsistency externalConsistency;
		private static InstancedStaticMeshes instancedStaticMeshes;
		private static ObjectOrientedDesign objectOrientedDesign;
		private static PhysicsSimulation physicsSimulation;
		private static RadialForce radialForce;
		private static RuntimeConsistency runtimeConsistency;
		private static SkeletalMeshes skeletalMeshes;
		private static SpatialQueries spatialQueries;
		private static StaticMeshes staticMeshes;
		private static TextureAssets textureAssets;
		private static TestSystems testSystem;

		public static void OnWorldPostBegin() {
			Debug.Log(LogLevel.Display, "Hello, Unreal Engine!");

			if (World.GetActor<LevelScript>().GetEnum("Test Systems", ref testSystem))
				Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, testSystem + " system started!");

			switch (testSystem) {
				case TestSystems.AssertionConsistency:
					assertionConsistency = new AssertionConsistency();
					assertionConsistency.OnBeginPlay();
					break;

				case TestSystems.AudioPlayback:
					audioPlayback = new AudioPlayback();
					audioPlayback.OnBeginPlay();
					break;

				case TestSystems.BlueprintsExtensibility:
					blueprintsExtensibility = new BlueprintsExtensibility();
					blueprintsExtensibility.OnBeginPlay();
					break;

				case TestSystems.DebugVisualization:
					debugVisualization = new DebugVisualization();
					debugVisualization.OnBeginPlay();
					break;

				case TestSystems.DynamicEvents:
					dynamicEvents = new DynamicEvents();
					dynamicEvents.OnBeginPlay();
					break;

				case TestSystems.DynamicsConsistency:
					dynamicsConsistency = new DynamicsConsistency();
					dynamicsConsistency.OnBeginPlay();
					break;

				case TestSystems.ExceptionsConsistency:
					exceptionsConsistency = new ExceptionsConsistency();
					exceptionsConsistency.OnBeginPlay();
					break;

				case TestSystems.ExternalConsistency:
					externalConsistency = new ExternalConsistency();
					externalConsistency.OnBeginPlay();
					break;

				case TestSystems.InstancedStaticMeshes:
					instancedStaticMeshes = new InstancedStaticMeshes();
					instancedStaticMeshes.OnBeginPlay();
					break;

				case TestSystems.ObjectOrientedDesign:
					objectOrientedDesign = new ObjectOrientedDesign();
					objectOrientedDesign.OnBeginPlay();
					break;

				case TestSystems.PhysicsSimulation:
					physicsSimulation = new PhysicsSimulation();
					physicsSimulation.OnBeginPlay();
					break;

				case TestSystems.RadialForce:
					radialForce = new RadialForce();
					radialForce.OnBeginPlay();
					break;

				case TestSystems.RuntimeConsistency:
					runtimeConsistency = new RuntimeConsistency();
					runtimeConsistency.OnBeginPlay();
					break;

				case TestSystems.SkeletalMeshes:
					skeletalMeshes = new SkeletalMeshes();
					skeletalMeshes.OnBeginPlay();
					break;

				case TestSystems.SpatialQueries:
					spatialQueries = new SpatialQueries();
					spatialQueries.OnBeginPlay();
					break;

				case TestSystems.StaticMeshes:
					staticMeshes = new StaticMeshes();
					staticMeshes.OnBeginPlay();
					break;

				case TestSystems.TextureAssets:
					textureAssets = new TextureAssets();
					textureAssets.OnBeginPlay();
					break;

				default:
					break;
			}
		}

		public static void OnWorldPrePhysicsTick(float deltaTime) {
			switch (testSystem) {
				case TestSystems.DynamicEvents:
					dynamicEvents.OnTick();
					break;

				case TestSystems.DynamicsConsistency:
					dynamicsConsistency.OnTick();
					break;

				case TestSystems.InstancedStaticMeshes:
					instancedStaticMeshes.OnTick(deltaTime);
					break;

				case TestSystems.ObjectOrientedDesign:
					objectOrientedDesign.OnTick(deltaTime);
					break;

				case TestSystems.PhysicsSimulation:
					physicsSimulation.OnTick(deltaTime);
					break;

				case TestSystems.StaticMeshes:
					staticMeshes.OnTick(deltaTime);
					break;

				default:
					break;
			}
		}

		public static void OnWorldEnd() {
			switch (testSystem) {
				case TestSystems.AudioPlayback:
					audioPlayback.OnEndPlay();
					break;

				case TestSystems.BlueprintsExtensibility:
					blueprintsExtensibility.OnEndPlay();
					break;

				case TestSystems.DebugVisualization:
					debugVisualization.OnEndPlay();
					break;

				case TestSystems.DynamicEvents:
					dynamicEvents.OnEndPlay();
					break;

				case TestSystems.DynamicsConsistency:
					dynamicsConsistency.OnEndPlay();
					break;

				case TestSystems.ExceptionsConsistency:
					exceptionsConsistency.OnEndPlay();
					break;

				case TestSystems.InstancedStaticMeshes:
					instancedStaticMeshes.OnEndPlay();
					break;

				case TestSystems.ObjectOrientedDesign:
					objectOrientedDesign.OnEndPlay();
					break;

				case TestSystems.PhysicsSimulation:
					physicsSimulation.OnEndPlay();
					break;

				case TestSystems.RadialForce:
					radialForce.OnEndPlay();
					break;

				case TestSystems.SkeletalMeshes:
					skeletalMeshes.OnEndPlay();
					break;

				case TestSystems.SpatialQueries:
					spatialQueries.OnEndPlay();
					break;

				case TestSystems.StaticMeshes:
					staticMeshes.OnEndPlay();
					break;

				case TestSystems.TextureAssets:
					textureAssets.OnEndPlay();
					break;

				default:
					break;
			}

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
}