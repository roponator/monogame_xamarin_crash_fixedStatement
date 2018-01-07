using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace Game1
{
    [Activity(Label = "Game1"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.FullUser
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        public unsafe void CallingThisFunctionCrashes()
        {
            // the code in here does not get executed because it crashes at function call for this function
            string x = "sadf";
            fixed (char* c = x)
            {
                char* b = c;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            CallingThisFunctionCrashes();

            var g = new Game1();
            SetContentView((View)g.Services.GetService(typeof(View)));
            g.Run();
        }
    }
}

