using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov2ndWSAD2
{
    class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }

        public Contact()
        {
            this.Image = "ms-appx:///Assets/empty-profile.png";
        }
    }
}
