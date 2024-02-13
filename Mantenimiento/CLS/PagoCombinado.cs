using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class PagoCombinado
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
    }
}
