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
		private static SkeletalMeshComponent skeletalMeshComponent = actor.GetComponent<SkeletalMeshComponent>();
		private static AnimationInstance animationInstance = skeletalMeshComponent.GetAnimationInstance();
		private const string boolProperty = "Test Bool";
		private const string byteProperty = "Test Byte";
		private const string intProperty = "Test Int";
		private const string floatProperty = "Test Float";
		private const string textProperty = "Test Text";

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
			TestAnimationBoolProperty();
			TestAnimationByteProperty();
			TestAnimationIntProperty();
			TestAnimationFloatProperty();
			TestAnimationTextProperty();
		}

		public static void OnEndPlay() {
			Debug.Log(LogLevel.Display, "See you soon, Unreal Engine!");
			Debug.ClearOnScreenMessages();
		}

		private static void TestActorBoolProperty() {
			bool value = false;

			Assert.IsTrue(actor.SetBool(boolProperty, true));

			if (actor.GetBool(boolProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorByteProperty() {
			byte value = 0;

			Assert.IsTrue(actor.SetByte(byteProperty, 128));

			if (actor.GetByte(byteProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorIntProperty() {
			int value = 0;

			Assert.IsTrue(actor.SetInt(intProperty, 500));

			if (actor.GetInt(intProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorFloatProperty() {
			float value = 0;

			Assert.IsTrue(actor.SetFloat(floatProperty, 250.5f));

			if (actor.GetFloat(floatProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestActorTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(actor.SetText(textProperty, "Test message from managed code"));

			if (actor.GetText(textProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private static void TestSceneComponentBoolProperty() {
			bool value = false;

			Assert.IsTrue(sceneComponent.SetBool(boolProperty, true));

			if (sceneComponent.GetBool(boolProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentByteProperty() {
			byte value = 0;

			Assert.IsTrue(sceneComponent.SetByte(byteProperty, 128));

			if (sceneComponent.GetByte(byteProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentIntProperty() {
			int value = 0;

			Assert.IsTrue(sceneComponent.SetInt(intProperty, 500));

			if (sceneComponent.GetInt(intProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentFloatProperty() {
			float value = 0;

			Assert.IsTrue(sceneComponent.SetFloat(floatProperty, 250.5f));

			if (sceneComponent.GetFloat(floatProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestSceneComponentTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(sceneComponent.SetText(textProperty, "Test message from managed code"));

			if (sceneComponent.GetText(textProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private static void TestLevelScriptBoolProperty() {
			bool value = false;

			Assert.IsTrue(levelScript.SetBool(boolProperty, true));

			if (levelScript.GetBool(boolProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private static void TestLevelScriptByteProperty() {
			byte value = 0;

			Assert.IsTrue(levelScript.SetByte(byteProperty, 128));

			if (levelScript.GetByte(byteProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private static void TestLevelScriptIntProperty() {
			int value = 0;

			Assert.IsTrue(levelScript.SetInt(intProperty, 500));

			if (levelScript.GetInt(intProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private static void TestLevelScriptFloatProperty() {
			float value = 0;

			Assert.IsTrue(levelScript.SetFloat(floatProperty, 250.5f));

			if (levelScript.GetFloat(floatProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private static void TestLevelScriptTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(levelScript.SetText(textProperty, "Test message from managed code"));

			if (levelScript.GetText(textProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private static void TestAnimationBoolProperty() {
			bool value = false;

			Assert.IsTrue(animationInstance.SetBool(boolProperty, true));

			if (animationInstance.GetBool(boolProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " animation property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " animation property value retrievement failed!");
		}

		private static void TestAnimationByteProperty() {
			byte value = 0;

			Assert.IsTrue(animationInstance.SetByte(byteProperty, 128));

			if (animationInstance.GetByte(byteProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " animation property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " animation property value retrievement failed!");
		}

		private static void TestAnimationIntProperty() {
			int value = 0;

			Assert.IsTrue(animationInstance.SetInt(intProperty, 500));

			if (animationInstance.GetInt(intProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " animation property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " animation property value retrievement failed!");
		}

		private static void TestAnimationFloatProperty() {
			float value = 0;

			Assert.IsTrue(animationInstance.SetFloat(floatProperty, 250.5f));

			if (animationInstance.GetFloat(floatProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " animation property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " animation property value retrievement failed!");
		}

		private static void TestAnimationTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(animationInstance.SetText(textProperty, "Test message from managed code"));

			if (animationInstance.GetText(textProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " animation property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " animation property value retrievement failed!");
		}

		public static void TestBlueprintActorFunction(ObjectReference blueprintReference) {
			Actor blueprintActor = blueprintReference.ToActor<Actor>();

			Debug.AddOnScreenMessage(-1, 30.0f, Color.Orange, "Cheers from managed function of the " + blueprintActor.Name);
		}

		public static void TestBlueprintComponentFunction(ObjectReference blueprintReference) {
			SceneComponent blueprintSceneComponent = blueprintReference.ToComponent<SceneComponent>();

			Debug.AddOnScreenMessage(-1, 30.0f, Color.Orange, "Cheers from managed function of the " + blueprintSceneComponent.Name);
		}
	}
}