
namespace Reportes.GUI
{
    partial class ReportesFiltrados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesFiltrados));
            this.pbFin = new System.Windows.Forms.PictureBox();
            this.pbInicio = new System.Windows.Forms.PictureBox();
            this.btnQuitarFiltro = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.cmbTipoAjuste = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbAjusteEn = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnVerInforme = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVerInforme = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvMeseros = new System.Windows.Forms.DataGridView();
            this.Asignado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DUI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sueldoBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVerPropinas = new System.Windows.Forms.Button();
            this.checkBoxConMesero = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbRolMesero = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.cmbTipoVetas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipoCompras = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnSalirIngrediente = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInicio)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMeseros)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFin
            // 
            this.pbFin.Image = ((System.Drawing.Image)(resources.GetObject("pbFin.Image")));
            this.pbFin.Location = new System.Drawing.Point(325, 112);
            this.pbFin.Name = "pbFin";
            this.pbFin.Size = new System.Drawing.Size(21, 20);
            this.pbFin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFin.TabIndex = 142;
            this.pbFin.TabStop = false;
            this.pbFin.Visible = false;
            // 
            // pbInicio
            // 
            this.pbInicio.Image = ((System.Drawing.Image)(resources.GetObject("pbInicio.Image")));
            this.pbInicio.Location = new System.Drawing.Point(325, 69);
            this.pbInicio.Name = "pbInicio";
            this.pbInicio.Size = new System.Drawing.Size(21, 20);
            this.pbInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInicio.TabIndex = 141;
            this.pbInicio.TabStop = false;
            this.pbInicio.Visible = false;
            // 
            // btnQuitarFiltro
            // 
            this.btnQuitarFiltro.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitarFiltro.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarFiltro.Image")));
            this.btnQuitarFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitarFiltro.Location = new System.Drawing.Point(553, 69);
            this.btnQuitarFiltro.Name = "btnQuitarFiltro";
            this.btnQuitarFiltro.Size = new System.Drawing.Size(210, 63);
            this.btnQuitarFiltro.TabIndex = 140;
            this.btnQuitarFiltro.Text = "Quitar filtro de fechas";
            this.btnQuitarFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitarFiltro.UseVisualStyleBackColor = false;
            this.btnQuitarFiltro.Click += new System.EventHandler(this.btnQuitarFiltro_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox4.Controls.Add(this.btnBuscarProducto);
            this.groupBox4.Controls.Add(this.btnImprimir);
            this.groupBox4.Controls.Add(this.txtNombreProducto);
            this.groupBox4.Controls.Add(this.cmbTipoAjuste);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cmbAjusteEn);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(42, 506);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1006, 98);
            this.groupBox4.TabIndex = 139;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reportes de ajustes de inventario";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarProducto.Location = new System.Drawing.Point(742, 57);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(99, 21);
            this.btnBuscarProducto.TabIndex = 128;
            this.btnBuscarProducto.Text = "Buscar";
            this.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(885, 25);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(104, 61);
            this.btnImprimir.TabIndex = 127;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(511, 58);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(225, 20);
            this.txtNombreProducto.TabIndex = 126;
            // 
            // cmbTipoAjuste
            // 
            this.cmbTipoAjuste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoAjuste.FormattingEnabled = true;
            this.cmbTipoAjuste.Items.AddRange(new object[] {
            "Incrementar",
            "Decrementar"});
            this.cmbTipoAjuste.Location = new System.Drawing.Point(258, 57);
            this.cmbTipoAjuste.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoAjuste.Name = "cmbTipoAjuste";
            this.cmbTipoAjuste.Size = new System.Drawing.Size(196, 21);
            this.cmbTipoAjuste.TabIndex = 125;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.Location = new System.Drawing.Point(508, 42);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(228, 13);
            this.label11.TabIndex = 124;
            this.label11.Text = "Nombre  del producto o ingrediente (opcional) :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.Location = new System.Drawing.Point(255, 42);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 122;
            this.label10.Text = "Tipo de ajuste:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(5, 42);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 120;
            this.label9.Text = "Ajusten en:";
            // 
            // cmbAjusteEn
            // 
            this.cmbAjusteEn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAjusteEn.FormattingEnabled = true;
            this.cmbAjusteEn.Items.AddRange(new object[] {
            "Productos",
            "Ingredientes"});
            this.cmbAjusteEn.Location = new System.Drawing.Point(8, 57);
            this.cmbAjusteEn.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAjusteEn.Name = "cmbAjusteEn";
            this.cmbAjusteEn.Size = new System.Drawing.Size(196, 21);
            this.cmbAjusteEn.TabIndex = 121;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Controls.Add(this.btnVerInforme);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cmbVerInforme);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(699, 211);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 282);
            this.groupBox3.TabIndex = 138;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Productos e ingredientes";
            // 
            // btnVerInforme
            // 
            this.btnVerInforme.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerInforme.Image = ((System.Drawing.Image)(resources.GetObject("btnVerInforme.Image")));
            this.btnVerInforme.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVerInforme.Location = new System.Drawing.Point(8, 112);
            this.btnVerInforme.Name = "btnVerInforme";
            this.btnVerInforme.Size = new System.Drawing.Size(334, 80);
            this.btnVerInforme.TabIndex = 96;
            this.btnVerInforme.Text = "Ver informe ";
            this.btnVerInforme.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVerInforme.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.Location = new System.Drawing.Point(5, 42);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 120;
            this.label8.Text = "Tipo de reporte";
            // 
            // cmbVerInforme
            // 
            this.cmbVerInforme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVerInforme.FormattingEnabled = true;
            this.cmbVerInforme.Items.AddRange(new object[] {
            "Productos sin stock",
            "Ingredientes sin stock",
            "Productos con stock menor o igual al stock minimo"});
            this.cmbVerInforme.Location = new System.Drawing.Point(8, 57);
            this.cmbVerInforme.Margin = new System.Windows.Forms.Padding(2);
            this.cmbVerInforme.Name = "cmbVerInforme";
            this.cmbVerInforme.Size = new System.Drawing.Size(324, 21);
            this.cmbVerInforme.TabIndex = 121;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.dtgvMeseros);
            this.groupBox2.Controls.Add(this.btnVerPropinas);
            this.groupBox2.Controls.Add(this.checkBoxConMesero);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbRolMesero);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(279, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 282);
            this.groupBox2.TabIndex = 137;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reporte de propinas";
            // 
            // dtgvMeseros
            // 
            this.dtgvMeseros.AllowUserToAddRows = false;
            this.dtgvMeseros.AllowUserToDeleteRows = false;
            this.dtgvMeseros.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgvMeseros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvMeseros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvMeseros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Asignado,
            this.nombres,
            this.apellidos,
            this.idEmpleado,
            this.direccion,
            this.email,
            this.telefono,
            this.DUI,
            this.NIT,
            this.sueldoBase,
            this.comision,
            this.regContable});
            this.dtgvMeseros.Location = new System.Drawing.Point(8, 116);
            this.dtgvMeseros.Name = "dtgvMeseros";
            this.dtgvMeseros.RowHeadersVisible = false;
            this.dtgvMeseros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvMeseros.Size = new System.Drawing.Size(396, 160);
            this.dtgvMeseros.TabIndex = 127;
            // 
            // Asignado
            // 
            this.Asignado.DataPropertyName = "Asignado";
            this.Asignado.HeaderText = "";
            this.Asignado.Name = "Asignado";
            this.Asignado.Width = 40;
            // 
            // nombres
            // 
            this.nombres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombres.DataPropertyName = "nombres";
            this.nombres.HeaderText = "Empleado";
            this.nombres.Name = "nombres";
            // 
            // apellidos
            // 
            this.apellidos.HeaderText = "Apellidos";
            this.apellidos.Name = "apellidos";
            this.apellidos.Visible = false;
            // 
            // idEmpleado
            // 
            this.idEmpleado.HeaderText = "ID Empleado";
            this.idEmpleado.Name = "idEmpleado";
            this.idEmpleado.Visible = false;
            // 
            // direccion
            // 
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.Visible = false;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.Visible = false;
            // 
            // telefono
            // 
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.Visible = false;
            // 
            // DUI
            // 
            this.DUI.HeaderText = "DUI";
            this.DUI.Name = "DUI";
            this.DUI.Visible = false;
            // 
            // NIT
            // 
            this.NIT.HeaderText = "NIT";
            this.NIT.Name = "NIT";
            this.NIT.Visible = false;
            // 
            // sueldoBase
            // 
            this.sueldoBase.HeaderText = "Sueldo Base";
            this.sueldoBase.Name = "sueldoBase";
            this.sueldoBase.Visible = false;
            // 
            // comision
            // 
            this.comision.HeaderText = "Comision";
            this.comision.Name = "comision";
            this.comision.Visible = false;
            // 
            // regContable
            // 
            this.regContable.HeaderText = "Reg Contable";
            this.regContable.Name = "regContable";
            this.regContable.Visible = false;
            // 
            // btnVerPropinas
            // 
            this.btnVerPropinas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerPropinas.Image = ((System.Drawing.Image)(resources.GetObject("btnVerPropinas.Image")));
            this.btnVerPropinas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVerPropinas.Location = new System.Drawing.Point(300, 17);
            this.btnVerPropinas.Name = "btnVerPropinas";
            this.btnVerPropinas.Size = new System.Drawing.Size(104, 61);
            this.btnVerPropinas.TabIndex = 96;
            this.btnVerPropinas.Text = "Ver propinas";
            this.btnVerPropinas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVerPropinas.UseVisualStyleBackColor = false;
            this.btnVerPropinas.Click += new System.EventHandler(this.btnVerPropinas_Click);
            // 
            // checkBoxConMesero
            // 
            this.checkBoxConMesero.AutoSize = true;
            this.checkBoxConMesero.Location = new System.Drawing.Point(227, 59);
            this.checkBoxConMesero.Name = "checkBoxConMesero";
            this.checkBoxConMesero.Size = new System.Drawing.Size(71, 17);
            this.checkBoxConMesero.TabIndex = 126;
            this.checkBoxConMesero.Text = "Cambiar";
            this.checkBoxConMesero.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(5, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 120;
            this.label6.Text = "Seleccione el rol mesero";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(5, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 123;
            this.label7.Text = "Seleccion a los meseros";
            // 
            // cmbRolMesero
            // 
            this.cmbRolMesero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRolMesero.FormattingEnabled = true;
            this.cmbRolMesero.Location = new System.Drawing.Point(8, 57);
            this.cmbRolMesero.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRolMesero.Name = "cmbRolMesero";
            this.cmbRolMesero.Size = new System.Drawing.Size(213, 21);
            this.cmbRolMesero.TabIndex = 121;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.btnVentas);
            this.groupBox1.Controls.Add(this.btnCompras);
            this.groupBox1.Controls.Add(this.cmbTipoVetas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbTipoCompras);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(42, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 282);
            this.groupBox1.TabIndex = 136;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de compras y ventas";
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas.Image")));
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(8, 198);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(213, 61);
            this.btnVentas.TabIndex = 128;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCompras.Image = ((System.Drawing.Image)(resources.GetObject("btnCompras.Image")));
            this.btnCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompras.Location = new System.Drawing.Point(8, 70);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(213, 61);
            this.btnCompras.TabIndex = 127;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // cmbTipoVetas
            // 
            this.cmbTipoVetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVetas.FormattingEnabled = true;
            this.cmbTipoVetas.Items.AddRange(new object[] {
            "Ventas",
            "Ventas Resumen",
            "Ventas / Mesero",
            "Ventas / Mesero Resumen",
            "Ventas Facturadas",
            "Facturas Anuladas",
            "Ventas Productos",
            "Ventas Productos Agrupados",
            "Ventas Productos Resumen"});
            this.cmbTipoVetas.Location = new System.Drawing.Point(8, 171);
            this.cmbTipoVetas.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoVetas.Name = "cmbTipoVetas";
            this.cmbTipoVetas.Size = new System.Drawing.Size(213, 21);
            this.cmbTipoVetas.TabIndex = 124;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(5, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 120;
            this.label4.Text = "Tipo de Reporte";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(5, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 123;
            this.label5.Text = "Tipo de Reporte";
            // 
            // cmbTipoCompras
            // 
            this.cmbTipoCompras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCompras.FormattingEnabled = true;
            this.cmbTipoCompras.Items.AddRange(new object[] {
            "Compras",
            "Compras / Proveedor",
            "Compras / Comprobante"});
            this.cmbTipoCompras.Location = new System.Drawing.Point(8, 44);
            this.cmbTipoCompras.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoCompras.Name = "cmbTipoCompras";
            this.cmbTipoCompras.Size = new System.Drawing.Size(213, 21);
            this.cmbTipoCompras.TabIndex = 121;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 166);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(617, 13);
            this.label3.TabIndex = 135;
            this.label3.Text = "Seleccione  la fecha o rango de fechas  (desde, hasta) Seleccione solo \"Desde\" pa" +
    "ra una fecha espesifica";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(52, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 134;
            this.label2.Text = "Hasta";
            // 
            // dtpFin
            // 
            this.dtpFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtpFin.CustomFormat = "yyyy/MM/dd";
            this.dtpFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(95, 112);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(224, 20);
            this.dtpFin.TabIndex = 133;
            this.dtpFin.CloseUp += new System.EventHandler(this.dtpFechaHasta_CloseUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(52, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 132;
            this.label1.Text = "Desde";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtpInicio.CustomFormat = "yyyy/MM/dd";
            this.dtpInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(95, 69);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(224, 20);
            this.dtpInicio.TabIndex = 131;
            this.dtpInicio.CloseUp += new System.EventHandler(this.dtpFechaDesde_CloseUp);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalirIngrediente,
            this.toolStripLabel1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1086, 57);
            this.toolStrip2.TabIndex = 130;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnSalirIngrediente
            // 
            this.btnSalirIngrediente.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalirIngrediente.Image = ((System.Drawing.Image)(resources.GetObject("btnSalirIngrediente.Image")));
            this.btnSalirIngrediente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSalirIngrediente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalirIngrediente.Name = "btnSalirIngrediente";
            this.btnSalirIngrediente.Size = new System.Drawing.Size(101, 54);
            this.btnSalirIngrediente.Text = "Salir";
            this.btnSalirIngrediente.Click += new System.EventHandler(this.btnSalirIngrediente_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 54);
            // 
            // ReportesFiltrados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 637);
            this.Controls.Add(this.pbFin);
            this.Controls.Add(this.pbInicio);
            this.Controls.Add(this.btnQuitarFiltro);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportesFiltrados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportesFiltrados";
            ((System.ComponentModel.ISupportInitialize)(this.pbFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInicio)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMeseros)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFin;
        private System.Windows.Forms.PictureBox pbInicio;
        private System.Windows.Forms.Button btnQuitarFiltro;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.ComboBox cmbTipoAjuste;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbAjusteEn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnVerInforme;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbVerInforme;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgvMeseros;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Asignado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn sueldoBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn regContable;
        private System.Windows.Forms.Button btnVerPropinas;
        private System.Windows.Forms.CheckBox checkBoxConMesero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbRolMesero;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.ComboBox cmbTipoVetas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipoCompras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnSalirIngrediente;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}