namespace Personal.GUI
{
    partial class Asignar_roles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Asignar_roles));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.dgtUsuarioSin = new System.Windows.Forms.DataGridView();
            this.idEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgtUsuariosRol = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.lblPin = new System.Windows.Forms.Label();
            this.txtPinRepetido = new System.Windows.Forms.TextBox();
            this.lblRepetirPin = new System.Windows.Forms.Label();
            this.btnEnrolar = new System.Windows.Forms.Button();
            this.btnDesEnrolar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgtUsuarioSin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgtUsuariosRol)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rol Seleccionado";
            // 
            // cmbRol
            // 
            this.cmbRol.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(12, 100);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(222, 28);
            this.cmbRol.TabIndex = 1;
            this.cmbRol.SelectedValueChanged += new System.EventHandler(this.cmbRol_SelectedValueChanged);
            // 
            // dgtUsuarioSin
            // 
            this.dgtUsuarioSin.AllowUserToAddRows = false;
            this.dgtUsuarioSin.AllowUserToDeleteRows = false;
            this.dgtUsuarioSin.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Snow;
            this.dgtUsuarioSin.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgtUsuarioSin.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgtUsuarioSin.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgtUsuarioSin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgtUsuarioSin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEmpleado,
            this.Empleado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgtUsuarioSin.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgtUsuarioSin.Location = new System.Drawing.Point(12, 161);
            this.dgtUsuarioSin.MultiSelect = false;
            this.dgtUsuarioSin.Name = "dgtUsuarioSin";
            this.dgtUsuarioSin.ReadOnly = true;
            this.dgtUsuarioSin.RowHeadersVisible = false;
            this.dgtUsuarioSin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgtUsuarioSin.Size = new System.Drawing.Size(280, 170);
            this.dgtUsuarioSin.TabIndex = 2;
            // 
            // idEmpleado
            // 
            this.idEmpleado.DataPropertyName = "idEmpleado";
            this.idEmpleado.HeaderText = "ID";
            this.idEmpleado.Name = "idEmpleado";
            this.idEmpleado.ReadOnly = true;
            // 
            // Empleado
            // 
            this.Empleado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Empleado.DataPropertyName = "Empleado";
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            this.Empleado.ReadOnly = true;
            // 
            // dgtUsuariosRol
            // 
            this.dgtUsuariosRol.AllowUserToAddRows = false;
            this.dgtUsuariosRol.AllowUserToDeleteRows = false;
            this.dgtUsuariosRol.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Snow;
            this.dgtUsuariosRol.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgtUsuariosRol.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgtUsuariosRol.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgtUsuariosRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgtUsuariosRol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgtUsuariosRol.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgtUsuariosRol.Location = new System.Drawing.Point(420, 161);
            this.dgtUsuariosRol.MultiSelect = false;
            this.dgtUsuariosRol.Name = "dgtUsuariosRol";
            this.dgtUsuariosRol.ReadOnly = true;
            this.dgtUsuariosRol.RowHeadersVisible = false;
            this.dgtUsuariosRol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgtUsuariosRol.Size = new System.Drawing.Size(280, 170);
            this.dgtUsuariosRol.TabIndex = 3;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "idEmpleado";
            this.Column3.HeaderText = "ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "Empleado";
            this.Column4.HeaderText = "Empleado";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lista de empleados sin roles definidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(416, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usuarios enrolados";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir,
            this.toolStripSeparator2,
            this.btnGuardar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(716, 57);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(72, 54);
            this.btnSalir.Text = " ";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 57);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(449, 60);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 23);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.UseWaitCursor = true;
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.AutoSize = true;
            this.lblIdEmpleado.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdEmpleado.Location = new System.Drawing.Point(416, 60);
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(0, 23);
            this.lblIdEmpleado.TabIndex = 12;
            this.lblIdEmpleado.UseWaitCursor = true;
            // 
            // txtPin
            // 
            this.txtPin.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPin.Location = new System.Drawing.Point(420, 109);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(108, 26);
            this.txtPin.TabIndex = 39;
            this.txtPin.UseWaitCursor = true;
            this.txtPin.Visible = false;
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPin.Location = new System.Drawing.Point(416, 86);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(112, 20);
            this.lblPin.TabIndex = 38;
            this.lblPin.Text = "Pin de seguridad";
            this.lblPin.UseWaitCursor = true;
            this.lblPin.Visible = false;
            // 
            // txtPinRepetido
            // 
            this.txtPinRepetido.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPinRepetido.Location = new System.Drawing.Point(582, 109);
            this.txtPinRepetido.Name = "txtPinRepetido";
            this.txtPinRepetido.Size = new System.Drawing.Size(108, 26);
            this.txtPinRepetido.TabIndex = 41;
            this.txtPinRepetido.UseWaitCursor = true;
            this.txtPinRepetido.Visible = false;
            // 
            // lblRepetirPin
            // 
            this.lblRepetirPin.AutoSize = true;
            this.lblRepetirPin.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepetirPin.Location = new System.Drawing.Point(578, 86);
            this.lblRepetirPin.Name = "lblRepetirPin";
            this.lblRepetirPin.Size = new System.Drawing.Size(69, 20);
            this.lblRepetirPin.TabIndex = 40;
            this.lblRepetirPin.Text = "Repita pin";
            this.lblRepetirPin.UseWaitCursor = true;
            this.lblRepetirPin.Visible = false;
            // 
            // btnEnrolar
            // 
            this.btnEnrolar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnrolar.Image")));
            this.btnEnrolar.Location = new System.Drawing.Point(322, 191);
            this.btnEnrolar.Name = "btnEnrolar";
            this.btnEnrolar.Size = new System.Drawing.Size(75, 40);
            this.btnEnrolar.TabIndex = 42;
            this.btnEnrolar.UseVisualStyleBackColor = true;
            this.btnEnrolar.Click += new System.EventHandler(this.btnEnrolar_Click);
            // 
            // btnDesEnrolar
            // 
            this.btnDesEnrolar.Image = ((System.Drawing.Image)(resources.GetObject("btnDesEnrolar.Image")));
            this.btnDesEnrolar.Location = new System.Drawing.Point(322, 251);
            this.btnDesEnrolar.Name = "btnDesEnrolar";
            this.btnDesEnrolar.Size = new System.Drawing.Size(75, 40);
            this.btnDesEnrolar.TabIndex = 43;
            this.btnDesEnrolar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(146, 56);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Visible = false;
            // 
            // Asignar_roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 360);
            this.Controls.Add(this.btnDesEnrolar);
            this.Controls.Add(this.btnEnrolar);
            this.Controls.Add(this.txtPinRepetido);
            this.Controls.Add(this.lblRepetirPin);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.lblIdEmpleado);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgtUsuariosRol);
            this.Controls.Add(this.dgtUsuarioSin);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.label1);
            this.Name = "Asignar_roles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar roles";
            this.Load += new System.EventHandler(this.Asignar_roles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgtUsuarioSin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgtUsuariosRol)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.DataGridView dgtUsuarioSin;
        private System.Windows.Forms.DataGridView dgtUsuariosRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.TextBox txtPinRepetido;
        private System.Windows.Forms.Label lblRepetirPin;
        private System.Windows.Forms.Button btnEnrolar;
        private System.Windows.Forms.Button btnDesEnrolar;
        private System.Windows.Forms.ToolStripButton btnGuardar;
    }
}