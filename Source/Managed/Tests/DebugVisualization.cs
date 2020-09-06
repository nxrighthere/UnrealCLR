using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class DebugVisualization {
		public void OnBeginPlay() {
			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			const float linesThickness = 3.0f;

			Debug.DrawBox(new Vector3(0.0f, -300.0f, 0.0f), new Vector3(50.0f, 50.0f, 50.0f), Quaternion.Identity, Color.Red, true, thickness: linesThickness);
			Debug.DrawCapsule(new Vector3(0.0f, -150.0f, 0.0f), 50.0f, 25.0f, Quaternion.Identity, Color.Yellow, true, thickness: linesThickness);
			Debug.DrawCone(new Vector3(0.0f, 0.0f, 50.0f), -Vector3.UnitZ, 115.0f, 0.5f, 0.5f, 8, Color.Green, true, thickness: linesThickness);
			Debug.DrawCylinder(new Vector3(0.0f, 150.0f, 50.0f), new Vector3(0.0f, 150.0f, -50.0f), 50.0f, 32, Color.Blue, true, thickness: linesThickness);
			Debug.DrawSphere(new Vector3(0.0f, 300.0f, 0.0f), 50.0f, 16, Color.DeepPink, true, thickness: linesThickness);

			Debug.DrawLine(new Vector3(0.0f, -350.0f, -100.0f), new Vector3(0.0f, 350.0f, -100.0f), Color.DarkViolet, true, thickness: linesThickness);

			Debug.DrawPoint(new Vector3(0.0f, -350.0f, -150.0f), 8.0f, Color.MediumVioletRed, true);
			Debug.DrawPoint(new Vector3(0.0f, 350.0f, -150.0f), 8.0f, Color.MediumVioletRed, true);
		}

		public void OnEndPlay() => Debug.ClearOnScreenMessages();
	}
}