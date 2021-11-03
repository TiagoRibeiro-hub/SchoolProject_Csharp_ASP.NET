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
    public partial class formEnologos : Form
    {
        public formEnologos()
        {
            InitializeComponent();
        }

        VinhosEFAEntities db = new VinhosEFAEntities();
        int id, confirm; bool cb, cbe = false;

        void reset()
        {
            funcoes.Clean(this);
            getEnologos();
            funcoes.cbOption(checkBoxActivar);
        }

        void getEnologos()
        {
            MetodosEnologo.getEnologos(GridEnologos, null);
        }

        private void GridEnologos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(GridEnologos.CurrentRow.Cells[0].Value.ToString());
            textBoxNome.Text = GridEnologos.CurrentRow.Cells[1].Value == null ? "" : GridEnologos.CurrentRow.Cells[1].Value.ToString();
            textBoxInsta.Text = GridEnologos.CurrentRow.Cells[2].Value == null ? "" : GridEnologos.CurrentRow.Cells[2].Value.ToString();
            cb = Boolean.Parse(GridEnologos.CurrentRow.Cells[3].Value.ToString());
            if (cb == false)
            {
                checkBoxActivar.Checked = true;
            }

            var ve = db.VinhoEnologoes.Select(v => new
            {
                v.Enologo
            }).Where(v => v.Enologo == id);


            if (ve.ToList().Count >= 1) cbe = true;

            if (cbe == true)
            {
                checkBoxActivar.Enabled = false;
                buttonAlterar.Enabled = false;
                buttonEliminar.Enabled = false;
            }
            else if (cbe == false)
            {
                checkBoxActivar.Enabled = true;
                buttonAlterar.Enabled = true;
                buttonEliminar.Enabled = true;
            }

            funcoes.cbOption(checkBoxActivar);
            buttonAlterar.Visible = true;
            buttonEliminar.Visible = true;

        }

        private void formEnologos_Load(object sender, EventArgs e)
        {
            getEnologos();
        }

        private void checkBoxActivar_Click(object sender, EventArgs e)
        {
            funcoes.cbOption(checkBoxActivar);
        }

        ////// VALIDACAO
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

                    int contagem = MetodosEnologo.enologosRepetidos(textBoxNome.Text.ToString());

                    if (contagem == 0)
                    {
                        Enologo en = new Enologo();
                        en.Nome = textBoxNome.Text.ToString();
                        en.Instragram = textBoxInsta.Text.ToString();
                        en.Activo = funcoesRetorno.activar(checkBoxActivar);

                        MetodosEnologo.insertEnologo(en);
                    }
                    else MessageBox.Show("Enologo repetido", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possivel inserir o enologo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    Enologo en = new Enologo();
                    en.Id = id;
                    en.Nome = textBoxNome.Text.ToString();
                    en.Instragram = textBoxInsta.Text.ToString();
                    en.Activo = funcoesRetorno.activar(checkBoxActivar);

                    MetodosEnologo.updateEnologo(en);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possivel alterar o enologo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

                reset();
                buttonAlterar.Visible = false;
                buttonEliminar.Visible = false;
            


        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb == false && cbe == false)
                {
                    MetodosEnologo.deleteEnologo(id);
                }
                else
                {
                    MessageBox.Show("O enologo seleccionado não pode ser eliminado", "Eliminar - erro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possivel eliminar o enologo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
       
                reset();
                buttonAlterar.Visible = false;
                buttonEliminar.Visible = false;
            
        }

        #endregion

    }
}
