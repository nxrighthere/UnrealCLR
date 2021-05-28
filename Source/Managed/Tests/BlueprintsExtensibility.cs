using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class BlueprintsExtensibility : ISystem {
		private Blueprint blueprintActor;
		private Blueprint blueprintSceneComponent;
		private Actor actor;
		private SceneComponent sceneComponent;
		private LevelScript levelScript;
		private SkeletalMeshComponent skeletalMeshComponent;
		private AnimationInstance animationInstance;
		private const string boolProperty = "Test Bool";
		private const string byteProperty = "Test Byte";
		private const string intProperty = "Test Int";
		private const string floatProperty = "Test Float";
		private const string stringProperty = "Test String";
		private const string textProperty = "Test Text";

		public BlueprintsExtensibility() {
			blueprintActor = Blueprint.Load("/Game/Tests/BlueprintActor");
			blueprintSceneComponent = Blueprint.Load("/Game/Tests/BlueprintSceneComponent");
			actor = new(blueprint: blueprintActor);
			sceneComponent = new(actor, blueprint: blueprintSceneComponent);
			levelScript = World.GetActor<LevelScript>();
			skeletalMeshComponent = actor.GetComponent<SkeletalMeshComponent>();
			animationInstance = skeletalMeshComponent.GetAnimationInstance();
		}

		public void OnBeginPlay() {
			const string eventMessage = "Blueprint event dispatched";
			const float eventValue = 100.0f;

			Assert.IsTrue(levelScript.Invoke($"TestEvent \"{ eventMessage }: \" { eventValue }"));
			Assert.IsTrue(actor.IsSpawned);
			Assert.IsTrue(sceneComponent.IsCreated);

			TestActorBoolProperty();
			TestActorByteProperty();
			TestActorIntProperty();
			TestActorFloatProperty();
			TestActorStringProperty();
			TestActorTextProperty();
			TestSceneComponentBoolProperty();
			TestSceneComponentByteProperty();
			TestSceneComponentIntProperty();
			TestSceneComponentFloatProperty();
			TestSceneComponentStringProperty();
			TestSceneComponentTextProperty();
			TestLevelScriptBoolProperty();
			TestLevelScriptByteProperty();
			TestLevelScriptIntProperty();
			TestLevelScriptFloatProperty();
			TestLevelScriptStringProperty();
			TestLevelScriptTextProperty();
			TestAnimationBoolProperty();
			TestAnimationByteProperty();
			TestAnimationIntProperty();
			TestAnimationFloatProperty();
			TestAnimationStringProperty();
			TestAnimationTextProperty();
		}

		public void OnEndPlay() => Debug.ClearOnScreenMessages();

		private void TestActorBoolProperty() {
			bool value = false;

			Assert.IsTrue(actor.SetBool(boolProperty, true));

			if (actor.GetBool(boolProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private void TestActorByteProperty() {
			byte value = 0;

			Assert.IsTrue(actor.SetByte(byteProperty, 128));

			if (actor.GetByte(byteProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private void TestActorIntProperty() {
			int value = 0;

			Assert.IsTrue(actor.SetInt(intProperty, 500));

			if (actor.GetInt(intProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private void TestActorFloatProperty() {
			float value = 0;

			Assert.IsTrue(actor.SetFloat(floatProperty, 250.5f));

			if (actor.GetFloat(floatProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private void TestActorStringProperty() {
			string value = String.Empty;

			Assert.IsTrue(actor.SetString(stringProperty, "Test string from managed code"));

			if (actor.GetString(stringProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private void TestActorTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(actor.SetText(textProperty, "Test text from managed code"));

			if (actor.GetText(textProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " actor property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " actor property value retrievement failed!");
		}

		private void TestSceneComponentBoolProperty() {
			bool value = false;

			Assert.IsTrue(sceneComponent.SetBool(boolProperty, true));

			if (sceneComponent.GetBool(boolProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private void TestSceneComponentByteProperty() {
			byte value = 0;

			Assert.IsTrue(sceneComponent.SetByte(byteProperty, 128));

			if (sceneComponent.GetByte(byteProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private void TestSceneComponentIntProperty() {
			int value = 0;

			Assert.IsTrue(sceneComponent.SetInt(intProperty, 500));

			if (sceneComponent.GetInt(intProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private void TestSceneComponentFloatProperty() {
			float value = 0;

			Assert.IsTrue(sceneComponent.SetFloat(floatProperty, 250.5f));

			if (sceneComponent.GetFloat(floatProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private void TestSceneComponentStringProperty() {
			string value = String.Empty;

			Assert.IsTrue(sceneComponent.SetString(stringProperty, "Test string from managed code"));

			if (sceneComponent.GetString(stringProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private void TestSceneComponentTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(sceneComponent.SetText(textProperty, "Test text from managed code"));

			if (sceneComponent.GetText(textProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " scene component property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " scene component property value retrievement failed!");
		}

		private void TestLevelScriptBoolProperty() {
			bool value = false;

			Assert.IsTrue(levelScript.SetBool(boolProperty, true));

			if (levelScript.GetBool(boolProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private void TestLevelScriptByteProperty() {
			byte value = 0;

			Assert.IsTrue(levelScript.SetByte(byteProperty, 128));

			if (levelScript.GetByte(byteProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private void TestLevelScriptIntProperty() {
			int value = 0;

			Assert.IsTrue(levelScript.SetInt(intProperty, 500));

			if (levelScript.GetInt(intProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private void TestLevelScriptFloatProperty() {
			float value = 0;

			Assert.IsTrue(levelScript.SetFloat(floatProperty, 250.5f));

			if (levelScript.GetFloat(floatProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private void TestLevelScriptStringProperty() {
			string value = String.Empty;

			Assert.IsTrue(levelScript.SetString(stringProperty, "Test string message from managed code"));

			if (levelScript.GetString(stringProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private void TestLevelScriptTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(levelScript.SetText(textProperty, "Test text message from managed code"));

			if (levelScript.GetText(textProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " level script property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " level script property value retrievement failed!");
		}

		private void TestAnimationBoolProperty() {
			bool value = false;

			Assert.IsTrue(animationInstance.SetBool(boolProperty, true));

			if (animationInstance.GetBool(boolProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " animation property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " animation property value retrievement failed!");
		}

		private void TestAnimationByteProperty() {
			byte value = 0;

			Assert.IsTrue(animationInstance.SetByte(byteProperty, 128));

			if (animationInstance.GetByte(byteProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " animation property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " animation property value retrievement failed!");
		}

		private void TestAnimationIntProperty() {
			int value = 0;

			Assert.IsTrue(animationInstance.SetInt(intProperty, 500));

			if (animationInstance.GetInt(intProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " animation property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " animation property value retrievement failed!");
		}

		private void TestAnimationFloatProperty() {
			float value = 0;

			Assert.IsTrue(animationInstance.SetFloat(floatProperty, 250.5f));

			if (animationInstance.GetFloat(floatProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " animation property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " animation property value retrievement failed!");
		}

		private void TestAnimationStringProperty() {
			string value = String.Empty;

			Assert.IsTrue(animationInstance.SetString(stringProperty, "Test string message from managed code"));

			if (animationInstance.GetString(stringProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " animation property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " animation property value retrievement failed!");
		}

		private void TestAnimationTextProperty() {
			string value = String.Empty;

			Assert.IsTrue(animationInstance.SetText(textProperty, "Test text message from managed code"));

			if (animationInstance.GetText(textProperty, ref value))
				Debug.AddOnScreenMessage(-1, 30.0f, Color.LimeGreen, value.GetType() + " animation property value retrieved: " + value);
			else
				Debug.AddOnScreenMessage(-1, 30.0f, Color.Red, value.GetType() + " animation property value retrievement failed!");
		}

		public static void TestBlueprintActorFunction(ObjectReference self) {
			Actor blueprintActor = self.ToActor<Actor>();

			Debug.AddOnScreenMessage(-1, 30.0f, Color.Orange, "Cheers from managed function of the " + blueprintActor.Name);
		}

		public static void TestBlueprintComponentFunction(ObjectReference self) {
			SceneComponent blueprintSceneComponent = self.ToComponent<SceneComponent>();

			Debug.AddOnScreenMessage(-1, 30.0f, Color.Orange, "Cheers from managed function of the " + blueprintSceneComponent.Name);
		}
	}
}