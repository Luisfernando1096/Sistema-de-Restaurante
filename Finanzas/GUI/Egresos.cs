using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Finanzas.GUI
{
    public partial class Egresos : Form
    {
        BindingSource datos = new BindingSource();
        BindingSource datos1 = new BindingSource();

        public Egresos()
        {
            InitializeComponent();
        }
        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Egreso();
                dgvDatosCaja.DataSource = datos;
                dgvDatosCaja.AutoGenerateColumns = false;

                datos1.DataSource = DataManager.DBConsultas.Egreso();
                dgvDatos.DataSource = datos1;
                dgvDatos.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarListaCaja()
        {
            try
            {
                // Obtener los datos
                DataTable caja = DataManager.DBConsultas.Caja();

                // Crear un nuevo DataTable con la estructura
                DataTable dt = caja.Clone();

                // Fusionar los datos de categoría con el nuevo DataTable
                dt.Merge(caja);

                // Asignar el origen de datos al ComboBox
                cmbCaja.DataSource = dt;
                cmbCaja.DisplayMember = "idCaja";
                cmbCaja.ValueMember = "idCaja";
            }
            catch (Exception)
            {
                throw;
            }
        }
        //private void FiltrarDatosDgv() 
        //{
        //    try
        //    {
        //        string dateStringDesde = txtDesde.Text;
        //        string dateStringHasta = txtHasta.Text;
        //        dgvDatosCaja.CurrentCell = null;
        //        if (rbNinguno.Checked == true)
        //        {
        //            if (txtDesde.Text == string.Empty && txtHasta.Text == string.Empty)
        //            {
        //                CargarDatos();
        //            }
        //            else if (txtDesde.Text != string.Empty && txtHasta.Text == string.Empty)
        //            {
        //                DateTime datoString;

        //                if (DateTime.TryParse(txtDesde.Text, out datoString))
        //                {
        //                    foreach (DataGridViewRow item in dgvDatos.Rows)
        //                    {
        //                        item.Visible = false;

        //                        DateTime datoCells = Convert.ToDateTime(item.Cells["fecha"].Value.ToString());

        //                        if (datoString <= datoCells)
        //                        {
        //                            item.Visible = true;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    // La conversión falló, txtDesde.Text no es una fecha válida.
        //                    MessageBox.Show("Error en el formato de fecha");
        //                }
        //            }
        //            else if (txtDesde.Text == string.Empty && txtHasta.Text != string.Empty)
        //            {
        //                DateTime datoString;

        //                if (DateTime.TryParse(txtHasta.Text, out datoString))
        //                {
        //                    foreach (DataGridViewRow item in dgvDatos.Rows)
        //                    {
        //                        item.Visible = false;

        //                        DateTime datoCells = Convert.ToDateTime(item.Cells["fecha"].Value.ToString());

        //                        if (datoString >= datoCells)
        //                        {
        //                            item.Visible = true;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    // La conversión falló, txtHasta.Text no es una fecha válida.
        //                    MessageBox.Show("Error en el formato de fecha");
        //                }
        //            }

        //        }
        //        else if (true)
        //        {

        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        private void FiltrarDatos() 
        {
            try
            {
                string Desde = txtDesde.Text;
                string hasta = txtHasta.Text;

                if (rbNinguno.Checked)
                {
                    datos.DataSource = DataManager.DBConsultas.ConsultaFiltros1(Desde, hasta);
                    dgvDatosCaja.DataSource = datos;
                    dgvDatosCaja.AutoGenerateColumns = false;
                }
                else if (rbCaja.Checked)
                {
                    int combo = int.Parse(cmbCaja.Text);
                    datos.DataSource = DataManager.DBConsultas.ConsultaFiltros2(Desde, hasta, combo);
                    dgvDatosCaja.DataSource = datos;
                    dgvDatosCaja.AutoGenerateColumns = false;
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
            CargarListaCaja();
            CargarDatos();
        }

        private void txtDesde_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void txtHasta_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void cmbCaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void rbCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNinguno.Checked == true)
            {
                rbNinguno.Checked = false;
                rbCaja.Checked = true;
                cmbCaja.Visible = true;
                FiltrarDatos();
            }
            else
            {
                cmbCaja.Visible = true;
                FiltrarDatos();
            }
        }

        private void rbNinguno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCaja.Checked == true)
            {
                rbCaja.Checked = false;
                rbNinguno.Checked = true;
                cmbCaja.Visible = false;
                FiltrarDatos();
            }
            else
            {
                cmbCaja.Visible = false;
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

        private void chBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chBox.Checked == true)
            {
                cmbCaja1.Visible = true;
                rbtn1Caja.Visible = true;
                cmbCaja1.Visible = true;
                rbtn1Usuario.Visible = true;
            }
            else
            {
                cmbCaja1.Visible = false;
                rbtn1Caja.Visible = false;
                cmbCaja1.Visible = false;
                rbtn1Usuario.Visible = false;
            }
        }

        private void rbtn1Caja_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void txtHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evita que el carácter ingresado se muestre en el TextBox
                MessageBox.Show("El formato debe ser YYYY-MM-DD");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
