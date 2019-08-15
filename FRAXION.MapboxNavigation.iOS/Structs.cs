using ObjCRuntime;

namespace MapboxNavigation
{
    [Native]
    public enum MBCarPlayActivity : long
    {
        Browsing = 0,
        PanningInBrowsingMode = 1,
        Previewing = 2,
        Navigating = 3
    }

    [Native]
    public enum LanesStyleKitResizingBehavior : long
    {
        AspectFit = 0,
        AspectFill = 1,
        Stretch = 2,
        Center = 3
    }

    [Native]
    public enum ManeuversStyleKitResizingBehavior : long
    {
        AspectFit = 0,
        AspectFill = 1,
        Stretch = 2,
        Center = 3
    }

    [Native]
    public enum MBStyleType : long
    {
        Day = 0,
        Night = 1
    }
}

