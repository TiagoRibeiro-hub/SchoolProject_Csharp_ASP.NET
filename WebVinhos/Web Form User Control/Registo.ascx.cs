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
using Newtonsoft.Json;
using System.IO;
using System.Net;
using WebVinhos.Web_Form_User_Control;

namespace WebVinhos
{
    public partial class Registo : System.Web.UI.UserControl
    {

        #region PROPRIEDADES
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

        // ZONA EMAIL

        public string labelEmail_
        {
            get { return LabelEmail.Text; }
            set { LabelEmail.Text = value; }
        }

        public string textBoxEmail_
        {
            get { return TextBoxEmail.Text; }
            set { TextBoxEmail.Text = value; }
        }

        // DATA DE NASCIMENTO
        public string labelDataNascimento_
        {
            get { return LabelDataNascimento.Text; }
            set { LabelDataNascimento.Text = value; }
        }

        public string textBoxDataNascimento_
        {
            get { return TextBoxDataNascimento.Text; }
            set { TextBoxDataNascimento.Text = value; }
        }

        // PASSWORD
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

        // REPEAT PASSWORD
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

        public string buttonRegAlt_
        {
            get { return Button1.Text; }
            set { Button1.Text = value; }
        }

        #endregion

        VinhosEFAEntities db = new VinhosEFAEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LabelTitulo.Text.Equals("Alterar"))
                {
                    TextBoxPassword.Enabled = false;
                    TextBoxRepeatPassword.Enabled = false;
                    ButtonAlterarPass.Visible = true;
                    CompareValidator1.Enabled = false;
                    RequiredFieldValidatorPassword.Enabled = false;
                    RequiredFieldValidatorRepeatPassword.Enabled = false;
                    MetodosUtilizador.dadosUserPreencher((int)Session["id_utilizador"], TextBoxNome, TextBoxEmail, TextBoxDataNascimento);

                }
                string data = DateTime.Now.AddYears(-18).ToShortDateString();
                CompareValidatorMaiorIdade.ErrorMessage = "Tem que ser maior de 18 anos";
                CompareValidatorMaiorIdade.Type = ValidationDataType.Date;
                CompareValidatorMaiorIdade.Operator = ValidationCompareOperator.LessThan;
                CompareValidatorMaiorIdade.ValueToCompare = data;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "Registar")
            {
                try
                {
                    //configurar pedido
                    WebRequest req;

                    req = WebRequest.Create("https://disposable.debounce.io/?email=" + TextBoxEmail.Text);
                    req.ContentType = "application/json";

                    //obter resposta (JSON)
                    WebResponse resp = req.GetResponse();

                    //converter resposta para formato texto (string)
                    Stream strm = resp.GetResponseStream();
                    StreamReader strm_reader = new StreamReader(strm);
                    string json = strm_reader.ReadToEnd();

                    //converter string para objecto
                    EmailTemp dados = JsonConvert.DeserializeObject<EmailTemp>(json);

                    if (dados.disposable == "false")
                    {
                        Membership.CreateUser(TextBoxNome.Text, TextBoxPassword.Text, TextBoxEmail.Text);

                        MembershipUser user = Membership.GetUser(TextBoxNome.Text);
                        object user_id = user.ProviderUserKey;

                        Utilizador usr = new Utilizador();

                        usr.Nome = TextBoxNome.Text;
                        usr.Email = TextBoxEmail.Text;
                        usr.DataNascimento = DateTime.Parse(TextBoxDataNascimento.Text);
                        usr.UserID = user_id.ToString();

                        MetodosUtilizador.insertUtilizador(usr);

                        Response.Redirect("LogIn.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Insira um e-mail válido" + "');</script>");
                    }
                }
                catch (Exception)
                { 
                    Response.Write("<script>alert('" + "Não foi possivel fazer o seu registo!!" + "');</script>");
                }
            }

            if (Button1.Text == "Alterar")
            {
                MembershipUser user = Membership.GetUser(TextBoxNome.Text);
                string user_id = user.ProviderUserKey.ToString();
                Utilizador usr = new Utilizador();

                usr.Id = (int)Session["id_utilizador"];
                usr.Nome = TextBoxNome.Text.ToString();
                usr.Email = TextBoxEmail.Text.ToString();
                usr.DataNascimento = DateTime.Parse(TextBoxDataNascimento.Text.ToString());
                usr.UserID = user_id;

                MetodosUtilizador.updateUtilizador(usr);

                Response.Redirect("~/Admin/Formularios.aspx");
            }

        }

        protected void ButtonAlterarPass_Click(object sender, EventArgs e)
        {
            ChangePassword1.Visible = true;
        }
    }
}