using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class TextureAssets : ISystem {
		public void OnBeginPlay() {
			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			Actor actor = new();
			StaticMeshComponent staticMeshComponent = new(actor, setAsRoot: true);
			Texture2D texture = Texture2D.Load("/Game/Tests/BasicTexture");

			staticMeshComponent.SetStaticMesh(StaticMesh.Plane);
			staticMeshComponent.SetMaterial(0, Material.Load("/Game/Tests/TextureMaterial"));
			staticMeshComponent.CreateAndSetMaterialInstanceDynamic(0).SetTextureParameterValue("Texture", texture);
			staticMeshComponent.SetWorldLocation(new(-800.0f, 0.0f, 0.0f));
			staticMeshComponent.SetWorldRotation(Maths.Euler(90.0f, 0.0f, 90.0f));

			Debug.AddOnScreenMessage(-1, 5.0f, Color.PowderBlue, "Texture size: " + texture.GetSize());
			Debug.AddOnScreenMessage(-1, 5.0f, Color.PowderBlue, "Pixel format: " + texture.GetPixelFormat());
		}

		public void OnEndPlay() => Debug.ClearOnScreenMessages();
	}
}