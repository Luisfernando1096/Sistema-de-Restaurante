using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    internal class Caja
    {
        int _idCaja;
        int _idCajero;
        int _Estado;
        String _FechaApertura;
        String _FechaCierre;
        double _SaldoInicial;
        double _Efectivo;
        double _Saldo;

        public int IdCaja { get => _idCaja; set => _idCaja = value; }
        public int IdCajero { get => _idCajero; set => _idCajero = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public string FechaApertura { get => _FechaApertura; set => _FechaApertura = value; }
        public string FechaCierre { get => _FechaCierre; set => _FechaCierre = value; }
        public double SaldoInicial { get => _SaldoInicial; set => _SaldoInicial = value; }
        public double Efectivo { get => _Efectivo; set => _Efectivo = value; }
        public double Saldo { get => _Saldo; set => _Saldo = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"insert into caja(idCajero,estado,fechaApertura,fechaCierre,saldoInicial,efectivo,saldo) values ("+_idCajero+","+_Estado+",'"+_FechaApertura+"','"+_FechaCierre+"',"+_SaldoInicial+","+_Efectivo+","+_Saldo+");";

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
            sentencia = @"update caja set idCajero = "+_idCajero+", estado = "+_Estado+", fechaApertura ='"+_FechaApertura+"', fechaCierre ='"+_FechaCierre+"', saldoInicial = "+_SaldoInicial+", efectivo = "+_Efectivo+", saldo = "+_Saldo+" where idCaja ="+_idCaja+";";

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
            sentencia = @"delete from caja where idCaja = "+_idCaja+";";

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
