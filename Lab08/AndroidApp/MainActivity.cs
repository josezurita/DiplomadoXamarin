using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace AndroidApp
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);
            //var ViewGroup = (Android.Views.ViewGroup)
            //    Window.DecorView.FindViewById(Android.Resource.Id.Content);
            //var MainLayout = ViewGroup.GetChildAt(0) as LinearLayout;

            //var HeaderImage = new ImageView(this);
            //HeaderImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);

            //MainLayout.AddView(HeaderImage);
            //var UserNameTextView = new TextView(this);
            //UserNameTextView.Text = GetString(Resource.String.UserName);
            //MainLayout.AddView(UserNameTextView);

            Validate(Android.Provider.Settings.Secure.GetString(ContentResolver,Android.Provider.Settings.Secure.AndroidId), "jose.zurita@epn.edu.ec", "Jose099767037.");
        }
        public async void Validate(string device, string correo, string contrasena)
        {
            var UserNameValue = FindViewById<TextView>(Resource.Id.UserNameValue);
            var StatusValue = FindViewById<TextView>(Resource.Id.StatusValue);
            var TokenValue = FindViewById<TextView>(Resource.Id.TokenValue);
            var ServiceClient = new SALLab08.ServiceClient();
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

