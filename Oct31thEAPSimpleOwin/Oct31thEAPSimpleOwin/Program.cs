using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Owin.Hosting;
namespace Oct31thEAPSimpleOwin
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApp.Start<Startup>("http://localhost:9000/");
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost:9000/api/StringConvert/");
            Console.WriteLine(result.Result);
            Console.WriteLine(result.Result.Content.ReadAsStringAsync().Result);
            result = client.GetAsync("http://localhost:9000/api/StringConvert/Thang");
            Console.WriteLine(result.Result);
            Console.WriteLine(result.Result.Content.ReadAsStringAsync().Result);
            result = client.GetAsync("http://localhost:9000/api/ListStudent/");
            Console.WriteLine(result.Result);
            Console.WriteLine(result.Result.Content.ReadAsStringAsync().Result);
            result = client.GetAsync("http://localhost:9000/api/ListStudent/3");
            Console.WriteLine(result.Result);
            Console.WriteLine(result.Result.Content.ReadAsStringAsync().Result);
            result = client.GetAsync("http://localhost:9000/api/Movies/");
            Console.WriteLine(result.Result);
            Console.WriteLine(result.Result.Content.ReadAsStringAsync().Result);
            result = client.GetAsync("http://localhost:9000/api/Movies/Ava");
            Console.WriteLine(result.Result);
            Console.WriteLine(result.Result.Content.ReadAsStringAsync().Result);
            Console.ReadLine();
        }
    }
}
