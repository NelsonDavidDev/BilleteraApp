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

namespace BilleteraApp
{
    [Activity(Label = "CreatePocket")]
    public class CreatePocket : Activity
    {
        EditText txtName;
        EditText txtDescription;
        Button btnCreate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreatePocket);

            // Create your application here
            txtName = FindViewById<EditText>(Resource.Id.txtName);
            txtDescription = FindViewById<EditText>(Resource.Id.txtDescription);    
            btnCreate = FindViewById<Button>(Resource.Id.btnCreate);

            btnCreate.Click += BtnCreate_Click;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text.Trim()) && !string.IsNullOrEmpty(txtDescription.Text.Trim()))
                {
                    Toast.MakeText(this, "Bolsillo Creado", ToastLength.Long).Show();
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Complete ambos campos", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}