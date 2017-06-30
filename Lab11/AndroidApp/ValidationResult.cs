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
    class ValidationResult:Fragment
    {
        string Fullname { get; set; }
       SALLab11.Status Status { get; set; }
        string Token { get; set; }

        public override string ToString()
        {
            return $"{Fullname}\n{Status}\n{Token}";
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

        public void SaveValidation (SALLab11.ResultInfo result)
        {
            this.Fullname = result.Fullname;
            this.Status = result.Status;
            this.Token = result.Token;
        }
    }
}