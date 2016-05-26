using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConfigs
{
    class Program
    {
        static void Main(string[] args)
        {
            var trans = ConfigurationManager.AppSettings["transformar"];

            Console.WriteLine(trans);

            Console.Read();
        }
    }
}
