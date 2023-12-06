using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPV.GUI
{
    public partial class TicketsProcesados : Form
    {
        BindingSource datos = new BindingSource();
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;
        public TicketsProcesados()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            if (!txtidPedido.Text.Equals(""))
            {
                try
                {
                    datos.DataSource = DataManager.DBConsultas.PedidoPorId(Int32.Parse(txtidPedido.Text));
                    dgvClientes.DataSource = datos;
                    dgvClientes.AutoGenerateColumns = false;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TicketsProcesados_Load(object sender, EventArgs e)
        {

        }

        private void txtidPedido_TextChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //Imprimir ticket
            Reportes.REP.RepTicket oReporte = new Reportes.REP.RepTicket();
            GenerarTicket(oReporte);
        }

        private void GenerarTicket(ReportClass oReporte)
        {
            DataTable datos = DataManager.DBConsultas.ImprimirTicket(Int32.Parse(txtidPedido.Text));
            oReporte.SetDataSource(datos);
            oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
            oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
            oReporte.SetParameterValue("Telefono", oEmpresa.Telefono);
            oReporte.SetParameterValue("Footer3", "Gracias por tu visita");


            if (oReporte != null)
            {
                // Configurar la ruta de destino en la impresora virtual XPS
                PrinterSettings settings = new PrinterSettings
                {
                    PrinterName = oConfiguracion.PrinterComanda // Nombre de la impresora virtual XPS
                };

                // Imprimir el informe en la impresora virtual XPS
                oReporte.PrintOptions.PrinterName = settings.PrinterName;
                oReporte.PrintToPrinter(1, false, 0, 0);

                MessageBox.Show($"Finalizado con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void txtidPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
