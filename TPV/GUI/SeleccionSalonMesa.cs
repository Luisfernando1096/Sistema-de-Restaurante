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
    public partial class SeleccionSalonMesa : Form
    {
        public static int idMesa { get; set; }
        public static object Mesa { get; internal set; }

        public SeleccionSalonMesa()
        {
            InitializeComponent();
            cmbSalon.Text.ToUpper();
        }

        public void CargarSalones()
        {
            DataTable salones = new DataTable();
            try
            {
                salones = DataManager.DBConsultas.Salones();
                cmbSalon.DataSource = salones;
                cmbSalon.DisplayMember = "nombre";
                cmbSalon.ValueMember = "idSalon";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CargarMesasOcupadas(){
            DataTable mesas = DataManager.DBConsultas.MesasOcupadas(cmbSalon.SelectedValue.ToString());
            // Crear y agregar botones al FlowLayoutPanel
            foreach (DataRow mesa in mesas.Rows)
            {
                btnMesa = new Button();
                btnMesa.Text = mesa["nombre"].ToString().ToUpper();
                btnMesa.Tag = mesa["idMesa"].ToString().ToUpper();
                btnMesa.TextAlign = ContentAlignment.MiddleCenter;
                btnMesa.Font = new Font("Arial", 20, FontStyle.Bold);
                btnMesa.Size = new Size(253, 42);
                btnMesa.Click += BotonMesa_Click;
                flpMesas.Controls.Add(btnMesa);
                flpMesas.ScrollControlIntoView(btnMesa);
            }
        }

        private void BotonMesa_Click(object sender, EventArgs e)
        {
            Button btnMesa = (Button)sender;
            idMesa = Int32.Parse(btnMesa.Tag.ToString());
            Mesa = btnMesa.Text;
            Close();
        }

        private void SeleccionSalonMesa_Load(object sender, EventArgs e)
        {
            CargarSalones();
            CargarMesasOcupadas();
        }

        private void cmbSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flpMesas.Controls.Count > 0)
            {
                flpMesas.Controls.Clear();
            }
            CargarMesasOcupadas();
        }
    }
}
