using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var Validator = new PCLProject.AppValidator(new AndroidDialog(this));
            Validator.EMail = "jose.zurita@epn.edu.ec";
            Validator.Password = "***********";
            Validator.Device = Android.Provider.Settings.Secure.GetString(
                ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);
            Validator.Validate();
        }
    }
}

