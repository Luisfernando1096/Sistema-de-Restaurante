using System;
using System.Windows.Forms;

namespace Personal.GUI
{
    public partial class EmpleadosGestion : Form
    {
        BindingSource _DATOS = new BindingSource();
        Boolean EdicionMode = false;
        private void CargarDatos()
        {
            try
            {
                _DATOS.DataSource = DataManager.DBConsultas.Empleados();
                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.DataSource = _DATOS;
            }
            catch (Exception)
            {

            }
        }
        public EmpleadosGestion()
        {
            InitializeComponent();
        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpleadosGestion_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (EdicionMode)
            {
                Mantenimiento.CLS.Empleado Epl = new Mantenimiento.CLS.Empleado();
                Epl.IdEmpleado = int.Parse(txtIdEmpleado.Text);
                Epl.Nombres = txtNombres.Text.ToString();
                Epl.Apellidos = txtApellidos.Text.ToString();
                Epl.Telefono = txtTelefono.Text.ToString();
                Epl.Email = txtEmail.Text.ToString();
                Epl.Dui = txtDUI.Text.ToString();
                Epl.SueldoBase = Convert.ToDouble(txtSueldoBase.Text);
                Epl.Comision = Convert.ToDouble(txtComision.Text);
                Epl.Direccion = txtDireccion.Text.ToString();
                Epl.Nit = txtNIT.Text.ToString();
                Epl.Activo = chkActivo.Checked;
                String regg = "12323455";
                Epl.RegContable = regg;
                if (Epl.Actualizar())
                {
                    MessageBox.Show("Actualizacion Exitosa");
                    txtIdEmpleado.Clear();
                    txtNombres.Clear();
                    txtApellidos.Clear();
                    txtDireccion.Clear();
                    txtEmail.Clear();
                    txtTelefono.Clear();
                    txtDUI.Clear();
                    txtNIT.Clear();
                    txtSueldoBase.Clear();
                    txtComision.Clear();
                    CargarDatos();
                    EdicionMode = false;
                }
                else
                {
                    MessageBox.Show("Actualizacion Fallida");
                }
            }
            else
            {
                Mantenimiento.CLS.Empleado Epl = new Mantenimiento.CLS.Empleado();
                Epl.Nombres = txtNombres.Text.ToString();
                Epl.Apellidos = txtApellidos.Text.ToString();
                Epl.Direccion = txtDireccion.Text.ToString();
                Epl.Email = txtEmail.Text.ToString();
                Epl.Telefono = txtTelefono.Text.ToString();
                Epl.Dui = txtDUI.Text.ToString();
                Epl.Nit = txtNIT.Text.ToString();
                Epl.SueldoBase = Convert.ToDouble(txtSueldoBase.Text);
                Epl.Comision = Convert.ToDouble(txtComision.Text);
                String regg = "12323455";
                Epl.RegContable = regg;
                Epl.Activo = chkActivo.Checked;

                if (Epl.Insertar())
                {
                    MessageBox.Show("RegistroExitoso");
                    txtIdEmpleado.Clear();
                    txtNombres.Clear();
                    txtApellidos.Clear();
                    txtDireccion.Clear();
                    txtEmail.Clear();
                    txtTelefono.Clear();
                    txtDUI.Clear();
                    txtNIT.Clear();
                    txtSueldoBase.Clear();
                    txtComision.Clear();
                    CargarDatos();

                }
                else
                {
                    MessageBox.Show("RegistoFracaso");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (EdicionMode)
            {
                EdicionMode = false;
            }
            txtIdEmpleado.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDUI.Clear();
            txtNIT.Clear();
            txtSueldoBase.Clear();
            txtComision.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Mantenimiento.CLS.Empleado Epl = new Mantenimiento.CLS.Empleado();
            Epl.IdEmpleado = Convert.ToInt32(dgvDatos.CurrentRow.Cells["idEmpleado"].Value);
            if (Epl.Eliminar())
            {
                MessageBox.Show("Eliminacion Exitosa");
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Eliminacion Fallida");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EdicionMode = true;
            txtIdEmpleado.Text = dgvDatos.CurrentRow.Cells["idEmpleado"].Value.ToString();
            txtNombres.Text = dgvDatos.CurrentRow.Cells["nombres"].Value.ToString();
            txtApellidos.Text = dgvDatos.CurrentRow.Cells["apellidos"].Value.ToString();
            txtTelefono.Text = dgvDatos.CurrentRow.Cells["telefono"].Value.ToString();
            txtEmail.Text = dgvDatos.CurrentRow.Cells["email"].Value.ToString();
            txtDUI.Text = dgvDatos.CurrentRow.Cells["DUI"].Value.ToString();
            txtSueldoBase.Text = dgvDatos.CurrentRow.Cells["sueldoBase"].Value.ToString();
            txtComision.Text = dgvDatos.CurrentRow.Cells["comision"].Value.ToString();
            txtDireccion.Text = dgvDatos.CurrentRow.Cells["comision"].Value.ToString();
            txtNIT.Text = dgvDatos.CurrentRow.Cells["NIT"].Value.ToString();
            chkActivo.Checked = Boolean.Parse(dgvDatos.CurrentRow.Cells["activo"].Value.ToString());

        }
    }
}
