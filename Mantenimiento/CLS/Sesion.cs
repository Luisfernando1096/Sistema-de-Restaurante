using System;

namespace Mantenimiento.CLS
{
    class Sesion
    {
        /*DECLARACION DE VARIABLES*/
        int idSesion;
        int idUsuario;
        DateTime fecha;
        DateTime fechaFin;
        string estadoSesion;

        /*DECLARACION DE PROPIEDADES*/
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public string EstadoSesion { get => estadoSesion; set => estadoSesion = value; }
        public int IdSesion { get => idSesion; set => idSesion = value; }

        /*OPERACIONES BASICAS*/
        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = "INSERT INTO sesion (idUsuario, fecha, fechaFin, estadoSesion) VALUES (" + idUsuario + ", '" + fecha + "', '" + fechaFin + "', '" + estadoSesion + "');";
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
            sentencia = @"UPDATE sesion SET idUsuario = " + idUsuario + ", fecha = '" + fecha + "', fechaFin = '" + fechaFin + "', estadoSesion = '" + estadoSesion + "' " +
                "WHERE idSEsion = " + idSesion + ";";
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
        public Boolean Ekiminar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"DELETE FROM sesion " +
                "WHERE idSesion = " + idSesion + ";";
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
