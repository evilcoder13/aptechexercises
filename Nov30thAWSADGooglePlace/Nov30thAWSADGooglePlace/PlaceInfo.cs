using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov30thAWSADGooglePlace
{
    public class PlaceInfo
    {
        public string icon { get; set; }
        public string name { get; set; }
        public string vicinity { get; set; }
        public string[] types { get; set; }
        public string typesC { get { return String.Join(",", types); } }
    }
}
