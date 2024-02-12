
namespace TPV.GUI
{
    partial class PedidosSeparados
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
            this.flpPedidos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPedido = new System.Windows.Forms.Button();
            this.flpPedidos.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpPedidos
            // 
            this.flpPedidos.AutoScroll = true;
            this.flpPedidos.AutoSize = true;
            this.flpPedidos.Controls.Add(this.btnPedido);
            this.flpPedidos.Location = new System.Drawing.Point(7, 15);
            this.flpPedidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpPedidos.Name = "flpPedidos";
            this.flpPedidos.Size = new System.Drawing.Size(844, 306);
            this.flpPedidos.TabIndex = 5;
            // 
            // btnPedido
            // 
            this.btnPedido.AutoSize = true;
            this.btnPedido.Location = new System.Drawing.Point(4, 4);
            this.btnPedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPedido.Name = "btnPedido";
            this.btnPedido.Size = new System.Drawing.Size(267, 98);
            this.btnPedido.TabIndex = 14;
            this.btnPedido.UseVisualStyleBackColor = true;
            this.btnPedido.Visible = false;
            // 
            // PedidosSeparados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 336);
            this.Controls.Add(this.flpPedidos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PedidosSeparados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PedidosSeparados";
            this.Load += new System.EventHandler(this.PedidosSeparados_Load);
            this.flpPedidos.ResumeLayout(false);
            this.flpPedidos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpPedidos;
        public System.Windows.Forms.Button btnPedido;
    }
}