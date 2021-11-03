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
    public partial class formListaVinhoEnologos : Form
    {
        public formListaVinhoEnologos()
        {
            InitializeComponent();
        }
        public formListaVinhoEnologos(int idVinhoRec):this()
        {
            idVinho = idVinhoRec;
        }

        internal int idVinho;

        VinhosEFAEntities db = new VinhosEFAEntities();

        void getVinhoEnologos()
        {
            var ve = db.Enologoes.Join(db.VinhoEnologoes, e => e.Id, v => v.Enologo,
                (e, v) => new
                {
                    e.Id,
                    e.Nome,
                    ID = v.Vinho
                }).Where(e => e.ID == idVinho);

            listBoxVinhosEnologos.DataSource = ve.ToList();
            listBoxVinhosEnologos.ValueMember = "Id";
            listBoxVinhosEnologos.DisplayMember = "Nome";
        }

        private void formListaVinhoEnologos_Load(object sender, EventArgs e)
        {
            getVinhoEnologos();
        }

        private void buttonDissociarEnologos_Click(object sender, EventArgs e)
        {
            if (buttonDissociarEnologos.Text.Contains("Dissociar Enologo"))
            {
                db.usp_DissociarCastas(idVinho, listBoxVinhosEnologos.SelectedValue.ToString());
            }
            getVinhoEnologos();
        }

        private void listBoxVinhosEnologos_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxEnologoEscolhido.Text = listBoxVinhosEnologos.Text.ToString();
        }
    }
}
