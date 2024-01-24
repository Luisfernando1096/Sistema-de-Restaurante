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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtInicio.Text.Equals(""))
            {
                MessageBox.Show("No debe dejar campos vacios!", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtFin.Text.Equals(""))
            {
                MessageBox.Show("No debe dejar campos vacios!", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtActual.Text.Equals(""))
            {
                MessageBox.Show("No debe dejar campos vacios!", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSerie.Text.Equals(""))
            {
                MessageBox.Show("No debe dejar campos vacios!", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Int32.Parse(txtInicio.Text) > Int32.Parse(txtFin.Text))
            {
                MessageBox.Show("el inicio no puede ser mayor al fin!", "Campos No validos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TPV.GUI.AutorizarCambio f = new TPV.GUI.AutorizarCambio();
            f.ShowDialog();

            int pin = Int32.Parse(f.txtPin.Text);
            if (pin != 0)
            {
                DataTable filas = DataManager.DBConsultas.IniciarSesion(pin.ToString());
                if (filas.Rows.Count > 0)
                {
                    if (Int32.Parse(filas.Rows[0]["idRol"].ToString()) == 1)
                    {
                        Mantenimiento.CLS.Tiraje_Factura tiraje_Factura = new Mantenimiento.CLS.Tiraje_Factura();
                        tiraje_Factura.IdTiraje = Int32.Parse(cmbTipoFactura.SelectedValue.ToString());
                        tiraje_Factura.Inicio = Int32.Parse(txtInicio.Text);
                        tiraje_Factura.Fin = Int32.Parse(txtFin.Text);
                        tiraje_Factura.Actual = Int32.Parse(txtActual.Text);
                        tiraje_Factura.Serie = txtSerie.Text.ToString();
                        tiraje_Factura.TipoFactura = cmbTipoFactura.Text.ToString();
                        tiraje_Factura.Activo = true;

                        if (tiraje_Factura.Actualizar())
                        {
                            MessageBox.Show("Cambios realizados con exito!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tiene permiso para esta accion!");
                    }

                }
                else
                {
                    MessageBox.Show("Pin incorrecto, intentelo nuevamente!");
                }

            }

        }
    }
}
