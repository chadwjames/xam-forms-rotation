
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

namespace FormsRotation.Droid
{
    [Activity(Label = "FormsRotation", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            LoadApplication(new App());

            MessagingCenter.Subscribe<MainPage, NativeNavigationArgs>(
                this,
                App.NativeNavigationMessage,
                HandleNativeNavigationMessage);
        }

        private void HandleNativeNavigationMessage(MainPage sender, NativeNavigationArgs args)
        {
            //StartActivity(typeof(MyThirdActivity));
            switch (args.Navigation)
            {
                case App.ShowLandscapeView :
                    StartActivity(typeof(LandscapeActivity));
                    break;
                case App.ShowPortraitView :
                    StartActivity(typeof(PortraitActivity));
                    break;
            }
        }
    }
}

