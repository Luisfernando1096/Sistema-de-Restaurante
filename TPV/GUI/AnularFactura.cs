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
            btnAnular.Enabled = false;
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

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Mantenimiento.CLS.Pedido pedido = new Mantenimiento.CLS.Pedido();
            pedido.IdPedido = Int32.Parse(txtNumeroPedido.Text);
            pedido.Anular = true;
            DataTable datosCaja = DataManager.DBConsultas.CajaAbierta();
            Mantenimiento.CLS.Caja caja = new Mantenimiento.CLS.Caja();
            if (datosCaja.Rows.Count == 1)
            {
                double efectivo = 0;
                double saldo = 0;
                foreach (DataRow item in datosCaja.Rows)
                {
                    caja.IdCaja = Int32.Parse(item["idCaja"].ToString());
                    caja.IdCajero = Int32.Parse(item["idCajero"].ToString());
                    caja.Estado = true;

                    // La cadena de fecha y hora en formato original
                    string fechaHoraString = item["fechaApertura"].ToString();

                    // Define el formato original de la cadena de fecha y hora
                    string formatoOriginal = "d/M/yyyy HH:mm:ss";

                    // Convierte la cadena en un objeto DateTime
                    DateTime fechaHora = DateTime.ParseExact(fechaHoraString, formatoOriginal, System.Globalization.CultureInfo.InvariantCulture);

                    // Define el formato deseado
                    string formatoDeseado = "yyyy-MM-dd HH:mm:ss";

                    caja.FechaApertura = fechaHora.ToString(formatoDeseado); ;
                    caja.SaldoInicial = Double.Parse(item["saldoInicial"].ToString());
                    saldo = Double.Parse(item["saldo"].ToString());
                    efectivo = Double.Parse(item["efectivo"].ToString());
                }
                if (efectivo >= Double.Parse(txtTotales.Text) && saldo >= Double.Parse(txtTotales.Text))
                {
                    if (!pedido.ActualizarFactura())
                    {
                        MessageBox.Show("Ocurrio un error al anular, contacte al programador.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Vamos actualizar caja
                        
                        caja.Saldo = saldo - Double.Parse(txtTotales.Text);
                        caja.Efectivo = efectivo - Double.Parse(txtTotales.Text);
                        if (caja.Actualizar())
                        {
                            MessageBox.Show("Factura anulada con exito.", "¡Realizado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error actualizar caja, contacte al programador.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    //Saldo en caja insuficiente para anular factura
                    MessageBox.Show("Saldo en caja insuficiente para anular factura. Intente mas tarde.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Verifique que haya una caja abierta.", "¡Informacion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Limpiar();   
        }
    }
}
