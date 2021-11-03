using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using dbVinhosEFA.Metodos;
using dbVinhosEFA;
using System.Web.Services.Description;
using System.Net.Mail;
using System.Net;

namespace WebVinhos
{
    public partial class LogIn : System.Web.UI.UserControl
    {
        #region Propriedades
        // TITULO
        public string labelTitulo_
        {
            get { return LabelTitulo.Text; }
            set { LabelTitulo.Text = value; }
        }

        // ZONA NOME
        public string labelNome_
        {
            get { return LabelNome.Text; }
            set { LabelNome.Text = value; }
        }

        public string textBoxNome_
        {
            get { return TextBoxNome.Text; }
            set { TextBoxNome.Text = value; }
        }

        // ZONA PASSWORD
        public string labelPassword_
        {
            get { return LabelPassword.Text; }
            set { LabelPassword.Text = value; }
        }

        public string textBoxPassword_
        {
            get { return TextBoxPassword.Text; }
            set { TextBoxPassword.Text = value; }
        }

        // ZONA REPEAT PASSWORD
        public string labelRepeatPassword_
        {
            get { return LabelRepeatPassword.Text; }
            set { LabelRepeatPassword.Text = value; }
        }

        public string textBoxRepeatPassword_
        {
            get { return TextBoxRepeatPassword.Text; }
            set { TextBoxRepeatPassword.Text = value; }
        }

        #endregion

        VinhosEFAEntities db = new VinhosEFAEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipUser user = Membership.GetUser(TextBoxNome.Text);

                if(user != null)
                {
                    FormsAuthentication.SetAuthCookie(TextBoxNome.Text, true);

                    string user_id = user.ProviderUserKey.ToString();

                    int idUsr = MetodosUtilizador.dadosUser(user_id, out string admin);
                    Session["id_utilizador"] = idUsr;

                    if ((int)Session["id_utilizador"] > 0)
                    {
                        if (admin.Equals(""))
                        {
                            Response.Redirect("homePage.aspx");
                        }
                        if (admin.Equals("ok"))
                        {
                            Session["admin"] = "ok";
                            Response.Redirect("~/Admin/Formularios.aspx");
                        }
                    }
                }           
                else
                {
                    Response.Write("<script>alert('" + "Não foi possivel fazer log in!! Já se encontra Registado?" + "');</script>");
                    Response.Redirect("Register.aspx");
                }


            }
            catch (Exception)
            {
                Response.Write("<script>alert('" + "Não foi possivel fazer log in, tente mais tarde!!" + "');</script>");
            }

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser(UserName.Text);

            using (MailMessage mm = new MailMessage("efavinhos21@outlook.pt", user.Email))
            {
                mm.Subject = "Nova password";
                mm.Body = "A sua nova password é ";
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-mail.outlook.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("efavinhos21@outlook.pt", "citeforma21!");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Email enviado.');", true);
            }
        }

        protected void LinkButtonRecuperarPassword_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }
    }
}