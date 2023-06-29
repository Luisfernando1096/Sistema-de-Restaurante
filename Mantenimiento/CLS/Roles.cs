using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class Roles
    {
        /*DECLARACION DE VARIABLES*/
        int idRol;
        string rol;

        /*DECLARACION DE PROPIEDADES*/
        public int IdRol { get => idRol; set => idRol = value; }
        public string Rol { get => rol; set => rol = value; }

        /*OPREACIONES BASICAS*/
        public Boolean Insertar() 
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = "INSERT INTO rol(rol) VALUES('" + rol + "');";
            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                int filasAfectadas = 0;
                filasAfectadas = op.EjecutarSentencia(sentencia);
                if (filasAfectadas > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        public Boolean Actualizar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = "UPDATE rol SET rol = '" + rol + "' WHERE idRol = " + idRol + ";";
            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                int filasAfectadas = 0;
                filasAfectadas = op.EjecutarSentencia(sentencia);
                if (filasAfectadas > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        public Boolean Eliminar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = "DELETE FROM rol WHERE idRol = " + idRol + ";";
            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                int filasAfectadas = 0;
                filasAfectadas = op.EjecutarSentencia(sentencia);
                if (filasAfectadas > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
    }
}
