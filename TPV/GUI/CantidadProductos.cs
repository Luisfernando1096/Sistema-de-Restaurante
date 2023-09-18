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
    public partial class CantidadProductos : Form
    {
        private bool cerrarPorBoton = false;

        public CantidadProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtCantidad.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar la cantidad de productos. Por favor, ingrese un valor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Int32.Parse(txtCantidad.Text)<=0)
            {
                MessageBox.Show("Debe ingresar una cantidad valida. Por favor, ingrese un valor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cerrarPorBoton = true;
            Close();
            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CantidadProductos_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void CantidadProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrarPorBoton && e.CloseReason == CloseReason.UserClosing)
            {
                // Realizar la acción aquí cuando el usuario no cierra el diálogo
                txtCantidad.Text = "0";
            }
            cerrarPorBoton = false;
        }

        private void CantidadProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Suprimir la acción predeterminada del Enter (como insertar un salto de línea)
                button1.PerformClick(); // Ejecutar el evento Click del botón
            }
        }

        private void CantidadProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
