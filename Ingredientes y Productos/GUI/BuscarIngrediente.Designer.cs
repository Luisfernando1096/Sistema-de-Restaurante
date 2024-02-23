
namespace Ingredientes_y_Productos.GUI
{
    partial class BuscarIngrediente
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.rbtNinguno = new System.Windows.Forms.RadioButton();
            this.rbtnPresentacion = new System.Windows.Forms.RadioButton();
            this.rbtnIngrediente = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvBuscarIngrediente = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreIngrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Presentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selecionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarIngrediente)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNombre);
            this.groupBox3.Controls.Add(this.rbtNinguno);
            this.groupBox3.Controls.Add(this.rbtnPresentacion);
            this.groupBox3.Controls.Add(this.rbtnIngrediente);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(910, 50);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar datos por: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(286, 19);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(203, 20);
            this.txtNombre.TabIndex = 30;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
//            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // rbtNinguno
            // 
            this.rbtNinguno.AutoSize = true;
            this.rbtNinguno.Location = new System.Drawing.Point(50, 20);
            this.rbtNinguno.Margin = new System.Windows.Forms.Padding(2);
            this.rbtNinguno.Name = "rbtNinguno";
            this.rbtNinguno.Size = new System.Drawing.Size(62, 17);
            this.rbtNinguno.TabIndex = 27;
            this.rbtNinguno.TabStop = true;
            this.rbtNinguno.Text = "Sin filtro";
            this.rbtNinguno.UseVisualStyleBackColor = true;
            this.rbtNinguno.CheckedChanged += new System.EventHandler(this.rbtNinguno_CheckedChanged);
            // 
            // rbtnPresentacion
            // 
            this.rbtnPresentacion.AutoSize = true;
            this.rbtnPresentacion.Location = new System.Drawing.Point(194, 20);
            this.rbtnPresentacion.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnPresentacion.Name = "rbtnPresentacion";
            this.rbtnPresentacion.Size = new System.Drawing.Size(87, 17);
            this.rbtnPresentacion.TabIndex = 1;
            this.rbtnPresentacion.TabStop = true;
            this.rbtnPresentacion.Text = "Presentacion";
            this.rbtnPresentacion.UseVisualStyleBackColor = true;
            this.rbtnPresentacion.CheckedChanged += new System.EventHandler(this.rbtnPresentacion_CheckedChanged);
            // 
            // rbtnIngrediente
            // 
            this.rbtnIngrediente.AutoSize = true;
            this.rbtnIngrediente.Location = new System.Drawing.Point(115, 19);
            this.rbtnIngrediente.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnIngrediente.Name = "rbtnIngrediente";
            this.rbtnIngrediente.Size = new System.Drawing.Size(78, 17);
            this.rbtnIngrediente.TabIndex = 0;
            this.rbtnIngrediente.TabStop = true;
            this.rbtnIngrediente.Text = "Ingrediente";
            this.rbtnIngrediente.UseVisualStyleBackColor = true;
            this.rbtnIngrediente.CheckedChanged += new System.EventHandler(this.rbtnIngrediente_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 500);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(910, 50);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            // 
            // dgvBuscarIngrediente
            // 
            this.dgvBuscarIngrediente.AllowUserToAddRows = false;
            this.dgvBuscarIngrediente.AllowUserToDeleteRows = false;
            this.dgvBuscarIngrediente.AllowUserToResizeColumns = false;
            this.dgvBuscarIngrediente.AllowUserToResizeRows = false;
            this.dgvBuscarIngrediente.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvBuscarIngrediente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBuscarIngrediente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscarIngrediente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.nombreIngrediente,
            this.Presentacion,
            this.Stock,
            this.Precio,
            this.Selecionar});
            this.dgvBuscarIngrediente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBuscarIngrediente.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvBuscarIngrediente.Location = new System.Drawing.Point(0, 50);
            this.dgvBuscarIngrediente.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBuscarIngrediente.MultiSelect = false;
            this.dgvBuscarIngrediente.Name = "dgvBuscarIngrediente";
            this.dgvBuscarIngrediente.ReadOnly = true;
            this.dgvBuscarIngrediente.RowHeadersVisible = false;
            this.dgvBuscarIngrediente.RowHeadersWidth = 51;
            this.dgvBuscarIngrediente.RowTemplate.Height = 24;
            this.dgvBuscarIngrediente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuscarIngrediente.Size = new System.Drawing.Size(910, 450);
            this.dgvBuscarIngrediente.TabIndex = 12;
            this.dgvBuscarIngrediente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuscarIngrediente_CellClick);
            this.dgvBuscarIngrediente.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBuscarIngrediente_ColumnHeaderMouseClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "idIngrediente";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 40;
            // 
            // nombreIngrediente
            // 
            this.nombreIngrediente.DataPropertyName = "nombre";
            this.nombreIngrediente.HeaderText = "Nombre del ingrediente ";
            this.nombreIngrediente.MinimumWidth = 6;
            this.nombreIngrediente.Name = "nombreIngrediente";
            this.nombreIngrediente.ReadOnly = true;
            this.nombreIngrediente.Width = 400;
            // 
            // Presentacion
            // 
            this.Presentacion.DataPropertyName = "unidadMedida";
            this.Presentacion.HeaderText = "Presentacion";
            this.Presentacion.MinimumWidth = 6;
            this.Presentacion.Name = "Presentacion";
            this.Presentacion.ReadOnly = true;
            this.Presentacion.Width = 400;
            // 
            // Stock
            // 
            this.Stock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Stock.DataPropertyName = "Stock";
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Visible = false;
            this.Precio.Width = 6;
            // 
            // Selecionar
            // 
            this.Selecionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Selecionar.HeaderText = "Selecionar";
            this.Selecionar.MinimumWidth = 6;
            this.Selecionar.Name = "Selecionar";
            this.Selecionar.ReadOnly = true;
            this.Selecionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Selecionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Selecionar.Visible = false;
            // 
            // BuscarIngrediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 550);
            this.Controls.Add(this.dgvBuscarIngrediente);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BuscarIngrediente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscarIngrediente";
            this.Load += new System.EventHandler(this.BuscarIngrediente_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarIngrediente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtnPresentacion;
        private System.Windows.Forms.RadioButton rbtnIngrediente;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvBuscarIngrediente;
        private System.Windows.Forms.RadioButton rbtNinguno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Presentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selecionar;
        private System.Windows.Forms.TextBox txtNombre;
    }
}