using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using dbVinhosEFA;
using dbVinhosEFA.Metodos;

namespace WebVinhos.Admin
{
    public partial class formProdutos : System.Web.UI.Page
    {
        bool produtoresActivo;

        void reset(string limpar = "sim")
        {
            if (limpar == "no")
            {
                MetodosProdutores.getProdutores(null, GridViewProdutores);
            }
            else
            {
                this.Master.limpar();
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
                Funcoes.checkBoxChanged(CheckBoxActivar);
                MetodosProdutores.getProdutores(null, GridViewProdutores);
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
            }
            else
            {
                ButtonInserir.Text = "Alterar";
                ButtonEliminar.Visible = true;
                ButtonEliminarDeVez.Visible = true;
                LinkButtonInserir.Visible = true;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
                reset();
        }

        protected void GridViewProdutores_SelectedIndexChanged(object sender, EventArgs e)
        {
            alterarbtns("btnAlterar");

            ViewState["idps"] = int.Parse(GridViewProdutores.SelectedRow.Cells[1].Text);

            TextBoxNome.Text = GridViewProdutores.SelectedRow.Cells[2].Text;
            TextBoxMorada.Text = GridViewProdutores.SelectedRow.Cells[3].Text;
            TextBoxCodigoPosta.Text = GridViewProdutores.SelectedRow.Cells[4].Text;
            TextBoxLocalidade.Text = GridViewProdutores.SelectedRow.Cells[5].Text;
            TextBoxTelefone.Text = GridViewProdutores.SelectedRow.Cells[6].Text;
            TextBoxEmail.Text = GridViewProdutores.SelectedRow.Cells[7].Text;

            produtoresActivo = Funcoes.valorActivo(GridViewProdutores, 8);

            // se tem ligaçao com Vinhos nao pode mudar Activo para falso
            int p = MetodosVinhos.confirmarComListaVinhos((int)ViewState["idps"], "prod");
            ViewState["confirm"] = p;
            if (p != 0)
            {
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
                CheckBoxActivar.Enabled = false;
            }
            else
                Funcoes.mudarCheckBox(CheckBoxActivar, produtoresActivo);

        }

        protected void GridViewProdutores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false; // id 
                e.Row.Cells[8].Visible = false; // activo 

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[2].Text = Server.HtmlDecode(e.Row.Cells[2].Text);
                    e.Row.Cells[3].Text = Server.HtmlDecode(e.Row.Cells[3].Text);
                    e.Row.Cells[4].Text = Server.HtmlDecode(e.Row.Cells[4].Text);
                    e.Row.Cells[5].Text = Server.HtmlDecode(e.Row.Cells[5].Text);
                    e.Row.Cells[6].Text = Server.HtmlDecode(e.Row.Cells[6].Text);
                    e.Row.Cells[7].Text = Server.HtmlDecode(e.Row.Cells[7].Text);

                    bool res = Funcoes.mudarCorValorActivo(e, 8);
                    if (res)
                        e.Row.ForeColor = System.Drawing.Color.Blue;
                    else
                        e.Row.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void GridViewProdutores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProdutores.PageIndex = e.NewPageIndex;
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

        protected void ButtonInserir_Click(object sender, EventArgs e)
        {
            if (ButtonInserir.Text == "Inserir")
            {
                try
                {
                    int contagem = MetodosProdutores.produtoresRepetidos(TextBoxNome.Text.ToString());
                    if(contagem == 0)
                    {
                        Produtor p = new Produtor();
                        p.Nome = TextBoxNome.Text.ToString();
                        p.Morada = TextBoxMorada.Text.ToString();
                        p.CodigoPostal = TextBoxCodigoPosta.Text.ToString();
                        p.Localidade = TextBoxLocalidade.Text.ToString();
                        p.Telefone = TextBoxTelefone.Text.ToString();
                        p.Email = TextBoxEmail.Text.ToString();
                        p.Activo = Funcoes.campoActivo(CheckBoxActivar);
                        p.URL = TextBoxURL.Text;
                        MetodosProdutores.insertProdutor(p);
                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Nome do Produtor repetido" + "');</script>");
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('" + "Não foi possivel inserir o produtor" + "');</script>");
                }
            }

            if (ButtonInserir.Text == "Alterar")
            {
                try
                {
                    Produtor p = new Produtor();
                    p.Id = (int)ViewState["idps"];
                    p.Nome = TextBoxNome.Text.ToString();
                    p.Morada = TextBoxMorada.Text.ToString();
                    p.CodigoPostal = TextBoxCodigoPosta.Text.ToString();
                    p.Localidade = TextBoxLocalidade.Text.ToString();
                    p.Telefone = TextBoxTelefone.Text.ToString();
                    p.Email = TextBoxEmail.Text.ToString();
                    p.Activo = Funcoes.campoActivo(CheckBoxActivar);
                    p.URL = TextBoxURL.Text;
                    MetodosProdutores.updateProdutor(p);

                    alterarbtns();
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('" + "Não foi possivel alterar o produtor" + "');</script>");
                }
            }

            reset();
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            int confirm = MetodosProdutores.eliminar((int)ViewState["idps"], produtoresActivo, (int)ViewState["confirm"]);

            if (confirm == 1)
                Response.Write("<script>alert('" + "O produtor seleccionado não pode ser ocultado" + "');</script>");
            if (confirm == 2)
                Response.Write("<script>alert('" + "Não foi possivel ocultar o produtor" + "');</script>");

            reset();
        }

        protected void ButtonEliminarDeVez_Click(object sender, EventArgs e)
        {
            int confirm = MetodosProdutores.eliminar((int)ViewState["idps"], produtoresActivo, (int)ViewState["confirm"], "no");

            if (confirm == 1)
                Response.Write("<script>alert('" + "O produtor seleccionado não pode ser eliminar" + "');</script>");
            if (confirm == 2)
                Response.Write("<script>alert('" + "Não foi possivel eliminar o produtor" + "');</script>");

            reset();
        }

    }
}