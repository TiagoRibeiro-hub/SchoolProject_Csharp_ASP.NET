
namespace AppVinhos
{
    partial class formListaCastacs
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
            this.labelContemCastas = new System.Windows.Forms.Label();
            this.labelListaVinhoCastas = new System.Windows.Forms.Label();
            this.listBoxVinhoCasta = new System.Windows.Forms.ListBox();
            this.buttonDissociarCastas = new System.Windows.Forms.Button();
            this.textBoxCastaEscolhida = new System.Windows.Forms.TextBox();
            this.labelCastaEscolhida = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelContemCastas
            // 
            this.labelContemCastas.AutoSize = true;
            this.labelContemCastas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContemCastas.Location = new System.Drawing.Point(18, 84);
            this.labelContemCastas.Name = "labelContemCastas";
            this.labelContemCastas.Size = new System.Drawing.Size(283, 40);
            this.labelContemCastas.TabIndex = 103;
            this.labelContemCastas.Text = "Este vinho contem as seguintes \r\n                Castas";
            // 
            // labelListaVinhoCastas
            // 
            this.labelListaVinhoCastas.AutoSize = true;
            this.labelListaVinhoCastas.Font = new System.Drawing.Font("NSimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListaVinhoCastas.Location = new System.Drawing.Point(108, 25);
            this.labelListaVinhoCastas.Name = "labelListaVinhoCastas";
            this.labelListaVinhoCastas.Size = new System.Drawing.Size(102, 28);
            this.labelListaVinhoCastas.TabIndex = 102;
            this.labelListaVinhoCastas.Text = "CASTAS";
            // 
            // listBoxVinhoCasta
            // 
            this.listBoxVinhoCasta.FormattingEnabled = true;
            this.listBoxVinhoCasta.ItemHeight = 16;
            this.listBoxVinhoCasta.Location = new System.Drawing.Point(46, 178);
            this.listBoxVinhoCasta.Name = "listBoxVinhoCasta";
            this.listBoxVinhoCasta.Size = new System.Drawing.Size(226, 196);
            this.listBoxVinhoCasta.TabIndex = 101;
            this.listBoxVinhoCasta.SelectedIndexChanged += new System.EventHandler(this.listBoxVinhoCasta_SelectedIndexChanged);
            // 
            // buttonDissociarCastas
            // 
            this.buttonDissociarCastas.Location = new System.Drawing.Point(99, 504);
            this.buttonDissociarCastas.Name = "buttonDissociarCastas";
            this.buttonDissociarCastas.Size = new System.Drawing.Size(120, 53);
            this.buttonDissociarCastas.TabIndex = 105;
            this.buttonDissociarCastas.Text = "Dissociar Castas";
            this.buttonDissociarCastas.UseVisualStyleBackColor = true;
            this.buttonDissociarCastas.Click += new System.EventHandler(this.buttonDissociarCastas_Click);
            // 
            // textBoxCastaEscolhida
            // 
            this.textBoxCastaEscolhida.Location = new System.Drawing.Point(86, 444);
            this.textBoxCastaEscolhida.Name = "textBoxCastaEscolhida";
            this.textBoxCastaEscolhida.ReadOnly = true;
            this.textBoxCastaEscolhida.Size = new System.Drawing.Size(146, 22);
            this.textBoxCastaEscolhida.TabIndex = 106;
            this.textBoxCastaEscolhida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCastaEscolhida
            // 
            this.labelCastaEscolhida.AutoSize = true;
            this.labelCastaEscolhida.Location = new System.Drawing.Point(105, 402);
            this.labelCastaEscolhida.Name = "labelCastaEscolhida";
            this.labelCastaEscolhida.Size = new System.Drawing.Size(109, 17);
            this.labelCastaEscolhida.TabIndex = 107;
            this.labelCastaEscolhida.Text = "Casta Escolhida";
            // 
            // formListaCastacs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(354, 585);
            this.Controls.Add(this.labelCastaEscolhida);
            this.Controls.Add(this.textBoxCastaEscolhida);
            this.Controls.Add(this.buttonDissociarCastas);
            this.Controls.Add(this.labelContemCastas);
            this.Controls.Add(this.labelListaVinhoCastas);
            this.Controls.Add(this.listBoxVinhoCasta);
            this.Name = "formListaCastacs";
            this.Text = "formListaCastacs";
            this.Load += new System.EventHandler(this.formListaCastacs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelContemCastas;
        private System.Windows.Forms.Label labelListaVinhoCastas;
        private System.Windows.Forms.ListBox listBoxVinhoCasta;
        private System.Windows.Forms.Button buttonDissociarCastas;
        private System.Windows.Forms.TextBox textBoxCastaEscolhida;
        private System.Windows.Forms.Label labelCastaEscolhida;
    }
}