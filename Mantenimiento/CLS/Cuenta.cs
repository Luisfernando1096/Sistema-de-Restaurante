using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class Cuenta
    {
        int idCuenta;
        String nombreCuenta;
        String numero;
        double saldo;

        public int IdCuenta { get => idCuenta; set => idCuenta = value; }
        public string NombreCuenta { get => nombreCuenta; set => nombreCuenta = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public string Numero { get => numero; set => numero = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"insert into cuenta(nombreCuenta, numero, saldo) values ('" + nombreCuenta + "','" + numero + "', " + saldo + ");";

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
            sentencia = @"update cuenta set nombreCuenta = '" + nombreCuenta + "', numero = '" + numero + "', saldo = " + saldo + " where idCuenta = " + idCuenta + ";";

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
            sentencia = @"delete from cuenta where idCuenta =" + idCuenta + ";";

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
