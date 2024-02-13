using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionElectronica.CLS
{
    public class emisor
    {
        public string nit { get; set; }
        public string nrc { get; set; }
        public string nombre { get; set; }
        public string codActividad { get; set; }
        public string descActividad { get; set; }
        public object nombreComercial { get; set; }
        public string tipoEstablecimiento { get; set; }
        public direccion direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public object codEstableMH { get; set; }
        public object codEstable { get; set; }
        public object codPuntoVentaMH { get; set; }
        public object codPuntoVenta { get; set; }
    }
}
