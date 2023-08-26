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
        public Boolean seleccionCliente = false;
        public int idPedido;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idCliente;
            String nombres = txtNombre.Text.ToString();
            String telefono = txtTelefono.Text.ToString();
            String email = txtEmail.Text.ToString();
            String nit = txtNit.Text.ToString();
            String direccion = txtDireccion.Text.ToString();
            String regContable = txtRegContable.Text.ToString();
            Mantenimiento.CLS.Cliente cliente = new Mantenimiento.CLS.Cliente();

            if (txtNombre.Text.Equals(""))
            {
                MessageBox.Show("¡Debe digitar el nombre del cliente!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cliente.Nombre = nombres;
            cliente.Telefono = telefono;
            cliente.Email = email;
            cliente.NIT = nit;
            cliente.Direccion = direccion;
            cliente.RegContable = regContable;

            if (txtIdCliente.Text.Equals(""))
            {
                //Hacer insercion
                if (cliente.Insertar())
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
                idCliente = Int32.Parse(txtIdCliente.Text.ToString());
                cliente.IdCliente = idCliente;

                if (cliente.Actualizar())
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Mantenimiento.CLS.Cliente cliente = new Mantenimiento.CLS.Cliente();
                    cliente.IdCliente = int.Parse(dgvClientes.CurrentRow.Cells["idCliente"].Value.ToString());

                    if (cliente.Eliminar())
                    {
                        MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("¡El registro no fue eliminado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                CargarDatos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Codigo para filtrar clientes por nombre
            MessageBox.Show("Hola estoy escribiendo");
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (seleccionCliente)
            {
                if(idPedido != 0)
                {
                    Mantenimiento.CLS.Pedido pedido = new Mantenimiento.CLS.Pedido();
                    pedido.IdPedido = idPedido;
                    pedido.IdCliente = Int32.Parse(dgvClientes.CurrentRow.Cells["idCliente"].Value.ToString());
                    pedido.ActualizarCliente();
                    Close();
                }
                else
                {
                    MessageBox.Show("No hay ningun pedido seleccionado para asignar un cliente");
                }
                
            }
        }
    }
}
