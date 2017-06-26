using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Lab07
{
    [Activity(Label = "Lab07", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            var EmailEditText = FindViewById<EditText>(Resource.Id.EmailEditText);
            var PasswordEditText = FindViewById<EditText>(Resource.Id.PasswordEditText);
            var ValidateButton = FindViewById<Button>(Resource.Id.ValidateButton);
            string Device;

            Device = Android.Provider.Settings.Secure.GetString(
                ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);

            ValidateButton.Click += (object sender, System.EventArgs e) =>
            {
                Validate(Device, EmailEditText.Text, PasswordEditText.Text);
            };
        }

        public async void Validate(string device, string correo, string contrasena)
        {
            string Result;
            var ValidationResultTextView = FindViewById<TextView>(Resource.Id.ValidationResultTextView);
            var Builder = new Notification.Builder(this);
            var ServiceClient = new SALLab07.ServiceClient();
            Console.WriteLine($"{correo} | {contrasena}");
            var SvcResult = await ServiceClient.ValidateAsync(
                correo,
                contrasena,
                device);
            Result = $"{SvcResult.Status}\n{SvcResult.Fullname}\n{SvcResult.Token}";

            if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Builder.SetContentTitle("Resultado de la Validación");
                Builder.SetContentText(Result);
                Builder.SetSmallIcon(Resource.Drawable.Icon);
                Builder.SetCategory(Notification.CategoryMessage);

                var ObjectNotification = Builder.Build();
                var Manager = GetSystemService(
                    Android.Content.Context.NotificationService) as NotificationManager;
                Manager.Notify(0, ObjectNotification);
            }
            else
            {
                ValidationResultTextView.Text = Result;
            }
        }
    }
}

