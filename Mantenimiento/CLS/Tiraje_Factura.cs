using System;

namespace Mantenimiento.CLS
{
    public class Tiraje_Factura
    {
        /*DECLARACION DE VARIABLES*/
        int idTiraje;
        string tipoFactura;
        string serie;
        int inicio;
        int fin;
        int actual;
        bool activo;

        /*DECLARACION DE PROPIEDADES*/
        public int IdTiraje { get => idTiraje; set => idTiraje = value; }
        public string TipoFactura { get => tipoFactura; set => tipoFactura = value; }
        public string Serie { get => serie; set => serie = value; }
        public int Inicio { get => inicio; set => inicio = value; }
        public int Fin { get => fin; set => fin = value; }
        public int Actual { get => actual; set => actual = value; }
        public bool Activo { get => activo; set => activo = value; }

        /*OPERACIONES BASICAS*/
        public Boolean Insertar()
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "INSERT INTO tiraje_factura(tipoFactura, serie, inicio, fin, actual, activo) VALUES( '" + tipoFactura + "','" + serie + "'," + inicio + "," + fin + "," + actual + ", " + activo + ");";
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
            sentencia = "UPDATE tiraje_factura SET tipoFactura = '" + tipoFactura + "', serie = '" + serie + "', inicio = " + inicio + ", fin = " + fin + ", actual = " + actual + ", activo = " + activo + " WHERE idTiraje = " + idTiraje + ";";
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

        public Boolean ActualizarTirajeActual()
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "UPDATE tiraje_factura SET actual = " + actual + " WHERE idTiraje = " + idTiraje + ";";
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
            sentencia = "DELETE FROM tiraje_factura WHERE idTiraje = " + idTiraje + ";";
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
