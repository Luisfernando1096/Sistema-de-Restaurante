using System;
using System.Windows.Forms;

namespace ServiceExpressDsk.GUI
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
            timer1.Stop();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
