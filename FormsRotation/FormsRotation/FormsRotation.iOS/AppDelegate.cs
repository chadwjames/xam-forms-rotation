using System;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace FormsRotation.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public bool RestrictRotation { get; set; }
        public UIInterfaceOrientationMask OrientationMask { get; set; }
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            LoadApplication(new App());

            MessagingCenter.Subscribe<MainPage, NativeNavigationArgs>(
                this,
                App.NativeNavigationMessage,
                HandleNativeNavigationMessage);

            return base.FinishedLaunching(app, options);
        }

        private void HandleNativeNavigationMessage(MainPage sender, NativeNavigationArgs args)
        {
            switch (args.Navigation)
            {
                case App.ShowPortraitView:
                    OrientationMask = UIInterfaceOrientationMask.Portrait;
                    sender.Navigation.PushModalAsync(new PortraitPage());                    
                    break;

                case App.ShowLandscapeView:
                    OrientationMask = UIInterfaceOrientationMask.Landscape;
                    sender.Navigation.PushModalAsync(new LandscapePage());
                    break;
            }
        }
        
        //todo this export caused the iOS simulator to crash, works on devices...
        [Export("application:supportedInterfaceOrientationsForWindow:")]
        public UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, IntPtr forWindow)
        {
            return RestrictRotation ? OrientationMask : UIInterfaceOrientationMask.AllButUpsideDown;
        }
    }
}
