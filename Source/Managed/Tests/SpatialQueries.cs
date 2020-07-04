using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class SpatialQueries {
		public static void OnBeginPlay() {
			Debug.Log(LogLevel.Display, "Hello, Unreal Engine!");
			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, MethodBase.GetCurrentMethod().DeclaringType + " system started!");

			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			const float linesThickness = 3.0f;
			const string collisionProfile = "BoxProfile";

			Actor box = new Actor("Box");
			StaticMeshComponent staticMeshComponent = new StaticMeshComponent(box, setAsRoot: true);
			Vector3 boxLocation = new Vector3(0.0f, 500.0f, 0.0f);
			Vector3 boxScale = new Vector3(100.0f, 100.0f, 100.0f);

			staticMeshComponent.SetWorldLocation(boxLocation);
			staticMeshComponent.SetWorldScale(boxScale);
			staticMeshComponent.SetStaticMesh(StaticMesh.Cube);
			staticMeshComponent.SetCollisionChannel(CollisionChannel.WorldStatic);
			staticMeshComponent.SetCollisionProfileName(collisionProfile);

			Debug.DrawBox(boxLocation, boxScale, Quaternion.Identity, Color.SlateBlue, true, thickness: linesThickness);

			Hit hit = default(Hit);
			Vector3 lineTraceStart = new Vector3(0.0f, 150.0f, 0.0f);

			bool hitByChannel = World.LineTraceSingleByChannel(lineTraceStart, boxLocation, CollisionChannel.WorldStatic, ref hit);

			Assert.IsTrue(hitByChannel);
			Assert.IsTrue(hit.BlockingHit);

			if (hitByChannel) {
				Debug.AddOnScreenMessage(-1, 15.0f, Color.DeepPink, "Box trace hit by channel!");
				Debug.DrawPoint(hit.TraceStart, 8.0f, Color.DeepPink, true);
				Debug.DrawPoint(hit.TraceEnd, 8.0f, Color.DeepPink, true);
				Debug.DrawLine(hit.TraceStart, hit.TraceEnd, Color.DeepPink, true, thickness: linesThickness);
			}

			bool hitByProfile = World.LineTraceSingleByProfile(lineTraceStart, boxLocation, collisionProfile, ref hit);

			Assert.IsTrue(hitByProfile);
			Assert.IsTrue(hit.BlockingHit);

			if (hitByProfile)
				Debug.AddOnScreenMessage(-1, 15.0f, Color.DeepPink, "Box trace hit by profile!");
		}

		public static void OnEndPlay() {
			Debug.Log(LogLevel.Display, "See you soon, Unreal Engine!");
			Debug.ClearOnScreenMessages();
		}
	}
}