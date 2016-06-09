
using Xamarin.Forms;

namespace FormsRotation
{
    public class App : Application
    {
        public const string ShowPortraitView = "SHOW_PORTRAIT_VIEW";
        public const string ShowLandscapeView = "SHOW_LANDSCAPE_VIEW";
        public const string NativeNavigationMessage = "FormsRotatoin.NativeNavigationMessage";

        public App()
        {
            // The root page of your application         
            MainPage = new NavigationPage( new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public new static App Current => (App)Application.Current;
    }
}
