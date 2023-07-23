using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPV.GUI
{
    public partial class ClientesGestion : Form
    {
        BindingSource datos = new BindingSource();
        public ClientesGestion()
        {
            InitializeComponent();
        }

        private void ClientesGestion_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Clientes();
                dgvClientes.DataSource = datos;
                dgvClientes.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
            lblRegistros.Text = datos.List.Count.ToString() + " Registros Encontrados";
        }

        private void Limpiar()
        {
            txtIdCliente.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtNit.Text = "";
            txtDireccion.Text = "";
            txtRegContable.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = dgvClientes.CurrentRow.Cells["idCliente"].Value.ToString();
            txtNombre.Text = dgvClientes.CurrentRow.Cells["nombre"].Value.ToString();
            txtEmail.Text = dgvClientes.CurrentRow.Cells["email"].Value.ToString();
            txtTelefono.Text = dgvClientes.CurrentRow.Cells["telefono"].Value.ToString();
            txtNit.Text = dgvClientes.CurrentRow.Cells["NIT"].Value.ToString();
            txtDireccion.Text = dgvClientes.CurrentRow.Cells["direccion"].Value.ToString();
            txtRegContable.Text = dgvClientes.CurrentRow.Cells["regContable"].Value.ToString();
        }
    }
}
