using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finanzas.GUI
{
    public partial class CierreCaja : Form
    {
        SessionManager.Session oUsuario = SessionManager.Session.Instancia;
        BindingSource datos = new BindingSource();
        public CierreCaja()
        {
            InitializeComponent();
            dtpFecha.Text = DateTime.Now.ToString();
        }

        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Cajas(true);
                dgvCajas.DataSource = datos;
                dgvCajas.AutoGenerateColumns = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CierreCaja_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
            CargarDatos();
            txtSaldoInicial.Text = dgvCajas.CurrentRow.Cells["saldoInicial"].Value.ToString();
            txtSalidaEfectivo.Text = dgvCajas.CurrentRow.Cells["cantidad"].Value.ToString();
            txtSaldoCaja.Text = dgvCajas.CurrentRow.Cells["saldo"].Value.ToString();
            txtEfectivoRecaudado.Text = dgvCajas.CurrentRow.Cells["efectivo"].Value.ToString();
            txtCajero.Text = oUsuario.Usuario;
            txtCajero.Tag = oUsuario.IdUsuario;
            txtIdCaja.Text = dgvCajas.CurrentRow.Cells["idCaja"].Value.ToString();
        }

        private void CierreCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtpFecha.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
