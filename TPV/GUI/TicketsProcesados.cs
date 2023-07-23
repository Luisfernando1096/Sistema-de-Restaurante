using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPV.GUI
{
    public partial class TicketsProcesados : Form
    {
        BindingSource datos = new BindingSource();
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
    }
}
