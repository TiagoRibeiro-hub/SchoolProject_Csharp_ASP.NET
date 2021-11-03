using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppVinhos;
using dbVinhosEFA;
using dbVinhosEFA.Metodos;
using libraryValidacoes;
using Newtonsoft.Json;

namespace AppVinhos
{
    public partial class formProdutores : Form
    {
        public formProdutores()
        {
            InitializeComponent();
        }
        VinhosEFAEntities db = new VinhosEFAEntities();
        int id, confirm = 0;
        bool cbP, cbV = false;

        //FUNCOES
        #region FUNCOES
        void reset(string btn = "opcional")
        {
            funcoes.Clean(this);
            getProdutores();
            funcoes.cbOption(checkBoxActivar);
            if (btn.Contains("btn"))
            {
                alterarbtns();
            }
        }

        void alterarBtnSetErros(string i = "alterar")
        {
            if (i.Contains("alterar"))
            {
                buttonInserir.Enabled = false;
                buttonInserir.Visible = false;
                buttonAlterar.Visible = true;
                buttonAlterar.Enabled = true;
                buttonEliminar.Visible = true;
                linkLabelInserirNovo.Visible = true;
            }
            erros.SetError(textBoxNome, "");
            erros.SetError(textBoxMorada, "");
            erros.SetError(textBoxLocalidade, "");
            erros.SetError(maskedTextBoxCodigoPostal, "");
            erros.SetError(textBoxEmail, "");
            erros.SetError(textBoxTelefone, "");
            
        }

        void getProdutores()
        {
            MetodosProdutores.getProdutores(GridProdutores, null);
        }

        #endregion
        private void GridProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            funcoes.Clean(this);
            alterarBtnSetErros();

            id = int.Parse(GridProdutores.CurrentRow.Cells[0].Value.ToString());
            textBoxNome.Text = GridProdutores.CurrentRow.Cells[1].Value == null ? "" : GridProdutores.CurrentRow.Cells[1].Value.ToString();
            textBoxMorada.Text = GridProdutores.CurrentRow.Cells[2].Value == null ? "" : GridProdutores.CurrentRow.Cells[2].Value.ToString();
            maskedTextBoxCodigoPostal.Text = GridProdutores.CurrentRow.Cells[3].Value == null ? "" : GridProdutores.CurrentRow.Cells[3].Value.ToString();
            textBoxLocalidade.Text = GridProdutores.CurrentRow.Cells[4].Value == null ? "" : GridProdutores.CurrentRow.Cells[4].Value.ToString();
            textBoxTelefone.Text = GridProdutores.CurrentRow.Cells[5].Value == null ? "" : GridProdutores.CurrentRow.Cells[5].Value.ToString();
            textBoxEmail.Text = GridProdutores.CurrentRow.Cells[6].Value == null ? "" : GridProdutores.CurrentRow.Cells[6].Value.ToString();

            //ACTIVO
            cbP = Boolean.Parse(GridProdutores.CurrentRow.Cells[7].Value.ToString());
            if(cbP == false)
            {
                checkBoxActivar.Checked = true;  
            }

            var vp = db.Vinhoes.Select(v => new
                {
                    v.Produtor
                }).Where(v => v.Produtor == id);

            if (vp.ToList().Count >= 1) cbV = true;

            if (cbV == true)
            {
                checkBoxActivar.Enabled = false;
            }
            else if (cbV == false)
            {
                checkBoxActivar.Enabled = true;
            }

            funcoes.cbOption(checkBoxActivar);

        }

        private void formProdutores_Load(object sender, EventArgs e)
        {
            getProdutores();
        }


        //// VALIDACOES
        #region VALIDACOES

        //TEXTBOX NOME
        private void textBoxNome_Validating(object sender, CancelEventArgs e)
        {
            if(textBoxNome.Text == "")
            {
                return;
            }
            if (Validacoes.ValidarNome(textBoxNome.Text) == false)
            {
                erros.SetError(textBoxNome, "O nome deve conter apenas letras e/ou espaços.");
                textBoxNome.Focus();
                e.Cancel = true;
                return;
            }
            else
            {
                erros.SetError(textBoxNome, "");
            }
        }

        private void textBoxNome_Validated(object sender, EventArgs e)
        {
            erros.SetError(textBoxNome, "");
        }

        //TEXTBOX LOCALIDADE
        private void textBoxLocalidade_Validating(object sender, CancelEventArgs e)
        {
            if(textBoxLocalidade.Text == "")
            {
                return;
            }
            if (Validacoes.ValidarNome(textBoxLocalidade.Text) == false)
            {
                erros.SetError(textBoxLocalidade, "O nome deve conter apenas letras e/ou espaços.");
                textBoxLocalidade.Focus();
                e.Cancel = true;
                return;
            }
            else
            {
                erros.SetError(textBoxLocalidade, "");
            }
        }

        private void textBoxLocalidade_Validated(object sender, EventArgs e)
        {
            erros.SetError(textBoxLocalidade, "");
        }

        //TEXTBOX MORADA
        private void textBoxMorada_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxMorada.Text == "")
            {
                return;
            }
            if (Validacoes.ValidarMorada(textBoxMorada.Text) == false)
            {
                erros.SetError(textBoxMorada, "A morada deve conter apenas letras, números e espaços.");
                textBoxMorada.Focus();
                e.Cancel = true;
                return;
            }
        }

        private void textBoxMorada_Validated(object sender, EventArgs e)
        {
            erros.SetError(textBoxMorada, "");
        }

        //CODIGO_POSTAL
        private void maskedTextBoxCodigoPostal_Click(object sender, EventArgs e)
        {
           if(maskedTextBoxCodigoPostal.Text == "____-___") maskedTextBoxCodigoPostal.Text = "";
        }
        private void maskedTextBoxCodigoPostal_Validating(object sender, CancelEventArgs e)
        {
            if (maskedTextBoxCodigoPostal.Text == "" || maskedTextBoxCodigoPostal.Text == "____-___")
            {
                return;
            }
            if (Validacoes.ValidarCodigoPostal(maskedTextBoxCodigoPostal.Text) == false)
            {
                erros.SetError(maskedTextBoxCodigoPostal, "O codigo postal so deve conter numeros no formato 0000-000 ou 0000.");
                maskedTextBoxCodigoPostal.Focus();
                e.Cancel = true;
                return;
            }
            else
            {
                erros.SetError(maskedTextBoxCodigoPostal, "");
            }
        }
        private void maskedTextBoxCodigoPostal_Validated(object sender, EventArgs e)
        {
            erros.SetError(maskedTextBoxCodigoPostal, "");
            if (maskedTextBoxCodigoPostal.Text == "") maskedTextBoxCodigoPostal.Text = "____-___";
        }

        //TELEFONE
        private void textBoxTelefone_Validating(object sender, CancelEventArgs e)
        {
            if(textBoxTelefone.Text == "")
            {
                return;
            }
            else if(Validacoes.ValidarTelefone(textBoxTelefone.Text) == false && Validacoes.ValidarTelemovel(textBoxTelefone.Text) == false)
            {
                erros.SetError(textBoxTelefone, "O telefone de comecar por 2 ou 3, seguido de 8 dígitos ou por por 9, seguido de um dos seguintes dígitos(1, 2, 3 ou 6), seguido de 7 dígitos.");
                textBoxTelefone.Focus();
                e.Cancel = true;
                return;
            }
            else
            {
                erros.SetError(textBoxTelefone, "");
            }
        }

        private void textBoxTelefone_Validated(object sender, EventArgs e)
        {
            erros.SetError(textBoxTelefone, "");
        }

        //EMAIL
        private void textBoxEmail_Validating(object sender, CancelEventArgs e)
        {
            string key = "f46fdabb8ca87c433debfbc7660e2b2d";

            //configurar pedido
            WebRequest request;
            request = WebRequest.Create("http://apilayer.net/api/check?access_key=" + key + "&email=" + textBoxEmail.Text + "&smtp=&format=1");
            request.ContentType = "application/json";

            //obter resposta (JSON)
            WebResponse response = request.GetResponse();

            //converter resposta para formato texto (string)
            Stream stream = response.GetResponseStream();
            StreamReader stream_reader = new StreamReader(stream);
            string json = stream_reader.ReadToEnd();

            //converter string para objecto
            Email dados = JsonConvert.DeserializeObject<Email>(json);

            if (textBoxEmail.Text == "")
            {
                return;
            }
            if (dados.format_valid == false)
            {
                erros.SetError(textBoxEmail, "O Formato deve ser exemplo@exem.com");
                textBoxEmail.Focus();
                e.Cancel = true;
                return;
            }

        }
        private void textBoxEmail_Validated(object sender, EventArgs e)
        {
            erros.SetError(textBoxEmail, "");
        }
        #endregion

        ///// PRODUTORES INSERIR ALTERAR ELIMINAR
        #region PRODUTORES INSERIR ALTERAR ELIMINAR
        private void checkBoxActivar_CheckedChanged(object sender, EventArgs e)
        {
            funcoes.cbOption(checkBoxActivar);
        }

        void alterarbtns()
        {
            buttonInserir.Enabled = true;
            buttonInserir.Visible = true;
            buttonAlterar.Visible = false;
            buttonAlterar.Enabled = false;
            buttonEliminar.Visible = false;
            linkLabelInserirNovo.Visible = false;
        }

        private void linkLabelInserirNovo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            alterarbtns();
            funcoes.Clean(this);
            alterarBtnSetErros("setErros");
        }

        int confirmInserir()
        {
            confirm = 0;
            confirm += funcoesRetorno.obrigatorioPreencher(textBoxNome, erros, confirm);
            confirm += funcoesRetorno.obrigatorioPreencher(textBoxMorada, erros, confirm);
            confirm += funcoesRetorno.obrigatorioPreencher(textBoxLocalidade, erros, confirm);
            confirm += funcoesRetorno.obrigatorioPreencherMaskedTextBox(maskedTextBoxCodigoPostal, erros, confirm);

            return confirm;
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            confirm = confirmInserir();

            try
            {
                if (confirm == 0)
                {
                    int contagem = MetodosProdutores.produtoresRepetidos(textBoxNome.Text.ToString());

                    if (contagem == 0)
                    {
                        Produtor p = new Produtor();
                        p.Nome = textBoxNome.Text.ToString();
                        p.Morada = textBoxMorada.Text.ToString();
                        p.CodigoPostal = maskedTextBoxCodigoPostal.Text.ToString();
                        p.Localidade = textBoxLocalidade.Text.ToString();
                        p.Telefone = textBoxTelefone.Text.ToString();
                        p.Email = textBoxEmail.Text.ToString();
                        p.Activo = funcoesRetorno.activar(checkBoxActivar);
                        MetodosProdutores.insertProdutor(p);

                    }
                    else MessageBox.Show("Nome do Produtor repetido", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possivel inserir o produtor", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }       
                reset();
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            confirm = confirmInserir();

            try
            {
                if (confirm == 0)
                {
                    Produtor p = new Produtor();
                    p.Id = id;
                    p.Nome = textBoxNome.Text.ToString();
                    p.Morada = textBoxMorada.Text.ToString();
                    p.CodigoPostal = maskedTextBoxCodigoPostal.Text.ToString();
                    p.Localidade = textBoxLocalidade.Text.ToString();
                    p.Telefone = textBoxTelefone.Text.ToString();
                    p.Email = textBoxEmail.Text.ToString();
                    p.Activo = funcoesRetorno.activar(checkBoxActivar);
                    MetodosProdutores.updateProdutor(p);
                }        
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possivel alterar o produtor", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
                reset("btn");   
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbP == false && cbV == false)
                {
                    MetodosProdutores.deleteProdutor(id);
                }
                else
                {
                    MessageBox.Show("O Produtor seleccionado não pode ser eliminad0", "Eliminar - erro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possivel eliminar o produtor", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        
                reset("btn");
             
        }

        #endregion

       
    }
}
