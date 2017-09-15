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
                new Feeder {
                    Id = 1,
                    Name = "Hello from SqlServer"
                }
            };
        }
    }
}
