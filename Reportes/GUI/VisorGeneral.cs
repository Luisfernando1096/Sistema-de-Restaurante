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
        public int opc { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }

        public VisorGeneral()
        {
            InitializeComponent();
        }

        private void CargarReporte()
        {
            DataTable datos = new DataTable();

            if (opc == 1) //Reporte de clientes
            {
                REP.RepClientes oReporte = new REP.RepClientes();
                datos = DataManager.DBConsultas.Clientes();
                oReporte.SetDataSource(datos);
                oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
                oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
                crvVisor.ReportSource = oReporte;
            }
            else if(opc == 2) //Reporte de proveedores
            {
                REP.RepProveedores oReporte = new REP.RepProveedores();
                datos = DataManager.DBConsultas.Proveedor();
                oReporte.SetDataSource(datos);
                oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
                oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
                crvVisor.ReportSource = oReporte;
            }
            else if (opc == 3) //Reporte de stock de productos
            {
                REP.RepStockProducto oReporte = new REP.RepStockProducto();
                datos = DataManager.DBConsultas.VerProductos();
                oReporte.SetDataSource(datos);
                oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
                oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
                crvVisor.ReportSource = oReporte;
            }
            else if (opc == 4) //Reporte de entas por fechas
            {
                if (FechaInicio != string.Empty && FechaFinal != string.Empty)
                {
                    REP.RepVentasPorFechas oReporte = new REP.RepVentasPorFechas();
                    datos = DataManager.DBConsultas.VentasPorfecha(FechaInicio, FechaFinal);
                    oReporte.SetDataSource(datos);
                    oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
                    oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
                    oReporte.SetParameterValue("FechaInicio", FechaInicio);
                    oReporte.SetParameterValue("FechaFinal", FechaFinal);
                    crvVisor.ReportSource = oReporte;
                }
            }
        }
        private void crvVisor_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
