using System.Drawing;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
    public static class AssertionConsistency {
        private static Actor actor = null;

        public static void OnBeginPlay() {
            Assert.IsFalse(false, "Is false");
            Assert.IsTrue(true, "Is true");
            Assert.IsNull(actor, "Is null");

            actor = new Actor();

            Assert.IsNotNull(actor, "Is not null");
        }
    }
}