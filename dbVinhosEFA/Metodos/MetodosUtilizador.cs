using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using dbVinhosEFA;

namespace dbVinhosEFA.Metodos
{
    public static class MetodosUtilizador
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();

        public static void insertUtilizador(Utilizador u)
        {
            db.Utilizadors.Add(u);
            db.SaveChanges();
        }

        public static void updateUtilizador(Utilizador u)
        {

            Utilizador usr = db.Utilizadors.Find(u.Id);
            usr.Nome = u.Nome;
            usr.Email = u.Email;
            usr.DataNascimento = u.DataNascimento;
            usr.UserID = u.UserID;
            db.SaveChanges();
        }

        public static void deleteUtilizador(int Id)
        {
            Utilizador usr = db.Utilizadors.Find(Id);
            db.Utilizadors.Remove(usr);
            db.SaveChanges();
        }

        public static int dadosUser(string UserId, out string admin)
        {
            var usr = db.Utilizadors.Where(u => u.UserID == UserId).Select(u => new
            {
                u.Id,
                u.Nome,
                u.Email,
            }).FirstOrDefault();

            if (usr.Email.ToLower().Contains("admin"))
            {
                admin = "ok";
                return usr.Id;
            }
            else
            {
                admin = "";
                return usr.Id;
            }

        }

        public static void dadosUserPreencher(int idUser, TextBox nome, TextBox email, TextBox dataNascimento)
        {
            var usr = db.Utilizadors.Where(u => u.Id == idUser).Select(u => new
            {
                u.Id,
                u.Nome,
                u.Email,
                u.DataNascimento
            }).FirstOrDefault();

            
            nome.Text = usr.Nome;
            email.Text = usr.Email;
            dataNascimento.Text = usr.DataNascimento.ToString().Substring(0, 10);

        }

        public static string nomeUtilizadorPorId(int id)
        {
            var usr = db.Utilizadors.Where(u => u.Id == id).Select(u => u.Nome).FirstOrDefault();
            
            return usr.ToString();
        }

    }
}
