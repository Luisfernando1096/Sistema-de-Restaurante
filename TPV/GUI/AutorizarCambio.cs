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
    public partial class AutorizarCambio : Form
    {
        private bool cerrarPorBoton;

        public AutorizarCambio()
        {
            InitializeComponent();
        }

        private void btnComprobar_Click(object sender, EventArgs e)
        {
            if (txtPin.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el pin. Por favor, ingrese un valor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Int32.Parse(txtPin.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar un pin valido. Por favor, ingrese un valor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cerrarPorBoton = true;
            Close();
        }

        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AutorizarCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrarPorBoton && e.CloseReason == CloseReason.UserClosing)
            {
                // Realizar la acción aquí cuando el usuario no cierra el diálogo
                txtPin.Text = "0";
            }
            cerrarPorBoton = false;
        }

        private void txtPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Suprimir la acción predeterminada del Enter (como insertar un salto de línea)
                btnComprobar.PerformClick(); // Ejecutar el evento Click del botón
            }
        }
    }
}
