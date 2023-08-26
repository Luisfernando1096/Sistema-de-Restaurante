﻿using System;
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


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TPV.GUI.PuntoVenta f = new TPV.GUI.PuntoVenta();
            f.ShowDialog();
            this.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TPV.GUI.PuntoVenta f = new TPV.GUI.PuntoVenta();
            f.Hide();
            TPV.GUI.ComandaGestion f2 = new TPV.GUI.ComandaGestion(f);
            f2.Hide();
            TPV.GUI.PuntoPago f3 = new TPV.GUI.PuntoPago();
            f3.ShowDialog();
            if (f3.lblMesa.Tag != null)
            {
                DataTable productoEnMesas = DataManager.DBConsultas.ProductosEnMesa(f3.lblMesa.Tag.ToString());

                if (productoEnMesas.Rows.Count > 0)
                {
                    //Aqui cargamos los datos en datagrid 
                    f2.CargarProductosPorMesa(f3.lblMesa.Tag.ToString());
                    f2.lblTicket.Text = productoEnMesas.Rows[0][0].ToString();//Accedemos a la primera posicion de la tabla
                    DataTable pedido = DataManager.DBConsultas.PedidoPorId(Int32.Parse(productoEnMesas.Rows[0][0].ToString()));
                    if (!pedido.Rows[0]["nombres"].ToString().Equals(""))
                    {
                        f2.lblMesero.Text = pedido.Rows[0]["nombres"].ToString();
                        f2.lblMesero.Tag = int.Parse(pedido.Rows[0]["idMesero"].ToString());
                    }
                    else
                    {
                        f2.lblMesero.Text = "";
                        f2.lblMesero.Tag = "";
                    }
                    if (!pedido.Rows[0]["nombre"].ToString().Equals(""))
                    {
                        f2.lblCliente.Text = pedido.Rows[0]["nombre"].ToString();
                        f2.lblCliente.Tag = int.Parse(pedido.Rows[0]["idCliente"].ToString());
                    }
                    else
                    {
                        f2.lblCliente.Text = "";
                        f2.lblCliente.Tag = "";
                    }
                }
                f2.lblMesa.Text = f3.lblMesa.Text.ToString();
                f2.lblMesa.Tag = f3.lblMesa.Tag.ToString();
            }
            f2.ShowDialog();
            f.ShowDialog();
            this.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TPV.GUI.ClientesGestion f = new TPV.GUI.ClientesGestion();
            f.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            TPV.GUI.TicketsProcesados f = new TPV.GUI.TicketsProcesados();
            f.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TPV.GUI.AnularFactura f = new TPV.GUI.AnularFactura();
            f.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Productos f = new Ingredientes_y_Productos.GUI.Productos();
            f.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.BuscarProducto f = new Ingredientes_y_Productos.GUI.BuscarProducto();
            f.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Ingredientes f = new Ingredientes_y_Productos.GUI.Ingredientes();
            f.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.BuscarIngrediente f = new Ingredientes_y_Productos.GUI.BuscarIngrediente();
            f.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Ingredientes f = new Ingredientes_y_Productos.GUI.Ingredientes();
            f.tabControl1.SelectedIndex = 1;
            f.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Productos f = new Ingredientes_y_Productos.GUI.Productos();
            f.tabControl1.SelectedIndex = 1;
            f.ShowDialog();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.Productos f = new Ingredientes_y_Productos.GUI.Productos();
            f.tabControl1.SelectedIndex = 2;
            f.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Ingredientes_y_Productos.GUI.AjusteStock f = new Ingredientes_y_Productos.GUI.AjusteStock();
            f.ShowDialog();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Compras.GUI.Compras f = new Compras.GUI.Compras();
            f.ShowDialog();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Compras.GUI.Proveedores f = new Compras.GUI.Proveedores();
            f.ShowDialog();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            Compras.GUI.BuscarProveedor f = new Compras.GUI.BuscarProveedor();
            f.ShowDialog();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            Compras.GUI.TipoComprobante f = new Compras.GUI.TipoComprobante();
            f.ShowDialog();
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            Finanzas.GUI.Egresos f = new Finanzas.GUI.Egresos();
            f.ShowDialog();
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            Finanzas.GUI.AdministrarCuentas f = new Finanzas.GUI.AdministrarCuentas();
            f.ShowDialog();
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            Personal.GUI.EmpleadosGestion f = new Personal.GUI.EmpleadosGestion();
            f.ShowDialog();
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            Personal.GUI.RolesGestion f = new Personal.GUI.RolesGestion();
            f.ShowDialog();
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            Personal.GUI.Asignar_roles f = new Personal.GUI.Asignar_roles();
            f.ShowDialog();
        }

        private void toolStripButton41_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            Salones.GUI.SalonesMesas f = new Salones.GUI.SalonesMesas();
            f.ShowDialog();
        }
    }
}
