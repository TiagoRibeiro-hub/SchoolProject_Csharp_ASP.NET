using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVinhos
{
    public static class funcoes
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
                if (item is RichTextBox)
                {
                    RichTextBox t = (RichTextBox)item;
                    t.Text = "";
                }
                if (item is MaskedTextBox)
                {
                    MaskedTextBox t = (MaskedTextBox)item;
                    t.Text = "";
                }
                if (item is ComboBox)
                {
                    ComboBox c = (ComboBox)item;
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
                if (item is RadioButton)
                {
                    RadioButton r = (RadioButton)item;
                    r.Checked = false;
                }
                if (item is DataGridView)
                {
                    DataGridView d = (DataGridView)item;
                    d.ClearSelection();
                }
            }
        }

        public static void cbOption(CheckBox checkBoxActivar)
        {
            if (checkBoxActivar.Checked == true)
            {
                checkBoxActivar.Text = "Activado";
            }
            if (checkBoxActivar.Checked == false)
            {
                checkBoxActivar.Text = "Desactivado";
            }
        }

    }

    public static class funcoesRetorno
    {
        public static bool activar(CheckBox checkBoxActivar)
        {
            if (checkBoxActivar.Checked == true)
            {
                return false;
            }
            return true;
        }

        public static int obrigatorioPreencher(TextBox textBoxnome, ErrorProvider erros, int confirm)
        {
            if (textBoxnome.Text == "")
            {
                erros.SetError(textBoxnome, "Obrigatório");
                confirm += 1;
            }
            return confirm;
        }

        public static int obrigatorioPreencherMaskedTextBox(MaskedTextBox maskedTextBox, ErrorProvider erros, int confirm)
        {
            if (maskedTextBox.Text == "" || maskedTextBox.Text == "____-___")
            {
                erros.SetError(maskedTextBox, "Obrigatório");
                confirm += 1;
            }
            return confirm;
        }

        public static int obrigatorioPreencherComboBox(ComboBox comboBox, ErrorProvider erros, int confirm)
        {
            if (comboBox.SelectedIndex == -1)
            {
                erros.SetError(comboBox, "Escolha um Produtor");
                confirm += 1;
            }
            return confirm;
        }

        public static int obrigatorioPreencherListBox(ListBox listBox, ErrorProvider erros, int confirm, ComboBox comboBox)
        {
            if (listBox.Items.Count == 0)
            {
                erros.SetError(comboBox, "Associe pelo menos uma Casta");
                confirm += 1;
            }
            return confirm;
        }

    }
}
