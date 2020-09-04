using System.Drawing;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class Main {
		public static void OnWorldBegin() => Debug.Log(LogLevel.Display, "Hello, Unreal Engine!");

		public static void OnWorldEnd() => Debug.Log(LogLevel.Display, "See you soon, Unreal Engine!");
	}
}