using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class IngredienteProducto
    {
        int id;
        int idIngrediente;
        int idProducto;
        double cantidad;

        public int Id { get => id; set => id = value; }
        public int IdIngrediente { get => idIngrediente; set => idIngrediente = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"INSERT INTO ingrediente_producto(idIngrediente, idProducto, cantidad) VALUES(" + idIngrediente + ", " + idProducto + ", '" + cantidad + "');";

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
            sentencia = @"UPDATE ingrediente_producto SET idIngrediente = " + idIngrediente + ", idProducto = " + idProducto + ", cantidad = '" + cantidad + "' " +
                "WHERE id = " + id + ";";

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
            sentencia = @"DELETE FROM ingrediente_producto " +
                "WHERE id = " + id + ";";

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
