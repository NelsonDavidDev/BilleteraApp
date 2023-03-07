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
    [Activity(Label = "DeletePocket")]
    public class DeletePocket : Activity
    {
        Button btnDeletePocket1;
        Button btnDeletePocket2;
        Button btnDeletePocket3;
        Button btnDeletePocket4;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DeletePocket);
            // Create your application here

            btnDeletePocket1 = FindViewById<Button>(Resource.Id.btnDeletePocket1);
            btnDeletePocket2 = FindViewById<Button>(Resource.Id.btnDeletePocket2);
            btnDeletePocket3 = FindViewById<Button>(Resource.Id.btnDeletePocket3);
            btnDeletePocket4 = FindViewById<Button>(Resource.Id.btnDeletePocket4);

            btnDeletePocket1.Click += BtnDeletePocket_Click1;
            btnDeletePocket2.Click += BtnDeletePocket_Click2;
            btnDeletePocket3.Click += BtnDeletePocket_Click3;
            btnDeletePocket4.Click += BtnDeletePocket_Click4;
        }

        private void BtnDeletePocket_Click4(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Confirmación");
            builder.SetMessage("¿Está seguro de que desea borrar este bolsillo?");
            builder.SetPositiveButton("Sí", (s, e) => {
                ViewGroup parent = (ViewGroup)btnDeletePocket4.Parent;
                parent.RemoveView(btnDeletePocket4);
            });
            builder.SetNegativeButton("No", (s, e) => { /* Acción cuando se hace clic en No */ });

            // Muestra la alerta de confirmación
            builder.Show();
        }

        private void BtnDeletePocket_Click3(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Confirmación");
            builder.SetMessage("¿Está seguro de que desea borrar este bolsillo?");
            builder.SetPositiveButton("Sí", (s, e) => {
                ViewGroup parent = (ViewGroup)btnDeletePocket3.Parent;
                parent.RemoveView(btnDeletePocket3);
            });
            builder.SetNegativeButton("No", (s, e) => { /* Acción cuando se hace clic en No */ });

            // Muestra la alerta de confirmación
            builder.Show();
        }

        private void BtnDeletePocket_Click2(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Confirmación");
            builder.SetMessage("¿Está seguro de que desea borrar este bolsillo?");
            builder.SetPositiveButton("Sí", (s, e) => {
                ViewGroup parent = (ViewGroup)btnDeletePocket2.Parent;
                parent.RemoveView(btnDeletePocket2);
            });
            builder.SetNegativeButton("No", (s, e) => { /* Acción cuando se hace clic en No */ });

            // Muestra la alerta de confirmación
            builder.Show();
        }

        private void BtnDeletePocket_Click1(object sender, System.EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Confirmación");
            builder.SetMessage("¿Está seguro de que desea borrar este bolsillo?");
            builder.SetPositiveButton("Sí", (s, e) => {
                ViewGroup parent = (ViewGroup)btnDeletePocket1.Parent;
                parent.RemoveView(btnDeletePocket1);
            });
            builder.SetNegativeButton("No", (s, e) => { /* Acción cuando se hace clic en No */ });

            // Muestra la alerta de confirmación
            builder.Show();
        }
    }
}