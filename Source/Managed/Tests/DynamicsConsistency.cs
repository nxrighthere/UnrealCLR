using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class DynamicsConsistency : ISystem {
		private PlayerController playerController;
		private PlayerInput playerInput;
		private ConsoleVariable variable;
		private uint commandsCount;
		private const int variableValue = 64;
		private const string consoleVariable = "TestVariable";
		private const string consoleCommand = "TestCommand";
		private const string pauseResumeAction = "Pause/Resume";
		private const string playerCommandAction = "PlayerCommandAction";
		private const string pauseResumeKey = Keys.Q;
		private const string playerCommandKey = Keys.X;
		private const string messageKey = Keys.E;
		private const string mouseXAction = "Mouse X Message";
		private const string mouseYAction = "Mouse Y Message";
		private const string mouseXKey = Keys.MouseX;
		private const string mouseYKey = Keys.MouseY;

		public DynamicsConsistency() {
			playerController = World.GetFirstPlayerController();
			playerInput = playerController.GetPlayerInput();
			variable = ConsoleManager.RegisterVariable(consoleVariable, "A test variable", variableValue);
			commandsCount = 0;
		}

		public void OnBeginPlay() {
			Assert.IsFalse(variable.IsBool);
			Assert.IsFalse(variable.IsFloat);
			Assert.IsFalse(variable.IsString);
			Assert.IsTrue(variable.IsInt);
			Assert.IsTrue(variable.GetInt() == variableValue);

			variable.SetOnChangedCallback(VariableEvent);

			ConsoleManager.RegisterCommand(consoleCommand, "Executes a test command", ConsoleCommand);

			Assert.IsTrue(ConsoleManager.IsRegisteredVariable(consoleCommand));

			Engine.AddActionMapping(pauseResumeAction, pauseResumeKey);
			Engine.AddAxisMapping(mouseXAction, mouseXKey);
			Engine.AddAxisMapping(mouseYAction, mouseYKey);

			playerInput.AddActionMapping(playerCommandAction, playerCommandKey);

			InputComponent inputComponent = playerController.InputComponent;

			Assert.IsFalse(inputComponent.HasBindings);

			inputComponent.BindAction(pauseResumeAction, InputEvent.Pressed, PauseResume, true);
			inputComponent.BindAction(playerCommandAction, InputEvent.Pressed, PlayerCommand, true);
			inputComponent.BindAxis(mouseXAction, MouseXMessage);
			inputComponent.BindAxis(mouseYAction, MouseYMessage);

			Assert.IsTrue(inputComponent.HasBindings);
			Assert.IsTrue(inputComponent.ActionBindingsNumber == 2);

			const string removableAction = "TestRemovable";
			const string removableKey = Keys.R;

			playerInput.AddActionMapping(removableAction, removableKey, ctrl: true, alt: true);
			playerInput.RemoveActionMapping(removableAction, removableKey);
		}

		public void OnTick(float deltaTime) {
			TimeTest();
			MousePositionTest();
			WindowTest();
			ActionBindingsTest();
			KeyPressTest();
			ConsoleTest();
		}

		public void OnEndPlay() {
			ConsoleManager.UnregisterObject(consoleVariable);
			ConsoleManager.UnregisterObject(consoleCommand);
			Debug.ClearOnScreenMessages();
		}

		private void VariableEvent() => Debug.AddOnScreenMessage(-1, 5.0f, Color.LightBlue, "Variable has changed: " + variable.GetInt());

		private void ConsoleCommand(float value) => Debug.AddOnScreenMessage(-1, 5.0f, Color.LightGreen, "Test console command executed: " + value);

		private void PauseResume() => playerController.SetPause(!playerController.IsPaused);

		private void PlayerCommand() => playerController.ConsoleCommand(consoleCommand + " " + ++commandsCount);

		private void MouseXMessage(float axisValue) => Debug.AddOnScreenMessage(1, 3.0f, Color.PaleGoldenrod, "Mouse X axis value: " + axisValue);

		private void MouseYMessage(float axisValue) => Debug.AddOnScreenMessage(2, 3.0f, Color.PaleGoldenrod, "Mouse Y axis value: " + axisValue);

		private void TimeTest() {
			Debug.AddOnScreenMessage(3, 3.0f, Color.LightCyan, "Time: " + World.Time);
			Debug.AddOnScreenMessage(4, 3.0f, Color.LightCyan, "Delta time: " + World.DeltaTime);
			Debug.AddOnScreenMessage(5, 3.0f, Color.LightCyan, "Real time: " + World.RealTime);
		}

		private void MousePositionTest() {
			float mousePositionX = 0.0f;
			float mousePositionY = 0.0f;

			playerController.GetMousePosition(ref mousePositionX, ref mousePositionY);

			Debug.AddOnScreenMessage(7, 3.0f, Color.MediumAquamarine, "Mouse position X: " + mousePositionX);
			Debug.AddOnScreenMessage(8, 3.0f, Color.MediumAquamarine, "Mouse position Y: " + mousePositionY);
		}

		private void WindowTest() {
			Vector2 viewportSize = default;

			Engine.GetViewportSize(ref viewportSize);

			Debug.AddOnScreenMessage(9, 3.0f, Color.LightSkyBlue, "Viewport size X: " + viewportSize.X);
			Debug.AddOnScreenMessage(10, 3.0f, Color.LightSkyBlue, "Viewport size Y: " + viewportSize.Y);
			Debug.AddOnScreenMessage(11, 3.0f, Color.LightSteelBlue, "Window has focus: " + Engine.IsForegroundWindow);
			Debug.AddOnScreenMessage(12, 3.0f, Color.LightSteelBlue, "Window mode: " + Engine.WindowMode);
		}

		private void ActionBindingsTest() {
			Debug.AddOnScreenMessage(13, 3.0f, Color.Orange, "Action bindings: " + playerController.InputComponent.ActionBindingsNumber);
			Debug.AddOnScreenMessage(14, 3.0f, Color.Orange, "Press [" + pauseResumeKey + "] key to pause/resume");
			Debug.AddOnScreenMessage(15, 3.0f, Color.Orange, "Press [" + playerCommandKey + "] key to execute a player command");
		}

		private void KeyPressTest() {
			Debug.AddOnScreenMessage(16, 3.0f, Color.Khaki, "Press [" + messageKey + "] key for a message");

			if (playerInput.IsKeyPressed(Keys.E))
				Debug.AddOnScreenMessage(-1, 0.1f, Color.LightSalmon, "[" + messageKey + "] key pressed!");
		}

		private void ConsoleTest() {
			Debug.AddOnScreenMessage(17, 3.0f, Color.YellowGreen, "Enter " + consoleVariable + " (value) to the console to change a variable");
			Debug.AddOnScreenMessage(18, 3.0f, Color.YellowGreen, "Enter " + consoleCommand + " (value) to the console to execute a command");
		}
	}
}