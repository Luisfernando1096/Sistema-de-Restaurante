﻿using Mantenimiento.CLS;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TPV.GUI
{
    public partial class ClientesGestion : Form
    {
        BindingSource datos = new BindingSource();
        public Boolean seleccionCliente = false;
        public int idPedido;
        private Municipio municipio;
        private String complemento;
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
            txtCodActividad.Text = "";
            txtDesActividad.Text = "";
            txtTipoDoc.Text = "";
            txtDireccion.Tag = "";
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
            txtDireccion.Tag = dgvClientes.CurrentRow.Cells["idDireccion"].Value.ToString();
            txtDireccion.Text = dgvClientes.CurrentRow.Cells["direccion"].Value.ToString();
            txtRegContable.Text = dgvClientes.CurrentRow.Cells["regContable"].Value.ToString();
            txtCodActividad.Text = dgvClientes.CurrentRow.Cells["codActividad"].Value.ToString();
            txtDesActividad.Text = dgvClientes.CurrentRow.Cells["desActividad"].Value.ToString();
            txtTipoDoc.Text = dgvClientes.CurrentRow.Cells["tipoDocumento"].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposLLenos() > 0)
            {
                MessageBox.Show("¡Debe llenar los campos requeridos!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtNit.Text.Length != 14 && txtNit.Text.Length != 9)
            {
                MessageBox.Show("¡El nit debe tener 14 digitos o especificar dui con 9!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDesActividad.Text.Length >= 1 && txtDesActividad.Text.Length < 5)
            {
                MessageBox.Show("¡La descripcion de la actividad debe tener mas de 5 caracteres!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTelefono.Text.Length > 0)
            {
                if (txtTelefono.Text.Length < 8 || txtTelefono.Text.Length > 30)
                {
                    MessageBox.Show("¡El telefono debe tener de 8 a 30 caracteres!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (!txtEmail.Text.Equals(""))
            {
                if (!EsCorreoValido(txtEmail.Text))
                {
                    MessageBox.Show("El correo electrónico no es válido.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
            }
            if (txtCodActividad.Text.Length >= 1 && (txtCodActividad.Text.Length < 5 || txtCodActividad.Text.Length > 6))
            {
                MessageBox.Show("¡El codigo de la actividad debe tener entre 5 y 6 caracteres!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Direccion direccion = null;
            if (!txtDireccion.Tag.ToString().Equals(""))
            {
                //Agregaremos una direccion
                direccion = new Direccion
                {
                    IdDireccion = txtDireccion.Tag.ToString()
                };
                
            }
            else if (txtDireccion.Tag.ToString().Equals("") && complemento != null)
            {
                //Insertaremos una direccion
                Direccion direccion2 = new Direccion
                {
                    Municipio = municipio,
                    Complemento = complemento
                };

                if (direccion2.Insertar())
                {
                    DataManager.DBOperacion op = new DataManager.DBOperacion();
                    string consultaId = "SELECT LAST_INSERT_ID();";
                    int idInsertado = Convert.ToInt32(op.ConsultarScalar(consultaId));

                    //Obtenemos el id de la direccion agregada
                    direccion = new Direccion
                    {
                        IdDireccion = idInsertado.ToString()
                    };
                }

            }
            else
            {
                direccion = new Direccion
                {
                    IdDireccion = null
                };
            }

            String idCliente;
            String nombres = txtNombre.Text.ToString();
            String telefono = txtTelefono.Text.ToString();
            String email = txtEmail.Text.ToString();
            String nit = txtNit.Text.ToString();
            String codActividad = txtCodActividad.Text.ToString();
            String desActividad = txtDesActividad.Text.ToString();
            String tipoDoc = txtTipoDoc.Text.ToString();

            String regContable = txtRegContable.Text.ToString();
            Cliente cliente = new Cliente();
            
            cliente.RegContable = regContable;
            cliente.Nombre = nombres;
            cliente.CodActividad = codActividad;
            cliente.Telefono = telefono;
            cliente.Email = email;
            cliente.NIT = nit;
            cliente.Direccion = direccion;
            cliente.DesActividad = desActividad;
            cliente.TipoDocumento = tipoDoc;
            

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
                idCliente = txtIdCliente.Text.ToString();
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

        static bool EsCorreoValido(string correo)
        {
            // Expresión regular para validar correos electrónicos
            string patron = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            // Verificar si la cadena coincide con el patrón
            return Regex.IsMatch(correo, patron);
        }

        private int ValidarCamposLLenos()
        {
            int camposVacios = 0;

            if (txtNombre.Text.Equals(""))
            {
                camposVacios++;
            }
            if (txtNit.Text.Equals(""))
            {
                camposVacios++;
            }
            if (txtTipoDoc.Text.Equals(""))
            {
                camposVacios++;
            }

            return camposVacios;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Mantenimiento.CLS.Cliente cliente = new Mantenimiento.CLS.Cliente
                    {
                        IdCliente = dgvClientes.CurrentRow.Cells["idCliente"].Value.ToString()
                    };

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

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (seleccionCliente)
            {
                if (idPedido != 0)
                {
                    Mantenimiento.CLS.Pedido pedido = new Mantenimiento.CLS.Pedido
                    {
                        IdPedido = idPedido,
                        IdCliente = Int32.Parse(dgvClientes.CurrentRow.Cells["idCliente"].Value.ToString())
                    };
                    pedido.ActualizarCliente();
                    Close();
                }
                else
                {
                    MessageBox.Show("No hay ningun pedido seleccionado para asignar un cliente");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mantenimiento.GUI.fr f = new Mantenimiento.GUI.fr();
            if (f.ShowDialog() == DialogResult.OK) 
            {
                txtDireccion.Tag = "";
                complemento = f.txtComplemento.Text;
                txtDireccion.Text = f.cmbDepartamento.Text + ", " + f.cmbMunicipio.Text + ", " + f.txtComplemento.Text; //Direccion

                municipio = new Municipio
                {
                    IdMunicipio = f.cmbMunicipio.SelectedValue.ToString()
                };
                
            } 

        }

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
