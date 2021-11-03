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
    public partial class formListaCastacs : Form
    {
        public formListaCastacs()
        {
            InitializeComponent();
        }

        public formListaCastacs(int idVinhoRec):this()
        {
            idVinho = idVinhoRec;
        }

        public string mudarNomeBtn
        {
            set { buttonDissociarCastas.Text = value; }
        }


        internal int idVinho;

        VinhosEFAEntities db = new VinhosEFAEntities();
        
        void getVinhoCastas()
        {
            var vc = from c in db.Castas
                     join v in db.VinhoCastas on c.Id equals v.Casta
                     where v.Vinho == idVinho
                     select new
                     {
                         c.Id,
                         c.Nome
                     };

            listBoxVinhoCasta.DataSource = vc.ToList();
            listBoxVinhoCasta.ValueMember = "Id";
            listBoxVinhoCasta.DisplayMember = "Nome";

        }

        private void formListaCastacs_Load(object sender, EventArgs e)
        {
            getVinhoCastas();
        }

        private void listBoxVinhoCasta_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxCastaEscolhida.Text = listBoxVinhoCasta.Text.ToString();
        }

        private void buttonDissociarCastas_Click(object sender, EventArgs e)
        {
            if(buttonDissociarCastas.Text.Contains("Dissociar Castas"))
            {
                db.usp_DissociarCastas(idVinho, listBoxVinhoCasta.SelectedValue.ToString());
            }
            getVinhoCastas();


        }

    }
}
