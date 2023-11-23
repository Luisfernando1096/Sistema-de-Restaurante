using System;
using System.Data;
using System.Windows.Forms;

namespace Compras.GUI
{
    public partial class Compras : Form
    {
        BindingSource datos = new BindingSource();
        Boolean variable = false;
        Boolean estadoCmb = false;
        Boolean editar = false;
        private int indiceAnterior = -1;

        public Compras()
        {
            InitializeComponent();
            // Asocia el evento KeyPress del TextBox a tu método personalizado
            txtDescuento.KeyPress += txtDescuento_KeyPress;
            txtIva.KeyPress += txtIva_KeyPress;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CargarDatos(int identificador, int idProveedor, string nComprobante)
        {
            try
            {
                if (identificador == 1)
                {
                    datos.DataSource = DataManager.DBConsultas.Compras(1, idProveedor, nComprobante);
                    dgvDatos.DataSource = datos;
                    dgvDatos.AutoGenerateColumns = false;
                }
                else if (identificador == 2)
                {
                    datos.DataSource = DataManager.DBConsultas.Compras(2, idProveedor, nComprobante);
                    dgvDatos.DataSource = datos;
                    dgvDatos.AutoGenerateColumns = false;
                }
                else if (identificador == 3)
                {
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private DataGridViewColumn AgregarColumnaConAncho(string nombre, string encabezado, int ancho)
        {
            DataGridViewColumn columna = new DataGridViewTextBoxColumn
            {
                Name = nombre,
                HeaderText = encabezado,
                Width = ancho
            };

            dgvDatos.Columns.Add(columna);

            return columna;
        }

        private void CalcularTotal()
        {
            try
            {
                decimal Acumulado = 0;

                if (!string.IsNullOrEmpty(txtDescuento.Text) && decimal.TryParse(txtDescuento.Text, out decimal descuento) &&
                    !string.IsNullOrEmpty(txtIva.Text) && decimal.TryParse(txtIva.Text, out decimal iva))
                {
                    // Ambos txtDescuento y txtIva son números válidos y no están vacíos.
                    foreach (DataGridViewRow item in dgvDatos.Rows)
                    {
                        if (item.Cells["ventasGravadas"].Value != null &&
                            decimal.TryParse(item.Cells["ventasGravadas"].Value.ToString(), out decimal valorCelda))
                        {
                            Acumulado += valorCelda;
                        }
                    }
                    decimal SumaTotal = Acumulado - ((descuento / 100) * Acumulado) + ((iva / 100) * Acumulado);
                    txtSumas.Text = Acumulado.ToString("0.00");
                    txtTotales.Text = SumaTotal.ToString("0.00");
                }
                else if (!string.IsNullOrEmpty(txtDescuento.Text) && decimal.TryParse(txtDescuento.Text, out descuento))
                {
                    // Solo txtDescuento es un número válido y no está vacío.
                    foreach (DataGridViewRow item in dgvDatos.Rows)
                    {
                        if (item.Cells["ventasGravadas"].Value != null &&
                            decimal.TryParse(item.Cells["ventasGravadas"].Value.ToString(), out decimal valorCelda))
                        {
                            Acumulado += valorCelda;
                        }
                    }
                    decimal SumaTotal = Acumulado - ((descuento / 100) * Acumulado);
                    txtSumas.Text = Acumulado.ToString("0.00");
                    txtTotales.Text = SumaTotal.ToString("0.00");
                }
                else if (!string.IsNullOrEmpty(txtIva.Text) && decimal.TryParse(txtIva.Text, out iva))
                {
                    // Solo txtIva es un número válido y no está vacío.
                    foreach (DataGridViewRow item in dgvDatos.Rows)
                    {
                        if (item.Cells["ventasGravadas"].Value != null &&
                            decimal.TryParse(item.Cells["ventasGravadas"].Value.ToString(), out decimal valorCelda))
                        {
                            Acumulado += valorCelda;
                        }
                    }
                    decimal SumaTotal = Acumulado + ((iva / 100) * Acumulado);
                    txtSumas.Text = Acumulado.ToString("0.00");
                    txtTotales.Text = SumaTotal.ToString("0.00");
                }
                else
                {
                    txtDescuento.Text = "0";
                    txtIva.Text = "0";

                    // Ni txtDescuento ni txtIva son números válidos o están vacíos.
                    foreach (DataGridViewRow item in dgvDatos.Rows)
                    {
                        if (item.Cells["ventasGravadas"].Value != null &&
                            decimal.TryParse(item.Cells["ventasGravadas"].Value.ToString(), out decimal valorCelda))
                        {
                            Acumulado += valorCelda;
                        }
                    }
                    txtSumas.Text = Acumulado.ToString("0.00");
                    txtTotales.Text = txtSumas.Text;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private bool ExisteID(string ID) 
        {
            foreach (DataGridViewRow item in dgvDatos.Rows)
            {
                string existe = item.Cells["ID"].Value.ToString();

                if (ID == existe)
                {
                    return true;
                }
            }

            return false;
        }

        private void LimpiarCampos() 
        {
            try
            {
                txtDescripcion.Text = string.Empty;
                txtPrecio.Text = string.Empty;
                txtCantidad.Text = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarComprobante()
        {
            try
            {
                DataTable comprobante = DataManager.DBConsultas.Comprobante();

                cmbComprobante.DataSource = comprobante;
                cmbComprobante.DisplayMember = "tipo";
                cmbComprobante.ValueMember = "idComprobante";

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            BuscarProveedor proveedores = new BuscarProveedor();

            var result = proveedores.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtProveedor.Tag = proveedores.ID.ToString();
                txtProveedor.Text = proveedores.Nombre;
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.BuscarIngrediente ingrediente = new Ingredientes_y_Productos.GUI.BuscarIngrediente();
            Ingredientes_y_Productos.GUI.BuscarProducto producto = new Ingredientes_y_Productos.GUI.BuscarProducto();

            if (cmbTipoCompra.SelectedIndex == 0)
            {
                var result = producto.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtDescripcion.Tag = producto.IDProducto.ToString();
                    txtDescripcion.Text = producto.NombreProducto;
                }
            }
            else if (cmbTipoCompra.SelectedIndex == 1)
            {
                var result = ingrediente.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtDescripcion.Tag = ingrediente.IDIngrediente.ToString();
                    txtDescripcion.Text = ingrediente.NombreIngrediente;
                }
            }
            else
            {
                MessageBox.Show("¡Por favor seleccione un tipo de compra!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            btnAtras.Visible = false;
            cmbTipoCompra.Items.Insert(0, "Productos");
            cmbTipoCompra.Items.Insert(1, "Ingredientes");
            txtIva.Text = "0";
            txtDescuento.Text = "0";

            CargarComprobante();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcion.Text == string.Empty || txtCantidad.Text == string.Empty || txtPrecio.Text == string.Empty)
                {
                    MessageBox.Show("¡Por favor asegurese de selecionar todos los campos necesarios!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtDescripcion.Tag != null) 
                    {
                        string idBuscar = txtDescripcion.Tag.ToString();

                        if (variable)
                        {
                            if (ExisteID(idBuscar))
                            {
                                // Actualizar los valores de la fila existente
                                foreach (DataGridViewRow row in dgvDatos.Rows)
                                {
                                    string idExistente = row.Cells["ID"].Value.ToString();

                                    if (idBuscar == idExistente)
                                    {
                                        row.Cells["precioUnitario"].Value = Double.Parse(txtPrecio.Text).ToString("0.00");
                                        row.Cells["cantidad"].Value = txtCantidad.Text;
                                        row.Cells["ventasGravadas"].Value = decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecio.Text);
                                        break;
                                    }
                                }
                                MessageBox.Show("¡El se ha modificado con exito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LimpiarCampos();
                                variable = false;
                            }
                        }
                        else
                        {
                            if (ExisteID(idBuscar))
                            {
                                MessageBox.Show("¡El registro ya existe agregado, si desea cambiar sus datos por favor de click sobre editar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (!editar)
                            {
                                DataGridViewRow fila = new DataGridViewRow();
                                fila.CreateCells(dgvDatos);

                                fila.Cells[0].Value = txtCantidad.Text;
                                fila.Cells[1].Value = txtDescripcion.Tag;
                                fila.Cells[2].Value = txtDescripcion.Text;
                                fila.Cells[3].Value = txtPrecio.Text;
                                fila.Cells[4].Value = decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecio.Text);

                                dgvDatos.Rows.Add(fila);

                            }
                            else
                            {
                                DataGridViewRow fila = new DataGridViewRow();
                                fila.CreateCells(dgvDatos);

                                fila.Cells[0].Value = txtCantidad.Text;
                                fila.Cells[1].Value = txtDescripcion.Tag;
                                fila.Cells[2].Value = txtDescripcion.Text;
                                fila.Cells[3].Value = txtPrecio.Text;
                                fila.Cells[4].Value = decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecio.Text);

                                dgvDatos.Rows.Add(fila); // Asegúrate de agregar la fila después de establecer los valores de las celdas
                            }

                            LimpiarCampos();
                        }
                    }
                }
                CalcularTotal();
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
                if (dgvDatos.SelectedRows.Count > 0)
                {
                    txtDescripcion.Tag = dgvDatos.CurrentRow.Cells["ID"].Value.ToString();
                    txtDescripcion.Text = dgvDatos.CurrentRow.Cells["descripcion"].Value.ToString();
                    txtCantidad.Text = dgvDatos.CurrentRow.Cells["cantidad"].Value.ToString();
                    txtPrecio.Text = dgvDatos.CurrentRow.Cells["precioUnitario"].Value.ToString();
                    variable = true;
                }
                CalcularTotal();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmbTipoCompra_SelectedValueChanged(object sender, EventArgs e)
        {
            int indiceActual = cmbTipoCompra.SelectedIndex;
            if (!estadoCmb)
            {
                if (indiceActual != indiceAnterior)
                {
                    if (dgvDatos.Rows.Count != 0)
                    {
                        DialogResult respuesta = MessageBox.Show("¡Al cambiar el tipo de comprobante se eliminarán los registros actuales sin guardar! ¿Estás seguro?", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        if (respuesta == DialogResult.OK)
                        {
                            while (dgvDatos.Rows.Count > 0)
                            {
                                dgvDatos.Rows.RemoveAt(0);
                            }
                            MessageBox.Show("¡Datos borrados, nuevo tipo de comprobante listo!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtSumas.Text = string.Empty;
                            txtTotales.Text = string.Empty;
                            txtDescripcion.Text = string.Empty;
                            txtDescripcion.Tag = null;
                        }
                        else
                        {
                            // El usuario ha cancelado la advertencia, no permitir el cambio en el ComboBox.
                            cmbTipoCompra.SelectedIndex = indiceAnterior; // Restaurar el índice anterior
                        }
                    }
                    indiceAnterior = cmbTipoCompra.SelectedIndex; // Actualizar el índice anterior
                }
                txtDescripcion.Text = string.Empty;
                txtDescripcion.Tag = null;
            }
            estadoCmb = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean resultadoComprasDetalles = false;
                int filasComprasDetalles = 0;
                Boolean resultadoCompra = false;
                int filasCompras = 0;

                if (dgvDatos.Rows.Count == 0)
                {
                    MessageBox.Show("¡No hay datos que guardar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtProveedor.Text == string.Empty || txtNoComprobante.Text == string.Empty)
                    {
                        MessageBox.Show("¡Por favor asegurese de seleccionar el proveedor y escribir el numero de comprobante!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (txtDescuento.Text == string.Empty)
                        {
                            txtDescuento.Text = "0";
                        }
                        if (txtIva.Text == string.Empty)
                        {
                            txtIva.Text = "0";
                        }
                        if (txtIdCompra.Text == string.Empty)
                        {
                            Boolean existeComprobante = DataManager.DBConsultas.ExisteComprobante(txtNoComprobante.Text);
                            if (!existeComprobante)
                            {
                                Mantenimiento.CLS.Compra compra = new Mantenimiento.CLS.Compra();
                                compra.TipoCompra = cmbTipoCompra.Text;
                                compra.IdProveedor = int.Parse(txtProveedor.Tag.ToString());
                                compra.IdComprobante = int.Parse(cmbComprobante.SelectedValue.ToString());
                                compra.NComprobante = txtNoComprobante.Text;
                                compra.IdUsuario = int.Parse(SessionManager.Session.Instancia.IdUsuario);

                                DateTime fechaSeleccionada = dtpFechaCompra.Value;
                                string fechaFormateada = fechaSeleccionada.ToString("yyyy-MM-dd");
                                compra.Fecha = fechaFormateada;

                                compra.Total = double.Parse(txtSumas.Text.ToString());
                                compra.Descuento = (double.Parse(txtDescuento.Text) / 100);
                                compra.Iva = (double.Parse(txtIva.Text) / 100);
                                compra.TotalPago = double.Parse(txtTotales.Text);

                                int idCompraInsertada;
                                if (compra.Insertar(out idCompraInsertada))
                                {
                                    resultadoCompra = true;
                                    filasCompras = filasCompras + 1;
                                    int NuevoStock = 0;

                                    ///SI SE INSEERTO EN COMPRAS SE IRA A INSERTAR EN COMPRAS_DETALLES
                                    Mantenimiento.CLS.Compra_detalle compra_detalle = new Mantenimiento.CLS.Compra_detalle();
                                    compra_detalle.IdCompra = idCompraInsertada; /*DataManager.DBConsultas.ConsultarUltimoRegistro(int.Parse(SessionManager.Session.Instancia.IdUsuario));*/

                                    if (cmbTipoCompra.Text == "Productos")
                                    {
                                        foreach (DataGridViewRow item in dgvDatos.Rows)
                                        {
                                            compra_detalle.IdProducto = int.Parse(item.Cells["ID"].Value.ToString());
                                            compra_detalle.Cantidad = int.Parse(item.Cells["cantidad"].Value.ToString());
                                            compra_detalle.Precio = double.Parse(item.Cells["precioUnitario"].Value.ToString());
                                            compra_detalle.SubTotal = double.Parse(item.Cells["ventasGravadas"].Value.ToString());

                                            ///SI SE INSERTO DETALLES_COMPRAS, IR A MODIFICAR EL STOCK DE PRODUCTOS
                                            if (compra_detalle.InsertarProductos())
                                            {
                                                resultadoComprasDetalles = true;
                                                filasComprasDetalles = filasComprasDetalles + 1;

                                                NuevoStock = DataManager.DBConsultas.ConsultarStock(1, compra_detalle.IdProducto) + compra_detalle.Cantidad;
                                                Mantenimiento.CLS.Producto producto = new Mantenimiento.CLS.Producto();
                                                producto.IdProducto = compra_detalle.IdProducto;
                                                producto.Stock = NuevoStock;

                                                producto.ActualizarStockProductos();
                                            }
                                        }
                                    }
                                    else if (cmbTipoCompra.Text == "Ingredientes")
                                    {
                                        foreach (DataGridViewRow item in dgvDatos.Rows)
                                        {
                                            compra_detalle.IdIngrediente = int.Parse(item.Cells["ID"].Value.ToString());
                                            compra_detalle.Cantidad = int.Parse(item.Cells["cantidad"].Value.ToString());
                                            compra_detalle.Precio = double.Parse(item.Cells["precioUnitario"].Value.ToString());
                                            compra_detalle.SubTotal = double.Parse(item.Cells["ventasGravadas"].Value.ToString());

                                            ///SI SE INSERTO DETALLES_COMPRAS, IR A MODIFICAR EL STOCK DE INGREDIENTES
                                            if (compra_detalle.InsertarIngredientes())
                                            {
                                                resultadoComprasDetalles = true;
                                                filasComprasDetalles = filasComprasDetalles + 1;

                                                NuevoStock = DataManager.DBConsultas.ConsultarStock(2, compra_detalle.IdIngrediente) + compra_detalle.Cantidad;

                                                Mantenimiento.CLS.Ingrediente ingrediente = new Mantenimiento.CLS.Ingrediente();
                                                ingrediente.IdIngrediente = compra_detalle.IdIngrediente;
                                                ingrediente.Stock = NuevoStock;

                                                ingrediente.ActualizarStockIngredientes();
                                            }
                                        }
                                    }
                                }
                                if (resultadoComprasDetalles & resultadoCompra)
                                {
                                    MessageBox.Show("!" + filasComprasDetalles + " registros insertados correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvDatos.Rows.Clear();
                                    txtProveedor.Text = "";
                                    txtProveedor.Tag = "";
                                    txtSumas.Text = string.Empty;
                                    txtTotales.Text = string.Empty;
                                    txtNoComprobante.Text = string.Empty;
                                }
                                else
                                {
                                    MessageBox.Show("¡Error al insertar registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El numero de comprobante ya existe registradoe en el sistema", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("¡ACA SE MANEJARIA LA MODIFICACION!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
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
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dgvDatos.SelectedRows.Count != 0)
                        {
                            int rowIndex = dgvDatos.SelectedRows[0].Index;
                            dgvDatos.Rows.RemoveAt(rowIndex);
                            MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("¡El registro no fue eliminado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                CalcularTotal();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtIva_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o una tecla de control (por ejemplo, retroceso)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Si no es un número o una tecla de control, indica que el evento ya ha sido manejado
                e.Handled = true;
            }
            else
            {
                // Obtiene el texto actual del TextBox después de la inserción de la nueva tecla
                string nuevoTexto = txtIva.Text + e.KeyChar;

                // Intenta convertir el contenido del TextBox a un número
                if (int.TryParse(nuevoTexto, out int numero))
                {
                    // Verifica si el número está en el rango de 1 a 100
                    if (numero < 0 || numero > 100)
                    {
                        // Si no está en el rango, indica que el evento ya ha sido manejado
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o una tecla de control (por ejemplo, retroceso)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                // Si no es un número o una tecla de control, indica que el evento ya ha sido manejado
                e.Handled = true;
            }
            else
            {
                // Obtiene el texto actual del TextBox después de la inserción de la nueva tecla
                string nuevoTexto = txtDescuento.Text + e.KeyChar;

                // Intenta convertir el contenido del TextBox a un número
                if (int.TryParse(nuevoTexto, out int numero))
                {
                    // Verifica si el número está en el rango de 1 a 100
                    if (numero < 0 || numero > 100)
                    {
                        // Si no está en el rango, indica que el evento ya ha sido manejado
                        e.Handled = true;
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BuscarDetalles buscarDetalle = new BuscarDetalles();
            buscarDetalle.bntSelecionar.Visible = true;
            var resultado = buscarDetalle.ShowDialog();

            estadoCmb = true;
            if (resultado == DialogResult.OK)
            {
                txtDescripcion.Text = string.Empty;
                txtDescripcion.Tag = null;
                txtCantidad.Text = string.Empty;
                txtPrecio.Text = string.Empty;
                btnAtras.Visible = false;
                btnEliminar.Visible = false;
                btnGuardar.Visible = false;
                btnEditarReceta.Visible = false;
                button3.Visible = false;
                btnLimpiar.Visible = false;
                btnAtras.Visible = true;
                btnBuscarProveedor.Enabled = false;
                btnBuscar.Enabled = false;
                cmbComprobante.Enabled = false;
                dtpFechaCompra.Enabled = false;
                txtIva.Enabled = false;
                txtDescuento.Enabled = false;
                
                decimal subTotal = 0;
                cmbTipoCompra.Enabled = false;
                txtNoComprobante.Enabled = false;

                txtIdCompra.Text = buscarDetalle.IdCompra.ToString();
                cmbTipoCompra.Text = buscarDetalle.TCompra.ToString();
                txtProveedor.Tag = buscarDetalle.IdProveedor.ToString();
                txtProveedor.Text = buscarDetalle.Nombre;
                cmbComprobante.Tag = buscarDetalle.IdComprobante.ToString();
                cmbComprobante.Text = buscarDetalle.tipo.ToString();
                txtNoComprobante.Text = buscarDetalle.NComprobante;
                dtpFechaCompra.Value = buscarDetalle.Fecha;
                txtDescuento.Text = buscarDetalle.Descuento.ToString();
                txtIva.Text = buscarDetalle.Iva.ToString();
                txtTotales.Text = buscarDetalle.Total.ToString();
                editar = true;

                if (cmbTipoCompra.Text == "Productos")
                {
                    CargarDatos(1, buscarDetalle.IdProveedor, buscarDetalle.NComprobante);
                }
                else if (cmbTipoCompra.Text == "Ingredientes")
                {
                    CargarDatos(2, buscarDetalle.IdProveedor, buscarDetalle.NComprobante);
                }

                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    decimal subTotalItem = Convert.ToDecimal(item.Cells["ventasGravadas"].Value);

                    subTotal += subTotalItem;
                }
                txtSumas.Text = subTotal.ToString();
            }
            else
            {
               /// MessageBox.Show("¡No se seleciono ningun proveedor!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            txtIva.Enabled = true;
            txtDescuento.Enabled = true;
            btnBuscarProveedor.Enabled = true;
            btnBuscar.Enabled = true;
            cmbComprobante.Enabled = true;
            dtpFechaCompra.Enabled = true;
            btnAtras.Visible = true;
            btnEliminar.Visible = true;
            btnGuardar.Visible = true;
            btnEditarReceta.Visible = true;
            button3.Visible = true;
            btnAtras.Visible = false;
            txtNoComprobante.Enabled = true;
            LimpiarCampos();

            dgvDatos.DataSource = null;
            dgvDatos.Rows.Clear();
            // Borrar todas las columnas existentes en el DataGridView
            dgvDatos.Columns.Clear();
            // Agregar nuevas columnas al DataGridView con ancho y propiedades personalizadas
            AgregarColumnaConAncho("Cantidad", "Cantidad", 150).DataPropertyName = "cantidad";
            AgregarColumnaConAncho("ID", "ID", 80).DataPropertyName = "idTipo";
            AgregarColumnaConAncho("Descripcion", "Descripción", 455).DataPropertyName = "nombre";
            AgregarColumnaConAncho("precioUnitario", "Precio Unitario", 150).DataPropertyName = "precio";
            AgregarColumnaConAncho("ventasGravadas", "Ventas Gravadas", 150).DataPropertyName = "subtotal";
            // Crear una nueva fila
            DataGridViewRow fila = new DataGridViewRow();
            fila.CreateCells(dgvDatos);
            if (dgvDatos.Columns.Contains("ID"))
            {
                dgvDatos.Columns["ID"].Visible = false;
            }

            cmbComprobante.SelectedIndex = 0;
            cmbTipoCompra.Enabled = true;
            cmbTipoCompra.SelectedIndex = -1;
            txtProveedor.Text = string.Empty;
            txtProveedor.Tag = null;
            txtIdCompra.Text = string.Empty;

            btnLimpiar.Visible = true;
            txtNoComprobante.Text = string.Empty;
            txtSumas.Text = string.Empty;
            txtIva.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            txtTotales.Text = string.Empty;
            dtpFechaCompra.Value = DateTime.Now;
        }
    }
}
