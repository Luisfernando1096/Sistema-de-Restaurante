﻿namespace Salones.GUI
{
    partial class SalonesMesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalonesMesas));
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.idMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disponibilidad = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idSalon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomSalon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fondo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMesas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbSalones = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumeroMesa = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNotaEs = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtContador = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnAgregarMesa = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
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
            this.idMesa,
            this.Numero,
            this.Nombre,
            this.Capacidad,
            this.Disponibilidad,
            this.idSalon,
            this.nomSalon,
            this.Fondo,
            this.nMesas});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvDatos.Location = new System.Drawing.Point(0, 126);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(1354, 441);
            this.dgvDatos.TabIndex = 21;
            this.dgvDatos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDatos_ColumnHeaderMouseClick);
            // 
            // idMesa
            // 
            this.idMesa.DataPropertyName = "idMesa";
            this.idMesa.HeaderText = "ID";
            this.idMesa.MinimumWidth = 6;
            this.idMesa.Name = "idMesa";
            this.idMesa.ReadOnly = true;
            this.idMesa.Width = 40;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.MinimumWidth = 6;
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 250;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nomMesa";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 250;
            // 
            // Capacidad
            // 
            this.Capacidad.DataPropertyName = "capacidad";
            this.Capacidad.HeaderText = "Capacidad";
            this.Capacidad.MinimumWidth = 6;
            this.Capacidad.Name = "Capacidad";
            this.Capacidad.ReadOnly = true;
            this.Capacidad.Width = 250;
            // 
            // Disponibilidad
            // 
            this.Disponibilidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Disponibilidad.DataPropertyName = "disponible";
            this.Disponibilidad.HeaderText = "Disponibilidad";
            this.Disponibilidad.MinimumWidth = 6;
            this.Disponibilidad.Name = "Disponibilidad";
            this.Disponibilidad.ReadOnly = true;
            // 
            // idSalon
            // 
            this.idSalon.DataPropertyName = "idSalon";
            this.idSalon.HeaderText = "idSalon";
            this.idSalon.MinimumWidth = 6;
            this.idSalon.Name = "idSalon";
            this.idSalon.ReadOnly = true;
            this.idSalon.Visible = false;
            this.idSalon.Width = 125;
            // 
            // nomSalon
            // 
            this.nomSalon.DataPropertyName = "nombre";
            this.nomSalon.HeaderText = "Nombe Salon";
            this.nomSalon.MinimumWidth = 6;
            this.nomSalon.Name = "nomSalon";
            this.nomSalon.ReadOnly = true;
            this.nomSalon.Visible = false;
            this.nomSalon.Width = 125;
            // 
            // Fondo
            // 
            this.Fondo.DataPropertyName = "fondo";
            this.Fondo.HeaderText = "Fondo";
            this.Fondo.MinimumWidth = 6;
            this.Fondo.Name = "Fondo";
            this.Fondo.ReadOnly = true;
            this.Fondo.Visible = false;
            this.Fondo.Width = 125;
            // 
            // nMesas
            // 
            this.nMesas.DataPropertyName = "nMesas";
            this.nMesas.HeaderText = "Numero Mesas";
            this.nMesas.MinimumWidth = 6;
            this.nMesas.Name = "nMesas";
            this.nMesas.ReadOnly = true;
            this.nMesas.Visible = false;
            this.nMesas.Width = 125;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbSalones);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtNumeroMesa);
            this.groupBox2.Controls.Add(this.txtID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 67);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1354, 59);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // cmbSalones
            // 
            this.cmbSalones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalones.FormattingEnabled = true;
            this.cmbSalones.Location = new System.Drawing.Point(143, 17);
            this.cmbSalones.Name = "cmbSalones";
            this.cmbSalones.Size = new System.Drawing.Size(263, 24);
            this.cmbSalones.TabIndex = 18;
            this.cmbSalones.SelectedIndexChanged += new System.EventHandler(this.cmbSalones_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(437, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Cantidad de mesas";
            // 
            // txtNumeroMesa
            // 
            this.txtNumeroMesa.Enabled = false;
            this.txtNumeroMesa.Location = new System.Drawing.Point(570, 17);
            this.txtNumeroMesa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumeroMesa.Name = "txtNumeroMesa";
            this.txtNumeroMesa.Size = new System.Drawing.Size(85, 22);
            this.txtNumeroMesa.TabIndex = 16;
            this.txtNumeroMesa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroMesa_KeyPress);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(743, 19);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(27, 22);
            this.txtID.TabIndex = 11;
            this.txtID.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(715, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombre del Salon:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNotaEs);
            this.groupBox1.Controls.Add(this.lblNota);
            this.groupBox1.Controls.Add(this.txtContador);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 567);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1354, 62);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // lblNotaEs
            // 
            this.lblNotaEs.AutoSize = true;
            this.lblNotaEs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotaEs.Location = new System.Drawing.Point(746, 25);
            this.lblNotaEs.Name = "lblNotaEs";
            this.lblNotaEs.Size = new System.Drawing.Size(511, 17);
            this.lblNotaEs.TabIndex = 12;
            this.lblNotaEs.Text = "Las mesas que han sido usadas al menos una ves no es posibles eliminarlas";
            this.lblNotaEs.Visible = false;
            // 
            // lblNota
            // 
            this.lblNota.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNota.Location = new System.Drawing.Point(693, 25);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(57, 26);
            this.lblNota.TabIndex = 11;
            this.lblNota.Text = "Nota:";
            this.lblNota.Visible = false;
            // 
            // txtContador
            // 
            this.txtContador.AutoSize = true;
            this.txtContador.Location = new System.Drawing.Point(12, 26);
            this.txtContador.Name = "txtContador";
            this.txtContador.Size = new System.Drawing.Size(154, 17);
            this.txtContador.TabIndex = 10;
            this.txtContador.Text = "Numero de Registros : ";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.btnCancelar,
            this.btnNuevo,
            this.btnSalir,
            this.toolStripButton7,
            this.btnEliminar,
            this.btnEditar,
            this.btnGuardar,
            this.btnLimpiar,
            this.btnAgregarMesa,
            this.toolStripLabel1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1354, 67);
            this.toolStrip2.TabIndex = 23;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 67);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Salones.Properties.Resources.ENGRANAJE;
            this.btnCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 64);
            this.btnCancelar.Text = "Atras";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(135, 64);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(112, 64);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton7.Enabled = false;
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(29, 64);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(220, 64);
            this.btnEliminar.Text = "Eliminar mesa";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(115, 64);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(149, 64);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(129, 64);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAgregarMesa
            // 
            this.btnAgregarMesa.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAgregarMesa.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarMesa.Image")));
            this.btnAgregarMesa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAgregarMesa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarMesa.Name = "btnAgregarMesa";
            this.btnAgregarMesa.Size = new System.Drawing.Size(208, 64);
            this.btnAgregarMesa.Text = "Agregar mesa";
            this.btnAgregarMesa.Visible = false;
            this.btnAgregarMesa.Click += new System.EventHandler(this.btnAgregarMesa_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 64);
            // 
            // SalonesMesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 629);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SalonesMesas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalonesMesas";
            this.Load += new System.EventHandler(this.SalonesMesas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumeroMesa;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ComboBox cmbSalones;
        private System.Windows.Forms.Label txtContador;
        private System.Windows.Forms.Label lblNotaEs;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Disponibilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSalon;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomSalon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fondo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMesas;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton btnAgregarMesa;
    }
}