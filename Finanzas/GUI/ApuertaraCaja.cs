using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finanzas.GUI
{
    public partial class ApuertaraCaja : Form
    {
        SessionManager.Session oUsuario = SessionManager.Session.Instancia;
        BindingSource datos = new BindingSource();

        public ApuertaraCaja()
        {
            InitializeComponent();
            dtpFecha.Text = DateTime.Now.ToString();
        }

        private void ApuertaraCaja_Load(object sender, EventArgs e)
        {
            timer1.Start();
            txtCajero.Text = oUsuario.Usuario;
            txtCajero.Tag = oUsuario.IdUsuario;
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Cajas(false);
                dgvCajas.DataSource = datos;
                dgvCajas.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtSaldoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, el punto decimal y la tecla de retroceso (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignorar la tecla presionada
            }

            // Asegurarse de que solo haya un punto decimal en el texto
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Ignorar el punto decimal adicional
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtpFecha.Text = DateTime.Now.ToString();
        }

        private void ApuertaraCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtSaldoInicial.Text.Equals(""))
            {
                MessageBox.Show("El campo de Saldo inicial no puede estar vacío. Por favor, Selecione una direccion.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable cajaAbierta = DataManager.DBConsultas.CajaAbierta();
            Mantenimiento.CLS.Caja caja = new Mantenimiento.CLS.Caja();

            caja.IdCajero = Int32.Parse(txtCajero.Tag.ToString());
            caja.Estado = true;
            caja.FechaApertura = dtpFecha.Text;
            caja.SaldoInicial = Double.Parse(txtSaldoInicial.Text);
            caja.Efectivo = 0;
            caja.Saldo = 0;
            
            if (txtIdCaja.Text.Equals(""))
            {
                if (cajaAbierta.Rows.Count > 0)
                {
                    MessageBox.Show("Ya hay una caja abierta, para crear una nueva cierre la anterior.", "Caja Abierta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Se inserta y abre caja
                if (caja.Insertar())
                {
                    MessageBox.Show("Se abrio con exito una nueva caja.", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo abrir una nueva caja, contacte al programador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // La cadena de fecha y hora en formato original
                string fechaHoraString = dgvCajas.CurrentRow.Cells["fechaApertura"].Value.ToString();

                // Define el formato original de la cadena de fecha y hora
                string formatoOriginal = "d/M/yyyy HH:mm:ss";

                // Convierte la cadena en un objeto DateTime
                DateTime fechaHora = DateTime.ParseExact(fechaHoraString, formatoOriginal, System.Globalization.CultureInfo.InvariantCulture);

                // Define el formato deseado
                string formatoDeseado = "yyyy-MM-dd HH:mm:ss";

                // Formatea la fecha y hora en el formato deseado
                string fechaHoraFormateada = fechaHora.ToString(formatoDeseado);
                //Se actualiza
                caja.IdCaja = Int32.Parse(txtIdCaja.Text);
                caja.Efectivo = Double.Parse(dgvCajas.CurrentRow.Cells["efectivo"].Value.ToString());
                caja.Saldo = Double.Parse(dgvCajas.CurrentRow.Cells["saldo"].Value.ToString());
                caja.FechaApertura = fechaHoraFormateada;
                if (caja.Actualizar())
                {
                    MessageBox.Show("Se actualizo con exito la caja.", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar, contacte al programador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            CargarDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (bool.Parse(dgvCajas.CurrentRow.Cells["estado"].Value.ToString()))
            {
                txtIdCaja.Text = dgvCajas.CurrentRow.Cells["idCaja"].Value.ToString();
                txtCajero.Text = dgvCajas.CurrentRow.Cells["nombres"].Value.ToString();
                txtCajero.Tag = dgvCajas.CurrentRow.Cells["idCajero"].Value.ToString();
                txtSaldoInicial.Text = dgvCajas.CurrentRow.Cells["saldoInicial"].Value.ToString();


            }
            else
            {
                MessageBox.Show("No se puede editar una caja cerrada.", "No admitible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdCaja.Text = "";
            txtCajero.Text = oUsuario.Usuario;
            txtCajero.Tag = oUsuario.IdUsuario;
            txtSaldoInicial.Text = "0";
        }
    }
}
