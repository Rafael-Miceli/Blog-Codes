using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Data;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class FeederController : Controller
    {
        private readonly IFeederService _feederService;

        public FeederController(IFeederService feederService)
        {
            _feederService = feederService;
        }

        [HttpGet]
        public IEnumerable<Feeder> Get()
        {
            return _feederService.GetAll();
        }      

        [HttpPost]
        public void Post([FromBody]Feeder feeder)
        {
            
        }
       
    }
}
