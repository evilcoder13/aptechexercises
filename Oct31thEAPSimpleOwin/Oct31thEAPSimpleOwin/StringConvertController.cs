using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Oct31thEAPSimpleOwin
{
    public class StringConvertController:ApiController
    {
        public string Get()
        {
            return "Hello WOrld!";
        }

        public string Get(string id)
        {
            //id= ABCDEF -> Return FEDCBA
            return "Hello " + string.Join("",id.Reverse());
        }
    }
}
