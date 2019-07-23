using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;

namespace MapboxNavigationNative
{
    

    // @interface MBFixLocation : NSObject
    [BaseType(typeof(NSObject))]
    interface MBFixLocation
    {
        // -(instancetype _Nonnull)initWithCoordinate:(CLLocationCoordinate2D)coordinate time:(NSDate * _Nonnull)time speed:(NSNumber * _Nullable)speed bearing:(NSNumber * _Nullable)bearing altitude:(NSNumber * _Nullable)altitude accuracyHorizontal:(NSNumber * _Nullable)accuracyHorizontal provider:(NSString * _Nullable)provider;
        [Export("initWithCoordinate:time:speed:bearing:altitude:accuracyHorizontal:provider:")]
        IntPtr Constructor(CLLocationCoordinate2D coordinate, NSDate time, [NullAllowed] NSNumber speed, [NullAllowed] NSNumber bearing, [NullAllowed] NSNumber altitude, [NullAllowed] NSNumber accuracyHorizontal, [NullAllowed] string provider);

        // @property (readonly, nonatomic) CLLocationCoordinate2D coordinate;
        [Export("coordinate")]
        CLLocationCoordinate2D Coordinate { get; }

        // @property (readonly, nonatomic) NSDate * _Nonnull time;
        [Export("time")]
        NSDate Time { get; }

        // @property (readonly, nonatomic) NSNumber * _Nullable speed;
        [NullAllowed, Export("speed")]
        NSNumber Speed { get; }

        // @property (readonly, nonatomic) NSNumber * _Nullable bearing;
        [NullAllowed, Export("bearing")]
        NSNumber Bearing { get; }

        // @property (readonly, nonatomic) NSNumber * _Nullable altitude;
        [NullAllowed, Export("altitude")]
        NSNumber Altitude { get; }

        // @property (readonly, nonatomic) NSNumber * _Nullable accuracyHorizontal;
        [NullAllowed, Export("accuracyHorizontal")]
        NSNumber AccuracyHorizontal { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable provider;
        [NullAllowed, Export("provider")]
        string Provider { get; }
    }

    // @interface MBVoiceInstruction : NSObject
    [BaseType(typeof(NSObject))]
    interface MBVoiceInstruction
    {
        // -(instancetype _Nonnull)initWithSsmlAnnouncement:(NSString * _Nonnull)ssmlAnnouncement announcement:(NSString * _Nonnull)announcement remainingStepDistance:(float)remainingStepDistance index:(uint32_t)index;
        [Export("initWithSsmlAnnouncement:announcement:remainingStepDistance:index:")]
        IntPtr Constructor(string ssmlAnnouncement, string announcement, float remainingStepDistance, uint index);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull ssmlAnnouncement;
        [Export("ssmlAnnouncement")]
        string SsmlAnnouncement { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull announcement;
        [Export("announcement")]
        string Announcement { get; }

        // @property (readonly, nonatomic) float remainingStepDistance;
        [Export("remainingStepDistance")]
        float RemainingStepDistance { get; }

        // @property (readonly, nonatomic) uint32_t index;
        [Export("index")]
        uint Index { get; }
    }

    // @interface MBBannerComponent : NSObject
    [BaseType(typeof(NSObject))]
    interface MBBannerComponent
    {
        // -(instancetype _Nonnull)initWithType:(NSString * _Nonnull)type text:(NSString * _Nonnull)text abbr:(NSString * _Nullable)abbr abbrPriority:(NSNumber * _Nullable)abbrPriority imageBaseurl:(NSString * _Nullable)imageBaseurl active:(NSNumber * _Nullable)active directions:(NSArray<NSString *> * _Nullable)directions;
        [Export("initWithType:text:abbr:abbrPriority:imageBaseurl:active:directions:")]
        IntPtr Constructor(string type, string text, [NullAllowed] string abbr, [NullAllowed] NSNumber abbrPriority, [NullAllowed] string imageBaseurl, [NullAllowed] NSNumber active, [NullAllowed] string[] directions);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull type;
        [Export("type")]
        string Type { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull text;
        [Export("text")]
        string Text { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable abbr;
        [NullAllowed, Export("abbr")]
        string Abbr { get; }

        // @property (readonly, nonatomic) NSNumber * _Nullable abbrPriority;
        [NullAllowed, Export("abbrPriority")]
        NSNumber AbbrPriority { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable imageBaseurl;
        [NullAllowed, Export("imageBaseurl")]
        string ImageBaseurl { get; }

        // @property (readonly, nonatomic) NSNumber * _Nullable active;
        [NullAllowed, Export("active")]
        NSNumber Active { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable directions;
        [NullAllowed, Export("directions", ArgumentSemantic.Copy)]
        string[] Directions { get; }
    }

    // @interface MBBannerSection : NSObject
    [BaseType(typeof(NSObject))]
    interface MBBannerSection
    {
        // -(instancetype _Nonnull)initWithText:(NSString * _Nonnull)text type:(NSString * _Nullable)type modifier:(NSString * _Nullable)modifier degrees:(NSNumber * _Nullable)degrees drivingSide:(NSString * _Nullable)drivingSide components:(NSArray<MBBannerComponent *> * _Nullable)components;
        [Export("initWithText:type:modifier:degrees:drivingSide:components:")]
        IntPtr Constructor(string text, [NullAllowed] string type, [NullAllowed] string modifier, [NullAllowed] NSNumber degrees, [NullAllowed] string drivingSide, [NullAllowed] MBBannerComponent[] components);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull text;
        [Export("text")]
        string Text { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable type;
        [NullAllowed, Export("type")]
        string Type { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable modifier;
        [NullAllowed, Export("modifier")]
        string Modifier { get; }

        // @property (readonly, nonatomic) NSNumber * _Nullable degrees;
        [NullAllowed, Export("degrees")]
        NSNumber Degrees { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable drivingSide;
        [NullAllowed, Export("drivingSide")]
        string DrivingSide { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBBannerComponent *> * _Nullable components;
        [NullAllowed, Export("components", ArgumentSemantic.Copy)]
        MBBannerComponent[] Components { get; }
    }

    // @interface MBBannerInstruction : NSObject
    [BaseType(typeof(NSObject))]
    interface MBBannerInstruction
    {
        // -(instancetype _Nonnull)initWithPrimary:(MBBannerSection * _Nonnull)primary secondary:(MBBannerSection * _Nullable)secondary sub:(MBBannerSection * _Nullable)sub remainingStepDistance:(float)remainingStepDistance index:(uint32_t)index;
        [Export("initWithPrimary:secondary:sub:remainingStepDistance:index:")]
        IntPtr Constructor(MBBannerSection primary, [NullAllowed] MBBannerSection secondary, [NullAllowed] MBBannerSection sub, float remainingStepDistance, uint index);

        // @property (readonly, nonatomic) MBBannerSection * _Nonnull primary;
        [Export("primary")]
        MBBannerSection Primary { get; }

        // @property (readonly, nonatomic) MBBannerSection * _Nullable secondary;
        [NullAllowed, Export("secondary")]
        MBBannerSection Secondary { get; }

        // @property (readonly, nonatomic) MBBannerSection * _Nullable sub;
        [NullAllowed, Export("sub")]
        MBBannerSection Sub { get; }

        // @property (readonly, nonatomic) float remainingStepDistance;
        [Export("remainingStepDistance")]
        float RemainingStepDistance { get; }

        // @property (readonly, nonatomic) uint32_t index;
        [Export("index")]
        uint Index { get; }
    }

    // @interface MBNavigationStatus : NSObject
    [BaseType(typeof(NSObject))]
    interface MBNavigationStatus
    {
        // -(instancetype _Nonnull)initWithRouteState:(MBRouteState)routeState location:(MBFixLocation * _Nonnull)location routeIndex:(uint32_t)routeIndex legIndex:(uint32_t)legIndex remainingLegDistance:(float)remainingLegDistance remainingLegDuration:(NSTimeInterval)remainingLegDuration stepIndex:(uint32_t)stepIndex remainingStepDistance:(float)remainingStepDistance remainingStepDuration:(NSTimeInterval)remainingStepDuration voiceInstruction:(MBVoiceInstruction * _Nullable)voiceInstruction bannerInstruction:(MBBannerInstruction * _Nullable)bannerInstruction stateMessage:(NSString * _Nonnull)stateMessage inTunnel:(BOOL)inTunnel predicted:(NSTimeInterval)predicted shapeIndex:(uint32_t)shapeIndex intersectionIndex:(uint32_t)intersectionIndex;
        [Export("initWithRouteState:location:routeIndex:legIndex:remainingLegDistance:remainingLegDuration:stepIndex:remainingStepDistance:remainingStepDuration:voiceInstruction:bannerInstruction:stateMessage:inTunnel:predicted:shapeIndex:intersectionIndex:")]
        IntPtr Constructor(MBRouteState routeState, MBFixLocation location, uint routeIndex, uint legIndex, float remainingLegDistance, double remainingLegDuration, uint stepIndex, float remainingStepDistance, double remainingStepDuration, [NullAllowed] MBVoiceInstruction voiceInstruction, [NullAllowed] MBBannerInstruction bannerInstruction, string stateMessage, bool inTunnel, double predicted, uint shapeIndex, uint intersectionIndex);

        // @property (readonly, nonatomic) MBRouteState routeState;
        [Export("routeState")]
        MBRouteState RouteState { get; }

        // @property (readonly, nonatomic) MBFixLocation * _Nonnull location;
        [Export("location")]
        MBFixLocation Location { get; }

        // @property (readonly, nonatomic) uint32_t routeIndex;
        [Export("routeIndex")]
        uint RouteIndex { get; }

        // @property (readonly, nonatomic) uint32_t legIndex;
        [Export("legIndex")]
        uint LegIndex { get; }

        // @property (readonly, nonatomic) float remainingLegDistance;
        [Export("remainingLegDistance")]
        float RemainingLegDistance { get; }

        // @property (readonly, nonatomic) NSTimeInterval remainingLegDuration;
        [Export("remainingLegDuration")]
        double RemainingLegDuration { get; }

        // @property (readonly, nonatomic) uint32_t stepIndex;
        [Export("stepIndex")]
        uint StepIndex { get; }

        // @property (readonly, nonatomic) float remainingStepDistance;
        [Export("remainingStepDistance")]
        float RemainingStepDistance { get; }

        // @property (readonly, nonatomic) NSTimeInterval remainingStepDuration;
        [Export("remainingStepDuration")]
        double RemainingStepDuration { get; }

        // @property (readonly, nonatomic) MBVoiceInstruction * _Nullable voiceInstruction;
        [NullAllowed, Export("voiceInstruction")]
        MBVoiceInstruction VoiceInstruction { get; }

        // @property (readonly, nonatomic) MBBannerInstruction * _Nullable bannerInstruction;
        [NullAllowed, Export("bannerInstruction")]
        MBBannerInstruction BannerInstruction { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull stateMessage;
        [Export("stateMessage")]
        string StateMessage { get; }

        // @property (readonly, getter = isInTunnel, nonatomic) BOOL inTunnel;
        [Export("inTunnel")]
        bool InTunnel { [Bind("isInTunnel")] get; }

        // @property (readonly, nonatomic) NSTimeInterval predicted;
        [Export("predicted")]
        double Predicted { get; }

        // @property (readonly, nonatomic) uint32_t shapeIndex;
        [Export("shapeIndex")]
        uint ShapeIndex { get; }

        // @property (readonly, nonatomic) uint32_t intersectionIndex;
        [Export("intersectionIndex")]
        uint IntersectionIndex { get; }
    }

    // @interface MBRouterResult : NSObject
    [BaseType(typeof(NSObject))]
    interface MBRouterResult
    {
        // -(instancetype _Nonnull)initWithJson:(NSString * _Nonnull)json success:(BOOL)success;
        [Export("initWithJson:success:")]
        IntPtr Constructor(string json, bool success);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull json;
        [Export("json")]
        string Json { get; }

        // @property (readonly, getter = isSuccess, nonatomic) BOOL success;
        [Export("success")]
        bool Success { [Bind("isSuccess")] get; }
    }

    // @interface MBNavigatorConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface MBNavigatorConfig
    {
        // -(instancetype _Nonnull)initWithTemporalCoherenceCutoff:(float)temporalCoherenceCutoff spatialCoherenceCutoff:(float)spatialCoherenceCutoff minTrustedDuration:(float)minTrustedDuration minTrustedObserverations:(uint32_t)minTrustedObserverations offRouteThreshold:(float)offRouteThreshold offRouteThresholdWhenNearIntersection:(float)offRouteThresholdWhenNearIntersection intersectionRadiusForOffRouteDetection:(float)intersectionRadiusForOffRouteDetection gpsAccuracyOffRouteScaleFactor:(float)gpsAccuracyOffRouteScaleFactor proximityToRouteStayInitializedThreshold:(float)proximityToRouteStayInitializedThreshold corralBuffer:(float)corralBuffer maxHistory:(uint32_t)maxHistory lookAheadScale:(float)lookAheadScale defaultAccuracy:(float)defaultAccuracy maxUpdatesAwayFromRouteBeforeReroute:(uint8_t)maxUpdatesAwayFromRouteBeforeReroute bearingDifferenceRerouteThreshold:(uint16_t)bearingDifferenceRerouteThreshold nextStepTolerance:(float)nextStepTolerance maxRetroGradeTime:(uint8_t)maxRetroGradeTime maxRetroGradeJitter:(float)maxRetroGradeJitter maxPrediction:(float)maxPrediction maneuverApproachPredictionScalingDuration:(float)maneuverApproachPredictionScalingDuration speedMaxDeltaT:(float)speedMaxDeltaT minPredictionSpeed:(float)minPredictionSpeed minNearTunnel:(float)minNearTunnel minSpeedMetersPerSecond:(float)minSpeedMetersPerSecond minAnnotationDistance:(float)minAnnotationDistance arrivalThresholdDuration:(NSNumber * _Nullable)arrivalThresholdDuration arrivalThresholdDistance:(NSNumber * _Nullable)arrivalThresholdDistance voiceInstructionThreshold:(float)voiceInstructionThreshold defaultArrivalDistance:(float)defaultArrivalDistance;
        [Export("initWithTemporalCoherenceCutoff:spatialCoherenceCutoff:minTrustedDuration:minTrustedObserverations:offRouteThreshold:offRouteThresholdWhenNearIntersection:intersectionRadiusForOffRouteDetection:gpsAccuracyOffRouteScaleFactor:proximityToRouteStayInitializedThreshold:corralBuffer:maxHistory:lookAheadScale:defaultAccuracy:maxUpdatesAwayFromRouteBeforeReroute:bearingDifferenceRerouteThreshold:nextStepTolerance:maxRetroGradeTime:maxRetroGradeJitter:maxPrediction:maneuverApproachPredictionScalingDuration:speedMaxDeltaT:minPredictionSpeed:minNearTunnel:minSpeedMetersPerSecond:minAnnotationDistance:arrivalThresholdDuration:arrivalThresholdDistance:voiceInstructionThreshold:defaultArrivalDistance:")]
        IntPtr Constructor(float temporalCoherenceCutoff, float spatialCoherenceCutoff, float minTrustedDuration, uint minTrustedObserverations, float offRouteThreshold, float offRouteThresholdWhenNearIntersection, float intersectionRadiusForOffRouteDetection, float gpsAccuracyOffRouteScaleFactor, float proximityToRouteStayInitializedThreshold, float corralBuffer, uint maxHistory, float lookAheadScale, float defaultAccuracy, byte maxUpdatesAwayFromRouteBeforeReroute, ushort bearingDifferenceRerouteThreshold, float nextStepTolerance, byte maxRetroGradeTime, float maxRetroGradeJitter, float maxPrediction, float maneuverApproachPredictionScalingDuration, float speedMaxDeltaT, float minPredictionSpeed, float minNearTunnel, float minSpeedMetersPerSecond, float minAnnotationDistance, [NullAllowed] NSNumber arrivalThresholdDuration, [NullAllowed] NSNumber arrivalThresholdDistance, float voiceInstructionThreshold, float defaultArrivalDistance);

        // @property (readwrite, nonatomic) float temporalCoherenceCutoff;
        [Export("temporalCoherenceCutoff")]
        float TemporalCoherenceCutoff { get; set; }

        // @property (readwrite, nonatomic) float spatialCoherenceCutoff;
        [Export("spatialCoherenceCutoff")]
        float SpatialCoherenceCutoff { get; set; }

        // @property (readwrite, nonatomic) float minTrustedDuration;
        [Export("minTrustedDuration")]
        float MinTrustedDuration { get; set; }

        // @property (readwrite, nonatomic) uint32_t minTrustedObserverations;
        [Export("minTrustedObserverations")]
        uint MinTrustedObserverations { get; set; }

        // @property (readwrite, nonatomic) float offRouteThreshold;
        [Export("offRouteThreshold")]
        float OffRouteThreshold { get; set; }

        // @property (readwrite, nonatomic) float offRouteThresholdWhenNearIntersection;
        [Export("offRouteThresholdWhenNearIntersection")]
        float OffRouteThresholdWhenNearIntersection { get; set; }

        // @property (readwrite, nonatomic) float intersectionRadiusForOffRouteDetection;
        [Export("intersectionRadiusForOffRouteDetection")]
        float IntersectionRadiusForOffRouteDetection { get; set; }

        // @property (readwrite, nonatomic) float gpsAccuracyOffRouteScaleFactor;
        [Export("gpsAccuracyOffRouteScaleFactor")]
        float GpsAccuracyOffRouteScaleFactor { get; set; }

        // @property (readwrite, nonatomic) float proximityToRouteStayInitializedThreshold;
        [Export("proximityToRouteStayInitializedThreshold")]
        float ProximityToRouteStayInitializedThreshold { get; set; }

        // @property (readwrite, nonatomic) float corralBuffer;
        [Export("corralBuffer")]
        float CorralBuffer { get; set; }

        // @property (readwrite, nonatomic) uint32_t maxHistory;
        [Export("maxHistory")]
        uint MaxHistory { get; set; }

        // @property (readwrite, nonatomic) float lookAheadScale;
        [Export("lookAheadScale")]
        float LookAheadScale { get; set; }

        // @property (readwrite, nonatomic) float defaultAccuracy;
        [Export("defaultAccuracy")]
        float DefaultAccuracy { get; set; }

        // @property (readwrite, nonatomic) uint8_t maxUpdatesAwayFromRouteBeforeReroute;
        [Export("maxUpdatesAwayFromRouteBeforeReroute")]
        byte MaxUpdatesAwayFromRouteBeforeReroute { get; set; }

        // @property (readwrite, nonatomic) uint16_t bearingDifferenceRerouteThreshold;
        [Export("bearingDifferenceRerouteThreshold")]
        ushort BearingDifferenceRerouteThreshold { get; set; }

        // @property (readwrite, nonatomic) float nextStepTolerance;
        [Export("nextStepTolerance")]
        float NextStepTolerance { get; set; }

        // @property (readwrite, nonatomic) uint8_t maxRetroGradeTime;
        [Export("maxRetroGradeTime")]
        byte MaxRetroGradeTime { get; set; }

        // @property (readwrite, nonatomic) float maxRetroGradeJitter;
        [Export("maxRetroGradeJitter")]
        float MaxRetroGradeJitter { get; set; }

        // @property (readwrite, nonatomic) float maxPrediction;
        [Export("maxPrediction")]
        float MaxPrediction { get; set; }

        // @property (readwrite, nonatomic) float maneuverApproachPredictionScalingDuration;
        [Export("maneuverApproachPredictionScalingDuration")]
        float ManeuverApproachPredictionScalingDuration { get; set; }

        // @property (readwrite, nonatomic) float speedMaxDeltaT;
        [Export("speedMaxDeltaT")]
        float SpeedMaxDeltaT { get; set; }

        // @property (readwrite, nonatomic) float minPredictionSpeed;
        [Export("minPredictionSpeed")]
        float MinPredictionSpeed { get; set; }

        // @property (readwrite, nonatomic) float minNearTunnel;
        [Export("minNearTunnel")]
        float MinNearTunnel { get; set; }

        // @property (readwrite, nonatomic) float minSpeedMetersPerSecond;
        [Export("minSpeedMetersPerSecond")]
        float MinSpeedMetersPerSecond { get; set; }

        // @property (readwrite, nonatomic) float minAnnotationDistance;
        [Export("minAnnotationDistance")]
        float MinAnnotationDistance { get; set; }

        // @property (readwrite, nonatomic) NSNumber * _Nullable arrivalThresholdDuration;
        [NullAllowed, Export("arrivalThresholdDuration", ArgumentSemantic.Assign)]
        NSNumber ArrivalThresholdDuration { get; set; }

        // @property (readwrite, nonatomic) NSNumber * _Nullable arrivalThresholdDistance;
        [NullAllowed, Export("arrivalThresholdDistance", ArgumentSemantic.Assign)]
        NSNumber ArrivalThresholdDistance { get; set; }

        // @property (readwrite, nonatomic) float voiceInstructionThreshold;
        [Export("voiceInstructionThreshold")]
        float VoiceInstructionThreshold { get; set; }

        // @property (readwrite, nonatomic) float defaultArrivalDistance;
        [Export("defaultArrivalDistance")]
        float DefaultArrivalDistance { get; set; }
    }

    // @interface MBNavigator : NSObject
    [BaseType(typeof(NSObject))]
    interface MBNavigator
    {
        // -(MBNavigationStatus * _Nonnull)setRouteForRouteResponse:(NSString * _Nonnull)routeResponse route:(uint32_t)route leg:(uint32_t)leg;
        [Export("setRouteForRouteResponse:route:leg:")]
        MBNavigationStatus SetRouteForRouteResponse(string routeResponse, uint route, uint leg);

        // -(BOOL)updateAnnotationsForRouteResponse:(NSString * _Nonnull)routeResponse route:(uint32_t)route leg:(uint32_t)leg;
        [Export("updateAnnotationsForRouteResponse:route:leg:")]
        bool UpdateAnnotationsForRouteResponse(string routeResponse, uint route, uint leg);

        // -(BOOL)updateLocationForFixLocation:(MBFixLocation * _Nonnull)fixLocation;
        [Export("updateLocationForFixLocation:")]
        bool UpdateLocationForFixLocation(MBFixLocation fixLocation);

        // -(MBNavigationStatus * _Nonnull)getStatusForTimestamp:(NSDate * _Nonnull)timestamp;
        [Export("getStatusForTimestamp:")]
        MBNavigationStatus GetStatusForTimestamp(NSDate timestamp);

        // -(NSNumber * _Nullable)getBearing;
        [Export("getBearing")]
        [return: NullAllowed]
        NSNumber Bearing();

        // -(MBBannerInstruction * _Nullable)getBannerInstruction;
        [Export("getBannerInstruction")]
        [return: NullAllowed]
        MBBannerInstruction BannerInstruction();

        // -(MBVoiceInstruction * _Nullable)getVoiceInstruction;
        [Export("getVoiceInstruction")]
        [return: NullAllowed]
        MBVoiceInstruction VoiceInstruction();

        // -(MBBannerInstruction * _Nullable)getBannerInstructionForIndexInRoute:(uint32_t)indexInRoute;
        [Export("getBannerInstructionForIndexInRoute:")]
        [return: NullAllowed]
        MBBannerInstruction GetBannerInstructionForIndexInRoute(uint indexInRoute);

        // -(MBVoiceInstruction * _Nullable)getVoiceInstructionForIndexInRoute:(uint32_t)indexInRoute;
        [Export("getVoiceInstructionForIndexInRoute:")]
        [return: NullAllowed]
        MBVoiceInstruction GetVoiceInstructionForIndexInRoute(uint indexInRoute);

        // -(NSArray<CLLocation *> * _Nullable)getRouteGeometry;
        [Export("getRouteGeometry")]
        [return: NullAllowed]
        CLLocation[] RouteGeometry();

        // -(NSArray<CLLocation *> * _Nullable)getRouteBoundingBox;
        [Export("getRouteBoundingBox")]
        [return: NullAllowed]
        CLLocation[] RouteBoundingBox();

        // -(NSString * _Nullable)getRouteBufferGeoJsonForGrid_size:(float)grid_size dilation:(uint16_t)dilation;
        [Export("getRouteBufferGeoJsonForGrid_size:dilation:")]
        [return: NullAllowed]
        string GetRouteBufferGeoJsonForGrid_size(float grid_size, ushort dilation);

        // -(NSString * _Nonnull)getHistory;
        [Export("getHistory")]
        string History();

        // -(void)toggleHistoryForOnOff:(BOOL)onOff;
        [Export("toggleHistoryForOnOff:")]
        void ToggleHistoryForOnOff(bool onOff);

        // -(void)pushHistoryForEventType:(NSString * _Nonnull)eventType eventPropertiesJson:(NSString * _Nonnull)eventPropertiesJson;
        [Export("pushHistoryForEventType:eventPropertiesJson:")]
        void PushHistoryForEventType(string eventType, string eventPropertiesJson);

        // -(MBNavigationStatus * _Nonnull)changeRouteLegForRoute:(uint32_t)route leg:(uint32_t)leg;
        [Export("changeRouteLegForRoute:leg:")]
        MBNavigationStatus ChangeRouteLegForRoute(uint route, uint leg);

        // -(MBNavigatorConfig * _Nonnull)getConfig;
        [Export("getConfig")]
        MBNavigatorConfig Config();

        // -(void)setConfigForConfig:(MBNavigatorConfig * _Nullable)config;
        [Export("setConfigForConfig:")]
        void SetConfigForConfig([NullAllowed] MBNavigatorConfig config);

        // -(uint64_t)configureRouterForTilesPath:(NSString * _Nonnull)tilesPath;
        [Export("configureRouterForTilesPath:")]
        ulong ConfigureRouterForTilesPath(string tilesPath);

        // -(MBRouterResult * _Nonnull)getRouteForDirectionsUri:(NSString * _Nonnull)directionsUri;
        [Export("getRouteForDirectionsUri:")]
        MBRouterResult GetRouteForDirectionsUri(string directionsUri);

        // -(uint64_t)unpackTilesForPacked_tiles_path:(NSString * _Nonnull)packed_tiles_path output_directory:(NSString * _Nonnull)output_directory;
        [Export("unpackTilesForPacked_tiles_path:output_directory:")]
        ulong UnpackTilesForPacked_tiles_path(string packed_tiles_path, string output_directory);

        // -(uint64_t)removeTilesForTiles_path:(NSString * _Nonnull)tiles_path lower_left:(CLLocationCoordinate2D)lower_left upper_right:(CLLocationCoordinate2D)upper_right;
        [Export("removeTilesForTiles_path:lower_left:upper_right:")]
        ulong RemoveTilesForTiles_path(string tiles_path, CLLocationCoordinate2D lower_left, CLLocationCoordinate2D upper_right);

        // -(MBRouterResult * _Nonnull)getTraceAttributesForTraceAttributesUri:(NSString * _Nonnull)traceAttributesUri;
        [Export("getTraceAttributesForTraceAttributesUri:")]
        MBRouterResult GetTraceAttributesForTraceAttributesUri(string traceAttributesUri);
    }

}

