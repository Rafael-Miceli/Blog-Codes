using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class FeederService: IFeederService
    {
        private readonly IFeederRepository _feederRepo;

        public FeederService(IFeederRepository feederRepo)
        {
            _feederRepo = feederRepo;    
        }

        public IEnumerable<Feeder> GetAll()
        {
            return _feederRepo.GetAll();
        }

        public void Create(Feeder feeder)
        {
            var feeders = GetAll();

            if(feeders.Any(f => f.Name == feeder.Name))
                throw new Exception("Feeder Already Exists");

            _feederRepo.Create(feeder);
        }
    }

    public interface IFeederService
    {
        IEnumerable<Feeder> GetAll();
        void Create(Feeder feeder);
    }

    public class Feeder
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Feeder(string name)
        {
            Name = name;
        }        
    }

    public interface IFeederRepository
    {
        IEnumerable<Feeder> GetAll();
        void Create(Feeder feeder);
    }
}
