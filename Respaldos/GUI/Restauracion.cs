using System;
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
            progressBar1.Value = 0;
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

        private void bntRestaurar_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            OpenFileDialog direccion = new OpenFileDialog();
            direccion.Filter = "Archivo SQL (*.sql)|*.sql";
            direccion.Title = "Selección de ruta";

            if (direccion.ShowDialog() == DialogResult.OK)
            {
                string ruta = direccion.FileName;

                // Realiza el respaldo y obtén la duración
                (bool restauracionExitosa, TimeSpan duracionRespaldo) = op.RestaurarRespaldo(ruta);
                try
                {
                    if (restauracionExitosa)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
