using System;
using System.Data;
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
            if (dgtUsuarioSin.Rows.Count > 0)
            {
                HacerVisiblesCampos();
            }
            
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
            txtPin.Text = "";
            txtPin.Visible = false;
            txtPinRepetido.Text = "";
            txtPinRepetido.Visible = false;
            btnGuardar.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtPin.Text.ToString().Equals(txtPinRepetido.Text.ToString()))
            {
                //Es correcto, avanza
                if (txtPin.Text.ToString().Equals(""))
                {
                    MessageBox.Show("Debes agregar un pin valido");
                    return;
                }

                //Comprobar que el pin no se repita
                DataTable usuarios = DataManager.DBConsultas.UsuariosPin(txtPin.Text.ToString());
                if (usuarios.Rows.Count > 0)
                {
                    //Ya hay un pin en uso
                    MessageBox.Show("Ya hay un pin en uso");
                }
                else
                {
                    //Correcto crear usuario
                    Mantenimiento.CLS.Usuario usuario = new Mantenimiento.CLS.Usuario();
                    usuario.IdUsuario = Int32.Parse(lblIdEmpleado.Text.ToString());
                    usuario.PinCode = txtPin.Text.ToString();
                    usuario.IdRol = Int32.Parse(cmbRol.SelectedValue.ToString());
                    usuario.Insertar();
                    OcultarCampos();
                    CargarUsuarionSin();
                    CargarUsuarioRol();
                }
            }
            else
            {
                //No son iguales los pines
                MessageBox.Show("Los pines no coinciden");
            }
        }

        private void btnDesEnrolar_Click(object sender, EventArgs e)
        {
            if (dgtUsuariosRol.Rows.Count > 0)
            {
                Mantenimiento.CLS.Usuario usuario = new Mantenimiento.CLS.Usuario();
                usuario.IdUsuario = Int32.Parse(dgtUsuariosRol.CurrentRow.Cells["idEmpleadoRol"].Value.ToString());
                usuario.Eliminar();
                OcultarCampos();
                CargarUsuarionSin();
                CargarUsuarioRol();
            }
            
        }
    }
}
