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

    public partial class PuntoVenta : Form
    {
        public bool cambiarMesa = false;
        public int idPedidoCambioMesa = 0;
        private int idMesaAnterior = 0;
        public bool admin;
        public bool cerrarSesion;

        public PuntoVenta()
        {
            InitializeComponent();
            flpSalones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            flpMesas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            AjustarPosicionBoton();
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

        private void PuntoVenta_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            DataTable salones = DataManager.DBConsultas.Salones();
            // Crear y agregar botones al FlowLayoutPanel para cada salon
            int fila = 0;
            int columna = 0;
            foreach (DataRow salon in salones.Rows)
            {
                btnSalon = new Button();
                btnSalon.Text = salon["nombre"].ToString().ToUpper();
                btnSalon.Tag = salon["idSalon"].ToString().ToUpper();
                btnSalon.Size = new Size(200,80);
                btnSalon.Click += BotonSalon_Click;
                flpSalones.Controls.Add(btnSalon);
                flpSalones.ScrollControlIntoView(btnSalon);
                columna++;
                if (columna == 5)
                {
                    columna = 0;
                    fila++;
                }
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
                btnMesa.Size = new Size(110, 90);
                btnMesa.Click += BotonMesa_Click;
                flpMesas.Controls.Add(btnMesa);
                flpMesas.ScrollControlIntoView(btnMesa);
            }
        }

        private void BotonMesa_Click(object sender, EventArgs e)
        {
            this.Hide();
            Button botonMesa = (Button)sender;
            String idMesa = botonMesa.Tag.ToString();
            //Hacer que las mesas se puedan o no seleccionar
            if (cambiarMesa)
            {
                Mantenimiento.CLS.Pedido pedido = new Mantenimiento.CLS.Pedido();
                pedido.IdPedido = idPedidoCambioMesa;
                pedido.IdMesa = Int32.Parse(botonMesa.Tag.ToString());

                if (pedido.ActualizarMesa())
                {
                    //MessageBox.Show("SE ACTUALIZO CON EXITO");
                }
                else
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR");
                }
                
                //Aqui el codigo para cambiar de mesa
                Mantenimiento.CLS.Mesa mesa = new Mantenimiento.CLS.Mesa();
                mesa.Disponible = false;
                mesa.IdMesa = Int32.Parse(botonMesa.Tag.ToString());
                if (mesa.ActualizarEstado())
                {
                    //Hacer disponible la mesa anterior
                    Mantenimiento.CLS.Mesa mesa2 = new Mantenimiento.CLS.Mesa();
                    mesa2.Disponible = true;
                    mesa2.IdMesa = idMesaAnterior;
                    if (mesa2.ActualizarEstado())
                    {
                        //MessageBox.Show("SE ACTUALIZO CON EXITO");
                    }
                    else
                    {
                        MessageBox.Show("ERROR AL ACTUALIZAR");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR");
                }

            }
          
            DataTable productoEnMesas = DataManager.DBConsultas.ProductosEnMesa(idMesa);
            ComandaGestion f = new ComandaGestion(this);

            if (productoEnMesas.Rows.Count > 0)
            {
                //Asignamos datos al futuro formulario a abrir.
                f.CargarProductosPorMesa(idMesa);
                f.lblTicket.Text = productoEnMesas.Rows[0][0].ToString();//Accedemos a la primera posicion de la tabla
                //Agregando datos mesero y cliente si los hay
                DataTable pedido = DataManager.DBConsultas.PedidoPorId(Int32.Parse(productoEnMesas.Rows[0][0].ToString()));
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

        private void btnSalir_Resize(object sender, EventArgs e)
        {
            AjustarPosicionBoton();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
