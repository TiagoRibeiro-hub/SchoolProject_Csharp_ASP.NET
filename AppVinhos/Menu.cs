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
using Application = System.Windows.Forms.Application;

namespace AppVinhos
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.Top = 30;
            this.Left = 130;
            Height = 750;
            Width = 1250;
        }
        private void vinhosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(formVinhos))
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Activate();
                    return;
                }
            }
            Form formVinhos = new formVinhos();
            formVinhos.MdiParent = this;
            formVinhos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formVinhos.Show();
            formVinhos.Top = 0;
            formVinhos.Left = 0;
        }

        private void produtoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(formProdutores))
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Activate();
                    return;
                }
            }
            Form formProdutores = new formProdutores();
            formProdutores.MdiParent = this;
            formProdutores.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formProdutores.Show();
            formProdutores.Top = 0;
            formProdutores.Left = 0;
        }

        private void regiõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(formRegioes))
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Activate();
                    return;
                }
            }
            Form formRegioes = new formRegioes();
            formRegioes.MdiParent = this;
            formRegioes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formRegioes.Show();
            formRegioes.Top = 0;
            formRegioes.Left = 0;
        }

        private void castasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(formCastas))
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Activate();
                    return;
                }
            }
            Form formCastas = new formCastas();
            formCastas.MdiParent = this;
            formCastas.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formCastas.Show();
            formCastas.Top = 0;
            formCastas.Left = 0;
        }

        private void enologosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(formEnologos))
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Activate();
                    return;
                }
            }
            Form formEnologos = new formEnologos();
            formEnologos.MdiParent = this;
            formEnologos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formEnologos.Show();
            formEnologos.Top = 0;
            formEnologos.Left = 0;
        }

        //////LISTAS
        private void produtoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(formListaProdutores))
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Activate();
                    return;
                }
            }
            Form formListaProdutores = new formListaProdutores();
            formListaProdutores.MdiParent = this;
            formListaProdutores.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formListaProdutores.Show();
            formListaProdutores.Top = 0;
            formListaProdutores.Left = 0;
        }
        private void tiposDeVinhosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(formTiposDeVinhos))
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Activate();
                    return;
                }
            }
            Form formTiposDeVinhos = new formTiposDeVinhos();
            formTiposDeVinhos.MdiParent = this;
            formTiposDeVinhos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formTiposDeVinhos.Show();
            formTiposDeVinhos.Top = 0;
            formTiposDeVinhos.Left = 0;
        }
        private void castasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(formListaVinhoCastas))
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Activate();
                    return;
                }
            }
            Form formListaVinhoCastas = new formListaVinhoCastas();
            formListaVinhoCastas.MdiParent = this;
            formListaVinhoCastas.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formListaVinhoCastas.Show();
            formListaVinhoCastas.Top = 0;
            formListaVinhoCastas.Left = 0;
        }

        private void enologosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(formListaVinhosEnologos))
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }
                    f.Activate();
                    return;
                }
            }
            Form formListaVinhosEnologos = new formListaVinhosEnologos();
            formListaVinhosEnologos.MdiParent = this;
            formListaVinhosEnologos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            formListaVinhosEnologos.Show();
            formListaVinhosEnologos.Top = 0;
            formListaVinhosEnologos.Left = 0;
        }


        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que quer sair?", "SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
                
        }


    }
}
