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
    public partial class Asignar_roles : Form
    {
        public Asignar_roles()
        {
            InitializeComponent();
        }
        BindingSource _DATOS = new BindingSource();

        private void CargarRoles()
        {
            DataTable Roles = new DataTable();
            try
            {
                Roles = DataManager.DBConsultas.Roles();
                cmbRol.DataSource = Roles;
                cmbRol.DisplayMember = "rol";
                cmbRol.ValueMember = "idRol";
            }
            catch (Exception)
            {

            }
        }

        private void CargarUsuarionSin()
        {
            try
            {
                _DATOS.DataSource = DataManager.DBConsultas.UsuariosSinRol();
                dgtUsuarioSin.AutoGenerateColumns = false;
                dgtUsuarioSin.DataSource = _DATOS;
            }
            catch (Exception)
            {

            }
        }

        private void CargarUsuarioRol()
        {
            DataTable usuariosRol = new DataTable();
            String pIDRol = cmbRol.SelectedValue.ToString();
            try
            {
                usuariosRol = DataManager.DBConsultas.UsuariosSegunRol(pIDRol);
                dgtUsuariosRol.AutoGenerateColumns = false;
                dgtUsuariosRol.DataSource = usuariosRol;

            }
            catch (Exception)
            {

            }
        }

        private void Asignar_roles_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarUsuarionSin();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbRol_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarUsuarioRol();
        }

        private void btnEnrolar_Click(object sender, EventArgs e)
        {
            HacerVisiblesCampos();
        }

        private void HacerVisiblesCampos()
        {
            lblIdEmpleado.Text = dgtUsuarioSin.CurrentRow.Cells["idEmpleado"].Value.ToString();
            lblIdEmpleado.Visible = true;
            lblNombre.Text = dgtUsuarioSin.CurrentRow.Cells["Empleado"].Value.ToString();
            lblNombre.Visible = true;

            lblPin.Visible = true;
            lblRepetirPin.Visible = true;
            txtPin.Visible = true;
            txtPinRepetido.Visible = true;
            btnGuardar.Visible = true;
        }

        private void OcultarCampos()
        {
            lblIdEmpleado.Text = "";
            lblIdEmpleado.Visible = false;
            lblNombre.Text = "";
            lblNombre.Visible = false;

            lblPin.Visible = false;
            lblRepetirPin.Visible = false;
            txtPin.Visible = false;
            txtPinRepetido.Visible = false;
            btnGuardar.Visible = false;
        }
    }
}
