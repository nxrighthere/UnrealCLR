using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class RadialForce : ISystem {
		public void OnBeginPlay() {
			World.GetFirstPlayerController().SetViewTarget(World.GetActor<Camera>("MainCamera"));

			const int maxActors = 100;

			Actor[] actors = new Actor[maxActors];
			StaticMeshComponent[] staticMeshComponents = new StaticMeshComponent[maxActors];

			for (int i = 0; i < maxActors; i++) {
				actors[i] = new();
				staticMeshComponents[i] = new(actors[i], setAsRoot: true);
				staticMeshComponents[i].SetStaticMesh(StaticMesh.Cube);
				staticMeshComponents[i].SetMaterial(0, Material.Load("/Game/Tests/BasicMaterial"));
				staticMeshComponents[i].CreateAndSetMaterialInstanceDynamic(0).SetVectorParameterValue("Color", LinearColor.Red);
				staticMeshComponents[i].SetRelativeLocation(new Vector3(10000.0f, 0.0f, 0.0f));
				staticMeshComponents[i].UpdateToWorld(TeleportType.ResetPhysics);
				staticMeshComponents[i].SetSimulatePhysics(true);
				staticMeshComponents[i].SetCollisionChannel(CollisionChannel.PhysicsBody);
			}

			RadialForceComponent radialForceComponent = new(new(), setAsRoot: true);

			radialForceComponent.IgnoreOwningActor = true;
			radialForceComponent.ImpulseVelocityChange = true;
			radialForceComponent.LinearFalloff = true;
			radialForceComponent.ForceStrength = 10000000.0f;
			radialForceComponent.Radius = 1000;
			radialForceComponent.SetRelativeLocation(new(10000.0f, 0.0f, -100.0f));

			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, "Actors are spawned! Number of actors in the world: " + World.ActorCount);
		}

		public void OnEndPlay() => Debug.ClearOnScreenMessages();
	}
}