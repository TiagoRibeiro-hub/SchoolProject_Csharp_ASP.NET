
namespace AppVinhos
{
    partial class formListaProdutores
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
            this.buttonEscolher = new System.Windows.Forms.Button();
            this.labelProdutoresRegistados = new System.Windows.Forms.Label();
            this.labelListaProdutores = new System.Windows.Forms.Label();
            this.listBoxProdutores = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonEscolher
            // 
            this.buttonEscolher.Location = new System.Drawing.Point(132, 351);
            this.buttonEscolher.Name = "buttonEscolher";
            this.buttonEscolher.Size = new System.Drawing.Size(120, 30);
            this.buttonEscolher.TabIndex = 100;
            this.buttonEscolher.Text = "Sair";
            this.buttonEscolher.UseVisualStyleBackColor = true;
            this.buttonEscolher.Click += new System.EventHandler(this.buttonEscolher_Click);
            // 
            // labelProdutoresRegistados
            // 
            this.labelProdutoresRegistados.AutoSize = true;
            this.labelProdutoresRegistados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProdutoresRegistados.Location = new System.Drawing.Point(92, 81);
            this.labelProdutoresRegistados.Name = "labelProdutoresRegistados";
            this.labelProdutoresRegistados.Size = new System.Drawing.Size(201, 20);
            this.labelProdutoresRegistados.TabIndex = 99;
            this.labelProdutoresRegistados.Text = "Produtores Registados";
            // 
            // labelListaProdutores
            // 
            this.labelListaProdutores.AutoSize = true;
            this.labelListaProdutores.Font = new System.Drawing.Font("NSimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListaProdutores.Location = new System.Drawing.Point(44, 9);
            this.labelListaProdutores.Name = "labelListaProdutores";
            this.labelListaProdutores.Size = new System.Drawing.Size(297, 28);
            this.labelListaProdutores.TabIndex = 98;
            this.labelListaProdutores.Text = "LISTA DE PRODUTORES";
            // 
            // listBoxProdutores
            // 
            this.listBoxProdutores.FormattingEnabled = true;
            this.listBoxProdutores.ItemHeight = 16;
            this.listBoxProdutores.Location = new System.Drawing.Point(79, 129);
            this.listBoxProdutores.Name = "listBoxProdutores";
            this.listBoxProdutores.Size = new System.Drawing.Size(226, 196);
            this.listBoxProdutores.TabIndex = 97;
            // 
            // formListaProdutores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 422);
            this.Controls.Add(this.buttonEscolher);
            this.Controls.Add(this.labelProdutoresRegistados);
            this.Controls.Add(this.labelListaProdutores);
            this.Controls.Add(this.listBoxProdutores);
            this.Name = "formListaProdutores";
            this.Text = "formListaProdutores";
            this.Load += new System.EventHandler(this.formListaProdutores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonEscolher;
        private System.Windows.Forms.Label labelProdutoresRegistados;
        private System.Windows.Forms.Label labelListaProdutores;
        private System.Windows.Forms.ListBox listBoxProdutores;
    }
}