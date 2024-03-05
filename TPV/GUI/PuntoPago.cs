using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Humanizer;
using System.Collections.Generic;
using FacturacionElectronica.CLS;
using Mantenimiento.CLS;

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
        private bool pagoBtc;
        private String fechaPago = "";
        private String referencia;

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
                else
                {
                    btnCuentas.Visible = false;
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
            totalPagar = totalPagar - SumaMontos();
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
            String cadena = txtPagoRegistrar.Text;
            int longitud = cadena.Length;
            int seEncuentra = 0;

            for (int i = 0; i < longitud; i++)
            {
                if (cadena[i] == '.')
                {
                    seEncuentra++;
                }
            }

            if (seEncuentra == 0)
            {
                escritoUnPunto = false;
            }
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
                    if (Int32.Parse(item["actual"].ToString()) >= Int32.Parse(item["fin"].ToString()))
                    {
                        MessageBox.Show("Se ha alcanzado el maximo de facturas, solicite al administrador un nuevo tiraje.");
                    }
                    else
                    {
                        if (activarFactura)
                        {
                            activarFactura = false;
                            btnFactura.BackColor = Color.White;
                            activarTicket = true;
                            btnTicket.BackColor = Color.CadetBlue;
                        }
                        else
                        {
                            activarFactura = true;
                            btnFactura.BackColor = Color.CadetBlue;
                            activarTicket = false;
                            btnTicket.BackColor = Color.White;
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
                activarFactura = true;
                btnFactura.BackColor = Color.CadetBlue;
            }
            else
            {
                activarTicket = true;
                btnTicket.BackColor = Color.CadetBlue;
                activarFactura = false;
                btnFactura.BackColor = Color.White;
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
            pagoBtc = false;
            pagoTarjeta = false;
            pagoCortesia = false;
            pagoExacto = false;
            if (ValidarExistenciaTicket()) return;
            //Programar pago en efectivo
            if (!txtPagoRegistrar.Text.Equals("") && !txtPagoRegistrar.Text.Equals("0"))
            {
                pedido.Saldo = Double.Parse(lblCambio.Tag.ToString()) * (-1);
                //Registrar pago en cuenta
                AumentarCuenta();

                //Aqui insertar en la tabla pagos combinados
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
            pagoBtc = false;
            pagoTarjeta = true;
            pagoCortesia = false;
            pagoExacto = false;
            if (ValidarExistenciaTicket()) return;
            if (!txtPagoRegistrar.Text.Equals("") && !txtPagoRegistrar.Text.Equals("0"))
            {
                referencia = AgregarReferencia();
                pedido.Saldo = Double.Parse(lblCambio.Tag.ToString()) * (-1);
                
                //Registrar pago en cuenta
                AumentarCuenta();

                //Aqui insertar en la tabla pagos combinados
                ProcesarPago();
                
            }
            else
            {
                MessageBox.Show("Debe ingresar el pago a registrar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private String AgregarReferencia()
        {
            String refe = "";

            Referencia f = new Referencia();
            f.ShowDialog();

            if (!f.txtNReferencia.Text.Equals(""))
            {
                refe = f.txtNReferencia.Text;
            }

            return refe;
        }

        private Double SumaMontos()
        {
            Double resultado = 0;

            if (!lblTicket.Text.Equals(""))
            {
                int id = Int32.Parse(lblTicket.Text);
                DataTable totalPagos = DataManager.DBConsultas.TotalPagos(id);
                if (totalPagos.Rows.Count > 0)
                {
                    resultado = Double.Parse(totalPagos.Rows[0]["sumaMonto"].ToString());
                }

            }
            return resultado;
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
            if (SumaMontos() > 0)
            {
                MessageBox.Show("No se puede hacer el pago exacto porque ya inicio el pago combinado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtPagoRegistrar.Text = txtTotalPagar.Text;
                pagoEfectivo = false;
                pagoTarjeta = false;
                pagoExacto = true;
                pagoCortesia = false;
                pagoBtc = false;

                if (ValidarExistenciaTicket()) return;
                //Programar pago exacto
                pedido.Saldo = 0.00;
                if (SumaMontos() > 0)
                {
                    //Significa que ya habia hecho un pago antes de hacer pago exacto.
                    pedido.TotalPago = Double.Parse(txtTotalPagar.Text) + SumaMontos();
                }
                else
                {
                    pedido.TotalPago = Double.Parse(txtTotalPagar.Text);
                }
                
                //Registrar pago en cuenta
                AumentarCuenta();

                //Aqui insertar en la tabla pagos combinados
                TerminarPago(true);
                
            }
        }

        private void btnCortesia_Click(object sender, EventArgs e)
        {
            if (SumaMontos() > 0)
            {
                MessageBox.Show("No se puede hacer el pago cortesia porque ya inicio el pago combinado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                pagoEfectivo = false;
                pagoTarjeta = false;
                pagoExacto = false;
                pagoCortesia = true;
                if (ValidarExistenciaTicket()) return;
                //Programar pago cortesia
                pedido.Saldo = 0.00;
                pedido.TotalPago = Double.Parse(txtTotalPagar.Text);
                //Aqui insertar en la tabla pagos combinados
                RegistrarPago();
                ActualizarCuentaYMesa(true);
            }
            
        }

        private void ProcesarPago()
        {
            Double totalPago;
            if (SumaMontos() > 1)
            {
                totalPago = Double.Parse(txtPagoRegistrar.Text) + SumaMontos();
            }
            else
            {
                totalPago = Double.Parse(txtPagoRegistrar.Text);
            }
            
            pedido.TotalPago = totalPago;

            if (Double.Parse(txtPagoRegistrar.Text) < Double.Parse(txtTotalPagar.Text))
            {
                //Enviar mensaje que 
                if (MessageBox.Show("¿Desea continuar pagando? Si presiona 'No' se creara una cuenta por cobrar.", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Proceso para pagar combinado
                    HacerPago(Int32.Parse(lblTicket.Text), false);
                    CalcularTodo();
                    txtPagoRegistrar.Text = "0";
                    escritoUnPunto = false;
                }
                else
                {
                    //Se creara una cuenta por cobrar
                    //RegistrarPago();
                    
                }
            } 
            else
            {
                //Culminamos el pago
                TerminarPago(false);
            }

        }

        private void AumentarCuenta()
        {
            //Proceso para agregar el efectivo cancelado
            DataTable cuenta = null;
            Mantenimiento.CLS.Cuenta oCuenta = new Mantenimiento.CLS.Cuenta();
            if (pagoTarjeta)
            {
                cuenta = DataManager.DBConsultas.ObtenerCuentaPorId("2");
            }
            else if (pagoEfectivo || pagoExacto)
            {
                cuenta = DataManager.DBConsultas.ObtenerCuentaPorId("1");
            }
            else if (pagoBtc)
            {
                cuenta = DataManager.DBConsultas.ObtenerCuentaPorId("3");
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

                oCuenta.ActualizarSinTransaccion();
            }
        }

        private void TerminarPago(bool actualizar)
        {
            HacerPago(Int32.Parse(lblTicket.Text), true);
            RegistrarPago();
            ActualizarCuentaYMesa(false);
            ActualizarCaja(actualizar);

            CalcularTodo();
            txtPagoRegistrar.Text = "0";
            escritoUnPunto = false;
        }

        private void ActualizarCuentaYMesa(Boolean cortesia)
        {
            List<String> lstPago = new List<string>();
            if (!cortesia)
            {
                if (datosEnMesa.Rows.Count == 1 && Double.Parse(txtPagoRegistrar.Text) >= Double.Parse(txtTotalPagar.Text))
                {
                    //Actualizar estado de la mesa
                    Mantenimiento.CLS.Mesa mesa = new Mantenimiento.CLS.Mesa
                    {
                        IdMesa = Int32.Parse(lblMesa.Tag.ToString()),
                        Disponible = true
                    };
                    lstPago.Add(mesa.ActualizarEstado());

                }

            }
            else
            {
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
            }

            DataManager.DBOperacion transaccion = new DataManager.DBOperacion();
            if (transaccion.EjecutarTransaccion(lstPago) < 0)
            {
                MessageBox.Show("Ocurrio un error al hacer el pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CalcularTodo();
                txtPagoRegistrar.Text = "0";
                escritoUnPunto = false;
            }
            
        }

        private void HacerPago(int idP, bool terminar)
        {
            int idC;
            if (pagoBtc)
            {
                idC = 3;
            }else if (pagoEfectivo || pagoExacto)
            {
                idC = 1;
            } else if (pagoTarjeta)
            {
                idC = 2;
            }
            else
            {
                MessageBox.Show("Ocurrio un error, contacte al programador.");
                return;
            }
            String fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            PagoCombinado pago = new PagoCombinado();
            pago.Referencia = referencia;
            pago.FechaPago = fecha;
            if (terminar)
            {
                pago.Monto = Double.Parse(txtPagoRegistrar.Text) - Double.Parse(lblCambio.Tag.ToString());
            }
            else
            {
                pago.Monto = Double.Parse(txtPagoRegistrar.Text);
            }
            
            pago.IdPedido = idP;
            pago.IdCuenta = idC;

            pago.Insertar();

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
                        cajaActualizar.Saldo = Double.Parse(item["saldo"].ToString()) + SumaMontos();
                        cajaActualizar.Efectivo = Double.Parse(item["efectivo"].ToString()) + SumaMontos();
                    }
                    else
                    {
                        cajaActualizar.Saldo = Double.Parse(item["saldo"].ToString()) + SumaMontos();
                        cajaActualizar.Efectivo = Double.Parse(item["efectivo"].ToString()) + SumaMontos();
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
            fechaPago = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int siguiente = 0, idTiraje = 0;
            String serie = string.Empty;
            pedido.IdPedido = Int32.Parse(lblTicket.Text);
            pedido.Total = Double.Parse(lblSaldo.Tag.ToString());
            pedido.Descuento = Double.Parse(lblDescuento.Tag.ToString());
            pedido.Propina = Double.Parse(lblPropina.Tag.ToString());
            pedido.Iva = Double.Parse(lblIva.Tag.ToString());
            pedido.Cancelado = true;
            pedido.Fecha = fechaPago;

            if (activarFactura)
            {
                //Total en letras
                Double totalPagar = 0;
                String totalStr;
                DataTable datos2 = DataManager.DBConsultas.PagosRealizados(Int32.Parse(lblTicket.Text));
                if (datos2.Rows.Count > 1)
                {
                    foreach (DataRow item2 in datos2.Rows)
                    {
                        totalPagar += Math.Round(Double.Parse(item2["monto"].ToString()), 2);
                    }
                }
                else
                {
                    totalPagar = Math.Round(Double.Parse(txtTotalPagar.Text), 2);
                }

                totalStr = totalPagar.ToString().Trim();
                String totalLetras = "";
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
                    totalLetras = parteEnteraEnLetras + " CON " + parteDecimalEnLetras + " CENTAVOS";
                }
                else
                {
                    Console.WriteLine("La entrada no es un número válido.");
                }
                //Lleva factura
                //Generar JSON
                //Aqui se guardara el JSON como prueba

                SaveFileDialog direccion = new SaveFileDialog();
                direccion.Filter = "Archivo SQL (*.json)|*.json";
                direccion.InitialDirectory = @"C:\Users\Fuentes\Desktop\REPORTES";
                direccion.Title = "Selección de ruta";
                string ruta = "";
                if (direccion.ShowDialog() == DialogResult.OK)
                {
                    ruta = direccion.FileName;
                }

                string path = ruta;

                GenerarDTE generarDTE = new GenerarDTE(ListaPagos(), ListaDetalles());
                generarDTE.TotalLetras = totalLetras;

                dteJson dte = generarDTE.GenerarFactura();

                generarDTE.SerializarFactura(dte, path);
                //Termina generacion de JSON

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
                        Tiraje_Factura tiraje = new Tiraje_Factura();
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

                if (pagoTarjeta && generar)
                {
                    if (ObtenerPagosAnteriores() > 1)
                    {
                        //Facturar con muchos pagos
                        ElegirFactura(serie, siguiente);
                    }
                    else
                    {
                        //Facturar con un pago
                        if (Boolean.Parse(oConfiguracion.FacturaElectronica))
                        {
                            Reportes.REP.RepFacturaElectronica oReporte = new Reportes.REP.RepFacturaElectronica();
                            GenerarFactura(oReporte, serie, siguiente, "TARJETA", false);// se envia el nFactura y la serie que corresponde
                        }
                        else
                        {
                            Reportes.REP.RepFactura oReporte = new Reportes.REP.RepFactura();
                            GenerarFactura(oReporte, serie, siguiente, "TARJETA", false);// se envia el nFactura y la serie que corresponde
                        }

                        //Generar JSON

                    }
                    
                }
                else if (pagoBtc && generar)
                {
                    if (ObtenerPagosAnteriores() > 1)
                    {
                        ElegirFactura(serie, siguiente);
                    }
                    else
                    {
                        if (Boolean.Parse(oConfiguracion.FacturaElectronica))
                        {
                            Reportes.REP.RepFacturaElectronica oReporte = new Reportes.REP.RepFacturaElectronica();
                            GenerarFactura(oReporte, serie, siguiente, "BITCOIN", false);// se envia el nFactura y la serie que corresponde
                        }
                        else
                        {
                            Reportes.REP.RepFactura oReporte = new Reportes.REP.RepFactura();
                            GenerarFactura(oReporte, serie, siguiente, "BITCOIN", false);// se envia el nFactura y la serie que corresponde
                        }
                    }
                }
                else if (generar && (pagoEfectivo || pagoExacto))
                {
                    if (ObtenerPagosAnteriores() > 1)
                    {
                        ElegirFactura(serie, siguiente);
                    }
                    else
                    {
                        if (Boolean.Parse(oConfiguracion.FacturaElectronica))
                        {
                            Reportes.REP.RepFacturaElectronica oReporte = new Reportes.REP.RepFacturaElectronica();
                            GenerarFactura(oReporte, serie, siguiente, "EFECTIVO", false);// se envia el nFactura y la serie que corresponde
                        }
                        else
                        {
                            Reportes.REP.RepFactura oReporte = new Reportes.REP.RepFactura();
                            GenerarFactura(oReporte, serie, siguiente, "EFECTIVO", false);// se envia el nFactura y la serie que corresponde
                        }
                    }
                }
            }else {
                //Lleva ticket
                if (pagoEfectivo)
                {
                    if (dgvDatos.Rows.Count > 0)
                    {
                        if (ObtenerPagosAnteriores() > 1)
                        {
                            Reportes.REP.RepPagoCombinado oReporte = new Reportes.REP.RepPagoCombinado();
                            GenerarTicket(oReporte, true);
                        }
                        else
                        {
                            // Cargar los datos en un DataTable
                            Reportes.REP.RepPagoEfectivo oReporte = new Reportes.REP.RepPagoEfectivo();
                            GenerarTicket(oReporte, false);
                        }

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
                        if (ObtenerPagosAnteriores() > 1)
                        {
                            Reportes.REP.RepPagoCombinado oReporte = new Reportes.REP.RepPagoCombinado();
                            GenerarTicket(oReporte, true);
                        }
                        else
                        {
                            // Cargar los datos en un DataTable
                            Reportes.REP.RepPagoTarjeta oReporte = new Reportes.REP.RepPagoTarjeta();
                            GenerarTicket(oReporte, false);
                        }

                    }
                    else
                    {
                        MessageBox.Show("No hay datos que mostrar en el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }
                else if (pagoBtc)
                {
                    //MessageBox.Show("Imprimir el ticket Tarjeta");
                    if (dgvDatos.Rows.Count > 0)
                    {
                        if (ObtenerPagosAnteriores() > 1)
                        {
                            Reportes.REP.RepPagoCombinado oReporte = new Reportes.REP.RepPagoCombinado();
                            GenerarTicket(oReporte, true);
                        }
                        else
                        {
                            // Cargar los datos en un DataTable
                            Reportes.REP.RepPagoBtc oReporte = new Reportes.REP.RepPagoBtc();
                            GenerarTicket(oReporte, false);
                        }

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
                        GenerarTicket(oReporte, false);

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
                        GenerarTicket(oReporte, false);

                    }
                    else
                    {
                        MessageBox.Show("No hay datos que mostrar en el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            lstPago.Add(pedido.ActualizarPedidoPagado());

            DataManager.DBOperacion transaccion = new DataManager.DBOperacion();
            if (transaccion.EjecutarTransaccion(lstPago) > 0)
            {
                //IRa tpv
                comandaGestion.tpv = true;
                comandaGestion.Close();
                Close();
            }
            
        }

        private List<PedidoDetalle> ListaDetalles()
        {
            DataTable detalles = DataManager.DBConsultas.ProductosEnMesaConIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
            List<PedidoDetalle> lst = new List<PedidoDetalle>();

            foreach (DataRow item in detalles.Rows)
            {
                PedidoDetalle pd = new PedidoDetalle();
                pd.Nombre = item["nombre"].ToString();
                pd.Cantidad = Int32.Parse(item["cantidad"].ToString());
                pd.Precio = Double.Parse(item["precio"].ToString());
                pd.SubTotal = Double.Parse(item["subTotal"].ToString());

                lst.Add(pd);
            }

            return lst;
        }

        private List<PagoCombinado> ListaPagos()
        {
            DataTable totalPagos = DataManager.DBConsultas.PagosRealizados(Int32.Parse(lblTicket.Text));

            List<PagoCombinado> lst = new List<PagoCombinado>();

            foreach (DataRow item in totalPagos.Rows)
            {
                PagoCombinado pc = new PagoCombinado();
                if (item["formaPago"].Equals("EFECTIVO"))
                {
                    pc.IdCuenta = 1;
                    pc.Monto = Double.Parse(item["monto"].ToString());
                    pc.Referencia = item["referencia"].ToString();
                }
                else if (item["formaPago"].Equals("TARJETA"))
                {
                    pc.IdCuenta = 2;
                    pc.Monto = Double.Parse(item["monto"].ToString());
                    pc.Referencia = item["referencia"].ToString();
                }
                else if (item["formaPago"].Equals("BITCOIN"))
                {
                    pc.IdCuenta = 3;
                    pc.Monto = Double.Parse(item["monto"].ToString());
                    pc.Referencia = item["referencia"].ToString();
                }
                lst.Add(pc);
                
            }

            return lst;

        }

        private void ElegirFactura(string serie, int siguiente)
        {
            if (Boolean.Parse(oConfiguracion.FacturaElectronica))
            {
                Reportes.REP.RepFacturaElectronicaMuchosPagos oReporte = new Reportes.REP.RepFacturaElectronicaMuchosPagos();
                GenerarFactura(oReporte, serie, siguiente, "", true);// se envia el nFactura y la serie que corresponde
            }
            else
            {
                Reportes.REP.RepFacturaMuchosPagos oReporte = new Reportes.REP.RepFacturaMuchosPagos();
                GenerarFactura(oReporte, serie, siguiente, "", true);// se envia el nFactura y la serie que corresponde
            }
        }

        private int ObtenerPagosAnteriores()
        {
            int resultado = 0;

            if (!lblTicket.Text.Equals(""))
            {
                int id = Int32.Parse(lblTicket.Text);
                DataTable totalPagos = DataManager.DBConsultas.PagosRealizados(id);
                resultado = totalPagos.Rows.Count;
            }
            return resultado;
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
            PedidosSeparados pedidosSeparados = new PedidosSeparados(lblTicket.Text)
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
                GenerarTicket(oReporte, false);

            }
            else
            {
                MessageBox.Show("No hay datos que mostrar en el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void GenerarFactura(ReportClass oReporte, string serie, int nFactura,string tipoPago, Boolean pc)
        {
            DataTable datos = DataManager.DBConsultas.ProductosEnMesaConIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
            List<DataTable> lstFacturas = new List<DataTable>();

            int totalFilas = datos.Rows.Count;
            int filasPorCopia = 20;

            for (int i = 0; i < totalFilas; i += filasPorCopia)
            {
                DataTable data = datos.Clone(); // Clonar la estructura de la tabla original
                int copiaActual = Math.Min(filasPorCopia, totalFilas - i); // Determinar cuántas filas copiar en esta iteración

                for (int j = 0; j < copiaActual; j++)
                {
                    DataRow row = datos.Rows[i + j];
                    data.ImportRow(row); // Importar la fila a la nueva tabla
                }

                lstFacturas.Add(data); // Agregar la tabla copiada a la lista
            }

            foreach (DataTable item in lstFacturas)
            {
                oReporte.SetDataSource(item);
                Double totalPagar = 0;
                Double efectivo = 0;
                Double tarjeta = 0;
                Double btc = 0;
                if (pc)
                {
                    DataTable datos2 = DataManager.DBConsultas.PagosRealizados(Int32.Parse(lblTicket.Text));

                    foreach (DataRow item2 in datos2.Rows)
                    {
                        if (item2["formaPago"].ToString().Equals("EFECTIVO"))
                        {
                            efectivo = Double.Parse(item2["monto"].ToString());
                        }
                        else if (item2["formaPago"].ToString().Equals("TARJETA"))
                        {
                            tarjeta = Double.Parse(item2["monto"].ToString());
                        }
                        else if (item2["formaPago"].ToString().Equals("BITCOIN"))
                        {
                            btc = Double.Parse(item2["monto"].ToString());
                        }
                        totalPagar += Double.Parse(item2["monto"].ToString());
                    }
                    oReporte.SetParameterValue("PagoEfectivo", "EFECTIVO: $   " + efectivo.ToString("0.00"));
                    oReporte.SetParameterValue("PagoTarjeta", "TARJETA:  $   " + tarjeta.ToString("0.00"));
                    oReporte.SetParameterValue("PagoBtc", "BITCOIN:  $   " + btc.ToString("0.00"));
                }
                else
                {
                    totalPagar = Double.Parse(txtTotalPagar.Text);
                    oReporte.SetParameterValue("TipoPago", tipoPago);
                }
                oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
                oReporte.SetParameterValue("Direccion", oEmpresa.Direccion.ToUpper());
                oReporte.SetParameterValue("Telefono", oEmpresa.Telefono);
                oReporte.SetParameterValue("Subtotal", lblSaldo.Text.ToString());
                
                oReporte.SetParameterValue("Serie", serie);
                oReporte.SetParameterValue("nFactura", nFactura.ToString("00000"));
                oReporte.SetParameterValue("Propina", lblPropina.Text.ToString());
                oReporte.SetParameterValue("Total", "$" + totalPagar.ToString("0.00"));
                oReporte.SetParameterValue("FechaPago", fechaPago);
                string totalStr = totalPagar.ToString().Trim();

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
                            PrinterName = oConfiguracion.PrinterFactura
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
            
        }

        private void GenerarTicket(ReportClass oReporte, Boolean pc)
        {
            DataTable datos = DataManager.DBConsultas.ProductosEnMesaConIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Text));
            oReporte.SetDataSource(datos);
            Double totalPagar = 0;
            Double efectivo = 0;
            Double tarjeta = 0;
            Double btc = 0;
            if (pc)
            {
                DataTable datos2 = DataManager.DBConsultas.PagosRealizados(Int32.Parse(lblTicket.Text));

                foreach (DataRow item in datos2.Rows)
                {
                    if (item["formaPago"].ToString().Equals("EFECTIVO"))
                    {
                        efectivo = Double.Parse(item["monto"].ToString());
                    }
                    else if (item["formaPago"].ToString().Equals("TARJETA"))
                    {
                        tarjeta = Double.Parse(item["monto"].ToString());
                    }
                    else if (item["formaPago"].ToString().Equals("BITCOIN"))
                    {
                        btc = Double.Parse(item["monto"].ToString());
                    }
                    totalPagar += Double.Parse(item["monto"].ToString());
                }
                oReporte.SetParameterValue("PagoEfectivo", "EFECTIVO: $   " + efectivo.ToString("0.00"));
                oReporte.SetParameterValue("PagoTarjeta", "TARJETA:  $   " + tarjeta.ToString("0.00"));
                oReporte.SetParameterValue("PagoBtc", "BITCOIN:  $   " + btc.ToString("0.00"));
            }
            else
            {
                totalPagar = Double.Parse(txtTotalPagar.Text);
            }

            oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
            oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
            oReporte.SetParameterValue("Telefono", oEmpresa.Telefono);
            oReporte.SetParameterValue("Total", lblSaldo.Text.ToString());
            oReporte.SetParameterValue("Descuento", lblDescuento.Text.ToString());
            oReporte.SetParameterValue("Propina", lblPropina.Text.ToString());
            oReporte.SetParameterValue("Iva", lblIva.Text.ToString());
            oReporte.SetParameterValue("TotalPagar", "$" + totalPagar.ToString("0.00"));
            oReporte.SetParameterValue("FechaPago", fechaPago);
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

        private void btnBtc_Click(object sender, EventArgs e)
        {
            pagoEfectivo = false;
            pagoBtc = true;
            pagoTarjeta = false;
            pagoCortesia = false;
            pagoExacto = false;

            if (ValidarExistenciaTicket()) return;

            if (!txtPagoRegistrar.Text.Equals("") && !txtPagoRegistrar.Text.Equals("0"))
            {
                referencia = AgregarReferencia();
                pedido.Saldo = Double.Parse(lblCambio.Tag.ToString()) * (-1);

                //Registrar pago en cuenta
                AumentarCuenta();

                //Aqui insertar en la tabla pagos combinados
                ProcesarPago();
                
            }
            else
            {
                MessageBox.Show("Debe ingresar el pago a registrar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
