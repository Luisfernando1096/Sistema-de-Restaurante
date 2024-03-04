using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    public class Establecimiento
    {
        int idEstablecimiento, codigo;
        String descripcion;

        public int IdEstablecimiento { get => idEstablecimiento; set => idEstablecimiento = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
