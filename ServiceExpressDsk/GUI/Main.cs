using System;
using System.Data;
using System.Windows.Forms;

namespace ServiceExpressDsk.GUI
{
    public partial class Main : Form
    {
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;
        ConfiguracionManager.CLS.Ticket oTicket = ConfiguracionManager.CLS.Ticket.Instancia;
        SessionManager.Session oUsuario = SessionManager.Session.Instancia;
        private bool tpv;
        private bool cerrar;
        private int idPedidoSiguiente = 0;
        Server myServer = new Server();

        public Main()
        {
            InitializeComponent();
            // Iniciar el servidor
            myServer.StartServer();

            // Aquí puedes hacer otras cosas en tu aplicación, ya que el servidor se está ejecutando en un hilo separado
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrar)
            {
                DialogResult result = MessageBox.Show("Se cerrara la sesion, ¿esta seguro que desea cerrar sesion?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancelar el cierre del formulario
                }
                else
                {
                    // Detener el servidor (por ejemplo, cuando la aplicación se cierra)
                    myServer.StopServer();
                }
            }
            else
            {
                // Detener el servidor (por ejemplo, cuando la aplicación se cierra)
                myServer.StopServer();
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //Obtener todos los comandos
            DataTable comandos = DataManager.DBConsultas.ComandosPorRol(oUsuario.IdRol);

            if (comandos.Rows.Count > 0)
            {
                this.SuspendLayout();
                foreach (DataRow comando in comandos.Rows)
                {
                    switch (comando["comando"].ToString().Trim())
                    {
                        case "TPV - Ventas":
                            tpvPuntoVenta.Enabled = true;
                            break;
                        case "TPV - Pagos":
                            tpvPuntoPago.Enabled = true;
                            break;
                        case "Administrar Clientes":
                            tpvClientes.Enabled = true;
                            break;
                        case "Tickets procesados":
                            tpvTickets.Enabled = true;
                            break;
                        case "Administrar productos":
                            toolStripButton2.Enabled = true;
                            break;
                        case "Consultar productos":
                            toolStripButton3.Enabled = true;
                            break;
                        case "Administrar ingredientes":
                            toolStripButton4.Enabled = true;
                            break;
                        case "Consultar ingredientes":
                            toolStripButton5.Enabled = true;
                            break;
                        case "Administrar Recetas":
                            toolStripButton6.Enabled = true;
                            break;
                        case "Administrar categorías":
                            toolStripButton7.Enabled = true;
                            break;
                        case "Administrar unidades de medida":
                            toolStripButton9.Enabled = true;
                            break;
                        case "Ajustar stock":
                            toolStripButton8.Enabled = true;
                            break;
                        case "Compras":
                            toolStripButton10.Enabled = true;
                            break;
                        case "Proveedores":
                            toolStripButton11.Enabled = true;
                            break;
                        case "Consultar proveedores":
                            toolStripButton12.Enabled = true;
                            break;
                        case "Administrar Comprobantes de compra":
                            toolStripButton13.Enabled = true;
                            break;
                        case "Salones y mesas":
                            toolStripButton15.Enabled = true;
                            break;
                        case "Apertura de caja":
                            toolStripButton14.Enabled = true;
                            break;
                        case "Cerrar caja":
                            toolStripButton16.Enabled = true;
                            break;
                        case "Administrar salida de efectivo":
                            toolStripButton17.Enabled = true;
                            break;
                        case "Administración cuentas":
                            toolStripButton18.Enabled = true;
                            break;
                        case "Empleados":
                            toolStripButton19.Enabled = true;
                            break;
                        case "Roles":
                            toolStripButton20.Enabled = true;
                            break;
                        case "Asignar roles":
                            toolStripButton21.Enabled = true;
                            break;
                        case "Comandos del sistema":
                            toolStripButton22.Enabled = true;
                            break;
                        case "Permisos":
                            toolStripButton23.Enabled = true;
                            break;
                        case "Visor de eventos":
                            toolStripButton24.Enabled = true;
                            break;
                        case "Administrar sesiones":
                            toolStripButton25.Enabled = true;
                            break;
                        case "Reportes avanzados y financieros":
                            toolStripButton26.Enabled = true;
                            break;
                        case "Reportes básicos":
                            toolStripButton27.Enabled = true;
                            toolStripButton28.Enabled = true;
                            toolStripButton30.Enabled = true;
                            toolStripButton31.Enabled = true;
                            break;
                        case "Reportes de Ventas diarias":
                            toolStripButton29.Enabled = true;
                            break;
                        case "Respaldo de BD":
                            toolStripButton32.Enabled = true;
                            break;
                        case "Restaurar respaldos":
                            toolStripButton33.Enabled = true;
                            break;
                        case "Vaciar BD":
                            toolStripButton34.Enabled = true;
                            break;
                        case "Configuración TPV":
                            toolStripButton35.Enabled = true;
                            break;
                        case "Administrar datos de la empresa":
                            toolStripButton36.Enabled = true;
                            break;
                        case "Configurar tickets":
                            toolStripButton37.Enabled = true;
                            break;
                        case "Tiraje de factura":
                            toolStripButton39.Enabled = true;
                            break;
                        case "Cambiar usuario":
                            //cambiarUsuario.Enabled = true;
                            break;
                    }
                }
                this.ResumeLayout();

                if (oUsuario.IdRol.ToString().Equals("1"))
                {
                    //Administrador

                }
                else if (oUsuario.IdRol.ToString().Equals("2"))
                {
                    //Mesero
                    this.Hide();
                    TPV.GUI.PuntoVenta f = new TPV.GUI.PuntoVenta();
                    f.ShowDialog();
                    this.Show();

                }
                else if (oUsuario.IdRol.ToString().Equals("3"))
                {
                    //Cajero
                    CargarPuntoPago();

                }
                else if (oUsuario.IdRol.ToString().Equals("4"))
                {
                    //Mantenimiento

                }
            }
            else
            {
                //No tiene comandos disponibles

            }

            //lblConexionGreen.Visible = true;
            lblUsuario.Text = "SESION DE : " + oUsuario.Usuario.ToUpper();
            //lblRol.Text = oUsuario.Rol.ToUpper();
            //timer1.Start();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TPV.GUI.PuntoVenta f = new TPV.GUI.PuntoVenta();
            f.ShowDialog();
            cerrar = f.cerrarSesion;
            if (!cerrar)
            {
                this.Show();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CargarPuntoPago();
        }

        private void CargarPuntoPago()
        {
            this.Hide();
            TPV.GUI.PuntoVenta f = new TPV.GUI.PuntoVenta();
            f.Hide();
            TPV.GUI.ComandaGestion f2 = new TPV.GUI.ComandaGestion(f)
            {
                borrarData = true
            };
            f2.Hide();
            TPV.GUI.PuntoPago f3 = new TPV.GUI.PuntoPago(f2);
            f3.ShowDialog();

            if (f3.lblMesa.Tag != null)
            {

                if (!f3.lblTicket.Text.Equals("") && f2.datos == null)
                {
                    DataTable productoEnMesas = DataManager.DBConsultas.ProductosEnMesaConIdPedido(f3.lblMesa.Tag.ToString(), Int32.Parse(f3.lblTicket.Text));

                    if (productoEnMesas.Rows.Count > 0)
                    {
                        idPedidoSiguiente = f3.idPedidoSiguiente;
                        DataTable pedido;
                        //Aqui cargamos los datos en datagrid 
                        if (idPedidoSiguiente > 0)
                        {
                            f2.CargarProductosPorMesayIdPedido(f3.lblMesa.Tag.ToString(), idPedidoSiguiente);
                            f2.lblTicket.Text = idPedidoSiguiente.ToString();//Accedemos a la primera posicion de la tabla
                            pedido = DataManager.DBConsultas.PedidoPorId(idPedidoSiguiente, false);
                        }
                        else
                        {
                            f2.CargarProductosPorMesayIdPedido(f3.lblMesa.Tag.ToString(), Int32.Parse(f3.lblTicket.Text));
                            f2.lblTicket.Text = f3.lblTicket.Text;//Accedemos a la primera posicion de la tabla
                            pedido = DataManager.DBConsultas.PedidoPorId(Int32.Parse(f3.lblTicket.Text), false);
                        }

                        f2.CargarPedidosEnMesa(f3.lblMesa.Tag.ToString());

                        if (!pedido.Rows[0]["nombres"].ToString().Equals(""))
                        {
                            f2.lblMesero.Text = pedido.Rows[0]["nombres"].ToString();
                            f2.lblMesero.Tag = int.Parse(pedido.Rows[0]["idMesero"].ToString());
                        }
                        else
                        {
                            f2.lblMesero.Text = "";
                            f2.lblMesero.Tag = "";
                        }
                        if (!pedido.Rows[0]["nombre"].ToString().Equals(""))
                        {
                            f2.lblCliente.Text = pedido.Rows[0]["nombre"].ToString();
                            f2.lblCliente.Tag = int.Parse(pedido.Rows[0]["idCliente"].ToString());
                        }
                        else
                        {
                            f2.lblCliente.Text = "";
                            f2.lblCliente.Tag = "";
                        }
                    }
                    f2.lblMesa.Text = f3.lblMesa.Text.ToString();
                    f2.lblMesa.Tag = f3.lblMesa.Tag.ToString();
                }


            }

            //Si Se presiona click en cerrar sesion
            cerrar = f2.cerrarSesion;
            tpv = f2.tpv;
            if (!cerrar)
            {
                cerrar = f.cerrarSesion;
            }

            if (cerrar)
            {
                Close();
            }
            else
            {
                if (!tpv)
                {
                    f2.ShowDialog();
                    cerrar = f2.cerrarSesion;
                }

                if (!cerrar)
                {
                    if (!f.admin)
                    {
                        f.cambiarMesa = f2.cambiarMesa;
                        if (f2.lblMesa.Tag != null)
                        {
                            f.idMesaAnterior = Int32.Parse(f2.lblMesa.Tag.ToString());
                            if (!f2.lblTicket.Text.Equals(""))
                            {
                                f.idPedidoCambioMesa = int.Parse(f2.lblTicket.Text);
                            }
                        }

                        f.ShowDialog();
                        cerrar = f.cerrarSesion;
                    }

                    if (!cerrar)
                    {
                        this.Show();
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            TPV.GUI.TicketsProcesados f = new TPV.GUI.TicketsProcesados();
            f.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TPV.GUI.AnularFactura f = new TPV.GUI.AnularFactura();
            f.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Productos f = new Ingredientes_y_Productos.GUI.Productos();
            f.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.BuscarProducto f = new Ingredientes_y_Productos.GUI.BuscarProducto();
            f.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Ingredientes f = new Ingredientes_y_Productos.GUI.Ingredientes();
            f.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.BuscarIngrediente f = new Ingredientes_y_Productos.GUI.BuscarIngrediente();
            f.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Ingredientes f = new Ingredientes_y_Productos.GUI.Ingredientes();
            f.tabControl1.SelectedIndex = 1;
            f.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Productos f = new Ingredientes_y_Productos.GUI.Productos();
            f.tabControl1.SelectedIndex = 1;
            f.ShowDialog();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Productos f = new Ingredientes_y_Productos.GUI.Productos();
            f.tabControl1.SelectedIndex = 2;
            f.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.AjusteStock f = new Ingredientes_y_Productos.GUI.AjusteStock();
            f.tabControl1.SelectedIndex = 2;
            f.ShowDialog();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Compras.GUI.Compras f = new Compras.GUI.Compras();
            f.ShowDialog();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Compras.GUI.Proveedores f = new Compras.GUI.Proveedores();
            f.ShowDialog();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            Compras.GUI.BuscarProveedor f = new Compras.GUI.BuscarProveedor();
            f.ShowDialog();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            Compras.GUI.TipoComprobante f = new Compras.GUI.TipoComprobante();
            f.ShowDialog();
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            Finanzas.GUI.Egresos f = new Finanzas.GUI.Egresos();
            f.ShowDialog();
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            Finanzas.GUI.AdministrarCuentas f = new Finanzas.GUI.AdministrarCuentas();
            f.ShowDialog();
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            Personal.GUI.EmpleadosGestion f = new Personal.GUI.EmpleadosGestion();
            f.ShowDialog();
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            Personal.GUI.RolesGestion f = new Personal.GUI.RolesGestion();
            f.ShowDialog();
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            Personal.GUI.Asignar_roles f = new Personal.GUI.Asignar_roles();
            f.ShowDialog();
        }

        private void toolStripButton41_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            Salones.GUI.SalonesMesas f = new Salones.GUI.SalonesMesas();
            f.ShowDialog();
        }

        private void toolStripContainer3_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            Finanzas.GUI.ApuertaraCaja f = new Finanzas.GUI.ApuertaraCaja();
            f.ShowDialog();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            Finanzas.GUI.CierreCaja f = new Finanzas.GUI.CierreCaja();
            f.ShowDialog();
        }

        private void toolStripButton35_Click(object sender, EventArgs e)
        {
            Configuraciones.GUI.ConfiguracionTPV f = new Configuraciones.GUI.ConfiguracionTPV();
            f.tabControl1.SelectedIndex = 0;
            f.ShowDialog();
        }

        private void toolStripButton36_Click(object sender, EventArgs e)
        {
            Configuraciones.GUI.ConfiguracionTPV f = new Configuraciones.GUI.ConfiguracionTPV();
            f.tabControl1.SelectedIndex = 1;
            f.ShowDialog();
        }

        private void toolStripButton37_Click(object sender, EventArgs e)
        {
            Configuraciones.GUI.ConfiguracionTPV f = new Configuraciones.GUI.ConfiguracionTPV();
            f.tabControl1.SelectedIndex = 2;
            f.ShowDialog();
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            Personal.GUI.Permisos f = new Personal.GUI.Permisos();
            f.ShowDialog();
        }

        private void toolStripButton32_Click(object sender, EventArgs e)
        {
            Respaldos.GUI.Respaldo f = new Respaldos.GUI.Respaldo();
            f.ShowDialog();
        }

        private void toolStripButton33_Click(object sender, EventArgs e)
        {
            Respaldos.GUI.Restauracion f = new Respaldos.GUI.Restauracion();
            f.ShowDialog();
        }

        private void toolStripButton34_Click(object sender, EventArgs e)
        {
            Respaldos.GUI.Vaciar f = new Respaldos.GUI.Vaciar();
            f.ShowDialog();
        }

        private void toolStripButton26_Click(object sender, EventArgs e)
        {
            Reportes.GUI.ReportesFiltrados f = new Reportes.GUI.ReportesFiltrados();
            f.ShowDialog();
        }

        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
            Reportes.REP.RepStockProducto oReporte = new Reportes.REP.RepStockProducto();
            DataTable datos = DataManager.DBConsultas.VerProductos();
            oReporte.SetDataSource(datos);
            f.GenerarReporte(oReporte, datos, "", "", "");
            f.Show();
        }

        private void toolStripButton31_Click(object sender, EventArgs e)
        {
            Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
            Reportes.REP.RepProveedores oReporte = new Reportes.REP.RepProveedores();
            DataTable datos = DataManager.DBConsultas.Proveedor();
            oReporte.SetDataSource(datos);
            f.GenerarReporte(oReporte, datos, "", "", "");
            f.Show();
        }

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
            Reportes.REP.RepClientes oReporte = new Reportes.REP.RepClientes();
            DataTable datos = DataManager.DBConsultas.Clientes();
            oReporte.SetDataSource(datos);
            f.GenerarReporte(oReporte, datos, "", "", "");
            f.Show();
        }

        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
            String fechaBD = DateTime.Now.ToString("yyyy/MM/dd");
            String fechaREP = DateTime.Now.ToString("dd/MM/yyyy");

            DataTable datos = DataManager.DBConsultas.RepVentasDiarias(fechaBD);
            Reportes.REP.RepVentasDiarias rep = new Reportes.REP.RepVentasDiarias();
            f.GenerarReporte(rep, datos, "", "", fechaREP);
            f.Show();
        }

        private void tpvClientes_Click(object sender, EventArgs e)
        {
            TPV.GUI.ClientesGestion f = new TPV.GUI.ClientesGestion();
            f.ShowDialog();
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            Personal.GUI.Comandos f = new Personal.GUI.Comandos();
            f.ShowDialog();
        }

        private void toolStripButton39_Click(object sender, EventArgs e)
        {
            Configuraciones.GUI.TirajeFactura f = new Configuraciones.GUI.TirajeFactura();
            f.ShowDialog();
        }

        private void toolStripButton40_Click(object sender, EventArgs e)
        {
            Configuraciones.GUI.AdministrarFactura f = new Configuraciones.GUI.AdministrarFactura();
            f.ShowDialog();
        }

        private void toolStripButton30_Click(object sender, EventArgs e)
        {
            //Ingredientes sin stock 
            Reportes.GUI.VisorGeneral f = new Reportes.GUI.VisorGeneral();
            Reportes.REP.RepIngredientes oReporte = new Reportes.REP.RepIngredientes();
            DataTable datos = DataManager.DBConsultas.RepIngredientes();
            oReporte.SetDataSource(datos);
            f.GenerarReporte(oReporte, datos, "", "", "");
            f.Show();
        }

        private void toolStripButton38_Click(object sender, EventArgs e)
        {
            Configuraciones.GUI.Recomendada f = new Configuraciones.GUI.Recomendada();
            f.ShowDialog();
        }
    }
}
