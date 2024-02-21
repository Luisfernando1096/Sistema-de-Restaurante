using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mantenimiento.CLS;

namespace TPV.GUI
{
    public partial class AgregarCuentas : Form
    {
        Button botonMesa;
        public bool cambiarMesa = false;
        PuntoVenta punto_venta;
        public string idPedidoCambio;
        public string idMesaAnterior;
        SessionManager.Session oUsuario = SessionManager.Session.Instancia;

        public AgregarCuentas(Button botonMesa, PuntoVenta punto_venta)
        {
            InitializeComponent();
            this.botonMesa = botonMesa;
            this.punto_venta = punto_venta;
        }

        private void bttCuentaUnica_Click(object sender, EventArgs e)
        {
            ComandaGestion f = new ComandaGestion(punto_venta);
            f.lblMesa.Text = botonMesa.Text.ToString();
            f.lblMesa.Tag = botonMesa.Tag.ToString();
            this.Hide();
            f.ShowDialog();
            cambiarMesa = f.cambiarMesa;
            idPedidoCambio = f.lblTicket.Text;
            idMesaAnterior = f.lblMesa.Tag.ToString();
        }

        private void AgregarCuentas_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttVariasCuentas_Click_1(object sender, EventArgs e)
        {
            ComandaGestion f = new ComandaGestion(punto_venta);
            int primerPedidoID = 0;
            CantidadSeparar cantidadSeparar = new CantidadSeparar();
            cantidadSeparar.ShowDialog();
            int cantidad = 0;
            int idMesa = int.Parse(botonMesa.Tag.ToString());
            String fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataManager.DBOperacion transaccion1 = new DataManager.DBOperacion();
            List<String> lstPedido = new List<string>();

            if (!cantidadSeparar.txtCantidad.Text.Equals("") && cantidadSeparar.cerrarPorBoton)
            {
                cantidad = int.Parse(cantidadSeparar.txtCantidad.Text);
                if (cantidad > 1)
                {
                    int idMesero = 0;
                    if (oUsuario.IdRol.Equals("2"))
                    {
                        idMesero = Int32.Parse(oUsuario.IdUsuario);
                    }

                    if (idMesero > 0)
                    {
                        for (int i = 0; i < cantidad; i++)
                        {
                            Pedido pedido = new Pedido
                            {
                                IdMesa = idMesa,
                                IdMesero = idMesero,
                                Cancelado = false,
                                Fecha = fecha,
                                Listo = false,
                                Total = 0,
                                Descuento = 0,
                                Iva = 0,
                                Propina = 0,
                                TotalPago = 0,
                                Saldo = 0,
                                NFactura = "0",
                                Anular = false,
                                Efectivo = 0,
                                Credito = 0,
                                Btc = 0
                            };

                            lstPedido.Add(pedido.Insertar(true));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < cantidad; i++)
                        {
                            Pedido pedido = new Pedido
                            {
                                IdMesa = idMesa,
                                Cancelado = false,
                                Fecha = fecha,
                                Listo = false,
                                Total = 0,
                                Descuento = 0,
                                Iva = 0,
                                Propina = 0,
                                TotalPago = 0,
                                Saldo = 0,
                                NFactura = "0",
                                Anular = false,
                                Efectivo = 0,
                                Credito = 0,
                                Btc = 0
                            };

                            lstPedido.Add(pedido.Insertar(false));
                        }
                    }
                    
                    Mesa mesa = new Mesa
                    {
                        IdMesa = Int32.Parse(botonMesa.Tag.ToString()),
                        Disponible = false
                    };
                    lstPedido.Add(mesa.ActualizarEstado());

                    if (transaccion1.EjecutarTransaccion(lstPedido) > 0)
                    {
                        f.lblMesa.Text = botonMesa.Text.ToString();
                        f.lblMesa.Tag = botonMesa.Tag.ToString();
                        this.Close();

                        // Obtener el ID del último pedido insertado
                        int.TryParse(transaccion1.ConsultarScalar("SELECT LAST_INSERT_ID()").ToString(), out int ultimoPedidoID);
                        primerPedidoID = ultimoPedidoID - (cantidad - 1);
                        primerPedidoID = Math.Max(primerPedidoID, 1);

                        f.lblTicket.Text = primerPedidoID.ToString();
                        f.CargarPedidos(botonMesa.Tag.ToString());
                        f.ShowDialog();
                        cambiarMesa = f.cambiarMesa;
                        idPedidoCambio = f.lblTicket.Text;
                        idMesaAnterior = f.lblMesa.Tag.ToString();
                        f.BorrarPedidosVacios(idMesaAnterior);
                    }
                }
                else
                {
                    MessageBox.Show("El numero de cuentas debe ser mayor a 1 ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
