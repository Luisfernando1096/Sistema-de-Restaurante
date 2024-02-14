using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    public class PagoCombinado
    {
        int idPagoCombinado;
        Double monto;
        String fechaPago;
        int idPedido;
        int idCuenta;

        public int IdPagoCombinado { get => idPagoCombinado; set => idPagoCombinado = value; }
        public double Monto { get => monto; set => monto = value; }
        public string FechaPago { get => fechaPago; set => fechaPago = value; }
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int IdCuenta { get => idCuenta; set => idCuenta = value; }

        public Boolean Insertar()
        {
            try
            {
                Boolean resultado = false;
                string sentencia;
                sentencia = "INSERT INTO pago_combinado(monto, fechaPago, idPedido, idCuenta) VALUES(" + monto + ", '" + fechaPago + "', " + idPedido + ", " + idCuenta + ")";

                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasInsertadas = 0;
                filasInsertadas = op.EjecutarSentencia(sentencia);
                if (filasInsertadas > 0)
                {
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
