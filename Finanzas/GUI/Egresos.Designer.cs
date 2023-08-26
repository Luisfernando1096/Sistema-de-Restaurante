﻿
namespace Finanzas.GUI
{
    partial class Egresos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Egresos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tanConsultas = new System.Windows.Forms.TabPage();
            this.dgvDatosCaja = new System.Windows.Forms.DataGridView();
            this.idEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTPHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTPDesde = new System.Windows.Forms.DateTimePicker();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbCaja = new System.Windows.Forms.ComboBox();
            this.rbCaja = new System.Windows.Forms.RadioButton();
            this.rbNinguno = new System.Windows.Forms.RadioButton();
            this.tabEgresos = new System.Windows.Forms.TabPage();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.idEgreso1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCaja1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioIngrediente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStockIngrediente = new System.Windows.Forms.TextBox();
            this.txtIDIngrediente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalirIngrediente = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chBox = new System.Windows.Forms.CheckBox();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.cmbCaja1 = new System.Windows.Forms.ComboBox();
            this.rbtn1Usuario = new System.Windows.Forms.RadioButton();
            this.rbtn1Caja = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tanConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCaja)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabEgresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tanConsultas
            // 
            this.tanConsultas.Controls.Add(this.dgvDatosCaja);
            this.tanConsultas.Controls.Add(this.groupBox1);
            this.tanConsultas.Controls.Add(this.toolStrip1);
            this.tanConsultas.Controls.Add(this.groupBox4);
            this.tanConsultas.Location = new System.Drawing.Point(4, 44);
            this.tanConsultas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tanConsultas.Name = "tanConsultas";
            this.tanConsultas.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tanConsultas.Size = new System.Drawing.Size(1120, 487);
            this.tanConsultas.TabIndex = 1;
            this.tanConsultas.Text = "       Consulta egresos       ";
            this.tanConsultas.UseVisualStyleBackColor = true;
            // 
            // dgvDatosCaja
            // 
            this.dgvDatosCaja.AllowUserToAddRows = false;
            this.dgvDatosCaja.AllowUserToDeleteRows = false;
            this.dgvDatosCaja.AllowUserToResizeColumns = false;
            this.dgvDatosCaja.AllowUserToResizeRows = false;
            this.dgvDatosCaja.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvDatosCaja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatosCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosCaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEgreso,
            this.idCaja,
            this.Usuario,
            this.fecha,
            this.Cantidad,
            this.Descripcion});
            this.dgvDatosCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatosCaja.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvDatosCaja.Location = new System.Drawing.Point(2, 137);
            this.dgvDatosCaja.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDatosCaja.Name = "dgvDatosCaja";
            this.dgvDatosCaja.ReadOnly = true;
            this.dgvDatosCaja.RowHeadersVisible = false;
            this.dgvDatosCaja.RowHeadersWidth = 51;
            this.dgvDatosCaja.RowTemplate.Height = 24;
            this.dgvDatosCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosCaja.Size = new System.Drawing.Size(1116, 298);
            this.dgvDatosCaja.TabIndex = 17;
            // 
            // idEgreso
            // 
            this.idEgreso.DataPropertyName = "idEgreso";
            this.idEgreso.HeaderText = "ID";
            this.idEgreso.MinimumWidth = 6;
            this.idEgreso.Name = "idEgreso";
            this.idEgreso.ReadOnly = true;
            this.idEgreso.Width = 70;
            // 
            // idCaja
            // 
            this.idCaja.DataPropertyName = "idCaja";
            this.idCaja.HeaderText = "idCaja";
            this.idCaja.MinimumWidth = 6;
            this.idCaja.Name = "idCaja";
            this.idCaja.ReadOnly = true;
            this.idCaja.Width = 70;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "nombres";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.MinimumWidth = 6;
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 175;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.fecha.HeaderText = "Fecha";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 150;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 125;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "descripcion";
            this.Descripcion.HeaderText = "Descripcion/justifiacion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.dateTPHasta);
            this.groupBox1.Controls.Add(this.dateTPDesde);
            this.groupBox1.Controls.Add(this.txtHasta);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDesde);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(2, 59);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(1116, 78);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 14);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 21);
            this.button2.TabIndex = 23;
            this.button2.Text = "Borrar Filtro de fechas ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTPHasta
            // 
            this.dateTPHasta.Location = new System.Drawing.Point(230, 47);
            this.dateTPHasta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTPHasta.Name = "dateTPHasta";
            this.dateTPHasta.Size = new System.Drawing.Size(213, 20);
            this.dateTPHasta.TabIndex = 21;
            this.dateTPHasta.ValueChanged += new System.EventHandler(this.dateTPHasta_ValueChanged);
            // 
            // dateTPDesde
            // 
            this.dateTPDesde.Location = new System.Drawing.Point(230, 15);
            this.dateTPDesde.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTPDesde.Name = "dateTPDesde";
            this.dateTPDesde.Size = new System.Drawing.Size(213, 20);
            this.dateTPDesde.TabIndex = 20;
            this.dateTPDesde.ValueChanged += new System.EventHandler(this.dateTPDesde_ValueChanged);
            // 
            // txtHasta
            // 
            this.txtHasta.Location = new System.Drawing.Point(65, 49);
            this.txtHasta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(152, 20);
            this.txtHasta.TabIndex = 19;
            this.txtHasta.TextChanged += new System.EventHandler(this.txtHasta_TextChanged);
            this.txtHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHasta_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Hasta";
            // 
            // txtDesde
            // 
            this.txtDesde.Location = new System.Drawing.Point(65, 15);
            this.txtDesde.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(152, 20);
            this.txtDesde.TabIndex = 10;
            this.txtDesde.TextChanged += new System.EventHandler(this.txtDesde_TextChanged);
            this.txtDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesde_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Desde";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripSeparator4,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1116, 57);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(101, 54);
            this.toolStripButton5.Text = "Salir";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 57);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 54);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbCaja);
            this.groupBox4.Controls.Add(this.rbCaja);
            this.groupBox4.Controls.Add(this.rbNinguno);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(2, 435);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(1116, 50);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtrar por:";
            // 
            // cmbCaja
            // 
            this.cmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCaja.FormattingEnabled = true;
            this.cmbCaja.Location = new System.Drawing.Point(225, 19);
            this.cmbCaja.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCaja.Name = "cmbCaja";
            this.cmbCaja.Size = new System.Drawing.Size(127, 21);
            this.cmbCaja.TabIndex = 14;
            this.cmbCaja.Visible = false;
            this.cmbCaja.SelectedIndexChanged += new System.EventHandler(this.cmbCaja_SelectedIndexChanged);
            // 
            // rbCaja
            // 
            this.rbCaja.AutoSize = true;
            this.rbCaja.Location = new System.Drawing.Point(104, 19);
            this.rbCaja.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCaja.Name = "rbCaja";
            this.rbCaja.Size = new System.Drawing.Size(118, 17);
            this.rbCaja.TabIndex = 1;
            this.rbCaja.TabStop = true;
            this.rbCaja.Text = "Por numero de Caja";
            this.rbCaja.UseVisualStyleBackColor = true;
            this.rbCaja.CheckedChanged += new System.EventHandler(this.rbCaja_CheckedChanged);
            // 
            // rbNinguno
            // 
            this.rbNinguno.AutoSize = true;
            this.rbNinguno.Location = new System.Drawing.Point(17, 19);
            this.rbNinguno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbNinguno.Name = "rbNinguno";
            this.rbNinguno.Size = new System.Drawing.Size(65, 17);
            this.rbNinguno.TabIndex = 0;
            this.rbNinguno.TabStop = true;
            this.rbNinguno.Text = "Ninguno";
            this.rbNinguno.UseVisualStyleBackColor = true;
            this.rbNinguno.CheckedChanged += new System.EventHandler(this.rbNinguno_CheckedChanged);
            // 
            // tabEgresos
            // 
            this.tabEgresos.Controls.Add(this.dgvDatos);
            this.tabEgresos.Controls.Add(this.groupBox2);
            this.tabEgresos.Controls.Add(this.toolStrip2);
            this.tabEgresos.Controls.Add(this.groupBox3);
            this.tabEgresos.Location = new System.Drawing.Point(4, 44);
            this.tabEgresos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabEgresos.Name = "tabEgresos";
            this.tabEgresos.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabEgresos.Size = new System.Drawing.Size(1020, 487);
            this.tabEgresos.TabIndex = 0;
            this.tabEgresos.Text = "        Egresos de efectivo        ";
            this.tabEgresos.UseVisualStyleBackColor = true;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEgreso1,
            this.idCaja1,
            this.Usuario1,
            this.fecha1,
            this.cantidad1,
            this.descripcion1});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvDatos.Location = new System.Drawing.Point(2, 118);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(1016, 317);
            this.dgvDatos.TabIndex = 18;
            // 
            // idEgreso1
            // 
            this.idEgreso1.DataPropertyName = "idEgreso";
            this.idEgreso1.HeaderText = "ID";
            this.idEgreso1.MinimumWidth = 6;
            this.idEgreso1.Name = "idEgreso1";
            this.idEgreso1.ReadOnly = true;
            this.idEgreso1.Width = 70;
            // 
            // idCaja1
            // 
            this.idCaja1.DataPropertyName = "idCaja";
            this.idCaja1.HeaderText = "idCaja";
            this.idCaja1.MinimumWidth = 6;
            this.idCaja1.Name = "idCaja1";
            this.idCaja1.ReadOnly = true;
            this.idCaja1.Width = 70;
            // 
            // Usuario1
            // 
            this.Usuario1.DataPropertyName = "nombres";
            this.Usuario1.HeaderText = "Usuario";
            this.Usuario1.MinimumWidth = 6;
            this.Usuario1.Name = "Usuario1";
            this.Usuario1.ReadOnly = true;
            this.Usuario1.Width = 175;
            // 
            // fecha1
            // 
            this.fecha1.DataPropertyName = "fecha";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd HH:mm:ss";
            this.fecha1.DefaultCellStyle = dataGridViewCellStyle2;
            this.fecha1.HeaderText = "Fecha";
            this.fecha1.MinimumWidth = 6;
            this.fecha1.Name = "fecha1";
            this.fecha1.ReadOnly = true;
            this.fecha1.Width = 150;
            // 
            // cantidad1
            // 
            this.cantidad1.DataPropertyName = "cantidad";
            this.cantidad1.HeaderText = "Cantidad";
            this.cantidad1.MinimumWidth = 6;
            this.cantidad1.Name = "cantidad1";
            this.cantidad1.ReadOnly = true;
            this.cantidad1.Width = 125;
            // 
            // descripcion1
            // 
            this.descripcion1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion1.DataPropertyName = "descripcion";
            this.descripcion1.HeaderText = "Descripcion/justifiacion";
            this.descripcion1.MinimumWidth = 6;
            this.descripcion1.Name = "descripcion1";
            this.descripcion1.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPrecioIngrediente);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtStockIngrediente);
            this.groupBox2.Controls.Add(this.txtIDIngrediente);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(2, 64);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(1016, 54);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(104, 17);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(204, 20);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(689, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Cantidad";
            // 
            // txtPrecioIngrediente
            // 
            this.txtPrecioIngrediente.Location = new System.Drawing.Point(743, 17);
            this.txtPrecioIngrediente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecioIngrediente.Name = "txtPrecioIngrediente";
            this.txtPrecioIngrediente.Size = new System.Drawing.Size(65, 20);
            this.txtPrecioIngrediente.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(322, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Breve descripcion";
            // 
            // txtStockIngrediente
            // 
            this.txtStockIngrediente.Location = new System.Drawing.Point(418, 17);
            this.txtStockIngrediente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStockIngrediente.Name = "txtStockIngrediente";
            this.txtStockIngrediente.Size = new System.Drawing.Size(263, 20);
            this.txtStockIngrediente.TabIndex = 13;
            // 
            // txtIDIngrediente
            // 
            this.txtIDIngrediente.Enabled = false;
            this.txtIDIngrediente.Location = new System.Drawing.Point(25, 17);
            this.txtIDIngrediente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIDIngrediente.Name = "txtIDIngrediente";
            this.txtIDIngrediente.Size = new System.Drawing.Size(21, 20);
            this.txtIDIngrediente.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fecha";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.btnEliminar,
            this.toolStripSeparator6,
            this.btnEditar,
            this.toolStripSeparator7,
            this.btnGuardar,
            this.btnLimpiar,
            this.btnSalirIngrediente,
            this.toolStripButton6,
            this.toolStripSeparator8,
            this.toolStripLabel1});
            this.toolStrip2.Location = new System.Drawing.Point(2, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1016, 62);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 62);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(143, 59);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 62);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(102, 59);
            this.btnEditar.Text = "Editar";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 62);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 59);
            this.btnGuardar.Text = "Guardar";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(114, 59);
            this.btnLimpiar.Text = "Limpiar";
            // 
            // btnSalirIngrediente
            // 
            this.btnSalirIngrediente.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalirIngrediente.Image = ((System.Drawing.Image)(resources.GetObject("btnSalirIngrediente.Image")));
            this.btnSalirIngrediente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSalirIngrediente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalirIngrediente.Name = "btnSalirIngrediente";
            this.btnSalirIngrediente.Size = new System.Drawing.Size(101, 59);
            this.btnSalirIngrediente.Text = "Salir";
            this.btnSalirIngrediente.Click += new System.EventHandler(this.btnSalirIngrediente_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(126, 59);
            this.toolStripButton6.Text = "Imprimir";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 62);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 59);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chBox);
            this.groupBox3.Controls.Add(this.cmbUsuario);
            this.groupBox3.Controls.Add(this.cmbCaja1);
            this.groupBox3.Controls.Add(this.rbtn1Usuario);
            this.groupBox3.Controls.Add(this.rbtn1Caja);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(2, 435);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(1016, 50);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar datos por: ";
            // 
            // chBox
            // 
            this.chBox.AutoSize = true;
            this.chBox.Location = new System.Drawing.Point(39, 21);
            this.chBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chBox.Name = "chBox";
            this.chBox.Size = new System.Drawing.Size(48, 17);
            this.chBox.TabIndex = 32;
            this.chBox.Text = "Filtro";
            this.chBox.UseVisualStyleBackColor = true;
            this.chBox.CheckedChanged += new System.EventHandler(this.chBox_CheckedChanged);
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(302, 20);
            this.cmbUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(127, 21);
            this.cmbUsuario.TabIndex = 31;
            this.cmbUsuario.Visible = false;
            // 
            // cmbCaja1
            // 
            this.cmbCaja1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCaja1.FormattingEnabled = true;
            this.cmbCaja1.Location = new System.Drawing.Point(142, 20);
            this.cmbCaja1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCaja1.Name = "cmbCaja1";
            this.cmbCaja1.Size = new System.Drawing.Size(83, 21);
            this.cmbCaja1.TabIndex = 30;
            this.cmbCaja1.Visible = false;
            // 
            // rbtn1Usuario
            // 
            this.rbtn1Usuario.AutoSize = true;
            this.rbtn1Usuario.Location = new System.Drawing.Point(238, 20);
            this.rbtn1Usuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtn1Usuario.Name = "rbtn1Usuario";
            this.rbtn1Usuario.Size = new System.Drawing.Size(61, 17);
            this.rbtn1Usuario.TabIndex = 29;
            this.rbtn1Usuario.TabStop = true;
            this.rbtn1Usuario.Text = "Usuario";
            this.rbtn1Usuario.UseVisualStyleBackColor = true;
            this.rbtn1Usuario.Visible = false;
            // 
            // rbtn1Caja
            // 
            this.rbtn1Caja.AutoSize = true;
            this.rbtn1Caja.Location = new System.Drawing.Point(95, 20);
            this.rbtn1Caja.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtn1Caja.Name = "rbtn1Caja";
            this.rbtn1Caja.Size = new System.Drawing.Size(46, 17);
            this.rbtn1Caja.TabIndex = 28;
            this.rbtn1Caja.TabStop = true;
            this.rbtn1Caja.Text = "Caja";
            this.rbtn1Caja.UseVisualStyleBackColor = true;
            this.rbtn1Caja.Visible = false;
            this.rbtn1Caja.CheckedChanged += new System.EventHandler(this.rbtn1Caja_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEgresos);
            this.tabControl1.Controls.Add(this.tanConsultas);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 40);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1028, 535);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Egresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 535);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Egresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Egresos";
            this.Load += new System.EventHandler(this.Egresos_Load);
            this.tanConsultas.ResumeLayout(false);
            this.tanConsultas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCaja)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabEgresos.ResumeLayout(false);
            this.tabEgresos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tanConsultas;
        private System.Windows.Forms.DataGridView dgvDatosCaja;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTPHasta;
        private System.Windows.Forms.DateTimePicker dateTPDesde;
        private System.Windows.Forms.TextBox txtHasta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDesde;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabPage tabEgresos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecioIngrediente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStockIngrediente;
        private System.Windows.Forms.TextBox txtIDIngrediente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalirIngrediente;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtn1Usuario;
        private System.Windows.Forms.RadioButton rbtn1Caja;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.RadioButton rbCaja;
        private System.Windows.Forms.RadioButton rbNinguno;
        private System.Windows.Forms.ComboBox cmbCaja;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEgreso1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCaja1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion1;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.ComboBox cmbCaja1;
        private System.Windows.Forms.CheckBox chBox;
    }
}