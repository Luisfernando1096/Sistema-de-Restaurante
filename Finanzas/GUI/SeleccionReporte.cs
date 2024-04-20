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
    public partial class SeleccionReporte : Form
    {
        public int seleccion  = 0;
        public SeleccionReporte()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttSi_Click(object sender, EventArgs e)
        {
            seleccion = 1;
            Close();
        }

        private void bttNo_Click(object sender, EventArgs e)
        {
            seleccion = 2;
            Close();
        }
    }
}
