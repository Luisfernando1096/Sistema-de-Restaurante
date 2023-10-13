using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Configuraciones.GUI
{
    public partial class ConfiguracionTPV : Form
    {
        private String SeleccionarLogo = string.Empty;
        private String SeleccionarFirma = string.Empty;
        private String SeleccionarSello = string.Empty;
        private void CargarDatosConfig()
        {
            try
            {
                DataTable configuracionTable = DataManager.DBConsultas.Configuraciones();

                if (configuracionTable.Rows.Count > 0)
                {
                    DataRow configuracionRow = configuracionTable.Rows[0];

                    // Asigna valores a los CheckBoxes
                    checkActivarInventario.Checked = Convert.ToBoolean(configuracionRow["controlStock"]);
                    checkActivarPropina.Checked = Convert.ToBoolean(configuracionRow["incluirPropina"]);
                    checkActivarIva.Checked = Convert.ToBoolean(configuracionRow["incluirImpuesto"]);
                    checkActivarIVip.Checked = Convert.ToBoolean(configuracionRow["mesaVIP"]);
                    checkActivarAlerta.Checked = Convert.ToBoolean(configuracionRow["alertaCaja"]);
                    checkMultiSe.Checked = Convert.ToBoolean(configuracionRow["multisesion"]);
                    checkMuchosPro.Checked = Convert.ToBoolean(configuracionRow["muchosProductos"]);
                    checkAutorizacion.Checked = Convert.ToBoolean(configuracionRow["autorizarDescProp"]);
                    if (Convert.ToDouble(configuracionRow["mesaVip"]) != 0)
                    {
                        checkActivarIVip.Checked = true;
                    }
                    else
                    {
                        checkActivarIVip.Checked = false;
                    }

                    txtPropinas.Text = configuracionRow["propina"].ToString();
                    txtImpuesto.Text = configuracionRow["iva"].ToString();
                    txtImpuestoVIP.Text = configuracionRow["mesaVIP"].ToString();
                    txtMultiSe.Text = configuracionRow["numSesiones"].ToString();

                    // Configura los ComboBox para mostrar la opción que coincide con el valor del campo en la base de datos
                    cmbComandas.SelectedIndex = cmbComandas.FindStringExact(configuracionRow["printerComanda"].ToString());
                    cmbFacturas.SelectedIndex = cmbFacturas.FindStringExact(configuracionRow["printerFactura"].ToString());
                    cmbInformes.SelectedIndex = cmbInformes.FindStringExact(configuracionRow["printerInformes"].ToString());

                }
                else
                {
                    // Manejar el caso donde no se encontraron datos de configuración
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la configuración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarDatosOpTicket()
        {
            try
            {
                DataTable OpticketTable = DataManager.DBConsultas.Ticket(1);

                if (OpticketTable.Rows.Count > 0)
                {
                    DataRow configuracionRow = OpticketTable.Rows[0];

                    chkMostrarEmpresa.Checked = Convert.ToBoolean(configuracionRow["showEmpresa"]);
                    chkMostrarSlogan.Checked = Convert.ToBoolean(configuracionRow["showSlogan"]);
                    chkMostrarSaludo.Checked = Convert.ToBoolean(configuracionRow["showSaludo"]);
                    chkMostrarDireccion.Checked = Convert.ToBoolean(configuracionRow["showDireccion"]);
                    chkMostrarTel.Checked = Convert.ToBoolean(configuracionRow["showTelefono"]);
                    //chkMostrarSaludo.Checked = Convert.ToBoolean(configuracionRow["alertaCaja"]);
                    chkMostrarNIT.Checked = Convert.ToBoolean(configuracionRow["showNIT"]);
                    chkMostrarNCR.Checked = Convert.ToBoolean(configuracionRow["showNRC"]);
                    chkMostrarNumAutorizacion.Checked = Convert.ToBoolean(configuracionRow["numAutorizacion"]);
                    chkAgregarLinea.Checked = Convert.ToBoolean(configuracionRow["extraLine"]);

                    txtEncabezado1.Text = configuracionRow["header1"].ToString();
                    txtEncabezado2.Text = configuracionRow["header2"].ToString();
                    txtEncabezado3.Text = configuracionRow["header3"].ToString();

                    txtPie1.Text = configuracionRow["footer1"].ToString();
                    txtPie2.Text = configuracionRow["footer2"].ToString();
                    txtPie3.Text = configuracionRow["footer3"].ToString();

                    txtSecuenciaP.Text = configuracionRow["seCortePapel"].ToString();
                    txtMargen.Text = configuracionRow["leftMargin"].ToString();
                    txtNumCaracteres.Text = configuracionRow["nCaracteres"].ToString();

                }
                else
                {
                    // Manejar el caso donde no se encontraron datos de configuración
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEmpresa()
        {
            try
            {
                DataTable empresa = DataManager.DBConsultas.Empresa(1);

                if (empresa.Rows.Count > 0)
                {
                    DataRow configuracionRow = empresa.Rows[0];

                    txtEmpresa.Text = configuracionRow["nombreEmpresa"].ToString();
                    txtDireccion.Text = configuracionRow["direccion"].ToString();
                    txtSlogan.Text = configuracionRow["slogan"].ToString();
                    txtTelefono.Text = configuracionRow["telefono"].ToString();
                    txtSaludo.Text = configuracionRow["saludo"].ToString();
                    txtNRC.Text = configuracionRow["NRC"].ToString();
                    txtNIT.Text = configuracionRow["NIT"].ToString();
                    txtAutorizacionTicket.Text = configuracionRow["numAutorizacion"].ToString();
                    string rutaImagenLogo = configuracionRow["logo"].ToString();
                    string rutaImagenFirma = configuracionRow["firma"].ToString();
                    string rutaImagenSello = configuracionRow["sello"].ToString();

                    if (!string.IsNullOrEmpty(rutaImagenLogo))
                    {
                        pBoxLogo.Image = Image.FromFile(rutaImagenLogo);
                        pBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        //MessageBox.Show("La imagen no se encontró en la ruta especificada.");
                    }
                    if (!string.IsNullOrEmpty(rutaImagenFirma))
                    {
                        pBoxFirma.Image = Image.FromFile(rutaImagenFirma);
                        pBoxFirma.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        //MessageBox.Show("La imagen no se encontró en la ruta especificada.");
                    }
                    if (!string.IsNullOrEmpty(rutaImagenSello))
                    {
                        pBoxSello.Image = Image.FromFile(rutaImagenSello);
                        pBoxSello.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        //MessageBox.Show("La imagen no se encontró en la ruta especificada.");
                    }
                }
                else
                {
                    // Manejar el caso donde no se encontraron datos de configuración
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SeleccionDatos()
        {
            try
            {
                if (checkActivarPropina.Checked)
                {
                    txtPropinas.Enabled = true;
                }
                else
                {
                    txtPropinas.Enabled = false;
                }
                if (checkActivarIva.Checked)
                {
                    txtImpuesto.Enabled = true;
                }
                else
                {
                    txtImpuesto.Enabled = false;
                }

                if (checkActivarIVip.Checked)
                {
                    txtImpuestoVIP.Enabled = true;
                }
                else
                {
                    txtImpuestoVIP.Enabled = false;
                }
                if (checkMultiSe.Checked)
                {
                    txtMultiSe.Enabled = true;
                }
                else
                {
                    txtMultiSe.Enabled = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ConfiguracionTPV()
        {
            InitializeComponent();
        }

        private void ConfiguracionTPV_Load(object sender, EventArgs e)
        {
            // Crea una lista de impresoras
            List<string> lstImpresoras = new List<string>();
            lstImpresoras.Add("Microsoft Print to PDF");
            lstImpresoras.Add("Microsoft XPS Document Writer");

            // Asigna la lista de impresoras a los ComboBoxes
            cmbComandas.Items.AddRange(lstImpresoras.ToArray());
            cmbComandaTick.Items.AddRange(lstImpresoras.ToArray());
            cmbFacturas.Items.AddRange(lstImpresoras.ToArray());
            cmbInformes.Items.AddRange(lstImpresoras.ToArray());

            CargarDatosConfig();
            CargarDatosEmpresa();
            CargarDatosOpTicket();
            SeleccionDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnGuardarConfig_Click(object sender, EventArgs e)
        {
            try
            {
                Mantenimiento.CLS.Configuracion config = new Mantenimiento.CLS.Configuracion();
                config.IdConfiguracion = 1;

                //Propina
                if (checkActivarPropina.Checked)
                {
                    config.IncluirPropina = 1;
                    config.Propina = double.Parse(txtPropinas.Text);
                }
                else
                {
                    config.IncluirPropina = 0;
                    config.Propina = 0;
                }

                //Iva
                if (checkActivarIva.Checked)
                {
                    config.IncluirImpuesto = 1;
                    config.Iva = double.Parse(txtImpuesto.Text);
                }
                else
                {
                    config.IncluirImpuesto = 0;
                    config.Iva = 0;
                }
                //Mesa Vip
                if (checkActivarIVip.Checked)
                {
                    config.MesaVIP = double.Parse(txtImpuestoVIP.Text);
                }
                else
                {
                    config.MesaVIP = 0;
                }
                //Multisesiones
                if (checkMultiSe.Checked)
                {
                    config.Multisesion = 1;
                    config.NumSesiones = int.Parse(txtMultiSe.Text);
                }
                else
                {
                    config.Multisesion = 0;
                    config.NumSesiones = 0;
                }
                if (checkActivarInventario.Checked)
                {
                    config.ControlStock = 1;
                }
                else
                {
                    config.ControlStock = 0;
                }
                if (checkActivarAlerta.Checked)
                {
                    config.AlertaCaja = 1;
                }
                else
                {
                    config.AlertaCaja = 0;
                }

                if (checkAutorizacion.Checked)
                {
                    config.AutorizarDescProp = 1;
                }
                else
                {
                    config.AutorizarDescProp = 0;
                }

                if (checkMuchosPro.Checked)
                {
                    config.MuchosProductos = 1;
                }
                else
                {
                    config.MuchosProductos = 0;
                }

                if (cmbComandas.SelectedIndex != -1)
                {
                    config.PrinterComanda = cmbComandas.Text;
                }
                if (cmbInformes.SelectedIndex != -1)
                {
                    config.PrinterInformes = cmbInformes.Text;
                }
                if (cmbFacturas.SelectedIndex != -1)
                {
                    config.PrinterFactura = cmbFacturas.Text;
                }

                if (config.Actualizar())
                {
                    MessageBox.Show("¡Cambios actualizados exitosamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatosConfig();
                    this.Focus();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            Mantenimiento.CLS.Empresa empresa = new Mantenimiento.CLS.Empresa();
            empresa.IdEmpresa = 1;
            empresa.Logo = SeleccionarLogo;
            empresa.Firma = SeleccionarFirma;
            empresa.Sello = SeleccionarSello;
            if (txtEmpresa.Text != string.Empty)
            {
                empresa.NombreEmpresa = txtEmpresa.Text;
            }
            else
            {
                empresa.NombreEmpresa = "";
            }
            if (txtDireccion.Text != string.Empty)
            {
                empresa.Direccion = txtDireccion.Text;
            }
            else
            {
                empresa.Direccion = "";
            }
            if (txtSaludo.Text != string.Empty)
            {
                empresa.Saludo = txtSaludo.Text;
            }
            else
            {
                empresa.Saludo = "";
            }
            if (txtSlogan.Text != string.Empty)
            {
                empresa.Slogan = txtSlogan.Text;
            }
            else
            {
                empresa.Slogan = "";
            }
            if (txtTelefono.Text != string.Empty)
            {
                empresa.Telefono = txtTelefono.Text;
            }
            else
            {
                empresa.Telefono = "";
            }
            if (txtNRC.Text != string.Empty)
            {
                empresa.NRC1 = txtNRC.Text;
            }
            else
            {
                empresa.NRC1 = "";
            }
            if (txtNIT.Text != string.Empty)
            {
                empresa.NIT1 = txtNIT.Text;
            }
            else
            {
                empresa.NIT1 = "";
            }
            if (txtAutorizacionTicket.Text != string.Empty)
            {
                empresa.NumAutorizacion = txtAutorizacionTicket.Text;
            }
            else
            {
                empresa.NumAutorizacion = "";
            }

            if (empresa.Actualizar())
            {
                MessageBox.Show("¡Cambios actualizados exitosamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatosEmpresa();
                this.Focus();
            }
        }

        private void btnGuardarOpT_Click(object sender, EventArgs e)
        {
            Mantenimiento.CLS.Ticket ticket = new Mantenimiento.CLS.Ticket();
            ticket.IdTicket = 1;
            if (chkMostrarEmpresa.Checked)
            {
                ticket.ShowEmpresa = true;
            }
            else
            {
                ticket.ShowEmpresa = false;
            }
            if (chkMostrarSlogan.Checked)
            {
                ticket.ShowSlogan = true;
            }
            else
            {
                ticket.ShowSlogan = false;
            }
            if (chkMostrarDireccion.Checked)
            {
                ticket.ShowDireccion = true;
            }
            else
            {
                ticket.ShowDireccion = false;
            }
            if (chkMostrarSaludo.Checked)
            {
                ticket.ShowSaludo = true;
            }
            else
            {
                ticket.ShowSaludo = false;
            }
            if (chkMostrarTel.Checked)
            {
                ticket.ShowTelefono = true;
            }
            else
            {
                ticket.ShowTelefono = false;
            }
            if (chkMostrarNIT.Checked)
            {
                ticket.ShowNIT = true;
            }
            else
            {
                ticket.ShowNIT = false;
            }
            if (chkMostrarNCR.Checked)
            {
                ticket.ShowNRC = true;
            }
            else
            {
                ticket.ShowNRC = false;
            }
            if (chkMostrarNumAutorizacion.Checked)
            {
                ticket.NumAutorizacion = true;
            }
            else
            {
                ticket.NumAutorizacion = false;
            }
            if (chkAgregarLinea.Checked)
            {
                ticket.ExtraLine = true;
            }
            else
            {
                ticket.ExtraLine = false;
            }
            if (txtEncabezado1.Text != string.Empty )
            {
                ticket.Header1 = txtEncabezado1.Text;
            }
            if (txtEncabezado2.Text != string.Empty)
            {
                ticket.Header2 = txtEncabezado2.Text;
            }
            if (txtEncabezado3.Text != string.Empty)
            {
                ticket.Header3 = txtEncabezado3.Text;
            }
            if (txtPie1.Text != string.Empty)
            {
                ticket.Footer1 = txtPie1.Text;
            }
            if (txtPie2.Text != string.Empty)
            {
                ticket.Footer2 = txtPie2.Text;
            }
            if (txtPie3.Text != string.Empty)
            {
                ticket.Footer3 = txtPie3.Text;
            }
            if (txtSecuenciaP.Text != string.Empty)
            {
                ticket.SeCortePapel = txtSecuenciaP.Text;
            }

            if (!string.IsNullOrWhiteSpace(txtMargen.Text))
            {
                if (int.TryParse(txtMargen.Text, out int margen))
                {
                    ticket.LeftMargin = margen;
                }
                else
                {
                    MessageBox.Show("El valor en el campo no es un número válido.");
                }
            }
            else
            {
                ticket.LeftMargin = 0;
            }
            if (!string.IsNullOrWhiteSpace(txtNumCaracteres.Text))
            {
                if (int.TryParse(txtNumCaracteres.Text, out int numCaracteres))
                {
                    ticket.NCaracteres = numCaracteres;
                }
                else
                {
                    MessageBox.Show("El valor en el campo no es un número válido.");
                }
            }
            else
            {
                ticket.NCaracteres = 0;
            }

            if (ticket.Actualizar())
            {
                MessageBox.Show("¡Cambios actualizados exitosamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatosOpTicket();
                this.Focus();
            }
        }
        public static string SeleccionarImagen()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";
                openFileDialog.Title = "Seleccionar imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }

                return string.Empty;
            }
        }
        private void bttExaminarLogo_Click(object sender, EventArgs e)
        {
            string rutaImagen = SeleccionarImagen();

            if (!string.IsNullOrEmpty(rutaImagen))
            {
                string rutaFormateada = rutaImagen.Replace("\\", "\\\\");

                pBoxLogo.ImageLocation = rutaImagen;
                pBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;

                SeleccionarLogo = rutaFormateada;
            }
            else
            {
                //MessageBox.Show("No se seleccionó ninguna imagen.");
            }
        }

        private void bttExaminarFirma_Click(object sender, EventArgs e)
        {
            string rutaImagen = SeleccionarImagen();

            if (!string.IsNullOrEmpty(rutaImagen))
            {
                string rutaFormateada = rutaImagen.Replace("\\", "\\\\");

                pBoxFirma.ImageLocation = rutaImagen;
                pBoxFirma.SizeMode = PictureBoxSizeMode.Zoom;

                SeleccionarFirma = rutaFormateada;
            }
            else
            {
                //MessageBox.Show("No se seleccionó ninguna imagen.");
            }
        }

        private void bttExaminarSello_Click(object sender, EventArgs e)
        {
            string rutaImagen = SeleccionarImagen();

            if (!string.IsNullOrEmpty(rutaImagen))
            {
                string rutaFormateada = rutaImagen.Replace("\\", "\\\\");

                pBoxSello.ImageLocation = rutaImagen;
                pBoxSello.SizeMode = PictureBoxSizeMode.Zoom;

                SeleccionarSello = rutaFormateada;
            }
            else
            {
                //MessageBox.Show("No se seleccionó ninguna imagen.");
            }
        }

        private void checkActivarPropina_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionDatos();
        }

        private void checkActivarIVip_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionDatos();
        }

        private void checkActivarIva_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionDatos();
        }

        private void checkMultiSe_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionDatos();
        }

        private void txtPropinas_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un número, un punto decimal o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Evita que se ingrese el carácter no permitido
            }

            // Verificar si ya se ha ingresado un punto decimal y se intenta ingresar otro
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true; // Evita que se ingrese el segundo punto decimal
            }
        }

        private void txtImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un número, un punto decimal o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Evita que se ingrese el carácter no permitido
            }

            // Verificar si ya se ha ingresado un punto decimal y se intenta ingresar otro
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true; // Evita que se ingrese el segundo punto decimal
            }
        }

        private void txtImpuestoVIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un número, un punto decimal o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Evita que se ingrese el carácter no permitido
            }

            // Verificar si ya se ha ingresado un punto decimal y se intenta ingresar otro
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true; // Evita que se ingrese el segundo punto decimal
            }
        }

        private void txtMultiSe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMargen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumCaracteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
