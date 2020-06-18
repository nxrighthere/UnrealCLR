using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class BlueprintsExtensibility {
		private static Blueprint blueprintActor = Blueprint.Load("/Game/Tests/BlueprintActor");
		private static Blueprint blueprintSceneComponent = Blueprint.Load("/Game/Tests/BlueprintSceneComponent");
		private static Actor actor = new Actor(blueprint: blueprintActor);
		private static SceneComponent sceneComponent = new SceneComponent(actor, blueprint: blueprintSceneComponent);

		public static void OnBeginPlay() {
			Debug.Log(LogLevel.Display, "Hello, Unreal Engine!");

			if (actor.IsSpawned)
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Tomato, "Blueprint actor is spawned!");

			if (sceneComponent.IsCreated)
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Tomato, "Blueprint scene component is created!");

			TestActorBoolProperty();
			TestActorByteProperty();
			TestActorIntProperty();
			TestActorFloatProperty();
			TestActorTextProperty();
			TestSceneComponentBoolProperty();
			TestSceneComponentByteProperty();
			TestSceneComponentIntProperty();
			TestSceneComponentFloatProperty();
			TestSceneComponentTextProperty();
		}

		public static void OnEndPlay() {
			Debug.Log(LogLevel.Display, "See you soon, Unreal Engine!");
			Debug.ClearOnScreenMessages();
		}

		private static void TestActorBoolProperty() {
			bool value = false;

			Assert.IsTrue(actor.SetBool("Test Bool", true));

			if (actor.GetBool("Test Bool", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorByteProperty() {
			byte value = 0;

			Assert.IsTrue(actor.SetByte("Test Byte", 128));

			if (actor.GetByte("Test Byte", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorIntProperty() {
			int value = 0;

			Assert.IsTrue(actor.SetInt("Test Int", 500));

			if (actor.GetInt("Test Int", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorFloatProperty() {
			float value = 0;

			Assert.IsTrue(actor.SetFloat("Test Float", 250.5f));

			if (actor.GetFloat("Test Float", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(actor.SetText("Test Text", "Test message from managed code"));

			if (actor.GetText("Test Text", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestSceneComponentBoolProperty() {
			bool value = false;

			Assert.IsTrue(sceneComponent.SetBool("Test Bool", true));

			if (sceneComponent.GetBool("Test Bool", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentByteProperty() {
			byte value = 0;

			Assert.IsTrue(sceneComponent.SetByte("Test Byte", 128));

			if (sceneComponent.GetByte("Test Byte", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentIntProperty() {
			int value = 0;

			Assert.IsTrue(sceneComponent.SetInt("Test Int", 500));

			if (sceneComponent.GetInt("Test Int", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentFloatProperty() {
			float value = 0;

			Assert.IsTrue(sceneComponent.SetFloat("Test Float", 250.5f));

			if (sceneComponent.GetFloat("Test Float", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(sceneComponent.SetText("Test Text", "Test message from managed code"));

			if (sceneComponent.GetText("Test Text", ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}
	}

	public static class BlueprintActor {
		public static void OnBeginPlay() => Debug.AddOnScreenMessage(-1, 30.0f, Color.Orange, "Cheers from managed function of the blueprint actor!");
	}

	public static class BlueprintSceneComponent {
		public static void OnBeginPlay() => Debug.AddOnScreenMessage(-1, 30.0f, Color.Orange, "Cheers from managed function of the blueprint scene component!");
	}
}