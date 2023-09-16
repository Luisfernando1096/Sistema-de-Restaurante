
namespace TPV.GUI
{
    partial class DividirPago
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblPago = new System.Windows.Forms.Label();
            this.lblReunido = new System.Windows.Forms.Label();
            this.lblSobrara = new System.Windows.Forms.Label();
            this.lblFaltara = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFaltara);
            this.groupBox1.Controls.Add(this.lblSobrara);
            this.groupBox1.Controls.Add(this.lblReunido);
            this.groupBox1.Controls.Add(this.lblPago);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "¿Entre cuantas personas quiere dividir la cuenta?";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(6, 46);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(117, 26);
            this.txtCantidad.TabIndex = 0;
            this.txtCantidad.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Location = new System.Drawing.Point(6, 85);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(13, 20);
            this.lblPago.TabIndex = 1;
            this.lblPago.Text = " ";
            // 
            // lblReunido
            // 
            this.lblReunido.AutoSize = true;
            this.lblReunido.Location = new System.Drawing.Point(6, 105);
            this.lblReunido.Name = "lblReunido";
            this.lblReunido.Size = new System.Drawing.Size(0, 20);
            this.lblReunido.TabIndex = 2;
            // 
            // lblSobrara
            // 
            this.lblSobrara.AutoSize = true;
            this.lblSobrara.Location = new System.Drawing.Point(6, 125);
            this.lblSobrara.Name = "lblSobrara";
            this.lblSobrara.Size = new System.Drawing.Size(0, 20);
            this.lblSobrara.TabIndex = 3;
            // 
            // lblFaltara
            // 
            this.lblFaltara.AutoSize = true;
            this.lblFaltara.Location = new System.Drawing.Point(6, 125);
            this.lblFaltara.Name = "lblFaltara";
            this.lblFaltara.Size = new System.Drawing.Size(0, 20);
            this.lblFaltara.TabIndex = 4;
            // 
            // DividirPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 212);
            this.Controls.Add(this.groupBox1);
            this.Name = "DividirPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dividir cuenta entre N personas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFaltara;
        private System.Windows.Forms.Label lblSobrara;
        private System.Windows.Forms.Label lblReunido;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.TextBox txtCantidad;
    }
}