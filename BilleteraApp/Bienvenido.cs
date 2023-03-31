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
        Button btnReadPocket;
        Button btnCerrar;
        Button btnCreatePocket;
        Toolbar toolbarmenu;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Bienvenido);

            // Create your application here
            btnReadPocket = FindViewById<Button>(Resource.Id.btnReadPocket);
            btnCerrar = FindViewById<Button>(Resource.Id.btnCerrar);
            btnCreatePocket = FindViewById<Button>(Resource.Id.btnCreatePocket);
            toolbarmenu = FindViewById<Toolbar>(Resource.Id.toolbarMenu);

            SetActionBar(toolbarmenu);
            ActionBar.Title = "Menu";

            btnReadPocket.Click += BtnReadPocket_Click;
            btnCerrar.Click += BtnCerrar_Click;
            btnCreatePocket.Click += BtnCreatePocket_Click;
        }

        private void BtnReadPocket_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ReadPocket));
            StartActivity(i);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.icAdd:
                    Intent i = new Intent(this, typeof(CreatePocket));
                    StartActivity(i);
                    break;
                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
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
    }
}