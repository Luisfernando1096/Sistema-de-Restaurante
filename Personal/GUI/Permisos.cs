using System;
using System.Data;
using System.Windows.Forms;

namespace Personal.GUI
{
    public partial class Permisos : Form
    {
        private void CargarRoles()
        {
            DataTable Roles = new DataTable();
            try
            {
                DataTable rol = DataManager.DBConsultas.Roles();
                DataTable dt = rol.Clone();

                dt.Merge(rol);

                cmbRol.DataSource = dt;
                cmbRol.DisplayMember = "rol";
                cmbRol.ValueMember = "idRol";
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarPermisoDiponibles()
        {
            DataTable permisos = new DataTable();
            String pIDRol = cmbRol.SelectedValue.ToString();
            try
            {
                permisos = DataManager.DBConsultas.PermisosDisponibles(pIDRol);
                dgvPermisosDisponibles.AutoGenerateColumns = false;
                dgvPermisosDisponibles.DataSource = permisos;

            }
            catch (Exception)
            {

            }
        }
        private void CargarPermisosOtorgados()
        {
            DataTable permisos = new DataTable();
            String pIDRol = cmbRol.SelectedValue.ToString();
            try
            {
                permisos = DataManager.DBConsultas.PermisosOtorgados(pIDRol);
                dgvDatosOtorgados.AutoGenerateColumns = false;
                dgvDatosOtorgados.DataSource = permisos;

            }
            catch (Exception)
            {

            }
        }

        public Permisos()
        {
            InitializeComponent();
        }

        private void Permisos_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarPermisosOtorgados();
            CargarPermisoDiponibles();
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPermisosOtorgados();
            CargarPermisoDiponibles();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvPermisosDisponibles.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea asignar este permiso?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mantenimiento.CLS.Permiso permiso = new Mantenimiento.CLS.Permiso();
                        permiso.IdRol = int.Parse(cmbRol.SelectedValue.ToString());
                        permiso.IdComando = int.Parse(dgvPermisosDisponibles.CurrentRow.Cells["idComandoDisponible"].Value.ToString());
                        permiso.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd");

                        if (permiso.Insertar())
                        {
                            MessageBox.Show("¡Permiso asignado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPermisoDiponibles();
                            CargarPermisosOtorgados();
                        }
                        else
                        {
                            MessageBox.Show("¡Ocurrio un problema al asignar este permiso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatosOtorgados.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea remover este permiso?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mantenimiento.CLS.Permiso permiso = new Mantenimiento.CLS.Permiso();
                        permiso.IdRol = int.Parse(cmbRol.SelectedValue.ToString());
                        permiso.IdComando = int.Parse(dgvDatosOtorgados.CurrentRow.Cells["idComandoOtorgado"].Value.ToString());
                        if (permiso.Eliminar())
                        {
                            MessageBox.Show("¡Permiso removido con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPermisoDiponibles();
                            CargarPermisosOtorgados();
                        }
                        else
                        {
                            MessageBox.Show("¡Ocurrio un problema al remover este permiso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
