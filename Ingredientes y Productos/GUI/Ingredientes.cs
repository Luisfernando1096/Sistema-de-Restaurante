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
    public partial class Ingredientes : Form
    {
        public int IdProducto;
        public string NombreProducto;
        BindingSource datosIgredientes = new BindingSource();
        BindingSource datosUnidad = new BindingSource();
        Boolean variable = false;

        public void CargarDatos() 
        {
            try
            {
                datosIgredientes.DataSource = DataManager.DBConsultas.VerIngrediente();
                dgvIngredientes.DataSource = datosIgredientes;
                dgvIngredientes.AutoGenerateColumns = false;

                datosUnidad.DataSource = DataManager.DBConsultas.VerUnidad();
                dgvUnidad.DataSource = datosUnidad;
                dgvUnidad.AutoGenerateColumns = false;
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
        private void CargarListaPresentacion()
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
        private void BuscarDatosEnCombo()
        {
            try
            {
                if (rbtnIngrediente.Checked == true)
                {
                    if (cmbLista.Text != "")
                    {
                        dgvIngredientes.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvIngredientes.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvIngredientes.Rows)
                        {
                            if (r.Cells["nombre"].Value.ToString().ToUpper().IndexOf(cmbLista.Text.ToUpper()) == 0)
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
                        dgvIngredientes.CurrentCell = null;
                        foreach (DataGridViewRow r in dgvIngredientes.Rows)
                        {
                            r.Visible = false;
                        }
                        foreach (DataGridViewRow r in dgvIngredientes.Rows)
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
        /// METODOS PARA INGREDIENTES
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
                cmPresentacion.DataSource = dt;
                cmPresentacion.DisplayMember = "unidadMedida";
                cmPresentacion.ValueMember = "idUnidad";
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LimpiarCamposIngredientes()
        {
            try
            {
                txtIDIngrediente.Text = string.Empty;
                txtNombreIngrediente.Text = string.Empty;
                cmPresentacion.SelectedIndex = 0;
                txtStockIngrediente.Text = string.Empty;
                txtPrecioIngrediente.Text = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// METODOS PARA RECETAS 
        private void LimpiarCamposReceta() 
        {
            try
            {
                txtIDProducto.Text = string.Empty;
                txtNombreProducto.Text = string.Empty;
                txtID.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtCantidad.Text = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LimpiarTextBox()
        {
            // Limpiar el contenido de los TextBox
            txtID.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "";
        }
        private bool ExisteIDEnDataGridView(string idBuscar)
        {
            foreach (DataGridViewRow row in dgvReceta.Rows)
            {
                string idExistente = row.Cells["idIngredienteReceta"].Value.ToString();

                if (idBuscar == idExistente)
                {
                    return true;
                }
            }

            return false;
        }
        /// METODOS PARA UNIDAD DE MEDIDA
        private void LimpiarTextBoxUnidad() 
        {
            try
            {
                txtIDUnidad.Text = "";
                txtPresentacion.Text = "";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Ingredientes()
        {
            InitializeComponent();
        }

        private void Ingredientes_Load(object sender, EventArgs e)
        {
            int desiredWidth = 1100; // Establece el ancho deseado para el formulario
            this.Width = desiredWidth;

            // Centrar el formulario en la pantalla CargarDatos();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
            CargarDatos();
            CargarPresentacion();
            rbtNinguno.Checked = true;
        }

        private void btnSalirIngrediente_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntSalirReceta_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntSalirUnidad_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarProducto f = new BuscarProducto();
            f.bntSelecionar.Visible = true;
            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtIDProducto.Text = f.IDProducto.ToString();
                txtNombreProducto.Text = f.NombreProducto;
            }
        }

        private void btnBuscarIngrediente_Click(object sender, EventArgs e)
        {
            BuscarIngrediente f = new BuscarIngrediente();
            f.bntSelecionar.Visible = true;
            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtID.Text = f.IDIngrediente.ToString();
                txtNombre.Text = f.NombreIngrediente;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposIngredientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreIngrediente.Text == "" || txtStockIngrediente.Text == "" || txtPrecioIngrediente.Text == "")
                {
                    MessageBox.Show("¡Por favor asegurese de llenar todos los campos necesarios!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (cmPresentacion.SelectedIndex != 0)
                    {
                        Mantenimiento.CLS.Ingrediente mantenimiento = new Mantenimiento.CLS.Ingrediente();
                        mantenimiento.Nombre = txtNombreIngrediente.Text;
                        mantenimiento.IdUnidad = int.Parse(cmPresentacion.SelectedValue.ToString());
                        mantenimiento.Stock = decimal.Parse(txtStockIngrediente.Text);
                        mantenimiento.Precio = decimal.Parse(txtPrecioIngrediente.Text);

                        if (txtIDIngrediente.Text == "")
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
                            mantenimiento.IdIngrediente = int.Parse(txtIDIngrediente.Text);

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
                        LimpiarCamposIngredientes();
                    }
                    else
                    {
                        MessageBox.Show("¡Por favor seleccione la presentacion!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvIngredientes.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mantenimiento.CLS.Ingrediente mantenimiento = new Mantenimiento.CLS.Ingrediente();
                        mantenimiento.IdIngrediente = int.Parse(dgvIngredientes.CurrentRow.Cells["idIngrediente"].Value.ToString());

                        if (mantenimiento.Eliminar())
                        {
                            MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCamposIngredientes();
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
                if (dgvIngredientes.SelectedRows.Count > 0)
                {
                    Mantenimiento.CLS.Ingrediente mantenimiento = new Mantenimiento.CLS.Ingrediente();
                    if (MessageBox.Show("¿Esta seguro que desea editar este registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtIDIngrediente.Text = dgvIngredientes.CurrentRow.Cells["idIngrediente"].Value.ToString();
                        txtNombreIngrediente.Text = dgvIngredientes.CurrentRow.Cells["nombre"].Value.ToString();
                        cmPresentacion.Text = dgvIngredientes.CurrentRow.Cells["Presentacion"].Value.ToString();
                        txtStockIngrediente.Text = dgvIngredientes.CurrentRow.Cells["Stock"].Value.ToString();
                        txtPrecioIngrediente.Text = dgvIngredientes.CurrentRow.Cells["Precio"].Value.ToString();
                    }
                }   
            }
            catch (Exception)
            {
                throw;
            }
        }

 
        private void dgvIngredientes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BuscarDatosEnCombo();
        }

        private void btnLimpiarReceta_Click(object sender, EventArgs e)
        {
            LimpiarCamposReceta();
            lblCantidad.Text = "Cantidad (3 digitos maximo)";
            btnBuscarIngrediente.Text = "Buscar Ingrediente";
            btnGuardarReceta.Enabled = true;
        }

        private void btnGuardarReceta_Click(object sender, EventArgs e)
        {
            Boolean resultado = false;
            int filas = 0;
            try
            {
                if (txtIDProducto.Text == "" || txtNombreProducto.Text == "")
                {
                    MessageBox.Show("¡Debe seleccionar un producto!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    Mantenimiento.CLS.IngredienteProducto mantenimiento = new Mantenimiento.CLS.IngredienteProducto();
                    mantenimiento.IdProducto = int.Parse(txtIDProducto.Text);
                    foreach (DataGridViewRow item in dgvReceta.Rows)
                    {
                        mantenimiento.IdIngrediente = int.Parse(item.Cells["idIngredienteReceta"].Value.ToString());
                        mantenimiento.Cantidad = int.Parse(item.Cells["cantidad"].Value.ToString());
                        if (mantenimiento.Insertar())
                        {
                            resultado = true;
                            filas = filas + 1;
                        }
                    }
                }
                if (resultado)
                {
                    MessageBox.Show(filas + " ¡registros insertados correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvReceta.Rows.Clear();
                    txtIDProducto.Text = "";
                    txtNombreProducto.Text = "";
                } 
                else
                {
                    MessageBox.Show("¡Error al insertar registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void bntAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string idBuscar = txtID.Text;
                if (txtCantidad.Text == "" || txtID.Text == "")
                {
                    MessageBox.Show("¡Asegurse de llenar todos los campos necesario!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (variable)
                {
                    if (ExisteIDEnDataGridView(idBuscar))
                    {
                        // Actualizar los valores de la fila existente
                        foreach (DataGridViewRow row in dgvReceta.Rows)
                        {
                            string idExistente = row.Cells["idIngredienteReceta"].Value.ToString();

                            if (idBuscar == idExistente)
                            {
                                row.Cells["nombreReceta"].Value = txtNombre.Text;
                                row.Cells["cantidad"].Value = txtCantidad.Text;
                                break;
                            }
                        }
                        MessageBox.Show("¡El se ha modificado con exito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lblCantidad.Text = "Cantidad (3 dígitos máximo)";
                        btnBuscarIngrediente.Text = "Buscar Ingrediente";
                        btnGuardarReceta.Enabled = true;
                        LimpiarTextBox();
                        variable = false;
                    }
                }
                else
                {
                    if (ExisteIDEnDataGridView(idBuscar))
                    {
                        MessageBox.Show("¡El registro ya existe agregado, si desea cambiar sus datos por favor de click sobre editar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(dgvReceta);

                    fila.Cells[0].Value = txtID.Text;
                    fila.Cells[1].Value = txtNombre.Text;
                    fila.Cells[2].Value = txtCantidad.Text;

                    dgvReceta.Rows.Add(fila);

                    // Limpiar los TextBox después de agregar los datos
                    LimpiarTextBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarReceta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReceta.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dgvReceta.SelectedRows.Count != 0)
                        {
                            int rowIndex = dgvReceta.SelectedRows[0].Index;
                            dgvReceta.Rows.RemoveAt(rowIndex);
                            MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblCantidad.Text = "Cantidad (3 digitos maximo)";
                            btnBuscarIngrediente.Text = "Buscar Ingrediente";
                            btnGuardarReceta.Enabled = true;
                            LimpiarTextBox();
                        }
                        else
                        {
                            MessageBox.Show("¡El registro no fue eliminado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEditarReceta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReceta.SelectedRows.Count > 0)
                {
                    txtID.Text = dgvReceta.CurrentRow.Cells["idIngredienteReceta"].Value.ToString();
                    txtNombre.Text = dgvReceta.CurrentRow.Cells["nombreReceta"].Value.ToString();
                    txtCantidad.Text = dgvReceta.CurrentRow.Cells["cantidad"].Value.ToString();
                    btnBuscarIngrediente.Text = "Cambiar Ingrediente";
                    lblCantidad.Text = "Editar Cantidad(3 digitos Maximo)";
                    btnGuardarReceta.Enabled = false;
                    variable = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnLimpiarUnidad_Click(object sender, EventArgs e)
        {
            LimpiarTextBoxUnidad();
        }

        private void btnEliminarUnidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUnidad.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mantenimiento.CLS.UnidadMedida mantenimiento = new Mantenimiento.CLS.UnidadMedida();

                        mantenimiento.IdUnidad = int.Parse(dgvUnidad.CurrentRow.Cells["idUnidadMedida"].Value.ToString());
                        if (mantenimiento.Eliminar())
                        {
                            MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarTextBoxUnidad();
                        }
                        else
                        {
                            MessageBox.Show("¡El registro no fue eliminado, posiblemente contenga datos vincuados con este registro!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnEditarUnidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUnidad.SelectedRows.Count > 0)
                {
                    Mantenimiento.CLS.UnidadMedida mantenimiento = new Mantenimiento.CLS.UnidadMedida();
                    if (MessageBox.Show("¿Esta seguro que desea editar este registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtIDUnidad.Text = dgvUnidad.CurrentRow.Cells["idUnidadMedida"].Value.ToString();
                        txtPresentacion.Text = dgvUnidad.CurrentRow.Cells["unidadMedida"].Value.ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnGuardarUnidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPresentacion.Text == "")
                {
                    MessageBox.Show("¡El campo de presentacion es necesario!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Mantenimiento.CLS.UnidadMedida mantenimiento = new Mantenimiento.CLS.UnidadMedida();
                    mantenimiento.Unidad_Medida = txtPresentacion.Text;
                    if (txtIDUnidad.Text == "")
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
                        mantenimiento.IdUnidad = int.Parse(txtIDUnidad.Text);

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
                    LimpiarTextBoxUnidad();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void rbtnIngrediente_CheckedChanged_1(object sender, EventArgs e)
        {
            CargarListaIngrediente();
            cmbLista.Visible = true;
        }

        private void rbtnPresentacion_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaPresentacion();
            cmbLista.Visible = true;
        }

        private void rbtNinguno_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatos();
            cmbLista.Visible = false;
        }

        private void cmbLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarDatosEnCombo();
        }

        private void txtPrecioIngrediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un número, un punto decimal o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Evita que se ingrese el carácter no permitido
            }

            // Verificar si ya se ha ingresado un punto decimal y se intenta ingresar otro
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true; // Evita que se ingrese el segundo punto decimal
            }
        }

        private void txtStockIngrediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un número, un punto decimal o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Evita que se ingrese el carácter no permitido
            }

            // Verificar si ya se ha ingresado un punto decimal y se intenta ingresar otro
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true; // Evita que se ingrese el segundo punto decimal
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}