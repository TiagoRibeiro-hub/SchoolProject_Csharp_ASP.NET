using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppVinhos;
using dbVinhosEFA;
using dbVinhosEFA.Metodos;
using libraryValidacoes;

namespace AppVinhos
{
    public partial class formRegioes : Form
    {
        public formRegioes()
        {
            InitializeComponent();
        }

        VinhosEFAEntities db = new VinhosEFAEntities();
        int id, confirm; bool reg, regV = false;

        void reset()
        {
            funcoes.Clean(this);
            getRegioes();
            funcoes.cbOption(checkBoxActivar);
        }

        void getRegioes()
        {
            MetodosRegioes.getRegioes(GridRegioes, null);     
        }

        private void GridRegioes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(GridRegioes.CurrentRow.Cells[0].Value.ToString());
            textBoxNome.Text = GridRegioes.CurrentRow.Cells[1].Value == null ? "" : GridRegioes.CurrentRow.Cells[1].Value.ToString();
            richTextBoxDescricao.Text = GridRegioes.CurrentRow.Cells[2].Value == null ? "" : GridRegioes.CurrentRow.Cells[2].Value.ToString();

            reg = Boolean.Parse(GridRegioes.CurrentRow.Cells[3].Value.ToString());
            if (reg == false)
            {
                checkBoxActivar.Checked = true;
            }

            var re = db.Vinhoes.Select(v => new
            {
                v.Regiao
            }).Where(v => v.Regiao == id);


            if (re.ToList().Count >= 1) regV = true;

            if (regV == true)
            {
                checkBoxActivar.Enabled = false;
                buttonAlterar.Enabled = false;
                buttonEliminar.Enabled = false;
            }
            else if (regV == false)
            {
                checkBoxActivar.Enabled = true;
                buttonAlterar.Enabled = true;
                buttonEliminar.Enabled = true;
            }


            funcoes.cbOption(checkBoxActivar);
            buttonAlterar.Visible = true;
            buttonEliminar.Visible = true;
        }

        private void formRegioes_Load(object sender, EventArgs e)
        {
            getRegioes();
        }


        ///////VALIDACOES
        #region VALIDACOES
        private void textBoxNome_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxNome.Text == "")
            {
                return;
            }
            if (Validacoes.ValidarNome(textBoxNome.Text) == false)
            {
                erros.SetError(textBoxNome, "O nome só deverá incluir letras (maiúsculas ou minúsculas) e espaços");
                textBoxNome.Focus();
                e.Cancel = true;
                return;
            }
        }

        private void textBoxNome_Validated(object sender, EventArgs e)
        {
            erros.SetError(textBoxNome, "");
        }
        #endregion

        /////ENOLOGO INSERIR ALTERAR ELIMINAR
        #region ENOLOGO INSERIR ALTERAR ELIMINAR

        private void linkLabelProcuraRegioes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formListaRegioes flr = new formListaRegioes();
            flr.ShowDialog();
            textBoxNome.Text = flr.regiaoEscolhida;
        }

        private void checkBoxActivar_Click(object sender, EventArgs e)
        {
            funcoes.cbOption(checkBoxActivar);
        }

        int confirmInserir()
        {
            confirm = 0;
            confirm += funcoesRetorno.obrigatorioPreencher(textBoxNome, erros, confirm);

            return confirm;
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            confirm = confirmInserir();

            try
            {
                if (confirm == 0)
                {
                    var regRepetidas = db.Regiaos.Select(re => new { re.Nome }).Distinct().OrderBy(re => re.Nome);

                    int contagem = MetodosRegioes.regioesRepetidas(textBoxNome.Text.ToString());

                    if (contagem == 0)
                    {
                        Regiao r = new Regiao();
                        r.Nome = textBoxNome.Text.ToString();
                        r.Descricao = richTextBoxDescricao.Text.ToString();
                        r.Activo = funcoesRetorno.activar(checkBoxActivar);
                        MetodosRegioes.insertRegiao(r);
                    }
                    else MessageBox.Show("Região repetida", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possivel inserir a região", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Regiao r = new Regiao();
                    r.Id = id;
                    r.Nome = textBoxNome.Text.ToString();
                    r.Descricao = richTextBoxDescricao.Text.ToString();
                    r.Activo = funcoesRetorno.activar(checkBoxActivar);
                    MetodosRegioes.updateRegiao(r);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possivel alterar a região", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            reset();
            buttonAlterar.Visible = false;
            buttonEliminar.Visible = false;

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (reg == false && regV == false)
                {
                    MetodosRegioes.deleteRegiao(id);
                }
                else
                {
                    MessageBox.Show("O enologo seleccionado não pode ser eliminado", "Eliminar - erro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possivel eliminar a região", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            reset();
            buttonAlterar.Visible = false;
            buttonEliminar.Visible = false;


        }

        #endregion
    }
}
