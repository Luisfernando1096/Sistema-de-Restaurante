using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public static class DBConsultas
    {
        public static DataTable IniciarSesion(string pClave)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT r.idRol, r.rol, u.idUsuario, e.idEmpleado, e.nombres
                                    FROM rol r, usuario u, empleado e
                                    WHERE u.idRol=r.idRol AND u.pinCode=MD5('" + pClave + "') limit 1;";
                DataManager.DBOperacion operacion = new DataManager.DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }

        }

        public static DataTable Salones()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT * FROM salon;";
                DBOperacion operacion = new DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }
        }
    }
}

