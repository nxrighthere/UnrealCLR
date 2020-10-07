using System;
using System.Drawing;
using System.Numerics;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
    public class VirtualReality : ISystem {
        private Pawn pawnVR;
        private SceneComponent body;
        private MotionControllerComponent leftHand;
        private MotionControllerComponent rightHand;

        public VirtualReality() {
            pawnVR = new("PawnVR");
            body = new(pawnVR, "Root");
            leftHand = new(pawnVR, "LeftHand");
            rightHand = new(pawnVR, "RightHand");
        }

        public void OnBeginPlay() {
            Camera mainCamera = World.GetActor<Camera>("MainCamera");

            mainCamera.GetComponent<CameraComponent>().LockToHeadMountedDisplay = true;

            PlayerController playerController = World.GetFirstPlayerController();

            playerController.SetViewTarget(mainCamera);
            playerController.Possess(pawnVR);

            leftHand.DisplayDeviceModel = true;
            leftHand.SetTrackingMotionSource("Left");

            rightHand.DisplayDeviceModel = true;
            rightHand.SetTrackingMotionSource("Right");
        }

        public void OnTick(float deltaTime) {
            Debug.AddOnScreenMessage(1, 3.0f, Color.Yellow, "Head-mounted display is connected: " + HeadMountedDisplay.IsConnected);
            Debug.AddOnScreenMessage(2, 3.0f, Color.Yellow, "Device enabled: " + HeadMountedDisplay.Enabled);
            Debug.AddOnScreenMessage(3, 3.0f, Color.Yellow, "Device name: " + HeadMountedDisplay.DeviceName);
        }

        public void OnEndPlay() => Debug.ClearOnScreenMessages();
    }
}