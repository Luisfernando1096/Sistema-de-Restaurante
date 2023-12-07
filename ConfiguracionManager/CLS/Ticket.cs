using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguracionManager.CLS
{
    public class Ticket
    {
        //Atributos
        static Ticket instancia = null;
        static readonly Object codelock = new object();
        string showEmpresa, showSlogan, showDireccion, showTelefono, showSaludo, showNRC, showNIT, numAutorizacion, extraLine, header1, header2, header3, footer1, footer2, footer3, seCortePapel, leftMargin, nCaracteres;

        //Propiedades
        public static Ticket Instancia//Esta es una propiedad y retorna el valor de un atributo
        {
            get
            {
                if (instancia == null)
                {
                    lock (codelock)
                    {
                        if (instancia == null)
                        {
                            instancia = new Ticket();
                        }
                    }
                }
                return instancia;
            }
        }

        public string ShowEmpresa { get => showEmpresa; set => showEmpresa = value; }
        public string ShowSlogan { get => showSlogan; set => showSlogan = value; }
        public string ShowDireccion { get => showDireccion; set => showDireccion = value; }
        public string ShowTelefono { get => showTelefono; set => showTelefono = value; }
        public string ShowSaludo { get => showSaludo; set => showSaludo = value; }
        public string ShowNRC { get => showNRC; set => showNRC = value; }
        public string ShowNIT { get => showNIT; set => showNIT = value; }
        public string NumAutorizacion { get => numAutorizacion; set => numAutorizacion = value; }
        public string ExtraLine { get => extraLine; set => extraLine = value; }
        public string Header1 { get => header1; set => header1 = value; }
        public string Header2 { get => header2; set => header2 = value; }
        public string Header3 { get => header3; set => header3 = value; }
        public string Footer1 { get => footer1; set => footer1 = value; }
        public string Footer2 { get => footer2; set => footer2 = value; }
        public string Footer3 { get => footer3; set => footer3 = value; }
        public string SeCortePapel { get => seCortePapel; set => seCortePapel = value; }
        public string LeftMargin { get => leftMargin; set => leftMargin = value; }
        public string NCaracteres { get => nCaracteres; set => nCaracteres = value; }

        //Metodos
        private Ticket()
        {

        }

        public Boolean ObtenerConfiguracion()
        {
            Boolean result = false;
            try
            {
                DataTable OpticketTable = new DataTable();
                OpticketTable = DataManager.DBConsultas.Ticket(1);

                if (OpticketTable.Rows.Count > 0)
                {
                    showEmpresa = OpticketTable.Rows[0]["showEmpresa"].ToString();
                    showSlogan = OpticketTable.Rows[0]["showSlogan"].ToString();
                    showSaludo = OpticketTable.Rows[0]["showSaludo"].ToString();
                    showDireccion = OpticketTable.Rows[0]["showDireccion"].ToString();
                    showTelefono = OpticketTable.Rows[0]["showTelefono"].ToString();
                    //chkMostrarSaludo.Checked = Convert.ToBoolean(configuracionRow["alertaCaja"]);
                    showNIT = OpticketTable.Rows[0]["showNIT"].ToString();
                    showNRC = OpticketTable.Rows[0]["showNRC"].ToString();
                    numAutorizacion = OpticketTable.Rows[0]["numAutorizacion"].ToString();
                    extraLine = OpticketTable.Rows[0]["extraLine"].ToString();

                    header1 = OpticketTable.Rows[0]["header1"].ToString();
                    header2 = OpticketTable.Rows[0]["header2"].ToString();
                    header3 = OpticketTable.Rows[0]["header3"].ToString();

                    footer1 = OpticketTable.Rows[0]["footer1"].ToString();
                    footer2 = OpticketTable.Rows[0]["footer2"].ToString(); 
                    footer3 = OpticketTable.Rows[0]["footer3"].ToString();

                    seCortePapel = OpticketTable.Rows[0]["seCortePapel"].ToString();
                    leftMargin = OpticketTable.Rows[0]["leftMargin"].ToString();
                    nCaracteres = OpticketTable.Rows[0]["nCaracteres"].ToString();
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
