using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov07thWSAD2ProductCart
{
    public class Cart
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public bool Buy { get; set; }
        public string UserName { get; set; }
    }
}
