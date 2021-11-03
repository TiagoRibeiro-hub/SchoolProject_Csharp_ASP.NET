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
    public partial class formListaRegioes : Form
    {
        public formListaRegioes()
        {
            InitializeComponent();
        }

        public string regiaoEscolhida 
        {
            get { return textBoxRegiaoEscolhida.Text; }
        }
        private void pictureBoxMapaRegioes_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelDao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Dão";
            Close();
        }

        private void linkLabelTavoaVarosa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Tavoa e Varosa";
            Close();
        }

        private void linkLabelPortoDouro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Porto e Douro";
            Close();
        }

        private void linkLabelTrásMontes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Trás-os-Montes";
            Close();
        }

        private void linkLabelBeiraInteriror_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Beira Interior";
            Close();
        }

        private void linkLabelAcores_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Açores";
            Close();
        }

        private void linkLabelAlentejo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Alentejo";
            Close();
        }

        private void linkLabelMadeira_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Madeira";
            Close();
        }

        private void linkLabelAlgarve_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Algarve";
            Close();
        }

        private void linkLabelSetubal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Setubal";
            Close();
        }

        private void linkLabelLisboa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Lisboa";
            Close();
        }

        private void linkLabelTejo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Tejo";
            Close();
        }

        private void linkLabelBairrada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Bairrada";
            Close();
        }

        private void linkLabelVinhoVerde_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxRegiaoEscolhida.Text = "Vinho Verde";
            Close();
        }
    }
}
