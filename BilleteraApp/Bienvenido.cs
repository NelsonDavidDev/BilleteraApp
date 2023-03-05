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
        Button btnCreatePocket;
        Button btnDeletePocket;
        Button btnUpdatePocket;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Bienvenido);

            // Create your application here
            btnCerrar = FindViewById<Button>(Resource.Id.btnCerrar);
            btnCreatePocket = FindViewById<Button>(Resource.Id.btnCreatePocket);
            btnDeletePocket = FindViewById<Button>(Resource.Id.btnDeletePocket);

            btnCerrar.Click += BtnCerrar_Click;
            btnCreatePocket.Click += BtnCreatePocket_Click;
            btnDeletePocket.Click += BtnDeletePocket_Click;
            btnUpdatePocket.Click += BtnUpdatePocket_Click;
        }

        private void BtnDeletePocket_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(DeletePocket));
            StartActivity(i);
        }

        private void BtnCreatePocket_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(CreatePocket));
            StartActivity(i);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }

        private void BtnUpdatePocket_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(UpdatePocket));
            StartActivity(i);
            Finish();
        }
    }
}