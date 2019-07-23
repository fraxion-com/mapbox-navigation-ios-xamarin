using System;
using ObjCRuntime;
namespace MapboxSpeech
{

    [Native]
    public enum MBAudioFormat : ulong
    {
        MBAudioFormatMp3 = 0
    }

    [Native]
    public enum MBSpeechGender : ulong
    {
        Female = 0,
        Male = 1,
        Neuter = 2
    }

    [Native]
    public enum MBTextType : ulong
    {
        Text = 0,
        Ssml = 1
    }
}

