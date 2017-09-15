using System;
using System.Collections.Generic;

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
    }

    public interface IFeederService
    {
        IEnumerable<Feeder> GetAll();
    }

    public class Feeder
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IFeederRepository
    {
        IEnumerable<Feeder> GetAll();
    }
}
