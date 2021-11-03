using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dbVinhosEFA;
using dbVinhosEFA.Metodos;
using WebVinhos.Utilizadores;


namespace WebVinhos.Web_Form_User_Control
{
    public partial class VinhoPorUtilizador1 : System.Web.UI.UserControl
    {

        static VinhosEFAEntities db = new VinhosEFAEntities();

        int CurrentPage;
        void BindListVinhos(DataTable table)
        {
            PagedDataSource paged = new PagedDataSource();

            paged.DataSource = table.DefaultView;
            paged.PageSize = 8;
            paged.AllowPaging = true;
            paged.CurrentPageIndex = CurrentPage;

            linkPrimeira.Enabled = !paged.IsFirstPage;
            linkAnterior.Enabled = !paged.IsFirstPage;
            linkSeguinte.Enabled = !paged.IsLastPage;
            linkUltima.Enabled = !paged.IsLastPage;

            ViewState["total"] = paged.PageCount;

            listVinhos.DataSource = paged;
            listVinhos.DataBind();
            ViewState["dataSourceListVinhos"] = table;

            if ((int)ViewState["total"] == 1)
            {
                linkSeguinte.Visible = false;
                linkUltima.Text = "Página Unica";
            }
            else
                linkUltima.Text = "Ultima (" + (int)ViewState["total"] + "ªpag.)";
        }

        public string getListaVinhosUtilizador(int id)
        {
            DataTable table = MetodosVinhos.listaVinhosPorUtilizador(id, out string nome);
            BindListVinhos(table);
            return nome;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nome;
                if (Request.QueryString["id"] != null)
                {
                    if(Session["id_utilizador"] is null)
                    {
                        nome = getListaVinhosUtilizador(int.Parse(Request.QueryString["id"]));
                        LabelUtilizador.Text = "Lista de Vinhos de " + nome;
                    }
                    else
                    {
                        nome = getListaVinhosUtilizador((int)Session["id_utilizador"]);

                        if ((int)Session["id_utilizador"] == int.Parse(Request.QueryString["id"]))
                        {
                            LabelUtilizador.Text = "Minha Lista de Vinhos";
                        }
                        else
                        {
                            LabelUtilizador.Text = "Lista de Vinhos de " + nome;
                        }                   
                    }
                }
                else
                {
                    getListaVinhosUtilizador((int)Session["id_utilizador"]);
                    LabelUtilizador.Text = "Minha Lista de Vinhos";
                }
                

                ViewState["contador"] = 0;
                LabelPagina.Text = (int)ViewState["contador"] + 1 + "ªpag.";

                linkPrimeira.Visible = false;
                linkAnterior.Visible = false;

            }
            CurrentPage = (int)ViewState["contador"];
        }

        #region LinkButtonPag
        void linkBtnPaginacao(string ultima = "no")
        {
            if (ultima.Equals("y"))
            {
                linkUltima.Visible = false;
                linkSeguinte.Visible = false;
                linkPrimeira.Visible = true;
                linkAnterior.Visible = true;
            }
            else
            {
                linkUltima.Visible = true;
                linkSeguinte.Visible = true;
                linkPrimeira.Visible = false;
                linkAnterior.Visible = false;
            }
        }

        protected void linkPrimeira_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            ViewState["contador"] = CurrentPage;
            LabelPagina.Text = (int)ViewState["contador"] + 1 + "ªpag.";

            linkBtnPaginacao();

            if (Request.QueryString["id"] != null)
            {
                getListaVinhosUtilizador(int.Parse(Request.QueryString["id"]));
            }
            else
                getListaVinhosUtilizador((int)Session["id_utilizador"]);
        }

        protected void linkAnterior_Click(object sender, EventArgs e)
        {
            CurrentPage = (int)ViewState["contador"];
            CurrentPage -= 1;
            ViewState["contador"] = CurrentPage;
            LabelPagina.Text = (int)ViewState["contador"] + 1 + "ªpag.";

            linkUltima.Visible = true;
            linkSeguinte.Visible = true;

            if (CurrentPage == 0)
            {
                linkBtnPaginacao();
            }

            BindListVinhos((DataTable)ViewState["dataSourceListVinhos"]);
        }

        protected void linkSeguinte_Click(object sender, EventArgs e)
        {
            CurrentPage = (int)ViewState["contador"];
            CurrentPage += 1;
            ViewState["contador"] = CurrentPage;
            LabelPagina.Text = (int)ViewState["contador"] + 1 + "ªpag.";

            linkPrimeira.Visible = true;
            linkAnterior.Visible = true;

            if (CurrentPage == (int)ViewState["total"] - 1)
            {
                linkBtnPaginacao("y");
            }

            BindListVinhos((DataTable)ViewState["dataSourceListVinhos"]);
        }

        protected void linkUltima_Click(object sender, EventArgs e)
        {
            CurrentPage = (int)ViewState["total"] - 1;
            ViewState["contador"] = CurrentPage;
            LabelPagina.Text = (int)ViewState["contador"] + 1 + "ªpag.";

            linkBtnPaginacao("y");

            BindListVinhos((DataTable)ViewState["dataSourceListVinhos"]);
        }

        #endregion


    }
}