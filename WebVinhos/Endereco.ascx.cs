using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        //public string labelMorada 
        //{ 
           
        //}



        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}