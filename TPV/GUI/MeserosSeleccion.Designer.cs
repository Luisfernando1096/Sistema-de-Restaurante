
namespace TPV.GUI
{
    partial class MeserosSeleccion
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
            this.btnFamilia = new System.Windows.Forms.Button();
            this.flpMeseros = new System.Windows.Forms.FlowLayoutPanel();
            this.flpMeseros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFamilia
            // 
            this.btnFamilia.Location = new System.Drawing.Point(3, 3);
            this.btnFamilia.Name = "btnFamilia";
            this.btnFamilia.Size = new System.Drawing.Size(187, 83);
            this.btnFamilia.TabIndex = 0;
            this.btnFamilia.UseVisualStyleBackColor = true;
            this.btnFamilia.Visible = false;
            // 
            // flpMeseros
            // 
            this.flpMeseros.AutoScroll = true;
            this.flpMeseros.Controls.Add(this.btnFamilia);
            this.flpMeseros.Location = new System.Drawing.Point(29, 24);
            this.flpMeseros.Name = "flpMeseros";
            this.flpMeseros.Size = new System.Drawing.Size(746, 391);
            this.flpMeseros.TabIndex = 2;
            this.flpMeseros.WrapContents = false;
            // 
            // MeserosSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flpMeseros);
            this.Name = "MeserosSeleccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Mesero";
            this.flpMeseros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFamilia;
        private System.Windows.Forms.FlowLayoutPanel flpMeseros;
    }
}