using System;

namespace Mantenimiento.CLS
{
    public class Egreso
    {
        int idEgreso;
        int idCaja;
        int idUsuario;
        String fecha;
        String descripcion;
        double cantidad;

        public int IdEgreso { get => idEgreso; set => idEgreso = value; }
        public int IdCaja { get => idCaja; set => idCaja = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"INSERT INTO egreso(idCaja, idUsuario, fecha, descripcion, cantidad) VALUES(" + idCaja + ", " + idUsuario + ", '" + fecha + "', '" + descripcion + "', " + cantidad + ");";

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
            sentencia = @"UPDATE egreso SET idCaja = " + idCaja + ", idUsuario = " + idUsuario + ", fecha= '" + fecha + "', descripcion = '" + descripcion + "', cantidad = " + cantidad + " " +
                "WHERE idEgreso = " + idEgreso + ";";

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
            sentencia = @"DELETE FROM egreso " +
                "WHERE idEgreso = " + idEgreso + ";";

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

        public String EliminarTabla()
        {
            string sentencia;
            sentencia = @"DELETE FROM egreso";
            return sentencia;
        }
    }
}
