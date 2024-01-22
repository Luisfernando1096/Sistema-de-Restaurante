using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Configuraciones.GUI
{
    public partial class TirajeFactura : Form
    {
        DataTable tf;
        public TirajeFactura()
        {
            InitializeComponent();

            // Suscribir al evento KeyPress del TextBox
            txtInicio.KeyPress += txtInicio_KeyPress;
            txtFin.KeyPress += txtFin_KeyPress;
            txtActual.KeyPress += txtActual_KeyPress;
        }

        private void TirajeFactura_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                tf = DataManager.DBConsultas.TirajeFactura();
                
                cmbTipoFactura.DataSource = tf;
                cmbTipoFactura.DisplayMember = "tipoFactura";
                cmbTipoFactura.ValueMember = "idTiraje";

                LlenarTexto();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar datos: " + e);
                throw;
            }
        }

        private void LlenarTexto()
        {
            txtInicio.Text = tf.Rows[cmbTipoFactura.SelectedIndex]["inicio"].ToString();
            txtFin.Text = tf.Rows[cmbTipoFactura.SelectedIndex]["fin"].ToString();
            txtActual.Text = tf.Rows[cmbTipoFactura.SelectedIndex]["actual"].ToString();
            txtSerie.Text = tf.Rows[cmbTipoFactura.SelectedIndex]["serie"].ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbTipoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarTexto();
        }

        private void PermitirSoloSeisDigitos(object sender, KeyPressEventArgs e) 
        {

            // Verificar si la tecla presionada es un número o una tecla de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancelar la tecla si no es un número o una tecla de control
                e.Handled = true;
            }

            // Verificar la longitud actual del texto en el TextBox
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length >= 6 && !char.IsControl(e.KeyChar))
            {
                // Cancelar la tecla si la longitud es igual o mayor a 6 y no es una tecla de control
                e.Handled = true;
            }
        }

        private void txtInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloSeisDigitos(sender, e);
        }

        private void txtFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloSeisDigitos(sender, e);
        }

        private void txtActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloSeisDigitos(sender, e);
        }
    }
}
