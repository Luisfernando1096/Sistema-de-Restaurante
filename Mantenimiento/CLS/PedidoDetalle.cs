using System;

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
        String cocinero;
        int idProducto;
        int idPedido;
        int cantidad;
        double precio;
        double subTotal;
        String grupo;
        String usuario;
        String fecha;
        String nombre;
        String mesa;
        String cliente;
        String salon;
        String mesero;

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
        public string Nombre { get => nombre; set => nombre = value; }
        public string Mesa { get => mesa; set => mesa = value; }
        public string Cocinero { get => cocinero; set => cocinero = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public string Salon { get => salon; set => salon = value; }
        public string Mesero { get => mesero; set => mesero = value; }

        public String Insertar(Boolean primerPedido)
        {
            string sentencia;
            if (primerPedido)
            {
                sentencia = @"INSERT INTO pedido_detalle(cocinando, extras, horaEntregado, horaPedido, idProducto, idPedido, cantidad, precio, subTotal, grupo, usuario) VALUES(" + cocinando + ", '" + extras + "', '" + horaEntregado + "', '" + horaPedido + "', " + idProducto + ", (SELECT MAX(ultimoId) FROM(SELECT idPedido AS ultimoId FROM pedido) AS subconsulta), " + cantidad + ", " + precio + ", " + subTotal + ", '" + grupo + "', '" + usuario + "');";

            }
            else
            {
                sentencia = @"INSERT INTO pedido_detalle(cocinando, extras, horaEntregado, horaPedido, idProducto, idPedido, cantidad, precio, subTotal, grupo, usuario) VALUES(" + cocinando + ", '" + extras + "', '" + horaEntregado + "', '" + horaPedido + "', " + idProducto + ", " + idPedido + ", " + cantidad + ", " + precio + ", " + subTotal + ", '" + grupo + "', '" + usuario + "');";

            }

            return sentencia;
        }

        public String ActualizarCompra(Boolean primerPedido)
        {
            string sentencia;
            if (primerPedido)
            {
                sentencia = @"UPDATE pedido_detalle pd, pedido pe SET  pd.cantidad = " + cantidad + @", pd.subTotal = " + subTotal + @" 
                            WHERE pe.idPedido=pd.idPedido AND pe.idPedido = (SELECT LAST_INSERT_ID()) AND pd.idProducto = " + idProducto + @"
                            AND pd.idDetalle = " + IdDetalle + ";";
            }
            else if(!primerPedido && precio > 0)
            {
                sentencia = @"UPDATE pedido_detalle pd, pedido pe SET  pd.cantidad = " + cantidad + @", pd.subTotal = " + subTotal + @", pd.precio = " + precio + @" 
                            WHERE pe.idPedido=pd.idPedido AND pe.idPedido = " + idPedido + @" AND pd.idProducto = " + idProducto + @"
                            AND pd.idDetalle = " + IdDetalle + ";";
            }
            else
            {
                sentencia = @"UPDATE pedido_detalle pd, pedido pe SET  pd.cantidad = " + cantidad + @", pd.subTotal = " + subTotal + @" 
                            WHERE pe.idPedido=pd.idPedido AND pe.idPedido = " + idPedido + @" AND pd.idProducto = " + idProducto + @"
                            AND pd.idDetalle = " + IdDetalle + ";";
            }
            

            return sentencia;
        }

        public Boolean ActualizarDatos()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"UPDATE pedido_detalle SET cocinando = " + cocinando + ", extras = '" + extras + "', horaEntregado= '" + horaEntregado + "', horaPedido = '" + horaPedido + "', idProducto = " + idProducto + ", idPedido = " + idPedido + ", cantidad = " + cantidad + ", precio = " + precio + ", subTotal = " + subTotal + ", grupo = '" + grupo + "', usuario = '" + usuario + "', fecha = '" + fecha + "' " +
                "WHERE idDetalle = " + idDetalle + ";";

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

        public String Eliminar()
        {
            string sentencia;
            sentencia = @"DELETE FROM pedido_detalle " +
                "WHERE idDetalle = " + idDetalle + ";";

            return sentencia;
        }
    }
}
