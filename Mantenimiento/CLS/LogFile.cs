using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class LogFile
    {
        int idLog;
        int idSesion;
        int idUsuario;
        String fecha;
        String log;
        String estado;

        public int IdLog { get => idLog; set => idLog = value; }
        public int IdSesion { get => idSesion; set => idSesion = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Log { get => log; set => log = value; }
        public string Estado { get => estado; set => estado = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"INSERT INTO logfile(idSesion, idUsuario, fecha, log, estado) VALUES(" + idSesion + ", " + idUsuario + ", '" + fecha + "', '" + log + "', '" + estado + "');";

            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasInsertadas = 0;
                filasInsertadas = op.EjecutarSentencia(sentencia);
                if (filasInsertadas > 0)
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
            sentencia = @"UPDATE logfile SET idSesion = " + idSesion + ", idUsuario = " + idUsuario + ", fecha= '" + fecha + "', log = '" + log + "', estado = '" + estado + "' " +
                "WHERE idLog = " + idLog + ";";

            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasActualizadas = 0;
                filasActualizadas = op.EjecutarSentencia(sentencia);
                if (filasActualizadas > 0)
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
            sentencia = @"DELETE FROM logfile " +
                "WHERE idLog = " + idLog + ";";

            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasEliminadas = 0;
                filasEliminadas = op.EjecutarSentencia(sentencia);
                if (filasEliminadas > 0)
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
