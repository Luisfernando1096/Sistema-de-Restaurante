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
        ComandaGestion comandaGestion;
        BindingSource datos = new BindingSource();
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        DataTable actualFactura = DataManager.DBConsultas.ObtenerTirajeActual();
        private Mantenimiento.CLS.Pedido pedido = new Mantenimiento.CLS.Pedido();
        private bool hasEnteredNumber = false; // Variable para controlar si se ha ingresado un número
        private bool escritoUnPunto = false; //Variable para verificar si se ha ingresado un punto
        private bool activarFactura = false;
        private bool activarTicket = true;
        private DataTable datosEnMesa;

        public PuntoPago(ComandaGestion comandaGestion)
        {
            InitializeComponent();
            this.comandaGestion = comandaGestion;
            btnTicket.BackColor = Color.CadetBlue;
        }

        public void CargarProductosPorMesa(String id)
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.ProductosEnMesa(id);
                dgvDatos.DataSource = datos;
                dgvDatos.AutoGenerateColumns = false;

                lblTicket.Text = dgvDatos.Rows[0].Cells["idPedido"].Value.ToString();//Accedemos a la primera posicion de la tabla
                lblTicket.Tag = Int32.Parse(dgvDatos.Rows[0].Cells["idPedido"].Value.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CargarPedidosEnMesa(String id)
        {
            try
            {
                datosEnMesa = DataManager.DBConsultas.PedidosEnMesa(id);
                if (datosEnMesa.Rows.Count > 1)
                {
                    btnCuentas.Visible = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void PuntoPago_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;

            if(dgvDatos.Rows.Count > 0)
            {
                lblSaldo.Text = "$" + CalcularTotal().ToString("0.00");
                lblSaldo.Tag = Math.Round(CalcularTotal(), 2);
                if (oConfiguracion != null)
                {
                    bool incluirPropina = bool.Parse(oConfiguracion.IncluirPropina);

                    if (incluirPropina)
                    {
                        //Activar  el check
                        cbPropina.Checked = false;
                        CalcularTodo();
                    }
                    else
                    {
                        //Activar  el check
                        cbPropina.Checked = true;
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
            if (oConfiguracion != null)
            {
                double porcentaje = Double.Parse(oConfiguracion.Propina);
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
            comandaGestion.tpv = true;
            comandaGestion.Close();
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SeleccionSalonMesa f = new SeleccionSalonMesa();
            f.ShowDialog();
            if (SeleccionSalonMesa.idMesa > 0)
            {
                CargarProductosPorMesa(SeleccionSalonMesa.idMesa.ToString());
                CargarPedidosEnMesa(SeleccionSalonMesa.idMesa.ToString());
                lblMesa.Text = SeleccionSalonMesa.Mesa.ToString();
                lblMesa.Tag = SeleccionSalonMesa.idMesa.ToString();
                DataTable pedido = DataManager.DBConsultas.PedidoPorId(Int32.Parse(lblTicket.Text.ToString()));
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
                if (!txtPagoRegistrar.Text.Equals("."))
                {
                    cambio = double.Parse(txtPagoRegistrar.Text.ToString()) - totalPagar;
                }
                else
                {
                    txtPagoRegistrar.Text = "";
                }
            }
            return cambio;
        }

        private void cbPropina_CheckedChanged(object sender, EventArgs e)
        {
            
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
                if(e.KeyChar != '.' || !hasEnteredNumber)
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
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se cerrara la sesion, ¿esta seguro que desea cerrar sesion?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                comandaGestion.cerrarSesion = true;
                comandaGestion.Close();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Obtener la ultima factura y crear una nueva
            if (actualFactura.Rows.Count > 0)
            {
                foreach (DataRow item in actualFactura.Rows)
                {
                    if (Int32.Parse(item["actual"].ToString()) == Int32.Parse(item["fin"].ToString()))
                    {
                        MessageBox.Show("Se ha alcanzado el maximo de facturas, solicite al administrador un nuevo tiraje.");
                    }
                    else
                    {
                        if (activarFactura)
                        {
                            activarFactura = false;
                            btnFactura.BackColor = Color.White;
                        }
                        else
                        {
                            activarFactura = true;
                            btnFactura.BackColor = Color.CadetBlue;
                        }
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Ocurrio un error al buscar ultima factura, contacte al programador.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (activarTicket)
            {
                activarTicket = false;
                btnTicket.BackColor = Color.White;
            }
            else
            {
                activarTicket = true;
                btnTicket.BackColor = Color.CadetBlue;
            }
        }

        private void cbPropina_Click_1(object sender, EventArgs e)
        {
            //Autorizar
            bool autorizar = bool.Parse(oConfiguracion.AutorizarDescProp);
            if (autorizar)
            {
                //Codigo para mostrar la interfaz y autorizar
                bool exito = false;

                if (exito)
                {
                    CalcularTodo();
                }
                else
                {
                    if (cbPropina.Checked)
                    {
                        cbPropina.Checked = false;
                    }
                    else
                    {
                        cbPropina.Checked = true;
                    }
                }
                MessageBox.Show("Necesita autorizar");
            }
            else
            {
                CalcularTodo();
            }
        }

        private bool ValidarExistenciaTicket()
        {
            if (lblTicket.Text.Equals(""))
            {
                MessageBox.Show("Debe seleccionar un pedido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            if (ValidarExistenciaTicket()) return;
            //Programar pago en efectivo
            if (!txtPagoRegistrar.Text.Equals(""))
            {
                pedido.Saldo = Double.Parse(lblCambio.Tag.ToString())*(-1);
                ProcesarPago();
            }
            else
            {
                MessageBox.Show("Debe ingresar el pago a registrar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            if (ValidarExistenciaTicket()) return;
            if (!txtPagoRegistrar.Text.Equals(""))
            {
                pedido.Saldo = Double.Parse(lblCambio.Tag.ToString()) * (-1);
                pedido.TotalPago = Double.Parse(txtTotalPagar.Text);
                ProcesarPago();
            }
            else
            {
                MessageBox.Show("Debe ingresar el pago a registrar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMuchos_Click(object sender, EventArgs e)
        {
            if (ValidarExistenciaTicket()) return;
            //Programar pago entre muchos
            //Mostrar interfaz para dividir la cuenta
            DividirPago f = new DividirPago();
            f.Tag = txtTotalPagar.Text;//Mandamos el total a pagar en el tag
            f.ShowDialog();
            
        }

        private void btnExacto_Click(object sender, EventArgs e)
        {
            if (ValidarExistenciaTicket()) return;
            //Programar pago exacto
            pedido.Saldo = 0.00;
            pedido.TotalPago = Double.Parse(txtTotalPagar.Text);
            RegistrarPago();
            ActualizarCaja(true);
        }

        private void btnCortesia_Click(object sender, EventArgs e)
        {
            if (ValidarExistenciaTicket()) return;
            //Programar pago cortesia
            pedido.Saldo = 0.00;
            pedido.TotalPago = Double.Parse(txtTotalPagar.Text);
            RegistrarPago();
        }

        private void ProcesarPago()
        {
            pedido.TotalPago = Double.Parse(txtPagoRegistrar.Text);
            if (Double.Parse(txtPagoRegistrar.Text) < Double.Parse(txtTotalPagar.Text))
            {
                //Enviar mensaje que 
                if (MessageBox.Show("El total a registrar es menor al total a pagar, si continua se creara una cuenta por cobrar ¿Esta seguro que desea continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Se creara una cuenta por cobrar
                    RegistrarPago();
                }
                else
                {
                    return;
                }
            }
            else
            {
                RegistrarPago();
            }

            ActualizarCaja(false);

        }

        private void ActualizarCaja(Boolean exacto)
        {
            //Sucedera algo en caja programar aqui
            DataTable caja = DataManager.DBConsultas.CajaAbierta();
            if (caja.Rows.Count > 0)
            {
                Mantenimiento.CLS.Caja cajaActualizar = new Mantenimiento.CLS.Caja();
                foreach (DataRow item in caja.Rows)
                {
                    cajaActualizar.IdCaja = Int32.Parse(item["idCaja"].ToString());
                    cajaActualizar.IdCajero = Int32.Parse(item["idCajero"].ToString());
                    cajaActualizar.Estado = true;
                    cajaActualizar.SaldoInicial = Double.Parse(item["saldoInicial"].ToString());
                    if (exacto)
                    {
                        cajaActualizar.Saldo = Double.Parse(item["saldo"].ToString()) + Double.Parse(txtTotalPagar.Text);
                        cajaActualizar.Efectivo = Double.Parse(item["efectivo"].ToString()) + Double.Parse(txtTotalPagar.Text);
                    }
                    else
                    {
                        cajaActualizar.Saldo = Double.Parse(item["saldo"].ToString()) + Double.Parse(txtPagoRegistrar.Text);
                        cajaActualizar.Efectivo = Double.Parse(item["efectivo"].ToString()) + Double.Parse(txtPagoRegistrar.Text);
                    }
                }
                if (!cajaActualizar.Actualizar())
                {
                    MessageBox.Show("Ocurrio un error al actualizar caja, contacte al programador.");
                }
            }
            else
            {
                MessageBox.Show("No se encontro caja abierta, el pago no se registro en caja.");
            }
        }

        private void RegistrarPago()
        {
            int siguiente = 0, idTiraje = 0;
            pedido.IdPedido = Int32.Parse(lblTicket.Text);
            pedido.Total = Double.Parse(lblSaldo.Tag.ToString());
            pedido.Descuento = Double.Parse(lblDescuento.Tag.ToString());
            pedido.Propina = Double.Parse(lblPropina.Tag.ToString());
            pedido.Cancelado = true;

            if (activarFactura)
            {
                //Lleva factura
                //Obtener la ultima factura y crear una nueva
                if (actualFactura.Rows.Count>0)
                {
                    foreach (DataRow item in actualFactura.Rows)
                    {
                        pedido.NFactura  = (Int32.Parse(item["actual"].ToString())+1).ToString();
                        siguiente = (Int32.Parse(item["actual"].ToString()) + 1);
                        idTiraje = Int32.Parse(item["idTiraje"].ToString());
                    }

                    Mantenimiento.CLS.Tiraje_Factura tiraje = new Mantenimiento.CLS.Tiraje_Factura();
                    if (siguiente != 0)
                    {
                        tiraje.IdTiraje = idTiraje;
                        tiraje.Actual = siguiente;
                        if (!tiraje.ActualizarTirajeActual()){
                            MessageBox.Show("Fallo al actualizar el tiraje actual");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Ocurrio un error al buscar ultima factura, contacte al programador.");
                }
                MessageBox.Show("Imprimir la factura");

            }
            if (activarTicket)
            {
                //Lleva ticket
                MessageBox.Show("Imprimir el ticket");
            }

            if (!pedido.ActualizarPedidoPagado())
            {
                MessageBox.Show("Ocurrio un error al guardar pago, contacte al programador.");
            }
            else
            {
                //Actualizar estado de la mesa
                Mantenimiento.CLS.Mesa mesa = new Mantenimiento.CLS.Mesa();
                mesa.IdMesa = Int32.Parse(lblMesa.Tag.ToString());
                mesa.Disponible = true;
                if (mesa.ActualizarEstado())
                {
                    //MessageBox.Show("SE ACTUALIZO CON EXITO");
                    
                }
                else
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR");
                }
                //IRa tpv
                comandaGestion.tpv = true;
                comandaGestion.Close();
                Close();
            }
        }

        public void CargarProductosPorMesayIdPedido(string idMesa, int idPedido)
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.ProductosEnMesaConIdPedido(idMesa, idPedido);
                dgvDatos.DataSource = datos;
                dgvDatos.AutoGenerateColumns = false;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
