﻿using System;
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
    public partial class CantidadProductos : Form
    {
        public CantidadProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtCantidad.Text.Equals("") || txtCantidad.Text.Equals("0"))
            {
                MessageBox.Show("Debe ingresar la cantidad de productos. Por favor, ingrese un valor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Close();
        }
    }
}
