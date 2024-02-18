using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    public class Municipio
    {
        String idMunicipio;
        String codigo;
        String nombre;
        Departamento departamento;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public String IdMunicipio { get => idMunicipio; set => idMunicipio = value; }
        public Departamento Departamento { get => departamento; set => departamento = value; }
    }
}
