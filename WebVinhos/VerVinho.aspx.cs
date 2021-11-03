using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dbVinhosEFA.Metodos;
using dbVinhosEFA;
using WebVinhos.Utilizadores;

namespace WebVinhos
{
    public partial class VerVinho : System.Web.UI.Page
    {
        VinhosEFAEntities db = new VinhosEFAEntities();

        void getListaVinhosPorId(int idVinho)
        {
            MetodosVinhos.listaVinhosPorId(idVinho, NomeLabel, ProdutorLabel, RegiãoLabel, TipoVinhoLabel, Image1, AnoLabel, VolumeLabel, TeorAlcoolicoLabel, TemperaturaLabel, UtilizadorLabel);
        }

        void getCastas_Enologos(int id)
        {
            var castas = (from vc in db.VinhoCastas
                          join c in db.Castas on vc.Casta equals c.Id
                          where vc.Vinho == id
                          select new { Castas = c.Nome });

            var enologos = (from ve in db.VinhoEnologoes
                            join e in db.Enologoes on ve.Enologo equals e.Id
                            where ve.Vinho == id
                            select new { Enologos = e.Nome });


            GridViewCastas.DataSource = castas.ToList();
            GridViewCastas.DataBind();
            GridViewEnologos.DataSource = enologos.ToList();
            GridViewEnologos.DataBind();
        }

        void getComentsById()
        {
            int idVinho = int.Parse(Request.QueryString["id"]);

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
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                
                getListaVinhosPorId(int.Parse(Request.QueryString["id"]));
                getCastas_Enologos(int.Parse(Request.QueryString["id"]));

                if (Session["id_utilizador"] != null)
                {
                    ButtonEditar.Visible = true;
                    ButtonEliminar.Visible = true;
                    ButtonComentar.Visible = true;
                }
                else
                {
                    ButtonEliminar.Text = "Ver Comentarios";
                    ButtonEliminar.Visible = true;
                }
                getComentsById();
            }            
        }

        protected void GridViewCastasEnologos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCastas.PageIndex = e.NewPageIndex;
            GridViewEnologos.PageIndex = e.NewPageIndex;
            GridViewVerComentarios.PageIndex = e.NewPageIndex;
            getCastas_Enologos(int.Parse(Request.QueryString["id"]));
            getComentsById();
        }

        protected void ButtonEditar_Click(object sender, EventArgs e)
        {
            Session["id_vinho"] = int.Parse(Request.QueryString["id"]);
            Session["oQue"] = "editar";
            Response.Redirect("~/Utilizadores/InseririNovoVinho.aspx?id=" + Session["id_vinho"].ToString());
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (ButtonEliminar.Text == "Ver Comentarios")
            {
                GridViewVerComentarios.Visible = true;
            }
            else
            {
                Session["id_vinho"] = int.Parse(Request.QueryString["id"]);
                Session["oQue"] = "eliminar";
                Response.Redirect("~/Utilizadores/InseririNovoVinho.aspx?id=" + Session["id_vinho"].ToString());
            }

        }

        protected void ButtonComentar_Click(object sender, EventArgs e)
        {
            PanelComentar.Visible = true;
        }

        protected void LinkButtonComentario_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);

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
                        GridViewVerComentarios.Visible = true;
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

        protected void LinkButtonVerComentarios_Click(object sender, EventArgs e)
        {
            GridViewVerComentarios.Visible = true;
        }

        protected void LinkButtonSair_Click(object sender, EventArgs e)
        {
            PanelComentar.Visible = false;
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