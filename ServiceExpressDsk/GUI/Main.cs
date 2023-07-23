using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceExpressDsk.GUI
{
    public partial class Main : Form
    {
        SessionManager.Session oUsuario = SessionManager.Session.Instancia;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Se cerrara la sesion, ¿esta seguro que desea cerrar sesion?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancelar el cierre del formulario
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //lblConexionGreen.Visible = true;
            lblUsuario.Text = "SESION DE : " + oUsuario.Usuario.ToUpper();
            //lblRol.Text = oUsuario.Rol.ToUpper();
            //timer1.Start();
        }

        private void puntoDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TPV.GUI.PuntoVenta f = new TPV.GUI.PuntoVenta();
            f.ShowDialog();
            this.Show();
        }

        private void aperturaCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TPV.GUI.ClientesGestion f = new TPV.GUI.ClientesGestion();
            f.ShowDialog();
        }

        private void puntoDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TPV.GUI.PuntoVenta f = new TPV.GUI.PuntoVenta();
            f.Hide();
            TPV.GUI.ComandaGestion f2 = new TPV.GUI.ComandaGestion(f);
            f2.Hide();
            TPV.GUI.PuntoPago f3 = new TPV.GUI.PuntoPago();
            f3.ShowDialog();
            f2.ShowDialog();
            f.ShowDialog();
            this.Show();
        }

        private void ticketsProcesadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TPV.GUI.TicketsProcesados f = new TPV.GUI.TicketsProcesados();
            f.ShowDialog();
        }

        private void anularFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TPV.GUI.AnularFactura f = new TPV.GUI.AnularFactura();
            f.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ingredientes_y_Productos.GUI.Productos f = new Ingredientes_y_Productos.GUI.Productos();
            f.ShowDialog();
            this.Show();
        }

        private void buscarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ingredientes_y_Productos.GUI.BuscarProducto f = new Ingredientes_y_Productos.GUI.BuscarProducto();
            f.ShowDialog();
            this.Show();
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ingredientes_y_Productos.GUI.Ingredientes f = new Ingredientes_y_Productos.GUI.Ingredientes();
            f.ShowDialog();
            this.Show();
        }

        private void buscarIngredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ingredientes_y_Productos.GUI.BuscarIngrediente f = new Ingredientes_y_Productos.GUI.BuscarIngrediente();
            f.ShowDialog();
            this.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Productos f = new Ingredientes_y_Productos.GUI.Productos();
            f.tabControl1.SelectedIndex = 1;
            f.ShowDialog();
        }
        private void recetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Ingredientes f = new Ingredientes_y_Productos.GUI.Ingredientes();
            f.tabControl1.SelectedIndex = 1;
            f.ShowDialog();
        }

        private void presentacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Productos f = new Ingredientes_y_Productos.GUI.Productos();
            f.tabControl1.SelectedIndex = 2;
            f.ShowDialog();
        }

        private void ajustarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.AjusteStock f = new Ingredientes_y_Productos.GUI.AjusteStock();
            f.ShowDialog();
            this.Show();
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Compras.GUI.Compras f = new Compras.GUI.Compras();
            f.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compras.GUI.Proveedores f = new Compras.GUI.Proveedores();
            f.ShowDialog();
        }

        private void buscarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compras.GUI.BuscarProveedor f = new Compras.GUI.BuscarProveedor();
            f.ShowDialog();
        }

        private void tipoComprobantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compras.GUI.TipoComprobante f = new Compras.GUI.TipoComprobante();
            f.ShowDialog();
        }
    }
}
