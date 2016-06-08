using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace FormsRotation.Droid
{
    [Activity(MainLauncher = false, Label = "LandscapeActivity", Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen"
    , ScreenOrientation = ScreenOrientation.Landscape
    , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
        Exported = false
    )]
    public class LandscapeActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_landscape);

            var button = FindViewById<Button>(Resource.Id.backButton);

            button.Click += (sender, e) => {
                Finish(); // back to the previous activity
            };
        }
    }
}