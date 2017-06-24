using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PhoneApp
{
    [Activity(Label = "Validar Actividad", Theme = "@android:style/Theme.Holo", MainLauncher = true, Icon = "@drawable/icon")]
    public class ValidateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Validate);

            var EmailText = FindViewById<EditText>(Resource.Id.EmailText);
            var PasswordText = FindViewById<EditText>(Resource.Id.PasswordText);
            var ValidateButton = FindViewById<Button>(Resource.Id.ValidateButton);

            string Device;

            Device = Android.Provider.Settings.Secure.GetString(
                ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);

            ValidateButton.Click += (object sender, System.EventArgs e) =>
            {
                Validate(Device, EmailText.Text, PasswordText.Text);
            };
        }
        public async void Validate(string device, string correo, string contrasena)
        {
            string Result;
            var ValidationText = FindViewById<TextView>(Resource.Id.ValidationText);
            var ServiceClient = new SALLab06.ServiceClient();
            Console.WriteLine($"{correo} | {contrasena}");
            var SvcResult = await ServiceClient.ValidateAsync(
                correo,
                contrasena,
                device);
            Result = $"{SvcResult.Status}\n{SvcResult.Fullname}\n{SvcResult.Token}";
            ValidationText.Text = Result;
        }
    }
}