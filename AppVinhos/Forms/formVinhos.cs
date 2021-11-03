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
    public partial class formVinhos : Form
    {
        public formVinhos()
        {
            InitializeComponent();
        }
        static VinhosEFAEntities db = new VinhosEFAEntities();
        int id, idPro, idReg, idTpVi, confirm = 0;
        string listaCastas = "", listaEnologos = "";
        bool vv;

        //////FUNCOES
        #region FUNCOES
        void reset(string btn = "opcional")
        {
            funcoes.Clean(this);
            getVinhos();
            funcoes.cbOption(checkBoxActivar);
            if (btn.Contains("btn"))
            {
                alterarBtns();
            }
        }
        void alterarBtns()
        {
            buttonAlterar.Visible = false;
            buttonAlterar.Enabled = false;
            buttonEliminar.Visible = false;
            buttonInserir.Visible = true;
            buttonInserir.Enabled = true;
            linkLabelInserirNovo.Visible = false;
            linkLabelCopiar.Visible = false;
            buttonEliminarCasta.Text = "Eliminar Casta";
            buttonEscolherCastas.Text = "Inserir Casta";
            buttonEliminarEnologo.Text = "Eliminar Enologo";
            buttonEscolherEnologo.Text = "Inserir Enologo";
        }
        void alterarBtnSetErros(string i = "alterar")
        {
            if (i.Contains("alterar"))
            {
                buttonAlterar.Visible = true;
                buttonAlterar.Enabled = true;
                linkLabelCopiar.Visible = true;
                buttonInserir.Visible = false;
                buttonInserir.Enabled = false;
            }
            erros.SetError(textBoxNome, "");
            erros.SetError(textBoxAno, "");
            erros.SetError(textBoxVolume, "");
            erros.SetError(textBoxTeorAlcoolico, "");
            erros.SetError(textBoxTemperatura, "");
            erros.SetError(comboBoxEnologos, "");
            erros.SetError(comboBoxCastas, "");
            erros.SetError(comboBoxTiposDeVinhos, "");
            erros.SetError(comboBoxRegioes, "");
            erros.SetError(comboBoxProdutores, "");
        }

        void getVinhos()
        {
            MetodosVinhos.getVinhos(GridVinhos, comboBoxProdutores, comboBoxRegioes, comboBoxTiposDeVinhos, comboBoxCastas, comboBoxEnologos, null);
        }

        #endregion

        private void GridVinhos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            funcoes.Clean(this);
            alterarBtnSetErros();

            // VINHO
            id = int.Parse(GridVinhos.CurrentRow.Cells[0].Value.ToString()); //id
            textBoxNome.Text = GridVinhos.CurrentRow.Cells[1].Value == null ? "" : GridVinhos.CurrentRow.Cells[1].Value.ToString(); // nome
            textBoxAno.Text = GridVinhos.CurrentRow.Cells[2].Value == null ? "" : GridVinhos.CurrentRow.Cells[2].Value.ToString();  //ano

            textBoxVolume.Text = GridVinhos.CurrentRow.Cells[3].Value == null ? "" : GridVinhos.CurrentRow.Cells[3].Value.ToString(); // volume
            if (textBoxVolume.Text.Equals("0,00")) textBoxVolume.Text = "";

            textBoxTeorAlcoolico.Text = GridVinhos.CurrentRow.Cells[4].Value == null ? "" : GridVinhos.CurrentRow.Cells[4].Value.ToString(); //teorAlcool
            if (textBoxTeorAlcoolico.Text.Equals("0,00")) textBoxTeorAlcoolico.Text = "";

            textBoxTemperatura.Text = GridVinhos.CurrentRow.Cells[5].Value == null ? "" : GridVinhos.CurrentRow.Cells[5].Value.ToString(); //temperaturaif (textBoxTemperatura.Text.Equals("0,00")) textBoxTemperatura.Text = "";
            if (textBoxTemperatura.Text.Equals("0,00")) textBoxTemperatura.Text = "";


            // COMBOBOXES
            idReg = int.Parse(GridVinhos.CurrentRow.Cells[7].Value.ToString()); // regiao
            comboBoxRegioes.SelectedValue = idReg;

            idPro = int.Parse(GridVinhos.CurrentRow.Cells[10].Value.ToString()); // produtor
            comboBoxProdutores.SelectedValue = idPro;

            idTpVi = int.Parse(GridVinhos.CurrentRow.Cells[13].Value.ToString()); // tipo de vinho
            comboBoxTiposDeVinhos.SelectedValue = idTpVi;
            ;

            // LISTBOX CASTAS
            var vc = db.Castas.Join(db.VinhoCastas, c => c.Id, v => v.Casta,
                (c, v) => new
                {
                    c.Id,
                    c.Nome,
                    ID = v.Vinho
                }).Where(c => c.ID == id);

            foreach (var item in vc.ToList())
            {
                listBoxCastas.Items.Add(item.Nome);
            }
            buttonEliminarCasta.Text = "Dissociar Casta";
            buttonEscolherCastas.Text = "Associar Casta";


            // LISTBOX ENOLOGOS
            var ve = db.Enologoes.Join(db.VinhoEnologoes, eno => eno.Id, v => v.Enologo,
                (eno, v) => new
                {
                    eno.Id,
                    eno.Nome,
                    ID = v.Vinho
                }).Where(eno => eno.ID == id);

            foreach (var item in ve.ToList())
            {
                listBoxEnologos.Items.Add(item.Nome);
            }

            ////ACTIVO
            vv = bool.Parse(GridVinhos.CurrentRow.Cells[6].Value.ToString());
            if (vv == false)
            {
                checkBoxActivar.Checked = true;
            }

            funcoes.cbOption(checkBoxActivar);
            buttonEliminarEnologo.Text = "Dissociar Enologo";
            buttonEscolherEnologo.Text = "Associar Enologo";

            linkLabelInserirNovo.Visible = true;
            buttonEliminar.Visible = true;

        }

        private void formVinhos_Load(object sender, EventArgs e)
        {
            getVinhos();
        }

        ///////////VALIDACOES
        #region VALIDACOES

        //TEXTBOX NOME
        private void textBoxNome_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxNome.Text == "")
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

        //TEXTBOX ANO
        private void textBoxAno_Validating(object sender, CancelEventArgs e)
        {
            DateTime p = new DateTime(1900, 1, 1);
            DateTime d = System.DateTime.Now;

            if (textBoxAno.Text == "")
            {
                return;
            }
            if (Validacoes.ValidarSoNumeros(textBoxAno.Text) == false)
            {
                erros.SetError(textBoxAno, "O ano deve conter apenas numeros.");
                textBoxAno.Focus();
                e.Cancel = true;
                return;
            }
            else
            {
                if (int.Parse(textBoxAno.Text) < p.Year)
                {
                    erros.SetError(textBoxAno, "Defina uma data igua ou posterior a 1900.");
                    textBoxAno.Focus();
                    e.Cancel = true;
                    return;
                }
                if (int.Parse(textBoxAno.Text) > d.Year)
                {
                    erros.SetError(textBoxAno, "Defina uma data inferior ao ano corrente.");
                    textBoxAno.Focus();
                    e.Cancel = true;
                    return;
                }
            }


        }
        private void textBoxAno_Validated(object sender, EventArgs e)
        {
            erros.SetError(textBoxAno, "");
        }

        //TEXTBOX VOLUME
        private void textBoxVolume_Validating(object sender, CancelEventArgs e)
        {

            if (textBoxVolume.Text == "")
            {
                return;
            }
            else if (Validacoes.ValidarSoNumeros(textBoxVolume.Text) == false)
            {
                erros.SetError(textBoxVolume, "O ano deve conter apenas numeros.");
                textBoxVolume.Focus();
                e.Cancel = true;
                return;
            }


            if (decimal.Parse(textBoxVolume.Text) <= 0 || decimal.Parse(textBoxVolume.Text) >= 100)
            {
                erros.SetError(textBoxVolume, "Numero real superior a 0 e inferior a 100");
                textBoxVolume.Focus();
                e.Cancel = true;
                return;
            }



        }
        private void textBoxVolume_Validated(object sender, EventArgs e)
        {
            erros.SetError(textBoxVolume, "");
        }

        //TEXTBOX TEOR ALCOOLICO
        private void textBoxTeorAlcoolico_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxTeorAlcoolico.Text == "")
            {
                return;
            }
            else if (Validacoes.ValidarSoNumeros(textBoxTeorAlcoolico.Text) == false)
            {
                erros.SetError(textBoxTeorAlcoolico, "O ano deve conter apenas numeros.");
                textBoxTeorAlcoolico.Focus();
                e.Cancel = true;
                return;
            }


            if (decimal.Parse(textBoxTeorAlcoolico.Text) <= 0 || decimal.Parse(textBoxTeorAlcoolico.Text) >= 100)
            {
                erros.SetError(textBoxTeorAlcoolico, "Numero real superior a 0 e inferior a 100");
                textBoxTeorAlcoolico.Focus();
                e.Cancel = true;
                return;
            }
        }

        private void textBoxTeorAlcoolico_Validated(object sender, EventArgs e)
        {
            erros.SetError(textBoxTeorAlcoolico, "");
        }

        //TEXTBOX TEMPERATURA
        private void textBoxTemperatura_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxTemperatura.Text == "")
            {
                return;
            }
            else if (Validacoes.ValidarSoNumeros(textBoxTemperatura.Text) == false)
            {
                erros.SetError(textBoxTemperatura, "O ano deve conter apenas numeros.");
                textBoxTemperatura.Focus();
                e.Cancel = true;
                return;
            }


            if (decimal.Parse(textBoxTemperatura.Text) <= 0 || decimal.Parse(textBoxTemperatura.Text) >= 100)
            {
                erros.SetError(textBoxTemperatura, "Numero real superior a 0 e inferior a 100");
                textBoxTemperatura.Focus();
                e.Cancel = true;
                return;
            }
        }

        private void textBoxTemperatura_Validated(object sender, EventArgs e)
        {
            erros.SetError(textBoxTemperatura, "");
        }


        //COMBOBOX PRODUTORES
        private void comboBoxProdutores_Validated(object sender, EventArgs e)
        {
            erros.SetError(comboBoxProdutores, "");
        }

        //COMBOBOX REGIOES
        private void comboBoxRegioes_Validated(object sender, EventArgs e)
        {
            erros.SetError(comboBoxRegioes, "");
        }
        //COMBOBOX TIPO DE VINHOS
        private void comboBoxTiposDeVinhos_Validated(object sender, EventArgs e)
        {
            erros.SetError(comboBoxTiposDeVinhos, "");
        }

        //COMBOBOX CASTAS
        private void comboBoxCastas_Validated(object sender, EventArgs e)
        {
            erros.SetError(comboBoxCastas, "");
        }

        //COMBOBOX ENOLOGOS
        private void comboBoxEnologos_Validated(object sender, EventArgs e)
        {
            erros.SetError(comboBoxEnologos, "");
        }


        #endregion

        ///////////LIST BOX CASTAS E ENOLOGOS
        #region LISTBOX
        List<string> liCa = new List<string>();
        List<string> liEn = new List<string>();
        bool igual = false, casta = false, enologo = false, associar = false;

        void inseririrListBox(string op)
        {
            if (op.Contains("c"))
            {
                if (associar == true)
                {
                    listBoxCastas.Items.Add(comboBoxCastas.Text);
                    db.usp_AssociarCastas(id, comboBoxCastas.SelectedValue.ToString());
                }
                if (igual == true)
                {
                    listBoxCastas.Items.Add(comboBoxCastas.Text);
                    liCa.Add(comboBoxCastas.SelectedValue.ToString());
                }
            }
            if (op.Contains("e"))
            {
                if (associar == true)
                {
                    listBoxEnologos.Items.Add(comboBoxEnologos.Text);
                    db.usp_AssociarEnologo(id, comboBoxEnologos.SelectedValue.ToString());
                }
                if (igual == true)
                {
                    listBoxEnologos.Items.Add(comboBoxEnologos.Text);
                    liEn.Add(comboBoxEnologos.SelectedValue.ToString());
                }
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (casta == true)
            {
                casta = false;
                string c = "c";
                foreach (var item in listBoxCastas.Items)
                {
                    if (item.ToString().Contains(comboBoxCastas.Text))
                    {
                        igual = false;
                        associar = false;
                        break;
                    }
                }
                inseririrListBox(c);
            }
            if (enologo == true)
            {
                enologo = false;
                string E = "e";
                foreach (var item in listBoxEnologos.Items)
                {
                    if (item.ToString().Contains(comboBoxEnologos.Text))
                    {
                        igual = false;
                        associar = false;
                        break;
                    }
                }
                inseririrListBox(E);
            }

        }

        // CASTAS
        private void buttonEscolherCastas_Click(object sender, EventArgs e)
        {
            if (buttonEscolherCastas.Text.Contains("Associar Casta"))
            {
                associar = true;
            }
            else
            {
                igual = true;
            }

            if (listBoxCastas.Items.Count >= 1)
            {
                casta = true;
                timer1.Enabled = true;
            }
            else if (buttonEscolherCastas.Text.Contains("Associar Casta"))
            {
                listBoxCastas.Items.Add(comboBoxCastas.Text);
                db.usp_AssociarCastas(id, comboBoxCastas.SelectedValue.ToString());
            }
            else
            {
                listBoxCastas.Items.Add(comboBoxCastas.Text);
                liCa.Add(comboBoxCastas.SelectedValue.ToString());
            }

        }

        string listarCastas()
        {
            int contagem = liCa.Count;
            foreach (var item in liCa)
            {
                if (contagem == 1)
                {
                    listaCastas += item.ToString();
                }
                else
                {
                    listaCastas += item.ToString() + ", ";
                }
                contagem -= 1;
            }
            return listaCastas;
        }

        private void buttonEliminarCasta_Click(object sender, EventArgs e)
        {
            if (listBoxCastas.SelectedIndex >= 0)
            {
                if (buttonEliminarCasta.Text.Contains("Dissociar Casta"))
                {
                    MetodosVinhoCastas.dissociarCastas(id, listBoxCastas.SelectedItem.ToString());
                    listBoxCastas.Items.Remove(listBoxCastas.SelectedItem.ToString());
                }
                else
                {
                    listBoxCastas.Items.Remove(listBoxCastas.SelectedItem.ToString());
                }

            }

        }

        // ENOLOGO
        private void buttonEscolherEnologo_Click(object sender, EventArgs e)
        {
            if (buttonEscolherEnologo.Text.Contains("Associar Enologo"))
            {
                associar = true;
            }
            else
            {
                igual = true;
            }
            if (listBoxEnologos.Items.Count >= 1)
            {
                enologo = true;
                timer1.Enabled = true;
            }
            else if (buttonEscolherEnologo.Text.Contains("Associar Enologo"))
            {
                listBoxEnologos.Items.Add(comboBoxEnologos.Text);
                db.usp_AssociarEnologo(id, comboBoxEnologos.SelectedValue.ToString());
            }
            else
            {
                listBoxEnologos.Items.Add(comboBoxEnologos.Text);
                liEn.Add(comboBoxEnologos.SelectedValue.ToString());
            }

        }

        string listarEnologos()
        {
            int contagem = liEn.Count;
            foreach (var item in liEn)
            {
                if (contagem == 1)
                {
                    listaEnologos += item.ToString();
                }
                else
                {
                    listaEnologos += item.ToString() + ", ";
                }
                contagem -= 1;
            }
            return listaEnologos;
        }


        private void buttonEliminarEnologo_Click(object sender, EventArgs e)
        {
            if (listBoxEnologos.SelectedIndex >= 0)
            {
                if (buttonEliminarEnologo.Text.Contains("Dissociar Enologo"))
                {
                    MetodosVinhoEnologos.dissociarEnologos(id, listBoxEnologos.SelectedItem.ToString());
                    listBoxEnologos.Items.Remove(listBoxEnologos.SelectedItem.ToString());
                }
                else
                {
                    listBoxEnologos.Items.Remove(listBoxEnologos.SelectedItem.ToString());
                }
            }
        }
        #endregion

        ///////////VINHOS INSERT UPDATE DELETE
        #region INSERT UPDATE DELETE
        private void checkBoxActivar_CheckedChanged(object sender, EventArgs e)
        {
            funcoesRetorno.activar(checkBoxActivar);
        }

        private void linkLabelInserirNovo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            alterarBtns();
            funcoes.Clean(this);
            alterarBtnSetErros("setErros");
        }

        private void linkLabelCopiar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            alterarBtns();
            foreach (Control item in this.Controls)
            {
                if (item is ListBox)
                {
                    ListBox l = (ListBox)item;
                    l.Items.Clear();
                }
            }
        }

        int confirmInserir(string alterar = "opcional")
        {
            confirm = 0;
            confirm += funcoesRetorno.obrigatorioPreencher(textBoxNome, erros, confirm);
            confirm += funcoesRetorno.obrigatorioPreencher(textBoxAno, erros, confirm);
            confirm += funcoesRetorno.obrigatorioPreencher(textBoxAno, erros, confirm);
            confirm += funcoesRetorno.obrigatorioPreencherComboBox(comboBoxProdutores, erros, confirm);
            confirm += funcoesRetorno.obrigatorioPreencherComboBox(comboBoxRegioes, erros, confirm);
            confirm += funcoesRetorno.obrigatorioPreencherComboBox(comboBoxTiposDeVinhos, erros, confirm);

            if (alterar.Contains("y"))
            {
                confirm += funcoesRetorno.obrigatorioPreencherListBox(listBoxCastas, erros, confirm, comboBoxCastas);
                confirm += funcoesRetorno.obrigatorioPreencherListBox(listBoxEnologos, erros, confirm, comboBoxEnologos);
            }
            else
            {
                confirm += funcoesRetorno.obrigatorioPreencherComboBox(comboBoxCastas, erros, confirm);
                confirm += funcoesRetorno.obrigatorioPreencherComboBox(comboBoxEnologos, erros, confirm);
            }

            return confirm;
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            confirm = confirmInserir();
            int resCompVinhos = 0;
            listaCastas = listarCastas();
            listaEnologos = listarEnologos();

            if (confirm == 0)
            {
                resCompVinhos = MetodosVinhos.compararVinhos(textBoxNome.Text.ToString(), textBoxAno.Text.ToString(),
                                textBoxVolume.Text.ToString(), textBoxTeorAlcoolico.Text.ToString(),
                                textBoxTemperatura.Text.ToString(), comboBoxRegioes.SelectedValue.ToString(),
                                comboBoxProdutores.SelectedValue.ToString(), comboBoxTiposDeVinhos.SelectedValue.ToString(), liCa);

                if (resCompVinhos == 0)
                {
                    try
                    {
                        Vinho v = new Vinho();

                        v.Nome = textBoxNome.Text.ToString();
                        v.Volume = decimal.Parse(textBoxVolume.Text == "" ? "0" : textBoxVolume.Text);
                        v.TeorAlcoolico = decimal.Parse(textBoxTeorAlcoolico.Text == "" ? "0" : textBoxTeorAlcoolico.Text);
                        v.Temperatura = decimal.Parse(textBoxTemperatura.Text == "" ? "0" : textBoxTemperatura.Text);
                        v.Ano = int.Parse(textBoxAno.Text);
                        v.Regiao = (int)comboBoxRegioes.SelectedValue;
                        v.Produtor = (int)comboBoxProdutores.SelectedValue;
                        v.TipoVinho = (int)comboBoxTiposDeVinhos.SelectedValue;
                        v.Activo = funcoesRetorno.activar(checkBoxActivar);

                        MetodosVinhos.insertVinhos(v);


                        if (!listaCastas.Equals(""))
                        {
                            db.usp_AssociarCastas(v.Id, listaCastas);
                        }
                        if (!listaEnologos.Equals(""))
                        {
                            db.usp_AssociarEnologo(v.Id, listaEnologos);
                        }


                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Não foi possivel inserir o vinho", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Este vinho já se encontra registado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                reset();


            }
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            confirm = confirmInserir("y");

            if (confirm == 0)
            {
                try
                {
                    Vinho v = new Vinho();

                    v.Id = id;
                    v.Nome = textBoxNome.Text.ToString();
                    v.Volume = decimal.Parse(textBoxVolume.Text == "" ? "0" : textBoxVolume.Text);
                    v.TeorAlcoolico = decimal.Parse(textBoxTeorAlcoolico.Text == "" ? "0" : textBoxTeorAlcoolico.Text);
                    v.Temperatura = decimal.Parse(textBoxTemperatura.Text == "" ? "0" : textBoxTemperatura.Text);
                    v.Ano = int.Parse(textBoxAno.Text);
                    v.Regiao = (int)comboBoxRegioes.SelectedValue;
                    v.Produtor = (int)comboBoxProdutores.SelectedValue;
                    v.TipoVinho = (int)comboBoxTiposDeVinhos.SelectedValue;
                    v.Activo = funcoesRetorno.activar(checkBoxActivar);

                    MetodosVinhos.updateVinhos(v);

                }
                catch (Exception)
                {

                    MessageBox.Show("Não foi possivel alterar o vinho", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                reset("btn");

            }

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Tem a certeza que pertende eliminar?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    checkBoxActivar.Checked = false;
                    MetodosVinhoCastas.deleteVinhoCastas(id);
                    MetodosVinhoEnologos.deleteVinhoEnologos(id);
                    MetodosVinhos.deleteVinhos(id);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possivel eliminar o vinho", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            reset("btn");

        }

        #endregion



    }
}
