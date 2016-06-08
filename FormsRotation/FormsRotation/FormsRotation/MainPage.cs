using Xamarin.Forms;

namespace FormsRotation
{
    public class MainPage: ContentPage
    {
        public MainPage()
        {
            var landscapeButton = new Button
            {
                Text = "Show Landscape Page"
            };

            landscapeButton.Clicked +=
                (s, e) =>
                    MessagingCenter.Send(this, App.NativeNavigationMessage,
                        new NativeNavigationArgs { Navigation = App.ShowLandscapeView });

            var portraitButton = new Button
            {
                Text = "Show Portait Page"
            };

            portraitButton.Clicked +=
                (s, e) =>
                    MessagingCenter.Send(this, App.NativeNavigationMessage,
                        new NativeNavigationArgs { Navigation = App.ShowPortraitView });

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new Label
                    {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Welcome to Xamarin Forms Rotation!"
                    },
                    portraitButton,
                    landscapeButton
                }
            };
        }
    }
}