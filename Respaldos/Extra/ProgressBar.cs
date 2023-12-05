using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgressBarControl = System.Windows.Forms.ProgressBar;

namespace Respaldos.Extra
{
    public class ProgressBar
    {
        public void ActualizarProgressBar(TimeSpan duracion, System.Windows.Forms.ProgressBar progressBar)
        {
            // Calcula el progreso en base a la duración (ajusta según tus necesidades)
            int progreso = (int)((duracion.TotalMilliseconds / 100) * 100);

            // Asegúrate de que el progreso esté en el rango adecuado
            progreso = Math.Max(0, Math.Min(progreso, 100));

            // Actualiza el ProgressBar
            progressBar.Value = progreso;
        }
    }
}
