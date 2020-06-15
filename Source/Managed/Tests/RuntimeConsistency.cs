using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class RuntimeConsistency {
		public static void OnBeginPlay() {
			ActorMemoryManagementTest();
			ComponentMemoryManagementTest();
			DuplicateActorMemoryManagementTest();
			DuplicateComponentMemoryManagementTest();
			ConsoleVariablesMemoryManagementTest();

			Debug.AddOnScreenMessage(-1, 10.0f, Color.MediumTurquoise, "Verify " + MethodBase.GetCurrentMethod().DeclaringType + " results in output log!");
		}

		private static void ActorMemoryManagementTest() {
			Debug.Log(LogLevel.Display, "Starting " + MethodBase.GetCurrentMethod().Name + "...");

			try {
				Actor actor = new Actor();
				SceneComponent sceneComponent = new SceneComponent(actor, setAsRoot: true);

				actor.Destroy();

				Debug.Log(LogLevel.Display, "Triggering invalid action after the destruction");

				sceneComponent.Destroy();
			}

			catch (Exception exception) {
				Debug.Log(LogLevel.Display, "The exception has successfully reached: " + exception.Message);

				return;
			}

			Debug.Log(LogLevel.Error, "Test failed!");
		}

		private static void ComponentMemoryManagementTest() {
			Debug.Log(LogLevel.Display, "Starting " + MethodBase.GetCurrentMethod().Name + "...");

			try {
				Actor actor = new Actor();
				SceneComponent sceneComponent = new SceneComponent(actor, setAsRoot: true);

				sceneComponent.Destroy();

				Debug.Log(LogLevel.Display, "Triggering invalid action after the destruction");

				sceneComponent.AddLocalOffset(default(Vector3));
			}

			catch (Exception exception) {
				Debug.Log(LogLevel.Display, "The exception has successfully reached: " + exception.Message);

				return;
			}

			Debug.Log(LogLevel.Error, "Test failed!");
		}

		private static void DuplicateActorMemoryManagementTest() {
			Debug.Log(LogLevel.Display, "Starting " + MethodBase.GetCurrentMethod().Name + "...");

			try {
				Pawn pawn = new Pawn();
				Pawn namedPawn = new Pawn("Player");
				Pawn duplicateActor = World.GetActor<Pawn>("Player");

				if (!namedPawn.Equals(duplicateActor)) {
					Debug.Log(LogLevel.Error, "Actor reference equality check failed!");

					return;
				}

				namedPawn.Destroy();

				Debug.Log(LogLevel.Display, "Triggering invalid actions after the destruction");

				duplicateActor.SetLifeSpan(5.0f);
				duplicateActor.Destroy();
			}

			catch (Exception exception) {
				Debug.Log(LogLevel.Display, "The exception has successfully reached: " + exception.Message);

				return;
			}

			Debug.Log(LogLevel.Error, "Test failed!");
		}

		private static void DuplicateComponentMemoryManagementTest() {
			Debug.Log(LogLevel.Display, "Starting " + MethodBase.GetCurrentMethod().Name + "...");

			try {
				Actor actor = new Actor();
				SceneComponent sceneComponent = new SceneComponent(actor, setAsRoot: true);
				SceneComponent duplicateReference = actor.GetRootComponent<SceneComponent>();

				if (!sceneComponent.Equals(duplicateReference)) {
					Debug.Log(LogLevel.Error, "Scene component reference equality check failed!");

					return;
				}

				sceneComponent.Destroy();

				Debug.Log(LogLevel.Display, "Triggering invalid actions after the destruction");

				duplicateReference.AddLocalOffset(default(Vector3));
				duplicateReference.Destroy();
			}

			catch (Exception exception) {
				Debug.Log(LogLevel.Display, "The exception has successfully reached: " + exception.Message);

				return;
			}

			Debug.Log(LogLevel.Error, "Test failed!");
		}

		private static void ConsoleVariablesMemoryManagementTest() {
			Debug.Log(LogLevel.Display, "Starting " + MethodBase.GetCurrentMethod().Name + "...");

			const string variableName = "TestVariable";

			try {
				ConsoleVariable variable = ConsoleManager.RegisterVariable(variableName, "A test variable", 64);

				if (!ConsoleManager.IsRegisteredVariable(variableName)) {
					Debug.Log(LogLevel.Error, "Variable registration check failed!");

					return;
				}

				ConsoleManager.UnregisterObject(variableName);

				Debug.Log(LogLevel.Display, "Triggering invalid actions after the destruction");

				variable.GetInt();
			}

			catch (Exception exception) {
				Debug.Log(LogLevel.Display, "The exception has successfully reached: " + exception.Message);

				return;
			}

			Debug.Log(LogLevel.Error, "Test failed!");
		}
	}
}