﻿using ObjCRuntime;

namespace MapboxCoreNavigation
{

    [Native]
    public enum MBFeedbackSource : long
    {
        User = 0,
        Reroute = 1,
        Unknown = 2
    }

    [Native]
    public enum MBFeedbackType : long
    {
        General = 0,
        Accident = 1,
        Hazard = 2,
        RoadClosed = 3,
        NotAllowed = 4,
        MissingRoad = 5,
        MissingExit = 6,
        RoutingError = 7,
        ConfusingInstruction = 8,
        ReportTraffic = 9,
        MapIssue = 10
    }

    [Native]
    public enum MBNavigationSimulatiolongent : long
    {
        Manual = 0,
        PoorGPS = 1
    }

    [Native]
    public enum MBNavigationSimulationOptions : long
    {
        OnPoorGPS = 0,
        Always = 1,
        Never = 2
    }

    [Native]
    public enum MBNavigationSimulationIntent : long
    {
        Manual = 0,
        PoorGPS = 1,
    }
}

