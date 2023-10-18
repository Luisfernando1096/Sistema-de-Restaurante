using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguracionManager.CLS
{
    public class Empresa
    {

        //Atributos
        static Empresa instancia = null;
        static readonly Object codelock = new object();
        string nombreEmpresa, slogan, direccion, telefono, logo, firma, sello, saludo, nrc, nit, numAutorizacion;
        //Propiedades

        public static Empresa Instancia//Esta es una propiedad y retorna el valor de un atributo
        {
            get
            {
                if (instancia == null)
                {
                    lock (codelock)
                    {
                        if (instancia == null)
                        {
                            instancia = new Empresa();
                        }
                    }
                }
                return instancia;
            }
        }

        public string NombreEmpresa { get => nombreEmpresa; set => nombreEmpresa = value; }
        public string Slogan { get => slogan; set => slogan = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Logo { get => logo; set => logo = value; }
        public string Firma { get => firma; set => firma = value; }
        public string Sello { get => sello; set => sello = value; }
        public string Saludo { get => saludo; set => saludo = value; }
        public string Nrc { get => nrc; set => nrc = value; }
        public string Nit { get => nit; set => nit = value; }
        public string NumAutorizacion { get => numAutorizacion; set => numAutorizacion = value; }




        //Metodos
        private Empresa()
        {

        }

        public Boolean ObtenerConfiguracion()
        {
            Boolean result = false;

            try
            {
                DataTable datosEmpresa = new DataTable();
                datosEmpresa = DataManager.DBConsultas.Empresa(1);
                if (datosEmpresa.Rows.Count == 1)
                {

                    nombreEmpresa = datosEmpresa.Rows[0]["nombreEmpresa"].ToString();
                    slogan = datosEmpresa.Rows[0]["slogan"].ToString();
                    direccion = datosEmpresa.Rows[0]["direccion"].ToString();
                    telefono = datosEmpresa.Rows[0]["telefono"].ToString();
                    logo = datosEmpresa.Rows[0]["logo"].ToString();
                    firma = datosEmpresa.Rows[0]["firma"].ToString();
                    sello = datosEmpresa.Rows[0]["sello"].ToString();
                    saludo = datosEmpresa.Rows[0]["saludo"].ToString();
                    nrc = datosEmpresa.Rows[0]["NRC"].ToString();
                    nit = datosEmpresa.Rows[0]["NIT"].ToString();
                    numAutorizacion = datosEmpresa.Rows[0]["numAutorizacion"].ToString();
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
