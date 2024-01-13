using System;
using System.Data;

namespace SessionManager
{
    public class Session
    {
        //Atributos
        static Session instancia = null;
        static readonly Object codelock = new object();
        string usuario;
        string idUsuario;
        string rol;
        string idRol;
        //Propiedades

        public static Session Instancia//Esta es una propiedad y retorna el valor de un atributo
        {
            get
            {
                if (instancia == null)
                {
                    lock (codelock)
                    {
                        if (instancia == null)
                        {
                            instancia = new Session();
                        }
                    }
                }
                return instancia;
            }
        }

        //public string Usuario { get => usuario; }
        public string IdUsuario { get => idUsuario; }
        public string Rol { get => rol; }
        public string IdRol { get => idRol; }
        public string Usuario { get => usuario; set => usuario = value; }

        //Metodos
        private Session()
        {

        }

        public Boolean IniciarSesion(string clave)
        {
            Boolean result = false;

            try
            {
                DataTable datosUsuario = new DataTable();
                datosUsuario = DataManager.DBConsultas.IniciarSesion(clave);
                if (datosUsuario.Rows.Count == 1)
                {
                    idUsuario = datosUsuario.Rows[0]["idUsuario"].ToString();
                    usuario = datosUsuario.Rows[0]["nombres"].ToString();
                    idRol = datosUsuario.Rows[0]["idRol"].ToString();
                    rol = datosUsuario.Rows[0]["rol"].ToString();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return result;
        }
        public Boolean CerrarSesion()
        {
            idUsuario = "";
            //usuario = "";
            idRol = "";
            rol = "";
            return true;
        }

    }
}