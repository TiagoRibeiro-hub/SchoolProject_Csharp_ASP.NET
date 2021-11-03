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
    public partial class formCastas : Form
    {
        public formCastas()
        {
            InitializeComponent();
        }

        public string escolherVinho
        {
            set { textBoxTipoDeVinho.Text = value; }
        }

        VinhosEFAEntities db = new VinhosEFAEntities();
        int idC, idTV, confirm;
        bool cbC, cbTV, cbCv = false, vTPV = false;

        void reset()
        {
            funcoes.Clean(this);
            getCastas();
            funcoes.cbOption(checkBoxActivar);
        }
        void getCastas()
        {
            MetodosCastas.getCastas(GridCastas, null);
        }

        private void GridCastas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idC = int.Parse(GridCastas.CurrentRow.Cells[0].Value.ToString()); // castas
            textBoxNome.Text = GridCastas.CurrentRow.Cells[1].Value == null ? "" : GridCastas.CurrentRow.Cells[1].Value.ToString();
            richTextBoxCaracteristicas.Text = GridCastas.CurrentRow.Cells[2].Value == null ? "" : GridCastas.CurrentRow.Cells[2].Value.ToString();

            idTV = int.Parse(GridCastas.CurrentRow.Cells[3].Value.ToString()); // tipo de vinho
            textBoxTipoDeVinho.Text = GridCastas.CurrentRow.Cells[4].Value == null ? "" : GridCastas.CurrentRow.Cells[4].Value.ToString();

            cbC = Boolean.Parse(GridCastas.CurrentRow.Cells[5].Value.ToString()); // castas
            cbTV = Boolean.Parse(GridCastas.CurrentRow.Cells[6].Value.ToString()); // tipo de vinho
            if (cbC == false && cbTV == false)
            {
                checkBoxActivar.Checked = true;
            }

            // LIGACAO COM TIPO DE CASTAS
            var env = db.VinhoCastas.Select(en => new
            {
                en.Casta
            }).Where(en => en.Casta == idC);

            if (env.ToList().Count >= 1) cbCv = true;

            if (cbCv == true)
            {
                checkBoxActivar.Enabled = false;
                buttonAlterar.Enabled = false;
                buttonEliminar.Enabled = false;
            }
            else if (cbCv == false)
            {
                checkBoxActivar.Enabled = true;
                buttonAlterar.Enabled = true;
                buttonEliminar.Enabled = true;
            }

            //LIGACAO COM TIPO DE VINHOS
            if ((cbC == true && cbTV == false) || (cbC == false && cbTV == true) || (cbC == true && cbTV == true))
            {
                checkBoxActivar.Enabled = false;
            }

            // CONFIRMAR SE TIPOS DE VINHO TEM LIGAÇAO COM VINHOS
            var vtpv = db.Vinhoes.Select(v => new
            {
                v.TipoVinho,
            }).Where(v => v.TipoVinho == idTV);

            if (vtpv.ToList().Count >= 1)
            {
                vTPV = true;
            }
            else
            {
                vTPV = false;
            }

            funcoes.cbOption(checkBoxActivar);
            buttonAlterar.Visible = true;
            buttonEliminar.Visible = true;
        }

        private void linkLabelEscolherTipoVinho_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formTiposDeVinhos fTv = new formTiposDeVinhos();
            fTv.btnEscolher = "Escolher";
            fTv.lbescolher = true;
            fTv.tbEscolher = true;
            fTv.ShowDialog();
            textBoxTipoDeVinho.Text = fTv.tipoVinhoEscolhido;
        }

        private void formCastas_Load(object sender, EventArgs e)
        {
            getCastas();
        }

        /////VALIDACOES
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

        private void textBoxTipoDeVinho_Validated(object sender, EventArgs e)
        {
            erros.SetError(textBoxTipoDeVinho, "");
        }
        #endregion

        /////ENOLOGO INSERIR ALTERAR ELIMINAR
        #region ENOLOGO INSERIR ALTERAR ELIMINAR
        private void checkBoxActivar_Click(object sender, EventArgs e)
        {
            funcoes.cbOption(checkBoxActivar);
        }

        int confirmInserir()
        {
            confirm = 0;
            confirm += funcoesRetorno.obrigatorioPreencher(textBoxNome, erros, confirm);
            confirm += funcoesRetorno.obrigatorioPreencher(textBoxTipoDeVinho, erros, confirm);
            return confirm;
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            confirm = confirmInserir();

            try
            {
                if (confirm == 0)
                {
                    TipoVinho tv = new TipoVinho();
                    Casta ca = new Casta();

                    int contagemCasta = MetodosCastas.castasRepetidas(textBoxNome.Text.ToString());
                    int contagemTipoVinho = MetodosTipoDeVinho.tipoVinhosRepetidos(textBoxTipoDeVinho.Text.ToString(), out int vinhoID);

                    if (vTPV == true)
                    {
                        checkBoxActivar.Checked = false;
                    }

                    if (contagemCasta == 0)
                    {
                        if (contagemTipoVinho != 0)
                        {
                            tv.Id = vinhoID;

                            ca.Nome = textBoxNome.Text.ToString();
                            ca.Caracteristicas = richTextBoxCaracteristicas.Text.ToString();
                            ca.TipoVinho = tv.Id;
                            ca.Activo = funcoesRetorno.activar(checkBoxActivar);
                            MetodosCastas.insertCastas(ca);
                            contagemTipoVinho += 1;
                        }

                        if (contagemTipoVinho == 0)
                        {
                            tv.Nome = textBoxTipoDeVinho.Text.ToString();
                            tv.Activo = funcoesRetorno.activar(checkBoxActivar);
                            MetodosTipoDeVinho.insertTipoDeVinho(tv);

                            ca.Nome = textBoxNome.Text.ToString();
                            ca.Caracteristicas = richTextBoxCaracteristicas.Text.ToString();
                            ca.TipoVinho = tv.Id;
                            ca.Activo = funcoesRetorno.activar(checkBoxActivar);
                            MetodosCastas.insertCastas(ca);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Casta repetida", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possivel inserir a casta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (vTPV == true)
                    {
                        checkBoxActivar.Checked = false;
                    }
                    TipoVinho tv = new TipoVinho();
                    tv.Id = idTV;
                    tv.Nome = textBoxTipoDeVinho.Text.ToString();
                    tv.Activo = funcoesRetorno.activar(checkBoxActivar);

                    MetodosTipoDeVinho.updateTipoDeVinho(tv);

                    Casta ca = new Casta();
                    ca.Id = idC;
                    ca.Nome = textBoxNome.Text.ToString();
                    ca.Caracteristicas = richTextBoxCaracteristicas.Text.ToString();
                    ca.TipoVinho = idTV;
                    ca.Activo = funcoesRetorno.activar(checkBoxActivar);

                    MetodosCastas.updateCastas(ca);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possivel alterar a casta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reset();
            buttonAlterar.Visible = false;
            buttonEliminar.Visible = false;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbC == false && cbTV == false && cbCv == false)
                {
                    MetodosCastas.deleteCastas(idC);
                    if (vTPV == false)
                    {
                        MetodosTipoDeVinho.deleteTipoDeVinho(idTV);
                    }
                }
                else
                {
                    MessageBox.Show("A Casta seleccionado não pode ser eliminado", "Eliminar - erro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possivel eliminar a casta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            reset();
            buttonAlterar.Visible = false;
            buttonEliminar.Visible = false;
        }

        #endregion
    }
}
