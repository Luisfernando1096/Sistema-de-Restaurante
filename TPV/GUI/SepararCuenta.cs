using Mantenimiento.CLS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TPV.GUI
{
    public partial class SepararCuenta : Form
    {
        private DataTable datosActual = new DataTable();
        private DataTable datosSiguiente = new DataTable();
        private DataTable datosPrincipales = new DataTable();
        int CantidadLista = 0;
        int idPedido1 = 0;
        public List<Tuple<int, int>> listaIdProductos = new List<Tuple<int, int>>();
        SessionManager.Session oUsuario = SessionManager.Session.Instancia;
        Boolean pasar = false;
        public Boolean cerrar;
        public SepararCuenta()
        {
            InitializeComponent();
        }

        public void CargarProductosPorMesayPorIdPedido(String id, int idPedido)
        {
            try
            {
                datosActual = DataManager.DBConsultas.ProductosEnMesaConIdPedido(id, idPedido);
                datosPrincipales = DataManager.DBConsultas.ProductosEnMesaConIdPedido(id, idPedido);
                dgvActual.DataSource = datosActual;
                dgvActual.AutoGenerateColumns = false;

                // Agregar columnas al DataTable (asegúrate de que coincidan c  on las columnas en el DataGridView)
                foreach (DataGridViewColumn column in dgvActual.Columns)
                {
                    datosSiguiente.Columns.Add(column.Name + "Siguiente");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnTraer_Click(object sender, EventArgs e)
        {
            pasar = false;
            if (dgvSiguiente.CurrentRow != null)
            {
                CantidadSeparar cantidadSeparar = new CantidadSeparar();
                int cantidad = Int32.Parse(dgvSiguiente.CurrentRow.Cells["cantidadSiguiente"].Value.ToString());
                int separar = 1, quedaran = 0;
                Boolean seEncuentra = false;
                int siguiente = 0;
                int indiceSiguiente = -1; // Inicializar con un valor que indique que no se encontró ninguna coincidencia
                int indiceActual = dgvSiguiente.CurrentRow.Index;
                double precio = Double.Parse(dgvSiguiente.CurrentRow.Cells["precioSiguiente"].Value.ToString());

                foreach (DataRow item in datosActual.Rows)
                {
                    // Comparar el dato actual con el siguiente
                    if (dgvSiguiente.CurrentRow.Cells["idProductoSiguiente"].Value.ToString().Equals(item["idProducto"].ToString()))
                    {
                        seEncuentra = true;
                        indiceSiguiente = siguiente; // Almacena el índice de la fila en la que se encontró la coincidencia
                        break; // Puedes salir del bucle una vez que encuentres la primera coincidencia si eso es lo que necesitas
                    }
                    siguiente++;
                }

                if (cantidad > 1)
                {
                    cantidadSeparar.lblInformacion.Text = "Seleccione la cantidad a separar entre 1 y " + cantidad;
                    cantidadSeparar.ShowDialog();
                }
                else
                {
                    //Pasar y quitar
                    ModificarGeneral(seEncuentra, indiceSiguiente, separar, quedaran, indiceActual, precio);
                    PasarCompleto(indiceActual);
                }

                if (!cantidadSeparar.txtCantidad.Text.Equals("") && cantidadSeparar.cerrarPorBoton)
                {

                    separar = Int32.Parse(cantidadSeparar.txtCantidad.Text.ToString());
                    quedaran = cantidad - Int32.Parse(cantidadSeparar.txtCantidad.Text.ToString());
                    precio = Double.Parse(dgvSiguiente.CurrentRow.Cells["precioSiguiente"].Value.ToString());

                    if (cantidad == Int32.Parse(cantidadSeparar.txtCantidad.Text.ToString()) && dgvSiguiente.Rows.Count >= 1)
                    {
                        //Pasar y quitar todos
                        ModificarGeneral(seEncuentra, indiceSiguiente, separar, quedaran, indiceActual, precio);
                        PasarCompleto(indiceActual);
                    }
                    else if (cantidad > Int32.Parse(cantidadSeparar.txtCantidad.Text.ToString()))
                    {
                        //Pasar una parte
                        ModificarGeneral(seEncuentra, indiceSiguiente, separar, quedaran, indiceActual, precio);
                    }
                    else
                    {
                        MessageBox.Show("Ha definido una cantidad mayor y no se puede realizar.");
                        return;
                    }
                }

            }

            dgvActual.DataSource = datosActual;
            dgvSiguiente.DataSource = datosSiguiente;
        }

        private void SepararCuenta_Load(object sender, EventArgs e)
        {
            CargarProductosPorMesayPorIdPedido(lblMesa.Tag.ToString(), Int32.Parse(lblTicket.Tag.ToString()));
        }

        private void btnPasar_Click(object sender, EventArgs e)
        {
            pasar = true;
            if (dgvActual.CurrentRow != null)
            {
                CantidadSeparar cantidadSeparar = new CantidadSeparar();
                int cantidad = Int32.Parse(dgvActual.CurrentRow.Cells["cantidad"].Value.ToString());
                int separar = 1, quedaran = 0;
                Boolean seEncuentra = false;
                int siguiente = 0;
                int indiceSiguiente = -1; // Inicializar con un valor que indique que no se encontró ninguna coincidencia
                int indiceActual = dgvActual.CurrentRow.Index;
                double precio = Double.Parse(dgvActual.CurrentRow.Cells["precio"].Value.ToString());
                int idPLocal = Int32.Parse(dgvActual.CurrentRow.Cells["idProducto"].Value.ToString());
                idPedido1 = idPLocal;

                foreach (DataRow item in datosSiguiente.Rows)
                {
                    // Comparar el dato actual con el siguiente
                    if (dgvActual.CurrentRow.Cells["idProducto"].Value.ToString().Equals(item["idProductoSiguiente"].ToString()))
                    {
                        seEncuentra = true;
                        indiceSiguiente = siguiente; // Almacena el índice de la fila en la que se encontró la coincidencia
                        break; // Puedes salir del bucle una vez que encuentres la primera coincidencia si eso es lo que necesitas
                    }
                    siguiente++;
                }

                if (cantidad == 1 && dgvActual.Rows.Count == 1)
                {
                    MessageBox.Show("Debe haber mas de un producto en la comanda");
                    return;
                }
                else if (cantidad > 1)
                {
                    cantidadSeparar.lblInformacion.Text = "Seleccione la cantidad a separar entre 1 y " + cantidad;
                    cantidadSeparar.ShowDialog();
                }
                else
                {
                    //Pasar y quitar
                    ModificarGeneral(seEncuentra, indiceSiguiente, separar, quedaran, indiceActual, precio);
                    PasarCompleto(indiceActual);
                }

                if (!cantidadSeparar.txtCantidad.Text.Equals("") && cantidadSeparar.cerrarPorBoton)
                {

                    separar = Int32.Parse(cantidadSeparar.txtCantidad.Text.ToString());
                    CantidadLista = separar; ///Cantidad que se va separar
                    listaIdProductos.Add(new Tuple<int, int>(idPedido1, CantidadLista));

                    quedaran = cantidad - Int32.Parse(cantidadSeparar.txtCantidad.Text.ToString());
                    precio = Double.Parse(dgvActual.CurrentRow.Cells["precio"].Value.ToString());

                    if (cantidad == Int32.Parse(cantidadSeparar.txtCantidad.Text.ToString()) && dgvActual.Rows.Count > 1)
                    {
                        //Pasar y quitar todos
                        ModificarGeneral(seEncuentra, indiceSiguiente, separar, quedaran, indiceActual, precio);
                        PasarCompleto(indiceActual);
                    }
                    else if (cantidad == Int32.Parse(cantidadSeparar.txtCantidad.Text.ToString()) && dgvActual.Rows.Count == 1)
                    {
                        MessageBox.Show("No puede pasar todos los productos");
                        return;
                    }
                    else if (cantidad > Int32.Parse(cantidadSeparar.txtCantidad.Text.ToString()))
                    {
                        //Pasar una parte
                        ModificarGeneral(seEncuentra, indiceSiguiente, separar, quedaran, indiceActual, precio);
                    }
                    else
                    {
                        MessageBox.Show("Ha definido una cantidad mayor y no se puede realizar.");
                        return;
                    }
                }

            }

            dgvActual.DataSource = datosActual;
            dgvSiguiente.DataSource = datosSiguiente;
        }

        private void ModificarGeneral(bool seEncuentra, int indiceSiguiente, int separar, int quedaran, int indiceActual, double precio)
        {
            if (seEncuentra)
            {
                ModificarFilaSiguiente(separar, quedaran, precio, indiceActual, indiceSiguiente);
            }
            else
            {
                CrearNuevaFila(separar, quedaran, precio, indiceActual);
            }
        }

        private void ModificarFilaSiguiente(int separar, int quedaran, double precio, int indiceActual, int indiceSiguiente)
        {
            if (pasar)
            {
                // Copia los datos de cada celda de la fila seleccionada al clon.
                if (indiceActual >= 0)
                {
                    DataRow filaOriginal = datosActual.Rows[indiceActual];
                    DataRow filaSiguiente = datosSiguiente.Rows[indiceSiguiente];

                    int cant = Int32.Parse(filaSiguiente["cantidadSiguiente"].ToString());

                    filaOriginal["cantidad"] = quedaran;
                    filaOriginal["subTotal"] = precio * quedaran;
                    datosActual.AcceptChanges();

                    filaSiguiente["cantidadSiguiente"] = (separar + cant);
                    filaSiguiente["subTotalSiguiente"] = precio * (separar + cant);
                    datosSiguiente.AcceptChanges();
                }
            }
            else
            {
                // Copia los datos de cada celda de la fila seleccionada al clon.
                if (indiceActual >= 0)
                {
                    DataRow filaOriginal = datosSiguiente.Rows[indiceActual];
                    DataRow filaSiguiente = datosActual.Rows[indiceSiguiente];

                    int cant = Int32.Parse(filaSiguiente["cantidad"].ToString());

                    filaOriginal["cantidadSiguiente"] = quedaran;
                    filaOriginal["subTotalSiguiente"] = precio * quedaran;
                    datosSiguiente.AcceptChanges();

                    filaSiguiente["cantidad"] = (separar + cant);
                    filaSiguiente["subTotal"] = precio * (separar + cant);
                    datosActual.AcceptChanges();
                }
            }
        }

        private void CrearNuevaFila(int separar, int quedaran, double precio, int indiceActual)
        {
            if (pasar)
            {
                if (indiceActual >= 0)
                {

                    DataRow filaOriginal = datosActual.Rows[indiceActual]; // Obtiene la primera fila de datosActual.

                    DataRow nuevaFila = datosSiguiente.NewRow(); // Crea una nueva fila en datosSiguiente.

                    // Copia los valores de las columnas desde la fila original a la nueva fila.
                    nuevaFila.ItemArray = filaOriginal.ItemArray;

                    // Realiza los cambios en los valores de las columnas necesarios.
                    nuevaFila["cantidadSiguiente"] = separar;
                    nuevaFila["subTotalSiguiente"] = precio * separar;

                    // Agrega la nueva fila al DataTable de destino.
                    datosSiguiente.Rows.Add(nuevaFila);

                    filaOriginal["cantidad"] = quedaran;
                    filaOriginal["subTotal"] = precio * quedaran;
                    datosActual.AcceptChanges();
                }
            }
            else
            {
                if (indiceActual >= 0)
                {

                    DataRow filaOriginal = datosSiguiente.Rows[indiceActual]; // Obtiene la primera fila de datosActual.

                    DataRow nuevaFila = datosActual.NewRow(); // Crea una nueva fila en datosSiguiente.

                    // Copia los valores de las columnas desde la fila original a la nueva fila.
                    nuevaFila.ItemArray = filaOriginal.ItemArray;

                    // Realiza los cambios en los valores de las columnas necesarios.
                    nuevaFila["cantidad"] = separar;
                    nuevaFila["subTotal"] = precio * separar;

                    // Agrega la nueva fila al DataTable de destino.
                    datosActual.Rows.Add(nuevaFila);

                    filaOriginal["cantidadSiguiente"] = quedaran;
                    filaOriginal["subTotalSiguiente"] = precio * quedaran;
                    datosActual.AcceptChanges();
                }
            }
        }

        private void PasarCompleto(int indiceActual)
        {
            if (pasar)
            {
                if (dgvActual.CurrentRow != null)
                {
                    // Agrega la nueva fila al DataTable de destino.
                    datosActual.Rows.RemoveAt(indiceActual);

                    datosActual.AcceptChanges();

                }
            }
            else
            {
                if (dgvSiguiente.CurrentRow != null)
                {
                    // Agrega la nueva fila al DataTable de destino.
                    datosSiguiente.Rows.RemoveAt(indiceActual);

                    datosSiguiente.AcceptChanges();

                }
            }


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExtras_Click(object sender, EventArgs e)
        {
            List<String> lstSeparar = new List<string>();
            int idPedido = Int32.Parse(lblTicket.Tag.ToString());
            int idMesa = Int32.Parse(lblMesa.Tag.ToString());

            if (datosSiguiente.Rows.Count > 0)
            {
                //Programado para el pedido principal
                Mantenimiento.CLS.PedidoDetalle pedidoDetalle;
                if (datosPrincipales.Rows.Count == datosActual.Rows.Count)
                {
                    //Solo actualizacion
                    foreach (DataRow siguiente in datosSiguiente.Rows)
                    {
                        foreach (DataRow actual in datosActual.Rows)
                        {
                            if (siguiente["idProductoSiguiente"].ToString().Equals(actual["idProducto"].ToString()))
                            {
                                pedidoDetalle = new Mantenimiento.CLS.PedidoDetalle
                                {
                                    IdDetalle = Int32.Parse(actual["idDetalle"].ToString()),
                                    IdPedido = idPedido,
                                    IdProducto = Int32.Parse(actual["idProducto"].ToString()),
                                    Cantidad = Int32.Parse(actual["cantidad"].ToString()),
                                    SubTotal = Double.Parse(actual["subTotal"].ToString())
                                };
                                lstSeparar.Add(pedidoDetalle.ActualizarCompra(false));
                            }
                        }
                    }
                }
                else
                {
                    bool eliminar = false;
                    //Habra eliminacion y posible actualizacion
                    foreach (DataRow siguiente in datosSiguiente.Rows)
                    {
                        foreach (DataRow actual in datosActual.Rows)
                        {
                            if (siguiente["idProductoSiguiente"].ToString().Equals(actual["idProducto"].ToString()))
                            {
                                pedidoDetalle = new Mantenimiento.CLS.PedidoDetalle
                                {
                                    IdDetalle = Int32.Parse(actual["idDetalle"].ToString()),
                                    IdPedido = idPedido,
                                    IdProducto = Int32.Parse(actual["idProducto"].ToString()),
                                    Cantidad = Int32.Parse(actual["cantidad"].ToString()),
                                    SubTotal = Double.Parse(actual["subTotal"].ToString())
                                };
                                lstSeparar.Add(pedidoDetalle.ActualizarCompra(false));
                                
                                eliminar = false;
                                break;
                            }
                            else
                            {
                                eliminar = true;
                            }
                        }

                        if (eliminar)
                        {
                            pedidoDetalle = new Mantenimiento.CLS.PedidoDetalle
                            {
                                IdDetalle = Int32.Parse(siguiente["idDetalleSiguiente"].ToString())
                            };
                            lstSeparar.Add(pedidoDetalle.Eliminar());
                            
                        }
                        //Vamos a actualizar el total del pedido
                        Mantenimiento.CLS.Pedido pedido2 = new Mantenimiento.CLS.Pedido
                        {
                            IdPedido = idPedido,
                            IdMesa = idMesa
                        };
                        double total2 = CalcularTotal(dgvActual, "subTotal");
                        lstSeparar.Add(pedido2.ActualizarTotal(total2, false));
                        //HAcer la transaccion
                    }
                }
                String fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //Creamos un nuevo pedido y despues los detalles
                Mantenimiento.CLS.Pedido pedido = new Mantenimiento.CLS.Pedido
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

                //Agregamos detalles al pedido
                Mantenimiento.CLS.PedidoDetalle pedidoDetalle2;

                //Insertamos en la base de datos el pedido
                lstSeparar.Add(pedido.Insertar(false));
                foreach (DataRow siguiente in datosSiguiente.Rows)
                {
                    pedidoDetalle2 = new Mantenimiento.CLS.PedidoDetalle
                    {
                        IdDetalle = 0,
                        Cocinando = true,
                        Extras = "",
                        HoraEntregado = fecha,
                        HoraPedido = fecha,
                        //pedidoDetalle2.IdCocinero = null;
                        IdProducto = Int32.Parse(siguiente["idProductoSiguiente"].ToString()),
                        Cantidad = Int32.Parse(siguiente["cantidadSiguiente"].ToString()),
                        Precio = Double.Parse(siguiente["precioSiguiente"].ToString()),
                        SubTotal = Double.Parse(siguiente["subTotalSiguiente"].ToString()),
                        Grupo = "0",
                        Usuario = oUsuario.IdUsuario
                    };
                    //pedidoDetalle2.Fecha = null;
                    lstSeparar.Add(pedidoDetalle2.Insertar(true));
                        
                }
                double total = CalcularTotal(dgvSiguiente, "subTotalSiguiente");
                lstSeparar.Add(pedido.ActualizarTotal(total, true));
                    
                //Hacer la transaccion aqui
                DataManager.DBOperacion transaccion1 = new DataManager.DBOperacion();
                if (transaccion1.EjecutarTransaccion(lstSeparar) > 0)
                {
                    //lblTicket.Text = idPedidoInsertado.ToString(); //Debo colocar el id del pedido
                    cerrar = true;
                }
                else
                {
                    MessageBox.Show("ERROR EN TRANSACCION AL SEPARAR PEDIDO, CONTACTE AL PROGRAMADOR.");
                }
                Close();
            }
            else
            {
                MessageBox.Show("No hay nada que separar");
            }
        }

        private double CalcularTotal(DataGridView dgv, String name)
        {
            double total = 0;
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells[name].Value != null && row.Cells[name].Value != DBNull.Value)
                    {
                        total += Convert.ToDouble(row.Cells[name].Value);
                    }
                }
            }
            return total;
        }
    }
}
