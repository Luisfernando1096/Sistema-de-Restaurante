using System;

namespace Mantenimiento.CLS
{
    public class Usuario
    {
        /*DECLARACION DE VARIABLES*/
        int idUsuario;
        int idRol;
        string pinCode;

        /*DECLARACION DE PROPIEDADES*/
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdRol { get => idRol; set => idRol = value; }
        public string PinCode { get => pinCode; set => pinCode = value; }

        /*OPERACIONES BASICAS*/
        public Boolean Insertar()
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "INSERT INTO usuario(idUsuario, idRol, pinCode) VALUES(" + idUsuario + ", " + idRol + ", md5(" + pinCode + "));";
            try
            {
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
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "UPDATE usuario SET idRol = " + idRol + ", pinCode = '" + pinCode + "';";
            try
            {
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
        public Boolean Contraseña()
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "UPDATE usuario SET pinCode = MD5('" + pinCode + "') WHERE idUsuario = " + idUsuario + ";";
            try
            {
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
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "DELETE FROM usuario WHERE idUsuario = " + idUsuario + ";";
            try
            {
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
