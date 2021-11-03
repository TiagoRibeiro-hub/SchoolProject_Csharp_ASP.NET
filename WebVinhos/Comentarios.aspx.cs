using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dbVinhosEFA;
using dbVinhosEFA.Metodos;

namespace WebVinhos
{
    public partial class Comentarios : System.Web.UI.Page
    {
        VinhosEFAEntities db = new VinhosEFAEntities();

        void getComentsById(int idVinho)
        {
            var coment = (from c in db.VinhoProvas
                          join u in db.Utilizadors on c.Utilizador equals u.Id
                          where c.Vinho == idVinho
                          select new
                          {
                              Utilizador = u.Nome,
                              c.Classificacao,
                              c.Comentario,
                          }).ToList();

            GridViewVerComentarios.DataSource = coment;
            GridViewVerComentarios.DataBind();

            if (coment.Count == 0)
                if (Session["id_utilizador"] != null)
                    LinkButtonPrimeiroComentar.Visible = true;
        }

        void getDropDown()
        {
            var listaVinhos = (from v in db.Vinhoes where v.Activo == true select new { v.Id, v.Nome }).ToList();

            DropDownListVinhos.DataSource = listaVinhos;
            DropDownListVinhos.DataValueField = "Id";
            DropDownListVinhos.DataTextField = "Nome";
            DropDownListVinhos.SelectedIndex = -1;
            DropDownListVinhos.DataBind();

            DropDownListVinhos.Items.Insert(0, "Seleccione um vinho");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                getDropDown();
        }

        protected void DropDownListVinhos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListVinhos.SelectedIndex != 0)
            {
                int id = int.Parse(DropDownListVinhos.SelectedValue);
                GridViewVerComentarios.Visible = true;
                getComentsById(id);
            }

            if (DropDownListVinhos.SelectedIndex == 0)
                GridViewVerComentarios.Visible = false;
        }

        protected void GridViewVerComentarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewVerComentarios.PageIndex = e.NewPageIndex;
        }

        protected void GridViewVerComentarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[0].Text = Server.HtmlDecode(e.Row.Cells[0].Text); // nome utilizador
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text == "1" ? e.Row.Cells[1].Text + " Estrela" : e.Row.Cells[1].Text + " Estrelas";
                    e.Row.Cells[2].Text = Server.HtmlDecode(e.Row.Cells[2].Text); // comentario
                }
            }
        }

        protected void LinkButtonPrimeiroComentar_Click(object sender, EventArgs e)
        {
            PanelComentar.Visible = true;
            DropDownListVinhos.Enabled = false;
        }

        protected void LinkButtonComentario_Click(object sender, EventArgs e)
        {
            int id = int.Parse(DropDownListVinhos.SelectedValue);

            if (TextBoxComentario.Text != "")
            {
                if (CheckBox1Estrela.Checked || CheckBox2Estrelas.Checked || CheckBox3Estrelas.Checked || CheckBox4Estrelas.Checked || CheckBox5Estrelas.Checked)
                {
                    try
                    {
                        VinhoProva vp = new VinhoProva();
                        vp.Vinho = id;
                        vp.Utilizador = int.Parse(Session["id_utilizador"].ToString());
                        vp.Comentario = TextBoxComentario.Text;
                        vp.Classificacao = checkBox();
                        MetodosVinhoProva.insertProva(vp);

                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('" + "Não foi possivel inserir o Comentário, tente de novo." + "');</script>");
                    }
                    finally
                    {
                        TextBoxComentario.Text = "";
                        mudarCheckbox(false, false, false, false, false);
                        PanelComentar.Visible = false;
                        DropDownListVinhos.Enabled = true;
                        GridViewVerComentarios.Visible = true;
                        getComentsById(id);
                    }
                }
                else
                {
                    Response.Write("<script>alert('" + "Falta Classificar" + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('" + "Falta Comentar" + "');</script>");
            }

        }

        protected void LinkButtonSair_Click(object sender, EventArgs e)
        {
            PanelComentar.Visible = false;
            DropDownListVinhos.Enabled = true;
        }

        #region CheckBoxes
        public byte checkBox()
        {
            byte estrela = 0;
            if (CheckBox1Estrela.Checked)
                estrela = 1;
            if (CheckBox2Estrelas.Checked)
                estrela = 2;
            if (CheckBox3Estrelas.Checked)
                estrela = 3;
            if (CheckBox4Estrelas.Checked)
                estrela = 4;
            if (CheckBox5Estrelas.Checked)
                estrela = 5;

            return estrela;
        }

        void mudarCheckbox(bool e1, bool e2, bool e3, bool e4, bool e5)
        {
            CheckBox1Estrela.Checked = e1;
            CheckBox2Estrelas.Checked = e2;
            CheckBox3Estrelas.Checked = e3;
            CheckBox4Estrelas.Checked = e4;
            CheckBox5Estrelas.Checked = e5;
        }

        protected void CheckBox1Estrela_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1Estrela.Checked)
                mudarCheckbox(true, false, false, false, false);
        }

        protected void CheckBox2Estrelas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2Estrelas.Checked)
                mudarCheckbox(false, true, false, false, false);
        }

        protected void CheckBox3Estrelas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox3Estrelas.Checked)
                mudarCheckbox(false, false, true, false, false);
        }

        protected void CheckBox4Estrelas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox4Estrelas.Checked)
                mudarCheckbox(false, false, false, true, false);
        }

        protected void CheckBox5Estrelas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox5Estrelas.Checked)
                mudarCheckbox(false, false, false, false, true);
        }

        #endregion


    }
}