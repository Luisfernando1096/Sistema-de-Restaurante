using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataManager
{
    public class DBConexion
    {//Server=localhost;Port=3306;Database=bd_service_express_dsk;Uid=root;Pwd=Pa55word;

        String _CadenaConexion = "";
        protected MySqlConnection conexion = new MySqlConnection();
        public Boolean Conectar()
        {
            _CadenaConexion = ObtenerCadenaConexion();
            Console.WriteLine(_CadenaConexion);
            Boolean result = false;
            try
            {
                conexion.ConnectionString = _CadenaConexion;
                conexion.Open();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void Desconectar()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        private String ObtenerCadenaConexion()
        {
            string archivoConfiguracion = "configuracion.xml";

            if (File.Exists(archivoConfiguracion))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(archivoConfiguracion);

                string servidor = xmlDoc.SelectSingleNode("/Configuracion/Servidor").InnerText;
                string baseDeDatos = xmlDoc.SelectSingleNode("/Configuracion/BaseDeDatos").InnerText;
                string usuario = xmlDoc.SelectSingleNode("/Configuracion/Usuario").InnerText;
                string contraseña = xmlDoc.SelectSingleNode("/Configuracion/Contraseña").InnerText;

                // Utiliza los valores de la cadena de conexión como desees
                string cadenaConexion = $"Server={servidor};Port=3306;Database={baseDeDatos};Uid={usuario};Pwd={contraseña};";
                return cadenaConexion;
            }
            return "";
        }
    }

}


