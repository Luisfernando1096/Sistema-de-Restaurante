
namespace Reportes.GUI
{
    partial class VisorComandaCompleta
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
            this.crvComandaCompleta = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvComandaCompleta
            // 
            this.crvComandaCompleta.ActiveViewIndex = -1;
            this.crvComandaCompleta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvComandaCompleta.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvComandaCompleta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvComandaCompleta.Location = new System.Drawing.Point(0, 0);
            this.crvComandaCompleta.Name = "crvComandaCompleta";
            this.crvComandaCompleta.Size = new System.Drawing.Size(800, 450);
            this.crvComandaCompleta.TabIndex = 0;
            this.crvComandaCompleta.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // VisorComandaCompleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvComandaCompleta);
            this.Name = "VisorComandaCompleta";
            this.Text = "VisorComandaCompleta";
            this.Load += new System.EventHandler(this.VisorComandaCompleta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvComandaCompleta;
    }
}