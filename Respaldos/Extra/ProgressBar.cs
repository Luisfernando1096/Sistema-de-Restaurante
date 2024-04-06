using System;
using System.Windows.Forms;

namespace Respaldos.Extra
{
    public class ProgressBar
    {
        public void ActualizarProgressBar(TimeSpan duracion, System.Windows.Forms.ProgressBar progressBar, bool error)
        {
            if (error)
            {
                DialogResult result = MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK || result == DialogResult.Cancel)
                {
                    progressBar.Value = 0;
                }
            }
            else
            {
                int progreso = (int)((duracion.TotalMilliseconds / 100) * 100);
                progreso = Math.Max(0, Math.Min(progreso, 100));
                progressBar.Value = progreso;
            }
        }
    }
}
