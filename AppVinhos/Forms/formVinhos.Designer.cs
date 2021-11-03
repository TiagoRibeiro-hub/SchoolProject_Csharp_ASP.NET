
namespace AppVinhos
{
    partial class formVinhos
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
            this.labelVinhosRegistados = new System.Windows.Forms.Label();
            this.GridVinhos = new System.Windows.Forms.DataGridView();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonAlterar = new System.Windows.Forms.Button();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.buttonEliminarEnologo = new System.Windows.Forms.Button();
            this.buttonEliminarCasta = new System.Windows.Forms.Button();
            this.buttonEscolherEnologo = new System.Windows.Forms.Button();
            this.buttonEscolherCastas = new System.Windows.Forms.Button();
            this.listBoxEnologos = new System.Windows.Forms.ListBox();
            this.listBoxCastas = new System.Windows.Forms.ListBox();
            this.comboBoxEnologos = new System.Windows.Forms.ComboBox();
            this.comboBoxCastas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPercentagemTeor = new System.Windows.Forms.Label();
            this.labelºC = new System.Windows.Forms.Label();
            this.labelVinhos = new System.Windows.Forms.Label();
            this.labelAno = new System.Windows.Forms.Label();
            this.labelTemperatura = new System.Windows.Forms.Label();
            this.labelTeorAlcoolico = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.labelTiposDeVinhos = new System.Windows.Forms.Label();
            this.labelRegioes = new System.Windows.Forms.Label();
            this.labelProdutores = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxAno = new System.Windows.Forms.TextBox();
            this.textBoxTemperatura = new System.Windows.Forms.TextBox();
            this.textBoxTeorAlcoolico = new System.Windows.Forms.TextBox();
            this.textBoxVolume = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.comboBoxTiposDeVinhos = new System.Windows.Forms.ComboBox();
            this.comboBoxRegioes = new System.Windows.Forms.ComboBox();
            this.comboBoxProdutores = new System.Windows.Forms.ComboBox();
            this.checkBoxActivar = new System.Windows.Forms.CheckBox();
            this.labelEliminar = new System.Windows.Forms.Label();
            this.labelVolumeLitro = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabelInserirNovo = new System.Windows.Forms.LinkLabel();
            this.erros = new System.Windows.Forms.ErrorProvider(this.components);
            this.linkLabelCopiar = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.GridVinhos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).BeginInit();
            this.SuspendLayout();
            // 
            // labelVinhosRegistados
            // 
            this.labelVinhosRegistados.AutoSize = true;
            this.labelVinhosRegistados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVinhosRegistados.Location = new System.Drawing.Point(670, 345);
            this.labelVinhosRegistados.Name = "labelVinhosRegistados";
            this.labelVinhosRegistados.Size = new System.Drawing.Size(166, 20);
            this.labelVinhosRegistados.TabIndex = 85;
            this.labelVinhosRegistados.Text = "Vinhos Registados";
            // 
            // GridVinhos
            // 
            this.GridVinhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridVinhos.Location = new System.Drawing.Point(202, 414);
            this.GridVinhos.Name = "GridVinhos";
            this.GridVinhos.RowHeadersWidth = 51;
            this.GridVinhos.RowTemplate.Height = 24;
            this.GridVinhos.Size = new System.Drawing.Size(1147, 261);
            this.GridVinhos.TabIndex = 84;
            this.GridVinhos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridVinhos_CellClick);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(693, 694);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(120, 30);
            this.buttonEliminar.TabIndex = 83;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Visible = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonAlterar
            // 
            this.buttonAlterar.Enabled = false;
            this.buttonAlterar.Location = new System.Drawing.Point(1345, 212);
            this.buttonAlterar.Name = "buttonAlterar";
            this.buttonAlterar.Size = new System.Drawing.Size(120, 30);
            this.buttonAlterar.TabIndex = 82;
            this.buttonAlterar.Text = "Alterar";
            this.buttonAlterar.UseVisualStyleBackColor = true;
            this.buttonAlterar.Visible = false;
            this.buttonAlterar.Click += new System.EventHandler(this.buttonAlterar_Click);
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(1345, 212);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(120, 30);
            this.buttonInserir.TabIndex = 81;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // buttonEliminarEnologo
            // 
            this.buttonEliminarEnologo.Location = new System.Drawing.Point(1077, 273);
            this.buttonEliminarEnologo.Name = "buttonEliminarEnologo";
            this.buttonEliminarEnologo.Size = new System.Drawing.Size(139, 34);
            this.buttonEliminarEnologo.TabIndex = 80;
            this.buttonEliminarEnologo.Text = "Eliminar Enologo";
            this.buttonEliminarEnologo.UseVisualStyleBackColor = true;
            this.buttonEliminarEnologo.Click += new System.EventHandler(this.buttonEliminarEnologo_Click);
            // 
            // buttonEliminarCasta
            // 
            this.buttonEliminarCasta.Location = new System.Drawing.Point(832, 273);
            this.buttonEliminarCasta.Name = "buttonEliminarCasta";
            this.buttonEliminarCasta.Size = new System.Drawing.Size(120, 34);
            this.buttonEliminarCasta.TabIndex = 79;
            this.buttonEliminarCasta.Text = "Eliminar Casta";
            this.buttonEliminarCasta.UseVisualStyleBackColor = true;
            this.buttonEliminarCasta.Click += new System.EventHandler(this.buttonEliminarCasta_Click);
            // 
            // buttonEscolherEnologo
            // 
            this.buttonEscolherEnologo.Location = new System.Drawing.Point(1077, 142);
            this.buttonEscolherEnologo.Name = "buttonEscolherEnologo";
            this.buttonEscolherEnologo.Size = new System.Drawing.Size(139, 32);
            this.buttonEscolherEnologo.TabIndex = 78;
            this.buttonEscolherEnologo.Text = "Inserir Enologo";
            this.buttonEscolherEnologo.UseVisualStyleBackColor = true;
            this.buttonEscolherEnologo.Click += new System.EventHandler(this.buttonEscolherEnologo_Click);
            // 
            // buttonEscolherCastas
            // 
            this.buttonEscolherCastas.Location = new System.Drawing.Point(834, 142);
            this.buttonEscolherCastas.Name = "buttonEscolherCastas";
            this.buttonEscolherCastas.Size = new System.Drawing.Size(116, 32);
            this.buttonEscolherCastas.TabIndex = 77;
            this.buttonEscolherCastas.Text = "Inserir Casta";
            this.buttonEscolherCastas.UseVisualStyleBackColor = true;
            this.buttonEscolherCastas.Click += new System.EventHandler(this.buttonEscolherCastas_Click);
            // 
            // listBoxEnologos
            // 
            this.listBoxEnologos.FormattingEnabled = true;
            this.listBoxEnologos.ItemHeight = 16;
            this.listBoxEnologos.Location = new System.Drawing.Point(1056, 183);
            this.listBoxEnologos.Name = "listBoxEnologos";
            this.listBoxEnologos.Size = new System.Drawing.Size(181, 84);
            this.listBoxEnologos.TabIndex = 76;
            // 
            // listBoxCastas
            // 
            this.listBoxCastas.FormattingEnabled = true;
            this.listBoxCastas.ItemHeight = 16;
            this.listBoxCastas.Location = new System.Drawing.Point(802, 183);
            this.listBoxCastas.Name = "listBoxCastas";
            this.listBoxCastas.Size = new System.Drawing.Size(181, 84);
            this.listBoxCastas.TabIndex = 75;
            // 
            // comboBoxEnologos
            // 
            this.comboBoxEnologos.FormattingEnabled = true;
            this.comboBoxEnologos.Location = new System.Drawing.Point(1056, 112);
            this.comboBoxEnologos.Name = "comboBoxEnologos";
            this.comboBoxEnologos.Size = new System.Drawing.Size(181, 24);
            this.comboBoxEnologos.TabIndex = 11;
            this.comboBoxEnologos.Validated += new System.EventHandler(this.comboBoxEnologos_Validated);
            // 
            // comboBoxCastas
            // 
            this.comboBoxCastas.FormattingEnabled = true;
            this.comboBoxCastas.Location = new System.Drawing.Point(802, 112);
            this.comboBoxCastas.Name = "comboBoxCastas";
            this.comboBoxCastas.Size = new System.Drawing.Size(181, 24);
            this.comboBoxCastas.TabIndex = 10;
            this.comboBoxCastas.Validated += new System.EventHandler(this.comboBoxCastas_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1103, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 72;
            this.label2.Text = "Enologos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(858, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 71;
            this.label1.Text = "Castas";
            // 
            // labelPercentagemTeor
            // 
            this.labelPercentagemTeor.AutoSize = true;
            this.labelPercentagemTeor.Location = new System.Drawing.Point(690, 212);
            this.labelPercentagemTeor.Name = "labelPercentagemTeor";
            this.labelPercentagemTeor.Size = new System.Drawing.Size(44, 17);
            this.labelPercentagemTeor.TabIndex = 70;
            this.labelPercentagemTeor.Text = "%Vol.";
            // 
            // labelºC
            // 
            this.labelºC.AutoSize = true;
            this.labelºC.Location = new System.Drawing.Point(690, 275);
            this.labelºC.Name = "labelºC";
            this.labelºC.Size = new System.Drawing.Size(22, 17);
            this.labelºC.TabIndex = 69;
            this.labelºC.Text = "ºC";
            // 
            // labelVinhos
            // 
            this.labelVinhos.AutoSize = true;
            this.labelVinhos.Font = new System.Drawing.Font("NSimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVinhos.Location = new System.Drawing.Point(702, 9);
            this.labelVinhos.Name = "labelVinhos";
            this.labelVinhos.Size = new System.Drawing.Size(102, 28);
            this.labelVinhos.TabIndex = 68;
            this.labelVinhos.Text = "VINHOS";
            // 
            // labelAno
            // 
            this.labelAno.AutoSize = true;
            this.labelAno.Location = new System.Drawing.Point(483, 86);
            this.labelAno.Name = "labelAno";
            this.labelAno.Size = new System.Drawing.Size(33, 17);
            this.labelAno.TabIndex = 67;
            this.labelAno.Text = "Ano";
            // 
            // labelTemperatura
            // 
            this.labelTemperatura.AutoSize = true;
            this.labelTemperatura.Location = new System.Drawing.Point(426, 275);
            this.labelTemperatura.Name = "labelTemperatura";
            this.labelTemperatura.Size = new System.Drawing.Size(90, 17);
            this.labelTemperatura.TabIndex = 66;
            this.labelTemperatura.Text = "Temperatura";
            // 
            // labelTeorAlcoolico
            // 
            this.labelTeorAlcoolico.AutoSize = true;
            this.labelTeorAlcoolico.Location = new System.Drawing.Point(418, 212);
            this.labelTeorAlcoolico.Name = "labelTeorAlcoolico";
            this.labelTeorAlcoolico.Size = new System.Drawing.Size(98, 17);
            this.labelTeorAlcoolico.TabIndex = 65;
            this.labelTeorAlcoolico.Text = "Teor Alcoolico";
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(461, 149);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(55, 17);
            this.labelVolume.TabIndex = 64;
            this.labelVolume.Text = "Volume";
            // 
            // labelTiposDeVinhos
            // 
            this.labelTiposDeVinhos.AutoSize = true;
            this.labelTiposDeVinhos.Location = new System.Drawing.Point(26, 275);
            this.labelTiposDeVinhos.Name = "labelTiposDeVinhos";
            this.labelTiposDeVinhos.Size = new System.Drawing.Size(108, 17);
            this.labelTiposDeVinhos.TabIndex = 63;
            this.labelTiposDeVinhos.Text = "Tipos de vinhos";
            // 
            // labelRegioes
            // 
            this.labelRegioes.AutoSize = true;
            this.labelRegioes.Location = new System.Drawing.Point(74, 212);
            this.labelRegioes.Name = "labelRegioes";
            this.labelRegioes.Size = new System.Drawing.Size(60, 17);
            this.labelRegioes.TabIndex = 62;
            this.labelRegioes.Text = "Regiões";
            // 
            // labelProdutores
            // 
            this.labelProdutores.AutoSize = true;
            this.labelProdutores.Location = new System.Drawing.Point(56, 149);
            this.labelProdutores.Name = "labelProdutores";
            this.labelProdutores.Size = new System.Drawing.Size(78, 17);
            this.labelProdutores.TabIndex = 61;
            this.labelProdutores.Text = "Produtores";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(89, 86);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(45, 17);
            this.labelNome.TabIndex = 1;
            this.labelNome.Text = "Nome";
            // 
            // textBoxAno
            // 
            this.textBoxAno.Location = new System.Drawing.Point(584, 83);
            this.textBoxAno.Name = "textBoxAno";
            this.textBoxAno.Size = new System.Drawing.Size(100, 22);
            this.textBoxAno.TabIndex = 6;
            this.textBoxAno.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAno_Validating);
            this.textBoxAno.Validated += new System.EventHandler(this.textBoxAno_Validated);
            // 
            // textBoxTemperatura
            // 
            this.textBoxTemperatura.Location = new System.Drawing.Point(584, 272);
            this.textBoxTemperatura.Name = "textBoxTemperatura";
            this.textBoxTemperatura.Size = new System.Drawing.Size(100, 22);
            this.textBoxTemperatura.TabIndex = 9;
            this.textBoxTemperatura.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTemperatura_Validating);
            this.textBoxTemperatura.Validated += new System.EventHandler(this.textBoxTemperatura_Validated);
            // 
            // textBoxTeorAlcoolico
            // 
            this.textBoxTeorAlcoolico.Location = new System.Drawing.Point(584, 209);
            this.textBoxTeorAlcoolico.Name = "textBoxTeorAlcoolico";
            this.textBoxTeorAlcoolico.Size = new System.Drawing.Size(100, 22);
            this.textBoxTeorAlcoolico.TabIndex = 8;
            this.textBoxTeorAlcoolico.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTeorAlcoolico_Validating);
            this.textBoxTeorAlcoolico.Validated += new System.EventHandler(this.textBoxTeorAlcoolico_Validated);
            // 
            // textBoxVolume
            // 
            this.textBoxVolume.Location = new System.Drawing.Point(584, 146);
            this.textBoxVolume.Name = "textBoxVolume";
            this.textBoxVolume.Size = new System.Drawing.Size(100, 22);
            this.textBoxVolume.TabIndex = 7;
            this.textBoxVolume.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxVolume_Validating);
            this.textBoxVolume.Validated += new System.EventHandler(this.textBoxVolume_Validated);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(202, 83);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(181, 22);
            this.textBoxNome.TabIndex = 2;
            this.textBoxNome.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNome_Validating);
            this.textBoxNome.Validated += new System.EventHandler(this.textBoxNome_Validated);
            // 
            // comboBoxTiposDeVinhos
            // 
            this.comboBoxTiposDeVinhos.FormattingEnabled = true;
            this.comboBoxTiposDeVinhos.Location = new System.Drawing.Point(202, 270);
            this.comboBoxTiposDeVinhos.Name = "comboBoxTiposDeVinhos";
            this.comboBoxTiposDeVinhos.Size = new System.Drawing.Size(181, 24);
            this.comboBoxTiposDeVinhos.TabIndex = 5;
            this.comboBoxTiposDeVinhos.Validated += new System.EventHandler(this.comboBoxTiposDeVinhos_Validated);
            // 
            // comboBoxRegioes
            // 
            this.comboBoxRegioes.FormattingEnabled = true;
            this.comboBoxRegioes.Location = new System.Drawing.Point(202, 207);
            this.comboBoxRegioes.Name = "comboBoxRegioes";
            this.comboBoxRegioes.Size = new System.Drawing.Size(181, 24);
            this.comboBoxRegioes.TabIndex = 4;
            this.comboBoxRegioes.Validated += new System.EventHandler(this.comboBoxRegioes_Validated);
            // 
            // comboBoxProdutores
            // 
            this.comboBoxProdutores.FormattingEnabled = true;
            this.comboBoxProdutores.Location = new System.Drawing.Point(202, 144);
            this.comboBoxProdutores.Name = "comboBoxProdutores";
            this.comboBoxProdutores.Size = new System.Drawing.Size(181, 24);
            this.comboBoxProdutores.TabIndex = 3;
            this.comboBoxProdutores.Validated += new System.EventHandler(this.comboBoxProdutores_Validated);
            // 
            // checkBoxActivar
            // 
            this.checkBoxActivar.AutoSize = true;
            this.checkBoxActivar.Location = new System.Drawing.Point(1368, 119);
            this.checkBoxActivar.Name = "checkBoxActivar";
            this.checkBoxActivar.Size = new System.Drawing.Size(97, 21);
            this.checkBoxActivar.TabIndex = 12;
            this.checkBoxActivar.Text = "Desactivar";
            this.checkBoxActivar.UseVisualStyleBackColor = true;
            this.checkBoxActivar.CheckedChanged += new System.EventHandler(this.checkBoxActivar_CheckedChanged);
            // 
            // labelEliminar
            // 
            this.labelEliminar.AutoSize = true;
            this.labelEliminar.Location = new System.Drawing.Point(1265, 88);
            this.labelEliminar.Name = "labelEliminar";
            this.labelEliminar.Size = new System.Drawing.Size(183, 17);
            this.labelEliminar.TabIndex = 86;
            this.labelEliminar.Text = "Possibilidade de se eliminar";
            // 
            // labelVolumeLitro
            // 
            this.labelVolumeLitro.AutoSize = true;
            this.labelVolumeLitro.Location = new System.Drawing.Point(690, 149);
            this.labelVolumeLitro.Name = "labelVolumeLitro";
            this.labelVolumeLitro.Size = new System.Drawing.Size(16, 17);
            this.labelVolumeLitro.TabIndex = 88;
            this.labelVolumeLitro.Text = "L";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // linkLabelInserirNovo
            // 
            this.linkLabelInserirNovo.AutoSize = true;
            this.linkLabelInserirNovo.Location = new System.Drawing.Point(1363, 290);
            this.linkLabelInserirNovo.Name = "linkLabelInserirNovo";
            this.linkLabelInserirNovo.Size = new System.Drawing.Size(84, 17);
            this.linkLabelInserirNovo.TabIndex = 89;
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
            // linkLabelCopiar
            // 
            this.linkLabelCopiar.AutoSize = true;
            this.linkLabelCopiar.Location = new System.Drawing.Point(1344, 259);
            this.linkLabelCopiar.Name = "linkLabelCopiar";
            this.linkLabelCopiar.Size = new System.Drawing.Size(123, 17);
            this.linkLabelCopiar.TabIndex = 90;
            this.linkLabelCopiar.TabStop = true;
            this.linkLabelCopiar.Text = "Copiar Informação";
            this.linkLabelCopiar.Visible = false;
            this.linkLabelCopiar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCopiar_LinkClicked);
            // 
            // formVinhos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1516, 736);
            this.Controls.Add(this.linkLabelCopiar);
            this.Controls.Add(this.linkLabelInserirNovo);
            this.Controls.Add(this.labelVolumeLitro);
            this.Controls.Add(this.checkBoxActivar);
            this.Controls.Add(this.labelEliminar);
            this.Controls.Add(this.labelVinhosRegistados);
            this.Controls.Add(this.GridVinhos);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonAlterar);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.buttonEliminarEnologo);
            this.Controls.Add(this.buttonEliminarCasta);
            this.Controls.Add(this.buttonEscolherEnologo);
            this.Controls.Add(this.buttonEscolherCastas);
            this.Controls.Add(this.listBoxEnologos);
            this.Controls.Add(this.listBoxCastas);
            this.Controls.Add(this.comboBoxEnologos);
            this.Controls.Add(this.comboBoxCastas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPercentagemTeor);
            this.Controls.Add(this.labelºC);
            this.Controls.Add(this.labelVinhos);
            this.Controls.Add(this.labelAno);
            this.Controls.Add(this.labelTemperatura);
            this.Controls.Add(this.labelTeorAlcoolico);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.labelTiposDeVinhos);
            this.Controls.Add(this.labelRegioes);
            this.Controls.Add(this.labelProdutores);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.textBoxAno);
            this.Controls.Add(this.textBoxTemperatura);
            this.Controls.Add(this.textBoxTeorAlcoolico);
            this.Controls.Add(this.textBoxVolume);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.comboBoxTiposDeVinhos);
            this.Controls.Add(this.comboBoxRegioes);
            this.Controls.Add(this.comboBoxProdutores);
            this.Name = "formVinhos";
            this.Text = "formVinhos";
            this.Load += new System.EventHandler(this.formVinhos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridVinhos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVinhosRegistados;
        private System.Windows.Forms.DataGridView GridVinhos;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonAlterar;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.Button buttonEliminarEnologo;
        private System.Windows.Forms.Button buttonEliminarCasta;
        private System.Windows.Forms.Button buttonEscolherEnologo;
        private System.Windows.Forms.Button buttonEscolherCastas;
        private System.Windows.Forms.ListBox listBoxEnologos;
        private System.Windows.Forms.ListBox listBoxCastas;
        private System.Windows.Forms.ComboBox comboBoxEnologos;
        private System.Windows.Forms.ComboBox comboBoxCastas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPercentagemTeor;
        private System.Windows.Forms.Label labelºC;
        private System.Windows.Forms.Label labelVinhos;
        private System.Windows.Forms.Label labelAno;
        private System.Windows.Forms.Label labelTemperatura;
        private System.Windows.Forms.Label labelTeorAlcoolico;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Label labelTiposDeVinhos;
        private System.Windows.Forms.Label labelRegioes;
        private System.Windows.Forms.Label labelProdutores;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxAno;
        private System.Windows.Forms.TextBox textBoxTemperatura;
        private System.Windows.Forms.TextBox textBoxTeorAlcoolico;
        private System.Windows.Forms.TextBox textBoxVolume;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.ComboBox comboBoxTiposDeVinhos;
        private System.Windows.Forms.ComboBox comboBoxRegioes;
        private System.Windows.Forms.ComboBox comboBoxProdutores;
        private System.Windows.Forms.CheckBox checkBoxActivar;
        private System.Windows.Forms.Label labelEliminar;
        private System.Windows.Forms.Label labelVolumeLitro;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel linkLabelInserirNovo;
        private System.Windows.Forms.ErrorProvider erros;
        private System.Windows.Forms.LinkLabel linkLabelCopiar;
    }
}