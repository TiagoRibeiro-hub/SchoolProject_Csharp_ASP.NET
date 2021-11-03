using dbVinhosEFA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVinhos
{
    public partial class formListaProdutores : Form
    {
        public formListaProdutores()
        {
            InitializeComponent();
        }
        VinhosEFAEntities db = new VinhosEFAEntities();

        void getProdutores()
        {
            var pr = db.Produtors.Select(p => new
            {
                ID = p.Id,
                Nome = p.Nome,
                p.Activo
            }).Distinct().Where(p => p.Activo == true).OrderBy(p => p.Nome);

            listBoxProdutores.DataSource = pr.ToList();
            listBoxProdutores.ValueMember = "Id";
            listBoxProdutores.DisplayMember = "Nome";

        }
        private void formListaProdutores_Load(object sender, EventArgs e)
        {
            getProdutores();
        }

        private void buttonEscolher_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
