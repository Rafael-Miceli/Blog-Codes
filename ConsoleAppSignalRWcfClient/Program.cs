using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSignalRWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var hubConnection = new HubConnection("http://localhost:61464/");
            IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("MyHub");
            stockTickerHubProxy.On<string>("notify", message => Console.WriteLine("Do WCF {0}", message));
            hubConnection.Start().Wait();

            Console.ReadKey();
        }
    }
}
