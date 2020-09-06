using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class DynamicEvents {
		private Actor leftActor;
		private Actor rightActor;
		private StaticMeshComponent leftStaticMeshComponent;
		private StaticMeshComponent rightStaticMeshComponent;
		private Material material;
		private bool stopTranslation;
		private const float startY = 450.0f;

		public DynamicEvents() {
			leftActor = new Actor("LeftActor");
			rightActor = new Actor("RightActor");
			leftStaticMeshComponent = new StaticMeshComponent(leftActor, "LeftActorComponent", true);
			rightStaticMeshComponent = new StaticMeshComponent(rightActor, "RightActorComponent", true);
			material = Material.Load("/Game/Tests/BasicMaterial");
			stopTranslation = false;
		}

		public void OnBeginPlay() {
			PlayerController playerController = World.GetFirstPlayerController();

			playerController.ShowMouseCursor = true;
			playerController.EnableMouseOverEvents = true;
			playerController.SetViewTarget(World.GetActor<Camera>("MainCamera"));

			World.SetOnActorBeginOverlapCallback(OnActorBeginOverlap);
			World.SetOnActorEndOverlapCallback(OnActorEndOverlap);
			World.SetOnActorHitCallback(OnActorHit);
			World.SetOnActorBeginCursorOverCallback(OnActorBeginCursorOver);
			World.SetOnActorEndCursorOverCallback(OnActorEndCursorOver);
			World.SetOnComponentBeginOverlapCallback(OnComponentBeginOverlap);
			World.SetOnComponentEndOverlapCallback(OnComponentEndOverlap);
			World.SetOnComponentHitCallback(OnComponentHit);
			World.SetOnComponentBeginCursorOverCallback(OnComponentBeginCursorOver);
			World.SetOnComponentEndCursorOverCallback(OnComponentEndCursorOver);

			const float linesThickness = 3.0f;

			TriggerBox triggerBox = new TriggerBox();
			BoxComponent collisionComponent = triggerBox.GetComponent<BoxComponent>();
			Vector3 collisionShape = new Vector3(200.0f, 200.0f, 200.0f);

			collisionComponent.SetBoxExtent(collisionShape);

			Debug.DrawBox(collisionComponent.GetLocation(), collisionShape, Quaternion.Identity, Color.Aqua, true, thickness: linesThickness);

			leftActor.RegisterEvent(ActorEventType.OnActorBeginOverlap);
			leftActor.RegisterEvent(ActorEventType.OnActorEndOverlap);
			leftActor.RegisterEvent(ActorEventType.OnActorHit);
			leftActor.RegisterEvent(ActorEventType.OnActorBeginCursorOver);
			leftActor.RegisterEvent(ActorEventType.OnActorEndCursorOver);

			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentBeginOverlap);
			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentEndOverlap);
			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentHit);
			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentBeginCursorOver);
			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentEndCursorOver);
			leftStaticMeshComponent.SetGenerateOverlapEvents(true);
			leftStaticMeshComponent.SetGenerateHitEvents(true);

			leftStaticMeshComponent.SetStaticMesh(StaticMesh.Cube);
			leftStaticMeshComponent.SetMaterial(0, material);
			leftStaticMeshComponent.CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", LinearColor.Green);
			leftStaticMeshComponent.SetWorldLocation(new Vector3(0.0f, -startY, 0.0f));
			leftStaticMeshComponent.UpdateToWorld(TeleportType.ResetPhysics);
			leftStaticMeshComponent.SetEnableGravity(false);
			leftStaticMeshComponent.SetSimulatePhysics(true);

			rightActor.RegisterEvent(ActorEventType.OnActorBeginOverlap);
			rightActor.RegisterEvent(ActorEventType.OnActorEndOverlap);
			rightActor.RegisterEvent(ActorEventType.OnActorHit);
			rightActor.RegisterEvent(ActorEventType.OnActorBeginCursorOver);
			rightActor.RegisterEvent(ActorEventType.OnActorEndCursorOver);

			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentBeginOverlap);
			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentEndOverlap);
			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentHit);
			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentBeginCursorOver);
			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentEndCursorOver);
			rightStaticMeshComponent.SetGenerateOverlapEvents(true);
			rightStaticMeshComponent.SetGenerateHitEvents(true);

			rightStaticMeshComponent.SetStaticMesh(StaticMesh.Cube);
			rightStaticMeshComponent.SetMaterial(0, material);
			rightStaticMeshComponent.CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", LinearColor.Yellow);
			rightStaticMeshComponent.SetWorldLocation(new Vector3(0.0f, startY, 0.0f));
			rightStaticMeshComponent.UpdateToWorld(TeleportType.ResetPhysics);
			rightStaticMeshComponent.SetEnableGravity(false);
			rightStaticMeshComponent.SetSimulatePhysics(true);
		}

		public void OnTick() {
			Translate(leftStaticMeshComponent, 750.0f);
			Translate(rightStaticMeshComponent, -750.0f);
		}

		public void OnEndPlay() => Debug.ClearOnScreenMessages();

		private void Translate(StaticMeshComponent staticMeshComponent, float direction) {
			if (!stopTranslation) {
				Vector3 currentLocation = default;

				staticMeshComponent.GetLocation(ref currentLocation);

				currentLocation.Y += direction * World.DeltaTime;

				staticMeshComponent.SetWorldLocation(currentLocation);
			}
		}

		private void OnActorBeginOverlap(ObjectReference overlapActor, ObjectReference otherActor) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlapActor.ID == leftActor.ID ? Color.Lime : Color.Yellow, overlapActor.Name + " start overlapping " + otherActor.Name);

			Assert.IsNotNull(overlapActor.ToActor<Actor>());
			Assert.IsNotNull(otherActor.ToActor<Actor>());
		}

		private void OnActorEndOverlap(ObjectReference overlapActor, ObjectReference otherActor) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlapActor.ID == leftActor.ID ? Color.Lime : Color.Yellow, overlapActor.Name + " stop overlapping " + otherActor.Name);

			Assert.IsNotNull(overlapActor.ToActor<Actor>());
			Assert.IsNotNull(otherActor.ToActor<Actor>());
		}

		private void OnActorHit(ObjectReference hitActor, ObjectReference otherActor, in Vector3 normalImpulse, in Hit hit) {
			Debug.AddOnScreenMessage(1, 3.0f, hitActor.ID == leftActor.ID ? Color.Lime : Color.Yellow, hitActor.Name + " hit " + otherActor.Name);

			if (!stopTranslation) {
				leftStaticMeshComponent.AddImpulse(new Vector3(0.0f, -250.0f, 0.0f), velocityChange: true);
				leftStaticMeshComponent.AddTorqueInRadians(new Vector3(20.0f, 25.0f, 30.0f), accelerationChange: true);
				rightStaticMeshComponent.AddImpulse(new Vector3(0.0f, 250.0f, 0.0f), velocityChange: true);
				rightStaticMeshComponent.AddTorqueInRadians(new Vector3(-20.0f, -25.0f, -30.0f), accelerationChange: true);
				stopTranslation = true;
			}

			Assert.IsNotNull(hitActor.ToActor<Actor>());
			Assert.IsNotNull(otherActor.ToActor<Actor>());
			Assert.IsNotNull(hit.GetActor());
		}

		private void OnActorBeginCursorOver(ObjectReference actor) {
			Debug.AddOnScreenMessage(2, 3.0f, Color.Plum, "Cursor moved over " + actor.Name);

			Assert.IsNotNull(actor.ToActor<Actor>());
		}

		private void OnActorEndCursorOver(ObjectReference actor) {
			Debug.AddOnScreenMessage(2, 3.0f, Color.Plum, "Cursor moved off " + actor.Name);

			Assert.IsNotNull(actor.ToActor<Actor>());
		}

		private void OnComponentBeginOverlap(ObjectReference overlapComponent, ObjectReference otherComponent) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlapComponent.ID == leftStaticMeshComponent.ID ? Color.Lime : Color.Yellow, overlapComponent.Name + " start overlapping " + otherComponent.Name);

			Assert.IsNotNull(overlapComponent.ToComponent<StaticMeshComponent>());
			Assert.IsNotNull(otherComponent.ToComponent<BoxComponent>());
		}

		private void OnComponentEndOverlap(ObjectReference overlapComponent, ObjectReference otherComponent) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlapComponent.ID == leftStaticMeshComponent.ID ? Color.Lime : Color.Yellow, overlapComponent.Name + " end overlapping " + otherComponent.Name);

			Assert.IsNotNull(overlapComponent.ToComponent<StaticMeshComponent>());
			Assert.IsNotNull(otherComponent.ToComponent<BoxComponent>());
		}

		private void OnComponentHit(ObjectReference hitComponent, ObjectReference otherComponent, in Vector3 normalImpulse, in Hit hit) {
			Debug.AddOnScreenMessage(3, 3.0f, hitComponent.ID == leftStaticMeshComponent.ID ? Color.Lime : Color.Yellow, hitComponent.Name + " hit " + otherComponent.Name);

			Assert.IsNotNull(hitComponent.ToComponent<StaticMeshComponent>());
			Assert.IsNotNull(otherComponent.ToComponent<StaticMeshComponent>());
			Assert.IsNotNull(hit.GetActor());
		}

		private void OnComponentBeginCursorOver(ObjectReference component) {
			Debug.AddOnScreenMessage(4, 3.0f, Color.Plum, "Cursor moved over " + component.Name);

			Assert.IsNotNull(component.ToComponent<StaticMeshComponent>());
		}

		private void OnComponentEndCursorOver(ObjectReference component) {
			Debug.AddOnScreenMessage(4, 3.0f, Color.Plum, "Cursor moved off " + component.Name);

			Assert.IsNotNull(component.ToComponent<StaticMeshComponent>());
		}
	}
}