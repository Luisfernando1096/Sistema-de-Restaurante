using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    internal class Compra_detalle
    {
        int _idDetalleCompra;
        int _idCompra;
        int _idProducto;
        int _idIngrediente;
        int _cantidad;
        double _precio;
        double _subTotal;

        public int IdDetalleCompra { get => _idDetalleCompra; set => _idDetalleCompra = value; }
        public int IdCompra { get => _idCompra; set => _idCompra = value; }
        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public int IdIngrediente { get => _idIngrediente; set => _idIngrediente = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public double SubTotal { get => _subTotal; set => _subTotal = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"insert into compra_detalle(idCompra,idProducto,idIngrediente,cantidad,precio,subtotal) values("+_idCompra+","+_idProducto+","+_idIngrediente+","+_cantidad+","+_precio+","+_subTotal+");";

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
            sentencia = @"update compra_detalle set idCompra = "+_idCompra+", idProducto = "+_idProducto+", idIngrediente = "+_idIngrediente+", cantidad = "+_cantidad+", precio = "+_precio+", subTotal = "+_subTotal+" where idDetalleCompra = "+_idDetalleCompra+";";

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
            sentencia = @"delete from compra_detalle where idDetalleCompra = "+_idDetalleCompra+";";

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
