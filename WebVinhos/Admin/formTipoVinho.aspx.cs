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
    public partial class formTipoVinho : System.Web.UI.Page
    {
        bool tipoVinhoActivo;

        void reset(string limpar = "sim")
        {      
            if (limpar == "no") 
                MetodosTipoDeVinho.getTipoVinhos(null, GridViewTipoVinhos, null);
            else
            {
                this.Master.limpar();
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
                Funcoes.checkBoxChanged(CheckBoxActivar);
                MetodosTipoDeVinho.getTipoVinhos(null, GridViewTipoVinhos, null);
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
                CheckBoxActivar.Enabled = true;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
                reset();
        }

        protected void GridViewTipoVinhos_SelectedIndexChanged(object sender, EventArgs e)
        {
            alterarbtns("alterar");

            ViewState["idtv"] = int.Parse(GridViewTipoVinhos.SelectedRow.Cells[1].Text);

            TextBoxNome.Text = GridViewTipoVinhos.SelectedRow.Cells[2].Text;

            tipoVinhoActivo = Funcoes.valorActivo(GridViewTipoVinhos, 3);

            // se tem ligacao Castas e Vinhos pode mudar Activo para falso
            int v = MetodosVinhos.confirmarComListaVinhos((int)ViewState["idtv"], "tipoVinho");
            int c = MetodosCastas.castasRepetidas(GridViewTipoVinhos.SelectedRow.Cells[1].Text, "tipoVinho");
            if (v != 0 && c != 0)
            {
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
                CheckBoxActivar.Enabled = false;
            }
            Funcoes.mudarCheckBox(CheckBoxActivar, tipoVinhoActivo);
            
        }

        protected void GridViewTipoVinhos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false; // id tipo vinho
                e.Row.Cells[3].Visible = false; // activo tipo vinho

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[2].Text = Server.HtmlDecode(e.Row.Cells[2].Text);

                    bool res = Funcoes.mudarCorValorActivo(e, 3);
                    if (res)
                        e.Row.ForeColor = System.Drawing.Color.Blue;
                    else
                        e.Row.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void GridViewTipoVinhos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTipoVinhos.PageIndex = e.NewPageIndex;
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
                    int contagem = MetodosTipoDeVinho.tipoVinhosRepetidos(TextBoxNome.Text.ToString(), out int id);

                    if (contagem == 0)
                    {
                        TipoVinho tv = new TipoVinho();
                        tv.Nome = TextBoxNome.Text.ToString();
                        tv.Activo = Funcoes.campoActivo(CheckBoxActivar);
                        MetodosTipoDeVinho.insertTipoDeVinho(tv);
                    }
                    else
                    Response.Write("<script>alert('" + "Tipo de Vinho repetido" + "');</script>");

                }
                catch (Exception)
                {
                    Response.Write("<script>alert('" + "Não foi possivel inserir o Tipo de Vinho" + "');</script>");
                }
            }

            if (ButtonInserir.Text == "Alterar")
            {
                try
                {
                    TipoVinho tv = new TipoVinho();

                    tv.Id = (int)ViewState["idtv"];
                    tv.Nome = TextBoxNome.Text.ToString();
                    tv.Activo = Funcoes.campoActivo(CheckBoxActivar);
                    MetodosTipoDeVinho.updateTipoDeVinho(tv);

                    alterarbtns();

                }
                catch (Exception)
                {
                    Response.Write("<script>alert('" + "Não foi possivel alterar o Tipo de Vinho" + "');</script>");
                }
            }

            reset(); 
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            int resposta = MetodosTipoDeVinho.eliminar((int)ViewState["idtv"], tipoVinhoActivo);

            if(resposta == 1)
                Response.Write("<script>alert('" + "O Tipo de Vinho seleccionado não pode ser ocultado" + "');</script>");
            if (resposta == 2)
                Response.Write("<script>alert('" + "Não foi possivel ocultar o Tipo de Vinho" + "');</script>");

            reset();

        }

        protected void ButtonEliminarDeVez_Click(object sender, EventArgs e)
        {
            int resposta = MetodosTipoDeVinho.eliminar((int)ViewState["idtv"], tipoVinhoActivo, "no");

            if (resposta == 1)
                Response.Write("<script>alert('" + "O Tipo de Vinho seleccionado não pode ser eliminado" + "');</script>");
            if (resposta == 2)
                Response.Write("<script>alert('" + "Não foi possivel eliminar o Tipo de Vinho" + "');</script>");

            reset();
            
        }
    }
}