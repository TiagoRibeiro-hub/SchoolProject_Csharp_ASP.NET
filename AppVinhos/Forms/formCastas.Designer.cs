
namespace AppVinhos
{
    partial class formCastas
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
            this.components = new System.ComponentModel.Container();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonAlterar = new System.Windows.Forms.Button();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.GridCastas = new System.Windows.Forms.DataGridView();
            this.labelCastasRegistadas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTipoDeVinho = new System.Windows.Forms.Label();
            this.labelCaracteristicas = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxTipoDeVinho = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.checkBoxActivar = new System.Windows.Forms.CheckBox();
            this.labelEliminar = new System.Windows.Forms.Label();
            this.richTextBoxCaracteristicas = new System.Windows.Forms.RichTextBox();
            this.linkLabelEscolherTipoVinho = new System.Windows.Forms.LinkLabel();
            this.erros = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridCastas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(969, 493);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(120, 30);
            this.buttonEliminar.TabIndex = 46;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Visible = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonAlterar
            // 
            this.buttonAlterar.Location = new System.Drawing.Point(599, 493);
            this.buttonAlterar.Name = "buttonAlterar";
            this.buttonAlterar.Size = new System.Drawing.Size(120, 30);
            this.buttonAlterar.TabIndex = 45;
            this.buttonAlterar.Text = "Alterar";
            this.buttonAlterar.UseVisualStyleBackColor = true;
            this.buttonAlterar.Visible = false;
            this.buttonAlterar.Click += new System.EventHandler(this.buttonAlterar_Click);
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(223, 493);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(120, 30);
            this.buttonInserir.TabIndex = 44;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // GridCastas
            // 
            this.GridCastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridCastas.Location = new System.Drawing.Point(454, 143);
            this.GridCastas.Name = "GridCastas";
            this.GridCastas.RowHeadersWidth = 51;
            this.GridCastas.RowTemplate.Height = 24;
            this.GridCastas.Size = new System.Drawing.Size(760, 321);
            this.GridCastas.TabIndex = 41;
            this.GridCastas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCastas_CellContentClick);
            // 
            // labelCastasRegistadas
            // 
            this.labelCastasRegistadas.AutoSize = true;
            this.labelCastasRegistadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCastasRegistadas.Location = new System.Drawing.Point(750, 89);
            this.labelCastasRegistadas.Name = "labelCastasRegistadas";
            this.labelCastasRegistadas.Size = new System.Drawing.Size(168, 20);
            this.labelCastasRegistadas.TabIndex = 40;
            this.labelCastasRegistadas.Text = "Castas Registadas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("NSimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(547, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 28);
            this.label1.TabIndex = 39;
            this.label1.Text = "CASTAS";
            // 
            // labelTipoDeVinho
            // 
            this.labelTipoDeVinho.AutoSize = true;
            this.labelTipoDeVinho.Location = new System.Drawing.Point(86, 276);
            this.labelTipoDeVinho.Name = "labelTipoDeVinho";
            this.labelTipoDeVinho.Size = new System.Drawing.Size(98, 17);
            this.labelTipoDeVinho.TabIndex = 38;
            this.labelTipoDeVinho.Text = "Tipo De Vinho";
            // 
            // labelCaracteristicas
            // 
            this.labelCaracteristicas.AutoSize = true;
            this.labelCaracteristicas.Location = new System.Drawing.Point(83, 143);
            this.labelCaracteristicas.Name = "labelCaracteristicas";
            this.labelCaracteristicas.Size = new System.Drawing.Size(101, 17);
            this.labelCaracteristicas.TabIndex = 37;
            this.labelCaracteristicas.Text = "Caracteristicas";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(139, 92);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(45, 17);
            this.labelNome.TabIndex = 36;
            this.labelNome.Text = "Nome";
            // 
            // textBoxTipoDeVinho
            // 
            this.textBoxTipoDeVinho.Location = new System.Drawing.Point(223, 276);
            this.textBoxTipoDeVinho.Name = "textBoxTipoDeVinho";
            this.textBoxTipoDeVinho.Size = new System.Drawing.Size(172, 22);
            this.textBoxTipoDeVinho.TabIndex = 35;
            this.textBoxTipoDeVinho.Validated += new System.EventHandler(this.textBoxTipoDeVinho_Validated);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(223, 90);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(172, 22);
            this.textBoxNome.TabIndex = 33;
            this.textBoxNome.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNome_Validating);
            this.textBoxNome.Validated += new System.EventHandler(this.textBoxNome_Validated);
            // 
            // checkBoxActivar
            // 
            this.checkBoxActivar.AutoSize = true;
            this.checkBoxActivar.Location = new System.Drawing.Point(189, 420);
            this.checkBoxActivar.Name = "checkBoxActivar";
            this.checkBoxActivar.Size = new System.Drawing.Size(97, 21);
            this.checkBoxActivar.TabIndex = 48;
            this.checkBoxActivar.Text = "Desactivar";
            this.checkBoxActivar.UseVisualStyleBackColor = true;
            this.checkBoxActivar.Click += new System.EventHandler(this.checkBoxActivar_Click);
            // 
            // labelEliminar
            // 
            this.labelEliminar.AutoSize = true;
            this.labelEliminar.Location = new System.Drawing.Point(86, 389);
            this.labelEliminar.Name = "labelEliminar";
            this.labelEliminar.Size = new System.Drawing.Size(183, 17);
            this.labelEliminar.TabIndex = 47;
            this.labelEliminar.Text = "Possibilidade de se eliminar";
            // 
            // richTextBoxCaracteristicas
            // 
            this.richTextBoxCaracteristicas.Location = new System.Drawing.Point(223, 143);
            this.richTextBoxCaracteristicas.Name = "richTextBoxCaracteristicas";
            this.richTextBoxCaracteristicas.Size = new System.Drawing.Size(172, 96);
            this.richTextBoxCaracteristicas.TabIndex = 49;
            this.richTextBoxCaracteristicas.Text = "";
            // 
            // linkLabelEscolherTipoVinho
            // 
            this.linkLabelEscolherTipoVinho.AutoSize = true;
            this.linkLabelEscolherTipoVinho.Location = new System.Drawing.Point(231, 323);
            this.linkLabelEscolherTipoVinho.Name = "linkLabelEscolherTipoVinho";
            this.linkLabelEscolherTipoVinho.Size = new System.Drawing.Size(157, 17);
            this.linkLabelEscolherTipoVinho.TabIndex = 50;
            this.linkLabelEscolherTipoVinho.TabStop = true;
            this.linkLabelEscolherTipoVinho.Text = "Escolher Tipo De Vinho";
            this.linkLabelEscolherTipoVinho.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEscolherTipoVinho_LinkClicked);
            // 
            // erros
            // 
            this.erros.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erros.ContainerControl = this;
            // 
            // formCastas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 559);
            this.Controls.Add(this.linkLabelEscolherTipoVinho);
            this.Controls.Add(this.richTextBoxCaracteristicas);
            this.Controls.Add(this.checkBoxActivar);
            this.Controls.Add(this.labelEliminar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonAlterar);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.GridCastas);
            this.Controls.Add(this.labelCastasRegistadas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTipoDeVinho);
            this.Controls.Add(this.labelCaracteristicas);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.textBoxTipoDeVinho);
            this.Controls.Add(this.textBoxNome);
            this.Name = "formCastas";
            this.Text = "formCastas";
            this.Load += new System.EventHandler(this.formCastas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridCastas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonAlterar;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.DataGridView GridCastas;
        private System.Windows.Forms.Label labelCastasRegistadas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTipoDeVinho;
        private System.Windows.Forms.Label labelCaracteristicas;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.CheckBox checkBoxActivar;
        private System.Windows.Forms.Label labelEliminar;
        private System.Windows.Forms.RichTextBox richTextBoxCaracteristicas;
        private System.Windows.Forms.TextBox textBoxTipoDeVinho;
        private System.Windows.Forms.LinkLabel linkLabelEscolherTipoVinho;
        private System.Windows.Forms.ErrorProvider erros;
    }
}