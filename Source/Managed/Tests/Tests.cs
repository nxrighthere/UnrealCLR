using System;
using System.Drawing;
using UnrealEngine.Framework;

namespace Game {
	public static class Main {
		private static Entity[] entities = new Entity[32];

		public static void OnWorldBegin() {
			for (int i = 0; i < entities.Length; i++) {
				entities[i] = new Entity(nameof(Entity) + i);
				entities[i].OnBegin();
			}
		}

		public static void OnWorldPrePhysicsTick(float deltaTime) {
			for (int i = 0; i < entities.Length; i++) {
				if (entities[i].CanTick)
					entities[i].OnPrePhysicsTick(deltaTime);
			}
		}
	}

	public class Entity : Actor {
		public Entity(string name = null, bool canTick = true) : base(name) {
			CanTick = canTick;
		}

		public bool CanTick { get; set; }

		public void OnBegin() => Debug.AddOnScreenMessage(-1, 1.0f, Color.LightSeaGreen, Name + " begin!");

		public void OnPrePhysicsTick(float deltaTime) => Debug.AddOnScreenMessage(-1, 1.0f, Color.LightSteelBlue, Name + " tick!");
	}
}