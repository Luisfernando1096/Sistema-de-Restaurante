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
    public partial class AgregarPedido : Form
    {
        public string seleccion = "";

        public AgregarPedido()
        {
            InitializeComponent();
        }

        private void bttSi_Click(object sender, EventArgs e)
        {
            seleccion = "SI";
            Close();
        }

        private void bttNo_Click(object sender, EventArgs e)
        {
            seleccion = "NO";
            Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
