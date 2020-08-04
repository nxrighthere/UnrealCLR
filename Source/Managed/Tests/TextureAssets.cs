using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class TextureAssets {
		public static void OnBeginPlay() {
			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, MethodBase.GetCurrentMethod().DeclaringType + " system started!");

			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			Actor actor = new Actor();
			StaticMeshComponent staticMeshComponent = new StaticMeshComponent(actor, setAsRoot: true);
			Texture2D texture = Texture2D.Load("/Game/Tests/BasicTexture");

			staticMeshComponent.SetStaticMesh(StaticMesh.Plane);
			staticMeshComponent.SetMaterial(0, Material.Load("/Game/Tests/TextureMaterial"));
			staticMeshComponent.CreateAndSetMaterialInstanceDynamic(0).SetTextureParameterValue("Texture", texture);
			staticMeshComponent.SetWorldLocation(new Vector3(-800.0f, 0.0f, 0.0f));
			staticMeshComponent.SetWorldRotation(Maths.Euler(90.0f, 0.0f, 90.0f));

			Vector2 textureSize = default(Vector2);

			texture.GetSize(ref textureSize);

			Debug.AddOnScreenMessage(-1, 5.0f, Color.PowderBlue, "Texture size: " + textureSize);
		}

		public static void OnEndPlay() => Debug.ClearOnScreenMessages();
	}
}