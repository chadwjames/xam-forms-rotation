using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace FormsRotation.Droid
{
    [Activity(MainLauncher = false, Label = "PortraitActivity", Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen"
    , ScreenOrientation = ScreenOrientation.Portrait
    , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
        Exported = false
    )]
    public class PortraitActivity: Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_portrait);

            var button = FindViewById<Button>(Resource.Id.backButton);

            button.Click += (sender, e) => {
                Finish(); // back to the previous activity
            };
        }

    }
}