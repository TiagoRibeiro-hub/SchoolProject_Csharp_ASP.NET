using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using dbVinhosEFA;

namespace dbVinhosEFA.Metodos
{
    public static class MetodosCastas
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();

        public static void insertCastas(Casta c)
        {
            db.Castas.Add(c);
            db.SaveChanges();
        }

        public static void updateCastas(Casta c)
        {

            Casta ca = db.Castas.Find(c.Id);
            ca.Nome = c.Nome;
            ca.Caracteristicas = c.Caracteristicas;
            ca.TipoVinho = c.TipoVinho;
            ca.Activo = c.Activo;

            db.SaveChanges();
        }

        public static void deleteCastas(int Id, string op = "op")
        {
            Casta ca = db.Castas.Find(Id);
            if (op.Equals("f"))
                ca.Activo = false;
            else
                db.Castas.Remove(ca);

            db.SaveChanges();
        }

        public static void getCastas(DataGridView dataGridCastas = null, GridView GridCastas = null)
        {
            var ca = db.Castas.Join(db.TipoVinhoes,
                c => c.TipoVinho,
                t => t.Id,
                (c, t) => new
                {
                    ID_C = c.Id,
                    Nome = c.Nome,
                    Caracteristica = c.Caracteristicas,
                    ID_TV = t.Id,
                    TipoVinho = t.Nome,
                    EliminarC = c.Activo,
                    EliminarTV = t.Activo
                }).OrderBy(c => c.Nome);

            if (GridCastas == null)
            {
                dataGridCastas.DataSource = ca.ToList();

                dataGridCastas.Columns[0].Visible = false;
                dataGridCastas.Columns[1].HeaderText = "Nome";
                dataGridCastas.Columns[2].HeaderText = "Caracteristica";
                dataGridCastas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridCastas.Columns[3].Visible = false;
                dataGridCastas.Columns[4].HeaderText = "Tipo de Vinho";
                dataGridCastas.Columns[5].Visible = false;
                dataGridCastas.Columns[6].Visible = false;
            }


            if (dataGridCastas == null)
            {
                GridCastas.DataSource = ca.ToList();
                GridCastas.DataBind();
            }


        }

        public static int castasRepetidas(string valorComparar, string op = "castas")
        {
            var caRepetido = db.Castas.Select(ca => new { ca.Nome, ca.TipoVinho });

            int contagem = 0;

            if(op == "castas")
            {
                foreach (var item in caRepetido)
                {
                    if (valorComparar == item.Nome)
                    {
                        contagem += 1;
                        break;
                    }
                }
            } 

            if (op == "tipoVinho")
            {
                foreach (var item in caRepetido)
                {
                    if (valorComparar == item.TipoVinho.ToString())
                    {
                        contagem += 1;
                        break;
                    }
                }
            }

            return contagem;

        }

        public static int eliminar(int idCasta, bool Activo, string ocultar = "sim")
        {
            try
            {
                int confirmCastas = MetodosVinhoCastas.compararCastasAssoc(idCasta);

                if (Activo == false && confirmCastas == 0)
                {
                    if (ocultar == "sim")
                        deleteCastas(idCasta, "f");
                    else
                        deleteCastas(idCasta);
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
