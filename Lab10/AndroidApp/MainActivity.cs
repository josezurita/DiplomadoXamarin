using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int Counter = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Validate);
            /*
            var ContentHeader = FindViewById<TextView>(Resource.Id.ContentHeader);
            var ClickMe = FindViewById<Button>(Resource.Id.ClickMe);
            var ClickCounter = FindViewById<TextView>(Resource.Id.ClickCounter);
            ContentHeader.Text = GetText(Resource.String.ContentHeader);

            Android.Content.Res.AssetManager Manager = this.Assets;
            using (var Reader = new System.IO.StreamReader(Manager.Open("Contenido.txt")))
            {
                ContentHeader.Text += $"\n\n{Reader.ReadToEnd()}";
            }

            ClickMe.Click += (s, e) =>
            {
                Counter++;
                ClickCounter.Text = Resources.GetQuantityString(
                    Resource.Plurals.numberOfClicks, Counter, Counter);
                var Player = Android.Media.MediaPlayer.Create(
                    this, Resource.Raw.sound);
                Player.Start();
            };*/
            Validate(Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId), "jose.zurita@epn.edu.ec", "**************");
        }

        public async void Validate(string device, string correo, string contrasena)
        {
            var ValidationText = FindViewById<TextView>(Resource.Id.ValidationText);
            var ServiceClient = new SALLab10.ServiceClient();
            var SvcResult = await ServiceClient.ValidateAsync(
                correo,
                contrasena,
                device);
            ValidationText.Text = $"{SvcResult.Fullname}\n{SvcResult.Status}\n{SvcResult.Token}";
        }
    }
}

