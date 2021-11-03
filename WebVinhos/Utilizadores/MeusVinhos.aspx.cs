using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVinhos.Utilizadores
{
    public partial class MeusVinhos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
                Response.Redirect("~/Admin/Formularios.aspx");
        }

        protected void ButtonInseriri_Click(object sender, EventArgs e)
        {
            Session["id_vinho"] = 0;
            Session["oQue"] = "Inserir";
            Response.Redirect("InseririNovoVinho.aspx");
        }
    }
}