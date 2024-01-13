using System;

namespace Mantenimiento.CLS
{
    public class Empleado
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

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"insert into empleado(nombres,apellidos,direccion,email,telefono,DUI,NIT,sueldoBase,comision,regContable) values('" + nombres + "','" + apellidos + "','" + direccion + "','" + email + "','" + telefono + "','" + dui + "','" + nit + "'," + sueldoBase + "," + comision + ",'" + regContable + "');";

            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasInsertadas = 0;
                filasInsertadas = op.EjecutarSentencia(sentencia);
                if (filasInsertadas > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }

        public Boolean Actualizar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"update empleado set nombres = '" + nombres + "', apellidos = '" + apellidos + "', direccion = '" + direccion + "', email = '" + email + "', telefono = '" + telefono + "', DUI = '" + dui + "', NIT = '" + nit + "', SueldoBase = " + sueldoBase + ", Comision = " + comision + " Where idEmpleado = " + idEmpleado + ";";

            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasActualizadas = 0;
                filasActualizadas = op.EjecutarSentencia(sentencia);
                if (filasActualizadas > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }

        public Boolean Eliminar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"delete from empleado where idEmpleado = " + idEmpleado + ";";

            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasEliminadas = 0;
                filasEliminadas = op.EjecutarSentencia(sentencia);
                if (filasEliminadas > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }
    }
}
