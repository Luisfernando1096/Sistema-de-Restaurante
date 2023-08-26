
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtNinguno = new System.Windows.Forms.RadioButton();
            this.bntSelecionar = new System.Windows.Forms.Button();
            this.rbtnFamilia = new System.Windows.Forms.RadioButton();
            this.rbtnProducto = new System.Windows.Forms.RadioButton();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.idProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registroContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtFiltrar);
            this.groupBox3.Controls.Add(this.rbtNinguno);
            this.groupBox3.Controls.Add(this.bntSelecionar);
            this.groupBox3.Controls.Add(this.rbtnFamilia);
            this.groupBox3.Controls.Add(this.rbtnProducto);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(800, 50);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar datos por: ";
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
            this.rbtNinguno.Text = "Nombre";
            this.rbtNinguno.UseVisualStyleBackColor = true;
            // 
            // bntSelecionar
            // 
            this.bntSelecionar.Location = new System.Drawing.Point(810, 12);
            this.bntSelecionar.Margin = new System.Windows.Forms.Padding(2);
            this.bntSelecionar.Name = "bntSelecionar";
            this.bntSelecionar.Size = new System.Drawing.Size(162, 28);
            this.bntSelecionar.TabIndex = 24;
            this.bntSelecionar.Text = "Seleccionar y salir";
            this.bntSelecionar.UseVisualStyleBackColor = true;
            this.bntSelecionar.Visible = false;
            // 
            // rbtnFamilia
            // 
            this.rbtnFamilia.AutoSize = true;
            this.rbtnFamilia.Location = new System.Drawing.Point(183, 20);
            this.rbtnFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnFamilia.Name = "rbtnFamilia";
            this.rbtnFamilia.Size = new System.Drawing.Size(43, 17);
            this.rbtnFamilia.TabIndex = 1;
            this.rbtnFamilia.TabStop = true;
            this.rbtnFamilia.Text = "NIT";
            this.rbtnFamilia.UseVisualStyleBackColor = true;
            // 
            // rbtnProducto
            // 
            this.rbtnProducto.AutoSize = true;
            this.rbtnProducto.Location = new System.Drawing.Point(114, 20);
            this.rbtnProducto.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnProducto.Name = "rbtnProducto";
            this.rbtnProducto.Size = new System.Drawing.Size(48, 17);
            this.rbtnProducto.TabIndex = 0;
            this.rbtnProducto.TabStop = true;
            this.rbtnProducto.Text = "NRC";
            this.rbtnProducto.UseVisualStyleBackColor = true;
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltrar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltrar.Location = new System.Drawing.Point(254, 15);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(311, 26);
            this.txtFiltrar.TabIndex = 79;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 28);
            this.button1.TabIndex = 80;
            this.button1.Text = "Seleccionar y salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Snow;
            this.dgvClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientes.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProveedor,
            this.proveedor,
            this.telefono,
            this.email,
            this.nit,
            this.registroContable,
            this.direccion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClientes.Location = new System.Drawing.Point(0, 55);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(794, 264);
            this.dgvClientes.TabIndex = 49;
            // 
            // idProveedor
            // 
            this.idProveedor.HeaderText = "ID";
            this.idProveedor.Name = "idProveedor";
            this.idProveedor.ReadOnly = true;
            this.idProveedor.Width = 50;
            // 
            // proveedor
            // 
            this.proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.proveedor.HeaderText = "Nombre";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // email
            // 
            this.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // nit
            // 
            this.nit.HeaderText = "Nit";
            this.nit.Name = "nit";
            this.nit.ReadOnly = true;
            // 
            // registroContable
            // 
            this.registroContable.HeaderText = "Registro Contable";
            this.registroContable.Name = "registroContable";
            this.registroContable.ReadOnly = true;
            // 
            // direccion
            // 
            this.direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // BuscarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 331);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.groupBox3);
            this.Name = "BuscarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscarProveedor";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtNinguno;
        public System.Windows.Forms.Button bntSelecionar;
        private System.Windows.Forms.RadioButton rbtnFamilia;
        private System.Windows.Forms.RadioButton rbtnProducto;
        public System.Windows.Forms.TextBox txtFiltrar;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn registroContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
    }
}