using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppVinhos;
using dbVinhosEFA;
using dbVinhosEFA.Metodos;

namespace AppVinhos
{
    public partial class formListaVinhoCastas : Form
    {
        public formListaVinhoCastas()
        {
            InitializeComponent();
        }

        VinhosEFAEntities db = new VinhosEFAEntities();

        void getNomeVinhos()
        {
            var nv = db.Vinhoes.Select(v => new
            {
                v.Id,
                v.Nome,
            });

            comboBoxEscolherVinho.DataSource = nv.ToList();
            comboBoxEscolherVinho.ValueMember = "Id";
            comboBoxEscolherVinho.DisplayMember = "Nome";

        }

        private void formListaVinhoCastas_Load(object sender, EventArgs e)
        {
            getNomeVinhos();
            
        }

        private void comboBoxEscolherVinho_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is ListBox)
                {
                    ListBox l = (ListBox)item;
                    l.Items.Clear();
                }
            }

            var vc = from c in db.Castas
                     join v in db.VinhoCastas on c.Id equals v.Casta
                     select new
                     {
                         c.Id,
                         c.Nome,
                         v.Vinho
                     };

            foreach (var item in vc.ToList())
            {
                if (item.Vinho.ToString().Contains(comboBoxEscolherVinho.SelectedValue.ToString()))
                {
                    listBoxVinhoCasta.Items.Add(item.Nome);
                }
            }
        }

    }
}
