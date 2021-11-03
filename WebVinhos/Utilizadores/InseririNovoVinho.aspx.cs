using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dbVinhosEFA;
using dbVinhosEFA.Metodos;

namespace WebVinhos.Utilizadores
{
    public partial class InseririNovoVinho : System.Web.UI.Page
    {

        static VinhosEFAEntities db = new VinhosEFAEntities();

        List<VinhoCasta> castasAdicionar = new List<VinhoCasta>();
        List<VinhoEnologo> enologosAdicionar = new List<VinhoEnologo>();

        void visibleEscolhidos(bool TorF, string op = "castas")
        {
            if (op.Equals("castas"))
            {
                LabelCastasEscolhidas.Visible = TorF;
                ButtonRemoverCasta.Visible = TorF;
            }
            else
            {
                LabelEnologosEscolhidos.Visible = TorF;
                ButtonRemoverEnologo.Visible = TorF;
            }
        }

        void getCastas_Enologos()
        {
            List<Casta> ca = (from c in db.Castas orderby c.Nome select c).ToList();
            ViewState["castas"] = ca;

            List<Enologo> en = (from eno in db.Enologoes orderby eno.Nome select eno).ToList();
            ViewState["enologos"] = en;
        }

        void preencherDropDown()
        {
            //DROPDOWN REGIOES
            MetodosVinhos.dropDownListRegioesShow(DropDownListRegiao);

            ////DROPDOWN PRODUTORES
            MetodosVinhos.dropDownListProdutoresShow(DropDownListProdutor);

            ////DROPDOWN TIPOS DE VINHOS
            MetodosVinhos.dropDownListTipoVinhosShow(DropDownListTiposVinho);
        }

        void preencherCampos(int id)
        {
            var listaVinhos = db.Vinhoes.Where(vi => vi.Id == id).Select(vi => new
            {
                vi.Id,
                vi.Nome,
                vi.Ano,
                vi.Volume,
                vi.Temperatura,
                vi.Regiao,
                vi.TeorAlcoolico,
                vi.Produtor,
                vi.TipoVinho
            });

            foreach (var item in listaVinhos)
            {
                TextBoxNome.Text = item.Nome;
                TextBoxAno.Text = item.Ano.ToString();
                TextBoxVolume.Text = item.Volume.ToString();
                TextBoxTeorAlcoolico.Text = item.TeorAlcoolico.ToString();
                TextBoxTemperatura.Text = item.Temperatura.ToString();
                DropDownListRegiao.SelectedValue = item.Regiao.ToString();
                DropDownListProdutor.SelectedValue = item.Produtor.ToString();
                DropDownListTiposVinho.SelectedValue = item.TipoVinho.ToString();
            }

            List<VinhoCasta> vc = (from c in db.VinhoCastas select c).ToList();


            foreach (var itemC in vc)
            {
                if (itemC.Vinho == id)
                    castasAdicionar.Add(itemC);
            }
            ViewState["castasAdicionar"] = castasAdicionar;

            List<VinhoEnologo> ven = (from eno in db.VinhoEnologoes select eno).ToList();

            foreach (var itemE in ven)
            {
                if (itemE.Vinho == id)
                    enologosAdicionar.Add(itemE);
            }
            ViewState["enologosAdicionar"] = enologosAdicionar;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["castasAdicionar"] != null)
                castasAdicionar = (List<VinhoCasta>)ViewState["castasAdicionar"];

            if (ViewState["enologosAdicionar"] != null)
                enologosAdicionar = (List<VinhoEnologo>)ViewState["enologosAdicionar"];

            if (!IsPostBack)
            {
                RangeValidatorAno.MaximumValue = DateTime.Now.Year.ToString();

                if (Session["oQue"] != null)
                {
                    if (Session["oQue"].ToString() == "Inserir")
                    {
                        LabelVinhos.Text = "Inserir Vinho";
                        ButtonInserir.Text = "Inserir";
                    }
                    if (Session["oQue"].ToString() == "editar")
                    {
                        LabelVinhos.Text = "Editar Vinho";
                        ButtonInserir.Text = "Alterar";
                    }
                    if (Session["oQue"].ToString() == "eliminar")
                    {
                        LabelVinhos.Text = "Eliminar Vinho";
                        ButtonInserir.Text = "Eliminar";
                    }
                }

                getCastas_Enologos();

                if (Session["id_vinho"] != null)
                {
                    int id = int.Parse(Session["id_vinho"].ToString());
                    if (id == 0)
                    {
                        //criar novas lista:
                        castasAdicionar = new List<VinhoCasta>();
                        enologosAdicionar = new List<VinhoEnologo>();
                    }
                    else
                    {
                        preencherCampos(id);
                    }
                }
                preencherGridViewsCastas();
                preencherGridViewsEnologos();
                preencherDropDown();

                if (castasAdicionar.Count == 0)
                    visibleEscolhidos(false);
                else
                    visibleEscolhidos(true);

                if (enologosAdicionar.Count == 0)
                    visibleEscolhidos(false, "enologo");
                else
                    visibleEscolhidos(true, "enologo");

            }

        }

        // CASTAS
        protected void ButtonAssociarCasta_Click(object sender, EventArgs e)
        {

            if (GridViewCastasDisponiveis.SelectedRow != null)
            {
                visibleEscolhidos(true);

                castasAdicionar = (List<VinhoCasta>)ViewState["castasAdicionar"];
                if (castasAdicionar == null)
                    castasAdicionar = new List<VinhoCasta>();

                int id = int.Parse(GridViewCastasDisponiveis.SelectedRow.Cells[1].Text);
                castasAdicionar.Add(new VinhoCasta() { Casta = id });
                preencherGridViewsCastas();
                ViewState["castasAdicionar"] = castasAdicionar;

                if (Session["oQue"].ToString() == "editar")
                {
                    db.usp_AssociarCastas(int.Parse(Session["id_vinho"].ToString()), id.ToString());
                }
            }
        }

        protected void ButtonRemoverCasta_Click(object sender, EventArgs e)
        {
            if (ViewState["castasAdicionar"] != null)
            {
                castasAdicionar = (List<VinhoCasta>)ViewState["castasAdicionar"];

                int castaSelected = int.Parse(GridViewCastasEscolhidas.SelectedRow.Cells[1].Text);

                castasAdicionar.RemoveAll(ca => ca.Casta == castaSelected);
                GridViewCastasEscolhidas.SelectedIndex = -1;
                preencherGridViewsCastas();

                ViewState["castasAdicionar"] = castasAdicionar;
                if (castasAdicionar.Count == 0)
                {
                    visibleEscolhidos(false);
                }

                if (Session["oQue"].ToString() == "editar")
                {
                    db.usp_DissociarCastas(int.Parse(Session["id_vinho"].ToString()), castaSelected.ToString());
                }
            }

        }

        void preencherGridViewsCastas()
        {
            List<Casta> castas = (List<Casta>)ViewState["castas"];

            if (castasAdicionar.Count > 0)
            {
                // c.Casta é o id escolhido pelo user
                var idCastaSelected = castasAdicionar.Select(c => c.Casta).ToList();
                // retirar a casta escolhida
                var ca = from c in db.Castas
                         where !(idCastaSelected.Contains(c.Id))
                         select new { c.Id, c.Nome, c.Caracteristicas, c.TipoVinho, c.Activo };

                GridViewCastasDisponiveis.DataSource = ca.ToList();
                GridViewCastasDisponiveis.DataBind();

                var castasEscolhidas = from c in castas
                                       from id in idCastaSelected
                                       where c.Id == id
                                       orderby c.Nome
                                       select new
                                       {
                                           c.Id,
                                           c.Nome,
                                           c.Caracteristicas
                                       };

                GridViewCastasEscolhidas.DataSource = castasEscolhidas.ToList();
                GridViewCastasEscolhidas.DataBind();
            }
            else
            {
                var ca = from c in db.Castas
                         select new { c.Id, c.Nome, c.Caracteristicas, c.TipoVinho, c.Activo };

                GridViewCastasDisponiveis.DataSource = ca.ToList();
                GridViewCastasDisponiveis.DataBind();
                GridViewCastasEscolhidas.DataSource = null;
                GridViewCastasEscolhidas.DataBind();
            }
        }

        protected void GridViewCastasDisponiveis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false; // id casta
                e.Row.Cells[4].Visible = false; // id tipo vinho
                e.Row.Cells[5].Visible = false; // activo casta

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[2].Text = Server.HtmlDecode(e.Row.Cells[2].Text); // nome casta
                    e.Row.Cells[3].Text = Server.HtmlDecode(e.Row.Cells[3].Text); // caracteristicas

                }
            }
        }

        protected void GridViewCastasEscolhidas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false; // id casta

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[2].Text = Server.HtmlDecode(e.Row.Cells[2].Text); // nome casta
                    e.Row.Cells[3].Text = Server.HtmlDecode(e.Row.Cells[3].Text); // caracteristicas
                }
            }
        }

        // ENOLOGO
        protected void ButtonAssociarEnologo_Click(object sender, EventArgs e)
        {

            if (GridViewEnologosDisponiveis.SelectedRow != null)
            {
                visibleEscolhidos(true, "enologo");

                enologosAdicionar = (List<VinhoEnologo>)ViewState["enologosAdicionar"];
                if (enologosAdicionar == null)
                    enologosAdicionar = new List<VinhoEnologo>();

                int id = int.Parse(GridViewEnologosDisponiveis.SelectedRow.Cells[1].Text);
                enologosAdicionar.Add(new VinhoEnologo() { Enologo = id });
                preencherGridViewsEnologos();
                ViewState["enologosAdicionar"] = enologosAdicionar;

                if (Session["oQue"].ToString() == "editar")
                {
                    db.usp_AssociarEnologo(int.Parse(Session["id_vinho"].ToString()), id.ToString());
                }

            }
        }

        protected void ButtonRemoverEnologo_Click(object sender, EventArgs e)
        {
            if (ViewState["enologosAdicionar"] != null)
            {
                enologosAdicionar = (List<VinhoEnologo>)ViewState["enologosAdicionar"];

                int enologoSelected = int.Parse(GridViewEnologosEscolhidos.SelectedRow.Cells[1].Text);

                enologosAdicionar.RemoveAll(en => en.Enologo == enologoSelected);
                GridViewEnologosEscolhidos.SelectedIndex = -1;

                preencherGridViewsEnologos();
                ViewState["enologosAdicionar"] = enologosAdicionar;

                if (enologosAdicionar.Count == 0)
                {
                    visibleEscolhidos(false, "enologo");
                }

                if (Session["oQue"].ToString() == "editar")
                {
                    db.usp_DissociarEnologo(int.Parse(Session["id_vinho"].ToString()), enologoSelected.ToString());
                }
            }

        }

        void preencherGridViewsEnologos()
        {
            List<Enologo> enologos = (List<Enologo>)ViewState["enologos"];

            if (castasAdicionar.Count > 0)
            {
                // en.Enologo é o id escolhido pelo user
                var idEnologoSelected = enologosAdicionar.Select(en => en.Enologo).ToList();
                // retirar o enologo escolhida
                var eno = from en in db.Enologoes
                          where !(idEnologoSelected.Contains(en.Id))
                          select new { en.Id, en.Nome, en.Instragram, en.Activo };

                GridViewEnologosDisponiveis.DataSource = eno.ToList();
                GridViewEnologosDisponiveis.DataBind();

                var enologosEscolhidos = from en in enologos
                                         from id in idEnologoSelected
                                         where en.Id == id
                                         orderby en.Nome
                                         select new
                                         {
                                             en.Id,
                                             en.Nome
                                         };

                GridViewEnologosEscolhidos.DataSource = enologosEscolhidos.ToList();
                GridViewEnologosEscolhidos.DataBind();
            }
            else
            {
                var eno = from en in db.Enologoes
                          select new { en.Id, en.Nome, en.Instragram, en.Activo };

                GridViewEnologosDisponiveis.DataSource = eno.ToList();
                GridViewEnologosDisponiveis.DataBind();
                GridViewEnologosEscolhidos.DataSource = null;
                GridViewEnologosEscolhidos.DataBind();
            }

        }

        protected void GridViewEnologosDisponiveis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false; // id enologo
                e.Row.Cells[3].Visible = false; // insta
                e.Row.Cells[4].Visible = false; // activo enologo

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[2].Text = Server.HtmlDecode(e.Row.Cells[2].Text); // nome enologo
                }
            }
        }

        protected void GridViewEnologosEscolhidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false; // id enologo

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[2].Text = Server.HtmlDecode(e.Row.Cells[2].Text); // nome enologo
                }
            }
        }


        // INSERIR ALTERAR ELIMINAR
        protected void ButtonInserir_Click(object sender, EventArgs e)
        {
            if (DropDownListProdutor.SelectedValue != "Seleccione o produtor" && DropDownListRegiao.SelectedValue != "Seleccione a região" && DropDownListTiposVinho.SelectedValue != "Seleccione o tipo d´vinho")
            {

                if (ButtonInserir.Text == "Inserir")
                {
                    List<string> listaCastasAssociadas = new List<string>();
                    foreach (var itemC in castasAdicionar)
                    {
                        listaCastasAssociadas.Add(itemC.Casta.ToString());
                    }

                    int resCompVinhos = 0;
                    resCompVinhos = MetodosVinhos.compararVinhos(TextBoxNome.Text.ToString(), TextBoxAno.Text.ToString(),
                                                       TextBoxVolume.Text.ToString(), TextBoxTeorAlcoolico.Text.ToString(), TextBoxTemperatura.Text.ToString(),
                                                       DropDownListRegiao.SelectedValue.ToString(), DropDownListProdutor.SelectedValue.ToString(),
                                                       DropDownListTiposVinho.SelectedValue.ToString(), listaCastasAssociadas);

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
                            v.TipoVinho = int.Parse(DropDownListTiposVinho.SelectedValue);
                            v.Activo = Funcoes.campoActivo(CheckBoxActivar);
                            v.Utilizador = int.Parse(Session["id_utilizador"].ToString());

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


                            foreach (var itemC in castasAdicionar)
                            {
                                v.VinhoCastas.Add(itemC);
                            }

                            foreach (var itemE in enologosAdicionar)
                            {
                                v.VinhoEnologoes.Add(itemE);
                            }

                            MetodosVinhos.insertVinhos(v);
                            Response.Redirect("MeusVinhos.aspx");

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

                        v.Id = int.Parse(Session["id_vinho"].ToString());
                        v.Nome = TextBoxNome.Text.ToString();
                        v.Volume = decimal.Parse(TextBoxVolume.Text == "" ? "0" : TextBoxVolume.Text);
                        v.TeorAlcoolico = decimal.Parse(TextBoxTeorAlcoolico.Text == "" ? "0" : TextBoxTeorAlcoolico.Text);
                        v.Temperatura = decimal.Parse(TextBoxTemperatura.Text == "" ? "0" : TextBoxTemperatura.Text);
                        v.Ano = int.Parse(TextBoxAno.Text == "" ? "0" : TextBoxAno.Text);
                        v.Regiao = int.Parse(DropDownListRegiao.SelectedValue);
                        v.Produtor = int.Parse(DropDownListProdutor.SelectedValue);
                        v.TipoVinho = int.Parse(DropDownListTiposVinho.SelectedValue);
                        v.Utilizador = int.Parse(Session["id_utilizador"].ToString());
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
                        Response.Redirect("MeusVinhos.aspx");

                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('" + "Não foi possivel alterar o vinho" + "');</script>");
                    }
                }

                if (ButtonInserir.Text == "Eliminar")
                {
                    int confirm = MetodosVinhos.eliminar(int.Parse(Session["id_vinho"].ToString()));

                    if (confirm == 1)
                        Response.Write("<script>alert('" + "Não foi possivel eliminar o vinho" + "');</script>");

                    Response.Redirect("MeusVinhos.aspx");
                }

            }
            else
            {
                Response.Write("<script>alert('" + "Confirmar se escolheu a Região, o Produtor ou Tipo d'Vinho" + "');</script>");
            }
        }

        protected void CheckBoxActivar_CheckedChanged(object sender, EventArgs e)
        {
            Funcoes.checkBoxChanged(CheckBoxActivar);
        }
    }
}

