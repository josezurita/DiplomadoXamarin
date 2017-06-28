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
            SetContentView (Resource.Layout.Main);
            Validate(Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId), "jose.zurita@epn.edu.ec", "**************");
        }

        public async void Validate(string device, string correo, string contrasena)
        {
            var UserNameValue = FindViewById<TextView>(Resource.Id.UserNameValue);
            var StatusValue = FindViewById<TextView>(Resource.Id.StatusValue);
            var TokenValue = FindViewById<TextView>(Resource.Id.TokenValue);
            var ServiceClient = new SALLab09.ServiceClient();
            var SvcResult = await ServiceClient.ValidateAsync(
                correo,
                contrasena,
                device);
            StatusValue.Text = $"{SvcResult.Status}";
            UserNameValue.Text = $"{SvcResult.Fullname}";
            TokenValue.Text = $"{SvcResult.Token}";
        }
    }
}

