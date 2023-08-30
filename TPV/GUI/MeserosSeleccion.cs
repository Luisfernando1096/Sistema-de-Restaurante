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
    public partial class MeserosSeleccion : Form
    {
        internal int idPedido;

        public MeserosSeleccion()
        {
            InitializeComponent();
        }

        private void MeserosSeleccion_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                DataTable meseros = DataManager.DBConsultas.Meseros();
                if (meseros.Rows.Count > 0)
                {
                    foreach (DataRow mesero in meseros.Rows)
                    {
                        btnMesero = new Button();
                        btnMesero.Text = mesero["nombres"].ToString().ToUpper();
                        btnMesero.Tag = mesero["idEmpleado"].ToString().ToUpper();
                        btnMesero.Size = new Size(190, 75);
                        btnMesero.Click += BotonMesero_Click;
                        flpMeseros.Controls.Add(btnMesero);
                        flpMeseros.ScrollControlIntoView(btnMesero);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BotonMesero_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        
    }
}
