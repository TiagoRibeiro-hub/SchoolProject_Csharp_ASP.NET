
namespace AppVinhos
{
    partial class formListaVinhoEnologos
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
            this.labelEnologoEscolhido = new System.Windows.Forms.Label();
            this.textBoxEnologoEscolhido = new System.Windows.Forms.TextBox();
            this.buttonDissociarEnologos = new System.Windows.Forms.Button();
            this.labelContemEnologos = new System.Windows.Forms.Label();
            this.labelVinhoEnologos = new System.Windows.Forms.Label();
            this.listBoxVinhosEnologos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelEnologoEscolhido
            // 
            this.labelEnologoEscolhido.AutoSize = true;
            this.labelEnologoEscolhido.Location = new System.Drawing.Point(114, 402);
            this.labelEnologoEscolhido.Name = "labelEnologoEscolhido";
            this.labelEnologoEscolhido.Size = new System.Drawing.Size(125, 17);
            this.labelEnologoEscolhido.TabIndex = 119;
            this.labelEnologoEscolhido.Text = "Enologo Escolhida";
            // 
            // textBoxEnologoEscolhido
            // 
            this.textBoxEnologoEscolhido.Location = new System.Drawing.Point(103, 444);
            this.textBoxEnologoEscolhido.Name = "textBoxEnologoEscolhido";
            this.textBoxEnologoEscolhido.ReadOnly = true;
            this.textBoxEnologoEscolhido.Size = new System.Drawing.Size(146, 22);
            this.textBoxEnologoEscolhido.TabIndex = 118;
            this.textBoxEnologoEscolhido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonDissociarEnologos
            // 
            this.buttonDissociarEnologos.Location = new System.Drawing.Point(116, 504);
            this.buttonDissociarEnologos.Name = "buttonDissociarEnologos";
            this.buttonDissociarEnologos.Size = new System.Drawing.Size(120, 53);
            this.buttonDissociarEnologos.TabIndex = 117;
            this.buttonDissociarEnologos.Text = "Dissociar Enologos";
            this.buttonDissociarEnologos.UseVisualStyleBackColor = true;
            this.buttonDissociarEnologos.Click += new System.EventHandler(this.buttonDissociarEnologos_Click);
            // 
            // labelContemEnologos
            // 
            this.labelContemEnologos.AutoSize = true;
            this.labelContemEnologos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContemEnologos.Location = new System.Drawing.Point(36, 84);
            this.labelContemEnologos.Name = "labelContemEnologos";
            this.labelContemEnologos.Size = new System.Drawing.Size(280, 20);
            this.labelContemEnologos.TabIndex = 116;
            this.labelContemEnologos.Text = "Criação dos seguintes Enologos";
            // 
            // labelVinhoEnologos
            // 
            this.labelVinhoEnologos.AutoSize = true;
            this.labelVinhoEnologos.Font = new System.Drawing.Font("NSimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVinhoEnologos.Location = new System.Drawing.Point(65, 25);
            this.labelVinhoEnologos.Name = "labelVinhoEnologos";
            this.labelVinhoEnologos.Size = new System.Drawing.Size(222, 28);
            this.labelVinhoEnologos.TabIndex = 115;
            this.labelVinhoEnologos.Text = "VINHO ENOLOGOS";
            // 
            // listBoxVinhosEnologos
            // 
            this.listBoxVinhosEnologos.FormattingEnabled = true;
            this.listBoxVinhosEnologos.ItemHeight = 16;
            this.listBoxVinhosEnologos.Location = new System.Drawing.Point(63, 178);
            this.listBoxVinhosEnologos.Name = "listBoxVinhosEnologos";
            this.listBoxVinhosEnologos.Size = new System.Drawing.Size(226, 196);
            this.listBoxVinhosEnologos.TabIndex = 114;
            this.listBoxVinhosEnologos.SelectedIndexChanged += new System.EventHandler(this.listBoxVinhosEnologos_SelectedIndexChanged);
            // 
            // formListaVinhoEnologos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 585);
            this.Controls.Add(this.labelEnologoEscolhido);
            this.Controls.Add(this.textBoxEnologoEscolhido);
            this.Controls.Add(this.buttonDissociarEnologos);
            this.Controls.Add(this.labelContemEnologos);
            this.Controls.Add(this.labelVinhoEnologos);
            this.Controls.Add(this.listBoxVinhosEnologos);
            this.Name = "formListaVinhoEnologos";
            this.Text = "formListaVinhoEnologos";
            this.Load += new System.EventHandler(this.formListaVinhoEnologos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEnologoEscolhido;
        private System.Windows.Forms.TextBox textBoxEnologoEscolhido;
        private System.Windows.Forms.Button buttonDissociarEnologos;
        private System.Windows.Forms.Label labelContemEnologos;
        private System.Windows.Forms.Label labelVinhoEnologos;
        private System.Windows.Forms.ListBox listBoxVinhosEnologos;
    }
}