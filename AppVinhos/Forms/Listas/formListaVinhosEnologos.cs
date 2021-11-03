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
    public partial class formListaVinhosEnologos : Form
    {
        public formListaVinhosEnologos()
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

            comboBoxEscolherEnologo.DataSource = nv.ToList();
            comboBoxEscolherEnologo.ValueMember = "Id";
            comboBoxEscolherEnologo.DisplayMember = "Nome";

        }

        private void formListaVinhosEnologos_Load(object sender, EventArgs e)
        {
            getNomeVinhos();
        }

        private void comboBoxEscolherEnologo_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is ListBox)
                {
                    ListBox l = (ListBox)item;
                    l.Items.Clear();
                }
            }

            var ve = db.Enologoes.Join(db.VinhoEnologoes, en => en.Id, v => v.Enologo,
               (en, v) => new
               {
                   en.Id,
                   en.Nome,
                   v.Vinho
               });

            foreach (var item in ve.ToList())
            {
                if (item.Vinho.ToString().Contains(comboBoxEscolherEnologo.SelectedValue.ToString()))
                {
                    listBoxVinhosEnologos.Items.Add(item.Nome);
                }
            }

        }

    }
}
