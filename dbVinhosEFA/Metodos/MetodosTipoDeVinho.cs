using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace dbVinhosEFA.Metodos
{
    public static class MetodosTipoDeVinho
    {
        static VinhosEFAEntities db = new VinhosEFAEntities();



        public static void insertTipoDeVinho(TipoVinho tv)
        {
            db.TipoVinhoes.Add(tv);
            db.SaveChanges();
        }

        public static void updateTipoDeVinho(TipoVinho tv)
        {
            TipoVinho v = db.TipoVinhoes.Find(tv.Id);
            v.Nome = tv.Nome;
            v.Activo = tv.Activo;
            db.SaveChanges();
        }

        public static void deleteTipoDeVinho(int id, string op = "op")
        {
            TipoVinho v = db.TipoVinhoes.Find(id);
            if (op.Equals("f"))
                v.Activo = false;
            else
                db.TipoVinhoes.Remove(v);
            db.SaveChanges();
        }

        public static void getTipoVinhos(System.Windows.Forms.ListBox listBoxTipoVinhos = null, GridView GridTipoVinhos = null, DropDownList dropDownListTipoVinhos = null)
        {
            var tv = db.TipoVinhoes.Select(v => new
            {
                v.Id,
                v.Nome,
                v.Activo
            }).Distinct().OrderBy(v => v.Nome);


            if (GridTipoVinhos is null && dropDownListTipoVinhos is null)
            {
                var tvt = tv.ToList().Select(v => v.Activo).Where(v => v.Equals(true));
                listBoxTipoVinhos.DataSource = tvt.ToList();
                listBoxTipoVinhos.ValueMember = "Id";
                listBoxTipoVinhos.DisplayMember = "Nome";
            }

            if (GridTipoVinhos is null && listBoxTipoVinhos is null)
            {
                dropDownListTipoVinhos.DataSource = tv.ToList();
                dropDownListTipoVinhos.DataValueField = "Id";
                dropDownListTipoVinhos.DataTextField = "Nome";
                dropDownListTipoVinhos.SelectedIndex = -1;
                dropDownListTipoVinhos.DataBind();
            }

            if (dropDownListTipoVinhos is null && listBoxTipoVinhos is null)
            {
                GridTipoVinhos.DataSource = tv.ToList();
                GridTipoVinhos.DataBind();
            }


        }

        public static int tipoVinhosRepetidos(string nomeVinho, out int id)
        {
            var tvRepetidos = db.TipoVinhoes.Select(t => new
            {
                ID = t.Id,
                Nome = t.Nome,
            }).Where(t => t.Nome == nomeVinho);

            int contagem = 0, idTemp = 0;

            if(tvRepetidos.ToList().Count != 0)
            {
                foreach (var item in tvRepetidos)
                {
                    idTemp = item.ID;
                    contagem += 1;
                }
            }
 
            id = idTemp;
            return contagem;
        }

        public static int tipoVinhoLista(int id = -1)
        {
            var tp = db.TipoVinhoes.Select(v => new
            {
                v.Id,
                v.Activo
            });

            int confirm = 0;

            if(id == -1)
            {
                var tpvActivo = tp.Select(v => v.Activo).Where(v => v == true);

                if (tpvActivo.ToList().Count != 0) confirm += 1;
            }
            else
            {
                var tpvById = tp.Select(v => v.Id).Where(v => v == id);

                if (tpvById.ToList().Count != 0) confirm += 1;
            }
            

            return confirm;
        }

        public static int eliminar(int id, bool Activo, string ocultar = "sim")
        {
            try
            {
                int confirm = MetodosCastas.castasRepetidas(id.ToString(), "tipoVinho");

                if (Activo == false && confirm == 0)
                {
                    if (ocultar == "sim")
                        MetodosTipoDeVinho.deleteTipoDeVinho(id, "f");
                    else
                        MetodosTipoDeVinho.deleteTipoDeVinho(id);
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
