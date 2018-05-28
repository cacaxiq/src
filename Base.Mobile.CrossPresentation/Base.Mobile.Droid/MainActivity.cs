
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Base.Constants;
using Base.Mobile.CrossPresentation;
using Xamarin.Forms;

namespace Base.Mobile.Droid
{
    [Activity(Label = "Base.Mobile.CrossPresentation", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            InitializePlugins();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private void InitializePlugins()
        {
            UserDialogs.Init(this);
            global::Android.Gms.Ads.MobileAds.Initialize(ApplicationContext, AppConstants.AdmobKeyAndroid);
        }
    }
}

