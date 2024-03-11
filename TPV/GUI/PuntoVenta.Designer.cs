﻿
namespace TPV.GUI
{
    partial class PuntoVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuntoVenta));
            this.flpSalones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSalon = new System.Windows.Forms.Button();
            this.flpMesas = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMesa = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.flpSalones.SuspendLayout();
            this.flpMesas.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpSalones
            // 
            this.flpSalones.AutoScroll = true;
            this.flpSalones.Controls.Add(this.btnSalon);
            this.flpSalones.Location = new System.Drawing.Point(12, 74);
            this.flpSalones.Name = "flpSalones";
            this.flpSalones.Size = new System.Drawing.Size(1357, 160);
            this.flpSalones.TabIndex = 0;
            // 
            // btnSalon
            // 
            this.btnSalon.Location = new System.Drawing.Point(3, 3);
            this.btnSalon.Name = "btnSalon";
            this.btnSalon.Size = new System.Drawing.Size(98, 56);
            this.btnSalon.TabIndex = 0;
            this.btnSalon.UseVisualStyleBackColor = true;
            this.btnSalon.Visible = false;
            // 
            // flpMesas
            // 
            this.flpMesas.AutoScroll = true;
            this.flpMesas.Controls.Add(this.btnMesa);
            this.flpMesas.Location = new System.Drawing.Point(12, 284);
            this.flpMesas.Name = "flpMesas";
            this.flpMesas.Size = new System.Drawing.Size(1357, 261);
            this.flpMesas.TabIndex = 1;
            // 
            // btnMesa
            // 
            this.btnMesa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMesa.BackgroundImage = global::TPV.Properties.Resources.mesa;
            this.btnMesa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMesa.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMesa.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnMesa.Location = new System.Drawing.Point(3, 3);
            this.btnMesa.Name = "btnMesa";
            this.btnMesa.Size = new System.Drawing.Size(110, 90);
            this.btnMesa.TabIndex = 2;
            this.btnMesa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMesa.UseVisualStyleBackColor = false;
            this.btnMesa.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(898, -2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(113, 58);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // PuntoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.flpMesas);
            this.Controls.Add(this.flpSalones);
            this.MinimumSize = new System.Drawing.Size(1364, 718);
            this.Name = "PuntoVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PuntoVenta";
            this.Load += new System.EventHandler(this.PuntoVenta_Load);
            this.flpSalones.ResumeLayout(false);
            this.flpMesas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSalones;
        private System.Windows.Forms.FlowLayoutPanel flpMesas;
        private System.Windows.Forms.Button btnSalon;
        private System.Windows.Forms.Button btnMesa;
        private System.Windows.Forms.Button btnSalir;
    }
}