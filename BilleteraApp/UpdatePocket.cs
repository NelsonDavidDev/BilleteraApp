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
    [Activity(Label = "updatePocket")]
    public class UpdatePocket : Activity


    {
        Button btnUpdatePocket;
        EditText txtNameBolsillo;
        EditText txtDescription;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UpdatePocket);
            btnUpdatePocket.Click += BtnUpdatePocket_Click;

            // Create your application here
        }

        private void BtnUpdatePocket_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(UpdatePocket));
            StartActivity(i);

            try
            {
                if (!string.IsNullOrEmpty(txtNameBolsillo.Text.Trim()) || !string.IsNullOrEmpty(txtDescription.Text.Trim()))
                {
                    Toast.MakeText(this, "Registro Actualizado", ToastLength.Long).Show();
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "No ha realizado ningún cambio", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }


    }
}