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
    public partial class PuntoPago : Form
    {
        BindingSource datos = new BindingSource();
        DataTable configuracion = DataManager.DBConsultas.Configuraciones();
        private bool hasEnteredNumber = false; // Variable para controlar si se ha ingresado un número
        private bool escritoUnPunto = false; //Variable para verificar si se ha ingresado un punto

        public PuntoPago()
        {
            InitializeComponent();
        }

        public void CargarProductosPorMesa(String id)
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.ProductosEnMesa(id);
                dgvDatos.DataSource = datos;
                dgvDatos.AutoGenerateColumns = false;

                lblTicket.Text = dgvDatos.Rows[0].Cells["idPedido"].Value.ToString();//Accedemos a la primera posicion de la tabla

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void PuntoPago_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;

            if(dgvDatos.Rows.Count > 0)
            {
                lblSaldo.Text = "$" + CalcularTotal().ToString("0.00");
                lblSaldo.Tag = Math.Round(CalcularTotal(), 2);
                if (configuracion.Rows.Count > 0)
                {
                    bool incluirPropina = bool.Parse(configuracion.Rows[0]["incluirPropina"].ToString());

                    if (incluirPropina)
                    {
                        //Denifir la propina
                        CalcularTodo();
                    }
                    else
                    {
                        CalcularTodo();
                    }
                }
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

        private double CalcularPropina()
        {
            if (configuracion.Rows.Count > 0)
            {
                double porcentaje = Double.Parse(configuracion.Rows[0]["propina"].ToString());
                double total = CalcularTotal();
                return (total * (porcentaje / 100));
            }
            return 0;
        }

        private double CalcularDescuento()
        {
            double total = CalcularTotal();
            if (!txtPorcentaje.Text.Equals(""))
            {
                //Calculamos el descuento
                return (total * (double.Parse(txtPorcentaje.Text.ToString()) / 100));
            }
            return 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PuntoVenta f = new PuntoVenta();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SeleccionSalonMesa f = new SeleccionSalonMesa();
            f.ShowDialog();
            if (SeleccionSalonMesa.idMesa > 0)
            {
                CargarProductosPorMesa(SeleccionSalonMesa.idMesa.ToString());
                lblMesa.Text = SeleccionSalonMesa.Mesa.ToString();
                lblMesa.Tag = SeleccionSalonMesa.idMesa.ToString();
            }
            lblSaldo.Text = "$" + CalcularTotal().ToString("0.00");
            lblSaldo.Tag = Math.Round(CalcularTotal(), 2);
            CalcularTodo();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtPagoRegistrar.Text.Equals("0"))
            {
                txtPagoRegistrar.Text = btn9.Text;
            }
            else
            {
                txtPagoRegistrar.Text += btn9.Text;
            }
            
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtPagoRegistrar.Text.Equals("0"))
            {
                txtPagoRegistrar.Text = btn8.Text;
            }
            else
            {
                txtPagoRegistrar.Text += btn8.Text;
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtPagoRegistrar.Text.Equals("0"))
            {
                txtPagoRegistrar.Text = btn7.Text;
            }
            else
            {
                txtPagoRegistrar.Text += btn7.Text;
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtPagoRegistrar.Text.Equals("0"))
            {
                txtPagoRegistrar.Text = btn6.Text;
            }
            else
            {
                txtPagoRegistrar.Text += btn6.Text;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtPagoRegistrar.Text.Equals("0"))
            {
                txtPagoRegistrar.Text = btn5.Text;
            }
            else
            {
                txtPagoRegistrar.Text += btn5.Text;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtPagoRegistrar.Text.Equals("0"))
            {
                txtPagoRegistrar.Text = btn4.Text;
            }
            else
            {
                txtPagoRegistrar.Text += btn4.Text;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtPagoRegistrar.Text.Equals("0"))
            {
                txtPagoRegistrar.Text = btn3.Text;
            }
            else
            {
                txtPagoRegistrar.Text += btn3.Text;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtPagoRegistrar.Text.Equals("0"))
            {
                txtPagoRegistrar.Text = btn2.Text;
            }
            else
            {
                txtPagoRegistrar.Text += btn2.Text;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtPagoRegistrar.Text.Equals("0"))
            {
                txtPagoRegistrar.Text = btn1.Text;
            }
            else
            {
                txtPagoRegistrar.Text += btn1.Text;
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtPagoRegistrar.Text.Equals("0"))
            {
                txtPagoRegistrar.Text = btn0.Text;
            }
            else
            {
                txtPagoRegistrar.Text += btn0.Text;
            }
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!escritoUnPunto)
            {
                if (!txtPagoRegistrar.Text.Equals("0"))
                {
                    txtPagoRegistrar.Text += btnPunto.Text;
                    escritoUnPunto = true;
                }
            }
            
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtPagoRegistrar.Text = "0";
            escritoUnPunto = false;
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            double pagar = Double.Parse(txtPagoRegistrar.Text.ToString());
            int valor = 1;
            pagar = valor + pagar;
            txtPagoRegistrar.Text = pagar.ToString().Trim();
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            double pagar = Double.Parse(txtPagoRegistrar.Text.ToString());
            int valor = 2;
            pagar = valor + pagar;
            txtPagoRegistrar.Text = pagar.ToString().Trim();
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            double pagar = Double.Parse(txtPagoRegistrar.Text.ToString());
            int valor = 5;
            pagar = valor + pagar;
            txtPagoRegistrar.Text = pagar.ToString().Trim();
        }

        private void btnDiez_Click(object sender, EventArgs e)
        {
            double pagar = Double.Parse(txtPagoRegistrar.Text.ToString());
            int valor = 10;
            pagar = valor + pagar;
            txtPagoRegistrar.Text = pagar.ToString().Trim();
        }

        private void btnVeinte_Click(object sender, EventArgs e)
        {
            double pagar = Double.Parse(txtPagoRegistrar.Text.ToString());
            int valor = 20;
            pagar = valor + pagar;
            txtPagoRegistrar.Text = pagar.ToString().Trim();
        }

        private void btnCincuenta_Click(object sender, EventArgs e)
        {
            double pagar = Double.Parse(txtPagoRegistrar.Text.ToString());
            int valor = 50;
            pagar = valor + pagar;
            txtPagoRegistrar.Text = pagar.ToString().Trim();
        }

        private void btnCien_Click(object sender, EventArgs e)
        {
            double pagar = Double.Parse(txtPagoRegistrar.Text.ToString());
            int valor = 100;
            pagar = valor + pagar;
            txtPagoRegistrar.Text = pagar.ToString().Trim();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txtPagoRegistrar.Text = "0";
            escritoUnPunto = false;
        }

        private void cbDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescuento.Checked)
            {
                lblPorcentaje.Visible = true;
                txtPorcentaje.Visible = true;
            }
            else
            {
                txtPorcentaje.Text = "";
                lblPorcentaje.Visible = false;
                txtPorcentaje.Visible = false;
            }
            CalcularTodo();
        }

        private void CalcularTodo()
        {
            double totalPagar = Math.Round(CalcularTotal(), 2);
            double propina = Math.Round(CalcularPropina(), 2);
            double descuento = Math.Round(CalcularDescuento(), 2);
            double iva = Math.Round(CalcularIva(), 2);

            if (cbPropina.Checked)
            {
                //Sin propina
                propina = 0;
            }
            else
            {
                //Con propina
                totalPagar = totalPagar + propina;
            }

            if (cbDescuento.Checked)
            {
                //Con descuento
                totalPagar = totalPagar - descuento;
            }
            else
            {
                //Sin descuento
                descuento = 0;
            }
            double cambio = Math.Round(CalcularCambio(totalPagar), 2);
            ActualizarCampos(propina,descuento,totalPagar, iva, cambio);
        }

        private double CalcularIva()
        {
            return 0;
        }

        private void ActualizarCampos(double propina, double descuento, double total, double iva, double cambio)
        {
            lblPropina.Text = "$" + propina.ToString("0.00");
            lblPropina.Tag = propina;
            lblDescuento.Text = "$" + descuento.ToString("0.00");
            lblDescuento.Tag = descuento;
            lblCambio.Text = "$" + cambio.ToString("0.00");
            lblCambio.Tag = cambio;
            lblIva.Text = "$" + iva.ToString("0.00");
            lblIva.Tag = iva;

            txtTotalPagar.Text = Math.Round(total, 2).ToString();
            txtTotalPagar.Tag = Math.Round(total, 2);
            
        }

        private double CalcularCambio(double totalPagar)
        {
            double cambio = 0;
            if (!txtPagoRegistrar.Text.Equals(""))
            {
                cambio = double.Parse(txtPagoRegistrar.Text.ToString()) - totalPagar;
            }
            return cambio;
        }

        private void cbPropina_CheckedChanged(object sender, EventArgs e)
        {
            CalcularTodo();
        }

        private void txtPorcentaje_TextChanged(object sender, EventArgs e)
        {
            CalcularTodo();
        }

        private void txtPagoRegistrar_TextChanged(object sender, EventArgs e)
        {
            CalcularTodo();
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado es un dígito o una tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter si no es un dígito ni una tecla de control
            }

            // Verificar si se ha ingresado un número
            if (char.IsDigit(e.KeyChar))
            {
                // Obtener el contenido actual del TextBox
                string currentText = txtPorcentaje.Text + e.KeyChar;

                // Convertir el contenido en un número
                if (!int.TryParse(currentText, out int number))
                {
                    e.Handled = true; // Ignorar el carácter si no se puede convertir a número
                }

                // Verificar si el número está fuera del rango permitido
                if (number < 1 || number > 99)
                {
                    e.Handled = true; // Ignorar el carácter si el número está fuera del rango
                }
            }
        }

        private void txtPagoRegistrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado no es un dígito
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter si no es un dígito ni una tecla de control
            }
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                // Si se ingresó un dígito o una tecla de control, permitirlo siempre
                hasEnteredNumber = true; // Marcar que se ha ingresado un número
            }
            else if (e.KeyChar == '.' && hasEnteredNumber && !txtPagoRegistrar.Text.Contains("."))
            {
                // Si se ingresó un punto y se ha ingresado un número antes, permitirlo solo si no hay otro punto en el texto
                // Además, marcar que se ha ingresado un punto
                hasEnteredNumber = false;
            }
            else
            {
                e.Handled = true; // Ignorar cualquier otro carácter
            }
            // Verificar si la tecla presionada es el retroceso (Backspace)
            if (e.KeyChar == (char)Keys.Back)
            {
                // Impedir borrar si solo hay un carácter en el TextBox
                if (txtPagoRegistrar.Text.Length <= 1)
                {
                    e.Handled = true; // Indicar que el evento está manejado y no debe procesarse
                }
            }
        }
    }
}
