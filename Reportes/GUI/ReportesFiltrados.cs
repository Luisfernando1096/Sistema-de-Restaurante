using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.GUI
{
    public partial class ReportesFiltrados : Form
    {
        public ReportesFiltrados()
        {
            InitializeComponent();
        }

        private void btnSalirIngrediente_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            pbInicio.Visible = false;
            pbFin.Visible = false;
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
        }

        private void dtpFechaDesde_CloseUp(object sender, EventArgs e)
        {
            if (dtpInicio.Value.Date > dtpFin.Value.Date)
            {
                pbInicio.Visible = false;
                dtpInicio.Value = DateTime.Now;
                MessageBox.Show("Debe seleccionar un rango de fecha valido.");
                return;
            }
            pbInicio.Visible = true;
        }

        private void dtpFechaHasta_CloseUp(object sender, EventArgs e)
        {
            if (dtpInicio.Value.Date > dtpFin.Value.Date)
            {
                pbFin.Visible = false;
                dtpFin.Value = DateTime.Now;
                MessageBox.Show("Debe seleccionar un rango de fecha valido.");
                return;
            }
            pbFin.Visible = true;
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (cmbTipoVetas.SelectedIndex == 7)
            {
                Reportes.GUI.VisorGeneral rg = new Reportes.GUI.VisorGeneral();
                rg.opc = 4;
                rg.FechaInicio = dtpInicio.Value.ToString("yyyy-MM-dd");
                rg.FechaFinal = dtpFin.Value.ToString("yyyy-MM-dd");
                rg.ShowDialog();
            }
        }
    }
}
