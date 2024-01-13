using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ingredientes_y_Productos.GUI
{
    public partial class Productos : Form
    {
        BindingSource datosProductos = new BindingSource();
        BindingSource datosFamilias = new BindingSource();
        BindingSource datosUnidadMedida = new BindingSource();
        private String SeleccionarImg = string.Empty;
        private string selectedImagePathImg;
        private string destinationPathImg;
        String seleccionImgAnterior;

        private void CargarDatos()
        {
            try
            {
                datosProductos.DataSource = DataManager.DBConsultas.VerProductos();
                dgvProductos.DataSource = datosProductos;
                dgvProductos.AutoGenerateColumns = false;

                datosFamilias.DataSource = DataManager.DBConsultas.VerFamilia();
                dgvFamilia.DataSource = datosFamilias;
                dgvFamilia.AutoGenerateColumns = false;

                datosUnidadMedida.DataSource = DataManager.DBConsultas.VerUnidad();
                dgvUnidadMedida.DataSource = datosUnidadMedida;
                dgvUnidadMedida.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarListaProductos()
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
        private void CargarListaFamilia()
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
        private void CargarUnidad()
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
                cmbUnidad.DataSource = dt;
                cmbUnidad.DisplayMember = "unidadMedida";
                cmbUnidad.ValueMember = "idUnidad";
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
                cmbFamilia.DataSource = dt;
                cmbFamilia.DisplayMember = "familia";
                cmbFamilia.ValueMember = "idFamilia";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LimpiarCamposProductos()
        {
            try
            {
                txtID.Text = "";
                cmbFamilia.SelectedIndex = 0;
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                txtCosto.Text = "";
                txtPrecio.Text = "";
                cmbUnidad.SelectedIndex = 0;
                txtStock.Text = "";
                txtStockMinimo.Text = "";
                chBoxConIngrediente.Checked = false;
                chBoxInventariable.Checked = false;
                chBoxMostrar.Checked = false;
                ImgPrevia.Image = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        ///METODOS FAMILIA
        private void LimpiarCamposFamilia()
        {
            try
            {
                txtIdFamilia.Text = "";
                txtFamilia.Text = "";
                txtGrupoImpresion.Text = "";
                chMostrarMenu.Checked = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        ///METODOS UNIDAD
        private void LimpiarCamposUnidad()
        {
            try
            {
                txtIDUnidad.Text = "";
                txtUnidad.Text = "";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            int desiredWidth = 1200; // Establece el ancho deseado para el formulario
            this.Width = desiredWidth;

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
            CargarDatos();
            CargarUnidad();
            CargarFamilia();
            rbtNinguno.Checked = true;
        }

        private void btnSalirProducto_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntSalirFamilia_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntSalirUnidad_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mantenimiento.CLS.Producto mantenimiento = new Mantenimiento.CLS.Producto();
                        mantenimiento.IdProducto = int.Parse(dgvProductos.CurrentRow.Cells["idProducto"].Value.ToString());

                        if (mantenimiento.Eliminar())
                        {
                            MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCamposProductos();
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
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    Mantenimiento.CLS.Ingrediente mantenimiento = new Mantenimiento.CLS.Ingrediente();
                    if (MessageBox.Show("¿Esta seguro que desea editar este registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtID.Text = dgvProductos.CurrentRow.Cells["idProducto"].Value.ToString();
                        cmbFamilia.Text = dgvProductos.CurrentRow.Cells["Familia"].Value.ToString();
                        txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                        txtDescripcion.Text = dgvProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
                        txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
                        txtCosto.Text = dgvProductos.CurrentRow.Cells["Costo"].Value.ToString();
                        cmbUnidad.Text = dgvProductos.CurrentRow.Cells["Unidad"].Value.ToString();
                        txtStock.Text = dgvProductos.CurrentRow.Cells["Stock"].Value.ToString();
                        txtStockMinimo.Text = dgvProductos.CurrentRow.Cells["StockMinimo"].Value.ToString();

                        SeleccionarImg = dgvProductos.CurrentRow.Cells["foto"].Value.ToString();
                        seleccionImgAnterior = dgvProductos.CurrentRow.Cells["foto"].Value.ToString();

                        if (!string.IsNullOrEmpty(SeleccionarImg))
                        {
                            // Obtén la ruta de la imagen en la carpeta "Images" en el directorio de salida
                            string imagePathInOutput = Path.Combine("Ingredientes y Productos", "Images", SeleccionarImg);

                            // Obten la ruta del directorio de salida de la aplicación
                            string outputPath = AppDomain.CurrentDomain.BaseDirectory;
                            string projectDirectory = Path.GetFullPath(Path.Combine(outputPath, @"..\..\..\"));
                            string fullPath = Path.Combine(projectDirectory, imagePathInOutput);

                            if (File.Exists(fullPath))
                            {
                                // Carga la imagen desde la ruta en el directorio de salida
                                Image originalImage = Image.FromFile(fullPath);
                                ImgPrevia.Image = originalImage;
                            }
                            else
                            {
                                //MessageBox.Show("¡La imagen no se encontró, se recomienda agregar una nueva imagen para tener una mejor experiencia!", "Error al buscar imagen del producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            //MessageBox.Show("¡No existe imagen asociada a este producto, se recomienda agregar una nueva imagen para tener una mejor experiencia!", "Error al buscar imagen del producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        bool conIngrediente = Convert.ToBoolean(dgvProductos.CurrentRow.Cells["ConIngrediente"].Value);
                        chBoxConIngrediente.Checked = conIngrediente;

                        bool inventariable = Convert.ToBoolean(dgvProductos.CurrentRow.Cells["Inventariable"].Value);
                        chBoxInventariable.Checked = inventariable;

                        bool mostrar = Convert.ToBoolean(dgvProductos.CurrentRow.Cells["activo"].Value);
                        chBoxMostrar.Checked = mostrar;
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
                if (txtNombre.Text != "" & cmbFamilia.SelectedIndex != 0 && cmbUnidad.SelectedIndex != 0)
                {
                    Mantenimiento.CLS.Producto mantenimiento = new Mantenimiento.CLS.Producto();
                    mantenimiento.Foto = SeleccionarImg;
                    mantenimiento.Nombre = txtNombre.Text;
                    mantenimiento.IdFamilia = int.Parse(cmbFamilia.SelectedValue.ToString());
                    mantenimiento.IdUnidad = int.Parse(cmbUnidad.SelectedValue.ToString());
                    mantenimiento.Descripcion = txtDescripcion.Text;
                    mantenimiento.Precio = double.Parse(txtPrecio.Text);
                    mantenimiento.Costo = double.Parse(txtCosto.Text);
                    mantenimiento.Stock = int.Parse(txtStock.Text);
                    mantenimiento.StockMinimo = int.Parse(txtStockMinimo.Text);

                    mantenimiento.ConIngrediente = chBoxConIngrediente.Checked ? 1 : 0;
                    mantenimiento.Inventariable = chBoxInventariable.Checked ? 1 : 0;
                    mantenimiento.Activo = chBoxMostrar.Checked ? 1 : 0;

                    // Obten la ruta del directorio de salida de la aplicación
                    string outputPath = AppDomain.CurrentDomain.BaseDirectory;
                    string projectDirectory = Path.GetFullPath(Path.Combine(outputPath, @"..\..\..\"));
                    // Ahora tienes la ruta del directorio base de tu proyecto
                    string imagesDirectory = Path.Combine(projectDirectory, "Ingredientes y Productos", "Images");
                    // Obtén el nombre del archivo seleccionado
                    string selectedImageFileName = Path.GetFileName(selectedImagePathImg);
                    //Sise selecciono alguna imagen
                    if (selectedImageFileName != null)
                    {
                        // Construye la ruta de destino
                        destinationPathImg = Path.Combine(imagesDirectory, selectedImageFileName);
                        // Si el archivo no existe o si el nombre de la imagen es diferente a SeleccionarImg
                        if (!File.Exists(destinationPathImg) || !SeleccionarImg.Equals(selectedImageFileName))
                        {
                            // Copia la imagen seleccionada a la ubicación en tu proyecto
                            File.Copy(selectedImagePathImg, destinationPathImg);

                            // Actualiza la variable SeleccionarImg con el nuevo nombre
                            SeleccionarImg = selectedImageFileName;
                        }
                    }


                    if (txtID.Text == "")
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
                        mantenimiento.IdProducto = int.Parse(txtID.Text);
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
                    LimpiarCamposProductos();
                    BuscarDatosEnCombo();
                }
                else
                {
                    MessageBox.Show("¡Asegurese de llenar todos los campos necesarios!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void bntLimpiarFamilia_Click(object sender, EventArgs e)
        {
            LimpiarCamposFamilia();
        }

        private void bntEliminarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFamilia.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mantenimiento.CLS.Familia mantenimiento = new Mantenimiento.CLS.Familia();
                        mantenimiento.IdFamilia = int.Parse(dgvFamilia.CurrentRow.Cells["idFamilia"].Value.ToString());

                        if (mantenimiento.Eliminar())
                        {
                            MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCamposFamilia();
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

        private void bntEditarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFamilia.SelectedRows.Count > 0)
                {
                    Mantenimiento.CLS.Familia mantenimiento = new Mantenimiento.CLS.Familia();
                    if (MessageBox.Show("¿Esta seguro que desea editar este registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtIdFamilia.Text = dgvFamilia.CurrentRow.Cells["idFamilia"].Value.ToString();
                        txtFamilia.Text = dgvFamilia.CurrentRow.Cells["Categoria"].Value.ToString();
                        txtGrupoImpresion.Text = dgvFamilia.CurrentRow.Cells["grupoPrinter"].Value.ToString();

                        bool activo = Convert.ToBoolean(dgvFamilia.CurrentRow.Cells["ActivoFamilia"].Value);
                        chMostrarMenu.Checked = activo;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void bntGuardarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFamilia.Text != "" & txtGrupoImpresion.Text != "")
                {
                    Mantenimiento.CLS.Familia mantenimiento = new Mantenimiento.CLS.Familia();
                    mantenimiento.Familia1 = txtFamilia.Text;
                    mantenimiento.GrupoPrinter = txtGrupoImpresion.Text.ToUpper();
                    mantenimiento.Activo = chMostrarMenu.Checked ? 1 : 0;

                    if (txtIdFamilia.Text == "")
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
                        mantenimiento.IdFamilia = int.Parse(txtIdFamilia.Text);
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
                    LimpiarCamposFamilia();
                }
                else
                {
                    MessageBox.Show("¡Asegurese de llenar todos los campos necesarios!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void bntLimpiarUnidad_Click(object sender, EventArgs e)
        {
            LimpiarCamposUnidad();
        }

        private void bntEliminarUnidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUnidadMedida.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Mantenimiento.CLS.UnidadMedida mantenimiento = new Mantenimiento.CLS.UnidadMedida();

                        mantenimiento.IdUnidad = int.Parse(dgvUnidadMedida.CurrentRow.Cells["idUnidad"].Value.ToString());
                        if (mantenimiento.Eliminar())
                        {
                            MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCamposUnidad();
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

        private void bntEditarUnidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUnidadMedida.SelectedRows.Count > 0)
                {
                    Mantenimiento.CLS.UnidadMedida mantenimiento = new Mantenimiento.CLS.UnidadMedida();
                    if (MessageBox.Show("¿Esta seguro que desea editar este registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtIDUnidad.Text = dgvUnidadMedida.CurrentRow.Cells["idUnidad"].Value.ToString();
                        txtUnidad.Text = dgvUnidadMedida.CurrentRow.Cells["unidadMedida"].Value.ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void bntGuardarUnidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUnidad.Text == "")
                {
                    MessageBox.Show("¡El campo de unidad es necesario!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Mantenimiento.CLS.UnidadMedida mantenimiento = new Mantenimiento.CLS.UnidadMedida();
                    mantenimiento.Unidad_Medida = txtUnidad.Text;
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
                    LimpiarCamposUnidad();
                }
            }
            catch (Exception)
            {
                throw;
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

        private void rbtnFamilia_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaFamilia();
            cmbLista.Visible = true;
        }

        private void rbtnProducto_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaProductos();
            cmbLista.Visible = true;
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

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // El usuario seleccionó una imagen
                selectedImagePathImg = openFileDialog.FileName;
                try
                {
                    if (!Path.GetFileName(selectedImagePathImg).Equals(SeleccionarImg))
                    {
                        SeleccionarImg = Path.GetFileName(selectedImagePathImg);

                        // Carga la imagen desde la ruta en el directorio de salida
                        Image originalImage = Image.FromFile(selectedImagePathImg);
                        ImgPrevia.Image = originalImage;
                    }
                    else
                    {
                        SeleccionarImg = Path.GetFileName(selectedImagePathImg);

                        // Carga la imagen desde la ruta en el directorio de salida
                        Image originalImage = Image.FromFile(selectedImagePathImg);
                        ImgPrevia.Image = originalImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al copiar la imagen: " + ex.Message);
                }
            }
        }
        public static string SeleccionarImagen()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";
                openFileDialog.Title = "Seleccionar imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }

                return string.Empty;
            }
        }
    }
}
