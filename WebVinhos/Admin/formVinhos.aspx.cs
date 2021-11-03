using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppVinhos;
using dbVinhosEFA;
using dbVinhosEFA.Metodos;

namespace WebVinhos
{
    public partial class formVinhos : System.Web.UI.Page
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();

        bool vinhoActivo;
        string listaCastas = "", listaEnologos = "";
        //--------------------------------------------------------------\\

        void reset(string limpar = "sim")
        {
            if (limpar == "no")
            {
                MetodosVinhos.getVinhos(null, null, null, null, null, null, GridViewVinhos, DropDownListRegiao, DropDownListProdutor, DropDownListTipoVinho, DropDownListCastas, DropDownListEnologos);

            }
            else
            {
                this.Master.limpar();
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
                Funcoes.checkBoxChanged(CheckBoxActivar);
                MetodosVinhos.getVinhos(null, null, null, null, null, null, GridViewVinhos, DropDownListRegiao, DropDownListProdutor, DropDownListTipoVinho, DropDownListCastas, DropDownListEnologos);
            }
        }

        void alterarbtns(string btn = "btnInserir")
        {
            if (btn.Equals("btnInserir"))
            {
                ButtonInserir.Text = "Inserir";
                ButtonEliminar.Visible = false;
                ButtonEliminarDeVez.Visible = false;
                LinkButtonInserir.Visible = false;
                CheckBoxActivar.Enabled = true;
                ButtonEliminarCasta.Text = "Eliminar";
                ButtonInserirCasta.Text = "Inserir";
                ButtonEliminarEnologo.Text = "Eliminar";
                ButtonInserirEnologo.Text = "Inserir";
            }
            else
            {
                ButtonInserir.Text = "Alterar";
                ButtonEliminar.Visible = true;
                ButtonEliminarDeVez.Visible = true;
                LinkButtonInserir.Visible = true;
                ButtonEliminarCasta.Text = "Dissociar Casta";
                ButtonInserirCasta.Text = "Associar Casta";
                ButtonEliminarEnologo.Text = "Dissociar Enologo";
                ButtonInserirEnologo.Text = "Associar Enologo";
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["castasAssociar"] != null)
                listaCastasAssociadas = (List<string>)ViewState["castasAssociar"];

            if (ViewState["enologosAssociar"] != null)
                listaEnologosAssociados = (List<string>)ViewState["enologosAssociar"];

            if (this.IsPostBack == false)
            {
                //TemplateField coluna = new TemplateField();
                //coluna.ItemStyle.Width = 200;
                //coluna.HeaderText = "User's";
                //coluna.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //GridViewVinhos.Columns.Add(coluna);
                RangeValidatorAno.MaximumValue = DateTime.Now.Year.ToString();
                reset();
            }

        }

        protected void GridViewVinhos_SelectedIndexChanged(object sender, EventArgs e)
        {
            alterarbtns("btnAlterar");
            ListBoxCastas.Items.Clear();
            ListBoxEnologos.Items.Clear();

            ViewState["idvs"] = int.Parse(GridViewVinhos.SelectedRow.Cells[1].Text);

            TextBoxNome.Text = GridViewVinhos.SelectedRow.Cells[2].Text;
            TextBoxAno.Text = GridViewVinhos.SelectedRow.Cells[3].Text;
            TextBoxVolume.Text = GridViewVinhos.SelectedRow.Cells[4].Text;
            TextBoxTeorAlcoolico.Text = GridViewVinhos.SelectedRow.Cells[5].Text;
            TextBoxTemperatura.Text = GridViewVinhos.SelectedRow.Cells[6].Text;

            //FOTO
            ImageFoto.ImageUrl = "~" + GridViewVinhos.SelectedRow.Cells[18].Text;

            // DROPDOWNLIST
            DropDownListRegiao.SelectedValue = GridViewVinhos.SelectedRow.Cells[8].Text;
            DropDownListProdutor.SelectedValue = GridViewVinhos.SelectedRow.Cells[11].Text;
            DropDownListTipoVinho.SelectedValue = GridViewVinhos.SelectedRow.Cells[14].Text;

            // LISTBOX
            MetodosVinhos.dropDownListCastasShow(null, ListBoxCastas, (int)ViewState["idvs"]);

            MetodosVinhos.dropDownListEnologosShow(null, ListBoxEnologos, (int)ViewState["idvs"]);

            // ACTIVO
            vinhoActivo = Funcoes.valorActivo(GridViewVinhos, 7);
            Funcoes.mudarCheckBox(CheckBoxActivar, vinhoActivo);

        }

        protected void GridViewVinhos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false; // id vinho
                e.Row.Cells[7].Visible = false; // activo vinho

                e.Row.Cells[8].Visible = false; // id regiao
                e.Row.Cells[10].Visible = false; // activo regiao

                e.Row.Cells[11].Visible = false; // id produtor
                e.Row.Cells[13].Visible = false; // activo produtor

                e.Row.Cells[14].Visible = false; // id tipo vinho
                e.Row.Cells[16].Visible = false; // activo tipo vinho

                e.Row.Cells[17].Visible = false; // id user

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //string nome = "";

                    //if (e.Row.Cells[17].Text != "")
                    //{
                    //    nome = MetodosUtilizador.nomeUtilizadorPorId(int.Parse(e.Row.Cells[17].Text));
                    //}
   
                    //HyperLink link = new HyperLink();
                    //link.Text = nome;
                    //link.NavigateUrl = "userListaVinhos.aspx?id=" + e.Row.Cells[17].Text;
                    //e.Row.Cells[19].Controls.Add(link);

                    e.Row.Cells[2].Text = Server.HtmlDecode(e.Row.Cells[2].Text); // nome
                    e.Row.Cells[3].Text = Server.HtmlDecode(e.Row.Cells[3].Text); // ano
                    e.Row.Cells[4].Text = Server.HtmlDecode(e.Row.Cells[4].Text); // volume
                    e.Row.Cells[5].Text = Server.HtmlDecode(e.Row.Cells[5].Text); // teor alcoolico
                    e.Row.Cells[6].Text = Server.HtmlDecode(e.Row.Cells[6].Text); // temperatura
                    e.Row.Cells[9].Text = Server.HtmlDecode(e.Row.Cells[9].Text); // regiao
                    e.Row.Cells[12].Text = Server.HtmlDecode(e.Row.Cells[12].Text); // produtor
                    e.Row.Cells[15].Text = Server.HtmlDecode(e.Row.Cells[15].Text); // tipo vinho
                    e.Row.Cells[18].Text = Server.HtmlDecode(e.Row.Cells[18].Text); // foto

                    bool res = Funcoes.mudarCorValorActivo(e, 7);
                    if (res)
                        e.Row.ForeColor = System.Drawing.Color.Blue;
                    else
                        e.Row.ForeColor = System.Drawing.Color.Red;

                }

            }
        }

        protected void GridViewVinhos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewVinhos.PageIndex = e.NewPageIndex;
            reset("no");
        }

        protected void CheckBoxActivar_CheckedChanged(object sender, EventArgs e)
        {
            Funcoes.checkBoxChanged(CheckBoxActivar);
        }

        protected void LinkButtonInserir_Click(object sender, EventArgs e)
        {
            alterarbtns();
            reset();
        }


        //--------------------------------------------------------------\\
        #region LISTBOXES
        List<string> listaCastasAssociadas = new List<string>();
        List<string> listaEnologosAssociados = new List<string>();

        bool associar = false, igual = false, casta = false, enologo = false;


        //--------------------------------------------------------------\\
        void inseririrListBox(string op)
        {
            if (op.Contains("c"))
            {
                if (associar == true)
                {
                    ListBoxCastas.Items.Add(DropDownListCastas.SelectedItem);
                    db.usp_AssociarCastas((int)ViewState["idvs"], DropDownListCastas.SelectedValue.ToString());
                }
                if (igual == true)
                {
                    ListBoxCastas.Items.Add(DropDownListCastas.SelectedItem);
                    listaCastasAssociadas.Add(DropDownListCastas.SelectedValue.ToString());
                    ViewState["castasAssociar"] = listaCastasAssociadas;
                }
            }
            if (op.Contains("e"))
            {
                if (associar == true)
                {
                    ListBoxEnologos.Items.Add(DropDownListEnologos.SelectedItem);
                    db.usp_AssociarEnologo((int)ViewState["idvs"], DropDownListEnologos.SelectedValue.ToString());
                }
                if (igual == true)
                {
                    ListBoxEnologos.Items.Add(DropDownListEnologos.SelectedItem);
                    listaEnologosAssociados.Add(DropDownListEnologos.SelectedValue.ToString());
                    ViewState["enologosAssociar"] = listaEnologosAssociados;
                }
            }

        }

        protected void confirmarSeNaoExiste()
        {
            if (casta == true)
            {
                casta = false;
                string c = "c";
                foreach (var item in ListBoxCastas.Items)
                {
                    if (item.ToString().Contains(DropDownListCastas.SelectedItem.ToString()))
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
                foreach (var item in ListBoxEnologos.Items)
                {
                    if (item.ToString().Contains(DropDownListEnologos.SelectedItem.ToString()))
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
        protected void ButtonInserirCasta_Click(object sender, EventArgs e)
        {
            if (ButtonInserirCasta.Text.Contains("Associar Casta"))
            {
                associar = true;
            }
            else
            {
                igual = true;
            }

            if (ListBoxCastas.Items.Count >= 1)
            {
                casta = true;
                confirmarSeNaoExiste();
            }
            else if (ButtonInserirCasta.Text.Contains("Associar Casta"))
            {
                ListBoxCastas.Items.Add(DropDownListCastas.SelectedItem);
                db.usp_AssociarCastas((int)ViewState["idvs"], DropDownListCastas.SelectedValue.ToString());
            }
            else
            {
                ListBoxCastas.Items.Add(DropDownListCastas.SelectedItem);
                listaCastasAssociadas.Add(DropDownListCastas.SelectedValue.ToString());
                ViewState["castasAssociar"] = listaCastasAssociadas;
            }
        }

        string listarCastas()
        {
            listaCastasAssociadas = (List<string>)ViewState["castasAssociar"];
            int contagem = listaCastasAssociadas.Count;

            foreach (var item in listaCastasAssociadas)
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

        protected void ButtonEliminarCasta_Click(object sender, EventArgs e)
        {
            if (ListBoxCastas.SelectedIndex >= 0)
            {
                if (ButtonEliminarCasta.Text.Contains("Dissociar Casta"))
                {
                    MetodosVinhoCastas.dissociarCastas((int)ViewState["idvs"], ListBoxCastas.SelectedValue.ToString());
                    ListBoxCastas.Items.Remove(ListBoxCastas.SelectedItem);
                }
                else
                {
                    ListBoxCastas.Items.Remove(ListBoxCastas.SelectedItem);
                    listaCastasAssociadas.Remove(DropDownListCastas.SelectedValue.ToString());
                    ViewState["castasAssociar"] = listaCastasAssociadas;
                }

            }
        }

        // ENOLOGOS
        protected void ButtonInserirEnologo_Click(object sender, EventArgs e)
        {
            if (ButtonInserirEnologo.Text.Contains("Associar Enologo"))
            {
                associar = true;
            }
            else
            {
                igual = true;
            }
            if (ListBoxEnologos.Items.Count >= 1)
            {
                enologo = true;
                confirmarSeNaoExiste();
            }
            else if (ButtonInserirEnologo.Text.Contains("Associar Enologo"))
            {
                ListBoxEnologos.Items.Add(DropDownListEnologos.SelectedItem);
                db.usp_AssociarEnologo((int)ViewState["idvs"], DropDownListEnologos.SelectedValue.ToString());
            }
            else
            {
                ListBoxEnologos.Items.Add(DropDownListEnologos.SelectedItem);
                listaEnologosAssociados.Add(DropDownListEnologos.SelectedValue.ToString());
                ViewState["enologosAssociar"] = listaEnologosAssociados;
            }

        }

        string listarEnologos()
        {
            listaEnologosAssociados = (List<string>)ViewState["enologosAssociar"];
            int contagem = listaEnologosAssociados.Count;
            foreach (var item in listaEnologosAssociados)
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

        protected void ButtonEliminarEnologo_Click(object sender, EventArgs e)
        {
            if (ListBoxEnologos.SelectedIndex >= 0)
            {
                if (ButtonEliminarEnologo.Text.Contains("Dissociar Enologo"))
                {
                    MetodosVinhoEnologos.dissociarEnologos((int)ViewState["idvs"], ListBoxEnologos.SelectedValue.ToString());
                    ListBoxEnologos.Items.Remove(ListBoxEnologos.SelectedItem);
                }
                else
                {
                    ListBoxEnologos.Items.Remove(ListBoxEnologos.SelectedItem);
                    listaEnologosAssociados.Remove(DropDownListEnologos.SelectedValue.ToString());
                    ViewState["enologosAssociar"] = listaEnologosAssociados;
                }
            }
        }


        #endregion

        //--------------------------------------------------------------\\
        #region INSERIR ALTERAR ELIMINAR
        List<string> listaVinhos = new List<string>();
        List<string> listaCastasPorVinho = new List<string>();

        protected void ButtonInserir_Click(object sender, EventArgs e)
        {
            if(DropDownListProdutor.SelectedValue != "Seleccione o produtor" && DropDownListRegiao.SelectedValue != "Seleccione a região" && DropDownListTipoVinho.SelectedValue != "Seleccione o tipo d´vinho")
            {
                if (ButtonInserir.Text == "Inserir")
                {
                    listaCastas = listarCastas();
                    listaEnologos = listarEnologos();
                    int resCompVinhos = 0;

                    resCompVinhos = MetodosVinhos.compararVinhos(TextBoxNome.Text.ToString(), TextBoxAno.Text.ToString(),
                                                TextBoxVolume.Text.ToString(), TextBoxTeorAlcoolico.Text.ToString(), TextBoxTemperatura.Text.ToString(),
                                                DropDownListRegiao.SelectedValue.ToString(), DropDownListProdutor.SelectedValue.ToString(),
                                                DropDownListTipoVinho.SelectedValue.ToString(), listaCastasAssociadas);

                    if (resCompVinhos == 0)
                    {
                        try
                        {
                            Vinho v = new Vinho();

                            v.Nome = TextBoxNome.Text.ToString();
                            v.Volume = decimal.Parse(TextBoxVolume.Text == "" ? "0" : TextBoxVolume.Text);
                            v.TeorAlcoolico = decimal.Parse(TextBoxTeorAlcoolico.Text == "" ? "0" : TextBoxTeorAlcoolico.Text);
                            v.Temperatura = decimal.Parse(TextBoxTemperatura.Text == "" ? "0" : TextBoxTemperatura.Text);
                            v.Ano = int.Parse(TextBoxAno.Text == "" ? "0" : TextBoxAno.Text);
                            v.Regiao = int.Parse(DropDownListRegiao.SelectedValue);
                            v.Produtor = int.Parse(DropDownListProdutor.SelectedValue);
                            v.TipoVinho = int.Parse(DropDownListTipoVinho.SelectedValue);
                            v.Activo = Funcoes.campoActivo(CheckBoxActivar);

                            if (FileUploadImagem.HasFile)
                            {
                                bool ok = false;
                                string[] ext = { ".jpg", ".png", ".jpeg", "*tiff" };
                                string extensao_ficheiro = System.IO.Path.GetExtension(FileUploadImagem.FileName).ToString();
                                foreach (var item in ext)
                                {
                                    if (item == extensao_ficheiro.ToLower())
                                    {
                                        ok = true;
                                        break;
                                    }
                                }
                                if (ok == true)
                                {
                                    //fazer upload para a pasta imagens
                                    FileUploadImagem.SaveAs(Server.MapPath("~/Imagens/imagensVinhos/" + FileUploadImagem.FileName));
                                    v.Foto = "~/Imagens/imagensVinhos/" + FileUploadImagem.FileName;
                                }
                                else
                                    v.Foto = "";
                            }
                            else
                                v.Foto = "";

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
                            Response.Write("<script>alert('" + "Não foi possivel inserir o vinho" + "');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Este vinho já se encontra registado" + "');</script>");
                    }
                }


                if (ButtonInserir.Text == "Alterar")
                {
                    try
                    {
                        Vinho v = new Vinho();

                        v.Id = (int)ViewState["idvs"];
                        v.Nome = TextBoxNome.Text.ToString();
                        v.Volume = decimal.Parse(TextBoxVolume.Text == "" ? "0" : TextBoxVolume.Text);
                        v.TeorAlcoolico = decimal.Parse(TextBoxTeorAlcoolico.Text == "" ? "0" : TextBoxTeorAlcoolico.Text);
                        v.Temperatura = decimal.Parse(TextBoxTemperatura.Text == "" ? "0" : TextBoxTemperatura.Text);
                        v.Ano = int.Parse(TextBoxAno.Text == "" ? "0" : TextBoxAno.Text);
                        v.Regiao = int.Parse(DropDownListRegiao.SelectedValue);
                        v.Produtor = int.Parse(DropDownListProdutor.SelectedValue);
                        v.TipoVinho = int.Parse(DropDownListTipoVinho.SelectedValue);
                        v.Activo = Funcoes.campoActivo(CheckBoxActivar);

                        string backupFoto = v.Foto;

                        if (FileUploadImagem.HasFile)
                        {
                            bool ok = false;
                            string[] ext = { ".jpg", ".png", ".jpeg", "*tiff" };
                            string extensao_ficheiro = System.IO.Path.GetExtension(FileUploadImagem.FileName).ToString();

                            foreach (var item in ext)
                            {
                                if (item == extensao_ficheiro.ToLower())
                                {
                                    ok = true;
                                    break;
                                }
                            }
                            if (ok == true)
                            {
                                //fazer upload para a pasta imagens
                                FileUploadImagem.SaveAs(Server.MapPath("~/ Imagens / imagensVinhos / " + FileUploadImagem.FileName));
                                v.Foto = "~/Imagens/imagensVinhos/" + FileUploadImagem.FileName;
                            }
                            else
                                v.Foto = backupFoto;
                        }
                        else
                            v.Foto = backupFoto;

                        MetodosVinhos.updateVinhos(v);

                        alterarbtns();

                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('" + "Não foi possivel alterar o vinho" + "');</script>");
                    }
                }

                reset();

            }
            else
            {
                Response.Write("<script>alert('" + "Confirmar se escolheu a Região, o Produtor ou Tipo d'Vinho" + "');</script>");
            }

        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            int confirm = MetodosVinhos.eliminar((int)ViewState["idvs"]);

            if (confirm == 1)
                Response.Write("<script>alert('" + "Não foi possivel ocultar o vinho" + "');</script>");

            reset();
            alterarbtns();

        }

        protected void ButtonEliminarDeVez_Click(object sender, EventArgs e)
        {

            int confirm = MetodosVinhos.eliminar((int)ViewState["idvs"], "no");

            if (confirm == 1)
                Response.Write("<script>alert('" + "Não foi possivel eliminar o vinho" + "');</script>");

            reset();
            alterarbtns();
        }
        #endregion

    }
}