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
    public partial class PuntoVenta : Form
    {
        public PuntoVenta()
        {
            InitializeComponent();
        }

        private void PuntoVenta_Load(object sender, EventArgs e)
        {
            //List<string> productos = ObtenerProductosDesdeBD();
            DataTable salones = DataManager.DBConsultas.Salones();
            // Crear y agregar botones al FlowLayoutPanel para cada producto
            foreach (DataRow salon in salones.Rows)
            {
                Button button = new Button();
                button.Text = salon["nombre"].ToString();
                button.Click += BotonProducto_Click;
                flpSalones.Controls.Add(button);
            }
        }

        private void BotonProducto_Click(object sender, EventArgs e)
        {
            Button botonSalon = (Button)sender;
            string nombreSalon = botonSalon.Text;

            MessageBox.Show("Has seleccionado el salon: " + nombreSalon);
        }
    }
}
