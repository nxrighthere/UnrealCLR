using System;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class ExceptionsConsistency : ISystem {
		private const string consoleVariable = "TestVariable";
		private const string consoleCommand = "TestCommand";

		public void OnBeginPlay() {
			ConsoleVariable variable = ConsoleManager.RegisterVariable(consoleVariable, "A test variable", 0);

			ConsoleManager.RegisterCommand(consoleCommand, "A test command", ConsoleCommand);

			variable.SetOnChangedCallback(VariableEvent);

			PlayerController playerController = World.GetFirstPlayerController();

			playerController.ConsoleCommand(consoleVariable + " 1");
			playerController.ConsoleCommand(consoleCommand + " 1.5");

			throw new Exception("Test exception (OnBeginPlay)");
		}

		public void OnEndPlay() {
			ConsoleManager.UnregisterObject(consoleVariable);
			ConsoleManager.UnregisterObject(consoleCommand);
			Debug.ClearOnScreenMessages();
		}

		private void VariableEvent() => throw new Exception("Test exception (VariableEvent)");

		private void ConsoleCommand(float value) => throw new Exception("Test exception (ConsoleCommand)");
	}
}