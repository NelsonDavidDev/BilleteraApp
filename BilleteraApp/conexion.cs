using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BilleteraApp
{
    #region Madejo de usuarios
    public class Login
    {
        //constructor vacio
        public Login() { }

        [PrimaryKey, AutoIncrement] //Funcioa como un incremental para la variable ID
        [MaxLength(10)]
            public int Id { set; get; }
        [MaxLength(20)]

        public string Usuario { get; set; }
        [MaxLength(20)] //Limita la cantidad de caracteres que lleva la variable

        public string Password { get; set; }
    }
    #endregion
    public class Ticket { 
        
        }

    #region Manejo de datos y conexion a BD
    public class Auxiliar
    {
        static object locker = new object();
        SQLiteConnection conexion;

        public Auxiliar()
        {
            conexion = Conectar();
            conexion.CreateTable<Login>();
        }

        public SQLite.SQLiteConnection Conectar()
        {
            SQLiteConnection conexionAuxiliar;
            string nombreArchivo = "tdea.db3"; //nombre de la base de datos
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);
            conexionAuxiliar = new SQLiteConnection(rutaCompleta);
            return conexionAuxiliar;
        }
        //Seleccionar muchos
        public IEnumerable<Login> SeleccionarTodo()
        {
            lock (locker)
            {
                return (from i in conexion.Table<Login>() select i).ToList();
            }
        }
        //Seleccionar un registro
        public Login Seleccionar(string UserName, string PassWord)
        {
            lock (locker)
            {
                return conexion.Table<Login>().FirstOrDefault(x => x.Usuario == UserName && x.Password == PassWord);
            }
        }
        //Actualizar o insertar
        public int Guardar(Login registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }
        
            //Eliminar
        public int Eliminar(int ID)
        {
            lock (locker)
            {
                return conexion.Delete<Login>(ID);
            }
        }
    }
    #endregion
}