/*
 * Copyright (c) 2020 Stanislav Denisov (nxrighthere@gmail.com)
 *
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the GNU Lesser General Public License
 * (LGPL) version 3 with a static linking exception which accompanies this
 * distribution.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace UnrealEngine.Framework {
	// Internal

	internal static class Path {
		private static string project;

		// Determines the path of the project by parsing assembly location
		internal static string Project {
			get {
				if (project == null) {
					project = Assembly.GetExecutingAssembly().Location;
					project = project.Substring(0, project.IndexOf("Managed", StringComparison.CurrentCulture));
				}

				return project;
			}
		}
	}

	// Public

	/// <summary>
	/// Specifies the log level for an output log message
	/// </summary>
	public enum LogLevel : int {
		/// <summary>
		/// Logs are printed to console and log files
		/// </summary>
		Display,
		/// <summary>
		/// Logs are printed to console and log files with the yellow color
		/// </summary>
		Warning,
		/// <summary>
		/// Logs are printed to console and log files with the red color
		/// </summary>
		Error,
		/// <summary>
		/// Logs are printed to console and log files then crashes the application even if logging is disabled
		/// </summary>
		Fatal
	}

	/// <summary>
	/// Specifies how often a component is allowed to move
	/// </summary>
	public enum ComponentMobility : int {
		/// <summary>
		/// Movable objects can be moved and changed
		/// </summary>
		Movable,
		/// <summary>
		/// Static objects cannot be moved or changed
		/// - Allows baked lighting
		/// - Fastest rendering
		/// </summary>
		Static,
		/// <summary>
		/// A stationary light will only have its shadowing and bounced lighting from static geometry baked by <a href="https://docs.unrealengine.com/en-US/Engine/Rendering/LightingAndShadows/Lightmass/index.html">Lightmass</a>, all other lighting will be dynamic
		/// </summary>
		Stationary
	}

	/// <summary>
	/// Rules for attaching components
	/// </summary>
	public enum AttachmentTransformRule : int {
		/// <summary>
		/// Keeps current relative transform as the relative transform to the new parent
		/// </summary>
		KeepRelativeTransform,
		/// <summary>
		/// Automatically calculates the relative transform such that the attached component maintains the same world transform
		/// </summary>
		KeepWorldTransform,
		/// <summary>
		/// Snaps location and rotation to the attach point, calculates the relative scale so that the final world scale of the component remains the same
		/// </summary>
		SnapToTargetIncludingScale,
		/// <summary>
		/// Snaps the entire transform to target, including scale
		/// </summary>
		SnapToTargetNotIncludingScale
	}

	/// <summary>
	/// Specifies whether to teleport physics body or not
	/// </summary>
	public enum TeleportType : int {
		/// <summary>
		/// Don't teleport physics body
		/// </summary>
		None,
		/// <summary>
		/// Teleport physics body so that velocity remains the same and no collision occurs
		/// </summary>
		TeleportPhysics,
		/// <summary>
		/// Teleport physics body and reset physics state completely
		/// </summary>
		ResetPhysics
	}

	/// <summary>
	/// Specifies how to update transform during movement
	/// </summary>
	[Flags]
	public enum UpdateTransformFlags : int {
		/// <summary>
		/// Default update
		/// </summary>
		None = 0,
		/// <summary>
		/// Don't update the underlying physics
		/// </summary>
		SkipPhysicsUpdate = 1 << 0,
		/// <summary>
		/// The update is coming as a result of the parent updating
		/// </summary>
		PropagateFromParent = 1 << 1,
		/// <summary>
		/// Only update child transform if attached to parent via a socket
		/// </summary>
		OnlyUpdateIfUsingSocket = 1 << 2
	}

	/// <summary>
	/// Specifies focus priority for AI
	/// </summary>
	public enum AIFocusPriority : int {
		/// <summary/>
		Normal = 0,
		/// <summary/>
		Low = 1,
		/// <summary/>
		High = 2,
		/// <summary/>
		VeryHigh = 3
	}

	/// <summary>
	/// Specifies the animation mode
	/// </summary>
	public enum AnimationMode : int {
		/// <summary/>
		Blueprint,
		/// <summary/>
		Asset,
		/// <summary/>
		Custom
	}

	/// <summary>
	/// Specifies the projection mode for a camera
	/// </summary>
	public enum CameraProjectionMode : int {
		/// <summary/>
		Perspective,
		/// <summary/>
		Orthographic
	}

	/// <summary>
	/// Specifies the collision mode
	/// </summary>
	public enum CollisionMode : int {
		/// <summary>
		/// No collision
		/// </summary>
		NoCollision,
		/// <summary>
		/// Used for spatial queries (raycasts, sweeps, and overlaps)
		/// </summary>
		QueryOnly,
		/// <summary>
		/// Used for physics simulation (rigid bodies, and constraints)
		/// </summary>
		PhysicsOnly,
		/// <summary>
		/// Can be used for both spatial queries and physics simulation
		/// </summary>
		QueryAndPhysics
	}

	/// <summary>
	/// Specifies the window mode
	/// </summary>
	public enum WindowMode : int {
		/// <summary/>
		Fullscreen,
		/// <summary/>
		WindowedFullscreen,
		/// <summary/>
		Windowed
	}

	/// <summary>
	/// Specifies the type of fade to adjust audio volume
	/// </summary>
	public enum AudioFadeCurve : byte {
		/// <summary/>
		Linear,
		/// <summary/>
		Logarithmic,
		/// <summary/>
		SCurve,
		/// <summary/>
		Sin
	}

	/// <summary>
	/// Specifies how to blend when changing view targets
	/// </summary>
	public enum BlendType : int {
		/// <summary>
		/// A simple linear interpolation
		/// </summary>
		Linear,
		/// <summary>
		/// A slight ease in and ease out, but amount of ease cannot be tweaked
		/// </summary>
		Cubic,
		/// <summary>
		/// Immediately accelerates, but smoothly decelerates into the target, ease amount can be controlled
		/// </summary>
		EaseIn,
		/// <summary>
		/// Smoothly accelerates, but does not decelerate into the target, ease amount can be controlled
		/// </summary>
		EaseOut,
		/// <summary>
		/// Smoothly accelerates and decelerates, ease amount can be controlled
		/// </summary>
		EaseInOut
	}

	/// <summary>
	/// Specifies input behavior type
	/// </summary>
	public enum InputEvent : int {
		/// <summary>
		/// Key pressed
		/// </summary>
		Pressed = 0,
		/// <summary>
		/// Key released
		/// </summary>
		Released = 1,
		/// <summary>
		/// Key repeating
		/// </summary>
		Repeat = 2,
		/// <summary>
		/// Key double clicked
		/// </summary>
		DoubleClick = 3,
		/// <summary>
		/// Axis activated
		/// </summary>
		Axis = 4
	}

	/// <summary>
	/// Specifies the networking mode
	/// </summary>
	public enum NetMode : byte {
		/// <summary>
		/// A game without networking, with one or more local players
		/// </summary>
		Standalone,
		/// <summary>
		/// A server with no local players
		/// </summary>
		DedicatedServer,
		/// <summary>
		/// A server that also has a local player who is hosting the game, available to other players on the network
		/// </summary>
		ListenServer,
		/// <summary>
		/// A client connected to a server
		/// </summary>
		Client
	}

	/// <summary>
	/// A linear 32-bit floating-point RGBA color
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LinearColor : IEquatable<LinearColor> {
		private float r;
		private float g;
		private float b;
		private float a;

		/// <summary>
		/// Initializes a new instance the linear color
		/// </summary>
		public LinearColor(float red, float green, float blue, float alpha = 1.0f) {
			r = red;
			g = green;
			b = blue;
			a = alpha;
		}

		/// <summary>
		/// Initializes a new instance the linear color
		/// </summary>
		public LinearColor(Vector3 value, float alpha = 1.0f) {
			r = value.X;
			g = value.Y;
			b = value.Z;
			a = alpha;
		}

		/// <summary>
		/// Initializes a new instance the linear color
		/// </summary>
		public LinearColor(Vector4 value) {
			r = value.X;
			g = value.Y;
			b = value.Z;
			a = value.W;
		}

		/// <summary>
		/// Initializes a new instance the linear color
		/// </summary>
		public LinearColor(float[] values) {
			if (values == null)
				throw new ArgumentNullException(nameof(values));

			if (values.Length != 3 && values.Length != 4)
				throw new ArgumentOutOfRangeException(nameof(values));

			r = values[0];
			g = values[1];
			b = values[2];
			a = values.Length >= 4 ? values[3] : 1.0f;
		}

		/// <summary>
		/// Gets or sets the component at the specified index
		/// </summary>
		public float this[int index] {
			get {
				switch (index) {
					case 0: return r;
					case 1: return g;
					case 2: return b;
					case 3: return a;
				}

				throw new ArgumentOutOfRangeException(nameof(index));
			}

			set {
				switch (index) {
					case 0: r = value; break;
					case 1: g = value; break;
					case 2: b = value; break;
					case 3: a = value; break;
					default: throw new ArgumentOutOfRangeException(nameof(index));
				}
			}
		}

		/// <summary>
		/// Gets or sets the red component of the color
		/// </summary>
		public float R {
			get => r;
			set => r = value;
		}

		/// <summary>
		/// Gets or sets the green component of the color
		/// </summary>
		public float G {
			get => g;
			set => g = value;
		}

		/// <summary>
		/// Gets or sets the blue component of the color
		/// </summary>
		public float B {
			get => b;
			set => b = value;
		}

		/// <summary>
		/// Gets or sets the alpha component of the color
		/// </summary>
		public float A {
			get => a;
			set => a = value;
		}

		/// <summary>
		/// The black color
		/// </summary>
		public static LinearColor Black => new LinearColor(0.0f, 0.0f, 0.0f, 1.0f);

		/// <summary>
		/// The blue color
		/// </summary>
		public static LinearColor Blue => new LinearColor(0.0f, 0.0f, 1.0f, 1.0f);

		/// <summary>
		/// The green color
		/// </summary>
		public static LinearColor Green => new LinearColor(0.0f, 1.0f, 0.0f, 1.0f);

		/// <summary>
		/// The grey color
		/// </summary>
		public static LinearColor Grey => new LinearColor(0.5f, 0.5f, 0.5f, 1.0f);

		/// <summary>
		/// The red color
		/// </summary>
		public static LinearColor Red => new LinearColor(1.0f, 0.0f, 0.0f, 1.0f);

		/// <summary>
		/// The white color
		/// </summary>
		public static LinearColor White => new LinearColor(1.0f, 1.0f, 1.0f, 1.0f);

		/// <summary>
		/// The yellow color
		/// </summary>
		public static LinearColor Yellow => new LinearColor(1.0f, 1.0f, 0.0f, 1.0f);

		/// <summary>
		/// Tests for equality between two linear color objects
		/// </summary>
		public static bool operator ==(LinearColor left, LinearColor right) => left.Equals(right);

		/// <summary>
		/// Tests for inequality between two linear color objects
		/// </summary>
		public static bool operator !=(LinearColor left, LinearColor right) => !left.Equals(right);

		/// <summary>
		/// Adds two colors
		/// </summary>
		public static LinearColor operator +(LinearColor left, LinearColor right) => new LinearColor(left.r + right.r, left.g + right.g, left.b + right.b, left.a + right.a);

		/// <summary>
		/// Subtracts two colors
		/// </summary>
		public static LinearColor operator -(LinearColor left, LinearColor right) => new LinearColor(left.b - right.b, left.g - right.g, left.b - right.b, left.a - right.a);

		/// <summary>
		/// Multiplies two colors
		/// </summary>
		public static LinearColor operator *(float scale, LinearColor value) => new LinearColor(value.r * scale, value.g * scale, value.b * scale, value.a * scale);

		/// <summary>
		/// Divides two colors
		/// </summary>
		public static LinearColor operator /(float scale, LinearColor value) => new LinearColor(value.r / scale, value.g / scale, value.b / scale, value.a / scale);

		/// <summary>
		/// Implicitly casts this instance to a string
		/// </summary>
		public static implicit operator string(LinearColor value) => value.ToString();

		/// <summary>
		/// Adds two colors
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearColor Add(LinearColor left, LinearColor right) => new LinearColor(left.r + right.r, left.g + right.g, left.b + right.b, left.a + right.a);

		/// <summary>
		/// Subtracts two colors
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearColor Subtract(LinearColor left, LinearColor right) => new LinearColor(left.r - right.r, left.g - right.g, left.b - right.b, left.a - right.a);

		/// <summary>
		/// Multiplies two colors
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearColor Multiply(LinearColor left, LinearColor right) => new LinearColor(left.r * right.r, left.g * right.g, left.b * right.b, left.a * right.a);

		/// <summary>
		/// Divides two colors
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearColor Divide(LinearColor left, LinearColor right) => new LinearColor(left.r / right.r, left.g / right.g, left.b / right.b, left.a / right.a);

		/// <summary>
		/// Performs a linear interpolation between two colors
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearColor Lerp(LinearColor start, LinearColor end, float amount) => new LinearColor(Maths.Lerp(start.r, end.r, amount), Maths.Lerp(start.g, end.g, amount), Maths.Lerp(start.b, end.b, amount), Maths.Lerp(start.a, end.a, amount));

		/// <summary>
		/// Converts the color into a three component vector
		/// </summary>
		public Vector3 ToVector3() => new Vector3(r, g, b);

		/// <summary>
		/// Converts the color into a four component vector
		/// </summary>
		public Vector4 ToVector4() => new Vector4(r, g, b, a);

		/// <summary>
		/// Creates an array containing the elements of the color
		/// </summary>
		public float[] ToArray() => new[] { r, g, b, a };

		/// <summary>
		/// Returns a string that represents this instance
		/// </summary>
		public override string ToString() => ToString(CultureInfo.CurrentCulture);

		/// <summary>
		/// Returns a string that represents this instance
		/// </summary>
		public string ToString(IFormatProvider formatProvider) => string.Format(formatProvider, "R:{0} G:{1} B:{2} A:{3}", R, G, B, A);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(LinearColor other) => r == other.r && g == other.g && b == other.b && a == other.a;

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public override bool Equals(object value) {
			if (value == null)
				return false;

			if (!ReferenceEquals(value.GetType(), typeof(LinearColor)))
				return false;

			return Equals((LinearColor)value);
		}

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => HashCode.Combine(r, g, b, a);
	}

	/// <summary>
	/// Transform composed of location, rotation, and scale
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Transform : IEquatable<Transform> {
		private Vector3 location;
		private Quaternion rotation;
		private Vector3 scale;

		/// <summary>
		/// Initializes a new instance the transform
		/// </summary>
		public Transform(Vector3 location = default, Quaternion rotation = default, Vector3 scale = default) {
			this.location = location;
			this.rotation = rotation;
			this.scale = scale;
		}

		/// <summary>
		/// Gets or sets the location component
		/// </summary>
		public Vector3 Location {
			get => location;
			set => location = value;
		}

		/// <summary>
		/// Gets or sets the rotation component
		/// </summary>
		public Quaternion Rotation {
			get => rotation;
			set => rotation = value;
		}

		/// <summary>
		/// Gets or sets the scale component
		/// </summary>
		public Vector3 Scale {
			get => scale;
			set => scale = value;
		}

		/// <summary>
		/// Tests for equality between two transform objects
		/// </summary>
		public static bool operator ==(Transform left, Transform right) => left.Equals(right);

		/// <summary>
		/// Tests for inequality between two transform objects
		/// </summary>
		public static bool operator !=(Transform left, Transform right) => !left.Equals(right);

		/// <summary>
		/// Implicitly casts this instance to a string
		/// </summary>
		public static implicit operator string(Transform value) => value.ToString();

		/// <summary>
		/// Returns a string that represents this instance
		/// </summary>
		public override string ToString() => ToString(CultureInfo.CurrentCulture);

		/// <summary>
		/// Returns a string that represents this instance
		/// </summary>
		public string ToString(IFormatProvider formatProvider) => string.Format(formatProvider, "Location:{0} Rotation:{1} Scale:{2}", Location, Rotation, Scale);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(Transform other) => location == other.location && rotation == other.rotation && scale == other.scale;

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public override bool Equals(object value) {
			if (value == null)
				return false;

			if (!ReferenceEquals(value.GetType(), typeof(Transform)))
				return false;

			return Equals((Transform)value);
		}

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => HashCode.Combine(location, rotation, scale);
	}

	/// <summary>
	/// Delegate for action events
	/// </summary>
	public delegate void InputDelegate();

	/// <summary>
	/// Delegate for axis events
	/// </summary>
	public delegate void InputAxisDelegate(float axisValue);

	/// <summary>
	/// Delegate for console variable events
	/// </summary>
	public delegate void ConsoleVariableDelegate();

	/// <summary>
	/// Delegate for console command events
	/// </summary>
	public delegate void ConsoleCommandDelegate(float value);

	/// <summary>
	/// Provides additional static constants and methods for mathematical functions that are lack in <see cref="System.Math"/>, <see cref="System.MathF"/>, and <see cref="System.Numerics"/>
	/// </summary>
	public static class Maths {
		/// <summary>
		/// Degrees-to-radians conversion constant
		/// </summary>
		public const float DegToRadF = MathF.PI * 2.0f / 360.0f;

		/// <summary>
		/// Radians-to-degrees conversion constant
		/// </summary>
		public const float RadToDegF = 1.0f / DegToRadF;

		// Double-precision

		/// <summary>
		/// Returns the dot product of two float values
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Dot(double left, double right) => left * right;

		/// <summary>
		/// Clamps value between 0.0d and 1.0d
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Saturate(double value) => value < 0.0d ? 0.0d : value > 1.0d ? 1.0d : value;

		/// <summary>
		/// Returns the fractional part of a float value
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Fraction(double value) => value - Math.Floor(value);

		/// <summary>
		/// Calculates the shortest difference between two given angles given in degrees
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double DeltaAngle(double current, double target) {
			double delta = Repeat((target - current), 360.0d);

			if (delta > 180.0d)
				delta -= 360.0d;

			return delta;
		}

		/// <summary>
		/// Returns the next power of two
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double NextPowerOfTwo(double value) => Math.Pow(2.0d, Math.Ceiling(Math.Log(value, 2.0d)));

		/// <summary>
		/// Returns the previous power of two
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double PreviousPowerOfTwo(double value) => Math.Pow(2.0d, Math.Floor(Math.Log(value, 2.0d)));

		/// <summary>
		/// Performs smooth (Cubic Hermite) interpolation between 0.0d and 1.0d
		/// </summary>
		/// <param name="amount">Value between 0.0d and 1.0d indicating interpolation amount</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double SmoothStep(double amount) => (amount <= 0.0d) ? 0.0d : (amount >= 1.0d) ? 1.0d : amount * amount * (3.0d - (2.0d * amount));

		/// <summary>
		/// Performs a smoother interpolation between 0.0d and 1.0d with 1st and 2nd order derivatives of zero at endpoints
		/// </summary>
		/// <param name="amount">>Value between 0.0d and 1.0d indicating interpolation amount</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double SmootherStep(double amount) => (amount <= 0.0d) ? 0.0d : (amount >= 1.0d) ? 1.0d : amount * amount * amount * (amount * ((amount * 6.0d) - 15.0d) + 10.0d);

		/// <summary>
		/// Loops the value so that it is never larger than length and never smaller than 0.0d
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Repeat(double value, double length) => Math.Clamp(value - Math.Floor(value / length) * length, 0.0d, length);

		/// <summary>
		/// Interpolates between two values linearly
		/// </summary>
		/// <param name="from">Value to interpolate from</param>
		/// <param name="to">Value to interpolate to</param>
		/// <param name="amount">Interpolation amount</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Lerp(double from, double to, double amount) => from + amount * (to - from);

		/// <summary>
		/// Interpolates between two values linearly, but makes sure the values calculated correctly when they wrap around 360 degrees
		/// </summary>
		/// <param name="from">Value to interpolate from</param>
		/// <param name="to">Value to interpolate to</param>
		/// <param name="amount">Interpolation amount</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double LerpAngle(double from, double to, double amount) {
			double delta = Repeat((to - from), 360.0d);

			if (delta > 180.0d)
				delta -= 360.0d;

			return from + delta * Saturate(amount);
		}

		/// <summary>
		/// Inverse-interpolates between two values linearly
		/// </summary>
		/// <param name="from">Value to interpolate from</param>
		/// <param name="to">Value to interpolate to</param>
		/// <param name="amount">Interpolation amount</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double InverseLerp(double from, double to, double amount) => from != to ? Saturate((amount - from) / (to - from)) : 0.0d;

		/// <summary>
		/// Creates framerate-independent dampened motion between two values
		/// </summary>
		/// <param name="from">Value to damp from</param>
		/// <param name="to">Value to damp to</param>
		/// <param name="lambda">Smoothing factor</param>
		/// <param name="deltaTime">Time since last damp</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double Damp(double from, double to, double lambda, double deltaTime) => Lerp(from, to, 1.0d - Math.Exp(-lambda * deltaTime));

		/// <summary>
		/// Returns the vector moved towards a target
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double MoveTowards(double current, double target, double maxDelta) => Math.Abs(target - current) <= maxDelta ? target : current + Math.Sign(target - current) * maxDelta;

		/// <summary>
		/// Returns the vector moved towards a target, but makes sure the values calculated correctly when they wrap around 360 degrees
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double MoveTowardsAngle(double current, double target, double maxDelta) {
			double deltaAngle = DeltaAngle(current, target);

			if (-maxDelta < deltaAngle && deltaAngle < maxDelta)
				return target;

			target = current + deltaAngle;

			return MoveTowards(current, target, maxDelta);
		}

		// Single-precision

		/// <summary>
		/// Clamps the specified value
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Clamp(float value, float min, float max) => value < min ? min : value > max ? max : value;

		/// <summary>
		/// Returns the dot product of two float values
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Dot(float left, float right) => left * right;

		/// <summary>
		/// Clamps value between 0.0f and 1.0f
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Saturate(float value) => value < 0.0f ? 0.0f : value > 1.0f ? 1.0f : value;

		/// <summary>
		/// Returns the fractional part of a float value
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Fraction(float value) => value - MathF.Floor(value);

		/// <summary>
		/// Calculates the shortest difference between two given angles given in degrees
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float DeltaAngle(float current, float target) {
			float delta = Repeat((target - current), 360.0f);

			if (delta > 180.0f)
				delta -= 360.0f;

			return delta;
		}

		/// <summary>
		/// Returns the next power of two
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float NextPowerOfTwo(float value) => MathF.Pow(2.0f, MathF.Ceiling(MathF.Log(value, 2.0f)));

		/// <summary>
		/// Returns the previous power of two
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float PreviousPowerOfTwo(float value) => MathF.Pow(2.0f, MathF.Floor(MathF.Log(value, 2.0f)));

		/// <summary>
		/// Performs smooth (Cubic Hermite) interpolation between 0.0f and 1.0f
		/// </summary>
		/// <param name="amount">Value between 0.0f and 1.0f indicating interpolation amount</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SmoothStep(float amount) => (amount <= 0.0f) ? 0.0f : (amount >= 1.0f) ? 1.0f : amount * amount * (3.0f - (2.0f * amount));

		/// <summary>
		/// Performs a smoother interpolation between 0.0f and 1.0f with 1st and 2nd order derivatives of zero at endpoints
		/// </summary>
		/// <param name="amount">>Value between 0.0f and 1.0f indicating interpolation amount</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SmootherStep(float amount) => (amount <= 0.0f) ? 0.0f : (amount >= 1.0f) ? 1.0f : amount * amount * amount * (amount * ((amount * 6.0f) - 15.0f) + 10.0f);

		/// <summary>
		/// Loops the value so that it is never larger than length and never smaller than 0.0f
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Repeat(float value, float length) => Clamp(value - MathF.Floor(value / length) * length, 0.0f, length);

		/// <summary>
		/// Interpolates between two values linearly
		/// </summary>
		/// <param name="from">Value to interpolate from</param>
		/// <param name="to">Value to interpolate to</param>
		/// <param name="amount">Interpolation amount</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Lerp(float from, float to, float amount) => from + amount * (to - from);

		/// <summary>
		/// Interpolates between two values linearly, but makes sure the values calculated correctly when they wrap around 360 degrees
		/// </summary>
		/// <param name="from">Value to interpolate from</param>
		/// <param name="to">Value to interpolate to</param>
		/// <param name="amount">Interpolation amount</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float LerpAngle(float from, float to, float amount) {
			float delta = Repeat((to - from), 360.0f);

			if (delta > 180.0f)
				delta -= 360.0f;

			return from + delta * Saturate(amount);
		}

		/// <summary>
		/// Inverse-interpolates between two values linearly
		/// </summary>
		/// <param name="from">Value to interpolate from</param>
		/// <param name="to">Value to interpolate to</param>
		/// <param name="amount">Interpolation amount</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float InverseLerp(float from, float to, float amount) => from != to ? Saturate((amount - from) / (to - from)) : 0.0f;

		/// <summary>
		/// Creates framerate-independent dampened motion between two values
		/// </summary>
		/// <param name="from">Value to damp from</param>
		/// <param name="to">Value to damp to</param>
		/// <param name="lambda">Smoothing factor</param>
		/// <param name="deltaTime">Time since last damp</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Damp(float from, float to, float lambda, float deltaTime) => Lerp(from, to, 1.0f - MathF.Exp(-lambda * deltaTime));

		/// <summary>
		/// Returns the vector moved towards a target
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float MoveTowards(float current, float target, float maxDelta) => MathF.Abs(target - current) <= maxDelta ? target : current + MathF.Sign(target - current) * maxDelta;

		/// <summary>
		/// Returns the vector moved towards a target, but makes sure the values calculated correctly when they wrap around 360 degrees
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float MoveTowardsAngle(float current, float target, float maxDelta) {
			float deltaAngle = DeltaAngle(current, target);

			if (-maxDelta < deltaAngle && deltaAngle < maxDelta)
				return target;

			target = current + deltaAngle;

			return MoveTowards(current, target, maxDelta);
		}

		// Vector2

		/// <summary>
		/// Returns the length of the vector
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Magnitude(Vector2 value) => MathF.Sqrt(SquareMagnitude(value));

		/// <summary>
		/// Returns the squared length of the vector
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SquareMagnitude(Vector2 value) => Vector2.Dot(value, value);

		/// <summary>
		/// Returns the refraction vector
		/// </summary>
		/// <param name="value">The incident vector</param>
		/// <param name="normal">The normal vector</param>
		/// <param name="eta">The refraction index</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Refract(Vector2 value, Vector2 normal, float eta) {
			float ni = Vector2.Dot(normal, value);
			float k = 1.0f - eta * eta * (1.0f - ni * ni);

			return k >= 0.0f ? eta * value - (eta * ni + MathF.Sqrt(k)) * normal : Vector2.Zero;
		}

		/// <summary>
		/// Returns the vector perpendicular to the specified vector
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Perpendicular(Vector2 value) => new Vector2(-value.Y, value.X);

		/// <summary>
		/// Returns the unsigned angle in degrees
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Angle(Vector2 left, Vector2 right) {
			Vector2 lr = left * Magnitude(right);
			Vector2 rl = right * Magnitude(left);

			return 2.0f * MathF.Atan2(Magnitude(lr - rl), Magnitude(lr + rl)) * RadToDegF;
		}

		/// <summary>
		/// Returns a copy of vector with clamped magnitude
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 ClampMagnitude(Vector2 value, float maxLength) {
			float squareMagnitude = SquareMagnitude(value);

			if (squareMagnitude > maxLength * maxLength) {
				float magnitude = MathF.Sqrt(squareMagnitude);

				return new Vector2((value.X / magnitude) * maxLength, (value.Y / magnitude) * maxLength);
			}

			return value;
		}

		/// <summary>
		/// Creates framerate-independent dampened motion between two values
		/// </summary>
		/// <param name="from">Value to damp from</param>
		/// <param name="to">Value to damp to</param>
		/// <param name="lambda">Smoothing factor</param>
		/// <param name="deltaTime">Time since last damp</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Damp(Vector2 from, Vector2 to, float lambda, float deltaTime) => Vector2.Lerp(from, to, 1.0f - MathF.Exp(-lambda * deltaTime));

		/// <summary>
		/// Returns the vector moved towards a target
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta) {
			Vector2 destination = Vector2.Subtract(target, current);

			float squareMagnitude = SquareMagnitude(destination);

			if (squareMagnitude == 0.0f || (maxDistanceDelta >= 0.0f && squareMagnitude <= maxDistanceDelta * maxDistanceDelta))
				return target;

			float distance = MathF.Sqrt(squareMagnitude);

			return new Vector2(current.X + destination.X / distance * maxDistanceDelta, current.Y + destination.Y / distance * maxDistanceDelta);
		}

		// Vector3

		/// <summary>
		/// Returns the length of the vector
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Magnitude(Vector3 value) => MathF.Sqrt(SquareMagnitude(value));

		/// <summary>
		/// Returns the squared length of the vector
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SquareMagnitude(Vector3 value) => Vector3.Dot(value, value);

		/// <summary>
		/// Returns the refraction vector
		/// </summary>
		/// <param name="value">The incident vector</param>
		/// <param name="normal">The normal vector</param>
		/// <param name="eta">The refraction index</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Refract(Vector3 value, Vector3 normal, float eta) {
			float ni = Vector3.Dot(normal, value);
			float k = 1.0f - eta * eta * (1.0f - ni * ni);

			return k >= 0.0f ? eta * value - (eta * ni + MathF.Sqrt(k)) * normal : Vector3.Zero;
		}

		/// <summary>
		/// Returns the unsigned angle in degrees
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Angle(Vector3 left, Vector3 right) {
			Vector3 lr = left * Magnitude(right);
			Vector3 rl = right * Magnitude(left);

			return 2.0f * MathF.Atan2(Magnitude(lr - rl), Magnitude(lr + rl)) * RadToDegF;
		}

		/// <summary>
		/// Returns the signed angle in degrees
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SignedAngle(Vector3 left, Vector3 right, Vector3 axis) {
			Vector3 cross = Vector3.Cross(left, right);

			return Angle(left, right) * MathF.Sign(Vector3.Dot(axis, cross));
		}

		/// <summary>
		/// Returns a copy of vector with clamped magnitude
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ClampMagnitude(Vector3 value, float maxLength) {
			float squareMagnitude = SquareMagnitude(value);

			if (squareMagnitude > maxLength * maxLength) {
				float magnitude = MathF.Sqrt(squareMagnitude);

				return new Vector3((value.X / magnitude) * maxLength, (value.Y / magnitude) * maxLength, (value.Z / magnitude) * maxLength);
			}

			return value;
		}

		/// <summary>
		/// Creates framerate-independent dampened motion between two values
		/// </summary>
		/// <param name="from">Value to damp from</param>
		/// <param name="to">Value to damp to</param>
		/// <param name="lambda">Smoothing factor</param>
		/// <param name="deltaTime">Time since last damp</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Damp(Vector3 from, Vector3 to, float lambda, float deltaTime) => Vector3.Lerp(from, to, 1.0f - MathF.Exp(-lambda * deltaTime));

		/// <summary>
		/// Returns the vector moved towards a target
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta) {
			Vector3 destination = Vector3.Subtract(target, current);

			float squareMagnitude = SquareMagnitude(destination);

			if (squareMagnitude == 0.0f || (maxDistanceDelta >= 0.0f && squareMagnitude <= maxDistanceDelta * maxDistanceDelta))
				return target;

			float distance = MathF.Sqrt(squareMagnitude);

			return new Vector3(current.X + destination.X / distance * maxDistanceDelta, current.Y + destination.Y / distance * maxDistanceDelta, current.Z + destination.Z / distance * maxDistanceDelta);
		}

		/// <summary>
		/// Projects a vector onto another vector
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Project(Vector3 value, Vector3 normal) {
			float squareMagnitude = SquareMagnitude(normal);

			if (squareMagnitude < float.Epsilon)
				return Vector3.Zero;

			float dot = Vector3.Dot(value, normal);

			return new Vector3(normal.X * dot / squareMagnitude, normal.Y * dot / squareMagnitude, normal.Z * dot / squareMagnitude);
		}

		/// <summary>
		/// Projects a vector onto a plane defined by a normal orthogonal to the plane
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ProjectOnPlane(Vector3 value, Vector3 planeNormal) {
			float squareMagnitude = SquareMagnitude(planeNormal);

			if (squareMagnitude < float.Epsilon)
				return value;

			float dot = Vector3.Dot(value, planeNormal);

			return new Vector3(value.X - planeNormal.X * dot / squareMagnitude, value.Y - planeNormal.Y * dot / squareMagnitude, value.Z - planeNormal.Z * dot / squareMagnitude);
		}

		// Vector4

		/// <summary>
		/// Returns the length of the vector
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Magnitude(Vector4 value) => MathF.Sqrt(SquareMagnitude(value));

		/// <summary>
		/// Returns the squared length of the vector
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SquareMagnitude(Vector4 value) => Vector4.Dot(value, value);

		/// <summary>
		/// Returns the refraction vector
		/// </summary>
		/// <param name="value">The incident vector</param>
		/// <param name="normal">The normal vector</param>
		/// <param name="eta">The refraction index</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4 Refract(Vector4 value, Vector4 normal, float eta) {
			float ni = Vector4.Dot(normal, value);
			float k = 1.0f - eta * eta * (1.0f - ni * ni);

			return k >= 0.0f ? eta * value - (eta * ni + MathF.Sqrt(k)) * normal : Vector4.Zero;
		}

		// Quaternion

		/// <summary>
		/// Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion Euler(float x, float y, float z) {
			x *= DegToRadF;
			y *= DegToRadF;
			z *= DegToRadF;

			return Quaternion.CreateFromYawPitchRoll(y, x, z);
		}

		/// <summary>
		/// Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion Euler(Vector3 eulerAngles) => Euler(eulerAngles.X, eulerAngles.Y, eulerAngles.Z);

		/// <summary>
		/// Returns the unsigned angle in degrees
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Angle(Quaternion from, Quaternion to) {
			float dot = Quaternion.Dot(from, to);

			return dot > 1.0f - 0.000001f ? 0.0f : MathF.Acos(MathF.Min(MathF.Abs(dot), 1.0f)) * 2.0f * RadToDegF;
		}

		/// <summary>
		///	Returns a rotation which rotates angle degrees around axis
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion AngleAxis(float angle, Vector3 axis) {
			axis = axis * DegToRadF;
			axis = Vector3.Normalize(axis);

			float halfAngle = angle * DegToRadF * 0.5f;
			float sin = MathF.Sin(halfAngle);

			return new Quaternion(axis.X * sin, axis.Y * sin, axis.Z * sin, MathF.Cos(halfAngle));
		}

		/// <summary>
		/// Creates framerate-independent dampened motion between two values
		/// </summary>
		/// <param name="from">Value to damp from</param>
		/// <param name="to">Value to damp to</param>
		/// <param name="lambda">Smoothing factor</param>
		/// <param name="deltaTime">Time since last damp</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion Damp(Quaternion from, Quaternion to, float lambda, float deltaTime) => Quaternion.Slerp(from, to, 1.0f - MathF.Exp(-lambda * deltaTime));

		/// <summary>
		///	Returns a rotation which rotated towards a target
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta) {
			float angle = Angle(from, to);

			if (angle == 0.0f)
				return to;

			return Quaternion.Slerp(from, to, MathF.Min(1.0f, maxDegreesDelta / angle));
		}
	}

	/// <summary>
	/// Key codes
	/// </summary>
	public static class Keys {
		/// <summary/>
		public const string AnyKey = "AnyKey";

		/// <summary/>
		public const string MouseX = "MouseX";
		/// <summary/>
		public const string MouseY = "MouseY";
		/// <summary/>
		public const string MouseScrollUp = "MouseScrollUp";
		/// <summary/>
		public const string MouseScrollDown = "MouseScrollDown";
		/// <summary/>
		public const string MouseWheelAxis = "MouseWheelAxis";

		/// <summary/>
		public const string LeftMouseButton = "LeftMouseButton";
		/// <summary/>
		public const string RightMouseButton = "RightMouseButton";
		/// <summary/>
		public const string MiddleMouseButton = "MiddleMouseButton";
		/// <summary/>
		public const string ThumbMouseButton = "ThumbMouseButton";
		/// <summary/>
		public const string ThumbMouseButton2 = "ThumbMouseButton2";

		/// <summary/>
		public const string BackSpace = "BackSpace";
		/// <summary/>
		public const string Tab = "Tab";
		/// <summary/>
		public const string Enter = "Enter";
		/// <summary/>
		public const string Pause = "Pause";

		/// <summary/>
		public const string CapsLock = "CapsLock";
		/// <summary/>
		public const string Escape = "Escape";
		/// <summary/>
		public const string SpaceBar = "SpaceBar";
		/// <summary/>
		public const string PageUp = "PageUp";
		/// <summary/>
		public const string PageDown = "PageDown";
		/// <summary/>
		public const string End = "End";
		/// <summary/>
		public const string Home = "Home";

		/// <summary/>
		public const string Left = "Left";
		/// <summary/>
		public const string Up = "Up";
		/// <summary/>
		public const string Right = "Right";
		/// <summary/>
		public const string Down = "Down";

		/// <summary/>
		public const string Insert = "Insert";
		/// <summary/>
		public const string Delete = "Delete";

		/// <summary/>
		public const string Zero = "Zero";
		/// <summary/>
		public const string One = "One";
		/// <summary/>
		public const string Two = "Two";
		/// <summary/>
		public const string Three = "Three";
		/// <summary/>
		public const string Four = "Four";
		/// <summary/>
		public const string Five = "Five";
		/// <summary/>
		public const string Six = "Six";
		/// <summary/>
		public const string Seven = "Seven";
		/// <summary/>
		public const string Eight = "Eight";
		/// <summary/>
		public const string Nine = "Nine";

		/// <summary/>
		public const string A = "A";
		/// <summary/>
		public const string B = "B";
		/// <summary/>
		public const string C = "C";
		/// <summary/>
		public const string D = "D";
		/// <summary/>
		public const string E = "E";
		/// <summary/>
		public const string F = "F";
		/// <summary/>
		public const string G = "G";
		/// <summary/>
		public const string H = "H";
		/// <summary/>
		public const string I = "I";
		/// <summary/>
		public const string J = "J";
		/// <summary/>
		public const string K = "K";
		/// <summary/>
		public const string L = "L";
		/// <summary/>
		public const string M = "M";
		/// <summary/>
		public const string N = "N";
		/// <summary/>
		public const string O = "O";
		/// <summary/>
		public const string P = "P";
		/// <summary/>
		public const string Q = "Q";
		/// <summary/>
		public const string R = "R";
		/// <summary/>
		public const string S = "S";
		/// <summary/>
		public const string T = "T";
		/// <summary/>
		public const string U = "U";
		/// <summary/>
		public const string V = "V";
		/// <summary/>
		public const string W = "W";
		/// <summary/>
		public const string X = "X";
		/// <summary/>
		public const string Y = "Y";
		/// <summary/>
		public const string Z = "Z";

		/// <summary/>
		public const string NumPadZero = "NumPadZero";
		/// <summary/>
		public const string NumPadOne = "NumPadOne";
		/// <summary/>
		public const string NumPadTwo = "NumPadTwo";
		/// <summary/>
		public const string NumPadThree = "NumPadThree";
		/// <summary/>
		public const string NumPadFour = "NumPadFour";
		/// <summary/>
		public const string NumPadFive = "NumPadFive";
		/// <summary/>
		public const string NumPadSix = "NumPadSix";
		/// <summary/>
		public const string NumPadSeven = "NumPadSeven";
		/// <summary/>
		public const string NumPadEight = "NumPadEight";
		/// <summary/>
		public const string NumPadNine = "NumPadNine";

		/// <summary/>
		public const string Multiply = "Multiply";
		/// <summary/>
		public const string Add = "Add";
		/// <summary/>
		public const string Subtract = "Subtract";
		/// <summary/>
		public const string Decimal = "Decimal";
		/// <summary/>
		public const string Divide = "Divide";

		/// <summary/>
		public const string F1 = "F1";
		/// <summary/>
		public const string F2 = "F2";
		/// <summary/>
		public const string F3 = "F3";
		/// <summary/>
		public const string F4 = "F4";
		/// <summary/>
		public const string F5 = "F5";
		/// <summary/>
		public const string F6 = "F6";
		/// <summary/>
		public const string F7 = "F7";
		/// <summary/>
		public const string F8 = "F8";
		/// <summary/>
		public const string F9 = "F9";
		/// <summary/>
		public const string F10 = "F10";
		/// <summary/>
		public const string F11 = "F11";
		/// <summary/>
		public const string F12 = "F12";

		/// <summary/>
		public const string NumLock = "NumLock";
		/// <summary/>
		public const string ScrollLock = "ScrollLock";

		/// <summary/>
		public const string LeftShift = "LeftShift";
		/// <summary/>
		public const string RightShift = "RightShift";
		/// <summary/>
		public const string LeftControl = "LeftControl";
		/// <summary/>
		public const string RightControl = "RightControl";
		/// <summary/>
		public const string LeftAlt = "LeftAlt";
		/// <summary/>
		public const string RightAlt = "RightAlt";
		/// <summary/>
		public const string LeftCommand = "LeftCommand";
		/// <summary/>
		public const string RightCommand = "RightCommand";

		/// <summary/>
		public const string Semicolon = "Semicolon";
		/// <summary/>
		public const string Equal = "Equals";
		/// <summary/>
		public const string Comma = "Comma";
		/// <summary/>
		public const string Underscore = "Underscore";
		/// <summary/>
		public const string Hyphen = "Hyphen";
		/// <summary/>
		public const string Period = "Period";
		/// <summary/>
		public const string Slash = "Slash";
		/// <summary/>
		public const string Tilde = "Tilde";
		/// <summary/>
		public const string LeftBracket = "LeftBracket";
		/// <summary/>
		public const string Backslash = "Backslash";
		/// <summary/>
		public const string RightBracket = "RightBracket";
		/// <summary/>
		public const string Apostrophe = "Apostrophe";

		/// <summary/>
		public const string Ampersand = "Ampersand";
		/// <summary/>
		public const string Asterix = "Asterix";
		/// <summary/>
		public const string Caret = "Caret";
		/// <summary/>
		public const string Colon = "Colon";
		/// <summary/>
		public const string Dollar = "Dollar";
		/// <summary/>
		public const string Exclamation = "Exclamation";
		/// <summary/>
		public const string LeftParantheses = "LeftParantheses";
		/// <summary/>
		public const string RightParantheses = "RightParantheses";
		/// <summary/>
		public const string Quote = "Quote";

		/// <summary/>
		public const string Section = "Section";

		/// <summary/>
		public const string Invalid = "Invalid";

		/// <summary>
		/// Platform-specific
		/// </summary>
		public static class Platform {
			/// <summary/>
			public const string Delete = "Platform_Delete";
		}

		/// <summary>
		/// Gamepad
		/// </summary>
		public static class Gamepad {
			/// <summary/>
			public const string LeftX = "Gamepad_LeftX";
			/// <summary/>
			public const string LeftY = "Gamepad_LeftY";
			/// <summary/>
			public const string RightX = "Gamepad_RightX";
			/// <summary/>
			public const string RightY = "Gamepad_RightY";
			/// <summary/>
			public const string LeftTriggerAxis = "Gamepad_LeftTriggerAxis";
			/// <summary/>
			public const string RightTriggerAxis = "Gamepad_RightTriggerAxis";
			/// <summary/>
			public const string LeftThumbstick = "Gamepad_LeftThumbstick";
			/// <summary/>
			public const string RightThumbstick = "Gamepad_RightThumbstick";
			/// <summary/>
			public const string LeftShoulder = "Gamepad_LeftShoulder";
			/// <summary/>
			public const string RightShoulder = "Gamepad_RightShoulder";
			/// <summary/>
			public const string LeftTrigger = "Gamepad_LeftTrigger";
			/// <summary/>
			public const string RightTrigger = "Gamepad_RightTrigger";
			/// <summary/>
			public const string DPadUp = "Gamepad_DPad_Up";
			/// <summary/>
			public const string DPadDown = "Gamepad_DPad_Down";
			/// <summary/>
			public const string DPadRight = "Gamepad_DPad_Right";
			/// <summary/>
			public const string DPadLeft = "Gamepad_DPad_Left";
			/// <summary/>
			public const string SpecialLeft = "Gamepad_Special_Left";
			/// <summary/>
			public const string SpecialLeftX = "Gamepad_Special_Left_X";
			/// <summary/>
			public const string SpecialLeftY = "Gamepad_Special_Left_Y";
			/// <summary/>
			public const string SpecialRight = "Gamepad_Special_Right";
			/// <summary/>
			public const string FaceButtonBottom = "Gamepad_FaceButton_Bottom";
			/// <summary/>
			public const string FaceButtonRight = "Gamepad_FaceButton_Right";
			/// <summary/>
			public const string FaceButtonLeft = "Gamepad_FaceButton_Left";
			/// <summary/>
			public const string FaceButtonTop = "Gamepad_FaceButton_Top";
		}

		/// <summary>
		/// Virtual key codes used for input axis button press/release emulation
		/// </summary>
		public static class Virtual {
			/// <summary/>
			public const string LeftStickUp = "Gamepad_LeftStick_Up";
			/// <summary/>
			public const string LeftStickDown = "Gamepad_LeftStick_Down";
			/// <summary/>
			public const string LeftStickRight = "Gamepad_LeftStick_Right";
			/// <summary/>
			public const string LeftStickLeft = "Gamepad_LeftStick_Left";
			/// <summary/>
			public const string RightStickUp = "Gamepad_RightStick_Up";
			/// <summary/>
			public const string RightStickDown = "Gamepad_RightStick_Down";
			/// <summary/>
			public const string RightStickRight = "Gamepad_RightStick_Right";
			/// <summary/>
			public const string RightStickLeft = "Gamepad_RightStick_Left";

			/// <summary/>
			public const string Tilt = "Tilt";
			/// <summary/>
			public const string RotationRate = "RotationRate";
			/// <summary/>
			public const string Gravity = "Gravity";
			/// <summary/>
			public const string Acceleration = "Acceleration";

			/// <summary/>
			public const string Accept = "Virtual_Accept";
			/// <summary/>
			public const string Back = "Virtual_Back";
		}

		/// <summary>
		/// Gestures
		/// </summary>
		public static class Gesture {
			/// <summary/>
			public const string Pinch = "Gesture_Pinch";
			/// <summary/>
			public const string Flick = "Gesture_Flick";
			/// <summary/>
			public const string Rotate = "Gesture_Rotate";
		}

		/// <summary>
		/// PS4
		/// </summary>
		public static class PS4 {
			/// <summary/>
			public const string Special = "PS4_Special";
		}

		/// <summary>
		/// Steam Controller
		/// </summary>
		public static class Steam {
			/// <summary/>
			public const string TouchZero = "Steam_Touch_0";
			/// <summary/>
			public const string TouchOne = "Steam_Touch_1";
			/// <summary/>
			public const string TouchTwo = "Steam_Touch_2";
			/// <summary/>
			public const string TouchThree = "Steam_Touch_3";
			/// <summary/>
			public const string BackLeft = "Steam_Back_Left";
			/// <summary/>
			public const string BackRight = "Steam_Back_Right";
		}

		/// <summary>
		/// Xbox
		/// </summary>
		public static class Xbox {
			/// <summary/>
			public const string GlobalMenu = "Global_Menu";
			/// <summary/>
			public const string GlobalView = "Global_View";
			/// <summary/>
			public const string GlobalPause = "Global_Pause";
			/// <summary/>
			public const string GlobalPlay = "Global_Play";
			/// <summary/>
			public const string GlobalBack = "Global_Back";
		}

		/// <summary>
		/// Android
		/// </summary>
		public static class Android {
			/// <summary/>
			public const string Back = "Android_Back";
			/// <summary/>
			public const string VolumeUp = "Android_Volume_Up";
			/// <summary/>
			public const string VolumeDown = "Android_Volume_Down";
			/// <summary/>
			public const string Menu = "Android_Menu";
		}

		/// <summary>
		/// Google Daydream
		/// </summary>
		public static class Daydream {
			/// <summary/>
			public const string LeftSelectClick = "Daydream_Left_Select_Click";
			/// <summary/>
			public const string LeftTrackpadX = "Daydream_Left_Trackpad_X";
			/// <summary/>
			public const string LeftTrackpadY = "Daydream_Left_Trackpad_Y";
			/// <summary/>
			public const string LeftTrackpadClick = "Daydream_Left_Trackpad_Click";
			/// <summary/>
			public const string LeftTrackpadTouch = "Daydream_Left_Trackpad_Touch";
			/// <summary/>
			public const string RightSelectClick = "Daydream_Right_Select_Click";
			/// <summary/>
			public const string RightTrackpadX = "Daydream_Right_Trackpad_X";
			/// <summary/>
			public const string RightTrackpadY = "Daydream_Right_Trackpad_Y";
			/// <summary/>
			public const string RightTrackpadClick = "Daydream_Right_Trackpad_Click";
			/// <summary/>
			public const string RightTrackpadTouch = "Daydream_Right_Trackpad_Touch";
		}

		/// <summary>
		/// HTC Vive
		/// </summary>
		public static class Vive {
			/// <summary/>
			public const string LeftSystemClick = "Vive_Left_System_Click";
			/// <summary/>
			public const string LeftGripClick = "Vive_Left_Grip_Click";
			/// <summary/>
			public const string LeftMenuClick = "Vive_Left_Menu_Click";
			/// <summary/>
			public const string LeftTriggerClick = "Vive_Left_Trigger_Click";
			/// <summary/>
			public const string LeftTriggerAxis = "Vive_Left_Trigger_Axis";
			/// <summary/>
			public const string LeftTrackpadX = "Vive_Left_Trackpad_X";
			/// <summary/>
			public const string LeftTrackpadY = "Vive_Left_Trackpad_Y";
			/// <summary/>
			public const string LeftTrackpadClick = "Vive_Left_Trackpad_Click";
			/// <summary/>
			public const string LeftTrackpadTouch = "Vive_Left_Trackpad_Touch";
			/// <summary/>
			public const string LeftTrackpadUp = "Vive_Left_Trackpad_Up";
			/// <summary/>
			public const string LeftTrackpadDown = "Vive_Left_Trackpad_Down";
			/// <summary/>
			public const string LeftTrackpadLeft = "Vive_Left_Trackpad_Left";
			/// <summary/>
			public const string LeftTrackpadRight = "Vive_Left_Trackpad_Right";
			/// <summary/>
			public const string RightSystemClick = "Vive_Right_System_Click";
			/// <summary/>
			public const string RightGripClick = "Vive_Right_Grip_Click";
			/// <summary/>
			public const string RightMenuClick = "Vive_Right_Menu_Click";
			/// <summary/>
			public const string RightTriggerClick = "Vive_Right_Trigger_Click";
			/// <summary/>
			public const string RightTriggerAxis = "Vive_Right_Trigger_Axis";
			/// <summary/>
			public const string RightTrackpadX = "Vive_Right_Trackpad_X";
			/// <summary/>
			public const string RightTrackpadY = "Vive_Right_Trackpad_Y";
			/// <summary/>
			public const string RightTrackpadClick = "Vive_Right_Trackpad_Click";
			/// <summary/>
			public const string RightTrackpadTouch = "Vive_Right_Trackpad_Touch";
			/// <summary/>
			public const string RightTrackpadUp = "Vive_Right_Trackpad_Up";
			/// <summary/>
			public const string RightTrackpadDown = "Vive_Right_Trackpad_Down";
			/// <summary/>
			public const string RightTrackpadLeft = "Vive_Right_Trackpad_Left";
			/// <summary/>
			public const string RightTrackpadRight = "Vive_Right_Trackpad_Right";
		}

		/// <summary>
		/// Microsoft Mixed Reality
		/// </summary>
		public static class MixedReality {
			/// <summary/>
			public const string LeftMenuClick = "MixedReality_Left_Menu_Click";
			/// <summary/>
			public const string LeftGripClick = "MixedReality_Left_Grip_Click";
			/// <summary/>
			public const string LeftTriggerClick = "MixedReality_Left_Trigger_Click";
			/// <summary/>
			public const string LeftTriggerAxis = "MixedReality_Left_Trigger_Axis";
			/// <summary/>
			public const string LeftThumbstickX = "MixedReality_Left_Thumbstick_X";
			/// <summary/>
			public const string LeftThumbstickY = "MixedReality_Left_Thumbstick_Y";
			/// <summary/>
			public const string LeftThumbstickClick = "MixedReality_Left_Thumbstick_Click";
			/// <summary/>
			public const string LeftThumbstickUp = "MixedReality_Left_Thumbstick_Up";
			/// <summary/>
			public const string LeftThumbstickDown = "MixedReality_Left_Thumbstick_Down";
			/// <summary/>
			public const string LeftThumbstickLeft = "MixedReality_Left_Thumbstick_Left";
			/// <summary/>
			public const string LeftThumbstickRight = "MixedReality_Left_Thumbstick_Right";
			/// <summary/>
			public const string LeftTrackpadX = "MixedReality_Left_Trackpad_X";
			/// <summary/>
			public const string LeftTrackpadY = "MixedReality_Left_Trackpad_Y";
			/// <summary/>
			public const string LeftTrackpadClick = "MixedReality_Left_Trackpad_Click";
			/// <summary/>
			public const string LeftTrackpadTouch = "MixedReality_Left_Trackpad_Touch";
			/// <summary/>
			public const string LeftTrackpadUp = "MixedReality_Left_Trackpad_Up";
			/// <summary/>
			public const string LeftTrackpadDown = "MixedReality_Left_Trackpad_Down";
			/// <summary/>
			public const string LeftTrackpadLeft = "MixedReality_Left_Trackpad_Left";
			/// <summary/>
			public const string LeftTrackpadRight = "MixedReality_Left_Trackpad_Right";
			/// <summary/>
			public const string RightMenuClick = "MixedReality_Right_Menu_Click";
			/// <summary/>
			public const string RightGripClick = "MixedReality_Right_Grip_Click";
			/// <summary/>
			public const string RightTriggerClick = "MixedReality_Right_Trigger_Click";
			/// <summary/>
			public const string RightTriggerAxis = "MixedReality_Right_Trigger_Axis";
			/// <summary/>
			public const string RightThumbstickX = "MixedReality_Right_Thumbstick_X";
			/// <summary/>
			public const string RightThumbstickY = "MixedReality_Right_Thumbstick_Y";
			/// <summary/>
			public const string RightThumbstickClick = "MixedReality_Right_Thumbstick_Click";
			/// <summary/>
			public const string RightThumbstickUp = "MixedReality_Right_Thumbstick_Up";
			/// <summary/>
			public const string RightThumbstickDown = "MixedReality_Right_Thumbstick_Down";
			/// <summary/>
			public const string RightThumbstickLeft = "MixedReality_Right_Thumbstick_Left";
			/// <summary/>
			public const string RightThumbstickRight = "MixedReality_Right_Thumbstick_Right";
			/// <summary/>
			public const string RightTrackpadX = "MixedReality_Right_Trackpad_X";
			/// <summary/>
			public const string RightTrackpadY = "MixedReality_Right_Trackpad_Y";
			/// <summary/>
			public const string RightTrackpadClick = "MixedReality_Right_Trackpad_Click";
			/// <summary/>
			public const string RightTrackpadTouch = "MixedReality_Right_Trackpad_Touch";
			/// <summary/>
			public const string RightTrackpadUp = "MixedReality_Right_Trackpad_Up";
			/// <summary/>
			public const string RightTrackpadDown = "MixedReality_Right_Trackpad_Down";
			/// <summary/>
			public const string RightTrackpadLeft = "MixedReality_Right_Trackpad_Left";
			/// <summary/>
			public const string RightTrackpadRight = "MixedReality_Right_Trackpad_Right";
		}

		/// <summary>
		/// Oculus Go
		/// </summary>
		public static class OculusGo {
			/// <summary/>
			public const string LeftSystemClick = "OculusGo_Left_System_Click";
			/// <summary/>
			public const string LeftBackClick = "OculusGo_Left_Back_Click";
			/// <summary/>
			public const string LeftTriggerClick = "OculusGo_Left_Trigger_Click";
			/// <summary/>
			public const string LeftTrackpadX = "OculusGo_Left_Trackpad_X";
			/// <summary/>
			public const string LeftTrackpadY = "OculusGo_Left_Trackpad_Y";
			/// <summary/>
			public const string LeftTrackpadClick = "OculusGo_Left_Trackpad_Click";
			/// <summary/>
			public const string LeftTrackpadTouch = "OculusGo_Left_Trackpad_Touch";
			/// <summary/>
			public const string RightSystemClick = "OculusGo_Right_System_Click";
			/// <summary/>
			public const string RightBackClick = "OculusGo_Right_Back_Click";
			/// <summary/>
			public const string RightTriggerClick = "OculusGo_Right_Trigger_Click";
			/// <summary/>
			public const string RightTrackpadX = "OculusGo_Right_Trackpad_X";
			/// <summary/>
			public const string RightTrackpadY = "OculusGo_Right_Trackpad_Y";
			/// <summary/>
			public const string RightTrackpadClick = "OculusGo_Right_Trackpad_Click";
			/// <summary/>
			public const string RightTrackpadTouch = "OculusGo_Right_Trackpad_Touch";
		}

		/// <summary>
		/// Oculus Touch
		/// </summary>
		public static class OculusTouch {
			/// <summary/>
			public const string LeftXClick = "OculusTouch_Left_X_Click";
			/// <summary/>
			public const string LeftYClick = "OculusTouch_Left_Y_Click";
			/// <summary/>
			public const string LeftXTouch = "OculusTouch_Left_X_Touch";
			/// <summary/>
			public const string LeftYTouch = "OculusTouch_Left_Y_Touch";
			/// <summary/>
			public const string LeftMenuClick = "OculusTouch_Left_Menu_Click";
			/// <summary/>
			public const string LeftGripClick = "OculusTouch_Left_Grip_Click";
			/// <summary/>
			public const string LeftGripAxis = "OculusTouch_Left_Grip_Axis";
			/// <summary/>
			public const string LeftTriggerClick = "OculusTouch_Left_Trigger_Click";
			/// <summary/>
			public const string LeftTriggerAxis = "OculusTouch_Left_Trigger_Axis";
			/// <summary/>
			public const string LeftTriggerTouch = "OculusTouch_Left_Trigger_Touch";
			/// <summary/>
			public const string LeftThumbstickX = "OculusTouch_Left_Thumbstick_X";
			/// <summary/>
			public const string LeftThumbstickY = "OculusTouch_Left_Thumbstick_Y";
			/// <summary/>
			public const string LeftThumbstickClick = "OculusTouch_Left_Thumbstick_Click";
			/// <summary/>
			public const string LeftThumbstickTouch = "OculusTouch_Left_Thumbstick_Touch";
			/// <summary/>
			public const string LeftThumbstickUp = "OculusTouch_Left_Thumbstick_Up";
			/// <summary/>
			public const string LeftThumbstickDown = "OculusTouch_Left_Thumbstick_Down";
			/// <summary/>
			public const string LeftThumbstickLeft = "OculusTouch_Left_Thumbstick_Left";
			/// <summary/>
			public const string LeftThumbstickRight = "OculusTouch_Left_Thumbstick_Right";
			/// <summary/>
			public const string RightAClick = "OculusTouch_Right_A_Click";
			/// <summary/>
			public const string RightBClick = "OculusTouch_Right_B_Click";
			/// <summary/>
			public const string RightATouch = "OculusTouch_Right_A_Touch";
			/// <summary/>
			public const string RightBTouch = "OculusTouch_Right_B_Touch";
			/// <summary/>
			public const string RightSystemClick = "OculusTouch_Right_System_Click";
			/// <summary/>
			public const string RightGripClick = "OculusTouch_Right_Grip_Click";
			/// <summary/>
			public const string RightGripAxis = "OculusTouch_Right_Grip_Axis";
			/// <summary/>
			public const string RightTriggerClick = "OculusTouch_Right_Trigger_Click";
			/// <summary/>
			public const string RightTriggerAxis = "OculusTouch_Right_Trigger_Axis";
			/// <summary/>
			public const string RightTriggerTouch = "OculusTouch_Right_Trigger_Touch";
			/// <summary/>
			public const string RightThumbstickX = "OculusTouch_Right_Thumbstick_X";
			/// <summary/>
			public const string RightThumbstickY = "OculusTouch_Right_Thumbstick_Y";
			/// <summary/>
			public const string RightThumbstickClick = "OculusTouch_Right_Thumbstick_Click";
			/// <summary/>
			public const string RightThumbstickTouch = "OculusTouch_Right_Thumbstick_Touch";
			/// <summary/>
			public const string RightThumbstickUp = "OculusTouch_Right_Thumbstick_Up";
			/// <summary/>
			public const string RightThumbstickDown = "OculusTouch_Right_Thumbstick_Down";
			/// <summary/>
			public const string RightThumbstickLeft = "OculusTouch_Right_Thumbstick_Left";
			/// <summary/>
			public const string RightThumbstickRight = "OculusTouch_Right_Thumbstick_Right";
		}

		/// <summary>
		/// Valve Index
		/// </summary>
		public static class ValveIndex {
			/// <summary/>
			public const string LeftAClick = "ValveIndex_Left_A_Click";
			/// <summary/>
			public const string LeftBClick = "ValveIndex_Left_B_Click";
			/// <summary/>
			public const string LeftATouch = "ValveIndex_Left_A_Touch";
			/// <summary/>
			public const string LeftBTouch = "ValveIndex_Left_B_Touch";
			/// <summary/>
			public const string LeftSystemClick = "ValveIndex_Left_System_Click";
			/// <summary/>
			public const string LeftSystemTouch = "ValveIndex_Left_System_Touch";
			/// <summary/>
			public const string LeftGripClick = "ValveIndex_Left_Grip_Click";
			/// <summary/>
			public const string LeftGripAxis = "ValveIndex_Left_Grip_Axis";
			/// <summary/>
			public const string LeftGripForce = "ValveIndex_Left_Grip_Force";
			/// <summary/>
			public const string LeftTriggerClick = "ValveIndex_Left_Trigger_Click";
			/// <summary/>
			public const string LeftTriggerAxis = "ValveIndex_Left_Trigger_Axis";
			/// <summary/>
			public const string LeftTriggerTouch = "ValveIndex_Left_Trigger_Touch";
			/// <summary/>
			public const string LeftThumbstickX = "ValveIndex_Left_Thumbstick_X";
			/// <summary/>
			public const string LeftThumbstickY = "ValveIndex_Left_Thumbstick_Y";
			/// <summary/>
			public const string LeftThumbstickClick = "ValveIndex_Left_Thumbstick_Click";
			/// <summary/>
			public const string LeftThumbstickTouch = "ValveIndex_Left_Thumbstick_Touch";
			/// <summary/>
			public const string LeftThumbstickUp = "ValveIndex_Left_Thumbstick_Up";
			/// <summary/>
			public const string LeftThumbstickDown = "ValveIndex_Left_Thumbstick_Down";
			/// <summary/>
			public const string LeftThumbstickLeft = "ValveIndex_Left_Thumbstick_Left";
			/// <summary/>
			public const string LeftThumbstickRight = "ValveIndex_Left_Thumbstick_Right";
			/// <summary/>
			public const string LeftTrackpadX = "ValveIndex_Left_Trackpad_X";
			/// <summary/>
			public const string LeftTrackpadY = "ValveIndex_Left_Trackpad_Y";
			/// <summary/>
			public const string LeftTrackpadClick = "ValveIndex_Left_Trackpad_Click";
			/// <summary/>
			public const string LeftTrackpadForce = "ValveIndex_Left_Trackpad_Force";
			/// <summary/>
			public const string LeftTrackpadTouch = "ValveIndex_Left_Trackpad_Touch";
			/// <summary/>
			public const string LeftTrackpadUp = "ValveIndex_Left_Trackpad_Up";
			/// <summary/>
			public const string LeftTrackpadDown = "ValveIndex_Left_Trackpad_Down";
			/// <summary/>
			public const string LeftTrackpadLeft = "ValveIndex_Left_Trackpad_Left";
			/// <summary/>
			public const string LeftTrackpadRight = "ValveIndex_Left_Trackpad_Right";
			/// <summary/>
			public const string RightAClick = "ValveIndex_Right_A_Click";
			/// <summary/>
			public const string RightBClick = "ValveIndex_Right_B_Click";
			/// <summary/>
			public const string RightATouch = "ValveIndex_Right_A_Touch";
			/// <summary/>
			public const string RightBTouch = "ValveIndex_Right_B_Touch";
			/// <summary/>
			public const string RightSystemClick = "ValveIndex_Right_System_Click";
			/// <summary/>
			public const string RightSystemTouch = "ValveIndex_Right_System_Touch";
			/// <summary/>
			public const string RightGripClick = "ValveIndex_Right_Grip_Click";
			/// <summary/>
			public const string RightGripAxis = "ValveIndex_Right_Grip_Axis";
			/// <summary/>
			public const string RightGripForce = "ValveIndex_Right_Grip_Force";
			/// <summary/>
			public const string RightTriggerClick = "ValveIndex_Right_Trigger_Click";
			/// <summary/>
			public const string RightTriggerAxis = "ValveIndex_Right_Trigger_Axis";
			/// <summary/>
			public const string RightTriggerTouch = "ValveIndex_Right_Trigger_Touch";
			/// <summary/>
			public const string RightThumbstickX = "ValveIndex_Right_Thumbstick_X";
			/// <summary/>
			public const string RightThumbstickY = "ValveIndex_Right_Thumbstick_Y";
			/// <summary/>
			public const string RightThumbstickClick = "ValveIndex_Right_Thumbstick_Click";
			/// <summary/>
			public const string RightThumbstickTouch = "ValveIndex_Right_Thumbstick_Touch";
			/// <summary/>
			public const string RightThumbstickUp = "ValveIndex_Right_Thumbstick_Up";
			/// <summary/>
			public const string RightThumbstickDown = "ValveIndex_Right_Thumbstick_Down";
			/// <summary/>
			public const string RightThumbstickLeft = "ValveIndex_Right_Thumbstick_Left";
			/// <summary/>
			public const string RightThumbstickRight = "ValveIndex_Right_Thumbstick_Right";
			/// <summary/>
			public const string RightTrackpadX = "ValveIndex_Right_Trackpad_X";
			/// <summary/>
			public const string RightTrackpadY = "ValveIndex_Right_Trackpad_Y";
			/// <summary/>
			public const string RightTrackpadClick = "ValveIndex_Right_Trackpad_Click";
			/// <summary/>
			public const string RightTrackpadForce = "ValveIndex_Right_Trackpad_Force";
			/// <summary/>
			public const string RightTrackpadTouch = "ValveIndex_Right_Trackpad_Touch";
			/// <summary/>
			public const string RightTrackpadUp = "ValveIndex_Right_Trackpad_Up";
			/// <summary/>
			public const string RightTrackpadDown = "ValveIndex_Right_Trackpad_Down";
			/// <summary/>
			public const string RightTrackpadLeft = "ValveIndex_Right_Trackpad_Left";
			/// <summary/>
			public const string RightTrackpadRight = "ValveIndex_Right_Trackpad_Right";
		}
	}

	/// <summary>
	/// Functionality to detect and diagnose unexpected or invalid runtime conditions during development, emitted if the assembly is built with the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build#options">Debug</a> configuration or if <c>ASSERTIONS</c> symbol is defined, signals a breakpoint to an attached debugger
	/// </summary>
	public static partial class Assert {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new StringBuilder(8192);

		private static void Message(string message, int callerLineNumber, string callerFilePath) {
			stringBuffer.Clear()
			.AppendFormat("Assertion is failed at line {0} in file \"{1}\"", callerLineNumber, callerFilePath);

			if (message != null)
				stringBuffer.AppendFormat(" with message: {0}", message);

			outputMessage(stringBuffer.ToString());

			Debugger.Break();
		}

		/// <summary>
		/// Logs an assertion if condition is <c>true</c>, and prints it on the screen
		/// </summary>
		[Conditional("DEBUG"), Conditional("ASSERTIONS")]
		public static void IsFalse(bool condition, string message = null, [CallerLineNumber] int callerLineNumber = 0, [CallerFilePath] string callerFilePath = null) {
			if (condition)
				Message(message, callerLineNumber, callerFilePath);
		}

		/// <summary>
		/// Logs an assertion if condition is <c>false</c>, and prints it on the screen
		/// </summary>
		[Conditional("DEBUG"), Conditional("ASSERTIONS")]
		public static void IsTrue(bool condition, string message = null, [CallerLineNumber] int callerLineNumber = 0, [CallerFilePath] string callerFilePath = null) {
			if (!condition)
				Message(message, callerLineNumber, callerFilePath);
		}

		/// <summary>
		/// Logs an assertion if value is not `null`, and prints it on the screen
		/// </summary>
		[Conditional("DEBUG"), Conditional("ASSERTIONS")]
		public static void IsNull<T>(T value, string message = null, [CallerLineNumber] int callerLineNumber = 0, [CallerFilePath] string callerFilePath = null) where T : class {
			if (value != null)
				Message(message, callerLineNumber, callerFilePath);
		}

		/// <summary>
		/// Logs an assertion if value is `null`, and prints it on the screen
		/// </summary>
		[Conditional("DEBUG"), Conditional("ASSERTIONS")]
		public static void IsNotNull<T>(T value, string message = null, [CallerLineNumber] int callerLineNumber = 0, [CallerFilePath] string callerFilePath = null) where T : class {
			if (value == null)
				Message(message, callerLineNumber, callerFilePath);
		}
	}

	/// <summary>
	/// Functionality to work with the command-line of the engine executable
	/// </summary>
	public static partial class CommandLine {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new StringBuilder(8192);

		/// <summary>
		/// Returns the user arguments
		/// </summary>
		public static string Get() {
			stringBuffer.Clear();

			get(stringBuffer);

			return stringBuffer.ToString();
		}

		/// <summary>
		/// Overrides the arguments
		/// </summary>
		public static void Set(string arguments) {
			if (arguments == null)
				throw new ArgumentNullException(nameof(arguments));

			set(arguments);
		}

		/// <summary>
		/// Appends the string to the arguments as it is without adding a space
		/// </summary>
		public static void Append(string arguments) {
			if (arguments == null)
				throw new ArgumentNullException(nameof(arguments));

			append(arguments);
		}
	}

	/// <summary>
	/// Functionality for debugging
	/// </summary>
	public static partial class Debug {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new StringBuilder(8192);

		/// <summary>
		/// Logs a message in accordance to the specified level, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void Log(LogLevel level, string message) {
			if (message == null)
				throw new ArgumentNullException(nameof(message));

			log(level, message);
		}

		/// <summary>
		/// Creates a log file with the name of assembly if required and writes an exception to it, prints it on the screen, printing on the screen is omitted in package builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration, but log file will persist
		/// </summary>
		public static void Exception(Exception exception) {
			if (exception == null)
				throw new ArgumentNullException(nameof(exception));

			stringBuffer.Clear()
			.AppendFormat("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
			.AppendLine().AppendFormat("Message: {0}", exception.Message)
			.AppendLine().AppendFormat("StackTrace: {0}", exception.StackTrace)
			.AppendLine().AppendFormat("Source: {0}", exception.Source)
			.AppendLine();

			handleException(stringBuffer.ToString());

			using (StreamWriter streamWriter = File.AppendText(Path.Project + "/Saved/Logs/Exceptions-" + Assembly.GetCallingAssembly().GetName().Name + ".log")) {
				streamWriter.WriteLine(stringBuffer);
				streamWriter.Close();
			}
		}

		/// <summary>
		/// Prints a debug message on the screen assigned to the key identifier, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void AddOnScreenMessage(int key, float timeToDisplay, Color displayColor, string message) {
			if (message == null)
				throw new ArgumentNullException(nameof(message));

			addOnScreenMessage(key, timeToDisplay, displayColor.ToArgb(), message);
		}

		/// <summary>
		/// Clears any existing debug messages, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void ClearOnScreenMessages() => clearOnScreenMessages();

		/// <summary>
		/// Draws a debug box, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void DrawBox(in Vector3 center, in Vector3 extent, in Quaternion rotation, Color color, bool persistentLines = false, float lifeTime = -1.0f, byte depthPriority = 0, float thickness = 0.0f) => drawBox(center, extent, rotation, color.ToArgb(), persistentLines, lifeTime, depthPriority, thickness);

		/// <summary>
		/// Draws a debug capsule, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void DrawCapsule(in Vector3 center, float halfHeight, float radius, in Quaternion rotation, Color color, bool persistentLines = false, float lifeTime = -1.0f, byte depthPriority = 0, float thickness = 0.0f) => drawCapsule(center, halfHeight, radius, rotation, color.ToArgb(), persistentLines, lifeTime, depthPriority, thickness);

		/// <summary>
		/// Draws a debug cone, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void DrawCone(in Vector3 origin, in Vector3 direction, float length, float angleWidth, float angleHeight, int sides, Color color, bool persistentLines = false, float lifeTime = -1.0f, byte depthPriority = 0, float thickness = 0.0f) => drawCone(origin, direction, length, angleWidth, angleHeight, sides, color.ToArgb(), persistentLines, lifeTime, depthPriority, thickness);

		/// <summary>
		/// Draws a debug cylinder, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void DrawCylinder(in Vector3 start, in Vector3 end, float radius, int segments, Color color, bool persistentLines = false, float lifeTime = -1.0f, byte depthPriority = 0, float thickness = 0.0f) => drawCylinder(start, end, radius, segments, color.ToArgb(), persistentLines, lifeTime, depthPriority, thickness);

		/// <summary>
		/// Draws a debug sphere, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void DrawSphere(in Vector3 center, float radius, int segments, Color color, bool persistentLines = false, float lifeTime = -1.0f, byte depthPriority = 0, float thickness = 0.0f) => drawSphere(center, radius, segments, color.ToArgb(), persistentLines, lifeTime, depthPriority, thickness);

		/// <summary>
		/// Draws a debug line, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void DrawLine(in Vector3 start, in Vector3 end, Color color, bool persistentLines = false, float lifeTime = -1.0f, byte depthPriority = 0, float thickness = 0.0f) => drawLine(start, end, color.ToArgb(), persistentLines, lifeTime, depthPriority, thickness);

		/// <summary>
		/// Draws a debug point, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void DrawPoint(in Vector3 location, float size, Color color, bool persistentLines = false, float lifeTime = -1.0f, byte depthPriority = 0) => drawPoint(location, size, color.ToArgb(), persistentLines, lifeTime, depthPriority);

		/// <summary>
		/// Flushes persistent debug lines, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void FlushPersistentLines() => flushPersistentLines();
	}

	/// <summary>
	/// Provides information about the application
	/// </summary>
	public static partial class Application {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new StringBuilder(8192);

		/// <summary>
		/// Returns <c>true</c> if the application can render anything
		/// </summary>
		public static bool IsCanEverRender => isCanEverRender();

		/// <summary>
		/// Returns <c>true</c> if current build is meant for release to retail
		/// </summary>
		public static bool IsPackagedForDistribution => isPackagedForDistribution();

		/// <summary>
		/// Returns <c>true</c> if current build is packaged for shipping
		/// </summary>
		public static bool IsPackagedForShipping => isPackagedForShipping();

		/// <summary>
		/// Returns the project directory
		/// </summary>
		public static string ProjectDirectory {
			get {
				stringBuffer.Clear();

				getProjectDirectory(stringBuffer);

				return stringBuffer.ToString();
			}
		}

		/// <summary>
		/// Returns the default language used by current platform
		/// </summary>
		public static string DefaultLanguage {
			get {
				stringBuffer.Clear();

				getDefaultLanguage(stringBuffer);

				return stringBuffer.ToString();
			}
		}

		/// <summary>
		/// Gets or sets the name of the current project
		/// </summary>
		public static string ProjectName {
			get {
				stringBuffer.Clear();

				getProjectName(stringBuffer);

				return stringBuffer.ToString();
			}

			set {
				setProjectName(value);
			}
		}

		/// <summary>
		/// Gets or sets the current volume multiplier
		/// </summary>
		public static float VolumeMultiplier {
			get => getVolumeMultiplier();
			set => setVolumeMultiplier(value);
		}
	}

	/// <summary>
	/// Handles console commands and variables
	/// </summary>
	public static partial class ConsoleManager {
		/// <summary>
		/// Returns <c>true</c> if a console command or variable has been registered
		/// </summary>
		public static bool IsRegisteredVariable(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return isRegisteredVariable(name);
		}

		/// <summary>
		/// Finds a console variable
		/// </summary>
		/// <returns>A console variable or <c>null</c> on failure</returns>
		public static ConsoleVariable FindVariable(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (findVariable(name) != IntPtr.Zero)
				return new ConsoleVariable(name);

			return null;
		}

		/// <summary>
		/// Creates and registers a bool console variable, remains alive during the lifetime of the engine until unregistered
		/// </summary>
		/// <param name="name">The name of the variable</param>
		/// <param name="help">Help text for the variable</param>
		/// <param name="defaultValue">A default value</param>
		/// <param name="readOnly">If <c>true</c>, cannot be changed by the user from console</param>
		/// <returns>A console variable or <c>null</c> on failure</returns>
		public static ConsoleVariable RegisterVariable(string name, string help, bool defaultValue = false, bool readOnly = false) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (help == null)
				throw new ArgumentNullException(nameof(help));

			if (registerVariableBool(name, help, defaultValue, readOnly) != IntPtr.Zero)
				return new ConsoleVariable(name);

			return null;
		}

		/// <summary>
		/// Creates and registers an integer console variable, remains alive during the lifetime of the engine until unregistered
		/// </summary>
		/// <param name="name">The name of the variable</param>
		/// <param name="help">Help text for the variable</param>
		/// <param name="defaultValue">A default value</param>
		/// <param name="readOnly">If <c>true</c>, cannot be changed by the user from console</param>
		/// <returns>A console variable or <c>null</c> on failure</returns>
		public static ConsoleVariable RegisterVariable(string name, string help, int defaultValue = 0, bool readOnly = false) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (help == null)
				throw new ArgumentNullException(nameof(help));

			if (registerVariableInt(name, help, defaultValue, readOnly) != IntPtr.Zero)
				return new ConsoleVariable(name);

			return null;
		}

		/// <summary>
		/// Creates and registers a float console variable, remains alive during the lifetime of the engine until unregistered
		/// </summary>
		/// <param name="name">The name of the variable</param>
		/// <param name="help">Help text for the variable</param>
		/// <param name="defaultValue">A default value</param>
		/// <param name="readOnly">If <c>true</c>, cannot be changed by the user from console</param>
		/// <returns>A console variable or <c>null</c> on failure</returns>
		public static ConsoleVariable RegisterVariable(string name, string help, float defaultValue = 0.0f, bool readOnly = false) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (help == null)
				throw new ArgumentNullException(nameof(help));

			if (registerVariableFloat(name, help, defaultValue, readOnly) != IntPtr.Zero)
				return new ConsoleVariable(name);

			return null;
		}

		/// <summary>
		/// Creates and registers a string console variable, remains alive during the lifetime of the engine until unregistered
		/// </summary>
		/// <param name="name">The name of the variable</param>
		/// <param name="help">Help text for the variable</param>
		/// <param name="defaultValue">A default value</param>
		/// <param name="readOnly">If <c>true</c>, cannot be changed by the user from console</param>
		/// <returns>A console variable or <c>null</c> on failure</returns>
		public static ConsoleVariable RegisterVariable(string name, string help, string defaultValue = null, bool readOnly = false) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (help == null)
				throw new ArgumentNullException(nameof(help));

			if (registerVariableString(name, help, defaultValue, readOnly) != IntPtr.Zero)
				return new ConsoleVariable(name);

			return null;
		}

		/// <summary>
		/// Creates and registers a static callback function to a console command that takes no arguments, remains alive during the lifetime of the engine until unregistered
		/// </summary>
		/// <param name="name">The name of the command</param>
		/// <param name="help">Help text for the command</param>
		/// <param name="action">The static function to call when the command is executed</param>
		/// <param name="readOnly">If <c>true</c>, cannot be changed by the user from console</param>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="action"/> is not static</exception>
		public static void RegisterCommand(string name, string help, ConsoleCommandDelegate action, bool readOnly = false) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (help == null)
				throw new ArgumentNullException(nameof(help));

			if (action == null)
				throw new ArgumentNullException(nameof(action));

			if (!action.Method.IsStatic)
				throw new ArgumentException(nameof(action) + " should be static");

			registerCommand(name, help, action.Method.MethodHandle.GetFunctionPointer(), readOnly);
		}

		/// <summary>
		/// Deletes and unregister a console command or variable
		/// </summary>
		public static void UnregisterObject(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			unregisterObject(name);
		}
	}

	/// <summary>
	/// Functionality for management of engine systems
	/// </summary>
	public static partial class Engine {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new StringBuilder(8192);

		/// <summary>
		/// Returns <c>true</c> if the game is running in split screen mode
		/// </summary>
		public static bool IsSplitScreen => isSplitScreen();

		/// <summary>
		/// Returns <c>true</c> if the script is executing within the editor
		/// </summary>
		public static bool IsEditor => isEditor();

		/// <summary>
		/// Returns <c>true</c> if the window has focus
		/// </summary>
		public static bool IsForegroundWindow => isForegroundWindow();

		/// <summary>
		/// Returns <c>true</c> if the exit was requested
		/// </summary>
		public static bool IsExitRequested => isExitRequested();

		/// <summary>
		/// Returns the current networking mode
		/// </summary>
		/// <remarks>Networking functionality</remarks>
		public static NetMode NetMode => getNetMode();

		/// <summary>
		/// Incremented once per frame before the scene is being rendered
		/// </summary>
		public static uint FrameNumber => getFrameNumber();

		/// <summary>
		/// Retrieves the current size of the viewport
		/// </summary>
		public static void GetViewportSize(ref Vector2 value) => getViewportSize(ref value);

		/// <summary>
		/// Retrieves the current resolution of the screen
		/// </summary>
		public static void GetScreenResolution(ref Vector2 value) => getScreenResolution(ref value);

		/// <summary>
		/// Returns the current mode of the window
		/// </summary>
		public static WindowMode WindowMode => getWindowMode();

		/// <summary>
		/// Updates the timer between garbage collection such that at the next opportunity garbage collection will be run
		/// </summary>
		/// <param name="fullPurge">If <c>true</c>, all possible memory will be freed</param>
		public static void ForceGarbageCollection(bool fullPurge = false) => forceGarbageCollection(fullPurge);

		/// <summary>
		/// Requests a one frame delay of garbage collection
		/// </summary>
		public static void DelayGarbageCollection() => delayGarbageCollection();

		/// <summary>
		/// Returns the current engine version
		/// </summary>
		public static string Version {
			get {
				stringBuffer.Clear();

				getVersion(stringBuffer);

				return stringBuffer.ToString();
			}
		}

		/// <summary>
		/// Gets or sets max frames per second, overrides console variable
		/// </summary>
		public static float MaxFPS {
			get => getMaxFPS();
			set => setMaxFPS(value);
		}

		/// <summary>
		/// Adds an engine defined axis mapping, cannot be remapped
		/// </summary>
		/// <param name="actionName">Friendly name of action</param>
		/// <param name="key">Key to bind in accordance with <see cref="Keys"/></param>
		/// <param name="shift"><c>true</c> if one of the Shift keys must be down when the KeyEvent is received to be acknowledged</param>
		/// <param name="ctrl"><c>true</c> if one of the Ctrl keys must be down when the KeyEvent is received to be acknowledged</param>
		/// <param name="alt"><c>true</c> if one of the Alt keys must be down when the KeyEvent is received to be acknowledged</param>
		/// <param name="cmd"><c>true</c> if one of the Cmd keys must be down when the KeyEvent is received to be acknowledged</param>
		public static void AddActionMapping(string actionName, string key, bool shift = false, bool ctrl = false, bool alt = false, bool cmd = false) {
			if (actionName == null)
				throw new ArgumentNullException(nameof(actionName));

			if (key == null)
				throw new ArgumentNullException(nameof(key));

			addActionMapping(actionName, key, shift, ctrl, alt, cmd);
		}

		/// <summary>
		/// Adds an engine defined mapping between an axis and key, cannot be remapped
		/// </summary>
		/// <param name="axisName">Friendly name of axis</param>
		/// <param name="key">Key to bind in accordance with <see cref="Keys"/></param>
		/// <param name="scale">Multiplier to use for the mapping when accumulating the axis value</param>
		public static void AddAxisMapping(string axisName, string key, float scale = 1.0f) {
			if (axisName == null)
				throw new ArgumentNullException(nameof(axisName));

			if (key == null)
				throw new ArgumentNullException(nameof(key));

			addAxisMapping(axisName, key, scale);
		}

		/// <summary>
		/// Sets the window title
		/// </summary>
		public static void SetTitle(string title) => setTitle(title);

		/// <summary>
		/// Requests application exit
		/// </summary>
		public static void RequestExit(bool force = false) => requestExit(force);
	}

	/// <summary>
	/// Functionality for access to the head mounted display
	/// </summary>
	public static partial class HeadMountedDisplay {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new StringBuilder(8192);

		/// <summary>
		/// Returns <c>true</c> if the head mounted display is enabled
		/// </summary>
		public static bool IsEnabled => isEnabled();

		/// <summary>
		/// Retrieves the name of the device
		/// </summary>
		public static string DeviceName {
			get {
				stringBuffer.Clear();

				getDeviceName(stringBuffer);

				return stringBuffer.ToString();
			}
		}
	}

	/// <summary>
	/// The top level representation of a map or a sandbox in which actors and components will exist and be rendered
	/// </summary>
	public static partial class World {
		/// <summary>
		/// Returns the actor count
		/// </summary>
		public static int ActorCount => getActorCount();

		/// <summary>
		/// Returns the frame delta time in seconds
		/// </summary>
		public static float DeltaTime => getDeltaSeconds();

		/// <summary>
		/// Returns time in seconds since the world was brought up for play, does not stop when the game pauses, not dilated or clamped
		/// </summary>
		public static float RealTime => getRealTimeSeconds();

		/// <summary>
		/// Returns time in seconds since the world was brought up for play, it is stopped when the game pauses, it is dilated or clamped
		/// </summary>
		public static float Time => getTimeSeconds();

		/// <summary>
		/// Gets or sets physics simulation for the world
		/// </summary>
		public static bool SimulatePhysics {
			get => getSimulatePhysics();
			set => setSimulatePhysics(value);
		}

		/// <summary>
		/// Returns the first actor in the world of the specified class, optionally with the specified name, this operation is slow and should be used with caution
		/// </summary>
		/// <param name="name">The name of the actor, may differ from the label in the editor</param>
		/// <typeparam name="T">The type of the actor</typeparam>
		/// <returns>An actor or <c>null</c> on failure</returns>
		public static T GetActor<T>(string name = null) where T : Actor {
			T actor = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = getActor(name, actor.Type);

			if (pointer != IntPtr.Zero) {
				actor.Pointer = pointer;

				return actor;
			}

			return null;
		}

		/// <summary>
		/// Returns the first actor in the world of the specified class and tag, this operation is slow and should be used with caution
		/// </summary>
		/// <param name="tag">The tag of the actor</param>
		/// <typeparam name="T">The type of the actor</typeparam>
		/// <returns>An actor or <c>null</c> on failure</returns>
		public static T GetActorByTag<T>(string tag) where T : Actor {
			T actor = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = getActorByTag(tag, actor.Type);

			if (pointer != IntPtr.Zero) {
				actor.Pointer = pointer;

				return actor;
			}

			return null;
		}

		/// <summary>
		/// Returns the first player controller
		/// </summary>
		/// <returns>A player controller or <c>null</c> if there is none</returns>
		public static PlayerController GetFirstPlayerController() {
			IntPtr pointer = getFirstPlayerController();

			if (pointer != IntPtr.Zero)
				return new PlayerController(pointer);

			return null;
		}

		/// <summary>
		/// Retrieves the current location of the <a href="https://docs.unrealengine.com/en-US/Engine/LevelStreaming/WorldBrowser/index.html">world origin</a>
		/// </summary>
		public static void GetWorldOrigin(ref Vector3 value) => getWorldOrigin(ref value);

		/// <summary>
		/// Sets the gravity applied to all objects in the world
		/// </summary>
		public static void SetGravity(float value) => setGravity(value);

		/// <summary>
		/// Sets <a href="https://docs.unrealengine.com/en-US/Engine/LevelStreaming/WorldBrowser/index.html">world origin</a> to the specified location
		/// </summary>
		public static void SetWorldOrigin(in Vector3 value) => setWorldOrigin(value);
	}

	/// <summary>
	/// Interface for engine objects
	/// </summary>
	public interface IObject {
		/// <summary/>
		string Name { get; }
		/// <summary/>
		bool GetBool(string name, ref bool value);
		/// <summary/>
		bool GetByte(string name, ref byte value);
		/// <summary/>
		bool GetShort(string name, ref short value);
		/// <summary/>
		bool GetInt(string name, ref int value);
		/// <summary/>
		bool GetLong(string name, ref long value);
		/// <summary/>
		bool GetUShort(string name, ref ushort value);
		/// <summary/>
		bool GetUInt(string name, ref uint value);
		/// <summary/>
		bool GetULong(string name, ref ulong value);
		/// <summary/>
		bool GetFloat(string name, ref float value);
		/// <summary/>
		bool GetDouble(string name, ref double value);
		/// <summary/>
		bool GetText(string name, ref string value);
		/// <summary/>
		bool SetBool(string name, bool value);
		/// <summary/>
		bool SetByte(string name, byte value);
		/// <summary/>
		bool SetShort(string name, short value);
		/// <summary/>
		bool SetInt(string name, int value);
		/// <summary/>
		bool SetLong(string name, long value);
		/// <summary/>
		bool SetUShort(string name, ushort value);
		/// <summary/>
		bool SetUInt(string name, uint value);
		/// <summary/>
		bool SetULong(string name, ulong value);
		/// <summary/>
		bool SetFloat(string name, float value);
		/// <summary/>
		bool SetDouble(string name, double value);
		/// <summary/>
		bool SetText(string name, string value);
	}

	/// <summary>
	/// Interface for console objects
	/// </summary>
	public partial class ConsoleObject : IEquatable<ConsoleObject> {
		private string name;

		internal string Name {
			get {
				if (!IsCreated)
					throw new InvalidOperationException();

				return name;
			}

			set {
				name = value;
			}
		}

		internal IntPtr Pointer {
			get {
				IntPtr pointer = ConsoleManager.findVariable(Name);

				if (pointer == IntPtr.Zero)
					throw new InvalidOperationException();

				return pointer;
			}
		}

		private protected ConsoleObject() { }

		internal ConsoleObject(string name) => Name = name;

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => name != null && ConsoleManager.isRegisteredVariable(name);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(ConsoleObject other) => IsCreated && name == other?.name;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => name.GetHashCode(StringComparison.CurrentCulture);

		/// <summary>
		/// Returns <c>true</c> if the object is a bool
		/// </summary>
		public bool IsBool => isBool(Pointer);

		/// <summary>
		/// Returns <c>true</c> if the object is an integer
		/// </summary>
		public bool IsInt => isInt(Pointer);

		/// <summary>
		/// Returns <c>true</c> if the object is a float
		/// </summary>
		public bool IsFloat => isFloat(Pointer);

		/// <summary>
		/// Returns <c>true</c> if the object is a string
		/// </summary>
		public bool IsString => isString(Pointer);
	}

	/// <summary>
	/// Interface for console variables
	/// </summary>
	public partial class ConsoleVariable : ConsoleObject {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new StringBuilder(8192);

		private protected ConsoleVariable() { }

		internal ConsoleVariable(string name) => Name = name;

		/// <summary>
		/// Returns the value as a bool, also works on integers and floats
		/// </summary>
		public bool GetBool() => getBool(Pointer);

		/// <summary>
		/// Returns the value as an integer, shouldn't be used on strings
		/// </summary>
		public int GetInt() => getInt(Pointer);

		/// <summary>
		/// Returns the value as a float, works on all types
		/// </summary>
		public float GetFloat() => getFloat(Pointer);

		/// <summary>
		/// Returns the value as a string, works on all types
		/// </summary>
		public string GetString() {
			stringBuffer.Clear();

			getString(Pointer, stringBuffer);

			return stringBuffer.ToString();
		}

		/// <summary>
		/// Sets the value as a bool
		/// </summary>
		public void SetBool(bool value) => setBool(Pointer, value);

		/// <summary>
		/// Sets the value as an integer
		/// </summary>
		public void SetInt(int value) => setInt(Pointer, value);

		/// <summary>
		/// Sets the value as a float
		/// </summary>
		public void SetFloat(float value) => setFloat(Pointer, value);

		/// <summary>
		/// Sets the value as a string
		/// </summary>
		public void SetString(string value) => setString(Pointer, value);

		/// <summary>
		/// Sets the static callback function that is called when the console variable value changes
		/// </summary>
		/// <param name="action">The static function to call when the value of variable is changed</param>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="action"/> is not static</exception>
		public void SetOnChangedCallback(ConsoleVariableDelegate action) {
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			if (!action.Method.IsStatic)
				throw new ArgumentException(nameof(action) + " should be static");

			setOnChangedCallback(Pointer, action.Method.MethodHandle.GetFunctionPointer());
		}

		/// <summary>
		/// Clears callback function
		/// </summary>
		public void ClearOnChangedCallback() => clearOnChangedCallback(Pointer);
	}

	/// <summary>
	/// The base class of an object that can be placed or spawned in a level
	/// </summary>
	public partial class Actor : IObject, IEquatable<Actor> {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new StringBuilder(8192);

		private IntPtr pointer;

		internal IntPtr Pointer {
			get {
				if (!IsSpawned)
					throw new InvalidOperationException();

				return pointer;
			}

			set {
				if (value == IntPtr.Zero)
					throw new InvalidOperationException();

				pointer = value;
			}
		}

		internal virtual ActorType Type => ActorType.Base;

		private protected Actor() { }

		internal Actor(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public Actor(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name, Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns <c>true</c> if the actor is spawned
		/// </summary>
		public bool IsSpawned => pointer != IntPtr.Zero && !isPendingKill(pointer);

		/// <summary>
		/// Returns <c>true</c> if the root component is <see cref="ComponentMobility.Movable"/>
		/// </summary>
		public bool IsRootComponentMovable => isRootComponentMovable(Pointer);

		/// <summary>
		/// Returns <c>true</c> if any component of the actor is overlapping any component of another one
		/// </summary>
		public bool IsOverlappingActor(Actor other) {
			if (other == null)
				throw new ArgumentNullException(nameof(other));

			return isOverlappingActor(Pointer, other.Pointer);
		}

		/// <summary>
		/// Returns the name of the actor
		/// </summary>
		public string Name {
			get {
				stringBuffer.Clear();

				Object.getName(Pointer, stringBuffer);

				return stringBuffer.ToString();
			}
		}

		/// <summary>
		/// Retrieves the value of the bool property
		/// </summary>
		public bool GetBool(string name, ref bool value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getBool(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the byte property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetByte(string name, ref byte value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getByte(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetShort(string name, ref short value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getShort(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetInt(string name, ref int value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getInt(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetLong(string name, ref long value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getLong(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetUShort(string name, ref ushort value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getUShort(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetUInt(string name, ref uint value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getUInt(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetULong(string name, ref ulong value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getULong(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the float property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetFloat(string name, ref float value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getFloat(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the double property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetDouble(string name, ref double value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getDouble(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the text property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetText(string name, ref string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			stringBuffer.Clear();

			if (Object.getText(Pointer, name, stringBuffer)) {
				value = stringBuffer.ToString();

				return true;
			}

			return false;
		}

		/// <summary>
		/// Sets the value of the bool property
		/// </summary>
		public bool SetBool(string name, bool value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setBool(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the byte property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetByte(string name, byte value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setByte(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetShort(string name, short value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setShort(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetInt(string name, int value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setInt(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetLong(string name, long value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setLong(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the unsigned short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetUShort(string name, ushort value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setUShort(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the unsigned integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetUInt(string name, uint value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setUInt(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the unsigned long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetULong(string name, ulong value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setULong(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the float property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetFloat(string name, float value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setFloat(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the double property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetDouble(string name, double value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setDouble(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the text property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetText(string name, string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (value == null)
				throw new ArgumentNullException(nameof(value));

			return Object.setText(Pointer, name, value);
		}

		/// <summary>
		/// Gets or sets the component that handles input for the actor, if enabled
		/// </summary>
		public InputComponent InputComponent {
			get {
				IntPtr pointer = getInputComponent(Pointer);

				if (pointer != IntPtr.Zero)
					return new InputComponent(pointer);

				return null;
			}

			set {
				if (value == null)
					throw new ArgumentNullException(nameof(value));

				setInputComponent(Pointer, value.Pointer);
			}
		}

		/// <summary>
		/// Gets or sets whether the all input on the stack below this actor will not be considered
		/// </summary>
		public bool BlockInput {
			get => getBlockInput(Pointer);
			set => setBlockInput(Pointer, value);
		}

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(Actor other) => IsSpawned && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Returns <c>true</c> if the actor is destroyed or already marked for destruction, <c>false</c> if indestructible
		/// </summary>
		public bool Destroy() => destroy(Pointer);

		/// <summary>
		/// Renames the actor
		/// </summary>
		public void Rename(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			rename(Pointer, name);
		}

		/// <summary>
		/// Sets the actor to be hidden
		/// </summary>
		public void Hide(bool value) => hide(Pointer, value);

		/// <summary>
		/// Teleports an actor to a new location
		/// </summary>
		/// <param name="destinationLocation">The target destination point</param>
		/// <param name="destinationRotation">The target rotation at the destination</param>
		/// <param name="isATest">If <c>true</c>, shouldn't cause any notifications (used by AI pathfinding, for example)</param>
		/// <param name="noCheck">If <c>true</c>, should skip checking for positioning in the world or relative to other actors trying to slightly move the actor out</param>
		/// <returns><c>true</c> if the actor has been successfully moved</returns>
		public bool TeleportTo(in Vector3 destinationLocation, in Quaternion destinationRotation, bool isATest = false, bool noCheck = false) => teleportTo(Pointer, destinationLocation, destinationRotation, isATest, noCheck);

		/// <summary>
		/// Returns the distance from this actor to another one
		/// </summary>
		public float GetDistanceTo(Actor actor) {
			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			return getDistanceTo(Pointer, actor.Pointer);
		}

		/// <summary>
		/// Retrieves the bounding box of all components of the actor
		/// </summary>
		/// <param name="onlyCollidingComponents">If <c>true</c>, will only return the bounding box for components with enabled collision</param>
		/// <param name="origin">The center of the actor in world space</param>
		/// <param name="extent">Half the actor's size in 3D space</param>
		public void GetBounds(bool onlyCollidingComponents, ref Vector3 origin, ref Vector3 extent) => getBounds(Pointer, onlyCollidingComponents, ref origin, ref extent);

		/// <summary>
		/// Returns the component of the actor if matches the specified type, optionally with the specified name
		/// </summary>
		/// <returns>A component or <c>null</c> on failure</returns>
		public T GetComponent<T>(string name = null) where T : ActorComponent {
			T component = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = getComponent(Pointer, name, component.Type);

			if (pointer != IntPtr.Zero) {
				component.Pointer = pointer;

				return component;
			}

			return null;
		}

		/// <summary>
		/// Returns the root component of the actor if matches the specified type
		/// </summary>
		/// <returns>A component or <c>null</c> on failure</returns>
		public T GetRootComponent<T>() where T : SceneComponent {
			T component = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = getRootComponent(Pointer, component.Type);

			if (pointer != IntPtr.Zero) {
				component.Pointer = pointer;

				return component;
			}

			return null;
		}

		/// <summary>
		/// Sets the root component, the actor should be the owner of the component
		/// </summary>
		/// <returns><c>true</c> if successful</returns>
		public bool SetRootComponent(SceneComponent component) {
			if (component == null)
				throw new ArgumentNullException(nameof(component));

			return setRootComponent(Pointer, component.Pointer);
		}

		/// <summary>
		/// Sets the lifespan of the actor, when it expires the actor will be destroyed, if requested lifespan set to zero, the timer is cleared and the actor will remain alive
		/// </summary>
		/// <param name="lifeSpan">Lifespan time in seconds</param>
		public void SetLifeSpan(float lifeSpan) => setLifeSpan(Pointer, lifeSpan);

		/// <summary>
		/// Sets the collision detection of the actor
		/// </summary>
		public void SetEnableCollision(bool value) => setEnableCollision(Pointer, value);

		/// <summary>
		/// Adds a tag to the actor that can be used for grouping and categorizing
		/// </summary>
		public void AddTag(string tag) => addTag(Pointer, tag);

		/// <summary>
		/// Removes a tag from the actor
		/// </summary>
		public void RemoveTag(string tag) => removeTag(Pointer, tag);

		/// <summary>
		/// Indicates whether the actor has a tag
		/// </summary>
		public bool HasTag(string tag) => hasTag(Pointer, tag);
	}

	/// <summary>
	/// A camera viewpoint that can be placed in a level
	/// </summary>
	public partial class Camera : Actor {
		internal override ActorType Type => ActorType.Camera;

		private protected Camera() { }

		internal Camera(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public Camera(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name, Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// The base class of actors that can be possessed by players or AI
	/// </summary>
	public partial class Pawn : Actor {
		internal override ActorType Type => ActorType.Pawn;

		private protected Pawn() { }

		internal Pawn(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public Pawn(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name, Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Adds yaw (turn) input to the controller, if it's a local <see cref="PlayerController"/>
		/// </summary>
		public void AddControllerYawInput(float value) => addControllerYawInput(Pointer, value);

		/// <summary>
		/// Adds pitch (look up) input to the controller, if it's a local <see cref="PlayerController"/>
		/// </summary>
		public void AddControllerPitchInput(float value) => addControllerPitchInput(Pointer, value);

		/// <summary>
		/// Adds roll input to the controller, if it's a local <see cref="PlayerController"/>
		/// </summary>
		public void AddControllerRollInput(float value) => addControllerRollInput(Pointer, value);

		/// <summary>
		/// Adds movement input along the given world direction vector (usually normalized)
		/// </summary>
		/// <param name="worldDirection">Direction in world space to apply input</param>
		/// <param name="scaleValue">Scale to apply to input, 0.5f applies half the normal value, while -1.0 would reverse the direction</param>
		/// <param name="force">If <c>true</c>, always add the input, ignoring the result of <see cref="Controller.IsMoveInputIgnored"/></param>
		public void AddMovementInput(in Vector3 worldDirection, float scaleValue = 1.0f, bool force = false) => addMovementInput(Pointer, worldDirection, scaleValue, force);

		/// <summary>
		/// Retrieves vector direction of gravity
		/// </summary>
		public void GetGravityDirection(ref Vector3 value) => getGravityDirection(Pointer, ref value);
	}

	/// <summary>
	/// Represents a character that have a mesh, collision, and built-in movement logic
	/// </summary>
	public partial class Character : Pawn {
		internal override ActorType Type => ActorType.Character;

		private protected Character() { }

		internal Character(IntPtr pointer) => Pointer = pointer;
	}

	/// <summary>
	/// Non-physical actors that can possess a <see cref="Pawn"/> to control its actions
	/// </summary>
	public abstract partial class Controller : Actor {
		private protected Controller() { }

		/// <summary>
		/// Returns <c>true</c> if look input is ignored
		/// </summary>
		public bool IsLookInputIgnored => isLookInputIgnored(Pointer);

		/// <summary>
		/// Returns <c>true</c> if movement input is ignored
		/// </summary>
		public bool IsMoveInputIgnored => isMoveInputIgnored(Pointer);

		/// <summary>
		/// Returns <c>true</c> if the controller is a <see cref="PlayerController"/>
		/// </summary>
		public bool IsPlayerController => isPlayerController(Pointer);

		/// <summary>
		/// Returns the controller's pawn or <c>null</c> on failure
		/// </summary>
		public Pawn GetPawn() {
			IntPtr pointer = getPawn(Pointer);

			if (pointer != IntPtr.Zero)
				return new Pawn(pointer);

			return null;
		}

		/// <summary>
		/// Checks line to center and top of other actor
		/// </summary>
		/// <param name="actor">The actor whose visibility is being checked</param>
		/// <param name="viewPoint">Eye position visibility is being checked from, if <see cref="Vector3.Zero"/> is passed in, uses current view target's eye position</param>
		/// <param name="alternateChecks">Used only in <see cref="AIController"/> implementation</param>
		/// <returns><c>true</c> if controller's <see cref="Pawn"/> can see other actor</returns>
		public bool LineOfSightTo(Actor actor, in Vector3 viewPoint, bool alternateChecks = false) {
			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			return lineOfSightTo(Pointer, actor.Pointer, viewPoint, alternateChecks);
		}

		/// <summary>
		/// Sets the initial location and rotation of the controller, as well as the control rotation
		/// </summary>
		public void SetInitialLocationAndRotation(in Vector3 newLocation, in Quaternion newRotation) => setInitialLocationAndRotation(Pointer, newLocation, newRotation);

		/// <summary>
		/// Locks or unlocks look input, consecutive calls stack up and require the same amount of calls to undo, or can all be undone using <see cref="ResetIgnoreLookInput"/>
		/// </summary>
		public void SetIgnoreLookInput(bool value) => setIgnoreLookInput(Pointer, value);

		/// <summary>
		/// Locks or unlocks movement input, consecutive calls stack up and require the same amount of calls to undo, or can all be undone using <see cref="ResetIgnoreMoveInput"/>
		/// </summary>
		public void SetIgnoreMoveInput(bool value) => setIgnoreMoveInput(Pointer, value);

		/// <summary>
		/// Stops ignoring look input by resetting the ignore look input state
		/// </summary>
		public void ResetIgnoreLookInput() => resetIgnoreLookInput(Pointer);

		/// <summary>
		/// Stops ignoring move input by resetting the ignore move input state
		/// </summary>
		public void ResetIgnoreMoveInput() => resetIgnoreMoveInput(Pointer);
	}

	/// <summary>
	/// The base class of controllers for an AI-controlled <see cref="Pawn"/>
	/// </summary>
	public partial class AIController : Controller {
		internal override ActorType Type => ActorType.AIController;

		private protected AIController() { }

		internal AIController(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public AIController(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name, Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Gets or sets whether strafing allowed during movement
		/// </summary>
		public bool AllowStrafe {
			get => getAllowStrafe(Pointer);
			set => setAllowStrafe(Pointer, value);
		}

		/// <summary>
		/// Clears focus for given priority, will clear focal point as a result
		/// </summary>
		public void ClearFocus(AIFocusPriority priority = AIFocusPriority.High) => clearFocus(Pointer, priority);

		/// <summary>
		/// Retrieves the final position that controller should be looking at
		/// </summary>
		public void GetFocalPoint(ref Vector3 value) => getFocalPoint(Pointer, ref value);

		/// <summary>
		/// Sets focal point for given priority as absolute position or offset from base
		/// </summary>
		public void SetFocalPoint(in Vector3 newFocus, AIFocusPriority priority) => setFocalPoint(Pointer, newFocus, priority);

		/// <summary>
		/// Returns the focused actor or <c>null</c> on failure
		/// </summary>
		public Actor GetFocusActor() {
			IntPtr pointer = getFocusActor(Pointer);

			if (pointer != IntPtr.Zero)
				return new Actor(pointer);

			return null;
		}

		/// <summary>
		/// Sets focus actor for given priority, will set focal point as a result
		/// </summary>
		public void SetFocus(Actor newFocus, AIFocusPriority priority = AIFocusPriority.High) {
			if (newFocus == null)
				throw new ArgumentNullException(nameof(newFocus));

			setFocus(Pointer, newFocus.Pointer, priority);
		}
	}

	/// <summary>
	/// A component that is used by human players to control a <see cref="Pawn"/>
	/// </summary>
	public partial class PlayerController : Controller {
		internal override ActorType Type => ActorType.PlayerController;

		private protected PlayerController() { }

		internal PlayerController(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public PlayerController(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name, Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns <c>true</c> if game is currently paused
		/// </summary>
		public bool IsPaused => isPaused(Pointer);

		/// <summary>
		/// Gets or sets whether the mouse cursor should be displayed
		/// </summary>
		public bool ShowMouseCursor {
			get => getShowMouseCursor(Pointer);
			set => setShowMouseCursor(Pointer, value);
		}

		/// <summary>
		/// Retrieves the X and Y screen coordinates of the mouse cursor
		/// </summary>
		/// <returns><c>true</c> if successful</returns>
		public bool GetMousePosition(ref float x, ref float y) => getMousePosition(Pointer, ref x, ref y);

		/// <summary>
		/// Retrieves player's point of view for the AI
		/// </summary>
		public void GetPlayerViewPoint(ref Vector3 location, ref Quaternion rotation) => getPlayerViewPoint(Pointer, ref location, ref rotation);

		/// <summary>
		/// Returns the input manager or <c>null</c> on failure
		/// </summary>
		public PlayerInput GetPlayerInput() {
			IntPtr pointer = getPlayerInput(Pointer);

			if (pointer != IntPtr.Zero)
				return new PlayerInput(pointer);

			return null;
		}

		/// <summary>
		/// Positions the mouse cursor in screen space, in pixels
		/// </summary>
		public void SetMousePosition(float x, float y) => setMousePosition(Pointer, x, y);

		/// <summary>
		/// Executes the command on the <see cref="Player"/> object, <c>DumpConsoleCommands</c> command can be used to list all available variables and commands
		/// </summary>
		/// <param name="command">A command to execute, string of commands optionally separated by a <c>|</c> symbol</param>
		/// <param name="writeToLog"></param>
		public void ConsoleCommand(string command, bool writeToLog) => consoleCommand(Pointer, command, writeToLog);

		/// <summary>
		/// Attempts to pause a local game
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetPause(bool value) => setPause(Pointer, value);

		/// <summary>
		/// Sets the view target
		/// </summary>
		/// <param name="newViewTarget">An actor to set as view target</param>
		public void SetViewTarget(Actor newViewTarget) {
			if (newViewTarget == null)
				throw new ArgumentNullException(nameof(newViewTarget));

			setViewTarget(Pointer, newViewTarget.Pointer);
		}

		/// <summary>
		/// Sets the view target blending with variable control
		/// </summary>
		/// <param name="newViewTarget">An actor to set as view target</param>
		/// <param name="time">Time taken to blend</param>
		/// <param name="exponent">Exponent, used by certain <see cref="BlendType"/> to control the shape of the curve</param>
		/// <param name="type">The blending type</param>
		/// <param name="lockOutgoing">If <c>true</c>, lock outgoing view target to last frame's camera position for the remainder of the blend</param>
		public void SetViewTargetWithBlend(Actor newViewTarget, float time = 0.0f, float exponent = 0.0f, BlendType type = BlendType.Linear, bool lockOutgoing = false) {
			if (newViewTarget == null)
				throw new ArgumentNullException(nameof(newViewTarget));

			setViewTargetWithBlend(Pointer, newViewTarget.Pointer, time, exponent, type, lockOutgoing);
		}

		/// <summary>
		/// Adds yaw (turn) input
		/// </summary>
		public void AddYawInput(float value) => addYawInput(Pointer, value);

		/// <summary>
		/// Adds pitch (look up) input
		/// </summary>
		public void AddPitchInput(float value) => addPitchInput(Pointer, value);

		/// <summary>
		/// Adds roll input
		/// </summary>
		public void AddRollInput(float value) => addRollInput(Pointer, value);
	}

	/// <summary>
	/// The base class of brushes for level construction
	/// </summary>
	public partial class Brush : Actor {
		internal override ActorType Type => ActorType.Brush;

		private protected Brush() { }

		internal Brush(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public Brush(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name, Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// An editable 3D volume placed in a level, different types of volumes perform different functions
	/// </summary>
	public abstract partial class Volume : Brush {
		private protected Volume() { }

		/// <summary>
		/// Returns <c>true</c> if a point or sphere overlaps the volume
		/// </summary>
		public bool EncompassesPoint(in Vector3 point, float sphereRadius, ref float distanceToPoint) => encompassesPoint(Pointer, point, sphereRadius, ref distanceToPoint);
	}

	/// <summary>
	/// A sound actor that can be placed in a level
	/// </summary>
	public partial class AmbientSound : Actor {
		internal override ActorType Type => ActorType.AmbientSound;

		private protected AmbientSound() { }

		internal AmbientSound(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public AmbientSound(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name, Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// A light actor that can be placed in a level
	/// </summary>
	public abstract partial class Light : Actor {
		private protected Light() { }
	}

	/// <summary>
	/// Simulates light that is being emitted from a source that is infinitely far away
	/// </summary>
	public partial class DirectionalLight : Light {
		internal override ActorType Type => ActorType.DirectionalLight;

		private protected DirectionalLight() { }

		internal DirectionalLight(IntPtr pointer) => Pointer = pointer;
	}

	/// <summary>
	/// Emits light in all directions from the light bulb's tungsten filament
	/// </summary>
	public partial class PointLight : Light {
		internal override ActorType Type => ActorType.PointLight;

		private protected PointLight() { }

		internal PointLight(IntPtr pointer) => Pointer = pointer;
	}

	/// <summary>
	/// Emits light into the scene from a rectangular plane with a defined width and height
	/// </summary>
	public partial class RectLight : Light {
		internal override ActorType Type => ActorType.RectLight;

		private protected RectLight() { }

		internal RectLight(IntPtr pointer) => Pointer = pointer;
	}

	/// <summary>
	/// Emits light from a single point in a cone shape
	/// </summary>
	public partial class SpotLight : Light {
		internal override ActorType Type => ActorType.SpotLight;

		private protected SpotLight() { }

		internal SpotLight(IntPtr pointer) => Pointer = pointer;
	}

	/// <summary>
	/// The base class of playable sound objects
	/// </summary>
	public abstract partial class SoundBase : IEquatable<SoundBase> {
		private IntPtr pointer;

		internal IntPtr Pointer {
			get {
				if (!IsCreated)
					throw new InvalidOperationException();

				return pointer;
			}

			set {
				if (value == IntPtr.Zero)
					throw new InvalidOperationException();

				pointer = value;
			}
		}

		private protected SoundBase() { }

		internal SoundBase(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && Object.isValid(pointer);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(SoundBase other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Returns the duration of a sound object in seconds
		/// </summary>
		public float Duration => getDuration(Pointer);
	}

	/// <summary>
	/// A playable sound object for raw wave files
	/// </summary>
	public partial class SoundWave : SoundBase {
		private protected SoundWave() { }

		internal SoundWave(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Finds and loads a sound wave by name
		/// </summary>
		/// <returns>A sound wave or <c>null</c> on failure</returns>
		public static SoundWave Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.SoundWave, name);

			if (pointer != IntPtr.Zero)
				return new SoundWave(pointer);

			return null;
		}

		/// <summary>
		/// Gets or sets whether the sound wave will be looped if played directly
		/// </summary>
		public bool Loop {
			get => getLoop(Pointer);
			set => setLoop(Pointer, value);
		}
	}

	/// <summary>
	/// The base class of animation assets that can be played and evaluated to produce a pose
	/// </summary>
	public abstract partial class AnimationAsset : IEquatable<AnimationAsset> {
		private IntPtr pointer;

		internal IntPtr Pointer {
			get {
				if (!IsCreated)
					throw new InvalidOperationException();

				return pointer;
			}

			set {
				if (value == IntPtr.Zero)
					throw new InvalidOperationException();

				pointer = value;
			}
		}

		private protected AnimationAsset() { }

		internal AnimationAsset(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && Object.isValid(pointer);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(AnimationAsset other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();
	}

	/// <summary>
	/// The base class of animation sequences
	/// </summary>
	public abstract partial class AnimationSequenceBase : AnimationAsset {
		private protected AnimationSequenceBase() { }
	}

	/// <summary>
	/// A single animation asset that can be played
	/// </summary>
	public partial class AnimationSequence : AnimationSequenceBase {
		private protected AnimationSequence() { }

		internal AnimationSequence(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Finds and loads an animation sequence by name
		/// </summary>
		/// <returns>An animation sequence or <c>null</c> on failure</returns>
		public static AnimationSequence Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.AnimationSequence, name);

			if (pointer != IntPtr.Zero)
				return new AnimationSequence(pointer);

			return null;
		}
	}

	/// <summary>
	/// The base class of animation composites
	/// </summary>
	public abstract partial class AnimationCompositeBase : AnimationSequenceBase {
		private protected AnimationCompositeBase() { }
	}

	/// <summary>
	/// A single animation asset that can combine and selectively play animations
	/// </summary>
	public partial class AnimationMontage : AnimationCompositeBase {
		private protected AnimationMontage() { }

		internal AnimationMontage(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Finds and loads an animation montage by name
		/// </summary>
		/// <returns>An animation montage or <c>null</c> on failure</returns>
		public static AnimationMontage Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.AnimationMontage, name);

			if (pointer != IntPtr.Zero)
				return new AnimationMontage(pointer);

			return null;
		}
	}

	/// <summary>
	/// An animation representation
	/// </summary>
	public partial class AnimationInstance : IEquatable<AnimationInstance> {
		private IntPtr pointer;

		internal IntPtr Pointer {
			get {
				if (!IsCreated)
					throw new InvalidOperationException();

				return pointer;
			}

			set {
				if (value == IntPtr.Zero)
					throw new InvalidOperationException();

				pointer = value;
			}
		}

		private protected AnimationInstance() { }

		internal AnimationInstance(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && Object.isValid(pointer);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(AnimationInstance other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Returns the current active animation montage or <c>null</c> on failure
		/// </summary>
		public AnimationMontage GetCurrentActiveMontage() {
			IntPtr pointer = getCurrentActiveMontage(Pointer);

			if (pointer != IntPtr.Zero)
				return new AnimationMontage(pointer);

			return null;
		}

		/// <summary>
		/// Plays an animation montage
		/// </summary>
		/// <returns>The length of the animation montage in seconds, or 0.0f if failed to play</returns>
		public float MontagePlay(AnimationMontage montage, float playRate = 1.0f, float timeToStartMontageAt = 0.0f, bool stopAllMontages = true) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			return montagePlay(Pointer, montage.Pointer, playRate, timeToStartMontageAt, stopAllMontages);
		}

		/// <summary>
		/// Pauses an animation montage
		/// </summary>
		public void MontagePause(AnimationMontage montage) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			montagePause(Pointer, montage.Pointer);
		}

		/// <summary>
		/// Resumes a paused animation montage
		/// </summary>
		public void MontageResume(AnimationMontage montage) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			montageResume(Pointer, montage.Pointer);
		}
	}

	/// <summary>
	/// A player representation
	/// </summary>
	public partial class Player : IEquatable<Player> {
		private IntPtr pointer;

		internal IntPtr Pointer {
			get {
				if (!IsCreated)
					throw new InvalidOperationException();

				return pointer;
			}

			set {
				if (value == IntPtr.Zero)
					throw new InvalidOperationException();

				pointer = value;
			}
		}

		private protected Player() { }

		internal Player(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && Object.isValid(pointer);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(Player other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();
	}

	/// <summary>
	/// An input manager of <see cref="PlayerController"/>
	/// </summary>
	public partial class PlayerInput : IEquatable<PlayerInput> {
		private IntPtr pointer;

		internal IntPtr Pointer {
			get {
				if (!IsCreated)
					throw new InvalidOperationException();

				return pointer;
			}

			set {
				if (value == IntPtr.Zero)
					throw new InvalidOperationException();

				pointer = value;
			}
		}

		private protected PlayerInput() { }

		internal PlayerInput(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && Object.isValid(pointer);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(PlayerInput other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Returns <c>true</c> if a key is pressed
		/// </summary>
		public bool IsKeyPressed(string key) {
			if (key == null)
				throw new ArgumentNullException(nameof(key));

			return isKeyPressed(Pointer, key);
		}

		/// <summary>
		/// Returns the time a key was pressed
		/// </summary>
		public float GetTimeKeyPressed(string key) {
			if (key == null)
				throw new ArgumentNullException(nameof(key));

			return getTimeKeyPressed(Pointer, key);
		}

		/// <summary>
		/// Retrieves mouse sensitivity
		/// </summary>
		public void GetMouseSensitivity(ref Vector2 value) => getMouseSensitivity(Pointer, ref value);

		/// <summary>
		/// Sets mouse sensitivity
		/// </summary>
		public void SetMouseSensitivity(in Vector2 value) => setMouseSensitivity(Pointer, value);
	}

	/// <summary>
	/// An asset that provides an intuitive node-based interface
	/// </summary>
	public partial class Blueprint : IEquatable<Blueprint> {
		private IntPtr pointer;

		internal IntPtr Pointer {
			get {
				if (!IsCreated)
					throw new InvalidOperationException();

				return pointer;
			}

			set {
				if (value == IntPtr.Zero)
					throw new InvalidOperationException();

				pointer = value;
			}
		}

		private protected Blueprint() { }

		internal Blueprint(IntPtr pointer) => Pointer = pointer;

		internal bool IsValidClass(ActorType type) => isValidActorClass(Pointer, type);

		internal bool IsValidClass(ComponentType type) => isValidComponentClass(Pointer, type);

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && Object.isValid(pointer);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(Blueprint other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Finds and loads a blueprint by name
		/// </summary>
		/// <returns>A blueprint or <c>null</c> on failure</returns>
		public static Blueprint Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.Blueprint, name);

			if (pointer != IntPtr.Zero)
				return new Blueprint(pointer);

			return null;
		}
	}

	/// <summary>
	/// A render asset that can be streamed at runtime
	/// </summary>
	public abstract partial class StreamableRenderAsset : IEquatable<StreamableRenderAsset> {
		private IntPtr pointer;

		internal IntPtr Pointer {
			get {
				if (!IsCreated)
					throw new InvalidOperationException();

				return pointer;
			}

			set {
				if (value == IntPtr.Zero)
					throw new InvalidOperationException();

				pointer = value;
			}
		}

		private protected StreamableRenderAsset() { }

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && Object.isValid(pointer);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(StreamableRenderAsset other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();
	}

	/// <summary>
	/// A piece of geometry that consists of a static set of polygons
	/// </summary>
	public partial class StaticMesh : StreamableRenderAsset {
		private protected StaticMesh() { }

		internal StaticMesh(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// A basic cone
		/// </summary>
		public static readonly StaticMesh Cone = Load("/Engine/BasicShapes/Cone");

		/// <summary>
		/// A basic cylinder
		/// </summary>
		public static readonly StaticMesh Cylinder = Load("/Engine/BasicShapes/Cylinder");

		/// <summary>
		/// A basic cube
		/// </summary>
		public static readonly StaticMesh Cube = Load("/Engine/BasicShapes/Cube");

		/// <summary>
		/// A basic plane
		/// </summary>
		public static readonly StaticMesh Plane = Load("/Engine/BasicShapes/Plane");

		/// <summary>
		/// A basic sphere
		/// </summary>
		public static readonly StaticMesh Sphere = Load("/Engine/BasicShapes/Sphere");

		/// <summary>
		/// Finds and loads a static mesh by name
		/// </summary>
		/// <returns>A static mesh or <c>null</c> on failure</returns>
		public static StaticMesh Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.StaticMesh, name);

			if (pointer != IntPtr.Zero)
				return new StaticMesh(pointer);

			return null;
		}
	}

	/// <summary>
	/// A geometry bound to a hierarchical skeleton of bones which can be animated
	/// </summary>
	public partial class SkeletalMesh : StreamableRenderAsset {
		private protected SkeletalMesh() { }

		internal SkeletalMesh(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Finds and loads a skeletal mesh by name
		/// </summary>
		/// <returns>A skeletal mesh or <c>null</c> on failure</returns>
		public static SkeletalMesh Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.SkeletalMesh, name);

			if (pointer != IntPtr.Zero)
				return new SkeletalMesh(pointer);

			return null;
		}
	}

	/// <summary>
	/// A representation of the surface of an object
	/// </summary>
	public abstract partial class Texture : StreamableRenderAsset {
		private protected Texture() { }
	}

	/// <summary>
	/// A single texture asset
	/// </summary>
	public partial class Texture2D : Texture {
		private protected Texture2D() { }

		internal Texture2D(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Finds and loads a texture by name
		/// </summary>
		/// <returns>A texture or <c>null</c> on failure</returns>
		public static Texture2D Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.Texture2D, name);

			if (pointer != IntPtr.Zero)
				return new Texture2D(pointer);

			return null;
		}

		/// <summary>
		/// Retrieves size of the texture
		/// </summary>
		public void GetSize(ref Vector2 value) => getSize(Pointer, ref value);
	}

	/// <summary>
	/// The base class of components that define reusable behavior and can be added to different types of actors
	/// </summary>
	public partial class ActorComponent : IObject, IEquatable<ActorComponent> {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new StringBuilder(8192);

		private IntPtr pointer;

		internal IntPtr Pointer {
			get {
				if (!IsCreated)
					throw new InvalidOperationException();

				return pointer;
			}

			set {
				if (value == IntPtr.Zero)
					throw new InvalidOperationException();

				pointer = value;
			}
		}

		internal virtual ComponentType Type => ComponentType.Actor;

		private protected ActorComponent() { }

		internal ActorComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && !Object.isPendingKill(pointer);

		/// <summary>
		/// Returns the name of the component
		/// </summary>
		public string Name {
			get {
				stringBuffer.Clear();

				Object.getName(Pointer, stringBuffer);

				return stringBuffer.ToString();
			}
		}

		/// <summary>
		/// Retrieves the value of the bool property
		/// </summary>
		public bool GetBool(string name, ref bool value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getBool(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the byte property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetByte(string name, ref byte value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getByte(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetShort(string name, ref short value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getShort(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetInt(string name, ref int value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getInt(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetLong(string name, ref long value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getLong(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetUShort(string name, ref ushort value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getUShort(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetUInt(string name, ref uint value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getUInt(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetULong(string name, ref ulong value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getULong(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the float property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetFloat(string name, ref float value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getFloat(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the double property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetDouble(string name, ref double value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getDouble(Pointer, name, ref value);
		}

		/// <summary>
		/// Retrieves the value of the text property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetText(string name, ref string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			stringBuffer.Clear();

			if (Object.getText(Pointer, name, stringBuffer)) {
				value = stringBuffer.ToString();

				return true;
			}

			return false;
		}

		/// <summary>
		/// Sets the value of the bool property
		/// </summary>
		public bool SetBool(string name, bool value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setBool(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the byte property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetByte(string name, byte value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setByte(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetShort(string name, short value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setShort(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetInt(string name, int value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setInt(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetLong(string name, long value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setLong(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the unsigned short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetUShort(string name, ushort value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setUShort(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the unsigned integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetUInt(string name, uint value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setUInt(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the unsigned long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetULong(string name, ulong value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setULong(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the float property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetFloat(string name, float value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setFloat(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the double property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetDouble(string name, double value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setDouble(Pointer, name, value);
		}

		/// <summary>
		/// Sets the value of the text property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetText(string name, string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (value == null)
				throw new ArgumentNullException(nameof(value));

			return Object.setText(Pointer, name, value);
		}

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(ActorComponent other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Renames the component
		/// </summary>
		public void Rename(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			Object.rename(Pointer, name);
		}

		/// <summary>
		/// Unregister the component, removes it from its outer actor's components array and marks for pending kill
		/// </summary>
		/// <param name="promoteChildren">Promotes the children component in the hierarchy during the destruction</param>
		public void Destroy(bool promoteChildren = false) => destroy(Pointer, promoteChildren);

		/// <summary>
		/// Returns <c>true</c> if the component's owner is selected in the editor
		/// </summary>
		public bool IsOwnerSelected => isOwnerSelected(Pointer);

		/// <summary>
		/// Returns the owner of the component or <c>null</c> on failure
		/// </summary>
		public Actor GetActor() {
			IntPtr pointer = getOwner(Pointer);

			if (pointer != IntPtr.Zero)
				return new Actor(pointer);

			return null;
		}

		/// <summary>
		/// Adds a tag to the component that can be used for grouping and categorizing
		/// </summary>
		public void AddTag(string tag) => addTag(Pointer, tag);

		/// <summary>
		/// Removes a tag from the component
		/// </summary>
		public void RemoveTag(string tag) => removeTag(Pointer, tag);

		/// <summary>
		/// Indicates whether the component has a tag
		/// </summary>
		public bool HasTag(string tag) => hasTag(Pointer, tag);
	}

	/// <summary>
	/// An input component is a transient component that enables an actor to bind various forms of input events to delegate functions
	/// </summary>
	public partial class InputComponent : ActorComponent {
		internal override ComponentType Type => ComponentType.Input;

		private protected InputComponent() { }

		internal InputComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Indicates whether the component has any input bindings
		/// </summary>
		public bool HasBindings => hasBindings(Pointer);

		/// <summary>
		/// Gets the number of action bindings
		/// </summary>
		public int ActionBindingsNumber => getActionBindingsNumber(Pointer);

		/// <summary>
		/// Gets or sets whether any components lower on the input stack should be allowed to receive input
		/// </summary>
		public bool BlockInput {
			get => getBlockInput(Pointer);
			set => setBlockInput(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the priority of the input component when pushed in to the stack
		/// </summary>
		public int Priority {
			get => getPriority(Pointer);
			set => setPriority(Pointer, value);
		}

		/// <summary>
		/// Removes all action bindings
		/// </summary>
		public void ClearActionBindings() => clearActionBindings(Pointer);

		/// <summary>
		/// Binds a static callback function to an action defined in the project settings or by using <see cref="Engine.AddActionMapping"/>
		/// </summary>
		/// <param name="actionName">The name of the action</param>
		/// <param name="keyEvent">The type of input behavior</param>
		/// <param name="action">The static function to call when the input is triggered</param>
		/// <param name="executedWhenPaused">If <c>true</c>, executes even if the game is paused</param>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="action"/> is not static</exception>
		public void BindAction(string actionName, InputEvent keyEvent, InputDelegate action, bool executedWhenPaused = false) {
			if (actionName == null)
				throw new ArgumentNullException(nameof(actionName));

			if (action == null)
				throw new ArgumentNullException(nameof(action));

			if (!action.Method.IsStatic)
				throw new ArgumentException(nameof(action) + " should be static");

			bindAction(Pointer, actionName, keyEvent, executedWhenPaused, action.Method.MethodHandle.GetFunctionPointer());
		}

		/// <summary>
		/// Binds a static callback function an axis defined in the project settings or by using <see cref="Engine.AddAxisMapping"/>
		/// </summary>
		/// <param name="axisName">The name of the axis</param>
		/// <param name="action">The static function to call while tracking axis</param>
		/// <param name="executedWhenPaused">If <c>true</c>, executes even if the game is paused</param>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="action"/> is not static</exception>
		public void BindAxis(string axisName, InputAxisDelegate action, bool executedWhenPaused = false) {
			if (axisName == null)
				throw new ArgumentNullException(nameof(axisName));

			if (action == null)
				throw new ArgumentNullException(nameof(action));

			if (!action.Method.IsStatic)
				throw new ArgumentException(nameof(action) + " should be static");

			bindAxis(Pointer, axisName, executedWhenPaused, action.Method.MethodHandle.GetFunctionPointer());
		}

		/// <summary>
		/// Removes the action binding
		/// </summary>
		public void RemoveActionBinding(string actionName, InputEvent keyEvent) => removeActionBinding(Pointer, actionName, keyEvent);
	}

	/// <summary>
	/// The base class of components that can be transformed or attached, but has no rendering or collision capabilities
	/// </summary>
	public partial class SceneComponent : ActorComponent {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new StringBuilder(8192);

		internal override ComponentType Type => ComponentType.Scene;

		private protected SceneComponent() { }

		internal SceneComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public SceneComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name, setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns <c>true</c> if the component is attached to the supplied component
		/// </summary>
		public bool IsAttachedToComponent(SceneComponent component) {
			if (component == null)
				throw new ArgumentNullException(nameof(component));

			return isAttachedToComponent(Pointer, component.Pointer);
		}

		/// <summary>
		/// Returns <c>true</c> if the component is attached to the actor
		/// </summary>
		public bool IsAttachedToActor(Actor actor) {
			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			return isAttachedToActor(Pointer, actor.Pointer);
		}

		/// <summary>
		/// Returns <c>true</c> if the a socket with given name exists
		/// </summary>
		public bool IsSocketExists(string socketName) {
			if (socketName == null)
				throw new ArgumentNullException(nameof(socketName));

			return isSocketExists(Pointer, socketName);
		}

		/// <summary>
		/// Returns <c>true</c> if the component has any sockets
		/// </summary>
		public bool HasAnySockets => hasAnySockets(Pointer);

		/// <summary>
		/// Attaches the component to another component, optionally at a named socket
		/// </summary>
		/// <returns><c>true</c> if successful</returns>
		public bool AttachToComponent(SceneComponent parent, AttachmentTransformRule attachmentRule, string socketName = null) {
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));

			return attachToComponent(Pointer, parent.Pointer, attachmentRule, socketName);
		}

		/// <summary>
		/// Recalculates the value of the component to world transform
		/// </summary>
		public void UpdateToWorld(TeleportType type = TeleportType.None, UpdateTransformFlags flags = UpdateTransformFlags.None) => updateToWorld(Pointer, type, flags);

		/// <summary>
		/// Adds a delta to the location of the component in its local reference frame
		/// </summary>
		public void AddLocalOffset(in Vector3 deltaLocation) => addLocalOffset(Pointer, deltaLocation);

		/// <summary>
		/// Adds a delta to the rotation of the component in its local reference frame
		/// </summary>
		public void AddLocalRotation(in Quaternion deltaRotation) => addLocalRotation(Pointer, deltaRotation);

		/// <summary>
		/// Adds a delta to the translation of the component relative to its parent
		/// </summary>
		public void AddRelativeLocation(in Vector3 deltaLocation) => addRelativeLocation(Pointer, deltaLocation);

		/// <summary>
		/// Adds a delta to the rotation of the component relative to its parent
		/// </summary>
		public void AddRelativeRotation(in Quaternion deltaRotation) => addRelativeRotation(Pointer, deltaRotation);

		/// <summary>
		/// Adds a delta to the transform of the component in its local reference frame, scale is unchanged
		/// </summary>
		public void AddLocalTransform(in Transform deltaTransform) => addLocalTransform(Pointer, deltaTransform);

		/// <summary>
		/// Adds a delta to the location of the component in world space
		/// </summary>
		public void AddWorldOffset(in Vector3 deltaLocation) => addWorldOffset(Pointer, deltaLocation);

		/// <summary>
		/// Adds a delta to the rotation of the component in world space
		/// </summary>
		public void AddWorldRotation(in Quaternion deltaRotation) => addWorldRotation(Pointer, deltaRotation);

		/// <summary>
		/// Adds a delta to the transform of the component in world space, scale is unchanged
		/// </summary>
		public void AddWorldTransform(in Transform deltaTransform) => addWorldTransform(Pointer, deltaTransform);

		/// <summary>
		/// Returns the name of a socket the component is attached to
		/// </summary>
		public string GetAttachedSocketName() {
			stringBuffer.Clear();

			getAttachedSocketName(Pointer, stringBuffer);

			return stringBuffer.ToString();
		}

		/// <summary>
		/// Retrieves location of a socket in world space
		/// </summary>
		public void GetSocketLocation(string socketName, ref Vector3 value) => getSocketLocation(Pointer, socketName, ref value);

		/// <summary>
		/// Retrieves rotation of a socket in world space
		/// </summary>
		public void GetSocketRotation(string socketName, ref Quaternion value) => getSocketRotation(Pointer, socketName, ref value);

		/// <summary>
		/// Retrieves velocity of the component, or the velocity of the physics body if simulating physics
		/// </summary>
		public void GetVelocity(ref Vector3 value) => getComponentVelocity(Pointer, ref value);

		/// <summary>
		/// Retrieves location of the component in world space
		/// </summary>
		public void GetLocation(ref Vector3 value) => getComponentLocation(Pointer, ref value);

		/// <summary>
		/// Retrieves rotation of the component in world space
		/// </summary>
		public void GetRotation(ref Quaternion value) => getComponentRotation(Pointer, ref value);

		/// <summary>
		/// Retrieves scale of the component in world space
		/// </summary>
		public void GetScale(ref Vector3 value) => getComponentScale(Pointer, ref value);

		/// <summary>
		/// Retrieves the transform which assigned to the component
		/// </summary>
		public void GetTransform(ref Transform value) => SceneComponent.getComponentTransform(Pointer, ref value);

		/// <summary>
		/// Gets the forward (X) unit direction vector from the component in world space
		/// </summary>
		public void GetForwardVector(ref Vector3 value) => getForwardVector(Pointer, ref value);

		/// <summary>
		/// Gets the right (Y) unit direction vector from the component in world space
		/// </summary>
		public void GetRightVector(ref Vector3 value) => getRightVector(Pointer, ref value);

		/// <summary>
		/// Gets the up (Z) unit direction vector from the component in world space
		/// </summary>
		public void GetUpVector(ref Vector3 value) => getUpVector(Pointer, ref value);

		/// <summary>
		/// Sets how often the component is allowed to move at runtime
		/// </summary>
		public void SetMobility(ComponentMobility mobility) => setMobility(Pointer, mobility);

		/// <summary>
		/// Sets the location of the component relative to its parent
		/// </summary>
		public void SetRelativeLocation(in Vector3 location) => setRelativeLocation(Pointer, location);

		/// <summary>
		/// Sets the rotation of the component relative to its parent
		/// </summary>
		public void SetRelativeRotation(in Quaternion rotation) => setRelativeRotation(Pointer, rotation);

		/// <summary>
		/// Sets the transform of the component relative to its parent
		/// </summary>
		public void SetRelativeTransform(in Transform transform) => setRelativeTransform(Pointer, transform);

		/// <summary>
		/// Sets the location of the component in world space
		/// </summary>
		public void SetWorldLocation(in Vector3 location) => setWorldLocation(Pointer, location);

		/// <summary>
		/// Sets the rotation of the component in world space
		/// </summary>
		public void SetWorldRotation(in Quaternion rotation) => setWorldRotation(Pointer, rotation);

		/// <summary>
		/// Sets the transform of the component in world space
		/// </summary>
		public void SetWorldTransform(in Transform transform) => setWorldTransform(Pointer, transform);
	}

	/// <summary>
	/// A component that is used to play a sound
	/// </summary>
	public partial class AudioComponent : SceneComponent {
		internal override ComponentType Type => ComponentType.Audio;

		private protected AudioComponent() { }

		internal AudioComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public AudioComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name, setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns <c>true</c> if the sound playing any audio
		/// </summary>
		public bool IsPlaying => isPlaying(Pointer);

		/// <summary>
		/// Gets or sets whether the audio is paused
		/// </summary>
		public bool Paused {
			get => getPaused(Pointer);
			set => setPaused(Pointer, value);
		}

		/// <summary>
		/// Sets a sound object
		/// </summary>
		public void SetSound(SoundBase sound) {
			if (sound == null)
				throw new ArgumentNullException(nameof(sound));

			setSound(Pointer, sound.Pointer);
		}

		/// <summary>
		/// Plays the audio
		/// </summary>
		public void Play() => play(Pointer);

		/// <summary>
		/// Stops the audio
		/// </summary>
		public void Stop() => stop(Pointer);

		/// <summary>
		/// Smoothly starts the audio, can be used instead of <see cref="Play"/>
		/// </summary>
		/// <param name="duration">Duration to reach the <paramref name="volumeLevel"/></param>
		/// <param name="volumeLevel">The percentage of calculated volume to fade to</param>
		/// <param name="startTime">Fading start time</param>
		/// <param name="fadeCurve">Curve to adjust audio volume</param>
		public void FadeIn(float duration, float volumeLevel = 1.0f, float startTime = 0.0f, AudioFadeCurve fadeCurve = AudioFadeCurve.Linear) => fadeIn(Pointer, duration, volumeLevel, startTime, fadeCurve);

		/// <summary>
		/// Smoothly stops the audio, can be used instead of <see cref="Stop"/>
		/// </summary>
		/// <param name="duration">Duration to reach the <paramref name="volumeLevel"/></param>
		/// <param name="volumeLevel">he percentage of calculated volume to fade to</param>
		/// <param name="fadeCurve">Curve to adjust audio volume</param>
		public void FadeOut(float duration, float volumeLevel = 0.0f, AudioFadeCurve fadeCurve = AudioFadeCurve.Linear) => fadeOut(Pointer, duration, volumeLevel, fadeCurve);
	}

	/// <summary>
	/// Represents a camera viewpoint and settings, such as projection type, field of view, and post-process overrides
	/// </summary>
	public partial class CameraComponent : PrimitiveComponent {
		internal override ComponentType Type => ComponentType.Camera;

		private protected CameraComponent() { }

		internal CameraComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public CameraComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name, setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Gets or sets whether black bars will be added if the destination view has a different aspect ratio than the camera requested
		/// </summary>
		public bool ConstrainAspectRatio {
			get => getConstrainAspectRatio(Pointer);
			set => setConstrainAspectRatio(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the aspect ratio if <see cref="ConstrainAspectRatio"/> set to <c>true</c>
		/// </summary>
		public float AspectRatio {
			get => getAspectRatio(Pointer);
			set => setAspectRatio(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the horizontal field of view (in degrees) in perspective mode (ignored in orthographic mode)
		/// </summary>
		public float FieldOfView {
			get => getFieldOfView(Pointer);
			set => setFieldOfView(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the far plane distance of the orthographic view (in world units)
		/// </summary>
		public float OrthoFarClipPlane {
			get => getOrthoFarClipPlane(Pointer);
			set => setOrthoFarClipPlane(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the near plane distance of the orthographic view (in world units)
		/// </summary>
		public float OrthoNearClipPlane {
			get => getOrthoNearClipPlane(Pointer);
			set => setOrthoNearClipPlane(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the desired width of the orthographic view (in world units)
		/// </summary>
		public float OrthoWidth {
			get => getOrthoWidth(Pointer);
			set => setOrthoWidth(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the camera's orientation and position is locked to the head-mounted display
		/// </summary>
		public bool LockToHeadMountedDisplay {
			get => getLockToHeadMountedDisplay(Pointer);
			set => setLockToHeadMountedDisplay(Pointer, value);
		}

		/// <summary>
		/// Sets the projection mode
		/// </summary>
		public void SetProjectionMode(CameraProjectionMode type) => setProjectionMode(Pointer, type);
	}

	/// <summary>
	/// An abstract component that contains or generates some sort of geometry, generally to be rendered or used as collision data
	/// </summary>
	public abstract partial class PrimitiveComponent : SceneComponent {
		private protected PrimitiveComponent() { }

		/// <summary>
		/// Returns <c>true</c> if the component is affected by gravity, always returns <c>false</c> if physics simulation is disabled for the component
		/// </summary>
		public bool IsGravityEnabled => isGravityEnabled(Pointer);

		/// <summary>
		/// Returns approximate mass in kilograms
		/// </summary>
		public float Mass => getMass(Pointer);

		/// <summary>
		/// Gets or sets whether the component should cast a shadow or not
		/// </summary>
		public bool CastShadow {
			get => getCastShadow(Pointer);
			set => setCastShadow(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the component visibility when the view actor is the component's owner
		/// </summary>
		public bool OnlyOwnerSee {
			get => getOnlyOwnerSee(Pointer);
			set => setOnlyOwnerSee(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the component would not be visible when the view actor is the component's owner, directly or indirectly
		/// </summary>
		public bool OwnerNoSee {
			get => getOwnerNoSee(Pointer);
			set => setOwnerNoSee(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the angular damping of the component
		/// </summary>
		public float AngularDamping {
			get => getAngularDamping(Pointer);
			set => setAngularDamping(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the linear damping of the component
		/// </summary>
		public float LinearDamping {
			get => getLinearDamping(Pointer);
			set => setLinearDamping(Pointer, value);
		}

		/// <summary>
		/// Returns number of material elements in the primitive
		/// </summary>
		public int MaterialsNumber => getMaterialsNumber(Pointer);

		/// <summary>
		/// Adds an angular impulse in degrees to a rigid body
		/// </summary>
		/// <param name="impulse">Magnitude and direction of the impulse to apply, the direction is the axis of rotation</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="velocityChange">If <c>true</c>, <paramref name="impulse"/> is taken as a change in velocity instead of a physical force (the mass will have no effect)</param>
		public void AddAngularImpulseInDegrees(in Vector3 impulse, string boneName = null, bool velocityChange = false) => addAngularImpulseInDegrees(Pointer, impulse, boneName, velocityChange);

		/// <summary>
		/// Adds an angular impulse in radians to a rigid body
		/// </summary>
		/// <param name="impulse">Magnitude and direction of the impulse to apply, the direction is the axis of rotation</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="velocityChange">If <c>true</c>, <paramref name="impulse"/> is taken as a change in velocity instead of a physical force (the mass will have no effect)</param>
		public void AddAngularImpulseInRadians(in Vector3 impulse, string boneName = null, bool velocityChange = false) => addAngularImpulseInRadians(Pointer, impulse, boneName, velocityChange);

		/// <summary>
		/// Adds a force to a rigid body
		/// </summary>
		/// <param name="force">Force vector to apply, magnitude indicates strength of force</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="accelerationChange">If <c>true</c>, <paramref name="force"/> is taken as a change in acceleration instead of a physical force (the mass will have no effect)</param>
		public void AddForce(in Vector3 force, string boneName = null, bool accelerationChange = false) => addForce(Pointer, force, boneName, accelerationChange);

		/// <summary>
		/// Adds a force to a rigid body at a specific location, optionally in local space
		/// </summary>
		/// <param name="force">Force vector to apply, magnitude indicates strength of force</param>
		/// <param name="location">A point in world or local space to apply the force at</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="localSpace">If <c>true</c>, applies force in local space instead of world space</param>
		public void AddForceAtLocation(in Vector3 force, in Vector3 location, string boneName = null, bool localSpace = false) => addForceAtLocation(Pointer, force, location, boneName, localSpace);

		/// <summary>
		/// Adds an impulse to a rigid body
		/// </summary>
		/// <param name="impulse">Magnitude and direction of the impulse to apply</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="velocityChange">If <c>true</c>, <paramref name="impulse"/> is taken as a change in velocity instead of a physical force (the mass will have no effect)</param>
		public void AddImpulse(in Vector3 impulse, string boneName = null, bool velocityChange = false) => addImpulse(Pointer, impulse, boneName, velocityChange);

		/// <summary>
		/// Adds an impulse to a rigid body at a specific location
		/// </summary>
		/// <param name="impulse">Magnitude and direction of the impulse to apply</param>
		/// <param name="location">A point in world space to apply the impulse at</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		public void AddImpulseAtLocation(in Vector3 impulse, in Vector3 location, string boneName = null) => addImpulseAtLocation(Pointer, impulse, location, boneName);

		/// <summary>
		/// Adds a force to all rigid bodies in the component, originating from the supplied world-space location
		/// </summary>
		/// <param name="origin">Origin of the force in world space</param>
		/// <param name="radius">Radius within which to apply the force</param>
		/// <param name="strength">Strength of the force to apply</param>
		/// <param name="linearFalloff">If <c>true</c>, the force will lose its strength linearly</param>
		/// <param name="accelerationChange">If <c>true</c>, <paramref name="strength"/> is taken as a change in acceleration instead of a physical force (the mass will have no effect)</param>
		public void AddRadialForce(in Vector3 origin, float radius, float strength, bool linearFalloff = false, bool accelerationChange = false) => addRadialForce(Pointer, origin, radius, strength, linearFalloff, accelerationChange);

		/// <summary>
		/// Adds an impulse to all rigid bodies in the component, originating from the supplied world-space location
		/// </summary>
		/// <param name="origin">Origin of the impulse in world space</param>
		/// <param name="radius">Radius within which to apply the impulse</param>
		/// <param name="strength">Strength of the impulse to apply</param>
		/// <param name="linearFalloff">If <c>true</c>, the force will lose its strength linearly</param>
		/// <param name="accelerationChange">If <c>true</c>, <paramref name="strength"/> is taken as a change in acceleration instead of a physical force (the mass will have no effect)</param>
		public void AddRadialImpulse(in Vector3 origin, float radius, float strength, bool linearFalloff = false, bool accelerationChange = false) => addRadialImpulse(Pointer, origin, radius, strength, linearFalloff, accelerationChange);

		/// <summary>
		/// Adds a torque in degrees to a rigid body
		/// </summary>
		/// <param name="torque">Torque to apply, direction is axis of rotation and magnitude is strength of the torque</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="accelerationChange">If <c>true</c>, <paramref name="torque"/> is taken as a change in acceleration instead of a physical force (the mass will have no effect)</param>
		public void AddTorqueInDegrees(in Vector3 torque, string boneName = null, bool accelerationChange = false) => addTorqueInDegrees(Pointer, torque, boneName, accelerationChange);

		/// <summary>
		/// Adds a torque in radians to a rigid body
		/// </summary>
		/// <param name="torque">Torque to apply, direction is axis of rotation and magnitude is strength of the torque</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="accelerationChange">If <c>true</c>, <paramref name="torque"/> is taken as a change in acceleration instead of a physical force (the mass will have no effect)</param>
		public void AddTorqueInRadians(in Vector3 torque, string boneName = null, bool accelerationChange = false) => addTorqueInRadians(Pointer, torque, boneName, accelerationChange);

		/// <summary>
		/// Returns the material at the specified element index
		/// </summary>
		public MaterialInstanceDynamic GetMaterial(int elementIndex) => new MaterialInstanceDynamic(getMaterial(Pointer, elementIndex));

		/// <summary>
		/// Retrieves distance to closest collision
		/// </summary>
		/// <param name="point"></param>
		/// <param name="closestPointOnCollision"></param>
		/// <returns>More than 0.0f if successful, equals to 0.0f if a point is inside the geometry, less than 0.0f if the primitive does not have collision or if the geometry not supported</returns>
		public float GetDistanceToCollision(in Vector3 point, ref Vector3 closestPointOnCollision) => getDistanceToCollision(Pointer, point, ref closestPointOnCollision);

		/// <summary>
		/// Retrieves squared distance to closest collision
		/// </summary>
		/// <param name="point"></param>
		/// <param name="squaredDistance"></param>
		/// <param name="closestPointOnCollision"></param>
		/// <returns><c>true</c> if a distance to the body was found and <paramref name="squaredDistance"/> has been populated</returns>
		public bool GetSquaredDistanceToCollision(in Vector3 point, ref float squaredDistance, ref Vector3 closestPointOnCollision) => getSquaredDistanceToCollision(Pointer, point, ref squaredDistance, ref closestPointOnCollision);

		/// <summary>
		/// Sets the material applied to an element of the mesh
		/// </summary>
		/// <param name="elementIndex">The element to access the material of</param>
		/// <param name="material">A material</param>
		public void SetMaterial(int elementIndex, MaterialInterface material) {
			if (material == null)
				throw new ArgumentNullException(nameof(material));

			setMaterial(Pointer, elementIndex, material.Pointer);
		}

		/// <summary>
		/// Sets the mass in kilograms of a rigid body
		/// </summary>
		public void SetMass(float mass, string boneName = null) => setMass(Pointer, mass, boneName);

		/// <summary>
		/// Sets the linear velocity of a single body
		/// </summary>
		public void SetPhysicsLinearVelocity(in Vector3 velocity, bool addToCurrent = false, string boneName = null) => setPhysicsLinearVelocity(Pointer, velocity, addToCurrent, boneName);

		/// <summary>
		/// Sets the angular velocity in degrees of a single body
		/// </summary>
		public void SetPhysicsAngularVelocityInDegrees(in Vector3 angularVelocity, bool addToCurrent = false, string boneName = null) => setPhysicsAngularVelocityInDegrees(Pointer, angularVelocity, addToCurrent, boneName);

		/// <summary>
		/// Sets the angular velocity in radians of a single body
		/// </summary>
		public void SetPhysicsAngularVelocityInRadians(in Vector3 angularVelocity, bool addToCurrent = false, string boneName = null) => setPhysicsAngularVelocityInRadians(Pointer, angularVelocity, addToCurrent, boneName);

		/// <summary>
		/// Sets the maximum angular velocity in degrees of a single body
		/// </summary>
		public void SetPhysicsMaxAngularVelocityInDegrees(float maxAngularVelocity, bool addToCurrent = false, string boneName = null) => setPhysicsMaxAngularVelocityInDegrees(Pointer, maxAngularVelocity, addToCurrent, boneName);

		/// <summary>
		/// Sets the maximum angular velocity in radians of a single body
		/// </summary>
		public void SetPhysicsMaxAngularVelocityInRadians(float maxAngularVelocity, bool addToCurrent = false, string boneName = null) => setPhysicsMaxAngularVelocityInRadians(Pointer, maxAngularVelocity, addToCurrent, boneName);

		/// <summary>
		/// Sets whether or not a single body should use physics simulation, or should be kinematic, if the component is currently attached to something, beginning simulation will detach it
		/// </summary>
		public void SetSimulatePhysics(bool value) => setSimulatePhysics(Pointer, value);

		/// <summary>
		/// Sets whether or not the component is affected by gravity, applies only to components with enabled physics simulation
		/// </summary>
		public void SetEnableGravity(bool value) => setEnableGravity(Pointer, value);

		/// <summary>
		/// Sets the collision mode of the component
		/// </summary>
		public void SetCollisionMode(CollisionMode mode) => setCollisionMode(Pointer, mode);

		/// <summary>
		/// Creates a dynamic material instance for the specified element index, the parent of the instance is set to the material being replaced
		/// </summary>
		/// <param name="elementIndex">The index of the skin to replace the material for, if invalid, the material is unchanged and <c>null</c> is returned</param>
		/// <returns>A material instance or <c>null</c> on failure</returns>
		public MaterialInstanceDynamic CreateAndSetMaterialInstanceDynamic(int elementIndex) {
			IntPtr pointer = createAndSetMaterialInstanceDynamic(Pointer, elementIndex);

			if (pointer != IntPtr.Zero)
				return new MaterialInstanceDynamic(pointer);

			return null;
		}
	}

	/// <summary>
	/// An abstract component that is represented by a simple geometrical shape
	/// </summary>
	public abstract partial class ShapeComponent : PrimitiveComponent {
		private protected ShapeComponent() { }

		/// <summary>
		/// Gets or sets whether the shape will be used for navigation as a dynamic modifier instead of using regular collision data
		/// </summary>
		public bool DynamicObstacle {
			get => getDynamicObstacle(Pointer);
			set => setDynamicObstacle(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the color of the shape
		/// </summary>
		public Color ShapeColor {
			get => Color.FromArgb(getShapeColor(Pointer));
			set => setShapeColor(Pointer, value.ToArgb());
		}
	}

	/// <summary>
	/// A box generally used for simple collision
	/// </summary>
	public partial class BoxComponent : ShapeComponent {
		internal override ComponentType Type => ComponentType.Box;

		private protected BoxComponent() { }

		internal BoxComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public BoxComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name, setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Retrieves the box extents scaled by the component scale
		/// </summary>
		public void GetScaledBoxExtent(ref Vector3 value) => getScaledBoxExtent(Pointer, ref value);

		/// <summary>
		/// Retrieves the box extent ignoring the component scale
		/// </summary>
		public void GetUnscaledBoxExtent(ref Vector3 value) => getUnscaledBoxExtent(Pointer, ref value);

		/// <summary>
		/// Sets the box extent size, unscaled before the component scale is applied
		/// </summary>
		public void SetBoxExtent(in Vector3 extent, bool updateOverlaps = true) => setBoxExtent(Pointer, extent, updateOverlaps);

		/// <summary>
		/// Sets the box extent size without triggering a render or physics update
		/// </summary>
		public void InitBoxExtent(in Vector3 extent) => initBoxExtent(Pointer, extent);
	}

	/// <summary>
	/// A sphere generally used for simple collision
	/// </summary>
	public partial class SphereComponent : ShapeComponent {
		internal override ComponentType Type => ComponentType.Sphere;

		private protected SphereComponent() { }

		internal SphereComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public SphereComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name, setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns the sphere radius scaled by the component scale
		/// </summary>
		public float ScaledSphereRadius => getScaledSphereRadius(Pointer);

		/// <summary>
		/// Returns the sphere radius ignoring the component scale
		/// </summary>
		public float UnscaledSphereRadius => getUnscaledSphereRadius(Pointer);

		/// <summary>
		/// Returns the scale of the shape
		/// </summary>
		public float ShapeScale => getShapeScale(Pointer);

		/// <summary>
		/// Sets the sphere radius, unscaled before the component scale is applied
		/// </summary>
		public void SetSphereRadius(float sphereRadius, bool updateOverlaps = true) => setSphereRadius(Pointer, sphereRadius, updateOverlaps);

		/// <summary>
		/// Sets the sphere radius without triggering a render or physics update
		/// </summary>
		public void InitSphereRadius(float sphereRadius) => initSphereRadius(Pointer, sphereRadius);
	}

	/// <summary>
	/// A capsule generally used for simple collision
	/// </summary>
	public partial class CapsuleComponent : ShapeComponent {
		internal override ComponentType Type => ComponentType.Capsule;

		private protected CapsuleComponent() { }

		internal CapsuleComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public CapsuleComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name, setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns the capsule radius scaled by the component scale
		/// </summary>
		public float ScaledCapsuleRadius => getScaledCapsuleRadius(Pointer);

		/// <summary>
		/// Returns the capsule radius ignoring the component scale
		/// </summary>
		public float UnscaledCapsuleRadius => getUnscaledCapsuleRadius(Pointer);

		/// <summary>
		/// Returns the scale of the shape
		/// </summary>
		public float ShapeScale => getShapeScale(Pointer);

		/// <summary>
		/// Retrieves the capsule radius and half-height scaled by the component scale
		/// </summary>
		public void GetScaledCapsuleSize(ref float radius, ref float halfHeight) => getScaledCapsuleSize(Pointer, ref radius, ref halfHeight);

		/// <summary>
		/// Retrieves the capsule radius and half-height ignoring the component scale
		/// </summary>
		public void GetUnscaledCapsuleSize(ref float radius, ref float halfHeight) => getUnscaledCapsuleSize(Pointer, ref radius, ref halfHeight);

		/// <summary>
		/// Sets the capsule radius, unscaled before the component scale is applied
		/// </summary>
		public void SetCapsuleRadius(float radius, bool updateOverlaps = true) => setCapsuleRadius(Pointer, radius, updateOverlaps);

		/// <summary>
		/// Sets the capsule size, unscaled before the component scale is applied
		/// </summary>
		public void SetCapsuleSize(float radius, float halfHeight, bool updateOverlaps = true) => setCapsuleSize(Pointer, radius, halfHeight, updateOverlaps);

		/// <summary>
		/// Sets the capsule size without triggering a render or physics update
		/// </summary>
		public void InitCapsuleSize(float radius, float halfHeight) => initCapsuleSize(Pointer, radius, halfHeight);
	}

	/// <summary>
	/// An abstract component that is an instance of a renderable collection of triangles
	/// </summary>
	public abstract partial class MeshComponent : PrimitiveComponent {
		private protected MeshComponent() { }

		/// <summary>
		/// Returns a material index given a slot name
		/// </summary>
		public int GetMaterialIndex(string materialSlotName) {
			if (materialSlotName == null)
				throw new ArgumentNullException(nameof(materialSlotName));

			return getMaterialIndex(Pointer, materialSlotName);
		}
	}

	/// <summary>
	/// The base class of light components
	/// </summary>
	public abstract partial class LightComponentBase : SceneComponent {
		private protected LightComponentBase() { }

		/// <summary>
		/// Returns the total energy that the light emits
		/// </summary>
		public float Intensity => getIntensity(Pointer);

		/// <summary>
		/// Gets or sets whether the light should cast shadows
		/// </summary>
		public bool CastShadows {
			get => getCastShadows(Pointer);
			set => setCastShadows(Pointer, value);
		}
	}

	/// <summary>
	/// A component that represents light
	/// </summary>
	public partial class LightComponent : LightComponentBase {
		internal override ComponentType Type => ComponentType.Light;

		private protected LightComponent() { }

		internal LightComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Sets the intensity of the light
		/// </summary>
		public void SetIntensity(float value) => setIntensity(Pointer, value);

		/// <summary>
		/// Sets the light color
		/// </summary>
		public void SetLightColor(in LinearColor value) => setLightColor(Pointer, value);
	}

	/// <summary>
	/// A component that represents directional light
	/// </summary>
	public partial class DirectionalLightComponent : LightComponent {
		internal override ComponentType Type => ComponentType.DirectionalLight;

		private protected DirectionalLightComponent() { }

		internal DirectionalLightComponent(IntPtr pointer) => Pointer = pointer;
	}

	/// <summary>
	/// A component that represents a physical motion controller in 3D space
	/// </summary>
	public partial class MotionControllerComponent : PrimitiveComponent {
		internal override ComponentType Type => ComponentType.MotionController;

		private protected MotionControllerComponent() { }

		internal MotionControllerComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public MotionControllerComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name, setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns <c>true</c> if the component has a valid tracked device this frame
		/// </summary>
		public bool IsTracked => isTracked(Pointer);
	}

	/// <summary>
	/// A component that is used to create an instance of a static mesh, a piece of geometry that consists of a static set of polygons
	/// </summary>
	public partial class StaticMeshComponent : MeshComponent {
		internal override ComponentType Type => ComponentType.StaticMesh;

		private protected StaticMeshComponent() { }

		internal StaticMeshComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public StaticMeshComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name, setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Retrieves local bounds of the mesh
		/// </summary>
		public void GetLocalBounds(ref Vector3 min, ref Vector3 max) => getLocalBounds(Pointer, ref min, ref max);

		/// <summary>
		/// Returns the static mesh used by this instance or <c>null</c> on failure
		/// </summary>
		public StaticMesh GetStaticMesh() {
			IntPtr pointer = getStaticMesh(Pointer);

			if (pointer != IntPtr.Zero)
				return new StaticMesh(pointer);

			return null;
		}

		/// <summary>
		/// Returns <c>true</c> if the mesh was set
		/// </summary>
		public bool SetStaticMesh(StaticMesh staticMesh) {
			if (staticMesh == null)
				throw new ArgumentNullException(nameof(staticMesh));

			return setStaticMesh(Pointer, staticMesh.Pointer);
		}
	}

	/// <summary>
	/// A component that efficiently renders multiple instances of the same <see cref="StaticMeshComponent"/>
	/// </summary>
	public partial class InstancedStaticMeshComponent : StaticMeshComponent {
		internal override ComponentType Type => ComponentType.InstancedStaticMesh;

		private protected InstancedStaticMeshComponent() { }

		internal InstancedStaticMeshComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public InstancedStaticMeshComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name, setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Gets the number of instances in the component
		/// </summary>
		public int InstanceCount => getInstanceCount(Pointer);

		/// <summary>
		/// Adds an instance to the component using the transform that will be applied at instantiation
		/// </summary>
		public int AddInstance(in Transform instanceTransform) => addInstance(Pointer, instanceTransform);

		/// <summary>
		/// Updates the transform for the specified instance
		/// </summary>
		/// <param name="instanceIndex">The index of the instance to update</param>
		/// <param name="instanceTransform">The new transform to apply</param>
		/// <param name="worldSpace">If <c>true</c>, the new transform is interpreted as a world space transform, otherwise it is interpreted as local space</param>
		/// <param name="markRenderStateDirty">If the render state is marked as dirty the change should be visible immediately, consider setting it to <c>true</c> only during the update of the last instance in a batch</param>
		/// <param name="teleport">Whether or not the instance's physics should be moved normally, or teleported (moved instantly, ignoring velocity)</param>
		/// <returns><c>true</c> if successful</returns>
		public bool UpdateInstanceTransform(int instanceIndex, in Transform instanceTransform, bool worldSpace = false, bool markRenderStateDirty = false, bool teleport = false) => updateInstanceTransform(Pointer, instanceIndex, instanceTransform, worldSpace, markRenderStateDirty, teleport);

		/// <summary>
		/// Clears all instances being rendered by the component
		/// </summary>
		public void ClearInstances() => clearInstances(Pointer);
	}

	/// <summary>
	/// A component that supports bone skinned mesh rendering
	/// </summary>
	public abstract partial class SkinnedMeshComponent : MeshComponent {
		private protected SkinnedMeshComponent() { }

		/// <summary>
		/// Changes the skeletal mesh
		/// </summary>
		public void SetSkeletalMesh(SkeletalMesh skeletalMesh, bool reinitializePose = true) {
			if (skeletalMesh == null)
				throw new ArgumentNullException(nameof(skeletalMesh));

			setSkeletalMesh(Pointer, skeletalMesh.Pointer, reinitializePose);
		}
	}

	/// <summary>
	/// A component that is used to create an instance of an animated <see cref="SkeletalMesh"/> asset
	/// </summary>
	public partial class SkeletalMeshComponent : SkinnedMeshComponent {
		internal override ComponentType Type => ComponentType.SkeletalMesh;

		private protected SkeletalMeshComponent() { }

		internal SkeletalMeshComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public SkeletalMeshComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name, setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns the animation instance that is driving the class or <c>null</c> on failure
		/// </summary>
		public AnimationInstance GetAnimationInstance() {
			IntPtr pointer = getAnimationInstance(Pointer);

			if (pointer != IntPtr.Zero)
				return new AnimationInstance(pointer);

			return null;
		}

		/// <summary>
		/// Sets the animation to play
		/// </summary>
		public void SetAnimation(AnimationAsset asset) {
			if (asset == null)
				throw new ArgumentNullException(nameof(asset));

			setAnimation(Pointer, asset.Pointer);
		}

		/// <summary>
		/// Sets the animation mode
		/// </summary>
		public void SetAnimationMode(AnimationMode mode) => setAnimationMode(Pointer, mode);

		/// <summary>
		/// Sets the animation blueprint
		/// </summary>
		public void SetAnimationBlueprint(Blueprint blueprint) {
			if (blueprint == null)
				throw new ArgumentNullException(nameof(blueprint));

			setAnimationBlueprint(Pointer, blueprint.Pointer);
		}

		/// <summary>
		/// Plays the animation
		/// </summary>
		public void Play(bool loop = false) => play(Pointer, loop);

		/// <summary>
		/// Plays the animation asset
		/// </summary>
		public void PlayAnimation(AnimationAsset asset, bool loop = false) {
			if (asset == null)
				throw new ArgumentNullException(nameof(asset));

			playAnimation(Pointer, asset.Pointer, loop);
		}

		/// <summary>
		/// Stops the animation
		/// </summary>
		public void Stop() => stop(Pointer);
	}

	/// <summary>
	/// The base class of materials that can be applied to meshes
	/// </summary>
	public abstract partial class MaterialInterface : IEquatable<MaterialInterface> {
		private IntPtr pointer;

		internal IntPtr Pointer {
			get {
				if (!IsCreated)
					throw new InvalidOperationException();

				return pointer;
			}

			set {
				if (value == IntPtr.Zero)
					throw new InvalidOperationException();

				pointer = value;
			}
		}

		private protected MaterialInterface() { }

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && Object.isValid(pointer);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(MaterialInterface other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Returns <c>true</c> if the material is two sided
		/// </summary>
		public bool IsTwoSided => isTwoSided(Pointer);
	}

	/// <summary>
	/// An asset which can be applied to a mesh to control the visual look
	/// </summary>
	public partial class Material : MaterialInterface {
		private protected Material() { }

		internal Material(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Finds and loads a material by name
		/// </summary>
		/// <returns>A material or <c>null</c> on failure</returns>
		public static Material Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.Material, name);

			if (pointer != IntPtr.Zero)
				return new Material(pointer);

			return null;
		}

		/// <summary>
		/// Returns <c>true</c> if the material is one of the default materials
		/// </summary>
		public bool IsDefaultMaterial => isDefaultMaterial(Pointer);
	}

	/// <summary>
	/// An abstract instance of the material
	/// </summary>
	public abstract partial class MaterialInstance : MaterialInterface {
		private protected MaterialInstance() { }

		/// <summary>
		/// Returns <c>true</c> if the material instance is a child of another Material
		/// </summary>
		public bool IsChildOf(MaterialInterface material) {
			if (material == null)
				throw new ArgumentNullException(nameof(material));

			return isChildOf(Pointer, material.Pointer);
		}
	}

	/// <summary>
	/// A dynamic instance of the material
	/// </summary>
	public partial class MaterialInstanceDynamic : MaterialInstance {
		private protected MaterialInstanceDynamic() { }

		internal MaterialInstanceDynamic(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Removes all parameter values
		/// </summary>
		public void ClearParameterValues() => clearParameterValues(Pointer);

		/// <summary>
		/// Sets the texture parameter value
		/// </summary>
		public void SetTextureParameterValue(string parameterName, Texture value) {
			if (parameterName == null)
				throw new ArgumentNullException(nameof(parameterName));

			if (value == null)
				throw new ArgumentNullException(nameof(value));

			setTextureParameterValue(Pointer, parameterName, value.Pointer);
		}

		/// <summary>
		/// Sets the vector parameter value
		/// </summary>
		public void SetVectorParameterValue(string parameterName, in LinearColor value) {
			if (parameterName == null)
				throw new ArgumentNullException(nameof(parameterName));

			setVectorParameterValue(Pointer, parameterName, value);
		}

		/// <summary>
		/// Sets the scalar parameter value
		/// </summary>
		public void SetScalarParameterValue(string parameterName, float value) {
			if (parameterName == null)
				throw new ArgumentNullException(nameof(parameterName));

			setScalarParameterValue(Pointer, parameterName, value);
		}
	}
}
