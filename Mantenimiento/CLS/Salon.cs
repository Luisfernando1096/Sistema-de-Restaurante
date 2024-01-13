using System;

namespace Mantenimiento.CLS
{
    public class Salon
    {
        /*DECLARAR LAS VARIABLES*/
        int idSalon;
        string nombre;
        string fondo;
        int nMesas;

        /*DECLARACION DE PROPIEDADES*/
        public int IdSalon { get => idSalon; set => idSalon = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Fondo { get => fondo; set => fondo = value; }
        public int NMesas { get => nMesas; set => nMesas = value; }

        /*OPERACIONES BASICAS*/
        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = "INSERT INTO salon(nombre, fondo, nMesas) VALUES ('" + nombre + "', '" + fondo + "', " + nMesas + ")";
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
        public Boolean Actualizar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = "UPDATE salon SET nombre = '" + nombre + "', fondo = '" + fondo + "', nMesas = " + nMesas + " WHERE idSalon = " + idSalon + ";";

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
        public Boolean ActualizarNombre()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = "UPDATE salon SET nombre = '" + nombre + "' WHERE idSalon = " + idSalon + ";";

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

        public Boolean ActualizarNMesas()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = "UPDATE salon SET nMesas = " + nMesas + " WHERE idSalon = " + idSalon + ";";

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
            sentencia = "DELETE FROM salon WHERE idSalon = " + idSalon + ";";
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
