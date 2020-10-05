using System.Drawing;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public class AssertionConsistency : ISystem {
		private Actor actor;

		public void OnBeginPlay() {
			Assert.IsFalse(true, "Is true");
			Assert.IsTrue(false, "Is false");
			Assert.IsNotNull(actor, "Is null");

			actor = new();

			Assert.IsNull(actor, "Is not null");
		}
	}
}