﻿using System;
using System.Data;
using System.Windows.Forms;

namespace Ingredientes_y_Productos.GUI
{
    public partial class BuscarProducto : Form
    {
        public int IDProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadInicial { get; set; }

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
        private void CargarProductos(String nombre)
        {
            try
            {
                // Obtener los datos
                DataTable familia = DataManager.DBConsultas.ListaProductos();

                
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarFamilia(String nombre)
        {
            try
            {
                // Obtener los datos
                DataTable familia = DataManager.DBConsultas.VerFamilia();

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
                    if (txtNombre.Text != "")
                    {
                        dgvProductos.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvProductos.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvProductos.Rows)
                        {
                            if (r.Cells["Nombre"].Value.ToString().ToUpper().IndexOf(txtNombre.Text.ToUpper()) == 0)
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
                    if (txtNombre.Text != "")
                    {
                        dgvProductos.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvProductos.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvProductos.Rows)
                        {
                            if (r.Cells["familia"].Value.ToString().ToUpper().IndexOf(txtNombre.Text.ToUpper()) == 0)
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
            CargarProductos("");
            txtNombre.Visible = true;
        }

        private void rbtnFamilia_CheckedChanged(object sender, EventArgs e)
        {
            CargarFamilia("");
            txtNombre.Visible = true;
        }

        private void rbtNinguno_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
            txtNombre.Visible = false;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.SelectedRows.Count != 0)
            {
                IDProducto = int.Parse(dgvProductos.CurrentRow.Cells["ID"].Value.ToString());
                NombreProducto = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                CantidadInicial = int.Parse(dgvProductos.CurrentRow.Cells["stock"].Value.ToString());

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Producto.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            BuscarDatosEnCombo();
        }
    }
}
