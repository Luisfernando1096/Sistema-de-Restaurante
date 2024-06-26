﻿
using System.Windows.Forms;

namespace TPV.GUI
{
    partial class PuntoPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuntoPago));
            this.lblMesa = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblMesero = new System.Windows.Forms.Label();
            this.lblTicket = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cocinando = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreMesero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnFactura = new System.Windows.Forms.Button();
            this.btnTicket = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnMuchos = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.chkExento = new System.Windows.Forms.CheckBox();
            this.cbPropina = new System.Windows.Forms.CheckBox();
            this.cbDescuento = new System.Windows.Forms.CheckBox();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.flpDinero = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUno = new System.Windows.Forms.Button();
            this.btnDos = new System.Windows.Forms.Button();
            this.btnCinco = new System.Windows.Forms.Button();
            this.btnDiez = new System.Windows.Forms.Button();
            this.btnVeinte = new System.Windows.Forms.Button();
            this.btnCincuenta = new System.Windows.Forms.Button();
            this.btnCien = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblPropina = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPagoRegistrar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.btnEfectivo = new System.Windows.Forms.Button();
            this.btnTarjeta = new System.Windows.Forms.Button();
            this.btnExacto = new System.Windows.Forms.Button();
            this.btnCortesia = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnPunto = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCambio = new System.Windows.Forms.Label();
            this.btnCuentas = new System.Windows.Forms.Button();
            this.tFecha = new System.Windows.Forms.Timer(this.components);
            this.btnBtc = new System.Windows.Forms.Button();
            this.lble1 = new System.Windows.Forms.Label();
            this.lblExento = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblConexionRed = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConexionGreen = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.flpAcciones.SuspendLayout();
            this.flpDinero.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesa.Location = new System.Drawing.Point(209, 64);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(0, 23);
            this.lblMesa.TabIndex = 23;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(209, 84);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(0, 23);
            this.lblCliente.TabIndex = 22;
            // 
            // lblMesero
            // 
            this.lblMesero.AutoSize = true;
            this.lblMesero.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesero.Location = new System.Drawing.Point(209, 104);
            this.lblMesero.Name = "lblMesero";
            this.lblMesero.Size = new System.Drawing.Size(0, 23);
            this.lblMesero.TabIndex = 21;
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicket.Location = new System.Drawing.Point(209, 44);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(0, 23);
            this.lblTicket.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(143, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Mesa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(143, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(143, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mesero:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ticket # ";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Snow;
            this.dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cantidad,
            this.idDetalle,
            this.idPedido,
            this.idProducto,
            this.precio,
            this.fecha,
            this.nombre,
            this.subTotal,
            this.grupo,
            this.cocinando,
            this.nombreMesero,
            this.nombres,
            this.mesa,
            this.salon});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.Location = new System.Drawing.Point(140, 139);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(359, 315);
            this.dgvDatos.TabIndex = 15;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // idDetalle
            // 
            this.idDetalle.DataPropertyName = "idDetalle";
            this.idDetalle.HeaderText = "ID";
            this.idDetalle.Name = "idDetalle";
            this.idDetalle.ReadOnly = true;
            this.idDetalle.Visible = false;
            // 
            // idPedido
            // 
            this.idPedido.DataPropertyName = "idPedido";
            this.idPedido.HeaderText = "Id Pedido";
            this.idPedido.Name = "idPedido";
            this.idPedido.ReadOnly = true;
            this.idPedido.Visible = false;
            // 
            // idProducto
            // 
            this.idProducto.DataPropertyName = "idProducto";
            this.idProducto.HeaderText = "Id Producto";
            this.idProducto.Name = "idProducto";
            this.idProducto.ReadOnly = true;
            this.idProducto.Visible = false;
            // 
            // precio
            // 
            this.precio.DataPropertyName = "precio";
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Visible = false;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Visible = false;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Producto";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // subTotal
            // 
            this.subTotal.DataPropertyName = "subTotal";
            this.subTotal.HeaderText = "Sub Total";
            this.subTotal.Name = "subTotal";
            this.subTotal.ReadOnly = true;
            // 
            // grupo
            // 
            this.grupo.DataPropertyName = "grupo";
            this.grupo.HeaderText = "Grupo";
            this.grupo.Name = "grupo";
            this.grupo.ReadOnly = true;
            this.grupo.Visible = false;
            // 
            // cocinando
            // 
            this.cocinando.DataPropertyName = "cocinando";
            this.cocinando.HeaderText = "Cocinando";
            this.cocinando.Name = "cocinando";
            this.cocinando.ReadOnly = true;
            this.cocinando.Visible = false;
            // 
            // nombreMesero
            // 
            this.nombreMesero.DataPropertyName = "nombreMesero";
            this.nombreMesero.HeaderText = "Mesero";
            this.nombreMesero.Name = "nombreMesero";
            this.nombreMesero.ReadOnly = true;
            this.nombreMesero.Visible = false;
            // 
            // nombres
            // 
            this.nombres.DataPropertyName = "nombres";
            this.nombres.HeaderText = "Cliente";
            this.nombres.Name = "nombres";
            this.nombres.ReadOnly = true;
            this.nombres.Visible = false;
            // 
            // mesa
            // 
            this.mesa.DataPropertyName = "mesa";
            this.mesa.HeaderText = "Mesa";
            this.mesa.Name = "mesa";
            this.mesa.ReadOnly = true;
            this.mesa.Visible = false;
            // 
            // salon
            // 
            this.salon.DataPropertyName = "salon";
            this.salon.HeaderText = "Salon";
            this.salon.Name = "salon";
            this.salon.ReadOnly = true;
            this.salon.Visible = false;
            // 
            // flpAcciones
            // 
            this.flpAcciones.AutoScroll = true;
            this.flpAcciones.Controls.Add(this.btnCliente);
            this.flpAcciones.Controls.Add(this.btnFactura);
            this.flpAcciones.Controls.Add(this.btnTicket);
            this.flpAcciones.Controls.Add(this.button4);
            this.flpAcciones.Controls.Add(this.button5);
            this.flpAcciones.Controls.Add(this.btnMuchos);
            this.flpAcciones.Controls.Add(this.button6);
            this.flpAcciones.Controls.Add(this.chkExento);
            this.flpAcciones.Controls.Add(this.cbPropina);
            this.flpAcciones.Controls.Add(this.cbDescuento);
            this.flpAcciones.Controls.Add(this.txtPorcentaje);
            this.flpAcciones.Controls.Add(this.lblPorcentaje);
            this.flpAcciones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAcciones.Location = new System.Drawing.Point(10, 10);
            this.flpAcciones.Margin = new System.Windows.Forms.Padding(1);
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Size = new System.Drawing.Size(129, 653);
            this.flpAcciones.TabIndex = 14;
            this.flpAcciones.WrapContents = false;
            // 
            // btnCliente
            // 
            this.btnCliente.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnCliente.Image")));
            this.btnCliente.Location = new System.Drawing.Point(0, 0);
            this.btnCliente.Margin = new System.Windows.Forms.Padding(0);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(115, 80);
            this.btnCliente.TabIndex = 2;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnFactura
            // 
            this.btnFactura.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnFactura.Image")));
            this.btnFactura.Location = new System.Drawing.Point(0, 80);
            this.btnFactura.Margin = new System.Windows.Forms.Padding(0);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(115, 80);
            this.btnFactura.TabIndex = 1;
            this.btnFactura.Text = "Factura";
            this.btnFactura.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFactura.UseVisualStyleBackColor = true;
            this.btnFactura.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTicket
            // 
            this.btnTicket.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnTicket.Image")));
            this.btnTicket.Location = new System.Drawing.Point(0, 160);
            this.btnTicket.Margin = new System.Windows.Forms.Padding(0);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(115, 80);
            this.btnTicket.TabIndex = 0;
            this.btnTicket.Text = "Ticket";
            this.btnTicket.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTicket.UseVisualStyleBackColor = true;
            this.btnTicket.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(0, 240);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 80);
            this.button4.TabIndex = 3;
            this.button4.Text = "Regresar";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(0, 320);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 80);
            this.button5.TabIndex = 4;
            this.button5.Text = "Imprimir";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnMuchos
            // 
            this.btnMuchos.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuchos.Image = ((System.Drawing.Image)(resources.GetObject("btnMuchos.Image")));
            this.btnMuchos.Location = new System.Drawing.Point(0, 400);
            this.btnMuchos.Margin = new System.Windows.Forms.Padding(0);
            this.btnMuchos.Name = "btnMuchos";
            this.btnMuchos.Size = new System.Drawing.Size(115, 80);
            this.btnMuchos.TabIndex = 45;
            this.btnMuchos.Text = "Muchos";
            this.btnMuchos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMuchos.UseVisualStyleBackColor = true;
            this.btnMuchos.Click += new System.EventHandler(this.btnMuchos_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(0, 480);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(115, 80);
            this.button6.TabIndex = 8;
            this.button6.Text = "Cerrar Sesion";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // chkExento
            // 
            this.chkExento.AutoSize = true;
            this.chkExento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExento.Location = new System.Drawing.Point(3, 563);
            this.chkExento.Name = "chkExento";
            this.chkExento.Size = new System.Drawing.Size(87, 20);
            this.chkExento.TabIndex = 10;
            this.chkExento.Text = "Exento Iva";
            this.chkExento.UseVisualStyleBackColor = true;
            this.chkExento.CheckedChanged += new System.EventHandler(this.chkExento_CheckedChanged);
            this.chkExento.Click += new System.EventHandler(this.chkExento_Click);
            // 
            // cbPropina
            // 
            this.cbPropina.AutoSize = true;
            this.cbPropina.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPropina.Location = new System.Drawing.Point(3, 589);
            this.cbPropina.Name = "cbPropina";
            this.cbPropina.Size = new System.Drawing.Size(92, 20);
            this.cbPropina.TabIndex = 6;
            this.cbPropina.Text = "Sin propina";
            this.cbPropina.UseVisualStyleBackColor = true;
            this.cbPropina.CheckedChanged += new System.EventHandler(this.cbPropina_CheckedChanged);
            this.cbPropina.Click += new System.EventHandler(this.cbPropina_Click_1);
            // 
            // cbDescuento
            // 
            this.cbDescuento.AutoSize = true;
            this.cbDescuento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDescuento.Location = new System.Drawing.Point(3, 615);
            this.cbDescuento.Name = "cbDescuento";
            this.cbDescuento.Size = new System.Drawing.Size(116, 20);
            this.cbDescuento.TabIndex = 7;
            this.cbDescuento.Text = "Con Descuento";
            this.cbDescuento.UseVisualStyleBackColor = true;
            this.cbDescuento.CheckedChanged += new System.EventHandler(this.cbDescuento_CheckedChanged);
            this.cbDescuento.Click += new System.EventHandler(this.cbDescuento_Click);
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentaje.Location = new System.Drawing.Point(3, 641);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(112, 26);
            this.txtPorcentaje.TabIndex = 9;
            this.txtPorcentaje.Visible = false;
            this.txtPorcentaje.TextChanged += new System.EventHandler(this.txtPorcentaje_TextChanged);
            this.txtPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentaje_KeyPress);
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.Location = new System.Drawing.Point(3, 670);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(112, 51);
            this.lblPorcentaje.TabIndex = 9;
            this.lblPorcentaje.Text = "Digite el porcentaje de descuento.";
            this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPorcentaje.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(209, 9);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 23);
            this.lblFecha.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(143, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Fecha:";
            // 
            // flpDinero
            // 
            this.flpDinero.AutoScroll = true;
            this.flpDinero.Controls.Add(this.btnUno);
            this.flpDinero.Controls.Add(this.btnDos);
            this.flpDinero.Controls.Add(this.btnCinco);
            this.flpDinero.Controls.Add(this.btnDiez);
            this.flpDinero.Controls.Add(this.btnVeinte);
            this.flpDinero.Controls.Add(this.btnCincuenta);
            this.flpDinero.Controls.Add(this.btnCien);
            this.flpDinero.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDinero.Location = new System.Drawing.Point(506, 68);
            this.flpDinero.Margin = new System.Windows.Forms.Padding(1);
            this.flpDinero.Name = "flpDinero";
            this.flpDinero.Size = new System.Drawing.Size(249, 595);
            this.flpDinero.TabIndex = 26;
            this.flpDinero.WrapContents = false;
            // 
            // btnUno
            // 
            this.btnUno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUno.BackgroundImage")));
            this.btnUno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUno.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUno.Location = new System.Drawing.Point(2, 2);
            this.btnUno.Margin = new System.Windows.Forms.Padding(2);
            this.btnUno.Name = "btnUno";
            this.btnUno.Size = new System.Drawing.Size(240, 80);
            this.btnUno.TabIndex = 0;
            this.btnUno.Tag = "1";
            this.btnUno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUno.UseVisualStyleBackColor = true;
            this.btnUno.Click += new System.EventHandler(this.btnUno_Click);
            // 
            // btnDos
            // 
            this.btnDos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDos.BackgroundImage")));
            this.btnDos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDos.Location = new System.Drawing.Point(2, 86);
            this.btnDos.Margin = new System.Windows.Forms.Padding(2);
            this.btnDos.Name = "btnDos";
            this.btnDos.Size = new System.Drawing.Size(240, 80);
            this.btnDos.TabIndex = 3;
            this.btnDos.Tag = "2";
            this.btnDos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDos.UseVisualStyleBackColor = true;
            this.btnDos.Click += new System.EventHandler(this.btnDos_Click);
            // 
            // btnCinco
            // 
            this.btnCinco.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCinco.BackgroundImage")));
            this.btnCinco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCinco.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCinco.Location = new System.Drawing.Point(2, 170);
            this.btnCinco.Margin = new System.Windows.Forms.Padding(2);
            this.btnCinco.Name = "btnCinco";
            this.btnCinco.Size = new System.Drawing.Size(240, 80);
            this.btnCinco.TabIndex = 4;
            this.btnCinco.Tag = "5";
            this.btnCinco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCinco.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCinco.UseVisualStyleBackColor = true;
            this.btnCinco.Click += new System.EventHandler(this.btnCinco_Click);
            // 
            // btnDiez
            // 
            this.btnDiez.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDiez.BackgroundImage")));
            this.btnDiez.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDiez.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiez.Location = new System.Drawing.Point(2, 254);
            this.btnDiez.Margin = new System.Windows.Forms.Padding(2);
            this.btnDiez.Name = "btnDiez";
            this.btnDiez.Size = new System.Drawing.Size(240, 80);
            this.btnDiez.TabIndex = 5;
            this.btnDiez.Tag = "10";
            this.btnDiez.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDiez.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDiez.UseVisualStyleBackColor = true;
            this.btnDiez.Click += new System.EventHandler(this.btnDiez_Click);
            // 
            // btnVeinte
            // 
            this.btnVeinte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVeinte.BackgroundImage")));
            this.btnVeinte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVeinte.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeinte.Location = new System.Drawing.Point(2, 338);
            this.btnVeinte.Margin = new System.Windows.Forms.Padding(2);
            this.btnVeinte.Name = "btnVeinte";
            this.btnVeinte.Size = new System.Drawing.Size(240, 80);
            this.btnVeinte.TabIndex = 3;
            this.btnVeinte.Tag = "20";
            this.btnVeinte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVeinte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVeinte.UseVisualStyleBackColor = true;
            this.btnVeinte.Click += new System.EventHandler(this.btnVeinte_Click);
            // 
            // btnCincuenta
            // 
            this.btnCincuenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCincuenta.BackgroundImage")));
            this.btnCincuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCincuenta.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCincuenta.Location = new System.Drawing.Point(2, 422);
            this.btnCincuenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnCincuenta.Name = "btnCincuenta";
            this.btnCincuenta.Size = new System.Drawing.Size(240, 80);
            this.btnCincuenta.TabIndex = 0;
            this.btnCincuenta.Tag = "50";
            this.btnCincuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCincuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCincuenta.UseVisualStyleBackColor = true;
            this.btnCincuenta.Click += new System.EventHandler(this.btnCincuenta_Click);
            // 
            // btnCien
            // 
            this.btnCien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCien.BackgroundImage")));
            this.btnCien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCien.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCien.Location = new System.Drawing.Point(2, 506);
            this.btnCien.Margin = new System.Windows.Forms.Padding(2);
            this.btnCien.Name = "btnCien";
            this.btnCien.Size = new System.Drawing.Size(240, 80);
            this.btnCien.TabIndex = 6;
            this.btnCien.Tag = "100";
            this.btnCien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCien.UseVisualStyleBackColor = true;
            this.btnCien.Click += new System.EventHandler(this.btnCien_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Chartreuse;
            this.button8.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.Location = new System.Drawing.Point(540, 7);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(180, 57);
            this.button8.TabIndex = 27;
            this.button8.Text = "Pedidos Activos";
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva.Location = new System.Drawing.Point(244, 476);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(44, 18);
            this.lblIva.TabIndex = 35;
            this.lblIva.Tag = "0";
            this.lblIva.Text = "$0.00";
            // 
            // lblPropina
            // 
            this.lblPropina.AutoSize = true;
            this.lblPropina.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropina.Location = new System.Drawing.Point(244, 497);
            this.lblPropina.Name = "lblPropina";
            this.lblPropina.Size = new System.Drawing.Size(44, 18);
            this.lblPropina.TabIndex = 34;
            this.lblPropina.Tag = "0";
            this.lblPropina.Text = "$0.00";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(244, 517);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(44, 18);
            this.lblDescuento.TabIndex = 33;
            this.lblDescuento.Tag = "0";
            this.lblDescuento.Text = "$0.00";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(244, 455);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(44, 18);
            this.lblSaldo.TabIndex = 32;
            this.lblSaldo.Tag = "0";
            this.lblSaldo.Text = "$0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(146, 476);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "Iva:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(146, 497);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Propina:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(146, 517);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 17);
            this.label12.TabIndex = 29;
            this.label12.Text = "Descuento:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(146, 457);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 17);
            this.label13.TabIndex = 28;
            this.label13.Text = "Saldo:";
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.Location = new System.Drawing.Point(175, 582);
            this.button13.Margin = new System.Windows.Forms.Padding(2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(240, 73);
            this.button13.TabIndex = 36;
            this.button13.Text = "Ir a Punto de Venta";
            this.button13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPagar.Location = new System.Drawing.Point(765, 106);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.ReadOnly = true;
            this.txtTotalPagar.Size = new System.Drawing.Size(269, 48);
            this.txtTotalPagar.TabIndex = 38;
            this.txtTotalPagar.Text = "0";
            this.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(761, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 31);
            this.label5.TabIndex = 37;
            this.label5.Text = "Total a pagar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(844, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(332, 37);
            this.label6.TabIndex = 39;
            this.label6.Text = "REGISTRO DE PAGO";
            // 
            // txtPagoRegistrar
            // 
            this.txtPagoRegistrar.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagoRegistrar.Location = new System.Drawing.Point(765, 208);
            this.txtPagoRegistrar.Name = "txtPagoRegistrar";
            this.txtPagoRegistrar.Size = new System.Drawing.Size(269, 48);
            this.txtPagoRegistrar.TabIndex = 40;
            this.txtPagoRegistrar.Text = "0";
            this.txtPagoRegistrar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPagoRegistrar.TextChanged += new System.EventHandler(this.txtPagoRegistrar_TextChanged);
            this.txtPagoRegistrar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagoRegistrar_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(761, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 31);
            this.label7.TabIndex = 41;
            this.label7.Text = "Total a registrar";
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Image = ((System.Drawing.Image)(resources.GetObject("button14.Image")));
            this.button14.Location = new System.Drawing.Point(1085, 138);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(138, 118);
            this.button14.TabIndex = 42;
            this.button14.Text = "Limpiar";
            this.button14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEfectivo.Image = ((System.Drawing.Image)(resources.GetObject("btnEfectivo.Image")));
            this.btnEfectivo.Location = new System.Drawing.Point(1023, 340);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(200, 65);
            this.btnEfectivo.TabIndex = 43;
            this.btnEfectivo.Text = "Efectivo";
            this.btnEfectivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEfectivo.UseVisualStyleBackColor = true;
            this.btnEfectivo.Click += new System.EventHandler(this.btnEfectivo_Click);
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarjeta.Image = ((System.Drawing.Image)(resources.GetObject("btnTarjeta.Image")));
            this.btnTarjeta.Location = new System.Drawing.Point(1023, 409);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(200, 65);
            this.btnTarjeta.TabIndex = 44;
            this.btnTarjeta.Text = "Tarjeta";
            this.btnTarjeta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTarjeta.UseVisualStyleBackColor = true;
            this.btnTarjeta.Click += new System.EventHandler(this.btnTarjeta_Click);
            // 
            // btnExacto
            // 
            this.btnExacto.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExacto.Image = ((System.Drawing.Image)(resources.GetObject("btnExacto.Image")));
            this.btnExacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExacto.Location = new System.Drawing.Point(1023, 271);
            this.btnExacto.Name = "btnExacto";
            this.btnExacto.Size = new System.Drawing.Size(200, 65);
            this.btnExacto.TabIndex = 46;
            this.btnExacto.Text = "Pago exacto";
            this.btnExacto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExacto.UseVisualStyleBackColor = true;
            this.btnExacto.Click += new System.EventHandler(this.btnExacto_Click);
            // 
            // btnCortesia
            // 
            this.btnCortesia.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCortesia.Image = ((System.Drawing.Image)(resources.GetObject("btnCortesia.Image")));
            this.btnCortesia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCortesia.Location = new System.Drawing.Point(1025, 545);
            this.btnCortesia.Name = "btnCortesia";
            this.btnCortesia.Size = new System.Drawing.Size(200, 65);
            this.btnCortesia.TabIndex = 47;
            this.btnCortesia.Text = "Cortesia";
            this.btnCortesia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCortesia.UseVisualStyleBackColor = true;
            this.btnCortesia.Click += new System.EventHandler(this.btnCortesia_Click);
            // 
            // btn9
            // 
            this.btn9.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Location = new System.Drawing.Point(765, 271);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(80, 80);
            this.btn9.TabIndex = 48;
            this.btn9.Text = "9";
            this.btn9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btn8
            // 
            this.btn8.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Location = new System.Drawing.Point(851, 271);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(80, 80);
            this.btn8.TabIndex = 49;
            this.btn8.Text = "8";
            this.btn8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btn7
            // 
            this.btn7.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Location = new System.Drawing.Point(937, 271);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(80, 80);
            this.btn7.TabIndex = 50;
            this.btn7.Text = "7";
            this.btn7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(937, 357);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(80, 80);
            this.btn4.TabIndex = 53;
            this.btn4.Text = "4";
            this.btn4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn5
            // 
            this.btn5.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(851, 357);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(80, 80);
            this.btn5.TabIndex = 52;
            this.btn5.Text = "5";
            this.btn5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn6
            // 
            this.btn6.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Location = new System.Drawing.Point(765, 357);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(80, 80);
            this.btn6.TabIndex = 51;
            this.btn6.Text = "6";
            this.btn6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(939, 443);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(80, 80);
            this.btn1.TabIndex = 56;
            this.btn1.Text = "1";
            this.btn1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(853, 443);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(80, 80);
            this.btn2.TabIndex = 55;
            this.btn2.Text = "2";
            this.btn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(767, 443);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(80, 80);
            this.btn3.TabIndex = 54;
            this.btn3.Text = "3";
            this.btn3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btnC
            // 
            this.btnC.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnC.Location = new System.Drawing.Point(939, 529);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(80, 80);
            this.btnC.TabIndex = 59;
            this.btnC.Text = "c";
            this.btnC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btn0
            // 
            this.btn0.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Location = new System.Drawing.Point(853, 529);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(80, 80);
            this.btn0.TabIndex = 58;
            this.btn0.Text = "0";
            this.btn0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btnPunto
            // 
            this.btnPunto.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPunto.Location = new System.Drawing.Point(767, 529);
            this.btnPunto.Name = "btnPunto";
            this.btnPunto.Size = new System.Drawing.Size(80, 80);
            this.btnPunto.TabIndex = 57;
            this.btnPunto.Text = ".";
            this.btnPunto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPunto.UseVisualStyleBackColor = true;
            this.btnPunto.Click += new System.EventHandler(this.btnPunto_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(146, 541);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 60;
            this.label8.Text = "Cambio:";
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.Location = new System.Drawing.Point(245, 538);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(44, 18);
            this.lblCambio.TabIndex = 61;
            this.lblCambio.Tag = "0";
            this.lblCambio.Text = "$0.00";
            // 
            // btnCuentas
            // 
            this.btnCuentas.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuentas.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuentas.Image = ((System.Drawing.Image)(resources.GetObject("btnCuentas.Image")));
            this.btnCuentas.Location = new System.Drawing.Point(376, 76);
            this.btnCuentas.Name = "btnCuentas";
            this.btnCuentas.Size = new System.Drawing.Size(123, 57);
            this.btnCuentas.TabIndex = 62;
            this.btnCuentas.Text = "Cuentas";
            this.btnCuentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCuentas.UseVisualStyleBackColor = false;
            this.btnCuentas.Visible = false;
            this.btnCuentas.Click += new System.EventHandler(this.btnCuentas_Click);
            // 
            // tFecha
            // 
            this.tFecha.Interval = 1000;
            this.tFecha.Tick += new System.EventHandler(this.tFecha_Tick);
            // 
            // btnBtc
            // 
            this.btnBtc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBtc.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBtc.Image = ((System.Drawing.Image)(resources.GetObject("btnBtc.Image")));
            this.btnBtc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBtc.Location = new System.Drawing.Point(1025, 476);
            this.btnBtc.Name = "btnBtc";
            this.btnBtc.Size = new System.Drawing.Size(200, 65);
            this.btnBtc.TabIndex = 63;
            this.btnBtc.Text = "Bitcoin";
            this.btnBtc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBtc.UseVisualStyleBackColor = true;
            this.btnBtc.Click += new System.EventHandler(this.btnBtc_Click);
            // 
            // lble1
            // 
            this.lble1.AutoSize = true;
            this.lble1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lble1.Location = new System.Drawing.Point(147, 562);
            this.lble1.Name = "lble1";
            this.lble1.Size = new System.Drawing.Size(57, 17);
            this.lble1.TabIndex = 64;
            this.lble1.Text = "Exento:";
            // 
            // lblExento
            // 
            this.lblExento.AutoSize = true;
            this.lblExento.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExento.Location = new System.Drawing.Point(245, 559);
            this.lblExento.Name = "lblExento";
            this.lblExento.Size = new System.Drawing.Size(44, 18);
            this.lblExento.TabIndex = 65;
            this.lblExento.Tag = "0";
            this.lblExento.Text = "$0.00";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConexionRed,
            this.lblConexionGreen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 656);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1248, 25);
            this.toolStrip1.TabIndex = 66;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblConexionRed
            // 
            this.lblConexionRed.Image = ((System.Drawing.Image)(resources.GetObject("lblConexionRed.Image")));
            this.lblConexionRed.Name = "lblConexionRed";
            this.lblConexionRed.Size = new System.Drawing.Size(98, 20);
            this.lblConexionRed.Text = "Desconectado";
            this.lblConexionRed.Visible = false;
            // 
            // lblConexionGreen
            // 
            this.lblConexionGreen.Image = ((System.Drawing.Image)(resources.GetObject("lblConexionGreen.Image")));
            this.lblConexionGreen.Name = "lblConexionGreen";
            this.lblConexionGreen.Size = new System.Drawing.Size(81, 20);
            this.lblConexionGreen.Text = "Conectado";
            this.lblConexionGreen.Visible = false;
            // 
            // PuntoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 681);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lble1);
            this.Controls.Add(this.lblExento);
            this.Controls.Add(this.btnBtc);
            this.Controls.Add(this.btnCuentas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnPunto);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnCortesia);
            this.Controls.Add(this.btnExacto);
            this.Controls.Add(this.btnTarjeta);
            this.Controls.Add(this.btnEfectivo);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPagoRegistrar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalPagar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.lblIva);
            this.Controls.Add(this.lblPropina);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.flpDinero);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblMesa);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblMesero);
            this.Controls.Add(this.lblTicket);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.flpAcciones);
            this.MinimumSize = new System.Drawing.Size(1264, 697);
            this.Name = "PuntoPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PuntoPago";
            this.Activated += new System.EventHandler(this.PuntoPago_Activated);
            this.Deactivate += new System.EventHandler(this.PuntoPago_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PuntoPago_FormClosing);
            this.Load += new System.EventHandler(this.PuntoPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.flpAcciones.ResumeLayout(false);
            this.flpAcciones.PerformLayout();
            this.flpDinero.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblMesa;
        public System.Windows.Forms.Label lblCliente;
        public System.Windows.Forms.Label lblMesero;
        public System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox cbPropina;
        private System.Windows.Forms.CheckBox cbDescuento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FlowLayoutPanel flpDinero;
        private System.Windows.Forms.Button btnUno;
        private System.Windows.Forms.Button btnDos;
        private System.Windows.Forms.Button btnCinco;
        private System.Windows.Forms.Button btnDiez;
        private System.Windows.Forms.Button btnVeinte;
        private System.Windows.Forms.Button btnCincuenta;
        private System.Windows.Forms.Button btnCien;
        private System.Windows.Forms.Button button8;
        public System.Windows.Forms.Label lblIva;
        public System.Windows.Forms.Label lblPropina;
        public System.Windows.Forms.Label lblDescuento;
        public System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtPagoRegistrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button btnEfectivo;
        private System.Windows.Forms.Button btnTarjeta;
        private System.Windows.Forms.Button btnMuchos;
        private System.Windows.Forms.Button btnExacto;
        private System.Windows.Forms.Button btnCortesia;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnPunto;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Button btnCuentas;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewTextBoxColumn idDetalle;
        private DataGridViewTextBoxColumn idPedido;
        private DataGridViewTextBoxColumn idProducto;
        private DataGridViewTextBoxColumn precio;
        private DataGridViewTextBoxColumn fecha;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn subTotal;
        private DataGridViewTextBoxColumn grupo;
        private DataGridViewTextBoxColumn cocinando;
        private DataGridViewTextBoxColumn nombreMesero;
        private DataGridViewTextBoxColumn nombres;
        private DataGridViewTextBoxColumn mesa;
        private DataGridViewTextBoxColumn salon;
        private Timer tFecha;
        private Button btnBtc;
        private CheckBox chkExento;
        private Label lble1;
        public Label lblExento;
        private ToolStrip toolStrip1;
        private ToolStripStatusLabel lblConexionRed;
        private ToolStripStatusLabel lblConexionGreen;
    }
}