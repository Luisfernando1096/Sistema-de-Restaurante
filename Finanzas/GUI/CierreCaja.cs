using System;
using System.Data;
using System.Windows.Forms;

namespace Finanzas.GUI
{
    public partial class CierreCaja : Form
    {
        SessionManager.Session oUsuario = SessionManager.Session.Instancia;
        BindingSource datos = new BindingSource();
        Boolean cerreCaja = false;
        Mantenimiento.CLS.Caja caja = new Mantenimiento.CLS.Caja();
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

            if (dgvCajas.Rows.Count > 0)
            {
                // La cadena de fecha y hora en formato original
                string fechaHoraString = dgvCajas.CurrentRow.Cells["fechaApertura"].Value.ToString();

                // Define el formato original de la cadena de fecha y hora
                string formatoOriginal = "d/M/yyyy HH:mm:ss";

                // Convierte la cadena en un objeto DateTime
                DateTime fechaHora = DateTime.ParseExact(fechaHoraString, formatoOriginal, System.Globalization.CultureInfo.InvariantCulture);

                // Define el formato deseado
                string formatoDeseado = "yyyy-MM-dd HH:mm:ss";


                double saldo = Double.Parse(dgvCajas.CurrentRow.Cells["saldo"].Value.ToString());
                double efectivo = Double.Parse(dgvCajas.CurrentRow.Cells["efectivo"].Value.ToString());
                double saldoInicial = Double.Parse(dgvCajas.CurrentRow.Cells["saldoInicial"].Value.ToString());
                int idCaja = Int32.Parse(dgvCajas.CurrentRow.Cells["idCaja"].Value.ToString());
                int idCajero = Int32.Parse(dgvCajas.CurrentRow.Cells["idCajero"].Value.ToString());
                string fechaApertura = fechaHora.ToString(formatoDeseado);

                caja.Saldo = saldo;
                caja.SaldoInicial = saldoInicial;
                caja.Efectivo = efectivo;
                caja.IdCaja = idCaja;
                caja.IdCajero = idCajero;
                caja.FechaApertura = fechaApertura;

                txtSaldoInicial.Text = saldoInicial.ToString();
                txtSalidaEfectivo.Text = dgvCajas.CurrentRow.Cells["cantidad"].Value.ToString();
                txtSaldoCaja.Text = saldo.ToString();
                txtEfectivoRecaudado.Text = efectivo.ToString();
                txtCajero.Text = oUsuario.Usuario;
                txtCajero.Tag = oUsuario.IdUsuario;
                txtIdCaja.Text = idCaja.ToString();
            }

        }

        private void CierreCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (cerreCaja)
            {
                caja.FechaCierre = dtpFecha.Tag.ToString();
                caja.Actualizar();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtpFecha.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCajas.Rows.Count > 0)
            {
                //Cerrar Caja
                if (MessageBox.Show("¿Esta seguro que desea cerrar la caja? Una vez cerrado el formulario no podra revertir los cambios.", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {   
                    DataTable info = DataManager.DBConsultas.Cajas(true);
                    dtpFecha.Tag = dtpFecha.Text;
                    caja.Estado = false;
                    cerreCaja = true;
                    if (caja.Actualizar())
                    {
                        MessageBox.Show("¡Se cerro la caja exitosamente!", "Cierre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                        Reportes.REP.RepCierreCaja rep = new Reportes.REP.RepCierreCaja();
                        rep.SetDataSource(info);
                        rep.SetParameterValue("Titulo", "Corte de Caja");

                        f.crvVisor.ReportSource = rep;
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("¡No se pudo cerrar! Contacte al programador.", "Cierre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    CargarDatos();
                }
            }
            else
            {
                //No hay caja abierta
                MessageBox.Show("¡No hay una caja abierta que cerrar.", "Cerrar Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cerreCaja)
            {
                //Deshacer los cambios
                caja.Estado = true;
                cerreCaja = false;
                if (caja.Actualizar())
                {
                    MessageBox.Show("¡Se deshizo la accion correctamente!", "Deshacer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("¡No se pudo deshacer! Contacte al programador.", "Cierre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CargarDatos();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            DataTable info = DataManager.DBConsultas.Cajas(true);
            Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
            Reportes.REP.RepCierreCaja rep = new Reportes.REP.RepCierreCaja();
            rep.SetDataSource(info);
            rep.SetParameterValue("Titulo", "Estado de Caja");
            
            f.crvVisor.ReportSource = rep;
            f.Show();
        }
    }
}
