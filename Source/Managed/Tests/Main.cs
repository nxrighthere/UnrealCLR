using System;
using System.Drawing;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class Main {
		public static void OnBeginWorld() => Debug.Log(LogLevel.Display, "Hello, Unreal Engine!");

		public static void OnEndWorld() => Debug.Log(LogLevel.Display, "See you soon, Unreal Engine!");
	}
}