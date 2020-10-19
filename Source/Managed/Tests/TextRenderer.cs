using System;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class TextRenderer : ISystem {
		private Actor actor;
		private TextRenderComponent textRenderComponent;
		private Font font;
		private Material material;

		public TextRenderer() {
			actor = new("TextActor");
			textRenderComponent = new(actor);
			font = Font.Load("/Game/Tests/PlayFont");
			material = Material.Load("/Game/Tests/PlayFontMaterial");
		}

		public void OnBeginPlay() {
			textRenderComponent.SetFont(font);
			textRenderComponent.SetTextMaterial(material);
			textRenderComponent.SetText("WELCOME TO THE WORLD");
			textRenderComponent.SetHorizontalSpacingAdjustment(2.0f);
			textRenderComponent.SetHorizontalAlignment(HorizontalTextAligment.Center);
			textRenderComponent.SetVerticalAlignment(VerticalTextAligment.Center);
			textRenderComponent.SetWorldLocation(new Vector3(200.0f, 0.0f, 0.0f));
			textRenderComponent.SetWorldRotation(Maths.Euler(0.0f, 0.0f, 180.0f));
		}
	}
}