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
		private static LevelScript levelScript = World.GetActor<LevelScript>();

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
			TestLevelScriptBoolProperty();
			TestLevelScriptByteProperty();
			TestLevelScriptIntProperty();
			TestLevelScriptFloatProperty();
			TestLevelScriptTextProperty();
		}

		public static void OnEndPlay() {
			Debug.Log(LogLevel.Display, "See you soon, Unreal Engine!");
			Debug.ClearOnScreenMessages();
		}

		private static void TestActorBoolProperty() {
			const string propertyName = "Test Bool";
			bool value = false;

			Assert.IsTrue(actor.SetBool(propertyName, true));

			if (actor.GetBool(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorByteProperty() {
			const string propertyName = "Test Byte";
			byte value = 0;

			Assert.IsTrue(actor.SetByte(propertyName, 128));

			if (actor.GetByte(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorIntProperty() {
			const string propertyName = "Test Int";
			int value = 0;

			Assert.IsTrue(actor.SetInt(propertyName, 500));

			if (actor.GetInt(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorFloatProperty() {
			const string propertyName = "Test Float";
			float value = 0;

			Assert.IsTrue(actor.SetFloat(propertyName, 250.5f));

			if (actor.GetFloat(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorTextProperty() {
			const string propertyName = "Test Text";
			string value = String.Empty;

			Assert.IsTrue(actor.SetText(propertyName, "Test message from managed code"));

			if (actor.GetText(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestSceneComponentBoolProperty() {
			const string propertyName = "Test Bool";
			bool value = false;

			Assert.IsTrue(sceneComponent.SetBool(propertyName, true));

			if (sceneComponent.GetBool(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentByteProperty() {
			const string propertyName = "Test Byte";
			byte value = 0;

			Assert.IsTrue(sceneComponent.SetByte(propertyName, 128));

			if (sceneComponent.GetByte(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentIntProperty() {
			const string propertyName = "Test Int";
			int value = 0;

			Assert.IsTrue(sceneComponent.SetInt(propertyName, 500));

			if (sceneComponent.GetInt(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentFloatProperty() {
			const string propertyName = "Test Float";
			float value = 0;

			Assert.IsTrue(sceneComponent.SetFloat(propertyName, 250.5f));

			if (sceneComponent.GetFloat(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentTextProperty() {
			const string propertyName = "Test Text";
			string value = String.Empty;

			Assert.IsTrue(sceneComponent.SetText(propertyName, "Test message from managed code"));

			if (sceneComponent.GetText(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestLevelScriptBoolProperty() {
			const string propertyName = "Test Bool";
			bool value = false;

			Assert.IsTrue(levelScript.SetBool(propertyName, true));

			if (levelScript.GetBool(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private static void TestLevelScriptByteProperty() {
			const string propertyName = "Test Byte";
			byte value = 0;

			Assert.IsTrue(levelScript.SetByte(propertyName, 128));

			if (levelScript.GetByte(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private static void TestLevelScriptIntProperty() {
			const string propertyName = "Test Int";
			int value = 0;

			Assert.IsTrue(levelScript.SetInt(propertyName, 500));

			if (levelScript.GetInt(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private static void TestLevelScriptFloatProperty() {
			const string propertyName = "Test Float";
			float value = 0;

			Assert.IsTrue(levelScript.SetFloat(propertyName, 250.5f));

			if (levelScript.GetFloat(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private static void TestLevelScriptTextProperty() {
			const string propertyName = "Test Text";
			string value = String.Empty;

			Assert.IsTrue(levelScript.SetText(propertyName, "Test message from managed code"));

			if (levelScript.GetText(propertyName, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		public static void TestBlueprintActorFunction() => Debug.AddOnScreenMessage(-1, 30.0f, Color.Orange, "Cheers from managed function of the blueprint actor!");

		public static void TestBlueprintComponentFunction() => Debug.AddOnScreenMessage(-1, 30.0f, Color.Orange, "Cheers from managed function of the blueprint scene component!");
	}
}