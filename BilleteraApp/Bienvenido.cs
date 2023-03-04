using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilleteraApp
{
    [Activity(Label = "Bienvenido")]
    public class Bienvenido : Activity
    {
        Button btnCerrar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Bienvenido);

            // Create your application here
            btnCerrar = FindViewById<Button>(Resource.Id.btnCerrar);
            btnCerrar.Click += BtnCerrrar_Click;
        }

        private void BtnCerrrar_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
            Finish();
        }
    }
}