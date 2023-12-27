using Common;
using Primarna_AGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Sekundarna_AGS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<ITest2> channelTest = new ChannelFactory<ITest2>("TestSekundarna");
            ITest2 proxyTest = channelTest.CreateChannel();

            string tekst = proxyTest.Proba2();
            Console.WriteLine(tekst);
            Console.Read();
        }
    }
}
