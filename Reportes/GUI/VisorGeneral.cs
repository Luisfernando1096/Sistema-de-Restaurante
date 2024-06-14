using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
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
                    
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones: muestra un mensaje de error en caso de problemas
                    this.Invoke((MethodInvoker)delegate
                    {
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
            
        }
    }
}
