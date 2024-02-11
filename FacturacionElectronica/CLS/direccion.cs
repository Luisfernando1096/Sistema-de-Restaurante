using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionElectronica.CLS
{
    public class direccion
    {
        [StringLength(2, MinimumLength = 2, ErrorMessage = "El departamento debe tener 2 caracteres.")]
        public string departamento { get; set; }
        public string municipio { get; set; }
        public string complemento { get; set; }
    }
}
