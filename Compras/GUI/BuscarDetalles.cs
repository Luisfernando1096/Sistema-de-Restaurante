using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compras.GUI
{
    public partial class BuscarDetalles : Form
    {
        BindingSource datos = new BindingSource();
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public int IdComprobante { get; set; }
        public int IdUsuario { get; set; }
        public string TCompra { get; set; }
        public string Nombre { get; set; }
        public string tipo { get; set; }
        public string NComprobante { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string FormaPago { get; set; }
        public string TipoFactura { get; set; }

        private void CargarDatos(int id) 
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.ComprasProveedor(id);
                dgvBuscar.DataSource = datos;
                dgvBuscar.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void BuscarDatos() 
        {
            try
            {
                dgvBuscar.CurrentCell = null;

                foreach (DataGridViewRow r in dgvBuscar.Rows)
                {
                    r.Visible = false;

                    if (rbtnNumero.Checked)
                    {
                        string filtro = cmbLista.Text;

                        cmbLista.Visible = true;
                        dtFecha.Visible = false;
                        string valorCelda = r.Cells["nComprobante"].Value.ToString();
                        if (valorCelda.StartsWith(filtro, StringComparison.OrdinalIgnoreCase)) // Comparación desde el principio, insensible a mayúsculas y minúsculas
                        {
                            r.Visible = true;
                        }
                    }
                    else if (rbtFecha.Checked)
                    {
                        cmbLista.Visible = false;
                        dtFecha.Visible = true;

                        DateTime fechaSeleccionada = dtFecha.Value.Date;  // Obtén la fecha sin la hora
                        DateTime fechaInicioDia = fechaSeleccionada;
                        DateTime fechaFinDia = fechaSeleccionada.AddDays(1).AddSeconds(-1); // Finaliza a las 23:59:59

                        string valorCelda = r.Cells["fecha"].Value.ToString();

                        DateTime fechaEnCelda;
                        if (DateTime.TryParse(valorCelda, out fechaEnCelda))
                        {
                            // Comprueba si la fecha en la celda está dentro del rango del día seleccionado
                            if (fechaEnCelda >= fechaInicioDia && fechaEnCelda <= fechaFinDia)
                            {
                                r.Visible = true;
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BuscarDetalles()
        {
            InitializeComponent();
            KeyPreview = true; // Habilitar la captura de teclas en el formulario
        }

        private void BuscarDetalles_Load(object sender, EventArgs e)
        {
            rdAmbos.Checked = true;
            if (rdAmbos.Checked == true)
            {
                CargarDatos(3);
            }
            else if (rdIngrediente.Checked == true)
            {
                CargarDatos(2);
            }
            else if (rdProducto.Checked == true)
            {
                CargarDatos(1);
            }
        }

        private void bntSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvBuscar.SelectedRows.Count != 0)
            {
                IdCompra = int.Parse(dgvBuscar.CurrentRow.Cells["idCompra"].Value.ToString());
                TCompra = dgvBuscar.CurrentRow.Cells["TipoCompra"].Value.ToString();
                IdProveedor = int.Parse(dgvBuscar.CurrentRow.Cells["idProveedor"].Value.ToString());
                Nombre = dgvBuscar.CurrentRow.Cells["nombre"].Value.ToString();
                IdComprobante = int.Parse(dgvBuscar.CurrentRow.Cells["idComprobante"].Value.ToString());
                tipo = dgvBuscar.CurrentRow.Cells["tipo"].Value.ToString();
                NComprobante = dgvBuscar.CurrentRow.Cells["nComprobante"].Value.ToString();
                IdUsuario = int.Parse(dgvBuscar.CurrentRow.Cells["idUsuario"].Value.ToString());
                Fecha = DateTime.Parse(dgvBuscar.CurrentRow.Cells["fecha"].Value.ToString());
                SubTotal = decimal.Parse(dgvBuscar.CurrentRow.Cells["total"].Value.ToString());
                Descuento = (decimal.Parse(dgvBuscar.CurrentRow.Cells["descuento"].Value.ToString()));
                Iva = (decimal.Parse(dgvBuscar.CurrentRow.Cells["iva"].Value.ToString()));
                Total = decimal.Parse(dgvBuscar.CurrentRow.Cells["totalPago"].Value.ToString());
                FormaPago = dgvBuscar.CurrentRow.Cells["formaPago"].Value.ToString();
                TipoFactura = dgvBuscar.CurrentRow.Cells["tipoFactura"].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void rdProducto_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos(1);
            BuscarDatos();
        }

        private void rdIngrediente_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos(2);
            BuscarDatos();
        }

        private void rdAmbos_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos(3);
            BuscarDatos();
        }

        private void rbtnNumero_CheckedChanged(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void rbtFecha_CheckedChanged(object sender, EventArgs e)
        {
            BuscarDatos();
        }
        private void cmbLista_TextChanged(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void dgvBuscar_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BuscarDatos();
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void BuscarDetalles_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvBuscar.SelectedRows.Count != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // Suprimir la acción predeterminada del Enter (como insertar un salto de línea)
                    bntSelecionar.PerformClick(); // Ejecutar el evento Click del botón
                }
            }
        }
    }
}
