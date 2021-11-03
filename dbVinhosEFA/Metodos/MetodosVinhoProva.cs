using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace dbVinhosEFA.Metodos
{
    public static class MetodosVinhoProva
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();

        public static void insertProva(VinhoProva v)
        {
            db.VinhoProvas.Add(v);
            db.SaveChanges();
        }

        public static void updateProva(VinhoProva v)
        {

            VinhoProva vp = db.VinhoProvas.Find(v.Id);
            vp.Vinho = v.Vinho;
            vp.Utilizador = v.Utilizador;
            vp.Comentario = v.Comentario;
            vp.Classificacao = v.Classificacao;
            db.SaveChanges();
        }

        public static void deleteProva(int Id)
        {
            VinhoProva vp = db.VinhoProvas.Find(Id);
            db.VinhoProvas.Remove(vp);
            db.SaveChanges();
        }


    }
}
