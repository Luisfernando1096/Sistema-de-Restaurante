﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionElectronica.CLS
{
    public class resumen
    {
        public int totalNoSuj { get; set; }
        public int totalExenta { get; set; }
        public Double totalGravada { get; set; }
        public Double subTotalVentas { get; set; }
        public int descuNoSuj { get; set; }
        public int descuExenta { get; set; }
        public int descuGravada { get; set; }
        public int porcentajeDescuento { get; set; }
        public int totalDescu { get; set; }
        public object tributos { get; set; }
        public Double subTotal { get; set; }
        public int ivaRete1 { get; set; }
        public int reteRenta { get; set; }
        public Double montoTotalOperacion { get; set; }
        public int totalNoGravado { get; set; }
        public Double totalPagar { get; set; }
        public string totalLetras { get; set; }
        public int totalIva { get; set; }
        public int saldoFavor { get; set; }
        public int condicionOperacion { get; set; }
        public List<pagos> pagos { get; set; }
        public object numPagoElectronico { get; set; }
    }
}
