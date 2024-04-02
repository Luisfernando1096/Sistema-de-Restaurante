using System;
using System.Data;
using System.Windows.Forms;

namespace Reportes.GUI
{
    public partial class ReportesFiltrados : Form
    {
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
                MessageBox.Show("Debe seleccionar un rango de fecha valido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Debe seleccionar un rango de fecha valido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        using (VisorGeneral f = new VisorGeneral())
                        {
                            using (REP.RepCompras rep = new REP.RepCompras())
                            {
                                DataTable datos = DataManager.DBConsultas.RepComprasProveedorComprobante(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio, fin, "");
                                f.ShowDialog();
                            }
                        }
                            
                    }
                    else if (cmbTipoCompras.SelectedIndex == 1)
                    {
                        //Programar reporte compras / proveedor
                        using (VisorGeneral f = new VisorGeneral())
                        {
                            using (REP.RepComprasProveedor rep = new REP.RepComprasProveedor())
                            {
                                DataTable datos = DataManager.DBConsultas.RepComprasProveedorComprobante(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio, fin, "");
                                f.ShowDialog();
                            }
                        }
                            
                    }
                    else if (cmbTipoCompras.SelectedIndex == 2)
                    {
                        using (VisorGeneral f = new VisorGeneral())
                        {
                            using (REP.RepComprasComprobante rep = new REP.RepComprasComprobante())
                            {
                                DataTable datos = DataManager.DBConsultas.RepComprasProveedorComprobante(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio, fin, "");
                                f.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un tipo de reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else if (valor.Equals("ventas"))
                {
                    //Generar reporte de ventas
                    if (cmbTipoVetas.SelectedIndex == 0)
                    {
                        //Ventas
                        using (VisorGeneral f = new VisorGeneral())
                        {
                            using (REP.RepVentasPorPeriodo rep = new REP.RepVentasPorPeriodo())
                            {
                                DataTable datos = DataManager.DBConsultas.RepResumenVentasPorPeriodo(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio, fin, "");
                                f.ShowDialog();
                            }
                        }
                            
                    }
                    else if (cmbTipoVetas.SelectedIndex == 1)
                    {
                        using (VisorGeneral f = new VisorGeneral())
                        {
                            using (REP.RepVentasResumenPorPeriodo rep = new REP.RepVentasResumenPorPeriodo())
                            {
                                DataTable datos = DataManager.DBConsultas.RepResumenVentasPorPeriodo(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio, fin, "");
                                f.ShowDialog();
                            }
                        }
                    }
                    else if (cmbTipoVetas.SelectedIndex == 2)
                    {
                        using (VisorGeneral f = new VisorGeneral())
                        {
                            using (REP.RepVentasMesero rep = new REP.RepVentasMesero())
                            {
                                DataTable datos = DataManager.DBConsultas.RepResumenVentasPorPeriodo(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio, fin, "");
                                f.ShowDialog();
                            }
                        }
                    }
                    else if (cmbTipoVetas.SelectedIndex == 3)
                    {
                        using (VisorGeneral f = new VisorGeneral())
                        {
                            using (REP.RepVentasMeseroResumen rep = new REP.RepVentasMeseroResumen())
                            {
                                DataTable datos = DataManager.DBConsultas.RepResumenVentasPorPeriodo(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio, fin, "");
                                f.ShowDialog();
                            }
                        }
                    }
                    else if (cmbTipoVetas.SelectedIndex == 4)
                    {
                        using (VisorGeneral f = new VisorGeneral())
                        {
                            using (REP.RepVentasPorPeriodo rep = new REP.RepVentasPorPeriodo())
                            {
                                DataTable datos = DataManager.DBConsultas.RepVentasFacturadas(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio, fin, "");
                                f.ShowDialog();
                            }
                                
                        }
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
                        using (VisorGeneral f = new VisorGeneral())
                        {
                            using (REP.RepVentasAgrupadoPorProducto rep = new REP.RepVentasAgrupadoPorProducto())
                            {
                                DataTable datos = DataManager.DBConsultas.RepVentasAgrupadasPorProducto(inicio, fin);
                                f.GenerarReporte(rep, datos, inicio, fin, "");
                                f.ShowDialog();
                            }
                                
                        }
                            
                    }
                    else if (cmbTipoVetas.SelectedIndex == 8)
                    {
                        //Ventas Productos Resumen
                        using (VisorGeneral f = new VisorGeneral())
                        {
                            using (REP.RepVentasPorFechas oReporte = new REP.RepVentasPorFechas())
                            {
                                DataTable datos = DataManager.DBConsultas.RepVentasAgrupadasPorProductoResumen(inicio, fin);
                                f.GenerarReporte(oReporte, datos, inicio, fin, "");
                                f.ShowDialog();
                            }
                                
                        }
                            
                    }
                    else if (cmbTipoVetas.SelectedIndex == 9)
                    {
                        //Productos Eliminados
                        using (VisorGeneral f = new VisorGeneral())
                        {
                            using (REP.RepProductosEliminadosDePedido oReporte = new REP.RepProductosEliminadosDePedido())
                            {
                                DataTable datos = DataManager.DBConsultas.RepProductosEliminadosDePedidos((inicio + " 00:00:00"), (fin + " 23:59:59"));
                                f.GenerarReporte(oReporte, datos, "", "", "");
                                f.ShowDialog();
                            }
                                
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un tipo de reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (valor.Equals("propinas"))
                {
                    //Generar reporte de propinas

                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar la fecha inicial.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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
                using (VisorGeneral f = new VisorGeneral())
                {
                    using (REP.RepProductoSinStock oReporte = new REP.RepProductoSinStock())
                    {
                        DataTable datos = DataManager.DBConsultas.ProductosSinStock();
                        oReporte.SetDataSource(datos);
                        f.GenerarReporte(oReporte, datos, "", "", "");
                        f.ShowDialog();
                    }
                }
                
                    
            }
            else if (cmbVerInforme.SelectedIndex == 1)
            {
                //Ingredientes sin stock 
                using (VisorGeneral f = new VisorGeneral())
                {
                    using (REP.RepIngredientes oReporte = new REP.RepIngredientes())
                    {
                        DataTable datos = DataManager.DBConsultas.IngredientesSinStock();
                        oReporte.SetDataSource(datos);
                        f.GenerarReporte(oReporte, datos, "", "", "");
                        f.ShowDialog();
                    }
                }
                

            }
            else if (cmbVerInforme.SelectedIndex == 2)
            {
                //Productos con stock minimo
                using (VisorGeneral f = new VisorGeneral())
                {
                    using (REP.RepProductoStockMinimo oReporte = new REP.RepProductoStockMinimo())
                    {
                        DataTable datos = DataManager.DBConsultas.ProductosStockMinimo();
                        oReporte.SetDataSource(datos);
                        f.GenerarReporte(oReporte, datos, "", "", "");
                        f.ShowDialog();
                    }
                }
                    
            }
           
        }
    }
}
