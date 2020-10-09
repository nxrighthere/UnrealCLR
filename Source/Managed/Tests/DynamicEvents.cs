using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class DynamicEvents : ISystem {
		private PlayerController playerController;
		private TriggerBox triggerBox;
		private BoxComponent triggerCollisionComponent;
		private Actor leftActor;
		private Actor rightActor;
		private StaticMeshComponent leftStaticMeshComponent;
		private StaticMeshComponent rightStaticMeshComponent;
		private Material material;
		private bool stopTranslation;
		private const float startY = 450.0f;

		public DynamicEvents() {
			playerController = World.GetFirstPlayerController();
			triggerBox = new();
			triggerCollisionComponent = triggerBox.GetComponent<BoxComponent>();
			leftActor = new("LeftActor");
			rightActor = new("RightActor");
			leftStaticMeshComponent = new(leftActor, "LeftActorComponent", true);
			rightStaticMeshComponent = new(rightActor, "RightActorComponent", true);
			material = Material.Load("/Game/Tests/BasicMaterial");
			stopTranslation = false;
		}

		public void OnBeginPlay() {
			playerController.ShowMouseCursor = true;
			playerController.EnableClickEvents = true;
			playerController.EnableMouseOverEvents = true;
			playerController.SetViewTarget(World.GetActor<Camera>("MainCamera"));

			World.SetOnActorBeginOverlapCallback(OnActorBeginOverlap);
			World.SetOnActorEndOverlapCallback(OnActorEndOverlap);
			World.SetOnActorHitCallback(OnActorHit);
			World.SetOnActorBeginCursorOverCallback(OnActorBeginCursorOver);
			World.SetOnActorEndCursorOverCallback(OnActorEndCursorOver);
			World.SetOnActorClickedCallback(OnActorClicked);
			World.SetOnActorReleasedCallback(OnActorReleased);
			World.SetOnComponentBeginOverlapCallback(OnComponentBeginOverlap);
			World.SetOnComponentEndOverlapCallback(OnComponentEndOverlap);
			World.SetOnComponentHitCallback(OnComponentHit);
			World.SetOnComponentBeginCursorOverCallback(OnComponentBeginCursorOver);
			World.SetOnComponentEndCursorOverCallback(OnComponentEndCursorOver);
			World.SetOnComponentClickedCallback(OnComponentClicked);
			World.SetOnComponentReleasedCallback(OnComponentReleased);

			const float linesThickness = 3.0f;

			Vector3 collisionShape = new(200.0f, 200.0f, 200.0f);

			triggerCollisionComponent.SetBoxExtent(collisionShape);

			Debug.DrawBox(triggerCollisionComponent.GetLocation(), collisionShape, Quaternion.Identity, Color.Aqua, true, thickness: linesThickness);

			leftActor.RegisterEvent(ActorEventType.OnActorBeginOverlap);
			leftActor.RegisterEvent(ActorEventType.OnActorEndOverlap);
			leftActor.RegisterEvent(ActorEventType.OnActorHit);
			leftActor.RegisterEvent(ActorEventType.OnActorBeginCursorOver);
			leftActor.RegisterEvent(ActorEventType.OnActorEndCursorOver);
			leftActor.RegisterEvent(ActorEventType.OnActorClicked);
			leftActor.RegisterEvent(ActorEventType.OnActorReleased);

			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentBeginOverlap);
			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentEndOverlap);
			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentHit);
			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentBeginCursorOver);
			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentEndCursorOver);
			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentClicked);
			leftStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentReleased);
			leftStaticMeshComponent.SetGenerateOverlapEvents(true);
			leftStaticMeshComponent.SetGenerateHitEvents(true);

			leftStaticMeshComponent.SetStaticMesh(StaticMesh.Cube);
			leftStaticMeshComponent.SetMaterial(0, material);
			leftStaticMeshComponent.CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", LinearColor.Green);
			leftStaticMeshComponent.SetWorldLocation(new(0.0f, -startY, 0.0f));
			leftStaticMeshComponent.UpdateToWorld(TeleportType.ResetPhysics);
			leftStaticMeshComponent.SetEnableGravity(false);
			leftStaticMeshComponent.SetSimulatePhysics(true);

			Assert.IsNotNull(leftStaticMeshComponent.GetMaterial(0));

			rightActor.RegisterEvent(ActorEventType.OnActorBeginOverlap);
			rightActor.RegisterEvent(ActorEventType.OnActorEndOverlap);
			rightActor.RegisterEvent(ActorEventType.OnActorHit);
			rightActor.RegisterEvent(ActorEventType.OnActorBeginCursorOver);
			rightActor.RegisterEvent(ActorEventType.OnActorEndCursorOver);
			rightActor.RegisterEvent(ActorEventType.OnActorClicked);
			rightActor.RegisterEvent(ActorEventType.OnActorReleased);

			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentBeginOverlap);
			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentEndOverlap);
			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentHit);
			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentBeginCursorOver);
			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentEndCursorOver);
			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentClicked);
			rightStaticMeshComponent.RegisterEvent(ComponentEventType.OnComponentReleased);
			rightStaticMeshComponent.SetGenerateOverlapEvents(true);
			rightStaticMeshComponent.SetGenerateHitEvents(true);

			rightStaticMeshComponent.SetStaticMesh(StaticMesh.Cube);
			rightStaticMeshComponent.SetMaterial(0, material);
			rightStaticMeshComponent.CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", LinearColor.Yellow);
			rightStaticMeshComponent.SetWorldLocation(new(0.0f, startY, 0.0f));
			rightStaticMeshComponent.UpdateToWorld(TeleportType.ResetPhysics);
			rightStaticMeshComponent.SetEnableGravity(false);
			rightStaticMeshComponent.SetSimulatePhysics(true);

			Assert.IsNotNull(rightStaticMeshComponent.GetMaterial(0));
		}

		public void OnTick(float deltaTime) {
			Translate(leftStaticMeshComponent, 750.0f);
			Translate(rightStaticMeshComponent, -750.0f);

			Hit hit = default;

			if (playerController.GetHitResultUnderCursor(CollisionChannel.WorldDynamic, ref hit))
				Debug.AddOnScreenMessage(13, 3.0f, Color.CornflowerBlue, "Cursor hit " + hit.GetActor().Name);

			triggerBox.ForEachOverlappingActor(OnTriggerOverlapActor);
			triggerCollisionComponent.ForEachOverlappingComponent(OnTriggerOverlapComponent);
		}

		public void OnEndPlay() => Debug.ClearOnScreenMessages();

		private Action<Actor> OnTriggerOverlapActor = (actor) => {
			Debug.AddOnScreenMessage((int)(actor.ID % Int32.MaxValue), 3.0f, Color.Aqua, "Trigger box overlapped " + actor.Name);
		};

		private Action<StaticMeshComponent> OnTriggerOverlapComponent = (component) => {
			Debug.AddOnScreenMessage((int)(component.ID % Int32.MaxValue), 3.0f, Color.Aquamarine, "Trigger collision component overlapped " + component.Name);
		};

		private void Translate(StaticMeshComponent staticMeshComponent, float direction) {
			if (!stopTranslation) {
				Vector3 currentLocation = default;

				staticMeshComponent.GetLocation(ref currentLocation);

				currentLocation.Y += direction * World.DeltaTime;

				staticMeshComponent.SetWorldLocation(currentLocation);
			}
		}

		private void OnActorBeginOverlap(ActorReference overlapActor, ActorReference otherActor) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlapActor.ID == leftActor.ID ? Color.Lime : Color.Yellow, overlapActor.Name + " start overlapping " + otherActor.Name);

			Assert.IsNotNull(overlapActor.ToActor<Actor>());
			Assert.IsNotNull(otherActor.ToActor<Actor>());
		}

		private void OnActorEndOverlap(ActorReference overlapActor, ActorReference otherActor) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlapActor.ID == leftActor.ID ? Color.Lime : Color.Yellow, overlapActor.Name + " stop overlapping " + otherActor.Name);

			Assert.IsNotNull(overlapActor.ToActor<Actor>());
			Assert.IsNotNull(otherActor.ToActor<Actor>());
		}

		private void OnActorHit(ActorReference hitActor, ActorReference otherActor, in Vector3 normalImpulse, in Hit hit) {
			Debug.AddOnScreenMessage(1, 3.0f, hitActor.ID == leftActor.ID ? Color.Lime : Color.Yellow, hitActor.Name + " hit " + otherActor.Name);

			if (!stopTranslation) {
				leftStaticMeshComponent.AddImpulse(new(0.0f, -250.0f, 0.0f), velocityChange: true);
				leftStaticMeshComponent.AddTorqueInRadians(new(20.0f, 25.0f, 30.0f), accelerationChange: true);
				rightStaticMeshComponent.AddImpulse(new(0.0f, 250.0f, 0.0f), velocityChange: true);
				rightStaticMeshComponent.AddTorqueInRadians(new(-20.0f, -25.0f, -30.0f), accelerationChange: true);
				stopTranslation = true;
			}

			Assert.IsNotNull(hitActor.ToActor<Actor>());
			Assert.IsNotNull(otherActor.ToActor<Actor>());
			Assert.IsNotNull(hit.GetActor());
		}

		private void OnActorBeginCursorOver(ActorReference actor) {
			Debug.AddOnScreenMessage(2, 3.0f, Color.Plum, "Cursor moved over " + actor.Name);

			Assert.IsNotNull(actor.ToActor<Actor>());
		}

		private void OnActorEndCursorOver(ActorReference actor) {
			Debug.AddOnScreenMessage(3, 3.0f, Color.Plum, "Cursor moved off " + actor.Name);

			Assert.IsNotNull(actor.ToActor<Actor>());
		}

		private void OnActorClicked(ActorReference actor, string key) {
			Debug.AddOnScreenMessage(4, 3.0f, Color.Thistle, key + " clicked on " + actor.Name);

			if (key == Keys.LeftMouseButton)
				Debug.AddOnScreenMessage(5, 3.0f, Color.MistyRose, key + " validated on actor!");

			Assert.IsNotNull(actor.ToActor<Actor>());
		}

		private void OnActorReleased(ActorReference actor, string key) {
			Debug.AddOnScreenMessage(6, 3.0f, Color.Thistle, key + " released on " + actor.Name);

			if (key == Keys.LeftMouseButton)
				Debug.AddOnScreenMessage(5, 3.0f, Color.MistyRose, key + " validated on actor!");

			Assert.IsNotNull(actor.ToActor<Actor>());
		}

		private void OnComponentBeginOverlap(ComponentReference overlapComponent, ComponentReference otherComponent) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlapComponent.ID == leftStaticMeshComponent.ID ? Color.Lime : Color.Yellow, overlapComponent.Name + " start overlapping " + otherComponent.Name);

			Assert.IsNotNull(overlapComponent.ToComponent<StaticMeshComponent>());
			Assert.IsNotNull(otherComponent.ToComponent<BoxComponent>());
		}

		private void OnComponentEndOverlap(ComponentReference overlapComponent, ComponentReference otherComponent) {
			Debug.AddOnScreenMessage(-1, 3.0f, overlapComponent.ID == leftStaticMeshComponent.ID ? Color.Lime : Color.Yellow, overlapComponent.Name + " end overlapping " + otherComponent.Name);

			Assert.IsNotNull(overlapComponent.ToComponent<StaticMeshComponent>());
			Assert.IsNotNull(otherComponent.ToComponent<BoxComponent>());
		}

		private void OnComponentHit(ComponentReference hitComponent, ComponentReference otherComponent, in Vector3 normalImpulse, in Hit hit) {
			Debug.AddOnScreenMessage(7, 3.0f, hitComponent.ID == leftStaticMeshComponent.ID ? Color.Lime : Color.Yellow, hitComponent.Name + " hit " + otherComponent.Name);

			Assert.IsNotNull(hitComponent.ToComponent<StaticMeshComponent>());
			Assert.IsNotNull(otherComponent.ToComponent<StaticMeshComponent>());
			Assert.IsNotNull(hit.GetActor());
		}

		private void OnComponentBeginCursorOver(ComponentReference component) {
			Debug.AddOnScreenMessage(8, 3.0f, Color.Plum, "Cursor moved over " + component.Name);

			Assert.IsNotNull(component.ToComponent<StaticMeshComponent>());
		}

		private void OnComponentEndCursorOver(ComponentReference component) {
			Debug.AddOnScreenMessage(9, 3.0f, Color.Plum, "Cursor moved off " + component.Name);

			Assert.IsNotNull(component.ToComponent<StaticMeshComponent>());
		}

		private void OnComponentClicked(ComponentReference component, string key) {
			Debug.AddOnScreenMessage(10, 3.0f, Color.Thistle, key + " clicked on " + component.Name);

			if (key == Keys.LeftMouseButton)
				Debug.AddOnScreenMessage(11, 3.0f, Color.MistyRose, key + " validated on component!");

			Assert.IsNotNull(component.ToComponent<StaticMeshComponent>());
		}

		private void OnComponentReleased(ComponentReference component, string key) {
			Debug.AddOnScreenMessage(12, 3.0f, Color.Thistle, key + " released on " + component.Name);

			if (key == Keys.LeftMouseButton)
				Debug.AddOnScreenMessage(11, 3.0f, Color.MistyRose, key + " validated on component!");

			Assert.IsNotNull(component.ToComponent<StaticMeshComponent>());
		}
	}
}