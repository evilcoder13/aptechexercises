using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec2ndWSAD1
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Downloads { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }

    }
}
