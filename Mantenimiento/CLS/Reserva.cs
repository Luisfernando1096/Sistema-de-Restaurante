using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class Reserva
    {
        /*DECLARACION DE VARIABLES*/
        int idReserva;
        string DUI;
        string fecha;
        int numeroDeMesa; /*variable tinyblob*/
        int idMesa;

        /*DECLARACION DE PROPIEDADES*/
        public int IdReserva { get => idReserva; set => idReserva = value; }
        public string DUI1 { get => DUI; set => DUI = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int NumeroDeMesa { get => numeroDeMesa; set => numeroDeMesa = value; }
        public int IdMesa { get => idMesa; set => idMesa = value; }

        /*OPREACIONES BASICAS*/
        public Boolean Insertar() 
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = "INSERT INTO reserva(DUI, fecha, numerodemesa, idMesa) VALUES('" + DUI + "', '" + fecha + "', " + numeroDeMesa + ", " + idMesa + ");";
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
            sentencia = "UPDATE reserva SET DUI = '" + DUI + "', fecha = '" + fecha + "', numerodemesa = " + numeroDeMesa + ", idMesa = " + idMesa + " " +
                            "WHERE idReserva = " + idReserva + ";";
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
            sentencia = "DELETE FROM reserva WHERE idReserva = " + idReserva + ";";
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
