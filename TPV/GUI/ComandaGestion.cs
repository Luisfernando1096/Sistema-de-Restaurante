using CrystalDecisions.CrystalReports.Engine;
using Mantenimiento.CLS;
using Reportes.REP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace TPV.GUI
{
    public partial class ComandaGestion : Form
    {
        public List<PedidoDetalle> lstDetalle = new List<PedidoDetalle>();
        private Dictionary<string, List<PedidoDetalle>> miDiccionario = new Dictionary<string, List<PedidoDetalle>>();
        public List<Tuple<int, int>> listaIdProductos = new List<Tuple<int, int>>();

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

        string AnchoProducto = "0";
        string AltoProducto = "0";
        string SeparadorProducto = "0";
        string AnchoFamilia = "0";
        string AltoFamilia = "0";
        string SeparadorFamilia = "0";

        public ComandaGestion(PuntoVenta punto_venta)
        {

            InitializeComponent();
            AjustarPosicionBoton();
            this.punto_venta = punto_venta;
            lblFecha.Text = DateTime.Now.ToString();
            CargarDimensiones();
        }

        private void CargarDimensiones()
        {
            string archivoConfiguracion = "dimensiones.xml";

            if (File.Exists(archivoConfiguracion))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(archivoConfiguracion);

                if (xmlDoc.SelectSingleNode("/Dimension/AnchoProducto") != null
                    && xmlDoc.SelectSingleNode("/Dimension/AltoProducto") != null
                    && xmlDoc.SelectSingleNode("/Dimension/SeparadorProducto") != null)
                {
                    //Productos
                    AnchoProducto = xmlDoc.SelectSingleNode("/Dimension/AnchoProducto").InnerText;
                    AltoProducto = xmlDoc.SelectSingleNode("/Dimension/AltoProducto").InnerText;
                    SeparadorProducto = xmlDoc.SelectSingleNode("/Dimension/SeparadorProducto").InnerText;
                }
                else
                {
                    MessageBox.Show("No ha establecido medidas para las mesas y salones, por favor defina medidas.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (xmlDoc.SelectSingleNode("/Dimension/AnchoFamilia") != null
                    && xmlDoc.SelectSingleNode("/Dimension/AltoFamilia") != null
                    && xmlDoc.SelectSingleNode("/Dimension/SeparadorFamilia") != null)
                {
                    //Familias
                    AnchoFamilia = xmlDoc.SelectSingleNode("/Dimension/AnchoFamilia").InnerText;
                    AltoFamilia = xmlDoc.SelectSingleNode("/Dimension/AltoFamilia").InnerText;
                    SeparadorFamilia = xmlDoc.SelectSingleNode("/Dimension/SeparadorFamilia").InnerText;
                }
                else
                {
                    MessageBox.Show("No ha establecido medidas para las mesas y salones, por favor defina medidas.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
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
        public void CargarListaPedidos(String id)
        {
            try
            {
                // Limpiar el diccionario antes de cargar nuevos datos (si es necesario)
                miDiccionario.Clear();

                // Consulta para obtener los idPedido
                DataTable datosIdPedido = DataManager.DBConsultas.PedidosEnMesa(id);

                foreach (DataRow fila in datosIdPedido.Rows)
                {
                    // Asumiendo que la columna que contiene el idPedido se llama "idPedido"
                    string idPedidoClave = fila["idPedido"].ToString();

                    // Realizar la segunda consulta según el idPedido
                    DataTable detallesPorIdPedido = DataManager.DBConsultas.ProductosEnMesaConIdPedido(id, int.Parse(idPedidoClave));

                    // Crear una lista para almacenar los detalles
                    List<PedidoDetalle> detallesLista = new List<PedidoDetalle>();

                    foreach (DataRow filaDetalle in detallesPorIdPedido.Rows)
                    {
                        // Crear objeto PedidoDetalle y asignar propiedades
                        PedidoDetalle detalle = new PedidoDetalle
                        {
                            IdPedido = Convert.ToInt32(filaDetalle["IdPedido"]),
                            IdProducto = Convert.ToInt32(filaDetalle["IdProducto"]),
                            Cantidad = Convert.ToInt32(filaDetalle["Cantidad"]),
                        };

                        detallesLista.Add(detalle);
                    }

                    // Agregar la lista de detalles directamente al diccionario
                    miDiccionario[idPedidoClave] = detallesLista;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void MostrarClavesYDetalles()//SIRVE PARA REVISAR EL DICCIONARIA DE LOS PEDIDOS
        {
            foreach (var clave in miDiccionario.Keys)
            {
                Console.WriteLine($"Clave: {clave}");

                // Obtener la lista de detalles asociada con la clave
                List<PedidoDetalle> detallesLista = miDiccionario[clave];

                // Mostrar cada detalle en la consola
                foreach (var detalle in detallesLista)
                {
                    Console.WriteLine($"  Detalle: IdPedido = {detalle.IdPedido}, IdProducto = {detalle.IdProducto}, ..."); // Reemplaza con las propiedades reales de PedidoDetalle
                }

                // Separador entre claves
                Console.WriteLine(new string('-', 30));
            }
        }
        private void CompararLista(int idPedidoEspecifico, int idProductoEspecifico, int idDetalle, double precio, String fecha)
        {
            try
            {
                Boolean existePedido = false;
                Boolean existeProducto = false;
                Boolean existeDiccionario = false;
                // Paso 1: Buscar en lstDetalle
                var detalleEspecifico = lstDetalle.FirstOrDefault(det => det.IdPedido == idPedidoEspecifico && det.IdProducto == idProductoEspecifico);

                if (detalleEspecifico != null)
                {
                    existePedido = true;

                    // Paso 2: Verificar si el IdPedido está en el diccionario
                    String idPedidoClave = idPedidoEspecifico.ToString();
                    if (miDiccionario.ContainsKey(idPedidoClave))
                    {
                        existeDiccionario = true;
                        // Paso 3: Buscar el idProductoEspecifico en lstDetalle (no en los detalles del diccionario)
                        var productoEnDetalles = lstDetalle.Any(det => det.IdPedido == idPedidoEspecifico && det.IdProducto == idProductoEspecifico);
                        if (productoEnDetalles)
                        {
                            existeProducto = true;
                        }
                    }
                    else
                    {
                        //Console.WriteLine($"Paso 2: IdPedido {idPedidoEspecifico} no encontrado en el diccionario.");
                    }
                }
                InsertarLogDetalles(existePedido, existeProducto, idProductoEspecifico, idPedidoEspecifico, idDetalle, precio, fecha, existeDiccionario);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void VerListaDetalle() 
        {
            foreach (var detalle in lstDetalle)
            {
                // Accede a las propiedades del objeto detalle y muestra los datos
                Console.WriteLine($"IdPedido: {detalle.IdPedido}, idProducto: {detalle.IdProducto}, Nombre: {detalle.Nombre}, Cantidad: {detalle.Cantidad}, Mesa: {detalle.Mesa}, fecha: {detalle.Fecha}, Grupo: {detalle.Grupo} ");
                // Reemplaza "OtroDato" con el nombre real de otras propiedades que puedan tener tus objetos
            }
            Console.WriteLine($"----------------------------------------------------------------------------- ");

        }

        private void InsertarLogDetalles(Boolean existeP,Boolean existePro,int idProductoI, int idPedidoI, int idDetalle, double precio, String fechaPedido, Boolean existeDiccionario) 
        {
            if (!existeP)
            {
                if (!existePro)//No existe en lstDetalles, significa que ya fue impreso
                {
                    String fechaMod = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    String fechaPed = DateTime.Parse(fechaPedido).ToString("yyyy-MM-dd HH:mm:ss");
                    Mantenimiento.CLS.PedidoDetalleLog log = new Mantenimiento.CLS.PedidoDetalleLog();
                    log.IdDetalle = idDetalle;
                    log.Cocinando = false;
                    log.Extras = "";
                    log.HoraEntregado = fechaMod;
                    log.HoraPedido = fechaPed;
                    log.IdCocinero = 0;
                    log.IdProducto = idProductoI;
                    log.IdPedido = idPedidoI;
                    log.Cantidad = 1;
                    log.Precio = precio;
                    log.SubTotal = log.Cantidad * log.Precio;
                    log.Grupo = "";
                    log.UsuarioDelete = oUsuario.IdUsuario;
                    log.FechaDelete = fechaMod;

                    if (log.Insertar())
                    {

                    }
                    else
                    {
                        log.IdDetalle = idDetalle;
                        DataTable dt = DataManager.DBConsultas.ObtenerCantidadLog(idDetalle);
                        if (dt.Rows.Count > 0)
                        {
                            int cantidad = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
                            log.Cantidad = cantidad + 1;
                            log.Grupo = "2";
                            log.SubTotal = log.Cantidad * log.Precio;
                            log.FechaDelete = fechaMod;
                        }
                        if (log.ModificarRegistro())
                        {

                        }
                    }
                }
            }
        }


        public void CargarPedidos(String id)
        {
            try
            {
                datosEnMesa = DataManager.DBConsultas.Pedidos(id);
                btnCuentas.Visible = true;

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
                    Size = new Size(Int32.Parse(AnchoFamilia), Int32.Parse(AltoFamilia)),
                    Margin = new Padding(Int32.Parse(SeparadorFamilia))
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
            /*
             string archivoConfiguracion = "dimensiones.xml";

            string AnchoProducto = "10";
            string AltoProducto = "10";
            string SeparadorProducto = "10";

            if (File.Exists(archivoConfiguracion))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(archivoConfiguracion);

                //Productos
                AnchoProducto = xmlDoc.SelectSingleNode("/Dimension/AnchoProducto").InnerText;
                AltoProducto = xmlDoc.SelectSingleNode("/Dimension/AltoProducto").InnerText;
                SeparadorProducto = xmlDoc.SelectSingleNode("/Dimension/SeparadorProducto").InnerText;

            }
             */
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
                        int nuevoAncho = Int32.Parse(AnchoProducto) - 30; // Cambia este valor al ancho deseado
                        int nuevoAlto = Int32.Parse(AltoProducto) - 30; // Cambia este valor al alto deseado

                        if (nuevoAncho < 0)
                        {
                            nuevoAncho = 0;
                        }
                        if (nuevoAlto < 0)
                        {
                            nuevoAlto = 0;
                        }

                        // Crea una nueva imagen con las dimensiones deseadas
                        Image imagenRedimensionada = new Bitmap(originalImage, new Size(nuevoAncho, nuevoAlto));

                        // Asigna la imagen redimensionada al botón
                        btnProducto.Image = imagenRedimensionada;
                        btnProducto.TextImageRelation = TextImageRelation.ImageAboveText;
                    }

                }

                btnProducto.TextAlign = ContentAlignment.BottomCenter;
                btnProducto.Size = new Size(Int32.Parse(AnchoProducto), Int32.Parse(AltoProducto));
                btnProducto.Margin = new Padding(Int32.Parse(SeparadorProducto));
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
            //Actualizar al final el datagrid
            if (bool.Parse(oConfiguracion.MuchosProductos))
            {
                // Agregar muchos productos
                CantidadProductos f = new CantidadProductos();
                f.ShowDialog();
                cantidad = Int32.Parse(f.txtCantidad.Text);
                if (cantidad != 0)
                {
                    if (dgvDatos.Rows.Count == 0 && lblTicket.Text != string.Empty) 
                    {
                        AgregarOtrosProductos(botonProducto, cantidad);
                    }
                    else
                    {
                        AgregarProductos(botonProducto, cantidad);
                    }
                }
            }
            else
            {
                cantidad = 1;
                if (dgvDatos.Rows.Count == 0 && lblTicket.Text != string.Empty)
                {
                    AgregarOtrosProductos(botonProducto, cantidad);
                }
                else
                {
                    // Agregar un producto
                    AgregarProductos(botonProducto, cantidad);
                }
            }
        }
        private void AgregarOtrosProductos(Button botonProducto, int cantidad) 
        {
            int cant = cantidad;
            String fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String fechaParaComandaParcial = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            String[] aux = (string[])botonProducto.Tag;
            List<String> primerProductoEnPedido = new List<string>();
            List<String> actualizarTotal = new List<string>();
            DataManager.DBOperacion transaccion1 = new DataManager.DBOperacion();
            DataTable productoNuevo = DataManager.DBConsultas.ObtenerPrecioDeProducto(Int32.Parse(aux[0].ToString()));

            PedidoDetalle pedidoDetalle = new PedidoDetalle();
            try
            {
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
                pDetalle.Fecha = fechaParaComandaParcial;
                pDetalle.Nombre = botonProducto.Text;
                pDetalle.Grupo = aux[1].ToString();

                Boolean encontrado = false;

                if (lstDetalle.Any(item => item.IdPedido == pDetalle.IdPedido && item.IdProducto == pDetalle.IdProducto))
                {
                    lstDetalle.First(item => item.IdPedido == pDetalle.IdPedido && item.IdProducto == pDetalle.IdProducto).Cantidad += pDetalle.Cantidad;
                }
                else
                {
                    lstDetalle.Add(pDetalle);
                }


                pedidoDetalle.Cocinando = true;
                pedidoDetalle.Extras = "";
                pedidoDetalle.HoraEntregado = fecha;
                pedidoDetalle.HoraPedido = fecha;
                //pedidoDetalle.IdCocinero = null;
                pedidoDetalle.IdProducto = Int32.Parse(aux[0].ToString());
                pedidoDetalle.IdPedido = int.Parse(lblTicket.Text);
                pedidoDetalle.Cantidad = cantidad;
                DataTable precio = DataManager.DBConsultas.ObtenerPrecioDeProducto(Int32.Parse(aux[0].ToString()));
                pedidoDetalle.Precio = double.Parse(precio.Rows[0]["precio"].ToString());
                pedidoDetalle.SubTotal = CalcularSubTotal(cantidad, Int32.Parse(aux[0].ToString()), double.Parse(precio.Rows[0]["precio"].ToString()));
                pedidoDetalle.Grupo = "0";
                pedidoDetalle.Usuario = oUsuario.IdUsuario;
                //pedidoDetalle.Fecha = null;
                if (oUsuario.IdRol.Equals("2") && !btnCuentas.Visible)
                {
                    //Entro un mesero
                    Pedido pedido3 = new Pedido();
                    pedido3.IdMesero = Int32.Parse(oUsuario.IdUsuario);
                    primerProductoEnPedido.Add(pedido3.ActualizarMesero(true));
                }
                //Insertamos el detalle del pedido
                primerProductoEnPedido.Add(pedidoDetalle.Insertar(false));

                if (transaccion1.EjecutarTransaccion(primerProductoEnPedido) > 0)
                {
                    int idPedido = int.Parse(lblTicket.Text);
                    //Todo esto si el resultado es exitoso
                    btnComanda.Enabled = true;
                    btnDisminuir.Enabled = true;
                    btnExtras.Enabled = true;

                    //Actualizar al final el datagrid
                    CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), int.Parse(lblTicket.Text));

                    bool primerProducto = true;
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
                        actualizarTotal.Add(pedido2.ActualizarTotal(total, false));

                        DataManager.DBOperacion transaccion3 = new DataManager.DBOperacion();
                        if (transaccion3.EjecutarTransaccion(actualizarTotal) < 0)
                        {
                            MessageBox.Show("ERROR EN TRANSACCION AL ACTUALIZAR TOTAL DE PEDIDO, CONTACTE AL PROGRAMADOR.");
                        }
                    }
                    ActualizarLabelsRetroceder(idPedido, false);
                }
                ActualizarStockProductosIngredientes(aux[0].ToString(), cant, productoNuevo, true);
                //Actualizar al final el datagrid
                CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), int.Parse(lblTicket.Text));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AgregarProductos(Button botonProducto, int cantidad)
        {
            List<String> yaHayProductoEnPedido = new List<string>();
            int cant = cantidad;
            Boolean primerProducto;
            String fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String fechaParaComandaParcial = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
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
            pDetalle.Fecha = fechaParaComandaParcial;
            pDetalle.Nombre = botonProducto.Text;
            pDetalle.Grupo = aux[1].ToString();

            Boolean encontrado = false;

            if (lstDetalle.Any(item => item.IdPedido == pDetalle.IdPedido && item.IdProducto == pDetalle.IdProducto))
            {
                lstDetalle.First(item => item.IdPedido == pDetalle.IdPedido && item.IdProducto == pDetalle.IdProducto).Cantidad += pDetalle.Cantidad;
            }
            else
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
                primerProductoEnPedido.Add(pedido.Insertar(false));
                //Se agregara el mesero tambien si entro un mesero
                if (oUsuario.IdRol.Equals("2") && !btnCuentas.Visible)
                {
                    //Entro un mesero
                    Pedido pedido3 = new Pedido();
                    pedido3.IdMesero = Int32.Parse(oUsuario.IdUsuario);
                    primerProductoEnPedido.Add(pedido3.ActualizarMesero(true));
                }
                if (lstDetalle.Count == 0)
                {
                    lstDetalle.Add(pDetalle);
                }

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
                    //Todo esto si el resultado es exit1oso
                    btnComanda.Enabled = true;
                    btnDisminuir.Enabled = true;
                    btnExtras.Enabled = true;

                    CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), idPedido);

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
            Salir();
        }
        private void Salir() ///SE AAJUSTARON DETALLES ANTES DE SALIR PARA EVITAR ERRORES
        {
            try
            {
                DataTable dt = DataManager.DBConsultas.Pedidos(idMesa);
                DataTable dt1 = new DataTable();
                int idPedido;
                bool existe = false;
                foreach (DataRow row in dt.Rows)
                {
                    idPedido = Convert.ToInt32(row["idPedido"]);
                    dt1 = DataManager.DBConsultas.ProductosEnMesaConIdPedido(idMesa, idPedido);
                    if (dt1.Rows.Count != 0)
                    {
                        existe = true;
                        break;
                    }
                }
                if (existe)
                {
                    if (dgvDatos.Rows.Count != 0)
                    {
                        BorrarPedidosVacios(lblMesa.Tag.ToString());
                        ImprimirComandaActual();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Antes de salir, por favor selecciona una cuenta no vacía. Ten en cuenta que las cuentas vacías serán eliminadas.", "Información Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (lblMesa.Tag != null)
                    {
                        BorrarPedidosVacios(lblMesa.Tag.ToString());
                    }
                    Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
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
            if (dgvDatos.Rows.Count != 0)
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

        private void DisminuirProducto() 
        {
            List<String> eliminacion = new List<string>();  //Actualizamos el total en el pedido recien insertado
            PedidoDetalle pedidoDetalle = new PedidoDetalle();  //Programando boton de disminuir

            if (MessageBox.Show("¿Esta seguro que desea disminuir?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idDetall = Int32.Parse(dgvDatos.CurrentRow.Cells["idDetalle"].Value.ToString());
                int idPed = Int32.Parse(lblTicket.Text.ToString());
                int idPro = Int32.Parse(dgvDatos.CurrentRow.Cells["idProducto"].Value.ToString());
                double precio = double.Parse(dgvDatos.CurrentRow.Cells["precio"].Value.ToString());
                String fecha = dgvDatos.CurrentRow.Cells["fecha"].Value.ToString();
                pedidoDetalle.IdDetalle = idDetall;
                pedidoDetalle.IdPedido = idPed;
                pedidoDetalle.IdProducto = idPro;
                pedidoDetalle.Cantidad = Int32.Parse(dgvDatos.CurrentRow.Cells["cantidad"].Value.ToString()) - 1;
                pedidoDetalle.SubTotal = CalcularSubTotal(Int32.Parse(dgvDatos.CurrentRow.Cells["cantidad"].Value.ToString()) - 1, Int32.Parse(dgvDatos.CurrentRow.Cells["idProducto"].Value.ToString()), double.Parse(dgvDatos.CurrentRow.Cells["precio"].Value.ToString()));

                CompararLista(idPed, idPro, idDetall, precio, fecha);

                if (pedidoDetalle.Cantidad != 0)
                {
                    //Actualizamos el total en el pedido recien insertado
                    List<String> actualizarTotal = new List<string>();
                    actualizarTotal.Add(pedidoDetalle.ActualizarCompra(false));

                    EliminarPedidoOActualizarDetalle(false, actualizarTotal, 0);
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
                    EliminarPedidoOActualizarDetalle(true, eliminacion, 1);
                }

                if (dgvDatos.Rows.Count == 0)
                {
                    lstDetalle.Clear();
                    DataTable dt = DataManager.DBConsultas.Pedidos(lblMesa.Tag.ToString());

                    // Verificar si hay filas en el DataTable
                    if (dt.Rows.Count > 0)
                    {
                        // Tomar el IDPedido de la primera fila (índice 0)
                        int idPedidoSeleccionado = Convert.ToInt32(dt.Rows[0]["idPedido"]);

                        // Puedes asignar este IDPedido a donde sea necesario, por ejemplo, a un TextBox
                        lblTicket.Text = idPedidoSeleccionado.ToString();
                    }
                    else
                    {
                        btnCuentas.Visible = false;
                    }
                }
                if (lstDetalle.Count > 0)

                {
                    // Actualiza la cantidad solo para el IdPedido e IdProducto actual
                    foreach (var item in lstDetalle.ToList())
                    {
                        if (item.IdPedido == idPed && item.IdProducto == idPro && item.Cantidad > 0)
                        {
                            item.Cantidad--;
                            if (item.Cantidad == 0)
                            {
                                lstDetalle.Remove(item);
                            }
                        }
                    }
                }

                DataTable productoNuevo = DataManager.DBConsultas.ObtenerPrecioDeProducto(pedidoDetalle.IdProducto);
                ActualizarStockProductosIngredientes(pedidoDetalle.IdProducto.ToString(), 1, productoNuevo, false);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            bool autorizar = bool.Parse(oConfiguracion.AutorizarDescProp);

            if (dgvDatos.Rows.Count > 0)
            {
                if (autorizar)
                {
                    AutorizarCambio f = new AutorizarCambio();
                    f.ShowDialog();
                    int pin = Int32.Parse(f.txtPin.Text);
                    if (pin != 0)
                    {
                        DataTable filas = DataManager.DBConsultas.IniciarSesion(pin.ToString());
                        if (filas.Rows.Count > 0)
                        {
                            //Codigo para mostrar la interfaz y autorizar
                            if (Int32.Parse(filas.Rows[0]["idRol"].ToString()) == 1)
                            {
                                DisminuirProducto();
                            }
                            else
                            {
                                MessageBox.Show("No tiene permiso para esta accion!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pin incorrecto, intentelo nuevamente!");
                        }
                    }
                }
                else
                {
                    DisminuirProducto();
                }
            }
        }
        public void BorrarPedidosVacios(String idMesa) 
        {
            try
            {
                DataTable dt = DataManager.DBConsultas.Pedidos(idMesa);
                Pedido pd = new Pedido();
                DataManager.DBOperacion transaccion = new DataManager.DBOperacion();
                List<String> lista = new List<string>();
                List<String> lista2 = new List<string>();
                int idPedido;
                int contador = 0;
                int contador1 = 0;

                DataTable dt1 = new DataTable();
                foreach (DataRow row in dt.Rows)
                {
                    idPedido = Convert.ToInt32(row["idPedido"]);
                    contador1++;
                    Console.WriteLine("ID Pedido: " + row["idPedido"]);
                    dt1 = DataManager.DBConsultas.ProductosEnMesaConIdPedido(idMesa, idPedido);
                    if (dt1.Rows.Count == 0)
                    {
                        contador++;
                        pd.IdPedido = idPedido;
                        lista.Add(pd.Eliminar()) ;
                    }
                }
                transaccion.EjecutarTransaccion(lista);
                if (contador == contador1)
                {
                    Mesa mesa = new Mesa
                    {
                        IdMesa = int.Parse(idMesa),
                        Disponible = true
                    };
                    lista2.Add(mesa.ActualizarEstado());
                    transaccion.EjecutarTransaccion(lista2);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EliminarPedidoOActualizarDetalle(bool eliminar, List<string> accion, int id)
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

                    //if (dgvDatos.Rows.Count == 1)
                    //{
                    //    CargarProductosPorMesa(lblMesa.Tag.ToString());
                    //}
                    //else
                    //{
                    //    CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
                    //}
                    CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));

                }
                else
                {
                    MessageBox.Show("ERROR EN TRANSACCION AL ELIMINAR PEDIDO O SU DETALLE, CONTACTE AL PROGRAMADOR.");
                }
            }
            if (id == 1 )
            {
                CargarPedidos(lblMesa.Tag.ToString());
                DataTable  dt = DataManager.DBConsultas.Pedidos(lblMesa.Tag.ToString());
                if (dt.Rows.Count == 1)
                {
                    btnCuentas.Visible = false;
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
            if (dgvDatos.Rows.Count > 0)
            {
                idPedidoCambioMesa = Int32.Parse(lblTicket.Text.ToString());
                cambiarMesa = true;
                Close();
            }
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
            if (dgvDatos.Rows.Count != 0)
            {
                SepararCuenta separar = new SepararCuenta();
                separar.lblMesa.Tag = lblMesa.Tag;
                separar.lblMesa.Text = "#Mesa: " + lblMesa.Tag;
                separar.lblTicket.Tag = lblTicket.Text;
                separar.lblTicket.Text = "#Pedido: " + lblTicket.Text;
                if (separar.ShowDialog().Equals(DialogResult.OK))
                {
                    DataTable dt = DataManager.DBConsultas.UltimoPedidoDeMesa(int.Parse(lblMesa.Tag.ToString()));
                    int idPedidoInsertado = Convert.ToInt32(dt.Rows[0]["IdPedido"]);
                    if (dt.Rows.Count > 0)
                    {
                        if (separar.cerrar)
                        {
                            listaIdProductos = separar.listaIdProductos;
                            ModificarLista(int.Parse(lblTicket.Text), listaIdProductos, idPedidoInsertado);
                        }
                    }
                    CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
                    if (idPedidoSiguiente > 0)
                    {
                        CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
                    }
                    else
                    {
                        CargarPedidos(lblMesa.Tag.ToString());
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
                    CargarPedidos(lblMesa.Tag.ToString());
                }
            }
        }

        private void ModificarLista(int idPedidoList, List<Tuple<int, int>> listaIdProductos, int idPedidoInsert)
        {
            try
            {
                foreach (var tupla in listaIdProductos)
                {
                    int idProducto = tupla.Item1;
                    int Cantidad = tupla.Item2;

                    ///Consulta para trear los datos del producto. grupo, nombre  
                    string claveDiccionario = idPedidoList.ToString(); //CLAVE IDPEDIDO
                    Boolean agregarElemento = false;

                    if (miDiccionario.ContainsKey(claveDiccionario)) ///BUSCA EL PEDIDO IDPEDIDO ES LA CLAVE
                    {
                        List<PedidoDetalle> DetallesDiccionario = miDiccionario[claveDiccionario];
                        var diccionario = DetallesDiccionario.FirstOrDefault(detalle => detalle.IdPedido == idPedidoList && detalle.IdProducto == idProducto); // Buscar el detalle correspondiente en la lista según idPedido
                        if (diccionario != null) /// SI EXISTE EL PEDIDO Y PRODUCTO EN EL DICCIONARIO
                        {
                            ///BUSCAR EN LA LISTA EL MISMO ID Y PRDOCUTO
                            foreach (var item in lstDetalle)
                            {
                                if (item.IdPedido == diccionario.IdPedido && item.IdProducto == diccionario.IdProducto) ///EXISTE EN LA LISTA Y EN EL PEDIDO EL IDPEDIDO Y PRODUCTO
                                {
                                    if (Cantidad >= item.Cantidad)
                                    {
                                        item.IdPedido = idPedidoInsert;
                                    }
                                    else if (Cantidad < item.Cantidad)
                                    {
                                        item.Cantidad = item.Cantidad - Cantidad ;
                                        agregarElemento = true;
                                    }
                                    break; // Se encontró el detalle, salimos del bucle
                                }
                            }
                        }
                        else
                        {
                            AgregarProductoLista(idProducto, Cantidad,idPedidoList ,idPedidoInsert);
                        }
                    }
                    else// NO HAY CLAVE CON DE ESTE PEDIDO
                    {
                        AgregarProductoLista(idProducto, Cantidad, idPedidoList, idPedidoInsert);
                    }

                    if (agregarElemento) //// SOLO CUANDO SE VA AGREGAR UN NUEVO ELEMENTO
                    {
                        AgregarElemento(Cantidad, idPedidoInsert, idProducto);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void AgregarProductoLista(int idProducto, int Cantidad,int idPedido, int idPedidoInsert) 
        {
            try
            {
                Boolean agregarElemento = false;
                foreach (var item in lstDetalle)
                {
                    if (item.IdProducto == idProducto && item.IdPedido == idPedido)
                    {
                        if (Cantidad >= item.Cantidad)
                        {
                            item.IdPedido = idPedidoInsert;
                        }
                        else if (Cantidad < item.Cantidad)
                        {
                            item.Cantidad = item.Cantidad - Cantidad;
                            agregarElemento = true;
                        }
                        break; // Se encontró el detalle, salimos del bucle
                    }
                }
                //VerListaDetalle();
                if (agregarElemento)
                {
                    AgregarElemento(Cantidad, idPedidoInsert, idProducto);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AgregarElemento(int Cantidad,int idPedidoInsert, int idProducto) 
        {
            ///Obtener detalles del productp
            DataTable dt = DataManager.DBConsultas.DetallesProducto(idProducto);
            String Nombre = "";
            String Grupo = "";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Nombre = row["nombre"].ToString();
                    Grupo = row["grupoPrinter"].ToString();
                }
            }
            PedidoDetalle pDetalle = new PedidoDetalle
            {
                Cantidad = Cantidad,
                IdPedido = idPedidoInsert,
                Mesa = lblMesa.Text,
                IdProducto = idProducto,
                Fecha = "",
                Nombre = Nombre,
                Grupo = Grupo,
            };
            lstDetalle.Add(pDetalle);
            //VerListaDetalle();
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            PedidosSeparados pedidosSeparados = new PedidosSeparados(lblTicket.Text)
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
                /*this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Finalizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });*/
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

            foreach (PedidoDetalle detalle in lstDetalle)
            {
                string grupoKey = detalle.Grupo;

                Console.WriteLine($"idPedido {detalle.IdPedido}, idProducto {detalle.IdProducto}, Grupo {detalle.Grupo}");

                if (grupos.ContainsKey(grupoKey))
                {
                    // Si el grupo ya existe, busca el detalle en la lista por IdProducto
                    var detalleExistente = grupos[grupoKey].FirstOrDefault(item => item.IdProducto == detalle.IdProducto);

                    if (detalleExistente != null)
                    {
                        // Si existe, suma las cantidades al detalle existente
                        detalleExistente.Cantidad += detalle.Cantidad;
                    }
                    else
                    {
                        // Si no existe, agrega el detalle a la lista del grupo
                        grupos[grupoKey].Add(detalle);
                    }
                }
                else
                {
                    // Si el grupo no existe, crea una nueva lista y agrega el detalle al grupo
                    grupos[grupoKey] = new List<PedidoDetalle> { detalle };
                }
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
                        // Crear un diccionario para asociar cada grupo con su impresora
                        Dictionary<string, string> impresorasPorGrupo = new Dictionary<string, string>{
                                { "COCINA", oConfiguracion.ImpresoraCocina },
                                { "BAR", oConfiguracion.ImpresoraBar },
                                { "GRUPO1", oConfiguracion.ImpresoraGrupoUno },
                                { "GRUPO2", oConfiguracion.ImpresoraGrupoDos },
                            };

                        if (impresorasPorGrupo.TryGetValue(kvp.Key, out string nombreImpresora))
                        {
                            // Configurar impresora según el grupo
                            PrinterSettings settings = new PrinterSettings
                            {
                                PrinterName = nombreImpresora
                            };

                            oReporte.PrintOptions.PrinterName = settings.PrinterName;
                            oReporte.PrintToPrinter(1, false, 0, 0);
                        }
                        else
                        {
                            //MessageBox.Show($"No se encontró una impresora asociada al grupo: {kvp.Key}, se recomienda revisar los nombres de los grupos para evitar fallas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CambioPrecioProducto f = new CambioPrecioProducto();
            f.lblPrecio.Text = Double.Parse(dgvDatos.CurrentRow.Cells["precio"].Value.ToString()).ToString("0.00");
            f.lblProducto.Text = dgvDatos.CurrentRow.Cells["nombre"].Value.ToString();
            f.ShowDialog();

            if (!f.txtPrecio.Text.Equals(""))
            {
                int idDetalle = Int32.Parse(dgvDatos.CurrentRow.Cells["idDetalle"].Value.ToString());
                int cantidad = Int32.Parse(dgvDatos.CurrentRow.Cells["cantidad"].Value.ToString());
                int idProducto = Int32.Parse(dgvDatos.CurrentRow.Cells["idProducto"].Value.ToString());
                int idPedido = Int32.Parse(dgvDatos.CurrentRow.Cells["idPedido"].Value.ToString());
                double precioNuevo = Double.Parse(f.txtPrecio.Text);
                double subTotal = cantidad*precioNuevo;

                PedidoDetalle pd = new PedidoDetalle();
                pd.IdDetalle = idDetalle;
                pd.Cantidad = cantidad;
                pd.Precio = precioNuevo;
                pd.SubTotal = subTotal;
                pd.IdPedido = idPedido;
                pd.IdProducto = idProducto;

                List<String> prod = new List<string>();
                prod.Add(pd.ActualizarCompra(false));

                DataManager.DBOperacion transaccion = new DataManager.DBOperacion();
                if (transaccion.EjecutarTransaccion(prod) < 0)
                {
                    MessageBox.Show("ERROR EN TRANSACCION AL CAMBIAR PRECIO, CONTACTE AL PROGRAMADOR.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ACTUALIZADO CON EXITO.", "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
                }
            }
        }
    }
}
