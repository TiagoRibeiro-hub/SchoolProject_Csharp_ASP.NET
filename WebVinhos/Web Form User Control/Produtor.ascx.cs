using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libraryValidacoes;

namespace WebVinhos
{
    public partial class Endereco : System.Web.UI.UserControl
    {   
        // TITULO
        public string labelTitulo
        {
            get { return LabelTitulo.Text; }
            set { LabelTitulo.Text = value; }
        }

        // ZONA NOME
        public string labelNome
        {
            get { return LabelNome.Text; }
            set { LabelNome.Text = value; }
        }

        public string textBoxNome
        {
            get {return TextBoxNome.Text; }
            set { TextBoxNome.Text = value; }
        }

        // ZONA MORADA

        public string labelMorada
        {
            get { return LabelMorada.Text; }
            set { LabelMorada.Text = value; }
        }

        public string textBoxMorada
        {
            get { return TextBoxMorada.Text; }
            set { TextBoxMorada.Text = value; }
        }

        // ZONA LOCALIDADE

        public string labelLocalidade
        {
            get { return LabelLocalidade.Text; }
            set { LabelLocalidade.Text = value; }
        }

        public string textBoxLocalidade
        {
            get { return TextBoxLocalidade.Text; }
            set { TextBoxLocalidade.Text = value; }
        }

        // ZONA CODIGO POSTAL

        public string labelCodigoPostal
        {
            get { return LabelCodigoPostal.Text; }
            set { LabelCodigoPostal.Text = value; }
        }

        public string textBoxCodigoPostal
        {
            get { return TextBoxCodigoPostal.Text; }
            set { TextBoxCodigoPostal.Text = value; }
        }

        // ZONA TELEMOVEL
        public string labelTelemovel
        {
            get { return LabelTelemovel.Text; }
            set { LabelTelemovel.Text = value; }
        }

        public string textBoxTelemovel
        {
            get { return TextBoxTelemovel.Text; }
            set { TextBoxTelemovel.Text = value; }
        }

        // ZONA EMAIL

        public string labelEmail
        {
            get { return LabelEmail.Text; }
            set { LabelEmail.Text = value; }
        }

        public string textBoxEmail
        {
            get { return TextBoxEmail.Text; }
            set { TextBoxEmail.Text = value; }
        }


        //////////////
        protected void Page_Load(object sender, EventArgs e)
        {
              
        }
    }
}