using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimiento.GUI
{
    public partial class fr : Form
    {
        BindingSource datos = new BindingSource();
        public fr()
        {
            InitializeComponent();
        }

        private void CargarMunicipiosPorDepartamento(int id)
        {
            try
            {
                DataTable rol = DataManager.DBConsultas.MunicipiosPorDepartamento(id);

                cmbMunicipio.DataSource = rol;
                cmbMunicipio.DisplayMember = "nombre";
                cmbMunicipio.ValueMember = "idMunicipio";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CargarDepartamentos()
        {
            try
            {
                DataTable rol = DataManager.DBConsultas.Departamentos();

                cmbDepartamento.DataSource = rol;
                cmbDepartamento.DisplayMember = "nombre";
                cmbDepartamento.ValueMember = "idDepartamento";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AgregarDireccion_Load(object sender, EventArgs e)
        {
            //CargarDatos();
            CargarDepartamentos();
        }

        private void cmbDepartamento_ValueMemberChanged(object sender, EventArgs e)//Se ejecuta una vez al inicio
        {
            if (cmbDepartamento.SelectedItem != null)
            {
                int valor = Int32.Parse(cmbDepartamento.SelectedValue.ToString());
                CargarMunicipiosPorDepartamento(valor);
            }
        }

        private void cmbDepartamento_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbDepartamento.SelectedItem != null)
            {
                int valor = Int32.Parse(cmbDepartamento.SelectedValue.ToString());
                CargarMunicipiosPorDepartamento(valor);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
