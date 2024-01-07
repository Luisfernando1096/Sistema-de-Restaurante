using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.GUI
{
    public partial class VisorGeneral : Form
    {
        ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;
        ConfiguracionManager.CLS.Ticket oTicket = ConfiguracionManager.CLS.Ticket.Instancia;
        private ReportDocument reporteActual;

        public VisorGeneral()
        {
            InitializeComponent();
        }

        public void GenerarReporte(ReportClass oReporte, DataTable datos, string fi, string ff, string f)
        {
            oReporte.SetDataSource(datos);
            oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
            if (!f.Equals(""))
            {
                // Convertir la cadena a DateTime
                if (DateTime.TryParse(f, out DateTime fecha))
                {
                    // Formatear la fecha
                    string fechaFormateada = fecha.ToString("dd-MM-yyyy");

                    oReporte.SetParameterValue("Fecha", fechaFormateada);
                }
                else
                {
                    Console.WriteLine("La cadena no es un formato de fecha válido.");
                }

            }
            if (!fi.Equals(""))
            {
                // Convertir la cadena a DateTime
                if (DateTime.TryParse(fi, out DateTime fecha))
                {
                    // Formatear la fecha
                    string fechaFormateada = fecha.ToString("dd-MM-yyyy");

                    oReporte.SetParameterValue("fInicio", fechaFormateada);
                }
                else
                {
                    Console.WriteLine("La cadena no es un formato de fecha válido.");
                }
            }
            if (!ff.Equals(""))
            {
                // Convertir la cadena a DateTime
                if (DateTime.TryParse(ff, out DateTime fecha))
                {
                    // Formatear la fecha
                    string fechaFormateada = fecha.ToString("dd-MM-yyyy");

                    oReporte.SetParameterValue("fFin", fechaFormateada);
                }
                else
                {
                    Console.WriteLine("La cadena no es un formato de fecha válido.");
                }
            }
            if (Boolean.Parse(oTicket.ShowSlogan))
            {
                oReporte.SetParameterValue("Footer", oEmpresa.Slogan);
            }
            else
            {
                oReporte.SetParameterValue("Footer", "");
            }

            if (oReporte != null)
            {
                try
                {
                    this.reporteActual = oReporte;
                    //// Imprimir el informe en la impresora seleccionada
                    //PrinterSettings settings = new PrinterSettings
                    //{
                    //    PrinterName = oConfiguracion.PrinterInformes
                    //};

                    //oReporte.PrintOptions.PrinterName = settings.PrinterName;
                    //oReporte.PrintToPrinter(1, false, 0, 0);

                    //// Muestra un mensaje de éxito en el hilo de la interfaz de usuario
                    //this.Invoke((MethodInvoker)delegate {
                    //    MessageBox.Show($"Finalizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //});
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones: muestra un mensaje de error en caso de problemas
                    this.Invoke((MethodInvoker)delegate {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            }
        }

        private void crvVisor_Load(object sender, EventArgs e)
        {
            if (reporteActual != null && crvVisor != null)
            {
                crvVisor.ReportSource = reporteActual;
            }
            else
            {
                MessageBox.Show("Error: reporteActual o crvVisor es nulo.");
            }
        }
    }
}
