using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System;
using System.Net.Http;

namespace BilleteraApp
{
    [Activity(Label = "WebService")]
    public class WebService : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WebService);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            Button btnConsultar = FindViewById<Button>(Resource.Id.btnConsultar);
            Button btnInsertar = FindViewById<Button>(Resource.Id.btnInsertar);

            EditText txtId = FindViewById<EditText>(Resource.Id.txtId);
            EditText txtName = FindViewById<EditText>(Resource.Id.txtName);
            EditText txtDescription = FindViewById<EditText>(Resource.Id.txtDescription);


            //btnConsultar += BtnConsultar_click;

            string urlServicio = "https://jsonplaceholder.typicode.com/posts";

            btnConsultar.Click += async (sender, e) =>
            {
                try
                {
                    Cliente cliente = new Cliente();
                    if (!string.IsNullOrWhiteSpace(txtId.Text))
                    {
                        int id = 0;
                        if (int.TryParse(txtId.Text.Trim(), out id))
                        {
                            var resultado = await cliente.Get<Entrada>(urlServicio + "/" + txtId.Text);
                            if (cliente.codigoHTTP == 200)
                            {
                                txtName.Text = resultado.title;
                                txtDescription.Text = resultado.body;
                                Toast.MakeText(this, "Consulta realizada con éxito", ToastLength.Long).Show();
                            }
                            else
                            {
                                throw new Exception(cliente.codigoHTTP.ToString());
                            }
                        }
                        else
                        {
                            Toast.MakeText(this, "Por favor ingrese un número entero como ID", ToastLength.Long).Show();
                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Por favor ingrese un ID", ToastLength.Long).Show();
                    }
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, "Error: " + ex.Message, ToastLength.Long).Show();
                }
            };

            btnInsertar.Click += async (sender, e) =>
            {
                try
                {
                    Cliente cliente = new Cliente();
                    Entrada entrada = new Entrada();

                    entrada.title = txtName.Text;
                    entrada.body = txtDescription.Text;

                    if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text))
                    {
                        var resultado = await cliente.Post<Entrada>(entrada, urlServicio);
                        if (cliente.codigoHTTP == 201)
                        {
                            txtId.Text = resultado.id.ToString();
                            AlertDialog.Builder builder = new AlertDialog.Builder(this);
                            builder.SetTitle("Confirmación");
                            builder.SetMessage("Inserción realizada con éxito");
                            builder.SetNeutralButton("Ok", (s, e) => {});

                            // Muestra la alerta de confirmación
                            builder.Show();
                        }
                        else
                        {
                            throw new Exception(cliente.codigoHTTP.ToString());
                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Por favor ingrese el título y el contenido de la entrada", ToastLength.Long).Show();
                    }
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, "Error: " + ex.Message, ToastLength.Long).Show();
                }
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }

    public class Entrada
    {
        public Entrada()
        {
            userId = 1;
            id = 0;
            title = "";
            body = "";
        }
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

    public class Cliente
    {
        public Cliente()
        {
            codigoHTTP = 200;
        }

        public int codigoHTTP { get; set; }

        //GET
        public async Task<T> Get<T>(string url)
        {
            HttpClient cliente = new HttpClient();
            var response = await cliente.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            codigoHTTP = (int)response.StatusCode;
            return JsonConvert.DeserializeObject<T>(json);
        }

        //POST

        public async Task<T> Post<T>(Entrada item, string url)
        {
            HttpClient cliente = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "aplication/json");

            HttpResponseMessage response = null;
            response = await cliente.PostAsync(url, content);
            json = await response.Content.ReadAsStringAsync();
            codigoHTTP = (int)response.StatusCode;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}