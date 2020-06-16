using System.Drawing;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
    public static class AssertionConsistency {
        private static Actor actor = null;

        public static void OnBeginPlay() {
            Assert.IsFalse(true, "Is true");
            Assert.IsTrue(false, "Is false");
            Assert.IsNotNull(actor, "Is null");

            actor = new Actor();

            Assert.IsNull(actor, "Is not null");
        }
    }
}