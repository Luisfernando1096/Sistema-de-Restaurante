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
    public partial class BuscarProducto : Form
    {
        public int IDProducto { get; set; }
        public string NombreProducto { get; set; }

        BindingSource datos = new BindingSource();
        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.VerProductos();
                dgvProductos.DataSource = datos;
                dgvProductos.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarProductos()
        {
            try
            {
                // Obtener los datos
                DataTable familia = DataManager.DBConsultas.ListaProductos();

                // Crear un nuevo DataTable con la estructura
                DataTable dt = familia.Clone();

                // Agregar la fila de "Seleccione" al nuevo DataTable
                dt.Rows.Add(0, "Selecionar");

                // Fusionar los datos de categoría con el nuevo DataTable
                dt.Merge(familia);

                // Asignar el origen de datos al ComboBox
                cmbLista.DataSource = dt;
                cmbLista.DisplayMember = "nombre";
                cmbLista.ValueMember = "idProducto";
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarFamilia()
        {
            try
            {
                // Obtener los datos
                DataTable familia = DataManager.DBConsultas.VerFamilia();

                // Crear un nuevo DataTable con la estructura
                DataTable dt = familia.Clone();

                // Agregar la fila de "Seleccione" al nuevo DataTable
                dt.Rows.Add(0, "Selecionar");

                // Fusionar los datos de categoría con el nuevo DataTable
                dt.Merge(familia);

                // Asignar el origen de datos al ComboBox
                cmbLista.DataSource = dt;
                cmbLista.DisplayMember = "familia";
                cmbLista.ValueMember = "idFamilia";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* private void BuscarDatos() 
           {
               try
               {
                   if (rbtnProducto.Checked == true)
                   {
                       if (txtBuscar.Text != "")
                       {
                           dgvProductos.CurrentCell = null;
                           foreach (DataGridViewRow r in dgvProductos.Rows)
                           {
                               r.Visible = false;
                           }
                           foreach (DataGridViewRow r in dgvProductos.Rows)
                           {

                               if (r.Cells["nombre"].Value.ToString().ToUpper().IndexOf(txtBuscar.Text.ToUpper()) == 0)
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
                   else if (rbtnFamilia.Checked == true)
                   {
                       if (txtBuscar.Text != "")
                       {
                           dgvProductos.CurrentCell = null;
                           foreach (DataGridViewRow r in dgvProductos.Rows)
                           {
                               r.Visible = false;
                           }
                           foreach (DataGridViewRow r in dgvProductos.Rows)
                           {

                               if (r.Cells["familia"].Value.ToString().ToUpper().IndexOf(txtBuscar.Text.ToUpper()) == 0)
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
                if (rbtnProducto.Checked == true)
                {
                    if (cmbLista.Text != "")
                    {
                        dgvProductos.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvProductos.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvProductos.Rows)
                        {
                            if (r.Cells["Nombre"].Value.ToString().ToUpper().IndexOf(cmbLista.Text.ToUpper()) == 0)
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
                else if (rbtnFamilia.Checked == true)
                {
                    if (cmbLista.Text != "")
                    {
                        dgvProductos.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvProductos.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvProductos.Rows)
                        {
                            if (r.Cells["familia"].Value.ToString().ToUpper().IndexOf(cmbLista.Text.ToUpper()) == 0)
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
        public BuscarProducto()
        {
            InitializeComponent();
            KeyPreview = true; // Habilitar la captura de teclas en el formulario
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            int desiredWidth = 1200; // Establece el ancho deseado para el formulario
            this.Width = desiredWidth;

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
            CargarDatos();
            rbtNinguno.Checked = true;
        }

        private void dgvProductos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BuscarDatosEnCombo();
        }

        private void rbtnProducto_CheckedChanged(object sender, EventArgs e)
        {
            CargarProductos();
            cmbLista.Visible = true;
        }

        private void rbtnFamilia_CheckedChanged(object sender, EventArgs e)
        {
            CargarFamilia();
            cmbLista.Visible = true;
        }

        private void bntSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count != 0)
            {
                IDProducto = int.Parse(dgvProductos.CurrentRow.Cells["ID"].Value.ToString());
                NombreProducto = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Producto.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        private void BuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvProductos.SelectedRows.Count != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // Suprimir la acción predeterminada del Enter (como insertar un salto de línea)
                    bntSelecionar.PerformClick(); // Ejecutar el evento Click del botón
                }
            }
        }
    }
}
