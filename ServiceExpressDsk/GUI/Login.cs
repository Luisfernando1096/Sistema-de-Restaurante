using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceExpressDsk.GUI
{
    public partial class Login : Form
    {
        Boolean autorizado = false;
        //SessionManager.Session oSesion = SessionManager.Session.Instancia;
        public bool Autorizado { get => autorizado; }
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            autorizado = true;
            Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!autorizado)
            {
                Environment.Exit(0);
            }
            
        }
    }
}
