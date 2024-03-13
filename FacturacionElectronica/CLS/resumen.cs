using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionElectronica.CLS
{
    public class resumen
    {
        public Double totalNoSuj { get; set; }
        public Double totalExenta { get; set; }
        public Double totalGravada { get; set; }
        public Double subTotalVentas { get; set; }
        public Double descuNoSuj { get; set; }
        public Double descuExenta { get; set; }
        public int descuGravada { get; set; }
        public int porcentajeDescuento { get; set; }
        public Double totalDescu { get; set; }
        public object tributos { get; set; }
        public Double subTotal { get; set; }
        public Double ivaRete1 { get; set; }
        public Double reteRenta { get; set; }
        public Double montoTotalOperacion { get; set; }
        public Double totalNoGravado { get; set; }
        public Double totalPagar { get; set; }
        public string totalLetras { get; set; }
        public Double totalIva { get; set; }
        public Double saldoFavor { get; set; }
        public int condicionOperacion { get; set; }
        public List<pagos> pagos { get; set; }
        public object numPagoElectronico { get; set; }
    }
}
