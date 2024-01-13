using System;
using System.Windows.Forms;

namespace Respaldos.GUI
{
    public partial class Respaldo : Form
    {
        private Respaldos.Extra.ProgressBar progressBarHelper = new Respaldos.Extra.ProgressBar();

        public Respaldo()
        {
            InitializeComponent();
        }

        private void bntRespaldo_Click(object sender, EventArgs e)
        {

            DataManager.DBOperacion op = new DataManager.DBOperacion();
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

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}