using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;

namespace MapboxDirections
{
    public partial interface IMBComponentRepresentable { }

    // @protocol MBComponentRepresentable <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface MBComponentRepresentable : INSSecureCoding
    {
    }

    // @interface MBCoordinateBounds : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBCoordinateBounds
    {
        // -(instancetype _Nonnull)initWithSouthWest:(CLLocationCoordinate2D)southWest northEast:(CLLocationCoordinate2D)northEast __attribute__((objc_designated_initializer));
        [Export("initWithSouthWest:northEast:")]
        [DesignatedInitializer]
        IntPtr MBCoordinateBoundsSouthWestNothEast(CLLocationCoordinate2D southWest, CLLocationCoordinate2D northEast);

        // -(instancetype _Nonnull)initWithNorthWest:(CLLocationCoordinate2D)northWest southEast:(CLLocationCoordinate2D)southEast __attribute__((objc_designated_initializer));
        [Export("initWithNorthWest:southEast:")]
        [DesignatedInitializer]
        IntPtr MBCoordinateBoundsNorthWestSouthEast(CLLocationCoordinate2D northWest, CLLocationCoordinate2D southEast);

        // -(instancetype _Nonnull)initWithCoordinates:(NSArray<NSValue *> * _Nonnull)coordinates;
        [Export("initWithCoordinates:")]
        IntPtr Constructor(NSValue[] coordinates);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBCoordinateBounds New();
    }

    // @interface MBDirections : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDirections: MBOfflineDirectionsProtocol
    {
        // @property (readonly, nonatomic, strong, class) MBDirections * _Nonnull sharedDirections;
        [Static]
        [Export("sharedDirections", ArgumentSemantic.Strong)]
        MBDirections SharedDirections { get; }

        // @property (readonly, copy, nonatomic) NSURL * _Nonnull apiEndpoint;
        [Export("apiEndpoint", ArgumentSemantic.Copy)]
        NSUrl ApiEndpoint { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull accessToken;
        [Export("accessToken")]
        string AccessToken { get; }

        // -(instancetype _Nonnull)initWithAccessToken:(NSString * _Nullable)accessToken host:(NSString * _Nullable)host __attribute__((objc_designated_initializer));
        [Export("initWithAccessToken:host:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string accessToken, [NullAllowed] string host);

        // -(instancetype _Nonnull)initWithAccessToken:(NSString * _Nullable)accessToken;
        [Export("initWithAccessToken:")]
        IntPtr Constructor([NullAllowed] string accessToken);

        // -(NSURLSessionDataTask * _Nonnull)calculateDirectionsWithOptions:(MBRouteOptions * _Nonnull)options completionHandler:(void (^ _Nonnull)(NSArray<MBWaypoint *> * _Nullable, NSArray<MBRoute *> * _Nullable, NSError * _Nullable))completionHandler;
        [Export("calculateDirectionsWithOptions:completionHandler:")]
        NSUrlSessionDataTask CalculateDirectionsWithOptions(MBRouteOptions options, Action<NSArray<MBWaypoint>, MBRoute[], NSError> completionHandler);

        // -(NSURLSessionDataTask * _Nonnull)calculateMatchesWithOptions:(MBMatchOptions * _Nonnull)options completionHandler:(void (^ _Nonnull)(NSArray<MBMatch *> * _Nullable, NSError * _Nullable))completionHandler;
        [Export("calculateMatchesWithOptions:completionHandler:")]
        NSUrlSessionDataTask CalculateMatchesWithOptions(MBMatchOptions options, Action<MBMatch[], NSError> completionHandler);

        // -(NSURLSessionDataTask * _Nonnull)calculateRoutesMatchingOptions:(MBMatchOptions * _Nonnull)options completionHandler:(void (^ _Nonnull)(NSArray<MBWaypoint *> * _Nullable, NSArray<MBRoute *> * _Nullable, NSError * _Nullable))completionHandler;
        [Export("calculateRoutesMatchingOptions:completionHandler:")]
        NSUrlSessionDataTask CalculateRoutesMatchingOptions(MBMatchOptions options, Action<NSArray<MBWaypoint>, MBRoute[], NSError> completionHandler);

        // -(NSURL * _Nonnull)URLForCalculatingDirectionsWithOptions:(MBDirectionsOptions * _Nonnull)options __attribute__((warn_unused_result));
        [Export("URLForCalculatingDirectionsWithOptions:")]
        NSUrl URLForCalculatingDirectionsWithOptions(MBDirectionsOptions options);

        // -(NSURL * _Nonnull)URLForCalculatingDirectionsWithOptions:(MBDirectionsOptions * _Nonnull)options HTTPMethod:(NSString * _Nonnull)httpMethod __attribute__((warn_unused_result));
        [Export("URLForCalculatingDirectionsWithOptions:HTTPMethod:")]
        NSUrl URLForCalculatingDirectionsWithOptions(MBDirectionsOptions options, string httpMethod);

        // -(NSURLRequest * _Nonnull)URLRequestForCalculatingDirectionsWithOptions:(MBDirectionsOptions * _Nonnull)options __attribute__((warn_unused_result));
        [Export("URLRequestForCalculatingDirectionsWithOptions:")]
        NSUrlRequest URLRequestForCalculatingDirectionsWithOptions(MBDirectionsOptions options);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBDirections New();

    }

    // @protocol MBOfflineDirectionsProtocol
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface MBOfflineDirectionsProtocol
    {
        // @required -(NSURLSessionDataTask * _Nonnull)fetchAvailableOfflineVersionsWithCompletionHandler:(void (^ _Nonnull)(NSArray<NSString *> * _Nullable, NSError * _Nullable))completionHandler;
        [Abstract]
        [Export("fetchAvailableOfflineVersionsWithCompletionHandler:")]
        NSUrlSessionDataTask FetchAvailableOfflineVersionsWithCompletionHandler(Action<NSArray<NSString>, NSError> completionHandler);

        // @required -(NSURLSessionDownloadTask * _Nonnull)downloadTilesIn:(MBCoordinateBounds * _Nonnull)coordinateBounds version:(NSString * _Nonnull)version session:(NSURLSession * _Nullable)session completionHandler:(void (^ _Nonnull)(NSURL * _Nullable, NSURLResponse * _Nullable, NSError * _Nullable))completionHandler;
        [Abstract]
        [Export("downloadTilesIn:version:session:completionHandler:")]
        NSUrlSessionDownloadTask DownloadTilesIn(MBCoordinateBounds coordinateBounds, string version, [NullAllowed] NSUrlSession session, Action completionHandler);
    }


    // @interface MBDirectionsOptions : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDirectionsOptions : INSCopying, INSSecureCoding
    {
        // -(instancetype _Nonnull)initWithWaypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier __attribute__((objc_designated_initializer));
        [Export("initWithWaypoints:profileIdentifier:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBWaypoint[] waypoints, [NullAllowed] string profileIdentifier);

        // @property (readonly, nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; }

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);

        // -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result));
        [Export("isEqual:")]
        [Override]
        bool IsEqual([NullAllowed] NSObject @object);

        // -(BOOL)isEqualToDirectionsOptions:(MBDirectionsOptions * _Nullable)directionsOptions __attribute__((warn_unused_result));
        [Export("isEqualToDirectionsOptions:")]
        bool IsEqualToDirectionsOptions([NullAllowed] MBDirectionsOptions directionsOptions);

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        // @property (copy, nonatomic) NSArray<MBWaypoint *> * _Nonnull waypoints;
        [Export("waypoints", ArgumentSemantic.Copy)]
        MBWaypoint[] Waypoints { get; set; }

        // @property (nonatomic) MBDirectionsProfileIdentifier _Nonnull profileIdentifier;
        [Export("profileIdentifier")]
        string ProfileIdentifier { get; set; }

        // @property (nonatomic) BOOL includesSteps;
        [Export("includesSteps")]
        bool IncludesSteps { get; set; }

        // @property (nonatomic) enum MBRouteShapeFormat shapeFormat;
        [Export("shapeFormat", ArgumentSemantic.Assign)]
        MBRouteShapeFormat ShapeFormat { get; set; }

        // @property (nonatomic) enum MBRouteShapeResolution routeShapeResolution;
        [Export("routeShapeResolution", ArgumentSemantic.Assign)]
        MBRouteShapeResolution RouteShapeResolution { get; set; }

        // @property (nonatomic) MBAttributeOptions attributeOptions;
        [Export("attributeOptions", ArgumentSemantic.Assign)]
        MBAttributeOptions AttributeOptions { get; set; }

        // @property (copy, nonatomic) NSLocale * _Nonnull locale;
        [Export("locale", ArgumentSemantic.Copy)]
        NSLocale Locale { get; set; }

        // @property (nonatomic) BOOL includesSpokenInstructions;
        [Export("includesSpokenInstructions")]
        bool IncludesSpokenInstructions { get; set; }

        // @property (nonatomic) enum MBMeasurementSystem distanceMeasurementSystem;
        [Export("distanceMeasurementSystem", ArgumentSemantic.Assign)]
        MBMeasurementSystem DistanceMeasurementSystem { get; set; }

        // @property (nonatomic) BOOL includesVisualInstructions;
        [Export("includesVisualInstructions")]
        bool IncludesVisualInstructions { get; set; }

        // @property (readonly, copy, nonatomic) NSArray<NSURLQueryItem *> * _Nonnull URLQueryItems;
        [Export("URLQueryItems", ArgumentSemantic.Copy)]
        NSUrlQueryItem[] URLQueryItems { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBDirectionsOptions New();
    }

    // @interface MBDirectionsResult : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDirectionsResult : INSSecureCoding
    {
        // @property (readonly, nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; }

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        // @property (readonly, copy, nonatomic) NSArray<NSValue *> * _Nullable coordinates;
        [NullAllowed, Export("coordinates", ArgumentSemantic.Copy)]
        NSValue[] Coordinates { get; }

        // @property (readonly, nonatomic) NSUInteger coordinateCount;
        [Export("coordinateCount")]
        nuint CoordinateCount { get; }

        // -(void)getCoordinates:(CLLocationCoordinate2D * _Nonnull)coordinates;
        [Export("getCoordinates:")]
        unsafe void GetCoordinates(CLLocationCoordinate2D coordinates);

        // @property (readonly, copy, nonatomic) NSArray<MBRouteLeg *> * _Nonnull legs;
        [Export("legs", ArgumentSemantic.Copy)]
        MBRouteLeg[] Legs { get; }

        // @property (readonly, nonatomic) CLLocationDistance distance;
        [Export("distance")]
        double Distance { get; }

        // @property (readonly, nonatomic) NSTimeInterval expectedTravelTime;
        [Export("expectedTravelTime")]
        double ExpectedTravelTime { get; }

        // @property (readonly, nonatomic, strong) MBDirectionsOptions * _Nonnull directionsOptions;
        [Export("directionsOptions", ArgumentSemantic.Strong)]
        MBDirectionsOptions DirectionsOptions { get; }

        // @property (copy, nonatomic) NSString * _Nullable accessToken;
        [NullAllowed, Export("accessToken")]
        string AccessToken { get; set; }

        // @property (copy, nonatomic) NSURL * _Nullable apiEndpoint;
        [NullAllowed, Export("apiEndpoint", ArgumentSemantic.Copy)]
        NSUrl ApiEndpoint { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable routeIdentifier;
        [NullAllowed, Export("routeIdentifier")]
        string RouteIdentifier { get; set; }

        // @property (copy, nonatomic) NSLocale * _Nullable speechLocale;
        [NullAllowed, Export("speechLocale", ArgumentSemantic.Copy)]
        NSLocale SpeechLocale { get; set; }

        // @property (copy, nonatomic) NSDate * _Nullable fetchStartDate;
        [NullAllowed, Export("fetchStartDate", ArgumentSemantic.Copy)]
        NSDate FetchStartDate { get; set; }

        // @property (copy, nonatomic) NSDate * _Nullable responseEndDate;
        [NullAllowed, Export("responseEndDate", ArgumentSemantic.Copy)]
        NSDate ResponseEndDate { get; set; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBDirectionsResult New();
    }

    // @interface MBIntersection : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBIntersection : INSSecureCoding
    {
        // @property (readonly, nonatomic) CLLocationCoordinate2D location;
        [Export("location")]
        CLLocationCoordinate2D Location { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nonnull headings;
        [Export("headings", ArgumentSemantic.Copy)]
        NSNumber[] Headings { get; }

        // @property (readonly, copy, nonatomic) NSIndexSet * _Nonnull outletIndexes;
        [Export("outletIndexes", ArgumentSemantic.Copy)]
        NSIndexSet OutletIndexes { get; }

        // @property (readonly, nonatomic) NSInteger approachIndex;
        [Export("approachIndex")]
        nint ApproachIndex { get; }

        // @property (readonly, nonatomic) NSInteger outletIndex;
        [Export("outletIndex")]
        nint OutletIndex { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBLane *> * _Nullable approachLanes;
        [NullAllowed, Export("approachLanes", ArgumentSemantic.Copy)]
        MBLane[] ApproachLanes { get; }

        // @property (readonly, copy, nonatomic) NSIndexSet * _Nullable usableApproachLanes;
        [NullAllowed, Export("usableApproachLanes", ArgumentSemantic.Copy)]
        NSIndexSet UsableApproachLanes { get; }

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBIntersection New();
    }

    // @interface MBLane : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBLane : INSSecureCoding
    {
        // @property (readonly, nonatomic) MBLaneIndication indications;
        [Export("indications")]
        MBLaneIndication Indications { get; }

        // -(instancetype _Nonnull)initWithIndications:(MBLaneIndication)indications __attribute__((objc_designated_initializer));
        [Export("initWithIndications:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBLaneIndication indications);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBLane New();
    }

    // @interface MBLaneIndicationComponent : NSObject <MBComponentRepresentable>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBLaneIndicationComponent : MBComponentRepresentable
    {
        // @property (nonatomic) MBLaneIndication indications;
        [Export("indications", ArgumentSemantic.Assign)]
        MBLaneIndication Indications { get; set; }

        // @property (nonatomic) BOOL isUsable;
        [Export("isUsable")]
        bool IsUsable { get; set; }

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        // -(instancetype _Nonnull)initWithIndications:(MBLaneIndication)indications isUsable:(BOOL)isUsable __attribute__((objc_designated_initializer));
        [Export("initWithIndications:isUsable:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBLaneIndication indications, bool isUsable);

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBLaneIndicationComponent New();
    }

    // @interface MBMatch : MBDirectionsResult
    [BaseType(typeof(MBDirectionsResult))]
    interface MBMatch
    {
        // -(instancetype _Nonnull)initWithJSON:(NSDictionary<NSString *,id> * _Nonnull)json tracepoints:(NSArray<MBTracepoint *> * _Nonnull)tracepoints waypointIndices:(NSIndexSet * _Nonnull)waypointIndices matchOptions:(MBMatchOptions * _Nonnull)matchOptions;
        [Export("initWithJSON:tracepoints:waypointIndices:matchOptions:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json, MBTracepoint[] tracepoints, NSIndexSet waypointIndices, MBMatchOptions matchOptions);

        // @property (nonatomic) float confidence;
        [Export("confidence")]
        float Confidence { get; set; }

        // @property (copy, nonatomic) NSArray<MBTracepoint *> * _Nonnull tracepoints;
        [Export("tracepoints", ArgumentSemantic.Copy)]
        MBTracepoint[] Tracepoints { get; set; }

        // @property (copy, nonatomic) NSIndexSet * _Nullable waypointIndices;
        [NullAllowed, Export("waypointIndices", ArgumentSemantic.Copy)]
        NSIndexSet WaypointIndices { get; set; }

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //[Override]
        //void EncodeWithCoder(NSCoder coder);

        // -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result));
        [Export("isEqual:")]
        [Override]
        bool IsEqual([NullAllowed] NSObject @object);

        // -(BOOL)isEqualToMatch:(MBMatch * _Nullable)match __attribute__((warn_unused_result));
        [Export("isEqualToMatch:")]
        bool IsEqualToMatch([NullAllowed] MBMatch match);
    }

    // @interface MBMatchOptions : MBDirectionsOptions
    [BaseType(typeof(MBDirectionsOptions))]
    interface MBMatchOptions
    {
        // -(instancetype _Nonnull)initWithLocations:(NSArray<CLLocation *> * _Nonnull)locations profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier;
        [Export("initWithLocations:profileIdentifier:")]
        IntPtr Constructor(CLLocation[] locations, [NullAllowed] string profileIdentifier);

        // -(instancetype _Nonnull)initWithCoordinates:(NSArray<NSValue *> * _Nonnull)coordinates profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier;
        [Export("initWithCoordinates:profileIdentifier:")]
        IntPtr Constructor(NSValue[] coordinates, [NullAllowed] string profileIdentifier);

        // -(instancetype _Nonnull)initWithWaypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier __attribute__((objc_designated_initializer));
        [Export("initWithWaypoints:profileIdentifier:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBWaypoint[] waypoints, [NullAllowed] string profileIdentifier);

        // @property (nonatomic) BOOL resamplesTraces;
        [Export("resamplesTraces")]
        bool ResamplesTraces { get; set; }

        // @property (copy, nonatomic) NSIndexSet * _Nullable waypointIndices __attribute__((deprecated("Use Waypoint.separatesLegs instead.")));
        [NullAllowed, Export("waypointIndices", ArgumentSemantic.Copy)]
        NSIndexSet WaypointIndices { get; set; }

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //[Override]
        //void EncodeWithCoder(NSCoder coder);
    }

    // @interface MBRoute : MBDirectionsResult
    [BaseType(typeof(MBDirectionsResult))]
    interface MBRoute
    {
        // -(instancetype _Nonnull)initWithJSON:(NSDictionary<NSString *,id> * _Nonnull)json waypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints routeOptions:(MBRouteOptions * _Nonnull)options __attribute__((objc_designated_initializer));
        [Export("initWithJSON:waypoints:routeOptions:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json, MBWaypoint[] waypoints, MBRouteOptions options);
    }

    // @interface MBRouteLeg : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRouteLeg : INSSecureCoding
    {
        // -(instancetype _Nonnull)initWithJSON:(NSDictionary<NSString *,id> * _Nonnull)json source:(MBWaypoint * _Nonnull)source destination:(MBWaypoint * _Nonnull)destination options:(MBRouteOptions * _Nonnull)options;
        [Export("initWithJSON:source:destination:options:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json, MBWaypoint source, MBWaypoint destination, MBRouteOptions options);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        // @property (readonly, nonatomic, strong) MBWaypoint * _Nonnull source;
        [Export("source", ArgumentSemantic.Strong)]
        MBWaypoint Source { get; }

        // @property (readonly, nonatomic, strong) MBWaypoint * _Nonnull destination;
        [Export("destination", ArgumentSemantic.Strong)]
        MBWaypoint Destination { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBRouteStep *> * _Nonnull steps;
        [Export("steps", ArgumentSemantic.Copy)]
        MBRouteStep[] Steps { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable segmentDistances;
        [NullAllowed, Export("segmentDistances", ArgumentSemantic.Copy)]
        NSNumber[] SegmentDistances { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable expectedSegmentTravelTimes;
        [NullAllowed, Export("expectedSegmentTravelTimes", ArgumentSemantic.Copy)]
        NSNumber[] ExpectedSegmentTravelTimes { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable segmentSpeeds;
        [NullAllowed, Export("segmentSpeeds", ArgumentSemantic.Copy)]
        NSNumber[] SegmentSpeeds { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) CLLocationDistance distance;
        [Export("distance")]
        double Distance { get; }

        // @property (readonly, nonatomic) NSTimeInterval expectedTravelTime;
        [Export("expectedTravelTime")]
        double ExpectedTravelTime { get; }

        // @property (readonly, nonatomic) MBDirectionsProfileIdentifier _Nonnull profileIdentifier;
        [Export("profileIdentifier")]
        string ProfileIdentifier { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBRouteLeg New();
    }

    // @interface MBRouteOptions : MBDirectionsOptions
    [BaseType(typeof(MBDirectionsOptions))]
    interface MBRouteOptions
    {
        // -(instancetype _Nonnull)initWithLocations:(NSArray<CLLocation *> * _Nonnull)locations profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier;
        [Export("initWithLocations:profileIdentifier:")]
        IntPtr Constructor(CLLocation[] locations, [NullAllowed] string profileIdentifier);

        // -(instancetype _Nonnull)initWithCoordinates:(NSArray<NSValue *> * _Nonnull)coordinates profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier;
        [Export("initWithCoordinates:profileIdentifier:")]
        IntPtr Constructor(NSValue[] coordinates, [NullAllowed] string profileIdentifier);

        // -(instancetype _Nonnull)initWithWaypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier __attribute__((objc_designated_initializer));
        [Export("initWithWaypoints:profileIdentifier:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBWaypoint[] waypoints, [NullAllowed] string profileIdentifier);

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //[Override]
        //void EncodeWithCoder(NSCoder coder);

        // @property (nonatomic) BOOL allowsUTurnAtWaypoint;
        [Export("allowsUTurnAtWaypoint")]
        bool AllowsUTurnAtWaypoint { get; set; }

        // @property (nonatomic) BOOL includesAlternativeRoutes;
        [Export("includesAlternativeRoutes")]
        bool IncludesAlternativeRoutes { get; set; }

        // @property (nonatomic) BOOL includesExitRoundaboutManeuver;
        [Export("includesExitRoundaboutManeuver")]
        bool IncludesExitRoundaboutManeuver { get; set; }

        // @property (nonatomic) MBRoadClasses roadClassesToAvoid;
        [Export("roadClassesToAvoid", ArgumentSemantic.Assign)]
        MBRoadClasses RoadClassesToAvoid { get; set; }

        // @property (nonatomic) MBDirectionsPriority alleyPriority;
        [Export("alleyPriority")]
        double AlleyPriority { get; set; }

        // @property (nonatomic) MBDirectionsPriority walkwayPriority;
        [Export("walkwayPriority")]
        double WalkwayPriority { get; set; }

        // @property (nonatomic) CLLocationSpeed speed;
        [Export("speed")]
        double Speed { get; set; }

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
        //[Export("copyWithZone:")]
        //[Override]
        //unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);

        // -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result));
        [Export("isEqual:")]
        [Override]
        bool IsEqual([NullAllowed] NSObject @object);

        // -(BOOL)isEqualToRouteOptions:(MBRouteOptions * _Nullable)routeOptions __attribute__((warn_unused_result));
        [Export("isEqualToRouteOptions:")]
        bool IsEqualToRouteOptions([NullAllowed] MBRouteOptions routeOptions);
    }

    // @interface MBRouteOptionsV4 : MBRouteOptions
    [BaseType(typeof(MBRouteOptions))]
    interface MBRouteOptionsV4
    {
        // @property (nonatomic) enum MBInstructionFormat instructionFormat;
        [Export("instructionFormat", ArgumentSemantic.Assign)]
        MBInstructionFormat InstructionFormat { get; set; }

        // @property (nonatomic) BOOL includesShapes;
        [Export("includesShapes")]
        bool IncludesShapes { get; set; }

        // -(instancetype _Nonnull)initWithWaypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier __attribute__((objc_designated_initializer));
        [Export("initWithWaypoints:profileIdentifier:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBWaypoint[] waypoints, [NullAllowed] string profileIdentifier);

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //[Override]
        //void EncodeWithCoder(NSCoder coder);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
        //[Export("copyWithZone:")]
        //[Override]
        //unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
    }

    // @interface MBRouteStep : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRouteStep : INSSecureCoding
    {
        // -(instancetype _Nonnull)initWithJSON:(NSDictionary<NSString *,id> * _Nonnull)json options:(MBRouteOptions * _Nonnull)options;
        [Export("initWithJSON:options:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json, MBRouteOptions options);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        // @property (readonly, copy, nonatomic) NSArray<NSValue *> * _Nullable coordinates;
        [NullAllowed, Export("coordinates", ArgumentSemantic.Copy)]
        NSValue[] Coordinates { get; }

        // @property (readonly, nonatomic) NSUInteger coordinateCount;
        [Export("coordinateCount")]
        nuint CoordinateCount { get; }

        // -(BOOL)getCoordinates:(CLLocationCoordinate2D * _Nonnull)coordinates __attribute__((warn_unused_result));
        [Export("getCoordinates:")]
        unsafe bool GetCoordinates(CLLocationCoordinate2D coordinates);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull instructions;
        [Export("instructions")]
        string Instructions { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBSpokenInstruction *> * _Nullable instructionsSpokenAlongStep;
        [NullAllowed, Export("instructionsSpokenAlongStep", ArgumentSemantic.Copy)]
        MBSpokenInstruction[] InstructionsSpokenAlongStep { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBVisualInstructionBanner *> * _Nullable instructionsDisplayedAlongStep;
        [NullAllowed, Export("instructionsDisplayedAlongStep", ArgumentSemantic.Copy)]
        MBVisualInstructionBanner[] InstructionsDisplayedAlongStep { get; }

        // @property (readonly, nonatomic) enum MBManeuverType maneuverType;
        [Export("maneuverType")]
        MBManeuverType ManeuverType { get; }

        // @property (readonly, nonatomic) enum MBManeuverDirection maneuverDirection;
        [Export("maneuverDirection")]
        MBManeuverDirection ManeuverDirection { get; }

        // @property (readonly, nonatomic) CLLocationCoordinate2D maneuverLocation;
        [Export("maneuverLocation")]
        CLLocationCoordinate2D ManeuverLocation { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable exitCodes;
        [NullAllowed, Export("exitCodes", ArgumentSemantic.Copy)]
        string[] ExitCodes { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable exitNames;
        [NullAllowed, Export("exitNames", ArgumentSemantic.Copy)]
        string[] ExitNames { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable phoneticExitNames;
        [NullAllowed, Export("phoneticExitNames", ArgumentSemantic.Copy)]
        string[] PhoneticExitNames { get; }

        // @property (readonly, nonatomic) CLLocationDistance distance;
        [Export("distance")]
        double Distance { get; }

        // @property (readonly, nonatomic) NSTimeInterval expectedTravelTime;
        [Export("expectedTravelTime")]
        double ExpectedTravelTime { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable names;
        [NullAllowed, Export("names", ArgumentSemantic.Copy)]
        string[] Names { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable phoneticNames;
        [NullAllowed, Export("phoneticNames", ArgumentSemantic.Copy)]
        string[] PhoneticNames { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable codes;
        [NullAllowed, Export("codes", ArgumentSemantic.Copy)]
        string[] Codes { get; }

        // @property (readonly, nonatomic) enum MBTransportType transportType;
        [Export("transportType")]
        MBTransportType TransportType { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable destinationCodes;
        [NullAllowed, Export("destinationCodes", ArgumentSemantic.Copy)]
        string[] DestinationCodes { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable destinations;
        [NullAllowed, Export("destinations", ArgumentSemantic.Copy)]
        string[] Destinations { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBIntersection *> * _Nullable intersections;
        [NullAllowed, Export("intersections", ArgumentSemantic.Copy)]
        MBIntersection[] Intersections { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBRouteStep New();
    }

    // @interface MBSpokenInstruction : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBSpokenInstruction : INSSecureCoding
    {
        // @property (readonly, nonatomic) CLLocationDistance distanceAlongStep;
        [Export("distanceAlongStep")]
        double DistanceAlongStep { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull text;
        [Export("text")]
        string Text { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull ssmlText;
        [Export("ssmlText")]
        string SsmlText { get; }

        // -(instancetype _Nonnull)initWithJSON:(NSDictionary<NSString *,id> * _Nonnull)json;
        [Export("initWithJSON:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json);

        // -(instancetype _Nonnull)initWithDistanceAlongStep:(CLLocationDistance)distanceAlongStep text:(NSString * _Nonnull)text ssmlText:(NSString * _Nonnull)ssmlText __attribute__((objc_designated_initializer));
        [Export("initWithDistanceAlongStep:text:ssmlText:")]
        [DesignatedInitializer]
        IntPtr Constructor(double distanceAlongStep, string text, string ssmlText);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBSpokenInstruction New();
    }

    // @interface MBWaypoint : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBWaypoint : INSCopying, INSSecureCoding
    {
        // @property (readonly, nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; }

        // -(instancetype _Nonnull)initWithCoordinate:(CLLocationCoordinate2D)coordinate coordinateAccuracy:(CLLocationAccuracy)coordinateAccuracy name:(NSString * _Nullable)name __attribute__((objc_designated_initializer));
        [Export("initWithCoordinate:coordinateAccuracy:name:")]
        [DesignatedInitializer]
        IntPtr Constructor(CLLocationCoordinate2D coordinate, double coordinateAccuracy, [NullAllowed] string name);

        // -(instancetype _Nonnull)initWithLocation:(CLLocation * _Nonnull)location heading:(CLHeading * _Nullable)heading name:(NSString * _Nullable)name __attribute__((objc_designated_initializer));
        [Export("initWithLocation:heading:name:")]
        [DesignatedInitializer]
        IntPtr Constructor(CLLocation location, [NullAllowed] CLHeading heading, [NullAllowed] string name);

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        //// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
        //[Export("copyWithZone:")]
        //unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);

        // -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result));
        [Export("isEqual:")]
        [Override]
        bool IsEqual([NullAllowed] NSObject @object);

        // -(BOOL)isEqualToWaypoint:(MBWaypoint * _Nullable)other __attribute__((warn_unused_result));
        [Export("isEqualToWaypoint:")]
        bool IsEqualToWaypoint([NullAllowed] MBWaypoint other);

        // @property (readonly, nonatomic) CLLocationCoordinate2D coordinate;
        [Export("coordinate")]
        CLLocationCoordinate2D Coordinate { get; }

        // @property (nonatomic) CLLocationAccuracy coordinateAccuracy;
        [Export("coordinateAccuracy")]
        double CoordinateAccuracy { get; set; }

        // @property (nonatomic) CLLocationCoordinate2D targetCoordinate;
        [Export("targetCoordinate", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D TargetCoordinate { get; set; }

        // @property (nonatomic) CLLocationDirection heading;
        [Export("heading")]
        double Heading { get; set; }

        // @property (nonatomic) CLLocationDirection headingAccuracy;
        [Export("headingAccuracy")]
        double HeadingAccuracy { get; set; }

        // @property (nonatomic) BOOL allowsArrivingOnOppositeSide;
        [Export("allowsArrivingOnOppositeSide")]
        bool AllowsArrivingOnOppositeSide { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export("name")]
        string Name { get; set; }

        // @property (nonatomic) BOOL separatesLegs;
        [Export("separatesLegs")]
        bool SeparatesLegs { get; set; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBWaypoint New();
    }

    // @interface MBTracepoint : MBWaypoint
    [BaseType(typeof(MBWaypoint))]
    interface MBTracepoint
    {
        // @property (nonatomic) NSInteger alternateCount;
        [Export("alternateCount")]
        nint AlternateCount { get; set; }

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //[Override]
        //void EncodeWithCoder(NSCoder coder);

        // -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result));
        [Export("isEqual:")]
        [Override]
        bool IsEqual([NullAllowed] NSObject @object);

        // -(BOOL)isEqualToTracepoint:(MBTracepoint * _Nullable)other __attribute__((warn_unused_result));
        [Export("isEqualToTracepoint:")]
        bool IsEqualToTracepoint([NullAllowed] MBTracepoint other);
    }

    // @interface MBVisualInstruction : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBVisualInstruction : INSSecureCoding
    {
        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable text;
        [NullAllowed, Export("text")]
        string Text { get; }

        // @property (nonatomic) enum MBManeuverType maneuverType;
        [Export("maneuverType", ArgumentSemantic.Assign)]
        MBManeuverType ManeuverType { get; set; }

        // @property (nonatomic) enum MBManeuverDirection maneuverDirection;
        [Export("maneuverDirection", ArgumentSemantic.Assign)]
        MBManeuverDirection ManeuverDirection { get; set; }

        // @property (readonly, copy, nonatomic) NSArray<id<MBComponentRepresentable>> * _Nonnull components;
        [Export("components", ArgumentSemantic.Copy)]
        IMBComponentRepresentable[] Components { get; }

        // @property (nonatomic) CLLocationDegrees finalHeading;
        [Export("finalHeading")]
        double FinalHeading { get; set; }

        // -(instancetype _Nonnull)initWithText:(NSString * _Nullable)text maneuverType:(enum MBManeuverType)maneuverType maneuverDirection:(enum MBManeuverDirection)maneuverDirection components:(NSArray<id<MBComponentRepresentable>> * _Nonnull)components degrees:(CLLocationDegrees)degrees __attribute__((objc_designated_initializer));
        [Export("initWithText:maneuverType:maneuverDirection:components:degrees:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string text, MBManeuverType maneuverType, MBManeuverDirection maneuverDirection, MBComponentRepresentable[] components, double degrees);

        // -(instancetype _Nonnull)initWithJSON:(NSDictionary<NSString *,id> * _Nonnull)json;
        [Export("initWithJSON:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json);

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        ////[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBVisualInstruction New();
    }

    // @interface MBVisualInstructionBanner : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBVisualInstructionBanner : INSSecureCoding
    {
        // @property (readonly, nonatomic) CLLocationDistance distanceAlongStep;
        [Export("distanceAlongStep")]
        double DistanceAlongStep { get; }

        // @property (readonly, nonatomic, strong) MBVisualInstruction * _Nonnull primaryInstruction;
        [Export("primaryInstruction", ArgumentSemantic.Strong)]
        MBVisualInstruction PrimaryInstruction { get; }

        // @property (readonly, nonatomic, strong) MBVisualInstruction * _Nullable secondaryInstruction;
        [NullAllowed, Export("secondaryInstruction", ArgumentSemantic.Strong)]
        MBVisualInstruction SecondaryInstruction { get; }

        // @property (readonly, nonatomic, strong) MBVisualInstruction * _Nullable tertiaryInstruction;
        [NullAllowed, Export("tertiaryInstruction", ArgumentSemantic.Strong)]
        MBVisualInstruction TertiaryInstruction { get; }

        // @property (nonatomic) enum MBDrivingSide drivingSide;
        [Export("drivingSide", ArgumentSemantic.Assign)]
        MBDrivingSide DrivingSide { get; set; }

        // -(instancetype _Nonnull)initWithJSON:(NSDictionary<NSString *,id> * _Nonnull)json drivingSide:(enum MBDrivingSide)drivingSide;
        [Export("initWithJSON:drivingSide:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json, MBDrivingSide drivingSide);

        // -(instancetype _Nonnull)initWithDistanceAlongStep:(CLLocationDistance)distanceAlongStep primaryInstruction:(MBVisualInstruction * _Nonnull)primaryInstruction secondaryInstruction:(MBVisualInstruction * _Nullable)secondaryInstruction tertiaryInstruction:(MBVisualInstruction * _Nullable)tertiaryInstruction drivingSide:(enum MBDrivingSide)drivingSide __attribute__((objc_designated_initializer));
        [Export("initWithDistanceAlongStep:primaryInstruction:secondaryInstruction:tertiaryInstruction:drivingSide:")]
        [DesignatedInitializer]
        IntPtr Constructor(double distanceAlongStep, MBVisualInstruction primaryInstruction, [NullAllowed] MBVisualInstruction secondaryInstruction, [NullAllowed] MBVisualInstruction tertiaryInstruction, MBDrivingSide drivingSide);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBVisualInstructionBanner New();
    }

    // @interface MBVisualInstructionComponent : NSObject <MBComponentRepresentable>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBVisualInstructionComponent : MBComponentRepresentable
    {
        // @property (copy, nonatomic) NSURL * _Nullable imageURL;
        [NullAllowed, Export("imageURL", ArgumentSemantic.Copy)]
        NSUrl ImageURL { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable abbreviation;
        [NullAllowed, Export("abbreviation")]
        string Abbreviation { get; set; }

        // @property (nonatomic) NSInteger abbreviationPriority;
        [Export("abbreviationPriority")]
        nint AbbreviationPriority { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable text;
        [NullAllowed, Export("text")]
        string Text { get; set; }

        // @property (nonatomic) enum MBVisualInstructionComponentType type;
        [Export("type", ArgumentSemantic.Assign)]
        MBVisualInstructionComponentType Type { get; set; }

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        // -(instancetype _Nonnull)initWithJSON:(NSDictionary<NSString *,id> * _Nonnull)json;
        [Export("initWithJSON:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json);

        // -(instancetype _Nonnull)initWithType:(enum MBVisualInstructionComponentType)type text:(NSString * _Nullable)text imageURL:(NSURL * _Nullable)imageURL abbreviation:(NSString * _Nullable)abbreviation abbreviationPriority:(NSInteger)abbreviationPriority __attribute__((objc_designated_initializer));
        [Export("initWithType:text:imageURL:abbreviation:abbreviationPriority:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBVisualInstructionComponentType type, [NullAllowed] string text, [NullAllowed] NSUrl imageURL, [NullAllowed] string abbreviation, nint abbreviationPriority);

        //// -(void)encodeWithCoder:(NSCoder * _Nonnull)coder;
        //[Export("encodeWithCoder:")]
        //void EncodeWithCoder(NSCoder coder);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBVisualInstructionComponent New();
    }

}

