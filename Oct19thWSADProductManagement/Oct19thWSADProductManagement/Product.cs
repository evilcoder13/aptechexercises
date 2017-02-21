using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct19thWSADProductManagement
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public Product()
        {
            this.Image = "ms-appx:///Assets/empty-img.png";
        }
    }
}
