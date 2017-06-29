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
            var ListColors = FindViewById<ListView>(Resource.Id.listView1);
            ListColors.Adapter = new CustomAdapters.ColorAdapter(
                this, Resource.Layout.ListItem,
                Resource.Id.textView1,
                Resource.Id.textView2,
                Resource.Id.imageView1);
            Validate(Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId), "jose.zurita@epn.edu.ec", "**************");
        }

        public async void Validate(string device, string correo, string contrasena)
        {
            var ValidationText = FindViewById<TextView>(Resource.Id.ValidationText);
            var ServiceClient = new SALLab12.ServiceClient();
            var SvcResult = await ServiceClient.ValidateAsync(
                correo,
                contrasena,
                device);
            ValidationText.Text = $"{SvcResult.FullName}\n{SvcResult.Status}\n{SvcResult.Token}";
        }
    }
}

