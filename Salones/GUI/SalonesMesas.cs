using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Windows.Forms;

namespace Salones.GUI
{
    public partial class SalonesMesas : Form
    {
        BindingSource datos = new BindingSource();
        public SalonesMesas()
        {
            InitializeComponent();
        }
        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Mesas();
                dgvDatos.DataSource = datos;
                dgvDatos.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LimpiarCampos()
        {
            try
            {
                cmbSalones.Text = string.Empty;
                txtNumeroMesa.Text = string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }
        void VolverCargarDatos()
        {
            try
            {
                btnGuardar.Visible = false;
                btnEditar.Visible = true;
                btnNuevo.Visible = true;
                btnCancelar.Visible = false;
                btnLimpiar.Visible = false;
                btnEliminar.Visible = false;
                lblNota.Visible = false;
                lblNotaEs.Visible = false;
                btnAgregarMesa.Visible = false;

                LimpiarCampos();
                cmbSalones.DropDownStyle = ComboBoxStyle.DropDownList;
                txtNumeroMesa.Enabled = false;

                ListaSalones();
                CargarDatos();
                compararDatos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ListaSalones()
        {
            try
            {
                // Obtener los datos
                DataTable salon = DataManager.DBConsultas.Salones();
                // Crear un nuevo DataTable con la estructura
                DataTable dt = salon.Clone();

                // Fusionar los datos de categoría con el nuevo DataTable
                dt.Merge(salon);

                // Asignar el origen de datos al ComboBox
                cmbSalones.DataSource = dt;
                cmbSalones.DisplayMember = "nombre";
                cmbSalones.ValueMember = "idSalon";

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void compararDatos()
        {
            try
            {
                if (cmbSalones.SelectedValue != null)
                {
                    dgvDatos.CurrentCell = null;
                    int contador = 0;

                    foreach (DataGridViewRow item in dgvDatos.Rows)
                    {
                        item.Visible = false;
                        txtID.Text = cmbSalones.SelectedValue.ToString();

                        if (item.Cells["nomSalon"].Value.ToString() == cmbSalones.Text)
                        {
                            if (item.Cells["idSalon"].Value.ToString() == txtID.Text)
                            {
                                item.Visible = true;
                                txtNumeroMesa.Text = item.Cells["nMesas"].Value.ToString();
                                contador = contador + 1;
                            }
                        }
                    }
                    txtContador.Text = "Mesas encontradas " + contador;

                    if (contador == 0)
                    {
                        txtNumeroMesa.Text = "0";
                    }
                }
                else
                {
                    VolverCargarDatos();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SalonesMesas_Load(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnLimpiar.Visible = false;
            btnEliminar.Visible = false;
            CargarDatos();
            ListaSalones();
            compararDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cmbSalones.Text != string.Empty)
            {
                btnGuardar.Visible = true;
                btnEditar.Visible = false;
                btnCancelar.Visible = true;
                btnLimpiar.Visible = false;
                btnEliminar.Visible = true;
                lblNota.Visible = true;
                lblNotaEs.Visible = true;
                btnAgregarMesa.Visible = true;

                btnNuevo.Visible = false;
                cmbSalones.DropDownStyle = ComboBoxStyle.Simple;
                txtNumeroMesa.Enabled = false;
            }
            else
            {
                MessageBox.Show("¡No hay datos disponibles!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            VolverCargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void cmbSalones_SelectedIndexChanged(object sender, EventArgs e)
        {
            compararDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            btnCancelar.Visible = true;
            btnEditar.Visible = false;
            btnGuardar.Visible = true;
            btnLimpiar.Visible = true;
            btnEliminar.Visible = false;
            lblNota.Visible = false;
            lblNotaEs.Visible = false;

            txtNumeroMesa.Enabled = true;
            cmbSalones.ValueMember = string.Empty;
            cmbSalones.DropDownStyle = ComboBoxStyle.Simple;

            btnNuevo.Visible = false;
            txtContador.Text = "Mesas encontradas " + 0;

            dgvDatos.DataSource = new BindingSource();

            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Mantenimiento.CLS.Salon salon = new Mantenimiento.CLS.Salon();
                Mantenimiento.CLS.Mesa mesa = new Mantenimiento.CLS.Mesa();

                if (txtID.Text == string.Empty)
                {
                    if (txtNumeroMesa.Text == "" || cmbSalones.Text == "")
                    {
                        MessageBox.Show("¡Por favor asegurese de llenar todos los campos necesarios!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        salon.Nombre = cmbSalones.Text;
                        int nMesas = int.Parse(txtNumeroMesa.Text);
                        salon.NMesas = nMesas;
                        //salon.Fondo = txtFondo.tex;

                        if (salon.Insertar())
                        {
                            Boolean insertado = false;
                            for (int i = 1; i <= nMesas; i++)
                            {
                                mesa.IdSalon = DataManager.DBConsultas.UltimoSalon(cmbSalones.Text);//Consultar el id del ultimo registro ingresado en la tabla salones
                                mesa.Numero = i;
                                mesa.Nombre = "Mesa " + i;
                                mesa.Capacidad = 0;
                                mesa.Disponible = true;

                                if (mesa.Insertar())
                                {
                                    insertado = true;
                                }
                                else
                                {
                                    insertado = false;
                                }
                            }
                            if (insertado)
                            {
                                MessageBox.Show("¡Registro insertado con exito!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                VolverCargarDatos();
                            }
                            else
                            {
                                MessageBox.Show("¡Registro no insertado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("¡Registro no insertado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    if (cmbSalones.Text == string.Empty)
                    {
                        MessageBox.Show("¡Por favor asegurese de llenar campo de nombre!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        salon.IdSalon = int.Parse(txtID.Text);
                        salon.Nombre = cmbSalones.Text;
                        if (salon.ActualizarNombre())
                        {
                            MessageBox.Show("¡Registro actualizado con exito!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Mantenimiento.CLS.Mesa mesa = new Mantenimiento.CLS.Mesa();
                    int idMesa = int.Parse(dgvDatos.CurrentRow.Cells["idMesa"].Value.ToString());
                    Boolean existe = DataManager.DBConsultas.MesaActiva(idMesa);
                    if (existe)
                    {
                        MessageBox.Show("¡Esta mesa no se puede eliminar!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("¿Esta seguro que desea eliminar esta mesa?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            mesa.IdMesa = idMesa;
                            if (mesa.EliminarFila())
                            {
                                Mantenimiento.CLS.Salon salon = new Mantenimiento.CLS.Salon();
                                int idSalon = int.Parse(txtID.Text);
                                int CantidadMesas = DataManager.DBConsultas.CantidadMesas(idSalon);
                                salon.IdSalon = idSalon;
                                //salon.Nombre = cmbSalones.Text;
                                salon.NMesas = CantidadMesas;
                                if (salon.ActualizarNMesas())
                                {
                                    MessageBox.Show("¡Registro eliminado con exito!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CargarDatos();
                                    compararDatos();
                                }
                            }
                            else
                            {
                                MessageBox.Show("¡Esta mesa no se puede eliminar!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("¡No hay datos selecionados!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgvDatos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            compararDatos();
        }

        private void btnAgregarMesa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro que desea agregar mas mesas este salon?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Muestra un cuadro de diálogo personalizado para pedir la cantidad
                    string input = Interaction.InputBox("¿Cuentas mesas desea agregar?:", "Agregar nuevas mesas", "");

                    // Verifica si el usuario ingresó una cantidad válida
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        return;
                    }

                    // Intenta convertir la entrada a un número entero
                    if (int.TryParse(input, out int cantidad) && cantidad > 0)
                    {
                        Mantenimiento.CLS.Mesa mesa = new Mantenimiento.CLS.Mesa();
                        Mantenimiento.CLS.Salon salon = new Mantenimiento.CLS.Salon();

                        Boolean insertado = false;
                        int nMesa = int.Parse(txtID.Text);
                        mesa.IdSalon = nMesa;

                        for (int i = 1; i <= cantidad; i++)
                        {
                            //Consultar el numero de la ultima mesa registrada
                            int Un = DataManager.DBConsultas.CantidadMesas(nMesa) + 1;
                            int UltimaMesa = DataManager.DBConsultas.UltimoNumero(int.Parse(txtID.Text)) + 1;
                            mesa.Numero = UltimaMesa;
                            mesa.Nombre = "Mesa " + UltimaMesa;
                            mesa.Capacidad = 0;
                            mesa.Disponible = true;

                            if (mesa.Insertar())
                            {
                                int idSalon = int.Parse(txtID.Text);
                                int CantidadMesas = DataManager.DBConsultas.UltimoNumero(idSalon);
                                salon.IdSalon = idSalon;
                                //salon.Nombre = cmbSalones.Text;
                                //salon.Fondo = txtFondo.tex;
                                salon.NMesas = Un;
                                if (salon.ActualizarNMesas())
                                {
                                    insertado = true;
                                }
                                else
                                {
                                    insertado = false;
                                }
                            }
                        }
                        if (insertado)
                        {
                            MessageBox.Show("¡Registro actualizado con exito!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos();
                            compararDatos();
                        }
                        else
                        {
                            MessageBox.Show("¡Registro no actualizado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡Porfavor ingrese una cantidad valida!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtNumeroMesa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
