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

            var buttonValidate = FindViewById<Button>(Resource.Id.buttonValidate);

            buttonValidate.Click += async (sender, e) =>
            {
                var Client = new SALLab14.ServiceClient();
                var Result = await Client.ValidateAsync(this);
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

