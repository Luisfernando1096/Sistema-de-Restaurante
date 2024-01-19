using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Personal.GUI
{
    public partial class Comandos : Form
    {
        BindingSource datos = new BindingSource();
        public Comandos()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Comandos();
                dgvComandos.DataSource = datos;
                dgvComandos.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void lblIdEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void txtIdEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Comandos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Configurar el contexto de licencia para EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // O Commercial si tienes una licencia comercial
            Mantenimiento.CLS.Comando comando = new Mantenimiento.CLS.Comando();
            List<Mantenimiento.CLS.Comando> lstComandos = new List<Mantenimiento.CLS.Comando>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo xlsx (*.xlsx)|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string ruta = openFileDialog.FileName;

                // Cargar el archivo Excel
                using (var package = new ExcelPackage(new FileInfo(ruta)))
                {
                    // Obtener la hoja de trabajo
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    // Obtener la cantidad de filas en la columna A
                    int rowCount = worksheet.Dimension.Rows;

                    // Obtener los comandos desde la base de datos
                    DataTable comandos = DataManager.DBConsultas.ComandosPorRol("");

                    // Comparar y agregar nuevos comandos
                    for (int row = 1; row <= rowCount; row++)
                    {
                        // Obtener el valor de la celda en la columna A y fila actual
                        string cellValue = worksheet.Cells[row, 1].Text;

                        // Verificar si el comando ya existe en la DataTable
                        DataRow[] foundRows = comandos.Select("comando = '" + cellValue.Trim() + "'");
                        if (foundRows.Length == 0)
                        {
                            // El comando no existe, agregarlo a la DataTable
                            DataRow newRow = comandos.NewRow();
                            comando = new Mantenimiento.CLS.Comando();
                            comando.Comando1 = cellValue;

                            lstComandos.Add(comando);
                        }

                        // Puedes realizar aquí cualquier operación que necesites con el valor de cada fila.
                    }

                    // Actualizar la base de datos con los nuevos comandos
                    foreach (Mantenimiento.CLS.Comando com in lstComandos)
                    {
                        // Agregar lógica para guardar el nuevoComando en tu base de datos si es necesario
                        com.Insertar(); ;
                    }

                    Console.ReadLine(); // Esta línea ahora está dentro del bloque 'if'
                }
            }
            CargarDatos();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Mantenimiento.CLS.Comando comando = new Mantenimiento.CLS.Comando
                    {
                        IdComando = int.Parse(dgvComandos.CurrentRow.Cells["idComando"].Value.ToString())
                    };

                    if (comando.Eliminar())
                    {
                        MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("¡El registro no se pudo eliminar!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                CargarDatos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtIdComando.Text = dgvComandos.CurrentRow.Cells["idComando"].Value.ToString();
            txtComando.Text = dgvComandos.CurrentRow.Cells["comando"].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idComando;
            String comando = txtComando.Text.ToString();
            Mantenimiento.CLS.Comando oComando = new Mantenimiento.CLS.Comando();

            if (txtComando.Text.Equals(""))
            {
                MessageBox.Show("¡Debe digitar el comando!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oComando.Comando1 = comando;

            if (txtIdComando.Text.Equals(""))
            {
                //Hacer insercion
                if (oComando.Insertar())
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
                //Hacer actualizacion
                idComando = Int32.Parse(txtIdComando.Text.ToString());
                oComando.IdComando = idComando;

                if (oComando.Actualizar())
                {
                    MessageBox.Show("¡Registro actualizado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("¡Error al actualizar el registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Limpiar();
        }

        private void Limpiar()
        {
            txtIdComando.Text = "";
            txtComando.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
