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
    public partial class PedidosSeparados : Form
    {
        public string idMesa;
        public DataTable pedidosEnMesa;
        public PedidosSeparados()
        {
            InitializeComponent();
            flpPedidos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

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
                flpPedidos.Controls.Add(btnPedido);
                flpPedidos.ScrollControlIntoView(btnPedido);
            }
        }

        private void BotonPedido_Click(object sender, EventArgs e)
        {
            
        }
    }
}
