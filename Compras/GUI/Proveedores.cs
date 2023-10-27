using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compras.GUI
{
    public partial class Proveedores : Form
    {
        BindingSource datos = new BindingSource();
        private void CargarDatos() {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Proveedor();
                dgvProveedor.DataSource = datos;
                dgvProveedor.AutoGenerateColumns = false;

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LimpiarCampos()
        {
            try
            {
                txtNombre.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtNrc.Text = string.Empty;
                txtNit.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtContacto.Text = string.Empty;
                txtDireccion.Text = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BuscarDatos() 
        {
            try
            {
                dgvProveedor.CurrentCell = null;
                foreach (DataGridViewRow r in dgvProveedor.Rows)
                {
                    r.Visible = false;
                    string Valor = r.Cells["nombre"].Value.ToString().ToUpper();
                    if ((Valor.StartsWith(txtFiltrar.Text, StringComparison.OrdinalIgnoreCase)))
                    {
                        r.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Proveedores()
        {
            InitializeComponent();
        }


        private void Proveedores_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProveedor.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mantenimiento.CLS.Proveedor mantenimiento = new Mantenimiento.CLS.Proveedor();
                        mantenimiento.IdProveedor = int.Parse(dgvProveedor.CurrentRow.Cells["idProveedor"].Value.ToString());

                        if (mantenimiento.Eliminar())
                        {
                            MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                            txtIdProveedor.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("¡El registro no fue eliminado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    CargarDatos();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProveedor.SelectedRows.Count > 0)
                {
                    Mantenimiento.CLS.Proveedor mantenimiento = new Mantenimiento.CLS.Proveedor();
                    if (MessageBox.Show("¿Esta seguro que desea editar este registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtIdProveedor.Text = dgvProveedor.CurrentRow.Cells["idProveedor"].Value.ToString();
                        txtNombre.Text = dgvProveedor.CurrentRow.Cells["nombre"].Value.ToString();
                        txtEmail.Text = dgvProveedor.CurrentRow.Cells["email"].Value.ToString();
                        txtTelefono.Text = dgvProveedor.CurrentRow.Cells["telefono"].Value.ToString();
                        txtNrc.Text = dgvProveedor.CurrentRow.Cells["regContable"].Value.ToString();
                        txtNit.Text = dgvProveedor.CurrentRow.Cells["nit"].Value.ToString();
                        txtContacto.Text = dgvProveedor.CurrentRow.Cells["contacto"].Value.ToString();
                        txtDireccion.Text = dgvProveedor.CurrentRow.Cells["direccion"].Value.ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != string.Empty & txtEmail.Text != string.Empty & txtTelefono.Text != string.Empty & txtNrc.Text != string.Empty)
                {
                    Mantenimiento.CLS.Proveedor mantenimiento = new Mantenimiento.CLS.Proveedor();
                    mantenimiento.Nombre = txtNombre.Text;
                    mantenimiento.Direccion = txtDireccion.Text;
                    mantenimiento.Email = txtEmail.Text;
                    mantenimiento.Telefono = txtTelefono.Text;
                    mantenimiento.Nit = txtNit.Text;
                    mantenimiento.RegContable = txtNrc.Text;
                    mantenimiento.Contacto = txtContacto.Text;

                    if (txtIdProveedor.Text == string.Empty)
                    {
                        if (mantenimiento.Insertar())
                        {
                            MessageBox.Show("¡Registro insertado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("¡Error al insertar registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        mantenimiento.IdProveedor = int.Parse(txtIdProveedor.Text);
                        if (mantenimiento.Actualizar())
                        {
                            MessageBox.Show("¡Registro actualizado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("¡Error al actualizar el registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        CargarDatos();
                        txtIdProveedor.Text = string.Empty;
                    }
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("¡Asegurese de llenar todos los campos necesarios!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void dgvProveedor_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BuscarDatos();
        }
    }
}
