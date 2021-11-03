
namespace AppVinhos
{
    partial class formEnologos
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
            this.labelEliminar = new System.Windows.Forms.Label();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonAlterar = new System.Windows.Forms.Button();
            this.GridEnologos = new System.Windows.Forms.DataGridView();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.labelEnologoLista = new System.Windows.Forms.Label();
            this.labelEnologos = new System.Windows.Forms.Label();
            this.labelInsta = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxInsta = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.checkBoxActivar = new System.Windows.Forms.CheckBox();
            this.erros = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridEnologos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEliminar
            // 
            this.labelEliminar.AutoSize = true;
            this.labelEliminar.Location = new System.Drawing.Point(43, 247);
            this.labelEliminar.Name = "labelEliminar";
            this.labelEliminar.Size = new System.Drawing.Size(183, 17);
            this.labelEliminar.TabIndex = 36;
            this.labelEliminar.Text = "Possibilidade de se eliminar";
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(679, 337);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(120, 30);
            this.buttonEliminar.TabIndex = 34;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Visible = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonAlterar
            // 
            this.buttonAlterar.Location = new System.Drawing.Point(396, 337);
            this.buttonAlterar.Name = "buttonAlterar";
            this.buttonAlterar.Size = new System.Drawing.Size(120, 30);
            this.buttonAlterar.TabIndex = 33;
            this.buttonAlterar.Text = "Alterar";
            this.buttonAlterar.UseVisualStyleBackColor = true;
            this.buttonAlterar.Visible = false;
            this.buttonAlterar.Click += new System.EventHandler(this.buttonAlterar_Click);
            // 
            // GridEnologos
            // 
            this.GridEnologos.AllowUserToAddRows = false;
            this.GridEnologos.AllowUserToDeleteRows = false;
            this.GridEnologos.AllowUserToResizeColumns = false;
            this.GridEnologos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridEnologos.Location = new System.Drawing.Point(334, 132);
            this.GridEnologos.Name = "GridEnologos";
            this.GridEnologos.RowHeadersWidth = 51;
            this.GridEnologos.RowTemplate.Height = 24;
            this.GridEnologos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridEnologos.Size = new System.Drawing.Size(546, 167);
            this.GridEnologos.TabIndex = 32;
            this.GridEnologos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridEnologos_CellContentClick);
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(146, 337);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(120, 30);
            this.buttonInserir.TabIndex = 31;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // labelEnologoLista
            // 
            this.labelEnologoLista.AutoSize = true;
            this.labelEnologoLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnologoLista.Location = new System.Drawing.Point(515, 79);
            this.labelEnologoLista.Name = "labelEnologoLista";
            this.labelEnologoLista.Size = new System.Drawing.Size(186, 20);
            this.labelEnologoLista.TabIndex = 30;
            this.labelEnologoLista.Text = "Enologos Registados";
            // 
            // labelEnologos
            // 
            this.labelEnologos.AutoSize = true;
            this.labelEnologos.Font = new System.Drawing.Font("NSimSun", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnologos.Location = new System.Drawing.Point(384, 9);
            this.labelEnologos.Name = "labelEnologos";
            this.labelEnologos.Size = new System.Drawing.Size(132, 28);
            this.labelEnologos.TabIndex = 29;
            this.labelEnologos.Text = "ENOLOGOS";
            // 
            // labelInsta
            // 
            this.labelInsta.AutoSize = true;
            this.labelInsta.Location = new System.Drawing.Point(43, 195);
            this.labelInsta.Name = "labelInsta";
            this.labelInsta.Size = new System.Drawing.Size(70, 17);
            this.labelInsta.TabIndex = 28;
            this.labelInsta.Text = "Instagram";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(68, 132);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(45, 17);
            this.labelNome.TabIndex = 27;
            this.labelNome.Text = "Nome";
            // 
            // textBoxInsta
            // 
            this.textBoxInsta.Location = new System.Drawing.Point(146, 192);
            this.textBoxInsta.Name = "textBoxInsta";
            this.textBoxInsta.Size = new System.Drawing.Size(147, 22);
            this.textBoxInsta.TabIndex = 26;
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(146, 132);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(147, 22);
            this.textBoxNome.TabIndex = 25;
            this.textBoxNome.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNome_Validating);
            this.textBoxNome.Validated += new System.EventHandler(this.textBoxNome_Validated);
            // 
            // checkBoxActivar
            // 
            this.checkBoxActivar.AutoSize = true;
            this.checkBoxActivar.Location = new System.Drawing.Point(146, 278);
            this.checkBoxActivar.Name = "checkBoxActivar";
            this.checkBoxActivar.Size = new System.Drawing.Size(108, 21);
            this.checkBoxActivar.TabIndex = 37;
            this.checkBoxActivar.Text = "Desactivado";
            this.checkBoxActivar.UseVisualStyleBackColor = true;
            this.checkBoxActivar.Click += new System.EventHandler(this.checkBoxActivar_Click);
            // 
            // erros
            // 
            this.erros.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erros.ContainerControl = this;
            // 
            // formEnologos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 418);
            this.Controls.Add(this.checkBoxActivar);
            this.Controls.Add(this.labelEliminar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonAlterar);
            this.Controls.Add(this.GridEnologos);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.labelEnologoLista);
            this.Controls.Add(this.labelEnologos);
            this.Controls.Add(this.labelInsta);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.textBoxInsta);
            this.Controls.Add(this.textBoxNome);
            this.Name = "formEnologos";
            this.Text = "formEnologos";
            this.Load += new System.EventHandler(this.formEnologos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridEnologos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEliminar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonAlterar;
        private System.Windows.Forms.DataGridView GridEnologos;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.Label labelEnologoLista;
        private System.Windows.Forms.Label labelEnologos;
        private System.Windows.Forms.Label labelInsta;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxInsta;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.CheckBox checkBoxActivar;
        private System.Windows.Forms.ErrorProvider erros;
    }
}