using System;
using System.Data;
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
                String inicio = dtpInicio.Text.ToString();
                String fin = dtpFin.Text.ToString();
                if (!pbFin.Visible)
                {
                    fin = dtpInicio.Text.ToString();
                }
                //Rango de fechas seleccionado
                if (valor.Equals("compras"))
                {
                    //Generar reporte de compras
                    if (cmbTipoCompras.SelectedIndex == 0)
                    {
                        //Programar reporte de compras
                        Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                        DataTable datos = DataManager.DBConsultas.RepComprasProveedorComprobante(inicio, fin);
                        REP.RepCompras rep = new REP.RepCompras();
                        f.GenerarReporte(rep, datos, inicio, fin, "");
                        f.Show();
                    }
                    else if (cmbTipoCompras.SelectedIndex == 1)
                    {
                        //Programar reporte compras / proveedor
                        Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                        DataTable datos = DataManager.DBConsultas.RepComprasProveedorComprobante(inicio, fin);
                        REP.RepComprasProveedor rep = new REP.RepComprasProveedor();
                        f.GenerarReporte(rep, datos, inicio, fin, "");
                        f.Show();
                    }
                    else if (cmbTipoCompras.SelectedIndex == 2)
                    {
                        //Programar reporte compras / comprobante
                        Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                        DataTable datos = DataManager.DBConsultas.RepComprasProveedorComprobante(inicio, fin);
                        REP.RepComprasComprobante rep = new REP.RepComprasComprobante();
                        f.GenerarReporte(rep, datos, inicio, fin, "");
                        f.Show();
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
                        //Ventas
                        Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                        DataTable datos = DataManager.DBConsultas.RepResumenVentasPorPeriodo(inicio, fin);
                        REP.RepVentasPorPeriodo rep = new REP.RepVentasPorPeriodo();
                        f.GenerarReporte(rep, datos, inicio, fin, "");
                        f.Show();
                    }
                    else if (cmbTipoVetas.SelectedIndex == 1)
                    {
                        //Ventas Resumen
                        Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                        DataTable datos = DataManager.DBConsultas.RepResumenVentasPorPeriodo(inicio, fin);
                        REP.RepVentasResumenPorPeriodo rep = new REP.RepVentasResumenPorPeriodo();
                        f.GenerarReporte(rep, datos, inicio, fin, "");
                        f.Show();
                    }
                    else if (cmbTipoVetas.SelectedIndex == 2)
                    {
                        //Ventas / Mesero
                        Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                        DataTable datos = DataManager.DBConsultas.RepResumenVentasPorPeriodo(inicio, fin);
                        REP.RepVentasMesero rep = new REP.RepVentasMesero();
                        f.GenerarReporte(rep, datos, inicio, fin, "");
                        f.Show();

                    }
                    else if (cmbTipoVetas.SelectedIndex == 3)
                    {
                        //Ventas / Mesero Resumen
                        Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                        DataTable datos = DataManager.DBConsultas.RepResumenVentasPorPeriodo(inicio, fin);
                        REP.RepVentasMeseroResumen rep = new REP.RepVentasMeseroResumen();
                        f.GenerarReporte(rep, datos, inicio, fin, "");
                        f.Show();

                    }
                    else if (cmbTipoVetas.SelectedIndex == 4)
                    {
                        //Ventas Facturadas
                        Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                        DataTable datos = DataManager.DBConsultas.RepVentasFacturadas(inicio, fin);
                        REP.RepVentasPorPeriodo rep = new REP.RepVentasPorPeriodo();
                        f.GenerarReporte(rep, datos, inicio, fin, "");
                        f.Show();
                    }
                    else if (cmbTipoVetas.SelectedIndex == 5)
                    {
                        //Facturas Anuladas

                    }
                    else if (cmbTipoVetas.SelectedIndex == 6)
                    {
                        //Ventas Productos

                    }
                    else if (cmbTipoVetas.SelectedIndex == 7)
                    {
                        //Ventas Productos Agrupados
                        Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                        DataTable datos = DataManager.DBConsultas.RepVentasAgrupadasPorProducto(inicio, fin);
                        REP.RepVentasAgrupadoPorProducto rep = new REP.RepVentasAgrupadoPorProducto();
                        f.GenerarReporte(rep, datos, inicio, fin, "");
                        f.Show();
                    }
                    else if (cmbTipoVetas.SelectedIndex == 8)
                    {
                        //Ventas Productos Resumen

                        Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                        REP.RepVentasPorFechas oReporte = new REP.RepVentasPorFechas();
                        DataTable datos = DataManager.DBConsultas.RepVentasAgrupadasPorProductoResumen(inicio, fin);
                        f.GenerarReporte(oReporte, datos, inicio, fin, "");
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

        private void btnVerInforme_Click(object sender, EventArgs e)
        {
            if (cmbVerInforme.SelectedIndex == 0)
            {
                //Productos con stock minimo
                Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                Reportes.REP.RepProductoSinStock oReporte = new Reportes.REP.RepProductoSinStock();
                DataTable datos = DataManager.DBConsultas.ProductosSinStock();
                oReporte.SetDataSource(datos);
                f.GenerarReporte(oReporte, datos, "", "", "");
                f.Show();
            }
            else if (cmbVerInforme.SelectedIndex == 1)
            {

            }
            else if (cmbVerInforme.SelectedIndex == 2)
            {
                //Productos con stock minimo
                Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
                Reportes.REP.RepProductoStockMinimo oReporte = new Reportes.REP.RepProductoStockMinimo();
                DataTable datos = DataManager.DBConsultas.ProductosStockMinimo();
                oReporte.SetDataSource(datos);
                f.GenerarReporte(oReporte, datos, "", "", "");
                f.Show();
            }
        }
    }
}
