using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dbVinhosEFA.Metodos;
using dbVinhosEFA;

namespace WebVinhos.Admin
{
    public partial class formCastas : System.Web.UI.Page
    {
        bool castasActivo, castasTipoVinhoActivo;

        void reset(string limpar = "sim")
        {
            if (limpar == "no")
            {
                MetodosCastas.getCastas(null, GridViewCastas);
                MetodosTipoDeVinho.getTipoVinhos(null, null, DropDownListTipoVinho);
            }
            else
            {
                this.Master.limpar();
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
                Funcoes.checkBoxChanged(CheckBoxActivar);
                MetodosCastas.getCastas(null, GridViewCastas);
                MetodosTipoDeVinho.getTipoVinhos(null, null, DropDownListTipoVinho);
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

        // PAGE CONTROLS
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
                reset();
        }

        protected void GridViewCastas_SelectedIndexChanged1(object sender, EventArgs e)
        {
            alterarbtns("alterar");

            ViewState["idcs"] = int.Parse(GridViewCastas.SelectedRow.Cells[1].Text);

            TextBoxNome.Text = GridViewCastas.SelectedRow.Cells[2].Text;
            TextBoxCaracteristica.Text = GridViewCastas.SelectedRow.Cells[3].Text;

            DropDownListTipoVinho.SelectedValue = GridViewCastas.SelectedRow.Cells[4].Text;

            castasActivo = Funcoes.valorActivo(GridViewCastas, 6);
            castasTipoVinhoActivo = Funcoes.valorActivo(GridViewCastas, 7);

            if (castasTipoVinhoActivo == true)
            {
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
                CheckBoxActivar.Enabled = false;
            }
            else
                Funcoes.mudarCheckBox(CheckBoxActivar, castasActivo);
        }

        protected void GridViewCastas_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false; // id casta
                e.Row.Cells[4].Visible = false; // id tipo vinho
                e.Row.Cells[6].Visible = false; // activo casta
                e.Row.Cells[7].Visible = false; // activo tipo vinho

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[2].Text = Server.HtmlDecode(e.Row.Cells[2].Text);
                    e.Row.Cells[3].Text = Server.HtmlDecode(e.Row.Cells[3].Text);
                    e.Row.Cells[5].Text = Server.HtmlDecode(e.Row.Cells[5].Text);

                    bool resC = Funcoes.mudarCorValorActivo(e, 6);
                    bool resTV = Funcoes.mudarCorValorActivo(e, 7);

                    if (resC && resTV)
                        e.Row.ForeColor = System.Drawing.Color.Blue;
                    else if (resC is false && resTV is false)
                        e.Row.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void GridViewCastas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCastas.PageIndex = e.NewPageIndex;
            reset("no");
        }

        protected void CheckBoxActivar_CheckedChanged(object sender, EventArgs e)
        {
            Funcoes.checkBoxChanged(CheckBoxActivar);
        }


        // CRUD
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
                    int contagem = MetodosCastas.castasRepetidas(TextBoxNome.Text.ToString());
                    if (contagem == 0)
                    {

                        Casta ca = new Casta();

                        ca.Nome = TextBoxNome.Text.ToString();
                        ca.Caracteristicas = TextBoxCaracteristica.Text.ToString();
                        ca.TipoVinho = int.Parse(DropDownListTipoVinho.SelectedValue);
                        ca.Activo = Funcoes.campoActivo(CheckBoxActivar);
                        MetodosCastas.insertCastas(ca);
                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Casta repetida" + "');</script>");
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('" + "Não foi possivel inserir a casta" + "');</script>");
                }
            }

            if (ButtonInserir.Text == "Alterar")
            {
                try
                {
                    Casta ca = new Casta();
                    ca.Id = (int)ViewState["idcs"];
                    ca.Nome = TextBoxNome.Text.ToString();
                    ca.Caracteristicas = TextBoxCaracteristica.Text.ToString();
                    ca.TipoVinho = int.Parse(DropDownListTipoVinho.SelectedValue);
                    ca.Activo = Funcoes.campoActivo(CheckBoxActivar);

                    MetodosCastas.updateCastas(ca);

                    alterarbtns();
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('" + "Não foi possivel alterar a casta" + "');</script>");
                }
            }

            reset();
        }

        protected void ButtonEliminar_Click1(object sender, EventArgs e)
        {
            int resposta = MetodosCastas.eliminar((int)ViewState["idcs"], castasActivo);

            if (resposta == 1)
                Response.Write("<script>alert('" + "A casta seleccionado não pode ser ocultado" + "');</script>");
            if (resposta == 2)
                Response.Write("<script>alert('" + "Não foi possivel ocultar a casta" + "');</script>");

            reset();
        }

        protected void ButtonEliminarDeVez_Click(object sender, EventArgs e)
        {
            int resposta = MetodosCastas.eliminar((int)ViewState["idcs"], castasActivo, "no");

            if (resposta == 1)
                Response.Write("<script>alert('" + "A casta seleccionado não pode ser eliminado" + "');</script>");
            if (resposta == 2)
                Response.Write("<script>alert('" + "Não foi possivel eliminar a casta" + "');</script>");

            reset();
        }


        // NOVO TIPO DE VINHO
        protected void LinkButtonNovoTipoVinho_Click(object sender, EventArgs e)
        {
            TextBoxNovoTipoVinho.Visible = true;
            ButtonNovoTipoVinho.Visible = true;
        }
        protected void ButtonNovoTipoVinho_Click(object sender, EventArgs e)
        {
            try
            {
                int contagem = MetodosTipoDeVinho.tipoVinhosRepetidos(TextBoxNovoTipoVinho.Text.ToString(), out int id);

                if (contagem == 0)
                {
                    TipoVinho tv = new TipoVinho();
                    tv.Nome = TextBoxNovoTipoVinho.Text.ToString();
                    tv.Activo = true;
                    MetodosTipoDeVinho.insertTipoDeVinho(tv);
                }
                else
                    Response.Write("<script>alert('" + "Tipo de Vinho repetido" + "');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('" + "Não foi possivel inserir o Tipo de Vinho" + "');</script>");
            }

            MetodosTipoDeVinho.getTipoVinhos(null, null, DropDownListTipoVinho);
            int busacarId = MetodosTipoDeVinho.tipoVinhosRepetidos(TextBoxNovoTipoVinho.Text.ToString(), out int idV);
            int idVinho = idV;
            DropDownListTipoVinho.SelectedValue = idVinho.ToString();
            TextBoxNovoTipoVinho.Text = "";
        }

    }
}
