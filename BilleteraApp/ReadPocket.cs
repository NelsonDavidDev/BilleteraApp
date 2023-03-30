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

            listaDePockets = new Auxiliar().SeleccionarTodosLosPockets().ToList();
        }
       
    }
}