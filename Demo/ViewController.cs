using CoreGraphics;
using CoreLocation;
using Mapbox;
using MapboxCoreNavigation;
using MapboxDirections;
using MapboxNavigation;
using System;
using UIKit;

namespace Demo
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        MGLMapView map;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            map = new MGLMapView(View.Bounds);
            map.AutoresizingMask = new UIViewAutoresizing();
            map.WeakDelegate = this;
            View.AddSubview(map);

            map.ShowsUserLocation = true;
            map.SetUserTrackingMode(MGLUserTrackingMode.Follow, true);


            UILongPressGestureRecognizer longPress = new UILongPressGestureRecognizer(DidLongPressOnMap);
            map.AddGestureRecognizer(longPress);

            MBWaypoint[] ways = new MBWaypoint[2];
            ways[0] = new MBWaypoint(new CLLocationCoordinate2D(45.622073, -73.824223), -1, "origin");
            ways[1] = new MBWaypoint(new CLLocationCoordinate2D(45.626764, -73.825742), -1, "destination");
            MBNavigationRouteOptions options = new MBNavigationRouteOptions(ways, MBDirectionsProfileIdentifier.Automobile);

            
            MBDirections.SharedDirections.CalculateDirectionsWithOptions(options, (way, routes, error) =>
            {
                if (routes.Length == 0 || routes == null)
                {
                    string errorMessage = "No routes found";
                    if (error != null)
                    {
                        errorMessage = error.LocalizedDescription;
                    }
                    var alert = UIAlertController.Create("Error", errorMessage, UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("Dismiss", UIAlertActionStyle.Cancel, null));
                    PresentViewController(alert, true, null);
                }
                else
                {
                    MBRoute route = routes[0];
                    MBNavigationService navigationService = new MBNavigationService(route, MBDirections.SharedDirections, null, null, MBNavigationSimulationOptions.Always, null);
                    //MBNavigationOptions navigationOptions = new MBNavigationOptions(null, navigationService, null, null, null);
                    MBNavigationViewController navigationViewController = new MBNavigationViewController(route, null);

                    PresentViewController(navigationViewController, true, null);
                }
            });




        }


        private void DidLongPressOnMap(UILongPressGestureRecognizer sender)
        {
            if (sender.State != UIGestureRecognizerState.Began) return;

            CGPoint point = sender.LocationInView(map);
            CLLocationCoordinate2D coordinate2D = map.ConvertPoint(point, map);
            if (map.Annotations != null)
            {
                map.RemoveAnnotations(map.Annotations);
            }
            MGLPointAnnotation pointAnnotation = new MGLPointAnnotation();

            pointAnnotation.Coordinate = coordinate2D;
            pointAnnotation.Title ="Start Navigation";
            map.AddAnnotation(pointAnnotation);
        }

        /*private void CalculateRoute(CLLocationCoordinate2D origin, CLLocationCoordinate2D destination, Action<Router, CLError> action)
        {
            //  MBWaypoint originWaypoint = new MBWaypoint(origin, -1, "Start");
            //   MBWaypoint destinationWaypoint = new MBWaypoint(destination, -1, "Destination");


            //MBMatchOptions routeOptions = new MBMatchOptions(new MBWaypoint[] { originWaypoint, destinationWaypoint }, MBDirectionsProfileIdentifier.AutomobileAvoidingTraffic);

            //MBDirections.SharedDirections.CalculateRoutesMatchingOptions(routeOptions, (waypoints, routes, error) =>
            //{
            //    if (routes == null || routes.Length == 0) return;



            //});



        }*/

        /*
        public void DrawRoute(MBRoute route)
        {
            if (route.CoordinateCount < 0) return;

            MGLPolylineFeature polylineFeature = (Mapbox.MGLPolylineFeature) MGLPolyline.PolylineWithCoordinates(route.Coordinates, route.CoordinateCount);

            

           

//            guard route.coordinateCount > 0 else { return }
//            // Convert the route’s coordinates into a polyline
//            var routeCoordinates = route.coordinates!
//let polyline = MGLPolylineFeature(coordinates: &routeCoordinates, count: route.coordinateCount)

//// If there's already a route line on the map, reset its shape to the new route
//            if let source = mapView.style?.source(withIdentifier: "route-source") as? MGLShapeSource {
//                source.shape = polyline
//} else
//            {
//                let source = MGLShapeSource(identifier: "route-source", features: [polyline], options: nil)

//// Customize the route line color and width
//                let lineStyle = MGLLineStyleLayer(identifier: "route-style", source: source)
//lineStyle.lineColor = NSExpression(forConstantValue: #colorLiteral(red: 0.1897518039, green: 0.3010634184, blue: 0.7994888425, alpha: 1))
//lineStyle.lineWidth = NSExpression(forConstantValue: 3)

//// Add the source and style layer of the route line to the map
//mapView.style?.addSource(source)
//mapView.style?.addLayer(lineStyle)
        }
        */

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}