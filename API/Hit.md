### [UnrealEngine.Framework](UnrealEngine_Framework.md 'UnrealEngine.Framework')
## Hit Struct
A trace hit  
```csharp
public struct Hit :
System.IEquatable<UnrealEngine.Framework.Hit>
```

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Hit](Hit.md 'UnrealEngine.Framework.Hit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Properties

***
[BlockingHit](Hit_BlockingHit.md 'UnrealEngine.Framework.Hit.BlockingHit')

Returns `true` if the hit was a result of blocking collision  

***
[Distance](Hit_Distance.md 'UnrealEngine.Framework.Hit.Distance')

Returns the distance from [TraceStart](Hit_TraceStart.md 'UnrealEngine.Framework.Hit.TraceStart') to [Location](Hit_Location.md 'UnrealEngine.Framework.Hit.Location') in world space  

***
[ImpactLocation](Hit_ImpactLocation.md 'UnrealEngine.Framework.Hit.ImpactLocation')

Returns the location in world space of the actual contact of the trace shape with the impacted object  

***
[ImpactNormal](Hit_ImpactNormal.md 'UnrealEngine.Framework.Hit.ImpactNormal')

Returns the normal of the hit in world space for the object that was hit by the sweep  

***
[Location](Hit_Location.md 'UnrealEngine.Framework.Hit.Location')

Returns the location in world space where the moving shape would end up against the impacted object if there was a hit  

***
[Normal](Hit_Normal.md 'UnrealEngine.Framework.Hit.Normal')

Returns the normal of the hit in world space for the object that was swept  

***
[PenetrationDepth](Hit_PenetrationDepth.md 'UnrealEngine.Framework.Hit.PenetrationDepth')

Returns the distance along with [Normal](Hit_Normal.md 'UnrealEngine.Framework.Hit.Normal') that will result in moving out of penetration if [StartPenetrating](Hit_StartPenetrating.md 'UnrealEngine.Framework.Hit.StartPenetrating') is `true` and a penetration vector can be computed  

***
[StartPenetrating](Hit_StartPenetrating.md 'UnrealEngine.Framework.Hit.StartPenetrating')

Returns `true` if the trace started penetration  

***
[Time](Hit_Time.md 'UnrealEngine.Framework.Hit.Time')

Returns the impact along trace direction between 0.0f and 1.0f if there was a hit, indicating time between [TraceStart](Hit_TraceStart.md 'UnrealEngine.Framework.Hit.TraceStart') and [TraceEnd](Hit_TraceEnd.md 'UnrealEngine.Framework.Hit.TraceEnd')

***
[TraceEnd](Hit_TraceEnd.md 'UnrealEngine.Framework.Hit.TraceEnd')

Returns the end location of the trace  

***
[TraceStart](Hit_TraceStart.md 'UnrealEngine.Framework.Hit.TraceStart')

Returns the start location of the trace  
### Methods

***
[Equals(object)](Hit_Equals(object).md 'UnrealEngine.Framework.Hit.Equals(object)')

Indicates equality of objects  

***
[Equals(Hit)](Hit_Equals(Hit).md 'UnrealEngine.Framework.Hit.Equals(UnrealEngine.Framework.Hit)')

Indicates equality of objects  

***
[GetActor()](Hit_GetActor().md 'UnrealEngine.Framework.Hit.GetActor()')

Returns the owner actor of the component that was hit or `null` on failure  

***
[GetHashCode()](Hit_GetHashCode().md 'UnrealEngine.Framework.Hit.GetHashCode()')

Returns a hash code for the object  

***
[ToString()](Hit_ToString().md 'UnrealEngine.Framework.Hit.ToString()')

Returns a string that represents this instance  

***
[ToString(IFormatProvider)](Hit_ToString(IFormatProvider).md 'UnrealEngine.Framework.Hit.ToString(System.IFormatProvider)')

Returns a string that represents this instance  
### Operators

***
[operator ==(Hit, Hit)](Hit_operator(Hit_Hit).md 'UnrealEngine.Framework.Hit.op_Equality(UnrealEngine.Framework.Hit, UnrealEngine.Framework.Hit)')

Tests for equality between two objects  

***
[implicit operator string(Hit)](Hit_implicitoperatorstring(Hit).md 'UnrealEngine.Framework.Hit.op_Implicit string(UnrealEngine.Framework.Hit)')

Implicitly casts this instance to a string  

***
[operator !=(Hit, Hit)](Hit_operator!(Hit_Hit).md 'UnrealEngine.Framework.Hit.op_Inequality(UnrealEngine.Framework.Hit, UnrealEngine.Framework.Hit)')

Tests for inequality between two objects  
