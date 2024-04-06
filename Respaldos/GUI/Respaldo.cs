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
            progressBar1.Value = 0;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            SaveFileDialog direccion = new SaveFileDialog();
            direccion.Filter = "Archivo SQL (*.sql)|*.sql";
            direccion.Title = "Selección de ruta";

            if (direccion.ShowDialog() == DialogResult.OK)
            {
                string ruta = direccion.FileName;

                (bool respaldoExitoso, TimeSpan duracionRespaldo) = op.Respaldo(ruta);
                try
                {
                    if (respaldoExitoso)
                    {
                        progressBarHelper.ActualizarProgressBar(duracionRespaldo, progressBar1, false);
                    }
                    else
                    {
                        progressBarHelper.ActualizarProgressBar(duracionRespaldo, progressBar1, true);
                    }
                }
                catch (Exception)
                {
                    progressBarHelper.ActualizarProgressBar(duracionRespaldo, progressBar1, true);
                }
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}