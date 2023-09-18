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
    public partial class FacturasCargar : Form
    {
        BindingSource datos = new BindingSource();
        public DataGridViewRow datosEnviar;
        public FacturasCargar()
        {
            InitializeComponent();
        }

        private void FacturasCargar_Load(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.TicketsFacturados(txtNumeroFactura.Text);
                dgvClientes.DataSource = datos;
                dgvClientes.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtNumeroFactura_TextChanged(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datosEnviar = dgvClientes.CurrentRow;
            Close();
        }
    }
}
