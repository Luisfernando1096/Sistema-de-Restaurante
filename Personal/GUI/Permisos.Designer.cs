namespace Personal.GUI
{
    partial class Permisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Permisos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.dgvDatosOtorgados = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvPermisosDisponibles = new System.Windows.Forms.DataGridView();
            this.idComandoDisponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comandoDisponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idComandoOtorgado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comandoOtorgado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosOtorgados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisosDisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1326, 57);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(122, 54);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 57);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 44;
            this.label1.Text = "Rol Seleccionado";
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(27, 79);
            this.cmbRol.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(295, 32);
            this.cmbRol.TabIndex = 45;
            this.cmbRol.SelectedIndexChanged += new System.EventHandler(this.cmbRol_SelectedIndexChanged);
            // 
            // dgvDatosOtorgados
            // 
            this.dgvDatosOtorgados.AllowUserToAddRows = false;
            this.dgvDatosOtorgados.AllowUserToDeleteRows = false;
            this.dgvDatosOtorgados.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Snow;
            this.dgvDatosOtorgados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDatosOtorgados.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvDatosOtorgados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvDatosOtorgados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosOtorgados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idComandoOtorgado,
            this.comandoOtorgado});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatosOtorgados.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDatosOtorgados.Location = new System.Drawing.Point(729, 154);
            this.dgvDatosOtorgados.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDatosOtorgados.MultiSelect = false;
            this.dgvDatosOtorgados.Name = "dgvDatosOtorgados";
            this.dgvDatosOtorgados.ReadOnly = true;
            this.dgvDatosOtorgados.RowHeadersVisible = false;
            this.dgvDatosOtorgados.RowHeadersWidth = 51;
            this.dgvDatosOtorgados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosOtorgados.Size = new System.Drawing.Size(543, 303);
            this.dgvDatosOtorgados.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 24);
            this.label2.TabIndex = 48;
            this.label2.Text = "Permisos disponibles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(725, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 24);
            this.label3.TabIndex = 49;
            this.label3.Text = "Permisos otorgados";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.Location = new System.Drawing.Point(595, 301);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(100, 49);
            this.btnQuitar.TabIndex = 52;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(595, 227);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 49);
            this.btnAgregar.TabIndex = 51;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvPermisosDisponibles
            // 
            this.dgvPermisosDisponibles.AllowUserToAddRows = false;
            this.dgvPermisosDisponibles.AllowUserToDeleteRows = false;
            this.dgvPermisosDisponibles.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Snow;
            this.dgvPermisosDisponibles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPermisosDisponibles.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvPermisosDisponibles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvPermisosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisosDisponibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idComandoDisponible,
            this.comandoDisponible});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPermisosDisponibles.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPermisosDisponibles.Location = new System.Drawing.Point(27, 154);
            this.dgvPermisosDisponibles.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPermisosDisponibles.MultiSelect = false;
            this.dgvPermisosDisponibles.Name = "dgvPermisosDisponibles";
            this.dgvPermisosDisponibles.ReadOnly = true;
            this.dgvPermisosDisponibles.RowHeadersVisible = false;
            this.dgvPermisosDisponibles.RowHeadersWidth = 51;
            this.dgvPermisosDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPermisosDisponibles.Size = new System.Drawing.Size(543, 303);
            this.dgvPermisosDisponibles.TabIndex = 53;
            // 
            // idComandoDisponible
            // 
            this.idComandoDisponible.DataPropertyName = "idComando";
            this.idComandoDisponible.HeaderText = "ID";
            this.idComandoDisponible.MinimumWidth = 6;
            this.idComandoDisponible.Name = "idComandoDisponible";
            this.idComandoDisponible.ReadOnly = true;
            this.idComandoDisponible.Width = 60;
            // 
            // comandoDisponible
            // 
            this.comandoDisponible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.comandoDisponible.DataPropertyName = "comando";
            this.comandoDisponible.HeaderText = "Permisos";
            this.comandoDisponible.MinimumWidth = 6;
            this.comandoDisponible.Name = "comandoDisponible";
            this.comandoDisponible.ReadOnly = true;
            // 
            // idComandoOtorgado
            // 
            this.idComandoOtorgado.DataPropertyName = "idComando";
            this.idComandoOtorgado.HeaderText = "ID";
            this.idComandoOtorgado.MinimumWidth = 6;
            this.idComandoOtorgado.Name = "idComandoOtorgado";
            this.idComandoOtorgado.ReadOnly = true;
            this.idComandoOtorgado.Width = 60;
            // 
            // comandoOtorgado
            // 
            this.comandoOtorgado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.comandoOtorgado.DataPropertyName = "comando";
            this.comandoOtorgado.HeaderText = "Permisos";
            this.comandoOtorgado.MinimumWidth = 6;
            this.comandoOtorgado.Name = "comandoOtorgado";
            this.comandoOtorgado.ReadOnly = true;
            // 
            // Permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 619);
            this.Controls.Add(this.dgvPermisosDisponibles);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDatosOtorgados);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Permisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permisos";
            this.Load += new System.EventHandler(this.Permisos_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosOtorgados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisosDisponibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.DataGridView dgvDatosOtorgados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvPermisosDisponibles;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComandoOtorgado;
        private System.Windows.Forms.DataGridViewTextBoxColumn comandoOtorgado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComandoDisponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn comandoDisponible;
    }
}