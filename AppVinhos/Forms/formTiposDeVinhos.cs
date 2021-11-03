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
    public partial class formTiposDeVinhos : Form
    {
        public formTiposDeVinhos()
        {
            InitializeComponent();
        }

        public string tipoVinhoEscolhido
        {
            get { return textBoxVinhoEscolhido.Text.ToString(); }
        }

        public string btnEscolher 
        {
            set { buttonEscolher.Text = value;}
        }
        public bool tbEscolher 
        {
            set {textBoxVinhoEscolhido.Visible = value; } 
        }
        public bool lbescolher
        {
            set { labelEscolherVinho.Visible = value; }
        }

        VinhosEFAEntities db = new VinhosEFAEntities();
        void getTipoVinhos()
        {
            MetodosTipoDeVinho.getTipoVinhos(listBoxTipoVinhos, null, null);
        }
        private void formTiposDeVinhos_Load(object sender, EventArgs e)
        {
            getTipoVinhos();
        }

        private void listBoxTipoVinhos_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxVinhoEscolhido.Text = listBoxTipoVinhos.Text.ToString();
        }

        private void buttonEscolher_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
