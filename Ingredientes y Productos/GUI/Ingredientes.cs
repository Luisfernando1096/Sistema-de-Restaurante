using System;
using System.Data;
using System.Windows.Forms;

namespace Ingredientes_y_Productos.GUI
{
    public partial class Ingredientes : Form
    {
        public int IdProducto;
        public string NombreProducto;
        BindingSource datosIgredientes = new BindingSource();
        DataTable datos;
        BindingSource datosUnidad = new BindingSource();

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
                dgvReceta.DataSource = null;
                txtIDProducto.Text = string.Empty;
                txtNombreProducto.Text = string.Empty;
                txtID.Text = string.Empty;
                txtID.Tag = null;
                txtNombre.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                lblCantidad.Text = "Cantidad (3 decimales maximo)";
                btnBuscarIngrediente.Text = "Buscar Ingrediente";
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
            txtID.Tag = null;
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
            txtCantidad.KeyPress += txtCantidad_KeyPress;
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
            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtIDProducto.Text = f.IDProducto.ToString();
                txtNombreProducto.Text = f.NombreProducto;

                //De haber ingredientes se mostraran en el datagrid
                CargarIngredientesDeProducto(f.IDProducto.ToString());
            }


        }

        private void CargarIngredientesDeProducto(string idProd)
        {
            datos = DataManager.DBConsultas.IngredientesPorProducto(idProd);
            dgvReceta.DataSource = datos;
            dgvReceta.AutoGenerateColumns = false;
        }

        private void btnBuscarIngrediente_Click(object sender, EventArgs e)
        {
            BuscarIngrediente f = new BuscarIngrediente();
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
                        Mantenimiento.CLS.Ingrediente mantenimiento = new Mantenimiento.CLS.Ingrediente
                        {
                            Nombre = txtNombreIngrediente.Text,
                            IdUnidad = int.Parse(cmPresentacion.SelectedValue.ToString()),
                            Stock = decimal.Parse(txtStockIngrediente.Text),
                            Precio = decimal.Parse(txtPrecioIngrediente.Text)
                        };

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
                        Mantenimiento.CLS.Ingrediente mantenimiento = new Mantenimiento.CLS.Ingrediente
                        {
                            IdIngrediente = int.Parse(dgvIngredientes.CurrentRow.Cells["idIngrediente"].Value.ToString())
                        };

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

        }

        private void MantenimientoADataGridRecetas()
        {
            try
            {
                if (txtIDProducto.Text == "" || txtNombreProducto.Text == "")
                {
                    MessageBox.Show("¡Debe seleccionar un producto!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    Mantenimiento.CLS.IngredienteProducto mantenimiento = new Mantenimiento.CLS.IngredienteProducto
                    {
                        IdProducto = int.Parse(txtIDProducto.Text)
                    };

                    mantenimiento.IdIngrediente = Int32.Parse(txtID.Text);
                    mantenimiento.Cantidad = double.Parse(txtCantidad.Text);

                    if (txtID.Tag != null)
                    {
                        mantenimiento.Id = Int32.Parse(txtID.Tag.ToString());
                        if (mantenimiento.Actualizar())
                        {
                            //registro actualizados
                            CargarIngredientesDeProducto(txtIDProducto.Text);
                            MessageBox.Show("Registro actualizado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarTextBox();
                            lblCantidad.Text = "Cantidad (3 decimales maximo)";
                            btnBuscarIngrediente.Text = "Buscar Ingrediente";
                        }

                    }
                    else
                    {
                        if (!ExisteIDEnDataGridView(txtID.Text))
                        {
                            if (mantenimiento.Insertar())
                            {
                                //Registro isertado
                                CargarIngredientesDeProducto(txtIDProducto.Text);
                                MessageBox.Show("Registro insertado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarTextBox();
                                lblCantidad.Text = "Cantidad (3 decimales maximo)";
                                btnBuscarIngrediente.Text = "Buscar Ingrediente";
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar porque ya existe un ingrediente de esta clase.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void bntAgregar_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                MantenimientoADataGridRecetas();
            }
            else
            {
                MessageBox.Show("Asegurese de seleccionar el producto, el ingrediente y la cantidad.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private bool Validacion()
        {
            Boolean pasar = true;

            if (txtIDProducto.Text.ToString().Equals(""))
            {
                pasar = false;
            }
            if (txtNombreProducto.Text.ToString().Equals(""))
            {
                pasar = false;
            }
            if (txtID.Text.ToString().Equals(""))
            {
                pasar = false;
            }
            if (txtID.Text.ToString().Equals(""))
            {
                pasar = false;
            }
            if (txtNombre.Text.ToString().Equals(""))
            {
                pasar = false;
            }
            if (txtCantidad.Text.ToString().Equals(""))
            {
                pasar = false;
            }
            return pasar;
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
                            Mantenimiento.CLS.IngredienteProducto ingredienteEliminar = new Mantenimiento.CLS.IngredienteProducto();
                            ingredienteEliminar.Id = Int32.Parse(dgvReceta.CurrentRow.Cells["idIngProd"].Value.ToString());
                            if (ingredienteEliminar.Eliminar())
                            {

                                CargarIngredientesDeProducto(txtIDProducto.Text);
                                MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            lblCantidad.Text = "Cantidad (3 digitos maximo)";
                            btnBuscarIngrediente.Text = "Buscar Ingrediente";
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
                    txtID.Tag = dgvReceta.CurrentRow.Cells["idIngProd"].Value.ToString();
                    txtID.Text = dgvReceta.CurrentRow.Cells["idIngredienteReceta"].Value.ToString();
                    txtNombre.Text = dgvReceta.CurrentRow.Cells["nombreReceta"].Value.ToString();
                    txtCantidad.Text = dgvReceta.CurrentRow.Cells["cantidad"].Value.ToString();
                    btnBuscarIngrediente.Text = "Cambiar Ingrediente";
                    lblCantidad.Text = "Editar Cantidad(3 digitos Maximo)";
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
                        Mantenimiento.CLS.UnidadMedida mantenimiento = new Mantenimiento.CLS.UnidadMedida
                        {
                            IdUnidad = int.Parse(dgvUnidad.CurrentRow.Cells["idUnidadMedida"].Value.ToString())
                        };
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
                    Mantenimiento.CLS.UnidadMedida mantenimiento = new Mantenimiento.CLS.UnidadMedida
                    {
                        Unidad_Medida = txtPresentacion.Text
                    };
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
            // Permitir solo números, el carácter de control (como retroceso) y el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal y asegurarse de que no haya más de 3 dígitos después del punto
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (e.KeyChar != '.' && char.IsDigit(e.KeyChar))
            {
                TextBox textBox = sender as TextBox;
                string currentText = textBox.Text.Insert(textBox.SelectionStart, e.KeyChar.ToString());
                string[] parts = currentText.Split('.');

                if (parts.Length > 1 && parts[1].Length > 3)
                {
                    e.Handled = true;
                }
            }
        }
    }
}