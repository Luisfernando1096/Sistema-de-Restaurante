using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TPV.GUI
{
    public partial class PedidosSeparados : Form
    {
        public string idMesa;
        public int idPedido;
        public DataTable pedidosEnMesa;
        public string BotonTag;
        public PedidosSeparados(string BotonTag)
        {
            InitializeComponent();
            flpPedidos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.BotonTag = BotonTag;
        }

        private void PedidosSeparados_Load(object sender, EventArgs e)
        {
            // Crear y agregar botones al FlowLayoutPanel para cada salon
            foreach (DataRow pedido in pedidosEnMesa.Rows)
            {
                btnPedido = new Button();
                btnPedido.Text = pedido["idPedido"].ToString().ToUpper();
                btnPedido.Size = new Size(200, 80);
                btnPedido.Click += BotonPedido_Click;
                btnPedido.TabStop = false; ///QUITA EL CALOR DE ENFOQUE
                flpPedidos.Controls.Add(btnPedido);
                flpPedidos.ScrollControlIntoView(btnPedido);
                if (btnPedido.Text == BotonTag)
                {
                    btnPedido.FlatStyle = FlatStyle.Flat;
                    btnPedido.FlatAppearance.BorderSize = 1;
                    btnPedido.BackColor = Color.LightBlue;
                }
            }
        }

        private void BotonPedido_Click(object sender, EventArgs e)
        {
            Button botonPedido = (Button)sender;
            idPedido = Int32.Parse(botonPedido.Text);
            Close();
        }
    }
}
