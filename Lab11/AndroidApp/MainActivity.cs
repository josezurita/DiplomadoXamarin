using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Complex Data;
        ValidationResult Result;
        int Counter = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnCreate");

            Data = (Complex)this.FragmentManager.FindFragmentByTag("Data");
            Result = (ValidationResult)this.FragmentManager.FindFragmentByTag("Result");
            var ValidationText = FindViewById<TextView>(Resource.Id.ValidationText);

            if (Result == null)
            {
                Result = new ValidationResult();
                var FragmentTransactionResult = this.FragmentManager.BeginTransaction();
                FragmentTransactionResult.Add(Result, "Result");
                FragmentTransactionResult.Commit();
                Validate(Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId), "jose.zurita@epn.edu.ec", "**************");
            }
            ValidationText.Text = Result.ToString();

            if (Data == null)
            {
                Data = new Complex();
                var FragmentTransaction = this.FragmentManager.BeginTransaction();
                FragmentTransaction.Add(Data, "Data");
                FragmentTransaction.Commit();
            }

            if (bundle != null)
            {
                Counter = bundle.GetInt("CounterValue", 0);
                Android.Util.Log.Debug("Lab11Log", "Activity A - Recovered Instance State");
            }

            var ClickCounter = FindViewById<Button>(Resource.Id.ClicksCounter);
            ClickCounter.Text = Resources.GetString(Resource.String.ClicksCounter_Text, Counter);
            ClickCounter.Text += $"\n{Data.ToString()}";

            ClickCounter.Click += (sender, e) =>
            {
                Counter++;
                ClickCounter.Text = Resources.GetString(Resource.String.ClicksCounter_Text, Counter);

                Data.Real++;
                Data.Imaginary++;
                ClickCounter.Text += $"\n{Data.ToString()}";
            };
            FindViewById<Button>(Resource.Id.StartActivity).Click += (sender, e) => {
                
            };
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnSaveInstanceState");
            outState.PutInt("CounterValue", Counter);
            base.OnSaveInstanceState(outState);
        }

        protected override void OnStart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnStart");
            base.OnStart();
        }

        protected override void OnResume()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnResume");
            base.OnResume();
        }

        protected override void OnPause()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnPause");
            base.OnPause();
        }

        protected override void OnStop()
        {
            base.OnStop();
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnStop");
        }

        protected override void OnDestroy()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnDestroy");
            base.OnDestroy();
        }

        protected override void OnRestart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnRestart");
            base.OnRestart();
        }

        public async void Validate(string device, string correo, string contrasena)
        {
            var ServiceClient = new SALLab11.ServiceClient();
            var SvcResult = await ServiceClient.ValidateAsync(
                correo,
                contrasena,
                device);

            Result.SaveValidation(SvcResult);
        }
    }
}

