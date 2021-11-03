
namespace AppVinhos
{
    partial class formProdutores
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
            this.GridProdutores = new System.Windows.Forms.DataGridView();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.labelProdutoresRegistados = new System.Windows.Forms.Label();
            this.maskedTextBoxCodigoPostal = new System.Windows.Forms.MaskedTextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.labelLocalidade = new System.Windows.Forms.Label();
            this.labelCodigoPostal = new System.Windows.Forms.Label();
            this.labelMorada = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxTelefone = new System.Windows.Forms.TextBox();
            this.textBoxLocalidade = new System.Windows.Forms.TextBox();
            this.textBoxMorada = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelProdutores = new System.Windows.Forms.Label();
            this.checkBoxActivar = new System.Windows.Forms.CheckBox();
            this.labelEliminar = new System.Windows.Forms.Label();
            this.linkLabelInserirNovo = new System.Windows.Forms.LinkLabel();
            this.erros = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridProdutores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(621, 640);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(120, 30);
            this.buttonEliminar.TabIndex = 59;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Visible = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonAlterar
            // 
            this.buttonAlterar.Enabled = false;
            this.buttonAlterar.Location = new System.Drawing.Point(751, 274);
            this.buttonAlterar.Name = "buttonAlterar";
            this.buttonAlterar.Size = new System.Drawing.Size(120, 30);
            this.buttonAlterar.TabIndex = 58;
            this.buttonAlterar.Text = "Alterar";
            this.buttonAlterar.UseVisualStyleBackColor = true;
            this.buttonAlterar.Visible = false;
            this.buttonAlterar.Click += new System.EventHandler(this.buttonAlterar_Click);
            // 
            // GridProdutores
            // 
            this.GridProdutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridProdutores.Location = new System.Drawing.Point(84, 400);
            this.GridProdutores.Name = "GridProdutores";
            this.GridProdutores.RowHeadersWidth = 51;
            this.GridProdutores.RowTemplate.Height = 24;
            this.GridProdutores.Size = new System.Drawing.Size(1188, 215);
            this.GridProdutores.TabIndex = 57;
            this.GridProdutores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridProdutos_CellContentClick);
            this.GridProdutores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridProdutos_CellContentClick);
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(751, 274);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(120, 30);
            this.buttonInserir.TabIndex = 56;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // labelProdutoresRegistados
            // 
            this.labelProdutoresRegistados.AutoSize = true;
            this.labelProdutoresRegistados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProdutoresRegistados.Location = new System.Drawing.Point(581, 355);
            this.labelProdutoresRegistados.Name = "labelProdutoresRegistados";
            this.labelProdutoresRegistados.Size = new System.Drawing.Size(201, 20);
            this.labelProdutoresRegistados.TabIndex = 55;
            this.labelProdutoresRegistados.Text = "Produtores Registados";
            // 
            // maskedTextBoxCodigoPostal
            // 
            this.maskedTextBoxCodigoPostal.Location = new System.Drawing.Point(363, 198);
            this.maskedTextBoxCodigoPostal.Name = "maskedTextBoxCodigoPostal";
            this.maskedTextBoxCodigoPostal.Size = new System.Drawing.Size(99, 22);
            this.maskedTextBoxCodigoPostal.TabIndex = 5;
            this.maskedTextBoxCodigoPostal.Text = "____-___";
            this.maskedTextBoxCodigoPostal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBoxCodigoPostal.Click += new System.EventHandler(this.maskedTextBoxCodigoPostal_Click);
            this.maskedTextBoxCodigoPostal.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBoxCodigoPostal_Validating);
            this.maskedTextBoxCodigoPostal.Validated += new System.EventHandler(this.maskedTextBoxCodigoPostal_Validated);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(729, 201);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(41, 16);
            this.labelEmail.TabIndex = 54;
            this.labelEmail.Text = "Email";
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Location = new System.Drawing.Point(486, 201);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(61, 16);
            this.labelTelefone.TabIndex = 53;
            this.labelTelefone.Text = "Telefone";
            // 
            // labelLocalidade
            // 
            this.labelLocalidade.AutoSize = true;
            this.labelLocalidade.Location = new System.Drawing.Point(690, 93);
            this.labelLocalidade.Name = "labelLocalidade";
            this.labelLocalidade.Size = new System.Drawing.Size(75, 16);
            this.labelLocalidade.TabIndex = 52;
            this.labelLocalidade.Text = "Localidade";
            // 
            // labelCodigoPostal
            // 
            this.labelCodigoPostal.AutoSize = true;
            this.labelCodigoPostal.Location = new System.Drawing.Point(226, 201);
            this.labelCodigoPostal.Name = "labelCodigoPostal";
            this.labelCodigoPostal.Size = new System.Drawing.Size(93, 16);
            this.labelCodigoPostal.TabIndex = 51;
            this.labelCodigoPostal.Text = "Codigo-Postal";
            // 
            // labelMorada
            // 
            this.labelMorada.AutoSize = true;
            this.labelMorada.Location = new System.Drawing.Point(266, 144);
            this.labelMorada.Name = "labelMorada";
            this.labelMorada.Size = new System.Drawing.Size(54, 16);
            this.labelMorada.TabIndex = 50;
            this.labelMorada.Text = "Morada";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(277, 93);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(44, 16);
            this.labelNome.TabIndex = 1;
            this.labelNome.Text = "Nome";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(795, 198);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(233, 22);
            this.textBoxEmail.TabIndex = 7;
            this.textBoxEmail.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEmail_Validating);
            this.textBoxEmail.Validated += new System.EventHandler(this.textBoxEmail_Validated);
            // 
            // textBoxTelefone
            // 
            this.textBoxTelefone.Location = new System.Drawing.Point(574, 198);
            this.textBoxTelefone.Name = "textBoxTelefone";
            this.textBoxTelefone.Size = new System.Drawing.Size(131, 22);
            this.textBoxTelefone.TabIndex = 6;
            this.textBoxTelefone.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTelefone_Validating);
            this.textBoxTelefone.Validated += new System.EventHandler(this.textBoxTelefone_Validated);
            // 
            // textBoxLocalidade
            // 
            this.textBoxLocalidade.Location = new System.Drawing.Point(800, 90);
            this.textBoxLocalidade.Name = "textBoxLocalidade";
            this.textBoxLocalidade.Size = new System.Drawing.Size(233, 22);
            this.textBoxLocalidade.TabIndex = 3;
            this.textBoxLocalidade.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxLocalidade_Validating);
            this.textBoxLocalidade.Validated += new System.EventHandler(this.textBoxLocalidade_Validated);
            // 
            // textBoxMorada
            // 
            this.textBoxMorada.Location = new System.Drawing.Point(363, 141);
            this.textBoxMorada.Name = "textBoxMorada";
            this.textBoxMorada.Size = new System.Drawing.Size(670, 22);
            this.textBoxMorada.TabIndex = 4;
            this.textBoxMorada.TextChanged += new System.EventHandler(this.textBoxMorada_TextChanged);
            this.textBoxMorada.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxMorada_Validating);
            this.textBoxMorada.Validated += new System.EventHandler(this.textBoxMorada_Validated);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(363, 90);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(303, 22);
            this.textBoxNome.TabIndex = 2;
            this.textBoxNome.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNome_Validating);
            this.textBoxNome.Validated += new System.EventHandler(this.textBoxNome_Validated);
            // 
            // labelProdutores
            // 
            this.labelProdutores.AutoSize = true;
            this.labelProdutores.Font = new System.Drawing.Font("NSimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProdutores.Location = new System.Drawing.Point(600, 6);
            this.labelProdutores.Name = "labelProdutores";
            this.labelProdutores.Size = new System.Drawing.Size(162, 28);
            this.labelProdutores.TabIndex = 42;
            this.labelProdutores.Text = "PRODUTORES";
            // 
            // checkBoxActivar
            // 
            this.checkBoxActivar.AutoSize = true;
            this.checkBoxActivar.Location = new System.Drawing.Point(329, 283);
            this.checkBoxActivar.Name = "checkBoxActivar";
            this.checkBoxActivar.Size = new System.Drawing.Size(94, 20);
            this.checkBoxActivar.TabIndex = 8;
            this.checkBoxActivar.Text = "Desactivar";
            this.checkBoxActivar.UseVisualStyleBackColor = true;
            this.checkBoxActivar.CheckedChanged += new System.EventHandler(this.checkBoxActivar_CheckedChanged);
            // 
            // labelEliminar
            // 
            this.labelEliminar.AutoSize = true;
            this.labelEliminar.Location = new System.Drawing.Point(226, 252);
            this.labelEliminar.Name = "labelEliminar";
            this.labelEliminar.Size = new System.Drawing.Size(177, 16);
            this.labelEliminar.TabIndex = 88;
            this.labelEliminar.Text = "Possibilidade de se eliminar";
            // 
            // linkLabelInserirNovo
            // 
            this.linkLabelInserirNovo.AutoSize = true;
            this.linkLabelInserirNovo.Location = new System.Drawing.Point(908, 281);
            this.linkLabelInserirNovo.Name = "linkLabelInserirNovo";
            this.linkLabelInserirNovo.Size = new System.Drawing.Size(79, 16);
            this.linkLabelInserirNovo.TabIndex = 90;
            this.linkLabelInserirNovo.TabStop = true;
            this.linkLabelInserirNovo.Text = "Inserir Novo";
            this.linkLabelInserirNovo.Visible = false;
            this.linkLabelInserirNovo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInserirNovo_LinkClicked);
            // 
            // erros
            // 
            this.erros.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erros.ContainerControl = this;
            // 
            // formProdutores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 682);
            this.Controls.Add(this.linkLabelInserirNovo);
            this.Controls.Add(this.checkBoxActivar);
            this.Controls.Add(this.labelEliminar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonAlterar);
            this.Controls.Add(this.GridProdutores);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.labelProdutoresRegistados);
            this.Controls.Add(this.maskedTextBoxCodigoPostal);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelTelefone);
            this.Controls.Add(this.labelLocalidade);
            this.Controls.Add(this.labelCodigoPostal);
            this.Controls.Add(this.labelMorada);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxTelefone);
            this.Controls.Add(this.textBoxLocalidade);
            this.Controls.Add(this.textBoxMorada);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelProdutores);
            this.Name = "formProdutores";
            this.Text = "formProdutores";
            this.Load += new System.EventHandler(this.formProdutores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridProdutores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonAlterar;
        private System.Windows.Forms.DataGridView GridProdutores;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.Label labelProdutoresRegistados;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCodigoPostal;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.Label labelLocalidade;
        private System.Windows.Forms.Label labelCodigoPostal;
        private System.Windows.Forms.Label labelMorada;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxTelefone;
        private System.Windows.Forms.TextBox textBoxLocalidade;
        private System.Windows.Forms.TextBox textBoxMorada;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelProdutores;
        private System.Windows.Forms.CheckBox checkBoxActivar;
        private System.Windows.Forms.Label labelEliminar;
        private System.Windows.Forms.LinkLabel linkLabelInserirNovo;
        private System.Windows.Forms.ErrorProvider erros;
    }
}