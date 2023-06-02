using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            Close();

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

                txtBaseDatos.Text = baseDeDatos;
                txtServidorBD.Text = servidor;
                txtUsuarioBD.Text = usuario;
                txtContraseniaBD.Text = contraseña;
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
