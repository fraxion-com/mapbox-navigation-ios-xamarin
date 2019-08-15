using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using MapboxDirections;
using MapboxNavigationNative;

namespace MapboxCoreNavigation
{
    // @interface MapboxCoreNavigation_Swift_199 (NSBundle)
    [Category]
    [BaseType(typeof(NSBundle))]
    interface NSBundle_MapboxCoreNavigation
    {
        // @property (readonly, copy, nonatomic) NSURL * _Nullable suggestedTileURL;
        [Export("suggestedTileURL", ArgumentSemantic.Copy)]
        [return: NullAllowed]
        NSUrl SuggestedTileURL();

        // -(NSURL * _Nullable)suggestedTileURLWithVersion:(NSString * _Nonnull)version __attribute__((warn_unused_result));
        [Export("suggestedTileURLWithVersion:")]
        [return: NullAllowed]
        NSUrl SuggestedTileURLWithVersion(string version);
    }

    [BaseType(typeof(NSObject))]
    partial interface NSBundle
    {
        // @property (readonly, nonatomic, strong, class) NSBundle * _Nonnull mapboxCoreNavigation;
        [Static]
        [Export("mapboxCoreNavigation", ArgumentSemantic.Strong)]
        NSBundle MapboxCoreNavigation { get; }
    }

    // @protocol MBDefaultInterfaceFlag
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface MBDefaultInterfaceFlag
    {
        // @required @property (nonatomic) BOOL usesDefaultUserInterface;
        [Abstract]
        [Export("usesDefaultUserInterface")]
        bool UsesDefaultUserInterface { get; set; }
    }

    // @interface MBDistanceFormatter : NSLengthFormatter
    [BaseType(typeof(NSLengthFormatter))]
    [DisableDefaultCtor]
    interface MBDistanceFormatter
    {
        // -(instancetype _Nonnull)initWithApproximate:(BOOL)approximate __attribute__((objc_designated_initializer));
        [Export("initWithApproximate:")]
        [DesignatedInitializer]
        IntPtr Constructor(bool approximate);

        // -(void)encodeWithCoder:(NSCoder * _Nonnull)aCoder;
        [Export("encodeWithCoder:")]
        void EncodeWithCoder(NSCoder aCoder);

        // -(NSString * _Nonnull)stringFrom:(CLLocationDistance)distance __attribute__((warn_unused_result));
        [Export("stringFrom:")]
        string StringFrom(double distance);

        // -(NSString * _Nonnull)stringFromMeters:(double)numberInMeters __attribute__((warn_unused_result));
        [Export("stringFromMeters:")]
        [Override]
        string StringFromMeters(double numberInMeters);

        // -(NSMeasurement<NSUnitLength *> * _Nonnull)measurementOfDistance:(CLLocationDistance)distance __attribute__((availability(ios, introduced=10.0))) __attribute__((warn_unused_result));
        [Introduced(PlatformName.iOS, 10, 0)]
        [Export("measurementOfDistance:")]
        NSMeasurement<NSUnitLength> MeasurementOfDistance(double distance);

        // -(NSAttributedString * _Nullable)attributedStringForObjectValue:(id _Nonnull)obj withDefaultAttributes:(NSDictionary<NSAttributedStringKey,id> * _Nullable)attrs __attribute__((warn_unused_result));
        [Export("attributedStringForObjectValue:withDefaultAttributes:")]
        [return: NullAllowed]
        NSAttributedString AttributedStringForObjectValue(NSObject obj, [NullAllowed] NSDictionary<NSString, NSObject> attrs);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBDistanceFormatter New();
    }

    // @interface EndOfRouteFeedback : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC20MapboxCoreNavigation18EndOfRouteFeedback")]
    [DisableDefaultCtor]
    interface EndOfRouteFeedback
    {
        // -(instancetype _Nonnull)initWithRating:(NSNumber * _Nullable)ratingNumber comment:(NSString * _Nullable)comment;
        [Export("initWithRating:comment:")]
        IntPtr Constructor([NullAllowed] NSNumber ratingNumber, [NullAllowed] string comment);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        EndOfRouteFeedback New();
    }

    // @protocol EventsManagerDataSource
    [BaseType(typeof(NSObject), Name = "_TtP20MapboxCoreNavigation23EventsManagerDataSource_")]
    [Protocol, Model]
    interface EventsManagerDataSource
    {
        // @required @property (readonly, nonatomic, strong) MBRouteProgress * _Nonnull routeProgress;
        [Abstract]
        [Export("routeProgress", ArgumentSemantic.Strong)]
        MBRouteProgress RouteProgress { get; }

        // @required @property (readonly, nonatomic, strong) id<Router> _Null_unspecified router;
        [Abstract]
        [Export("router", ArgumentSemantic.Strong)]
        Router Router { get; }

        // @required @property (readonly, nonatomic) CLLocationAccuracy desiredAccuracy;
        [Abstract]
        [Export("desiredAccuracy")]
        double DesiredAccuracy { get; }

        // @required @property (readonly, nonatomic) Class _Nonnull locationProvider;
        [Abstract]
        [Export("locationProvider")]
        Class LocationProvider { get; }
    }

    // @protocol Router <CLLocationManagerDelegate>
    [BaseType(typeof(NSObject), Name = "_TtP20MapboxCoreNavigation6Router_")]
    [Protocol, Model]
    interface Router : ICLLocationManagerDelegate
    {
        // @required @property (readonly, nonatomic, unsafe_unretained) id<MBRouterDataSource> _Nonnull dataSource;
        [Export("dataSource", ArgumentSemantic.Assign)]
        MBRouterDataSource DataSource { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBRouterDelegate Delegate { get; set; }

        // @required @property (nonatomic, strong) id<MBRouterDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Strong)]
        NSObject WeakDelegate { get; set; }

        // @required -(instancetype _Nonnull)initWithRoute:(MBRoute * _Nonnull)route directions:(MBDirections * _Nonnull)directions dataSource:(id<MBRouterDataSource> _Nonnull)source;
        [Export("initWithRoute:directions:dataSource:")]
        IntPtr Constructor(MBRoute route, MBDirections directions, MBRouterDataSource source);

        // @required @property (readonly, nonatomic, strong) MBRouteProgress * _Nonnull routeProgress;
        [Export("routeProgress", ArgumentSemantic.Strong)]
        MBRouteProgress RouteProgress { get; }

        // @required @property (nonatomic, strong) MBRoute * _Nonnull route;
        [Export("route", ArgumentSemantic.Strong)]
        MBRoute Route { get; set; }

        // @required -(BOOL)userIsOnRoute:(CLLocation * _Nonnull)location __attribute__((warn_unused_result));
        [Abstract]
        [Export("userIsOnRoute:")]
        bool UserIsOnRoute(CLLocation location);

        // @required -(void)rerouteFrom:(CLLocation * _Nonnull)from along:(MBRouteProgress * _Nonnull)along;
        [Abstract]
        [Export("rerouteFrom:along:")]
        void RerouteFrom(CLLocation from, MBRouteProgress along);

        // @required @property (readonly, nonatomic, strong) CLLocation * _Nullable location;
        [Abstract]
        [NullAllowed, Export("location", ArgumentSemantic.Strong)]
        CLLocation Location { get; }

        // @required @property (readonly, nonatomic, strong) CLLocation * _Nullable rawLocation;
        [Abstract]
        [NullAllowed, Export("rawLocation", ArgumentSemantic.Strong)]
        CLLocation RawLocation { get; }

        // @required @property (nonatomic) BOOL reroutesProactively;
        [Abstract]
        [Export("reroutesProactively")]
        bool ReroutesProactively { get; set; }

        // @required -(void)advanceLegIndexWithLocation:(CLLocation * _Nonnull)location;
        [Abstract]
        [Export("advanceLegIndexWithLocation:")]
        void AdvanceLegIndexWithLocation(CLLocation location);

        // @optional -(void)enableLocationRecording;
        [Export("enableLocationRecording")]
        void EnableLocationRecording();

        // @optional -(void)disableLocationRecording;
        [Export("disableLocationRecording")]
        void DisableLocationRecording();

        // @optional -(NSString * _Nonnull)locationHistory __attribute__((warn_unused_result));
        [Export("locationHistory")]
        string LocationHistory();
    }

    // @interface MBLegacyRouteController : NSObject <Router>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBLegacyRouteController : Router
    {
        // @property (nonatomic, strong) MBDirections * _Nonnull directions;
        [Export("directions", ArgumentSemantic.Strong)]
        MBDirections Directions { get; set; }

        // @property (nonatomic) NSTimeInterval waypointArrivalThreshold;
        [Export("waypointArrivalThreshold")]
        double WaypointArrivalThreshold { get; set; }

        // @property (readonly, nonatomic) CLLocationDistance reroutingTolerance;
        [Export("reroutingTolerance")]
        double ReroutingTolerance { get; }

        // -(void)locationManager:(CLLocationManager * _Nonnull)manager didUpdateHeading:(CLHeading * _Nonnull)newHeading;
        [Export("locationManager:didUpdateHeading:")]
        void LocationManagerDidUpdateHeading(CLLocationManager manager, CLHeading newHeading);

        // -(void)locationManager:(CLLocationManager * _Nonnull)manager didUpdateLocations:(NSArray<CLLocation *> * _Nonnull)locations;
        [Export("locationManager:didUpdateLocations:")]
        void LocationManagerDidUpdateLocations(CLLocationManager manager, CLLocation[] locations);

        // -(instancetype _Nonnull)initWithRoute:(MBRoute * _Nonnull)route directions:(MBDirections * _Nonnull)directions dataSource:(MBNavigationLocationManager * _Nonnull)dataSource eventsManager:(MBNavigationEventsManager * _Nonnull)eventsManager __attribute__((deprecated("MapboxNavigationService is now the point-of-entry to MapboxCoreNavigation. Direct use of RouteController is no longer reccomended. See MapboxNavigationService for more information.")));
        [Export("initWithRoute:directions:dataSource:eventsManager:")]
        IntPtr Constructor(MBRoute route, MBDirections directions, MBNavigationLocationManager dataSource, MBNavigationEventsManager eventsManager);

        // @property (nonatomic, strong) MBNavigationLocationManager * _Null_unspecified locationManager __attribute__((deprecated("RouteController no longer manages a location manager directly. Instead, the Router protocol conforms to CLLocationManagerDelegate, and RouteControllerDataSource provides access to synchronous location requests.")));
        [Export("locationManager", ArgumentSemantic.Strong)]
        MBNavigationLocationManager LocationManager { get; set; }

        // @property (nonatomic) id _Null_unspecified tunnelIntersectionManager __attribute__((deprecated("NavigationViewController no longer directly manages an NavigationLocationManager. See MapboxNavigationService, which contains a reference to the locationManager, for more information.", "locationManager")));
        [Export("tunnelIntersectionManager", ArgumentSemantic.Assign)]
        NSObject TunnelIntersectionManager { get; set; }

        // @property (nonatomic, strong) MBNavigationEventsManager * _Null_unspecified eventsManager __attribute__((deprecated("NavigationViewController no longer directly manages a NavigationEventsManager. See MapboxNavigationService, which contains a reference to the eventsManager, for more information.", "eventsManager")));
        [Export("eventsManager", ArgumentSemantic.Strong)]
        MBNavigationEventsManager EventsManager { get; set; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBLegacyRouteController New();
    }

    // @protocol MBRouterDataSource
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface MBRouterDataSource
    {
        // @required @property (readonly, nonatomic) Class _Nonnull locationProvider;
        [Abstract]
        [Export("locationProvider")]
        Class LocationProvider { get; }
    }

    // @interface MBNavigationService : NSObject <MBNavigationService>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBNavigationService : ICLLocationManagerDelegate, MBRouterDelegate, MBDefaultInterfaceFlag, EventsManagerDataSource, MBRouterDataSource
    {
        // @required @property (readonly, nonatomic, strong) MBNavigationLocationManager * _Nonnull locationManager;
        [Export("locationManager", ArgumentSemantic.Strong)]
        MBNavigationLocationManager LocationManager { get; }

        // @required @property (readonly, nonatomic, strong) MBDirections * _Nonnull directions;
        [Export("directions", ArgumentSemantic.Strong)]
        MBDirections Directions { get; }

        // @required @property (readonly, nonatomic, strong) MBNavigationEventsManager * _Null_unspecified eventsManager;
        [Export("eventsManager", ArgumentSemantic.Strong)]
        MBNavigationEventsManager EventsManager { get; }

        // @required @property (nonatomic, strong) MBRoute * _Nonnull route;
        [Export("route", ArgumentSemantic.Strong)]
        MBRoute Route { get; set; }

        // @required @property (nonatomic) enum MBNavigationSimulationOptions simulationMode;
        [Export("simulationMode", ArgumentSemantic.Assign)]
        MBNavigationSimulationOptions SimulationMode { get; set; }

        // @required @property (nonatomic) double simulationSpeedMultiplier;
        [Export("simulationSpeedMultiplier")]
        double SimulationSpeedMultiplier { get; set; }

        // @required @property (nonatomic) double poorGPSPatience;
        [Export("poorGPSPatience")]
        double PoorGPSPatience { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        NavigationServiceDelegate Delegate { get; set; }

        // @required @property (nonatomic, weak) id<NavigationServiceDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(instancetype _Nonnull)initWithRoute:(MBRoute * _Nonnull)route directions:(MBDirections * _Nullable)directions locationSource:(MBNavigationLocationManager * _Nullable)locationSource eventsManagerType:(Class _Nullable)eventsManagerType simulating:(enum MBNavigationSimulationOptions)simulationMode routerType:(Class<Router> _Nullable)routerType __attribute__((objc_designated_initializer));
        [Export("initWithRoute:directions:locationSource:eventsManagerType:simulating:routerType:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRoute route, [NullAllowed] MBDirections directions, [NullAllowed] MBNavigationLocationManager locationSource, [NullAllowed] Class eventsManagerType, MBNavigationSimulationOptions simulationMode, [NullAllowed] Router routerType);

        // -(void)locationManager:(CLLocationManager * _Nonnull)manager didUpdateHeading:(CLHeading * _Nonnull)newHeading;
        [Export("locationManager:didUpdateHeading:")]
        void LocationManagerDidUpdateHeading(CLLocationManager manager, CLHeading newHeading);

        // -(void)locationManager:(CLLocationManager * _Nonnull)manager didUpdateLocations:(NSArray<CLLocation *> * _Nonnull)locations;
        [Export("locationManager:didUpdateLocations:")]
        void LocationManagerDidUpdateLocations(CLLocationManager manager, CLLocation[] locations);

        // @required -(void)start;
        [Export("start")]
        void Start();

        // @required -(void)stop;
        [Export("stop")]
        void Stop();

        // @required -(void)endNavigationWithFeedback:(EndOfRouteFeedback * _Nullable)feedback;
        [Export("endNavigationWithFeedback:")]
        void EndNavigationWithFeedback([NullAllowed] EndOfRouteFeedback feedback);

        // @required -(BOOL)isInTunnelAt:(CLLocation * _Nonnull)location along:(MBRouteProgress * _Nonnull)progress __attribute__((warn_unused_result));
        [Export("isInTunnelAt:along:")]
        bool IsInTunnelAt(CLLocation location, MBRouteProgress progress);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBNavigationService New();
    }

    // @protocol MBRouterDelegate
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface MBRouterDelegate
    {
        // @optional -(BOOL)router:(id<Router> _Nonnull)router shouldRerouteFromLocation:(CLLocation * _Nonnull)location __attribute__((warn_unused_result));
        [Export("router:shouldRerouteFromLocation:")]
        bool RouterDhouldRerouteFromLocation(Router router, CLLocation location);

        // @optional -(void)router:(id<Router> _Nonnull)router willRerouteFromLocation:(CLLocation * _Nonnull)location;
        [Export("router:willRerouteFromLocation:")]
        void RouterWillRerouteFromLocation(Router router, CLLocation location);

        // @optional -(BOOL)router:(id<Router> _Nonnull)router shouldDiscardLocation:(CLLocation * _Nonnull)location __attribute__((warn_unused_result));
        [Export("router:shouldDiscardLocation:")]
        bool RouterShouldDiscardLocation(Router router, CLLocation location);

        // @optional -(void)router:(id<Router> _Nonnull)router didRerouteAlongRoute:(MBRoute * _Nonnull)route at:(CLLocation * _Nullable)location proactive:(BOOL)proactive;
        [Export("router:didRerouteAlongRoute:at:proactive:")]
        void RouterDidRerouteAlongRoute(Router router, MBRoute route, [NullAllowed] CLLocation location, bool proactive);

        // @optional -(void)router:(id<Router> _Nonnull)router didFailToRerouteWithError:(NSError * _Nonnull)error;
        [Export("router:didFailToRerouteWithError:")]
        void RouterDidFailToRerouteWithError(Router router, NSError error);

        // @optional -(void)router:(id<Router> _Nonnull)router didUpdateProgress:(MBRouteProgress * _Nonnull)progress withLocation:(CLLocation * _Nonnull)location rawLocation:(CLLocation * _Nonnull)rawLocation;
        [Export("router:didUpdateProgress:withLocation:rawLocation:")]
        void RouterDidUpdateProgress(Router router, MBRouteProgress progress, CLLocation location, CLLocation rawLocation);

        // @optional -(void)router:(id<Router> _Nonnull)router didPassVisualInstructionPoint:(MBVisualInstructionBanner * _Nonnull)instruction routeProgress:(MBRouteProgress * _Nonnull)routeProgress;
        [Export("router:didPassVisualInstructionPoint:routeProgress:")]
        void RouterDidPassVisualInstructionPoint(Router router, MBVisualInstructionBanner instruction, MBRouteProgress routeProgress);

        // @optional -(void)router:(id<Router> _Nonnull)router didPassSpokenInstructionPoint:(MBSpokenInstruction * _Nonnull)instruction routeProgress:(MBRouteProgress * _Nonnull)routeProgress;
        [Export("router:didPassSpokenInstructionPoint:routeProgress:")]
        void RouterDidPassSpokenInstructionPoint(Router router, MBSpokenInstruction instruction, MBRouteProgress routeProgress);

        // @optional -(void)router:(id<Router> _Nonnull)router willArriveAtWaypoint:(MBWaypoint * _Nonnull)waypoint in:(NSTimeInterval)remainingTimeInterval distance:(CLLocationDistance)distance;
        [Export("router:willArriveAtWaypoint:in:distance:")]
        void RouterWillArriveAtWaypoint(Router router, MBWaypoint waypoint, double remainingTimeInterval, double distance);

        // @optional -(BOOL)router:(id<Router> _Nonnull)router didArriveAtWaypoint:(MBWaypoint * _Nonnull)waypoint __attribute__((warn_unused_result));
        [Export("router:didArriveAtWaypoint:")]
        bool RouterDidArriveAtWaypoint(Router router, MBWaypoint waypoint);

        // @optional -(BOOL)router:(id<Router> _Nonnull)router shouldPreventReroutesWhenArrivingAtWaypoint:(MBWaypoint * _Nonnull)waypoint __attribute__((warn_unused_result));
        [Export("router:shouldPreventReroutesWhenArrivingAtWaypoint:")]
        bool RouterShouldPreventReroutesWhenArrivingAtWaypoint(Router router, MBWaypoint waypoint);

        // @optional -(BOOL)routerShouldDisableBatteryMonitoring:(id<Router> _Nonnull)router __attribute__((warn_unused_result));
        [Export("routerShouldDisableBatteryMonitoring:")]
        bool RouterShouldDisableBatteryMonitoring(Router router);
    }

    // @interface MBNavigationDirections
    interface MBNavigationDirections
    {
        // -(instancetype _Nonnull)initWithAccessToken:(NSString * _Nullable)accessToken host:(NSString * _Nullable)host __attribute__((objc_designated_initializer));
        [Export("initWithAccessToken:host:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string accessToken, [NullAllowed] string host);

        // -(void)configureRouterWithTilesURL:(NSURL * _Nonnull)tilesURL completionHandler:(void (^ _Nonnull)(uint64_t))completionHandler;
        [Export("configureRouterWithTilesURL:completionHandler:")]
        void ConfigureRouterWithTilesURL(NSUrl tilesURL, Action<ulong> completionHandler);

        // -(void)configureRouterWithTilesURL:(NSURL * _Nonnull)tilesURL translationsURL:(NSURL * _Nullable)translationsURL completionHandler:(void (^ _Nonnull)(uint64_t))completionHandler __attribute__((deprecated("", "NavigationDirections.configureRouter(tilesURL:completionHandler:)")));
        [Export("configureRouterWithTilesURL:translationsURL:completionHandler:")]
        void ConfigureRouterWithTilesURL(NSUrl tilesURL, [NullAllowed] NSUrl translationsURL, Action<ulong> completionHandler);

        // +(void)unpackTilePackAtURL:(NSURL * _Nonnull)filePathURL outputDirectoryURL:(NSURL * _Nonnull)outputDirectoryURL progressHandler:(void (^ _Nullable)(uint64_t, uint64_t))progressHandler completionHandler:(void (^ _Nullable)(uint64_t, NSError * _Nullable))completionHandler;
        [Static]
        [Export("unpackTilePackAtURL:outputDirectoryURL:progressHandler:completionHandler:")]
        void UnpackTilePackAtURL(NSUrl filePathURL, NSUrl outputDirectoryURL, [NullAllowed] Action<ulong, ulong> progressHandler, [NullAllowed] Action<ulong, NSError> completionHandler);

        // -(void)calculateDirectionsWithOptions:(MBRouteOptions * _Nonnull)options offline:(BOOL)offline completionHandler:(void (^ _Nonnull)(NSArray<MBWaypoint *> * _Nullable, NSArray<MBRoute *> * _Nullable, NSError * _Nullable))completionHandler;
        [Export("calculateDirectionsWithOptions:offline:completionHandler:")]
        void CalculateDirectionsWithOptions(MBRouteOptions options, bool offline, Action<NSArray<MBWaypoint>, NSArray<MBRoute>, NSError> completionHandler);
    }

    // @interface MBNavigationEventsManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBNavigationEventsManager
    {
        // -(instancetype _Nonnull)initWithDataSource:(id<EventsManagerDataSource> _Nullable)source accessToken:(NSString * _Nullable)possibleToken mobileEventsManager:(id)mobileEventsManager __attribute__((objc_designated_initializer));
        [Export("initWithDataSource:accessToken:mobileEventsManager:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] EventsManagerDataSource source, [NullAllowed] string possibleToken, NSObject mobileEventsManager);

        // @property (nonatomic) BOOL delaysEventFlushing;
        [Export("delaysEventFlushing")]
        bool DelaysEventFlushing { get; set; }

        // -(NSUUID * _Nullable)recordFeedbackWithType:(enum MBFeedbackType)type description:(NSString * _Nullable)description __attribute__((warn_unused_result));
        [Export("recordFeedbackWithType:description:")]
        [return: NullAllowed]
        NSUuid RecordFeedbackWithType(MBFeedbackType type, [NullAllowed] string description);

        // -(void)updateFeedbackWithUuid:(NSUUID * _Nonnull)uuid type:(enum MBFeedbackType)type source:(enum MBFeedbackSource)source description:(NSString * _Nullable)description;
        [Export("updateFeedbackWithUuid:type:source:description:")]
        void UpdateFeedbackWithUuid(NSUuid uuid, MBFeedbackType type, MBFeedbackSource source, [NullAllowed] string description);

        // -(void)cancelFeedbackWithUuid:(NSUUID * _Nonnull)uuid;
        [Export("cancelFeedbackWithUuid:")]
        void CancelFeedbackWithUuid(NSUuid uuid);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBNavigationEventsManager New();
    }

    // @interface MBNavigationLocationManager : CLLocationManager
    [BaseType(typeof(CLLocationManager))]
    interface MBNavigationLocationManager: MBRouterDataSource
    {

    }

    // @interface MBNavigationMatchOptions
    interface MBNavigationMatchOptions
    {
        // -(instancetype _Nonnull)initWithWaypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints profileIdentifier:(id)profileIdentifier __attribute__((objc_designated_initializer));
        [Export("initWithWaypoints:profileIdentifier:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBWaypoint[] waypoints, NSObject profileIdentifier);

        // -(instancetype _Nonnull)initWithLocations:(NSArray<CLLocation *> * _Nonnull)locations profileIdentifier:(id)profileIdentifier;
        [Export("initWithLocations:profileIdentifier:")]
        IntPtr Constructor(CLLocation[] locations, NSObject profileIdentifier);

        // -(instancetype _Nonnull)initWithCoordinates:(NSArray<NSValue *> * _Nonnull)coordinates profileIdentifier:(id)profileIdentifier;
        [Export("initWithCoordinates:profileIdentifier:")]
        IntPtr Constructor(NSValue[] coordinates, NSObject profileIdentifier);

        // -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder __attribute__((objc_designated_initializer));
        [Export("initWithCoder:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSCoder decoder);
    }

    // @interface MBNavigationRouteOptions
    [BaseType(typeof(MBRouteOptions))]
    interface MBNavigationRouteOptions
    {
        // -(instancetype _Nonnull)initWithWaypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints profileIdentifier:(id)profileIdentifier __attribute__((objc_designated_initializer));
        [Export("initWithWaypoints:profileIdentifier:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBWaypoint[] waypoints, MBDirectionsProfileIdentifier profileIdentifier);

        // -(instancetype _Nonnull)initWithLocations:(NSArray<CLLocation *> * _Nonnull)locations profileIdentifier:(id)profileIdentifier;
        [Export("initWithLocations:profileIdentifier:")]
        IntPtr Constructor(CLLocation[] locations, MBDirectionsProfileIdentifier profileIdentifier);

        // -(instancetype _Nonnull)initWithCoordinates:(NSArray<NSValue *> * _Nonnull)coordinates profileIdentifier:(id)profileIdentifier;
        [Export("initWithCoordinates:profileIdentifier:")]
        IntPtr Constructor(NSValue[] coordinates, MBDirectionsProfileIdentifier profileIdentifier);
    }

    // @protocol NavigationServiceDelegate
    [BaseType(typeof(NSObject), Name = "_TtP20MapboxCoreNavigation25NavigationServiceDelegate_")]
    [Model]
    interface NavigationServiceDelegate
    {
        // @optional -(BOOL)navigationService:(id<MBNavigationService> _Nonnull)service shouldRerouteFromLocation:(CLLocation * _Nonnull)location __attribute__((warn_unused_result));
        [Export("navigationService:shouldRerouteFromLocation:")]
        bool NavigationServiceShouldRerouteFromLocation(MBNavigationService service, CLLocation location);

        // @optional -(void)navigationService:(id<MBNavigationService> _Nonnull)service willRerouteFromLocation:(CLLocation * _Nonnull)location;
        [Export("navigationService:willRerouteFromLocation:")]
        void NavigationServiceWillRerouteFromLocation(MBNavigationService service, CLLocation location);

        // @optional -(BOOL)navigationService:(id<MBNavigationService> _Nonnull)service shouldDiscardLocation:(CLLocation * _Nonnull)location __attribute__((warn_unused_result));
        [Export("navigationService:shouldDiscardLocation:")]
        bool NavigationServiceShouldDiscardLocation(MBNavigationService service, CLLocation location);

        // @optional -(void)navigationService:(id<MBNavigationService> _Nonnull)service didRerouteAlongRoute:(MBRoute * _Nonnull)route at:(CLLocation * _Nullable)location proactive:(BOOL)proactive;
        [Export("navigationService:didRerouteAlongRoute:at:proactive:")]
        void NavigationServiceDidRerouteAlongRoute(MBNavigationService service, MBRoute route, [NullAllowed] CLLocation location, bool proactive);

        // @optional -(void)navigationService:(id<MBNavigationService> _Nonnull)service didFailToRerouteWithError:(NSError * _Nonnull)error;
        [Export("navigationService:didFailToRerouteWithError:")]
        void NavigationServiceDidFailToRerouteWithError(MBNavigationService service, NSError error);

        // @optional -(void)navigationService:(id<MBNavigationService> _Nonnull)service didUpdateProgress:(MBRouteProgress * _Nonnull)progress withLocation:(CLLocation * _Nonnull)location rawLocation:(CLLocation * _Nonnull)rawLocation;
        [Export("navigationService:didUpdateProgress:withLocation:rawLocation:")]
        void NavigationServiceDidUpdateProgress(MBNavigationService service, MBRouteProgress progress, CLLocation location, CLLocation rawLocation);

        // @optional -(void)navigationService:(id<MBNavigationService> _Nonnull)service didPassVisualInstructionPoint:(MBVisualInstructionBanner * _Nonnull)instruction routeProgress:(MBRouteProgress * _Nonnull)routeProgress;
        [Export("navigationService:didPassVisualInstructionPoint:routeProgress:")]
        void NavigationServiceDidPassVisualInstructionPoint(MBNavigationService service, MBVisualInstructionBanner instruction, MBRouteProgress routeProgress);

        // @optional -(void)navigationService:(id<MBNavigationService> _Nonnull)service didPassSpokenInstructionPoint:(MBSpokenInstruction * _Nonnull)instruction routeProgress:(MBRouteProgress * _Nonnull)routeProgress;
        [Export("navigationService:didPassSpokenInstructionPoint:routeProgress:")]
        void NavigationServiceDidPassSpokenInstructionPoint(MBNavigationService service, MBSpokenInstruction instruction, MBRouteProgress routeProgress);

        // @optional -(void)navigationService:(id<MBNavigationService> _Nonnull)service willArriveAtWaypoint:(MBWaypoint * _Nonnull)waypoint after:(NSTimeInterval)remainingTimeInterval distance:(CLLocationDistance)distance;
        [Export("navigationService:willArriveAtWaypoint:after:distance:")]
        void NavigationServiceWillArriveAtWaypoint(MBNavigationService service, MBWaypoint waypoint, double remainingTimeInterval, double distance);

        // @optional -(BOOL)navigationService:(id<MBNavigationService> _Nonnull)service didArriveAtWaypoint:(MBWaypoint * _Nonnull)waypoint __attribute__((warn_unused_result));
        [Export("navigationService:didArriveAtWaypoint:")]
        bool NavigationServiceDidArriveAtWaypoint(MBNavigationService service, MBWaypoint waypoint);

        // @optional -(BOOL)navigationService:(id<MBNavigationService> _Nonnull)service shouldPreventReroutesWhenArrivingAtWaypoint:(MBWaypoint * _Nonnull)waypoint __attribute__((warn_unused_result));
        [Export("navigationService:shouldPreventReroutesWhenArrivingAtWaypoint:")]
        bool NavigationServiceShouldPreventReroutesWhenArrivingAtWaypoint(MBNavigationService service, MBWaypoint waypoint);

        // @optional -(BOOL)navigationServiceShouldDisableBatteryMonitoring:(id<MBNavigationService> _Nonnull)service __attribute__((warn_unused_result));
        [Export("navigationServiceShouldDisableBatteryMonitoring:")]
        bool NavigationServiceShouldDisableBatteryMonitoring(MBNavigationService service);

        // @optional -(void)navigationService:(id<MBNavigationService> _Nonnull)service willBeginSimulating:(MBRouteProgress * _Nonnull)progress becauseOf:(enum MBNavigationSimulationIntent)reason;
        [Export("navigationService:willBeginSimulating:becauseOf:")]
        void NavigationServiceWillBeginSimulating(MBNavigationService service, MBRouteProgress progress, MBNavigationSimulationIntent reason);

        // @optional -(void)navigationService:(id<MBNavigationService> _Nonnull)service didBeginSimulating:(MBRouteProgress * _Nonnull)progress becauseOf:(enum MBNavigationSimulationIntent)reason;
        [Export("navigationService:didBeginSimulating:becauseOf:")]
        void NavigationServiceDidBeginSimulating(MBNavigationService service, MBRouteProgress progress, MBNavigationSimulationIntent reason);

        // @optional -(void)navigationService:(id<MBNavigationService> _Nonnull)service willEndSimulating:(MBRouteProgress * _Nonnull)progress becauseOf:(enum MBNavigationSimulationIntent)reason;
        [Export("navigationService:willEndSimulating:becauseOf:")]
        void NavigationServiceWillEndSimulating(MBNavigationService service, MBRouteProgress progress, MBNavigationSimulationIntent reason);

        // @optional -(void)navigationService:(id<MBNavigationService> _Nonnull)service didEndSimulating:(MBRouteProgress * _Nonnull)progress becauseOf:(enum MBNavigationSimulationIntent)reason;
        [Export("navigationService:didEndSimulating:becauseOf:")]
        void NavigationServiceDidEndSimulating(MBNavigationService service, MBRouteProgress progress, MBNavigationSimulationIntent reason);
    }

    // @interface MBNavigationSettings : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBNavigationSettings
    {
        // @property (nonatomic) float voiceVolume;
        [Export("voiceVolume")]
        float VoiceVolume { get; set; }

        // @property (nonatomic) BOOL voiceMuted;
        [Export("voiceMuted")]
        bool VoiceMuted { get; set; }

        // @property (nonatomic) NSLengthFormatterUnit distanceUnit;
        [Export("distanceUnit", ArgumentSemantic.Assign)]
        NSLengthFormatterUnit DistanceUnit { get; set; }

        // @property (readonly, nonatomic, strong, class) MBNavigationSettings * _Nonnull sharedSettings;
        [Static]
        [Export("sharedSettings", ArgumentSemantic.Strong)]
        MBNavigationSettings SharedSettings { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBNavigationSettings New();

        // -(void)observeValueForKeyPath:(NSString * _Nullable)keyPath ofObject:(id _Nullable)object change:(NSDictionary<NSKeyValueChangeKey,id> * _Nullable)change context:(void * _Nullable)context;
        [Export("observeValueForKeyPath:ofObject:change:context:")]
        unsafe void ObserveValueForKeyPath([NullAllowed] string keyPath, [NullAllowed] NSObject @object, [NullAllowed] NSDictionary<NSString, NSObject> change, [NullAllowed] IntPtr context);
    }

    // @interface MBReplayLocationManager : MBNavigationLocationManager
    [BaseType(typeof(MBNavigationLocationManager))]
    [DisableDefaultCtor]
    interface MBReplayLocationManager
    {
        // @property (nonatomic) NSTimeInterval speedMultiplier;
        [Export("speedMultiplier")]
        double SpeedMultiplier { get; set; }

        // -(void)startUpdatingLocation;
        [Export("startUpdatingLocation")]
        [Override]
        void StartUpdatingLocation();

        // -(void)stopUpdatingLocation;
        [Export("stopUpdatingLocation")]
        [Override]
        void StopUpdatingLocation();

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBReplayLocationManager New();
    }

    // @interface MBRouteController : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRouteController: Router
    {
        // @property (nonatomic, strong) MBNavigatorConfig * _Nullable config;
        [NullAllowed, Export("config", ArgumentSemantic.Strong)]
        MBNavigatorConfig Config { get; set; }

        // @property (nonatomic, strong) MBDirections * _Nonnull directions;
        [Export("directions", ArgumentSemantic.Strong)]
        MBDirections Directions { get; set; }

        // -(void)locationManager:(CLLocationManager * _Nonnull)manager didUpdateLocations:(NSArray<CLLocation *> * _Nonnull)locations;
        [Export("locationManager:didUpdateLocations:")]
        void LocationManager(CLLocationManager manager, CLLocation[] locations);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBRouteController New();
    }

    // @interface MBRouteLegProgress : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRouteLegProgress
    {
        // @property (readonly, nonatomic, strong) int * _Nonnull leg;
        [Export("leg", ArgumentSemantic.Strong)]
        unsafe int Leg { get; }

        // @property (nonatomic) NSInteger stepIndex;
        [Export("stepIndex")]
        nint StepIndex { get; set; }

        // @property (readonly, copy, nonatomic) NSArray<MBRouteStep *> * _Nonnull remainingSteps;
        [Export("remainingSteps", ArgumentSemantic.Copy)]
        MBRouteStep[] RemainingSteps { get; }

        // @property (readonly, nonatomic) CLLocationDistance distanceTraveled;
        [Export("distanceTraveled")]
        double DistanceTraveled { get; }

        // @property (readonly, nonatomic) NSTimeInterval durationRemaining;
        [Export("durationRemaining")]
        double DurationRemaining { get; }

        // @property (readonly, nonatomic) CLLocationDistance distanceRemaining;
        [Export("distanceRemaining")]
        double DistanceRemaining { get; }

        // @property (readonly, nonatomic) double fractionTraveled;
        [Export("fractionTraveled")]
        double FractionTraveled { get; }

        // @property (nonatomic) BOOL userHasArrivedAtWaypoint;
        [Export("userHasArrivedAtWaypoint")]
        bool UserHasArrivedAtWaypoint { get; set; }

        // -(MBRouteStep * _Nullable)stepBefore:(MBRouteStep * _Nonnull)step __attribute__((warn_unused_result));
        [Export("stepBefore:")]
        [return: NullAllowed]
        MBRouteStep StepBefore(MBRouteStep step);

        // -(MBRouteStep * _Nullable)stepAfter:(MBRouteStep * _Nonnull)step __attribute__((warn_unused_result));
        [Export("stepAfter:")]
        [return: NullAllowed]
        MBRouteStep StepAfter(MBRouteStep step);

        // @property (readonly, nonatomic, strong) MBRouteStep * _Nullable priorStep;
        [NullAllowed, Export("priorStep", ArgumentSemantic.Strong)]
        MBRouteStep PriorStep { get; }

        // @property (readonly, nonatomic, strong) MBRouteStep * _Nonnull currentStep;
        [Export("currentStep", ArgumentSemantic.Strong)]
        MBRouteStep CurrentStep { get; }

        // @property (readonly, nonatomic, strong) MBRouteStep * _Nullable upComingStep __attribute__((deprecated("", "upcomingStep")));
        [NullAllowed, Export("upComingStep", ArgumentSemantic.Strong)]
        MBRouteStep UpComingStep { get; }

        // @property (readonly, nonatomic, strong) MBRouteStep * _Nullable upcomingStep;
        [NullAllowed, Export("upcomingStep", ArgumentSemantic.Strong)]
        MBRouteStep UpcomingStep { get; }

        // @property (readonly, nonatomic, strong) MBRouteStep * _Nullable followOnStep;
        [NullAllowed, Export("followOnStep", ArgumentSemantic.Strong)]
        MBRouteStep FollowOnStep { get; }

        // -(BOOL)isCurrentStep:(MBRouteStep * _Nonnull)step __attribute__((warn_unused_result));
        [Export("isCurrentStep:")]
        bool IsCurrentStep(MBRouteStep step);

        // @property (nonatomic, strong) MBRouteStepProgress * _Nonnull currentStepProgress;
        [Export("currentStepProgress", ArgumentSemantic.Strong)]
        MBRouteStepProgress CurrentStepProgress { get; set; }

        // -(instancetype _Nonnull)initWithLeg:(id)leg stepIndex:(NSInteger)stepIndex spokenInstructionIndex:(NSInteger)spokenInstructionIndex __attribute__((objc_designated_initializer));
        [Export("initWithLeg:stepIndex:spokenInstructionIndex:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSObject leg, nint stepIndex, nint spokenInstructionIndex);

        // @property (readonly, copy, nonatomic) NSArray<NSValue *> * _Nonnull nearbyCoordinates __attribute__((deprecated("Use RouteProgress.nearbyCoordinates")));
        [Export("nearbyCoordinates", ArgumentSemantic.Copy)]
        NSValue[] NearbyCoordinates { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBRouteLegProgress New();
    }

    // @interface MBRouteProgress : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRouteProgress
    {
        // @property (readonly, nonatomic, strong) MBRoute * _Nonnull route;
        [Export("route", ArgumentSemantic.Strong)]
        MBRoute Route { get; }

        // @property (nonatomic) NSInteger legIndex;
        [Export("legIndex")]
        nint LegIndex { get; set; }

        // @property (readonly, nonatomic, strong) int * _Nonnull currentLeg;
        [Export("currentLeg", ArgumentSemantic.Strong)]
        unsafe int CurrentLeg { get; }

        // @property (readonly, copy, nonatomic) NSArray * _Nonnull remainingLegs;
        [Export("remainingLegs", ArgumentSemantic.Copy)]
        MBRouteLeg[] RemainingLegs { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBRouteStep *> * _Nonnull remainingSteps;
        [Export("remainingSteps", ArgumentSemantic.Copy)]
        MBRouteStep[] RemainingSteps { get; }

        // @property (readonly, nonatomic) CLLocationDistance distanceTraveled;
        [Export("distanceTraveled")]
        double DistanceTraveled { get; }

        // @property (readonly, nonatomic) NSTimeInterval durationRemaining;
        [Export("durationRemaining")]
        double DurationRemaining { get; }

        // @property (readonly, nonatomic) double fractionTraveled;
        [Export("fractionTraveled")]
        double FractionTraveled { get; }

        // @property (readonly, nonatomic) CLLocationDistance distanceRemaining;
        [Export("distanceRemaining")]
        double DistanceRemaining { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBWaypoint *> * _Nonnull remainingWaypoints;
        [Export("remainingWaypoints", ArgumentSemantic.Copy)]
        MBWaypoint[] RemainingWaypoints { get; }

        // @property (nonatomic, strong) MBRouteLegProgress * _Nonnull currentLegProgress;
        [Export("currentLegProgress", ArgumentSemantic.Strong)]
        MBRouteLegProgress CurrentLegProgress { get; set; }

        // @property (readonly, nonatomic, strong) int * _Nullable priorLeg;
        [NullAllowed, Export("priorLeg", ArgumentSemantic.Strong)]
        unsafe int PriorLeg { get; }

        // @property (readonly, nonatomic, strong) MBRouteStep * _Nullable priorStep;
        [NullAllowed, Export("priorStep", ArgumentSemantic.Strong)]
        MBRouteStep PriorStep { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable upcomingLeg;
        [NullAllowed, Export("upcomingLeg", ArgumentSemantic.Strong)]
        unsafe int UpcomingLeg { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSValue *> * _Nonnull nearbyCoordinates;
        [Export("nearbyCoordinates", ArgumentSemantic.Copy)]
        NSValue[] NearbyCoordinates { get; }

        // -(instancetype _Nonnull)initWithRoute:(MBRoute * _Nonnull)route legIndex:(NSInteger)legIndex spokenInstructionIndex:(NSInteger)spokenInstructionIndex __attribute__((objc_designated_initializer));
        [Export("initWithRoute:legIndex:spokenInstructionIndex:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRoute route, nint legIndex, nint spokenInstructionIndex);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBRouteProgress New();
    }

    // @interface MBRouteStepProgress : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRouteStepProgress
    {
        // @property (readonly, nonatomic, strong) MBRouteStep * _Nonnull step;
        [Export("step", ArgumentSemantic.Strong)]
        MBRouteStep Step { get; }

        // @property (nonatomic) CLLocationDistance distanceTraveled;
        [Export("distanceTraveled")]
        double DistanceTraveled { get; set; }

        // @property (nonatomic) CLLocationDistance userDistanceToManeuverLocation;
        [Export("userDistanceToManeuverLocation")]
        double UserDistanceToManeuverLocation { get; set; }

        // @property (readonly, nonatomic) CLLocationDistance distanceRemaining;
        [Export("distanceRemaining")]
        double DistanceRemaining { get; }

        // @property (readonly, nonatomic) double fractionTraveled;
        [Export("fractionTraveled")]
        double FractionTraveled { get; }

        // @property (readonly, nonatomic) NSTimeInterval durationRemaining;
        [Export("durationRemaining")]
        double DurationRemaining { get; }

        // -(instancetype _Nonnull)initWithStep:(MBRouteStep * _Nonnull)step spokenInstructionIndex:(NSInteger)spokenInstructionIndex __attribute__((objc_designated_initializer));
        [Export("initWithStep:spokenInstructionIndex:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRouteStep step, nint spokenInstructionIndex);

        // @property (copy, nonatomic) NSArray<MBIntersection *> * _Nullable intersectionsIncludingUpcomingManeuverIntersection;
        [NullAllowed, Export("intersectionsIncludingUpcomingManeuverIntersection", ArgumentSemantic.Copy)]
        MBIntersection[] IntersectionsIncludingUpcomingManeuverIntersection { get; set; }

        // @property (readonly, nonatomic, strong) MBIntersection * _Nullable upcomingIntersection;
        [NullAllowed, Export("upcomingIntersection", ArgumentSemantic.Strong)]
        MBIntersection UpcomingIntersection { get; }

        // @property (nonatomic) NSInteger intersectionIndex;
        [Export("intersectionIndex")]
        nint IntersectionIndex { get; set; }

        // @property (readonly, nonatomic, strong) MBIntersection * _Nullable currentIntersection;
        [NullAllowed, Export("currentIntersection", ArgumentSemantic.Strong)]
        MBIntersection CurrentIntersection { get; }

        // @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable intersectionDistances;
        [NullAllowed, Export("intersectionDistances", ArgumentSemantic.Copy)]
        NSNumber[] IntersectionDistances { get; set; }

        // @property (nonatomic) NSInteger visualInstructionIndex;
        [Export("visualInstructionIndex")]
        nint VisualInstructionIndex { get; set; }

        // @property (readonly, copy, nonatomic) NSArray<MBVisualInstructionBanner *> * _Nullable remainingVisualInstructions;
        [NullAllowed, Export("remainingVisualInstructions", ArgumentSemantic.Copy)]
        MBVisualInstructionBanner[] RemainingVisualInstructions { get; }

        // @property (nonatomic) NSInteger spokenInstructionIndex;
        [Export("spokenInstructionIndex")]
        nint SpokenInstructionIndex { get; set; }

        // @property (readonly, copy, nonatomic) NSArray<MBSpokenInstruction *> * _Nullable remainingSpokenInstructions;
        [NullAllowed, Export("remainingSpokenInstructions", ArgumentSemantic.Copy)]
        MBSpokenInstruction[] RemainingSpokenInstructions { get; }

        // @property (readonly, nonatomic, strong) MBSpokenInstruction * _Nullable currentSpokenInstruction;
        [NullAllowed, Export("currentSpokenInstruction", ArgumentSemantic.Strong)]
        MBSpokenInstruction CurrentSpokenInstruction { get; }

        // @property (readonly, nonatomic, strong) MBVisualInstructionBanner * _Nullable currentVisualInstruction;
        [NullAllowed, Export("currentVisualInstruction", ArgumentSemantic.Strong)]
        MBVisualInstructionBanner CurrentVisualInstruction { get; }

        // @property (readonly, copy, nonatomic) NSSet<NSString *> * _Nonnull keyPathsAffectingValueForRemainingVisualInstructions;
        [Export("keyPathsAffectingValueForRemainingVisualInstructions", ArgumentSemantic.Copy)]
        NSSet<NSString> KeyPathsAffectingValueForRemainingVisualInstructions { get; }

        // @property (readonly, copy, nonatomic) NSSet<NSString *> * _Nonnull keyPathsAffectingValueForRemainingSpokenInstructions;
        [Export("keyPathsAffectingValueForRemainingSpokenInstructions", ArgumentSemantic.Copy)]
        NSSet<NSString> KeyPathsAffectingValueForRemainingSpokenInstructions { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBRouteStepProgress New();
    }

    // @interface MBSimulatedLocationManager : MBNavigationLocationManager
    [BaseType(typeof(MBNavigationLocationManager))]
    [DisableDefaultCtor]
    interface MBSimulatedLocationManager
    {
        // @property (nonatomic) double speedMultiplier;
        [Export("speedMultiplier")]
        double SpeedMultiplier { get; set; }

        // -(id _Nonnull)copy __attribute__((warn_unused_result));
        [Export("copy")]
        [Override]
        NSObject Copy();

        // -(instancetype _Nonnull)initWithRoute:(MBRoute * _Nonnull)route __attribute__((objc_designated_initializer));
        [Export("initWithRoute:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRoute route);

        // -(instancetype _Nonnull)initWithRouteProgress:(MBRouteProgress * _Nonnull)routeProgress __attribute__((objc_designated_initializer));
        [Export("initWithRouteProgress:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRouteProgress routeProgress);

        // -(void)startUpdatingLocation;
        [Export("startUpdatingLocation")]
        [Override]
        void StartUpdatingLocation();

        // -(void)stopUpdatingLocation;
        [Export("stopUpdatingLocation")]
        [Override]
        void StopUpdatingLocation();

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBSimulatedLocationManager New();
    }

}


