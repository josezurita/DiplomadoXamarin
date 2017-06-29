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

namespace AndroidApp
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnCreate");
            // Create your application here
        }

        protected override void OnStart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnStart");
            base.OnStart();
        }

        protected override void OnResume()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnResume");
            base.OnResume();
        }

        protected override void OnPause()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnPause");
            base.OnPause();
        }

        protected override void OnStop()
        {
            base.OnStop();
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnStop");
        }

        protected override void OnDestroy()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnDestroy");
            base.OnDestroy();
        }

        protected override void OnRestart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity B - OnRestart");
            base.OnRestart();
        }
    }
}