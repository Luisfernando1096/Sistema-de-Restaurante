using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
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
            int idPedido = 0;
            if (!txtidPedido.Text.Equals(""))
            {
                idPedido = Int32.Parse(txtidPedido.Text);
            }

            try
            {
                datos.DataSource = DataManager.DBConsultas.PedidoPorIdConDetallePagos(idPedido, false);
                dgvClientes.DataSource = datos;
                dgvClientes.AutoGenerateColumns = false;
                
            }
            catch (Exception)
            {
                throw;
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
            CargarDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.Rows.Count > 0)
            {
                EditarTicket f = new EditarTicket();
                f.lblTicket.Text = dgvClientes.CurrentRow.Cells["idPedido"].Value.ToString(); ;
                f.lblTicket.Tag = dgvClientes.CurrentRow.Cells["idPagoCombinado"].Value.ToString();

                if (dgvClientes.CurrentRow.Cells["idCuenta"].Value.ToString().Equals("1"))
                {
                    f.rbEfectivo.Checked = true;
                } else if (dgvClientes.CurrentRow.Cells["idCuenta"].Value.ToString().Equals("2"))
                {
                    f.rbTarjeta.Checked = true;
                }
                else
                {
                    f.rbBtc.Checked = true;
                }

                f.ShowDialog();

                CargarDatos();
            }
            else
            {
                MessageBox.Show("No hay datos para editar");
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtidPedido.Enabled = true;
            txtidPedido.Text = "";
        }

    }
}
