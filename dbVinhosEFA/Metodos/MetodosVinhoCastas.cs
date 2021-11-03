using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbVinhosEFA.Metodos
{
    public static class MetodosVinhoCastas
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();

        public static void dissociarCastas(int id, string selectedItem)
        {
            var vc = db.Castas.Join(db.VinhoCastas, c => c.Id, v => v.Casta,
                       (c, v) => new
                       {
                           c.Id,
                           c.Nome,
                           ID = v.Vinho
                       }).Where(c => c.ID == id && c.Nome == selectedItem);

            foreach (var item in vc.ToList())
            {
                db.usp_DissociarCastas(item.ID, item.Id.ToString());
            }
        }

        public static void deleteVinhoCastas(int Id)
        {
            var vc = db.VinhoCastas.Select(cv => new
            {
                cv.Vinho,
                cv.Casta
            }).Where(cv => cv.Vinho == Id);

            foreach (var item in vc.ToList())
            {
                db.usp_DissociarCastas(Id, item.Casta.ToString());
            }
        }

        public static int compararCastasAssoc(int idCasta)
        {
            var castas = db.VinhoCastas.Select(c => new
            {
                c.Casta
            }).Where(c => c.Casta == idCasta);

            if (castas.ToList().Count > 0) return 1;
            else return 0;
        }


    }
}
