using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace TPV.GUI
{

    public partial class PuntoVenta : Form
    {
        public bool cambiarMesa = false;
        public int idPedidoCambioMesa = 0;
        public int idMesaAnterior = 0;
        public bool admin;
        public bool tpv;
        public bool cerrarSesion;
        //Salones
        string AnchoSalon;
        string AltoSalon;
        string SeparadorSalon;
        //Mesas
        string AnchoMesa;
        string AltoMesa;
        string SeparadorMesa;

        public PuntoVenta()
        {
            InitializeComponent();
            flpSalones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            flpMesas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            AjustarPosicionBoton();
            CargarDimensiones();
        }
        private void AjustarPosicionBoton()
        {
            // Obtenemos el ancho y alto de la pantalla
            int screenWidth = this.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Ajustamos la posición del botón a la esquina derecha superior
            btnSalir.Left = screenWidth - (btnSalir.Width + 30);
            btnSalir.Top = 0;
        }

        private void CargarDimensiones()
        {
            string archivoConfiguracion = "dimensiones.xml";

            if (File.Exists(archivoConfiguracion))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(archivoConfiguracion);

                //Salones
                AnchoSalon = xmlDoc.SelectSingleNode("/Dimension/AnchoSalon").InnerText;
                AltoSalon = xmlDoc.SelectSingleNode("/Dimension/AltoSalon").InnerText;
                SeparadorSalon = xmlDoc.SelectSingleNode("/Dimension/SeparadorSalon").InnerText;

                //Mesas
                AnchoMesa = xmlDoc.SelectSingleNode("/Dimension/AnchoMesa").InnerText;
                AltoMesa = xmlDoc.SelectSingleNode("/Dimension/AltoMesa").InnerText;
                SeparadorMesa = xmlDoc.SelectSingleNode("/Dimension/SeparadorMesa").InnerText;
            }
        }

        private void PuntoVenta_Load(object sender, EventArgs e)
        {
            /*
             string archivoConfiguracion = "dimensiones.xml";
            //Salones
            string AnchoSalon = "10";
            string AltoSalon = "10";
            string SeparadorSalon = "10";

            if (File.Exists(archivoConfiguracion))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(archivoConfiguracion);

                //Salones
                AnchoSalon = xmlDoc.SelectSingleNode("/Dimension/AnchoSalon").InnerText;
                AltoSalon = xmlDoc.SelectSingleNode("/Dimension/AltoSalon").InnerText;
                SeparadorSalon = xmlDoc.SelectSingleNode("/Dimension/SeparadorSalon").InnerText;
            }
             */
            WindowState = FormWindowState.Maximized;
            DataTable salones = DataManager.DBConsultas.Salones();
            // Crear y agregar botones al FlowLayoutPanel para cada salon
            foreach (DataRow salon in salones.Rows)
            {
                btnSalon = new Button();
                btnSalon.Text = salon["nombre"].ToString().ToUpper();
                btnSalon.Tag = salon["idSalon"].ToString().ToUpper();
                btnSalon.Size = new Size(Int32.Parse(AnchoSalon), Int32.Parse(AltoSalon));//Establecer ancho y alto
                btnSalon.Margin = new Padding(Int32.Parse(SeparadorSalon));//Establecer margen
                btnSalon.Click += BotonSalon_Click;
                flpSalones.Controls.Add(btnSalon);
                flpSalones.ScrollControlIntoView(btnSalon);

            }
        }

        private void BotonSalon_Click(object sender, EventArgs e)
        {
            if (flpMesas.Controls.Count > 0)
            {
                flpMesas.Controls.Clear();
            }

            Button botonSalon = (Button)sender;

            DataTable mesas = DataManager.DBConsultas.Mesas(botonSalon.Tag.ToString());
            // Crear y agregar botones al FlowLayoutPanel para cada producto
            foreach (DataRow mesa in mesas.Rows)
            {
                btnMesa = new Button();
                btnMesa.Text = mesa["nombre"].ToString().ToUpper();
                btnMesa.Tag = mesa["idMesa"].ToString().ToUpper();
                btnMesa.BackgroundImage = Properties.Resources.mesa;
                btnMesa.BackgroundImageLayout = ImageLayout.Stretch;
                btnMesa.TextAlign = ContentAlignment.TopCenter;
                if (!Boolean.Parse(mesa["disponible"].ToString()))
                {
                    btnMesa.BackColor = Color.MidnightBlue;
                    btnMesa.ForeColor = Color.White;
                    //Hacer que las mesas se puedan o no seleccionar
                    if (cambiarMesa && Int32.Parse(btnMesa.Tag.ToString()) != idMesaAnterior)
                    {
                        btnMesa.Enabled = false;

                    }
                }
                btnMesa.Margin = new Padding(Int32.Parse(SeparadorMesa));
                btnMesa.Size = new Size(Int32.Parse(AnchoMesa), Int32.Parse(AltoMesa));
                btnMesa.Click += BotonMesa_Click;
                flpMesas.Controls.Add(btnMesa);
                flpMesas.ScrollControlIntoView(btnMesa);
            }
        }

        private void BotonMesa_Click(object sender, EventArgs e)
        {
            List<String> lstCambioMesa = new List<string>();
            this.Hide();
            Button botonMesa = (Button)sender;
            String idMesa = botonMesa.Tag.ToString();
            DataTable datosEnMesa = DataManager.DBConsultas.PedidosEnMesa(idMesaAnterior.ToString());
            //Hacer que las mesas se puedan o no seleccionar
            if (cambiarMesa)
            {
                Mantenimiento.CLS.Pedido pedido = new Mantenimiento.CLS.Pedido();
                pedido.IdPedido = idPedidoCambioMesa;
                pedido.IdMesa = Int32.Parse(botonMesa.Tag.ToString());

                lstCambioMesa.Add(pedido.ActualizarMesa());

                //Aqui el codigo para cambiar de mesa
                Mantenimiento.CLS.Mesa mesa = new Mantenimiento.CLS.Mesa();
                mesa.Disponible = false;
                mesa.IdMesa = Int32.Parse(botonMesa.Tag.ToString());
                lstCambioMesa.Add(mesa.ActualizarEstado());
                
                if (datosEnMesa.Rows.Count == 1)
                {
                    //Hacer disponible la mesa anterior
                    Mantenimiento.CLS.Mesa mesa2 = new Mantenimiento.CLS.Mesa();
                    mesa2.Disponible = true;
                    mesa2.IdMesa = idMesaAnterior;
                    lstCambioMesa.Add(mesa2.ActualizarEstado());
                }

                //Hacer la transaccion aqui
                DataManager.DBOperacion transaccion1 = new DataManager.DBOperacion();
                if (transaccion1.EjecutarTransaccion(lstCambioMesa) > 0)
                {
                    
                }
                else
                {
                    MessageBox.Show("ERROR EN TRANSACCION AL CAMBIAR DE MESA, CONTACTE AL PROGRAMADOR.");
                }
            }

            DataTable productoEnMesas = DataManager.DBConsultas.ProductosEnMesaConIdPedido(idMesa, 0);
            ComandaGestion f = new ComandaGestion(this);
            f.borrarData = false;

            if (productoEnMesas.Rows.Count > 0)
            {
                //Asignamos datos al futuro formulario a abrir.
                f.CargarProductosPorMesa(idMesa);
                f.CargarPedidosEnMesa(idMesa);

                //Agregando datos mesero y cliente si los hay
                DataTable pedido = DataManager.DBConsultas.PedidoPorId(Int32.Parse(productoEnMesas.Rows[0][0].ToString()), false);
                if (!pedido.Rows[0]["nombres"].ToString().Equals(""))
                {
                    f.lblMesero.Text = pedido.Rows[0]["nombres"].ToString();
                    f.lblMesero.Tag = int.Parse(pedido.Rows[0]["idMesero"].ToString());
                }
                if (!pedido.Rows[0]["nombre"].ToString().Equals(""))
                {
                    f.lblCliente.Text = pedido.Rows[0]["nombre"].ToString();
                    f.lblCliente.Tag = int.Parse(pedido.Rows[0]["idCliente"].ToString());
                }
            }
            f.lblMesa.Text = botonMesa.Text.ToString();
            f.lblMesa.Tag = botonMesa.Tag.ToString();


            f.ShowDialog();
            cambiarMesa = f.cambiarMesa;
            if (!f.lblTicket.Text.ToString().Equals(""))
            {
                idPedidoCambioMesa = Int32.Parse(f.lblTicket.Text.ToString());
            }
            if (f.lblMesa.Tag != null)
            {
                idMesaAnterior = Int32.Parse(f.lblMesa.Tag.ToString());
            }
            this.Close();

            //Si no di click en el formulario anterior a ir a administracion
            if (!admin && !cerrarSesion)
            {
                PuntoVenta f2 = new PuntoVenta(); // Crea una nueva instancia del formulario
                f2.cambiarMesa = cambiarMesa;
                f2.idPedidoCambioMesa = idPedidoCambioMesa;
                f2.idMesaAnterior = idMesaAnterior;
                f2.ShowDialog(); // Muestra el nuevo formulario
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
