using dbVinhosEFA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dbVinhosEFA.Metodos;


namespace WebVinhos
{
    public partial class homePage : System.Web.UI.Page
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

            linkUltima.Text = "Ultima (" + (int)ViewState["total"] + "ªpag.)";
        }

        void getListaVinhos()
        {
            DataTable table = MetodosVinhos.dataTableListaVinhos();
            BindListVinhos(table);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getListaVinhos();
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
            LabelPagina.Text = (int)ViewState["contador"]+1 + "ªpag.";

            linkBtnPaginacao();
            
            getListaVinhos();
        }

        protected void linkAnterior_Click(object sender, EventArgs e)
        {
            CurrentPage = (int)ViewState["contador"];
            CurrentPage -= 1;
            ViewState["contador"] = CurrentPage;
            LabelPagina.Text = (int)ViewState["contador"]+1 +"ªpag.";
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
            LabelPagina.Text = (int)ViewState["contador"]+1 + "ªpag.";

            linkPrimeira.Visible = true;
            linkAnterior.Visible = true;

            if (CurrentPage == (int)ViewState["total"] -1)
            {
                linkBtnPaginacao("y");
            }

            BindListVinhos((DataTable)ViewState["dataSourceListVinhos"]);
        }

        protected void linkUltima_Click(object sender, EventArgs e)
        {
            CurrentPage = (int)ViewState["total"] - 1;
            ViewState["contador"] = CurrentPage;
            LabelPagina.Text = (int)ViewState["contador"]+1 + "ªpag.";

            linkBtnPaginacao("y");

            BindListVinhos((DataTable)ViewState["dataSourceListVinhos"]);
        }

        #endregion

        protected void listVinhos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    Label produtor = (Label)e.Item.FindControl("ProdutorLabel");
            //    produtor.Text = Server.HtmlDecode(produtor.Text);
            //}
        }
    }
}