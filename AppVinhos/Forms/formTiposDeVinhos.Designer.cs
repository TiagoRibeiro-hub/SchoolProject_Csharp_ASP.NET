
namespace AppVinhos
{
    partial class formTiposDeVinhos
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
            this.listBoxTipoVinhos = new System.Windows.Forms.ListBox();
            this.labelTiposVinhos = new System.Windows.Forms.Label();
            this.labelTipoVinhosRegistados = new System.Windows.Forms.Label();
            this.buttonEscolher = new System.Windows.Forms.Button();
            this.textBoxVinhoEscolhido = new System.Windows.Forms.TextBox();
            this.labelEscolherVinho = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxTipoVinhos
            // 
            this.listBoxTipoVinhos.FormattingEnabled = true;
            this.listBoxTipoVinhos.ItemHeight = 16;
            this.listBoxTipoVinhos.Location = new System.Drawing.Point(64, 128);
            this.listBoxTipoVinhos.Name = "listBoxTipoVinhos";
            this.listBoxTipoVinhos.Size = new System.Drawing.Size(226, 196);
            this.listBoxTipoVinhos.TabIndex = 90;
            this.listBoxTipoVinhos.SelectedIndexChanged += new System.EventHandler(this.listBoxTipoVinhos_SelectedIndexChanged);
            // 
            // labelTiposVinhos
            // 
            this.labelTiposVinhos.AutoSize = true;
            this.labelTiposVinhos.Font = new System.Drawing.Font("NSimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTiposVinhos.Location = new System.Drawing.Point(66, 8);
            this.labelTiposVinhos.Name = "labelTiposVinhos";
            this.labelTiposVinhos.Size = new System.Drawing.Size(222, 28);
            this.labelTiposVinhos.TabIndex = 92;
            this.labelTiposVinhos.Text = "TIPO DE VINHOS";
            // 
            // labelTipoVinhosRegistados
            // 
            this.labelTipoVinhosRegistados.AutoSize = true;
            this.labelTipoVinhosRegistados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoVinhosRegistados.Location = new System.Drawing.Point(58, 80);
            this.labelTipoVinhosRegistados.Name = "labelTipoVinhosRegistados";
            this.labelTipoVinhosRegistados.Size = new System.Drawing.Size(238, 20);
            this.labelTipoVinhosRegistados.TabIndex = 93;
            this.labelTipoVinhosRegistados.Text = "Tipo De Vinhos Registados";
            // 
            // buttonEscolher
            // 
            this.buttonEscolher.Location = new System.Drawing.Point(117, 447);
            this.buttonEscolher.Name = "buttonEscolher";
            this.buttonEscolher.Size = new System.Drawing.Size(120, 30);
            this.buttonEscolher.TabIndex = 94;
            this.buttonEscolher.Text = "Sair";
            this.buttonEscolher.UseVisualStyleBackColor = true;
            this.buttonEscolher.Click += new System.EventHandler(this.buttonEscolher_Click);
            // 
            // textBoxVinhoEscolhido
            // 
            this.textBoxVinhoEscolhido.Location = new System.Drawing.Point(97, 386);
            this.textBoxVinhoEscolhido.Name = "textBoxVinhoEscolhido";
            this.textBoxVinhoEscolhido.ReadOnly = true;
            this.textBoxVinhoEscolhido.Size = new System.Drawing.Size(161, 22);
            this.textBoxVinhoEscolhido.TabIndex = 95;
            this.textBoxVinhoEscolhido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxVinhoEscolhido.Visible = false;
            this.textBoxVinhoEscolhido.WordWrap = false;
            // 
            // labelEscolherVinho
            // 
            this.labelEscolherVinho.AutoSize = true;
            this.labelEscolherVinho.Location = new System.Drawing.Point(123, 352);
            this.labelEscolherVinho.Name = "labelEscolherVinho";
            this.labelEscolherVinho.Size = new System.Drawing.Size(109, 17);
            this.labelEscolherVinho.TabIndex = 96;
            this.labelEscolherVinho.Text = "Vinho Escolhido";
            this.labelEscolherVinho.Visible = false;
            // 
            // formTiposDeVinhos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 513);
            this.Controls.Add(this.labelEscolherVinho);
            this.Controls.Add(this.textBoxVinhoEscolhido);
            this.Controls.Add(this.buttonEscolher);
            this.Controls.Add(this.labelTipoVinhosRegistados);
            this.Controls.Add(this.labelTiposVinhos);
            this.Controls.Add(this.listBoxTipoVinhos);
            this.Name = "formTiposDeVinhos";
            this.Text = "formTiposDeVinhos";
            this.Load += new System.EventHandler(this.formTiposDeVinhos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxTipoVinhos;
        private System.Windows.Forms.Label labelTiposVinhos;
        private System.Windows.Forms.Label labelTipoVinhosRegistados;
        private System.Windows.Forms.Button buttonEscolher;
        private System.Windows.Forms.TextBox textBoxVinhoEscolhido;
        private System.Windows.Forms.Label labelEscolherVinho;
    }
}