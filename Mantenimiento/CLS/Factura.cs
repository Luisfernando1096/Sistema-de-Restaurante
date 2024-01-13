using System;

namespace Mantenimiento.CLS
{
    class Factura
    {
        /*DECLARACION DE VARIABLES*/
        int idFactura;
        Enum tipoFactura;
        string serie;
        string inicio;
        string fin;
        int actual;

        /*DECLARACION DE PROPIEDADES*/
        public int IdFactura { get => idFactura; set => idFactura = value; }
        public Enum TipoFactura { get => tipoFactura; set => tipoFactura = value; }
        public string Serie { get => serie; set => serie = value; }
        public string Inicio { get => inicio; set => inicio = value; }
        public string Fin { get => fin; set => fin = value; }
        public int Actual { get => actual; set => actual = value; }

        /*OPERACIONES BASICAS*/
        public Boolean Insertar()
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "INSERT INTO factura(tipoFactura, serie, inicio, fin, actual) VALUES('" + tipoFactura + "','" + serie + "','" + inicio + "','" + fin + "'," + actual + ");";
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
            sentencia = "UPDATE factura SET tipoFactura = '" + tipoFactura + "', serie = '" + serie + "', inicio = '" + inicio + "', fin = '" + fin + "', actual = " + actual + " WHERE idFactura = " + idFactura + ";";

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
            sentencia = "DELETE FROM factura WHERE idFactura = " + idFactura + ";";
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
