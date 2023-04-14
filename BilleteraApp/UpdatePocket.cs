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
    [Activity(Label = "UpdatePocket")]
    public class UpdatePocket : Activity
    {
        EditText txtIdPocket;
        EditText txtNameBolsillo;
        EditText txtDescription;
        EditText txtValue;
        Button btnUpdate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UpdatePocket);

            txtNameBolsillo = FindViewById<EditText>(Resource.Id.txtNameBolsillo);
            txtDescription = FindViewById<EditText>(Resource.Id.txtDescription);
            txtValue = FindViewById<EditText>(Resource.Id.txtValue);
            txtIdPocket = FindViewById<EditText>(Resource.Id.txtIdPocket);
            btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);

            //Recuperar datos de la vista anterior
            var pocketId = Intent.GetStringExtra("pocketId");
            var pocketName = Intent.GetStringExtra("pocketName");
            var pocketDesc = Intent.GetStringExtra("pocketDesc");
            var pocketValue = Intent.GetStringExtra("pocketValue");

            txtIdPocket.Text = pocketId;
            txtIdPocket.Visibility = ViewStates.Invisible;
            txtNameBolsillo.Text += pocketName;
            txtDescription.Text = pocketDesc;
            txtValue.Text = pocketValue;

            btnUpdate.Click += BtnUpdatePocket_Click;
        }

        private void BtnUpdatePocket_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNameBolsillo.Text.Trim()) && !string.IsNullOrEmpty(txtDescription.Text.Trim()))
                {
                    try
                    {
                        new Auxiliar().GuardarPocket(new Pocket()
                        {
                            Id = Int32.Parse(txtIdPocket.Text.Trim()),
                            NombreBolsillo = txtNameBolsillo.Text.Trim(),
                            Descripcion = txtDescription.Text.Trim(),
                            Valor = double.Parse(txtValue.Text.Trim())
                        });

                        Toast.MakeText(this, "Bolsillo Actualizado", ToastLength.Long).Show();
                        Finish();
                        Intent i = new Intent(this, typeof(ReadPocket));
                        StartActivity(i);
                    }
                    catch (Exception ex)
                    {

                        Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
                    }
                   
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