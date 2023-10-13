
namespace TPV.GUI
{
    partial class SepararCuenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SepararCuenta));
            this.lblTicket = new System.Windows.Forms.Label();
            this.lblMesa = new System.Windows.Forms.Label();
            this.dgvActual = new System.Windows.Forms.DataGridView();
            this.dgvSiguiente = new System.Windows.Forms.DataGridView();
            this.btnPasar = new System.Windows.Forms.Button();
            this.btnTraer = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnExtras = new System.Windows.Forms.Button();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDetalleSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPedidoSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProductoSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiguiente)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicket.Location = new System.Drawing.Point(13, 13);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(89, 20);
            this.lblTicket.TabIndex = 0;
            this.lblTicket.Text = "#Pedido: 241";
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesa.Location = new System.Drawing.Point(12, 33);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(63, 20);
            this.lblMesa.TabIndex = 1;
            this.lblMesa.Text = "#Mesa: 1";
            // 
            // dgvActual
            // 
            this.dgvActual.AllowUserToAddRows = false;
            this.dgvActual.AllowUserToDeleteRows = false;
            this.dgvActual.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Snow;
            this.dgvActual.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvActual.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvActual.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cantidad,
            this.idDetalle,
            this.idPedido,
            this.idProducto,
            this.precio,
            this.fecha,
            this.nombre,
            this.subTotal,
            this.grupo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActual.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvActual.Location = new System.Drawing.Point(12, 65);
            this.dgvActual.MultiSelect = false;
            this.dgvActual.Name = "dgvActual";
            this.dgvActual.ReadOnly = true;
            this.dgvActual.RowHeadersVisible = false;
            this.dgvActual.RowHeadersWidth = 51;
            this.dgvActual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActual.Size = new System.Drawing.Size(366, 310);
            this.dgvActual.TabIndex = 6;
            // 
            // dgvSiguiente
            // 
            this.dgvSiguiente.AllowUserToAddRows = false;
            this.dgvSiguiente.AllowUserToDeleteRows = false;
            this.dgvSiguiente.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Snow;
            this.dgvSiguiente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSiguiente.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvSiguiente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSiguiente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvSiguiente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiguiente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cantidadSiguiente,
            this.grupoSiguiente,
            this.idDetalleSiguiente,
            this.idPedidoSiguiente,
            this.idProductoSiguiente,
            this.precioSiguiente,
            this.fechaSiguiente,
            this.nombreSiguiente,
            this.subTotalSiguiente});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSiguiente.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSiguiente.Location = new System.Drawing.Point(466, 65);
            this.dgvSiguiente.MultiSelect = false;
            this.dgvSiguiente.Name = "dgvSiguiente";
            this.dgvSiguiente.ReadOnly = true;
            this.dgvSiguiente.RowHeadersVisible = false;
            this.dgvSiguiente.RowHeadersWidth = 51;
            this.dgvSiguiente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSiguiente.Size = new System.Drawing.Size(366, 310);
            this.dgvSiguiente.TabIndex = 7;
            // 
            // btnPasar
            // 
            this.btnPasar.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPasar.Location = new System.Drawing.Point(384, 142);
            this.btnPasar.Name = "btnPasar";
            this.btnPasar.Size = new System.Drawing.Size(75, 56);
            this.btnPasar.TabIndex = 8;
            this.btnPasar.Text = " >";
            this.btnPasar.UseVisualStyleBackColor = true;
            this.btnPasar.Click += new System.EventHandler(this.btnPasar_Click);
            // 
            // btnTraer
            // 
            this.btnTraer.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraer.Location = new System.Drawing.Point(385, 245);
            this.btnTraer.Name = "btnTraer";
            this.btnTraer.Size = new System.Drawing.Size(75, 56);
            this.btnTraer.TabIndex = 9;
            this.btnTraer.Text = "<";
            this.btnTraer.UseVisualStyleBackColor = true;
            this.btnTraer.Click += new System.EventHandler(this.btnTraer_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(719, 1);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(113, 58);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnExtras
            // 
            this.btnExtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExtras.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtras.Image = ((System.Drawing.Image)(resources.GetObject("btnExtras.Image")));
            this.btnExtras.Location = new System.Drawing.Point(648, 378);
            this.btnExtras.Margin = new System.Windows.Forms.Padding(0);
            this.btnExtras.Name = "btnExtras";
            this.btnExtras.Size = new System.Drawing.Size(184, 77);
            this.btnExtras.TabIndex = 16;
            this.btnExtras.Text = "Separar pedido";
            this.btnExtras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExtras.UseVisualStyleBackColor = true;
            this.btnExtras.Click += new System.EventHandler(this.btnExtras_Click);
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
            this.idDetalle.HeaderText = "ID Detalle";
            this.idDetalle.Name = "idDetalle";
            this.idDetalle.ReadOnly = true;
            this.idDetalle.Visible = false;
            // 
            // idPedido
            // 
            this.idPedido.DataPropertyName = "idPedido";
            this.idPedido.HeaderText = "ID";
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
            // cantidadSiguiente
            // 
            this.cantidadSiguiente.DataPropertyName = "cantidadSiguiente";
            this.cantidadSiguiente.HeaderText = "Cantidad";
            this.cantidadSiguiente.Name = "cantidadSiguiente";
            this.cantidadSiguiente.ReadOnly = true;
            // 
            // grupoSiguiente
            // 
            this.grupoSiguiente.DataPropertyName = "grupoSiguiente";
            this.grupoSiguiente.HeaderText = "Grupo";
            this.grupoSiguiente.Name = "grupoSiguiente";
            this.grupoSiguiente.ReadOnly = true;
            this.grupoSiguiente.Visible = false;
            // 
            // idDetalleSiguiente
            // 
            this.idDetalleSiguiente.DataPropertyName = "idDetalleSiguiente";
            this.idDetalleSiguiente.HeaderText = "ID Detalle";
            this.idDetalleSiguiente.Name = "idDetalleSiguiente";
            this.idDetalleSiguiente.ReadOnly = true;
            this.idDetalleSiguiente.Visible = false;
            // 
            // idPedidoSiguiente
            // 
            this.idPedidoSiguiente.DataPropertyName = "idPedidoSiguiente";
            this.idPedidoSiguiente.HeaderText = "ID";
            this.idPedidoSiguiente.Name = "idPedidoSiguiente";
            this.idPedidoSiguiente.ReadOnly = true;
            this.idPedidoSiguiente.Visible = false;
            // 
            // idProductoSiguiente
            // 
            this.idProductoSiguiente.DataPropertyName = "idProductoSiguiente";
            this.idProductoSiguiente.HeaderText = "Id Producto";
            this.idProductoSiguiente.Name = "idProductoSiguiente";
            this.idProductoSiguiente.ReadOnly = true;
            this.idProductoSiguiente.Visible = false;
            // 
            // precioSiguiente
            // 
            this.precioSiguiente.DataPropertyName = "precioSiguiente";
            this.precioSiguiente.HeaderText = "Precio";
            this.precioSiguiente.Name = "precioSiguiente";
            this.precioSiguiente.ReadOnly = true;
            this.precioSiguiente.Visible = false;
            // 
            // fechaSiguiente
            // 
            this.fechaSiguiente.DataPropertyName = "fechaSiguiente";
            this.fechaSiguiente.HeaderText = "Fecha";
            this.fechaSiguiente.Name = "fechaSiguiente";
            this.fechaSiguiente.ReadOnly = true;
            this.fechaSiguiente.Visible = false;
            // 
            // nombreSiguiente
            // 
            this.nombreSiguiente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreSiguiente.DataPropertyName = "nombreSiguiente";
            this.nombreSiguiente.HeaderText = "Producto";
            this.nombreSiguiente.Name = "nombreSiguiente";
            this.nombreSiguiente.ReadOnly = true;
            // 
            // subTotalSiguiente
            // 
            this.subTotalSiguiente.DataPropertyName = "subTotalSiguiente";
            this.subTotalSiguiente.HeaderText = "Sub Total";
            this.subTotalSiguiente.Name = "subTotalSiguiente";
            this.subTotalSiguiente.ReadOnly = true;
            // 
            // SepararCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 463);
            this.Controls.Add(this.btnExtras);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnTraer);
            this.Controls.Add(this.btnPasar);
            this.Controls.Add(this.dgvSiguiente);
            this.Controls.Add(this.dgvActual);
            this.Controls.Add(this.lblMesa);
            this.Controls.Add(this.lblTicket);
            this.Name = "SepararCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SepararCuenta";
            this.Load += new System.EventHandler(this.SepararCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiguiente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvActual;
        private System.Windows.Forms.DataGridView dgvSiguiente;
        private System.Windows.Forms.Button btnPasar;
        private System.Windows.Forms.Button btnTraer;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnExtras;
        public System.Windows.Forms.Label lblTicket;
        public System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadSiguiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoSiguiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleSiguiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedidoSiguiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoSiguiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioSiguiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaSiguiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreSiguiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalSiguiente;
    }
}