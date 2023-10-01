
namespace Compras.GUI
{
    partial class BuscarProveedor
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
            this.idProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtnNIT = new System.Windows.Forms.RadioButton();
            this.cmbLista = new System.Windows.Forms.ComboBox();
            this.bntSelecionar = new System.Windows.Forms.Button();
            this.rbtnNRC = new System.Windows.Forms.RadioButton();
            this.rbtnNombre = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscar)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.idProveedor,
            this.nombre,
            this.email,
            this.telefono,
            this.NIT,
            this.regContable,
            this.contacto,
            this.direccion});
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
            this.dgvBuscar.TabIndex = 15;
            // 
            // idProveedor
            // 
            this.idProveedor.DataPropertyName = "idProveedor";
            this.idProveedor.HeaderText = "ID";
            this.idProveedor.MinimumWidth = 6;
            this.idProveedor.Name = "idProveedor";
            this.idProveedor.ReadOnly = true;
            this.idProveedor.Width = 40;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre proveedor";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 150;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 150;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "telefono";
            this.telefono.HeaderText = "Telefono";
            this.telefono.MinimumWidth = 6;
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            this.telefono.Width = 125;
            // 
            // NIT
            // 
            this.NIT.DataPropertyName = "NIT";
            this.NIT.HeaderText = "NIT";
            this.NIT.MinimumWidth = 6;
            this.NIT.Name = "NIT";
            this.NIT.ReadOnly = true;
            this.NIT.Width = 125;
            // 
            // regContable
            // 
            this.regContable.DataPropertyName = "regContable";
            this.regContable.HeaderText = "regContable";
            this.regContable.MinimumWidth = 6;
            this.regContable.Name = "regContable";
            this.regContable.ReadOnly = true;
            this.regContable.Width = 125;
            // 
            // contacto
            // 
            this.contacto.DataPropertyName = "contacto";
            this.contacto.HeaderText = "Contacto";
            this.contacto.MinimumWidth = 6;
            this.contacto.Name = "contacto";
            this.contacto.ReadOnly = true;
            this.contacto.Width = 125;
            // 
            // direccion
            // 
            this.direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.direccion.DataPropertyName = "direccion";
            this.direccion.HeaderText = "Direccion";
            this.direccion.MinimumWidth = 6;
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnNIT);
            this.groupBox3.Controls.Add(this.cmbLista);
            this.groupBox3.Controls.Add(this.bntSelecionar);
            this.groupBox3.Controls.Add(this.rbtnNRC);
            this.groupBox3.Controls.Add(this.rbtnNombre);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1378, 62);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar datos por: ";
            // 
            // rbtnNIT
            // 
            this.rbtnNIT.AutoSize = true;
            this.rbtnNIT.Location = new System.Drawing.Point(212, 25);
            this.rbtnNIT.Name = "rbtnNIT";
            this.rbtnNIT.Size = new System.Drawing.Size(51, 21);
            this.rbtnNIT.TabIndex = 28;
            this.rbtnNIT.TabStop = true;
            this.rbtnNIT.Text = "NIT";
            this.rbtnNIT.UseVisualStyleBackColor = true;
            this.rbtnNIT.CheckedChanged += new System.EventHandler(this.rbtnNIT_CheckedChanged);
            // 
            // cmbLista
            // 
            this.cmbLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbLista.FormattingEnabled = true;
            this.cmbLista.Location = new System.Drawing.Point(292, 23);
            this.cmbLista.Name = "cmbLista";
            this.cmbLista.Size = new System.Drawing.Size(376, 24);
            this.cmbLista.TabIndex = 26;
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
            // rbtnNRC
            // 
            this.rbtnNRC.AutoSize = true;
            this.rbtnNRC.Location = new System.Drawing.Point(141, 25);
            this.rbtnNRC.Name = "rbtnNRC";
            this.rbtnNRC.Size = new System.Drawing.Size(58, 21);
            this.rbtnNRC.TabIndex = 1;
            this.rbtnNRC.TabStop = true;
            this.rbtnNRC.Text = "NRC";
            this.rbtnNRC.UseVisualStyleBackColor = true;
            this.rbtnNRC.CheckedChanged += new System.EventHandler(this.rbtnNRC_CheckedChanged);
            // 
            // rbtnNombre
            // 
            this.rbtnNombre.AutoSize = true;
            this.rbtnNombre.Location = new System.Drawing.Point(53, 24);
            this.rbtnNombre.Name = "rbtnNombre";
            this.rbtnNombre.Size = new System.Drawing.Size(79, 21);
            this.rbtnNombre.TabIndex = 0;
            this.rbtnNombre.TabStop = true;
            this.rbtnNombre.Text = "Nombre";
            this.rbtnNombre.UseVisualStyleBackColor = true;
            this.rbtnNombre.CheckedChanged += new System.EventHandler(this.rbtnNombre_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 477);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1378, 62);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            // 
            // BuscarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 539);
            this.Controls.Add(this.dgvBuscar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BuscarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscarProveedor";
            this.Load += new System.EventHandler(this.BuscarProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBuscar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtnNIT;
        private System.Windows.Forms.ComboBox cmbLista;
        public System.Windows.Forms.Button bntSelecionar;
        private System.Windows.Forms.RadioButton rbtnNRC;
        private System.Windows.Forms.RadioButton rbtnNombre;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn regContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
    }
}