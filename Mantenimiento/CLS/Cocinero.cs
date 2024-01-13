using System;

namespace Mantenimiento.CLS
{
    internal class Cocinero
    {
        int _idCocinero;
        double _tiempoOcuapdo;
        int _idEmpleado;

        public int IdCocinero { get => _idCocinero; set => _idCocinero = value; }
        public double TiempoOcuapdo { get => _tiempoOcuapdo; set => _tiempoOcuapdo = value; }
        public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"insert into cocinero(tiempoOcuapdo, idEmpleado) values (" + _tiempoOcuapdo + "," + _idEmpleado + ");";

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
            sentencia = @"update cocinero set tiempoOcuapdo = " + _tiempoOcuapdo + ", idEmpleado = " + _idEmpleado + " where idCocinero = " + _idCocinero + ";";

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
            sentencia = @"delete from cocinero where idCocinero =" + _idCocinero + ";";

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
