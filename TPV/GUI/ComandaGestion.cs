using CrystalDecisions.CrystalReports.Engine;
using Mantenimiento.CLS;
using Reportes.REP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace TPV.GUI
{
    public partial class ComandaGestion : Form
    {
        private List<PedidoDetalle> lstDetalle = new List<PedidoDetalle>();
        PuntoVenta punto_venta;
        SessionManager.Session oUsuario = SessionManager.Session.Instancia;
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;

        public BindingSource datos = new BindingSource();
        DataTable datosEnMesa = new DataTable();
        public bool cambiarMesa = false;
        public int idPedidoCambioMesa = 0;
        int idPedidoSiguiente = 0;
        String idMesa = "0";
        public bool cerrarSesion;
        public bool tpv;
        public bool borrarData;
        private String SeleccionarImg;

        public ComandaGestion(PuntoVenta punto_venta)
        {
            InitializeComponent();
            AjustarPosicionBoton();
            this.punto_venta = punto_venta;
            lblFecha.Text = DateTime.Now.ToString();
        }

        private void AjustarPosicionBoton()
        {
            // Obtenemos el ancho y alto de la pantalla
            int screenWidth = this.Width;
            //int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Ajustamos la posición del botón a la esquina derecha superior
            btnSalir.Left = screenWidth - (btnSalir.Width + 30);
            btnSalir.Top = 0;
        }

        public void CargarProductosPorMesa(String id)
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.ProductosEnMesaConIdPedido(id, 0);
                dgvDatos.DataSource = datos;
                dgvDatos.AutoGenerateColumns = false;

                if (dgvDatos.Rows.Count > 0)
                {
                    lblTicket.Text = dgvDatos.Rows[0].Cells["idPedido"].Value.ToString();//Accedemos a la primera posicion de la tabla

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CargarProductosPorMesayIdPedido(string idMesa, int idPedido)
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.ProductosEnMesaConIdPedido(idMesa, idPedido);
                dgvDatos.DataSource = datos;
                dgvDatos.AutoGenerateColumns = false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CargarPedidosEnMesa(String id)
        {
            try
            {
                datosEnMesa = DataManager.DBConsultas.PedidosEnMesa(id);
                if (datosEnMesa.Rows.Count > 1)
                {
                    btnCuentas.Visible = true;
                }
                else
                {
                    btnCuentas.Visible = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ComandaGestion_Load(object sender, EventArgs e)
        {
            tFecha.Start();
            WindowState = FormWindowState.Maximized;
            if (dgvDatos.Rows.Count > 0)
            {
                btnComanda.Enabled = true;
                btnDisminuir.Enabled = true;
                btnExtras.Enabled = true;
            }
            // Creamos un Panel para envolver el FlowLayoutPanel
            Panel panelWrapper = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            // Agregamos el FlowLayoutPanel al Panel
            panelWrapper.Controls.Add(panelComanda);

            // Agregamos el Panel al formulario
            Controls.Add(panelWrapper);

            DataTable salones = DataManager.DBConsultas.Familias();
            // Crear y agregar botones al FlowLayoutPanel para cada salon
            foreach (DataRow salon in salones.Rows)
            {
                btnFamilia = new Button
                {
                    Text = salon["familia"].ToString().ToUpper(),
                    Tag = salon["idFamilia"].ToString().ToUpper(),
                    Size = new Size(150, 60)
                };
                btnFamilia.Click += BotonFamilia_Click;
                flpFamilias.Controls.Add(btnFamilia);
            }
            if (lblMesa.Tag != null)
            {
                idMesa = lblMesa.Tag.ToString();
            }
            borrarData = false;
        }

        private void BotonFamilia_Click(object sender, EventArgs e)
        {
            if (flpProductos.Controls.Count > 0)
            {
                flpProductos.Controls.Clear();
            }

            Button botonFamilia = (Button)sender;

            DataTable productos = DataManager.DBConsultas.Productos(botonFamilia.Tag.ToString());
            // Crear y agregar botones al FlowLayoutPanel para cada producto
            foreach (DataRow producto in productos.Rows)
            {
                String[] aux = { producto["idProducto"].ToString().ToUpper(), producto["grupoPrinter"].ToString().ToUpper() };
                btnProducto = new Button
                {
                    Text = producto["nombre"].ToString().ToUpper(),
                    Tag = aux
                };

                // Crear un nuevo objeto Font con estilo negrita
                Font boldFont = new Font(btnProducto.Font, FontStyle.Bold);
                // Asignar el nuevo estilo de fuente al botón
                btnProducto.Font = boldFont;
                // Establecer el color del texto en negro
                btnProducto.ForeColor = Color.Black;

                SeleccionarImg = producto["foto"].ToString();

                if (!string.IsNullOrEmpty(SeleccionarImg))
                {
                    // Obtén la ruta de la imagen en la carpeta "Images" en el directorio de salida
                    string imagePathInOutput = Path.Combine("Ingredientes y Productos", "Images", SeleccionarImg);

                    // Obten la ruta del directorio de salida de la aplicación
                    string outputPath = AppDomain.CurrentDomain.BaseDirectory;
                    string projectDirectory = Path.GetFullPath(Path.Combine(outputPath, @"..\..\..\"));
                    string fullPath = Path.Combine(projectDirectory, imagePathInOutput);

                    if (File.Exists(fullPath))
                    {
                        // Carga la imagen desde la ruta en el directorio de salida
                        Image originalImage = Image.FromFile(fullPath);

                        // Define las dimensiones deseadas para la imagen
                        int nuevoAncho = 100; // Cambia este valor al ancho deseado
                        int nuevoAlto = 100; // Cambia este valor al alto deseado

                        // Crea una nueva imagen con las dimensiones deseadas
                        Image imagenRedimensionada = new Bitmap(originalImage, new Size(nuevoAncho, nuevoAlto));

                        // Asigna la imagen redimensionada al botón
                        btnProducto.Image = imagenRedimensionada;
                        btnProducto.TextImageRelation = TextImageRelation.ImageAboveText;
                    }

                }

                btnProducto.TextAlign = ContentAlignment.BottomCenter;
                btnProducto.Size = new Size(130, 130);
                btnProducto.Click += BotonProducto_Click;
                flpProductos.Controls.Add(btnProducto);
            }
        }

        private double CalcularTotal()
        {
            double total = 0;
            if (dgvDatos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    if (row.Cells["subTotal"].Value != null && row.Cells["subTotal"].Value != DBNull.Value)
                    {
                        total += Convert.ToDouble(row.Cells["subTotal"].Value);
                    }
                }
            }
            return total;
        }

        private double CalcularSubTotal(int cantidad, int id, double precio)
        {

            double subTotal;
            subTotal = precio * cantidad;
            return subTotal;
        }

        private void BotonProducto_Click(object sender, EventArgs e)
        {
            Button botonProducto = (Button)sender;
            int cantidad;

            if (bool.Parse(oConfiguracion.MuchosProductos))
            {
                // Agregar muchos productos
                CantidadProductos f = new CantidadProductos();
                f.ShowDialog();
                cantidad = Int32.Parse(f.txtCantidad.Text);
                if (cantidad != 0)
                {
                    AgregarProductos(botonProducto, cantidad);
                }
            }
            else
            {
                // Agregar un producto
                cantidad = 1;
                AgregarProductos(botonProducto, cantidad);
            }
        }

        private void AgregarProductos(Button botonProducto, int cantidad)
        {
            List<String> yaHayProductoEnPedido = new List<string>();
            int cant = cantidad;
            Boolean primerProducto;
            String fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String[] aux = (string[])botonProducto.Tag;
            DataTable productoNuevo = DataManager.DBConsultas.ObtenerPrecioDeProducto(Int32.Parse(aux[0].ToString()));
            PedidoDetalle pDetalle = new PedidoDetalle
            {
                Cantidad = cantidad
            };
            if (!lblTicket.Text.Equals(""))
            {
                pDetalle.IdPedido = Int32.Parse(lblTicket.Text.ToString());
            }
            pDetalle.Mesa = lblMesa.Text;
            pDetalle.IdProducto = Int32.Parse(aux[0].ToString());
            pDetalle.Fecha = fecha;
            pDetalle.Nombre = botonProducto.Text;
            pDetalle.Grupo = aux[1].ToString();


            Boolean encontrado = false;

            if (lstDetalle.Count > 0)
            {
                foreach (PedidoDetalle item in lstDetalle)
                {
                    if (aux[0].ToString().Equals(item.IdProducto.ToString()))
                    {
                        encontrado = true;
                        item.Cantidad += cantidad;
                        break;
                    }
                }
                if (!encontrado)
                {
                    lstDetalle.Add(pDetalle);
                }
            }
            else if (dgvDatos.Rows.Count > 0)
            {
                lstDetalle.Add(pDetalle);
            }

            if (dgvDatos.Rows.Count > 0)
            {
                //Ya existe un pedido
                bool aumentarUnProducto = false;
                double precio = 0;
                int idProducto = 0;
                int idDetalle = 0;
                //Saber si ya existe algun producto igual en los detalles
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    if (row.Cells["idProducto"].Value.ToString() == aux[0].ToString())
                    {
                        idDetalle = Int32.Parse(row.Cells["idDetalle"].Value.ToString());
                        cantidad += Int32.Parse(row.Cells["cantidad"].Value.ToString());
                        precio = double.Parse(row.Cells["precio"].Value.ToString());
                        idProducto = Int32.Parse(aux[0].ToString());
                        aumentarUnProducto = true;
                    }
                }

                PedidoDetalle pedidoDetalle = new PedidoDetalle();

                if (aumentarUnProducto)
                {
                    //Ya existe un producto igual en el datgrid, hay que aumentar
                    pedidoDetalle.IdDetalle = idDetalle;
                    pedidoDetalle.IdPedido = Int32.Parse(lblTicket.Text.ToString());
                    pedidoDetalle.IdProducto = Int32.Parse(aux[0].ToString());
                    pedidoDetalle.Cantidad = cantidad;
                    pedidoDetalle.SubTotal = CalcularSubTotal(cantidad, idProducto, precio);

                    yaHayProductoEnPedido.Add(pedidoDetalle.ActualizarCompra(false));
                    
                }
                else
                {
                    //No existe un producto igual en el datgrid, hay que crearlo
                    pedidoDetalle.IdDetalle = 0;
                    pedidoDetalle.Cocinando = true;
                    pedidoDetalle.Extras = "";
                    pedidoDetalle.HoraEntregado = fecha;
                    pedidoDetalle.HoraPedido = fecha;
                    //pedidoDetalle.IdCocinero = null;
                    pedidoDetalle.IdProducto = Int32.Parse(aux[0].ToString());
                    pedidoDetalle.IdPedido = Int32.Parse(lblTicket.Text.ToString());
                    pedidoDetalle.Cantidad = cantidad;
                    pedidoDetalle.Precio = double.Parse(productoNuevo.Rows[0]["precio"].ToString());
                    pedidoDetalle.SubTotal = CalcularSubTotal(cantidad, Int32.Parse(aux[0].ToString()), double.Parse(productoNuevo.Rows[0]["precio"].ToString()));
                    pedidoDetalle.Grupo = "0";
                    pedidoDetalle.Usuario = oUsuario.IdUsuario;
                    yaHayProductoEnPedido.Add(pedidoDetalle.Insertar(false));
                    
                }
                primerProducto = false;
            }
            else
            {
                //Creamos un nuevo pedido
                primerProducto = true;
                //No hay productos, se inicia el pedido
                //Creamos el pedido
                Pedido pedido = new Pedido
                {
                    IdMesa = Int32.Parse(lblMesa.Tag.ToString()),
                    IdCuenta = 1,
                    Cancelado = false,
                    Fecha = fecha,
                    Listo = false,
                    Total = 0,
                    Descuento = 0,
                    Iva = 0,
                    Propina = 0,
                    TotalPago = 0,
                    Saldo = 0,
                    NFactura = "0",
                    Anular = false,
                    Efectivo = 0,
                    Credito = 0,
                    Btc = 0
                };

                //Iniciamos las transacciones si no hay productos
                List<String> primerProductoEnPedido = new List<string>();

                

                //Insertamos en la base de datos el pedido
                primerProductoEnPedido.Add(pedido.Insertar());
                //Se agregara el mesero tambien si entro un mesero
                if (oUsuario.IdRol.Equals("2"))
                {
                    //Entro un mesero
                    Pedido pedido3 = new Pedido();
                    pedido3.IdMesero = Int32.Parse(oUsuario.IdUsuario);
                    primerProductoEnPedido.Add(pedido3.ActualizarMesero(true));
                }
                
                lstDetalle.Add(pDetalle);

                //Agregamos detalles al pedido
                PedidoDetalle pedidoDetalle = new PedidoDetalle
                {
                    IdDetalle = 0,
                    Cocinando = true,
                    Extras = "",
                    HoraEntregado = fecha,
                    HoraPedido = fecha,
                    //pedidoDetalle.IdCocinero = null;
                    IdProducto = Int32.Parse(aux[0].ToString())
                };
                
                pedidoDetalle.Cantidad = cantidad;
                DataTable precio = DataManager.DBConsultas.ObtenerPrecioDeProducto(Int32.Parse(aux[0].ToString()));
                pedidoDetalle.Precio = double.Parse(precio.Rows[0]["precio"].ToString());
                pedidoDetalle.SubTotal = CalcularSubTotal(cantidad, Int32.Parse(aux[0].ToString()), double.Parse(precio.Rows[0]["precio"].ToString()));
                pedidoDetalle.Grupo = "0";
                pedidoDetalle.Usuario = oUsuario.IdUsuario;
                //pedidoDetalle.Fecha = null;

                //Insertamos el detalle del pedido
                primerProductoEnPedido.Add(pedidoDetalle.Insertar(true));
                Mesa mesa = new Mesa
                {
                    IdMesa = Int32.Parse(lblMesa.Tag.ToString()),
                    Disponible = false
                };
                //Se actualiza el estado de la mesa
                primerProductoEnPedido.Add(mesa.ActualizarEstado());

                DataManager.DBOperacion transaccion1 = new DataManager.DBOperacion();
                if (transaccion1.EjecutarTransaccion(primerProductoEnPedido) > 0)
                {
                    int idPedido = DataManager.DBConsultas.ObtenerUltimoPedido();
                    lblTicket.Text = idPedido.ToString();//Debo actualizar el ticket
                    pDetalle.IdPedido = idPedido;//Debo asignar un id Para mostrar en la comanda parcial
                    //Todo esto si el resultado es exitoso
                    btnComanda.Enabled = true;
                    btnDisminuir.Enabled = true;
                    btnExtras.Enabled = true;

                    //Actualizar al final el datagrid
                    CargarProductosPorMesa(lblMesa.Tag.ToString());

                    if (primerProducto)
                    {
                        //Vamos a actualizar el total del pedido
                        Pedido pedido2 = new Pedido
                        {
                            IdMesa = Int32.Parse(lblMesa.Tag.ToString()),
                            IdPedido = Int32.Parse(lblTicket.Text.ToString())
                        };
                        double total = CalcularTotal();

                        //Actualizamos el total en el pedido recien insertado
                        List<String> actualizarTotal = new List<string>();
                        actualizarTotal.Add(pedido2.ActualizarTotal(total, false));

                        DataManager.DBOperacion transaccion3 = new DataManager.DBOperacion();
                        if (transaccion3.EjecutarTransaccion(actualizarTotal) < 0)
                        {
                            MessageBox.Show("ERROR EN TRANSACCION AL ACTUALIZAR TOTAL DE PEDIDO, CONTACTE AL PROGRAMADOR.");
                        }

                        ActualizarLabelsRetroceder(idPedido, false);

                    }
                }
                else
                {
                    MessageBox.Show("ERROR EN TRANSACCION AL INSERTAR UN NUEVO PEDIDO, CONTACTE AL PROGRAMADOR.");
                }
            }

            if (!primerProducto)
            {
                DataManager.DBOperacion transaccion2 = new DataManager.DBOperacion();
                if(transaccion2.EjecutarTransaccion(yaHayProductoEnPedido) > 0)
                {
                    //Actualizar al final el datagrid
                    CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text.ToString()));

                    //Vamos a actualizar el total del pedido
                    Pedido pedido2 = new Pedido
                    {
                        IdPedido = Int32.Parse(lblTicket.Text.ToString()),
                        IdMesa = Int32.Parse(lblMesa.Tag.ToString())
                    };
                    double total = CalcularTotal();

                    //Actualizamos el total en el pedido recien insertado
                    List<String> actualizarTotal = new List<string>();
                    actualizarTotal.Add(pedido2.ActualizarTotal(total, false));

                    DataManager.DBOperacion transaccion3 = new DataManager.DBOperacion();
                    if (transaccion3.EjecutarTransaccion(actualizarTotal) < 0)
                    {
                        MessageBox.Show("ERROR EN TRANSACCION AL ACTUALIZAR TOTAL DE PEDIDO, CONTACTE AL PROGRAMADOR.");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR EN TRANSACCION AL AUMENTAR EL DETALLE DEL PEDIDO, CONTACTE AL PROGRAMADOR.");
                }
            }

            ActualizarStockProductosIngredientes(aux[0].ToString(), cant, productoNuevo, true);

        }

        private void ActualizarStockProductosIngredientes(string id, int cantidad, DataTable productoNuevo, bool aumentar)
        {
            DataTable ingredientes = DataManager.DBConsultas.BuscarIngredientesPorProducto(id);

            Ingrediente ingrediente;
            Producto producto;

            if (aumentar)//Si seleccionamos un producto
            {
                if (ingredientes.Rows.Count > 0)
                {
                    foreach (DataRow item in ingredientes.Rows)
                    {
                        ingrediente = new Ingrediente
                        {
                            IdIngrediente = Int32.Parse(item["idIngrediente"].ToString()),
                            Stock = Decimal.Parse(item["stock_ingrediente"].ToString()) - CalcularCantidad(cantidad, Decimal.Parse(item["cantidad"].ToString()))
                        };
                        ingrediente.ActualizarStock();
                    }
                }
                else
                {
                    //El producto no tiene ingredientes
                    producto = new Producto
                    {
                        IdProducto = Int32.Parse(id),
                        Stock = Int32.Parse(productoNuevo.Rows[0]["stock"].ToString()) - cantidad
                    };
                    producto.ActualizarStock();
                }
            }
            else//Si disminuimos
            {
                if (ingredientes.Rows.Count > 0)
                {
                    foreach (DataRow item in ingredientes.Rows)
                    {
                        ingrediente = new Ingrediente
                        {
                            IdIngrediente = Int32.Parse(item["idIngrediente"].ToString()),
                            Stock = Decimal.Parse(item["stock_ingrediente"].ToString()) + CalcularCantidad(cantidad, Decimal.Parse(item["cantidad"].ToString()))
                        };
                        ingrediente.ActualizarStock();
                    }
                }
                else
                {
                    //El producto no tiene ingredientes
                    producto = new Producto
                    {
                        IdProducto = Int32.Parse(id),
                        Stock = Int32.Parse(productoNuevo.Rows[0]["stock"].ToString()) + cantidad
                    };
                    producto.ActualizarStock();
                }
            }
        }

        private decimal CalcularCantidad(int cantidad, decimal v)
        {
            return cantidad * v;
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            ImprimirComandaActual();
            Close();
        }

        private void ImprimirComandaActual()
        {
            if (lstDetalle.Count > 0)
            {
                // Cargar los datos en un DataTable
                RepComandaParcial oReporte = new RepComandaParcial();
                GenerarComandaParcial(oReporte);
            }

        }

        private void ComandaGestion_Resize(object sender, EventArgs e)
        {
            AjustarPosicionBoton();
        }

        private void tFecha_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            this.Hide();
            PuntoPago f = new PuntoPago(this);

            //Si comanda gestion va vacia
            if (lblMesa.Tag != null || !lblTicket.Text.Equals(""))
            {
                if (idPedidoSiguiente != 0 || !lblTicket.Text.Equals(""))
                {
                    DataTable productoEnMesas = DataManager.DBConsultas.ProductosEnMesaConIdPedido(idMesa, Int32.Parse(lblTicket.Text));
                    if (productoEnMesas.Rows.Count > 0)
                    {
                        if (lblMesa.Tag != null)
                        {
                            if (productoEnMesas.Rows.Count > 0)
                            {
                                f.CargarProductosPorMesayIdPedido(idMesa, Int32.Parse(lblTicket.Text));
                                f.CargarPedidosEnMesa(idMesa);
                                f.lblTicket.Text = productoEnMesas.Rows[0][0].ToString();//Accedemos a la primera posicion de la tabla

                                DataTable pedido = DataManager.DBConsultas.PedidoPorId(Int32.Parse(lblTicket.Text), false);
                                //Agregando datos mesero y cliente si los hay
                                if (!pedido.Rows[0]["nombres"].ToString().Equals(""))
                                {
                                    f.lblMesero.Text = pedido.Rows[0]["nombres"].ToString();
                                    f.lblMesero.Tag = int.Parse(pedido.Rows[0]["idMesero"].ToString());
                                }
                                else
                                {
                                    f.lblMesero.Text = "";
                                    f.lblMesero.Tag = "";
                                }
                                if (!pedido.Rows[0]["nombre"].ToString().Equals(""))
                                {
                                    f.lblCliente.Text = pedido.Rows[0]["nombre"].ToString();
                                    f.lblCliente.Tag = int.Parse(pedido.Rows[0]["idCliente"].ToString());
                                }
                                else
                                {
                                    f.lblCliente.Text = "";
                                    f.lblCliente.Tag = "";
                                }
                            }
                            f.lblMesa.Text = lblMesa.Text.ToString();
                            f.lblMesa.Tag = lblMesa.Tag.ToString();
                        }
                    }
                }
                else
                {
                    f.lblMesa.Text = lblMesa.Text.ToString();
                    f.lblMesa.Tag = lblMesa.Tag.ToString();
                }
            }
            //Hacer algo aqui al cerrar sesion
            if (!cerrarSesion)
            {
                f.ShowDialog();
            }

            //Procedimiento luego de presionar el boton regresar para traer la informacion de la orden que se ha seleccionado
            if (f.lblTicket.Tag != null)
            {
                this.CargarProductosPorMesa(f.lblMesa.Tag.ToString());
                this.CargarPedidosEnMesa(f.lblMesa.Tag.ToString());

                ActualizarLabelsRetroceder(Int32.Parse(f.lblTicket.Text.ToString()), false);
                lblMesa.Text = f.lblMesa.Text.ToString();
                lblMesa.Tag = f.lblMesa.Tag.ToString();
            }
            if (!cerrarSesion)
            {
                Show();
            }

        }

        public void ActualizarLabelsRetroceder(int id, Boolean primerPedido)
        {
            int longitud = lstDetalle.Count;
            //Obtengo el pedido que estaba abierto en el punto de pago.
            DataTable pedido = DataManager.DBConsultas.PedidoPorId(id, primerPedido);
            if (!pedido.Rows[0]["nombres"].ToString().Equals(""))
            {
                lblMesero.Text = pedido.Rows[0]["nombres"].ToString();
                lblMesero.Tag = int.Parse(pedido.Rows[0]["idMesero"].ToString());
                
                if (longitud > 0)
                {
                    for (int i = 0; i < longitud; i++)
                    {
                        lstDetalle[i].Mesero = pedido.Rows[0]["nombres"].ToString();
                    }
                    
                }
            }
            else
            {
                lblMesero.Text = "";
                lblMesero.Tag = "";
            }
            if (!pedido.Rows[0]["nombre"].ToString().Equals(""))
            {
                lblCliente.Text = pedido.Rows[0]["nombre"].ToString();
                lblCliente.Tag = int.Parse(pedido.Rows[0]["idCliente"].ToString());

                if (longitud > 0)
                {
                    for (int i = 0; i < longitud; i++)
                    {
                        lstDetalle[i].Cliente = pedido.Rows[0]["nombre"].ToString();
                    }

                }

            }
            else
            {
                lblCliente.Text = "";
                lblCliente.Tag = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            punto_venta.admin = true;
            punto_venta.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Actualizamos el total en el pedido recien insertado
            List<String> eliminacion = new List<string>();

            //Programando boton de disminuir
            PedidoDetalle pedidoDetalle = new PedidoDetalle();
            if (MessageBox.Show("¿Esta seguro que desea disminuir?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pedidoDetalle.IdDetalle = Int32.Parse(dgvDatos.CurrentRow.Cells["idDetalle"].Value.ToString());
                pedidoDetalle.IdPedido = Int32.Parse(lblTicket.Text.ToString());
                pedidoDetalle.IdProducto = Int32.Parse(dgvDatos.CurrentRow.Cells["idProducto"].Value.ToString());
                pedidoDetalle.Cantidad = Int32.Parse(dgvDatos.CurrentRow.Cells["cantidad"].Value.ToString()) - 1;
                pedidoDetalle.SubTotal = CalcularSubTotal(Int32.Parse(dgvDatos.CurrentRow.Cells["cantidad"].Value.ToString()) - 1, Int32.Parse(dgvDatos.CurrentRow.Cells["idProducto"].Value.ToString()), double.Parse(dgvDatos.CurrentRow.Cells["precio"].Value.ToString()));

                if (pedidoDetalle.Cantidad != 0)
                {
                    //Actualizamos el total en el pedido recien insertado
                    List<String> actualizarTotal = new List<string>();
                    actualizarTotal.Add(pedidoDetalle.ActualizarCompra(false));

                    EliminarPedidoOActualizarDetalle(false, actualizarTotal);

                }
                else
                {
                    
                    //Se eliminara el producto
                    eliminacion.Add(pedidoDetalle.Eliminar());
                    
                    if (dgvDatos.Rows.Count == 1)
                    {
                        Pedido pedido = new Pedido
                        {
                            IdPedido = Int32.Parse(lblTicket.Text)
                        };
                        eliminacion.Add(pedido.Eliminar());

                    }
                    EliminarPedidoOActualizarDetalle(true, eliminacion);
                }

                CargarPedidosEnMesa(lblMesa.Tag.ToString());
                if (lstDetalle.Count > 0)
                {
                    foreach (PedidoDetalle item in lstDetalle)
                    {
                        if (dgvDatos.CurrentRow.Cells["idProducto"].Value.ToString().Equals(item.IdProducto.ToString()))
                        {
                            item.IdPedido = item.IdPedido;
                            item.IdProducto = item.IdProducto;
                            item.Cantidad--;
                            if (item.Cantidad == 0)
                            {
                                lstDetalle.Remove(item);
                            }
                            break;
                        }
                    }
                }

                DataTable productoNuevo = DataManager.DBConsultas.ObtenerPrecioDeProducto(pedidoDetalle.IdProducto);
                ActualizarStockProductosIngredientes(pedidoDetalle.IdProducto.ToString(), 1, productoNuevo, false);
            }


        }

        private void EliminarPedidoOActualizarDetalle(bool eliminar, List<string> accion)
        {
            DataManager.DBOperacion transaccion = new DataManager.DBOperacion();
            if (eliminar)
            {
                if (transaccion.EjecutarTransaccion(accion) > 0)
                {

                    if (dgvDatos.Rows.Count == 1)
                    {
                        CargarProductosPorMesa(lblMesa.Tag.ToString());
                    }
                    else
                    {
                        CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
                    }

                }
                else
                {
                    MessageBox.Show("ERROR EN TRANSACCION AL ELIMINAR PEDIDO O SU DETALLE, CONTACTE AL PROGRAMADOR.");
                }
            }
            else
            {
                
                if (transaccion.EjecutarTransaccion(accion) > 0)
                {

                    if (dgvDatos.Rows.Count == 1)
                    {
                        CargarProductosPorMesa(lblMesa.Tag.ToString());
                    }
                    else
                    {
                        CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
                    }

                }
                else
                {
                    MessageBox.Show("ERROR EN TRANSACCION AL ELIMINAR PEDIDO O SU DETALLE, CONTACTE AL PROGRAMADOR.");
                }
            }

            if (dgvDatos.Rows.Count > 0)
            {
                //Vamos a actualizar el total del pedido
                Pedido pedido3 = new Pedido
                {
                    IdPedido = Int32.Parse(lblTicket.Text.ToString()),
                    IdMesa = Int32.Parse(lblMesa.Tag.ToString())
                };
                double total = CalcularTotal();

                //Actualizamos el total en el pedido recien insertado
                List<String> actualizarTotal = new List<string>();
                actualizarTotal.Add(pedido3.ActualizarTotal(total, false));

                DataManager.DBOperacion transaccion3 = new DataManager.DBOperacion();
                if (transaccion3.EjecutarTransaccion(actualizarTotal) < 0)
                {
                    MessageBox.Show("ERROR EN TRANSACCION AL ACTUALIZAR TOTAL DE PEDIDO, CONTACTE AL PROGRAMADOR.");
                }
            }
            else
            {
                //Lista para actualizar el estado de la mesa
                List<String> actualizarLaMesa = new List<string>();
                
                Mesa mesa = new Mesa
                {
                    IdMesa = Int32.Parse(lblMesa.Tag.ToString()),
                    Disponible = true
                };

                //Se actualiza el estado de la mesa
                actualizarLaMesa.Add(mesa.ActualizarEstado());
                DataManager.DBOperacion transaccion3 = new DataManager.DBOperacion();
                if (transaccion3.EjecutarTransaccion(actualizarLaMesa) < 0)
                {
                    MessageBox.Show("ERROR EN TRANSACCION AL ACTUALIZAR EL ESTADO DE LA MESA, CONTACTE AL PROGRAMADOR.");
                }

                lblTicket.Text = "";
                lblMesero.Text = "";
                lblMesero.Tag = "";
                lblCliente.Text = "";
                lblCliente.Tag = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            idPedidoCambioMesa = Int32.Parse(lblTicket.Text.ToString());
            cambiarMesa = true;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientesGestion cg = new ClientesGestion
            {
                seleccionCliente = true
            };
            if (lblTicket.Text.ToString().Equals(""))
            {
                cg.idPedido = 0;
            }
            else
            {
                cg.idPedido = Int32.Parse(lblTicket.Text.ToString());
            }

            cg.ShowDialog();
            if (!lblTicket.Text.ToString().Equals(""))
            {
                ActualizarLabelsRetroceder(Int32.Parse(lblTicket.Text.ToString()), false);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MeserosSeleccion m = new MeserosSeleccion();
            if (lblTicket.Text.ToString().Equals(""))
            {
                m.idPedido = 0;
            }
            else
            {
                m.idPedido = Int32.Parse(lblTicket.Text.ToString());
            }

            m.ShowDialog();
            if (!lblTicket.Text.ToString().Equals(""))
            {
                ActualizarLabelsRetroceder(Int32.Parse(lblTicket.Text.ToString()), false);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se cerrara la sesion, ¿esta seguro que desea cerrar sesion?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cerrarSesion = true;
                punto_venta.cerrarSesion = true;
                punto_venta.Close();
                this.Close();
            }

        }

        private void ComandaGestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarSesion)
            {
                punto_venta.tpv = true;
                punto_venta.cerrarSesion = true;
                punto_venta.Close();

            }
            tFecha.Stop();
        }

        private void btnExtras_Click(object sender, EventArgs e)
        {
            SepararCuenta separar = new SepararCuenta();
            separar.lblMesa.Tag = lblMesa.Tag;
            separar.lblMesa.Text = "#Mesa: " + lblMesa.Tag;
            separar.lblTicket.Tag = lblTicket.Text;
            separar.lblTicket.Text = "#Pedido: " + lblTicket.Text;
            separar.ShowDialog();
            if (idPedidoSiguiente > 0)
            {
                CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));

            }
            else
            {
                CargarProductosPorMesa(lblMesa.Tag.ToString());
            }

            //AQUI MODIFICAR EL TOTAL DEL PEDIDO
            //Vamos a actualizar el total del pedido
            Pedido pedido2 = new Pedido
            {
                IdMesa = Int32.Parse(lblMesa.Tag.ToString()),
                IdPedido = Int32.Parse(lblTicket.Text.ToString())
            };
            double total = CalcularTotal();

            //Actualizamos el total en el pedido recien insertado
            List<String> actualizarTotal = new List<string>();
            actualizarTotal.Add(pedido2.ActualizarTotal(total, false));

            DataManager.DBOperacion transaccion3 = new DataManager.DBOperacion();
            if (transaccion3.EjecutarTransaccion(actualizarTotal) < 0)
            {
                MessageBox.Show("ERROR EN TRANSACCION AL ACTUALIZAR TOTAL DE PEDIDO, CONTACTE AL PROGRAMADOR.");
            }
            CargarPedidosEnMesa(lblMesa.Tag.ToString());

        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            PedidosSeparados pedidosSeparados = new PedidosSeparados
            {
                idMesa = lblMesa.Tag.ToString(),
                pedidosEnMesa = datosEnMesa
            };
            pedidosSeparados.ShowDialog();
            idPedidoSiguiente = pedidosSeparados.idPedido;


            if (idPedidoSiguiente > 0)
            {
                CargarProductosPorMesayIdPedido(pedidosSeparados.idMesa, idPedidoSiguiente);
                lblTicket.Text = idPedidoSiguiente.ToString();//Accedemos a la primera posicion de la tabla

                DataTable pedido = DataManager.DBConsultas.PedidoPorId(idPedidoSiguiente, false);
                //Agregando datos mesero y cliente si los hay
                if (!pedido.Rows[0]["nombres"].ToString().Equals(""))
                {
                    lblMesero.Text = pedido.Rows[0]["nombres"].ToString();
                    lblMesero.Tag = int.Parse(pedido.Rows[0]["idMesero"].ToString());
                }
                else
                {
                    lblMesero.Text = "";
                    lblMesero.Tag = "";
                }
                if (!pedido.Rows[0]["nombre"].ToString().Equals(""))
                {
                    lblCliente.Text = pedido.Rows[0]["nombre"].ToString();
                    lblCliente.Tag = int.Parse(pedido.Rows[0]["idCliente"].ToString());
                }
                else
                {
                    lblCliente.Text = "";
                    lblCliente.Tag = "";
                }
            }
        }

        private void btnComanda_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                // Cargar los datos en un DataTable
                Reportes.REP.RepComandaCompleta oReporte = new Reportes.REP.RepComandaCompleta();
                GenerarComanda(oReporte);

            }
            else
            {
                MessageBox.Show("No hay datos que mostrar en el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void GenerarComanda(ReportClass oReporte)
        {
            try
            {
                // Código para obtener datos y configurar parámetros del informe
                DataTable datos = DataManager.DBConsultas.ProductosEnMesaConIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
                oReporte.SetDataSource(datos);
                oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
                oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
                oReporte.SetParameterValue("Mesero", datos.Rows[0]["nombreMesero"].ToString());
                oReporte.SetParameterValue("Cliente", datos.Rows[0]["nombres"].ToString());
                oReporte.SetParameterValue("Salon", datos.Rows[0]["salon"].ToString());

                // Imprimir el informe en la impresora seleccionada
                PrinterSettings settings = new PrinterSettings
                {
                    PrinterName = oConfiguracion.PrinterComanda
                };

                oReporte.PrintOptions.PrinterName = settings.PrinterName;
                oReporte.PrintToPrinter(1, false, 0, 0);

                // Muestra un mensaje de éxito en el hilo de la interfaz de usuario
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Finalizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: muestra un mensaje de error en caso de problemas
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }

        }

        private void GenerarComandaParcial(ReportClass oReporte)
        {
            // Crear un diccionario para almacenar listas de detalles por grupo
            var grupos = new Dictionary<string, List<PedidoDetalle>>();

            // Iterar a través de los detalles y agregar los detalles a las listas de grupos correspondientes
            foreach (PedidoDetalle detalle in lstDetalle)
            {
                string grupoKey = detalle.Grupo; // Asegúrate de tener una propiedad "Grupo" en tu clase PedidoDetalle

                if (!grupos.ContainsKey(grupoKey))
                {
                    grupos[grupoKey] = new List<PedidoDetalle>();
                }
                grupos[grupoKey].Add(detalle);
            }

            // Ahora, itera a través de los grupos y crea e imprime el informe para cada grupo
            foreach (var kvp in grupos)
            {
                var detallesDelGrupo = kvp.Value;

                oReporte.SetDataSource(detallesDelGrupo);
                oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
                oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
                oReporte.SetParameterValue("Salon", dgvDatos.Rows[0].Cells["salon"].Value.ToString());
                oReporte.SetParameterValue("Grupo", kvp.Key.ToString());
                if (!lblMesero.Text.Equals(""))
                {
                    oReporte.SetParameterValue("Mesero", lblMesero.Text.ToString());
                }
                else
                {
                    oReporte.SetParameterValue("Mesero", "");
                }

                if (!lblCliente.Text.Equals(""))
                {
                    oReporte.SetParameterValue("Cliente", lblCliente.Text.ToString());
                }
                else
                {
                    oReporte.SetParameterValue("Cliente", "");
                }

                if (oReporte != null)
                {
                    try
                    {
                        // Imprimir el informe en la impresora seleccionada
                        PrinterSettings settings = new PrinterSettings
                        {
                            PrinterName = oConfiguracion.PrinterComanda
                        };

                        oReporte.PrintOptions.PrinterName = settings.PrinterName;
                        oReporte.PrintToPrinter(1, false, 0, 0);

                        // Muestra un mensaje de éxito en el hilo de la interfaz de usuario
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show($"Informe para el grupo {kvp.Key} finalizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                    }
                    catch (Exception ex)
                    {
                        // Manejo de excepciones: muestra un mensaje de error en caso de problemas
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
            }

        }
    }
}
