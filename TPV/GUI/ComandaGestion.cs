using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPV.GUI
{
    public partial class ComandaGestion : Form
    {
        PuntoVenta punto_venta;
        BindingSource datos = new BindingSource();
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
            WindowState = FormWindowState.Maximized;
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
        private void CalcularTotal()
        {
            if (dgvDatos.Rows.Count > 0)
            {

            }
        }
        private void BotonProducto_Click(object sender, EventArgs e)
        {
            CantidadProductos cp = new CantidadProductos();
            cp.ShowDialog();
            String fecha = lblFecha.Text.ToString();
            Button botonProducto = (Button)sender;
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

            if (dgvDatos.Rows.Count <= 0)
            {
                //No hay productos, se inicia el pedido

            }
            else
            {
                //Ya hay productos, se actualiza el pedido
            }
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
            PuntoPago f = new PuntoPago();
            f.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            punto_venta.Close();
        }
    }
}
