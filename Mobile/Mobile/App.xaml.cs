using Xamarin.Forms;

namespace Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogInPage())
            {
                BarBackgroundColor = (Color)Resources["HeadBackgroundColor"],
                BarTextColor = ((Color)Resources["AccentColor"]).AddLuminosity(-0.1)
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}