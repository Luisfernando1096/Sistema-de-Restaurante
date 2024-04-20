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
    public partial class EditarTicket : Form
    {
        public EditarTicket()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int idPedido = Int32.Parse(lblTicket.Text);
            int idPagoCombinado = Int32.Parse(lblTicket.Tag.ToString());
            int idCuenta;
            
            if (rbEfectivo.Checked && rbEfectivo.Tag.ToString().Equals("0"))
            {
                idCuenta = 1;
                //Vamos a aumentar el saldo y efectivo en caja
                DataTable pOtro = DataManager.DBConsultas.PagoOtraForma(idPagoCombinado);
                if (pOtro.Rows.Count > 0)
                {
                    Double tEfectivo = 0;
                    foreach (DataRow item in pOtro.Rows)
                    {
                        tEfectivo += Double.Parse(item["monto"].ToString());
                    }

                    ActualizarCaja(tEfectivo, true);
                }
            }
            else if (rbTarjeta.Checked && rbTarjeta.Tag.ToString().Equals("0"))
            {
                idCuenta = 2;
            }
            else if(rbBtc.Checked && rbBtc.Tag.ToString().Equals("0") )
            {
                idCuenta = 3;
            }
            else
            {
                MessageBox.Show("No se puede seleccionar la misma forma de pago.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Mantenimiento.CLS.PagoCombinado pagoCombinado = new Mantenimiento.CLS.PagoCombinado();
            pagoCombinado.IdPagoCombinado = idPagoCombinado;
            pagoCombinado.IdPedido = idPedido;
            pagoCombinado.IdCuenta = idCuenta;

            //Vamos a disminuir el efectivo y saldo si se ha cambiado la forma de pago en efectivo.
            DataTable pEfectivo = DataManager.DBConsultas.PagosEfectivo(idPedido);
            if (pEfectivo.Rows.Count > 0)
            {
                Double tEfectivo = 0;
                foreach (DataRow item in pEfectivo.Rows)
                {
                    tEfectivo += Double.Parse(item["sumaPagos"].ToString());
                }

                ActualizarCaja(tEfectivo, false);
            }

            if (pagoCombinado.CambiarFormaPago())
            {
                MessageBox.Show("Cambio realizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operacion no se realizó, contacte al programador.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private void ActualizarCaja(Double tEfectivo, Boolean aumentar)
        {
            DataTable datosCaja = DataManager.DBConsultas.CajaAbierta();
            
            Mantenimiento.CLS.Caja caja = new Mantenimiento.CLS.Caja();
            if (datosCaja.Rows.Count == 1)
            {
                double efectivo = 0;
                double saldo = 0;
                foreach (DataRow item in datosCaja.Rows)
                {
                    caja.IdCaja = Int32.Parse(item["idCaja"].ToString());
                    caja.IdCajero = Int32.Parse(item["idCajero"].ToString());
                    caja.Estado = true;

                    // La cadena de fecha y hora en formato original
                    string fechaHoraString = item["fechaApertura"].ToString();

                    // Define el formato original de la cadena de fecha y hora
                    string formatoOriginal = "d/M/yyyy HH:mm:ss";

                    // Convierte la cadena en un objeto DateTime
                    DateTime fechaHora = DateTime.ParseExact(fechaHoraString, formatoOriginal, System.Globalization.CultureInfo.InvariantCulture);

                    // Define el formato deseado
                    string formatoDeseado = "yyyy-MM-dd HH:mm:ss";

                    caja.FechaApertura = fechaHora.ToString(formatoDeseado); ;
                    caja.SaldoInicial = Double.Parse(item["saldoInicial"].ToString());
                    saldo = Double.Parse(item["saldo"].ToString());
                    efectivo = Double.Parse(item["efectivo"].ToString());
                }
                if ((efectivo >= tEfectivo && saldo >= tEfectivo) || aumentar)
                {
                    //Vamos actualizar caja, primero a traer lo que se pago en efectivo para descontar eso en caja.
                    if (aumentar)
                    {
                        caja.Saldo = saldo + tEfectivo;
                        caja.Efectivo = efectivo + tEfectivo;
                    }
                    else
                    {
                        caja.Saldo = saldo - tEfectivo;
                        caja.Efectivo = efectivo - tEfectivo;
                    }

                    if (!caja.Actualizar())
                    {
                        MessageBox.Show("Ocurrio un error actualizar caja, contacte al programador.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    //Saldo en caja insuficiente para anular factura
                    MessageBox.Show("Saldo en caja insuficiente para cambiar forma de pago. Intente mas tarde.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Verifique que haya una caja abierta.", "¡Informacion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
        }
    }
}
