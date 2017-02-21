using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov18thAWSAD
{
    public class Language
    {
        public string Name { get; set; }
        public string Locale { get; set; }
        public Language()
        {
            Name = "English";
            Locale = "en-US";
        }
    }
}
