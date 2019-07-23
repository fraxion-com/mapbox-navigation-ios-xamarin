using System;
using Foundation;
using ObjCRuntime;
namespace MapboxSpeech
{
   

    // @interface MBSpeechOptions : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBSpeechOptions
    {
        // -(instancetype _Nonnull)initWithText:(NSString * _Nonnull)text __attribute__((objc_designated_initializer));
        [Export("initWithText:")]
        [DesignatedInitializer]
        IntPtr MBSpeechOptionsWithText(string text);

        // -(instancetype _Nonnull)initWithSsml:(NSString * _Nonnull)ssml __attribute__((objc_designated_initializer));
        [Export("initWithSsml:")]
        [DesignatedInitializer]
        IntPtr MBSpeechOptionsWithSsml(string ssml);

        // @property (copy, nonatomic) NSString * _Nonnull text;
        [Export("text")]
        string Text { get; set; }

        // @property (nonatomic) enum MBAudioFormat outputFormat;
        [Export("outputFormat", ArgumentSemantic.Assign)]
        MBAudioFormat OutputFormat { get; set; }

        // @property (copy, nonatomic) NSLocale * _Nonnull locale;
        [Export("locale", ArgumentSemantic.Copy)]
        NSLocale Locale { get; set; }

        // @property (nonatomic) enum MBSpeechGender speechGender;
        [Export("speechGender", ArgumentSemantic.Assign)]
        MBSpeechGender SpeechGender { get; set; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBSpeechOptions New();
    }

    // @interface MBSpeechSynthesizer : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBSpeechSynthesizer
    {
        // @property (readonly, nonatomic, strong, class) MBSpeechSynthesizer * _Nonnull sharedSpeechSynthesizer;
        [Static]
        [Export("sharedSpeechSynthesizer", ArgumentSemantic.Strong)]
        MBSpeechSynthesizer SharedSpeechSynthesizer { get; }

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

        // -(NSURLSessionDataTask * _Nonnull)audioDataWithOptions:(MBSpeechOptions * _Nonnull)options completionHandler:(void (^ _Nonnull)(NSData * _Nullable, NSError * _Nullable))completionHandler;
        [Export("audioDataWithOptions:completionHandler:")]
        NSUrlSessionDataTask AudioDataWithOptions(MBSpeechOptions options, Action<NSData, NSError> completionHandler);

        // -(NSURL * _Nonnull)URLForSynthesizingSpeechWithOptions:(MBSpeechOptions * _Nonnull)options __attribute__((warn_unused_result));
        [Export("URLForSynthesizingSpeechWithOptions:")]
        NSUrl URLForSynthesizingSpeechWithOptions(MBSpeechOptions options);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        MBSpeechSynthesizer New();
    }

}

