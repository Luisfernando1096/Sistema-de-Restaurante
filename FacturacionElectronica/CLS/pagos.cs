using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionElectronica.CLS
{
    public class pagos
    {
        public string codigo { get; set; }
        public int montoPago { get; set; }
        public object plazo { get; set; }
        public string referencia { get; set; }
        public object periodo { get; set; }
    }
}
