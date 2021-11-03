using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace dbVinhosEFA.Metodos
{
    public static class MetodosVinhos
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();
        public static void insertVinhos(Vinho v)
        {
            db.Vinhoes.Add(v);
            db.SaveChanges();
        }

        public static void updateVinhos(Vinho v)
        {
            Vinho vi = db.Vinhoes.Find(v.Id);
            vi.Nome = v.Nome;
            vi.Regiao = v.Regiao;
            vi.Produtor = v.Produtor;
            vi.TipoVinho = v.TipoVinho;
            vi.Volume = v.Volume;
            vi.TeorAlcoolico = v.TeorAlcoolico;
            vi.Temperatura = v.Temperatura;
            vi.Ano = v.Ano;
            vi.Activo = v.Activo;

            db.SaveChanges();
        }

        public static void deleteVinhos(int Id, string op = "op")
        {
            Vinho vi = db.Vinhoes.Find(Id);

            if (op.Equals("f"))
                vi.Activo = false;
            else
                db.Vinhoes.Remove(vi);
            db.SaveChanges();
        }

        public static void getVinhos(DataGridView dataGridVinhos = null, ComboBox comboBoxProdutores = null, ComboBox comboBoxRegioes = null, ComboBox comboBoxTipoDeVinhos = null, ComboBox comboBoxCastas = null, ComboBox comboBoxEnologos = null,
                                        GridView GridVinhos = null, DropDownList dropDownListRegioes = null, DropDownList dropDownListProdutores = null, DropDownList dropDownListTipoVinhos = null, DropDownList dropDownListCastas = null, DropDownList dropDownListEnologos = null)
        {
            var vi = from v in db.Vinhoes
                     join r in db.Regiaos on v.Regiao equals r.Id
                     join p in db.Produtors on v.Produtor equals p.Id
                     join tv in db.TipoVinhoes on v.TipoVinho equals tv.Id
                     orderby v.Nome
                     select new
                     {
                         Id = v.Id,
                         Nome = v.Nome,
                         Ano = v.Ano,
                         Volume = v.Volume,
                         TeorAlcoolico = v.TeorAlcoolico,
                         Temperatura = v.Temperatura,
                         Activo = v.Activo,

                         Id_Regiao = r.Id,
                         Regiao = r.Nome,
                         ActivoRegiao = r.Activo,

                         Id_Produtor = p.Id,
                         Produtor = p.Nome,
                         Activo_Produtor = p.Activo,

                         Id_TipoVinho = tv.Id,
                         TipoVinho = tv.Nome,
                         Activo_TipoVinho = tv.Activo,

                         Id_utilizador = v.Utilizador,
                         //Utilizador = (from u in db.Utilizadors where u.Id == v.Utilizador select u.Nome),

                         Foto = v.Foto

                     };


            if (GridVinhos is null)
            {
                // GRID VIEW

                dataGridVinhos.DataSource = vi.ToList();

                dataGridVinhos.Columns[0].Visible = false; //Id
                dataGridVinhos.Columns[1].HeaderText = "Nome";
                dataGridVinhos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridVinhos.Columns[2].HeaderText = "Ano";
                dataGridVinhos.Columns[3].HeaderText = "Volume";
                dataGridVinhos.Columns[4].HeaderText = "Teor Alcoolico";
                dataGridVinhos.Columns[5].HeaderText = "Temperatura";
                dataGridVinhos.Columns[6].Visible = false; //activo

                dataGridVinhos.Columns[7].Visible = false; //Id regiao
                dataGridVinhos.Columns[8].HeaderText = "Região";
                dataGridVinhos.Columns[9].Visible = false; //activo regiao

                dataGridVinhos.Columns[10].Visible = false; //Id produtor
                dataGridVinhos.Columns[11].HeaderText = "Produtor";
                dataGridVinhos.Columns[12].Visible = false; //activo produtor

                dataGridVinhos.Columns[13].Visible = false; //Id tipo Vinho
                dataGridVinhos.Columns[14].HeaderText = "Tipo de Vinho";
                dataGridVinhos.Columns[15].Visible = false; //activo tipo Vinho

                // COMBOBOX PRODUTORES
                var pr = db.Produtors.Select(p => new { p.Id, p.Nome }).OrderBy(p => p.Nome);
                comboBoxProdutores.DataSource = pr.ToList();
                comboBoxProdutores.ValueMember = "Id";
                comboBoxProdutores.DisplayMember = "Nome";
                comboBoxProdutores.SelectedIndex = -1;

                //COMBOBOX REGIOES
                var rg = db.Regiaos.Select(r => new { r.Id, r.Nome }).OrderBy(r => r.Nome);
                comboBoxRegioes.DataSource = rg.ToList();
                comboBoxRegioes.ValueMember = "Id";
                comboBoxRegioes.DisplayMember = "Nome";
                comboBoxRegioes.SelectedIndex = -1;

                //COMBOBOX TIPOS DE VINHOS
                var tpv = db.TipoVinhoes.Select(t => new { t.Id, t.Nome }).OrderBy(t => t.Nome);
                comboBoxTipoDeVinhos.DataSource = tpv.ToList();
                comboBoxTipoDeVinhos.ValueMember = "Id";
                comboBoxTipoDeVinhos.DisplayMember = "Nome";
                comboBoxTipoDeVinhos.SelectedIndex = -1;

                //COMBOBOX CASTAS
                var ca = db.Castas.Select(c => new { c.Id, c.Nome }).OrderBy(c => c.Nome);
                comboBoxCastas.DataSource = ca.ToList();
                comboBoxCastas.ValueMember = "Id";
                comboBoxCastas.DisplayMember = "Nome";
                comboBoxCastas.SelectedIndex = -1;

                //COMBOBOX ENOLOGOS
                var en = db.Enologoes.Select(e => new { e.Id, e.Nome }).OrderBy(e => e.Nome);
                comboBoxEnologos.DataSource = en.ToList();
                comboBoxEnologos.ValueMember = "Id";
                comboBoxEnologos.DisplayMember = "Nome";
                comboBoxEnologos.SelectedIndex = -1;
            }

            if (dataGridVinhos is null)
            {
                // GRID VIEW
                GridVinhos.DataSource = vi.ToList();
                GridVinhos.DataBind();

                //DROPDOWN REGIOES
                dropDownListRegioesShow(dropDownListRegioes);

                ////DROPDOWN PRODUTORES
                dropDownListProdutoresShow(dropDownListProdutores);

                ////DROPDOWN TIPOS DE VINHOS
                dropDownListTipoVinhosShow(dropDownListTipoVinhos);

                //DROPDOWN CASTAS
                dropDownListCastasShow(dropDownListCastas, null);

                //DROPDOWN ENOLOGOS
                dropDownListEnologosShow(dropDownListEnologos, null);
            }
        }

        public static void dropDownListRegioesShow(DropDownList dropDownListRegioes)
        {
            var rg = db.Regiaos.Select(r => new { r.Id, r.Nome }).OrderBy(r => r.Nome);

            dropDownListRegioes.DataSource = rg.ToList();
            dropDownListRegioes.DataValueField = "Id";
            dropDownListRegioes.DataTextField = "Nome";
            dropDownListRegioes.SelectedIndex = -1;
            dropDownListRegioes.DataBind();

            dropDownListRegioes.Items.Insert(0, "Seleccione a região");
        }

        public static void dropDownListProdutoresShow(DropDownList dropDownListProdutores)
        {
            var pr = db.Produtors.Select(p => new { p.Id, p.Nome }).OrderBy(p => p.Nome);

            dropDownListProdutores.DataSource = pr.ToList();
            dropDownListProdutores.DataValueField = "Id";
            dropDownListProdutores.DataTextField = "Nome";
            dropDownListProdutores.SelectedIndex = -1;
            dropDownListProdutores.DataBind();

            dropDownListProdutores.Items.Insert(0, "Seleccione o produtor");
        }

        public static void dropDownListTipoVinhosShow(DropDownList dropDownListTipoVinhos)
        {
            var tpv = db.TipoVinhoes.Select(t => new { t.Id, t.Nome }).OrderBy(t => t.Nome);

            dropDownListTipoVinhos.DataSource = tpv.ToList();
            dropDownListTipoVinhos.DataValueField = "Id";
            dropDownListTipoVinhos.DataTextField = "Nome";
            dropDownListTipoVinhos.SelectedIndex = -1;
            dropDownListTipoVinhos.DataBind();

            dropDownListTipoVinhos.Items.Insert(0, "Seleccione o tipo d´vinho");
        }

        public static void dropDownListCastasShow(DropDownList dropDownListCastas = null, System.Web.UI.WebControls.ListBox listBoxCastas = null, int id = -1)
        {
            var ca = db.Castas.Select(c => new { c.Id, c.Nome }).OrderBy(c => c.Nome);

            if (listBoxCastas is null)
            {
                dropDownListCastas.DataSource = ca.ToList();
                dropDownListCastas.DataValueField = "Id";
                dropDownListCastas.DataTextField = "Nome";
                dropDownListCastas.SelectedIndex = -1;
                dropDownListCastas.DataBind();

                dropDownListCastas.Items.Insert(0, "Seleccione a casta");
            }
            else
            {
                if (id != -1)
                {
                    var cl = db.VinhoCastas.Join(db.Castas, vc => vc.Casta, c => c.Id,
                        (vc, c) => new
                        {
                            c.Nome,
                            vc.Vinho,
                        }).Where(c => c.Vinho == id);

                    foreach (var item in cl.ToList())
                    {
                        listBoxCastas.Items.Add(item.Nome);
                    }
                }
            }

        }

        public static void dropDownListEnologosShow(DropDownList dropDownListEnologos, System.Web.UI.WebControls.ListBox listBoxEnologos = null, int id = -1)
        {
            var en = db.Enologoes.Select(e => new { e.Id, e.Nome, }).OrderBy(e => e.Nome);

            if (listBoxEnologos is null)
            {
                dropDownListEnologos.DataSource = en.ToList();
                dropDownListEnologos.DataValueField = "Id";
                dropDownListEnologos.DataTextField = "Nome";
                dropDownListEnologos.SelectedIndex = -1;
                dropDownListEnologos.DataBind();

                dropDownListEnologos.Items.Insert(0, "Seleccione o enologo");
            }
            else
            {
                if (id != -1)
                {
                    var el = db.VinhoEnologoes.Join(db.Enologoes, ve => ve.Enologo, e => e.Id,
                        (ve, e) => new
                        {
                            e.Nome,
                            ve.Vinho,
                        }).Where(e => e.Vinho == id);

                    foreach (var item in el.ToList())
                    {
                        listBoxEnologos.Items.Add(item.Nome);
                    }
                }
            }

        }

        public static int confirmarComListaVinhos(int id, string tipo)
        {
            int confirm = 0, size = 0;

            var vi = db.Vinhoes.Select(v => new
            {
                v.Id,
                v.Nome,
                v.Ano,
                v.Volume,
                v.TeorAlcoolico,
                v.Temperatura,
                v.Regiao,
                v.Produtor,
                v.TipoVinho,

            }).ToList();

            if (tipo == "regiao")
                size = vi.Where(v => v.Regiao == id).Count();

            if (tipo == "prod")
                size = vi.Where(v => v.Produtor == id).Count();

            if (tipo == "tipoVinho")
                size = vi.Where(v => v.TipoVinho == id).Count();



            if (size != 0) confirm += 1;

            return confirm;
        }

        public static int compararVinhos(string nome, string ano, string volume, string teorAlcoolico, string temperatura, string regiao, string produtor, string tipoVinho, List<string> listaCastas)
        {
            int compararVinhos = 0;

            var vi = db.Vinhoes.Select(v => new
            {
                v.Id,
                v.Nome,
                v.Ano,
                v.Volume,
                v.TeorAlcoolico,
                v.Temperatura,
                v.Regiao,
                v.Produtor,
                v.TipoVinho,
                v.Activo
            }).OrderBy(v => v.Nome);

            foreach (var item in vi.ToList())
            {
                if (item.Nome.ToString() == nome && item.Ano == int.Parse(ano)
                    && item.Volume == decimal.Parse(volume) && item.TeorAlcoolico == decimal.Parse(teorAlcoolico)
                    && item.Temperatura == decimal.Parse(temperatura)
                    && item.Regiao == int.Parse(regiao) && item.Produtor == int.Parse(produtor)
                    && item.TipoVinho == int.Parse(tipoVinho))
                {
                    compararVinhos = listaCastasPorVinho(item.Id, listaCastas);

                    if (compararVinhos == 0) break;
                }
            }

            return compararVinhos;

        }

        public static int listaCastasPorVinho(int idvinho, List<string> listaCastas)
        {
            int castaRepetidas = 0;

            var castas = db.Castas.Join(db.VinhoCastas, c => c.Id, v => v.Casta,
                        (c, v) => new
                        {
                            c.Id,
                            c.Nome,
                            IdVinho = v.Vinho
                        }).Where(v => v.IdVinho == idvinho);

            foreach (var item in castas)
            {
                foreach (var lc in listaCastas)
                {
                    if (item.Id.ToString() == lc.ToString())
                    {
                        castaRepetidas += 1;
                    }
                }
                if (castaRepetidas == 0) break;
            }

            return castaRepetidas;
        }

        public static int eliminar(int id, string ocultar = "sim")
        {
            try
            {
                if (ocultar == "sim")
                    deleteVinhos(id, "f");
                else
                {
                    MetodosVinhoCastas.deleteVinhoCastas(id);
                    MetodosVinhoEnologos.deleteVinhoEnologos(id);
                    deleteVinhos(id);
                }
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public static DataTable colunas()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Produtor", typeof(string));
            dt.Columns.Add("Regiao", typeof(string));
            dt.Columns.Add("Tipo de Vinho", typeof(string));
            dt.Columns.Add("Foto", typeof(string));
            dt.Columns.Add("Ano", typeof(string));
            dt.Columns.Add("Volume", typeof(string));
            dt.Columns.Add("Teor Alcoolico", typeof(string));
            dt.Columns.Add("Temperatura", typeof(string));
            dt.Columns.Add("Utilizador", typeof(string));
            dt.Columns.Add("ID_Utilizador", typeof(string));
            dt.Columns.Add("Activo", typeof(bool));
            dt.Columns.Add("URL_Produtor", typeof(string));

            return dt;
        }

        public static DataTable dataTableListaVinhos()
        {
            DataTable dt = colunas();

            var listaVinhosTemp = db.usp_GetListaVinhos().ToList();

            var listaVinhos = listaVinhosTemp.Where(v => v.Activo == true).Select(v => new
            {
                v.Id,
                v.Nome,
                v.Ano,
                v.Volume,
                v.Temperatura,
                v.TeorAlcoolico,
                v.Regiao,
                v.Produtor,
                v.TipoVinho,
                v.Foto,
                v.Utilizador,
                v.Activo
            });

            DataRow dr;
            foreach (var item in listaVinhos)
            {
                dr = dt.NewRow();
                dr[0] = item.Id.ToString();
                dr[1] = item.Nome;
                dr[2] = item.Produtor;
                dr[3] = item.Regiao;
                dr[4] = item.TipoVinho;
                dr[5] = item.Foto;
                dr[6] = item.Ano.ToString();
                dr[7] = item.Volume.ToString();
                dr[8] = item.TeorAlcoolico.ToString();
                dr[9] = item.Temperatura.ToString();
                if (item.Utilizador.ToString() != "")
                {
                    var q = (from u in db.Utilizadors
                             where u.Id == item.Utilizador
                             select new { u.Id, u.Nome });

                    foreach (var itemU in q.ToList())
                    {
                        dr[10] = itemU.Nome.ToString();
                        dr[11] = itemU.Id.ToString();
                    }
                }
                else
                {
                    dr[10] = "";
                    dr[11] = "";
                }
                dr[12] = item.Activo;
                
                var url = (from p in db.Produtors
                           where p.Nome == item.Produtor
                           select p.URL).FirstOrDefault();
                dr[13] = url;

                dt.Rows.Add(dr);
            }

            return dt;

        }

        public static void listaVinhosPorId(int idVinho, System.Web.UI.WebControls.Label nome, HyperLink produtor, System.Web.UI.WebControls.Label regiao, System.Web.UI.WebControls.Label tipoVinho, Image img, System.Web.UI.WebControls.Label ano, System.Web.UI.WebControls.Label volume, System.Web.UI.WebControls.Label teorAlcoolicao, System.Web.UI.WebControls.Label temperatura, System.Web.UI.WebControls.Label utilizador)
        {

            var listaVinhosTemp = db.usp_GetVinhoById(idVinho);

            var listaVinhos = listaVinhosTemp.Where(v => v.Activo == true).Select(v => new
            {
                v.Id,
                v.Nome,
                v.Ano,
                v.Volume,
                v.Temperatura,
                v.TeorAlcoolico,
                v.Regiao,
                v.Produtor,
                v.TipoVinho,
                v.Foto,
                v.Utilizador,
                v.Activo
            });


            foreach (var item in listaVinhos)
            {
                nome.Text = item.Nome;
                produtor.Text = item.Produtor;
                var url = (from p in db.Produtors
                           where p.Nome == item.Produtor
                           select p.URL).FirstOrDefault();
                produtor.NavigateUrl = url;

                regiao.Text = item.Regiao;
                tipoVinho.Text = item.TipoVinho;
                img.ImageUrl = item.Foto;
                ano.Text = item.Ano.ToString();
                volume.Text = item.Volume.ToString();
                teorAlcoolicao.Text = item.TeorAlcoolico.ToString();
                temperatura.Text = item.Temperatura.ToString();

                if (item.Utilizador.ToString() != "")
                {
                    var q = (from u in db.Utilizadors
                             where u.Id == item.Utilizador
                             select new { u.Nome }).FirstOrDefault();
                    utilizador.Text = q.Nome;
                }
                else utilizador.Text = "";
            }

        }

        public static DataTable listaVinhosPorUtilizador(int id, out string nome)
        {
            DataTable dt = colunas();
            string nomeTemp = "";

            var listaVinhosTemp = db.usp_GetVinhoByUser(id);

            var listaVinhos = listaVinhosTemp.Where(v => v.Activo == true).Select(v => new
            {
                v.Id,
                v.Nome,
                v.Ano,
                v.Volume,
                v.Temperatura,
                v.TeorAlcoolico,
                v.Regiao,
                v.Produtor,
                v.TipoVinho,
                v.Foto,
                v.Utilizador,
                v.User_Nome,
                v.Activo
            });

            DataRow dr;
            foreach (var item in listaVinhos)
            {
                dr = dt.NewRow();
                dr[0] = item.Id.ToString();
                dr[1] = item.Nome;
                dr[2] = item.Produtor;
                dr[3] = item.Regiao;
                dr[4] = item.TipoVinho;
                dr[5] = item.Foto;
                dr[6] = item.Ano.ToString();
                dr[7] = item.Volume.ToString();
                dr[8] = item.TeorAlcoolico.ToString();
                dr[9] = item.Temperatura.ToString();
                dr[10] = item.User_Nome;
                nomeTemp = item.User_Nome;
                dr[11] = item.Utilizador;
                dr[12] = item.Activo;

                var url = (from p in db.Produtors
                           where p.Nome == item.Produtor
                           select p.URL).FirstOrDefault();
                dr[13] = url;

                dt.Rows.Add(dr);
            }

            nome = nomeTemp;
            return dt;
        }
    }
}
