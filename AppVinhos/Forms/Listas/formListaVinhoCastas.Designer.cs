
namespace AppVinhos
{
    partial class formListaVinhoCastas
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
            this.comboBoxEscolherVinho = new System.Windows.Forms.ComboBox();
            this.labelVinhoEscolhida = new System.Windows.Forms.Label();
            this.labelContemCastas = new System.Windows.Forms.Label();
            this.labelListaVinhoCastas = new System.Windows.Forms.Label();
            this.listBoxVinhoCasta = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // comboBoxEscolherVinho
            // 
            this.comboBoxEscolherVinho.FormattingEnabled = true;
            this.comboBoxEscolherVinho.Location = new System.Drawing.Point(95, 143);
            this.comboBoxEscolherVinho.Name = "comboBoxEscolherVinho";
            this.comboBoxEscolherVinho.Size = new System.Drawing.Size(145, 24);
            this.comboBoxEscolherVinho.TabIndex = 122;
            this.comboBoxEscolherVinho.SelectedIndexChanged += new System.EventHandler(this.comboBoxEscolherVinho_SelectedIndexChanged);
            // 
            // labelVinhoEscolhida
            // 
            this.labelVinhoEscolhida.AutoSize = true;
            this.labelVinhoEscolhida.Location = new System.Drawing.Point(113, 96);
            this.labelVinhoEscolhida.Name = "labelVinhoEscolhida";
            this.labelVinhoEscolhida.Size = new System.Drawing.Size(109, 17);
            this.labelVinhoEscolhida.TabIndex = 121;
            this.labelVinhoEscolhida.Text = "Vinho Escolhida";
            // 
            // labelContemCastas
            // 
            this.labelContemCastas.AutoSize = true;
            this.labelContemCastas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContemCastas.Location = new System.Drawing.Point(27, 197);
            this.labelContemCastas.Name = "labelContemCastas";
            this.labelContemCastas.Size = new System.Drawing.Size(283, 40);
            this.labelContemCastas.TabIndex = 119;
            this.labelContemCastas.Text = "Este vinho contem as seguintes \r\n                Castas";
            // 
            // labelListaVinhoCastas
            // 
            this.labelListaVinhoCastas.AutoSize = true;
            this.labelListaVinhoCastas.Font = new System.Drawing.Font("NSimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListaVinhoCastas.Location = new System.Drawing.Point(116, 18);
            this.labelListaVinhoCastas.Name = "labelListaVinhoCastas";
            this.labelListaVinhoCastas.Size = new System.Drawing.Size(102, 28);
            this.labelListaVinhoCastas.TabIndex = 118;
            this.labelListaVinhoCastas.Text = "CASTAS";
            // 
            // listBoxVinhoCasta
            // 
            this.listBoxVinhoCasta.FormattingEnabled = true;
            this.listBoxVinhoCasta.ItemHeight = 16;
            this.listBoxVinhoCasta.Location = new System.Drawing.Point(55, 267);
            this.listBoxVinhoCasta.Name = "listBoxVinhoCasta";
            this.listBoxVinhoCasta.Size = new System.Drawing.Size(226, 196);
            this.listBoxVinhoCasta.TabIndex = 117;
            // 
            // formListaVinhoCastas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 518);
            this.Controls.Add(this.comboBoxEscolherVinho);
            this.Controls.Add(this.labelVinhoEscolhida);
            this.Controls.Add(this.labelContemCastas);
            this.Controls.Add(this.labelListaVinhoCastas);
            this.Controls.Add(this.listBoxVinhoCasta);
            this.Name = "formListaVinhoCastas";
            this.Text = "formListaVinhoCastas";
            this.Load += new System.EventHandler(this.formListaVinhoCastas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEscolherVinho;
        private System.Windows.Forms.Label labelVinhoEscolhida;
        private System.Windows.Forms.Label labelContemCastas;
        private System.Windows.Forms.Label labelListaVinhoCastas;
        private System.Windows.Forms.ListBox listBoxVinhoCasta;
    }
}