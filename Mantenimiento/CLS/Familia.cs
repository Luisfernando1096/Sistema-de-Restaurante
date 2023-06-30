using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class Familia
    {
        /*DECLARACION DE VARIABLES*/
        int idFamilia;
        bool activo;
        string familia1;
        string grupoPrinter;

        /*DECLARACION DE PROPIEDADES*/
        public int IdFamilia { get => idFamilia; set => idFamilia = value; }
        public bool Activo { get => activo; set => activo = value; }
        public string Familia1 { get => familia1; set => familia1 = value; }
        public string GrupoPrinter { get => grupoPrinter; set => grupoPrinter = value; }

        /*OPERACIONES BASICAS*/
        public Boolean Insertar()
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "INSERT INTO familia(activo, familia, grupoPrinter) VALUES(" + activo + ",'" + familia1 + "','" + grupoPrinter + "');";
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
            sentencia = "UPDATE familia SET activo = " + activo + ", familia = '" + familia1 + "', grupoPrinter = '" + grupoPrinter + "' WHERE idFamilia = " + idFamilia + ";";
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
            sentencia = "DELETE FROM familia WHERE idFamilia = " + idFamilia + ";";
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
