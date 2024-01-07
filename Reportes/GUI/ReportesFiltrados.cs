using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.GUI
{
    public partial class ReportesFiltrados : Form
    {
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;
        ConfiguracionManager.CLS.Ticket oTicket = ConfiguracionManager.CLS.Ticket.Instancia;
        public ReportesFiltrados()
        {
            InitializeComponent();
        }

        private void btnSalirIngrediente_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            pbInicio.Visible = false;
            pbFin.Visible = false;
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
        }

        private void dtpFechaDesde_CloseUp(object sender, EventArgs e)
        {
            if (dtpInicio.Value.Date > dtpFin.Value.Date)
            {
                pbInicio.Visible = false;
                dtpInicio.Value = DateTime.Now;
                MessageBox.Show("Debe seleccionar un rango de fecha valido.");
                return;
            }
            pbInicio.Visible = true;
        }

        private void dtpFechaHasta_CloseUp(object sender, EventArgs e)
        {
            if (dtpInicio.Value.Date > dtpFin.Value.Date)
            {
                pbFin.Visible = false;
                dtpFin.Value = DateTime.Now;
                MessageBox.Show("Debe seleccionar un rango de fecha valido.");
                return;
            }
            pbFin.Visible = true;
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            ProcesoImpresionReportes("compras");
        }

        private void ProcesoImpresionReportes(string valor)
        {
            if (pbInicio.Visible)
            {
                if (pbFin.Visible)
                {
                    //Rango de fechas seleccionado
                    if (valor.Equals("compras"))
                    {
                        //Generar reporte de compras
                        if (cmbTipoCompras.SelectedIndex == 0)
                        {
                            //Programar reporte de compras

                        }
                        else if (cmbTipoCompras.SelectedIndex == 1)
                        {
                            
                        }
                        else if (cmbTipoCompras.SelectedIndex == 2)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un tipo de reporte.");
                        }

                    }
                    else if (valor.Equals("ventas"))
                    {
                        //Generar reporte de ventas
                        if (cmbTipoVetas.SelectedIndex == 0)
                        {
                            //Ventas por periodo
                            Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                            DataTable datos = DataManager.DBConsultas.RepResumenVentasPorPeriodo(dtpInicio.Text.ToString(), dtpFin.Text.ToString());
                            REP.RepVentasPorPeriodo rep = new REP.RepVentasPorPeriodo();
                            f.GenerarReporte(rep, datos, dtpInicio.Text.ToString(), dtpFin.Text.ToString(), "");
                            f.Show();
                        } else if (cmbTipoVetas.SelectedIndex == 1)
                        {
                            //Ventas Resumen por periodo
                            Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                            DataTable datos = DataManager.DBConsultas.RepResumenVentasPorPeriodo(dtpInicio.Text.ToString(), dtpFin.Text.ToString());
                            REP.RepVentasResumenPorPeriodo rep = new REP.RepVentasResumenPorPeriodo();
                            f.GenerarReporte(rep, datos, dtpInicio.Text.ToString(), dtpFin.Text.ToString(), "");
                            f.Show();
                        }
                        else if (cmbTipoVetas.SelectedIndex == 2)
                        {

                        } else if (cmbTipoVetas.SelectedIndex == 3)
                        {

                        } else if (cmbTipoVetas.SelectedIndex == 4)
                        {

                        }
                        else if (cmbTipoVetas.SelectedIndex == 5)
                        {

                        }
                        else if (cmbTipoVetas.SelectedIndex == 6)
                        {

                        }
                        else if (cmbTipoVetas.SelectedIndex == 7)
                        {
                            //Agrupado por productos
                            Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                            DataTable datos = DataManager.DBConsultas.RepVentasAgrupadasPorProducto(dtpInicio.Text.ToString(), dtpFin.Text.ToString());
                            REP.RepVentasAgrupadoPorProducto rep = new REP.RepVentasAgrupadoPorProducto();
                            f.GenerarReporte(rep, datos, dtpInicio.Text.ToString(), dtpFin.Text.ToString(), "");
                            f.Show();
                        }
                        else if (cmbTipoVetas.SelectedIndex == 8)
                        {
                            //Agrupado por productos Resumen
                            /*DataTable datos = DataManager.DBConsultas.RepVentasAgrupadasPorProducto(dtpInicio.Text.ToString(), dtpFin.Text.ToString());
                            REP.RepVentasProductosResumen rep = new REP.RepVentasProductosResumen();
                            GenerarReporte(rep, datos, dtpInicio.Text.ToString(), dtpFin.Text.ToString(), "");*/

                            Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                            REP.RepVentasPorFechas oReporte = new REP.RepVentasPorFechas();
                            DataTable datos = DataManager.DBConsultas.RepVentasAgrupadasPorProductoResumen(dtpInicio.Text.ToString(), dtpFin.Text.ToString());
                            f.GenerarReporte(oReporte, datos, dtpInicio.Text.ToString(), dtpFin.Text.ToString(), "");
                            f.Show();
                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un tipo de reporte.");
                        }
                    }
                    else if (valor.Equals("propinas"))
                    {
                        //Generar reporte de propinas

                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar la fecha final.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar la fecha inicial.");
            }
        }

        //private void GenerarReporte(ReportClass oReporte, DataTable datos, string fi, string ff, string f)
        //{
        //    oReporte.SetDataSource(datos);
        //    if (!f.Equals(""))
        //    {
        //        // Convertir la cadena a DateTime
        //        if (DateTime.TryParse(f, out DateTime fecha))
        //        {
        //            // Formatear la fecha
        //            string fechaFormateada = fecha.ToString("dd-MM-yyyy");

        //            oReporte.SetParameterValue("Fecha", fechaFormateada);
        //        }
        //        else
        //        {
        //            Console.WriteLine("La cadena no es un formato de fecha válido.");
        //        }
                
        //    }
        //    if (!fi.Equals(""))
        //    {
        //        // Convertir la cadena a DateTime
        //        if (DateTime.TryParse(fi, out DateTime fecha))
        //        {
        //            // Formatear la fecha
        //            string fechaFormateada = fecha.ToString("dd-MM-yyyy");

        //            oReporte.SetParameterValue("fInicio", fechaFormateada);
        //        }
        //        else
        //        {
        //            Console.WriteLine("La cadena no es un formato de fecha válido.");
        //        }
        //    }
        //    if (!ff.Equals(""))
        //    {
        //        // Convertir la cadena a DateTime
        //        if (DateTime.TryParse(ff, out DateTime fecha))
        //        {
        //            // Formatear la fecha
        //            string fechaFormateada = fecha.ToString("dd-MM-yyyy");

        //            oReporte.SetParameterValue("fFin", fechaFormateada);
        //        }
        //        else
        //        {
        //            Console.WriteLine("La cadena no es un formato de fecha válido.");
        //        }
        //    }
        //    oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
        //    if (Boolean.Parse(oTicket.ShowSaludo))
        //    {
        //        oReporte.SetParameterValue("Footer", oTicket.Footer3);
        //    }
        //    else
        //    {
        //        oReporte.SetParameterValue("Footer", "");
        //    }
            
        //    if (oReporte != null)
        //    {
        //        try
        //        {
        //            // Imprimir el informe en la impresora seleccionada
        //            PrinterSettings settings = new PrinterSettings
        //            {
        //                PrinterName = oConfiguracion.PrinterInformes
        //            };

        //            oReporte.PrintOptions.PrinterName = settings.PrinterName;
        //            oReporte.PrintToPrinter(1, false, 0, 0);

        //            // Muestra un mensaje de éxito en el hilo de la interfaz de usuario
        //            this.Invoke((MethodInvoker)delegate {
        //                MessageBox.Show($"Finalizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            });
        //        }
        //        catch (Exception ex)
        //        {
        //            // Manejo de excepciones: muestra un mensaje de error en caso de problemas
        //            this.Invoke((MethodInvoker)delegate {
        //                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            });
        //        }
        //    }
        //}

        private void btnVentas_Click(object sender, EventArgs e)
        {
            ProcesoImpresionReportes("ventas");
        }

        private void btnVerPropinas_Click(object sender, EventArgs e)
        {
            ProcesoImpresionReportes("propinas");
        }

    }
}
