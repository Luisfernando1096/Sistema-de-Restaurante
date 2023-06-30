using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class Empleado
    {
        int idEmpleado;
        String nombres;
        String apellidos;
        String direccion;
        String email;
        String telefono;
        String dui;
        String nit;
        double sueldoBase;
        double comision;
        String regContable;

        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Nit { get => nit; set => nit = value; }
        public double SueldoBase { get => sueldoBase; set => sueldoBase = value; }
        public double Comision { get => comision; set => comision = value; }
        public string RegContable { get => regContable; set => regContable = value; }
    }
}
