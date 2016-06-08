using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FormsRotation.LandscapePage), typeof(FormsRotation.iOS.PortraitPageRenderer))]
namespace FormsRotation.iOS
{
    public class PortraitPageRenderer : PageRenderer
    {

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var hostViewController = ViewController;

            var viewController = new UIViewController();

            var label = new UILabel(new CGRect(0, 40, 320, 40)) { Text = "Native Portrait iOS UIViewController" };
            viewController.View.Add(label);

            hostViewController.AddChildViewController(viewController);
            hostViewController.View.Add(viewController.View);

            viewController.DidMoveToParentViewController(hostViewController);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            RestrictRotation(true);
        }

        public override bool ShouldAutorotate()
        {
            return true;
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

