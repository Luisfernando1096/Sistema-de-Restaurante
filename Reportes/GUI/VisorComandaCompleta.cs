﻿using CrystalDecisions.CrystalReports.Engine;
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
    public partial class VisorComandaCompleta : Form
    {
        public VisorComandaCompleta()
        {
            InitializeComponent();
        }

        private void CargarReporte()
        {
            DataTable datos = new DataTable();
            REP.RepVentasAgrupadoPorProducto oReporte = new REP.RepVentasAgrupadoPorProducto();
            datos = DataManager.DBConsultas.RepVentasAgrupadasPorProducto("", "");
            oReporte.SetDataSource(datos);
            crvVisor.ReportSource = oReporte;
        }

        private void VisorComandaCompleta_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
