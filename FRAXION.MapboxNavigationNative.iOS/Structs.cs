using ObjCRuntime;

namespace MapboxNavigationNative
{
 
    [Native]
    public enum MBRouteState : long
    {
        Invalid,
        Initialized,
        Tracking,
        Complete,
        OffRoute,
        Stale
    }

    [Native]
    public enum MBNavigationSimulationIntent : long
    {
        Manual,
        PoorGPS,
    }
}

