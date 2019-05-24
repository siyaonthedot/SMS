using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using SMS.Services.ServiceHosts;

namespace SM.ConsoleHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            var acmeServiceHost = new SMSServiceHost("127.0.0.1", 67);
            var acmeServiceHostThread = new Thread(acmeServiceHost.Initialize);
            acmeServiceHostThread.Start();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Service Started");
            Console.ReadLine();
        }
    }
}
