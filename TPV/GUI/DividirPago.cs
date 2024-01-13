using System;
using System.Windows.Forms;

namespace TPV.GUI
{
    public partial class DividirPago : Form
    {
        public DividirPago()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int cantidad;
            double totalPagar = 0, totalIndividual = 0, totalReunido = 0, totalSobrante = 0, totalFaltante = 0;
            if (!txtCantidad.Text.Equals(""))
            {
                cantidad = Int32.Parse(txtCantidad.Text);
                totalPagar = Double.Parse(Tag.ToString());

                totalIndividual = Math.Round((totalPagar / cantidad), 2);
                if ((totalIndividual * cantidad) < totalPagar)
                {
                    //Le falta a la cantidad
                    totalFaltante = totalPagar - (totalIndividual * cantidad);
                    lblFaltara.Text = "Faltara: $" + totalFaltante.ToString("0.00");
                }
                else
                {
                    lblFaltara.Text = "";
                }

                if ((totalIndividual * cantidad) > totalPagar)
                {
                    //Le sobra a la cantidad
                    totalSobrante = (totalIndividual * cantidad) - totalPagar;
                    lblSobrara.Text = "Sobrara: $" + totalSobrante.ToString("0.00");
                }
                else
                {
                    lblSobrara.Text = "";
                }
                totalReunido = totalIndividual * cantidad;
                lblPago.Text = "Cada uno debe pagar: $" + totalIndividual.ToString("0.00");
                lblReunido.Text = "Reuniran: $" + totalReunido.ToString("0.00");


            }
            else
            {
                lblPago.Text = "";
                lblReunido.Text = "";
                lblFaltara.Text = "";
                lblSobrara.Text = "";
            }
        }
    }
}
