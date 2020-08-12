using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class WorldEvents {
		private static Actor leftActor = new Actor("LeftActor");
		private static Actor rightActor = new Actor("RightActor");
		private static StaticMeshComponent leftStaticMeshComponent = new StaticMeshComponent(leftActor, setAsRoot: true);
		private static StaticMeshComponent rightStaticMeshComponent = new StaticMeshComponent(rightActor, setAsRoot: true);
		private static Material material = Material.Load("/Game/Tests/BasicMaterial");
		private static bool invertTranslation = false;
		private const float startY = 450.0f;

		public static void OnBeginPlay() {
			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, MethodBase.GetCurrentMethod().DeclaringType + " system started!");

			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));
			World.SetOnActorBeginOverlapCallback(OnActorBeginOverlap);
			World.SetOnActorEndOverlapCallback(OnActorEndOverlap);
			World.SetOnComponentBeginOverlapCallback(OnComponentBeginOverlap);
			World.SetOnComponentEndOverlapCallback(OnComponentEndOverlap);

			const float linesThickness = 3.0f;

			TriggerBox triggerBox = new TriggerBox();
			BoxComponent collisionComponent = triggerBox.GetComponent<BoxComponent>();
			Vector3 collisionLocation = new Vector3(0.0f, 0.0f, 0.0f);
			Vector3 collisionShape = new Vector3(200.0f, 200.0f, 200.0f);

			collisionComponent.GetLocation(ref collisionLocation);
			collisionComponent.SetBoxExtent(collisionShape);

			Debug.DrawBox(collisionLocation, collisionShape, Quaternion.Identity, Color.Aqua, true, thickness: linesThickness);

			leftActor.RegisterEvent(ActorEventType.OnActorBeginOverlap);
			leftActor.RegisterEvent(ActorEventType.OnActorEndOverlap);

			leftStaticMeshComponent.RegisterEvent(PrimitiveComponentEventType.OnComponentBeginOverlap);
			leftStaticMeshComponent.RegisterEvent(PrimitiveComponentEventType.OnComponentEndOverlap);
			leftStaticMeshComponent.SetStaticMesh(StaticMesh.Cube);
			leftStaticMeshComponent.SetMaterial(0, material);
			leftStaticMeshComponent.CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", LinearColor.Green);
			leftStaticMeshComponent.SetWorldLocation(new Vector3(0.0f, -startY, 0.0f));

			rightActor.RegisterEvent(ActorEventType.OnActorBeginOverlap);
			rightActor.RegisterEvent(ActorEventType.OnActorEndOverlap);

			rightStaticMeshComponent.RegisterEvent(PrimitiveComponentEventType.OnComponentBeginOverlap);
			rightStaticMeshComponent.RegisterEvent(PrimitiveComponentEventType.OnComponentEndOverlap);
			rightStaticMeshComponent.SetStaticMesh(StaticMesh.Cube);
			rightStaticMeshComponent.SetMaterial(0, material);
			rightStaticMeshComponent.CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", LinearColor.Yellow);
			rightStaticMeshComponent.SetWorldLocation(new Vector3(0.0f, startY, 0.0f));
		}

		public static void OnEndPlay() => Debug.ClearOnScreenMessages();

		public static void OnTick() {
			Translate(leftStaticMeshComponent, 300.0f);
			Translate(rightStaticMeshComponent, -300.0f);
		}

		private static void Translate(StaticMeshComponent staticMeshComponent, float direction) {
			Vector3 currentLocation = default(Vector3);

			staticMeshComponent.GetLocation(ref currentLocation);

			float currentY = MathF.Abs(currentLocation.Y);

			if (!invertTranslation && currentY <= 49.0f)
				invertTranslation = true;
			else if (invertTranslation && currentY >= startY)
				invertTranslation = false;

			currentLocation.Y += (invertTranslation ? -direction : direction) * World.DeltaTime;

			staticMeshComponent.SetWorldLocation(currentLocation);
		}

		private static void OnActorBeginOverlap(ObjectReference overlappedActor, ObjectReference otherActor) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlappedActor.ID == leftActor.ID ? Color.Lime : Color.Yellow, overlappedActor.Name + " start overlapping " + otherActor.Name);

			Assert.IsNotNull(overlappedActor.ToActor<Actor>());
			Assert.IsNotNull(otherActor.ToActor<Actor>());
		}

		private static void OnActorEndOverlap(ObjectReference overlappedActor, ObjectReference otherActor) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlappedActor.ID == leftActor.ID ? Color.Lime : Color.Yellow, overlappedActor.Name + " stop overlapping " + otherActor.Name);

			Assert.IsNotNull(overlappedActor.ToActor<Actor>());
			Assert.IsNotNull(otherActor.ToActor<Actor>());
		}

		private static void OnComponentBeginOverlap(ObjectReference overlappedComponent, ObjectReference otherComponent) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlappedComponent.ID == leftStaticMeshComponent.ID ? Color.Lime : Color.Yellow, overlappedComponent.Name + " start overlapping " + otherComponent.Name);

			Assert.IsNotNull(overlappedComponent.ToComponent<StaticMeshComponent>());
			Assert.IsNotNull(otherComponent.ToComponent<BoxComponent>());
		}

		private static void OnComponentEndOverlap(ObjectReference overlappedComponent, ObjectReference otherComponent) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlappedComponent.ID == leftStaticMeshComponent.ID ? Color.Lime : Color.Yellow, overlappedComponent.Name + " end overlapping " + otherComponent.Name);

			Assert.IsNotNull(overlappedComponent.ToComponent<StaticMeshComponent>());
			Assert.IsNotNull(otherComponent.ToComponent<BoxComponent>());
		}
	}
}