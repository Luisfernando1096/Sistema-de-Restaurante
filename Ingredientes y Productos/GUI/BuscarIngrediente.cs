using System;
using System.Data;
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
                    if (txtNombre.Text != "")
                    {
                        dgvBuscarIngrediente.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {
                            if (r.Cells["nombreIngrediente"].Value.ToString().ToUpper().IndexOf(txtNombre.Text.ToUpper()) == 0)
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
                    if (txtNombre.Text != "")
                    {
                        dgvBuscarIngrediente.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvBuscarIngrediente.Rows)
                        {
                            if (r.Cells["Presentacion"].Value.ToString().ToUpper().IndexOf(txtNombre.Text.ToUpper()) == 0)
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
            txtNombre.Visible = true;
        }

        private void rbtnPresentacion_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Visible = true;
        }

        private void dgvBuscarIngrediente_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BuscarDatosEnCombo();
        }

        private void rbtNinguno_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
            txtNombre.Visible = false;
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            BuscarDatosEnCombo();
        }
    }
}
