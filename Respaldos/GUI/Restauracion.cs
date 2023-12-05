using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Respaldos.GUI
{
    public partial class Restauracion : Form
    {
        DataManager.DBOperacion op = new DataManager.DBOperacion();
        private Respaldos.Extra.ProgressBar progressBarHelper = new Respaldos.Extra.ProgressBar();

        public Restauracion()
        {
            InitializeComponent();
        }

        private void bntRespaldo_Click(object sender, EventArgs e)
        {
            SaveFileDialog direccion = new SaveFileDialog();
            direccion.Filter = "Archivo SQL (*.sql)|*.sql";
            direccion.InitialDirectory = @"C:\Users\Fuentes\Desktop\REPORTES";
            direccion.Title = "Selección de ruta";

            if (direccion.ShowDialog() == DialogResult.OK)
            {
                string ruta = direccion.FileName;

                // Realiza el respaldo y obtén la duración
                TimeSpan duracionRespaldo = op.Respaldo(ruta);

                progressBarHelper.ActualizarProgressBar(duracionRespaldo, progressBar1);
            }
        }

        private void bntRestaurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog direccion = new OpenFileDialog();
            direccion.Filter = "Archivo SQL (*.sql)|*.sql";
            direccion.InitialDirectory = @"C:\Users\Fuentes\Desktop\REPORTES";
            direccion.Title = "Selección de ruta";

            if (direccion.ShowDialog() == DialogResult.OK)
            {
                string ruta = direccion.FileName;

                // Realiza el respaldo y obtén la duración
                TimeSpan duracionRespaldo = op.RestaurarRespaldo(ruta);

                progressBarHelper.ActualizarProgressBar(duracionRespaldo, progressBar1);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
