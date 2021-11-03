using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVinhos
{
    public static class Funcoes
    {
        public static void Clean(Control controlo)
        {
            foreach (Control item in controlo.Controls)
            {
                if (item is TextBox)
                {
                    TextBox t = (TextBox)item;
                    t.Text = "";
                }
                if (item is DropDownList)
                {
                    DropDownList c = (DropDownList)item;
                    c.SelectedIndex = -1;
                }
                if (item is ListBox)
                {
                    ListBox l = (ListBox)item;
                    l.Items.Clear();
                }
                if (item is CheckBox)
                {
                    CheckBox c = (CheckBox)item;
                    c.Checked = false;
                }
            }
        }

        public static bool campoActivo(CheckBox CheckBoxActivar)
        {
            if (CheckBoxActivar.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void checkBoxChanged(CheckBox CheckBoxActivar)
        {
            if (CheckBoxActivar.Checked == true)
            {
                Funcoes.mudarCheckBox(CheckBoxActivar, true);
            }
            else
            {
                Funcoes.mudarCheckBox(CheckBoxActivar, false);
            }
        }
        public static void mudarCheckBox(CheckBox CheckBoxActivar, bool activo)
        {
            if (activo == true)
            {
                CheckBoxActivar.Checked = true;
                CheckBoxActivar.Text = "Desactivada a possibilidade de eliminar";
            }
            if (activo == false)
            {
                CheckBoxActivar.Checked = false;
                CheckBoxActivar.Text = "Activada a possibilidade de eliminar";
            }
        }

        public static bool valorActivo(GridView gridViewNome, int cell)
        {
            bool activo = false;
            Control c = gridViewNome.SelectedRow.Cells[cell].Controls[0];

            if (c != null)
            {
                CheckBox ch = (CheckBox)c;
                activo = ch.Checked;
            }

            return activo;
        }

        public static bool mudarCorValorActivo(GridViewRowEventArgs e, int cell)
        {
            Control c = e.Row.Cells[cell].Controls[0];
            bool res = false;

            if (c != null && c is CheckBox)
            {
                CheckBox ch = (CheckBox)c;

                if (ch.Checked)
                    res = true;
                else
                    res = false;
            }

            return res;
            
        }


        public static void Message(string titulo, string mensagem, Control nomeClass)
        {
            ScriptManager.RegisterClientScriptBlock
                (nomeClass, nomeClass.GetType(), titulo, "alert('" + mensagem + "')", true);
        }

    }
}