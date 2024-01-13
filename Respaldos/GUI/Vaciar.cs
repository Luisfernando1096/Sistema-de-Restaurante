using System;
using System.Windows.Forms;

namespace Respaldos.GUI
{
    public partial class Vaciar : Form
    {
        public Vaciar()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
