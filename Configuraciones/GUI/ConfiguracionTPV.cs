﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Configuraciones.GUI
{
    public partial class ConfiguracionTPV : Form
    {
        private String SeleccionarLogo = string.Empty;
        private String SeleccionarFirma = string.Empty;
        private String SeleccionarSello = string.Empty;
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;
        private string selectedImagePathFirma, selectedImagePathLogo, selectedImagePathSello;
        private string destinationPathFirma, destinationPathLogo, destinationPathSello;
        String seleccionLogoAnterior;
        String seleccionFirmaAnterior;
        String seleccionSelloAnterior;

        private void CargarDatosConfig()
        {
            try
            {
                if (oConfiguracion != null)
                {
                    // Asigna valores a los CheckBoxes
                    checkActivarInventario.Checked = Boolean.Parse(oConfiguracion.ControlStock);
                    checkActivarPropina.Checked = Boolean.Parse(oConfiguracion.IncluirPropina);
                    checkActivarIva.Checked = Boolean.Parse(oConfiguracion.IncluirImpuesto);
                    checkActivarAlerta.Checked = Boolean.Parse(oConfiguracion.AlertaCaja);
                    checkMultiSe.Checked = Boolean.Parse(oConfiguracion.Multisesion);
                    checkMuchosPro.Checked = Boolean.Parse(oConfiguracion.MuchosProductos);
                    checkAutorizacion.Checked = Boolean.Parse(oConfiguracion.AutorizarDescProp);
                    if (Boolean.Parse(oConfiguracion.IncluirImpuesto))
                    {
                        checkActivarIVip.Checked = true;
                    }
                    else
                    {
                        checkActivarIVip.Checked = false;
                    }

                    txtPropinas.Text = oConfiguracion.Propina.ToString();
                    txtImpuesto.Text = oConfiguracion.Iva.ToString();
                    txtImpuestoVIP.Text = oConfiguracion.MesaVIP.ToString();
                    txtMultiSe.Text = oConfiguracion.NumSesiones.ToString();

                    // Configura los ComboBox para mostrar la opción que coincide con el valor del campo en la base de datos
                    cmbComandas.SelectedIndex = cmbComandas.FindStringExact((oConfiguracion.PrinterComanda).ToString());
                    cmbFacturas.SelectedIndex = cmbFacturas.FindStringExact((oConfiguracion.PrinterFactura).ToString());
                    cmbInformes.SelectedIndex = cmbInformes.FindStringExact((oConfiguracion.PrinterInformes).ToString());

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
                    SeleccionarLogo = configuracionRow["logo"].ToString();
                    seleccionLogoAnterior = configuracionRow["logo"].ToString();//Establezco cual era la imagen anterior
                    SeleccionarFirma = configuracionRow["firma"].ToString();
                    seleccionFirmaAnterior = configuracionRow["firma"].ToString();
                    SeleccionarSello = configuracionRow["sello"].ToString();
                    seleccionSelloAnterior = configuracionRow["sello"].ToString();

                    if (!string.IsNullOrEmpty(SeleccionarLogo))
                    {
                        // Obtén la ruta de la imagen en la carpeta "Images" en el directorio de salida
                        string imagePathInOutput = Path.Combine("Configuraciones", "Images", SeleccionarLogo);

                        // Obten la ruta del directorio de salida de la aplicación
                        string outputPath = AppDomain.CurrentDomain.BaseDirectory;
                        string projectDirectory = Path.GetFullPath(Path.Combine(outputPath, @"..\..\..\"));
                        string fullPath = Path.Combine(projectDirectory, imagePathInOutput);

                        if (File.Exists(fullPath))
                        {
                            // Carga la imagen desde la ruta en el directorio de salida
                            Image originalImage = Image.FromFile(fullPath);
                            pBoxLogo.Image = originalImage;
                        }
                        else
                        {
                            //MessageBox.Show("¡La imagen no se encontró, se recomienda agregar una nueva imagen para tener una mejor experiencia!", "Error al buscar imagen del producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        //MessageBox.Show("La imagen no se encontró en la ruta especificada.");
                    }

                    if (!string.IsNullOrEmpty(SeleccionarFirma))
                    {
                        // Obtén la ruta de la imagen en la carpeta "Images" en el directorio de salida
                        string imagePathInOutput = Path.Combine("Configuraciones", "Images", SeleccionarFirma);

                        // Obten la ruta del directorio de salida de la aplicación
                        string outputPath = AppDomain.CurrentDomain.BaseDirectory;
                        string projectDirectory = Path.GetFullPath(Path.Combine(outputPath, @"..\..\..\"));
                        string fullPath = Path.Combine(projectDirectory, imagePathInOutput);

                        if (File.Exists(fullPath))
                        {
                            // Carga la imagen desde la ruta en el directorio de salida
                            Image originalImage = Image.FromFile(fullPath);
                            pBoxFirma.Image = originalImage;
                        }
                        else
                        {
                            //MessageBox.Show("¡La imagen no se encontró, se recomienda agregar una nueva imagen para tener una mejor experiencia!", "Error al buscar imagen del producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("La imagen no se encontró en la ruta especificada.");
                    }

                    if (!string.IsNullOrEmpty(SeleccionarSello))
                    {
                        // Obtén la ruta de la imagen en la carpeta "Images" en el directorio de salida
                        string imagePathInOutput = Path.Combine("Configuraciones", "Images", SeleccionarSello);

                        // Obten la ruta del directorio de salida de la aplicación
                        string outputPath = AppDomain.CurrentDomain.BaseDirectory;
                        string projectDirectory = Path.GetFullPath(Path.Combine(outputPath, @"..\..\..\"));
                        string fullPath = Path.Combine(projectDirectory, imagePathInOutput);

                        if (File.Exists(fullPath))
                        {
                            // Carga la imagen desde la ruta en el directorio de salida
                            Image originalImage = Image.FromFile(fullPath);
                            pBoxSello.Image = originalImage;
                        }
                        else
                        {
                            //MessageBox.Show("¡La imagen no se encontró, se recomienda agregar una nueva imagen para tener una mejor experiencia!", "Error al buscar imagen del producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
                }
                else
                {
                    config.IncluirPropina = 0;
                }
                config.Propina = double.Parse(txtPropinas.Text);

                //Iva
                if (checkActivarIva.Checked)
                {
                    config.IncluirImpuesto = 1;
                }
                else
                {
                    config.IncluirImpuesto = 0;
                }
                config.Iva = double.Parse(txtImpuesto.Text);

                //Mesa Vip
                if (checkActivarIVip.Checked)
                {
                    config.MesaVIP = double.Parse(txtImpuestoVIP.Text);
                }
                else
                {
                    config.MesaVIP = double.Parse(txtImpuestoVIP.Text);
                }
                

                //Multisesiones
                if (checkMultiSe.Checked)
                {
                    config.Multisesion = 1;
                }
                else
                {
                    config.Multisesion = 0;
                }
                config.NumSesiones = int.Parse(txtMultiSe.Text);
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
                    oConfiguracion.ObtenerConfiguracion();
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
            try
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
                    //Aqui se guardara la imagen
                    if (!seleccionLogoAnterior.Equals(SeleccionarLogo))
                    {
                        // Obten la ruta del directorio de salida de la aplicación
                        string outputPath = AppDomain.CurrentDomain.BaseDirectory;
                        string projectDirectory = Path.GetFullPath(Path.Combine(outputPath, @"..\..\..\"));

                        // Ahora tienes la ruta del directorio base de tu proyecto
                        string imagesDirectory = Path.Combine(projectDirectory, "Configuraciones", "Images");

                        // Copia la imagen seleccionada a una ubicación en tu proyecto
                        destinationPathLogo = Path.Combine(imagesDirectory, Path.GetFileName(selectedImagePathLogo));

                        if (!File.Exists(destinationPathLogo))
                        {
                            // El archivo no existe, puedes proceder con la insercion
                            File.Copy(selectedImagePathLogo, destinationPathLogo);
                        }
                        // Continúa con el resto de tu lógica
                    }

                    //Aqui se guardara la imagen
                    if (!seleccionFirmaAnterior.Equals(SeleccionarFirma))
                    {
                        // Obten la ruta del directorio de salida de la aplicación
                        string outputPath = AppDomain.CurrentDomain.BaseDirectory;
                        string projectDirectory = Path.GetFullPath(Path.Combine(outputPath, @"..\..\..\"));

                        // Ahora tienes la ruta del directorio base de tu proyecto
                        string imagesDirectory = Path.Combine(projectDirectory, "Configuraciones", "Images");

                        // Copia la imagen seleccionada a una ubicación en tu proyecto
                        destinationPathFirma = Path.Combine(imagesDirectory, Path.GetFileName(selectedImagePathFirma));

                        if (!File.Exists(destinationPathFirma))
                        {
                            // El archivo no existe, puedes proceder con la insercion
                            File.Copy(selectedImagePathFirma, destinationPathFirma);
                        }
                        // Continúa con el resto de tu lógica
                    }

                    if (!seleccionSelloAnterior.Equals(SeleccionarSello))
                    {
                        // Obten la ruta del directorio de salida de la aplicación
                        string outputPath = AppDomain.CurrentDomain.BaseDirectory;
                        string projectDirectory = Path.GetFullPath(Path.Combine(outputPath, @"..\..\..\"));

                        // Ahora tienes la ruta del directorio base de tu proyecto
                        string imagesDirectory = Path.Combine(projectDirectory, "Configuraciones", "Images");

                        // Copia la imagen seleccionada a una ubicación en tu proyecto
                        destinationPathSello = Path.Combine(imagesDirectory, Path.GetFileName(selectedImagePathSello));

                        if (!File.Exists(destinationPathSello))
                        {
                            // El archivo no existe, puedes proceder con la insercion
                            File.Copy(selectedImagePathSello, destinationPathSello);
                        }
                        // Continúa con el resto de tu lógica
                    }
                    CargarDatosEmpresa();

                    this.Focus();
                }
                oEmpresa.ObtenerConfiguracion();
            }
            catch (Exception)
            {
                throw;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // El usuario seleccionó una imagen
                selectedImagePathLogo = openFileDialog.FileName;

                try
                {
                    if (!Path.GetFileName(selectedImagePathLogo).Equals(SeleccionarLogo))
                    {
                        SeleccionarLogo = Path.GetFileName(selectedImagePathLogo);

                        // Carga la imagen desde la ruta en el directorio de salida
                        Image originalImage = Image.FromFile(selectedImagePathLogo);
                        pBoxLogo.Image = originalImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al copiar la imagen: " + ex.Message);
                }
            }
        }

        private void bttExaminarFirma_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // El usuario seleccionó una imagen
                selectedImagePathFirma = openFileDialog.FileName;

                try
                {
                    if (!Path.GetFileName(selectedImagePathFirma).Equals(SeleccionarFirma))
                    {
                        SeleccionarFirma = Path.GetFileName(selectedImagePathFirma);

                        // Carga la imagen desde la ruta en el directorio de salida
                        Image originalImage = Image.FromFile(selectedImagePathFirma);
                        pBoxFirma.Image = originalImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al copiar la imagen: " + ex.Message);
                }

            }
        }

        private void bttExaminarSello_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // El usuario seleccionó una imagen
                selectedImagePathSello = openFileDialog.FileName;

                try
                {
                    if (!Path.GetFileName(selectedImagePathSello).Equals(SeleccionarSello))
                    {
                        SeleccionarSello = Path.GetFileName(selectedImagePathSello);

                        // Carga la imagen desde la ruta en el directorio de salida
                        Image originalImage = Image.FromFile(selectedImagePathSello);
                        pBoxSello.Image = originalImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al copiar la imagen: " + ex.Message);
                }
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
