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
                }
                btnMesa.Size = new Size(110, 90);
                btnMesa.Click += BotonMesa_Click;
                flpMesas.Controls.Add(btnMesa);
            }
        }

        private void BotonMesa_Click(object sender, EventArgs e)
        {
            this.Hide();
            Button botonMesa = (Button)sender;
            String idMesa = botonMesa.Tag.ToString();
            DataTable productoEnMesas = DataManager.DBConsultas.ProductosEnMesa(idMesa);
            ComandaGestion f = new ComandaGestion();
            
            if (productoEnMesas.Rows.Count > 0)
            {
                
                f.CargarProductosPorMesa(idMesa);
                f.lblMesa.Text = botonMesa.Text.ToString();
                f.lblMesa.Tag = botonMesa.Tag.ToString();
                f.lblMesa.Visible = true;
                f.lblTicket.Text = productoEnMesas.Rows[0][0].ToString();//Accedemos a la primera posicion de la tabla
                f.lblTicket.Visible = true;
            }
            
            f.ShowDialog();
            this.Show();
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
