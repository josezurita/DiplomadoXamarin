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
            SetContentView(Resource.Layout.Main);
            var ImageButton = FindViewById<ImageButton>(Resource.Id.imageButton1);

            ImageButton.Click += async (sender, e) =>
            {
                var Client = new SALLab13.ServiceClient();
                string EMail = "jose.zurita@epn.edu.ec";
                string Password = "**************";
                var Result = await Client.ValidateAsync(this, EMail, Password);
                Android.App.AlertDialog.Builder Builder =
                    new AlertDialog.Builder(this);
                AlertDialog Alert = Builder.Create();
                Alert.SetTitle("Resultado de la varificación");
                Alert.SetIcon(Resource.Drawable.Icon);
                Alert.SetMessage($"{Result.Status}\n{Result.FullName}\n{Result.Token}");
                Alert.SetButton("Ok", (s, e1) => { });
                Alert.Show();
            };
        }
    }
}

