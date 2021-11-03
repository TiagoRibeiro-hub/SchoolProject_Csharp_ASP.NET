using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVinhos
{
    public partial class alterar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Registo.labelTitulo_ = "Alterar";
            Registo.buttonRegAlt_ = "Alterar";
        }

    }
}