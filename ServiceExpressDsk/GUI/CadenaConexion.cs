using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace ServiceExpressDsk.GUI
{
    public partial class CadenaConexion : Form
    {
        public CadenaConexion()
        {
            InitializeComponent();
            cmbPc.SelectedIndex = 0;
            chkProbarConexion.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chkProbarConexion.Checked)
            {
                //Probar conexion
                GuardarDatos();

                try
                {
                    DataManager.DBConexion cn = new DataManager.DBConexion();
                    if (cn.Conectar())
                    {
                        MessageBox.Show("Conexion establecida con exito.", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cn.Desconectar();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se conecto a la base de datos, verifique que los campos sean correctos.", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
            else
            {
                GuardarDatos();
                Close();
            }
            

        }

        private void GuardarDatos()
        {
            if (txtServidorBD.Text.Equals(""))
            {
                MessageBox.Show("Favor llenar todos los campos.", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtBaseDatos.Text.Equals(""))
            {
                MessageBox.Show("Favor llenar todos los campos.", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtUsuarioBD.Text.Equals(""))
            {
                MessageBox.Show("Favor llenar todos los campos.", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtContraseniaBD.Text.Equals(""))
            {
                MessageBox.Show("Favor llenar todos los campos.", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtIpLocal.Text.Equals(""))
            {
                MessageBox.Show("Favor llenar todos los campos.", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPuerto.Text.Equals(""))
            {
                MessageBox.Show("Favor llenar todos los campos.", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            //Validar la ip
            if (!ValidariP())
            {
                MessageBox.Show("La ip no es valida, por favor escriba una ip valida", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string servidor = txtServidorBD.Text.Trim();
            string baseDeDatos = txtBaseDatos.Text.Trim();
            string usuario = txtUsuarioBD.Text.Trim();
            string contraseña = txtContraseniaBD.Text.Trim();
            string ipLocal = txtIpLocal.Text.Trim();
            string puerto = txtPuerto.Text.Trim();
            string pc = cmbPc.SelectedItem.ToString().Trim();

            string archivoConfiguracion = "configuracion.xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(archivoConfiguracion, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Configuracion");

                writer.WriteElementString("Servidor", servidor);
                writer.WriteElementString("BaseDeDatos", baseDeDatos);
                writer.WriteElementString("Usuario", usuario);
                writer.WriteElementString("Contraseña", contraseña);
                writer.WriteElementString("IpLocal", ipLocal);
                writer.WriteElementString("Puerto", puerto);
                writer.WriteElementString("Pc", pc);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private bool ValidariP()
        {
            IPAddress ipAddress;
            return IPAddress.TryParse(txtIpLocal.Text.ToString().Trim(), out ipAddress) && ipAddress.ToString().Equals(txtIpLocal.Text.ToString().Trim());
        }

        private void CadenaConexion_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void CadenaConexion_Load(object sender, EventArgs e)
        {
            string archivoConfiguracion = "configuracion.xml";

            if (File.Exists(archivoConfiguracion))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(archivoConfiguracion);

                if (xmlDoc.SelectSingleNode("/Configuracion/Servidor") != null)
                {
                    string baseDeDatos = xmlDoc.SelectSingleNode("/Configuracion/BaseDeDatos").InnerText;
                    txtBaseDatos.Text = baseDeDatos;
                }
                if (xmlDoc.SelectSingleNode("/Configuracion/BaseDeDatos") != null)
                {
                    string servidor = xmlDoc.SelectSingleNode("/Configuracion/Servidor").InnerText;
                    txtServidorBD.Text = servidor;
                }
                if (xmlDoc.SelectSingleNode("/Configuracion/Usuario") != null)
                {
                    string usuario = xmlDoc.SelectSingleNode("/Configuracion/Usuario").InnerText;
                    txtUsuarioBD.Text = usuario;
                }
                if (xmlDoc.SelectSingleNode("/Configuracion/Contraseña") != null)
                {
                    string contraseña = xmlDoc.SelectSingleNode("/Configuracion/Contraseña").InnerText;
                    txtContraseniaBD.Text = contraseña;
                }
                if (xmlDoc.SelectSingleNode("/Configuracion/IpLocal") != null)
                {
                    string ipLocal = xmlDoc.SelectSingleNode("/Configuracion/IpLocal").InnerText;
                    txtIpLocal.Text = ipLocal;
                }
                if (xmlDoc.SelectSingleNode("/Configuracion/Puerto") != null)
                {
                    string puerto = xmlDoc.SelectSingleNode("/Configuracion/Puerto").InnerText;
                    txtPuerto.Text = puerto;
                }
                if (xmlDoc.SelectSingleNode("/Configuracion/Pc") != null)
                {
                    string pc = xmlDoc.SelectSingleNode("/Configuracion/Pc").InnerText;
                    cmbPc.SelectedItem = pc;
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPuerto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnIpAutomatica_Click(object sender, EventArgs e)
        {
            //OBETNER IP AUTOMATICAMENTE
            string hostName = Dns.GetHostName();
            // Inicializar la variable
            IPAddress[] localIPs = Dns.GetHostAddresses(hostName);
            // Filtrar las direcciones IPv4
            IPAddress ipv4Address = localIPs.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            txtIpLocal.Text = ipv4Address.ToString();
        }
    }
}
