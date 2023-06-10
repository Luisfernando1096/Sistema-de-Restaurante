
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
            this.flpSalones = new System.Windows.Forms.FlowLayoutPanel();
            this.flpMesas = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSalon = new System.Windows.Forms.Button();
            this.btnMesa = new System.Windows.Forms.Button();
            this.flpSalones.SuspendLayout();
            this.flpMesas.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpSalones
            // 
            this.flpSalones.AutoScroll = true;
            this.flpSalones.AutoSize = true;
            this.flpSalones.Controls.Add(this.btnSalon);
            this.flpSalones.Location = new System.Drawing.Point(5, 99);
            this.flpSalones.Name = "flpSalones";
            this.flpSalones.Size = new System.Drawing.Size(1056, 180);
            this.flpSalones.TabIndex = 0;
            // 
            // flpMesas
            // 
            this.flpMesas.AutoScroll = true;
            this.flpMesas.AutoSize = true;
            this.flpMesas.Controls.Add(this.btnMesa);
            this.flpMesas.Location = new System.Drawing.Point(5, 285);
            this.flpMesas.Name = "flpMesas";
            this.flpMesas.Size = new System.Drawing.Size(1056, 261);
            this.flpMesas.TabIndex = 1;
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
            // PuntoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 553);
            this.Controls.Add(this.flpMesas);
            this.Controls.Add(this.flpSalones);
            this.Name = "PuntoVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PuntoVenta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PuntoVenta_Load);
            this.flpSalones.ResumeLayout(false);
            this.flpMesas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSalones;
        private System.Windows.Forms.FlowLayoutPanel flpMesas;
        private System.Windows.Forms.Button btnSalon;
        private System.Windows.Forms.Button btnMesa;
    }
}