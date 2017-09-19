using System;
using System.Collections.Generic;
using Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoData
{
    public class FeederMongoRepository: IFeederRepository
    {
        private IMongoDatabase _mongoDb;
        private IMongoCollection<Feeder> Feeders { get; set; }

        public FeederMongoRepository()
        {
            InitializeMongoDatabase();
            Feeders = _mongoDb.GetCollection<Feeder>("feeders");
        }        

        private void InitializeMongoDatabase()
        {
            try
            {
                //Caso você esteja usando docker-toolbox com VirtualBox descomente o código abaixo: 
                //Caso ainda tenha erro confirme o IP de saida da sua VM
                //var client = new MongoClient(@"mongodb://192.168.99.100:27017");
                var client = new MongoClient(@"mongodb://localhost:27017");
                _mongoDb = client.GetDatabase("local");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                _mongoDb = null; 
            }
        }

        public IEnumerable<Feeder> GetAll()
        {
            return Feeders.Find(_ => true).ToList();
        }

        public void Create(Feeder feeder)
        {
            Console.WriteLine("Criando no Mongo");
            Feeders.InsertOne(feeder);
        }
    }
}
