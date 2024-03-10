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
    public partial class Referencia : Form
    {
        public bool cerrarPorBoton;
        public Referencia()
        {
            InitializeComponent();
        }

        private void txtNReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Suprimir la acción predeterminada del Enter (como insertar un salto de línea)
                btnOk.PerformClick(); // Ejecutar el evento Click del botón
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtNReferencia.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el valor de referencia. Por favor, ingrese un valor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cerrarPorBoton = true;
            Close();
        }
    }
}
