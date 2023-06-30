using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class Empresa
    {
        /*DECLARACION DE VARIABLES*/
        int idEmpresa;
        string nombreEmpresa;
        string slogan;
        string direccion;
        string telefono;
        string logo;
        string firma;
        string sello;
        string saludo;
        string NRC;
        string NIT;
        string numAutorizacion;

        /*DECLARACION DE PROPIEDADES*/
        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }
        public string NombreEmpresa { get => nombreEmpresa; set => nombreEmpresa = value; }
        public string Slogan { get => slogan; set => slogan = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Logo { get => logo; set => logo = value; }
        public string Firma { get => firma; set => firma = value; }
        public string Sello { get => sello; set => sello = value; }
        public string Saludo { get => saludo; set => saludo = value; }
        public string NRC1 { get => NRC; set => NRC = value; }
        public string NIT1 { get => NIT; set => NIT = value; }
        public string NumAutorizacion { get => numAutorizacion; set => numAutorizacion = value; }

        /*OPERACIONES BASICAS*/
        public Boolean Insertar()
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "INSERT INTO empresa(nombreEmpresa, slogan, direccion, telefono, logo, firma, sello, saludo, NRC, NIT, numAutorizacion) VALUES('" + nombreEmpresa + "','" + slogan + "','" + direccion + "','" + telefono + "','" + logo + "','" + firma + "','" + sello + "','" + saludo + "','" + NRC + "','" + NIT + "','" + numAutorizacion + "');";
            try
            {
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
        public Boolean Actualizar()
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "UPDATE empresa SET  nombreEmpresa = '" + nombreEmpresa + "', slogan = '" + slogan + "', direccion = '" + direccion + "', telefono = '" + telefono + "', logo = '" + logo + "', firma = '" + firma + "', sello = '" + sello + "', saludo = '" + saludo + "', NRC = '" + NRC + "' , NIT  = '" + NIT + "', numAutorizacion = '" + numAutorizacion + "' " +
                          "WHERE idEmpresa = " + idEmpresa + ";";
            try
            {
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
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "DELETE FROM empresa WHERE idEmpresa = " + idEmpresa + ";";
            try
            {
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
