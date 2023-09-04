using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salones.GUI
{
    public partial class SalonesMesas : Form
    {
        BindingSource datos = new BindingSource();

        public SalonesMesas()
        {
            InitializeComponent();
        }
        private void CargarDatos() {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Mesas();
                dgvDatos.DataSource = datos;
                dgvDatos.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LimpiarCampos() {
            try
            {
                cmbSalones.Text = string.Empty;
                txtNumeroMesa.Text = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ListaSalones()
        {
            try
            {
                // Obtener los datos
                DataTable salon = DataManager.DBConsultas.Salones();

                // Crear un nuevo DataTable con la estructura
                DataTable dt = salon.Clone();

                // Fusionar los datos de categoría con el nuevo DataTable
                dt.Merge(salon);

                // Asignar el origen de datos al ComboBox
                cmbSalones.DataSource = dt;
                cmbSalones.DisplayMember = "nombre";
                cmbSalones.ValueMember = "idSalon";
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void compararDatos() {
            try
            {
                dgvDatos.CurrentCell = null;
                int contador = 0;
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    item.Visible = false;

                    if (item.Cells["nomSalon"].Value.ToString() == cmbSalones.Text)
                    {
                        item.Visible = true;
                        txtNumeroMesa.Text = item.Cells["nMesas"].Value.ToString();
                        txtID.Text = item.Cells["idSalon"].Value.ToString();

                        contador = contador+1;
                    }
                }
                txtContador.Text = "Mesas encontradas " + contador;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        private void SalonesMesas_Load(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnLimpiar.Visible = false;
            btnEliminar.Visible = false;
            CargarDatos();
            ListaSalones();
            compararDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cmbSalones.Text != string.Empty )
            {
                btnGuardar.Visible = true;
                btnEditar.Visible = false;
                btnCancelar.Visible = true;
                btnLimpiar.Visible = true;
                btnEliminar.Visible = true;

                btnNuevo.Visible = false;
                cmbSalones.DropDownStyle = ComboBoxStyle.Simple;
                txtNumeroMesa.Enabled = true;
            }
            else
            {
                MessageBox.Show("¡No hay datos disponibles!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnEditar.Visible = true;
            btnNuevo.Visible = true;
            btnCancelar.Visible = false;
            btnLimpiar.Visible = false;
            btnEliminar.Visible = false;

            LimpiarCampos();
            cmbSalones.DropDownStyle = ComboBoxStyle.DropDownList;
            txtNumeroMesa.Enabled = false;

            ListaSalones();
            CargarDatos();
            compararDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void cmbSalones_SelectedIndexChanged(object sender, EventArgs e)
        {
            compararDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            btnCancelar.Visible = true;
            btnEditar.Visible = false;
            btnGuardar.Visible = true;
            btnLimpiar.Visible = true;
            btnEliminar.Visible = false;

            txtNumeroMesa.Enabled = true;
            cmbSalones.ValueMember = string.Empty;
            cmbSalones.DropDownStyle = ComboBoxStyle.Simple;

            btnNuevo.Visible = false;
            txtContador.Text = "Mesas encontradas " + 0;

            dgvDatos.DataSource = new BindingSource();

            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeroMesa.Text == "" || cmbSalones.Text == "" )
                {
                    MessageBox.Show("¡Por favor asegurese de llenar todos los campos necesarios!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.SelectedRows.Count > 0)
                {

                }
                else
                {
                    MessageBox.Show("¡No hay datos selecionados!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
