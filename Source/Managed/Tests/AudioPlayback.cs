using System;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using UnrealEngine.Framework;

namespace UnrealEngine.Tests {
	public static class AudioPlayback {
		public static void OnBeginPlay() {
			Debug.AddOnScreenMessage(-1, 3.0f, Color.LightGreen, MethodBase.GetCurrentMethod().DeclaringType + " system started!");

			Actor alarmSound = new Actor("AlarmSound");
			AudioComponent alarmAudioComponent = new AudioComponent(alarmSound);
			SoundWave alarmSoundWave = SoundWave.Load("/Game/Tests/AlarmSound");

			Debug.AddOnScreenMessage(-1, 5.0f, Color.PowderBlue, "Sound wave duration: " + alarmSoundWave.Duration + " seconds");

			alarmSoundWave.Loop = true;
			alarmAudioComponent.SetSound(alarmSoundWave);
			alarmAudioComponent.Play();

			Assert.IsTrue(alarmAudioComponent.IsPlaying);
		}

		public static void OnEndPlay() => Debug.ClearOnScreenMessages();
	}
}
