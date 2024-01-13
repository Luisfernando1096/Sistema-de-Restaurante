using System;
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
                dgvPedidos.DataSource = datos;
                dgvPedidos.AutoGenerateColumns = false;
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
            datosEnviar = dgvPedidos.CurrentRow;
            Close();
        }
    }
}
