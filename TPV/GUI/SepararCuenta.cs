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
    public partial class SepararCuenta : Form
    {
        private DataTable datosActual = new DataTable();
        private DataTable datosSiguiente = new DataTable();
        Boolean pasar = false;
        public SepararCuenta()
        {
            InitializeComponent();
        }

        public void CargarProductosPorMesa(String id)
        {
            try
            {
                datosActual = DataManager.DBConsultas.ProductosEnMesa(id);
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
                    MessageBox.Show("Solo pasar ya que hay uno");

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
                        MessageBox.Show("Separar: " + separar + " Quedaran: " + quedaran);
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
            CargarProductosPorMesa(lblMesa.Tag.ToString());
        }

        private void btnPasar_Click(object sender, EventArgs e)
        {
            pasar = true;
            if(dgvActual.CurrentRow != null)
            {
                CantidadSeparar cantidadSeparar = new CantidadSeparar();
                int cantidad = Int32.Parse(dgvActual.CurrentRow.Cells["cantidad"].Value.ToString());
                int separar = 1, quedaran = 0;
                Boolean seEncuentra = false;
                int siguiente = 0;
                int indiceSiguiente = -1; // Inicializar con un valor que indique que no se encontró ninguna coincidencia
                int indiceActual = dgvActual.CurrentRow.Index;
                double precio = Double.Parse(dgvActual.CurrentRow.Cells["precio"].Value.ToString());

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
                    MessageBox.Show("Solo pasar ya que hay uno");

                    //Pasar y quitar
                    ModificarGeneral(seEncuentra, indiceSiguiente, separar, quedaran, indiceActual, precio);
                    PasarCompleto(indiceActual);
                }

                if (!cantidadSeparar.txtCantidad.Text.Equals("") && cantidadSeparar.cerrarPorBoton)
                {

                    separar = Int32.Parse(cantidadSeparar.txtCantidad.Text.ToString());
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
                        MessageBox.Show("Separar: " + separar + " Quedaran: " + quedaran);
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
                CrearNuevaFila(separar, quedaran, precio, indiceActual, indiceSiguiente);
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

        private void CrearNuevaFila(int separar, int quedaran, double precio, int indiceActual, int indiceSiguiente)
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
    }
}
