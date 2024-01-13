using System;
using System.Windows.Forms;

namespace Compras.GUI
{
    public partial class TipoComprobante : Form
    {
        BindingSource datos = new BindingSource();
        public TipoComprobante()
        {
            InitializeComponent();
        }
        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Comprobante();
                dgvComprobante.DataSource = datos;
                dgvComprobante.AutoGenerateColumns = false;
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
                txtId.Text = string.Empty;
                txtTipo.Text = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TipoComprobante_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvComprobante.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mantenimiento.CLS.Comprobante mantenimiento = new Mantenimiento.CLS.Comprobante();
                        mantenimiento.IdComprobante = int.Parse(dgvComprobante.CurrentRow.Cells["idComprobante"].Value.ToString());

                        if (mantenimiento.Eliminar())
                        {
                            MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvComprobante.SelectedRows.Count > 0)
            {
                Mantenimiento.CLS.Comprobante mantenimiento = new Mantenimiento.CLS.Comprobante();
                if (MessageBox.Show("¿Esta seguro que desea editar este registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtId.Text = dgvComprobante.CurrentRow.Cells["idComprobante"].Value.ToString();
                    txtTipo.Text = dgvComprobante.CurrentRow.Cells["tipo"].Value.ToString();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTipo.Text == string.Empty)
                {
                    MessageBox.Show("¡Por favor asegurese de llenar todos los campos necesarios!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Mantenimiento.CLS.Comprobante mantenimiento = new Mantenimiento.CLS.Comprobante();
                    mantenimiento.Tipo = txtTipo.Text;

                    if (txtId.Text == string.Empty)
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
                        mantenimiento.IdComprobante = int.Parse(txtId.Text);

                        if (mantenimiento.Actualizar())
                        {
                            MessageBox.Show("¡Registro actualizado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("¡Error al actualizar el registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    LimpiarCampos();
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
    }
}
