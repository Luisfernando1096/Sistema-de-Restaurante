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

namespace Configuraciones.GUI
{
    public partial class Recomendada : Form
    {
        public Recomendada()
        {
            InitializeComponent();
        }

        private void Recomendada_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            
            int numeroMoneda = culture.NumberFormat.CurrencyDecimalDigits;
            string decimalMoneda = culture.NumberFormat.CurrencyDecimalSeparator;
            string separadorMoneda = culture.NumberFormat.CurrencyGroupSeparator;
            string simboloMoneda = culture.NumberFormat.CurrencySymbol;
            String simboloNegativo = culture.NumberFormat.NegativeSign;
            int numeroNumero = culture.NumberFormat.NumberDecimalDigits;
            string decimalNumero = culture.NumberFormat.NumberDecimalSeparator;
            string separadorNumero = culture.NumberFormat.NumberGroupSeparator;

            txtNumeroMoneda.Text = numeroMoneda.ToString();
            txtDecimalMoneda.Text = decimalMoneda;
            txtSeparadorMoneda.Text = separadorMoneda;
            txtSimboloMoneda.Text = simboloMoneda;
            txtSimboloNegativo.Text = simboloNegativo;
            txtNumeroNumero.Text = numeroNumero.ToString();
            txtDecimalNumero.Text = decimalNumero;
            txtSeparadorNumero.Text = separadorNumero;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
