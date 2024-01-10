using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingredientes_y_Productos.GUI
{
    public partial class BuscarIngrediente : Form
    {
        public int IDIngrediente { get; set; }
        public string NombreIngrediente { get; set; }
        public string CantidadInicial { get; private set; }

        readonly BindingSource datos = new BindingSource();
        private void CargarDatos() 
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.VerIngrediente();
                dgvBuscarIngrediente.DataSource = datos;
                dgvBuscarIngrediente.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarListaIngrediente()
        {
            try
            {
                // Obtener los datos
                DataTable familia = DataManager.DBConsultas.VerIngrediente();

                // Crear un nuevo DataTable con la estructura
                DataTable dt = familia.Clone();

                // Agregar la fila de "Seleccione" al nuevo DataTable
                dt.Rows.Add(0, "Selecionar");

                // Fusionar los datos de categoría con el nuevo DataTable
                dt.Merge(familia);

                // Asignar el origen de datos al ComboBox
                cmbLista.DataSource = dt;
                cmbLista.DisplayMember = "nombre";
                cmbLista.ValueMember = "idIngrediente";
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarPresentacion()
        {
            try
            {
                // Obtener los datos
                DataTable presentacion = DataManager.DBConsultas.VerUnidad();

                // Crear un nuevo DataTable con la estructura
                DataTable dt = presentacion.Clone();

                // Agregar la fila de "Seleccione" al nuevo DataTable
                dt.Rows.Add(0, "Selecionar");

                // Fusionar los datos de categoría con el nuevo DataTable
                dt.Merge(presentacion);

                // Asignar el origen de datos al ComboBox
                cmbLista.DataSource = dt;
                cmbLista.DisplayMember = "unidadMedida";
                cmbLista.ValueMember = "idUnidad";
            }
            catch (Exception)
            {
                throw;
            }
        }

       /*private void BuscarDatos()
        {
            try
            {
                if (rbtnIngrediente.Checked == true)
                {
                    if (txtBuscar.Text != "")
                    {
                        dgvBuscarIngrediente.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {

                            if (r.Cells["nombreIngrediente"].Value.ToString().ToUpper().IndexOf(txtBuscar.Text.ToUpper()) == 0)
                            {
                                r.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        CargarDatos();
                    }
                }
                else if (rbtnPresentacion.Checked == true)
                {
                    if (txtBuscar.Text != "")
                    {
                        dgvBuscarIngrediente.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {

                            if (r.Cells["Presentacion"].Value.ToString().ToUpper().IndexOf(txtBuscar.Text.ToUpper()) == 0)
                            {
                                r.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        CargarDatos();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }*/

        private void BuscarDatosEnCombo()
        {
            try
            {
                if (rbtnIngrediente.Checked == true)
                {
                    if (cmbLista.Text != "")
                    {
                        dgvBuscarIngrediente.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {
                            if (r.Cells["nombreIngrediente"].Value.ToString().ToUpper().IndexOf(cmbLista.Text.ToUpper()) == 0)
                            {
                                r.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        CargarDatos();
                    }
                }
                else if (rbtnPresentacion.Checked == true)
                {
                    if (cmbLista.Text != "")
                    {
                        dgvBuscarIngrediente.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {
                            if (r.Cells["Presentacion"].Value.ToString().ToUpper().IndexOf(cmbLista.Text.ToUpper()) == 0)
                            {
                                r.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        CargarDatos();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BuscarIngrediente()
        {
            InitializeComponent();
            KeyPreview = true; // Habilitar la captura de teclas en el formulario
        }

        private void BuscarIngrediente_Load(object sender, EventArgs e)
        {
            int desiredWidth = 1100; // Establece el ancho deseado para el formulario
            this.Width = desiredWidth;

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
            CargarDatos();
            rbtNinguno.Checked = true;
        }

        private void rbtnIngrediente_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaIngrediente();
            cmbLista.Visible = true;
        }

        private void rbtnPresentacion_CheckedChanged(object sender, EventArgs e)
        {
            CargarPresentacion();
            cmbLista.Visible = true;
        }

        private void dgvBuscarIngrediente_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BuscarDatosEnCombo();
        }


        private void cmbLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarDatosEnCombo();
        }

        private void rbtNinguno_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
            cmbLista.Visible = false;
        }

        private void dgvBuscarIngrediente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBuscarIngrediente.SelectedRows.Count != 0)
            {
                IDIngrediente = int.Parse(dgvBuscarIngrediente.CurrentRow.Cells["ID"].Value.ToString());
                NombreIngrediente = dgvBuscarIngrediente.CurrentRow.Cells["nombreIngrediente"].Value.ToString();
                CantidadInicial = dgvBuscarIngrediente.CurrentRow.Cells["Stock"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Ingrediente.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
