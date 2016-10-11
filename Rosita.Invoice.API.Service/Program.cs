using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Rosita.Invoice.API.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
             //.UseContentRoot(Directory.GetCurrentDirectory())
             .UseKestrel()
             .UseStartup<Startup>()
             .Build();

            host.Run();
        }
    }
}
