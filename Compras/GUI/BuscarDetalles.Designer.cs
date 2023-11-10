
namespace Compras.GUI
{
    partial class BuscarDetalles
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
            this.dgvBuscar = new System.Windows.Forms.DataGridView();
            this.idCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbLista = new System.Windows.Forms.TextBox();
            this.bntSelecionar = new System.Windows.Forms.Button();
            this.rbtFecha = new System.Windows.Forms.RadioButton();
            this.rbtnNumero = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdAmbos = new System.Windows.Forms.RadioButton();
            this.rdIngrediente = new System.Windows.Forms.RadioButton();
            this.rdProducto = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscar)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBuscar
            // 
            this.dgvBuscar.AllowUserToAddRows = false;
            this.dgvBuscar.AllowUserToDeleteRows = false;
            this.dgvBuscar.AllowUserToResizeColumns = false;
            this.dgvBuscar.AllowUserToResizeRows = false;
            this.dgvBuscar.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCompra,
            this.TipoCompra,
            this.idProveedor,
            this.nombre,
            this.idComprobante,
            this.Tipo,
            this.nComprobante,
            this.idUsuario,
            this.fecha,
            this.total,
            this.descuento,
            this.iva,
            this.TotalPago});
            this.dgvBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBuscar.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvBuscar.Location = new System.Drawing.Point(0, 62);
            this.dgvBuscar.Name = "dgvBuscar";
            this.dgvBuscar.ReadOnly = true;
            this.dgvBuscar.RowHeadersVisible = false;
            this.dgvBuscar.RowHeadersWidth = 51;
            this.dgvBuscar.RowTemplate.Height = 24;
            this.dgvBuscar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuscar.Size = new System.Drawing.Size(1378, 415);
            this.dgvBuscar.TabIndex = 18;
            this.dgvBuscar.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBuscar_ColumnHeaderMouseClick);
            // 
            // idCompra
            // 
            this.idCompra.DataPropertyName = "idCompra";
            this.idCompra.HeaderText = "ID";
            this.idCompra.MinimumWidth = 6;
            this.idCompra.Name = "idCompra";
            this.idCompra.ReadOnly = true;
            this.idCompra.Width = 40;
            // 
            // TipoCompra
            // 
            this.TipoCompra.DataPropertyName = "tipoCompra";
            this.TipoCompra.HeaderText = "TipoCompra";
            this.TipoCompra.MinimumWidth = 6;
            this.TipoCompra.Name = "TipoCompra";
            this.TipoCompra.ReadOnly = true;
            this.TipoCompra.Visible = false;
            this.TipoCompra.Width = 150;
            // 
            // idProveedor
            // 
            this.idProveedor.DataPropertyName = "idProveedor";
            this.idProveedor.HeaderText = "idProveedor";
            this.idProveedor.MinimumWidth = 6;
            this.idProveedor.Name = "idProveedor";
            this.idProveedor.ReadOnly = true;
            this.idProveedor.Visible = false;
            this.idProveedor.Width = 70;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = " Nombre Proveedor";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 200;
            // 
            // idComprobante
            // 
            this.idComprobante.DataPropertyName = "idComprobante";
            this.idComprobante.HeaderText = "idComprobante";
            this.idComprobante.MinimumWidth = 6;
            this.idComprobante.Name = "idComprobante";
            this.idComprobante.ReadOnly = true;
            this.idComprobante.Visible = false;
            this.idComprobante.Width = 125;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Visible = false;
            this.Tipo.Width = 125;
            // 
            // nComprobante
            // 
            this.nComprobante.DataPropertyName = "nComprobante";
            this.nComprobante.HeaderText = "nComprobante";
            this.nComprobante.MinimumWidth = 6;
            this.nComprobante.Name = "nComprobante";
            this.nComprobante.ReadOnly = true;
            this.nComprobante.Width = 125;
            // 
            // idUsuario
            // 
            this.idUsuario.DataPropertyName = "idUsuario";
            this.idUsuario.HeaderText = "idUsuario";
            this.idUsuario.MinimumWidth = 6;
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            this.idUsuario.Visible = false;
            this.idUsuario.Width = 125;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.HeaderText = "fecha";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 125;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            this.total.HeaderText = "Subtotal";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 150;
            // 
            // descuento
            // 
            this.descuento.DataPropertyName = "descuento";
            this.descuento.HeaderText = "Descuento";
            this.descuento.MinimumWidth = 6;
            this.descuento.Name = "descuento";
            this.descuento.ReadOnly = true;
            this.descuento.Width = 125;
            // 
            // iva
            // 
            this.iva.DataPropertyName = "iva";
            this.iva.HeaderText = "Iva";
            this.iva.MinimumWidth = 6;
            this.iva.Name = "iva";
            this.iva.ReadOnly = true;
            this.iva.Width = 125;
            // 
            // TotalPago
            // 
            this.TotalPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalPago.DataPropertyName = "TotalPago";
            this.TotalPago.HeaderText = "TotalPago";
            this.TotalPago.MinimumWidth = 6;
            this.TotalPago.Name = "TotalPago";
            this.TotalPago.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtFecha);
            this.groupBox3.Controls.Add(this.cmbLista);
            this.groupBox3.Controls.Add(this.bntSelecionar);
            this.groupBox3.Controls.Add(this.rbtFecha);
            this.groupBox3.Controls.Add(this.rbtnNumero);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1378, 62);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar datos por: ";
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(314, 25);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(288, 22);
            this.dtFecha.TabIndex = 29;
            this.dtFecha.Visible = false;
            this.dtFecha.ValueChanged += new System.EventHandler(this.dtFecha_ValueChanged);
            // 
            // cmbLista
            // 
            this.cmbLista.Location = new System.Drawing.Point(314, 24);
            this.cmbLista.Name = "cmbLista";
            this.cmbLista.Size = new System.Drawing.Size(376, 22);
            this.cmbLista.TabIndex = 28;
            this.cmbLista.TextChanged += new System.EventHandler(this.cmbLista_TextChanged);
            // 
            // bntSelecionar
            // 
            this.bntSelecionar.Location = new System.Drawing.Point(992, 15);
            this.bntSelecionar.Name = "bntSelecionar";
            this.bntSelecionar.Size = new System.Drawing.Size(216, 34);
            this.bntSelecionar.TabIndex = 25;
            this.bntSelecionar.Text = "Seleccionar y salir";
            this.bntSelecionar.UseVisualStyleBackColor = true;
            this.bntSelecionar.Visible = false;
            this.bntSelecionar.Click += new System.EventHandler(this.bntSelecionar_Click);
            // 
            // rbtFecha
            // 
            this.rbtFecha.AutoSize = true;
            this.rbtFecha.Location = new System.Drawing.Point(244, 25);
            this.rbtFecha.Name = "rbtFecha";
            this.rbtFecha.Size = new System.Drawing.Size(64, 21);
            this.rbtFecha.TabIndex = 1;
            this.rbtFecha.TabStop = true;
            this.rbtFecha.Text = "fecha";
            this.rbtFecha.UseVisualStyleBackColor = true;
            this.rbtFecha.CheckedChanged += new System.EventHandler(this.rbtFecha_CheckedChanged);
            // 
            // rbtnNumero
            // 
            this.rbtnNumero.AutoSize = true;
            this.rbtnNumero.Location = new System.Drawing.Point(53, 24);
            this.rbtnNumero.Name = "rbtnNumero";
            this.rbtnNumero.Size = new System.Drawing.Size(186, 21);
            this.rbtnNumero.TabIndex = 0;
            this.rbtnNumero.TabStop = true;
            this.rbtnNumero.Text = "Numero de comprobante";
            this.rbtnNumero.UseVisualStyleBackColor = true;
            this.rbtnNumero.CheckedChanged += new System.EventHandler(this.rbtnNumero_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdAmbos);
            this.groupBox6.Controls.Add(this.rdIngrediente);
            this.groupBox6.Controls.Add(this.rdProducto);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 477);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1378, 62);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Buscar en:";
            // 
            // rdAmbos
            // 
            this.rdAmbos.AutoSize = true;
            this.rdAmbos.Location = new System.Drawing.Point(254, 29);
            this.rdAmbos.Name = "rdAmbos";
            this.rdAmbos.Size = new System.Drawing.Size(72, 21);
            this.rdAmbos.TabIndex = 4;
            this.rdAmbos.TabStop = true;
            this.rdAmbos.Text = "Ambos";
            this.rdAmbos.UseVisualStyleBackColor = true;
            this.rdAmbos.CheckedChanged += new System.EventHandler(this.rdAmbos_CheckedChanged);
            // 
            // rdIngrediente
            // 
            this.rdIngrediente.AutoSize = true;
            this.rdIngrediente.Location = new System.Drawing.Point(132, 29);
            this.rdIngrediente.Name = "rdIngrediente";
            this.rdIngrediente.Size = new System.Drawing.Size(107, 21);
            this.rdIngrediente.TabIndex = 3;
            this.rdIngrediente.TabStop = true;
            this.rdIngrediente.Text = "Ingredientes";
            this.rdIngrediente.UseVisualStyleBackColor = true;
            this.rdIngrediente.CheckedChanged += new System.EventHandler(this.rdIngrediente_CheckedChanged);
            // 
            // rdProducto
            // 
            this.rdProducto.AutoSize = true;
            this.rdProducto.Location = new System.Drawing.Point(32, 29);
            this.rdProducto.Name = "rdProducto";
            this.rdProducto.Size = new System.Drawing.Size(93, 21);
            this.rdProducto.TabIndex = 2;
            this.rdProducto.TabStop = true;
            this.rdProducto.Text = "Productos";
            this.rdProducto.UseVisualStyleBackColor = true;
            this.rdProducto.CheckedChanged += new System.EventHandler(this.rdProducto_CheckedChanged);
            // 
            // BuscarDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 539);
            this.Controls.Add(this.dgvBuscar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Name = "BuscarDetalles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar y seleccionar el Proveedor";
            this.Load += new System.EventHandler(this.BuscarDetalles_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BuscarDetalles_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBuscar;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button bntSelecionar;
        private System.Windows.Forms.RadioButton rbtFecha;
        private System.Windows.Forms.RadioButton rbtnNumero;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdAmbos;
        private System.Windows.Forms.RadioButton rdIngrediente;
        private System.Windows.Forms.RadioButton rdProducto;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.TextBox cmbLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPago;
    }
}