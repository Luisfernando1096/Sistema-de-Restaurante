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
    public partial class CambioContraseña : Form
    {
        SessionManager.Session oSesion = SessionManager.Session.Instancia;
        Boolean estado = false;

        public CambioContraseña()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtClave.Text != string.Empty)
            {
                if (oSesion.IniciarSesion(txtClave.Text))
                {
                    txtConfirmar.Enabled = true;
                    txtClaveNueva.Enabled = true;
                    pBox.Image = Properties.Resources.verdadero;
                    estado = true;
                    txtClave.Enabled = false;
                }
                else
                {
                    pBox.Image = Properties.Resources.falso;
                    MessageBox.Show("Pin de seguridad no encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    falso();
                    estado = false;
                }
            }
        }

        private void falso()
        {
            txtConfirmar.Enabled = false;
            txtClaveNueva.Enabled = false;
            txtConfirmar.Text = "";
            txtClaveNueva.Text = "";
        }

        private void bttGuardar_Click(object sender, EventArgs e)
        {
            if (estado)
            {
                if (txtConfirmar.Text != "" && txtClaveNueva.Text != "")
                {
                    if (txtClaveNueva.Text.ToString().Equals(txtConfirmar.Text.ToString()))
                    {
                        Mantenimiento.CLS.Usuario uS = new Mantenimiento.CLS.Usuario();
                        DataTable usuarios = DataManager.DBConsultas.UsuariosPin(txtClaveNueva.Text.ToString());
                        if (usuarios.Rows.Count == 0)
                        {
                            uS.IdUsuario = int.Parse(oSesion.IdUsuario);
                            uS.PinCode = txtClaveNueva.Text.ToString();
                            if (uS.Contraseña())
                            {
                                MessageBox.Show("Pin de seguridad actualizado con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pin de seguridad no es valido. Por favor trate con uno diferente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Los pin de seguridad no son iguales", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Suprimir la acción predeterminada del Enter (como insertar un salto de línea)
                btnIngresar.PerformClick(); // Ejecutar el evento Click del botón
            }
        }

        private void txtClaveNueva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Suprimir la acción predeterminada del Enter (como insertar un salto de línea)
                bttGuardar.PerformClick(); // Ejecutar el evento Click del botón
            }
        }
    }
}
