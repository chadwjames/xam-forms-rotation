using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FormsRotation.PortraitPage), typeof(FormsRotation.iOS.PortraitPageRenderer))]
namespace FormsRotation.iOS
{
    public class PortraitPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
                   
            var label = new UILabel(new CGRect(40, 40, 320, 40)) { Text = "Native Portrait iOS UIViewController" };
            View.Add(label);

            //back button
            var button = UIButton.FromType(UIButtonType.RoundedRect);
            button.SetTitle("Back", UIControlState.Normal);
            button.Frame = new CGRect(0, 100, 140, 40);
            button.TouchUpInside += (s, a) =>
            {
                RestrictRotation(false);
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
            return UIInterfaceOrientationMask.Portrait;
        }

        public override UIInterfaceOrientation PreferredInterfaceOrientationForPresentation()
        {
            return UIInterfaceOrientation.Portrait;
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

