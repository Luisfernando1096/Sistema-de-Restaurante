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
        string nombre;
        string direccion;
        string email;
        string telefono;
        string NIT;
        string regContable;
        string contacto;

        /*DECLARACION DE PROPIEDADES*/
        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string NIT1 { get => NIT; set => NIT = value; }
        public string RegContable { get => regContable; set => regContable = value; }
        public string Contacto { get => contacto; set => contacto = value; }

        /*OPREACIONES BASICAS*/
        public Boolean Insertar() 
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"INSERT INTO proveedor(nombre, direccion, email, telefono, NIT, regContable, contacto) VALUES('" + nombre + "', '" + direccion + "', '" + email + "', '" + telefono + "', '" + NIT + "', '" + regContable + "', '" + contacto + "');";
            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                int filasAfectadas = 0;
                filasAfectadas = op.EjecutarSentencia(sentencia);

                if (filasAfectadas > 0 )
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
            sentencia = @"UPDATE proveedor SET nombre = '" + nombre + "', direccion = '" + direccion + "', email = '" + email + "', telefono = '" + telefono + "', NIT = '" + NIT + "', regContable = '" + regContable + "', contacto = '" + contacto + "' " +
                "WHERE idProveedor = " + idProveedor + ";";
            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                int filasAfectadas = 0;
                filasAfectadas = op.EjecutarSentencia(sentencia);
                if (filasAfectadas > 0)
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
            sentencia = "DELETE FROM proveedor WHERE idProveedor = " + idProveedor + ";";
            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                int filasAfectadas = 0;
                filasAfectadas = op.EjecutarSentencia(sentencia);
                if (filasAfectadas > 0)
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
