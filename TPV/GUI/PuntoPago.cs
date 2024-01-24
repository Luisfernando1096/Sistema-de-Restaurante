using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Humanizer;
using System.Collections.Generic;

namespace TPV.GUI
{
    public partial class PuntoPago : Form
    {
        ComandaGestion comandaGestion;
        BindingSource datos = new BindingSource();
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;
        ConfiguracionManager.CLS.Ticket oTicket = ConfiguracionManager.CLS.Ticket.Instancia;
        DataTable actualFactura;
        private Mantenimiento.CLS.Pedido pedido = new Mantenimiento.CLS.Pedido();
        private bool hasEnteredNumber = false; // Variable para controlar si se ha ingresado un número
        private bool escritoUnPunto = false; //Variable para verificar si se ha ingresado un punto
        private bool activarFactura = false;
        private bool activarTicket = true;
        private DataTable datosEnMesa;
        public int idPedidoSiguiente;
        private bool pagoEfectivo;
        private bool pagoTarjeta;
        private bool pagoCortesia;
        private bool pagoExacto;

        public PuntoPago(ComandaGestion comandaGestion)
        {
            InitializeComponent();
            this.comandaGestion = comandaGestion;
            btnTicket.BackColor = Color.CadetBlue;
            lblFecha.Text = comandaGestion.lblFecha.Text;
        }

        public void CargarProductosPorMesa(String id)
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.ProductosEnMesaConIdPedido(id, 0);
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
            actualFactura = DataManager.DBConsultas.ObtenerTirajeActual(Boolean.Parse(oConfiguracion.IncluirImpuesto));
            tFecha.Start();
            WindowState = FormWindowState.Maximized;
            // Creamos un Panel para envolver el FlowLayoutPanel
            Panel panelWrapper = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            // Agregamos el FlowLayoutPanel al Panel
            panelWrapper.Controls.Add(flpAcciones);

            // Agregamos el Panel al formulario
            Controls.Add(panelWrapper);
            if (dgvDatos.Rows.Count > 0)
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
            if (idPedidoSiguiente > 0 || !lblTicket.Text.Equals(""))
            {
                if (comandaGestion.datos.DataSource != null && comandaGestion.borrarData)
                {
                    comandaGestion.datos.DataSource = null;
                }
                else
                {
                    comandaGestion.CargarProductosPorMesayIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
                    comandaGestion.lblTicket.Text = lblTicket.Text;
                    comandaGestion.lblMesa.Text = lblMesa.Text;
                    comandaGestion.lblMesa.Tag = lblMesa.Tag.ToString();
                    comandaGestion.ActualizarLabelsRetroceder(Int32.Parse(lblTicket.Text), false);
                }

            }
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
                DataTable pedido = DataManager.DBConsultas.PedidoPorId(Int32.Parse(lblTicket.Text.ToString()), false);
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
                totalPagar = totalPagar + propina + iva;
            }

            if (cbDescuento.Checked)
            {
                //Con descuento
                totalPagar = totalPagar - descuento + iva;
            }
            else
            {
                //Sin descuento
                descuento = 0;
            }
            double cambio = Math.Round(CalcularCambio(totalPagar), 2);
            ActualizarCampos(propina, descuento, totalPagar, iva, cambio);
        }

        private double CalcularIva()
        {
            double iva;
            bool incluirIva = bool.Parse(oConfiguracion.IncluirImpuesto);
            if (incluirIva)
            {
                iva = Double.Parse(lblSaldo.Tag.ToString()) * (Double.Parse(oConfiguracion.Iva) / 100);

            }
            else
            {
                iva = 0;
            }

            return iva;
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
                if (e.KeyChar != '.' || !hasEnteredNumber)
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
                    if (Int32.Parse(item["actual"].ToString()) <= Int32.Parse(item["fin"].ToString()))
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
                AutorizarCambio f = new AutorizarCambio();
                f.ShowDialog();
                int pin = Int32.Parse(f.txtPin.Text);
                if (pin != 0)
                {
                    DataTable filas = DataManager.DBConsultas.IniciarSesion(pin.ToString());
                    if (filas.Rows.Count > 0)
                    {
                        if (Int32.Parse(filas.Rows[0]["idRol"].ToString()) == 1)
                        {
                            exito = true;
                        }
                        else
                        {
                            MessageBox.Show("No tiene permiso para esta accion!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Pin incorrecto, intentelo nuevamente!");
                    }

                }

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
            pagoEfectivo = true;
            pagoTarjeta = false;
            pagoCortesia = false;
            pagoExacto = false;
            if (ValidarExistenciaTicket()) return;
            //Programar pago en efectivo
            if (!txtPagoRegistrar.Text.Equals(""))
            {
                pedido.Saldo = Double.Parse(lblCambio.Tag.ToString()) * (-1);
                pedido.IdCuenta = 1;
                ProcesarPago();
            }
            else
            {
                MessageBox.Show("Debe ingresar el pago a registrar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            pagoEfectivo = false;
            pagoTarjeta = true;
            pagoCortesia = false;
            pagoExacto = false; if (ValidarExistenciaTicket()) return;
            if (!txtPagoRegistrar.Text.Equals(""))
            {
                pedido.Saldo = Double.Parse(lblCambio.Tag.ToString()) * (-1);
                pedido.TotalPago = Double.Parse(txtTotalPagar.Text);
                pedido.IdCuenta = 2;
                ProcesarPago();
                //Registrar pago en cuenta
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
            DividirPago f = new DividirPago
            {
                Tag = txtTotalPagar.Text//Mandamos el total a pagar en el tag
            };
            f.ShowDialog();

        }

        private void btnExacto_Click(object sender, EventArgs e)
        {
            txtPagoRegistrar.Text = txtTotalPagar.Text;
            pagoEfectivo = false;
            pagoTarjeta = false;
            pagoExacto = true;
            pagoCortesia = false;

            if (ValidarExistenciaTicket()) return;
            //Programar pago exacto
            pedido.Saldo = 0.00;
            pedido.TotalPago = Double.Parse(txtTotalPagar.Text);
            pedido.IdCuenta = 1;
            RegistrarPago();
            ActualizarCaja(true);
        }

        private void btnCortesia_Click(object sender, EventArgs e)
        {
            pagoEfectivo = false;
            pagoTarjeta = false;
            pagoExacto = false;
            pagoCortesia = true;
            if (ValidarExistenciaTicket()) return;
            //Programar pago cortesia
            pedido.Saldo = 0.00;
            pedido.TotalPago = Double.Parse(txtTotalPagar.Text);
            pedido.IdCuenta = 1;
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
            List<String> lstPago = new List<string>();
            String fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int siguiente = 0, idTiraje = 0;
            String serie = string.Empty;
            pedido.IdPedido = Int32.Parse(lblTicket.Text);
            pedido.Total = Double.Parse(lblSaldo.Tag.ToString());
            pedido.Descuento = Double.Parse(lblDescuento.Tag.ToString());
            pedido.Propina = Double.Parse(lblPropina.Tag.ToString());
            pedido.Iva = Double.Parse(lblIva.Tag.ToString());
            pedido.Cancelado = true;
            pedido.Fecha = fecha;

            if (activarFactura)
            {
                //Lleva factura
                Boolean generar = false;
                //Obtener la ultima factura y crear una nueva
                if (actualFactura.Rows.Count > 0)
                {
                    
                    foreach (DataRow item in actualFactura.Rows)
                    {
                        if ((Int32.Parse(item["actual"].ToString()) + 1) <= (Int32.Parse(item["fin"].ToString())))
                        {
                            pedido.NFactura = (Int32.Parse(item["actual"].ToString()) + 1).ToString();
                            pedido.IdTiraje = Int32.Parse(item["idTiraje"].ToString());
                            siguiente = (Int32.Parse(item["actual"].ToString()) + 1);
                            idTiraje = Int32.Parse(item["idTiraje"].ToString());
                            serie = item["serie"].ToString();
                            generar = true;
                        }
                    }

                    if (generar)
                    {
                        Mantenimiento.CLS.Tiraje_Factura tiraje = new Mantenimiento.CLS.Tiraje_Factura();
                        if (siguiente != 0)
                        {
                            tiraje.IdTiraje = idTiraje;
                            tiraje.Actual = siguiente;
                            lstPago.Add(tiraje.ActualizarTirajeActual());
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se genero la factura, se llego al limite del tiraje activado, active uno nuevo para generar facturas.");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al buscar ultima factura, contacte al programador.");
                }

                if (pagoEfectivo && generar)
                {
                    Reportes.REP.RepFactura oReporte = new Reportes.REP.RepFactura();
                    GenerarFactura(oReporte, serie, siguiente, "EFECTIVO");// se envia el nFactura y la serie que corresponde
                }
                else if (pagoTarjeta && generar)
                {
                    Reportes.REP.RepFactura oReporte = new Reportes.REP.RepFactura();
                    GenerarFactura(oReporte, serie, siguiente, "TARJETA");// se envia el nFactura y la serie que corresponde
                }
                else if (pagoCortesia && generar)
                {
                    Reportes.REP.RepFactura oReporte = new Reportes.REP.RepFactura();
                    GenerarFactura(oReporte, serie, siguiente, "CORTESIA");// se envia el nFactura y la serie que corresponde
                }
                else if (pagoExacto )
                {
                    Reportes.REP.RepFactura oReporte = new Reportes.REP.RepFactura();
                    GenerarFactura(oReporte, serie, siguiente, "EXACTO");// se envia el nFactura y la serie que corresponde
                }
            }
            if (activarTicket)
            {
                //Lleva ticket
                if (pagoEfectivo)
                {
                    if (dgvDatos.Rows.Count > 0)
                    {
                        // Cargar los datos en un DataTable
                        Reportes.REP.RepPagoEfectivo oReporte = new Reportes.REP.RepPagoEfectivo();
                        GenerarTicket(oReporte);

                    }
                    else
                    {
                        MessageBox.Show("No hay datos que mostrar en el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else if (pagoTarjeta)
                {
                    //MessageBox.Show("Imprimir el ticket Tarjeta");
                    if (dgvDatos.Rows.Count > 0)
                    {
                        // Cargar los datos en un DataTable
                        Reportes.REP.RepPagoTarjeta oReporte = new Reportes.REP.RepPagoTarjeta();
                        GenerarTicket(oReporte);

                    }
                    else
                    {
                        MessageBox.Show("No hay datos que mostrar en el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }
                else if (pagoCortesia)
                {
                    //MessageBox.Show("Imprimir el ticket Tarjeta");
                    if (dgvDatos.Rows.Count > 0)
                    {
                        // Cargar los datos en un DataTable
                        Reportes.REP.RepPagoCortesia oReporte = new Reportes.REP.RepPagoCortesia();
                        GenerarTicket(oReporte);

                    }
                    else
                    {
                        MessageBox.Show("No hay datos que mostrar en el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }
                else if (pagoExacto)
                {
                    //MessageBox.Show("Imprimir el ticket Exacto");
                    if (dgvDatos.Rows.Count > 0)
                    {
                        // Cargar los datos en un DataTable
                        Reportes.REP.RepPagoExacto oReporte = new Reportes.REP.RepPagoExacto();
                        GenerarTicket(oReporte);

                    }
                    else
                    {
                        MessageBox.Show("No hay datos que mostrar en el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            lstPago.Add(pedido.ActualizarPedidoPagado());

            if (datosEnMesa.Rows.Count == 1)
            {
                //Actualizar estado de la mesa
                Mantenimiento.CLS.Mesa mesa = new Mantenimiento.CLS.Mesa
                {
                    IdMesa = Int32.Parse(lblMesa.Tag.ToString()),
                    Disponible = true
                };
                lstPago.Add(mesa.ActualizarEstado());
                
            }

            //Proceso para agregar el efectivo cancelado
            DataTable cuenta = null;
            Mantenimiento.CLS.Cuenta oCuenta = new Mantenimiento.CLS.Cuenta();
            if (pagoTarjeta)
            {
                cuenta = DataManager.DBConsultas.ObtenerCuentaPorId("2");
            }
            else if (!pagoCortesia)
            {
                cuenta = DataManager.DBConsultas.ObtenerCuentaPorId("1");
            }

            if (cuenta != null)
            {
                int idCuenta = Int32.Parse(cuenta.Rows[0]["idCuenta"].ToString());
                String nombreCuenta = cuenta.Rows[0]["nombreCuenta"].ToString();
                String numero = cuenta.Rows[0]["numero"].ToString();
                Double saldo = Double.Parse(cuenta.Rows[0]["saldo"].ToString());
                oCuenta.IdCuenta = idCuenta;
                oCuenta.NombreCuenta = nombreCuenta;
                oCuenta.Numero = numero;
                oCuenta.Saldo = saldo + Double.Parse(txtPagoRegistrar.Text.ToString());

                lstPago.Add(oCuenta.Actualizar());
            }

            DataManager.DBOperacion transaccion = new DataManager.DBOperacion();
            if (transaccion.EjecutarTransaccion(lstPago) > 0)
            {
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

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            PedidosSeparados pedidosSeparados = new PedidosSeparados
            {
                idMesa = lblMesa.Tag.ToString(),
                pedidosEnMesa = datosEnMesa
            };
            pedidosSeparados.ShowDialog();
            idPedidoSiguiente = pedidosSeparados.idPedido;

            if (idPedidoSiguiente > 0)
            {
                CargarProductosPorMesayIdPedido(pedidosSeparados.idMesa, idPedidoSiguiente);
                lblTicket.Text = idPedidoSiguiente.ToString();//Accedemos a la primera posicion de la tabla

                DataTable pedido = DataManager.DBConsultas.PedidoPorId(Int32.Parse(lblTicket.Text), false);
                //Agregando datos mesero y cliente si los hay
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
                lblSaldo.Text = "$" + CalcularTotal().ToString("0.00");
                lblSaldo.Tag = Math.Round(CalcularTotal(), 2);
                CalcularTodo();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                // Cargar los datos en un DataTable

                Reportes.REP.RepImprimirPuntoPago oReporte = new Reportes.REP.RepImprimirPuntoPago();
                GenerarTicket(oReporte);

            }
            else
            {
                MessageBox.Show("No hay datos que mostrar en el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void GenerarFactura(ReportClass oReporte, string serie, int nFactura,string tipoPago)
        {
            DataTable datos = DataManager.DBConsultas.ProductosEnMesaConIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
            oReporte.SetDataSource(datos);
            oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
            oReporte.SetParameterValue("Direccion", oEmpresa.Direccion.ToUpper());
            oReporte.SetParameterValue("Telefono", oEmpresa.Telefono);
            oReporte.SetParameterValue("Subtotal", lblSaldo.Text.ToString());
            oReporte.SetParameterValue("TipoPago", tipoPago);
            oReporte.SetParameterValue("Serie", serie);
            oReporte.SetParameterValue("nFactura", nFactura);
            oReporte.SetParameterValue("Propina", lblPropina.Text.ToString());
            oReporte.SetParameterValue("Total", "$" + Double.Parse(txtTotalPagar.Text).ToString("0.00"));
            string totalStr = txtTotalPagar.Text;

            // Convierte la cadena a un número decimal
            if (decimal.TryParse(totalStr, out decimal total))
            {
                // Dividir la parte entera y la parte decimal
                int parteEntera = (int)Math.Truncate(total);
                int parteDecimal = (int)((total - parteEntera) * 100);

                // Convierte cada parte a palabras utilizando Humanizer
                string parteEnteraEnLetras = parteEntera.ToWords().ToUpper();
                string parteDecimalEnLetras = parteDecimal.ToWords().ToUpper();

                // Asigna el valor en letras al parámetro del reporte
                oReporte.SetParameterValue("CantidadTexto", $"{parteEnteraEnLetras} CON {parteDecimalEnLetras} CENTAVOS");
            }
            else
            {
                Console.WriteLine("La entrada no es un número válido.");
            }

            if (oReporte != null)
            {
                try
                {
                    // Imprimir el informe en la impresora seleccionada
                    PrinterSettings settings = new PrinterSettings
                    {
                        PrinterName = oConfiguracion.PrinterComanda
                    };

                    oReporte.PrintOptions.PrinterName = settings.PrinterName;
                    oReporte.PrintToPrinter(1, false, 0, 0);

                    // Muestra un mensaje de éxito en el hilo de la interfaz de usuario
                    /*this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Finalizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });*/
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones: muestra un mensaje de error en caso de problemas
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            }
        }

        private void GenerarTicket(ReportClass oReporte)
        {
            DataTable datos = DataManager.DBConsultas.ProductosEnMesaConIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
            oReporte.SetDataSource(datos);
            oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
            oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
            oReporte.SetParameterValue("Telefono", oEmpresa.Telefono);
            oReporte.SetParameterValue("Total", lblSaldo.Text.ToString());
            oReporte.SetParameterValue("Descuento", lblDescuento.Text.ToString());
            oReporte.SetParameterValue("Propina", lblPropina.Text.ToString());
            oReporte.SetParameterValue("Iva", lblIva.Text.ToString());
            oReporte.SetParameterValue("TotalPagar", "$" + Double.Parse(txtTotalPagar.Text).ToString("0.00"));
            if (Boolean.Parse(oTicket.ShowSaludo))
            {
                oReporte.SetParameterValue("Footer3", oTicket.Footer3);
            }
            else
            {
                oReporte.SetParameterValue("Footer3", "");
            }
            oReporte.SetParameterValue("Pago", "$" + Double.Parse(txtPagoRegistrar.Text).ToString("0.00"));
            oReporte.SetParameterValue("Cambio", lblCambio.Text);
            oReporte.SetParameterValue("TipoPago", "Efectivo");

            
            if (oReporte != null)
            {
                try
                {
                    // Imprimir el informe en la impresora seleccionada
                    PrinterSettings settings = new PrinterSettings
                    {
                        PrinterName = oConfiguracion.PrinterComanda
                    };

                    oReporte.PrintOptions.PrinterName = settings.PrinterName;

                    if (Boolean.Parse(oConfiguracion.ImprimirDosTicketsPago))
                    {
                        oReporte.PrintToPrinter(1, false, 0, 0);
                        oReporte.PrintToPrinter(1, false, 0, 0);
                    }
                    else
                    {
                        oReporte.PrintToPrinter(1, false, 0, 0);
                    }
                    

                    // Muestra un mensaje de éxito en el hilo de la interfaz de usuario
                    /*this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Finalizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });*/
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones: muestra un mensaje de error en caso de problemas
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            }
        }

        private void tFecha_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString();
        }

        private void PuntoPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            tFecha.Stop();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ClientesGestion cg = new ClientesGestion
            {
                seleccionCliente = true
            };
            if (lblTicket.Text.ToString().Equals(""))
            {
                cg.idPedido = 0;
            }
            else
            {
                cg.idPedido = Int32.Parse(lblTicket.Text.ToString());
            }

            cg.ShowDialog();
            if (!lblTicket.Text.ToString().Equals(""))
            {
                ActualizarLabels(Int32.Parse(lblTicket.Text.ToString()));
            }
        }

        private void ActualizarLabels(int id)
        {
            //Obtengo el pedido que estaba abierto en el punto de pago.
            DataTable pedido = DataManager.DBConsultas.PedidoPorId(id, false);
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

        private void cbDescuento_Click(object sender, EventArgs e)
        {
            //Autorizar
            bool autorizar = bool.Parse(oConfiguracion.AutorizarDescProp);
            if (autorizar)
            {
                //Codigo para mostrar la interfaz y autorizar
                bool exito = false;
                AutorizarCambio f = new AutorizarCambio();
                f.ShowDialog();
                int pin = Int32.Parse(f.txtPin.Text);
                if (pin != 0)
                {
                    DataTable filas = DataManager.DBConsultas.IniciarSesion(pin.ToString());
                    if (filas.Rows.Count > 0)
                    {
                        if (Int32.Parse(filas.Rows[0]["idRol"].ToString()) == 1)
                        {
                            exito = true;
                        }
                        else
                        {
                            MessageBox.Show("No tiene permiso para esta accion!");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Pin incorrecto, intentelo nuevamente!");
                    }
                    
                }

                if (exito)
                {
                    if (cbDescuento.Checked)
                    {
                        lblPorcentaje.Visible = true;
                        txtPorcentaje.Visible = true;
                        txtPorcentaje.Text = "";
                    }
                    else
                    {
                        lblPorcentaje.Visible = false;
                        txtPorcentaje.Visible = false;
                        txtPorcentaje.Text = "";
                    }
                    CalcularTodo();
                }
                else
                {
                    if (cbDescuento.Checked)
                    {
                        cbDescuento.Checked = false;
                        lblPorcentaje.Visible = false;
                        txtPorcentaje.Visible = false;
                        txtPorcentaje.Text = "";
                    }
                    else
                    {
                        cbDescuento.Checked = true;
                        lblPorcentaje.Visible = true;
                        txtPorcentaje.Visible = true;
                        txtPorcentaje.Text = "";
                    }
                    CalcularTodo();
                }
            }
            else
            {
                if (cbDescuento.Checked)
                {
                    lblPorcentaje.Visible = true;
                    txtPorcentaje.Visible = true;
                    txtPorcentaje.Text = "";
                }
                else
                {
                    lblPorcentaje.Visible = false;
                    txtPorcentaje.Visible = false;
                    txtPorcentaje.Text = "";
                }
                CalcularTodo();
            }
        }
    }
}
