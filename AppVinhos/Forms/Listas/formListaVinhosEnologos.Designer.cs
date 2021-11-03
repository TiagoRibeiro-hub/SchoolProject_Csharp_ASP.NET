
namespace AppVinhos
{
    partial class formListaVinhosEnologos
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
            this.labelContemEnologos = new System.Windows.Forms.Label();
            this.labelVinhoEnologos = new System.Windows.Forms.Label();
            this.listBoxVinhosEnologos = new System.Windows.Forms.ListBox();
            this.comboBoxEscolherEnologo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelEnologoEscolhido
            // 
            this.labelEnologoEscolhido.AutoSize = true;
            this.labelEnologoEscolhido.Location = new System.Drawing.Point(115, 89);
            this.labelEnologoEscolhido.Name = "labelEnologoEscolhido";
            this.labelEnologoEscolhido.Size = new System.Drawing.Size(109, 17);
            this.labelEnologoEscolhido.TabIndex = 123;
            this.labelEnologoEscolhido.Text = "Vinho Escolhido";
            // 
            // labelContemEnologos
            // 
            this.labelContemEnologos.AutoSize = true;
            this.labelContemEnologos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContemEnologos.Location = new System.Drawing.Point(37, 200);
            this.labelContemEnologos.Name = "labelContemEnologos";
            this.labelContemEnologos.Size = new System.Drawing.Size(280, 20);
            this.labelContemEnologos.TabIndex = 122;
            this.labelContemEnologos.Text = "Criação dos seguintes Enologos";
            // 
            // labelVinhoEnologos
            // 
            this.labelVinhoEnologos.AutoSize = true;
            this.labelVinhoEnologos.Font = new System.Drawing.Font("NSimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVinhoEnologos.Location = new System.Drawing.Point(66, 9);
            this.labelVinhoEnologos.Name = "labelVinhoEnologos";
            this.labelVinhoEnologos.Size = new System.Drawing.Size(222, 28);
            this.labelVinhoEnologos.TabIndex = 121;
            this.labelVinhoEnologos.Text = "VINHO ENOLOGOS";
            // 
            // listBoxVinhosEnologos
            // 
            this.listBoxVinhosEnologos.FormattingEnabled = true;
            this.listBoxVinhosEnologos.ItemHeight = 16;
            this.listBoxVinhosEnologos.Location = new System.Drawing.Point(64, 255);
            this.listBoxVinhosEnologos.Name = "listBoxVinhosEnologos";
            this.listBoxVinhosEnologos.Size = new System.Drawing.Size(226, 196);
            this.listBoxVinhosEnologos.TabIndex = 120;
            // 
            // comboBoxEscolherEnologo
            // 
            this.comboBoxEscolherEnologo.FormattingEnabled = true;
            this.comboBoxEscolherEnologo.Location = new System.Drawing.Point(105, 141);
            this.comboBoxEscolherEnologo.Name = "comboBoxEscolherEnologo";
            this.comboBoxEscolherEnologo.Size = new System.Drawing.Size(145, 24);
            this.comboBoxEscolherEnologo.TabIndex = 124;
            this.comboBoxEscolherEnologo.SelectedIndexChanged += new System.EventHandler(this.comboBoxEscolherEnologo_SelectedIndexChanged);
            // 
            // formListaVinhosEnologos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 518);
            this.Controls.Add(this.comboBoxEscolherEnologo);
            this.Controls.Add(this.labelEnologoEscolhido);
            this.Controls.Add(this.labelContemEnologos);
            this.Controls.Add(this.labelVinhoEnologos);
            this.Controls.Add(this.listBoxVinhosEnologos);
            this.Name = "formListaVinhosEnologos";
            this.Text = "formListaVinhosEnologos";
            this.Load += new System.EventHandler(this.formListaVinhosEnologos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEnologoEscolhido;
        private System.Windows.Forms.Label labelContemEnologos;
        private System.Windows.Forms.Label labelVinhoEnologos;
        private System.Windows.Forms.ListBox listBoxVinhosEnologos;
        private System.Windows.Forms.ComboBox comboBoxEscolherEnologo;
    }
}