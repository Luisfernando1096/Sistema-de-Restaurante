using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ServiceExpressDsk.GUI
{
    public partial class Login : Form
    {
        Boolean autorizado = false;
        readonly SessionManager.Session oSesion = SessionManager.Session.Instancia;
        readonly ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        readonly ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;
        readonly ConfiguracionManager.CLS.Ticket oTicket = ConfiguracionManager.CLS.Ticket.Instancia;
        readonly ConfiguracionManager.CLS.Salon oSalon = ConfiguracionManager.CLS.Salon.Instancia;

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
                if (oConfiguracion.ObtenerConfiguracion())
                {
                    Close();
                }
                else
                {
                    //Acceder al archivo de configuracion para obtener que pc es
                    int idConf = 1;

                    string archivo = "configuracion.xml";

                    if (File.Exists(archivo))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(archivo);


                        if (xmlDoc.SelectSingleNode("/Configuracion/Pc") != null)
                        {
                            string pc = xmlDoc.SelectSingleNode("/Configuracion/Pc").InnerText;
                            if (pc.Equals("Principal"))
                            {
                                idConf = 1;
                            }
                            else if (pc.Equals("Cliente 1"))
                            {
                                idConf = 2;
                            }
                            else if (pc.Equals("Cliente 2"))
                            {
                                idConf = 3;
                            }

                        }

                    }
                    //No obtuve la configuracion hay que agregarla
                    Mantenimiento.CLS.Configuracion config = new Mantenimiento.CLS.Configuracion
                    {
                        IdConfiguracion = idConf,
                        ControlStock = 1,
                        IncluirPropina = 1,
                        Propina = 10.00,
                        IncluirImpuesto = 0,
                        Iva = 0,
                        MesaVIP = 0,
                        AutorizarDescProp = 0,
                        PrinterComanda = "Microsoft Print to PDF",
                        PrinterFactura = "Microsoft Print to PDF",
                        PrinterInformes = "Microsoft Print to PDF",
                        AlertaCaja = 1,
                        Multisesion = 1,
                        NumSesiones = 100,
                        MuchosProductos = 0,
                        ImprimirDosTicketsPago = 0,
                        ImpresoraAppMovil = "Microsoft Print to PDF",
                        FacturaElectronica = 0,
                        ImpresoraCocina = "Microsoft Print to PDF",
                        ImpresoraBar = "Microsoft Print to PDF",
                        ImpresoraGrupoUno = "Microsoft Print to PDF",
                        ImpresoraGrupoDos = "Microsoft Print to PDF"
                    };
                    config.Insertar();
                    if (oConfiguracion.ObtenerConfiguracion())
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al obtener la configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                oEmpresa.ObtenerConfiguracion();
                oTicket.ObtenerConfiguracion();
                oSalon.ObtenerSalon();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (CadenaConexion cadenaConexion = new CadenaConexion())
            {
                cadenaConexion.ShowDialog();
            }
                
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Suprimir la acción predeterminada del Enter (como insertar un salto de línea)
                btnIngresar.PerformClick(); // Ejecutar el evento Click del botón
            }
        }

        private void lblContaseña_Click(object sender, EventArgs e)
        {
            using (CambioContraseña f = new CambioContraseña())
            {
                this.Hide();
                f.FormClosed += (s, args) => this.Show();
                f.ShowDialog();
            }
                
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals("0"))
            {
                txtClave.Text = btn9.Text;
            }
            else
            {
                txtClave.Text += btn9.Text;
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals("0"))
            {
                txtClave.Text = btn8.Text;
            }
            else
            {
                txtClave.Text += btn8.Text;
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals("0"))
            {
                txtClave.Text = btn7.Text;
            }
            else
            {
                txtClave.Text += btn7.Text;
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals("0"))
            {
                txtClave.Text = btn6.Text;
            }
            else
            {
                txtClave.Text += btn6.Text;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals("0"))
            {
                txtClave.Text = btn5.Text;
            }
            else
            {
                txtClave.Text += btn5.Text;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals("0"))
            {
                txtClave.Text = btn4.Text;
            }
            else
            {
                txtClave.Text += btn4.Text;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals("0"))
            {
                txtClave.Text = btn3.Text;
            }
            else
            {
                txtClave.Text += btn3.Text;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals("0"))
            {
                txtClave.Text = btn2.Text;
            }
            else
            {
                txtClave.Text += btn2.Text;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals("0"))
            {
                txtClave.Text = btn1.Text;
            }
            else
            {
                txtClave.Text += btn1.Text;
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Equals("0"))
            {
                txtClave.Text = btn0.Text;
            }
            else
            {
                txtClave.Text += btn0.Text;
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtClave.Text = "";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Length > 0)
            {
                // Elimina el último dígito del texto en el TextBox
                txtClave.Text = txtClave.Text.Substring(0, txtClave.Text.Length - 1);
            }
        }
    }
}
