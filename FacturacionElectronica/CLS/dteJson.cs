using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionElectronica.CLS
{
    public class dteJson
    {
        public identificacion identificacion { get; set; }
        public documentoRelacionado documentoRelacionado { get; set; }
        public emisor emisor { get; set; }
        public receptor receptor { get; set; }
        public otrosDocumentos otrosDocumentos { get; set; }
        public ventaTercero ventaTercero { get; set; }
        public List<cuerpoDocumento> cuerpoDocumento { get; set; }
        public resumen resumen { get; set; }
        public extension extension { get; set; }
        public apendice apendice { get; set; }
    }
}
