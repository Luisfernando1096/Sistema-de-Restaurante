using System;

namespace Mantenimiento.CLS
{
    public class Configuracion
    {
        int idConfiguracion;
        int controlStock;
        int incluirPropina;
        double propina;
        int incluirImpuesto;
        double iva;
        double mesaVIP;
        int autorizarDescProp;
        String printerComanda;
        String printerFactura;
        String printerInformes;
        int alertaCaja;
        int multisesion;
        int numSesiones;
        int muchosProductos;
        int imprimirDosTicketsPago;
        String impresoraAppMovil;
        int facturaElectronica;
        String impresoraCocina;
        String impresoraBar;
        String impresoraGrupoUno;
        String impresoraGrupoDos;

        public int IdConfiguracion { get => idConfiguracion; set => idConfiguracion = value; }
        public int ControlStock { get => controlStock; set => controlStock = value; }
        public int IncluirPropina { get => incluirPropina; set => incluirPropina = value; }
        public double Propina { get => propina; set => propina = value; }
        public int IncluirImpuesto { get => incluirImpuesto; set => incluirImpuesto = value; }
        public double Iva { get => iva; set => iva = value; }
        public double MesaVIP { get => mesaVIP; set => mesaVIP = value; }
        public int AutorizarDescProp { get => autorizarDescProp; set => autorizarDescProp = value; }
        public string PrinterComanda { get => printerComanda; set => printerComanda = value; }
        public string PrinterFactura { get => printerFactura; set => printerFactura = value; }
        public int AlertaCaja { get => alertaCaja; set => alertaCaja = value; }
        public int Multisesion { get => multisesion; set => multisesion = value; }
        public int NumSesiones { get => numSesiones; set => numSesiones = value; }
        public string PrinterInformes { get => printerInformes; set => printerInformes = value; }
        public int MuchosProductos { get => muchosProductos; set => muchosProductos = value; }
        public int ImprimirDosTicketsPago { get => imprimirDosTicketsPago; set => imprimirDosTicketsPago = value; }
        public string ImpresoraAppMovil { get => impresoraAppMovil; set => impresoraAppMovil = value; }
        public int FacturaElectronica { get => facturaElectronica; set => facturaElectronica = value; }
        public string ImpresoraCocina { get => impresoraCocina; set => impresoraCocina = value; }
        public string ImpresoraBar { get => impresoraBar; set => impresoraBar = value; }
        public string ImpresoraGrupoUno { get => impresoraGrupoUno; set => impresoraGrupoUno = value; }
        public string ImpresoraGrupoDos { get => impresoraGrupoDos; set => impresoraGrupoDos = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"INSERT INTO configuracion(idConfiguracion, controlStock, incluirPropina, propina, incluirImpuesto, iva, mesaVIP, autorizarDescProp, printerComanda, printerFactura, printerInformes, alertaCaja, multisesion, numSesiones, imprimirDosTicketsPago, impresoraAppMovil, facturaElectronica, impresoraCocina, impresoraBar, impresoraGrupoUno, impresoraGrupoDos, muchosProductos) VALUES(" + idConfiguracion + ", " + controlStock + ", " + incluirPropina + ", " + propina + ", " + incluirImpuesto + ", " + iva + ", " + mesaVIP + ", " + autorizarDescProp + ", '" + printerComanda + "', '" + printerFactura + "', '" + PrinterInformes + "', " + alertaCaja + ", " + multisesion + ", " + numSesiones + ", " + imprimirDosTicketsPago + ", '" + impresoraAppMovil + "', " + facturaElectronica + ", '" + impresoraCocina + "', '" + impresoraBar + "', '" + impresoraGrupoUno + "', '" + impresoraGrupoDos + "', " + muchosProductos + ");";

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
            sentencia = @"UPDATE configuracion SET controlStock = " + controlStock + ", incluirPropina = " + incluirPropina + ", propina = " + propina + ", incluirImpuesto = " + incluirImpuesto + ", iva = " + iva + ", mesaVIP = " + mesaVIP + ", autorizarDescProp = " + autorizarDescProp + ", printerComanda = '" + printerComanda + "', printerFactura = '" + printerFactura + "', printerInformes = '" + printerInformes + "', alertaCaja = " + alertaCaja + ", multisesion = " + multisesion + ", numSesiones = " + numSesiones + ", muchosProductos = " + muchosProductos + ", imprimirDosTicketsPago = " + imprimirDosTicketsPago + ", impresoraAppMovil = '" + impresoraAppMovil + "', facturaElectronica = " + facturaElectronica + ", impresoraCocina = '" + impresoraCocina + "', impresoraBar = '" + impresoraBar + "', impresoraGrupoUno = '" + impresoraGrupoUno + "', impresoraGrupoDos = '" + impresoraGrupoDos + "' WHERE idConfiguracion = " + idConfiguracion + ";";

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
            sentencia = @"DELETE FROM configuracion " +
                "WHERE idConfiguracion = " + idConfiguracion + ";";

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
