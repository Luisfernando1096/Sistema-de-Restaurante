
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
            this.SuspendLayout();
            // 
            // flpSalones
            // 
            this.flpSalones.Location = new System.Drawing.Point(-1, -1);
            this.flpSalones.Name = "flpSalones";
            this.flpSalones.Size = new System.Drawing.Size(802, 137);
            this.flpSalones.TabIndex = 0;
            // 
            // flpMesas
            // 
            this.flpMesas.Location = new System.Drawing.Point(-1, 142);
            this.flpMesas.Name = "flpMesas";
            this.flpMesas.Size = new System.Drawing.Size(802, 304);
            this.flpMesas.TabIndex = 1;
            // 
            // PuntoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flpMesas);
            this.Controls.Add(this.flpSalones);
            this.Name = "PuntoVenta";
            this.Text = "PuntoVenta";
            this.Load += new System.EventHandler(this.PuntoVenta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSalones;
        private System.Windows.Forms.FlowLayoutPanel flpMesas;
    }
}