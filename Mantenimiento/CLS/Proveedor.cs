using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class Proveedor
    {
        /*DECLARACION DE VARIABLES IGUAL A LA BASE DE DATOS*/
        int idProveedor;
        String nombre;
        String direccion;
        String email;
        String telefono;
        String nit;
        String regContable;
        String contacto;

        /*DECLARACION DE PROPIEDADES*/
        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Nit { get => nit; set => nit = value; }
        public string RegContable { get => regContable; set => regContable = value; }
        public string Contacto { get => contacto; set => contacto = value; }

        /*OPREACIONES BASICAS*/
        public Boolean Insertar() 
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"INSERT INTO proveedor(nombre, direccion, email, telefono, NIT, regContable, contacto) VALUES('" + nombre + "', '" + direccion + "', '" + email + "', '" + telefono + "', '" + nit + "', '" + regContable + "', '" + contacto + "');";

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
            sentencia = @"UPDATE proveedor SET nombre = '" + nombre + "', direccion = '" + direccion + "', email = '" + email + "', telefono = '" + telefono + "', NIT = '" + nit + "', regContable = '" + regContable + "', contacto = '" + contacto + "'" +
                "WHERE idProveedor = " + idProveedor + ";";

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
            sentencia = @"DELETE FROM proveedor " +
                "WHERE idProveedor = " + idProveedor + ";";

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
