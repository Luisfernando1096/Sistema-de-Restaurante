using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    public class Pedido
    {
        int idPedido;
        int idCliente;
        int idMesa;
        int idCuenta;
        int idMesero;
        bool cancelado;
        String fecha;
        bool listo;
        double total;
        double descuento;
        double iva;
        double propina;
        double totalPago;
        double saldo;
        int idTiraje;
        String nFactura;
        bool anular;
        double efectivo;
        double credito;
        double btc;

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdMesa { get => idMesa; set => idMesa = value; }
        public int IdCuenta { get => idCuenta; set => idCuenta = value; }
        public int IdMesero { get => idMesero; set => idMesero = value; }
        public bool Cancelado { get => cancelado; set => cancelado = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public bool Listo { get => listo; set => listo = value; }
        public double Total { get => total; set => total = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public double Iva { get => iva; set => iva = value; }
        public double Propina { get => propina; set => propina = value; }
        public double TotalPago { get => totalPago; set => totalPago = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public int IdTiraje { get => idTiraje; set => idTiraje = value; }
        public string NFactura { get => nFactura; set => nFactura = value; }
        public bool Anular { get => anular; set => anular = value; }
        public double Efectivo { get => efectivo; set => efectivo = value; }
        public double Credito { get => credito; set => credito = value; }
        public double Btc { get => btc; set => btc = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"INSERT INTO pedido(idMesa, idCuenta, cancelado, fecha, listo, total, descuento, iva, propina, totalPago, saldo, nFactura, anular, efectivo, credito, btc) VALUES(" + idMesa + ", " + idCuenta + ", " + cancelado + ", '" + fecha + "', " + listo + ", " + total + ", " + descuento + ", " + iva + ", " + propina + ", " + totalPago + ", " + saldo + ", '" + nFactura + "', " + anular + ", " + efectivo + ", " + credito + ", " + btc + ");";

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

        public Boolean ActualizarFactura()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"UPDATE pedido SET anular = " + anular +
                " WHERE idPedido = " + idPedido + ";";

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

        public Boolean ActualizarCliente()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"UPDATE pedido SET idCliente = " + idCliente + 
                " WHERE idPedido = " + idPedido + ";";

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

        public Boolean ActualizarMesero()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"UPDATE pedido SET idMesero = " + idMesero +
                " WHERE idPedido = " + idPedido + ";";

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

        public Boolean ActualizarMesa()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"UPDATE pedido SET idMesa = " + idMesa + " " +
                "WHERE idPedido = " + idPedido + ";";

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

        public Boolean ActualizarTotal(double total)
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"UPDATE pedido SET total = " + total + " " +
                "WHERE idMesa = " + idMesa + " AND idPedido = " + idPedido + ";";

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
            sentencia = @"DELETE FROM pedido " +
                "WHERE idPedido = " + idPedido + ";";

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

        public Boolean ActualizarPedidoPagado()
        {
            Boolean resultado = false;
            string sentencia;
            if(nFactura != null)
            {
                sentencia = @"UPDATE pedido SET total = " + total + ", totalPago = " + totalPago + ", descuento = " + descuento + ", propina = " + propina + ", cancelado = " + cancelado + ", nFactura = '" + nFactura + "', saldo = " + saldo + " " +
                                "WHERE idPedido = " + idPedido + ";";
            }
            else
            {
                sentencia = @"UPDATE pedido SET total = " + total + ", totalPago = " + totalPago + ", descuento = " + descuento + ", propina = " + propina + ", cancelado = " + cancelado + ", saldo = " + saldo + " " +
                                "WHERE idPedido = " + idPedido + ";";
            }

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
    }
}
