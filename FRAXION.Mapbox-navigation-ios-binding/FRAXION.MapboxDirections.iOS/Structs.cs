using System;
using Foundation;
using ObjCRuntime;

namespace MapboxDirections
{
    [Native]
    public enum MBLaneIndication : ulong
    {
        SharpRight = (1 << 1),
        Right = (1 << 2),
        SlightRight = (1 << 3),
        StraightAhead = (1 << 4),
        SlightLeft = (1 << 5),
        Left = (1 << 6),
        SharpLeft = (1 << 7),
        UTurn = (1 << 8)
    }

    [Native]
    public enum MBAttributeOptions : ulong
    {
        Distance = (1 << 1),
        ExpectedTravelTime = (1 << 2),
        Speed = (1 << 3),
        CongestionLevel = (1 << 4)
    }

    [Native]
    public enum MBRoadClasses : ulong
    {
        Toll = (1 << 1),
        Restricted = (1 << 2),
        Motorway = (1 << 3),
        Ferry = (1 << 4),
        Tunnel = (1 << 5)
    }

    [Native]
    public enum MBCongestionLevel : long
    {
        Unknown = 0,
        Low = 1,
        Moderate = 2,
        Heavy = 3,
        Severe = 4
    }

    [Native]
    public enum MBDrivingSide : long
    {
        Left = 0,
        Right = 1
    }

    [Native]
    public enum MBInstructionFormat : ulong
    {
        Text = 0,
        Html = 1
    }

    [Native]
    public enum MBManeuverDirection : long
    {
        None = 0,
        SharpRight = 1,
        Right = 2,
        SlightRight = 3,
        StraightAhead = 4,
        SlightLeft = 5,
        Left = 6,
        SharpLeft = 7,
        UTurn = 8
    }

    [Native]
    public enum MBManeuverType : long
    {
        None = 0,
        Depart = 1,
        Turn = 2,
        Continue = 3,
        PassNameChange = 4,
        Merge = 5,
        TakeOnRamp = 6,
        TakeOffRamp = 7,
        ReachFork = 8,
        ReachEnd = 9,
        UseLane = 10,
        TakeRoundabout = 11,
        TakeRotary = 12,
        TurnAtRoundabout = 13,
        ExitRoundabout = 14,
        ExitRotary = 15,
        HeedWarning = 16,
        Arrive = 17,
        PassWaypoint = 18
    }

    [Native]
    public enum MBMeasurementSystem : ulong
    {
        Imperial = 0,
        Metric = 1
    }

    [Native]
    public enum MBRouteShapeFormat : ulong
    {
        GeoJSON = 0,
        Polyline = 1,
        Polyline6 = 2
    }

    [Native]
    public enum MBRouteShapeResolution : ulong
    {
        None = 0,
        Low = 1,
        Full = 2
    }

    [Native]
    public enum MBTransportType : long
    {
        None = 0,
        Automobile = 1,
        Ferry = 2,
        MovableBridge = 3,
        Inaccessible = 4,
        Walking = 5,
        Cycling = 6,
        Train = 7
    }

    [Native]
    public enum MBVisualInstructionComponentType : long
    {
        Delimiter = 0,
        Text = 1,
        Image = 2,
        Exit = 3,
        ExitCode = 4
    }

    [Native]
    public enum MBDirectionsProfileIdentifier: long
    {
        // extern const MBDirectionsProfileIdentifier MBDirectionsProfileIdentifierAutomobile;
        [Field("MBDirectionsProfileIdentifierAutomobile", "__Internal")]
        Automobile,
        // extern const MBDirectionsProfileIdentifier MBDirectionsProfileIdentifierAutomobileAvoidingTraffic;
        [Field("MBDirectionsProfileIdentifierAutomobileAvoidingTraffic", "__Internal")]
        AutomobileAvoidingTraffic,
        // extern const MBDirectionsProfileIdentifier MBDirectionsProfileIdentifierCycling;
        [Field("MBDirectionsProfileIdentifierCycling", "__Internal")]
        Cycling,
        // extern const MBDirectionsProfileIdentifier MBDirectionsProfileIdentifierWalking;
        [Field("MBDirectionsProfileIdentifierWalking", "__Internal")]
        Walking,
    }

    [Native]
    public enum MBDirectionsPriority: long
    {
        // extern const MBDirectionsPriority MBDirectionsPriorityLow;
        [Field("MBDirectionsPriorityLow", "__Internal")]
        Low,

        // extern const MBDirectionsPriority MBDirectionsPriorityDefault;
        [Field("MBDirectionsPriorityDefault", "__Internal")]
        Default,

        // extern const MBDirectionsPriority MBDirectionsPriorityHigh;
        [Field("MBDirectionsPriorityHigh", "__Internal")]
        High,
    }

}

