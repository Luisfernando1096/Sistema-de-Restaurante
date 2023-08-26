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
        Boolean EdicionMode = false;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (EdicionMode)
            {
                Mantenimiento.CLS.Roles r = new Mantenimiento.CLS.Roles();
                r.IdRol = int.Parse(txtIdRol.Text);
                r.Rol = txtROL.Text.ToString();
                if (r.Actualizar())
                {
                    MessageBox.Show("Actualizacion Exitosa");
                    txtROL.Clear();
                    txtIdRol.Clear();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Actualizacion Fallida");
                }
            }
            else
            {
                Mantenimiento.CLS.Roles r = new Mantenimiento.CLS.Roles();
                r.Rol = txtROL.Text.ToString();

                if (r.Insertar())
                {
                    MessageBox.Show("Registro insertado");
                    CargarDatos();
                    txtROL.Clear();
                    txtIdRol.Clear();
                }
                else
                {
                    MessageBox.Show("Registro no insertado");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Mantenimiento.CLS.Roles r = new Mantenimiento.CLS.Roles();
            r.IdRol =Convert.ToInt32(dgvDatos.CurrentRow.Cells["idRol"].Value);
            if (r.Eliminar())
            {
                MessageBox.Show("Eliminacion Exitosa");
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Eliminacion Fallida");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (EdicionMode)
            {
                EdicionMode = false;
            }
            txtIdRol.Clear();
            txtROL.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EdicionMode = true;
            txtIdRol.Text = dgvDatos.CurrentRow.Cells["idRol"].Value.ToString();
            txtROL.Text = dgvDatos.CurrentRow.Cells["rol"].Value.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
