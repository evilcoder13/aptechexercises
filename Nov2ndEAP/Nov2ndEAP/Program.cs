using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Nov2ndEAP
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApp.Start<Startup>("http://localhost:9000/");

            HttpClient client = new HttpClient();
            Console.WriteLine(client.GetStringAsync("http://localhost:9000/api/TaskClss").Result);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(client.GetStringAsync("http://localhost:9000/api/TaskClss/1").Result);
            Timer t = new Timer(3000);
            t.Elapsed += t_Elapsed;
            t.Start();
            Console.ReadLine();
        }

        static void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            HttpClient client = new HttpClient();
            Console.Clear();
            Console.WriteLine(client.GetStringAsync("http://localhost:9000/api/TaskClss").Result);
        }
    }
}
