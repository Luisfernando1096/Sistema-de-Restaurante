using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Configuraciones.GUI
{
    public partial class TirajeFactura : Form
    {
        DataTable tf;
        BindingSource datos = new BindingSource();
        public TirajeFactura()
        {
            InitializeComponent();

            // Suscribir al evento KeyPress del TextBox
            txtInicio.KeyPress += txtInicio_KeyPress;
            txtFin.KeyPress += txtFin_KeyPress;
            txtActual.KeyPress += txtActual_KeyPress;
        }

        private void CargarElementos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.TFactura();
                dgvDatos.DataSource = datos;
                dgvDatos.AutoGenerateColumns = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ActivarCampos() 
        {
            try
            {
                btnCancelar.Visible = true;
                btnNuevo.Visible = false;
                cmbTipoFactura.Enabled = true;
                txtSerie.Enabled = true;
                txtInicio.Enabled = true;
                txtFin.Enabled = true;
                txtActual.Enabled = true;
                btnActivar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DesactivarCampos()
        {
            try
            {
                btnCancelar.Visible = false;
                btnNuevo.Visible = true;
                cmbTipoFactura.Enabled = false;
                txtSerie.Enabled = false;
                txtInicio.Enabled = false;
                txtFin.Enabled = false;
                txtActual.Enabled = false;
                btnActivar.Enabled = true;
                btnEliminar.Enabled = true;
                txtSerie.Text = "";
                txtInicio.Text = "";
                txtFin.Text = "";
                txtActual.Text = "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void TirajeFactura_Load(object sender, EventArgs e)
        {
            CargarLista1();
            CargarLista2();
            DesactivarCampos();
            CargarElementos();
        }

        private void CargarLista1()
        {
            try
            {
                tf = DataManager.DBConsultas.Factura();
                
                cmbTipoFactura.DataSource = tf;
                cmbTipoFactura.DisplayMember = "tipoFactura";
                cmbTipoFactura.ValueMember = "idFactura";
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar datos: " + e);
                throw;
            }
        }

        private void CargarLista2()
        {
            try
            {
                DataTable presentacion = DataManager.DBConsultas.Factura();

                DataTable dt = presentacion.Clone();
                dt.Rows.Add(0, "TODOS");
                dt.Merge(presentacion);

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "tipoFactura";
                comboBox2.ValueMember = "idFactura";
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar datos: " + e);
                throw;
            }
        }

        private void LlenarTexto()
        {
            txtInicio.Text = tf.Rows[cmbTipoFactura.SelectedIndex]["inicio"].ToString();
            txtFin.Text = tf.Rows[cmbTipoFactura.SelectedIndex]["fin"].ToString();
            txtActual.Text = tf.Rows[cmbTipoFactura.SelectedIndex]["actual"].ToString();
            txtSerie.Text = tf.Rows[cmbTipoFactura.SelectedIndex]["serie"].ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbTipoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void PermitirSoloSeisDigitos(object sender, KeyPressEventArgs e) 
        {

            // Verificar si la tecla presionada es un número o una tecla de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancelar la tecla si no es un número o una tecla de control
                e.Handled = true;
            }

            // Verificar la longitud actual del texto en el TextBox
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length >= 6 && !char.IsControl(e.KeyChar))
            {
                // Cancelar la tecla si la longitud es igual o mayor a 6 y no es una tecla de control
                e.Handled = true;
            }
        }

        private void txtInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloSeisDigitos(sender, e);
        }

        private void txtFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloSeisDigitos(sender, e);
        }

        private void txtActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            PermitirSoloSeisDigitos(sender, e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtInicio.Text.Equals("") || txtFin.Text.Equals("") || txtActual.Text.Equals("") || txtSerie.Text.Equals(""))
            {
                MessageBox.Show("No debe dejar campos vacios!", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (Int32.Parse(txtInicio.Text) > Int32.Parse(txtFin.Text))
                {
                    MessageBox.Show("el inicio no puede ser mayor al fin!", "Campos No validos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    String tipo = cmbTipoFactura.Text;
                    bool existe = false;
                    Mantenimiento.CLS.Tiraje_Factura tiraje_Factura = new Mantenimiento.CLS.Tiraje_Factura();
                    tiraje_Factura.Inicio = Int32.Parse(txtInicio.Text);
                    tiraje_Factura.Fin = Int32.Parse(txtFin.Text);
                    tiraje_Factura.Actual = Int32.Parse(txtActual.Text);
                    tiraje_Factura.Serie = txtSerie.Text.ToString();
                    tiraje_Factura.TipoFactura = cmbTipoFactura.Text.ToString();
                    tiraje_Factura.Activo = true;

                    DataTable result = DataManager.DBConsultas.BuscarTipoFactura(tipo);
                    if (result.Rows.Count > 0)
                    {
                        existe = true;
                    }

                    if (existe)
                    {
                        if (DesactivarEstado(tipo))
                        {
                            if (tiraje_Factura.Insertar())
                            {
                                MessageBox.Show("Cambios realizados con exito!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        if (tiraje_Factura.Insertar())
                        {
                            MessageBox.Show("Cambios realizados con exito!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                CargarElementos();
                ListaPorTipo(comboBox2.Text);
                DesactivarCampos();
            }
        }

        private Boolean CambiarEstado(int id, bool estado, string tipo) 
        {
            Mantenimiento.CLS.Tiraje_Factura tf = new Mantenimiento.CLS.Tiraje_Factura();
            bool result = false;
            try
            {
                tf.IdTiraje = id;
                tf.Activo = estado;
                tf.ActualizarEstado(tipo);

                result = true;
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
        private bool DesactivarEstado(String tipo) 
        {
            bool resultado = false;
            try
            {
                DataTable result = DataManager.DBConsultas.TirajeFact(tipo);
                if (result.Rows.Count > 0)
                {
                    foreach (DataRow fila in result.Rows)
                    {
                        // Accediendo a los datos de cada columna en la fila
                        int idTiraje = Convert.ToInt32(fila["idTiraje"]);
                        string tipoFactura = fila["tipoFactura"].ToString();
                        bool activo = Convert.ToBoolean(fila["activo"]);
                        CambiarEstado(idTiraje, false, tipoFactura);
                    }
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception)
            {
                return resultado;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ActivarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesactivarCampos();
        }
        private void ListaPorTipo(String tipo)
        {
            try
            {
                if (dgvDatos.Rows.Count > 0)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        if (checkBox1.Checked)
                        {
                            datos.DataSource = DataManager.DBConsultas.TirajeFactura();
                            dgvDatos.DataSource = datos;
                            dgvDatos.AutoGenerateColumns = false;
                        }
                        else
                        {
                            CargarElementos();
                        }
                    }
                    else
                    {
                        if (checkBox1.Checked)
                        {
                            datos.DataSource = DataManager.DBConsultas.TirajeFact(tipo);
                            dgvDatos.DataSource = datos;
                            dgvDatos.AutoGenerateColumns = false;
                        }
                        else
                        {
                            datos.DataSource = DataManager.DBConsultas.BuscarTipoFactura(tipo);
                            dgvDatos.DataSource = datos;
                            dgvDatos.AutoGenerateColumns = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ListaPorTipo: {ex.Message}");
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaPorTipo(comboBox2.Text);
        }
        private bool Mensaje(String tipo)
        {
            bool resultado = false;
            int fin = 0;
            int actual = 0;
            int disponible = 0;
            try
            {
                DataTable result = DataManager.DBConsultas.TirajeFact(tipo);
                if (result.Rows.Count > 0)
                {
                    foreach (DataRow fila in result.Rows)
                    {
                        // Accediendo a los datos de cada columna en la fila
                        fin = Convert.ToInt32(fila["fin"]);
                        actual = Convert.ToInt32(fila["actual"]);
                        disponible = fin - actual;
                    }
                }
                string mensaje = "El tiraje actual de las facturas aún no ha concluido.\n" +
                                 "Es recomendable crear un nuevo tiraje hasta que se agote el anterior.\n\n" +
                                 "Final del tiraje: " + fin + "\n" +
                                 "Factura actual: " + actual + "\n" +
                                 "Disponible: " + disponible + "\n\n" +
                                 "Al agregar un nuevo tiraje, se DESACTIVARA el tiraje actual y el nuevo tiraje se establecerá como ACTIVO.\n\n" +
                                 "¿Deseas continuar con la creación del nuevo tiraje?";
                if (MessageBox.Show(mensaje, "Mensaje de advertencia CAMBIO DE TIRAJE EN: " + tipo.ToUpper() , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }

                return resultado;
            }
            catch (Exception)
            {
                return resultado;
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            TPV.GUI.AutorizarCambio f = new TPV.GUI.AutorizarCambio();
            f.ShowDialog();

            int pin = Int32.Parse(f.txtPin.Text);
            int fin = 0;
            int actual = 0;
            if (pin != 0)
            {
                DataTable filas = DataManager.DBConsultas.IniciarSesion(pin.ToString());
                int id = int.Parse(dgvDatos.CurrentRow.Cells["idTiraje"].Value.ToString());
                String tipo = dgvDatos.CurrentRow.Cells["tipoFactura"].Value.ToString();
                bool estado = true;
                bool existe = false;

                DataTable result = DataManager.DBConsultas.TirajeFact(tipo);
                if (result.Rows.Count > 0)
                {
                    existe = true;
                    foreach (DataRow fila in result.Rows)
                    {
                        // Accediendo a los datos de cada columna en la fila
                        fin = Convert.ToInt32(fila["fin"]);
                        actual = Convert.ToInt32(fila["actual"]);
                    }
                }
                if (filas.Rows.Count > 0)
                {
                    if (Int32.Parse(filas.Rows[0]["idRol"].ToString()) == 1)
                    {
                        if (existe)
                        {
                            if (fin > actual)
                            {
                                if (Mensaje(tipo))
                                {
                                    if (DesactivarEstado(tipo))
                                    {
                                        if (CambiarEstado(id, estado, tipo))
                                        {
                                            MessageBox.Show("Cambios realizados con exito!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ListaPorTipo(comboBox2.Text);
                                        }
                                    }
                                }
                            }
                            else if (fin == actual)
                            {
                                if (DesactivarEstado(tipo))
                                {
                                    if (CambiarEstado(id, estado, tipo))
                                    {
                                        MessageBox.Show("Cambios realizados con exito!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ListaPorTipo(comboBox2.Text);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un problema!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (CambiarEstado(id, estado, tipo))
                            {
                                MessageBox.Show("Cambios realizados con exito!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ListaPorTipo(comboBox2.Text);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tiene permiso para esta accion!");
                    }

                }
                else
                {
                    MessageBox.Show("Pin incorrecto, intentelo nuevamente!");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ListaPorTipo(comboBox2.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Mantenimiento.CLS.Tiraje_Factura tf = new Mantenimiento.CLS.Tiraje_Factura();
            tf.IdTiraje = int.Parse(dgvDatos.CurrentRow.Cells["idTiraje"].Value.ToString());
            bool estado = Convert.ToBoolean((dgvDatos.CurrentRow.Cells["activo"].Value.ToString()));

            if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (estado)
                {
                    MessageBox.Show("¡No se puede eliminar el tiraje porque se encuentra activo!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (tf.Eliminar())
                    {
                        MessageBox.Show("¡Registro eliminado correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListaPorTipo(comboBox2.Text);
                    }
                    else
                    {
                        MessageBox.Show("No es posible eliminar este tiraje porque ya ha sido utilizado en registros de facturas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
