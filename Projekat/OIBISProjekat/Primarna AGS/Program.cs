using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Primarna_AGS
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Test)))
            {
                host.Open();
                Console.WriteLine("Servis uspesno pokrenut");
                Console.ReadKey();
            }
        }

        
    }
}
