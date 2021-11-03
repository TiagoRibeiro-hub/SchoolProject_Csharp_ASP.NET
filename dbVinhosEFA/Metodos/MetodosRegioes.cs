using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace dbVinhosEFA.Metodos
{
    public static class MetodosRegioes
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();

        public static void insertRegiao(Regiao r)
        {
            db.Regiaos.Add(r);
            db.SaveChanges();
        }

        public static void updateRegiao(Regiao r)
        {
            Regiao rg = db.Regiaos.Find(r.Id);
            rg.Nome = r.Nome;
            rg.Descricao = r.Descricao;
            rg.Activo = r.Activo;
            db.SaveChanges();
        }

        public static void deleteRegiao(int Id, string op = "op")
        {
            Regiao rg = db.Regiaos.Find(Id);
            if (op.Equals("f"))
            {
                rg.Activo = false;
            }
            else
            {
                db.Regiaos.Remove(rg);
            }
            db.SaveChanges();
        }

        public static void getRegioes(DataGridView dataGridRegioes = null, GridView GridRegioes = null)
        {
            var rg = db.Regiaos.Select(r => new
            {
                Id = r.Id,
                Nome = r.Nome,
                Descricao = r.Descricao,
                Activo = r.Activo
            }).OrderBy(r => r.Nome);

            if(GridRegioes == null)
            {
                dataGridRegioes.DataSource = rg.ToList();

                dataGridRegioes.Columns[0].Visible = false;
                dataGridRegioes.Columns[1].HeaderText = "Nome";
                dataGridRegioes.Columns[2].HeaderText = "Descriçao"; 
                dataGridRegioes.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridRegioes.Columns[3].Visible = false;
            }

            if(dataGridRegioes == null)
            {
                GridRegioes.DataSource = rg.ToList();
                GridRegioes.DataBind();
            }    
        }

        public static int regioesRepetidas(string textBoxNome)
        {
            var regRepetidas = db.Regiaos.Select(re => new { re.Nome }).Distinct().OrderBy(re => re.Nome);

            int contagem = 0;

            foreach (var item in regRepetidas)
            {
                if (textBoxNome == item.Nome)
                {
                    contagem += 1;
                    break;
                }
                
            }
            return contagem;
        }

        public static int eliminar(int id, bool Activo, string ocultar = "sim")
        {
            try
            {
                int confirm = MetodosVinhos.confirmarComListaVinhos(id, "regiao");

                if (Activo == false && confirm == 0)
                {
                    if (ocultar == "sim")
                        MetodosRegioes.deleteRegiao(id, "f");
                    else
                        MetodosRegioes.deleteRegiao(id);
                }
                else
                {
                    return 1;
                }

            }
            catch (Exception)
            {
                return 2;
            }

            return 0;
        }
    }
}
