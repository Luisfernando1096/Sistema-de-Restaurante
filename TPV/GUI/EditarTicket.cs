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
            
            if (rbEfectivo.Checked)
            {
                idCuenta = 1;
            }else if (rbTarjeta.Checked)
            {
                idCuenta = 2;
            }
            else if(rbBtc.Checked)
            {
                idCuenta = 3;
            }
            else
            {
                MessageBox.Show("Ocurrio un error, parece que no ha seleccionado opcion.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Mantenimiento.CLS.PagoCombinado pagoCombinado = new Mantenimiento.CLS.PagoCombinado();
            pagoCombinado.IdPagoCombinado = idPagoCombinado;
            pagoCombinado.IdPedido = idPedido;
            pagoCombinado.IdCuenta = idCuenta;
            if(pagoCombinado.CambiarFormaPago())
            {
                MessageBox.Show("Cambio realizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operacion no se realizó, contacte al programador.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }
    }
}
