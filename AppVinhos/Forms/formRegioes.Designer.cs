
namespace AppVinhos
{
    partial class formRegioes
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
            this.GridRegioes = new System.Windows.Forms.DataGridView();
            this.labelRegioesRegistadas = new System.Windows.Forms.Label();
            this.richTextBoxDescricao = new System.Windows.Forms.RichTextBox();
            this.labelDescrição = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelRegioes = new System.Windows.Forms.Label();
            this.checkBoxActivar = new System.Windows.Forms.CheckBox();
            this.labelEliminar = new System.Windows.Forms.Label();
            this.erros = new System.Windows.Forms.ErrorProvider(this.components);
            this.linkLabelProcuraRegioes = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.GridRegioes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(516, 467);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(120, 30);
            this.buttonEliminar.TabIndex = 49;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Visible = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonAlterar
            // 
            this.buttonAlterar.Location = new System.Drawing.Point(199, 467);
            this.buttonAlterar.Name = "buttonAlterar";
            this.buttonAlterar.Size = new System.Drawing.Size(120, 30);
            this.buttonAlterar.TabIndex = 48;
            this.buttonAlterar.Text = "Alterar";
            this.buttonAlterar.UseVisualStyleBackColor = true;
            this.buttonAlterar.Visible = false;
            this.buttonAlterar.Click += new System.EventHandler(this.buttonAlterar_Click);
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(373, 171);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(120, 30);
            this.buttonInserir.TabIndex = 47;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // GridRegioes
            // 
            this.GridRegioes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridRegioes.Location = new System.Drawing.Point(69, 295);
            this.GridRegioes.Name = "GridRegioes";
            this.GridRegioes.RowHeadersWidth = 51;
            this.GridRegioes.RowTemplate.Height = 24;
            this.GridRegioes.Size = new System.Drawing.Size(710, 150);
            this.GridRegioes.TabIndex = 46;
            this.GridRegioes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridRegioes_CellContentClick);
            // 
            // labelRegioesRegistadas
            // 
            this.labelRegioesRegistadas.AutoSize = true;
            this.labelRegioesRegistadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegioesRegistadas.Location = new System.Drawing.Point(318, 244);
            this.labelRegioesRegistadas.Name = "labelRegioesRegistadas";
            this.labelRegioesRegistadas.Size = new System.Drawing.Size(177, 20);
            this.labelRegioesRegistadas.TabIndex = 45;
            this.labelRegioesRegistadas.Text = "Regiões Registadas";
            // 
            // richTextBoxDescricao
            // 
            this.richTextBoxDescricao.Location = new System.Drawing.Point(564, 94);
            this.richTextBoxDescricao.Name = "richTextBoxDescricao";
            this.richTextBoxDescricao.Size = new System.Drawing.Size(215, 170);
            this.richTextBoxDescricao.TabIndex = 44;
            this.richTextBoxDescricao.Text = "";
            // 
            // labelDescrição
            // 
            this.labelDescrição.AutoSize = true;
            this.labelDescrição.Location = new System.Drawing.Point(466, 94);
            this.labelDescrição.Name = "labelDescrição";
            this.labelDescrição.Size = new System.Drawing.Size(71, 17);
            this.labelDescrição.TabIndex = 41;
            this.labelDescrição.Text = "Descrição";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(66, 94);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(45, 17);
            this.labelNome.TabIndex = 40;
            this.labelNome.Text = "Nome";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(180, 94);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(222, 22);
            this.textBoxNome.TabIndex = 39;
            this.textBoxNome.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNome_Validating);
            this.textBoxNome.Validated += new System.EventHandler(this.textBoxNome_Validated);
            // 
            // labelRegioes
            // 
            this.labelRegioes.AutoSize = true;
            this.labelRegioes.Font = new System.Drawing.Font("NSimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegioes.Location = new System.Drawing.Point(348, 9);
            this.labelRegioes.Name = "labelRegioes";
            this.labelRegioes.Size = new System.Drawing.Size(117, 28);
            this.labelRegioes.TabIndex = 38;
            this.labelRegioes.Text = "Regiões";
            // 
            // checkBoxActivar
            // 
            this.checkBoxActivar.AutoSize = true;
            this.checkBoxActivar.Location = new System.Drawing.Point(169, 202);
            this.checkBoxActivar.Name = "checkBoxActivar";
            this.checkBoxActivar.Size = new System.Drawing.Size(97, 21);
            this.checkBoxActivar.TabIndex = 51;
            this.checkBoxActivar.Text = "Desactivar";
            this.checkBoxActivar.UseVisualStyleBackColor = true;
            this.checkBoxActivar.Click += new System.EventHandler(this.checkBoxActivar_Click);
            // 
            // labelEliminar
            // 
            this.labelEliminar.AutoSize = true;
            this.labelEliminar.Location = new System.Drawing.Point(66, 171);
            this.labelEliminar.Name = "labelEliminar";
            this.labelEliminar.Size = new System.Drawing.Size(183, 17);
            this.labelEliminar.TabIndex = 50;
            this.labelEliminar.Text = "Possibilidade de se eliminar";
            // 
            // erros
            // 
            this.erros.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erros.ContainerControl = this;
            // 
            // linkLabelProcuraRegioes
            // 
            this.linkLabelProcuraRegioes.AutoSize = true;
            this.linkLabelProcuraRegioes.Location = new System.Drawing.Point(234, 129);
            this.linkLabelProcuraRegioes.Name = "linkLabelProcuraRegioes";
            this.linkLabelProcuraRegioes.Size = new System.Drawing.Size(114, 17);
            this.linkLabelProcuraRegioes.TabIndex = 52;
            this.linkLabelProcuraRegioes.TabStop = true;
            this.linkLabelProcuraRegioes.Text = "Procura Regioes";
            this.linkLabelProcuraRegioes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelProcuraRegioes_LinkClicked);
            // 
            // formRegioes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 557);
            this.Controls.Add(this.linkLabelProcuraRegioes);
            this.Controls.Add(this.checkBoxActivar);
            this.Controls.Add(this.labelEliminar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonAlterar);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.GridRegioes);
            this.Controls.Add(this.labelRegioesRegistadas);
            this.Controls.Add(this.richTextBoxDescricao);
            this.Controls.Add(this.labelDescrição);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelRegioes);
            this.Name = "formRegioes";
            this.Text = "formRegioes";
            this.Load += new System.EventHandler(this.formRegioes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridRegioes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonAlterar;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.DataGridView GridRegioes;
        private System.Windows.Forms.Label labelRegioesRegistadas;
        private System.Windows.Forms.RichTextBox richTextBoxDescricao;
        private System.Windows.Forms.Label labelDescrição;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelRegioes;
        private System.Windows.Forms.CheckBox checkBoxActivar;
        private System.Windows.Forms.Label labelEliminar;
        private System.Windows.Forms.ErrorProvider erros;
        private System.Windows.Forms.LinkLabel linkLabelProcuraRegioes;
    }
}