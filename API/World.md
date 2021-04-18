### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## World Class
The top-level representation of a map or a sandbox in which actors and components will exist and rendered  
```csharp
public static class World
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; World  
### Properties

***
[ActorCount](World_ActorCount.md 'UnrealEngine.Framework.World.ActorCount')

Returns the actor count  

***
[CurrentLevelName](World_CurrentLevelName.md 'UnrealEngine.Framework.World.CurrentLevelName')

Returns the name of the current level  

***
[DeltaTime](World_DeltaTime.md 'UnrealEngine.Framework.World.DeltaTime')

Returns the frame delta time in seconds  

***
[RealTime](World_RealTime.md 'UnrealEngine.Framework.World.RealTime')

Returns time in seconds since the world was brought up for play, does not stop when the game pauses, not dilated or clamped  

***
[SimulatePhysics](World_SimulatePhysics.md 'UnrealEngine.Framework.World.SimulatePhysics')

Gets or sets physics simulation for the world  

***
[Time](World_Time.md 'UnrealEngine.Framework.World.Time')

Returns time in seconds since the world was brought up for play, it is stopped when the game pauses, it is dilated or clamped  
### Methods

***
[ForEachActor&lt;T&gt;(Action&lt;T&gt;)](World_ForEachActor_T_(Action_T_).md 'UnrealEngine.Framework.World.ForEachActor&lt;T&gt;(System.Action&lt;T&gt;)')

Performs the specified action on each actor in the world  

***
[GetActor&lt;T&gt;(string)](World_GetActor_T_(string).md 'UnrealEngine.Framework.World.GetActor&lt;T&gt;(string)')

Returns the first actor in the world of the specified class, optionally with the specified name, this operation is slow and should be used with caution  

***
[GetActorByID&lt;T&gt;(uint)](World_GetActorByID_T_(uint).md 'UnrealEngine.Framework.World.GetActorByID&lt;T&gt;(uint)')

Returns the first actor in the world of the specified class and ID, this operation is slow and should be used with caution  

***
[GetActorByTag&lt;T&gt;(string)](World_GetActorByTag_T_(string).md 'UnrealEngine.Framework.World.GetActorByTag&lt;T&gt;(string)')

Returns the first actor in the world of the specified class and tag, this operation is slow and should be used with caution  

***
[GetFirstPlayerController()](World_GetFirstPlayerController().md 'UnrealEngine.Framework.World.GetFirstPlayerController()')

Returns the first player controller  

***
[GetWorldOrigin()](World_GetWorldOrigin().md 'UnrealEngine.Framework.World.GetWorldOrigin()')

Returns the current location of the <a href="https://docs.unrealengine.com/en-US/Engine/LevelStreaming/WorldBrowser/index.html">world origin</a>

***
[GetWorldOrigin(Vector3)](World_GetWorldOrigin(Vector3).md 'UnrealEngine.Framework.World.GetWorldOrigin(System.Numerics.Vector3)')

Retrieves the current location of the <a href="https://docs.unrealengine.com/en-US/Engine/LevelStreaming/WorldBrowser/index.html">world origin</a> to a reference  

***
[LineTraceSingleByChannel(Vector3, Vector3, CollisionChannel, Hit, bool, Actor, PrimitiveComponent)](World_LineTraceSingleByChannel(Vector3_Vector3_CollisionChannel_Hit_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceSingleByChannel(System.Numerics.Vector3, System.Numerics.Vector3, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.Hit, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Traces a ray against the world using a specific channel and retrieves the first blocking hit  

***
[LineTraceSingleByChannel(Vector3, Vector3, CollisionChannel, Hit, string, bool, Actor, PrimitiveComponent)](World_LineTraceSingleByChannel(Vector3_Vector3_CollisionChannel_Hit_string_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceSingleByChannel(System.Numerics.Vector3, System.Numerics.Vector3, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.Hit, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Traces a ray against the world using a specific channel and retrieves the first blocking hit with a bone name  

***
[LineTraceSingleByProfile(Vector3, Vector3, string, Hit, bool, Actor, PrimitiveComponent)](World_LineTraceSingleByProfile(Vector3_Vector3_string_Hit_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceSingleByProfile(System.Numerics.Vector3, System.Numerics.Vector3, string, UnrealEngine.Framework.Hit, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Traces a ray against the world using a specific profile and retrieves the first blocking hit  

***
[LineTraceSingleByProfile(Vector3, Vector3, string, Hit, string, bool, Actor, PrimitiveComponent)](World_LineTraceSingleByProfile(Vector3_Vector3_string_Hit_string_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceSingleByProfile(System.Numerics.Vector3, System.Numerics.Vector3, string, UnrealEngine.Framework.Hit, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Traces a ray against the world using a specific profile and retrieves the first blocking hit with a bone name  

***
[LineTraceTestByChannel(Vector3, Vector3, CollisionChannel, bool, Actor, PrimitiveComponent)](World_LineTraceTestByChannel(Vector3_Vector3_CollisionChannel_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceTestByChannel(System.Numerics.Vector3, System.Numerics.Vector3, UnrealEngine.Framework.CollisionChannel, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Traces a ray against the world using a specific channel  

***
[LineTraceTestByProfile(Vector3, Vector3, string, bool, Actor, PrimitiveComponent)](World_LineTraceTestByProfile(Vector3_Vector3_string_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.LineTraceTestByProfile(System.Numerics.Vector3, System.Numerics.Vector3, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Traces a ray against the world using a specific profile  

***
[OpenLevel(string)](World_OpenLevel(string).md 'UnrealEngine.Framework.World.OpenLevel(string)')

Travels to another level  

***
[OverlapAnyTestByChannel(Vector3, Quaternion, CollisionChannel, CollisionShape, Actor, PrimitiveComponent)](World_OverlapAnyTestByChannel(Vector3_Quaternion_CollisionChannel_CollisionShape_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.OverlapAnyTestByChannel(System.Numerics.Vector3, System.Numerics.Quaternion, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.CollisionShape, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Tests the collision shape at the specified location using a specific channel to determine if any blocking or overlapping occurred  

***
[OverlapAnyTestByProfile(Vector3, Quaternion, string, CollisionShape, Actor, PrimitiveComponent)](World_OverlapAnyTestByProfile(Vector3_Quaternion_string_CollisionShape_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.OverlapAnyTestByProfile(System.Numerics.Vector3, System.Numerics.Quaternion, string, UnrealEngine.Framework.CollisionShape, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Tests the collision shape at the specified location using a specific profile to determine if any blocking or overlapping occurred  

***
[OverlapBlockingTestByChannel(Vector3, Quaternion, CollisionChannel, CollisionShape, Actor, PrimitiveComponent)](World_OverlapBlockingTestByChannel(Vector3_Quaternion_CollisionChannel_CollisionShape_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.OverlapBlockingTestByChannel(System.Numerics.Vector3, System.Numerics.Quaternion, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.CollisionShape, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Tests the collision shape at the specified location using a specific channel to determine if any blocking occurred  

***
[OverlapBlockingTestByProfile(Vector3, Quaternion, string, CollisionShape, Actor, PrimitiveComponent)](World_OverlapBlockingTestByProfile(Vector3_Quaternion_string_CollisionShape_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.OverlapBlockingTestByProfile(System.Numerics.Vector3, System.Numerics.Quaternion, string, UnrealEngine.Framework.CollisionShape, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Tests the collision shape at the specified location using a specific profile to determine if any blocking occurred  

***
[SetGravity(float)](World_SetGravity(float).md 'UnrealEngine.Framework.World.SetGravity(float)')

Sets the gravity applied to all objects in the world  

***
[SetOnActorBeginCursorOverCallback(ActorCursorDelegate)](World_SetOnActorBeginCursorOverCallback(ActorCursorDelegate).md 'UnrealEngine.Framework.World.SetOnActorBeginCursorOverCallback(UnrealEngine.Framework.ActorCursorDelegate)')

Sets the callback function that is called when the mouse cursor is moved over an actor if mouse over events are enabled in the player controller  

***
[SetOnActorBeginOverlapCallback(ActorOverlapDelegate)](World_SetOnActorBeginOverlapCallback(ActorOverlapDelegate).md 'UnrealEngine.Framework.World.SetOnActorBeginOverlapCallback(UnrealEngine.Framework.ActorOverlapDelegate)')

Sets the callback function that is called when actors start overlapping  

***
[SetOnActorClickedCallback(ActorKeyDelegate)](World_SetOnActorClickedCallback(ActorKeyDelegate).md 'UnrealEngine.Framework.World.SetOnActorClickedCallback(UnrealEngine.Framework.ActorKeyDelegate)')

Sets the callback function that is called when the mouse button is clicked while the mouse is over an actor if click events are enabled in the player controller  

***
[SetOnActorEndCursorOverCallback(ActorCursorDelegate)](World_SetOnActorEndCursorOverCallback(ActorCursorDelegate).md 'UnrealEngine.Framework.World.SetOnActorEndCursorOverCallback(UnrealEngine.Framework.ActorCursorDelegate)')

Sets the callback function that is called when the mouse cursor is moved off an actor if mouse over events are enabled in the player controller  

***
[SetOnActorEndOverlapCallback(ActorOverlapDelegate)](World_SetOnActorEndOverlapCallback(ActorOverlapDelegate).md 'UnrealEngine.Framework.World.SetOnActorEndOverlapCallback(UnrealEngine.Framework.ActorOverlapDelegate)')

Sets the callback function that is called when actors end overlapping  

***
[SetOnActorHitCallback(ActorHitDelegate)](World_SetOnActorHitCallback(ActorHitDelegate).md 'UnrealEngine.Framework.World.SetOnActorHitCallback(UnrealEngine.Framework.ActorHitDelegate)')

Sets the callback function that is called when actors hit collisions  

***
[SetOnActorReleasedCallback(ActorKeyDelegate)](World_SetOnActorReleasedCallback(ActorKeyDelegate).md 'UnrealEngine.Framework.World.SetOnActorReleasedCallback(UnrealEngine.Framework.ActorKeyDelegate)')

Sets the callback function that is called when the mouse button is released while the mouse is over an actor if click events are enabled in the player controller  

***
[SetOnComponentBeginCursorOverCallback(ComponentCursorDelegate)](World_SetOnComponentBeginCursorOverCallback(ComponentCursorDelegate).md 'UnrealEngine.Framework.World.SetOnComponentBeginCursorOverCallback(UnrealEngine.Framework.ComponentCursorDelegate)')

Sets the callback function that is called when the mouse cursor is moved over a component and mouse over events are enabled in the player controller  

***
[SetOnComponentBeginOverlapCallback(ComponentOverlapDelegate)](World_SetOnComponentBeginOverlapCallback(ComponentOverlapDelegate).md 'UnrealEngine.Framework.World.SetOnComponentBeginOverlapCallback(UnrealEngine.Framework.ComponentOverlapDelegate)')

Sets the callback function that is called when primitive components start overlapping  

***
[SetOnComponentClickedCallback(ComponentKeyDelegate)](World_SetOnComponentClickedCallback(ComponentKeyDelegate).md 'UnrealEngine.Framework.World.SetOnComponentClickedCallback(UnrealEngine.Framework.ComponentKeyDelegate)')

Sets the callback function that is called when the mouse button is clicked while the mouse is over a component if click events are enabled in the player controller  

***
[SetOnComponentEndCursorOverCallback(ComponentCursorDelegate)](World_SetOnComponentEndCursorOverCallback(ComponentCursorDelegate).md 'UnrealEngine.Framework.World.SetOnComponentEndCursorOverCallback(UnrealEngine.Framework.ComponentCursorDelegate)')

Sets the callback function that is called when the mouse cursor is moved off a component and mouse over events are enabled in the player controller  

***
[SetOnComponentEndOverlapCallback(ComponentOverlapDelegate)](World_SetOnComponentEndOverlapCallback(ComponentOverlapDelegate).md 'UnrealEngine.Framework.World.SetOnComponentEndOverlapCallback(UnrealEngine.Framework.ComponentOverlapDelegate)')

Sets the callback function that is called when primitive components end overlapping  

***
[SetOnComponentHitCallback(ComponentHitDelegate)](World_SetOnComponentHitCallback(ComponentHitDelegate).md 'UnrealEngine.Framework.World.SetOnComponentHitCallback(UnrealEngine.Framework.ComponentHitDelegate)')

Sets the callback function that is called when components hit collisions  

***
[SetOnComponentReleasedCallback(ComponentKeyDelegate)](World_SetOnComponentReleasedCallback(ComponentKeyDelegate).md 'UnrealEngine.Framework.World.SetOnComponentReleasedCallback(UnrealEngine.Framework.ComponentKeyDelegate)')

Sets the callback function that is called when the mouse button is released while the mouse is over a component if click events are enabled in the player controller  

***
[SetWorldOrigin(Vector3)](World_SetWorldOrigin(Vector3).md 'UnrealEngine.Framework.World.SetWorldOrigin(System.Numerics.Vector3)')

Sets <a href="https://docs.unrealengine.com/en-US/Engine/LevelStreaming/WorldBrowser/index.html">world origin</a> to the specified location  

***
[SweepSingleByChannel(Vector3, Vector3, Quaternion, CollisionChannel, CollisionShape, Hit, bool, Actor, PrimitiveComponent)](World_SweepSingleByChannel(Vector3_Vector3_Quaternion_CollisionChannel_CollisionShape_Hit_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.SweepSingleByChannel(System.Numerics.Vector3, System.Numerics.Vector3, System.Numerics.Quaternion, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.CollisionShape, UnrealEngine.Framework.Hit, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Sweeps a shape against the world using a specific profile and retrieves the first blocking hit  

***
[SweepSingleByChannel(Vector3, Vector3, Quaternion, CollisionChannel, CollisionShape, Hit, string, bool, Actor, PrimitiveComponent)](World_SweepSingleByChannel(Vector3_Vector3_Quaternion_CollisionChannel_CollisionShape_Hit_string_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.SweepSingleByChannel(System.Numerics.Vector3, System.Numerics.Vector3, System.Numerics.Quaternion, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.CollisionShape, UnrealEngine.Framework.Hit, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Sweeps a shape against the world using a specific profile and retrieves the first blocking hit with a bone name  

***
[SweepSingleByProfile(Vector3, Vector3, Quaternion, string, CollisionShape, Hit, bool, Actor, PrimitiveComponent)](World_SweepSingleByProfile(Vector3_Vector3_Quaternion_string_CollisionShape_Hit_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.SweepSingleByProfile(System.Numerics.Vector3, System.Numerics.Vector3, System.Numerics.Quaternion, string, UnrealEngine.Framework.CollisionShape, UnrealEngine.Framework.Hit, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Sweeps a shape against the world using a specific profile and retrieves the first blocking hit  

***
[SweepSingleByProfile(Vector3, Vector3, Quaternion, string, CollisionShape, Hit, string, bool, Actor, PrimitiveComponent)](World_SweepSingleByProfile(Vector3_Vector3_Quaternion_string_CollisionShape_Hit_string_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.SweepSingleByProfile(System.Numerics.Vector3, System.Numerics.Vector3, System.Numerics.Quaternion, string, UnrealEngine.Framework.CollisionShape, UnrealEngine.Framework.Hit, string, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Sweeps a shape against the world using a specific profile and retrieves the first blocking hit with a bone name  

***
[SweepTestByChannel(Vector3, Vector3, Quaternion, CollisionChannel, CollisionShape, bool, Actor, PrimitiveComponent)](World_SweepTestByChannel(Vector3_Vector3_Quaternion_CollisionChannel_CollisionShape_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.SweepTestByChannel(System.Numerics.Vector3, System.Numerics.Vector3, System.Numerics.Quaternion, UnrealEngine.Framework.CollisionChannel, UnrealEngine.Framework.CollisionShape, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Sweeps a shape against the world using a specific profile  

***
[SweepTestByProfile(Vector3, Vector3, Quaternion, string, CollisionShape, bool, Actor, PrimitiveComponent)](World_SweepTestByProfile(Vector3_Vector3_Quaternion_string_CollisionShape_bool_Actor_PrimitiveComponent).md 'UnrealEngine.Framework.World.SweepTestByProfile(System.Numerics.Vector3, System.Numerics.Vector3, System.Numerics.Quaternion, string, UnrealEngine.Framework.CollisionShape, bool, UnrealEngine.Framework.Actor, UnrealEngine.Framework.PrimitiveComponent)')

Sweeps a shape against the world using a specific profile  
