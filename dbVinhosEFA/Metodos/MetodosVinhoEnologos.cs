using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbVinhosEFA.Metodos
{
    public static class MetodosVinhoEnologos
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();

        public static void dissociarEnologos(int id, string selectedItem)
        {
            var ve = db.Enologoes.Join(db.VinhoEnologoes, eno => eno.Id, v => v.Enologo,
                   (eno, v) => new
                   {
                       eno.Id,
                       eno.Nome,
                       ID = v.Vinho
                   }).Where(eno => eno.ID == id && eno.Nome == selectedItem);

            foreach (var item in ve.ToList())
            {
                db.usp_DissociarEnologo(item.ID, item.Id.ToString());
            }
        }

        public static void deleteVinhoEnologos(int Id)
        {
            var ve = db.VinhoEnologoes.Select(ev => new
            {
                ev.Vinho,
                ev.Enologo
            }).Where(ev => ev.Vinho == Id);

            foreach (var item in ve.ToList())
            {
                db.usp_DissociarEnologo(Id, item.Enologo.ToString());
            }
        }

        public static int vinhoEnologosLista(int id)
        {
            var en = db.VinhoEnologoes.Select(e => new
            {
                e.Enologo
            }).Where(e => e.Enologo == id);

            int confirm = 0;

            if (en.ToList().Count != 0) confirm += 1;

            return confirm;
        }

    }
}
