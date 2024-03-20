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
    public partial class MesasOcupadas : Form
    {
        BindingSource datos = new BindingSource();
        public MesasOcupadas()
        {
            InitializeComponent();
        }

        private void MesasOcupadas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.MesasOcupadasConMeseroySalon();
                dgvClientes.DataSource = datos;
                dgvClientes.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
            lblRegistros.Text = datos.List.Count.ToString() + " Mesas ocupadas";
        }
    }
}
