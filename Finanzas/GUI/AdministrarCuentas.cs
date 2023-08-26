using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finanzas.GUI
{
    public partial class AdministrarCuentas : Form
    {
        BindingSource datos = new BindingSource();
        public void CargarDatos() 
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Cuentas();
                dgvDatos.DataSource = datos;
                dgvDatos.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LimpiarCampos() 
        {
            try
            {
                txtNombre.Text = string.Empty;
                txtNumero.Text = string.Empty;
                txtSaldo.Text = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public AdministrarCuentas()
        {
            InitializeComponent();
        }

        private void AdministrarCuentas_Load(object sender, EventArgs e)
        {
            CargarDatos();
            txtSaldo.Text = "0";
            
        }

        private void btnSalirIngrediente_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mantenimiento.CLS.Cuenta cuenta = new Mantenimiento.CLS.Cuenta();
                        cuenta.IdCuenta = int.Parse(dgvDatos.CurrentRow.Cells["idCuenta"].Value.ToString());

                        if (cuenta.Eliminar())
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
            try
            {
                if (dgvDatos.SelectedRows.Count > 0)
                {
                    Mantenimiento.CLS.Cuenta cuenta = new Mantenimiento.CLS.Cuenta();
                    if (MessageBox.Show("¿Esta seguro que desea editar este registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtIdCuenta.Text = dgvDatos.CurrentRow.Cells["idCuenta"].Value.ToString();
                        txtNombre.Text = dgvDatos.CurrentRow.Cells["nombreCuenta"].Value.ToString();
                        txtNumero.Text = dgvDatos.CurrentRow.Cells["numero"].Value.ToString();
                        txtSaldo.Text = dgvDatos.CurrentRow.Cells["Saldo"].Value.ToString();
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
                if (txtNombre.Text == string.Empty || txtNumero.Text == string.Empty || txtSaldo.Text == string.Empty)
                {
                    MessageBox.Show("¡Por favor asegurese de llenar todos los campos necesarios!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Mantenimiento.CLS.Cuenta cuenta = new Mantenimiento.CLS.Cuenta();
                    cuenta.NombreCuenta = txtNombre.Text;
                    cuenta.Numero = txtNumero.Text;
                    cuenta.Saldo = double.Parse(txtSaldo.Text);

                    if (txtIdCuenta.Text == "")
                    {
                        if (cuenta.Insertar())
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
                        cuenta.IdCuenta = int.Parse(txtIdCuenta.Text);

                        if (cuenta.Actualizar())
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
