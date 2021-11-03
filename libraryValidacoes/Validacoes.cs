using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace libraryValidacoes
{
    public static class Validacoes
    {   
        //Password - 8 ou mais caracteres

        public static bool ValidarPassword(string Password)
        {
            Regex validar = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$");
            return validar.IsMatch(Password);
        }

        //Só numeros
        public static bool ValidarSoNumeros(string Numero)
        {
            Regex validar = new Regex(@"^(-\d(\.\d|),|\d(\.\d|),|-\d(\.\d|)|\d(\.\d|))+$");
            return validar.IsMatch(Numero);
        }

        //Nomes – permitir apenas letras e espaços;
        public static bool ValidarNome(string Nome)
        {
            Regex validar = new Regex(@"^[a-zA-ZãáàéêíóõúçÃÁÀÉÊÍÓÕÚÇ\s]+$");
            return validar.IsMatch(Nome);
        }

        //Morada – permitir apenas letras, números e espaços;
        public static bool ValidarMorada(string Morada)
        {
            Regex validar = new Regex(@"^[0-9a-zA-ZãáàéêíóõúçÃÁÀÉÊÍÓÕÚÇºª.,\s]+$");
            return validar.IsMatch(Morada);
        }

        //Código postal – permitir apenas dados no formato 0000-000 ou 0000;
        public static bool ValidarCodigoPostal(string CP)
        {
            Regex validar = new Regex(@"^[1-9]\d{3}(-\d{3})?$");
            return validar.IsMatch(CP) && (CP.Length == 8 || CP.Length == 4);
        }

        //Telefone – permitir apenas valores que comecem por 2 ou 3, seguido de 8 dígitos;
        public static bool ValidarTelefone(string telefone)
        {
            Regex validar = new Regex(@"^[2|3]\d{8}");
            return (validar.IsMatch(telefone) && telefone.Length == 9);
        }

        //Telemóvel – permitir apenas valores que comecem por 9, seguido de um dos seguintes dígitos(1, 2, 3 ou 6), seguido de 7 dígitos;
        public static bool ValidarTelemovel(string telemovel)
        {
            Regex validar = new Regex(@"^[9][1|2|3|6]\d{7}");
            return (validar.IsMatch(telemovel) && telemovel.Length == 9);
        }

        //NIF - permitir apenas valores que comecem por um dos seguintes dígitos (1, 2, 3, 4, 5, 6 ou 9), seguido de 8 dígitos;
        public static bool ValidarNIF(string NIF)
        {
            Regex validar = new Regex(@"^[1|2|3|4|5|6|9]\d{8}");
            return (validar.IsMatch(NIF) && NIF.Length == 9);
        }

        //Email – validar o formato;
        public static bool ValidarEmail(string Email)
        {
            Regex validar = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return validar.IsMatch(Email);
        }

        // Data O formato deve ser (YYYY (/ou-) MM (/ou-) DD) ou (DD (/ou-) MM (/ou-) YYYY)
        public static bool ValidarData(string Data)
        {
            Regex validar = new Regex(@"^(\d{4}(/|-)\d{1,2}(/|-)\d{1,2})|(\d{1,2}(/|-)\d{1,2}(/|-)\d{4})$");
            return validar.IsMatch(Data);
        }

    }

}
