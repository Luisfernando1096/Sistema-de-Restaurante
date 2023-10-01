using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compras.GUI
{
    public partial class BuscarProveedor : Form
    {
        BindingSource datos = new BindingSource();
        public string Nombre { get; set; }
        public int ID { get; set; }

        public BuscarProveedor()
        {
            InitializeComponent();
        }
        private void CargarDatos() 
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Proveedor();
                dgvBuscar.DataSource = datos;
                dgvBuscar.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void BuscarDatos()
        {
            try
            {
                dgvBuscar.CurrentCell = null;
                string filtro = cmbLista.Text;

                foreach (DataGridViewRow r in dgvBuscar.Rows)
                {
                    r.Visible = false;

                    if (rbtnNombre.Checked)
                    {
                        string valorCelda = r.Cells["nombre"].Value.ToString();
                        if (valorCelda.StartsWith(filtro, StringComparison.OrdinalIgnoreCase)) // Comparación desde el principio, insensible a mayúsculas y minúsculas
                        {
                            r.Visible = true;
                        }
                    }
                    else if (rbtnNRC.Checked)
                    {
                        string valorCelda = r.Cells["regContable"].Value.ToString();
                        if (valorCelda.StartsWith(filtro, StringComparison.OrdinalIgnoreCase))
                        {
                            r.Visible = true;
                        }
                    }
                    else if (rbtnNIT.Checked)
                    {
                        string valorCelda = r.Cells["NIT"].Value.ToString();
                        if (valorCelda.StartsWith(filtro, StringComparison.OrdinalIgnoreCase))
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


        private void BuscarProveedor_Load(object sender, EventArgs e)
        {
            CargarDatos();
            BuscarDatos();
        }

        private void cmbLista_TextChanged(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void rbtnNombre_CheckedChanged(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void rbtnNRC_CheckedChanged(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void rbtnNIT_CheckedChanged(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void bntSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvBuscar.SelectedRows.Count != 0)
            {
                ID = int.Parse(dgvBuscar.CurrentRow.Cells["idProveedor"].Value.ToString());
                Nombre = dgvBuscar.CurrentRow.Cells["nombre"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
