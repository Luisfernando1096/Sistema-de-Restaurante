using System;
using System.Windows.Forms;

namespace ServiceExpressDsk.GUI
{
    public partial class Login : Form
    {
        Boolean autorizado = false;
        SessionManager.Session oSesion = SessionManager.Session.Instancia;
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;
        ConfiguracionManager.CLS.Ticket oTicket = ConfiguracionManager.CLS.Ticket.Instancia;
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
                MessageBox.Show("El campo para el pin no puede estar vacío. Por favor, ingrese un valor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (oSesion.IniciarSesion(txtClave.Text))
            {
                autorizado = true;
                oConfiguracion.ObtenerConfiguracion();
                oEmpresa.ObtenerConfiguracion();
                oTicket.ObtenerConfiguracion();
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
