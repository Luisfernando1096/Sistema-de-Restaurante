using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    public class PedidoDetalle
    {
        int idDetalle;
        bool cocinando;
        String extras;
        String horaEntregado;
        String horaPedido;
        int idCocinero;
        int idProducto;
        int idPedido;
        int cantidad;
        double precio;
        double subTotal;
        String grupo;
        String usuario;
        String fecha;

        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public bool Cocinando { get => cocinando; set => cocinando = value; }
        public string Extras { get => extras; set => extras = value; }
        public string HoraEntregado { get => horaEntregado; set => horaEntregado = value; }
        public string HoraPedido { get => horaPedido; set => horaPedido = value; }
        public int IdCocinero { get => idCocinero; set => idCocinero = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
        public double SubTotal { get => subTotal; set => subTotal = value; }
        public string Grupo { get => grupo; set => grupo = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Fecha { get => fecha; set => fecha = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"INSERT INTO pedido_detalle(cocinando, extras, horaEntregado, horaPedido, idProducto, idPedido, cantidad, precio, subTotal, grupo) VALUES(" + cocinando + ", '" + extras + "', '" + horaEntregado + "', '" + horaPedido + "', " + idProducto + ", " + idPedido + ", " + cantidad + ", " + precio + ", " + subTotal + ", '" + grupo + "');";

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
            sentencia = @"UPDATE pedido_detalle SET cocinando = " + cocinando + ", extras = '" + extras + "', horaEntregado= '" + horaEntregado + "', horaPedido = '" + horaPedido + "', idProducto = " + idProducto + ", idPedido = " + idPedido + ", cantidad = " + cantidad + ", precio = " + precio + ", subTotal = " + subTotal + ", grupo = '" + grupo + "' " +
                "WHERE idDetalle = " + IdDetalle + ";";

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
            sentencia = @"DELETE FROM pedido_detalle " +
                "WHERE idDetalle = " + idDetalle + ";";

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
