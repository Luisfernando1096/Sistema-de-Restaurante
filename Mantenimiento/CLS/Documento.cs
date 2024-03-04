using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    public class Documento
    {
        int idDocumento;
        String tipoDocumento;
        int valorEnNumero;

        public int IdDocumento { get => idDocumento; set => idDocumento = value; }
        public string TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public int ValorEnNumero { get => valorEnNumero; set => valorEnNumero = value; }
    }
}
