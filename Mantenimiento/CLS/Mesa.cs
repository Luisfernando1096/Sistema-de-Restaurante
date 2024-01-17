using System;

namespace Mantenimiento.CLS
{
    public class Mesa
    {
        int idMesa;
        int numero;
        String nombre;
        int capacidad;
        Boolean disponible;
        int idSalon;

        public int IdMesa { get => idMesa; set => idMesa = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public bool Disponible { get => disponible; set => disponible = value; }
        public int IdSalon { get => idSalon; set => idSalon = value; }

        public Boolean Insertar()
        {
            try
            {
                Boolean resultado = false;
                string sentencia;
                sentencia = "INSERT INTO mesa(numero, nombre, capacidad, disponible, idSalon) VALUES(" + numero + ", '" + nombre + "', " + capacidad + ", " + disponible + ", " + idSalon + ")";

                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasInsertadas = 0;
                filasInsertadas = op.EjecutarSentencia(sentencia);
                if (filasInsertadas > 0)
                {
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boolean Actualizar()
        {
            try
            {
                Boolean resultado = false;
                string sentencia;
                sentencia = @"UPDATE mesa SET numero = " + numero + ", nombre = '" + nombre + "', capacidad= " + capacidad + ", disponible = " + disponible + ", idSalon = " + idSalon + " " +
                    "WHERE idMesa = " + idMesa + ";";

                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasActualizadas = 0;
                filasActualizadas = op.EjecutarSentencia(sentencia);
                if (filasActualizadas > 0)
                {
                    resultado = true;
                }

                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boolean Eliminar()
        {
            try
            {
                Boolean resultado = false;
                string sentencia = @"DELETE FROM mesa WHERE idSalon = " + idSalon + ";";

                DataManager.DBOperacion op = new DataManager.DBOperacion();
                int filasEliminadas = op.EjecutarSentencia(sentencia);
                if (filasEliminadas > 0)
                {
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Boolean EliminarFila()
        {
            try
            {
                Boolean resultado = false;
                string sentencia;
                sentencia = @"DELETE FROM mesa " +
                    "WHERE idMesa = " + idMesa + ";";

                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasEliminadas = 0;
                filasEliminadas = op.EjecutarSentencia(sentencia);
                if (filasEliminadas > 0)
                {
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String ActualizarEstado()
        {

                string sentencia;
                
                    sentencia = @"UPDATE mesa SET disponible = " + disponible + " " +
                    "WHERE idMesa = " + idMesa + ";";
                
                return sentencia;

        }

        public String StringActualizarEstado()
        {
            string sentencia;
            sentencia = @"UPDATE mesa SET disponible = " + disponible + " " +
                "WHERE idMesa = " + idMesa + ";";

            return sentencia;
        }
    }
}
