using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCF.Service1)))
            {
                host.Open();
                Console.WriteLine("Service is gestart.");
                Console.ReadLine();
            }
                       
        }
    }
}
