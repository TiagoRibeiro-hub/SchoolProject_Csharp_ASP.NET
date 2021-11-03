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
    public partial class Pesquisar : System.Web.UI.Page
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();

        List<int> vinhosList = new List<int>();

        void getDropdowns()
        {
            MetodosVinhos.dropDownListRegioesShow(DropDownListRegião);
            MetodosVinhos.dropDownListProdutoresShow(DropDownListProdutor);
            MetodosVinhos.dropDownListTipoVinhosShow(DropDownListTipoVinho);
            MetodosVinhos.dropDownListCastasShow(DropDownListCastas);
            MetodosVinhos.dropDownListEnologosShow(DropDownListEnologos);

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                TemplateField coluna = new TemplateField();
                coluna.ItemStyle.Width = 300;
                coluna.HeaderText = "Vinho";
                coluna.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridViewPesquisa.Columns.Add(coluna);

                TemplateField coluna2 = new TemplateField();
                coluna2.ItemStyle.Width = 300;
                coluna2.HeaderText = "Produtor";
                coluna2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridViewPesquisa.Columns.Add(coluna2);

                getDropdowns();

            }
        }

        void showSearch()
        {
            List<int> vinhosRegiao = new List<int>();
            List<int> vinhosProdutor = new List<int>();
            List<int> vinhosTipoVinho = new List<int>();
            List<int> vinhosCastas = new List<int>();
            List<int> vinhosEnologos = new List<int>();
            List<int> vinhosPesquisa = new List<int>();
            List<int> vinhosListTemp = new List<int>();

            int regiao = 0;
            if (DropDownListRegião.SelectedIndex != 0)
            {
                regiao = int.Parse(DropDownListRegião.SelectedValue);
                var q = from v in db.Vinhoes
                        join r in db.Regiaos on v.Regiao equals r.Id
                        where r.Id == regiao
                        select new { v.Id, v.Regiao };
                vinhosRegiao = q.Select(v => v.Id).ToList();

                if (vinhosRegiao.Count > 0)
                {
                    vinhosList = vinhosRegiao;
                }
            }
            int produtor = 0;
            if (DropDownListProdutor.SelectedIndex != 0)
            {
                produtor = int.Parse(DropDownListProdutor.SelectedValue);
                var q = from v in db.Vinhoes
                        join p in db.Produtors on v.Produtor equals p.Id
                        where p.Id == produtor
                        select new { v.Id };
                vinhosProdutor = q.Select(v => v.Id).ToList();


                if (vinhosRegiao.Count == 0 && vinhosList.Count == 0)
                {
                    vinhosList = vinhosProdutor;
                }
                else if (vinhosListTemp.Count > 0 && vinhosProdutor.Count > 0)
                {
                    foreach (var item in vinhosList)
                    {
                        foreach (var itemV in vinhosProdutor)
                        {
                            if (itemV == item)
                            {
                                vinhosListTemp.Add(itemV);
                            }
                        }
                    }
                    vinhoListTempFill(vinhosListTemp);
                }
            }

            int tipoVinho = 0;
            if (DropDownListTipoVinho.SelectedIndex != 0)
            {
                tipoVinho = int.Parse(DropDownListTipoVinho.SelectedValue);

                var q = from v in db.Vinhoes
                        join tv in db.TipoVinhoes on v.TipoVinho equals tv.Id
                        where tv.Id == tipoVinho
                        select new { v.Id };
                vinhosTipoVinho = q.Select(v => v.Id).ToList();

                if (vinhosProdutor.Count == 0 && vinhosList.Count == 0)
                {
                    vinhosList = vinhosTipoVinho;
                }
                else if (vinhosList.Count > 0 && vinhosTipoVinho.Count > 0)
                {
                    foreach (var item in vinhosList)
                    {
                        foreach (var itemV in vinhosTipoVinho)
                        {
                            if (itemV == item)
                            {
                                vinhosListTemp.Add(itemV);
                            }
                        }
                    }
                    vinhoListTempFill(vinhosListTemp);
                }
            }

            int castaVinho = 0;
            if (DropDownListCastas.SelectedValue != "Seleccione a casta")
            {
                castaVinho = int.Parse(DropDownListCastas.SelectedValue);
            }

            int enologoVinho = 0;
            if (DropDownListEnologos.SelectedValue != "Seleccione o enologo")
            {
                enologoVinho = int.Parse(DropDownListEnologos.SelectedValue);
            }

            string nome = "";
            if (TextBoxNome.Text != "")
            {
                nome = TextBoxNome.Text;

                var q = from v in db.Vinhoes
                        where v.Nome.Contains(nome)
                        select new { v.Id };

                vinhosPesquisa = q.Select(v => v.Id).ToList();

                if (vinhosTipoVinho.Count == 0 && vinhosList.Count == 0)
                {
                    vinhosList = vinhosPesquisa;
                }
                else if (vinhosList.Count > 0 && vinhosPesquisa.Count > 0)
                {
                    foreach (var item in vinhosList)
                    {
                        foreach (var itemV in vinhosPesquisa)
                        {
                            if (itemV == item)
                            {
                                vinhosListTemp.Add(itemV);
                            }
                        }
                    }
                    vinhoListTempFill(vinhosListTemp);
                }

            }

            if (castaVinho > 0 && enologoVinho == 0)
            {
                var finalList = (from v in db.Vinhoes
                                 join p in db.Produtors on v.Produtor equals p.Id
                                 join r in db.Regiaos on v.Regiao equals r.Id
                                 join tv in db.TipoVinhoes on v.TipoVinho equals tv.Id
                                 join vc in db.VinhoCastas on v.Id equals vc.Vinho
                                 join c in db.Castas on vc.Casta equals c.Id
                                 join ve in db.VinhoEnologoes on v.Id equals ve.Vinho
                                 join en in db.Enologoes on ve.Enologo equals en.Id
                                 where vinhosList.Contains(v.Id) || c.Id == castaVinho
                                 select new
                                 {
                                     v.Id,
                                     v.Nome,
                                     Região = r.Nome,
                                     Tipo = tv.Nome,
                                     Produtor = p.Nome,
                                     Castas = c.Nome,
                                     Enologos = en.Nome
                                 }).Distinct().ToList();

                GridViewPesquisa.DataSource = finalList;
                GridViewPesquisa.DataBind();
            }

            if (enologoVinho > 0 && castaVinho == 0)
            {
                var finalList = (from v in db.Vinhoes
                                 join p in db.Produtors on v.Produtor equals p.Id
                                 join r in db.Regiaos on v.Regiao equals r.Id
                                 join tv in db.TipoVinhoes on v.TipoVinho equals tv.Id
                                 join vc in db.VinhoCastas on v.Id equals vc.Vinho
                                 join c in db.Castas on vc.Casta equals c.Id
                                 join ve in db.VinhoEnologoes on v.Id equals ve.Vinho
                                 join en in db.Enologoes on ve.Enologo equals en.Id
                                 where vinhosList.Contains(v.Id) || en.Id == enologoVinho
                                 select new
                                 {
                                     v.Id,
                                     v.Nome,
                                     Região = r.Nome,
                                     Tipo = tv.Nome,
                                     Produtor = p.Nome,
                                     Castas = c.Nome,
                                     Enologos = en.Nome
                                 }).Distinct().ToList();

                GridViewPesquisa.DataSource = finalList;
                GridViewPesquisa.DataBind();
            }

            if (castaVinho > 0 && enologoVinho > 0)
            {
                var finalList = (from v in db.Vinhoes
                                 join p in db.Produtors on v.Produtor equals p.Id
                                 join r in db.Regiaos on v.Regiao equals r.Id
                                 join tv in db.TipoVinhoes on v.TipoVinho equals tv.Id
                                 join vc in db.VinhoCastas on v.Id equals vc.Vinho
                                 join c in db.Castas on vc.Casta equals c.Id
                                 join ve in db.VinhoEnologoes on v.Id equals ve.Vinho
                                 join en in db.Enologoes on ve.Enologo equals en.Id
                                 where vinhosList.Contains(v.Id) || c.Id == castaVinho || en.Id == enologoVinho
                                 select new
                                 {
                                     v.Id,
                                     v.Nome,
                                     Região = r.Nome,
                                     Tipo = tv.Nome,
                                     Produtor = p.Nome,
                                     Castas = c.Nome,
                                     Enologos = en.Nome
                                 }).Distinct().ToList();

                GridViewPesquisa.DataSource = finalList;
                GridViewPesquisa.DataBind();
            }

            if (castaVinho == 0 && enologoVinho == 0)
            {
                var finalList = (from v in db.Vinhoes
                                 join p in db.Produtors on v.Produtor equals p.Id
                                 join r in db.Regiaos on v.Regiao equals r.Id
                                 join tv in db.TipoVinhoes on v.TipoVinho equals tv.Id
                                 where vinhosList.Contains(v.Id)
                                 select new
                                 {
                                     v.Id,
                                     v.Nome,
                                     Região = r.Nome,
                                     Tipo = tv.Nome,
                                     Produtor = p.Nome,
                                     Url = p.URL
                                 }).Distinct().ToList();

                GridViewPesquisa.DataSource = finalList;
                GridViewPesquisa.DataBind();
            }
        }

        void vinhoListTempFill(List<int> vinhosListTemp)
        {
            foreach (var item in vinhosListTemp)
            {
                vinhosList.Add(item);
            }

            vinhosListTemp.Clear();
        }

        protected void ButtonPesquisar_Click(object sender, EventArgs e)
        {
            showSearch();
        }

        protected void GridViewPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink link = new HyperLink();
                link.Text = e.Row.Cells[3].Text;
                link.NavigateUrl = "VerVinho.aspx?id=" + e.Row.Cells[2].Text;
                e.Row.Cells[0].Controls.Add(link);

                HyperLink link2 = new HyperLink();
                link2.Text = e.Row.Cells[6].Text;
                link2.NavigateUrl = e.Row.Cells[7].Text;
                e.Row.Cells[1].Controls.Add(link2);
            }
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
        }

    }
}