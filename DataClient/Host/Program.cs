using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create new Host of ServiceLibrary
            ServiceHost serviceHost = new ServiceHost(typeof(Getter)); 


            serviceHost.Open(); //Open ServiceHost
            Console.WriteLine("Service available at http://localhost:8744/WCF/Getter/");
            Console.WriteLine("Service running. Please 'Enter' to exit...");
            Console.ReadLine();
        }
    }
}
