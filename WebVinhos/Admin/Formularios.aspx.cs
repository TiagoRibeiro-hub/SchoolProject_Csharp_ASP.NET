using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVinhos.Admin
{
    public partial class Formularios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        protected void ImageButtonVinhos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("formVinhos.aspx");
        }

        protected void ImageButtonProdutores_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("formProdutores.aspx");
        }

        protected void ImageButtonRegioes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("formRegiao.aspx");
        }

        protected void ImageButtonTipoVinhos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("formTipoVinho.aspx");
        }

        protected void ImageButtonCastas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("formCastas.aspx"); 
        }

        protected void ImageButtonEnologos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("formEnologos.aspx"); 
        }
    }
}