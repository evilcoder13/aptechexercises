using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct28thWSAD2
{
    public class CalculatorCheck
    {
        public bool afterSign { get; set; }
        public bool afterNumber { get; set; }
        public bool allowClose { get; set; }
        public CalculatorCheck()
        {
            afterSign = true;
            afterNumber = false;
            allowClose = false;
        }
    }
}
