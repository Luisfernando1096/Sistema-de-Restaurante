using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguracionManager.CLS
{
    public class Configuracion
    {
        //Atributos
        static Configuracion instancia = null;
        static readonly Object codelock = new object();
        string controlStock, incluirPropina, propina, incluirImpuesto, iva, mesaVIP, autorizarDescProp, printerComanda, printerFactura, printerInformes, alertaCaja, multisesion, numSesiones, muchosProductos;
        //Propiedades

        public static Configuracion Instancia//Esta es una propiedad y retorna el valor de un atributo
        {
            get
            {
                if (instancia == null)
                {
                    lock (codelock)
                    {
                        if (instancia == null)
                        {
                            instancia = new Configuracion();
                        }
                    }
                }
                return instancia;
            }
        }

        public string ControlStock { get => controlStock; set => controlStock = value; }
        public string IncluirPropina { get => incluirPropina; set => incluirPropina = value; }
        public string Propina { get => propina; set => propina = value; }
        public string IncluirImpuesto { get => incluirImpuesto; set => incluirImpuesto = value; }
        public string Iva { get => iva; set => iva = value; }
        public string MesaVIP { get => mesaVIP; set => mesaVIP = value; }
        public string AutorizarDescProp { get => autorizarDescProp; set => autorizarDescProp = value; }
        public string PrinterComanda { get => printerComanda; set => printerComanda = value; }
        public string PrinterFactura { get => printerFactura; set => printerFactura = value; }
        public string PrinterInformes { get => printerInformes; set => printerInformes = value; }
        public string AlertaCaja { get => alertaCaja; set => alertaCaja = value; }
        public string Multisesion { get => multisesion; set => multisesion = value; }
        public string NumSesiones { get => numSesiones; set => numSesiones = value; }
        public string MuchosProductos { get => muchosProductos; set => muchosProductos = value; }



        //Metodos
        private Configuracion()
        {

        }

        public Boolean  ObtenerConfiguracion()
        {
            Boolean result = false;

            try
            {
                DataTable datosConfiguracion = new DataTable();
                datosConfiguracion = DataManager.DBConsultas.Configuraciones();
                if (datosConfiguracion.Rows.Count == 1)
                {
                    controlStock = datosConfiguracion.Rows[0]["controlStock"].ToString();
                    incluirPropina = datosConfiguracion.Rows[0]["incluirPropina"].ToString();
                    propina = datosConfiguracion.Rows[0]["propina"].ToString();
                    incluirImpuesto = datosConfiguracion.Rows[0]["incluirImpuesto"].ToString();
                    iva = datosConfiguracion.Rows[0]["iva"].ToString();
                    mesaVIP = datosConfiguracion.Rows[0]["mesaVIP"].ToString();
                    autorizarDescProp = datosConfiguracion.Rows[0]["autorizarDescProp"].ToString();
                    printerComanda = datosConfiguracion.Rows[0]["printerComanda"].ToString();
                    printerFactura = datosConfiguracion.Rows[0]["printerFactura"].ToString();
                    printerInformes = datosConfiguracion.Rows[0]["printerInformes"].ToString();
                    alertaCaja = datosConfiguracion.Rows[0]["alertaCaja"].ToString();
                    multisesion = datosConfiguracion.Rows[0]["multisesion"].ToString();
                    numSesiones = datosConfiguracion.Rows[0]["numSesiones"].ToString();
                    muchosProductos = datosConfiguracion.Rows[0]["muchosProductos"].ToString();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return result;
        }

    }
}
