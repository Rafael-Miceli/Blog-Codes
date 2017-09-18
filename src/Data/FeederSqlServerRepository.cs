using System;
using System.Collections.Generic;
using Domain;

namespace Data
{
    public class FeederSqlServerRepository: IFeederRepository
    {
        public IEnumerable<Feeder> GetAll()
        {
            return new List<Feeder> {
                new Feeder("Hello from SqlServer")                
            };
        }

        public void Create(Feeder feeder)
        {
            Console.WriteLine("Criando no SqlServer");
        }
    }
}
