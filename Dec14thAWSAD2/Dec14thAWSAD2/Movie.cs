using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec14thAWSAD2
{
    public class Movie
    {
        public string Title { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }

        private string _poster;

        public string Poster
        {
            get { return _poster; }
            set { _poster = value; }
        }
        
    }
}
