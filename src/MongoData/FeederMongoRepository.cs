using System;
using System.Collections.Generic;
using Domain;

namespace MongoData
{
    public class FeederMongoRepository: IFeederRepository
    {
        public IEnumerable<Feeder> GetAll()
        {
            return new List<Feeder> {
                new Feeder {
                    Id = 1,
                    Name = "Hello from Mongo"
                }
            };
        }
    }
}
