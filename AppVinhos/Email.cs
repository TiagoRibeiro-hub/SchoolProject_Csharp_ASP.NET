using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVinhos
{
    class Email
    {
        public string email { get; set; }
        public string did_you_mean { get; set; }
        public string user { get; set; }
        public string domain { get; set; }
        public bool format_valid { get; set; }
        public object mx_found { get; set; }
        public object smtp_check { get; set; }
        public object catch_all { get; set; }
        public bool role { get; set; }
        public bool disposable { get; set; }
        public bool free { get; set; }
        public double score { get; set; }

    }
}
