
namespace TPV.GUI
{
    partial class SeleccionSalonMesa
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
            this.flpMesas = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMesa = new System.Windows.Forms.Button();
            this.cmbSalon = new System.Windows.Forms.ComboBox();
            this.flpMesas.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpMesas
            // 
            this.flpMesas.AutoScroll = true;
            this.flpMesas.Controls.Add(this.btnMesa);
            this.flpMesas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMesas.Location = new System.Drawing.Point(2, 65);
            this.flpMesas.Name = "flpMesas";
            this.flpMesas.Size = new System.Drawing.Size(284, 150);
            this.flpMesas.TabIndex = 2;
            this.flpMesas.WrapContents = false;
            // 
            // btnMesa
            // 
            this.btnMesa.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMesa.Location = new System.Drawing.Point(3, 3);
            this.btnMesa.Name = "btnMesa";
            this.btnMesa.Size = new System.Drawing.Size(253, 42);
            this.btnMesa.TabIndex = 0;
            this.btnMesa.UseVisualStyleBackColor = true;
            this.btnMesa.Visible = false;
            // 
            // cmbSalon
            // 
            this.cmbSalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalon.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalon.FormattingEnabled = true;
            this.cmbSalon.Location = new System.Drawing.Point(12, 12);
            this.cmbSalon.Name = "cmbSalon";
            this.cmbSalon.Size = new System.Drawing.Size(259, 39);
            this.cmbSalon.TabIndex = 24;
            this.cmbSalon.SelectedIndexChanged += new System.EventHandler(this.cmbSalon_SelectedIndexChanged);
            // 
            // SeleccionSalonMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 259);
            this.Controls.Add(this.cmbSalon);
            this.Controls.Add(this.flpMesas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SeleccionSalonMesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione Salon y Mesa";
            this.Load += new System.EventHandler(this.SeleccionSalonMesa_Load);
            this.flpMesas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMesas;
        private System.Windows.Forms.Button btnMesa;
        private System.Windows.Forms.ComboBox cmbSalon;
    }
}