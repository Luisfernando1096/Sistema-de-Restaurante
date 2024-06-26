﻿using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;


namespace Finanzas.GUI
{
    public partial class Egresos : Form
    {
        BindingSource datos = new BindingSource();
        BindingSource datos1 = new BindingSource();
        SessionManager.Session oUsuario = SessionManager.Session.Instancia;
        int idCajaAbierta;

        public Egresos()
        {
            InitializeComponent();
            txtCantidad.TextChanged += txtCantidad_TextChanged;
            ConsultarCaja();
        }
        private void CargarDatos(int id)
        {
            try
            {
                datos1.DataSource = DataManager.DBConsultas.EgresoPorIdCaja(id);
                dgvDatos.DataSource = datos1;
                dgvDatos.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Egreso();
                dgvDatosCaja.DataSource = datos;
                dgvDatosCaja.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FiltrarDatos()
        {
            try
            {
                string Desde = txtDesde.Text;
                string hasta = txtHasta.Text;
                if (!txtDesde.Text.Equals("") || !txtHasta.Text.Equals(""))
                {
                    
                    if (rbNinguno.Checked)
                    {
                        datos.DataSource = DataManager.DBConsultas.ConsultaFiltros1(Desde, hasta);
                        dgvDatosCaja.DataSource = datos;
                        dgvDatosCaja.AutoGenerateColumns = false;
                    }
                    else if (rbCaja.Checked)
                    {
                        if (!txtNumero.Text.Equals(""))
                        {
                            datos.DataSource = DataManager.DBConsultas.ConsultaFiltros2(Desde, hasta, Int32.Parse(txtNumero.Text));
                            dgvDatosCaja.DataSource = datos;
                            dgvDatosCaja.AutoGenerateColumns = false;
                        }
                    }
                }
                else
                {
                    if (rbCaja.Checked)
                    {
                        if (!txtNumero.Text.Equals(""))
                        {
                            datos.DataSource = DataManager.DBConsultas.ConsultaFiltros2(Desde, hasta, Int32.Parse(txtNumero.Text));
                            dgvDatosCaja.DataSource = datos;
                            dgvDatosCaja.AutoGenerateColumns = false;
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
        private void Limpiar()
        {
            try
            {
                txtDesde.Text = string.Empty;
                txtHasta.Text = string.Empty;
                txtDescripcion.Text = "";
                txtCantidad.Text = "";
                txtDescripcion.Tag = null;
                txtCantidad.Tag = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dateTPDesde_ValueChanged(object sender, EventArgs e)
        {
            txtDesde.Text = dateTPDesde.Value.ToString("yyyy-MM-dd");
            FiltrarDatos();
        }

        private void dateTPHasta_ValueChanged(object sender, EventArgs e)
        {
            txtHasta.Text = dateTPHasta.Value.ToString("yyyy-MM-dd");
            FiltrarDatos();
        }

        private void Egresos_Load(object sender, EventArgs e)
        {
            rbNinguno.Checked = true;
            FiltrarDatos();
            CargarDatos();
            CargarDatos(idCajaAbierta);
        }

        private void txtDesde_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void txtHasta_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void rbCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNinguno.Checked == true)
            {
                rbNinguno.Checked = false;
                rbCaja.Checked = true;
                FiltrarDatos();
            }
            else
            {
                FiltrarDatos();
            }
        }

        private void rbNinguno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCaja.Checked == true)
            {
                rbCaja.Checked = false;
                rbNinguno.Checked = true;
                FiltrarDatos();
            }
            else
            {
                FiltrarDatos();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evita que el carácter ingresado se muestre en el TextBox
                MessageBox.Show("El formato debe ser YYYY-MM-DD");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
            FiltrarDatos();
        }

        private void txtHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evita que el carácter ingresado se muestre en el TextBox
                MessageBox.Show("El formato debe ser YYYY-MM-DD");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Mantenimiento.CLS.Egreso egreso = new Mantenimiento.CLS.Egreso();
                egreso.IdEgreso = Int32.Parse(dgvDatos.CurrentRow.Cells["idEgreso1"].Value.ToString());
                egreso.Eliminar();

                Mantenimiento.CLS.Caja caja = new Mantenimiento.CLS.Caja();
                caja.IdCaja = idCajaAbierta;
                caja.Saldo = Double.Parse(lblEfectivo.Text) + Double.Parse(dgvDatos.CurrentRow.Cells["cantidad1"].Value.ToString());
                caja.ActualizarSaldo();

                Limpiar();
                CargarDatos(idCajaAbierta);
                ConsultarCaja();
                MessageBox.Show("Operacion exitosa. ", "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }

        private void btnSalirIngrediente_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                txtDescripcion.Tag = dgvDatos.CurrentRow.Cells["idEgreso1"].Value.ToString();
                txtDescripcion.Text = dgvDatos.CurrentRow.Cells["descripcion1"].Value.ToString();
                txtCantidad.Text = dgvDatos.CurrentRow.Cells["cantidad1"].Value.ToString();
                txtCantidad.Tag = dgvDatos.CurrentRow.Cells["cantidad1"].Value.ToString();
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar la cantidad. ", "Completar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            double res;

            if (idCajaAbierta > 0)
            {
                Mantenimiento.CLS.Egreso egreso = new Mantenimiento.CLS.Egreso();
                egreso.IdCaja = idCajaAbierta;
                egreso.IdUsuario = Int32.Parse(oUsuario.IdUsuario);
                egreso.Fecha = dtpFecha.Text;
                egreso.Descripcion = txtDescripcion.Text;
                egreso.Cantidad = Double.Parse(txtCantidad.Text);

                Mantenimiento.CLS.Caja caja = new Mantenimiento.CLS.Caja();
                caja.IdCaja = idCajaAbierta;

                if (txtDescripcion.Tag == null)
                {
                    //Se insertara
                    egreso.Insertar();
                    caja.Saldo = Double.Parse(lblEfectivo.Text) - Double.Parse(txtCantidad.Text.ToString());
                    caja.ActualizarSaldo();
                }
                else
                {
                    //Se actualizara
                    egreso.IdEgreso = Int32.Parse(txtDescripcion.Tag.ToString());
                    egreso.Actualizar();

                    double cantAnterior = Double.Parse(txtCantidad.Tag.ToString());
                    double cantActual = Double.Parse(txtCantidad.Text.ToString());

                    if (cantAnterior != cantActual)
                    {
                        if (cantAnterior > cantActual)
                        {
                            res = cantAnterior - cantActual;
                            caja.Saldo = Double.Parse(lblEfectivo.Text) + res;
                        }
                        else
                        {
                            res = cantActual - cantAnterior;
                            caja.Saldo = Double.Parse(lblEfectivo.Text) - res;
                        }
                        caja.ActualizarSaldo();
                    }

                }
                Limpiar();
                CargarDatos(idCajaAbierta);
                ConsultarCaja();
                MessageBox.Show("Operacion exitosa. ", "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se realizo, no hay ninguna caja abierta. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

            // Verificar si el texto es numérico con dos decimales
            if (!EsNumeroConDosDecimales(text))
            {
                // Si no es válido, eliminar el último carácter
                if (text.Length > 0)
                {
                    text = text.Substring(0, text.Length - 1);
                }
                else
                {
                    text = string.Empty;
                }

                textBox.Text = text;
            }
        }
        private bool EsNumeroConDosDecimales(string text)
        {
            // Puedes usar una expresión regular para validar números con dos decimales
            // El patrón "^(\d*\.?\d{0,2})$" permite números enteros o con hasta dos decimales
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"^(\d*\.?\d{0,2})$");
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado no es un dígito
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter si no es un dígito ni una tecla de control
            }
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
        private void ConsultarCaja()
        {
            DataTable cajaAbierta = DataManager.DBConsultas.CajaAbierta();
            if (cajaAbierta.Rows.Count > 0)
            {
                lblEfectivo.Text = cajaAbierta.Rows[0]["saldo"].ToString();
                idCajaAbierta = Int32.Parse(cajaAbierta.Rows[0]["idCaja"].ToString());
            }
            
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Limpiar();
            FiltrarDatos();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ImprimirEgresos(datos1);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ImprimirEgresos(datos);
        }

        private void ImprimirEgresos(BindingSource dt)
        {
            // Supongamos que tienes un BindingSource llamado myBindingSource
            DataTable dataTable = null;

            // Verifica si la DataSource del BindingSource es un DataTable
            if (dt.DataSource is DataTable)
            {
                // Si lo es, castea la DataSource a un DataTable
                dataTable = (DataTable)dt.DataSource;
            }
            else if (dt.DataSource is DataView)
            {
                // Si la DataSource es un DataView, obtén la tabla subyacente
                DataView dataView = (DataView)dt.DataSource;
                dataTable = dataView.Table;
            }


            //Programar reporte de compras
            using (Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral())
            {
                using (Reportes.REP.RepEgresos rep = new Reportes.REP.RepEgresos())
                {
                    f.GenerarReporte(rep, dataTable, "", "", "");
                    f.ShowDialog();
                }
            }
                
        }

    }
}
