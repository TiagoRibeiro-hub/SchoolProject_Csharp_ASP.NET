using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace dbVinhosEFA.Metodos
{
    public static class MetodosProdutores
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();

        public static void insertProdutor(Produtor p)
        {
            db.Produtors.Add(p);
            db.SaveChanges();
        }

        public static void updateProdutor(Produtor p)
        {
            Produtor pr = db.Produtors.Find(p.Id);
            pr.Nome = p.Nome;
            pr.Morada = p.Morada;
            pr.CodigoPostal = p.CodigoPostal;
            pr.Localidade = p.Localidade;
            pr.Telefone = p.Telefone;
            pr.Email = p.Email;
            pr.Activo = p.Activo;
            pr.URL = p.URL;
            db.SaveChanges();
        }

        public static void deleteProdutor(int Id, string op ="op")
        {
            Produtor pr = db.Produtors.Find(Id);

            if (op.Equals("f"))
                pr.Activo = false;
            else
                db.Produtors.Remove(pr);
            db.SaveChanges();
        }

        public static void getProdutores(DataGridView dataGridProdutores = null, GridView GridProdutores = null)
        {
            var pr = db.Produtors.Select(p => new
            {
                ID = p.Id,
                Nome = p.Nome,
                Morada = p.Morada,
                CodigoPostal = p.CodigoPostal,
                Localidade = p.Localidade,
                Telefone = p.Telefone,
                Email = p.Email,
                ActivoP = p.Activo,
            }).OrderBy(p => p.Nome);

            if(GridProdutores is null)
            {
                var prt = pr.ToList().Select(p => p.ActivoP).Where(p => p.Equals(true));

                dataGridProdutores.DataSource = prt.ToList();

                dataGridProdutores.Columns[0].Visible = false;
                dataGridProdutores.Columns[1].HeaderText = "Nome";
                dataGridProdutores.Columns[2].HeaderText = "Morada";
                dataGridProdutores.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridProdutores.Columns[3].HeaderText = "Codigo-Postal";
                dataGridProdutores.Columns[4].HeaderText = "Localidade";
                dataGridProdutores.Columns[5].HeaderText = "Telefone";
                dataGridProdutores.Columns[6].HeaderText = "Email";
                dataGridProdutores.Columns[7].Visible = false; ;
            }

            if (dataGridProdutores is null)
            {
                GridProdutores.DataSource = pr.ToList();
                GridProdutores.DataBind();
            }
        }


        public static int produtoresRepetidos(string textBoxNome)
        {
            var prodRepetidos = db.Produtors.Select(pr => new { pr.Nome }).Distinct().OrderBy(pr => pr.Nome);

            int contagem = 0;

            foreach (var item in prodRepetidos)
            {
                if (textBoxNome == item.Nome)
                {
                    contagem += 1;
                    break;
                }
            }
            return contagem;
        }

        public static int eliminar(int id, bool Activo, int confirm, string ocultar = "sim")
        {
            try
            {             
                if (Activo == false && confirm == 0)
                {
                    if (ocultar == "sim")
                        deleteProdutor(id, "f");
                    else
                        deleteProdutor(id);
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
