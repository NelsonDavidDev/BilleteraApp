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
    [Activity(Label = "ReadPocket")]
    public class ReadPocket : Activity
    {
        public List<Pocket> listaDePockets;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ReadPocket);

            // Create your application here
            var inflater = LayoutInflater.FromContext(this); // Obtener el LayoutInflater desde el contexto de la actividad
            var layoutPockets = FindViewById<LinearLayout>(Resource.Id.layout_pockets); // Obtener el LinearLayout desde el layout XML
            listaDePockets = new Auxiliar().SeleccionarTodosLosPockets().ToList();


            foreach (var pocket in listaDePockets)
            {
                // Inflar la vista del elemento a crear (en este caso, un TextView)
                var vistaDePocket = inflater.Inflate(Resource.Layout.ReadPocket, null);

                // Configurar el TextView con los datos del pocket actual
                var txtName = vistaDePocket.FindViewById<TextView>(Resource.Id.textview_nombre);
                var txtDescription = vistaDePocket.FindViewById<TextView>(Resource.Id.textview_descripcion);
                var txtvalue = vistaDePocket.FindViewById<TextView>(Resource.Id.textview_value);
                var btnUpdate = vistaDePocket.FindViewById<Button>(Resource.Id.btn_update);
                var btnDelete = vistaDePocket.FindViewById<Button>(Resource.Id.btn_delete);
                btnUpdate.Visibility = ViewStates.Visible;
                btnDelete.Visibility = ViewStates.Visible;
                txtName.Text = "Nombre: " + pocket.NombreBolsillo;
                txtDescription.Text = "Descripcion: " + pocket.Descripcion;
                txtvalue.Text = "Valor: " + pocket.Valor.ToString();
                txtName.Visibility = ViewStates.Visible;
                txtDescription.Visibility = ViewStates.Visible;
                txtvalue.Visibility = ViewStates.Visible;

                btnDelete.Click += (sender, args) =>
                {
                    AlertDialog.Builder builder = new AlertDialog.Builder(this);
                    builder.SetTitle("Confirmación");
                    builder.SetMessage("¿Está seguro de que desea borrar este bolsillo?");
                    builder.SetPositiveButton("Sí", (s, e) =>
                    {
                        try
                        {
                            new Auxiliar().EliminarPocket(pocket.Id);
                            Toast.MakeText(this, "Bolsillo eliminado", ToastLength.Short).Show();

                            // recargar el layout para ver los cambios
                            Recreate();
                        }
                        catch (Exception ex)
                        {
                            Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
                        }
                    });
                    builder.SetNegativeButton("No", (s, e) => { /* Acción cuando se hace clic en No */ });

                    // Muestra la alerta de confirmación
                    builder.Show();
                };


                btnUpdate.Click += (sender, args) =>
                {
                    Intent i = new Intent(this, typeof(UpdatePocket));
                    i.PutExtra("pocketId", pocket.Id.ToString());
                    i.PutExtra("pocketName", pocket.NombreBolsillo);
                    i.PutExtra("pocketDesc", pocket.Descripcion);
                    i.PutExtra("pocketValue", pocket.Valor.ToString());
                    StartActivity(i);
                    Finish();
                };


                // Añadir la vista del elemento al LinearLayout padre
                layoutPockets.AddView(vistaDePocket);
            }
        }
    }
}