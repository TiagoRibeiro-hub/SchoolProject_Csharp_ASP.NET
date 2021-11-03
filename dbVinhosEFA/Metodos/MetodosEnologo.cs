using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using dbVinhosEFA.Metodos;

namespace dbVinhosEFA
{
    
    public static class MetodosEnologo
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();

        public static void insertEnologo(Enologo e)
        {
            db.Enologoes.Add(e);
            db.SaveChanges();

        }

        public static void updateEnologo(Enologo e)
        {
            Enologo en = db.Enologoes.Find(e.Id);
            en.Nome = e.Nome;
            en.Instragram = e.Instragram;
            en.Activo = e.Activo;
            db.SaveChanges();
        }

        public static void deleteEnologo(int Id, string op = "op")
        {
            Enologo en = db.Enologoes.Find(Id);

            if (op.Equals("f"))
                en.Activo = false;
            else
                db.Enologoes.Remove(en);
            db.SaveChanges();
        }

        public static void getEnologos(DataGridView dataGridEnologos = null, GridView GridEnologos = null)
        {
            var en = db.Enologoes.Select(e => new
            {
                ID = e.Id,
                Nome = e.Nome,
                Instagram = e.Instragram,
                Eliminar = e.Activo
            }).OrderBy(e => e.Nome);

            if(GridEnologos == null)
            {
                dataGridEnologos.DataSource = en.ToList();

                dataGridEnologos.Columns[0].Visible = false;
                dataGridEnologos.Columns[1].HeaderText = "Nome";
                dataGridEnologos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridEnologos.Columns[2].HeaderText = "Instagram";
                dataGridEnologos.Columns[3].Visible = false;
            }

            if(dataGridEnologos == null)
            {
                GridEnologos.DataSource = en.ToList();
                GridEnologos.DataBind();
            }
            
        }

        public static int enologosRepetidos(string TextBoxNome)
        {
            var enRepetido = db.Enologoes.Select(en => new { en.Nome }).Where(en => en.Equals(TextBoxNome));

            int contagem = 0;

            if(enRepetido.ToList().Count != 0) contagem += 1;

            return contagem;

        }

        public static int eliminar(int id, bool Activo, string ocultar = "sim")
        {
            try
            {
                int confirm = MetodosVinhoEnologos.vinhoEnologosLista(id);

                if (Activo == false && confirm == 0)
                {
                    if (ocultar == "sim")
                        deleteEnologo(id, "f");
                    else
                        deleteEnologo(id);
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
