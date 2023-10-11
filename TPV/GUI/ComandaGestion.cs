using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPV.GUI
{
    public partial class ComandaGestion : Form
    {
        PuntoVenta punto_venta;
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        BindingSource datos = new BindingSource();
        public bool cambiarMesa = false;
        public int idPedidoCambioMesa = 0;
        public bool cerrarSesion;
        public bool tpv;

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
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Ajustamos la posición del botón a la esquina derecha superior
            btnSalir.Left = screenWidth - btnSalir.Width;
            btnSalir.Top = 0;
        }

        public void CargarProductosPorMesa(String id)
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.ProductosEnMesa(id);
                dgvDatos.DataSource = datos;
                dgvDatos.AutoGenerateColumns = false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ComandaGestion_Load(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count>0)
            {
                btnComanda.Enabled = true;
                btnDisminuir.Enabled = true;
                btnExtras.Enabled = true;
            }
            FormBorderStyle = FormBorderStyle.None;
            // Creamos un Panel para envolver el FlowLayoutPanel
            Panel panelWrapper = new Panel();
            panelWrapper.Dock = DockStyle.Fill;
            panelWrapper.AutoScroll = true;

            // Agregamos el FlowLayoutPanel al Panel
            panelWrapper.Controls.Add(flpAcciones);
            panelWrapper.Controls.Add(flpFamilias);
            panelWrapper.Controls.Add(flpProductos);

            // Agregamos el Panel al formulario
            Controls.Add(panelWrapper);

            tFecha.Start();
            DataTable salones = DataManager.DBConsultas.Familias();
            // Crear y agregar botones al FlowLayoutPanel para cada salon
            foreach (DataRow salon in salones.Rows)
            {
                btnFamilia = new Button();
                btnFamilia.Text = salon["familia"].ToString().ToUpper();
                btnFamilia.Tag = salon["idFamilia"].ToString().ToUpper();
                btnFamilia.Size = new Size(150, 60);
                btnFamilia.Click += BotonFamilia_Click;
                flpFamilias.Controls.Add(btnFamilia);
            }
        }

        private void BotonFamilia_Click(object sender, EventArgs e)
        {
            if(flpProductos.Controls.Count > 0)
            {
                flpProductos.Controls.Clear();
            }

            Button botonFamilia = (Button)sender;

            DataTable productos = DataManager.DBConsultas.Productos(botonFamilia.Tag.ToString());
            // Crear y agregar botones al FlowLayoutPanel para cada producto
            foreach (DataRow producto in productos.Rows)
            {
                btnProducto = new Button();
                btnProducto.Text = producto["nombre"].ToString().ToUpper();
                btnProducto.Tag = producto["idProducto"].ToString().ToUpper();
                //btnProducto.BackgroundImage = Properties.Resources.mesa;
                //btnProducto.BackgroundImageLayout = ImageLayout.Stretch;
                btnProducto.TextAlign = ContentAlignment.MiddleCenter;
                /*if (!Boolean.Parse(producto["disponible"].ToString()))
                {
                    btnProducto.BackColor = Color.MidnightBlue;
                    btnProducto.ForeColor = Color.White;
                }*/
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
            
            double subTotal = 0;
            subTotal = precio*cantidad;
            return subTotal;
        }

        private void BotonProducto_Click(object sender, EventArgs e)
        {
            Button botonProducto = (Button)sender;
            int cantidad = 0;
                
            if (bool.Parse(oConfiguracion.MuchosProductos))
            {
                // Agregar muchos productos
                CantidadProductos f = new CantidadProductos();
                f.ShowDialog();
                cantidad = Int32.Parse(f.txtCantidad.Text);
                if (cantidad!=0)
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
            String fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (dgvDatos.Rows.Count > 0)
            {
                //Ya existe un pedido
                bool aumentarUnProducto = false;
                double precio = 0;
                //Saber si ya existe algun producto igual en los detalles
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    if (row.Cells["idProducto"].Value.ToString() == botonProducto.Tag.ToString())
                    {
                        cantidad = cantidad + Int32.Parse(row.Cells["cantidad"].Value.ToString());
                        precio = double.Parse(row.Cells["precio"].Value.ToString());
                        aumentarUnProducto = true;
                    }
                }
                Mantenimiento.CLS.PedidoDetalle pedidoDetalle = new Mantenimiento.CLS.PedidoDetalle();
                if (aumentarUnProducto)
                {
                    //Ya existe un producto igual en el datgrid, hay que aumentar
                    pedidoDetalle.IdPedido = Int32.Parse(lblTicket.Text.ToString());
                    pedidoDetalle.IdProducto = Int32.Parse(botonProducto.Tag.ToString());
                    pedidoDetalle.Cantidad = cantidad;
                    pedidoDetalle.SubTotal = CalcularSubTotal(cantidad, Int32.Parse(botonProducto.Tag.ToString()), precio);
                    if (pedidoDetalle.ActualizarCompra())
                    {

                    }
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
                    pedidoDetalle.IdProducto = Int32.Parse(botonProducto.Tag.ToString());
                    pedidoDetalle.IdPedido = Int32.Parse(lblTicket.Text.ToString());
                    pedidoDetalle.Cantidad = cantidad;
                    DataTable precioProductoNuevo = DataManager.DBConsultas.ObtenerPrecioDeProducto(Int32.Parse(botonProducto.Tag.ToString()));
                    pedidoDetalle.Precio = double.Parse(precioProductoNuevo.Rows[0]["precio"].ToString());
                    pedidoDetalle.SubTotal = CalcularSubTotal(cantidad, Int32.Parse(botonProducto.Tag.ToString()), double.Parse(precioProductoNuevo.Rows[0]["precio"].ToString()));
                    pedidoDetalle.Grupo = "0";
                    pedidoDetalle.Usuario = null;
                    pedidoDetalle.Insertar();
                }

            }
            else
            {
                //Creamos un nuevo pedido
                
                //No hay productos, se inicia el pedido
                //Creamos el pedido
                Mantenimiento.CLS.Pedido pedido = new Mantenimiento.CLS.Pedido();
                pedido.IdMesa = Int32.Parse(lblMesa.Tag.ToString());
                pedido.IdCuenta = 1;
                pedido.Cancelado = false;
                pedido.Fecha = fecha;
                pedido.Listo = false;
                pedido.Total = 0;
                pedido.Descuento = 0;
                pedido.Iva = 0;
                pedido.Propina = 0;
                pedido.TotalPago = 0;
                pedido.Saldo = 0;
                pedido.NFactura = "0";
                pedido.Anular = false;
                pedido.Efectivo = 0;
                pedido.Credito = 0;
                pedido.Btc = 0;

                int idPedidoInsertado;
                //Insertamos en la base de datos el pedido
                if (pedido.Insertar(out idPedidoInsertado))
                {
                    //MessageBox.Show("SE INSERTO CON EXITO");
                }
                else
                {
                    MessageBox.Show("ERROR AL INSERTAR PEDIDO");
                }

                //Agregamos detalles al pedido
                Mantenimiento.CLS.PedidoDetalle pedidoDetalle = new Mantenimiento.CLS.PedidoDetalle();
                pedidoDetalle.IdDetalle = 0;
                pedidoDetalle.Cocinando = true;
                pedidoDetalle.Extras = "";
                pedidoDetalle.HoraEntregado = fecha;
                pedidoDetalle.HoraPedido = fecha;
                //pedidoDetalle.IdCocinero = null;
                pedidoDetalle.IdProducto = Int32.Parse(botonProducto.Tag.ToString());
                pedidoDetalle.IdPedido = idPedidoInsertado;
                lblTicket.Text = idPedidoInsertado.ToString();
                pedidoDetalle.Cantidad = cantidad;
                DataTable precio = DataManager.DBConsultas.ObtenerPrecioDeProducto(Int32.Parse(botonProducto.Tag.ToString()));
                pedidoDetalle.Precio = double.Parse(precio.Rows[0]["precio"].ToString());
                pedidoDetalle.SubTotal = CalcularSubTotal(cantidad, Int32.Parse(botonProducto.Tag.ToString()), double.Parse(precio.Rows[0]["precio"].ToString()));
                pedidoDetalle.Grupo = "0";
                pedidoDetalle.Usuario = null;
                //pedidoDetalle.Fecha = null;

                if (pedidoDetalle.Insertar())
                {
                    Mantenimiento.CLS.Mesa mesa = new Mantenimiento.CLS.Mesa();
                    mesa.IdMesa = Int32.Parse(lblMesa.Tag.ToString());
                    if (mesa.ActualizarEstado())
                    {
                        //MessageBox.Show("SE ACTUALIZO CON EXITO");
                        btnComanda.Enabled = true;
                        btnDisminuir.Enabled = true;
                        btnExtras.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("ERROR AL ACTUALIZAR MESAO");
                    }
                    //MessageBox.Show("SE INSERTO CON EXITO");
                }
                else
                {
                    MessageBox.Show("ERROR AL INSERTAR DETALLE PEDIDO");
                }

            }
            //Vamos a actualizar el total del pedido
            Mantenimiento.CLS.Pedido pedido2 = new Mantenimiento.CLS.Pedido();
            pedido2.IdMesa = Int32.Parse(lblMesa.Tag.ToString());
            double total = CalcularTotal();
            pedido2.ActualizarTotal(total); 

            //Actualizar al final el datagrid
            CargarProductosPorMesa(lblMesa.Tag.ToString());

        }
        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
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
            if(lblMesa.Tag != null)
            {
                String idMesa = lblMesa.Tag.ToString();
                DataTable productoEnMesas = DataManager.DBConsultas.ProductosEnMesa(idMesa);
                if (lblMesa.Tag != null)
                {
                    if (productoEnMesas.Rows.Count > 0)
                    {
                        f.CargarProductosPorMesa(idMesa);
                        f.lblTicket.Text = productoEnMesas.Rows[0][0].ToString();//Accedemos a la primera posicion de la tabla

                        DataTable pedido = DataManager.DBConsultas.PedidoPorId(Int32.Parse(lblTicket.Text.ToString()));
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
            //Hacer algo aqui al cerrar sesion
            if (!cerrarSesion)
            {
                f.ShowDialog();
            }
            
            //Procedimiento luego de presionar el boton regresar para traer la informacion de la orden que se ha seleccionado
            if (f.lblTicket.Tag != null)
            {
                this.CargarProductosPorMesa(f.lblMesa.Tag.ToString());

                ActualizarLabelsRetroceder(Int32.Parse(f.lblTicket.Text.ToString()));
                lblMesa.Text = f.lblMesa.Text.ToString();
                lblMesa.Tag = f.lblMesa.Tag.ToString();
                lblTicket.Text = f.lblTicket.Text;
            }
            if (!cerrarSesion)
            {
                Show();
            }
            
        }

        private void ActualizarLabelsRetroceder(int id)
        {
            //Obtengo el pedido que estaba abierto en el punto de pago.
            DataTable pedido = DataManager.DBConsultas.PedidoPorId(id);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            punto_venta.admin = true;
            punto_venta.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Programando boton de disminuir
            Mantenimiento.CLS.PedidoDetalle pedidoDetalle = new Mantenimiento.CLS.PedidoDetalle();
            if (MessageBox.Show("¿Esta seguro que desea disminuir?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pedidoDetalle.IdPedido = Int32.Parse(lblTicket.Text.ToString());
                pedidoDetalle.IdProducto = Int32.Parse(dgvDatos.CurrentRow.Cells["idProducto"].Value.ToString());
                pedidoDetalle.Cantidad = Int32.Parse(dgvDatos.CurrentRow.Cells["cantidad"].Value.ToString()) - 1;
                pedidoDetalle.SubTotal = CalcularSubTotal(Int32.Parse(dgvDatos.CurrentRow.Cells["cantidad"].Value.ToString()) - 1, Int32.Parse(dgvDatos.CurrentRow.Cells["idProducto"].Value.ToString()), double.Parse(dgvDatos.CurrentRow.Cells["precio"].Value.ToString()));

            }
            if (pedidoDetalle.ActualizarCompra())
            {
                //Actualizar al final el datagrid
                CargarProductosPorMesa(lblMesa.Tag.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cambiarMesa = true;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientesGestion cg = new ClientesGestion();
            cg.seleccionCliente = true;
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
                ActualizarLabelsRetroceder(Int32.Parse(lblTicket.Text.ToString()));
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
                ActualizarLabelsRetroceder(Int32.Parse(lblTicket.Text.ToString()));
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
        }

        private void btnExtras_Click(object sender, EventArgs e)
        {
            SepararCuenta separar = new SepararCuenta();
            separar.lblMesa.Tag = lblMesa.Tag;
            separar.lblMesa.Text = "#Mesa: " + lblMesa.Tag;
            separar.lblTicket.Tag = lblTicket.Text;
            separar.lblTicket.Text = "#Pedido: " + lblTicket.Text;
            separar.ShowDialog();
        }
    }
}
