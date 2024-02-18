using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    public class Departamento
    {
        String idDepartamento;
        String codigo;
        String nombre;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public String IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
    }
}
