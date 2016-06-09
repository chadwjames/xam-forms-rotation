using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FormsRotation.LandscapePage), typeof(FormsRotation.iOS.LandscapePageRenderer))]
namespace FormsRotation.iOS
{
    public class LandscapePageRenderer : PageRenderer
    {        
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var label = new UILabel(new CGRect(40, 40, 320, 40)) { Text = "Native Landscape iOS UIViewController" };
            View.Add(label);

            //back button
            var button = UIButton.FromType(UIButtonType.RoundedRect);
            button.SetTitle("Back", UIControlState.Normal);
            button.Frame = new CGRect(0, 100, 140, 40);
            button.TouchUpInside += (s, a) =>
            {
                Element.Navigation.PushModalAsync(new MainPage());
            };
            View.AddSubview(button);

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            RestrictRotation(true);
        }

        public override bool ShouldAutorotate()
        {
            return false;
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return UIInterfaceOrientationMask.Landscape;
        }

        public override UIInterfaceOrientation PreferredInterfaceOrientationForPresentation()
        {
            return UIInterfaceOrientation.LandscapeRight;
        }

        private static void RestrictRotation(bool restriction)
        {
            var app = (AppDelegate)UIApplication.SharedApplication.Delegate;
            app.RestrictRotation = restriction;            
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            RestrictRotation(false);
        }
    }
}

