using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov18thAWSAD
{
    public class LanguageList : List<Language>
    {
        public LanguageList()
        {
            this.Add(new Language() { Name = "English", Locale = "en-US" });
            this.Add(new Language() { Name = "Tiếng Việt", Locale = "vi-VN" });
            this.Add(new Language() { Name = "日本国", Locale = "ja-JP" });
        }
    }
}
