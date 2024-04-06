using Mantenimiento.CLS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Respaldos.GUI
{
    public partial class Vaciar : Form
    {
        DataManager.DBOperacion op = new DataManager.DBOperacion();
        Boolean autoriacion = true;
        List<String> lstDetalle = new List<string>();
        private Respaldos.Extra.ProgressBar progressBarHelper = new Respaldos.Extra.ProgressBar();
        public Vaciar()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkPedido_Click(object sender, EventArgs e)
        {
            if (chkPedido.Checked)
            {
                chkPagoC.Checked = true;
                chkPagoC.Enabled = false;

                chkPedioLog.Checked = true;
                chkPedioLog.Enabled = false;

                chkPedidoDeta.Checked = true;
                chkPedidoDeta.Enabled = false;

                chkMesa.Checked = true;
                chkMesa.Enabled = false;
            }
            else
            {
                chkPagoC.Checked = false;
                chkPagoC.Enabled = true;

                chkPedioLog.Checked = false;
                chkPedioLog.Enabled = true;

                chkPedidoDeta.Checked = false;
                chkPedidoDeta.Enabled = true;

                chkMesa.Checked = false;
                chkMesa.Enabled = true;
            }
        }

        private void chkCompra_Click(object sender, EventArgs e)
        {
            if (chkCompra.Checked)
            {
                chkCompraDett.Checked = true;
                chkCompraDett.Enabled = false;
            }
            else
            {
                chkCompraDett.Checked = false;
                chkCompraDett.Enabled = true;
            }
        }

        private void chkCaja_Click(object sender, EventArgs e)
        {
            if (chkCaja.Checked)
            {
                chkEgreso.Checked = true;
                chkEgreso.Enabled = false;
            }
            else
            {
                chkEgreso.Checked = false;
                chkEgreso.Enabled = true;
            }
        }

        private void bntVaciar_Click(object sender, EventArgs e)
        {
            if (chkMesa.Checked || chkCaja.Checked || chkEgreso.Checked || chkPedido.Checked || chkPedidoDeta.Checked || chkPedidoDeta.Checked || chkPedioLog.Checked || chkCompra.Checked || chkCompraDett.Checked)
            {
                DialogResult result = MessageBox.Show("Esta seguro que desea eliminar los datos de las tablas selecionadas", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    if (!autoriacion)
                    {
                        if (progressBar2.Value == progressBar2.Maximum)
                        {
                            VaciarTablas();
                            autoriacion = true;
                        }
                    }
                    else
                    {
                        VaciarTablas();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos una tabla", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Respaldo() 
        {
            try
            {
                autoriacion = false;
                progressBar1.Value = 0;
                SaveFileDialog direccion = new SaveFileDialog();
                direccion.Filter = "Archivo SQL (*.sql)|*.sql";
                direccion.Title = "Selección de ruta";

                if (direccion.ShowDialog() == DialogResult.OK)
                {
                    string ruta = direccion.FileName;

                    (bool respaldoExitoso, TimeSpan duracionRespaldo) = op.Respaldo(ruta);
                    try
                    {
                        if (respaldoExitoso)
                        {
                            progressBarHelper.ActualizarProgressBar(duracionRespaldo, progressBar1, false);
                        }
                        else
                        {
                            progressBarHelper.ActualizarProgressBar(duracionRespaldo, progressBar1, true);
                        }
                    }
                    catch (Exception)
                    {
                        progressBarHelper.ActualizarProgressBar(duracionRespaldo, progressBar1, true);
                    }
                }
                else
                {
                    autoriacion = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void VaciarTablas() 
        {
            try
            {
                progressBar1.Value = 0;
                PagoCombinado pagcomb = new PagoCombinado();
                PedidoDetalleLog DetalleLog = new PedidoDetalleLog();
                PedidoDetalle Detalle = new PedidoDetalle();
                Pedido Pedido = new Pedido();
                Mesa mesa = new Mesa();

                Compra compra = new Compra();
                Compra_detalle Compra_det = new Compra_detalle();

                Egreso egreso = new Egreso();
                Caja caja = new Caja();

                if (chkPedido.Checked)
                {
                    //Eliminar tabla de pago_combinado
                    lstDetalle.Add(pagcomb.EliminarTabla());

                    //Eliminar tabla de detalle_log
                    lstDetalle.Add(DetalleLog.EliminarTabla());

                    //Eliminar tabla de detalle
                    lstDetalle.Add(Detalle.EliminarTabla());

                    //Eliminar tabla de pedido
                    lstDetalle.Add(Pedido.EliminarTabla());

                    //Actualizar mesa
                    lstDetalle.Add(mesa.ActualizarMesas());
                }
                else
                {
                    if (chkMesa.Checked)
                    {
                        lstDetalle.Add(mesa.ActualizarMesas());
                    }
                    if (chkPedidoDeta.Checked)
                    {
                        lstDetalle.Add(Detalle.EliminarTabla());
                    }
                    if (chkPagoC.Checked)
                    {
                        lstDetalle.Add(pagcomb.EliminarTabla());
                    }
                    if (chkPedioLog.Checked)
                    {
                        lstDetalle.Add(DetalleLog.EliminarTabla());
                    }
                }

                if (chkCaja.Checked)
                {
                    //Eliminar tabla de egresos
                    lstDetalle.Add(egreso.EliminarTabla());

                    //Eliminar tabla de caja
                    lstDetalle.Add(caja.EliminarTabla());
                }
                else
                {
                    if (chkEgreso.Checked)
                    {
                        lstDetalle.Add(egreso.EliminarTabla());
                    }
                }

                if (chkCompra.Checked)
                {
                    //Eliminar tabla de compra detalles
                    lstDetalle.Add(Compra_det.EliminarTabla());

                    //Eliminar tabla de compra
                    lstDetalle.Add(compra.EliminarTabla());
                }
                else
                {
                    if (chkCompraDett.Checked)
                    {
                        lstDetalle.Add(Compra_det.EliminarTabla());
                    }
                }

                Ejecutar(lstDetalle);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Ejecutar(List<string> lstDetalles)
        {
            TimeSpan duracionTransaccion;
            try
            {
                Console.WriteLine(lstDetalle.Count);
                Boolean estado = false;
                DataManager.DBOperacion transaccion = new DataManager.DBOperacion();
                Stopwatch stopwatch = new Stopwatch(); // Crear una instancia de Stopwatch
                stopwatch.Start(); // Iniciar el cronómetro
                if (transaccion.EjecutarScript(lstDetalles))
                {
                    estado = true;
                    lstDetalles.Clear();
                    lstDetalle.Clear();
                }
                else
                {
                    lstDetalles.Clear();
                    lstDetalle.Clear();
                }
                stopwatch.Stop(); // Detener el cronómetro
                duracionTransaccion = stopwatch.Elapsed;
                TimeSpan cincoSegundos = TimeSpan.FromSeconds(5);
                duracionTransaccion += cincoSegundos;

                if (estado)
                {
                    progressBarHelper.ActualizarProgressBar(duracionTransaccion, progressBar1, false);
                }
                else
                {
                    progressBarHelper.ActualizarProgressBar(duracionTransaccion, progressBar1, true);
                }
            }
            catch (Exception)
            {
                //progressBarHelper.ActualizarProgressBar(duracionTransaccion, progressBar1, true);
            }
        }

        private void bntRespaldo_Click(object sender, EventArgs e)
        {
            Respaldo();
        }
    }
}
