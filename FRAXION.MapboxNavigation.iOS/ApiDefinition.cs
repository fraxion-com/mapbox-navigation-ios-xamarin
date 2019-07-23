using System;
using AVFoundation;
using CarPlay;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;
using Mapbox;
using MapboxCoreNavigation;
using MapboxDirections;
using MapboxSpeech;

namespace MapboxNavigation
{
    // @interface MBStylableLabel : UILabel
    [BaseType(typeof(UILabel))]
    interface MBStylableLabel
    {
        // @property (nonatomic, strong) UIColor * _Nonnull normalTextColor;
        [Export("normalTextColor", ArgumentSemantic.Strong)]
        UIColor NormalTextColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull normalFont;
        [Export("normalFont", ArgumentSemantic.Strong)]
        UIFont NormalFont { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBArrivalTimeLabel : MBStylableLabel
    [BaseType(typeof(MBStylableLabel))]
    interface MBArrivalTimeLabel
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBBannerContainerView : UIView
    [BaseType(typeof(UIView))]
    interface MBBannerContainerView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface BaseInstructionsBannerView : UIControl
    [BaseType(typeof(UIControl), Name = "_TtC16MapboxNavigation26BaseInstructionsBannerView")]
    interface BaseInstructionsBannerView
    {
        // @property (nonatomic) BOOL swipeable;
        [Export("swipeable")]
        bool Swipeable { get; set; }

        // @property (nonatomic) BOOL showStepIndicator;
        [Export("showStepIndicator")]
        bool ShowStepIndicator { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)updateForVisualInstructionBanner:(MBVisualInstructionBanner * _Nullable)instruction;
        [Export("updateForVisualInstructionBanner:")]
        void UpdateForVisualInstructionBanner([NullAllowed] MBVisualInstructionBanner instruction);

        // -(void)prepareForInterfaceBuilder;
        [Export("prepareForInterfaceBuilder")]
        [Override]
        void PrepareForInterfaceBuilder();
    }

    // @protocol MBBimodalCache
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface MBBimodalCache
    {
        // @required -(void)clearMemory;
        [Abstract]
        [Export("clearMemory")]
        void ClearMemory();

        // @required -(void)clearDiskWithCompletion:(void (^ _Nullable)(void))completion;
        [Abstract]
        [Export("clearDiskWithCompletion:")]
        void ClearDiskWithCompletion([NullAllowed] Action completion);
    }

    // @protocol MBBimodalDataCache <MBBimodalCache>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface MBBimodalDataCache : MBBimodalCache
    {
        // @required -(void)store:(NSData * _Nonnull)data forKey:(NSString * _Nonnull)key toDisk:(BOOL)toDisk completion:(void (^ _Nullable)(void))completionBlock;
        [Abstract]
        [Export("store:forKey:toDisk:completion:")]
        void Store(NSData data, string key, bool toDisk, [NullAllowed] Action completionBlock);

        // @required -(NSData * _Nullable)dataForKey:(NSString * _Nullable)forKey __attribute__((warn_unused_result));
        [Abstract]
        [Export("dataForKey:")]
        [return: NullAllowed]
        NSData DataForKey([NullAllowed] string forKey);
    }

    // @protocol MBBimodalImageCache <MBBimodalCache>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface MBBimodalImageCache : MBBimodalCache
    {
        // @required -(void)store:(UIImage * _Nonnull)image forKey:(NSString * _Nonnull)key toDisk:(BOOL)toDisk completion:(void (^ _Nullable)(void))completionBlock;
        [Abstract]
        [Export("store:forKey:toDisk:completion:")]
        void Store(UIImage image, string key, bool toDisk, [NullAllowed] Action completionBlock);

        // @required -(UIImage * _Nullable)imageForKey:(NSString * _Nullable)forKey __attribute__((warn_unused_result));
        [Abstract]
        [Export("imageForKey:")]
        [return: NullAllowed]
        UIImage ImageForKey([NullAllowed] string forKey);
    }

    // @interface MBBottomBannerView : UIView
    [BaseType(typeof(UIView))]
    interface MBBottomBannerView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @protocol NavigationComponent
    [BaseType(typeof(NSObject), Name = "_TtP16MapboxNavigation19NavigationComponent_")]
    [Protocol, Model]
    interface NavigationComponent
    {
    }

    // @interface MBBottomBannerViewController : UIViewController <NavigationComponent>
    [BaseType(typeof(UIViewController))]
    interface MBBottomBannerViewController : NavigationComponent
    {
        // -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil __attribute__((objc_designated_initializer));
        [Export("initWithNibName:bundle:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] Foundation.NSBundle nibBundleOrNil);

        // -(void)viewWillDisappear:(BOOL)animated;
        [Export("viewWillDisappear:")]
        [Override]
        void ViewWillDisappear(bool animated);

        // -(void)viewDidLoad;
        [Export("viewDidLoad")]
        [Override]
        void ViewDidLoad();

        // -(void)prepareForInterfaceBuilder;
        [Export("prepareForInterfaceBuilder")]
        [Override]
        void PrepareForInterfaceBuilder();

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didRerouteAlongRoute:(MBRoute * _Nonnull)route at:(CLLocation * _Nullable)location proactive:(BOOL)proactive;
        [Export("navigationService:didRerouteAlongRoute:at:proactive:")]
        void NavigationService(MBNavigationService service, MBRoute route, [NullAllowed] CLLocation location, bool proactive);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didUpdateProgress:(MBRouteProgress * _Nonnull)progress withLocation:(CLLocation * _Nonnull)location rawLocation:(CLLocation * _Nonnull)rawLocation;
        [Export("navigationService:didUpdateProgress:withLocation:rawLocation:")]
        void NavigationService(MBNavigationService service, MBRouteProgress progress, CLLocation location, CLLocation rawLocation);

        // -(void)traitCollectionDidChange:(UITraitCollection * _Nullable)previousTraitCollection;
        [Export("traitCollectionDidChange:")]
        [Override]
        void TraitCollectionDidChange([NullAllowed] UITraitCollection previousTraitCollection);
    }

    // @interface MBStylableButton : UIButton
    [BaseType(typeof(UIButton))]
    interface MBStylableButton
    {
        // @property (nonatomic, strong) UIFont * _Nonnull textFont;
        [Export("textFont", ArgumentSemantic.Strong)]
        UIFont TextFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull textColor;
        [Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull borderColor;
        [Export("borderColor", ArgumentSemantic.Strong)]
        UIColor BorderColor { get; set; }

        // @property (nonatomic) CGFloat borderWidth;
        [Export("borderWidth")]
        nfloat BorderWidth { get; set; }

        // @property (nonatomic) CGFloat cornerRadius;
        [Export("cornerRadius")]
        nfloat CornerRadius { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBButton : MBStylableButton
    [BaseType(typeof(MBStylableButton))]
    interface MBButton
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBCancelButton : MBButton
    [BaseType(typeof(MBButton))]
    interface MBCancelButton
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBStylableView : UIView
    [BaseType(typeof(UIView))]
    interface MBStylableView
    {
        // @property (nonatomic, strong) UIColor * _Nullable borderColor;
        [NullAllowed, Export("borderColor", ArgumentSemantic.Strong)]
        UIColor BorderColor { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBCarPlayCompassView : MBStylableView
    [BaseType(typeof(MBStylableView))]
    interface MBCarPlayCompassView
    {
        // @property (nonatomic) CLLocationDirection course;
        [Export("course")]
        double Course { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @protocol CarPlayConnectionObserver
    [BaseType(typeof(NSObject), Name = "_TtP16MapboxNavigation25CarPlayConnectionObserver_")]
    [Protocol, Model]
    interface CarPlayConnectionObserver
    {
        // @required -(void)didConnectToCarPlay;
        [Abstract]
        [Export("didConnectToCarPlay")]
        void DidConnectToCarPlay();

        // @required -(void)didDisconnectFromCarPlay;
        [Abstract]
        [Export("didDisconnectFromCarPlay")]
        void DidDisconnectFromCarPlay();
    }

    // @interface MBCarPlayManager : NSObject
    [Introduced(PlatformName.iOS, 12, 0)]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBCarPlayManager: MBNavigationCarPlayDelegate, ICPInterfaceControllerDelegate, ICPMapTemplateDelegate
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBCarPlayManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MBCarPlayManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) BOOL simulatesLocations;
        [Export("simulatesLocations")]
        bool SimulatesLocations { get; set; }

        // @property (nonatomic) double simulatedSpeedMultiplier;
        [Export("simulatedSpeedMultiplier")]
        double SimulatedSpeedMultiplier { get; set; }

        // @property (nonatomic, class) BOOL isConnected;
        [Static]
        [Export("isConnected")]
        bool IsConnected { get; set; }

        // @property (readonly, nonatomic, strong) MBNavigationEventsManager * _Nonnull eventsManager;
        [Export("eventsManager", ArgumentSemantic.Strong)]
        MBNavigationEventsManager EventsManager { get; }

        // @property (readonly, nonatomic, strong) MBDirections * _Nonnull directions;
        [Export("directions", ArgumentSemantic.Strong)]
        MBDirections Directions { get; }

        // @property (readonly, nonatomic) Class _Nonnull navigationViewControllerType;
        [Export("navigationViewControllerType")]
        Class NavigationViewControllerType { get; }

        // @property (copy, nonatomic) NSArray<MBStyle *> * _Nonnull styles;
        [Export("styles", ArgumentSemantic.Copy)]
        MBStyle[] Styles { get; set; }

        // @property (readonly, nonatomic, strong) MBCarPlayMapViewController * _Nullable carPlayMapViewController;
        [NullAllowed, Export("carPlayMapViewController", ArgumentSemantic.Strong)]
        MBCarPlayMapViewController CarPlayMapViewController { get; }

        // @property (nonatomic, strong) CPBarButton * _Nonnull exitButton;
        [Export("exitButton", ArgumentSemantic.Strong)]
        CPBarButton ExitButton { get; set; }

        // @property (nonatomic, strong) CPBarButton * _Nonnull muteButton;
        [Export("muteButton", ArgumentSemantic.Strong)]
        CPBarButton MuteButton { get; set; }

        // @property (nonatomic, strong) CPMapButton * _Nonnull showFeedbackButton;
        [Export("showFeedbackButton", ArgumentSemantic.Strong)]
        CPMapButton ShowFeedbackButton { get; set; }

        // @property (nonatomic, strong) CPMapButton * _Nonnull userTrackingButton;
        [Export("userTrackingButton", ArgumentSemantic.Strong)]
        CPMapButton UserTrackingButton { get; set; }

        // @property (readonly, nonatomic, strong) CPMapButton * _Nonnull overviewButton __attribute__((deprecated("", "trackingStateButton")));
        [Export("overviewButton", ArgumentSemantic.Strong)]
        CPMapButton OverviewButton { get; }

        // @property (readonly, nonatomic, strong) MBNavigationMapView * _Nullable mapView;
        [NullAllowed, Export("mapView", ArgumentSemantic.Strong)]
        MBNavigationMapView MapView { get; }

        // -(instancetype _Nonnull)initWithStyles:(NSArray<MBStyle *> * _Nullable)styles directions:(MBDirections * _Nullable)directions eventsManager:(MBNavigationEventsManager * _Nullable)eventsManager;
        [Export("initWithStyles:directions:eventsManager:")]
        IntPtr Constructor([NullAllowed] MBStyle[] styles, [NullAllowed] MBDirections directions, [NullAllowed] MBNavigationEventsManager eventsManager);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBCarPlayManager New();

        // -(void)templateWillAppear:(CPTemplate * _Nonnull)template_ animated:(BOOL)animated;
        [Export("templateWillAppear:animated:")]
        void TemplateWillAppear(CPTemplate template_, bool animated);

        // -(void)templateDidAppear:(CPTemplate * _Nonnull)template_ animated:(BOOL)animated;
        [Export("templateDidAppear:animated:")]
        void TemplateDidAppear(CPTemplate template_, bool animated);

        // -(void)templateWillDisappear:(CPTemplate * _Nonnull)template_ animated:(BOOL)animated;
        [Export("templateWillDisappear:animated:")]
        void TemplateWillDisappear(CPTemplate template_, bool animated);

        // -(void)application:(UIApplication * _Nonnull)application didConnectCarInterfaceController:(CPInterfaceController * _Nonnull)interfaceController toWindow:(CPWindow * _Nonnull)window;
        [Export("application:didConnectCarInterfaceController:toWindow:")]
        void ApplicationDidConnectCarInterfaceController(UIApplication application, CPInterfaceController interfaceController, CPWindow window);

        // -(void)application:(UIApplication * _Nonnull)application didDisconnectCarInterfaceController:(CPInterfaceController * _Nonnull)interfaceController fromWindow:(CPWindow * _Nonnull)window;
        [Export("application:didDisconnectCarInterfaceController:fromWindow:")]
        void ApplicationDidDisconnectCarInterfaceController(UIApplication application, CPInterfaceController interfaceController, CPWindow window);

        // -(void)mapTemplate:(CPMapTemplate * _Nonnull)mapTemplate startedTrip:(CPTrip * _Nonnull)trip usingRouteChoice:(CPRouteChoice * _Nonnull)routeChoice;
        [Export("mapTemplate:startedTrip:usingRouteChoice:")]
        void MapTemplateStartedTrip(CPMapTemplate mapTemplate, CPTrip trip, CPRouteChoice routeChoice);

        // -(void)mapTemplate:(CPMapTemplate * _Nonnull)mapTemplate selectedPreviewForTrip:(CPTrip * _Nonnull)trip usingRouteChoice:(CPRouteChoice * _Nonnull)routeChoice;
        [Export("mapTemplate:selectedPreviewForTrip:usingRouteChoice:")]
        void MapTemplateSelectedPreviewForTrip(CPMapTemplate mapTemplate, CPTrip trip, CPRouteChoice routeChoice);

        // -(void)mapTemplateDidCancelNavigation:(CPMapTemplate * _Nonnull)mapTemplate;
        [Export("mapTemplateDidCancelNavigation:")]
        void MapTemplateDidCancelNavigation(CPMapTemplate mapTemplate);

        // -(void)mapTemplateDidBeginPanGesture:(CPMapTemplate * _Nonnull)mapTemplate;
        [Export("mapTemplateDidBeginPanGesture:")]
        void MapTemplateDidBeginPanGesture(CPMapTemplate mapTemplate);

        // -(void)mapTemplate:(CPMapTemplate * _Nonnull)mapTemplate didEndPanGestureWithVelocity:(CGPoint)velocity;
        [Export("mapTemplate:didEndPanGestureWithVelocity:")]
        void MapTemplateDidEndPanGestureWithVelocity(CPMapTemplate mapTemplate, CGPoint velocity);

        // -(void)mapTemplateDidShowPanningInterface:(CPMapTemplate * _Nonnull)mapTemplate;
        [Export("mapTemplateDidShowPanningInterface:")]
        void MapTemplateDidShowPanningInterface(CPMapTemplate mapTemplate);

        // -(void)mapTemplateWillDismissPanningInterface:(CPMapTemplate * _Nonnull)mapTemplate;
        [Export("mapTemplateWillDismissPanningInterface:")]
        void MapTemplateWillDismissPanningInterface(CPMapTemplate mapTemplate);

        // -(void)mapTemplate:(CPMapTemplate * _Nonnull)mapTemplate didUpdatePanGestureWithTranslation:(CGPoint)translation velocity:(CGPoint)velocity;
        [Export("mapTemplate:didUpdatePanGestureWithTranslation:velocity:")]
        void MapTemplateDidUpdatePanGestureWithTranslation(CPMapTemplate mapTemplate, CGPoint translation, CGPoint velocity);

        // -(void)mapTemplate:(CPMapTemplate * _Nonnull)mapTemplate panWithDirection:(CPPanDirection)direction;
        [Export("mapTemplate:panWithDirection:")]
        void MapTemplatePanWithDirection(CPMapTemplate mapTemplate, CPPanDirection direction);
    }

    // @protocol MBNavigationCarPlayDelegate
    [Introduced(PlatformName.iOS, 12, 0)]
    [BaseType(typeof(NSObject))]
    [Model]
    interface MBNavigationCarPlayDelegate
    {
        // @optional -(void)carPlayNavigationViewControllerDidDismiss:(MBCarPlayNavigationViewController * _Nonnull)carPlayNavigationViewController byCanceling:(BOOL)canceled;
        [Export("carPlayNavigationViewControllerDidDismiss:byCanceling:")]
        void CarPlayNavigationViewControllerDidDismiss(MBCarPlayNavigationViewController carPlayNavigationViewController, bool canceled);

        // @optional -(void)carPlayNavigationViewControllerDidArrive:(MBCarPlayNavigationViewController * _Nonnull)carPlayNavigationViewController __attribute__((deprecated("Use NavigationViewControllerDelegate.navigationViewController(_:didArriveAt:) or  NavigationServiceDelegate.navigationService(_:didArriveAt:) instead.")));
        [Export("carPlayNavigationViewControllerDidArrive:")]
        void CarPlayNavigationViewControllerDidArrive(MBCarPlayNavigationViewController carPlayNavigationViewController);
    }

    // @protocol MBCarPlayManagerDelegate
    [Introduced(PlatformName.iOS, 12, 0)]
    [BaseType(typeof(NSObject))]
    [Model]
    interface MBCarPlayManagerDelegate
    {
        // @optional -(NSArray<CPBarButton *> * _Nullable)carPlayManager:(MBCarPlayManager * _Nonnull)carPlayManager leadingNavigationBarButtonsWithTraitCollection:(UITraitCollection * _Nonnull)traitCollection inTemplate:(CPTemplate * _Nonnull)carPlayTemplate forActivity:(enum MBCarPlayActivity)activity __attribute__((warn_unused_result));
        [Export("carPlayManager:leadingNavigationBarButtonsWithTraitCollection:inTemplate:forActivity:")]
        [return: NullAllowed]
        CPBarButton[] CarPlayManagerLeadingNavigationBarButtonsWithTraitCollection(MBCarPlayManager carPlayManager, UITraitCollection traitCollection, CPTemplate carPlayTemplate, MBCarPlayActivity activity);

        // @optional -(NSArray<CPBarButton *> * _Nullable)carPlayManager:(MBCarPlayManager * _Nonnull)carPlayManager trailingNavigationBarButtonsWithTraitCollection:(UITraitCollection * _Nonnull)traitCollection inTemplate:(CPTemplate * _Nonnull)carPlayTemplate forActivity:(enum MBCarPlayActivity)activity __attribute__((warn_unused_result));
        [Export("carPlayManager:trailingNavigationBarButtonsWithTraitCollection:inTemplate:forActivity:")]
        [return: NullAllowed]
        CPBarButton[] CarPlayManagerTrailingNavigationBarButtonsWithTraitCollection(MBCarPlayManager carPlayManager, UITraitCollection traitCollection, CPTemplate carPlayTemplate, MBCarPlayActivity activity);

        // @optional -(NSArray<CPMapButton *> * _Nullable)carPlayManager:(MBCarPlayManager * _Nonnull)carPlayManager mapButtonsCompatibleWithTraitCollection:(UITraitCollection * _Nonnull)traitCollection inTemplate:(CPTemplate * _Nonnull)carPlayTemplate forActivity:(enum MBCarPlayActivity)activity __attribute__((warn_unused_result));
        [Export("carPlayManager:mapButtonsCompatibleWithTraitCollection:inTemplate:forActivity:")]
        [return: NullAllowed]
        CPMapButton[] CarPlayManagerMapButtonsCompatibleWithTraitCollection(MBCarPlayManager carPlayManager, UITraitCollection traitCollection, CPTemplate carPlayTemplate, MBCarPlayActivity activity);

        // @required -(id<MBNavigationService> _Nonnull)carPlayManager:(MBCarPlayManager * _Nonnull)carPlayManager navigationServiceAlongRoute:(MBRoute * _Nonnull)route desiredSimulationMode:(enum MBNavigationSimulationOptions)desiredSimulationMode __attribute__((warn_unused_result));
        [Abstract]
        [Export("carPlayManager:navigationServiceAlongRoute:desiredSimulationMode:")]
        MBNavigationService CarPlayManagerNavigationServiceAlongRoute(MBCarPlayManager carPlayManager, MBRoute route, MBNavigationSimulationOptions desiredSimulationMode);

        // @optional -(void)carPlayManager:(MBCarPlayManager * _Nonnull)carPlayManager searchTemplate:(CPSearchTemplate * _Nonnull)searchTemplate updatedSearchText:(NSString * _Nonnull)searchText completionHandler:(void (^ _Nonnull)(NSArray<CPListItem *> * _Nonnull))completionHandler;
        [Export("carPlayManager:searchTemplate:updatedSearchText:completionHandler:")]
        void CarPlayManagerSearchTemplate(MBCarPlayManager carPlayManager, CPSearchTemplate searchTemplate, string searchText, Action<NSArray<CPListItem>> completionHandler);

        // @optional -(void)carPlayManager:(MBCarPlayManager * _Nonnull)carPlayManager searchTemplate:(CPSearchTemplate * _Nonnull)searchTemplate selectedResult:(CPListItem * _Nonnull)item completionHandler:(void (^ _Nonnull)(void))completionHandler;
        [Export("carPlayManager:searchTemplate:selectedResult:completionHandler:")]
        void CarPlayManagerSearchTemplate(MBCarPlayManager carPlayManager, CPSearchTemplate searchTemplate, CPListItem item, Action completionHandler);

        // @optional -(CPNavigationAlert * _Nullable)carPlayManager:(MBCarPlayManager * _Nonnull)carPlayManager didFailToFetchRouteBetweenWaypoints:(NSArray<MBWaypoint *> * _Nullable)waypoints withOptions:(MBRouteOptions * _Nonnull)options becauseOfError:(NSError * _Nonnull)error __attribute__((warn_unused_result));
        [Export("carPlayManager:didFailToFetchRouteBetweenWaypoints:withOptions:becauseOfError:")]
        [return: NullAllowed]
        CPNavigationAlert CarPlayManagerDidFailToFetchRouteBetweenWaypoints(MBCarPlayManager carPlayManager, [NullAllowed] MBWaypoint[] waypoints, MBRouteOptions options, NSError error);

        // @optional -(CPTrip * _Nonnull)carPlayManager:(MBCarPlayManager * _Nonnull)carPlayManager willPreviewTrip:(CPTrip * _Nonnull)trip __attribute__((warn_unused_result));
        [Export("carPlayManager:willPreviewTrip:")]
        CPTrip CarPlayManagerWillPreviewTrip(MBCarPlayManager carPlayManager, CPTrip trip);

        // @optional -(CPTripPreviewTextConfiguration * _Nonnull)carPlayManager:(MBCarPlayManager * _Nonnull)carPlayManager willPreviewTrip:(CPTrip * _Nonnull)trip withPreviewTextConfiguration:(CPTripPreviewTextConfiguration * _Nonnull)previewTextConfiguration __attribute__((warn_unused_result));
        [Export("carPlayManager:willPreviewTrip:withPreviewTextConfiguration:")]
        CPTripPreviewTextConfiguration CarPlayManagerWillPreviewTrip(MBCarPlayManager carPlayManager, CPTrip trip, CPTripPreviewTextConfiguration previewTextConfiguration);

        // @optional -(void)carPlayManager:(MBCarPlayManager * _Nonnull)carPlayManager selectedPreviewForTrip:(CPTrip * _Nonnull)trip usingRouteChoice:(CPRouteChoice * _Nonnull)routeChoice;
        [Export("carPlayManager:selectedPreviewForTrip:usingRouteChoice:")]
        void CarPlayManagerSelectedPreviewForTrip(MBCarPlayManager carPlayManager, CPTrip trip, CPRouteChoice routeChoice);

        // @required -(void)carPlayManager:(MBCarPlayManager * _Nonnull)carPlayManager didBeginNavigationWithNavigationService:(id<MBNavigationService> _Nonnull)service;
        [Abstract]
        [Export("carPlayManager:didBeginNavigationWithNavigationService:")]
        void CarPlayManagerDidBeginNavigationWithNavigationService(MBCarPlayManager carPlayManager, MBNavigationService service);

        // @required -(void)carPlayManagerDidEndNavigation:(MBCarPlayManager * _Nonnull)carPlayManager;
        [Abstract]
        [Export("carPlayManagerDidEndNavigation:")]
        void CarPlayManagerDidEndNavigation(MBCarPlayManager carPlayManager);

        // @optional -(BOOL)carplayManagerShouldDisableIdleTimer:(MBCarPlayManager * _Nonnull)carPlayManager __attribute__((warn_unused_result));
        [Export("carplayManagerShouldDisableIdleTimer:")]
        bool CarplayManagerShouldDisableIdleTimer(MBCarPlayManager carPlayManager);
    }

    // @interface MBCarPlayMapViewController : UIViewController
    [Introduced(PlatformName.iOS, 12, 0)]
    [BaseType(typeof(UIViewController))]
    interface MBCarPlayMapViewController: MBStyleManagerDelegate
    {
        // @property (nonatomic, strong) CPMapButton * _Nonnull recenterButton;
        [Export("recenterButton", ArgumentSemantic.Strong)]
        CPMapButton RecenterButton { get; set; }

        // @property (nonatomic, strong) CPMapButton * _Nonnull zoomInButton;
        [Export("zoomInButton", ArgumentSemantic.Strong)]
        CPMapButton ZoomInButton { get; set; }

        // @property (nonatomic, strong) CPMapButton * _Nonnull zoomOutButton;
        [Export("zoomOutButton", ArgumentSemantic.Strong)]
        CPMapButton ZoomOutButton { get; set; }

        // @property (readonly, nonatomic, strong) CPMapButton * _Nullable panMapButton;
        [NullAllowed, Export("panMapButton", ArgumentSemantic.Strong)]
        CPMapButton PanMapButton { get; }

        // @property (readonly, nonatomic, strong) CPMapButton * _Nullable dismissPanningButton;
        [NullAllowed, Export("dismissPanningButton", ArgumentSemantic.Strong)]
        CPMapButton DismissPanningButton { get; }

        // -(void)encodeWithCoder:(NSCoder * _Nonnull)aCoder;
        [Export("encodeWithCoder:")]
        void EncodeWithCoder(NSCoder aCoder);

        // -(void)loadView;
        [Export("loadView")]
        [Override]
        void LoadView();

        // -(void)viewDidLoad;
        [Export("viewDidLoad")]
        [Override]
        void ViewDidLoad();

        // -(void)viewWillDisappear:(BOOL)animated;
        [Export("viewWillDisappear:")]
        [Override]
        void ViewWillDisappear(bool animated);

        // -(void)viewSafeAreaInsetsDidChange __attribute__((objc_requires_super));
        [Export("viewSafeAreaInsetsDidChange")]
        [RequiresSuper]
        [Override]
        void ViewSafeAreaInsetsDidChange();
    }

    // @protocol MBStyleManagerDelegate <NSObject>
    [Model]
    [BaseType(typeof(NSObject))]
    interface MBStyleManagerDelegate
    {
        // @required -(CLLocation * _Nullable)locationForStyleManager:(MBStyleManager * _Nonnull)styleManager __attribute__((warn_unused_result));
        [Abstract]
        [Export("locationForStyleManager:")]
        [return: NullAllowed]
        CLLocation LocationForStyleManager(MBStyleManager styleManager);

        // @optional -(void)styleManager:(MBStyleManager * _Nonnull)styleManager didApplyStyle:(MBStyle * _Nonnull)style;
        [Export("styleManager:didApplyStyle:")]
        void StyleManager(MBStyleManager styleManager, MBStyle style);

        // @optional -(void)styleManagerDidRefreshAppearance:(MBStyleManager * _Nonnull)styleManager;
        [Export("styleManagerDidRefreshAppearance:")]
        void StyleManagerDidRefreshAppearance(MBStyleManager styleManager);
    }

    // @protocol MBNavigationMapViewDelegate
    [BaseType(typeof(NSObject))]
    [Model]
    interface MBNavigationMapViewDelegate
    {
        // @optional -(MGLStyleLayer * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView routeStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationMapView:routeStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationMapViewRouteStyleLayerWithIdentifier(MBNavigationMapView mapView, string identifier, MGLSource source);

        // @optional -(MGLStyleLayer * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView waypointStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationMapView:waypointStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationMapViewWaypointStyleLayerWithIdentifier(MBNavigationMapView mapView, string identifier, MGLSource source);

        // @optional -(MGLStyleLayer * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView waypointSymbolStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationMapView:waypointSymbolStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationMapViewWaypointSymbolStyleLayerWithIdentifier(MBNavigationMapView mapView, string identifier, MGLSource source);

        // @optional -(MGLStyleLayer * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView routeCasingStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationMapView:routeCasingStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationMapViewRouteCasingStyleLayerWithIdentifier(MBNavigationMapView mapView, string identifier, MGLSource source);

        // @optional -(void)navigationMapView:(MBNavigationMapView * _Nonnull)mapView didSelectRoute:(MBRoute * _Nonnull)route;
        [Export("navigationMapView:didSelectRoute:")]
        void NavigationMapViewDidSelectRoute(MBNavigationMapView mapView, MBRoute route);

        // @optional -(void)navigationMapView:(MBNavigationMapView * _Nonnull)mapView didSelectWaypoint:(MBWaypoint * _Nonnull)waypoint;
        [Export("navigationMapView:didSelectWaypoint:")]
        void NavigationMapViewDidSelectWaypoint(MBNavigationMapView mapView, MBWaypoint waypoint);

        // @optional -(MGLShape * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView shapeForRoutes:(NSArray<MBRoute *> * _Nonnull)routes __attribute__((warn_unused_result));
        [Export("navigationMapView:shapeForRoutes:")]
        [return: NullAllowed]
        MGLShape NavigationMapViewShapeForRoutes(MBNavigationMapView mapView, MBRoute[] routes);

        // @optional -(MGLShape * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView simplifiedShapeForRoute:(MBRoute * _Nonnull)route __attribute__((warn_unused_result));
        [Export("navigationMapView:simplifiedShapeForRoute:")]
        [return: NullAllowed]
        MGLShape NavigationMapViewSimplifiedShapeForRoute(MBNavigationMapView mapView, MBRoute route);

        // @optional -(MGLShape * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView shapeForWaypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints legIndex:(NSInteger)legIndex __attribute__((warn_unused_result));
        [Export("navigationMapView:shapeForWaypoints:legIndex:")]
        [return: NullAllowed]
        MGLShape NavigationMapViewShapeForWaypoints(MBNavigationMapView mapView, MBWaypoint[] waypoints, nint legIndex);

        // @optional -(CGPoint)navigationMapViewUserAnchorPoint:(MBNavigationMapView * _Nonnull)mapView __attribute__((warn_unused_result));
        [Export("navigationMapViewUserAnchorPoint:")]
        CGPoint NavigationMapViewUserAnchorPoint(MBNavigationMapView mapView);

        // @optional -(MGLAnnotationImage * _Nullable)navigationMapView:(MGLMapView * _Nonnull)mapView imageForAnnotation:(id<MGLAnnotation> _Nonnull)annotation __attribute__((deprecated("The NavigationMapView no longer forwards MGLMapViewDelegate messages. Use MGLMapViewDelegate.mapView(_:imageFor:) instead."))) __attribute__((warn_unused_result));
        [Export("navigationMapView:imageForAnnotation:")]
        [return: NullAllowed]
        MGLAnnotationImage NavigationMapViewImageForAnnotation(MGLMapView mapView, MGLAnnotation annotation);

        // @optional -(MGLAnnotationView * _Nullable)navigationMapView:(MGLMapView * _Nonnull)mapView viewForAnnotation:(id<MGLAnnotation> _Nonnull)annotation __attribute__((deprecated("The NavigationMapView no longer forwards MGLMapViewDelegate messages. Use MGLMapViewDelegate.mapView(_:viewFor:) instead."))) __attribute__((warn_unused_result));
        [Export("navigationMapView:viewForAnnotation:")]
        [return: NullAllowed]
        MGLAnnotationView NavigationMapViewViewForAnnotation(MGLMapView mapView, MGLAnnotation annotation);
    }

    // @interface MBCarPlayNavigationViewController : UIViewController <MBNavigationMapViewDelegate>
    [Introduced(PlatformName.iOS, 12, 0)]
    [BaseType(typeof(UIViewController))]
    interface MBCarPlayNavigationViewController : MBNavigationMapViewDelegate, MBStyleManagerDelegate
    {
        [Wrap("WeakCarPlayNavigationDelegate")]
        [NullAllowed]
        MBNavigationCarPlayDelegate CarPlayNavigationDelegate { get; set; }

        // @property (nonatomic, weak) id<MBNavigationCarPlayDelegate> _Nullable carPlayNavigationDelegate;
        [NullAllowed, Export("carPlayNavigationDelegate", ArgumentSemantic.Weak)]
        NSObject WeakCarPlayNavigationDelegate { get; set; }

        // @property (nonatomic) enum MBDrivingSide drivingSide;
        [Export("drivingSide", ArgumentSemantic.Assign)]
        MBDrivingSide DrivingSide { get; set; }

        // @property (nonatomic, strong) id<MBNavigationService> _Nonnull navigationService;
        [Export("navigationService", ArgumentSemantic.Strong)]
        MBNavigationService NavigationService { get; set; }

        // @property (readonly, nonatomic, strong) MBNavigationMapView * _Nullable mapView;
        [NullAllowed, Export("mapView", ArgumentSemantic.Strong)]
        MBNavigationMapView MapView { get; }

        // @property (nonatomic, weak) MBCarPlayCompassView * _Null_unspecified compassView;
        [Export("compassView", ArgumentSemantic.Weak)]
        MBCarPlayCompassView CompassView { get; set; }

        // @property (copy, nonatomic) NSArray<MBStyle *> * _Nonnull styles;
        [Export("styles", ArgumentSemantic.Copy)]
        MBStyle[] Styles { get; set; }

        // -(instancetype _Nonnull)initWithNavigationService:(id<MBNavigationService> _Nonnull)navigationService mapTemplate:(CPMapTemplate * _Nonnull)mapTemplate interfaceController:(CPInterfaceController * _Nonnull)interfaceController manager:(MBCarPlayManager * _Nonnull)manager styles:(NSArray<MBStyle *> * _Nullable)styles __attribute__((objc_designated_initializer));
        [Export("initWithNavigationService:mapTemplate:interfaceController:manager:styles:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBNavigationService navigationService, CPMapTemplate mapTemplate, CPInterfaceController interfaceController, MBCarPlayManager manager, [NullAllowed] MBStyle[] styles);

        // -(void)viewDidLoad;
        [Export("viewDidLoad")]
        [Override]
        void ViewDidLoad();

        // -(void)viewWillDisappear:(BOOL)animated;
        [Export("viewWillDisappear:")]
        [Override]
        void ViewWillDisappear(bool animated);

        // -(void)viewSafeAreaInsetsDidChange __attribute__((objc_requires_super));
        [Export("viewSafeAreaInsetsDidChange")]
        [RequiresSuper]
        [Override]
        void ViewSafeAreaInsetsDidChange();

        // -(void)startNavigationSessionForTrip:(CPTrip * _Nonnull)trip;
        [Export("startNavigationSessionForTrip:")]
        void StartNavigationSessionForTrip(CPTrip trip);

        // -(void)exitNavigationByCanceling:(BOOL)canceled;
        [Export("exitNavigationByCanceling:")]
        void ExitNavigationByCanceling(bool canceled);

        // -(void)showFeedback;
        [Export("showFeedback")]
        void ShowFeedback();

        // @property (nonatomic) BOOL tracksUserCourse;
        [Export("tracksUserCourse")]
        bool TracksUserCourse { get; set; }
    }

    // @interface MBCarPlaySearchController : NSObject
    [Introduced(PlatformName.iOS, 12, 0)]
    [BaseType(typeof(NSObject))]
    interface MBCarPlaySearchController
    {
        // -(void)listTemplate:(CPListTemplate * _Nonnull)listTemplate didSelectListItem:(CPListItem * _Nonnull)item completionHandler:(void (^ _Nonnull)(void))completionHandler;
        [Export("listTemplate:didSelectListItem:completionHandler:")]
        void ListTemplate(CPListTemplate listTemplate, CPListItem item, Action completionHandler);

        // -(void)searchTemplate:(CPSearchTemplate * _Nonnull)searchTemplate updatedSearchText:(NSString * _Nonnull)searchText completionHandler:(void (^ _Nonnull)(NSArray<CPListItem *> * _Nonnull))completionHandler;
        [Export("searchTemplate:updatedSearchText:completionHandler:")]
        void SearchTemplate(CPSearchTemplate searchTemplate, string searchText, Action<NSArray<CPListItem>> completionHandler);

        // -(void)searchTemplateSearchButtonPressed:(CPSearchTemplate * _Nonnull)searchTemplate;
        [Export("searchTemplateSearchButtonPressed:")]
        void SearchTemplateSearchButtonPressed(CPSearchTemplate searchTemplate);

        // -(void)searchTemplate:(CPSearchTemplate * _Nonnull)searchTemplate selectedResult:(CPListItem * _Nonnull)item completionHandler:(void (^ _Nonnull)(void))completionHandler;
        [Export("searchTemplate:selectedResult:completionHandler:")]
        void SearchTemplate(CPSearchTemplate searchTemplate, CPListItem item, Action completionHandler);


    }

    // @interface MBLineView : UIView
    [BaseType(typeof(UIView))]
    interface MBLineView
    {
        // @property (nonatomic, strong) UIColor * _Nonnull lineColor;
        [Export("lineColor", ArgumentSemantic.Strong)]
        UIColor LineColor { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBDashedLineView : MBLineView
    [BaseType(typeof(MBLineView))]
    interface MBDashedLineView
    {
        // @property (nonatomic) CGFloat dashedLength;
        [Export("dashedLength")]
        nfloat DashedLength { get; set; }

        // @property (nonatomic) CGFloat dashedGap;
        [Export("dashedGap")]
        nfloat DashedGap { get; set; }

        // -(void)layoutSubviews;
        [Export("layoutSubviews")]
        [Override]
        void LayoutSubviews();

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBDataCache : NSObject <MBBimodalDataCache>
    [BaseType(typeof(NSObject))]
    interface MBDataCache : MBBimodalDataCache
    {

    }

    // @interface MBStyle : NSObject
    [BaseType(typeof(NSObject))]
    interface MBStyle
    {
        // @property (nonatomic, strong) UIColor * _Nullable tintColor;
        [NullAllowed, Export("tintColor", ArgumentSemantic.Strong)]
        UIColor TintColor { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable fontFamily;
        [NullAllowed, Export("fontFamily")]
        string FontFamily { get; set; }

        // @property (nonatomic) enum MBStyleType styleType;
        [Export("styleType", ArgumentSemantic.Assign)]
        MBStyleType StyleType { get; set; }

        // @property (copy, nonatomic) NSURL * _Nonnull mapStyleURL;
        [Export("mapStyleURL", ArgumentSemantic.Copy)]
        NSUrl MapStyleURL { get; set; }

        // @property (copy, nonatomic) NSURL * _Nonnull previewMapStyleURL;
        [Export("previewMapStyleURL", ArgumentSemantic.Copy)]
        NSUrl PreviewMapStyleURL { get; set; }

        // -(void)apply;
        [Export("apply")]
        void Apply();
    }

    // @interface MBDayStyle : MBStyle
    [BaseType(typeof(MBStyle))]
    interface MBDayStyle
    {
        // -(void)apply;
        [Export("apply")]
        [Override]
        void Apply();
    }

    // @protocol DeprecatedStatusViewDelegate
    [BaseType(typeof(NSObject), Name = "_TtP16MapboxNavigation28DeprecatedStatusViewDelegate_")]
    [Model]
    interface DeprecatedStatusViewDelegate
    {
    }

    // @interface MBDismissButton : MBButton
    [BaseType(typeof(MBButton))]
    interface MBDismissButton
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBDistanceLabel : MBStylableLabel
    [BaseType(typeof(MBStylableLabel))]
    interface MBDistanceLabel
    {
        // @property (nonatomic, strong) UIColor * _Nonnull valueTextColor;
        [Export("valueTextColor", ArgumentSemantic.Strong)]
        UIColor ValueTextColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull unitTextColor;
        [Export("unitTextColor", ArgumentSemantic.Strong)]
        UIColor UnitTextColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull valueFont;
        [Export("valueFont", ArgumentSemantic.Strong)]
        UIFont ValueFont { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull unitFont;
        [Export("unitFont", ArgumentSemantic.Strong)]
        UIFont UnitFont { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBDistanceRemainingLabel : MBStylableLabel
    [BaseType(typeof(MBStylableLabel))]
    interface MBDistanceRemainingLabel
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBEndOfRouteButton : MBStylableButton
    [BaseType(typeof(MBStylableButton))]
    interface MBEndOfRouteButton
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBStylableTextView : UITextView
    [BaseType(typeof(UITextView))]
    interface MBStylableTextView
    {
        // @property (nonatomic, strong) UIColor * _Nonnull normalTextColor;
        [Export("normalTextColor", ArgumentSemantic.Strong)]
        UIColor NormalTextColor { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame textContainer:(NSTextContainer * _Nullable)textContainer __attribute__((availability(ios, introduced=7.0))) __attribute__((objc_designated_initializer));
        [Introduced(PlatformName.iOS, 7, 0)]
        [Export("initWithFrame:textContainer:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame, [NullAllowed] NSTextContainer textContainer);
    }

    // @interface MBEndOfRouteCommentView : MBStylableTextView
    [BaseType(typeof(MBStylableTextView))]
    interface MBEndOfRouteCommentView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame textContainer:(NSTextContainer * _Nullable)textContainer __attribute__((availability(ios, introduced=7.0))) __attribute__((objc_designated_initializer));
        [Introduced(PlatformName.iOS, 7, 0)]
        [Export("initWithFrame:textContainer:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame, [NullAllowed] NSTextContainer textContainer);
    }

    // @interface MBEndOfRouteContentView : UIView
    [BaseType(typeof(UIView))]
    interface MBEndOfRouteContentView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBEndOfRouteStaticLabel : MBStylableLabel
    [BaseType(typeof(MBStylableLabel))]
    interface MBEndOfRouteStaticLabel
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBEndOfRouteTitleLabel : MBStylableLabel
    [BaseType(typeof(MBStylableLabel))]
    interface MBEndOfRouteTitleLabel
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface ExitView : MBStylableView
    [BaseType(typeof(MBStylableView), Name = "_TtC16MapboxNavigation8ExitView")]
    interface ExitView
    {
        // @property (nonatomic, strong) UIColor * _Nullable foregroundColor;
        [NullAllowed, Export("foregroundColor", ArgumentSemantic.Strong)]
        UIColor ForegroundColor { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBFeedbackItem : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBFeedbackItem
    {
        // @property (copy, nonatomic) NSString * _Nonnull title;
        [Export("title")]
        string Title { get; set; }

        // @property (nonatomic, strong) UIImage * _Nonnull image;
        [Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @property (nonatomic) enum MBFeedbackType feedbackType;
        [Export("feedbackType", ArgumentSemantic.Assign)]
        MBFeedbackType FeedbackType { get; set; }

        // -(instancetype _Nonnull)initWithTitle:(NSString * _Nonnull)title image:(UIImage * _Nonnull)image feedbackType:(enum MBFeedbackType)feedbackType __attribute__((objc_designated_initializer));
        [Export("initWithTitle:image:feedbackType:")]
        [DesignatedInitializer]
        IntPtr Constructor(string title, UIImage image, MBFeedbackType feedbackType);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBFeedbackItem New();
    }

    // @interface MBFeedbackViewController : UIViewController <UIGestureRecognizerDelegate>
    [BaseType(typeof(UIViewController))]
    interface MBFeedbackViewController : IUIGestureRecognizerDelegate, IUICollectionViewDelegateFlowLayout, IUICollectionViewDelegate, IUIViewControllerTransitioningDelegate
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        FeedbackViewControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<FeedbackViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(instancetype _Nonnull)initWithEventsManager:(MBNavigationEventsManager * _Nonnull)eventsManager __attribute__((objc_designated_initializer));
        [Export("initWithEventsManager:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBNavigationEventsManager eventsManager);

        // -(void)encodeWithCoder:(NSCoder * _Nonnull)aCoder;
        [Export("encodeWithCoder:")]
        void EncodeWithCoder(NSCoder aCoder);

        // -(void)viewDidLoad;
        [Export("viewDidLoad")]
        [Override]
        void ViewDidLoad();

        // -(void)viewWillAppear:(BOOL)animated;
        [Export("viewWillAppear:")]
        [Override]
        void ViewWillAppear(bool animated);

        // -(void)viewDidAppear:(BOOL)animated;
        [Export("viewDidAppear:")]
        [Override]
        void ViewDidAppear(bool animated);

        // -(void)willTransitionToTraitCollection:(UITraitCollection * _Nonnull)newCollection withTransitionCoordinator:(id<UIViewControllerTransitionCoordinator> _Nonnull)coordinator;
        [Export("willTransitionToTraitCollection:withTransitionCoordinator:")]
        [Override]
        void WillTransitionToTraitCollection(UITraitCollection newCollection, IUIViewControllerTransitionCoordinator coordinator);

        // -(void)dismissFeedback;
        [Export("dismissFeedback")]
        void DismissFeedback();

        // -(BOOL)gestureRecognizer:(UIGestureRecognizer * _Nonnull)gestureRecognizer shouldReceiveTouch:(UITouch * _Nonnull)touch __attribute__((warn_unused_result));
        [Export("gestureRecognizer:shouldReceiveTouch:")]
        bool GestureRecognizer(UIGestureRecognizer gestureRecognizer, UITouch touch);

        // -(CGSize)collectionView:(UICollectionView * _Nonnull)collectionView layout:(UICollectionViewLayout * _Nonnull)collectionViewLayout sizeForItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath __attribute__((warn_unused_result));
        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        CGSize CollectionViewLayout(UICollectionView collectionView, UICollectionViewLayout collectionViewLayout, NSIndexPath indexPath);

        // -(void)collectionView:(UICollectionView * _Nonnull)collectionView didSelectItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("collectionView:didSelectItemAtIndexPath:")]
        void CollectionViewDidSelectItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

        // -(UICollectionViewCell * _Nonnull)collectionView:(UICollectionView * _Nonnull)collectionView cellForItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath __attribute__((warn_unused_result));
        [Export("collectionView:cellForItemAtIndexPath:")]
        UICollectionViewCell CollectionViewCellForItemAtIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

        // -(NSInteger)collectionView:(UICollectionView * _Nonnull)collectionView numberOfItemsInSection:(NSInteger)section __attribute__((warn_unused_result));
        [Export("collectionView:numberOfItemsInSection:")]
        nint CollectionViewNumberOfItemsInSection(UICollectionView collectionView, nint section);

        // -(id<UIViewControllerAnimatedTransitioning> _Nullable)animationControllerForDismissedController:(UIViewController * _Nonnull)dismissed __attribute__((warn_unused_result));
        [Export("animationControllerForDismissedController:")]
        [return: NullAllowed]
        UIViewControllerAnimatedTransitioning AnimationControllerForDismissedController(UIViewController dismissed);

        // -(id<UIViewControllerAnimatedTransitioning> _Nullable)animationControllerForPresentedController:(UIViewController * _Nonnull)presented presentingController:(UIViewController * _Nonnull)presenting sourceController:(UIViewController * _Nonnull)source __attribute__((warn_unused_result));
        [Export("animationControllerForPresentedController:presentingController:sourceController:")]
        [return: NullAllowed]
        UIViewControllerAnimatedTransitioning AnimationControllerForPresentedController(UIViewController presented, UIViewController presenting, UIViewController source);

        // -(id<UIViewControllerInteractiveTransitioning> _Nullable)interactionControllerForDismissal:(id<UIViewControllerAnimatedTransitioning> _Nonnull)animator __attribute__((warn_unused_result));
        [Export("interactionControllerForDismissal:")]
        [return: NullAllowed]
        UIViewControllerInteractiveTransitioning InteractionControllerForDismissal(UIViewControllerAnimatedTransitioning animator);

        // -(NSInteger)numberOfSectionsInCollectionView:(UICollectionView * _Nonnull)collectionView __attribute__((warn_unused_result));
        [Export("numberOfSectionsInCollectionView:")]
        nint NumberOfSectionsInCollectionView(UICollectionView collectionView);

      

        // -(void)scrollViewDidScroll:(UIScrollView * _Nonnull)scrollView;
        [Export("scrollViewDidScroll:")]
        void ScrollViewDidScroll(UIScrollView scrollView);
    }

    // @protocol FeedbackViewControllerDelegate
    [BaseType(typeof(NSObject), Name = "_TtP16MapboxNavigation30FeedbackViewControllerDelegate_")]
    [Model]
    interface FeedbackViewControllerDelegate
    {
        // @optional -(void)feedbackViewControllerDidOpen:(MBFeedbackViewController * _Nonnull)feedbackViewController;
        [Export("feedbackViewControllerDidOpen:")]
        void FeedbackViewControllerDidOpen(MBFeedbackViewController feedbackViewController);

        // @optional -(void)feedbackViewController:(MBFeedbackViewController * _Nonnull)feedbackViewController didSendFeedbackItem:(MBFeedbackItem * _Nonnull)feedbackItem UUID:(NSUUID * _Nonnull)uuid;
        [Export("feedbackViewController:didSendFeedbackItem:UUID:")]
        void FeedbackViewController(MBFeedbackViewController feedbackViewController, MBFeedbackItem feedbackItem, NSUuid uuid);

        // @optional -(void)feedbackViewControllerDidCancel:(MBFeedbackViewController * _Nonnull)feedbackViewController;
        [Export("feedbackViewControllerDidCancel:")]
        void FeedbackViewControllerDidCancel(MBFeedbackViewController feedbackViewController);
    }

    // @interface MBFloatingButton : MBButton
    [BaseType(typeof(MBButton))]
    interface MBFloatingButton
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface GenericRouteShield : MBStylableView
    [BaseType(typeof(MBStylableView), Name = "_TtC16MapboxNavigation18GenericRouteShield")]
    interface GenericRouteShield
    {
        // @property (nonatomic, strong) UIColor * _Nullable foregroundColor;
        [NullAllowed, Export("foregroundColor", ArgumentSemantic.Strong)]
        UIColor ForegroundColor { get; set; }
    }

    // @interface MBHighlightedButton : MBButton
    [BaseType(typeof(MBButton))]
    interface MBHighlightedButton
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBInstructionLabel : MBStylableLabel
    [BaseType(typeof(MBStylableLabel))]
    interface MBInstructionLabel
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBInstructionsBannerView : BaseInstructionsBannerView <NavigationComponent>
    [BaseType(typeof(BaseInstructionsBannerView))]
    interface MBInstructionsBannerView : NavigationComponent
    {
        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didPassVisualInstructionPoint:(MBVisualInstructionBanner * _Nonnull)instruction routeProgress:(MBRouteProgress * _Nonnull)routeProgress;
        [Export("navigationService:didPassVisualInstructionPoint:routeProgress:")]
        void NavigationService(MBNavigationService service, MBVisualInstructionBanner instruction, MBRouteProgress routeProgress);

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @protocol MBInstructionsBannerViewDelegate
    [BaseType(typeof(NSObject))]
    [Model]
    interface MBInstructionsBannerViewDelegate
    {
        // @optional -(void)didTapInstructionsBanner:(BaseInstructionsBannerView * _Nonnull)sender;
        [Export("didTapInstructionsBanner:")]
        void DidTapInstructionsBanner(BaseInstructionsBannerView sender);

        // @optional -(void)didDragInstructionsBanner:(BaseInstructionsBannerView * _Nonnull)sender __attribute__((deprecated("Please use didSwipeInstructionsBanner instead.")));
        [Export("didDragInstructionsBanner:")]
        void DidDragInstructionsBanner(BaseInstructionsBannerView sender);

        // @optional -(void)didSwipeInstructionsBanner:(BaseInstructionsBannerView * _Nonnull)sender swipeDirection:(UISwipeGestureRecognizerDirection)direction;
        [Export("didSwipeInstructionsBanner:swipeDirection:")]
        void DidSwipeInstructionsBanner(BaseInstructionsBannerView sender, UISwipeGestureRecognizerDirection direction);
    }

    // @interface MBLaneView : UIView
    [BaseType(typeof(UIView))]
    interface MBLaneView
    {
        // @property (readonly, nonatomic) CGSize intrinsicContentSize;
        [Export("intrinsicContentSize")]
        [Override]
        CGSize IntrinsicContentSize { get; }

        // @property (nonatomic, strong) UIColor * _Nonnull primaryColor;
        [Export("primaryColor", ArgumentSemantic.Strong)]
        UIColor PrimaryColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull secondaryColor;
        [Export("secondaryColor", ArgumentSemantic.Strong)]
        UIColor SecondaryColor { get; set; }

        // -(void)drawRect:(CGRect)rect;
        [Export("drawRect:")]
        void DrawRect(CGRect rect);

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBLanesStyleKit : NSObject
    [BaseType(typeof(NSObject))]
    interface MBLanesStyleKit
    {
        // +(void)drawLaneStraightRightWithFrame:(CGRect)targetFrame resizing:(enum LanesStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size flipHorizontally:(BOOL)flipHorizontally;
        [Static]
        [Export("drawLaneStraightRightWithFrame:resizing:primaryColor:size:flipHorizontally:")]
        void DrawLaneStraightRightWithFrame(CGRect targetFrame, LanesStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size, bool flipHorizontally);

        // +(void)drawLaneStraightOnlyWithFrame:(CGRect)targetFrame resizing:(enum LanesStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor secondaryColor:(UIColor * _Nonnull)secondaryColor size:(CGSize)size flipHorizontally:(BOOL)flipHorizontally;
        [Static]
        [Export("drawLaneStraightOnlyWithFrame:resizing:primaryColor:secondaryColor:size:flipHorizontally:")]
        void DrawLaneStraightOnlyWithFrame(CGRect targetFrame, LanesStyleKitResizingBehavior resizing, UIColor primaryColor, UIColor secondaryColor, CGSize size, bool flipHorizontally);

        // +(void)drawLaneRightWithFrame:(CGRect)targetFrame resizing:(enum LanesStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size flipHorizontally:(BOOL)flipHorizontally;
        [Static]
        [Export("drawLaneRightWithFrame:resizing:primaryColor:size:flipHorizontally:")]
        void DrawLaneRightWithFrame(CGRect targetFrame, LanesStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size, bool flipHorizontally);

        // +(void)drawLaneRightOnlyWithFrame:(CGRect)targetFrame resizing:(enum LanesStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor secondaryColor:(UIColor * _Nonnull)secondaryColor size:(CGSize)size flipHorizontally:(BOOL)flipHorizontally;
        [Static]
        [Export("drawLaneRightOnlyWithFrame:resizing:primaryColor:secondaryColor:size:flipHorizontally:")]
        void DrawLaneRightOnlyWithFrame(CGRect targetFrame, LanesStyleKitResizingBehavior resizing, UIColor primaryColor, UIColor secondaryColor, CGSize size, bool flipHorizontally);

        // +(void)drawLaneStraightWithFrame:(CGRect)targetFrame resizing:(enum LanesStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size;
        [Static]
        [Export("drawLaneStraightWithFrame:resizing:primaryColor:size:")]
        void DrawLaneStraightWithFrame(CGRect targetFrame, LanesStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size);

        // +(void)drawLaneUturnWithFrame:(CGRect)targetFrame resizing:(enum LanesStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size flipHorizontally:(BOOL)flipHorizontally;
        [Static]
        [Export("drawLaneUturnWithFrame:resizing:primaryColor:size:flipHorizontally:")]
        void DrawLaneUturnWithFrame(CGRect targetFrame, LanesStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size, bool flipHorizontally);

        // +(void)drawLaneSlightRightWithFrame:(CGRect)targetFrame resizing:(enum LanesStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size flipHorizontally:(BOOL)flipHorizontally;
        [Static]
        [Export("drawLaneSlightRightWithFrame:resizing:primaryColor:size:flipHorizontally:")]
        void DrawLaneSlightRightWithFrame(CGRect targetFrame, LanesStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size, bool flipHorizontally);
    }

    // @interface MBLanesView : UIView <NavigationComponent>
    [BaseType(typeof(UIView))]
    interface MBLanesView : NavigationComponent
    {
        // -(void)prepareForInterfaceBuilder;
        [Export("prepareForInterfaceBuilder")]
        [Override]
        void PrepareForInterfaceBuilder();

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didPassVisualInstructionPoint:(MBVisualInstructionBanner * _Nonnull)instruction routeProgress:(MBRouteProgress * _Nonnull)routeProgress;
        [Export("navigationService:didPassVisualInstructionPoint:routeProgress:")]
        void NavigationService(MBNavigationService service, MBVisualInstructionBanner instruction, MBRouteProgress routeProgress);

        // -(void)updateForVisualInstructionBanner:(MBVisualInstructionBanner * _Nullable)visualInstruction;
        [Export("updateForVisualInstructionBanner:")]
        void UpdateForVisualInstructionBanner([NullAllowed] MBVisualInstructionBanner visualInstruction);
    }

    //TODO
    //// @interface MapboxNavigation_Swift_1273
    //interface MapboxNavigation_Swift_1273
    //{
    //    // @property (readonly, nonatomic, class) BOOL hasChinaBaseURL;
    //    [Static]
    //    [Export("hasChinaBaseURL")]
    //    bool HasChinaBaseURL { }

    //    // +(BOOL)hasChinaBaseURL __attribute__((warn_unused_result));
    //    [Static]
    //    [Export("hasChinaBaseURL")]
    //    [Verify(MethodToProperty)]
    //    bool HasChinaBaseURL { get; }
    //}

    //TODO
    //// @interface MapboxNavigation_Swift_1282
    //interface MapboxNavigation_Swift_1282
    //{
    //    // @property (readonly, copy, nonatomic, class) NSURL * _Nonnull navigationGuidanceDayStyleURL;
    //    [Static]
    //    [Export("navigationGuidanceDayStyleURL", ArgumentSemantic.Copy)]
    //    NSUrl NavigationGuidanceDayStyleURL { }

    //    // +(NSURL * _Nonnull)navigationGuidanceDayStyleURL __attribute__((warn_unused_result));
    //    [Static]
    //    [Export("navigationGuidanceDayStyleURL")]
    //    [Verify(MethodToProperty)]
    //    NSUrl NavigationGuidanceDayStyleURL { get; }

    //    // @property (readonly, copy, nonatomic, class) NSURL * _Nonnull navigationGuidanceNightStyleURL;
    //    [Static]
    //    [Export("navigationGuidanceNightStyleURL", ArgumentSemantic.Copy)]
    //    NSUrl NavigationGuidanceNightStyleURL { }

    //    // +(NSURL * _Nonnull)navigationGuidanceNightStyleURL __attribute__((warn_unused_result));
    //    [Static]
    //    [Export("navigationGuidanceNightStyleURL")]
    //    [Verify(MethodToProperty)]
    //    NSUrl NavigationGuidanceNightStyleURL { get; }

    //    // +(NSURL * _Nonnull)navigationGuidanceDayStyleURLWithVersion:(NSInteger)version __attribute__((warn_unused_result));
    //    [Static]
    //    [Export("navigationGuidanceDayStyleURLWithVersion:")]
    //    NSUrl NavigationGuidanceDayStyleURLWithVersion(nint version);

    //    // +(NSURL * _Nonnull)navigationGuidanceNightStyleURLWithVersion:(NSInteger)version __attribute__((warn_unused_result));
    //    [Static]
    //    [Export("navigationGuidanceNightStyleURLWithVersion:")]
    //    NSUrl NavigationGuidanceNightStyleURLWithVersion(nint version);

    //    // @property (readonly, copy, nonatomic, class) NSURL * _Nonnull navigationPreviewDayStyleURL;
    //    [Static]
    //    [Export("navigationPreviewDayStyleURL", ArgumentSemantic.Copy)]
    //    NSUrl NavigationPreviewDayStyleURL { }

    //    // +(NSURL * _Nonnull)navigationPreviewDayStyleURL __attribute__((warn_unused_result));
    //    [Static]
    //    [Export("navigationPreviewDayStyleURL")]
    //    [Verify(MethodToProperty)]
    //    NSUrl NavigationPreviewDayStyleURL { get; }

    //    // @property (readonly, copy, nonatomic, class) NSURL * _Nonnull navigationPreviewNightStyleURL;
    //    [Static]
    //    [Export("navigationPreviewNightStyleURL", ArgumentSemantic.Copy)]
    //    NSUrl NavigationPreviewNightStyleURL { }

    //    // +(NSURL * _Nonnull)navigationPreviewNightStyleURL __attribute__((warn_unused_result));
    //    [Static]
    //    [Export("navigationPreviewNightStyleURL")]
    //    [Verify(MethodToProperty)]
    //    NSUrl NavigationPreviewNightStyleURL { get; }

    //    // +(NSURL * _Nonnull)navigationPreviewDayStyleURLWithVersion:(NSInteger)version __attribute__((warn_unused_result));
    //    [Static]
    //    [Export("navigationPreviewDayStyleURLWithVersion:")]
    //    NSUrl NavigationPreviewDayStyleURLWithVersion(nint version);

    //    // +(NSURL * _Nonnull)navigationPreviewNightStyleURLWithVersion:(NSInteger)version __attribute__((warn_unused_result));
    //    [Static]
    //    [Export("navigationPreviewNightStyleURLWithVersion:")]
    //    NSUrl NavigationPreviewNightStyleURLWithVersion(nint version);
    //}

    // @interface MBManeuverContainerView : UIView
    [BaseType(typeof(UIView))]
    interface MBManeuverContainerView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBManeuverView : UIView
    [BaseType(typeof(UIView))]
    interface MBManeuverView
    {
        // @property (nonatomic, strong) UIColor * _Nonnull primaryColor;
        [Export("primaryColor", ArgumentSemantic.Strong)]
        UIColor PrimaryColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull secondaryColor;
        [Export("secondaryColor", ArgumentSemantic.Strong)]
        UIColor SecondaryColor { get; set; }

        // @property (nonatomic) BOOL isStart;
        [Export("isStart")]
        bool IsStart { get; set; }

        // @property (nonatomic) BOOL isEnd;
        [Export("isEnd")]
        bool IsEnd { get; set; }

        // @property (nonatomic, strong) MBVisualInstruction * _Nullable visualInstruction;
        [NullAllowed, Export("visualInstruction", ArgumentSemantic.Strong)]
        MBVisualInstruction VisualInstruction { get; set; }

        // @property (nonatomic) enum MBDrivingSide drivingSide;
        [Export("drivingSide", ArgumentSemantic.Assign)]
        MBDrivingSide DrivingSide { get; set; }

        // -(void)drawRect:(CGRect)rect;
        [Export("drawRect:")]
        void DrawRect(CGRect rect);

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBManeuversStyleKit : NSObject
    [BaseType(typeof(NSObject))]
    interface MBManeuversStyleKit
    {
        // +(void)drawArrow180rightWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size;
        [Static]
        [Export("drawArrow180rightWithFrame:resizing:primaryColor:size:")]
        void DrawArrow180rightWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size);

        // +(void)drawArrowrightWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size;
        [Static]
        [Export("drawArrowrightWithFrame:resizing:primaryColor:size:")]
        void DrawArrowrightWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size);

        // +(void)drawArrowslightrightWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size;
        [Static]
        [Export("drawArrowslightrightWithFrame:resizing:primaryColor:size:")]
        void DrawArrowslightrightWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size);

        // +(void)drawArrowstraightWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size;
        [Static]
        [Export("drawArrowstraightWithFrame:resizing:primaryColor:size:")]
        void DrawArrowstraightWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size);

        // +(void)drawArrowsharprightWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size;
        [Static]
        [Export("drawArrowsharprightWithFrame:resizing:primaryColor:size:")]
        void DrawArrowsharprightWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size);

        // +(void)drawArriveWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size;
        [Static]
        [Export("drawArriveWithFrame:resizing:primaryColor:size:")]
        void DrawArriveWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size);

        // +(void)drawStartingWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size;
        [Static]
        [Export("drawStartingWithFrame:resizing:primaryColor:size:")]
        void DrawStartingWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size);

        // +(void)drawDestinationWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size;
        [Static]
        [Export("drawDestinationWithFrame:resizing:primaryColor:size:")]
        void DrawDestinationWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size);

        // +(void)drawMergeWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor secondaryColor:(UIColor * _Nonnull)secondaryColor size:(CGSize)size;
        [Static]
        [Export("drawMergeWithFrame:resizing:primaryColor:secondaryColor:size:")]
        void DrawMergeWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, UIColor secondaryColor, CGSize size);

        // +(void)drawForkWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor secondaryColor:(UIColor * _Nonnull)secondaryColor size:(CGSize)size;
        [Static]
        [Export("drawForkWithFrame:resizing:primaryColor:secondaryColor:size:")]
        void DrawForkWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, UIColor secondaryColor, CGSize size);

        // +(void)drawOfframpWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor secondaryColor:(UIColor * _Nonnull)secondaryColor size:(CGSize)size;
        [Static]
        [Export("drawOfframpWithFrame:resizing:primaryColor:secondaryColor:size:")]
        void DrawOfframpWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, UIColor secondaryColor, CGSize size);

        // +(void)drawArriverightWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size;
        [Static]
        [Export("drawArriverightWithFrame:resizing:primaryColor:size:")]
        void DrawArriverightWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size);

        // +(void)drawRoundaboutWithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor secondaryColor:(UIColor * _Nonnull)secondaryColor size:(CGSize)size roundabout_angle:(CGFloat)roundabout_angle roundabout_radius:(CGFloat)roundabout_radius;
        [Static]
        [Export("drawRoundaboutWithFrame:resizing:primaryColor:secondaryColor:size:roundabout_angle:roundabout_radius:")]
        void DrawRoundaboutWithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, UIColor secondaryColor, CGSize size, nfloat roundabout_angle, nfloat roundabout_radius);

        // +(void)drawArriveright2WithFrame:(CGRect)targetFrame resizing:(enum ManeuversStyleKitResizingBehavior)resizing primaryColor:(UIColor * _Nonnull)primaryColor size:(CGSize)size;
        [Static]
        [Export("drawArriveright2WithFrame:resizing:primaryColor:size:")]
        void DrawArriveright2WithFrame(CGRect targetFrame, ManeuversStyleKitResizingBehavior resizing, UIColor primaryColor, CGSize size);
    }

    // @interface MBRouteVoiceController : NSObject <AVSpeechSynthesizerDelegate>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRouteVoiceController : IAVSpeechSynthesizerDelegate
    {
        // @property (nonatomic) BOOL playRerouteSound;
        [Export("playRerouteSound")]
        bool PlayRerouteSound { get; set; }

        // @property (nonatomic, strong) AVAudioPlayer * _Nonnull rerouteSoundPlayer;
        [Export("rerouteSoundPlayer", ArgumentSemantic.Strong)]
        AVAudioPlayer RerouteSoundPlayer { get; set; }

        [Wrap("WeakVoiceControllerDelegate")]
        [NullAllowed]
        MBVoiceControllerDelegate VoiceControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBVoiceControllerDelegate> _Nullable voiceControllerDelegate;
        [NullAllowed, Export("voiceControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakVoiceControllerDelegate { get; set; }

        // -(instancetype _Nonnull)initWithNavigationService:(id<MBNavigationService> _Nonnull)navigationService __attribute__((objc_designated_initializer));
        [Export("initWithNavigationService:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBNavigationService navigationService);

        // -(void)speechSynthesizer:(AVSpeechSynthesizer * _Nonnull)synthesizer didFinishSpeechUtterance:(AVSpeechUtterance * _Nonnull)utterance;
        [Export("speechSynthesizer:didFinishSpeechUtterance:")]
        void SpeechSynthesizer(AVSpeechSynthesizer synthesizer, AVSpeechUtterance utterance);

        // -(void)didPassSpokenInstructionPointWithNotification:(NSNotification * _Nonnull)notification;
        [Export("didPassSpokenInstructionPointWithNotification:")]
        void DidPassSpokenInstructionPointWithNotification(NSNotification notification);
    }

    // @interface MBMapboxVoiceController : MBRouteVoiceController <AVAudioPlayerDelegate>
    [BaseType(typeof(MBRouteVoiceController))]
    interface MBMapboxVoiceController : IAVAudioPlayerDelegate
    {
        // @property (nonatomic) NSTimeInterval timeoutIntervalForRequest;
        [Export("timeoutIntervalForRequest")]
        double TimeoutIntervalForRequest { get; set; }

        // @property (nonatomic) NSInteger stepsAheadToCache;
        [Export("stepsAheadToCache")]
        nint StepsAheadToCache { get; set; }

        // @property (nonatomic, strong) AVAudioPlayer * _Nullable audioPlayer;
        [NullAllowed, Export("audioPlayer", ArgumentSemantic.Strong)]
        AVAudioPlayer AudioPlayer { get; set; }

        // -(instancetype _Nonnull)initWithNavigationService:(id<MBNavigationService> _Nonnull)navigationService speechClient:(MBSpeechSynthesizer * _Nonnull)speechClient dataCache:(id<MBBimodalDataCache> _Nonnull)dataCache audioPlayerType:(Class _Nullable)audioPlayerType __attribute__((objc_designated_initializer));
        [Export("initWithNavigationService:speechClient:dataCache:audioPlayerType:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBNavigationService navigationService, MBSpeechSynthesizer speechClient, MBBimodalDataCache dataCache, [NullAllowed] Class audioPlayerType);

        // -(void)audioPlayerDidFinishPlaying:(AVAudioPlayer * _Nonnull)player successfully:(BOOL)flag;
        [Export("audioPlayerDidFinishPlaying:successfully:")]
        void AudioPlayerDidFinishPlaying(AVAudioPlayer player, bool flag);

        // -(void)didPassSpokenInstructionPointWithNotification:(NSNotification * _Nonnull)notification;
        [Export("didPassSpokenInstructionPointWithNotification:")]
        [Override]
        void DidPassSpokenInstructionPointWithNotification(NSNotification notification);

        // -(void)speak:(MBSpokenInstruction * _Nonnull)instruction;
        [Export("speak:")]
        void Speak(MBSpokenInstruction instruction);

        // -(void)speakWithDefaultSpeechSynthesizer:(MBSpokenInstruction * _Nonnull)instruction error:(NSError * _Nullable)error;
        [Export("speakWithDefaultSpeechSynthesizer:error:")]
        void SpeakWithDefaultSpeechSynthesizer(MBSpokenInstruction instruction, [NullAllowed] NSError error);

        // -(void)fetchAndSpeakWithInstruction:(MBSpokenInstruction * _Nonnull)instruction;
        [Export("fetchAndSpeakWithInstruction:")]
        void FetchAndSpeakWithInstruction(MBSpokenInstruction instruction);

        // -(void)downloadAndCacheSpokenInstructionWithInstruction:(MBSpokenInstruction * _Nonnull)instruction;
        [Export("downloadAndCacheSpokenInstructionWithInstruction:")]
        void DownloadAndCacheSpokenInstructionWithInstruction(MBSpokenInstruction instruction);

        // -(void)play:(NSData * _Nonnull)data;
        [Export("play:")]
        void Play(NSData data);
    }

    // @interface MBMarkerView : UIView
    [BaseType(typeof(UIView))]
    interface MBMarkerView
    {
        // @property (nonatomic, strong) UIColor * _Nonnull innerColor;
        [Export("innerColor", ArgumentSemantic.Strong)]
        UIColor InnerColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull shadowColor;
        [Export("shadowColor", ArgumentSemantic.Strong)]
        UIColor ShadowColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull pinColor;
        [Export("pinColor", ArgumentSemantic.Strong)]
        UIColor PinColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull strokeColor;
        [Export("strokeColor", ArgumentSemantic.Strong)]
        UIColor StrokeColor { get; set; }

        // -(void)layoutSubviews;
        [Export("layoutSubviews")]
        [Override]
        void LayoutSubviews();

        // -(void)drawRect:(CGRect)rect;
        [Export("drawRect:")]
        void DrawRect(CGRect rect);

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @protocol NavigationMapInteractionObserver
    [BaseType(typeof(NSObject), Name = "_TtP16MapboxNavigation32NavigationMapInteractionObserver_")]
    [Protocol, Model]
    interface NavigationMapInteractionObserver
    {
        // @required -(void)navigationViewControllerDidCenterOnLocation:(CLLocation * _Nonnull)location;
        [Abstract]
        [Export("navigationViewControllerDidCenterOnLocation:")]
        void NavigationViewControllerDidCenterOnLocation(CLLocation location);
    }

    // @interface MBNavigationMapView <UIGestureRecognizerDelegate>
    [BaseType(typeof(NSObject))]
    interface MBNavigationMapView : IUIGestureRecognizerDelegate
    {
        // @property (nonatomic) int minimumFramesPerSecond;
        [Export("minimumFramesPerSecond")]
        int MinimumFramesPerSecond { get; set; }

        // @property (nonatomic) CLLocationDistance defaultAltitude;
        [Export("defaultAltitude")]
        double DefaultAltitude { get; set; }

        // @property (nonatomic) CLLocationDistance zoomedOutMotorwayAltitude;
        [Export("zoomedOutMotorwayAltitude")]
        double ZoomedOutMotorwayAltitude { get; set; }

        // @property (nonatomic) CLLocationDistance longManeuverDistance;
        [Export("longManeuverDistance")]
        double LongManeuverDistance { get; set; }

        // @property (nonatomic) CGFloat tapGestureDistanceThreshold;
        [Export("tapGestureDistanceThreshold")]
        nfloat TapGestureDistanceThreshold { get; set; }

        [Wrap("WeakNavigationMapViewDelegate")]
        [NullAllowed]
        MBNavigationMapViewDelegate NavigationMapViewDelegate { get; set; }

        // @property (nonatomic, weak) id<MBNavigationMapViewDelegate> _Nullable navigationMapViewDelegate;
        [NullAllowed, Export("navigationMapViewDelegate", ArgumentSemantic.Weak)]
        NSObject WeakNavigationMapViewDelegate { get; set; }

        [Wrap("WeakNavigationMapDelegate")]
        [NullAllowed]
        MBNavigationMapViewDelegate NavigationMapDelegate { get; set; }

        // @property (nonatomic, weak) id<MBNavigationMapViewDelegate> _Nullable navigationMapDelegate __attribute__((deprecated("", "navigationMapViewDelegate")));
        [NullAllowed, Export("navigationMapDelegate", ArgumentSemantic.Weak)]
        NSObject WeakNavigationMapDelegate { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull trafficUnknownColor;
        [Export("trafficUnknownColor", ArgumentSemantic.Strong)]
        UIColor TrafficUnknownColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull trafficLowColor;
        [Export("trafficLowColor", ArgumentSemantic.Strong)]
        UIColor TrafficLowColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull trafficModerateColor;
        [Export("trafficModerateColor", ArgumentSemantic.Strong)]
        UIColor TrafficModerateColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull trafficHeavyColor;
        [Export("trafficHeavyColor", ArgumentSemantic.Strong)]
        UIColor TrafficHeavyColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull trafficSevereColor;
        [Export("trafficSevereColor", ArgumentSemantic.Strong)]
        UIColor TrafficSevereColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull routeCasingColor;
        [Export("routeCasingColor", ArgumentSemantic.Strong)]
        UIColor RouteCasingColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull routeAlternateColor;
        [Export("routeAlternateColor", ArgumentSemantic.Strong)]
        UIColor RouteAlternateColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull routeAlternateCasingColor;
        [Export("routeAlternateCasingColor", ArgumentSemantic.Strong)]
        UIColor RouteAlternateCasingColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull maneuverArrowColor;
        [Export("maneuverArrowColor", ArgumentSemantic.Strong)]
        UIColor ManeuverArrowColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull maneuverArrowStrokeColor;
        [Export("maneuverArrowStrokeColor", ArgumentSemantic.Strong)]
        UIColor ManeuverArrowStrokeColor { get; set; }

        // @property (nonatomic) BOOL showsUserLocation;
        [Export("showsUserLocation")]
        bool ShowsUserLocation { get; set; }

        // @property (nonatomic, strong) UIView * _Nullable userCourseView;
        [NullAllowed, Export("userCourseView", ArgumentSemantic.Strong)]
        UIView UserCourseView { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame styleURL:(NSURL * _Nullable)styleURL __attribute__((objc_designated_initializer));
        [Export("initWithFrame:styleURL:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame, [NullAllowed] NSUrl styleURL);

        // -(void)layoutMarginsDidChange;
        [Export("layoutMarginsDidChange")]
        void LayoutMarginsDidChange();

        // -(void)prepareForInterfaceBuilder;
        [Export("prepareForInterfaceBuilder")]
        [Override]
        void PrepareForInterfaceBuilder();

        // -(void)layoutSubviews;
        [Export("layoutSubviews")]
        void LayoutSubviews();

        // -(CGPoint)anchorPointForGesture:(UIGestureRecognizer * _Nonnull)gesture __attribute__((warn_unused_result));
        [Export("anchorPointForGesture:")]
        CGPoint AnchorPointForGesture(UIGestureRecognizer gesture);

        // -(void)mapViewDidFinishRenderingFrameFullyRendered:(BOOL)fullyRendered;
        [Export("mapViewDidFinishRenderingFrameFullyRendered:")]
        void MapViewDidFinishRenderingFrameFullyRendered(bool fullyRendered);

        // -(void)updatePreferredFrameRateForRouteProgress:(MBRouteProgress * _Nonnull)routeProgress;
        [Export("updatePreferredFrameRateForRouteProgress:")]
        void UpdatePreferredFrameRateForRouteProgress(MBRouteProgress routeProgress);

        // -(void)updateCourseTrackingWithLocation:(CLLocation * _Nullable)location camera:(MGLMapCamera * _Nullable)camera animated:(BOOL)animated;
        [Export("updateCourseTrackingWithLocation:camera:animated:")]
        void UpdateCourseTrackingWithLocation([NullAllowed] CLLocation location, [NullAllowed] MGLMapCamera camera, bool animated);

        // -(void)showcase:(NSArray<MBRoute *> * _Nonnull)routes animated:(BOOL)animated;
        [Export("showcase:animated:")]
        void Showcase(MBRoute[] routes, bool animated);

        // -(void)showRoutes:(NSArray<MBRoute *> * _Nonnull)routes legIndex:(NSInteger)legIndex;
        [Export("showRoutes:legIndex:")]
        void ShowRoutes(MBRoute[] routes, nint legIndex);

        // -(void)removeRoutes;
        [Export("removeRoutes")]
        void RemoveRoutes();

        // -(void)showWaypoints:(MBRoute * _Nonnull)route legIndex:(NSInteger)legIndex;
        [Export("showWaypoints:legIndex:")]
        void ShowWaypoints(MBRoute route, nint legIndex);

        // -(void)removeWaypoints;
        [Export("removeWaypoints")]
        void RemoveWaypoints();

        // -(void)addArrowWithRoute:(MBRoute * _Nonnull)route legIndex:(NSInteger)legIndex stepIndex:(NSInteger)stepIndex;
        [Export("addArrowWithRoute:legIndex:stepIndex:")]
        void AddArrowWithRoute(MBRoute route, nint legIndex, nint stepIndex);

        // -(void)removeArrow;
        [Export("removeArrow")]
        void RemoveArrow();

        // -(void)localizeLabels;
        [Export("localizeLabels")]
        void LocalizeLabels();

        // -(void)showVoiceInstructionsOnMapWithRoute:(MBRoute * _Nonnull)route;
        [Export("showVoiceInstructionsOnMapWithRoute:")]
        void ShowVoiceInstructionsOnMapWithRoute(MBRoute route);

        // -(void)setOverheadCameraViewFrom:(CLLocationCoordinate2D)userLocation along:(NSArray<NSValue *> * _Nonnull)coordinates for:(UIEdgeInsets)padding;
        [Export("setOverheadCameraViewFrom:along:for:")]
        void SetOverheadCameraViewFrom(CLLocationCoordinate2D userLocation, Foundation.NSValue[] coordinates, UIEdgeInsets padding);

        // -(void)recenterMap;
        [Export("recenterMap")]
        void RecenterMap();
    }

    // @protocol MBNavigationMapViewCourseTrackingDelegate
    [BaseType(typeof(NSObject))]
    [Model]
    interface MBNavigationMapViewCourseTrackingDelegate
    {
        // @optional -(void)navigationMapViewDidStartTrackingCourse:(MBNavigationMapView * _Nonnull)mapView;
        [Export("navigationMapViewDidStartTrackingCourse:")]
        void NavigationMapViewDidStartTrackingCourse(MBNavigationMapView mapView);

        // @optional -(void)navigationMapViewDidStopTrackingCourse:(MBNavigationMapView * _Nonnull)mapView;
        [Export("navigationMapViewDidStopTrackingCourse:")]
        void NavigationMapViewDidStopTrackingCourse(MBNavigationMapView mapView);
    }

    // @interface MBNavigationOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface MBNavigationOptions
    {
        // @property (copy, nonatomic) NSArray<MBStyle *> * _Nullable styles;
        [NullAllowed, Export("styles", ArgumentSemantic.Copy)]
        MBStyle[] Styles { get; set; }

        // @property (nonatomic, strong) id<MBNavigationService> _Nullable navigationService;
        [NullAllowed, Export("navigationService", ArgumentSemantic.Strong)]
        MBNavigationService NavigationService { get; set; }

        // @property (nonatomic, strong) MBRouteVoiceController * _Nullable voiceController;
        [NullAllowed, Export("voiceController", ArgumentSemantic.Strong)]
        MBRouteVoiceController VoiceController { get; set; }

        // @property (nonatomic, strong) UIViewController<NavigationComponent> * _Nullable topBanner;
        [NullAllowed, Export("topBanner", ArgumentSemantic.Strong)]
        NavigationComponent TopBanner { get; set; }

        // @property (nonatomic, strong) UIViewController<NavigationComponent> * _Nullable bottomBanner;
        [NullAllowed, Export("bottomBanner", ArgumentSemantic.Strong)]
        NavigationComponent BottomBanner { get; set; }

        // -(instancetype _Nonnull)initWithStyles:(NSArray<MBStyle *> * _Nullable)styles navigationService:(id<MBNavigationService> _Nullable)navigationService voiceController:(MBRouteVoiceController * _Nullable)voiceController topBanner:(UIViewController<NavigationComponent> * _Nullable)topBanner bottomBanner:(UIViewController<NavigationComponent> * _Nullable)bottomBanner;
        [Export("initWithStyles:navigationService:voiceController:topBanner:bottomBanner:")]
        IntPtr Constructor([NullAllowed] MBStyle[] styles, [NullAllowed] MBNavigationService navigationService, [NullAllowed] MBRouteVoiceController voiceController, [NullAllowed] NavigationComponent topBanner, [NullAllowed] NavigationComponent bottomBanner);

        // +(instancetype _Nonnull)navigationOptions __attribute__((warn_unused_result));
        [Static]
        [Export("navigationOptions")]
        MBNavigationOptions NavigationOptions();
    }

    // @protocol NavigationStatusPresenter
    [BaseType(typeof(NSObject), Name = "_TtP16MapboxNavigation25NavigationStatusPresenter_")]
    [Protocol, Model]
    interface NavigationStatusPresenter
    {
        // @required -(void)showStatusWithTitle:(NSString * _Nonnull)title spinner:(BOOL)spinner duration:(NSTimeInterval)duration animated:(BOOL)animated interactive:(BOOL)interactive;
        [Abstract]
        [Export("showStatusWithTitle:spinner:duration:animated:interactive:")]
        void ShowStatusWithTitle(string title, bool spinner, double duration, bool animated, bool interactive);
    }

    // @interface MBNavigationView : UIView
    [BaseType(typeof(UIView))]
    interface MBNavigationView
    {
        // -(void)prepareForInterfaceBuilder;
        [Export("prepareForInterfaceBuilder")]
        [Override]
        void PrepareForInterfaceBuilder();
    }

    // @interface MBNavigationViewController : UIViewController <NavigationStatusPresenter>
    [BaseType(typeof(UIViewController))]
    interface MBNavigationViewController : CarPlayConnectionObserver, MBStyleManagerDelegate, TopBannerViewControllerDelegate, NavigationStatusPresenter
    {
        // @property (nonatomic, strong) MBRoute * _Nonnull route;
        [Export("route", ArgumentSemantic.Strong)]
        MBRoute Route { get; set; }

        // @property (readonly, nonatomic, strong) MBDirections * _Nonnull directions;
        [Export("directions", ArgumentSemantic.Strong)]
        MBDirections Directions { get; }

        // @property (nonatomic, strong) MGLMapCamera * _Nullable pendingCamera;
        [NullAllowed, Export("pendingCamera", ArgumentSemantic.Strong)]
        MGLMapCamera PendingCamera { get; set; }

        // @property (nonatomic, strong) id<MGLAnnotation> _Nullable origin;
        [NullAllowed, Export("origin", ArgumentSemantic.Strong)]
        MGLAnnotation Origin { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBNavigationViewControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MBNavigationViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, strong) MBRouteVoiceController * _Null_unspecified voiceController;
        [Export("voiceController", ArgumentSemantic.Strong)]
        MBRouteVoiceController VoiceController { get; set; }

        // @property (readonly, nonatomic, strong) id<MBNavigationService> _Null_unspecified navigationService;
        [Export("navigationService", ArgumentSemantic.Strong)]
        MBNavigationService NavigationService { get; }

        // @property (readonly, nonatomic, strong) MBNavigationMapView * _Nullable mapView;
        [NullAllowed, Export("mapView", ArgumentSemantic.Strong)]
        MBNavigationMapView MapView { get; }

        // @property (nonatomic) BOOL snapsUserLocationAnnotationToRoute;
        [Export("snapsUserLocationAnnotationToRoute")]
        bool SnapsUserLocationAnnotationToRoute { get; set; }

        // @property (nonatomic) BOOL sendsNotifications;
        [Export("sendsNotifications")]
        bool SendsNotifications { get; set; }

        // @property (nonatomic) BOOL showsReportFeedback;
        [Export("showsReportFeedback")]
        bool ShowsReportFeedback { get; set; }

        // @property (nonatomic) BOOL showsEndOfRouteFeedback;
        [Export("showsEndOfRouteFeedback")]
        bool ShowsEndOfRouteFeedback { get; set; }

        // @property (nonatomic) BOOL automaticallyAdjustsStyleForTimeOfDay;
        [Export("automaticallyAdjustsStyleForTimeOfDay")]
        bool AutomaticallyAdjustsStyleForTimeOfDay { get; set; }

        // @property (nonatomic) BOOL shouldManageApplicationIdleTimer;
        [Export("shouldManageApplicationIdleTimer")]
        bool ShouldManageApplicationIdleTimer { get; set; }

        // @property (nonatomic) BOOL annotatesSpokenInstructions;
        [Export("annotatesSpokenInstructions")]
        bool AnnotatesSpokenInstructions { get; set; }

        // -(instancetype _Nonnull)initWithRoute:(MBRoute * _Nonnull)route options:(MBNavigationOptions * _Nullable)options __attribute__((objc_designated_initializer));
        [Export("initWithRoute:options:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRoute route, [NullAllowed] MBNavigationOptions options);

        // -(void)viewDidLoad;
        [Export("viewDidLoad")]
        [Override]
        void ViewDidLoad();

        // -(void)viewWillAppear:(BOOL)animated;
        [Export("viewWillAppear:")]
        [Override]
        void ViewWillAppear(bool animated);

        // -(void)viewWillDisappear:(BOOL)animated;
        [Export("viewWillDisappear:")]
        [Override]
        void ViewWillDisappear(bool animated);

        // -(MGLStyleLayer * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView routeCasingStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationMapView:routeCasingStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationMapViewRouteCasingStyleLayerWithIdentifier(MBNavigationMapView mapView, string identifier, MGLSource source);

        // -(MGLStyleLayer * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView routeStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationMapView:routeStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationMapViewRouteStyleLayerWithIdentifier(MBNavigationMapView mapView, string identifier, MGLSource source);

        // -(void)navigationMapView:(MBNavigationMapView * _Nonnull)mapView didSelectRoute:(MBRoute * _Nonnull)route;
        [Export("navigationMapView:didSelectRoute:")]
        void NavigationMapViewDidSelectRoute(MBNavigationMapView mapView, MBRoute route);

        // -(MGLShape * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView shapeForRoutes:(NSArray<MBRoute *> * _Nonnull)routes __attribute__((warn_unused_result));
        [Export("navigationMapView:shapeForRoutes:")]
        [return: NullAllowed]
        MGLShape NavigationMapViewShapeForRoutes(MBNavigationMapView mapView, MBRoute[] routes);

        // -(MGLShape * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView simplifiedShapeForRoute:(MBRoute * _Nonnull)route __attribute__((warn_unused_result));
        [Export("navigationMapView:simplifiedShapeForRoute:")]
        [return: NullAllowed]
        MGLShape NavigationMapViewSimplifiedShapeForRoute(MBNavigationMapView mapView, MBRoute route);

        // -(MGLStyleLayer * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView waypointStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationMapView:waypointStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationMapViewWaypointStyleLayerWithIdentifier(MBNavigationMapView mapView, string identifier, MGLSource source);

        // -(MGLStyleLayer * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView waypointSymbolStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationMapView:waypointSymbolStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationMapViewWaypointSymbolStyleLayerWithIdentifier(MBNavigationMapView mapView, string identifier, MGLSource source);

        // -(MGLShape * _Nullable)navigationMapView:(MBNavigationMapView * _Nonnull)mapView shapeForWaypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints legIndex:(NSInteger)legIndex __attribute__((warn_unused_result));
        [Export("navigationMapView:shapeForWaypoints:legIndex:")]
        [return: NullAllowed]
        MGLShape NavigationMapViewShapeForWaypoints(MBNavigationMapView mapView, MBWaypoint[] waypoints, nint legIndex);

        // -(CGPoint)navigationMapViewUserAnchorPoint:(MBNavigationMapView * _Nonnull)mapView __attribute__((warn_unused_result));
        [Export("navigationMapViewUserAnchorPoint:")]
        CGPoint NavigationMapViewUserAnchorPoint(MBNavigationMapView mapView);

        // -(NSAttributedString * _Nullable)label:(MBInstructionLabel * _Nonnull)label willPresentVisualInstruction:(MBVisualInstruction * _Nonnull)instruction asAttributedString:(NSAttributedString * _Nonnull)presented __attribute__((warn_unused_result));
        [Export("label:willPresentVisualInstruction:asAttributedString:")]
        [return: NullAllowed]
        NSAttributedString Label(MBInstructionLabel label, MBVisualInstruction instruction, NSAttributedString presented);

        // -(BOOL)navigationService:(id<MBNavigationService> _Nonnull)service shouldRerouteFromLocation:(CLLocation * _Nonnull)location __attribute__((warn_unused_result));
        [Export("navigationService:shouldRerouteFromLocation:")]
        bool NavigationServiceShouldRerouteFromLocation(MBNavigationService service, CLLocation location);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service willRerouteFromLocation:(CLLocation * _Nonnull)location;
        [Export("navigationService:willRerouteFromLocation:")]
        void NavigationServiceWillRerouteFromLocation(MBNavigationService service, CLLocation location);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didRerouteAlongRoute:(MBRoute * _Nonnull)route at:(CLLocation * _Nullable)location proactive:(BOOL)proactive;
        [Export("navigationService:didRerouteAlongRoute:at:proactive:")]
        void NavigationServiceDidRerouteAlongRoute(MBNavigationService service, MBRoute route, [NullAllowed] CLLocation location, bool proactive);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didFailToRerouteWithError:(NSError * _Nonnull)error;
        [Export("navigationService:didFailToRerouteWithError:")]
        void NavigationServiceDidFailToRerouteWithError(MBNavigationService service, NSError error);

        // -(BOOL)navigationService:(id<MBNavigationService> _Nonnull)service shouldDiscardLocation:(CLLocation * _Nonnull)location __attribute__((warn_unused_result));
        [Export("navigationService:shouldDiscardLocation:")]
        bool NavigationServiceShouldDiscardLocation(MBNavigationService service, CLLocation location);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didUpdateProgress:(MBRouteProgress * _Nonnull)progress withLocation:(CLLocation * _Nonnull)location rawLocation:(CLLocation * _Nonnull)rawLocation;
        [Export("navigationService:didUpdateProgress:withLocation:rawLocation:")]
        void NavigationServiceDidUpdateProgress(MBNavigationService service, MBRouteProgress progress, CLLocation location, CLLocation rawLocation);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didPassSpokenInstructionPoint:(MBSpokenInstruction * _Nonnull)instruction routeProgress:(MBRouteProgress * _Nonnull)routeProgress;
        [Export("navigationService:didPassSpokenInstructionPoint:routeProgress:")]
        void NavigationServiceDidPassSpokenInstructionPoint(MBNavigationService service, MBSpokenInstruction instruction, MBRouteProgress routeProgress);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didPassVisualInstructionPoint:(MBVisualInstructionBanner * _Nonnull)instruction routeProgress:(MBRouteProgress * _Nonnull)routeProgress;
        [Export("navigationService:didPassVisualInstructionPoint:routeProgress:")]
        void NavigationServiceDidPassVisualInstructionPoint(MBNavigationService service, MBVisualInstructionBanner instruction, MBRouteProgress routeProgress);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service willArriveAtWaypoint:(MBWaypoint * _Nonnull)waypoint after:(NSTimeInterval)remainingTimeInterval distance:(CLLocationDistance)distance;
        [Export("navigationService:willArriveAtWaypoint:after:distance:")]
        void NavigationServiceWillArriveAtWaypoint(MBNavigationService service, MBWaypoint waypoint, double remainingTimeInterval, double distance);

        // -(BOOL)navigationService:(id<MBNavigationService> _Nonnull)service didArriveAtWaypoint:(MBWaypoint * _Nonnull)waypoint __attribute__((warn_unused_result));
        [Export("navigationService:didArriveAtWaypoint:")]
        bool NavigationServiceDidArriveAtWaypoint(MBNavigationService service, MBWaypoint waypoint);

        // -(void)showEndOfRouteFeedbackWithDuration:(NSTimeInterval)duration completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
        [Export("showEndOfRouteFeedbackWithDuration:completionHandler:")]
        void ShowEndOfRouteFeedbackWithDuration(double duration, [NullAllowed] Action<bool> completionHandler);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service willBeginSimulating:(MBRouteProgress * _Nonnull)progress becauseOf:(enum MBNavigationSimulationIntent)reason;
        [Export("navigationService:willBeginSimulating:becauseOf:")]
        void NavigationServiceWillBeginSimulating(MBNavigationService service, MBRouteProgress progress, MBNavigationSimulationIntent reason);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didBeginSimulating:(MBRouteProgress * _Nonnull)progress becauseOf:(enum MBNavigationSimulationIntent)reason;
        [Export("navigationService:didBeginSimulating:becauseOf:")]
        void NavigationServiceDidBeginSimulating(MBNavigationService service, MBRouteProgress progress, MBNavigationSimulationIntent reason);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service willEndSimulating:(MBRouteProgress * _Nonnull)progress becauseOf:(enum MBNavigationSimulationIntent)reason;
        [Export("navigationService:willEndSimulating:becauseOf:")]
        void NavigationServiceWillEndSimulating(MBNavigationService service, MBRouteProgress progress, MBNavigationSimulationIntent reason);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didEndSimulating:(MBRouteProgress * _Nonnull)progress becauseOf:(enum MBNavigationSimulationIntent)reason;
        [Export("navigationService:didEndSimulating:becauseOf:")]
        void NavigationServiceDidEndSimulating(MBNavigationService service, MBRouteProgress progress, MBNavigationSimulationIntent reason);

        // -(BOOL)navigationService:(id<MBNavigationService> _Nonnull)service shouldPreventReroutesWhenArrivingAtWaypoint:(MBWaypoint * _Nonnull)waypoint __attribute__((warn_unused_result));
        [Export("navigationService:shouldPreventReroutesWhenArrivingAtWaypoint:")]
        bool NavigationServiceShouldPreventReroutesWhenArrivingAtWaypoint(MBNavigationService service, MBWaypoint waypoint);

        // -(BOOL)navigationServiceShouldDisableBatteryMonitoring:(id<MBNavigationService> _Nonnull)service __attribute__((warn_unused_result));
        [Export("navigationServiceShouldDisableBatteryMonitoring:")]
        bool NavigationServiceShouldDisableBatteryMonitoring(MBNavigationService service);

        // -(instancetype _Nonnull)initWithRoute:(MBRoute * _Nonnull)route styles:(NSArray<MBStyle *> * _Nullable)styles navigationService:(id<MBNavigationService> _Nullable)navigationService voiceController:(MBRouteVoiceController * _Nullable)voiceController __attribute__((deprecated("Use the new init(route:options:) initalizer.")));
        [Export("initWithRoute:styles:navigationService:voiceController:")]
        IntPtr Constructor(MBRoute route, [NullAllowed] MBStyle[] styles, [NullAllowed] MBNavigationService navigationService, [NullAllowed] MBRouteVoiceController voiceController);

        // @property (nonatomic, strong) MBRouteController * _Null_unspecified routeController __attribute__((deprecated("NavigationViewController no longer directly manages a RouteController. See MapboxNavigationService, which contains a protocol-bound reference to the RouteController, for more information.", "navigationService")));
        [Export("routeController", ArgumentSemantic.Strong)]
        MBRouteController RouteController { get; set; }

        // @property (nonatomic, strong) MBNavigationEventsManager * _Null_unspecified eventsManager __attribute__((deprecated("NavigationViewController no-longer directly manages a NavigationEventsManager. See MapboxNavigationService, which contains a reference to the eventsManager, for more information.", "eventsManager")));
        [Export("eventsManager", ArgumentSemantic.Strong)]
        MBNavigationEventsManager EventsManager { get; set; }

        // @property (nonatomic, strong) MBNavigationLocationManager * _Null_unspecified locationManager __attribute__((deprecated("NavigationViewController no-longer directly manages an NavigationLocationManager. See MapboxNavigationService, which contains a reference to the locationManager, for more information.", "locationManager")));
        [Export("locationManager", ArgumentSemantic.Strong)]
        MBNavigationLocationManager LocationManager { get; set; }

        // -(instancetype _Nonnull)initWithRoute:(MBRoute * _Nonnull)route directions:(MBDirections * _Nonnull)directions styles:(NSArray<MBStyle *> * _Nullable)styles routeController:(MBRouteController * _Nullable)routeController locationManager:(MBNavigationLocationManager * _Nullable)locationManager voiceController:(MBRouteVoiceController * _Nullable)voiceController eventsManager:(MBNavigationEventsManager * _Nullable)eventsManager __attribute__((deprecated("Intializing a NavigationViewController directly with a RouteController is no longer supported. Use a NavigationService instead.", "initWithRoute:styles:navigationService:voiceController:")));
        [Export("initWithRoute:directions:styles:routeController:locationManager:voiceController:eventsManager:")]
        IntPtr Constructor(MBRoute route, MBDirections directions, [NullAllowed] MBStyle[] styles, [NullAllowed] MBRouteController routeController, [NullAllowed] MBNavigationLocationManager locationManager, [NullAllowed] MBRouteVoiceController voiceController, [NullAllowed] MBNavigationEventsManager eventsManager);

    }

    // @protocol TopBannerViewControllerDelegate
    [BaseType(typeof(NSObject), Name = "_TtP16MapboxNavigation31TopBannerViewControllerDelegate_")]
    [Model]
    interface TopBannerViewControllerDelegate
    {
        // @optional -(void)topBanner:(TopBannerViewController * _Nonnull)banner didSwipeInDirection:(UISwipeGestureRecognizerDirection)direction;
        [Export("topBanner:didSwipeInDirection:")]
        void DidSwipeInDirection(TopBannerViewController banner, UISwipeGestureRecognizerDirection direction);

        // @optional -(void)topBanner:(TopBannerViewController * _Nonnull)banner didSelect:(NSInteger)legIndex stepIndex:(NSInteger)stepIndex cell:(MBStepTableViewCell * _Nonnull)cell;
        [Export("topBanner:didSelect:stepIndex:cell:")]
        void DidSelect(TopBannerViewController banner, nint legIndex, nint stepIndex, MBStepTableViewCell cell);

        // @optional -(void)topBanner:(TopBannerViewController * _Nonnull)banner willDisplayStepsController:(MBStepsViewController * _Nonnull)willDisplayStepsController;
        [Export("topBanner:willDisplayStepsController:")]
        void WillDisplayStepsController(TopBannerViewController banner, MBStepsViewController willDisplayStepsController);

        // @optional -(void)topBanner:(TopBannerViewController * _Nonnull)banner didDisplayStepsController:(MBStepsViewController * _Nonnull)didDisplayStepsController;
        [Export("topBanner:didDisplayStepsController:")]
        void DidDisplayStepsController(TopBannerViewController banner, MBStepsViewController didDisplayStepsController);

        // @optional -(void)topBanner:(TopBannerViewController * _Nonnull)banner willDismissStepsController:(MBStepsViewController * _Nonnull)willDismissStepsController;
        [Export("topBanner:willDismissStepsController:")]
        void WillDismissStepsController(TopBannerViewController banner, MBStepsViewController willDismissStepsController);

        // @optional -(void)topBanner:(TopBannerViewController * _Nonnull)banner didDismissStepsController:(MBStepsViewController * _Nonnull)didDismissStepsController;
        [Export("topBanner:didDismissStepsController:")]
        void DidDismissStepsController(TopBannerViewController banner, MBStepsViewController didDismissStepsController);
    }

    // @protocol MBVisualInstructionDelegate
    [BaseType(typeof(NSObject))]
    [Model]
    interface MBVisualInstructionDelegate
    {
        // @optional -(NSAttributedString * _Nullable)label:(MBInstructionLabel * _Nonnull)label willPresentVisualInstruction:(MBVisualInstruction * _Nonnull)instruction asAttributedString:(NSAttributedString * _Nonnull)presented __attribute__((warn_unused_result));
        [Export("label:willPresentVisualInstruction:asAttributedString:")]
        [return: NullAllowed]
        NSAttributedString WillPresentVisualInstruction(MBInstructionLabel label, MBVisualInstruction instruction, NSAttributedString presented);
    }

    // @protocol MBNavigationViewControllerDelegate <MBVisualInstructionDelegate>
    [BaseType(typeof(NSObject))]
    [Model]
    interface MBNavigationViewControllerDelegate : MBVisualInstructionDelegate
    {
        // @optional -(void)navigationViewControllerDidDismiss:(MBNavigationViewController * _Nonnull)navigationViewController byCanceling:(BOOL)canceled;
        [Export("navigationViewControllerDidDismiss:byCanceling:")]
        void NavigationViewControllerDidDismiss(MBNavigationViewController navigationViewController, bool canceled);

        // @optional -(void)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController willArriveAtWaypoint:(MBWaypoint * _Nonnull)waypoint after:(NSTimeInterval)remainingTimeInterval distance:(CLLocationDistance)distance;
        [Export("navigationViewController:willArriveAtWaypoint:after:distance:")]
        void NavigationViewControllerWillArriveAtWaypoint(MBNavigationViewController navigationViewController, MBWaypoint waypoint, double remainingTimeInterval, double distance);

        // @optional -(BOOL)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController didArriveAtWaypoint:(MBWaypoint * _Nonnull)waypoint __attribute__((warn_unused_result));
        [Export("navigationViewController:didArriveAtWaypoint:")]
        bool NavigationViewControllerDidArriveAtWaypoint(MBNavigationViewController navigationViewController, MBWaypoint waypoint);

        // @optional -(BOOL)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController shouldRerouteFromLocation:(CLLocation * _Nonnull)location __attribute__((warn_unused_result));
        [Export("navigationViewController:shouldRerouteFromLocation:")]
        bool NavigationViewControllerShouldRerouteFromLocation(MBNavigationViewController navigationViewController, CLLocation location);

        // @optional -(void)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController willRerouteFromLocation:(CLLocation * _Nullable)location;
        [Export("navigationViewController:willRerouteFromLocation:")]
        void NavigationViewControllerWillRerouteFromLocation(MBNavigationViewController navigationViewController, [NullAllowed] CLLocation location);

        // @optional -(void)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController didRerouteAlongRoute:(MBRoute * _Nonnull)route;
        [Export("navigationViewController:didRerouteAlongRoute:")]
        void NavigationViewControllerDidRerouteAlongRoute(MBNavigationViewController navigationViewController, MBRoute route);

        // @optional -(void)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController didFailToRerouteWithError:(NSError * _Nonnull)error;
        [Export("navigationViewController:didFailToRerouteWithError:")]
        void NavigationViewControllerDidFailToRerouteWithError(MBNavigationViewController navigationViewController, NSError error);

        // @optional -(MGLStyleLayer * _Nullable)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController routeStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationViewController:routeStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationViewControllerRouteStyleLayerWithIdentifier(MBNavigationViewController navigationViewController, string identifier, MGLSource source);

        // @optional -(MGLStyleLayer * _Nullable)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController routeCasingStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationViewController:routeCasingStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationViewControllerRouteCasingStyleLayerWithIdentifier(MBNavigationViewController navigationViewController, string identifier, MGLSource source);

        // @optional -(MGLShape * _Nullable)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController shapeForRoutes:(NSArray<MBRoute *> * _Nonnull)routes __attribute__((warn_unused_result));
        [Export("navigationViewController:shapeForRoutes:")]
        [return: NullAllowed]
        MGLShape NavigationViewControllerShapeForRoutes(MBNavigationViewController navigationViewController, MBRoute[] routes);

        // @optional -(MGLShape * _Nullable)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController simplifiedShapeForRoute:(MBRoute * _Nonnull)route __attribute__((warn_unused_result));
        [Export("navigationViewController:simplifiedShapeForRoute:")]
        [return: NullAllowed]
        MGLShape NavigationViewControllerSimplifiedShapeForRoute(MBNavigationViewController navigationViewController, MBRoute route);

        // @optional -(MGLStyleLayer * _Nullable)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController waypointStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationViewController:waypointStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationViewControllerWaypointStyleLayerWithIdentifier(MBNavigationViewController navigationViewController, string identifier, MGLSource source);

        // @optional -(MGLStyleLayer * _Nullable)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController waypointSymbolStyleLayerWithIdentifier:(NSString * _Nonnull)identifier source:(MGLSource * _Nonnull)source __attribute__((warn_unused_result));
        [Export("navigationViewController:waypointSymbolStyleLayerWithIdentifier:source:")]
        [return: NullAllowed]
        MGLStyleLayer NavigationViewControllerWaypointSymbolStyleLayerWithIdentifier(MBNavigationViewController navigationViewController, string identifier, MGLSource source);

        // @optional -(MGLShape * _Nullable)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController shapeForWaypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints legIndex:(NSInteger)legIndex __attribute__((warn_unused_result));
        [Export("navigationViewController:shapeForWaypoints:legIndex:")]
        [return: NullAllowed]
        MGLShape NavigationViewControllerShapeForWaypoints(MBNavigationViewController navigationViewController, MBWaypoint[] waypoints, nint legIndex);

        // @optional -(void)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController didSelectRoute:(MBRoute * _Nonnull)route;
        [Export("navigationViewController:didSelectRoute:")]
        void NavigationViewControllerDidSelectRoute(MBNavigationViewController navigationViewController, MBRoute route);

        // @optional -(CGPoint)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController mapViewUserAnchorPoint:(MBNavigationMapView * _Nonnull)mapView __attribute__((warn_unused_result));
        [Export("navigationViewController:mapViewUserAnchorPoint:")]
        CGPoint NavigationViewControllerMapViewUserAnchorPoint(MBNavigationViewController navigationViewController, MBNavigationMapView mapView);

        // @optional -(BOOL)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController shouldDiscardLocation:(CLLocation * _Nonnull)location __attribute__((warn_unused_result));
        [Export("navigationViewController:shouldDiscardLocation:")]
        bool NavigationViewControllerShouldDiscardLocation(MBNavigationViewController navigationViewController, CLLocation location);

        // @optional -(NSString * _Nullable)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController roadNameAtLocation:(CLLocation * _Nonnull)location __attribute__((warn_unused_result));
        [Export("navigationViewController:roadNameAtLocation:")]
        [return: NullAllowed]
        string NavigationViewControllerRoadNameAtLocation(MBNavigationViewController navigationViewController, CLLocation location);

        // @optional -(MGLAnnotationImage * _Nullable)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController imageForAnnotation:(id<MGLAnnotation> _Nonnull)annotation __attribute__((deprecated("Use MGLMapViewDelegate.mapView(_:imageFor:) instead."))) __attribute__((warn_unused_result));
        [Export("navigationViewController:imageForAnnotation:")]
        [return: NullAllowed]
        MGLAnnotationImage NavigationViewControllerImageForAnnotation(MBNavigationViewController navigationViewController, MGLAnnotation annotation);

        // @optional -(MGLAnnotationView * _Nullable)navigationViewController:(MBNavigationViewController * _Nonnull)navigationViewController viewForAnnotation:(id<MGLAnnotation> _Nonnull)annotation __attribute__((deprecated("Use MGLMapViewDelegate.mapView(_:viewFor:) instead."))) __attribute__((warn_unused_result));
        [Export("navigationViewController:viewForAnnotation:")]
        [return: NullAllowed]
        MGLAnnotationView NavigationViewControllerViewForAnnotation(MBNavigationViewController navigationViewController, MGLAnnotation annotation);
    }

    // @interface MBNextBannerView : UIView <NavigationComponent>
    [BaseType(typeof(UIView))]
    interface MBNextBannerView : NavigationComponent
    {
        // -(void)prepareForInterfaceBuilder;
        [Export("prepareForInterfaceBuilder")]
        [Override]
        void PrepareForInterfaceBuilder();

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didPassVisualInstructionPoint:(MBVisualInstructionBanner * _Nonnull)instruction routeProgress:(MBRouteProgress * _Nonnull)routeProgress;
        [Export("navigationService:didPassVisualInstructionPoint:routeProgress:")]
        void NavigationService(MBNavigationService service, MBVisualInstructionBanner instruction, MBRouteProgress routeProgress);

        // -(void)updateForVisualInstructionBanner:(MBVisualInstructionBanner * _Nullable)visualInstruction;
        [Export("updateForVisualInstructionBanner:")]
        void UpdateForVisualInstructionBanner([NullAllowed] MBVisualInstructionBanner visualInstruction);
    }

    // @interface MBNextInstructionLabel : MBInstructionLabel
    [BaseType(typeof(MBInstructionLabel))]
    interface MBNextInstructionLabel
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBNightStyle : MBDayStyle
    [BaseType(typeof(MBDayStyle))]
    interface MBNightStyle
    {
        // -(void)apply;
        [Export("apply")]
        [Override]
        void Apply();
    }

    // @interface MBPrimaryLabel : MBInstructionLabel
    [BaseType(typeof(MBInstructionLabel))]
    interface MBPrimaryLabel
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBProgressBar : UIView
    [BaseType(typeof(UIView))]
    interface MBProgressBar
    {
        // @property (nonatomic, strong) UIColor * _Nonnull barColor;
        [Export("barColor", ArgumentSemantic.Strong)]
        UIColor BarColor { get; set; }

        // -(void)layoutSubviews;
        [Export("layoutSubviews")]
        [Override]
        void LayoutSubviews();

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBReportButton : MBButton
    [BaseType(typeof(MBButton))]
    interface MBReportButton
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBResumeButton : UIControl
    [BaseType(typeof(UIControl))]
    interface MBResumeButton
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)prepareForInterfaceBuilder;
        [Export("prepareForInterfaceBuilder")]
        [Override]
        void PrepareForInterfaceBuilder();
    }

    // @interface MBSecondaryLabel : MBInstructionLabel
    [BaseType(typeof(MBInstructionLabel))]
    interface MBSecondaryLabel
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBSeparatorView : UIView
    [BaseType(typeof(UIView))]
    interface MBSeparatorView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBStatusView : UIControl
    [BaseType(typeof(UIControl))]
    interface MBStatusView
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        DeprecatedStatusViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<DeprecatedStatusViewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) BOOL canChangeValue __attribute__((deprecated("", "enabled")));
        [Export("canChangeValue")]
        bool CanChangeValue { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @protocol StatusViewDelegate <DeprecatedStatusViewDelegate>
    [BaseType(typeof(NSObject), Name = "_TtP16MapboxNavigation18StatusViewDelegate_")]
    [Model]
    interface StatusViewDelegate : DeprecatedStatusViewDelegate
    {
        // @optional -(void)statusView:(MBStatusView * _Nonnull)statusView valueChangedTo:(double)value __attribute__((deprecated("Add a target to StatusView for UIControl.Event.valueChanged instead.")));
        [Export("statusView:valueChangedTo:")]
        void ValueChangedTo(MBStatusView statusView, double value);
    }

    // @interface MBStepInstructionsView : BaseInstructionsBannerView
    [BaseType(typeof(BaseInstructionsBannerView))]
    interface MBStepInstructionsView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBDraggableView : UIView
    [BaseType(typeof(UIView))]
    interface MBDraggableView
    {
        // @property (copy, nonatomic) NSArray<UIColor *> * _Nonnull gradientColors;
        [Export("gradientColors", ArgumentSemantic.Copy)]
        UIColor[] GradientColors { get; set; }

        // -(void)layoutSubviews;
        [Export("layoutSubviews")]
        [Override]
        void LayoutSubviews();

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBStepTableViewCell : UITableViewCell
    [BaseType(typeof(UITableViewCell))]
    interface MBStepTableViewCell
    {
        // -(void)prepareForReuse __attribute__((objc_requires_super));
        [Export("prepareForReuse")]
        [Override]
        [RequiresSuper]
        void PrepareForReuse();
    }

    // @interface MBStepsBackgroundView : UIView
    [BaseType(typeof(UIView))]
    interface MBStepsBackgroundView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBStepsViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface MBStepsViewController: IUITableViewDelegate, IUITableViewDataSource
    {
        // -(void)viewDidLoad;
        [Export("viewDidLoad")]
        [Override]
        void ViewDidLoad();

        // -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil __attribute__((objc_designated_initializer));
        [Export("initWithNibName:bundle:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] Foundation.NSBundle nibBundleOrNil);

        // -(void)tableView:(UITableView * _Nonnull)tableView didSelectRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("tableView:didSelectRowAtIndexPath:")]
        void TableView(UITableView tableView, NSIndexPath indexPath);

        // -(NSInteger)numberOfSectionsInTableView:(UITableView * _Nonnull)tableView __attribute__((warn_unused_result));
        [Export("numberOfSectionsInTableView:")]
        nint NumberOfSectionsInTableView(UITableView tableView);

        // -(CGFloat)tableView:(UITableView * _Nonnull)tableView heightForRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath __attribute__((warn_unused_result));
        [Export("tableView:heightForRowAtIndexPath:")]
        nfloat TableViewHeightForRowAtIndexPath(UITableView tableView, NSIndexPath indexPath);

        // -(void)tableView:(UITableView * _Nonnull)tableView willDisplayCell:(UITableViewCell * _Nonnull)cell forRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("tableView:willDisplayCell:forRowAtIndexPath:")]
        void TableViewWillDisplayCell(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath);

        // -(NSString * _Nullable)tableView:(UITableView * _Nonnull)tableView titleForHeaderInSection:(NSInteger)section __attribute__((warn_unused_result));
        [Export("tableView:titleForHeaderInSection:")]
        [return: NullAllowed]
        string TableViewTitleForHeaderInSection(UITableView tableView, nint section);
    }

    // @protocol StepsViewControllerDelegate
    [BaseType(typeof(NSObject), Name = "_TtP16MapboxNavigation27StepsViewControllerDelegate_")]
    [Model]
    interface StepsViewControllerDelegate
    {
        // @optional -(void)stepsViewController:(MBStepsViewController * _Nonnull)viewController didSelect:(NSInteger)legIndex stepIndex:(NSInteger)stepIndex cell:(MBStepTableViewCell * _Nonnull)cell;
        [Export("stepsViewController:didSelect:stepIndex:cell:")]
        void StepsViewController(MBStepsViewController viewController, nint legIndex, nint stepIndex, MBStepTableViewCell cell);

        // @required -(void)didDismissStepsViewController:(MBStepsViewController * _Nonnull)viewController;
        [Abstract]
        [Export("didDismissStepsViewController:")]
        void DidDismissStepsViewController(MBStepsViewController viewController);
    }

    // @interface MBStyleKitMarker : NSObject
    [BaseType(typeof(NSObject))]
    interface MBStyleKitMarker
    {
        // +(void)drawMarkerWithFrame:(CGRect)frame innerColor:(UIColor * _Nonnull)innerColor shadowColor:(UIColor * _Nonnull)shadowColor pinColor:(UIColor * _Nonnull)pinColor strokeColor:(UIColor * _Nonnull)strokeColor;
        [Static]
        [Export("drawMarkerWithFrame:innerColor:shadowColor:pinColor:strokeColor:")]
        void DrawMarkerWithFrame(CGRect frame, UIColor innerColor, UIColor shadowColor, UIColor pinColor, UIColor strokeColor);
    }

    // @interface MBStyleManager : NSObject
    [BaseType(typeof(NSObject))]
    interface MBStyleManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBStyleManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MBStyleManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) BOOL automaticallyAdjustsStyleForTimeOfDay;
        [Export("automaticallyAdjustsStyleForTimeOfDay")]
        bool AutomaticallyAdjustsStyleForTimeOfDay { get; set; }

        // @property (copy, nonatomic) NSArray<MBStyle *> * _Nonnull styles;
        [Export("styles", ArgumentSemantic.Copy)]
        MBStyle[] Styles { get; set; }
    }

    // @interface MBSubtitleLabel : MBStylableLabel
    [BaseType(typeof(MBStylableLabel))]
    interface MBSubtitleLabel
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBTimeRemainingLabel : MBStylableLabel
    [BaseType(typeof(MBStylableLabel))]
    interface MBTimeRemainingLabel
    {
        // @property (nonatomic, strong) UIColor * _Nonnull trafficUnknownColor;
        [Export("trafficUnknownColor", ArgumentSemantic.Strong)]
        UIColor TrafficUnknownColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull trafficLowColor;
        [Export("trafficLowColor", ArgumentSemantic.Strong)]
        UIColor TrafficLowColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull trafficModerateColor;
        [Export("trafficModerateColor", ArgumentSemantic.Strong)]
        UIColor TrafficModerateColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull trafficHeavyColor;
        [Export("trafficHeavyColor", ArgumentSemantic.Strong)]
        UIColor TrafficHeavyColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull trafficSevereColor;
        [Export("trafficSevereColor", ArgumentSemantic.Strong)]
        UIColor TrafficSevereColor { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBTitleLabel : MBStylableLabel
    [BaseType(typeof(MBStylableLabel))]
    interface MBTitleLabel
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBTopBannerView : UIView
    [BaseType(typeof(UIView))]
    interface MBTopBannerView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface TopBannerViewController : UIViewController
    [BaseType(typeof(UIViewController), Name = "_TtC16MapboxNavigation23TopBannerViewController")]
    interface TopBannerViewController: NavigationMapInteractionObserver, StepsViewControllerDelegate, CarPlayConnectionObserver, MBInstructionsBannerViewDelegate, NavigationComponent
    {

        // -(void)viewDidLoad;
        [Export("viewDidLoad")]
        [Override]
        void ViewDidLoad();

        // -(void)showStatusWithTitle:(NSString * _Nonnull)title spinner:(BOOL)spin duration:(NSTimeInterval)time animated:(BOOL)animated interactive:(BOOL)interactive;
        [Export("showStatusWithTitle:spinner:duration:animated:interactive:")]
        void ShowStatusWithTitle(string title, bool spin, double time, bool animated, bool interactive);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didUpdateProgress:(MBRouteProgress * _Nonnull)progress withLocation:(CLLocation * _Nonnull)location rawLocation:(CLLocation * _Nonnull)rawLocation;
        [Export("navigationService:didUpdateProgress:withLocation:rawLocation:")]
        void NavigationServiceDidUpdateProgress(MBNavigationService service, MBRouteProgress progress, CLLocation location, CLLocation rawLocation);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didPassVisualInstructionPoint:(MBVisualInstructionBanner * _Nonnull)instruction routeProgress:(MBRouteProgress * _Nonnull)routeProgress;
        [Export("navigationService:didPassVisualInstructionPoint:routeProgress:")]
        void NavigationServiceDidPassVisualInstructionPoint(MBNavigationService service, MBVisualInstructionBanner instruction, MBRouteProgress routeProgress);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service willRerouteFromLocation:(CLLocation * _Nonnull)location;
        [Export("navigationService:willRerouteFromLocation:")]
        void NavigationServiceWillRerouteFromLocation(MBNavigationService service, CLLocation location);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service didRerouteAlongRoute:(MBRoute * _Nonnull)route at:(CLLocation * _Nullable)location proactive:(BOOL)proactive;
        [Export("navigationService:didRerouteAlongRoute:at:proactive:")]
        void NavigationServiceDidRerouteAlongRoute(MBNavigationService service, MBRoute route, [NullAllowed] CLLocation location, bool proactive);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service willBeginSimulating:(MBRouteProgress * _Nonnull)progress becauseOf:(enum MBNavigationSimulationIntent)reason;
        [Export("navigationService:willBeginSimulating:becauseOf:")]
        void NavigationServiceWillBeginSimulating(MBNavigationService service, MBRouteProgress progress, MBNavigationSimulationIntent reason);

        // -(void)navigationService:(id<MBNavigationService> _Nonnull)service willEndSimulating:(MBRouteProgress * _Nonnull)progress becauseOf:(enum MBNavigationSimulationIntent)reason;
        [Export("navigationService:willEndSimulating:becauseOf:")]
        void NavigationServiceWillEndSimulating(MBNavigationService service, MBRouteProgress progress, MBNavigationSimulationIntent reason);
    }

    // @interface MapboxNavigation_Swift_2239 (UIDevice)
    [Category]
    [BaseType(typeof(UIDevice))]
    interface UIDevice_MapboxNavigation_Swift_2239
    {
        // @property (readonly, nonatomic) BOOL isPluggedIn;
        [Export("isPluggedIn")]
        bool IsPluggedIn();
    }

    // @interface MapboxNavigation_Swift_2247 (UIFont)
    [Category]
    [BaseType(typeof(UIFont))]
    interface UIFont_MapboxNavigation_Swift_2247
    {
        // @property (readonly, nonatomic, strong) UIFont * _Nonnull adjustedFont;
        [Export("adjustedFont", ArgumentSemantic.Strong)]
        UIFont AdjustedFont();
    }
    // @protocol MBUserCourseView
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface MBUserCourseView
    {
        // @optional @property (nonatomic, strong) CLLocation * _Nonnull location;
        [Export("location", ArgumentSemantic.Strong)]
        CLLocation Location { get; set; }

        // @optional @property (nonatomic) CLLocationDegrees direction;
        [Export("direction")]
        double Direction { get; set; }

        // @optional @property (nonatomic) CLLocationDegrees pitch;
        [Export("pitch")]
        double Pitch { get; set; }

        // @optional -(void)updateWithLocation:(CLLocation * _Nonnull)location pitch:(CGFloat)pitch direction:(CLLocationDegrees)direction animated:(BOOL)animated tracksUserCourse:(BOOL)tracksUserCourse;
        [Export("updateWithLocation:pitch:direction:animated:tracksUserCourse:")]
        void UpdateWithLocation(CLLocation location, nfloat pitch, double direction, bool animated, bool tracksUserCourse);
    }

    // @interface MBUserPuckCourseView : UIView <MBUserCourseView>
    [BaseType(typeof(UIView))]
    interface MBUserPuckCourseView : MBUserCourseView
    {
        // @property (nonatomic, strong) UIColor * _Nonnull puckColor;
        [Export("puckColor", ArgumentSemantic.Strong)]
        UIColor PuckColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull fillColor;
        [Export("fillColor", ArgumentSemantic.Strong)]
        UIColor FillColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull shadowColor;
        [Export("shadowColor", ArgumentSemantic.Strong)]
        UIColor ShadowColor { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @protocol MBVoiceControllerDelegate
    [BaseType(typeof(NSObject))]
    [Model]
    interface MBVoiceControllerDelegate
    {
        // @optional -(void)voiceController:(MBRouteVoiceController * _Nonnull)voiceController spokenInstrucionsDidFailWithError:(NSError * _Nonnull)error;
        [Export("voiceController:spokenInstrucionsDidFailWithError:")]
        void VoiceController(MBRouteVoiceController voiceController, NSError error);

        // @optional -(void)voiceController:(MBRouteVoiceController * _Nonnull)voiceController didInterruptSpokenInstruction:(MBSpokenInstruction * _Nonnull)interruptedInstruction withInstruction:(MBSpokenInstruction * _Nonnull)interruptingInstruction;
        [Export("voiceController:didInterruptSpokenInstruction:withInstruction:")]
        void VoiceController(MBRouteVoiceController voiceController, MBSpokenInstruction interruptedInstruction, MBSpokenInstruction interruptingInstruction);

        // @optional -(MBSpokenInstruction * _Nullable)voiceController:(MBRouteVoiceController * _Nonnull)voiceController willSpeakSpokenInstruction:(MBSpokenInstruction * _Nonnull)instruction routeProgress:(MBRouteProgress * _Nonnull)routeProgress __attribute__((warn_unused_result));
        [Export("voiceController:willSpeakSpokenInstruction:routeProgress:")]
        [return: NullAllowed]
        MBSpokenInstruction VoiceController(MBRouteVoiceController voiceController, MBSpokenInstruction instruction, MBRouteProgress routeProgress);
    }

    // @interface MBWayNameLabel : MBStylableLabel
    [BaseType(typeof(MBStylableLabel))]
    interface MBWayNameLabel
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBWayNameView : UIView
    [BaseType(typeof(UIView))]
    interface MBWayNameView
    {
        // @property (nonatomic, strong) UIColor * _Nullable borderColor;
        [NullAllowed, Export("borderColor", ArgumentSemantic.Strong)]
        UIColor BorderColor { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)layoutSubviews;
        [Export("layoutSubviews")]
        [Override]
        void LayoutSubviews();
    }

}

