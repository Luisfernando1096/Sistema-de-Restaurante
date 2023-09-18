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
    public partial class AnularFactura : Form
    {
        BindingSource datos = new BindingSource();
        public AnularFactura()
        {
            InitializeComponent();
        }

        private void btnCargarFactura_Click(object sender, EventArgs e)
        {
            FacturasCargar f = new FacturasCargar();
            f.ShowDialog();
            DataGridViewRow datos = f.datosEnviar;
            if (datos != null)
            {
                txtCliente.Text = datos.Cells["nombre"].Value.ToString();
                txtNumeroFactura.Text = datos.Cells["nFactura"].Value.ToString();
                txtNumeroPedido.Text = datos.Cells["idPedido"].Value.ToString();
                txtFecha.Text = datos.Cells["fecha"].Value.ToString();
                txtDescuento.Text = datos.Cells["descuento"].Value.ToString();
                txtPropina.Text = datos.Cells["propina"].Value.ToString();
                txtSumas.Text = datos.Cells["total"].Value.ToString();
                txtTotales.Text = datos.Cells["totalPago"].Value.ToString();
                txtIva.Text = datos.Cells["iva"].Value.ToString();

                LlenarDetalle();
                btnAnular.Enabled = true;
            }
            else
            {
                btnAnular.Enabled = false;
                Limpiar();
            }
        }

        private void LlenarDetalle()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.ObtenerDetallePedidoConIdParaAnular(txtNumeroPedido.Text);
                dgvDetalle.DataSource = datos;
                dgvDetalle.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Limpiar()
        {
            txtCliente.Text = "";
            txtNumeroFactura.Text = "";
            txtNumeroPedido.Text = "";
            txtFecha.Text = "";
            txtDescuento.Text = "";
            txtPropina.Text = "";
            txtSumas.Text = "";
            txtTotales.Text = "";
            txtIva.Text = "";
            dgvDetalle.DataSource = null;
            dgvDetalle.Rows.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void AnularFactura_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
