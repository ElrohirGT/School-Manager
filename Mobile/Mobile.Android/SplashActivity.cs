using Android.App;
using Android.Content;
using System.Threading.Tasks;

namespace Mobile.Droid
{
    [Activity(Label = "School Manager", Theme = "@style/MainTheme.Splash", NoHistory = true, MainLauncher = true)]
    public class SplashActivity : Activity
    {
        protected override void OnResume()
        {
            base.OnResume();
            var startUpWork = new Task(() => StartUp());
            startUpWork.Start();
        }

        private void StartUp() => StartActivity(new Intent(Application.Context, typeof(MainActivity)));
    }
}