
namespace Ingredientes_y_Productos.GUI
{
    partial class BuscarProducto
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbLista = new System.Windows.Forms.ComboBox();
            this.rbtNinguno = new System.Windows.Forms.RadioButton();
            this.rbtnFamilia = new System.Windows.Forms.RadioButton();
            this.rbtnProducto = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inventariable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ConIngrediente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Foto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbLista);
            this.groupBox3.Controls.Add(this.rbtNinguno);
            this.groupBox3.Controls.Add(this.rbtnFamilia);
            this.groupBox3.Controls.Add(this.rbtnProducto);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(981, 50);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar datos por: ";
            // 
            // cmbLista
            // 
            this.cmbLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLista.FormattingEnabled = true;
            this.cmbLista.Location = new System.Drawing.Point(242, 20);
            this.cmbLista.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLista.Name = "cmbLista";
            this.cmbLista.Size = new System.Drawing.Size(283, 21);
            this.cmbLista.TabIndex = 29;
            this.cmbLista.SelectedIndexChanged += new System.EventHandler(this.cmbLista_SelectedIndexChanged);
            // 
            // rbtNinguno
            // 
            this.rbtNinguno.AutoSize = true;
            this.rbtNinguno.Location = new System.Drawing.Point(50, 20);
            this.rbtNinguno.Margin = new System.Windows.Forms.Padding(2);
            this.rbtNinguno.Name = "rbtNinguno";
            this.rbtNinguno.Size = new System.Drawing.Size(62, 17);
            this.rbtNinguno.TabIndex = 28;
            this.rbtNinguno.TabStop = true;
            this.rbtNinguno.Text = "Sin filtro";
            this.rbtNinguno.UseVisualStyleBackColor = true;
            this.rbtNinguno.CheckedChanged += new System.EventHandler(this.rbtNinguno_CheckedChanged);
            // 
            // rbtnFamilia
            // 
            this.rbtnFamilia.AutoSize = true;
            this.rbtnFamilia.Location = new System.Drawing.Point(183, 20);
            this.rbtnFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnFamilia.Name = "rbtnFamilia";
            this.rbtnFamilia.Size = new System.Drawing.Size(57, 17);
            this.rbtnFamilia.TabIndex = 1;
            this.rbtnFamilia.TabStop = true;
            this.rbtnFamilia.Text = "Familia";
            this.rbtnFamilia.UseVisualStyleBackColor = true;
            this.rbtnFamilia.CheckedChanged += new System.EventHandler(this.rbtnFamilia_CheckedChanged);
            // 
            // rbtnProducto
            // 
            this.rbtnProducto.AutoSize = true;
            this.rbtnProducto.Location = new System.Drawing.Point(114, 20);
            this.rbtnProducto.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnProducto.Name = "rbtnProducto";
            this.rbtnProducto.Size = new System.Drawing.Size(68, 17);
            this.rbtnProducto.TabIndex = 0;
            this.rbtnProducto.TabStop = true;
            this.rbtnProducto.Text = "Producto";
            this.rbtnProducto.UseVisualStyleBackColor = true;
            this.rbtnProducto.CheckedChanged += new System.EventHandler(this.rbtnProducto_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 521);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(981, 50);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Familia,
            this.Nombre,
            this.Descripcion,
            this.Costo,
            this.Precio,
            this.Unidad,
            this.Stock,
            this.StockMinimo,
            this.Inventariable,
            this.ConIngrediente,
            this.Foto,
            this.Activo});
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvProductos.Location = new System.Drawing.Point(0, 50);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(981, 471);
            this.dgvProductos.TabIndex = 9;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            this.dgvProductos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProductos_ColumnHeaderMouseClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "idProducto";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 70;
            // 
            // Familia
            // 
            this.Familia.DataPropertyName = "familia";
            this.Familia.HeaderText = "Familia";
            this.Familia.MinimumWidth = 6;
            this.Familia.Name = "Familia";
            this.Familia.ReadOnly = true;
            this.Familia.Width = 115;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 160;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 160;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "costo";
            this.Costo.HeaderText = "Costo";
            this.Costo.MinimumWidth = 6;
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            this.Costo.Width = 60;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 60;
            // 
            // Unidad
            // 
            this.Unidad.DataPropertyName = "unidadMedida";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.MinimumWidth = 6;
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            this.Unidad.Width = 110;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "stock";
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 60;
            // 
            // StockMinimo
            // 
            this.StockMinimo.DataPropertyName = "stockminimo";
            this.StockMinimo.HeaderText = "StockMinimo";
            this.StockMinimo.MinimumWidth = 6;
            this.StockMinimo.Name = "StockMinimo";
            this.StockMinimo.ReadOnly = true;
            this.StockMinimo.Width = 70;
            // 
            // Inventariable
            // 
            this.Inventariable.DataPropertyName = "inventariable";
            this.Inventariable.HeaderText = "Inventariable";
            this.Inventariable.MinimumWidth = 6;
            this.Inventariable.Name = "Inventariable";
            this.Inventariable.ReadOnly = true;
            this.Inventariable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Inventariable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Inventariable.Width = 70;
            // 
            // ConIngrediente
            // 
            this.ConIngrediente.DataPropertyName = "conIngrediente";
            this.ConIngrediente.HeaderText = "Con Ingrediente";
            this.ConIngrediente.MinimumWidth = 6;
            this.ConIngrediente.Name = "ConIngrediente";
            this.ConIngrediente.ReadOnly = true;
            this.ConIngrediente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ConIngrediente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ConIngrediente.Width = 70;
            // 
            // Foto
            // 
            this.Foto.DataPropertyName = "foto";
            this.Foto.HeaderText = "Foto";
            this.Foto.MinimumWidth = 6;
            this.Foto.Name = "Foto";
            this.Foto.ReadOnly = true;
            this.Foto.Width = 125;
            // 
            // Activo
            // 
            this.Activo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Activo.DataPropertyName = "activo";
            this.Activo.HeaderText = "Activo";
            this.Activo.MinimumWidth = 6;
            this.Activo.Name = "Activo";
            this.Activo.ReadOnly = true;
            this.Activo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Activo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BuscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 571);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BuscarProducto";
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.Buscar_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtnFamilia;
        private System.Windows.Forms.RadioButton rbtnProducto;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockMinimo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Inventariable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ConIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Foto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activo;
        private System.Windows.Forms.RadioButton rbtNinguno;
        private System.Windows.Forms.ComboBox cmbLista;
    }
}