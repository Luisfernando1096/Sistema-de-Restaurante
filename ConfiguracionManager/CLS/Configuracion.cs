using System;
using System.Data;
using System.IO;
using System.Xml;

namespace ConfiguracionManager.CLS
{
    public class Configuracion
    {
        //Atributos
        static Configuracion instancia = null;
        static readonly Object codelock = new object();
        string controlStock, incluirPropina, propina, incluirImpuesto, 
            iva, mesaVIP, autorizarDescProp, printerComanda, printerFactura,
            printerInformes, alertaCaja, multisesion, numSesiones, muchosProductos,
            imprimirDosTicketsPago, impresoraAppMovil, facturaElectronica, impresoraCocina,
            impresoraBar, impresoraGrupoUno, impresoraGrupoDos;
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
        public string ImprimirDosTicketsPago { get => imprimirDosTicketsPago; set => imprimirDosTicketsPago = value; }
        public string ImpresoraAppMovil { get => impresoraAppMovil; set => impresoraAppMovil = value; }
        public string FacturaElectronica { get => facturaElectronica; set => facturaElectronica = value; }
        public string ImpresoraCocina { get => impresoraCocina; set => impresoraCocina = value; }
        public string ImpresoraBar { get => impresoraBar; set => impresoraBar = value; }
        public string ImpresoraGrupoUno { get => impresoraGrupoUno; set => impresoraGrupoUno = value; }
        public string ImpresoraGrupoDos { get => impresoraGrupoDos; set => impresoraGrupoDos = value; }



        //Metodos
        private Configuracion()
        {

        }

        public Boolean ObtenerConfiguracion()
        {
            Boolean result = false;

            try
            {
                DataTable datosConfiguracion = new DataTable();

                //Acceder al archivo de configuracion para obtener que pc es
                int idConf = 1;

                string archivoConfiguracion = "configuracion.xml";

                if (File.Exists(archivoConfiguracion))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(archivoConfiguracion);

                    
                    if (xmlDoc.SelectSingleNode("/Configuracion/Pc") != null)
                    {
                        string pc = xmlDoc.SelectSingleNode("/Configuracion/Pc").InnerText;
                        if (pc.Equals("Principal"))
                        {
                            idConf = 1;
                        }else if (pc.Equals("Cliente 1"))
                        {
                            idConf = 2;
                        }
                        else if (pc.Equals("Cliente 2"))
                        {
                            idConf = 3;
                        }
                        
                    }

                }

                datosConfiguracion = DataManager.DBConsultas.Configuraciones(idConf);
                if (datosConfiguracion.Rows.Count > 0)
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
                    imprimirDosTicketsPago = datosConfiguracion.Rows[0]["imprimirDosTicketsPago"].ToString();
                    impresoraAppMovil = datosConfiguracion.Rows[0]["impresoraAppMovil"].ToString();
                    facturaElectronica = datosConfiguracion.Rows[0]["facturaElectronica"].ToString();
                    impresoraBar = datosConfiguracion.Rows[0]["impresoraBar"].ToString();
                    impresoraCocina = datosConfiguracion.Rows[0]["impresoraCocina"].ToString();
                    impresoraGrupoUno = datosConfiguracion.Rows[0]["impresoraGrupoUno"].ToString();
                    ImpresoraGrupoDos = datosConfiguracion.Rows[0]["ImpresoraGrupoDos"].ToString();
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
