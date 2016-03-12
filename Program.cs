using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkOwinAuthorizationParseError
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {

                Console.WriteLine("Server started. Make an unauthenticated GET request to {0}", baseAddress);
                Console.WriteLine("Press ENTER to quit.");

                Console.ReadLine();
            }

            
        }
    }
}
