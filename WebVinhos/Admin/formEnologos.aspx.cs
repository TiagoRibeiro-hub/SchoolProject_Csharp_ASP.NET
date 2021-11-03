using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dbVinhosEFA;
using dbVinhosEFA.Metodos;

namespace WebVinhos.Admin
{
    public partial class formEnologos : System.Web.UI.Page
    {
        bool enologosActivo;
        void reset(string limpar = "sim")
        {
            if (limpar == "no")
            {
                MetodosEnologo.getEnologos(null, GridViewEnologos);
            }
            else
            {
                this.Master.limpar();
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
                Funcoes.checkBoxChanged(CheckBoxActivar);
                MetodosEnologo.getEnologos(null, GridViewEnologos);
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

        protected void GridViewEnologos_SelectedIndexChanged(object sender, EventArgs e)
        {
            alterarbtns("alterar");

            ViewState["ides"] = int.Parse(GridViewEnologos.SelectedRow.Cells[1].Text);

            TextBoxNome.Text = GridViewEnologos.SelectedRow.Cells[2].Text;
            TextBoxInstagram.Text = GridViewEnologos.SelectedRow.Cells[3].Text;

            enologosActivo = Funcoes.valorActivo(GridViewEnologos, 4);

            // se tem ligaçao com vinhoEnologos nao pode mudar Activo para falso
            int ve = MetodosVinhoEnologos.vinhoEnologosLista((int)ViewState["ides"]);
            if (ve != 0)
            {
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
                CheckBoxActivar.Enabled = false;
            }
            else
                Funcoes.mudarCheckBox(CheckBoxActivar, enologosActivo);

        }

        protected void GridViewEnologos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false; // id enologo
                e.Row.Cells[4].Visible = false; // activo enologo

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

        protected void GridViewEnologos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEnologos.PageIndex = e.NewPageIndex;
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
                    int contagem = MetodosEnologo.enologosRepetidos(TextBoxNome.Text.ToString());

                    if (contagem == 0)
                    {
                        Enologo en = new Enologo();
                        en.Nome = TextBoxNome.Text;
                        en.Instragram = TextBoxInstagram.Text;
                        en.Activo = Funcoes.campoActivo(CheckBoxActivar);

                        MetodosEnologo.insertEnologo(en);
                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Enologo repetida" + "');</script>");
                    }
                }
                catch
                {
                    Response.Write("<script>alert('" + "Não foi possivel inserir o enologo" + "');</script>");
                }
            }

            if (ButtonInserir.Text == "Alterar")
            {
                try
                {

                    Enologo en = new Enologo();
                    en.Id = (int)ViewState["ides"];
                    en.Nome = TextBoxNome.Text;
                    en.Instragram = TextBoxInstagram.Text;
                    en.Activo = Funcoes.campoActivo(CheckBoxActivar);

                    MetodosEnologo.updateEnologo(en);

                    alterarbtns();

                }
                catch (Exception)
                {
                    Response.Write("<script>alert('" + "Não foi possivel alterar o enologo" + "');</script>");
                }
            }

            reset();

        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            int confirm = MetodosEnologo.eliminar((int)ViewState["ides"], enologosActivo);

            if (confirm == 1)
                Response.Write("<script>alert('" + "O enologo seleccionado não pode ser ocultado" + "');</script>");
            if (confirm == 2)
                Response.Write("<script>alert('" + "Não foi possivel ocultar o enologo" + "');</script>");

            reset();
        }

        protected void ButtonEliminarDeVez_Click(object sender, EventArgs e)
        {
            int confirm = MetodosEnologo.eliminar((int)ViewState["ides"], enologosActivo, "no");

            if (confirm == 1)
                Response.Write("<script>alert('" + "O enologo seleccionado não pode ser eliminado" + "');</script>");
            if (confirm == 2)
                Response.Write("<script>alert('" + "Não foi possivel eliminar o enologo" + "');</script>");

            reset();
        }
    }
}
