using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ServiceExpressDsk.GUI
{
    public partial class CadenaConexion : Form
    {
        public CadenaConexion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string servidor = txtServidorBD.Text.Trim();
            string baseDeDatos = txtBaseDatos.Text.Trim();
            string usuario = txtUsuarioBD.Text.Trim();
            string contraseña = txtContraseniaBD.Text.Trim();
            string ipLocal = txtIpLocal.Text.Trim();
            //Validar la ip
            if (ValidariP())
            {
                MessageBox.Show("La ip no es valida, por favor escriba una ip valida", "");
                return;
            }
            string host = txtHost.Text.Trim();

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
                writer.WriteElementString("Host", host);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            Close();

        }

        private bool ValidariP()
        {
            throw new NotImplementedException();
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

                string servidor = xmlDoc.SelectSingleNode("/Configuracion/Servidor").InnerText;
                string baseDeDatos = xmlDoc.SelectSingleNode("/Configuracion/BaseDeDatos").InnerText;
                string usuario = xmlDoc.SelectSingleNode("/Configuracion/Usuario").InnerText;
                string contraseña = xmlDoc.SelectSingleNode("/Configuracion/Contraseña").InnerText;
                string ipLocal = xmlDoc.SelectSingleNode("/Configuracion/IpLocal").InnerText;
                string host = xmlDoc.SelectSingleNode("/Configuracion/Host").InnerText;

                txtBaseDatos.Text = baseDeDatos;
                txtServidorBD.Text = servidor;
                txtUsuarioBD.Text = usuario;
                txtContraseniaBD.Text = contraseña;
                txtIpLocal.Text = ipLocal;
                txtHost.Text = host;
                // Utiliza los valores de la cadena de conexión como desees
                string cadenaConexion = $"Server={servidor};Database={baseDeDatos};User Id={usuario};Password={contraseña};";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
