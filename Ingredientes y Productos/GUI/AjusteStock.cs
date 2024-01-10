using Mantenimiento.CLS;
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
    public partial class AjusteStock : Form
    {
        Boolean variable = false;
        Boolean variable2 = false;
        BindingSource datos = new BindingSource();
        BindingSource datos1 = new BindingSource();
        BindingSource datos2 = new BindingSource();

        SessionManager.Session oUsuario = SessionManager.Session.Instancia;
        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.VerStock();
                dgvAjusteStock.DataSource = datos;
                dgvAjusteStock.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarDatosProductos()
        {
            try
            {
                datos1.DataSource = DataManager.DBConsultas.ProductosActivos();
                dgvAjusteStock.DataSource = datos1;
                dgvAjusteStock.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarDatosIngredientes()
        {
            try
            {
                datos2.DataSource = DataManager.DBConsultas.IngredientesActivos();
                dgvAjusteStock.DataSource = datos2;
                dgvAjusteStock.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LimpiarProductos() 
        {
            try
            {
                txtIdProducto.Text = "";
                txtProductos.Text = "";
                cmbAjusteProducto.SelectedIndex = -1;
                txtCantidadProducto.Text = "";
                txtJustificacionProducto.Text = "";
                txtProductos.Tag = "";
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool ExisteIDEnDataGridViewProductos(string idBuscar)
        {
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                string idExistente = row.Cells["idProducto"].Value.ToString();

                if (idBuscar == idExistente)
                {
                    return true;
                }
            }

            return false;
        }
        ///INGREDIENTE
        private bool ExisteIDEnDataGridViewIngrediente(string idBuscar)
        {
            foreach (DataGridViewRow row in dgvIngredientes.Rows)
            {
                string idExistente = row.Cells["idIngrediente"].Value.ToString();

                if (idBuscar == idExistente)
                {
                    return true;
                }
            }

            return false;
        }
        private void LimpiarIngrediente()
        {
            try
            {
                txtIdIngrediente.Text = "";
                txtIngrediente.Text = "";
                cmbAjusteIngrediente.SelectedIndex = -1;
                txtCantidadIngrediente.Text = "";
                txtJustificacionIngrediente.Text = "";
                txtIngrediente.Tag = "";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public AjusteStock()
        {
            InitializeComponent();
        }

        readonly List<string> items = new List<string>
        {
            "Seleccione una opcion",
            "Producto",
            "Ingrediente"
        };
        private void FiltrarDatos()
        {
            try
            {
                ////UNOOOOOOOOOOOOOOOOOOOOOOO
                if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatos();
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatos(); dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        if (r.Cells["Ingrediente"].Value.ToString().ToUpper().IndexOf(txtBuscar.Text.ToUpper()) == 0)
                        {
                            r.Visible = true;
                        }
                        if (r.Cells["Producto"].Value.ToString().ToUpper().IndexOf(txtBuscar.Text.ToUpper()) == 0)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatos(); DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatos(); DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if ((valorProducto.Contains(txtBuscar.Text.ToUpper()) || valorIngrediente.Contains(txtBuscar.Text.ToUpper())) && (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatos();
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatos();
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        if ((valorProducto.Contains(txtBuscar.Text.ToUpper()) || valorIngrediente.Contains(txtBuscar.Text.ToUpper())) && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }

                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatos();
                    DateTime fechaInicial = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (fechaRegistro >= fechaInicial)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatos();
                    DateTime fechaInicial = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if ((valorProducto.Contains(txtBuscar.Text.ToUpper()) || valorIngrediente.Contains(txtBuscar.Text.ToUpper())) && fechaRegistro >= fechaInicial)
                        {
                            r.Visible = true;
                        }
                    }
                }
                ///OTROOOOOOOOOOOOOO
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if ((valorProducto.Contains(txtBuscar.Text.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if ((valorProducto.Contains(txtBuscar.Text.ToUpper())) && (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        if ((valorProducto.Contains(txtBuscar.Text.ToUpper())) && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();
                    DateTime fechaInicial = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (fechaRegistro >= fechaInicial)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();
                    DateTime fechaInicial = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        if ((valorProducto.Contains(txtBuscar.Text.ToUpper())) && fechaRegistro >= fechaInicial)
                        {
                            r.Visible = true;
                        }
                    }
                }
                ///OTROOOOOOOOOOOO
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        if ((valorIngrediente.Contains(txtBuscar.Text.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if ((valorIngrediente.Contains(txtBuscar.Text.ToUpper())) && (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        if ((valorIngrediente.Contains(txtBuscar.Text.ToUpper())) && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    DateTime fechaInicial = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (fechaRegistro >= fechaInicial)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 0 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    DateTime fechaInicial = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        if ((valorIngrediente.Contains(txtBuscar.Text.ToUpper())) && fechaRegistro >= fechaInicial)
                        {
                            r.Visible = true;
                        }
                    }
                }
                ///OTROOOOOOOOOOOOOO
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string Buscar = "INCREMENTAR";

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        if (r.Cells["tipoAjuste"].Value.ToString().ToUpper().IndexOf(Buscar.ToUpper()) == 0)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "INCREMENTAR";
                    string buscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if ((valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (valorIngrediente.Contains(buscar) || valorProducto.Contains(buscar.ToUpper()))))
                        {
                            r.Visible = true;
                        }
                    }

                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "INCREMENTAR";
                    string textoBuscar = txtBuscar.Text.ToUpper();
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if ((valorTipoAjuste.Contains(buscarTexto.ToUpper())) && (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal) && (valorIngrediente.Contains(textoBuscar) || valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }

                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro <= fechaFinal) && (valorIngrediente.Contains(textoBuscar) || valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro >= fechaInicio) && (valorIngrediente.Contains(textoBuscar) || valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }
                }
                ///OTROOOOOOOOOOOOO
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string Buscar = "DECREMENTAR";

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        if (r.Cells["tipoAjuste"].Value.ToString().ToUpper().IndexOf(Buscar.ToUpper()) == 0)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "DECREMENTAR";
                    string buscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if ((valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (valorIngrediente.Contains(buscar) || valorProducto.Contains(buscar.ToUpper()))))

                        {
                            r.Visible = true;
                        }
                    }

                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "DECREMENTAR";
                    string textoBuscar = txtBuscar.Text.ToUpper();
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if ((valorTipoAjuste.Contains(buscarTexto.ToUpper())) && (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal) && (valorIngrediente.Contains(textoBuscar) || valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }

                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro <= fechaFinal) && (valorIngrediente.Contains(textoBuscar) || valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 0 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    CargarDatos();
                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro >= fechaInicio) && (valorIngrediente.Contains(textoBuscar) || valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }
                }
                ///OTROOOOOOOOOOOOO
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string Buscar = "INCREMENTAR";

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        if (r.Cells["tipoAjuste"].Value.ToString().ToUpper().IndexOf(Buscar.ToUpper()) == 0)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "INCREMENTAR";
                    string buscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && valorProducto.Contains(buscar.ToUpper()))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "INCREMENTAR";
                    string textoBuscar = txtBuscar.Text.ToUpper();
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if ((valorTipoAjuste.Contains(buscarTexto.ToUpper())) && (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal) && (valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }

                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro <= fechaFinal) && (valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro >= fechaInicio) && (valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }
                }
                ////OTROOOOOOOOOOOOO
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string Buscar = "DECREMENTAR";

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        if (r.Cells["tipoAjuste"].Value.ToString().ToUpper().IndexOf(Buscar.ToUpper()) == 0)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "DECREMENTAR";
                    string buscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && valorProducto.Contains(buscar.ToUpper()))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "DECREMENTAR";
                    string textoBuscar = txtBuscar.Text.ToUpper();
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if ((valorTipoAjuste.Contains(buscarTexto.ToUpper())) && (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal) && (valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }

                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro <= fechaFinal) && (valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 1 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = false;
                    dgvAjusteStock.Columns["Producto"].Visible = true;
                    CargarDatosProductos();

                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorProducto = r.Cells["producto"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro >= fechaInicio) && (valorProducto.Contains(textoBuscar.ToUpper())))
                        {
                            r.Visible = true;
                        }
                    }
                }
                ////OTROOOOOOOOOOOOO
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string Buscar = "INCREMENTAR";

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        if (r.Cells["tipoAjuste"].Value.ToString().ToUpper().IndexOf(Buscar.ToUpper()) == 0)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "INCREMENTAR";
                    string buscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        if ((valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (valorIngrediente.Contains(buscar))))
                        {
                            r.Visible = true;
                        }
                    }

                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "INCREMENTAR";
                    string textoBuscar = txtBuscar.Text.ToUpper();
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        if ((valorTipoAjuste.Contains(buscarTexto.ToUpper())) && (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal) && (valorIngrediente.Contains(textoBuscar)))
                        {
                            r.Visible = true;
                        }
                    }

                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro <= fechaFinal) && (valorIngrediente.Contains(textoBuscar)))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 1 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "INCREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro >= fechaInicio) && (valorIngrediente.Contains(textoBuscar)))
                        {
                            r.Visible = true;
                        }
                    }
                }
                ////OTROOOOOOOOOOOOO
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string Buscar = "DECREMENTAR";

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;
                    }
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        if (r.Cells["tipoAjuste"].Value.ToString().ToUpper().IndexOf(Buscar.ToUpper()) == 0)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "DECREMENTAR";
                    string buscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        if ((valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (valorIngrediente.Contains(buscar))))
                        {
                            r.Visible = true;
                        }
                    }

                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "DECREMENTAR";
                    string textoBuscar = txtBuscar.Text.ToUpper();
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        if ((valorTipoAjuste.Contains(buscarTexto.ToUpper())) && (fechaRegistro >= fechaInicio && fechaRegistro <= fechaFinal) && (valorIngrediente.Contains(textoBuscar)))
                        {
                            r.Visible = true;
                        }
                    }

                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro <= fechaFinal)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value == dtpFechaInicio.MinDate && dtpFechaFinal.Value != dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaFinal = dtpFechaFinal.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro <= fechaFinal) && (valorIngrediente.Contains(textoBuscar)))
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text == "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && fechaRegistro >= fechaInicio)
                        {
                            r.Visible = true;
                        }
                    }
                }
                else if (cmbAjusteEn.SelectedIndex == 2 && txtBuscar.Text != "" && cmbTipoAjusteStock.SelectedIndex == 2 && dtpFechaInicio.Value != dtpFechaInicio.MinDate && dtpFechaFinal.Value == dtpFechaFinal.MinDate)
                {
                    dgvAjusteStock.Columns["Ingrediente"].Visible = true;
                    dgvAjusteStock.Columns["Producto"].Visible = false;
                    CargarDatosIngredientes();

                    string buscarTexto = "DECREMENTAR";
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    string textoBuscar = txtBuscar.Text.ToUpper();

                    dgvAjusteStock.CurrentCell = null;
                    foreach (DataGridViewRow r in dgvAjusteStock.Rows)
                    {
                        r.Visible = false;

                        string valorTipoAjuste = r.Cells["tipoAjuste"].Value.ToString().ToUpper();
                        DateTime fechaRegistro = Convert.ToDateTime(r.Cells["Fecha"].Value);
                        string valorIngrediente = r.Cells["Ingrediente"].Value.ToString().ToUpper();

                        if (valorTipoAjuste.Contains(buscarTexto.ToUpper()) && (fechaRegistro >= fechaInicio) && (valorIngrediente.Contains(textoBuscar)))
                        {
                            r.Visible = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AjusteStock_Load(object sender, EventArgs e)
        {
            int desiredWidth = 1100; // Establece el ancho deseado para el formulario
            this.Width = desiredWidth;

            dtpFechaProducto.Format = DateTimePickerFormat.Custom;
            dtpFechaProducto.CustomFormat = "yyyy-MM-dd";

            dtpFechaIngrediente.Format = DateTimePickerFormat.Custom;
            dtpFechaIngrediente.CustomFormat = "yyyy-MM-dd";

            dtpFechaStock.Format = DateTimePickerFormat.Custom;
            dtpFechaStock.CustomFormat = "yyyy-MM-dd";

            dtpFechaInicio.Format = DateTimePickerFormat.Custom;
            dtpFechaInicio.CustomFormat = "yyyy-MM-dd";

            dtpFechaFinal.Format = DateTimePickerFormat.Custom;
            dtpFechaFinal.CustomFormat = "yyyy-MM-dd";

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
            CargarDatos();

            lblUsuario.Text = oUsuario.Usuario.ToUpper();
            lblUsuario1.Text = oUsuario.Usuario.ToUpper();
            lblUsuario2.Text = oUsuario.Usuario.ToUpper();

            cmbAjusteProducto.Items.Add("INCREMENTO"); // Agrega "INCREMENTO" en la posición 1
            cmbAjusteProducto.Items.Add("DECREMENTO"); // Agrega "DECREMENTO" en la posición 2

            cmbAjusteIngrediente.Items.Add("INCREMENTO"); // Agrega "INCREMENTO" en la posición 1
            cmbAjusteIngrediente.Items.Add("DECREMENTO"); // Agrega "DECREMENTO" en la posición 2

            cmbAjusteEn.Items.AddRange(items.ToArray());
            cmbAjusteEn.SelectedIndex = 0;
            cmbTipoAjusteStock.Items.Add("Selecione una opcion");
            cmbTipoAjusteStock.Items.Add("INCREMENTO");
            cmbTipoAjusteStock.Items.Add("DECREMENTO");
            cmbTipoAjusteStock.SelectedIndex = 0;
        }

        private void bntBuscarProductos_Click(object sender, EventArgs e)
        {
            BuscarProducto producto = new BuscarProducto();
            var result = producto.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtIdProducto.Text = producto.IDProducto.ToString();
                txtProductos.Text = producto.NombreProducto;
                txtProductos.Tag = producto.CantidadInicial;
            }
        }

        private void bntLimpiarProducto_Click(object sender, EventArgs e)
        {
            LimpiarProductos();
            bntGuardarProducto.Enabled = true;
        }

        private void bntGuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                variable = false;
                Boolean resultado = false;
                if (dgvProductos.Rows.Count != 0)
                {
                    Mantenimiento.CLS.Ajuste_Stock ajuste = new Mantenimiento.CLS.Ajuste_Stock
                    {
                        Fecha = dtpFechaProducto.Text,
                        IdUsuario = int.Parse(oUsuario.IdUsuario)
                    };
                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        ajuste.IdProducto = int.Parse(row.Cells["idProducto"].Value.ToString());
                        string valorCelda = row.Cells["ajusteProducto"].Value.ToString();
                        if (valorCelda == "INCREMENTO")
                        {
                            ajuste.TipoAjuste = 1;
                        }
                        else if (valorCelda == "DECREMENTO")
                        {
                            ajuste.TipoAjuste = 2;
                        }

                        ajuste.Cantidad = double.Parse(row.Cells["cantidadProducto"].Value.ToString());
                        ajuste.Justificacion = row.Cells["justificacionProducto"].Value.ToString();
                        if (ajuste.Insertar())
                        {
                            //Modificar el ajuste en productos
                            Producto producto;
                            if (row.Cells["ajusteProducto"].Value.ToString().Equals("INCREMENTO"))
                            {
                                producto = new Producto
                                {
                                    IdProducto = Int32.Parse(row.Cells["idProducto"].Value.ToString()),
                                    Stock = Int32.Parse(row.Cells["cantidadInicial"].Value.ToString()) + Int32.Parse(row.Cells["cantidadProducto"].Value.ToString())
                                };
                                producto.ActualizarStock();
                            }
                            else
                            {
                                producto = new Producto
                                {
                                    IdProducto = Int32.Parse(row.Cells["idProducto"].Value.ToString()),
                                    Stock = Int32.Parse(row.Cells["cantidadInicial"].Value.ToString()) - Int32.Parse(row.Cells["cantidadProducto"].Value.ToString())
                                };
                                producto.ActualizarStock();
                            }
                            resultado = true;

                        }
                            
                    }
                    if (resultado)
                    {
                        MessageBox.Show("¡Registro insertado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarProductos();
                        dgvProductos.Rows.Clear();
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("¡Error al insertar registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("¡Necesita agregar productos a la lista!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                string idBuscar = txtIdProducto.Text;
                if (cmbAjusteProducto.SelectedIndex != -1)
                {
                    if (txtIdProducto.Text == "" || cmbAjusteProducto.Text == "" || txtCantidadProducto.Text == "" || txtJustificacionProducto.Text == "")
                    {
                        MessageBox.Show("¡Asegurese de llenar todos los campos necesario!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (variable)
                    {
                        ///SE MODIFICA
                        if (ExisteIDEnDataGridViewProductos(idBuscar))
                        {
                            // Actualizar los valores de la fila existente
                            foreach (DataGridViewRow row in dgvProductos.Rows)
                            {
                                string idExistente = row.Cells["idProducto"].Value.ToString();

                                if (idBuscar == idExistente)
                                {
                                    row.Cells["nombreProducto"].Value = txtProductos.Text;
                                    row.Cells["cantidadProducto"].Value = txtCantidadProducto.Text;
                                    row.Cells["ajusteProducto"].Value = cmbAjusteProducto.Text;
                                    row.Cells["justificacionProducto"].Value = txtJustificacionProducto.Text;
                                    row.Cells["cantidadInicial"].Value = txtProductos.Tag;
                                    break;
                                }
                            }
                            MessageBox.Show("¡El se ha modificado con exito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            bntGuardarProducto.Enabled = true;
                            LimpiarProductos();
                            variable = false;
                        }
                    }
                    else
                    {
                        if (ExisteIDEnDataGridViewProductos(idBuscar))
                        {
                            MessageBox.Show("¡El registro ya existe agregado, si desea cambiar sus datos por favor de click sobre editar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        DataGridViewRow fila = new DataGridViewRow();
                        fila.CreateCells(dgvProductos);

                        fila.Cells[0].Value = txtIdProducto.Text;
                        fila.Cells[1].Value = txtProductos.Text;
                        fila.Cells[2].Value = txtCantidadProducto.Text;
                        fila.Cells[3].Value = cmbAjusteProducto.Text;
                        fila.Cells[4].Value = txtJustificacionProducto.Text;
                        fila.Cells[5].Value = txtProductos.Tag;

                        dgvProductos.Rows.Add(fila);

                        // Limpiar los TextBox después de agregar los datos
                        LimpiarProductos();
                    }
                }
                else
                {
                    MessageBox.Show("¡Seleccione el tipo de ajuste!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (dgvProductos.SelectedRows.Count > 0 )
                {
                    txtIdProducto.Text = dgvProductos.CurrentRow.Cells["idProducto"].Value.ToString();
                    txtProductos.Text = dgvProductos.CurrentRow.Cells["nombreProducto"].Value.ToString();
                    txtCantidadProducto.Text = dgvProductos.CurrentRow.Cells["cantidadProducto"].Value.ToString();
                    cmbAjusteProducto.Text = dgvProductos.CurrentRow.Cells["ajusteProducto"].Value.ToString();
                    txtJustificacionProducto.Text = dgvProductos.CurrentRow.Cells["justificacionProducto"].Value.ToString();
                    txtProductos.Tag = dgvProductos.CurrentRow.Cells["cantidadInicial"].Value.ToString();
                    bntGuardarProducto.Enabled = false;
                    variable = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEliminarReceta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dgvProductos.SelectedRows.Count != 0)
                        {
                            int rowIndex = dgvProductos.SelectedRows[0].Index;
                            dgvProductos.Rows.RemoveAt(rowIndex);
                            MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bntGuardarProducto.Enabled = true;
                            variable = false;
                            LimpiarProductos();
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntEliminarIngrediente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvIngredientes.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dgvIngredientes.SelectedRows.Count != 0)
                        {
                            int rowIndex = dgvIngredientes.SelectedRows[0].Index;
                            dgvIngredientes.Rows.RemoveAt(rowIndex);
                            MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bntGuardarIngrediente.Enabled = true;
                            variable2 = false;
                            LimpiarIngrediente();
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

        private void bntEditarIngrediente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvIngredientes.SelectedRows.Count > 0)
                {
                    txtIdIngrediente.Text = dgvIngredientes.CurrentRow.Cells["idIngrediente"].Value.ToString();
                    txtIngrediente.Text = dgvIngredientes.CurrentRow.Cells["nombreIngrediente"].Value.ToString();

                    txtCantidadIngrediente.Text = dgvIngredientes.CurrentRow.Cells["cantidadIngrediente"].Value.ToString();
                    cmbAjusteIngrediente.Text = dgvIngredientes.CurrentRow.Cells["ajusteIngrediente"].Value.ToString();
                    txtJustificacionIngrediente.Text = dgvIngredientes.CurrentRow.Cells["justificacionIngrediente"].Value.ToString();
                    txtIdIngrediente.Tag = dgvIngredientes.CurrentRow.Cells["CntidadInicial"].Value.ToString();
                    bntGuardarIngrediente.Enabled = false;
                    variable2 = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void bntGuardarIngrediente_Click(object sender, EventArgs e)
        {
            try
            {
                variable2 = false;
                Boolean resultado = false;
                if (dgvIngredientes.Rows.Count != 0)
                {
                    Mantenimiento.CLS.Ajuste_Stock ajuste = new Mantenimiento.CLS.Ajuste_Stock
                    {
                        Fecha = dtpFechaIngrediente.Text,
                        IdUsuario = int.Parse(oUsuario.IdUsuario)
                    };

                    foreach (DataGridViewRow row in dgvIngredientes.Rows)
                    {
                        ajuste.IdIngrediente = int.Parse(row.Cells["idIngrediente"].Value.ToString());
                        string valorCelda = row.Cells["ajusteIngrediente"].Value.ToString();
                        if (valorCelda == "INCREMENTO")
                        {
                            ajuste.TipoAjuste = 1;
                        }
                        else if (valorCelda == "DECREMENTO")
                        {
                            ajuste.TipoAjuste = 2;
                        }

                        ajuste.Cantidad = double.Parse(row.Cells["cantidadIngrediente"].Value.ToString());
                        ajuste.Justificacion = row.Cells["justificacionIngrediente"].Value.ToString();
                        if (ajuste.Insertar())
                        {
                            //Hacer el ajuste de stock en ingredientes
                            Ingrediente ingrediente;
                            if (row.Cells["ajusteIngrediente"].Value.ToString().Equals("INCREMENTO"))
                            {
                                ingrediente = new Ingrediente
                                {
                                    IdIngrediente = Int32.Parse(row.Cells["idIngrediente"].Value.ToString()),
                                    Stock = Decimal.Parse(row.Cells["CntidadInicial"].Value.ToString()) + Decimal.Parse(row.Cells["cantidadIngrediente"].Value.ToString())
                                };
                                ingrediente.ActualizarStock();
                            }
                            else
                            {
                                ingrediente = new Ingrediente
                                {
                                    IdIngrediente = Int32.Parse(row.Cells["idIngrediente"].Value.ToString()),
                                    Stock = Decimal.Parse(row.Cells["CntidadInicial"].Value.ToString()) - Decimal.Parse(row.Cells["cantidadIngrediente"].Value.ToString())
                                };
                                ingrediente.ActualizarStock();
                            }
                            resultado = true;
                        }
                    }
                    if (resultado)
                    {
                        MessageBox.Show("¡Registro insertado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarIngrediente();
                        dgvIngredientes.Rows.Clear();
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("¡Error al insertar registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("¡Necesita agregar productos a la lista!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void bntAgregarIngrediente_Click(object sender, EventArgs e)
        {
            try
            {
                string idBuscar = txtIdIngrediente.Text;
                if (cmbAjusteIngrediente.SelectedIndex != -1)
                {
                    if (txtIdIngrediente.Text == "" || cmbAjusteIngrediente.Text == "" || txtCantidadIngrediente.Text == "" || txtJustificacionIngrediente.Text == "")
                    {
                        MessageBox.Show("¡Asegurese de llenar todos los campos necesario!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (variable2)
                    {
                        ///SE MODIFICA
                        if (ExisteIDEnDataGridViewIngrediente(idBuscar))
                        {
                            // Actualizar los valores de la fila existente
                            foreach (DataGridViewRow row in dgvIngredientes.Rows)
                            {
                                string idExistente = row.Cells["idIngrediente"].Value.ToString();

                                if (idBuscar == idExistente)
                                {
                                    row.Cells["nombreIngrediete"].Value = txtIngrediente.Text;
                                    row.Cells["cantidadIngrediente"].Value = txtCantidadIngrediente.Text;
                                    row.Cells["ajusteIngrediente"].Value = cmbAjusteIngrediente.Text;
                                    row.Cells["justificacionIngrediente"].Value = txtJustificacionIngrediente.Text;
                                    row.Cells["CntidadInicial"].Value = txtIngrediente.Tag.ToString();
                                    break;
                                }
                            }
                            MessageBox.Show("¡El se ha modificado con exito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            bntGuardarIngrediente.Enabled = true;
                            LimpiarIngrediente();
                            variable2 = false;
                        }
                    }
                    else
                    {
                        if (ExisteIDEnDataGridViewIngrediente(idBuscar))
                        {
                            MessageBox.Show("¡El registro ya existe agregado, si desea cambiar sus datos por favor de click sobre editar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        DataGridViewRow fila = new DataGridViewRow();
                        fila.CreateCells(dgvIngredientes);

                        fila.Cells[0].Value = txtIdIngrediente.Text;
                        fila.Cells[1].Value = txtIngrediente.Text;
                        fila.Cells[2].Value = txtCantidadIngrediente.Text;
                        fila.Cells[3].Value = cmbAjusteIngrediente.Text;
                        fila.Cells[4].Value = txtJustificacionIngrediente.Text;
                        fila.Cells[5].Value = txtIngrediente.Tag;

                        dgvIngredientes.Rows.Add(fila);

                        // Limpiar los TextBox después de agregar los datos
                        LimpiarIngrediente();
                    }
                }
                else
                {
                    MessageBox.Show("¡Seleccione el tipo de ajuste!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void bnLimpiarIngrediente_Click(object sender, EventArgs e)
        {
            LimpiarIngrediente();
            bntGuardarIngrediente.Enabled = true;
        }

        private void btnSalirIngrediente_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntBuscarIngrediente_Click(object sender, EventArgs e)
        {
            BuscarIngrediente ingrediente = new BuscarIngrediente();
            var result = ingrediente.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtIdIngrediente.Text = ingrediente.IDIngrediente.ToString();
                txtIngrediente.Text = ingrediente.NombreIngrediente;
                txtIngrediente.Tag = ingrediente.CantidadInicial;
            }
        }

        private void txtCantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCantidadIngrediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbAjusteEn_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void cmbTipoAjusteStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = dtpFechaInicio.MinDate;
            dtpFechaFinal.Value = dtpFechaFinal.MinDate;
            FiltrarDatos();
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            FiltrarDatos();
        }

        private void bntSalirAjuste_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvAjusteStock_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FiltrarDatos();
        }
    }
}

