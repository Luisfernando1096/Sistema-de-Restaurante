using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionElectronica.CLS
{
    public class cuerpoDocumento
    {
        public int numItem { get; set; }
        public int tipoItem { get; set; }
        public object numeroDocumento { get; set; }
        public object codigo { get; set; }
        public object codTributo { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public int uniMedida { get; set; }
        public Double precioUni { get; set; }
        public Double montoDescu { get; set; }
        public int ventaNoSuj { get; set; }
        public int ventaExenta { get; set; }
        public Double ventaGravada { get; set; }
        public object tributos { get; set; }
        public double psv { get; set; }
        public int noGravado { get; set; }
        public Double ivaItem { get; set; }
    }
}
