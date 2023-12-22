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
                
            }
            else if(opc == 2) //Reporte de proveedores
            {
                
            }
            else if (opc == 3) //Reporte de stock de productos
            {
                
            }
            else if (opc == 4) //Reporte de entas por fechas
            {
                if (FechaInicio != string.Empty && FechaFinal != string.Empty)
                {
                    
                }
            }
        }
        private void crvVisor_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
