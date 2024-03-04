using System;
using System.Data;

namespace ConfiguracionManager.CLS
{
    public class Empresa
    {

        //Atributos
        static Empresa instancia = null;
        static readonly Object codelock = new object();
        string nombreEmpresa, slogan, direccion, telefono, logo, firma, sello, saludo, nrc, nit, desActividad, establecimiento, correo, complemento;
        int idEstablecimiento, idActividad, idDireccion, codEstablecimiento, codActividad, codDepartamento, codMunicipio;

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
        public int IdEstablecimiento { get => idEstablecimiento; set => idEstablecimiento = value; }
        public int IdActividad { get => idActividad; set => idActividad = value; }
        public string DesActividad { get => desActividad; set => desActividad = value; }
        public string Establecimiento { get => establecimiento; set => establecimiento = value; }
        public int IdDireccion { get => idDireccion; set => idDireccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public int CodEstablecimiento { get => codEstablecimiento; set => codEstablecimiento = value; }
        public int CodActividad { get => codActividad; set => codActividad = value; }
        public int CodDepartamento { get => codDepartamento; set => codDepartamento = value; }
        public String Complemento { get => complemento; set => complemento = value; }
        public int CodMunicipio { get => codMunicipio; set => codMunicipio = value; }




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
                datosEmpresa = DataManager.DBConsultas.Empresa(2);
                if (datosEmpresa.Rows.Count == 1)
                {

                    NombreEmpresa = datosEmpresa.Rows[0]["nombreEmpresa"].ToString();
                    Slogan = datosEmpresa.Rows[0]["slogan"].ToString();
                    direccion = datosEmpresa.Rows[0]["direccion"].ToString();
                    telefono = datosEmpresa.Rows[0]["telefono"].ToString();
                    logo = datosEmpresa.Rows[0]["logo"].ToString();
                    firma = datosEmpresa.Rows[0]["firma"].ToString();
                    sello = datosEmpresa.Rows[0]["sello"].ToString();
                    saludo = datosEmpresa.Rows[0]["saludo"].ToString();
                    nrc = datosEmpresa.Rows[0]["NRC"].ToString();
                    nit = datosEmpresa.Rows[0]["NIT"].ToString();
                    desActividad = datosEmpresa.Rows[0]["descripcion"].ToString();
                    establecimiento = datosEmpresa.Rows[0]["establecimiento"].ToString();
                    idActividad = Int32.Parse(datosEmpresa.Rows[0]["idActividad"].ToString());
                    idEstablecimiento = Int32.Parse(datosEmpresa.Rows[0]["idEstablecimiento"].ToString());
                    idDireccion = Int32.Parse(datosEmpresa.Rows[0]["idDireccion"].ToString());
                    Correo = datosEmpresa.Rows[0]["correo"].ToString();
                    codEstablecimiento = Int32.Parse(datosEmpresa.Rows[0]["codEstablecimiento"].ToString()); ;
                    codActividad = Int32.Parse(datosEmpresa.Rows[0]["codActividad"].ToString()); ;
                    codDepartamento = Int32.Parse(datosEmpresa.Rows[0]["codDepartamento"].ToString()); ;
                    complemento = datosEmpresa.Rows[0]["complemento"].ToString(); ;
                    codMunicipio = Int32.Parse(datosEmpresa.Rows[0]["codMunicipio"].ToString()); ;

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
