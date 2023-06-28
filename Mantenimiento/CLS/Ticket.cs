using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class Ticket
    {
        /*DECLARACION DE VARIABLES*/
        int idTicket;
        bool showEmpresa;
        bool showSlogan;
        bool showDireccion;
        bool showTelefono;
        bool showSaludo;
        bool showNRC;
        bool showNIT;
        bool numAutorizacion;
        bool extraLine;
        string header1;
        string header2;
        string header3;
        string footer1;
        string footer2;
        string footer3;
        string seCortePapel;
        int leftMargin;
        int nCaracteres;

        /*DECLARACION DE PROPIEADES*/
        public int IdTicket { get => idTicket; set => idTicket = value; }
        public bool ShowEmpresa { get => showEmpresa; set => showEmpresa = value; }
        public bool ShowSlogan { get => showSlogan; set => showSlogan = value; }
        public bool ShowDireccion { get => showDireccion; set => showDireccion = value; }
        public bool ShowTelefono { get => showTelefono; set => showTelefono = value; }
        public bool ShowSaludo { get => showSaludo; set => showSaludo = value; }
        public bool ShowNRC { get => showNRC; set => showNRC = value; }
        public bool ShowNIT { get => showNIT; set => showNIT = value; }
        public bool NumAutorizacion { get => numAutorizacion; set => numAutorizacion = value; }
        public bool ExtraLine { get => extraLine; set => extraLine = value; }
        public string Header1 { get => header1; set => header1 = value; }
        public string Header2 { get => header2; set => header2 = value; }
        public string Header3 { get => header3; set => header3 = value; }
        public string Footer1 { get => footer1; set => footer1 = value; }
        public string Footer2 { get => footer2; set => footer2 = value; }
        public string Footer3 { get => footer3; set => footer3 = value; }
        public string SeCortePapel { get => seCortePapel; set => seCortePapel = value; }
        public int LeftMargin { get => leftMargin; set => leftMargin = value; }
        public int NCaracteres { get => nCaracteres; set => nCaracteres = value; }

        /*OPERACIONES BASICAS*/
        public Boolean Insertar() 
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "INSERT INTO ticket(showEmpresa, showSlogan, showDireccion, showTelefono, showSaludo, showNRC, showNIT, numAutorizacion, extraLine, header1, header2, header3, footer1, footer2, footer3, seCortePapel, leftMargin, nCaracteres) VALUES(" + showEmpresa + ", " + showSlogan + ", " + showDireccion + ", " + showTelefono + ", " + showSaludo + ", " + showNRC + ", " + showNIT + ", " + numAutorizacion + ", " + extraLine + ", '" + header1 + "', '" + header2 + "', '" + header3 + "', '" + footer1 + "', '" + footer2 + "', '" + footer3 + "', '" + seCortePapel + "', " + leftMargin + ", " + nCaracteres + ");";
            try
            {
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
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "UPDATE ticket SET showEmpresa = " + showEmpresa + ", showSlogan = " + showSlogan + ", showDireccion = " + ShowDireccion + ", showTelefono = " + showTelefono + ", showSaludo = " + showSaludo + ", showNRC = " + showNRC + ", showNIT = " + showNIT + ", numAutorizacion = " + numAutorizacion + ", extraLine = " + extraLine + ", header1 = '" + header1 + "', header2 = '" + header2 + "', header3 = '" + header3 + "', footer1 = '" + footer1 + "', footer2 = '" + footer2 + "', footer3 = '" + footer3 + "', seCortePapel = '" + seCortePapel + "', leftMargin = " + leftMargin + ", nCaracteres = " + nCaracteres + " " +
                        "WHERE IdTicket = " + idTicket + ";";
            try
            {
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
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "DELETE FROM ticket WHERE idTicket = " + idTicket + ";";
            try
            {
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
