using dbVinhosEFA;
using dbVinhosEFA.Metodos;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebVinhos.Admin
{
    public partial class formRegiao : System.Web.UI.Page
    {
        bool regioesActivo;

        void reset(string limpar = "yes")
        {
            if (limpar == "no") 
                MetodosRegioes.getRegioes(null, GridViewRegioes);
            else
            {
                this.Master.limpar();
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
                Funcoes.checkBoxChanged(CheckBoxActivar);
                MetodosRegioes.getRegioes(null, GridViewRegioes);
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
            {
                MetodosRegioes.getRegioes(null, GridViewRegioes);
            }
        }

        protected void GridViewRegioes_SelectedIndexChanged(object sender, EventArgs e)
        {
            alterarbtns("alterar");

            ViewState["idrs"] = int.Parse(GridViewRegioes.SelectedRow.Cells[1].Text);

            TextBoxNome.Text = GridViewRegioes.SelectedRow.Cells[2].Text == "" ? "" : GridViewRegioes.SelectedRow.Cells[2].Text;
            TextBoxDescricao.Text = GridViewRegioes.SelectedRow.Cells[3].Text == "" ? "" : GridViewRegioes.SelectedRow.Cells[3].Text;

            regioesActivo = Funcoes.valorActivo(GridViewRegioes, 4);

            // se tem ligaçao com Vinhos nao pode mudar Activo para falso
            int r = MetodosVinhos.confirmarComListaVinhos((int)ViewState["idrs"], "regiao");
            if (r != 0)
            {
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
                CheckBoxActivar.Enabled = false;
            }
            else
                Funcoes.mudarCheckBox(CheckBoxActivar, regioesActivo);

        }

        protected void GridViewRegioes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[4].Visible = false;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[2].Text = Server.HtmlDecode(e.Row.Cells[2].Text);
                    e.Row.Cells[3].Text = Server.HtmlDecode(e.Row.Cells[3].Text);

                    bool res = Funcoes.mudarCorValorActivo(e, 4);
                    if (res)
                        e.Row.ForeColor = System.Drawing.Color.Blue;
                    else
                        e.Row.ForeColor = System.Drawing.Color.Red;

                }
            }

        }

        protected void GridViewRegioes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRegioes.PageIndex = e.NewPageIndex;
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
                    int contagem = MetodosRegioes.regioesRepetidas(TextBoxNome.Text.ToString());
                    if (contagem == 0)
                    {
                        Regiao r = new Regiao();
                        r.Nome = TextBoxNome.Text.ToString();
                        r.Descricao = TextBoxDescricao.Text.ToString();
                        r.Activo = Funcoes.campoActivo(CheckBoxActivar);
                        MetodosRegioes.insertRegiao(r);
                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Região repetida" + "');</script>");
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('" + "Não foi possivel inserir a região" + "');</script>");
                }
            }


            if (ButtonInserir.Text == "Alterar")
            {
                try
                {
                    Regiao r = new Regiao();
                    r.Id = (int)ViewState["idrs"];
                    r.Nome = TextBoxNome.Text.ToString();
                    r.Descricao = TextBoxDescricao.Text.ToString();
                    r.Activo = Funcoes.campoActivo(CheckBoxActivar);
                    MetodosRegioes.updateRegiao(r);

                    alterarbtns();
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('" + "Não foi possivel alterar a região" + "');</script>");
                }
            }

            reset();
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            int resposta = MetodosRegioes.eliminar((int)ViewState["idrs"], regioesActivo);

            if (resposta == 1)
                Response.Write("<script>alert('" + "O enologo seleccionado não pode ser ocultado" + "');</script>");
            if (resposta == 2)
                Response.Write("<script>alert('" + "Não foi possivel ocultar a região" + "');</script>");

            reset();

        }

        protected void ButtonEliminarDeVez_Click(object sender, EventArgs e)
        {
            int resposta = MetodosRegioes.eliminar((int)ViewState["idrs"], regioesActivo, "no");

            if (resposta == 1)
                Response.Write("<script>alert('" + "O enologo seleccionado não pode ser eliminado" + "');</script>");
            if (resposta == 2)
                Response.Write("<script>alert('" + "Não foi possivel eliminar a região" + "');</script>");

            reset();
        }
    }
}