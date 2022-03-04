/*
 *  Unreal Engine .NET 6 integration
 *  Copyright (c) 2021 Stanislav Denisov
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *  SOFTWARE.
 */

using System;
using System.Collections.Generic;
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

	internal static class ArrayPool {
		[ThreadStatic]
		private static byte[] stringBuffer;

		public static byte[] GetStringBuffer() {
			if (stringBuffer == null)
				stringBuffer = GC.AllocateUninitializedArray<byte>(8192, pinned: true);

			return stringBuffer;
		}
	}

	internal static class Collector {
		[ThreadStatic]
		private static List<object> references;

		public static IntPtr GetFunctionPointer(Delegate reference) {
			if (references == null)
				references = new();

			references.Add(reference);

			return Marshal.GetFunctionPointerForDelegate(reference);
		}
	}

	internal static class Extensions {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static T GetOrAdd<S, T>(this IDictionary<S, T> dictionary, S key, Func<T> valueCreator) => dictionary.TryGetValue(key, out var value) ? value : dictionary[key] = valueCreator();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static byte[] StringToBytes(this string value) {
			if (value != null)
				return Encoding.UTF8.GetBytes(value);

			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static string BytesToString(this byte[] buffer) {
			int end;

			for (end = 0; end < buffer.Length && buffer[end] != 0; end++);

			unsafe {
				fixed (byte* pinnedBuffer = buffer) {
					return new((sbyte*)pinnedBuffer, 0, end);
				}
			}
		}
	}

	internal static class Tables {
		// Table for fast conversion from the color to a linear color
		internal static readonly float[] Color = new float[256] {
			0.0f,
			0.000303526983548838f, 0.000607053967097675f, 0.000910580950646512f, 0.00121410793419535f, 0.00151763491774419f,
			0.00182116190129302f, 0.00212468888484186f, 0.0024282158683907f, 0.00273174285193954f, 0.00303526983548838f,
			0.00334653564113713f, 0.00367650719436314f, 0.00402471688178252f, 0.00439144189356217f, 0.00477695332960869f,
			0.005181516543916f, 0.00560539145834456f, 0.00604883284946662f, 0.00651209061157708f, 0.00699540999852809f,
			0.00749903184667767f, 0.00802319278093555f, 0.0085681254056307f, 0.00913405848170623f, 0.00972121709156193f,
			0.0103298227927056f, 0.0109600937612386f, 0.0116122449260844f, 0.012286488094766f, 0.0129830320714536f,
			0.0137020827679224f, 0.0144438433080002f, 0.0152085141260192f, 0.0159962930597398f, 0.0168073754381669f,
			0.0176419541646397f, 0.0185002197955389f, 0.0193823606149269f, 0.0202885627054049f, 0.0212190100154473f,
			0.0221738844234532f, 0.02315336579873f, 0.0241576320596103f, 0.0251868592288862f, 0.0262412214867272f,
			0.0273208912212394f, 0.0284260390768075f, 0.0295568340003534f, 0.0307134432856324f, 0.0318960326156814f,
			0.0331047661035236f, 0.0343398063312275f, 0.0356013143874111f, 0.0368894499032755f, 0.0382043710872463f,
			0.0395462347582974f, 0.0409151963780232f, 0.0423114100815264f, 0.0437350287071788f, 0.0451862038253117f,
			0.0466650857658898f, 0.0481718236452158f, 0.049706565391714f, 0.0512694577708345f, 0.0528606464091205f,
			0.0544802758174765f, 0.0561284894136735f, 0.0578054295441256f, 0.0595112375049707f, 0.0612460535624849f,
			0.0630100169728596f, 0.0648032660013696f, 0.0666259379409563f, 0.0684781691302512f, 0.070360094971063f,
			0.0722718499453493f, 0.0742135676316953f, 0.0761853807213167f, 0.0781874210336082f, 0.0802198195312533f,
			0.0822827063349132f, 0.0843762107375113f, 0.0865004612181274f, 0.0886555854555171f, 0.0908417103412699f,
			0.0930589619926197f, 0.0953074657649191f, 0.0975873462637915f, 0.0998987273569704f, 0.102241732185838f,
			0.104616483176675f, 0.107023102051626f, 0.109461709839399f, 0.1119324268857f, 0.114435372863418f,
			0.116970666782559f, 0.119538426999953f, 0.122138771228724f, 0.124771816547542f, 0.127437679409664f,
			0.130136475651761f, 0.132868320502552f, 0.135633328591233f, 0.138431613955729f, 0.141263290050755f,
			0.144128469755705f, 0.147027265382362f, 0.149959788682454f, 0.152926150855031f, 0.155926462553701f,
			0.158960833893705f, 0.162029374458845f, 0.16513219330827f, 0.168269398983119f, 0.171441099513036f,
			0.174647402422543f, 0.17788841473729f, 0.181164242990184f, 0.184474993227387f, 0.187820771014205f,
			0.191201681440861f, 0.194617829128147f, 0.198069318232982f, 0.201556252453853f, 0.205078735036156f,
			0.208636868777438f, 0.212230756032542f, 0.215860498718652f, 0.219526198320249f, 0.223227955893977f,
			0.226965872073417f, 0.23074004707378f, 0.23455058069651f, 0.238397572333811f, 0.242281120973093f,
			0.246201325201334f, 0.250158283209375f, 0.254152092796134f, 0.258182851372752f, 0.262250655966664f,
			0.266355603225604f, 0.270497789421545f, 0.274677310454565f, 0.278894261856656f, 0.283148738795466f,
			0.287440836077983f, 0.291770648154158f, 0.296138269120463f, 0.300543792723403f, 0.304987312362961f,
			0.309468921095997f, 0.313988711639584f, 0.3185467763743f, 0.323143207347467f, 0.32777809627633f,
			0.332451534551205f, 0.337163613238559f, 0.341914423084057f, 0.346704054515559f, 0.351532597646068f,
			0.356400142276637f, 0.361306777899234f, 0.36625259369956f, 0.371237678559833f, 0.376262121061519f,
			0.381326009488037f, 0.386429431827418f, 0.39157247577492f, 0.396755228735618f, 0.401977777826949f,
			0.407240209881218f, 0.41254261144808f, 0.417885068796976f, 0.423267667919539f, 0.428690494531971f,
			0.434153634077377f, 0.439657171728079f, 0.445201192387887f, 0.450785780694349f, 0.456411021020965f,
			0.462076997479369f, 0.467783793921492f, 0.473531493941681f, 0.479320180878805f, 0.485149937818323f,
			0.491020847594331f, 0.496932992791578f, 0.502886455747457f, 0.50888131855397f, 0.514917663059676f,
			0.520995570871595f, 0.527115123357109f, 0.533276401645826f, 0.539479486631421f, 0.545724458973463f,
			0.552011399099209f, 0.558340387205378f, 0.56471150325991f, 0.571124827003694f, 0.577580437952282f,
			0.584078415397575f, 0.590618838409497f, 0.597201785837643f, 0.603827336312907f, 0.610495568249093f,
			0.617206559844509f, 0.623960389083534f, 0.630757133738175f, 0.637596871369601f, 0.644479679329661f,
			0.651405634762384f, 0.658374814605461f, 0.665387295591707f, 0.672443154250516f, 0.679542466909286f,
			0.686685309694841f, 0.693871758534824f, 0.701101889159085f, 0.708375777101046f, 0.71569349769906f,
			0.723055126097739f, 0.730460737249286f, 0.737910405914797f, 0.745404206665559f, 0.752942213884326f,
			0.760524501766589f, 0.768151144321824f, 0.775822215374732f, 0.783537788566466f, 0.791297937355839f,
			0.799102735020525f, 0.806952254658248f, 0.81484656918795f, 0.822785751350956f, 0.830769873712124f,
			0.838799008660978f, 0.846873228412837f, 0.854992605009927f, 0.863157210322481f, 0.871367116049835f,
			0.879622393721502f, 0.887923114698241f, 0.896269350173118f, 0.904661171172551f, 0.913098648557343f,
			0.921581853023715f, 0.930110855104312f, 0.938685725169219f, 0.947306533426946f, 0.955973349925421f,
			0.964686244552961f, 0.973445287039244f, 0.982250546956257f, 0.991102093719252f, 1.0f
		};
	}

	// Public

	/// <summary>
	/// Defines the log level for an output log message
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
	/// Defines rules for attaching components
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
	/// Defines rules for detaching components
	/// </summary>
	public enum DetachmentTransformRule : int {
		/// <summary>
		/// Keeps current relative transform as the relative transform to the previous parent
		/// </summary>
		KeepRelativeTransform,
		/// <summary>
		/// Automatically calculates the relative transform such that the detached component maintains the same world transform
		/// </summary>
		KeepWorldTransform
	}

	/// <summary>
	/// Defines teleportation types of physics body
	/// </summary>
	public enum TeleportType : byte {
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
	/// Defines how to update transform during movement
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
	/// Defines focus priority for AI
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
	/// Defines actor events
	/// </summary>
	public enum ActorEventType : int {
		/// <summary>
		/// Called when actors start overlapping
		/// </summary>
		OnActorBeginOverlap,
		/// <summary>
		/// Called when actors stop overlapping
		/// </summary>
		OnActorEndOverlap,
		/// <summary>
		/// Called when actors hit collisions
		/// </summary>
		OnActorHit,
		/// <summary>
		/// Called when the mouse cursor is moved over an actor if mouse over events are enabled in the player controller
		/// </summary>
		OnActorBeginCursorOver,
		/// <summary>
		/// Called when the mouse cursor is moved off an actor if mouse over events are enabled in the player controller
		/// </summary>
		OnActorEndCursorOver,
		/// <summary>
		/// Called when the mouse button is clicked while the mouse is over an actor if click events are enabled in the player controller
		/// </summary>
		OnActorClicked,
		/// <summary>
		/// Called when the mouse button is released while the mouse is over an actor if click events are enabled in the player controller
		/// </summary>
		OnActorReleased
	}

	/// <summary>
	/// Defines component events
	/// </summary>
	public enum ComponentEventType : int {
		/// <summary>
		/// Called when components start overlapping
		/// </summary>
		OnComponentBeginOverlap,
		/// <summary>
		/// Called when components stop overlapping
		/// </summary>
		OnComponentEndOverlap,
		/// <summary>
		/// Called when components hit collisions
		/// </summary>
		OnComponentHit,
		/// <summary>
		/// Called when the mouse cursor is moved over a component and mouse over events are enabled in the player controller
		/// </summary>
		OnComponentBeginCursorOver,
		/// <summary>
		/// Called when the mouse cursor is moved off a component and mouse over events are enabled in the player controller
		/// </summary>
		OnComponentEndCursorOver,
		/// <summary>
		/// Called when the mouse button is clicked while the mouse is over a component if click events are enabled in the player controller
		/// </summary>
		OnComponentClicked,
		/// <summary>
		/// Called when the mouse button is released while the mouse is over a component if click events are enabled in the player controller
		/// </summary>
		OnComponentReleased
	}

	/// <summary>
	/// Defines the animation mode
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
	/// Defines the player index that will be used to pass input
	/// </summary>
	public enum AutoReceiveInput : int {
		/// <summary/>
		Disabled,
		/// <summary/>
		Player0,
		/// <summary/>
		Player1,
		/// <summary/>
		Player2,
		/// <summary/>
		Player3,
		/// <summary/>
		Player4,
		/// <summary/>
		Player5,
		/// <summary/>
		Player6,
		/// <summary/>
		Player7
	}

	/// <summary>
	/// Defines the projection mode for a camera
	/// </summary>
	public enum CameraProjectionMode : int {
		/// <summary/>
		Perspective,
		/// <summary/>
		Orthographic
	}

	/// <summary>
	/// Defines the collision mode
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
	/// Defines the collision shape type
	/// </summary>
	public enum CollisionShapeType : int {
		/// <summary/>
		Box = 1,
		/// <summary/>
		Sphere = 2,
		/// <summary/>
		Capsule = 3
	}

	/// <summary>
	/// Defines how often a component is allowed to move
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
	/// Defines coordinate space
	/// </summary>
	public enum SplineCoordinateSpace : int {
		/// <summary/>
		Local,
		/// <summary/>
		World
	}

	/// <summary>
	/// Defines the spline point type
	/// </summary>
	public enum SplinePointType : int {
		/// <summary/>
		Linear,
		/// <summary/>
		Curve,
		/// <summary/>
		Constant,
		/// <summary/>
		CurveClamped,
		/// <summary/>
		CurveCustomTangent
	}

	/// <summary>
	/// Defines the window mode
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
	/// Defines the type of fade to adjust audio volume
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
	/// Defines the possession type for AI pawn that will be automatically possed by an AI controller
	/// </summary>
	public enum AutoPossessAI : byte {
		/// <summary>
		/// Disabled and not possesses AI
		/// </summary>
		Disabled,
		/// <summary>
		/// Only possess by an AI controller if a pawn is placed in the world
		/// </summary>
		PlacedInWorld,
		/// <summary>
		/// Only possess by an AI controller if a pawn is spawned after the world has loaded
		/// </summary>
		Spawned,
		/// <summary>
		/// Pawn is automatically possessed by an AI controller whenever it's created
		/// </summary>
		PlacedInWorldOrSpawned
	}

	/// <summary>
	/// Defines how to blend when changing view targets
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
		EaseInOut,
		/// <summary>
		/// The game's camera system has already performed the blending, the engine shouldn't blend at all
		/// </summary>
		PreBlended
	}

	/// <summary>
	/// Defines collision channels
	/// </summary>
	public enum CollisionChannel : int {
		/// <summary/>
		WorldStatic,
		/// <summary/>
		WorldDynamic,
		/// <summary/>
		Pawn,
		/// <summary/>
		Visibility,
		/// <summary/>
		Camera,
		/// <summary/>
		PhysicsBody,
		/// <summary/>
		Vehicle,
		/// <summary/>
		Destructible,
		/// <summary/>
		EngineTraceChannel1,
		/// <summary/>
		EngineTraceChannel2,
		/// <summary/>
		EngineTraceChannel3,
		/// <summary/>
		EngineTraceChannel4,
		/// <summary/>
		EngineTraceChannel5,
		/// <summary/>
		EngineTraceChannel6,
		/// <summary/>
		GameTraceChannel1,
		/// <summary/>
		GameTraceChannel2,
		/// <summary/>
		GameTraceChannel3,
		/// <summary/>
		GameTraceChannel4,
		/// <summary/>
		GameTraceChannel5,
		/// <summary/>
		GameTraceChannel6,
		/// <summary/>
		GameTraceChannel7,
		/// <summary/>
		GameTraceChannel8,
		/// <summary/>
		GameTraceChannel9,
		/// <summary/>
		GameTraceChannel10,
		/// <summary/>
		GameTraceChannel11,
		/// <summary/>
		GameTraceChannel12,
		/// <summary/>
		GameTraceChannel13,
		/// <summary/>
		GameTraceChannel14,
		/// <summary/>
		GameTraceChannel15,
		/// <summary/>
		GameTraceChannel16,
		/// <summary/>
		GameTraceChannel17,
		/// <summary/>
		GameTraceChannel18
	}

	/// <summary>
	/// Defines collision response types
	/// </summary>
	public enum CollisionResponse : int {
		/// <summary/>
		Ignore,
		/// <summary/>
		Overlap,
		/// <summary/>
		Block
	}

	/// <summary>
	/// Defines the controller hands for tracking
	/// </summary>
	public enum ControllerHand : byte {
		/// <summary/>
		Left,
		/// <summary/>
		Right,
		/// <summary/>
		AnyHand,
		/// <summary/>
		Pad,
		/// <summary/>
		ExternalCamera,
		/// <summary/>
		Gun,
		/// <summary/>
		HMD,
		/// <summary/>
		Special1,
		/// <summary/>
		Special2,
		/// <summary/>
		Special3,
		/// <summary/>
		Special4,
		/// <summary/>
		Special5,
		/// <summary/>
		Special6,
		/// <summary/>
		Special7,
		/// <summary/>
		Special8,
		/// <summary/>
		Special9,
		/// <summary/>
		Special10,
		/// <summary/>
		Special11
	}

	/// <summary>
	/// Defines the horizontal text aligment type
	/// </summary>
	public enum HorizontalTextAligment : int {
		/// <summary/>
		Left,
		/// <summary/>
		Center,
		/// <summary/>
		Right
	}

	/// <summary>
	/// Defines the vertical text aligment type
	/// </summary>
	public enum VerticalTextAligment : int {
		/// <summary/>
		Top,
		/// <summary/>
		Center,
		/// <summary/>
		Bottom
	}

	/// <summary>
	/// Defines behavior when movement is restricted to a 2D plane defined by a specific axis/normal, so that movement along the locked axis will not be possible
	/// </summary>
	public enum PlaneConstraintAxis : byte {
		/// <summary>
		/// Lock movement to a user-defined axis
		/// </summary>
		Custom,
		/// <summary>
		/// Lock movement in the X axis
		/// </summary>
		X,
		/// <summary>
		/// Lock movement in the Y axis
		/// </summary>
		Y,
		/// <summary>
		/// Lock movement in the Z axis
		/// </summary>
		Z,
		/// <summary>
		/// Use the global physics project setting
		/// </summary>
		UseGlobalPhysicsSetting
	}

	/// <summary>
	/// Defines input behavior type
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
	/// Defines the networking mode
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
	/// Defines the pixel format
	/// </summary>
	public enum PixelFormat : int {
		/// <summary/>
		Unknown = 0,
		/// <summary/>
		A32B32G32R32F = 1,
		/// <summary/>
		B8G8R8A8 = 2,
		/// <summary/>
		G8 = 3,
		/// <summary/>
		G16 = 4,
		/// <summary/>
		DXT1 = 5,
		/// <summary/>
		DXT3 = 6,
		/// <summary/>
		DXT5 = 7,
		/// <summary/>
		UYVY = 8,
		/// <summary/>
		FloatRGB = 9,
		/// <summary/>
		FloatRGBA = 10,
		/// <summary/>
		DepthStencil = 11,
		/// <summary/>
		ShadowDepth = 12,
		/// <summary/>
		R32Float = 13,
		/// <summary/>
		G16R16 = 14,
		/// <summary/>
		G16R16F = 15,
		/// <summary/>
		G16R16FFilter = 16,
		/// <summary/>
		G32R32F = 17,
		/// <summary/>
		A2B10G10R10 = 18,
		/// <summary/>
		A16B16G16R16 = 19,
		/// <summary/>
		D24 = 20,
		/// <summary/>
		R16F = 21,
		/// <summary/>
		R16FFilter = 22,
		/// <summary/>
		BC5 = 23,
		/// <summary/>
		V8U8 = 24,
		/// <summary/>
		A1 = 25,
		/// <summary/>
		FloatR11G11B10 = 26,
		/// <summary/>
		A8 = 27,
		/// <summary/>
		R32UInt = 28,
		/// <summary/>
		R32SInt = 29,
		/// <summary/>
		PVRTC2 = 30,
		/// <summary/>
		PVRTC4 = 31,
		/// <summary/>
		R16UInt = 32,
		/// <summary/>
		R16SInt = 33,
		/// <summary/>
		R16G16B16A16UInt = 34,
		/// <summary/>
		R16G16B16A16SInt = 35,
		/// <summary/>
		R5G6B5UNorm = 36,
		/// <summary/>
		R8G8B8A8 = 37,
		/// <summary/>
		A8R8G8B8 = 38,
		/// <summary/>
		BC4 = 39,
		/// <summary/>
		R8G8 = 40,
		/// <summary/>
		ATCRGB = 41,
		/// <summary/>
		ATCRGBAE = 42,
		/// <summary/>
		ATCRGBAI = 43,
		/// <summary/>
		X24G8 = 44,
		/// <summary/>
		ETC1 = 45,
		/// <summary/>
		ETC2RGB = 46,
		/// <summary/>
		ETC2RGBA = 47,
		/// <summary/>
		R32G32B32A32UInt = 48,
		/// <summary/>
		R16G16UInt = 49,
		/// <summary/>
		ASTC4x4 = 50,
		/// <summary/>
		ASTC6x6 = 51,
		/// <summary/>
		ASTC8x8 = 52,
		/// <summary/>
		ASTC10x10 = 53,
		/// <summary/>
		ASTC12x12 = 54,
		/// <summary/>
		BC6H = 55,
		/// <summary/>
		BC7 = 56,
		/// <summary/>
		R8UInt = 57,
		/// <summary/>
		L8 = 58,
		/// <summary/>
		XGXR8 = 59,
		/// <summary/>
		R8G8B8A8UInt = 60,
		/// <summary/>
		R8G8B8A8SNorm = 61,
		/// <summary/>
		R16G16B16A16UNorm = 62,
		/// <summary/>
		R16G16B16A16SNorm = 63,
		/// <summary/>
		PLATFORMHDR0 = 64,
		/// <summary/>
		PLATFORMHDR1 = 65,
		/// <summary/>
		PLATFORMHDR2 = 66,
		/// <summary/>
		NV12 = 67,
		/// <summary/>
		R32G32UInt = 68,
		/// <summary/>
		ETC2R11EAC = 69,
		/// <summary/>
		ETC2RG11EAC = 70,
		/// <summary/>
		R8 = 71,
		/// <summary/>
		B5G5R5A1UNorm = 72,
		/// <summary/>
		ASTC4x4HDR = 73,
		/// <summary/>
		ASTC6x6HDR = 74,
		/// <summary/>
		ASTC8x8HDR = 75,
		/// <summary/>
		ASTC10x10HDR = 76,
		/// <summary/>
		ASTC12x12HDR = 77,
		/// <summary/>
		G16R16SNorm = 78,
		/// <summary/>
		R8G8UInt = 79, 
		/// <summary/>
		R32G32B32UInt = 80, 
		/// <summary/>
		R32G32B32SInt = 81, 
		/// <summary/>
		R32G32B32F = 82,
		/// <summary/>
		R8SInt = 83, 
		/// <summary/>
		R64UInt = 84, 
	}

	/// <summary>
	/// A representation of the engine's object reference
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ObjectReference : IEquatable<ObjectReference> {
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

		/// <summary>
		/// Tests for equality between two objects
		/// </summary>
		public static bool operator ==(ObjectReference left, ObjectReference right) => left.Equals(right);

		/// <summary>
		/// Tests for inequality between two objects
		/// </summary>
		public static bool operator !=(ObjectReference left, ObjectReference right) => !left.Equals(right);

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && Object.isValid(pointer);

		/// <summary>
		/// Returns the unique ID of the object, reused by the engine, only unique while the object is alive
		/// </summary>
		public uint ID => Object.getID(Pointer);

		/// <summary>
		/// Returns the name of the object
		/// </summary>
		public string Name {
			get {
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				Object.getName(Pointer, stringBuffer);

				return stringBuffer.BytesToString();
			}
		}

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(ObjectReference other) => IsCreated && pointer == other.pointer;

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public override bool Equals(object value) {
			if (value == null)
				return false;

			if (!ReferenceEquals(value.GetType(), typeof(ObjectReference)))
				return false;

			return Equals((ObjectReference)value);
		}

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Converts the object reference to the actor of the specified class
		/// </summary>
		/// <returns>An actor or <c>null</c> on failure</returns>
		public T ToActor<T>() where T : Actor {
			T actor = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = Object.toActor(Pointer, actor.Type);

			if (pointer != IntPtr.Zero) {
				actor.Pointer = pointer;

				return actor;
			}

			return null;
		}

		/// <summary>
		/// Converts the object reference to the component of the specified class
		/// </summary>
		/// <returns>A component or <c>null</c> on failure</returns>
		public T ToComponent<T>() where T : ActorComponent {
			T component = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = Object.toComponent(Pointer, component.Type);

			if (pointer != IntPtr.Zero) {
				component.Pointer = pointer;

				return component;
			}

			return null;
		}
	}

	/// <summary>
	/// A representation of the engine's actor reference
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ActorReference : IEquatable<ActorReference> {
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

		/// <summary>
		/// Tests for equality between two objects
		/// </summary>
		public static bool operator ==(ActorReference left, ActorReference right) => left.Equals(right);

		/// <summary>
		/// Tests for inequality between two objects
		/// </summary>
		public static bool operator !=(ActorReference left, ActorReference right) => !left.Equals(right);

		/// <summary>
		/// Returns <c>true</c> if the actor is spawned
		/// </summary>
		public bool IsSpawned => pointer != IntPtr.Zero && !Object.isPendingKill(pointer);

		/// <summary>
		/// Returns the unique ID of the object, reused by the engine, only unique while the object is alive
		/// </summary>
		public uint ID => Object.getID(Pointer);

		/// <summary>
		/// Returns the name of the object
		/// </summary>
		public string Name {
			get {
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				Object.getName(Pointer, stringBuffer);

				return stringBuffer.BytesToString();
			}
		}

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(ActorReference other) => IsSpawned && pointer == other.pointer;

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public override bool Equals(object value) {
			if (value == null)
				return false;

			if (!ReferenceEquals(value.GetType(), typeof(ActorReference)))
				return false;

			return Equals((ActorReference)value);
		}

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Converts the actor reference to the actor of the specified class
		/// </summary>
		/// <returns>An actor or <c>null</c> on failure</returns>
		public T ToActor<T>() where T : Actor {
			T actor = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = Object.toActor(Pointer, actor.Type);

			if (pointer != IntPtr.Zero) {
				actor.Pointer = pointer;

				return actor;
			}

			return null;
		}
	}

	/// <summary>
	/// A representation of the engine's component reference
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ComponentReference : IEquatable<ComponentReference> {
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

		/// <summary>
		/// Tests for equality between two objects
		/// </summary>
		public static bool operator ==(ComponentReference left, ComponentReference right) => left.Equals(right);

		/// <summary>
		/// Tests for inequality between two objects
		/// </summary>
		public static bool operator !=(ComponentReference left, ComponentReference right) => !left.Equals(right);

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && Object.isValid(pointer);

		/// <summary>
		/// Returns the unique ID of the object, reused by the engine, only unique while the object is alive
		/// </summary>
		public uint ID => Object.getID(Pointer);

		/// <summary>
		/// Returns the name of the object
		/// </summary>
		public string Name {
			get {
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				Object.getName(Pointer, stringBuffer);

				return stringBuffer.BytesToString();
			}
		}

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(ComponentReference other) => IsCreated && pointer == other.pointer;

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public override bool Equals(object value) {
			if (value == null)
				return false;

			if (!ReferenceEquals(value.GetType(), typeof(ComponentReference)))
				return false;

			return Equals((ComponentReference)value);
		}

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Converts the component reference to the component of the specified class
		/// </summary>
		/// <returns>A component or <c>null</c> on failure</returns>
		public T ToComponent<T>() where T : ActorComponent {
			T component = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = Object.toComponent(Pointer, component.Type);

			if (pointer != IntPtr.Zero) {
				component.Pointer = pointer;

				return component;
			}

			return null;
		}
	}

	/// <summary>
	/// A linear 32-bit floating-point RGBA color
	/// </summary>
	public partial struct LinearColor : IEquatable<LinearColor> {
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
		public LinearColor(Color value) {
			r = Tables.Color[value.R];
			g = Tables.Color[value.G];
			b = Tables.Color[value.B];
			a = Tables.Color[value.A];
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
		/// Gets or sets the red component of the linear color
		/// </summary>
		public float R {
			get => r;
			set => r = value;
		}

		/// <summary>
		/// Gets or sets the green component of the linear color
		/// </summary>
		public float G {
			get => g;
			set => g = value;
		}

		/// <summary>
		/// Gets or sets the blue component of the linear color
		/// </summary>
		public float B {
			get => b;
			set => b = value;
		}

		/// <summary>
		/// Gets or sets the alpha component of the linear color
		/// </summary>
		public float A {
			get => a;
			set => a = value;
		}

		/// <summary>
		/// The black color
		/// </summary>
		public static LinearColor Black => new(0.0f, 0.0f, 0.0f, 1.0f);

		/// <summary>
		/// The blue color
		/// </summary>
		public static LinearColor Blue => new(0.0f, 0.0f, 1.0f, 1.0f);

		/// <summary>
		/// The green color
		/// </summary>
		public static LinearColor Green => new(0.0f, 1.0f, 0.0f, 1.0f);

		/// <summary>
		/// The grey color
		/// </summary>
		public static LinearColor Grey => new(0.5f, 0.5f, 0.5f, 1.0f);

		/// <summary>
		/// The red color
		/// </summary>
		public static LinearColor Red => new(1.0f, 0.0f, 0.0f, 1.0f);

		/// <summary>
		/// The white color
		/// </summary>
		public static LinearColor White => new(1.0f, 1.0f, 1.0f, 1.0f);

		/// <summary>
		/// The yellow color
		/// </summary>
		public static LinearColor Yellow => new(1.0f, 1.0f, 0.0f, 1.0f);

		/// <summary>
		/// Tests for equality between two objects
		/// </summary>
		public static bool operator ==(LinearColor left, LinearColor right) => left.Equals(right);

		/// <summary>
		/// Tests for inequality between two objects
		/// </summary>
		public static bool operator !=(LinearColor left, LinearColor right) => !left.Equals(right);

		/// <summary>
		/// Adds two colors
		/// </summary>
		public static LinearColor operator +(LinearColor left, LinearColor right) => new(left.r + right.r, left.g + right.g, left.b + right.b, left.a + right.a);

		/// <summary>
		/// Subtracts two colors
		/// </summary>
		public static LinearColor operator -(LinearColor left, LinearColor right) => new(left.b - right.b, left.g - right.g, left.b - right.b, left.a - right.a);

		/// <summary>
		/// Multiplies two colors
		/// </summary>
		public static LinearColor operator *(float scale, LinearColor value) => new(value.r * scale, value.g * scale, value.b * scale, value.a * scale);

		/// <summary>
		/// Divides two colors
		/// </summary>
		public static LinearColor operator /(float scale, LinearColor value) => new(value.r / scale, value.g / scale, value.b / scale, value.a / scale);

		/// <summary>
		/// Implicitly casts color instance to a linear color
		/// </summary>
		public static implicit operator LinearColor(Color value) => new(value);

		/// <summary>
		/// Implicitly casts this instance to a string
		/// </summary>
		public static implicit operator string(LinearColor value) => value.ToString();

		/// <summary>
		/// Adds two colors
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearColor Add(LinearColor left, LinearColor right) => new(left.r + right.r, left.g + right.g, left.b + right.b, left.a + right.a);

		/// <summary>
		/// Subtracts two colors
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearColor Subtract(LinearColor left, LinearColor right) => new(left.r - right.r, left.g - right.g, left.b - right.b, left.a - right.a);

		/// <summary>
		/// Multiplies two colors
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearColor Multiply(LinearColor left, LinearColor right) => new(left.r * right.r, left.g * right.g, left.b * right.b, left.a * right.a);

		/// <summary>
		/// Divides two colors
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearColor Divide(LinearColor left, LinearColor right) => new(left.r / right.r, left.g / right.g, left.b / right.b, left.a / right.a);

		/// <summary>
		/// Performs a linear interpolation between two colors
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearColor Lerp(LinearColor start, LinearColor end, float amount) => new(Maths.Lerp(start.r, end.r, amount), Maths.Lerp(start.g, end.g, amount), Maths.Lerp(start.b, end.b, amount), Maths.Lerp(start.a, end.a, amount));

		/// <summary>
		/// Converts the color into a linear color
		/// </summary>
		public static LinearColor FromColor(Color value) => new(value);

		/// <summary>
		/// Converts the linear color into a three component vector
		/// </summary>
		public Vector3 ToVector3() => new(r, g, b);

		/// <summary>
		/// Converts the linear color into a four component vector
		/// </summary>
		public Vector4 ToVector4() => new(r, g, b, a);

		/// <summary>
		/// Creates an array containing the elements of the linear color
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
	public partial struct Transform : IEquatable<Transform> {
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
		/// Tests for equality between two objects
		/// </summary>
		public static bool operator ==(Transform left, Transform right) => left.Equals(right);

		/// <summary>
		/// Tests for inequality between two objects
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
	/// A trace hit
	/// </summary>
	public partial struct Hit : IEquatable<Hit> {
		/// <summary>
		/// Returns the location in world space where the moving shape would end up against the impacted object if there was a hit
		/// </summary>
		public Vector3 Location => location;

		/// <summary>
		/// Returns the location in world space of the actual contact of the trace shape with the impacted object
		/// </summary>
		public Vector3 ImpactLocation => impactLocation;

		/// <summary>
		/// Returns the normal of the hit in world space for the object that was swept
		/// </summary>
		public Vector3 Normal => normal;

		/// <summary>
		/// Returns the normal of the hit in world space for the object that was hit by the sweep
		/// </summary>
		public Vector3 ImpactNormal => impactNormal;

		/// <summary>
		/// Returns the start location of the trace
		/// </summary>
		public Vector3 TraceStart => traceStart;

		/// <summary>
		/// Returns the end location of the trace
		/// </summary>
		public Vector3 TraceEnd => traceEnd;

		/// <summary>
		/// Returns the impact along trace direction between 0.0f and 1.0f if there was a hit, indicating time between <see cref="TraceStart"/> and <see cref="TraceEnd"/>
		/// </summary>
		public float Time => time;

		/// <summary>
		/// Returns the distance from <see cref="TraceStart"/> to <see cref="Location"/> in world space
		/// </summary>
		public float Distance => distance;

		/// <summary>
		/// Returns the distance along with <see cref="Normal"/> that will result in moving out of penetration if <see cref="StartPenetrating"/> is <c>true</c> and a penetration vector can be computed
		/// </summary>
		public float PenetrationDepth => penetrationDepth;

		/// <summary>
		/// Returns <c>true</c> if the hit was a result of blocking collision
		/// </summary>
		public bool BlockingHit => blockingHit;

		/// <summary>
		/// Returns <c>true</c> if the trace started penetration
		/// </summary>
		public bool StartPenetrating => startPenetrating;

		/// <summary>
		/// Returns the owner actor of the component that was hit or <c>null</c> on failure
		/// </summary>
		public Actor GetActor() {
			if (actor != IntPtr.Zero)
				return new(actor);

			return null;
		}

		/// <summary>
		/// Implicitly casts this instance to a string
		/// </summary>
		public static implicit operator string(Hit value) => value.ToString();

		/// <summary>
		/// Returns a string that represents this instance
		/// </summary>
		public override string ToString() => ToString(CultureInfo.CurrentCulture);

		/// <summary>
		/// Returns a string that represents this instance
		/// </summary>
		public string ToString(IFormatProvider formatProvider) => string.Format(formatProvider, "Location:{0} ImpactLocation:{1} Normal:{2} ImpactNormal:{3}, TraceStart:{4}, TraceEnd:{5}, Time:{6}, Distance:{7}, PenetrationDepth:{8}, BlockingHit:{9}, StartPenetrating:{10}, Actor:{11}", Location, ImpactLocation, Normal, ImpactNormal, TraceStart, TraceEnd, Time, Distance, PenetrationDepth, BlockingHit, StartPenetrating, actor != IntPtr.Zero);

		/// <summary>
		/// Tests for equality between two objects
		/// </summary>
		public static bool operator ==(Hit left, Hit right) => left.Equals(right);

		/// <summary>
		/// Tests for inequality between two objects
		/// </summary>
		public static bool operator !=(Hit left, Hit right) => !left.Equals(right);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(Hit other) => location == other.location && impactLocation == other.impactLocation && normal == other.normal && impactNormal == other.impactNormal && traceStart == other.traceStart && traceEnd == other.traceEnd && actor == other.actor && time == other.time && distance == other.distance && penetrationDepth == other.penetrationDepth && blockingHit == other.blockingHit && startPenetrating == other.startPenetrating;

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public override bool Equals(object value) {
			if (value == null)
				return false;

			if (!ReferenceEquals(value.GetType(), typeof(Hit)))
				return false;

			return Equals((Hit)value);
		}

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => HashCode.Combine(location, impactLocation, normal, impactNormal, traceStart, traceEnd, actor) ^ HashCode.Combine(time, distance, penetrationDepth, blockingHit, startPenetrating);
	}

	/// <summary>
	/// A combined axis-aligned bounding box and bounding sphere with the same origin
	/// </summary>
	public partial struct Bounds : IEquatable<Bounds> {
		/// <summary>
		/// Returns the origin of the bounding box and sphere
		/// </summary>
		public Vector3 Origin => origin;

		/// <summary>
		/// Returns the extent of the bounding box
		/// </summary>
		public Vector3 BoxExtent => boxExtent;

		/// <summary>
		/// Returns the radius of the bounding sphere
		/// </summary>
		public double SphereRadius => sphereRadius;

		/// <summary>
		/// Tests for equality between two objects
		/// </summary>
		public static bool operator ==(Bounds left, Bounds right) => left.Equals(right);

		/// <summary>
		/// Tests for inequality between two objects
		/// </summary>
		public static bool operator !=(Bounds left, Bounds right) => !left.Equals(right);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(Bounds other) => origin == other.origin && boxExtent == other.boxExtent && sphereRadius == other.sphereRadius;

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public override bool Equals(object value) {
			if (value == null)
				return false;

			if (!ReferenceEquals(value.GetType(), typeof(Bounds)))
				return false;

			return Equals((Bounds)value);
		}

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => HashCode.Combine(origin, boxExtent, sphereRadius);
	}

	/// <summary>
	/// A collision shape
	/// </summary>
	public partial struct CollisionShape : IEquatable<CollisionShape> {
		/// <summary>
		/// Returns the shape type
		/// </summary>
		public CollisionShapeType ShapeType => shapeType;

		/// <summary>
		/// Returns a box shape
		/// </summary>
		public static CollisionShape CreateBox(in Vector3 halfExtent) {
			CollisionShape collisionShape = default;

			collisionShape.shapeType = CollisionShapeType.Box;
			collisionShape.box.halfExtent = halfExtent;

			return collisionShape;
		}

		/// <summary>
		/// Returns a sphere shape
		/// </summary>
		public static CollisionShape CreateSphere(float radius) {
			CollisionShape collisionShape = default;

			collisionShape.shapeType = CollisionShapeType.Sphere;
			collisionShape.sphere.radius = radius;

			return collisionShape;
		}

		/// <summary>
		/// Returns a capsule shape
		/// </summary>
		public static CollisionShape CreateCapsule(float radius, float halfHeight) {
			CollisionShape collisionShape = default;

			collisionShape.shapeType = CollisionShapeType.Capsule;
			collisionShape.capsule.radius = radius;
			collisionShape.capsule.halfHeight = halfHeight;

			return collisionShape;
		}

		/// <summary>
		/// Tests for equality between two objects
		/// </summary>
		public static bool operator ==(CollisionShape left, CollisionShape right) => left.Equals(right);

		/// <summary>
		/// Tests for inequality between two objects
		/// </summary>
		public static bool operator !=(CollisionShape left, CollisionShape right) => !left.Equals(right);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(CollisionShape other) => shapeType == other.shapeType && box.halfExtent == other.box.halfExtent;

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public override bool Equals(object value) {
			if (value == null)
				return false;

			if (!ReferenceEquals(value.GetType(), typeof(CollisionShape)))
				return false;

			return Equals((CollisionShape)value);
		}

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => HashCode.Combine(shapeType, box.halfExtent);
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
	/// Delegate for actor overlap events
	/// </summary>
	public delegate void ActorOverlapDelegate(ActorReference overlapActor, ActorReference otherActor);

	/// <summary>
	/// Delegate for actor hit events
	/// </summary>
	public delegate void ActorHitDelegate(ActorReference hitActor, ActorReference otherActor, in Vector3 normalImpulse, in Hit hit);

	/// <summary>
	/// Delegate for actor cursor events
	/// </summary>
	public delegate void ActorCursorDelegate(ActorReference actor);

	/// <summary>
	/// Delegate for actor key events
	/// </summary>
	public delegate void ActorKeyDelegate(ActorReference actor, string key);

	/// <summary>
	/// Delegate for component overlap events
	/// </summary>
	public delegate void ComponentOverlapDelegate(ComponentReference overlapComponent, ComponentReference otherComponent);

	/// <summary>
	/// Delegate for component hit events
	/// </summary>
	public delegate void ComponentHitDelegate(ComponentReference hitComponent, ComponentReference otherComponent, in Vector3 normalImpulse, in Hit hit);

	/// <summary>
	/// Delegate for component cursor events
	/// </summary>
	public delegate void ComponentCursorDelegate(ComponentReference component);

	/// <summary>
	/// Delegate for component key events
	/// </summary>
	public delegate void ComponentKeyDelegate(ComponentReference component, string key);

	/// <summary>
	/// Delegate for character landing events
	/// </summary>
	public delegate void CharacterLandedDelegate(in Hit hit);

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
		/// Calculates the shortest difference between the two given angles given in degrees
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
		/// Calculates the shortest difference between the two given angles given in degrees
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
		public static float Repeat(float value, float length) => Math.Clamp(value - MathF.Floor(value / length) * length, 0.0f, length);

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
		public static Vector2 Perpendicular(Vector2 value) => new(-value.Y, value.X);

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

				return new((value.X / magnitude) * maxLength, (value.Y / magnitude) * maxLength);
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

			return new(current.X + destination.X / distance * maxDistanceDelta, current.Y + destination.Y / distance * maxDistanceDelta);
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

				return new((value.X / magnitude) * maxLength, (value.Y / magnitude) * maxLength, (value.Z / magnitude) * maxLength);
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

			return new(current.X + destination.X / distance * maxDistanceDelta, current.Y + destination.Y / distance * maxDistanceDelta, current.Z + destination.Z / distance * maxDistanceDelta);
		}

		/// <summary>
		/// Projects a vector onto another vector
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Project(Vector3 value, Vector3 normal) {
			float squareMagnitude = SquareMagnitude(normal);

			if (squareMagnitude < Single.Epsilon)
				return Vector3.Zero;

			float dot = Vector3.Dot(value, normal);

			return new(normal.X * dot / squareMagnitude, normal.Y * dot / squareMagnitude, normal.Z * dot / squareMagnitude);
		}

		/// <summary>
		/// Projects a vector onto a plane defined by a normal orthogonal to the plane
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ProjectOnPlane(Vector3 value, Vector3 planeNormal) {
			float squareMagnitude = SquareMagnitude(planeNormal);

			if (squareMagnitude < Single.Epsilon)
				return value;

			float dot = Vector3.Dot(value, planeNormal);

			return new(value.X - planeNormal.X * dot / squareMagnitude, value.Y - planeNormal.Y * dot / squareMagnitude, value.Z - planeNormal.Z * dot / squareMagnitude);
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
		/// Returns a rotation which rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion Euler(float x, float y, float z) {
			x *= DegToRadF;
			y *= DegToRadF;
			z *= DegToRadF;

			return CreateFromYawPitchRoll(z, -y, -x);
		}

		/// <summary>
		/// Returns a rotation which rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis
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
		/// Returns a rotation which rotates angle degrees around axis
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion AngleAxis(float angle, Vector3 axis) {
			axis = axis * DegToRadF;
			axis = Vector3.Normalize(axis);

			float halfAngle = angle * DegToRadF * 0.5f;
			float sin = MathF.Sin(halfAngle);

			return new(axis.X * sin, axis.Y * sin, axis.Z * sin, MathF.Cos(halfAngle));
		}

		/// <summary>
		/// Returns a rotation which rotates from <paramref name="fromDirection"/> to <paramref name="toDirection"/>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection) {
			float dot = Vector3.Dot(fromDirection, toDirection);
			float normal = MathF.Sqrt(SquareMagnitude(fromDirection) * SquareMagnitude(toDirection));
			float real = normal + dot;
			Vector3 final = default;

			if (real < Single.Epsilon * normal) {
				real = 0.0f;
				final = MathF.Abs(fromDirection.X) > MathF.Abs(fromDirection.Z) ? new(-fromDirection.Y, fromDirection.X, 0.0f) : new(0.0f, -fromDirection.Z, fromDirection.Y);
			} else {
				final = Vector3.Cross(fromDirection, toDirection);
			}

			return Quaternion.Normalize(new(final, real));
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
		/// Returns a rotation which rotated towards a target
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta) {
			float angle = Angle(from, to);

			if (angle == 0.0f)
				return to;

			return Quaternion.Slerp(from, to, MathF.Min(1.0f, maxDegreesDelta / angle));
		}

		/// <summary>
		/// Returns a rotation from the given yaw, pitch, and roll, in radians
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion CreateFromYawPitchRoll(float yaw, float pitch, float roll) {
			float sr, cr, sp, cp, sy, cy;
			float halfRoll = roll * 0.5f;

			sr = MathF.Sin(halfRoll);
			cr = MathF.Cos(halfRoll);

			float halfPitch = pitch * 0.5f;

			sp = MathF.Sin(halfPitch);
			cp = MathF.Cos(halfPitch);

			float halfYaw = yaw * 0.5f;

			sy = MathF.Sin(halfYaw);
			cy = MathF.Cos(halfYaw);

			Quaternion result = default;

			result.X = cy * cp * sr - sy * sp * cr;
			result.Y = cy * sp * cr + sy * cp * sr;
			result.Z = sy * cp * cr - cy * sp * sr;
			result.W = cy * cp * cr + sy * sp * sr;

			return result;
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
	public static unsafe partial class Assert {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new(8192);

		private static void Message(string message, int callerLineNumber, string callerFilePath) {
			stringBuffer.Clear()
			.AppendFormat("Assertion is failed at line {0} in file \"{1}\"", callerLineNumber, callerFilePath);

			if (message != null)
				stringBuffer.AppendFormat(" with message: {0}", message);

			outputMessage(stringBuffer.ToString().StringToBytes());

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
	public static unsafe partial class CommandLine {
		/// <summary>
		/// Returns the user arguments
		/// </summary>
		public static string Get() {
			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			get(stringBuffer);

			return stringBuffer.BytesToString();
		}

		/// <summary>
		/// Overrides the arguments
		/// </summary>
		public static void Set(string arguments) {
			if (arguments == null)
				throw new ArgumentNullException(nameof(arguments));

			set(arguments.StringToBytes());
		}

		/// <summary>
		/// Appends the string to the arguments as it is without adding a space
		/// </summary>
		public static void Append(string arguments) {
			if (arguments == null)
				throw new ArgumentNullException(nameof(arguments));

			append(arguments.StringToBytes());
		}
	}

	/// <summary>
	/// Functionality for debugging
	/// </summary>
	public static unsafe partial class Debug {
		[ThreadStatic]
		private static StringBuilder stringBuffer = new(8192);

		/// <summary>
		/// Logs a message in accordance to the specified level, omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration
		/// </summary>
		public static void Log(LogLevel level, string message) {
			if (message == null)
				throw new ArgumentNullException(nameof(message));

			log(level, message.StringToBytes());
		}

		/// <summary>
		/// Creates a log file with the name of assembly if required and writes an exception to it, prints it on the screen, printing on the screen is omitted in builds with the <a href="https://docs.unrealengine.com/en-US/Programming/Development/BuildConfigurations/index.html#buildconfigurationdescriptions">Shipping</a> configuration, but log file will persist
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

			Debug.exception(stringBuffer.ToString().StringToBytes());

			using (StreamWriter streamWriter = File.AppendText(Application.ProjectDirectory + "Saved/Logs/Exceptions-" + Assembly.GetCallingAssembly().GetName().Name + ".log")) {
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

			addOnScreenMessage(key, timeToDisplay, displayColor.ToArgb(), message.StringToBytes());
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
	public static unsafe partial class Application {
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
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				getProjectDirectory(stringBuffer);

				return stringBuffer.BytesToString();
			}
		}

		/// <summary>
		/// Returns the default language used by current platform
		/// </summary>
		public static string DefaultLanguage {
			get {
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				getDefaultLanguage(stringBuffer);

				return stringBuffer.BytesToString();
			}
		}

		/// <summary>
		/// Gets or sets the name of the current project
		/// </summary>
		public static string ProjectName {
			get {
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				getProjectName(stringBuffer);

				return stringBuffer.BytesToString();
			}

			set {
				setProjectName(value.StringToBytes());
			}
		}

		/// <summary>
		/// Gets or sets the current volume multiplier
		/// </summary>
		public static float VolumeMultiplier {
			get => getVolumeMultiplier();
			set => setVolumeMultiplier(value);
		}

		/// <summary>
		/// Requests application exit
		/// </summary>
		public static void RequestExit(bool force = false) => requestExit(force);
	}

	/// <summary>
	/// Handles console commands and variables
	/// </summary>
	public static unsafe partial class ConsoleManager {
		/// <summary>
		/// Returns <c>true</c> if a console command or variable has been registered
		/// </summary>
		public static bool IsRegisteredVariable(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return isRegisteredVariable(name.StringToBytes());
		}

		/// <summary>
		/// Finds a console variable
		/// </summary>
		/// <returns>A console variable or <c>null</c> on failure</returns>
		public static ConsoleVariable FindVariable(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (findVariable(name.StringToBytes()) != IntPtr.Zero)
				return new(name);

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

			if (registerVariableBool(name.StringToBytes(), help.StringToBytes(), defaultValue, readOnly) != IntPtr.Zero)
				return new(name);

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

			if (registerVariableInt(name.StringToBytes(), help.StringToBytes(), defaultValue, readOnly) != IntPtr.Zero)
				return new(name);

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

			if (registerVariableFloat(name.StringToBytes(), help.StringToBytes(), defaultValue, readOnly) != IntPtr.Zero)
				return new(name);

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

			if (registerVariableString(name.StringToBytes(), help.StringToBytes(), defaultValue.StringToBytes(), readOnly) != IntPtr.Zero)
				return new(name);

			return null;
		}

		/// <summary>
		/// Creates and registers the callback function for a console command that takes no arguments, remains alive during the lifetime of the engine until unregistered
		/// </summary>
		/// <param name="name">The name of the command</param>
		/// <param name="help">Help text for the command</param>
		/// <param name="callback">The function to call when the command is executed</param>
		/// <param name="readOnly">If <c>true</c>, cannot be changed by the user from console</param>
		public static void RegisterCommand(string name, string help, ConsoleCommandDelegate callback, bool readOnly = false) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (help == null)
				throw new ArgumentNullException(nameof(help));

			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			registerCommand(name.StringToBytes(), help.StringToBytes(), Collector.GetFunctionPointer(callback), readOnly);
		}

		/// <summary>
		/// Deletes and unregisters a console command or variable
		/// </summary>
		public static void UnregisterObject(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			unregisterObject(name.StringToBytes());
		}
	}

	/// <summary>
	/// Functionality for management of engine systems
	/// </summary>
	public static unsafe partial class Engine {
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
		/// Returns the current size of the viewport
		/// </summary>
		public static Vector2 GetViewportSize() {
			Vector2 value = default;

			getViewportSize(ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the current resolution of the screen
		/// </summary>
		public static void GetScreenResolution(ref Vector2 value) => getScreenResolution(ref value);

		/// <summary>
		/// Returns the current resolution of the screen
		/// </summary>
		public static Vector2 GetScreenResolution() {
			Vector2 value = default;

			getScreenResolution(ref value);

			return value;
		}

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
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				getVersion(stringBuffer);

				return stringBuffer.BytesToString();
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
		/// Adds an engine defined action mapping, cannot be remapped
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

			addActionMapping(actionName.StringToBytes(), key.StringToBytes(), shift, ctrl, alt, cmd);
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

			addAxisMapping(axisName.StringToBytes(), key.StringToBytes(), scale);
		}

		/// <summary>
		/// Sets the window title
		/// </summary>
		public static void SetTitle(string title) => setTitle(title.StringToBytes());
	}

	/// <summary>
	/// Functionality for access to the head-mounted display
	/// </summary>
	public static unsafe partial class HeadMountedDisplay {
		/// <summary>
		/// Returns <c>true</c> if the head-mounted display is connected and ready to use
		/// </summary>
		public static bool IsConnected => isConnected();

		/// <summary>
		/// Gets or sets whether the head-mounted display is enabled
		/// </summary>
		public static bool Enabled {
			get => getEnabled();
			set => setEnable(value);
		}

		/// <summary>
		/// Gets or sets whether the head-mounted display is in low or full persistence mode
		/// </summary>
		public static bool LowPersistenceMode {
			get => getLowPersistenceMode();
			set => setLowPersistenceMode(value);
		}

		/// <summary>
		/// Returns the name of the device
		/// </summary>
		public static string DeviceName {
			get {
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				getDeviceName(stringBuffer);

				return stringBuffer.BytesToString();
			}
		}
	}

	/// <summary>
	/// The top-level representation of a map or a sandbox in which actors and components will exist and rendered
	/// </summary>
	public static unsafe partial class World {
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
		/// Returns the name of the current level
		/// </summary>
		public static string CurrentLevelName {
			get {
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				getCurrentLevelName(stringBuffer);

				return stringBuffer.BytesToString();
			}
		}

		/// <summary>
		/// Gets or sets physics simulation for the world
		/// </summary>
		public static bool SimulatePhysics {
			get => getSimulatePhysics();
			set => setSimulatePhysics(value);
		}

		/// <summary>
		/// Performs the specified action on each actor in the world
		/// </summary>
		public static unsafe void ForEachActor<T>(Action<T> action) where T : Actor {
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			ObjectReference* array = null;
			int elements = 0;

			forEachActor(ref array, ref elements);

			for (int i = 0; i < elements; i++) {
				T actor = array[i].ToActor<T>();

				if (actor != null)
					action(actor);
			}
		}

		/// <summary>
		/// Returns the first actor in the world of the specified class, optionally with the specified name, this operation is slow and should be used with caution
		/// </summary>
		/// <param name="name">The name of the actor, may differ from the label in the editor</param>
		/// <typeparam name="T">The type of the actor</typeparam>
		/// <returns>An actor or <c>null</c> on failure</returns>
		public static T GetActor<T>(string name = null) where T : Actor {
			T actor = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = getActor(name.StringToBytes(), actor.Type);

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
			IntPtr pointer = getActorByTag(tag.StringToBytes(), actor.Type);

			if (pointer != IntPtr.Zero) {
				actor.Pointer = pointer;

				return actor;
			}

			return null;
		}

		/// <summary>
		/// Returns the first actor in the world of the specified class and ID, this operation is slow and should be used with caution
		/// </summary>
		/// <param name="id">The ID of the actor</param>
		/// <typeparam name="T">The type of the actor</typeparam>
		/// <returns>An actor or <c>null</c> on failure</returns>
		public static T GetActorByID<T>(uint id) where T : Actor {
			T actor = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = getActorByID(id, actor.Type);

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
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Returns the current game mode instance which is always valid during gameplay on the server
		/// </summary>
		/// <returns>A game mode or <c>null</c> on failure</returns>
		public static GameModeBase GetGameMode() {
			IntPtr pointer = getGameMode();

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Retrieves the current location of the <a href="https://docs.unrealengine.com/en-US/Engine/LevelStreaming/WorldBrowser/index.html">world origin</a> to a reference
		/// </summary>
		public static void GetWorldOrigin(ref Vector3 value) => getWorldOrigin(ref value);

		/// <summary>
		/// Returns the current location of the <a href="https://docs.unrealengine.com/en-US/Engine/LevelStreaming/WorldBrowser/index.html">world origin</a>
		/// </summary>
		public static Vector3 GetWorldOrigin() {
			Vector3 value = default;

			getWorldOrigin(ref value);

			return value;
		}

		/// <summary>
		/// Sets the callback function that is called when actors start overlapping
		/// </summary>
		public static void SetOnActorBeginOverlapCallback(ActorOverlapDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnActorBeginOverlapCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when actors end overlapping
		/// </summary>
		public static void SetOnActorEndOverlapCallback(ActorOverlapDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnActorEndOverlapCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when actors hit collisions
		/// </summary>
		public static void SetOnActorHitCallback(ActorHitDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnActorHitCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when the mouse cursor is moved over an actor if mouse over events are enabled in the player controller
		/// </summary>
		public static void SetOnActorBeginCursorOverCallback(ActorCursorDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnActorBeginCursorOverCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when the mouse cursor is moved off an actor if mouse over events are enabled in the player controller
		/// </summary>
		public static void SetOnActorEndCursorOverCallback(ActorCursorDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnActorEndCursorOverCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when the mouse button is clicked while the mouse is over an actor if click events are enabled in the player controller
		/// </summary>
		public static void SetOnActorClickedCallback(ActorKeyDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnActorClickedCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when the mouse button is released while the mouse is over an actor if click events are enabled in the player controller
		/// </summary>
		public static void SetOnActorReleasedCallback(ActorKeyDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnActorReleasedCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when primitive components start overlapping
		/// </summary>
		public static void SetOnComponentBeginOverlapCallback(ComponentOverlapDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnComponentBeginOverlapCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when primitive components end overlapping
		/// </summary>
		public static void SetOnComponentEndOverlapCallback(ComponentOverlapDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnComponentEndOverlapCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when components hit collisions
		/// </summary>
		public static void SetOnComponentHitCallback(ComponentHitDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnComponentHitCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when the mouse cursor is moved over a component and mouse over events are enabled in the player controller
		/// </summary>
		public static void SetOnComponentBeginCursorOverCallback(ComponentCursorDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnComponentBeginCursorOverCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when the mouse cursor is moved off a component and mouse over events are enabled in the player controller
		/// </summary>
		public static void SetOnComponentEndCursorOverCallback(ComponentCursorDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnComponentEndCursorOverCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when the mouse button is clicked while the mouse is over a component if click events are enabled in the player controller
		/// </summary>
		public static void SetOnComponentClickedCallback(ComponentKeyDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnComponentClickedCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the callback function that is called when the mouse button is released while the mouse is over a component if click events are enabled in the player controller
		/// </summary>
		public static void SetOnComponentReleasedCallback(ComponentKeyDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnComponentReleasedCallback(Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Sets the gravity applied to all objects in the world
		/// </summary>
		public static void SetGravity(float value) => setGravity(value);

		/// <summary>
		/// Sets <a href="https://docs.unrealengine.com/en-US/Engine/LevelStreaming/WorldBrowser/index.html">world origin</a> to the specified location
		/// </summary>
		/// <returns><c>true</c> if the world origin was succesfuly shifted, or <c>false</c> if one of the levels are pending visibility update</returns>
		public static bool SetWorldOrigin(in Vector3 value) => setWorldOrigin(value);

		/// <summary>
		/// Travels to another level
		/// </summary>
		public static void OpenLevel(string levelName) => openLevel(levelName.StringToBytes());

		/// <summary>
		/// Traces a ray against the world using a specific channel
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool LineTraceTestByChannel(in Vector3 start, in Vector3 end, CollisionChannel channel, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => lineTraceTestByChannel(start, end, channel, traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

		/// <summary>
		/// Traces a ray against the world using a specific profile
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool LineTraceTestByProfile(in Vector3 start, in Vector3 end, string profileName, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => lineTraceTestByProfile(start, end, profileName.StringToBytes(), traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

		/// <summary>
		/// Traces a ray against the world using a specific channel and retrieves the first blocking hit
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool LineTraceSingleByChannel(in Vector3 start, in Vector3 end, CollisionChannel channel, ref Hit hit, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => lineTraceSingleByChannel(start, end, channel, ref hit, null, traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

		/// <summary>
		/// Traces a ray against the world using a specific channel and retrieves the first blocking hit with a bone name
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool LineTraceSingleByChannel(in Vector3 start, in Vector3 end, CollisionChannel channel, ref Hit hit, ref string boneName, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) {
			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			bool result = lineTraceSingleByChannel(start, end, channel, ref hit, stringBuffer, traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

			boneName = stringBuffer.BytesToString();

			return result;
		}

		/// <summary>
		/// Traces a ray against the world using a specific profile and retrieves the first blocking hit
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool LineTraceSingleByProfile(in Vector3 start, in Vector3 end, string profileName, ref Hit hit, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => lineTraceSingleByProfile(start, end, profileName.StringToBytes(), ref hit, null, traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

		/// <summary>
		/// Traces a ray against the world using a specific profile and retrieves the first blocking hit with a bone name
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool LineTraceSingleByProfile(in Vector3 start, in Vector3 end, string profileName, ref Hit hit, ref string boneName, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) {
			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			bool result = lineTraceSingleByProfile(start, end, profileName.StringToBytes(), ref hit, stringBuffer, traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

			boneName = stringBuffer.BytesToString();

			return result;
		}

		/// <summary>
		/// Sweeps a shape against the world using a specific profile
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool SweepTestByChannel(in Vector3 start, in Vector3 end, in Quaternion rotation, CollisionChannel channel, in CollisionShape shape, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => sweepTestByChannel(start, end, rotation, channel, shape, traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

		/// <summary>
		/// Sweeps a shape against the world using a specific profile
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool SweepTestByProfile(in Vector3 start, in Vector3 end, in Quaternion rotation, string profileName, in CollisionShape shape, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => sweepTestByProfile(start, end, rotation, profileName.StringToBytes(), shape, traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

		/// <summary>
		/// Sweeps a shape against the world using a specific profile and retrieves the first blocking hit
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool SweepSingleByChannel(in Vector3 start, in Vector3 end, in Quaternion rotation, CollisionChannel channel, in CollisionShape shape, ref Hit hit, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => sweepSingleByChannel(start, end, rotation, channel, shape, ref hit, null, traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

		/// <summary>
		/// Sweeps a shape against the world using a specific profile and retrieves the first blocking hit with a bone name
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool SweepSingleByChannel(in Vector3 start, in Vector3 end, in Quaternion rotation, CollisionChannel channel, in CollisionShape shape, ref Hit hit, ref string boneName, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) {
			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			bool result = sweepSingleByChannel(start, end, rotation, channel, shape, ref hit, stringBuffer, traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

			boneName = stringBuffer.BytesToString();

			return result;
		}

		/// <summary>
		/// Sweeps a shape against the world using a specific profile and retrieves the first blocking hit
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool SweepSingleByProfile(in Vector3 start, in Vector3 end, in Quaternion rotation, string profileName, in CollisionShape shape, ref Hit hit, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => sweepSingleByProfile(start, end, rotation, profileName.StringToBytes(), shape, ref hit, null, traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

		/// <summary>
		/// Sweeps a shape against the world using a specific profile and retrieves the first blocking hit with a bone name
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool SweepSingleByProfile(in Vector3 start, in Vector3 end, in Quaternion rotation, string profileName, in CollisionShape shape, ref Hit hit, ref string boneName, bool traceComplex = false, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) {
			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			bool result = sweepSingleByProfile(start, end, rotation, profileName.StringToBytes(), shape, ref hit, stringBuffer, traceComplex, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

			boneName = stringBuffer.BytesToString();

			return result;
		}

		/// <summary>
		/// Tests the collision shape at the specified location using a specific channel to determine if any blocking or overlapping occurred
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool OverlapAnyTestByChannel(in Vector3 location, in Quaternion rotation, CollisionChannel channel, in CollisionShape shape, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => overlapAnyTestByChannel(location, rotation, channel, shape, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

		/// <summary>
		/// Tests the collision shape at the specified location using a specific profile to determine if any blocking or overlapping occurred
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool OverlapAnyTestByProfile(in Vector3 location, in Quaternion rotation, string profileName, in CollisionShape shape, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => overlapAnyTestByProfile(location, rotation, profileName.StringToBytes(), shape, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

		/// <summary>
		/// Tests the collision shape at the specified location using a specific channel to determine if any blocking occurred
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool OverlapBlockingTestByChannel(in Vector3 location, in Quaternion rotation, CollisionChannel channel, in CollisionShape shape, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => overlapBlockingTestByChannel(location, rotation, channel, shape, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);

		/// <summary>
		/// Tests the collision shape at the specified location using a specific profile to determine if any blocking occurred
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public static bool OverlapBlockingTestByProfile(in Vector3 location, in Quaternion rotation, string profileName, in CollisionShape shape, Actor ignoredActor = null, PrimitiveComponent ignoredComponent = null) => overlapBlockingTestByProfile(location, rotation, profileName.StringToBytes(), shape, ignoredActor != null ? ignoredActor.Pointer : IntPtr.Zero, ignoredComponent != null ? ignoredComponent.Pointer : IntPtr.Zero);
	}

	/// <summary>
	/// A representation of the asset
	/// </summary>
	public unsafe partial struct Asset : IEquatable<Asset> {
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

		/// <summary>
		/// Tests for equality between two objects
		/// </summary>
		public static bool operator ==(Asset left, Asset right) => left.Equals(right);

		/// <summary>
		/// Tests for inequality between two objects
		/// </summary>
		public static bool operator !=(Asset left, Asset right) => !left.Equals(right);

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && isValid(pointer);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(Asset other) => IsCreated && pointer == other.pointer;

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public override bool Equals(object value) {
			if (value == null)
				return false;

			if (!ReferenceEquals(value.GetType(), typeof(Asset)))
				return false;

			return Equals((Asset)value);
		}

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Returns the name of the asset
		/// </summary>
		public string Name {
			get {
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				getName(Pointer, stringBuffer);

				return stringBuffer.BytesToString();
			}
		}

		/// <summary>
		/// Returns the path to the asset
		/// </summary>
		public string Path {
			get {
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				getPath(Pointer, stringBuffer);

				return stringBuffer.BytesToString();
			}
		}
	}

	/// <summary>
	/// An asset registry
	/// </summary>
	public unsafe partial class AssetRegistry : IEquatable<AssetRegistry> {
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

		/// <summary>
		/// Initializes a new instance of the asset registry
		/// </summary>
		public AssetRegistry() => Pointer = get();

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero;

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(AssetRegistry other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Checks whether the given path contain assets, optionally testing sub-paths
		/// </summary>
		public bool HasAssets(string path, bool recursive = false) {
			if (path == null)
				throw new ArgumentNullException(nameof(path));

			return hasAssets(Pointer, path.StringToBytes(), recursive);
		}

		/// <summary>
		/// Performs the specified action on each asset if any
		/// </summary>
		public unsafe void ForEachAsset(Action<Asset> action, string path, bool recursive = false, bool includeOnlyOnDiskAssets = false) {
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			Asset* array = null;
			int elements = 0;

			forEachAsset(Pointer, path.StringToBytes(), recursive, includeOnlyOnDiskAssets, ref array, ref elements);

			for (int i = 0; i < elements; i++) {
				action(array[i]);
			}
		}
	}

	/// <summary>
	/// Interface for console objects
	/// </summary>
	public unsafe partial class ConsoleObject : IEquatable<ConsoleObject> {
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
				IntPtr pointer = ConsoleManager.findVariable(Name.StringToBytes());

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
		public bool IsCreated => name != null && ConsoleManager.isRegisteredVariable(name.StringToBytes());

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(ConsoleObject other) => IsCreated && name == other?.name;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => name.GetHashCode(StringComparison.Ordinal);

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
	public unsafe partial class ConsoleVariable : ConsoleObject {
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
			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			getString(Pointer, stringBuffer);

			return stringBuffer.BytesToString();
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
		public void SetString(string value) => setString(Pointer, value.StringToBytes());

		/// <summary>
		/// Sets the callback function that is called when the console variable value changes
		/// </summary>
		/// <param name="callback">The function to call when the value of variable is changed</param>
		public void SetOnChangedCallback(ConsoleVariableDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnChangedCallback(Pointer, Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Clears callback function
		/// </summary>
		public void ClearOnChangedCallback() => clearOnChangedCallback(Pointer);
	}

	/// <summary>
	/// The base class of an object that can be placed or spawned in a level
	/// </summary>
	public unsafe partial class Actor : IEquatable<Actor> {
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

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
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
		/// Performs the specified action on each component if any
		/// </summary>
		public unsafe void ForEachComponent<T>(Action<T> action) where T : ActorComponent {
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			ObjectReference* array = null;
			int elements = 0;

			forEachComponent(Pointer, ref array, ref elements);

			for (int i = 0; i < elements; i++) {
				T component = array[i].ToComponent<T>();

				if (component != null)
					action(component);
			}
		}

		/// <summary>
		/// Performs the specified action on each attached actor if any
		/// </summary>
		public unsafe void ForEachAttachedActor<T>(Action<T> action) where T : Actor {
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			ObjectReference* array = null;
			int elements = 0;

			forEachAttachedActor(Pointer, ref array, ref elements);

			for (int i = 0; i < elements; i++) {
				T actor = array[i].ToActor<T>();

				if (actor != null)
					action(actor);
			}
		}

		/// <summary>
		/// Performs the specified action on each child actor with <see cref="ChildActorComponent"/>, including children of child if any
		/// </summary>
		public unsafe void ForEachChildActor<T>(Action<T> action) where T : Actor {
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			ObjectReference* array = null;
			int elements = 0;

			forEachChildActor(Pointer, ref array, ref elements);

			for (int i = 0; i < elements; i++) {
				T actor = array[i].ToActor<T>();

				if (actor != null)
					action(actor);
			}
		}

		/// <summary>
		/// Performs the specified action on each overlapping actor if any
		/// </summary>
		public unsafe void ForEachOverlappingActor<T>(Action<T> action) where T : Actor {
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			ObjectReference* array = null;
			int elements = 0;

			forEachOverlappingActor(Pointer, ref array, ref elements);

			for (int i = 0; i < elements; i++) {
				T actor = array[i].ToActor<T>();

				if (actor != null)
					action(actor);
			}
		}

		/// <summary>
		/// Returns the unique ID of the actor, reused by the engine, only unique while the actor is alive
		/// </summary>
		public uint ID => Object.getID(Pointer);

		/// <summary>
		/// Returns the name of the actor
		/// </summary>
		public string Name {
			get {
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				Object.getName(Pointer, stringBuffer);

				return stringBuffer.BytesToString();
			}
		}

		/// <summary>
		/// Retrieves the value of the bool property
		/// </summary>
		public bool GetBool(string name, ref bool value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getBool(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the byte property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetByte(string name, ref byte value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getByte(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetShort(string name, ref short value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getShort(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetInt(string name, ref int value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getInt(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetLong(string name, ref long value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getLong(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetUShort(string name, ref ushort value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getUShort(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetUInt(string name, ref uint value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getUInt(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetULong(string name, ref ulong value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getULong(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the float property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetFloat(string name, ref float value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getFloat(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the double property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetDouble(string name, ref double value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getDouble(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the enum property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetEnum<T>(string name, ref T value) where T : Enum {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			int data = 0;

			if (Object.getEnum(Pointer, name.StringToBytes(), ref data)) {
				value = (T)Enum.ToObject(typeof(T), data);

				return true;
			}

			return false;
		}

		/// <summary>
		/// Retrieves the value of the string property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetString(string name, ref string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			if (Object.getString(Pointer, name.StringToBytes(), stringBuffer)) {
				value = stringBuffer.BytesToString();

				return true;
			}

			return false;
		}

		/// <summary>
		/// Retrieves the value of the text property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetText(string name, ref string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			if (Object.getText(Pointer, name.StringToBytes(), stringBuffer)) {
				value = stringBuffer.BytesToString();

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

			return Object.setBool(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the byte property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetByte(string name, byte value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setByte(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetShort(string name, short value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setShort(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetInt(string name, int value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setInt(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetLong(string name, long value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setLong(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the unsigned short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetUShort(string name, ushort value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setUShort(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the unsigned integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetUInt(string name, uint value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setUInt(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the unsigned long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetULong(string name, ulong value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setULong(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the float property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetFloat(string name, float value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setFloat(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the double property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetDouble(string name, double value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setDouble(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the enum property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetEnum<T>(string name, T value) where T : Enum {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setEnum(Pointer, name.StringToBytes(), Convert.ToInt32(value));
		}

		/// <summary>
		/// Sets the value of the string property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetString(string name, string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (value == null)
				throw new ArgumentNullException(nameof(value));

			return Object.setString(Pointer, name.StringToBytes(), value.StringToBytes());
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

			return Object.setText(Pointer, name.StringToBytes(), value.StringToBytes());
		}

		/// <summary>
		/// Gets or sets the component that handles input for the actor, if enabled
		/// </summary>
		public InputComponent InputComponent {
			get {
				IntPtr pointer = getInputComponent(Pointer);

				if (pointer != IntPtr.Zero)
					return new(pointer);

				return null;
			}

			set {
				if (value == null)
					throw new ArgumentNullException(nameof(value));

				setInputComponent(Pointer, value.Pointer);
			}
		}

		/// <summary>
		/// Gets the time when the actor was created relative to <see cref="World.Time"/>
		/// </summary>
		public float CreationTime => getCreationTime(Pointer);

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

			rename(Pointer, name.StringToBytes());
		}

		/// <summary>
		/// Invokes a command, function, or an event with optional arguments
		/// </summary>
		public bool Invoke(string command) => Object.invoke(Pointer, command.StringToBytes());

		/// <summary>
		/// Hides the actor
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
		/// Returns the distance from this actor to another one, ignoring Z axis
		/// </summary>
		public float GetHorizontalDistanceTo(Actor actor) {
			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			return getHorizontalDistanceTo(Pointer, actor.Pointer);
		}

		/// <summary>
		/// Retrieves the bounding box of all components of the actor
		/// </summary>
		/// <param name="onlyCollidingComponents">If <c>true</c>, will only return the bounding box for components with enabled collision</param>
		/// <param name="origin">The center of the actor in world space</param>
		/// <param name="extent">Half the actor's size in 3D space</param>
		public void GetBounds(bool onlyCollidingComponents, ref Vector3 origin, ref Vector3 extent) => getBounds(Pointer, onlyCollidingComponents, ref origin, ref extent);

		/// <summary>
		/// Retrieves the point of view of the actor
		/// </summary>
		public void GetEyesViewPoint(ref Vector3 location, ref Quaternion rotation) => getEyesViewPoint(Pointer, ref location, ref rotation);

		/// <summary>
		/// Returns the component of the actor if matches the specified type, optionally with the specified name
		/// </summary>
		/// <param name="name">The name of the component</param>
		/// <typeparam name="T">The type of the component</typeparam>
		/// <returns>A component or <c>null</c> on failure</returns>
		public T GetComponent<T>(string name = null) where T : ActorComponent {
			T component = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = getComponent(Pointer, name.StringToBytes(), component.Type);

			if (pointer != IntPtr.Zero) {
				component.Pointer = pointer;

				return component;
			}

			return null;
		}

		/// <summary>
		/// Returns the component of the actor if matches the specified type and tag
		/// </summary>
		/// <param name="tag">The tag of the component</param>
		/// <typeparam name="T">The type of the component</typeparam>
		/// <returns>A component or <c>null</c> on failure</returns>
		public T GetComponentByTag<T>(string tag) where T : ActorComponent {
			T component = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = getComponentByTag(Pointer, tag.StringToBytes(), component.Type);

			if (pointer != IntPtr.Zero) {
				component.Pointer = pointer;

				return component;
			}

			return null;
		}

		/// <summary>
		/// Returns the component of the actor if matches the specified type and ID
		/// </summary>
		/// <param name="id">The ID of the component</param>
		/// <typeparam name="T">The type of the component</typeparam>
		/// <returns>A component or <c>null</c> on failure</returns>
		public T GetComponentByID<T>(uint id) where T : ActorComponent {
			T component = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = getComponentByID(Pointer, id, component.Type);

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
		/// Sets <see cref="InputComponent"/> for non-pawn actors handled by a <see cref="PlayerController"/>
		/// </summary>
		public void SetEnableInput(PlayerController playerController, bool value) {
			if (playerController == null)
				throw new ArgumentNullException(nameof(playerController));

			setEnableInput(Pointer, playerController.Pointer, value);
		}

		/// <summary>
		/// Sets the collision detection of the actor
		/// </summary>
		public void SetEnableCollision(bool value) => setEnableCollision(Pointer, value);

		/// <summary>
		/// Adds a tag to the actor that can be used for grouping and categorizing
		/// </summary>
		public void AddTag(string tag) => addTag(Pointer, tag.StringToBytes());

		/// <summary>
		/// Removes a tag from the actor
		/// </summary>
		public void RemoveTag(string tag) => removeTag(Pointer, tag.StringToBytes());

		/// <summary>
		/// Indicates whether the actor has a tag
		/// </summary>
		public bool HasTag(string tag) => hasTag(Pointer, tag.StringToBytes());

		/// <summary>
		/// Registers an event notification for the actor
		/// </summary>
		public void RegisterEvent(ActorEventType type) => registerEvent(Pointer, type);

		/// <summary>
		/// Unregisters an event notification for the actor
		/// </summary>
		public void UnregisterEvent(ActorEventType type) => unregisterEvent(Pointer, type);
	}

	/// <summary>
	/// A camera viewpoint that can be placed in a level
	/// </summary>
	public unsafe partial class Camera : Actor {
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

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// The base class of actors that used to generate collision events
	/// </summary>
	public abstract unsafe partial class TriggerBase : Actor {
		private protected TriggerBase() { }
	}

	/// <summary>
	/// A box shaped trigger with <see cref="BoxComponent"/> used to generate overlap events
	/// </summary>
	public unsafe partial class TriggerBox : TriggerBase {
		internal override ActorType Type => ActorType.TriggerBox;

		private protected TriggerBox() { }

		internal TriggerBox(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public TriggerBox(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// A sphere shaped trigger with <see cref="SphereComponent"/> used to generate overlap events
	/// </summary>
	public unsafe partial class TriggerSphere : TriggerBase {
		internal override ActorType Type => ActorType.TriggerSphere;

		private protected TriggerSphere() { }

		internal TriggerSphere(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public TriggerSphere(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// A capsule shaped trigger with <see cref="CapsuleComponent"/> used to generate overlap events
	/// </summary>
	public unsafe partial class TriggerCapsule : TriggerBase {
		internal override ActorType Type => ActorType.TriggerCapsule;

		private protected TriggerCapsule() { }

		internal TriggerCapsule(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public TriggerCapsule(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// Defines the game being played, instantiated only on the server
	/// </summary>
	public unsafe partial class GameModeBase : Actor {
		internal override ActorType Type => ActorType.GameModeBase;

		private protected GameModeBase() { }

		internal GameModeBase(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Gets or sets whether the game perform seamless map travels which loads in the background and doesn't disconnect clients
		/// </summary>
		public bool UseSeamlessTravel {
			get => getUseSeamlessTravel(Pointer);
			set => setUseSeamlessTravel(Pointer, value);
		}

		/// <summary>
		/// Swaps player controllers
		/// </summary>
		public void SwapPlayerControllers(PlayerController playerController, PlayerController newPlayerController) {
			if (playerController == null)
				throw new ArgumentNullException(nameof(playerController));

			if (newPlayerController == null)
				throw new ArgumentNullException(nameof(newPlayerController));

			swapPlayerControllers(Pointer, playerController.Pointer, newPlayerController.Pointer);
		}
	}

	/// <summary>
	/// The base class of actors that can be possessed by players or AI
	/// </summary>
	public unsafe partial class Pawn : Actor {
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

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns <c>true</c> if the pawn is possesed by a <see cref="Controller"/>
		/// </summary>
		public bool IsControlled => isControlled(Pointer);

		/// <summary>
		/// Returns <c>true</c> if the pawn is possesed by a <see cref="PlayerController"/>
		/// </summary>
		public bool IsPlayerControlled => isPlayerControlled(Pointer);

		/// <summary>
		/// Gets or sets the automatic possession type by an AI controller
		/// </summary>
		public AutoPossessAI AutoPossessAI {
			get => getAutoPossessAI(Pointer);
			set => setAutoPossessAI(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the player index for automatic possession by a player controller
		/// </summary>
		public AutoReceiveInput AutoPossessPlayer {
			get => getAutoPossessPlayer(Pointer);
			set => setAutoPossessPlayer(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether yaw will be updated to match the controller's control rotation yaw, if controlled by a <see cref="PlayerController"/>
		/// </summary>
		public bool UseControllerRotationYaw {
			get => getUseControllerRotationYaw(Pointer);
			set => setUseControllerRotationYaw(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether pitch will be updated to match the controller's control rotation pitch, if controlled by a <see cref="PlayerController"/>
		/// </summary>
		public bool UseControllerRotationPitch {
			get => getUseControllerRotationPitch(Pointer);
			set => setUseControllerRotationPitch(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether roll will be updated to match the controller's control rotation roll, if controlled by a <see cref="PlayerController"/>
		/// </summary>
		public bool UseControllerRotationRoll {
			get => getUseControllerRotationRoll(Pointer);
			set => setUseControllerRotationRoll(Pointer, value);
		}

		/// <summary>
		/// Retrieves vector direction of gravity
		/// </summary>
		public void GetGravityDirection(ref Vector3 value) => getGravityDirection(Pointer, ref value);

		/// <summary>
		/// Returns vector direction of gravity
		/// </summary>
		public Vector3 GetGravityDirection() {
			Vector3 value = default;

			getGravityDirection(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Returns the AI controller or <c>null</c> on failure
		/// </summary>
		public AIController GetAIController() {
			IntPtr pointer = getAIController(Pointer);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Returns the player controller or <c>null</c> on failure
		/// </summary>
		public PlayerController GetPlayerController() {
			IntPtr pointer = getPlayerController(Pointer);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
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
	}

	/// <summary>
	/// Represents a character that have a mesh, collision, and built-in movement logic
	/// </summary>
	public unsafe partial class Character : Pawn {
		internal override ActorType Type => ActorType.Character;

		private protected Character() { }

		internal Character(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public Character(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns <c>true</c> if the character is currently crouched
		/// </summary>
		public bool IsCrouched => isCrouched(Pointer);

		/// <summary>
		/// Returns <c>true</c> if the character can crouch
		/// </summary>
		public bool CanCrouch => canCrouch(Pointer);

		/// <summary>
		/// Returns <c>true</c> if the character can jump
		/// </summary>
		public bool CanJump => canJump(Pointer);

		/// <summary>
		/// Triggers jump if a jump button is pressed
		/// </summary>
		public void CheckJumpInput(float deltaTime) => checkJumpInput(Pointer, deltaTime);

		/// <summary>
		/// Updates jump input state after checking input
		/// </summary>
		public void ClearJumpInput(float deltaTime) => clearJumpInput(Pointer, deltaTime);

		/// <summary>
		/// Launches the character using the specified velocity
		/// </summary>
		public void Launch(in Vector3 velocity, bool overrideXY = false, bool overrideZ = false) => launch(Pointer, velocity, overrideXY, overrideZ);

		/// <summary>
		/// Starts the character crouching on the next update
		/// </summary>
		public void Crouch() => crouch(Pointer);

		/// <summary>
		/// Stops the character crouching on the next update
		/// </summary>
		public void StopCrouching() => stopCrouching(Pointer);

		/// <summary>
		/// Starts the character jumping on the next update
		/// </summary>
		public void Jump() => jump(Pointer);

		/// <summary>
		/// Stops the character from jumping on the next update
		/// </summary>
		public void StopJumping() => stopJumping(Pointer);

		/// <summary>
		/// Sets the callback function that is called when the character landing after falling
		/// </summary>
		public void SetOnLandedCallback(CharacterLandedDelegate callback) {
			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			setOnLandedCallback(Pointer, Collector.GetFunctionPointer(callback));
		}
	}

	/// <summary>
	/// Non-physical actors that can possess a <see cref="Pawn"/> to control its actions
	/// </summary>
	public abstract unsafe partial class Controller : Actor {
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
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Returns the character or <c>null</c> on failure
		/// </summary>
		public Character GetCharacter() {
			IntPtr pointer = getCharacter(Pointer);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Returns the actor the controller is looking at or <c>null</c> on failure
		/// </summary>
		public Actor GetViewTarget() {
			IntPtr pointer = getViewTarget(Pointer);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Retrieves the control rotation which is a full aim rotation
		/// </summary>
		public void GetControlRotation(ref Quaternion value) => getControlRotation(Pointer, ref value);

		/// <summary>
		/// Returns the control rotation which is a full aim rotation
		/// </summary>
		public Quaternion GetControlRotation() {
			Quaternion value = default;

			getControlRotation(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the target rotation of the pawn
		/// </summary>
		public void GetDesiredRotation(ref Quaternion value) => getDesiredRotation(Pointer, ref value);

		/// <summary>
		/// Returns the target rotation of the pawn
		/// </summary>
		public Quaternion GetDesiredRotation() {
			Quaternion value = default;

			getDesiredRotation(Pointer, ref value);

			return value;
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
		/// Sets the control rotation which is a full aim rotation
		/// </summary>
		public void SetControlRotation(in Quaternion value) => setControlRotation(Pointer, value);

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

		/// <summary>
		/// Handles attaching the controller to the specified pawn
		/// </summary>
		public void Possess(Pawn pawn) {
			if (pawn == null)
				throw new ArgumentNullException(nameof(pawn));

			possess(Pointer, pawn.Pointer);
		}

		/// <summary>
		/// Relinquishes control of the pawn
		/// </summary>
		public void Unpossess() => unpossess(Pointer);
	}

	/// <summary>
	/// The base class of controllers for an AI-controlled <see cref="Pawn"/>
	/// </summary>
	public unsafe partial class AIController : Controller {
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

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Gets or sets whether strafing allowed during movement
		/// </summary>
		public bool AllowStrafe {
			get => getAllowStrafe(Pointer);
			set => setAllowStrafe(Pointer, value);
		}

		/// <summary>
		/// Clears focus for the given priority, will clear focal point as a result
		/// </summary>
		public void ClearFocus(AIFocusPriority priority = AIFocusPriority.High) => clearFocus(Pointer, priority);

		/// <summary>
		/// Retrieves the final position that controller should be looking at
		/// </summary>
		public void GetFocalPoint(ref Vector3 value) => getFocalPoint(Pointer, ref value);

		/// <summary>
		/// Returns the final position that controller should be looking at
		/// </summary>
		public Vector3 GetFocalPoint() {
			Vector3 value = default;

			getFocalPoint(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Sets focal point for the given priority as absolute position or offset from base
		/// </summary>
		public void SetFocalPoint(in Vector3 newFocus, AIFocusPriority priority) => setFocalPoint(Pointer, newFocus, priority);

		/// <summary>
		/// Returns the focused actor or <c>null</c> on failure
		/// </summary>
		public Actor GetFocusActor() {
			IntPtr pointer = getFocusActor(Pointer);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Sets focus actor for the given priority, will set focal point as a result
		/// </summary>
		public void SetFocus(Actor newFocus, AIFocusPriority priority = AIFocusPriority.High) {
			if (newFocus == null)
				throw new ArgumentNullException(nameof(newFocus));

			setFocus(Pointer, newFocus.Pointer, priority);
		}
	}

	/// <summary>
	/// An actor that is used by human players to control a <see cref="Pawn"/>
	/// </summary>
	public unsafe partial class PlayerController : Controller {
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

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
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
		/// Gets or sets whether click events should be generated
		/// </summary>
		public bool EnableClickEvents {
			get => getEnableClickEvents(Pointer);
			set => setEnableClickEvents(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the mouse over events should be generated
		/// </summary>
		public bool EnableMouseOverEvents {
			get => getEnableMouseOverEvents(Pointer);
			set => setEnableMouseOverEvents(Pointer, value);
		}

		/// <summary>
		/// Retrieves the X and Y screen coordinates of the mouse cursor
		/// </summary>
		/// <returns><c>true</c> if successful</returns>
		public bool GetMousePosition(ref float x, ref float y) => getMousePosition(Pointer, ref x, ref y);

		/// <summary>
		/// Returns the player representation or <c>null</c> on failure
		/// </summary>
		public Player GetPlayer() {
			IntPtr pointer = getPlayer(Pointer);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Returns the input manager or <c>null</c> on failure
		/// </summary>
		public PlayerInput GetPlayerInput() {
			IntPtr pointer = getPlayerInput(Pointer);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Retrieves the first blocking hit from the position on the screen
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetHitResultAtScreenPosition(in Vector2 screenPosition, CollisionChannel traceChannel, ref Hit hit, bool traceComplex = false) => getHitResultAtScreenPosition(Pointer, screenPosition, traceChannel, ref hit, traceComplex);

		/// <summary>
		/// Retrieves the first blocking hit under the mouse cursor
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetHitResultUnderCursor(CollisionChannel traceChannel, ref Hit hit, bool traceComplex = false) => getHitResultUnderCursor(Pointer, traceChannel, ref hit, traceComplex);

		/// <summary>
		/// Positions the mouse cursor in screen space, in pixels
		/// </summary>
		public void SetMousePosition(float x, float y) => setMousePosition(Pointer, x, y);

		/// <summary>
		/// Executes the command on the <see cref="Player"/> object, <c>DumpConsoleCommands</c> command can be used to list all available variables and commands
		/// </summary>
		/// <param name="command">A command to execute, string of commands optionally separated by a <c>|</c> symbol</param>
		/// <param name="writeToLog"></param>
		public void ConsoleCommand(string command, bool writeToLog = false) => consoleCommand(Pointer, command.StringToBytes(), writeToLog);

		/// <summary>
		/// Pauses a local game
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
	public unsafe partial class Brush : Actor {
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

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// An editable 3D volume placed in a level, different types of volumes perform different functions
	/// </summary>
	public abstract unsafe partial class Volume : Brush {
		private protected Volume() { }

		/// <summary>
		/// Returns <c>true</c> if a point or sphere overlaps the volume
		/// </summary>
		public bool EncompassesPoint(in Vector3 point, float sphereRadius, ref float distanceToPoint) => encompassesPoint(Pointer, point, sphereRadius, ref distanceToPoint);
	}

	/// <summary>
	/// An actor that is used to trigger events
	/// </summary>
	public unsafe partial class TriggerVolume : Volume {
		internal override ActorType Type => ActorType.TriggerVolume;

		private protected TriggerVolume() { }

		internal TriggerVolume(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public TriggerVolume(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// An actor that is used for post-processing manipulations
	/// </summary>
	public unsafe partial class PostProcessVolume : Volume {
		internal override ActorType Type => ActorType.PostProcessVolume;

		private protected PostProcessVolume() { }

		internal PostProcessVolume(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public PostProcessVolume(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Gets or sets whether the volume is enabled
		/// </summary>
		public bool Enabled {
			get => getEnabled(Pointer);
			set => setEnabled(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the world space radius around the volume that is used for blending if not unbound
		/// </summary>
		public float BlendRadius {
			get => getBlendRadius(Pointer);
			set => setBlendRadius(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the blend weight, 0.0f indicates no effect, 1.0f indicates full effect
		/// </summary>
		public float BlendWeight {
			get => getBlendWeight(Pointer);
			set => setBlendWeight(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the volume covers the whole world or only the area inside its bounds
		/// </summary>
		public bool Unbound {
			get => getUnbound(Pointer);
			set => setUnbound(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the priority of the volume
		/// </summary>
		public float Priority {
			get => getPriority(Pointer);
			set => setPriority(Pointer, value);
		}
	}

	/// <summary>
	/// A representation of the level-wide logic defined in the level blueprint
	/// </summary>
	public unsafe partial class LevelScript : Actor {
		internal override ActorType Type => ActorType.LevelScript;

		private protected LevelScript() { }

		internal LevelScript(IntPtr pointer) => Pointer = pointer;
	}

	/// <summary>
	/// A sound actor that can be placed in a level
	/// </summary>
	public unsafe partial class AmbientSound : Actor {
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

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// A light actor that can be placed in a level
	/// </summary>
	public abstract unsafe partial class Light : Actor {
		private protected Light() { }
	}

	/// <summary>
	/// Simulates light that is being emitted from a source that is infinitely far away
	/// </summary>
	public unsafe partial class DirectionalLight : Light {
		internal override ActorType Type => ActorType.DirectionalLight;

		private protected DirectionalLight() { }

		internal DirectionalLight(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public DirectionalLight(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// Emits light in all directions from the light bulb's tungsten filament
	/// </summary>
	public unsafe partial class PointLight : Light {
		internal override ActorType Type => ActorType.PointLight;

		private protected PointLight() { }

		internal PointLight(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public PointLight(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// Emits light into the scene from a rectangular plane with a defined width and height
	/// </summary>
	public unsafe partial class RectLight : Light {
		internal override ActorType Type => ActorType.RectLight;

		private protected RectLight() { }

		internal RectLight(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public RectLight(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// Emits light from a single point in a cone shape
	/// </summary>
	public unsafe partial class SpotLight : Light {
		internal override ActorType Type => ActorType.SpotLight;

		private protected SpotLight() { }

		internal SpotLight(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Spawns the actor in the world
		/// </summary>
		/// <param name="name">The name of the actor</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the actor</param>
		public SpotLight(string name = null, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = spawn(name.StringToBytes(), Type, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// The base class of playable sound objects
	/// </summary>
	public abstract unsafe partial class SoundBase : IEquatable<SoundBase> {
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
	public unsafe partial class SoundWave : SoundBase {
		private protected SoundWave() { }

		internal SoundWave(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Finds and loads a sound wave by name
		/// </summary>
		/// <returns>A sound wave or <c>null</c> on failure</returns>
		public static SoundWave Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.SoundWave, name.StringToBytes());

			if (pointer != IntPtr.Zero)
				return new(pointer);

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
	public abstract unsafe partial class AnimationAsset : IEquatable<AnimationAsset> {
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
	public abstract unsafe partial class AnimationSequenceBase : AnimationAsset {
		private protected AnimationSequenceBase() { }
	}

	/// <summary>
	/// A single animation asset that can be played
	/// </summary>
	public unsafe partial class AnimationSequence : AnimationSequenceBase {
		private protected AnimationSequence() { }

		internal AnimationSequence(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Finds and loads an animation sequence by name
		/// </summary>
		/// <returns>An animation sequence or <c>null</c> on failure</returns>
		public static AnimationSequence Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.AnimationSequence, name.StringToBytes());

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}
	}

	/// <summary>
	/// The base class of animation composites
	/// </summary>
	public abstract unsafe partial class AnimationCompositeBase : AnimationSequenceBase {
		private protected AnimationCompositeBase() { }
	}

	/// <summary>
	/// A single animation asset that can combine and selectively play animations
	/// </summary>
	public unsafe partial class AnimationMontage : AnimationCompositeBase {
		private protected AnimationMontage() { }

		internal AnimationMontage(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Finds and loads an animation montage by name
		/// </summary>
		/// <returns>An animation montage or <c>null</c> on failure</returns>
		public static AnimationMontage Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.AnimationMontage, name.StringToBytes());

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}
	}

	/// <summary>
	/// An animation instance representation
	/// </summary>
	public unsafe partial class AnimationInstance : IEquatable<AnimationInstance> {
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
		/// Retrieves the value of the bool property
		/// </summary>
		public bool GetBool(string name, ref bool value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getBool(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the byte property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetByte(string name, ref byte value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getByte(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetShort(string name, ref short value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getShort(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetInt(string name, ref int value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getInt(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetLong(string name, ref long value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getLong(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetUShort(string name, ref ushort value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getUShort(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetUInt(string name, ref uint value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getUInt(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetULong(string name, ref ulong value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getULong(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the float property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetFloat(string name, ref float value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getFloat(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the double property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetDouble(string name, ref double value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getDouble(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the enum property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetEnum<T>(string name, ref T value) where T : Enum {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			int data = 0;

			if (Object.getEnum(Pointer, name.StringToBytes(), ref data)) {
				value = (T)Enum.ToObject(typeof(T), data);

				return true;
			}

			return false;
		}

		/// <summary>
		/// Retrieves the value of the string property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetString(string name, ref string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			if (Object.getString(Pointer, name.StringToBytes(), stringBuffer)) {
				value = stringBuffer.BytesToString();

				return true;
			}

			return false;
		}

		/// <summary>
		/// Retrieves the value of the text property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetText(string name, ref string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			if (Object.getText(Pointer, name.StringToBytes(), stringBuffer)) {
				value = stringBuffer.BytesToString();

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

			return Object.setBool(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the byte property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetByte(string name, byte value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setByte(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetShort(string name, short value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setShort(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetInt(string name, int value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setInt(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetLong(string name, long value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setLong(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the unsigned short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetUShort(string name, ushort value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setUShort(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the unsigned integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetUInt(string name, uint value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setUInt(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the unsigned long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetULong(string name, ulong value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setULong(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the float property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetFloat(string name, float value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setFloat(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the double property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetDouble(string name, double value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setDouble(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the enum property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetEnum<T>(string name, T value) where T : Enum {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setEnum(Pointer, name.StringToBytes(), Convert.ToInt32(value));
		}

		/// <summary>
		/// Sets the value of the string property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetString(string name, string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (value == null)
				throw new ArgumentNullException(nameof(value));

			return Object.setString(Pointer, name.StringToBytes(), value.StringToBytes());
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

			return Object.setText(Pointer, name.StringToBytes(), value.StringToBytes());
		}

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(AnimationInstance other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Invokes a command, function, or an event with optional arguments
		/// </summary>
		public bool Invoke(string command) => Object.invoke(Pointer, command.StringToBytes());

		/// <summary>
		/// Returns the current active animation montage or <c>null</c> on failure
		/// </summary>
		public AnimationMontage GetCurrentActiveMontage() {
			IntPtr pointer = getCurrentActiveMontage(Pointer);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Returns <c>true</c> if the animation montage is active and playing
		/// </summary>
		public bool IsPlaying(AnimationMontage montage) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			return isPlaying(Pointer, montage.Pointer);
		}

		/// <summary>
		/// Returns the current play rate of the animation montage
		/// </summary>
		public float GetPlayRate(AnimationMontage montage) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			return getPlayRate(Pointer, montage.Pointer);
		}

		/// <summary>
		/// Returns the current position of the animation montage
		/// </summary>
		public float GetPosition(AnimationMontage montage) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			return getPosition(Pointer, montage.Pointer);
		}

		/// <summary>
		/// Returns the current blend time of the animation montage
		/// </summary>
		public float GetBlendTime(AnimationMontage montage) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			return getBlendTime(Pointer, montage.Pointer);
		}

		/// <summary>
		/// Returns the name of the current animation montage section
		/// </summary>
		public string GetCurrentSection(AnimationMontage montage) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			getCurrentSection(Pointer, montage.Pointer, stringBuffer);

			return stringBuffer.BytesToString();
		}

		/// <summary>
		/// Sets the current play rate of the animation montage
		/// </summary>
		public void SetPlayRate(AnimationMontage montage, float value) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			setPlayRate(Pointer, montage.Pointer, value);
		}

		/// <summary>
		/// Sets the current position of the animation montage
		/// </summary>
		public void SetPosition(AnimationMontage montage, float position) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			setPosition(Pointer, montage.Pointer, position);
		}

		/// <summary>
		/// Sets the next section after <paramref name="sectionToChange"/>
		/// </summary>
		public void SetNextSection(AnimationMontage montage, string sectionToChange, string nextSection) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			setNextSection(Pointer, montage.Pointer, sectionToChange.StringToBytes(), nextSection.StringToBytes());
		}

		/// <summary>
		/// Plays the animation montage
		/// </summary>
		/// <returns>The length of the animation montage in seconds, or 0.0f if failed to play</returns>
		public float PlayMontage(AnimationMontage montage, float playRate = 1.0f, float timeToStartMontageAt = 0.0f, bool stopAllMontages = true) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			return playMontage(Pointer, montage.Pointer, playRate, timeToStartMontageAt, stopAllMontages);
		}

		/// <summary>
		/// Pauses the animation montage
		/// </summary>
		public void PauseMontage(AnimationMontage montage) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			pauseMontage(Pointer, montage.Pointer);
		}

		/// <summary>
		/// Resumes the paused animation montage
		/// </summary>
		public void ResumeMontage(AnimationMontage montage) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			resumeMontage(Pointer, montage.Pointer);
		}

		/// <summary>
		/// Stops the animation montage, if <paramref name="montage"/> is <c>null</c> stops all active montages
		/// </summary>
		public void StopMontage(AnimationMontage montage, float blendOutTime) => stopMontage(Pointer, montage != null ? montage.Pointer : IntPtr.Zero, blendOutTime);

		/// <summary>
		/// Makes the animation montage jump to a named section
		/// </summary>
		public void JumpToSection(AnimationMontage montage, string sectionName) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			if (sectionName == null)
				throw new ArgumentNullException(nameof(sectionName));

			jumpToSection(Pointer, montage.Pointer, sectionName.StringToBytes());
		}

		/// <summary>
		/// Makes the animation montage jump to the end of a named section
		/// </summary>
		public void JumpToSectionsEnd(AnimationMontage montage, string sectionName) {
			if (montage == null)
				throw new ArgumentNullException(nameof(montage));

			if (sectionName == null)
				throw new ArgumentNullException(nameof(sectionName));

			jumpToSectionsEnd(Pointer, montage.Pointer, sectionName.StringToBytes());
		}
	}

	/// <summary>
	/// A player representation
	/// </summary>
	public unsafe partial class Player : IEquatable<Player> {
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

		/// <summary>
		/// Returns the player controller or <c>null</c> on failure
		/// </summary>
		public PlayerController GetPlayerController() {
			IntPtr pointer = getPlayerController(Pointer);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}
	}

	/// <summary>
	/// An input manager of <see cref="PlayerController"/>
	/// </summary>
	public unsafe partial class PlayerInput : IEquatable<PlayerInput> {
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

			return isKeyPressed(Pointer, key.StringToBytes());
		}

		/// <summary>
		/// Returns the time a key was pressed
		/// </summary>
		public float GetTimeKeyPressed(string key) {
			if (key == null)
				throw new ArgumentNullException(nameof(key));

			return getTimeKeyPressed(Pointer, key.StringToBytes());
		}

		/// <summary>
		/// Retrieves mouse sensitivity
		/// </summary>
		public void GetMouseSensitivity(ref Vector2 value) => getMouseSensitivity(Pointer, ref value);

		/// <summary>
		/// Returns mouse sensitivity
		/// </summary>
		public Vector2 GetMouseSensitivity() {
			Vector2 value = default;

			getMouseSensitivity(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Sets mouse sensitivity
		/// </summary>
		public void SetMouseSensitivity(in Vector2 value) => setMouseSensitivity(Pointer, value);

		/// <summary>
		/// Adds a player-specific action mapping
		/// </summary>
		/// <param name="actionName">Friendly name of action</param>
		/// <param name="key">Key to bind in accordance with <see cref="Keys"/></param>
		/// <param name="shift"><c>true</c> if one of the Shift keys must be down when the KeyEvent is received to be acknowledged</param>
		/// <param name="ctrl"><c>true</c> if one of the Ctrl keys must be down when the KeyEvent is received to be acknowledged</param>
		/// <param name="alt"><c>true</c> if one of the Alt keys must be down when the KeyEvent is received to be acknowledged</param>
		/// <param name="cmd"><c>true</c> if one of the Cmd keys must be down when the KeyEvent is received to be acknowledged</param>
		public void AddActionMapping(string actionName, string key, bool shift = false, bool ctrl = false, bool alt = false, bool cmd = false) {
			if (actionName == null)
				throw new ArgumentNullException(nameof(actionName));

			if (key == null)
				throw new ArgumentNullException(nameof(key));

			addActionMapping(Pointer, actionName.StringToBytes(), key.StringToBytes(), shift, ctrl, alt, cmd);
		}

		/// <summary>
		/// Adds a player-specific mapping between an axis and key
		/// </summary>
		/// <param name="axisName">Friendly name of axis</param>
		/// <param name="key">Key to bind in accordance with <see cref="Keys"/></param>
		/// <param name="scale">Multiplier to use for the mapping when accumulating the axis value</param>
		public void AddAxisMapping(string axisName, string key, float scale = 1.0f) {
			if (axisName == null)
				throw new ArgumentNullException(nameof(axisName));

			if (key == null)
				throw new ArgumentNullException(nameof(key));

			addAxisMapping(Pointer, axisName.StringToBytes(), key.StringToBytes(), scale);
		}

		/// <summary>
		/// Removes a player-specific action mapping
		/// </summary>
		public void RemoveActionMapping(string actionName, string key) => removeActionMapping(Pointer, actionName.StringToBytes(), key.StringToBytes());

		/// <summary>
		/// Removes a player-specific mapping between an axis and key
		/// </summary>
		public void RemoveAxisMapping(string axisName, string key) => removeAxisMapping(Pointer, axisName.StringToBytes(), key.StringToBytes());
	}

	/// <summary>
	/// An asset that provides an intuitive node-based interface
	/// </summary>
	public unsafe partial class Blueprint : IEquatable<Blueprint> {
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

			IntPtr pointer = Object.load(ObjectType.Blueprint, name.StringToBytes());

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}
	}

	/// <summary>
	/// A font object that is used to draw text
	/// </summary>
	public unsafe partial class Font : IEquatable<Font> {
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

		private protected Font() { }

		internal Font(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Returns <c>true</c> if the object is created
		/// </summary>
		public bool IsCreated => pointer != IntPtr.Zero && Object.isValid(pointer);

		/// <summary>
		/// Indicates equality of objects
		/// </summary>
		public bool Equals(Font other) => IsCreated && pointer == other?.pointer;

		/// <summary>
		/// Returns a hash code for the object
		/// </summary>
		public override int GetHashCode() => pointer.GetHashCode();

		/// <summary>
		/// Finds and loads a font by name
		/// </summary>
		/// <returns>A font or <c>null</c> on failure</returns>
		public static Font Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.Font, name.StringToBytes());

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Retrieves height and width for a string
		/// </summary>
		public void GetStringSize(string text, ref int height, ref int width) => getStringSize(Pointer, text.StringToBytes(), ref height, ref width);
	}

	/// <summary>
	/// A render asset that can be streamed at runtime
	/// </summary>
	public abstract unsafe partial class StreamableRenderAsset : IEquatable<StreamableRenderAsset> {
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
	public unsafe partial class StaticMesh : StreamableRenderAsset {
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

			IntPtr pointer = Object.load(ObjectType.StaticMesh, name.StringToBytes());

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}
	}

	/// <summary>
	/// A geometry bound to a hierarchical skeleton of bones which can be animated
	/// </summary>
	public unsafe partial class SkeletalMesh : StreamableRenderAsset {
		private protected SkeletalMesh() { }

		internal SkeletalMesh(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Finds and loads a skeletal mesh by name
		/// </summary>
		/// <returns>A skeletal mesh or <c>null</c> on failure</returns>
		public static SkeletalMesh Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.SkeletalMesh, name.StringToBytes());

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}
	}

	/// <summary>
	/// A representation of the surface of an object
	/// </summary>
	public abstract unsafe partial class Texture : StreamableRenderAsset {
		private protected Texture() { }
	}

	/// <summary>
	/// A texture asset
	/// </summary>
	public unsafe partial class Texture2D : Texture {
		private protected Texture2D() { }

		internal Texture2D(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates a texture asset from a raw PNG, JPEG, BMP, or EXR image file
		/// </summary>
		public Texture2D(string filePath) {
			if (filePath == null)
				throw new ArgumentNullException(nameof(filePath));

			Pointer = createFromFile(filePath.StringToBytes());
		}

		/// <summary>
		/// Creates a texture asset from a raw PNG, JPEG, BMP, or EXR image buffer
		/// </summary>
		public Texture2D(byte[] buffer, int length) {
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer));

			Pointer = createFromBuffer(buffer, length);
		}

		/// <summary>
		/// Finds and loads a texture by name
		/// </summary>
		/// <returns>A texture or <c>null</c> on failure</returns>
		public static Texture2D Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.Texture2D, name.StringToBytes());

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Returns <c>true</c> if the runtime texture has an alpha channel that is not completely white
		/// </summary>
		public bool HasAlphaChannel => hasAlphaChannel(Pointer);

		/// <summary>
		/// Retrieves size of the texture
		/// </summary>
		public void GetSize(ref Vector2 value) => getSize(Pointer, ref value);

		/// <summary>
		/// Returns size of the texture
		/// </summary>
		public Vector2 GetSize() {
			Vector2 value = default;

			getSize(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Returns the pixel format
		/// </summary>
		public PixelFormat GetPixelFormat() => getPixelFormat(Pointer);
	}

	/// <summary>
	/// The base class of components that define reusable behavior and can be added to different types of actors
	/// </summary>
	public abstract unsafe partial class ActorComponent : IEquatable<ActorComponent> {
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
		/// Returns the unique ID of the component, reused by the engine, only unique while the component is alive
		/// </summary>
		public uint ID => Object.getID(Pointer);

		/// <summary>
		/// Returns the name of the component
		/// </summary>
		public string Name {
			get {
				byte[] stringBuffer = ArrayPool.GetStringBuffer();

				Object.getName(Pointer, stringBuffer);

				return stringBuffer.BytesToString();
			}
		}

		/// <summary>
		/// Retrieves the value of the bool property
		/// </summary>
		public bool GetBool(string name, ref bool value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getBool(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the byte property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetByte(string name, ref byte value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getByte(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetShort(string name, ref short value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getShort(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetInt(string name, ref int value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getInt(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetLong(string name, ref long value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getLong(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetUShort(string name, ref ushort value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getUShort(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetUInt(string name, ref uint value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getUInt(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the unsigned long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetULong(string name, ref ulong value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getULong(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the float property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetFloat(string name, ref float value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getFloat(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the double property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetDouble(string name, ref double value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.getDouble(Pointer, name.StringToBytes(), ref value);
		}

		/// <summary>
		/// Retrieves the value of the enum property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetEnum<T>(string name, ref T value) where T : Enum {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			int data = 0;

			if (Object.getEnum(Pointer, name.StringToBytes(), ref data)) {
				value = (T)Enum.ToObject(typeof(T), data);

				return true;
			}

			return false;
		}

		/// <summary>
		/// Retrieves the value of the string property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetString(string name, ref string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			if (Object.getString(Pointer, name.StringToBytes(), stringBuffer)) {
				value = stringBuffer.BytesToString();

				return true;
			}

			return false;
		}

		/// <summary>
		/// Retrieves the value of the text property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool GetText(string name, ref string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			if (Object.getText(Pointer, name.StringToBytes(), stringBuffer)) {
				value = stringBuffer.BytesToString();

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

			return Object.setBool(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the byte property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetByte(string name, byte value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setByte(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetShort(string name, short value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setShort(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetInt(string name, int value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setInt(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetLong(string name, long value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setLong(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the unsigned short property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetUShort(string name, ushort value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setUShort(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the unsigned integer property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetUInt(string name, uint value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setUInt(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the unsigned long property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetULong(string name, ulong value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setULong(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the float property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetFloat(string name, float value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setFloat(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the double property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetDouble(string name, double value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setDouble(Pointer, name.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the value of the enum property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetEnum<T>(string name, T value) where T : Enum {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			return Object.setEnum(Pointer, name.StringToBytes(), Convert.ToInt32(value));
		}

		/// <summary>
		/// Sets the value of the string property
		/// </summary>
		/// <returns><c>true</c> on success</returns>
		public bool SetString(string name, string value) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (value == null)
				throw new ArgumentNullException(nameof(value));

			return Object.setString(Pointer, name.StringToBytes(), value.StringToBytes());
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

			return Object.setText(Pointer, name.StringToBytes(), value.StringToBytes());
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

			Object.rename(Pointer, name.StringToBytes());
		}

		/// <summary>
		/// Invokes a command, function, or an event with optional arguments
		/// </summary>
		public bool Invoke(string command) => Object.invoke(Pointer, command.StringToBytes());

		/// <summary>
		/// Unregisters the component, removes it from its outer actor's components array and marks for pending kill
		/// </summary>
		/// <param name="promoteChild">Promotes the child component in the hierarchy during the destruction</param>
		public void Destroy(bool promoteChild = false) => destroy(Pointer, promoteChild);

		/// <summary>
		/// Returns <c>true</c> if the component's owner is selected in the editor
		/// </summary>
		/// <remarks>Editor functionality</remarks>
		public bool IsOwnerSelected => isOwnerSelected(Pointer);

		/// <summary>
		/// Returns the component's owner actor of the specified class
		/// </summary>
		/// <returns>An actor or <c>null</c> on failure</returns>
		public T GetActor<T>() where T : Actor {
			T actor = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = getOwner(Pointer, actor.Type);

			if (pointer != IntPtr.Zero) {
				actor.Pointer = pointer;

				return actor;
			}

			return null;
		}

		/// <summary>
		/// Adds a tag to the component that can be used for grouping and categorizing
		/// </summary>
		public void AddTag(string tag) => addTag(Pointer, tag.StringToBytes());

		/// <summary>
		/// Removes a tag from the component
		/// </summary>
		public void RemoveTag(string tag) => removeTag(Pointer, tag.StringToBytes());

		/// <summary>
		/// Indicates whether the component has a tag
		/// </summary>
		public bool HasTag(string tag) => hasTag(Pointer, tag.StringToBytes());
	}

	/// <summary>
	/// An input component is a transient component that enables an actor to bind various forms of input events to delegate functions
	/// </summary>
	public unsafe partial class InputComponent : ActorComponent {
		internal override ComponentType Type => ComponentType.Input;

		private protected InputComponent() { }

		internal InputComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Indicates whether the component has any input bindings
		/// </summary>
		public bool HasBindings => hasBindings(Pointer);

		/// <summary>
		/// Returns the number of action bindings
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
		/// Binds the callback function to an action defined in the project settings, or by using <see cref="Engine.AddActionMapping"/> and <see cref="PlayerInput.AddActionMapping"/>
		/// </summary>
		/// <param name="actionName">The name of the action</param>
		/// <param name="keyEvent">The type of input behavior</param>
		/// <param name="callback">The function to call when the input is triggered</param>
		/// <param name="executedWhenPaused">If <c>true</c>, executes even if the game is paused</param>
		public void BindAction(string actionName, InputEvent keyEvent, InputDelegate callback, bool executedWhenPaused = false) {
			if (actionName == null)
				throw new ArgumentNullException(nameof(actionName));

			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			bindAction(Pointer, actionName.StringToBytes(), keyEvent, executedWhenPaused, Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Binds the callback function to an axis defined in the project settings, or by using <see cref="Engine.AddAxisMapping"/> and <see cref="PlayerInput.AddAxisMapping"/>
		/// </summary>
		/// <param name="axisName">The name of the axis</param>
		/// <param name="callback">The function to call while tracking axis</param>
		/// <param name="executedWhenPaused">If <c>true</c>, executes even if the game is paused</param>
		public void BindAxis(string axisName, InputAxisDelegate callback, bool executedWhenPaused = false) {
			if (axisName == null)
				throw new ArgumentNullException(nameof(axisName));

			if (callback == null)
				throw new ArgumentNullException(nameof(callback));

			bindAxis(Pointer, axisName.StringToBytes(), executedWhenPaused, Collector.GetFunctionPointer(callback));
		}

		/// <summary>
		/// Removes the action binding
		/// </summary>
		public void RemoveActionBinding(string actionName, InputEvent keyEvent) => removeActionBinding(Pointer, actionName.StringToBytes(), keyEvent);
	}

	/// <summary>
	/// An abstract component that defines functionality for moving a <see cref="PrimitiveComponent"/>
	/// </summary>
	public abstract unsafe partial class MovementComponent : ActorComponent {
		internal override ComponentType Type => ComponentType.Movement;

		private protected MovementComponent() { }

		internal MovementComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Gets or sets whether the movement will be constrained to a plane
		/// </summary>
		public bool ConstrainToPlane {
			get => getConstrainToPlane(Pointer);
			set => setConstrainToPlane(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the updated component will be snapped to the plane when first is attached, if plane constraints are enabled
		/// </summary>
		public bool SnapToPlaneAtStart {
			get => getSnapToPlaneAtStart(Pointer);
			set => setSnapToPlaneAtStart(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether should be skipped if the updated component was not recently rendered
		/// </summary>
		public bool UpdateOnlyIfRendered {
			get => getUpdateOnlyIfRendered(Pointer);
			set => setUpdateOnlyIfRendered(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the plane constraint axis
		/// </summary>
		public PlaneConstraintAxis PlaneConstraint {
			get => getPlaneConstraint(Pointer);
			set => setPlaneConstraint(Pointer, value);
		}

		/// <summary>
		/// Returns <c>true</c> if it's in physics volume with water flag
		/// </summary>
		public bool IsInWater => isInWater(Pointer);

		/// <summary>
		/// Retrieves the current velocity of updated component
		/// </summary>
		public void GetVelocity(ref Vector3 value) => getVelocity(Pointer, ref value);

		/// <summary>
		/// Returns the current velocity of updated component
		/// </summary>
		public Vector3 GetVelocity() {
			Vector3 value = default;

			getVelocity(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the normal of the plane that constrains movement, enforced if the plane constraint is enabled
		/// </summary>
		public void GetPlaneConstraintNormal(ref Vector3 value) => getPlaneConstraintNormal(Pointer, ref value);

		/// <summary>
		/// Returns the normal of the plane that constrains movement, enforced if the plane constraint is enabled
		/// </summary>
		public Vector3 GetPlaneConstraintNormal() {
			Vector3 value = default;

			getPlaneConstraintNormal(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the plane constraint origin
		/// </summary>
		public void GetPlaneConstraintOrigin(ref Vector3 value) => getPlaneConstraintOrigin(Pointer, ref value);

		/// <summary>
		/// Returns the plane constraint origin
		/// </summary>
		public Vector3 GetPlaneConstraintOrigin() {
			Vector3 value = default;

			getPlaneConstraintOrigin(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Returns gravity that affects the component
		/// </summary>
		public float GetGravity() => getGravity(Pointer);

		/// <summary>
		/// Returns maximum speed of the component in current movement mode
		/// </summary>
		public float GetMaxSpeed() => getMaxSpeed(Pointer);

		/// <summary>
		/// Sets the current velocity of updated component
		/// </summary>
		public void SetVelocity(in Vector3 value) => setVelocity(Pointer, value);

		/// <summary>
		/// Sets the normal of the plane that constrains movement, enforced if the plane constraint is enabled
		/// </summary>
		public void SetPlaneConstraintNormal(in Vector3 value) => setPlaneConstraintNormal(Pointer, value);

		/// <summary>
		/// Sets the origin of the plane that constrains movement, enforced if the plane constraint is enabled
		/// </summary>
		public void SetPlaneConstraintOrigin(in Vector3 value) => setPlaneConstraintOrigin(Pointer, value);

		/// <summary>
		/// Sets the plane that constrains movement computed from the forward and up vectors, enforced if the plane constraint is enabled
		/// </summary>
		public void SetPlaneConstraintFromVectors(in Vector3 forward, in Vector3 up) => setPlaneConstraintFromVectors(Pointer, forward, up);

		/// <summary>
		/// Returns <c>true</c> if the current velocity is exceeding the given max speed within a small error tolerance
		/// </summary>
		public bool IsExceedingMaxSpeed(float maxSpeed) => isExceedingMaxSpeed(Pointer, maxSpeed);

		/// <summary>
		/// Stops movement immediately, zeroes velocity, usually zeros acceleration for components with acceleration
		/// </summary>
		public void StopMovement() => stopMovement(Pointer);

		/// <summary>
		/// Constrains a direction vector to the plane constraint, if enabled
		/// </summary>
		public void ConstrainDirectionToPlane(in Vector3 direction, ref Vector3 value) => constrainDirectionToPlane(Pointer, direction, ref value);

		/// <summary>
		/// Constrains a location vector to the plane constraint, if enabled
		/// </summary>
		public void ConstrainLocationToPlane(in Vector3 location, ref Vector3 value) => constrainLocationToPlane(Pointer, location, ref value);

		/// <summary>
		/// Constrains a normal vector (of unit length) to the plane constraint, if enabled
		/// </summary>
		public void ConstrainNormalToPlane(in Vector3 normal, ref Vector3 value) => constrainNormalToPlane(Pointer, normal, ref value);
	}

	/// <summary>
	/// A component that performs continuous rotation at a specific rotation rate
	/// </summary>
	public unsafe partial class RotatingMovementComponent : MovementComponent {
		internal override ComponentType Type => ComponentType.RotatingMovement;

		private protected RotatingMovementComponent() { }

		internal RotatingMovementComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		public RotatingMovementComponent(Actor actor, string name = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			Pointer = create(actor.Pointer, name.StringToBytes());
		}

		/// <summary>
		/// Gets or sets whether rotation is applied in local or world space
		/// </summary>
		public bool RotationInLocalSpace {
			get => getRotationInLocalSpace(Pointer);
			set => setRotationInLocalSpace(Pointer, value);
		}

		/// <summary>
		/// Retrieves translation of pivot point around which the component rotates, relative to the current rotation
		/// </summary>
		public void GetPivotTranslation(ref Vector3 value) => getPivotTranslation(Pointer, ref value);

		/// <summary>
		/// Returns translation of pivot point around which the component rotates, relative to the current rotation
		/// </summary>
		public Vector3 GetPivotTranslation() {
			Vector3 value = default;

			getPivotTranslation(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves yaw, pitch, and roll rotation rate of the component
		/// </summary>
		public void GetRotationRate(ref Quaternion value) => getRotationRate(Pointer, ref value);

		/// <summary>
		/// Returns yaw, pitch, and roll rotation rate of the component
		/// </summary>
		public Quaternion GetRotationRate() {
			Quaternion value = default;

			getRotationRate(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Sets translation of pivot point around which the component rotates, relative to the current rotation
		/// </summary>
		public void SetPivotTranslation(in Vector3 value) => setPivotTranslation(Pointer, value);

		/// <summary>
		/// Sets yaw, pitch, and roll rotation rate of the component
		/// </summary>
		public void SetRotationRate(in Quaternion value) => setRotationRate(Pointer, value);
	}

	/// <summary>
	/// The base class of components that can be transformed or attached, but has no rendering or collision capabilities
	/// </summary>
	public unsafe partial class SceneComponent : ActorComponent {
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

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
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
		/// Returns <c>true</c> if the component is visible in the current context
		/// </summary>
		public bool IsVisible => isVisible(Pointer);

		/// <summary>
		/// Returns <c>true</c> if the a socket with the given name exists
		/// </summary>
		public bool IsSocketExists(string socketName) {
			if (socketName == null)
				throw new ArgumentNullException(nameof(socketName));

			return isSocketExists(Pointer, socketName.StringToBytes());
		}

		/// <summary>
		/// Returns <c>true</c> if the component has any sockets
		/// </summary>
		public bool HasAnySockets => hasAnySockets(Pointer);

		/// <summary>
		/// Returns <c>true</c> if another scene component can be attached as a child
		/// </summary>
		public bool CanAttachAsChild(SceneComponent childComponent, string socketName = null) {
			if (childComponent == null)
				throw new ArgumentNullException(nameof(childComponent));

			return canAttachAsChild(Pointer, childComponent.Pointer, socketName.StringToBytes());
		}

		/// <summary>
		/// Performs the specified action on each attached child component if any
		/// </summary>
		public unsafe void ForEachAttachedChild<T>(Action<T> action) where T : SceneComponent {
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			ObjectReference* array = null;
			int elements = 0;

			forEachAttachedChild(Pointer, ref array, ref elements);

			for (int i = 0; i < elements; i++) {
				T component = array[i].ToComponent<T>();

				if (component != null)
					action(component);
			}
		}

		/// <summary>
		/// Attaches the component to another component, optionally at a named socket
		/// </summary>
		/// <returns><c>true</c> if successful</returns>
		public bool AttachToComponent(SceneComponent parent, AttachmentTransformRule attachmentRule, string socketName = null) {
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));

			return attachToComponent(Pointer, parent.Pointer, attachmentRule, socketName.StringToBytes());
		}

		/// <summary>
		/// Detaches the component from a parent
		/// </summary>
		public void DetachFromComponent(DetachmentTransformRule detachmentRule) => detachFromComponent(Pointer, detachmentRule);

		/// <summary>
		/// Activates the component
		/// </summary>
		public void Activate() => activate(Pointer);

		/// <summary>
		/// Deactivates the component
		/// </summary>
		public void Deactivate() => deactivate(Pointer);

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
			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			getAttachedSocketName(Pointer, stringBuffer);

			return stringBuffer.BytesToString();
		}

		/// <summary>
		/// Retrieves calculated bounds of the component
		/// </summary>
		public void GetBounds(in Transform localToWorld, ref Bounds value) => getBounds(Pointer, localToWorld, ref value);

		/// <summary>
		/// Retrieves location of a socket in world space
		/// </summary>
		public void GetSocketLocation(string socketName, ref Vector3 value) => getSocketLocation(Pointer, socketName.StringToBytes(), ref value);

		/// <summary>
		/// Returns location of a socket in world space
		/// </summary>
		public Vector3 GetSocketLocation(string socketName) {
			Vector3 value = default;

			getSocketLocation(Pointer, socketName.StringToBytes(), ref value);

			return value;
		}

		/// <summary>
		/// Retrieves rotation of a socket in world space
		/// </summary>
		public void GetSocketRotation(string socketName, ref Quaternion value) => getSocketRotation(Pointer, socketName.StringToBytes(), ref value);

		/// <summary>
		/// Returns rotation of a socket in world space
		/// </summary>
		public Quaternion GetSocketRotation(string socketName) {
			Quaternion value = default;

			getSocketRotation(Pointer, socketName.StringToBytes(), ref value);

			return value;
		}

		/// <summary>
		/// Retrieves velocity of the component, or the velocity of the physics body if simulating physics
		/// </summary>
		public void GetVelocity(ref Vector3 value) => getComponentVelocity(Pointer, ref value);

		/// <summary>
		/// Returns velocity of the component, or the velocity of the physics body if simulating physics
		/// </summary>
		public Vector3 GetVelocity() {
			Vector3 value = default;

			getComponentVelocity(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves location of the component in world space
		/// </summary>
		public void GetLocation(ref Vector3 value) => getComponentLocation(Pointer, ref value);

		/// <summary>
		/// Returns location of the component in world space
		/// </summary>
		public Vector3 GetLocation() {
			Vector3 value = default;

			getComponentLocation(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Returns rotation of the component in world space
		/// </summary>
		public void GetRotation(ref Quaternion value) => getComponentRotation(Pointer, ref value);

		/// <summary>
		/// Returns rotation of the component in world space
		/// </summary>
		public Quaternion GetRotation() {
			Quaternion value = default;

			getComponentRotation(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves scale of the component in world space
		/// </summary>
		public void GetScale(ref Vector3 value) => getComponentScale(Pointer, ref value);

		/// <summary>
		/// Returns scale of the component in world space
		/// </summary>
		public Vector3 GetScale() {
			Vector3 value = default;

			getComponentScale(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Returns the transform which assigned to the component
		/// </summary>
		public void GetTransform(ref Transform value) => SceneComponent.getComponentTransform(Pointer, ref value);

		/// <summary>
		/// Returns the transform which assigned to the component
		/// </summary>
		public Transform GetTransform() {
			Transform value = default;

			SceneComponent.getComponentTransform(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the forward X unit direction vector from the component in world space
		/// </summary>
		public void GetForwardVector(ref Vector3 value) => getForwardVector(Pointer, ref value);

		/// <summary>
		/// Returns the forward X unit direction vector from the component in world space
		/// </summary>
		public Vector3 GetForwardVector() {
			Vector3 value = default;

			getForwardVector(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the right Y unit direction vector from the component in world space
		/// </summary>
		public void GetRightVector(ref Vector3 value) => getRightVector(Pointer, ref value);

		/// <summary>
		/// Returns the right Y unit direction vector from the component in world space
		/// </summary>
		public Vector3 GetRightVector() {
			Vector3 value = default;

			getRightVector(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the up Z unit direction vector from the component in world space
		/// </summary>
		public void GetUpVector(ref Vector3 value) => getUpVector(Pointer, ref value);

		/// <summary>
		/// Returns the up Z unit direction vector from the component in world space
		/// </summary>
		public Vector3 GetUpVector() {
			Vector3 value = default;

			getUpVector(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Sets how often the component is allowed to move at runtime
		/// </summary>
		public void SetMobility(ComponentMobility mobility) => setMobility(Pointer, mobility);

		/// <summary>
		/// Sets the visibility of the component
		/// </summary>
		public void SetVisibility(bool newVisibility, bool propagateToChildren = false) => setVisibility(Pointer, newVisibility, propagateToChildren);

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
		/// Sets the scale of the component world space
		/// </summary>
		public void SetWorldScale(in Vector3 scale) => setWorldScale(Pointer, scale);

		/// <summary>
		/// Sets the transform of the component in world space
		/// </summary>
		public void SetWorldTransform(in Transform transform) => setWorldTransform(Pointer, transform);
	}

	/// <summary>
	/// A component that is used to play a sound
	/// </summary>
	public unsafe partial class AudioComponent : SceneComponent {
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

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
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
		/// Sets the sound object
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
		/// <param name="duration">Duration to reach <paramref name="volumeLevel"/></param>
		/// <param name="volumeLevel">The percentage of calculated volume to fade to</param>
		/// <param name="startTime">Fading start time</param>
		/// <param name="fadeCurve">Curve to adjust audio volume</param>
		public void FadeIn(float duration, float volumeLevel = 1.0f, float startTime = 0.0f, AudioFadeCurve fadeCurve = AudioFadeCurve.Linear) => fadeIn(Pointer, duration, volumeLevel, startTime, fadeCurve);

		/// <summary>
		/// Smoothly stops the audio, can be used instead of <see cref="Stop"/>
		/// </summary>
		/// <param name="duration">Duration to reach <paramref name="volumeLevel"/></param>
		/// <param name="volumeLevel">he percentage of calculated volume to fade to</param>
		/// <param name="fadeCurve">Curve to adjust audio volume</param>
		public void FadeOut(float duration, float volumeLevel = 0.0f, AudioFadeCurve fadeCurve = AudioFadeCurve.Linear) => fadeOut(Pointer, duration, volumeLevel, fadeCurve);
	}

	/// <summary>
	/// Represents a camera viewpoint and settings, such as projection type, field of view, and post-process overrides
	/// </summary>
	public unsafe partial class CameraComponent : SceneComponent {
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

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
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
	/// A component that automatically spawns and destroys a child actor
	/// </summary>
	public unsafe partial class ChildActorComponent : SceneComponent {
		internal override ComponentType Type => ComponentType.ChildActor;

		private protected ChildActorComponent() { }

		internal ChildActorComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public ChildActorComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Gets the child actor
		/// </summary>
		/// <returns>An actor or <c>null</c> on failure</returns>
		public T GetChildActor<T>() where T : Actor {
			T actor = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = getChildActor(Pointer, actor.Type);

			if (pointer != IntPtr.Zero) {
				actor.Pointer = pointer;

				return actor;
			}

			return null;
		}

		/// <summary>
		/// Sets the child actor
		/// </summary>
		/// <returns>An actor or <c>null</c> on failure</returns>
		public T SetChildActor<T>() where T : Actor {
			T actor = FormatterServices.GetUninitializedObject(typeof(T)) as T;
			IntPtr pointer = setChildActor(Pointer, actor.Type);

			if (pointer != IntPtr.Zero) {
				actor.Pointer = pointer;

				return actor;
			}

			return null;
		}
	}

	/// <summary>
	/// A component that maintains its children at a fixed distance from the parent, but will retract the children if there is a collision, and spring back when there is no collision
	/// </summary>
	public unsafe partial class SpringArmComponent : SceneComponent {
		internal override ComponentType Type => ComponentType.SpringArm;

		private protected SpringArmComponent() { }

		internal SpringArmComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public SpringArmComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns <c>true</c> if the collision test displacement being applied
		/// </summary>
		public bool IsCollisionFixApplied => isCollisionFixApplied(Pointer);

		/// <summary>
		/// Gets or sets whether draw markers at the camera target (in green) and the lagged position (in yellow) if the camera location lag is enabled
		/// </summary>
		public bool DrawDebugLagMarkers {
			get => getDrawDebugLagMarkers(Pointer);
			set => setDrawDebugLagMarkers(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the collision test is enabled using <see cref="ProbeChannel"/> and <see cref="ProbeSize"/> to prevent camera clipping into level
		/// </summary>
		public bool CollisionTest {
			get => getCollisionTest(Pointer);
			set => setCollisionTest(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the camera lags behind target position to smooth its movement
		/// </summary>
		public bool CameraPositionLag {
			get => getCameraPositionLag(Pointer);
			set => setCameraPositionLag(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the camera lags behind target rotation to smooth its movement
		/// </summary>
		public bool CameraRotationLag {
			get => getCameraRotationLag(Pointer);
			set => setCameraRotationLag(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the sub-step camera damping so that it handles fluctuating frame rates well
		/// </summary>
		public bool CameraLagSubstepping {
			get => getCameraLagSubstepping(Pointer);
			set => setCameraLagSubstepping(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the component should inherit yaw from the parent component, has no effect if using absolute rotation
		/// </summary>
		public bool InheritYaw {
			get => getInheritYaw(Pointer);
			set => setInheritYaw(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the component should inherit pitch from the parent component, has no effect if using absolute rotation
		/// </summary>
		public bool InheritPitch {
			get => getInheritPitch(Pointer);
			set => setInheritPitch(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the component should inherit roll from the parent component, has no effect if using absolute rotation
		/// </summary>
		public bool InheritRoll {
			get => getInheritRoll(Pointer);
			set => setInheritRoll(Pointer, value);
		}

		/// <summary>
		/// Gets or sets a max distance the camera target may lag behind the current location
		/// </summary>
		public float CameraLagMaxDistance {
			get => getCameraLagMaxDistance(Pointer);
			set => setCameraLagMaxDistance(Pointer, value);
		}

		/// <summary>
		/// Gets or sets a max time step used when sub-stepping camera lag
		/// </summary>
		public float CameraLagMaxTimeStep {
			get => getCameraLagMaxTimeStep(Pointer);
			set => setCameraLagMaxTimeStep(Pointer, value);
		}

		/// <summary>
		/// Gets or sets how quickly the camera reaches a target position
		/// </summary>
		public float CameraPositionLagSpeed {
			get => getCameraPositionLagSpeed(Pointer);
			set => setCameraPositionLagSpeed(Pointer, value);
		}

		/// <summary>
		/// Gets or sets how quickly еру camera reaches a target rotation
		/// </summary>
		public float CameraRotationLagSpeed {
			get => getCameraRotationLagSpeed(Pointer);
			set => setCameraRotationLagSpeed(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the collision channel of the query probe (<see cref="CollisionChannel.Camera"/> by default)
		/// </summary>
		public CollisionChannel ProbeChannel {
			get => getProbeChannel(Pointer);
			set => setProbeChannel(Pointer, value);
		}

		/// <summary>
		/// Gets or sets how big should be the query probe sphere
		/// </summary>
		public float ProbeSize {
			get => getProbeSize(Pointer);
			set => setProbeSize(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the natural length of the spring arm when there are no collisions
		/// </summary>
		public float TargetArmLength {
			get => getTargetArmLength(Pointer);
			set => setTargetArmLength(Pointer, value);
		}

		/// <summary>
		/// Gets or sets if the component should use the view/control rotation of the pawn
		/// </summary>
		public bool UsePawnControlRotation {
			get => getUsePawnControlRotation(Pointer);
			set => setUsePawnControlRotation(Pointer, value);
		}

		/// <summary>
		/// Retrieves offset at the end of the spring arm, can be used instead of the relative offset of the attached component to ensure the line trace works as desired
		/// </summary>
		public void GetSocketOffset(ref Vector3 value) => getSocketOffset(Pointer, ref value);

		/// <summary>
		/// Returns offset at the end of the spring arm, can be used instead of the relative offset of the attached component to ensure the line trace works as desired
		/// </summary>
		public Vector3 GetSocketOffset() {
			Vector3 value = default;

			getSocketOffset(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves offset at the start of the spring arm in world space
		/// </summary>
		public void GetTargetOffset(ref Vector3 value) => getTargetOffset(Pointer, ref value);

		/// <summary>
		/// Returns offset at the start of the spring arm in world space
		/// </summary>
		public Vector3 GetTargetOffset() {
			Vector3 value = default;

			getTargetOffset(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the unfixed camera position
		/// </summary>
		public void GetUnfixedCameraPosition(ref Vector3 value) => getUnfixedCameraPosition(Pointer, ref value);

		/// <summary>
		/// Returns the unfixed camera position
		/// </summary>
		public Vector3 GetUnfixedCameraPosition() {
			Vector3 value = default;

			getUnfixedCameraPosition(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the desired rotation for the spring arm, before the rotation constraints such as <see cref="InheritYaw"/>, <see cref="InheritPitch"/>, or <see cref="InheritRoll"/> are enforced
		/// </summary>
		public void GetDesiredRotation(ref Quaternion value) => getDesiredRotation(Pointer, ref value);

		/// <summary>
		/// Returns the desired rotation for the spring arm, before the rotation constraints such as <see cref="InheritYaw"/>, <see cref="InheritPitch"/>, or <see cref="InheritRoll"/> are enforced
		/// </summary>
		public Quaternion GetDesiredRotation() {
			Quaternion value = default;

			getDesiredRotation(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the target inherited rotation
		/// </summary>
		public void GetTargetRotation(ref Quaternion value) => getTargetRotation(Pointer, ref value);

		/// <summary>
		/// Returns the target inherited rotation
		/// </summary>
		public Quaternion GetTargetRotation() {
			Quaternion value = default;

			getTargetRotation(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Sets offset at the end of the spring arm, can be used instead of the relative offset of the attached component to ensure the line trace works as desired
		/// </summary>
		public void SetSocketOffset(in Vector3 value) => setSocketOffset(Pointer, value);

		/// <summary>
		/// Sets offset at the start of the spring arm in world space
		/// </summary>
		public void SetTargetOffset(in Vector3 value) => setTargetOffset(Pointer, value);
	}

	/// <summary>
	/// A component that is used for post-processing manipulations
	/// </summary>
	public unsafe partial class PostProcessComponent : SceneComponent {
		internal override ComponentType Type => ComponentType.PostProcess;

		private protected PostProcessComponent() { }

		internal PostProcessComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public PostProcessComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Gets or sets whether the volume is enabled
		/// </summary>
		public bool Enabled {
			get => getEnabled(Pointer);
			set => setEnabled(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the world space radius around the volume that is used for blending if not unbound
		/// </summary>
		public float BlendRadius {
			get => getBlendRadius(Pointer);
			set => setBlendRadius(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the blend weight, 0.0f indicates no effect, 1.0f indicates full effect
		/// </summary>
		public float BlendWeight {
			get => getBlendWeight(Pointer);
			set => setBlendWeight(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the volume covers the whole world or only the area inside its bounds
		/// </summary>
		public bool Unbound {
			get => getUnbound(Pointer);
			set => setUnbound(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the priority of the volume
		/// </summary>
		public float Priority {
			get => getPriority(Pointer);
			set => setPriority(Pointer, value);
		}
	}

	/// <summary>
	/// An abstract component that contains or generates some sort of geometry, generally to be rendered or used as collision data
	/// </summary>
	public abstract unsafe partial class PrimitiveComponent : SceneComponent {
		private protected PrimitiveComponent() { }

		/// <summary>
		/// Returns <c>true</c> if the component is affected by gravity, always returns <c>false</c> if physics simulation is disabled for the component
		/// </summary>
		public bool IsGravityEnabled => isGravityEnabled(Pointer);

		/// <summary>
		/// Returns <c>true</c> if the component is overlapping another component
		/// </summary>
		public bool IsOverlappingComponent(PrimitiveComponent other) {
			if (other == null)
				throw new ArgumentNullException(nameof(other));

			return isOverlappingComponent(Pointer, other.Pointer);
		}

		/// <summary>
		/// Performs the specified action on each overlapping component if any
		/// </summary>
		public unsafe void ForEachOverlappingComponent<T>(Action<T> action) where T : PrimitiveComponent {
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			ObjectReference* array = null;
			int elements = 0;

			forEachOverlappingComponent(Pointer, ref array, ref elements);

			for (int i = 0; i < elements; i++) {
				T component = array[i].ToComponent<T>();

				if (component != null)
					action(component);
			}
		}

		/// <summary>
		/// Returns approximate mass in kilograms
		/// </summary>
		public float Mass => getMass(Pointer);

		/// <summary>
		/// Gets or sets whether the component should cast a shadow
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
		/// Gets or sets whether the component should ignore radial forces
		/// </summary>
		public bool IgnoreRadialForce {
			get => getIgnoreRadialForce(Pointer);
			set => setIgnoreRadialForce(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the component should ignore radial impulses
		/// </summary>
		public bool IgnoreRadialImpulse {
			get => getIgnoreRadialImpulse(Pointer);
			set => setIgnoreRadialImpulse(Pointer, value);
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
		public void AddAngularImpulseInDegrees(in Vector3 impulse, string boneName = null, bool velocityChange = false) => addAngularImpulseInDegrees(Pointer, impulse, boneName.StringToBytes(), velocityChange);

		/// <summary>
		/// Adds an angular impulse in radians to a rigid body
		/// </summary>
		/// <param name="impulse">Magnitude and direction of the impulse to apply, the direction is the axis of rotation</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="velocityChange">If <c>true</c>, <paramref name="impulse"/> is taken as a change in velocity instead of a physical force (the mass will have no effect)</param>
		public void AddAngularImpulseInRadians(in Vector3 impulse, string boneName = null, bool velocityChange = false) => addAngularImpulseInRadians(Pointer, impulse, boneName.StringToBytes(), velocityChange);

		/// <summary>
		/// Adds a force to a rigid body
		/// </summary>
		/// <param name="force">Force vector to apply, magnitude indicates strength of force</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="accelerationChange">If <c>true</c>, <paramref name="force"/> is taken as a change in acceleration instead of a physical force (the mass will have no effect)</param>
		public void AddForce(in Vector3 force, string boneName = null, bool accelerationChange = false) => addForce(Pointer, force, boneName.StringToBytes(), accelerationChange);

		/// <summary>
		/// Adds a force to a rigid body at a specific location, optionally in local space
		/// </summary>
		/// <param name="force">Force vector to apply, magnitude indicates strength of force</param>
		/// <param name="location">A point in world or local space to apply the force at</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="localSpace">If <c>true</c>, applies force in local space instead of world space</param>
		public void AddForceAtLocation(in Vector3 force, in Vector3 location, string boneName = null, bool localSpace = false) => addForceAtLocation(Pointer, force, location, boneName.StringToBytes(), localSpace);

		/// <summary>
		/// Adds an impulse to a rigid body
		/// </summary>
		/// <param name="impulse">Magnitude and direction of the impulse to apply</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="velocityChange">If <c>true</c>, <paramref name="impulse"/> is taken as a change in velocity instead of a physical force (the mass will have no effect)</param>
		public void AddImpulse(in Vector3 impulse, string boneName = null, bool velocityChange = false) => addImpulse(Pointer, impulse, boneName.StringToBytes(), velocityChange);

		/// <summary>
		/// Adds an impulse to a rigid body at a specific location
		/// </summary>
		/// <param name="impulse">Magnitude and direction of the impulse to apply</param>
		/// <param name="location">A point in world space to apply the impulse at</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		public void AddImpulseAtLocation(in Vector3 impulse, in Vector3 location, string boneName = null) => addImpulseAtLocation(Pointer, impulse, location, boneName.StringToBytes());

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
		public void AddTorqueInDegrees(in Vector3 torque, string boneName = null, bool accelerationChange = false) => addTorqueInDegrees(Pointer, torque, boneName.StringToBytes(), accelerationChange);

		/// <summary>
		/// Adds a torque in radians to a rigid body
		/// </summary>
		/// <param name="torque">Torque to apply, direction is axis of rotation and magnitude is strength of the torque</param>
		/// <param name="boneName">If applied to <see cref="SkeletalMeshComponent"/>, the name of the body to apply an angular impulse to, or <c>null</c> to indicate the root body</param>
		/// <param name="accelerationChange">If <c>true</c>, <paramref name="torque"/> is taken as a change in acceleration instead of a physical force (the mass will have no effect)</param>
		public void AddTorqueInRadians(in Vector3 torque, string boneName = null, bool accelerationChange = false) => addTorqueInRadians(Pointer, torque, boneName.StringToBytes(), accelerationChange);

		/// <summary>
		/// Retrieves the linear velocity of a single body
		/// </summary>
		public void GetPhysicsLinearVelocity(ref Vector3 value, string boneName = null) => getPhysicsLinearVelocity(Pointer, ref value, boneName.StringToBytes());

		/// <summary>
		/// Returns the linear velocity of a single body
		/// </summary>
		public Vector3 GetPhysicsLinearVelocity(string boneName = null) {
			Vector3 value = default;

			getPhysicsLinearVelocity(Pointer, ref value, boneName.StringToBytes());

			return value;
		}

		/// <summary>
		/// Retrieves the linear velocity of a point on a single body
		/// </summary>
		public void GetPhysicsLinearVelocityAtPoint(ref Vector3 value, in Vector3 point, string boneName = null) => getPhysicsLinearVelocityAtPoint(Pointer, ref value, point, boneName.StringToBytes());

		/// <summary>
		/// Returns the linear velocity of a point on a single body
		/// </summary>
		public Vector3 GetPhysicsLinearVelocityAtPoint(in Vector3 point, string boneName = null) {
			Vector3 value = default;

			getPhysicsLinearVelocityAtPoint(Pointer, ref value, point, boneName.StringToBytes());

			return value;
		}

		/// <summary>
		/// Retrieves the angular velocity in degrees of a single body
		/// </summary>
		public void GetPhysicsAngularVelocityInDegrees(ref Vector3 value, string boneName = null) => getPhysicsAngularVelocityInDegrees(Pointer, ref value, boneName.StringToBytes());

		/// <summary>
		/// Returns the angular velocity in degrees of a single body
		/// </summary>
		public Vector3 GetPhysicsAngularVelocityInDegrees(string boneName = null) {
			Vector3 value = default;

			getPhysicsAngularVelocityInDegrees(Pointer, ref value, boneName.StringToBytes());

			return value;
		}

		/// <summary>
		/// Retrieves the angular velocity in radians of a single body
		/// </summary>
		public void GetPhysicsAngularVelocityInRadians(ref Vector3 value, string boneName = null) => getPhysicsAngularVelocityInRadians(Pointer, ref value, boneName.StringToBytes());

		/// <summary>
		/// Returns the angular velocity in radians of a single body
		/// </summary>
		public Vector3 GetPhysicsAngularVelocityInRadians(string boneName = null) {
			Vector3 value = default;

			getPhysicsAngularVelocityInRadians(Pointer, ref value, boneName.StringToBytes());

			return value;
		}

		/// <summary>
		/// Returns the material at the specified element index or <c>null</c> on failure
		/// </summary>
		public MaterialInstanceDynamic GetMaterial(int elementIndex) {
			IntPtr pointer = getMaterial(Pointer, elementIndex);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

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
		/// Sets whether the component should generate overlap events when it's overlaps other components
		/// </summary>
		public void SetGenerateOverlapEvents(bool value) => setGenerateOverlapEvents(Pointer, value);

		/// <summary>
		/// Sets whether the component should generate hit events when it's collides with other components
		/// </summary>
		public void SetGenerateHitEvents(bool value) => setGenerateHitEvents(Pointer, value);

		/// <summary>
		/// Sets the mass in kilograms of a rigid body
		/// </summary>
		public void SetMass(float mass, string boneName = null) => setMass(Pointer, mass, boneName.StringToBytes());

		/// <summary>
		/// Sets the center of mass of a single body
		/// </summary>
		public void SetCenterOfMass(in Vector3 offset, string boneName = null) => setCenterOfMass(Pointer, offset, boneName.StringToBytes());

		/// <summary>
		/// Sets the linear velocity of a single body
		/// </summary>
		public void SetPhysicsLinearVelocity(in Vector3 velocity, bool addToCurrent = false, string boneName = null) => setPhysicsLinearVelocity(Pointer, velocity, addToCurrent, boneName.StringToBytes());

		/// <summary>
		/// Sets the angular velocity in degrees of a single body
		/// </summary>
		public void SetPhysicsAngularVelocityInDegrees(in Vector3 angularVelocity, bool addToCurrent = false, string boneName = null) => setPhysicsAngularVelocityInDegrees(Pointer, angularVelocity, addToCurrent, boneName.StringToBytes());

		/// <summary>
		/// Sets the angular velocity in radians of a single body
		/// </summary>
		public void SetPhysicsAngularVelocityInRadians(in Vector3 angularVelocity, bool addToCurrent = false, string boneName = null) => setPhysicsAngularVelocityInRadians(Pointer, angularVelocity, addToCurrent, boneName.StringToBytes());

		/// <summary>
		/// Sets the maximum angular velocity in degrees of a single body
		/// </summary>
		public void SetPhysicsMaxAngularVelocityInDegrees(float maxAngularVelocity, bool addToCurrent = false, string boneName = null) => setPhysicsMaxAngularVelocityInDegrees(Pointer, maxAngularVelocity, addToCurrent, boneName.StringToBytes());

		/// <summary>
		/// Sets the maximum angular velocity in radians of a single body
		/// </summary>
		public void SetPhysicsMaxAngularVelocityInRadians(float maxAngularVelocity, bool addToCurrent = false, string boneName = null) => setPhysicsMaxAngularVelocityInRadians(Pointer, maxAngularVelocity, addToCurrent, boneName.StringToBytes());

		/// <summary>
		/// Sets whether a single body should use physics simulation, or should be kinematic, if the component is currently attached to something, beginning simulation will detach it
		/// </summary>
		public void SetSimulatePhysics(bool value) => setSimulatePhysics(Pointer, value);

		/// <summary>
		/// Sets whether the component is affected by gravity, applies only to components with enabled physics simulation
		/// </summary>
		public void SetEnableGravity(bool value) => setEnableGravity(Pointer, value);

		/// <summary>
		/// Sets the collision mode of the component
		/// </summary>
		public void SetCollisionMode(CollisionMode mode) => setCollisionMode(Pointer, mode);

		/// <summary>
		/// Sets the collision channel of the component
		/// </summary>
		public void SetCollisionChannel(CollisionChannel channel) => setCollisionChannel(Pointer, channel);

		/// <summary>
		/// Sets the collision <a href="https://docs.unrealengine.com/en-US/Engine/Physics/Collision/Reference/index.html">profile name</a> of the component
		/// </summary>
		public void SetCollisionProfileName(string profileName, bool updateOverlaps = true) => setCollisionProfileName(Pointer, profileName.StringToBytes(), updateOverlaps);

		/// <summary>
		/// Sets the collision response to channel of the component
		/// </summary>
		public void SetCollisionResponseToChannel(CollisionChannel channel, CollisionResponse response) => setCollisionResponseToChannel(Pointer, channel, response);

		/// <summary>
		/// Sets the collision response to all channels of the component
		/// </summary>
		public void SetCollisionResponseToAllChannels(CollisionResponse response) => setCollisionResponseToAllChannels(Pointer, response);

		/// <summary>
		/// Sets whether to ignore collision of all components of a specified actor during the movement
		/// </summary>
		public void SetIgnoreActorWhenMoving(Actor actor, bool value) {
			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			setIgnoreActorWhenMoving(Pointer, actor.Pointer, value);
		}

		/// <summary>
		/// Sets whether to ignore collision of a specified component during the movement
		/// </summary>
		public void SetIgnoreComponentWhenMoving(PrimitiveComponent component, bool value) {
			if (component == null)
				throw new ArgumentNullException(nameof(component));

			setIgnoreComponentWhenMoving(Pointer, component.Pointer, value);
		}

		/// <summary>
		/// Clears the list of actors that ignored during the movement
		/// </summary>
		public void ClearMoveIgnoreActors() => clearMoveIgnoreActors(Pointer);

		/// <summary>
		/// Clears the list of components that ignored during the movement
		/// </summary>
		public void ClearMoveIgnoreComponents() => clearMoveIgnoreComponents(Pointer);

		/// <summary>
		/// Creates a dynamic material instance for the specified element index, the parent of the instance is set to the material being replaced
		/// </summary>
		/// <param name="elementIndex">The index of the skin to replace the material for, if invalid, the material is unchanged and <c>null</c> is returned</param>
		/// <returns>A material instance or <c>null</c> on failure</returns>
		public MaterialInstanceDynamic CreateAndSetMaterialInstanceDynamic(int elementIndex) {
			IntPtr pointer = createAndSetMaterialInstanceDynamic(Pointer, elementIndex);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}

		/// <summary>
		/// Registers an event notification for the primitive component
		/// </summary>
		public void RegisterEvent(ComponentEventType type) => registerEvent(Pointer, type);

		/// <summary>
		/// Unregisters an event notification for the primitive component
		/// </summary>
		public void UnregisterEvent(ComponentEventType type) => unregisterEvent(Pointer, type);
	}

	/// <summary>
	/// An abstract component that is represented by a simple geometrical shape
	/// </summary>
	public abstract unsafe partial class ShapeComponent : PrimitiveComponent {
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
	public unsafe partial class BoxComponent : ShapeComponent {
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

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Retrieves the box extents scaled by the component scale
		/// </summary>
		public void GetScaledBoxExtent(ref Vector3 value) => getScaledBoxExtent(Pointer, ref value);

		/// <summary>
		/// Returns the box extents scaled by the component scale
		/// </summary>
		public Vector3 GetScaledBoxExtent() {
			Vector3 value = default;

			getScaledBoxExtent(Pointer, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the box extent ignoring the component scale
		/// </summary>
		public void GetUnscaledBoxExtent(ref Vector3 value) => getUnscaledBoxExtent(Pointer, ref value);

		/// <summary>
		/// Returns the box extent ignoring the component scale
		/// </summary>
		public Vector3 GetUnscaledBoxExtent() {
			Vector3 value = default;

			getUnscaledBoxExtent(Pointer, ref value);

			return value;
		}

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
	public unsafe partial class SphereComponent : ShapeComponent {
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

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
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
	public unsafe partial class CapsuleComponent : ShapeComponent {
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

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
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
	public abstract unsafe partial class MeshComponent : PrimitiveComponent {
		private protected MeshComponent() { }

		/// <summary>
		/// Returns <c>true</c> if the given slot name is valid
		/// </summary>
		public bool IsValidMaterialSlotName(string materialSlotName) {
			if (materialSlotName == null)
				throw new ArgumentNullException(nameof(materialSlotName));

			return isValidMaterialSlotName(Pointer, materialSlotName.StringToBytes());
		}

		/// <summary>
		/// Returns a material index the given a slot name
		/// </summary>
		public int GetMaterialIndex(string materialSlotName) {
			if (materialSlotName == null)
				throw new ArgumentNullException(nameof(materialSlotName));

			return getMaterialIndex(Pointer, materialSlotName.StringToBytes());
		}
	}

	/// <summary>
	/// Renders text in the world
	/// </summary>
	public unsafe partial class TextRenderComponent : PrimitiveComponent {
		internal override ComponentType Type => ComponentType.TextRender;

		private protected TextRenderComponent() { }

		internal TextRenderComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public TextRenderComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Sets the font of the component
		/// </summary>
		public void SetFont(Font value) {
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			setFont(Pointer, value.Pointer);
		}

		/// <summary>
		/// Sets the text of the component
		/// </summary>
		public void SetText(string value) => setText(Pointer, value.StringToBytes());

		/// <summary>
		/// Sets the text material of the component
		/// </summary>
		public void SetTextMaterial(MaterialInterface material) {
			if (material == null)
				throw new ArgumentNullException(nameof(material));

			setTextMaterial(Pointer, material.Pointer);
		}

		/// <summary>
		/// Sets the text render color of the component
		/// </summary>
		public void SetTextRenderColor(Color value) => setTextRenderColor(Pointer, value.ToArgb());

		/// <summary>
		/// Sets the herizontal alignment
		/// </summary>
		public void SetHorizontalAlignment(HorizontalTextAligment value) => setHorizontalAlignment(Pointer, value);

		/// <summary>
		/// Sets the horizontal spacing adjustment
		/// </summary>
		public void SetHorizontalSpacingAdjustment(float value) => setHorizontalSpacingAdjustment(Pointer, value);

		/// <summary>
		/// Sets the vertical alignment
		/// </summary>
		public void SetVerticalAlignment(VerticalTextAligment value) => setVerticalAlignment(Pointer, value);

		/// <summary>
		/// Sets the vertical spacing adjustment
		/// </summary>
		public void SetVerticalSpacingAdjustment(float value) => setVerticalSpacingAdjustment(Pointer, value);

		/// <summary>
		/// Sets the text scale
		/// </summary>
		public void SetScale(in Vector2 value) => setScale(Pointer, value);

		/// <summary>
		/// Sets the world size of the text
		/// </summary>
		public void SetWorldSize(float value) => setWorldSize(Pointer, value);
	}

	/// <summary>
	/// The base class of light components
	/// </summary>
	public abstract unsafe partial class LightComponentBase : SceneComponent {
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
	public unsafe partial class LightComponent : LightComponentBase {
		internal override ComponentType Type => ComponentType.Light;

		private protected LightComponent() { }

		internal LightComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public LightComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

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
	public unsafe partial class DirectionalLightComponent : LightComponent {
		internal override ComponentType Type => ComponentType.DirectionalLight;

		private protected DirectionalLightComponent() { }

		internal DirectionalLightComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public DirectionalLightComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}
	}

	/// <summary>
	/// A component that represents a physical motion controller in 3D space
	/// </summary>
	public unsafe partial class MotionControllerComponent : PrimitiveComponent {
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

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns <c>true</c> if the component has a valid tracked device this frame
		/// </summary>
		public bool IsTracked => isTracked(Pointer);

		/// <summary>
		/// Gets or sets whether to render a model associated with the set hand
		/// </summary>
		public bool DisplayDeviceModel {
			get => getDisplayDeviceModel(Pointer);
			set => setDisplayDeviceModel(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether render transforms within the motion controller hierarchy will be updated a second time immediately before rendering
		/// </summary>
		public bool DisableLowLatencyUpdate {
			get => getDisableLowLatencyUpdate(Pointer);
			set => setDisableLowLatencyUpdate(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the current tracking source
		/// </summary>
		public ControllerHand TrackingSource {
			get => getTrackingSource(Pointer);
			set => setTrackingSource(Pointer, value);
		}

		/// <summary>
		/// Sets the tracking motion source
		/// </summary>
		public void SetTrackingMotionSource(string source) => setTrackingMotionSource(Pointer, source.StringToBytes());

		/// <summary>
		/// Sets the player index which the motion controller should automatically follow
		/// </summary>
		public void SetAssociatedPlayerIndex(int playerIndex) => setAssociatedPlayerIndex(Pointer, playerIndex);

		/// <summary>
		/// Sets the custom display mesh that attached to the motion controller
		/// </summary>
		public void SetCustomDisplayMesh(StaticMesh staticMesh) {
			if (staticMesh == null)
				throw new ArgumentNullException(nameof(staticMesh));

			setCustomDisplayMesh(Pointer, staticMesh.Pointer);
		}

		/// <summary>
		/// Sets the display model source
		/// </summary>
		public void SetDisplayModelSource(string source) => setDisplayModelSource(Pointer, source.StringToBytes());
	}

	/// <summary>
	/// A component that is used to create an instance of a static mesh, a piece of geometry that consists of a static set of polygons
	/// </summary>
	public unsafe partial class StaticMeshComponent : MeshComponent {
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

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
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
				return new(pointer);

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
	public unsafe partial class InstancedStaticMeshComponent : StaticMeshComponent {
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

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns the number of instances in the component
		/// </summary>
		public int InstanceCount => getInstanceCount(Pointer);

		/// <summary>
		/// Retrieves the transform of the specified instance
		/// </summary>
		public bool GetInstanceTransform(int instanceIndex, ref Transform value, bool worldSpace = false) => getInstanceTransform(Pointer, instanceIndex, ref value, worldSpace);

		/// <summary>
		/// Adds an instance to the component using the transform that will be applied at instantiation
		/// </summary>
		public void AddInstance(in Transform instanceTransform) => addInstance(Pointer, instanceTransform);

		/// <summary>
		/// Adds multiple instances to the component using the transforms that will be applied at instantiation
		/// </summary>
		public void AddInstances(Transform[] instanceTransforms) {
			if (instanceTransforms == null)
				throw new ArgumentNullException(nameof(instanceTransforms));

			addInstances(Pointer, instanceTransforms.Length, instanceTransforms);
		}

		/// <summary>
		/// Updates the transform for the specified instance
		/// </summary>
		/// <param name="instanceIndex">The index of the instance to update</param>
		/// <param name="instanceTransform">The new transform to apply</param>
		/// <param name="worldSpace">If <c>true</c>, the new transform is interpreted as a world space transform, otherwise it is interpreted as local space</param>
		/// <param name="markRenderStateDirty">If the render state is marked as dirty the change should be visible immediately, consider setting it to <c>true</c> only during the update of the last instance in a batch</param>
		/// <param name="teleport">Whether the instance's physics should be moved normally, or teleported (moved instantly, ignoring velocity)</param>
		/// <returns><c>true</c> if successful</returns>
		public bool UpdateInstanceTransform(int instanceIndex, in Transform instanceTransform, bool worldSpace = false, bool markRenderStateDirty = false, bool teleport = false) => updateInstanceTransform(Pointer, instanceIndex, instanceTransform, worldSpace, markRenderStateDirty, teleport);

		/// <summary>
		/// Updates the transform for an array of instances
		/// </summary>
		/// <param name="startInstanceIndex">The starting index of the instances to update</param>
		/// <param name="instanceTransforms">The new transforms to apply</param>
		/// <param name="worldSpace">If <c>true</c>, the new transforms are interpreted as a world space transforms, otherwise it is interpreted as local space</param>
		/// <param name="markRenderStateDirty">If the render state is marked as dirty the change should be visible immediately</param>
		/// <param name="teleport">Whether the instances physics should be moved normally, or teleported (moved instantly, ignoring velocity)</param>
		/// <returns><c>true</c> if successful</returns>
		public bool BatchUpdateInstanceTransforms(int startInstanceIndex, Transform[] instanceTransforms, bool worldSpace = false, bool markRenderStateDirty = false, bool teleport = false) {
			if (instanceTransforms == null)
				throw new ArgumentNullException(nameof(instanceTransforms));

			return batchUpdateInstanceTransforms(Pointer, startInstanceIndex, instanceTransforms.Length, instanceTransforms, worldSpace, markRenderStateDirty, teleport);
		}

		/// <summary>
		/// Removes the specified instance
		/// </summary>
		public bool RemoveInstance(int instanceIndex) => removeInstance(Pointer, instanceIndex);

		/// <summary>
		/// Clears all instances being rendered by the component
		/// </summary>
		public void ClearInstances() => clearInstances(Pointer);
	}

	/// <summary>
	/// A component that efficiently renders multiple instances of the same <see cref="StaticMeshComponent"/> with different level of detail
	/// </summary>
	public unsafe partial class HierarchicalInstancedStaticMeshComponent : InstancedStaticMeshComponent {
		internal override ComponentType Type => ComponentType.HierarchicalInstancedStaticMesh;

		private protected HierarchicalInstancedStaticMeshComponent() { }

		internal HierarchicalInstancedStaticMeshComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public HierarchicalInstancedStaticMeshComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Gets or sets whether the collision should be disabled
		/// </summary>
		public bool DisableCollision {
			get => getDisableCollision(Pointer);
			set => setDisableCollision(Pointer, value);
		}
	}

	/// <summary>
	/// A component that supports bone skinned mesh rendering
	/// </summary>
	public abstract unsafe partial class SkinnedMeshComponent : MeshComponent {
		private protected SkinnedMeshComponent() { }

		/// <summary>
		/// Returns the number of bones in the skeleton
		/// </summary>
		public int GetBonesNumber() => getBonesNumber(Pointer);

		/// <summary>
		/// Returns the index of a bone by name
		/// </summary>
		public int GetBoneIndex(string boneName) => getBoneIndex(Pointer, boneName.StringToBytes());

		/// <summary>
		/// Returns the name of a bone by index
		/// </summary>
		public string GetBoneName(int boneIndex) {
			byte[] stringBuffer = ArrayPool.GetStringBuffer();

			getBoneName(Pointer, boneIndex, stringBuffer);

			return stringBuffer.BytesToString();
		}

		/// <summary>
		/// Retrieves the transform of a bone by index
		/// </summary>
		public void GetBoneTransform(int boneIndex, ref Transform value) => getBoneTransform(Pointer, boneIndex, ref value);

		/// <summary>
		/// Returns the transform of a bone by index
		/// </summary>
		public Transform GetBoneTransform(int boneIndex) {
			Transform value = default;

			getBoneTransform(Pointer, boneIndex, ref value);

			return value;
		}

		/// <summary>
		/// Sets the skeletal mesh
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
	public unsafe partial class SkeletalMeshComponent : SkinnedMeshComponent {
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

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns <c>true</c> if playing animation
		/// </summary>
		public bool IsPlaying => isPlaying(Pointer);

		/// <summary>
		/// Returns the animation instance that is driving the class or <c>null</c> on failure
		/// </summary>
		public AnimationInstance GetAnimationInstance() {
			IntPtr pointer = getAnimationInstance(Pointer);

			if (pointer != IntPtr.Zero)
				return new(pointer);

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
	/// Represents a spline shape
	/// </summary>
	public unsafe partial class SplineComponent : PrimitiveComponent {
		internal override ComponentType Type => ComponentType.Spline;

		private protected SplineComponent() { }

		internal SplineComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public SplineComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Returns <c>true</c> if the spline is a closed loop
		/// </summary>
		public bool IsClosedLoop => isClosedLoop(Pointer);

		/// <summary>
		/// Gets or sets the duration of the spline in seconds
		/// </summary>
		public float Duration {
			get => getDuration(Pointer);
			set => setDuration(Pointer, value);
		}

		/// <summary>
		/// Returns the number of spline points
		/// </summary>
		public int SplinePointsNumber => getSplinePointsNumber(Pointer);

		/// <summary>
		/// Returns the number of spline segments
		/// </summary>
		public int SplineSegmentsNumber => getSplineSegmentsNumber(Pointer);

		/// <summary>
		/// Returns the type of a spline point
		/// </summary>
		public SplinePointType GetSplinePointType(int pointIndex) => getSplinePointType(Pointer, pointIndex);

		/// <summary>
		/// Retrieves the tangent at the given distance along the length of the spline
		/// </summary>
		public void GetTangentAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getTangentAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

		/// <summary>
		/// Returns the tangent at the given distance along the length of the spline
		/// </summary>
		public Vector3 GetTangentAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getTangentAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the tangent at the spline point
		/// </summary>
		public void GetTangentAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getTangentAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

		/// <summary>
		/// Returns the tangent at the spline point
		/// </summary>
		public Vector3 GetTangentAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getTangentAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the tangent at the given time from 0.0f to the spline duration
		/// </summary>
		public void GetTangentAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity, ref Vector3 value) => getTangentAtTime(Pointer, time, coordinateSpace, useConstantVelocity, ref value);

		/// <summary>
		/// Returns the tangent at the given time from 0.0f to the spline duration
		/// </summary>
		public Vector3 GetTangentAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity = false) {
			Vector3 value = default;

			getTangentAtTime(Pointer, time, coordinateSpace, useConstantVelocity, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the transform at the given distance along the length of the spline
		/// </summary>
		public void GetTransformAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace, ref Transform value) => getTransformAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

		/// <summary>
		/// Returns the transform at the given distance along the length of the spline
		/// </summary>
		public Transform GetTransformAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace) {
			Transform value = default;

			getTransformAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the transform at the spline point
		/// </summary>
		public void GetTransformAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace, bool useScale, ref Transform value) => getTransformAtSplinePoint(Pointer, pointIndex, coordinateSpace, useScale, ref value);

		/// <summary>
		/// Returns the transform at the spline point
		/// </summary>
		public Transform GetTransformAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace, bool useScale = false) {
			Transform value = default;

			getTransformAtSplinePoint(Pointer, pointIndex, coordinateSpace, useScale, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the arrive tangent at the spline point
		/// </summary>
		public void GetArriveTangentAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getArriveTangentAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

		/// <summary>
		/// Returns the arrive tangent at the spline point
		/// </summary>
		public Vector3 GetArriveTangentAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getArriveTangentAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the default up vector of the spline
		/// </summary>
		public void GetDefaultUpVector(SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getDefaultUpVector(Pointer, coordinateSpace, ref value);

		/// <summary>
		/// Returns the default up vector of the spline
		/// </summary>
		public Vector3 GetDefaultUpVector(SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getDefaultUpVector(Pointer, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves a unit direction vector of the spline tangent at the given distance along the length of the spline
		/// </summary>
		public void GetDirectionAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getDirectionAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

		/// <summary>
		/// Returns a unit direction vector of the spline tangent at the given distance along the length of the spline
		/// </summary>
		public Vector3 GetDirectionAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getDirectionAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves a unit direction vector at the spline point
		/// </summary>
		public void GetDirectionAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getDirectionAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

		/// <summary>
		/// Returns a unit direction vector at the spline point
		/// </summary>
		public Vector3 GetDirectionAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getDirectionAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves a unit direction vector of the spline tangent at the given time from 0.0f to the spline duration
		/// </summary>
		public void GetDirectionAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity, ref Vector3 value) => getDirectionAtTime(Pointer, time, coordinateSpace, useConstantVelocity, ref value);

		/// <summary>
		/// Returns a unit direction vector of the spline tangent at the given time from 0.0f to the spline duration
		/// </summary>
		public Vector3 GetDirectionAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity = false) {
			Vector3 value = default;

			getDirectionAtTime(Pointer, time, coordinateSpace, useConstantVelocity, ref value);

			return value;
		}

		/// <summary>
		/// Returns the distance along the spline at the spline point
		/// </summary>
		public float GetDistanceAlongSplineAtSplinePoint(int pointIndex) => getDistanceAlongSplineAtSplinePoint(Pointer, pointIndex);

		/// <summary>
		/// Retrieves the leave tangent at the spline point
		/// </summary>
		public void GetLeaveTangentAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getLeaveTangentAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

		/// <summary>
		/// Returns the leave tangent at the spline point
		/// </summary>
		public Vector3 GetLeaveTangentAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getLeaveTangentAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the location and tangent at the spline point
		/// </summary>
		public void GetLocationAndTangentAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 location, ref Vector3 tangent) => getLocationAndTangentAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref location, ref tangent);

		/// <summary>
		/// Retrieves the location at the given distance along the length of the spline
		/// </summary>
		public void GetLocationAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getLocationAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

		/// <summary>
		/// Returns the location at the given distance along the length of the spline
		/// </summary>
		public Vector3 GetLocationAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getLocationAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the location at the spline point
		/// </summary>
		public void GetLocationAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getLocationAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

		/// <summary>
		/// Returns the location at the spline point
		/// </summary>
		public Vector3 GetLocationAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getLocationAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the location at the given time from 0.0f to the spline duration
		/// </summary>
		public void GetLocationAtTime(float time, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getLocationAtTime(Pointer, time, coordinateSpace, ref value);

		/// <summary>
		/// Returns the location at the given time from 0.0f to the spline duration
		/// </summary>
		public Vector3 GetLocationAtTime(float time, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getLocationAtTime(Pointer, time, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves a unit direction vector corresponding to the spline's right vector at the given distance along the length of the spline
		/// </summary>
		public void GetRightVectorAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getRightVectorAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

		/// <summary>
		/// Retrieves a unit direction vector corresponding to the spline's right vector at the given distance along the length of the spline
		/// </summary>
		public Vector3 GetRightVectorAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getRightVectorAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the spline's right vector at the spline point
		/// </summary>
		public void GetRightVectorAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getRightVectorAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

		/// <summary>
		/// Returns the spline's right vector at the spline point
		/// </summary>
		public Vector3 GetRightVectorAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getRightVectorAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the spline's right vector at the given time from 0.0f to the spline duration
		/// </summary>
		public void GetRightVectorAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity, ref Vector3 value) => getRightVectorAtTime(Pointer, time, coordinateSpace, useConstantVelocity, ref value);

		/// <summary>
		/// Returns the spline's right vector at the given time from 0.0f to the spline duration
		/// </summary>
		public Vector3 GetRightVectorAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity = false) {
			Vector3 value = default;

			getRightVectorAtTime(Pointer, time, coordinateSpace, useConstantVelocity, ref value);

			return value;
		}

		/// <summary>
		/// Returns the spline's roll in degrees at the given distance along the length of the spline
		/// </summary>
		public float GetRollAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace) => getRollAtDistanceAlongSpline(Pointer, distance, coordinateSpace);

		/// <summary>
		/// Returns the spline's roll in degrees at the spline point
		/// </summary>
		public float GetRollAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace) => getRollAtSplinePoint(Pointer, pointIndex, coordinateSpace);

		/// <summary>
		/// Returns the spline's roll in degrees at the given time from 0.0f to the spline duration
		/// </summary>
		public float GetRollAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity = false) => getRollAtTime(Pointer, time, coordinateSpace, useConstantVelocity);

		/// <summary>
		/// Retrieves a rotation corresponding to the spline's rotation at the given distance along the length of the spline
		/// </summary>
		public void GetRotationAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace, ref Quaternion value) => getRotationAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

		/// <summary>
		/// Returns a rotation corresponding to the spline's rotation at the given distance along the length of the spline
		/// </summary>
		public Quaternion GetRotationAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace) {
			Quaternion value = default;

			getRotationAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves a spline's rotation at the spline point
		/// </summary>
		public void GetRotationAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace, ref Quaternion value) => getRotationAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

		/// <summary>
		/// Returns a spline's rotation at the spline point
		/// </summary>
		public Quaternion GetRotationAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace) {
			Quaternion value = default;

			getRotationAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves a rotation corresponding to the spline's position and direction at the given time from 0.0f to the spline duration
		/// </summary>
		public void GetRotationAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity, ref Quaternion value) => getRotationAtTime(Pointer, time, coordinateSpace, useConstantVelocity, ref value);

		/// <summary>
		/// Returns a rotation corresponding to the spline's position and direction at the given time from 0.0f to the spline duration
		/// </summary>
		public Quaternion GetRotationAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity = false) {
			Quaternion value = default;

			getRotationAtTime(Pointer, time, coordinateSpace, useConstantVelocity, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the spline's scale at the given distance along the length of the spline
		/// </summary>
		public void GetScaleAtDistanceAlongSpline(float distance, ref Vector3 value) => getScaleAtDistanceAlongSpline(Pointer, distance, ref value);

		/// <summary>
		/// Returns the spline's scale at the given distance along the length of the spline
		/// </summary>
		public Vector3 GetScaleAtDistanceAlongSpline(float distance) {
			Vector3 value = default;

			getScaleAtDistanceAlongSpline(Pointer, distance, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the spline's scale at the spline point
		/// </summary>
		public void GetScaleAtSplinePoint(int pointIndex, ref Vector3 value) => getScaleAtSplinePoint(Pointer, pointIndex, ref value);

		/// <summary>
		/// Returns the spline's scale at the spline point
		/// </summary>
		public Vector3 GetScaleAtSplinePoint(int pointIndex) {
			Vector3 value = default;

			getScaleAtSplinePoint(Pointer, pointIndex, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the spline's scale at the given time from 0.0f to the spline duration
		/// </summary>
		public void GetScaleAtTime(float time, bool useConstantVelocity, ref Vector3 value) => getScaleAtTime(Pointer, time, useConstantVelocity, ref value);

		/// <summary>
		/// Returns the spline's scale at the given time from 0.0f to the spline duration
		/// </summary>
		public Vector3 GetScaleAtTime(float time, bool useConstantVelocity = false) {
			Vector3 value = default;

			getScaleAtTime(Pointer, time, useConstantVelocity, ref value);

			return value;
		}

		/// <summary>
		/// Returns the total length along the spline
		/// </summary>
		public float GetSplineLength() => getSplineLength(Pointer);

		/// <summary>
		/// Retrieves the spline's transform at the given time from 0.0f to the spline duration
		/// </summary>
		public void GetTransformAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity, bool useScale, ref Transform value) => getTransformAtTime(Pointer, time, coordinateSpace, useConstantVelocity, useScale, ref value);

		/// <summary>
		/// Returns the spline's transform at the given time from 0.0f to the spline duration
		/// </summary>
		public Transform GetTransformAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity = false, bool useScale = false) {
			Transform value = default;

			getTransformAtTime(Pointer, time, coordinateSpace, useConstantVelocity, useScale, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves a unit direction vector corresponding to the spline's up vector at the given distance along the length of the spline
		/// </summary>
		public void GetUpVectorAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getUpVectorAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

		/// <summary>
		/// Returns a unit direction vector corresponding to the spline's up vector at the given distance along the length of the spline
		/// </summary>
		public Vector3 GetUpVectorAtDistanceAlongSpline(float distance, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getUpVectorAtDistanceAlongSpline(Pointer, distance, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the spline's up vector at the spline point
		/// </summary>
		public void GetUpVectorAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace, ref Vector3 value) => getUpVectorAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

		/// <summary>
		/// Returns the spline's up vector at the spline point
		/// </summary>
		public Vector3 GetUpVectorAtSplinePoint(int pointIndex, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			getUpVectorAtSplinePoint(Pointer, pointIndex, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Retrieves the spline's up vector at the given time from 0.0f to the spline duration
		/// </summary>
		public void GetUpVectorAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity, ref Vector3 value) => getUpVectorAtTime(Pointer, time, coordinateSpace, useConstantVelocity, ref value);

		/// <summary>
		/// Returns the spline's up vector at the given time from 0.0f to the spline duration
		/// </summary>
		public Vector3 GetUpVectorAtTime(float time, SplineCoordinateSpace coordinateSpace, bool useConstantVelocity = false) {
			Vector3 value = default;

			getUpVectorAtTime(Pointer, time, coordinateSpace, useConstantVelocity, ref value);

			return value;
		}

		/// <summary>
		/// Sets the type of a spline point
		/// </summary>
		public void SetSplinePointType(int pointIndex, SplinePointType type, bool updateSpline = true) => setSplinePointType(Pointer, pointIndex, type, updateSpline);

		/// <summary>
		/// Sets whether the spline is a closed loop
		/// </summary>
		public void SetClosedLoop(bool value, bool updateSpline = true) => setClosedLoop(Pointer, value, updateSpline);

		/// <summary>
		/// Sets the default up vector of the spline
		/// </summary>
		public void SetDefaultUpVector(in Vector3 value, SplineCoordinateSpace coordinateSpace) => setDefaultUpVector(Pointer, value, coordinateSpace);

		/// <summary>
		/// Sets an existing point to a new location
		/// </summary>
		public void SetLocationAtSplinePoint(int pointIndex, in Vector3 value, SplineCoordinateSpace coordinateSpace, bool updateSpline = true) => setLocationAtSplinePoint(Pointer, pointIndex, value, coordinateSpace, updateSpline);

		/// <summary>
		/// Sets the tangent at a given spline point
		/// </summary>
		public void SetTangentAtSplinePoint(int pointIndex, in Vector3 tangent, SplineCoordinateSpace coordinateSpace, bool updateSpline = true) => setTangentAtSplinePoint(Pointer, pointIndex, tangent, coordinateSpace, updateSpline);

		/// <summary>
		/// Sets the tangents at a given spline point
		/// </summary>
		public void SetTangentsAtSplinePoint(int pointIndex, in Vector3 arriveTangent, in Vector3 leaveTangent, SplineCoordinateSpace coordinateSpace, bool updateSpline = true) => setTangentsAtSplinePoint(Pointer, pointIndex, arriveTangent, leaveTangent, coordinateSpace, updateSpline);

		/// <summary>
		/// Sets the up vector at a given spline point
		/// </summary>
		public void SetUpVectorAtSplinePoint(int pointIndex, in Vector3 upVector, SplineCoordinateSpace coordinateSpace, bool updateSpline = true) => setUpVectorAtSplinePoint(Pointer, pointIndex, upVector, coordinateSpace, updateSpline);

		/// <summary>
		/// Adds a point to the spline
		/// </summary>
		public void AddSplinePoint(in Vector3 location, SplineCoordinateSpace coordinateSpace, bool updateSpline = true) => addSplinePoint(Pointer, location, coordinateSpace, updateSpline);

		/// <summary>
		/// Adds a point to the spline at the specified index
		/// </summary>
		public void AddSplinePointAtIndex(in Vector3 location, int pointIndex, SplineCoordinateSpace coordinateSpace, bool updateSpline = true) => addSplinePointAtIndex(Pointer, location, pointIndex, coordinateSpace, updateSpline);

		/// <summary>
		/// Clears all the points in the spline
		/// </summary>
		public void ClearSplinePoints(bool updateSpline = true) => clearSplinePoints(Pointer, updateSpline);

		/// <summary>
		/// Returns a unit direction vector of the spline tangent closest to the location in world space
		/// </summary>
		public Vector3 FindDirectionClosestToWorldLocation(in Vector3 location, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			findDirectionClosestToWorldLocation(Pointer, location, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Returns a point of the spline closest to the location in world space
		/// </summary>
		public Vector3 FindLocationClosestToWorldLocation(in Vector3 location, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			findLocationClosestToWorldLocation(Pointer, location, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Returns a unit direction vector corresponding to the spline's up vector closest to the location in world space
		/// </summary>
		public Vector3 FindUpVectorClosestToWorldLocation(in Vector3 location, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			findUpVectorClosestToWorldLocation(Pointer, location, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Returns a unit direction vector corresponding to the spline's right vector closest to the location in world space
		/// </summary>
		public Vector3 FindRightVectorClosestToWorldLocation(in Vector3 location, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			findRightVectorClosestToWorldLocation(Pointer, location, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Returns the spline's roll in degrees closest to the location in world space
		/// </summary>
		public float FindRollClosestToWorldLocation(in Vector3 location, SplineCoordinateSpace coordinateSpace) => findRollClosestToWorldLocation(Pointer, location, coordinateSpace);

		/// <summary>
		/// Returns the spline's scale closest to the location in world space
		/// </summary>
		public Vector3 FindScaleClosestToWorldLocation(in Vector3 location) {
			Vector3 value = default;

			findScaleClosestToWorldLocation(Pointer, location, ref value);

			return value;
		}

		/// <summary>
		/// Returns a tangent of the spline closest to the location in world space
		/// </summary>
		public Vector3 FindTangentClosestToWorldLocation(in Vector3 location, SplineCoordinateSpace coordinateSpace) {
			Vector3 value = default;

			findTangentClosestToWorldLocation(Pointer, location, coordinateSpace, ref value);

			return value;
		}

		/// <summary>
		/// Returns a transform closest to the location in world space
		/// </summary>
		public Transform FindTransformClosestToWorldLocation(in Vector3 location, SplineCoordinateSpace coordinateSpace, bool useScale = false) {
			Transform value = default;

			findTransformClosestToWorldLocation(Pointer, location, coordinateSpace, useScale, ref value);

			return value;
		}

		/// <summary>
		/// Removes a point at the specified index from the spline
		/// </summary>
		public void RemoveSplinePoint(int pointIndex, bool updateSpline = true) => removeSplinePoint(Pointer, pointIndex, updateSpline);

		/// <summary>
		/// Updates the spline
		/// </summary>
		public void UpdateSpline() => updateSpline(Pointer);
	}

	/// <summary>
	/// A component that emits a radial force or impulse that can affect physics objects and destructible objects
	/// </summary>
	public unsafe partial class RadialForceComponent : SceneComponent {
		internal override ComponentType Type => ComponentType.RadialForce;

		private protected RadialForceComponent() { }

		internal RadialForceComponent(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Creates the component attached to an actor and optionally sets it as the root, first component will be set as the root automatically
		/// </summary>
		/// <param name="actor">The actor to attach the component to</param>
		/// <param name="name">The name of the component</param>
		/// <param name="setAsRoot">If <c>true</c>, sets the component as the root</param>
		/// <param name="blueprint">The blueprint class to use as a base class, should be equal to the exact type of the component</param>
		public RadialForceComponent(Actor actor, string name = null, bool setAsRoot = false, Blueprint blueprint = null) {
			if (name?.Length == 0)
				name = null;

			if (actor == null)
				throw new ArgumentNullException(nameof(actor));

			if (blueprint != null && !blueprint.IsValidClass(Type))
				throw new InvalidOperationException();

			Pointer = create(actor.Pointer, Type, name.StringToBytes(), setAsRoot, blueprint != null ? blueprint.Pointer : IntPtr.Zero);
		}

		/// <summary>
		/// Gets or sets whether to apply the force or impulse to any physics objects that are part of the actor which owns the component
		/// </summary>
		public bool IgnoreOwningActor {
			get => getIgnoreOwningActor(Pointer);
			set => setIgnoreOwningActor(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the impulse will ignore the mass of objects and will always result in a fixed velocity change
		/// </summary>
		public bool ImpulseVelocityChange {
			get => getImpulseVelocityChange(Pointer);
			set => setImpulseVelocityChange(Pointer, value);
		}

		/// <summary>
		/// Gets or sets whether the force or impulse should lose its strength linearly
		/// </summary>
		public bool LinearFalloff {
			get => getLinearFalloff(Pointer);
			set => setLinearFalloff(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the force strength
		/// </summary>
		public float ForceStrength {
			get => getForceStrength(Pointer);
			set => setForceStrength(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the impulse strength
		/// </summary>
		public float ImpulseStrength {
			get => getImpulseStrength(Pointer);
			set => setImpulseStrength(Pointer, value);
		}

		/// <summary>
		/// Gets or sets the radius within the force or impulse will be applied
		/// </summary>
		public float Radius {
			get => getRadius(Pointer);
			set => setRadius(Pointer, value);
		}

		/// <summary>
		/// Adds a collision channel that will be affected by the radial force
		/// </summary>
		public void AddCollisionChannelToAffect(CollisionChannel channel) => addCollisionChannelToAffect(Pointer, channel);

		/// <summary>
		/// Fires a single impulse
		/// </summary>
		public void FireImpulse() => fireImpulse(Pointer);
	}

	/// <summary>
	/// The base class of materials that can be applied to meshes
	/// </summary>
	public abstract unsafe partial class MaterialInterface : IEquatable<MaterialInterface> {
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
	public unsafe partial class Material : MaterialInterface {
		private protected Material() { }

		internal Material(IntPtr pointer) => Pointer = pointer;

		/// <summary>
		/// Finds and loads a material by name
		/// </summary>
		/// <returns>A material or <c>null</c> on failure</returns>
		public static Material Load(string name) {
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			IntPtr pointer = Object.load(ObjectType.Material, name.StringToBytes());

			if (pointer != IntPtr.Zero)
				return new(pointer);

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
	public abstract unsafe partial class MaterialInstance : MaterialInterface {
		private protected MaterialInstance() { }

		/// <summary>
		/// Returns <c>true</c> if the material instance is a child of another Material
		/// </summary>
		public bool IsChildOf(MaterialInterface material) {
			if (material == null)
				throw new ArgumentNullException(nameof(material));

			return isChildOf(Pointer, material.Pointer);
		}

		/// <summary>
		/// Returns the parent material or <c>null</c> on failure
		/// </summary>
		public MaterialInstanceDynamic GetParent() {
			IntPtr pointer = getParent(Pointer);

			if (pointer != IntPtr.Zero)
				return new(pointer);

			return null;
		}
	}

	/// <summary>
	/// A dynamic instance of the material
	/// </summary>
	public unsafe partial class MaterialInstanceDynamic : MaterialInstance {
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

			setTextureParameterValue(Pointer, parameterName.StringToBytes(), value.Pointer);
		}

		/// <summary>
		/// Sets the vector parameter value
		/// </summary>
		public void SetVectorParameterValue(string parameterName, in LinearColor value) {
			if (parameterName == null)
				throw new ArgumentNullException(nameof(parameterName));

			setVectorParameterValue(Pointer, parameterName.StringToBytes(), value);
		}

		/// <summary>
		/// Sets the scalar parameter value
		/// </summary>
		public void SetScalarParameterValue(string parameterName, float value) {
			if (parameterName == null)
				throw new ArgumentNullException(nameof(parameterName));

			setScalarParameterValue(Pointer, parameterName.StringToBytes(), value);
		}
	}
}
