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
        SessionManager.Session oSesion = SessionManager.Session.Instancia;
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        public bool Autorizado { get => autorizado; }
        public Login()
        {
            InitializeComponent();
            KeyPreview = true; // Habilitar la captura de teclas en el formulario
        }



        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!autorizado)
            {
                Environment.Exit(0);
            }
            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals(""))
            {
                MessageBox.Show("El campo de categoria no puede estar vacío. Por favor, ingrese un valor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (oSesion.IniciarSesion(txtClave.Text))
            {
                autorizado = true;
                oConfiguracion.ObtenerConfiguracion();
                Close();
            }
            else
            {
                autorizado = false;
                MessageBox.Show("Datos incorrectos");
                txtClave.Focus();
                txtClave.SelectAll();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CadenaConexion cadenaConexion = new CadenaConexion();
            cadenaConexion.ShowDialog();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Suprimir la acción predeterminada del Enter (como insertar un salto de línea)
                btnIngresar.PerformClick(); // Ejecutar el evento Click del botón
            }
        }
    }
}
