using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal.GUI
{
    public partial class RolesGestion : Form
    {
        BindingSource _DATOS = new BindingSource();

        private void CargarDatos()
        {
            try
            {
                _DATOS.DataSource = DataManager.DBConsultas.Roles();
                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.DataSource = _DATOS;
            }
            catch (Exception)
            {

            }
        }
        public RolesGestion()
        {
            InitializeComponent();
        }

        private void txtROL_TextChanged(object sender, EventArgs e)
        {

        }

        private void RolesGestion_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
