using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.GUI
{
    public partial class VisorComandaCompleta : Form
    {
        public VisorComandaCompleta()
        {
            InitializeComponent();
        }

        private void CargarReporte()
        {
            DataTable datos = new DataTable();
            REP.RepVentasDiarias oReporte = new REP.RepVentasDiarias();
            datos = DataManager.DBConsultas.RepVentasDiarias("");
            oReporte.SetDataSource(datos);
            oReporte.SetParameterValue("Empresa", "ALTEZZA");
            oReporte.SetParameterValue("Footer", "Hasta la cima del sabor");
            oReporte.SetParameterValue("Fecha", DateTime.Now.ToString());
            crvVisor.ReportSource = oReporte;
        }

        private void VisorComandaCompleta_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
