using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace TPV.GUI
{
    public partial class TicketsProcesados : Form
    {
        BindingSource datos = new BindingSource();
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;
        ConfiguracionManager.CLS.Ticket oTicket = ConfiguracionManager.CLS.Ticket.Instancia;
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
                    datos.DataSource = DataManager.DBConsultas.PedidoPorId(Int32.Parse(txtidPedido.Text), false);
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
            oReporte.SetParameterValue("Footer3", oTicket.Footer3);


            if (oReporte != null)
            {
                try
                {
                    // Imprimir el informe en la impresora seleccionada
                    PrinterSettings settings = new PrinterSettings
                    {
                        PrinterName = oConfiguracion.PrinterComanda
                    };

                    oReporte.PrintOptions.PrinterName = settings.PrinterName;
                    oReporte.PrintToPrinter(1, false, 0, 0);

                    // Muestra un mensaje de éxito en el hilo de la interfaz de usuario
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Finalizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones: muestra un mensaje de error en caso de problemas
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
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
